using System;

public partial class customer_Card_Modi_Replace : Web.UI.Permissions
{
    protected string action = "";
    protected Web.Model.customer.Card cModel = new Web.Model.customer.Card();
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.customer.Card cDAL = new Web.DAL.customer.Card();
            cModel = cDAL.Read(id);
            if (cModel.cardid.Equals(id))
            {
                if (action.Equals("save"))
                {
                    string cardNo = Base.Fun.Fetch.getpost("CardNo");
                    string cardNumber = Base.Fun.Fetch.getpost("CardNumber");
                    if (cardNo.Length > 0)
                    {
                        if (!cardNo.Equals(cModel.cardNo))
                        {
                            if (Web.UI.customer.Card.IsCardIs(StoresID, cardNo, cardNumber))
                            {
                                SyCms.Window.WindowsReturn.WindowsReturnAlert("会员卡号或卡序号已经存在");
                            }
                            else
                            {
                                if (cDAL.Update_CardNo(id, cardNo, cardNumber) > 0)
                                {
                                    Base.Log.Log.Add(2, "customer_Card", id);
                                    Web.DAL.customer.User uDAL = new Web.DAL.customer.User();
                                    uDAL.Update_PassWord(id, Base.Fun.Md5.MD5(cardNo));
                                    Web.UI.customer.CardNoLog.AddCardNoLog(StoresID, cModel.cardNo, cardNo);
                                    SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "换卡成功，卡号：" + cardNo, true);
                                    Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("CardGrid", id, true));
                                }
                                else
                                {
                                    SyCms.Window.WindowsReturn.WindowsReturnAlert("换卡失败");
                                }
                            }
                        }
                        else
                        {
                            SyCms.Window.WindowsReturn.WindowsReturnAlert("原卡与新卡一样，无需换卡。");
                        }
                    }
                    Response.End();
                }
                else
                {
                    if (cModel.cardstatus.Equals("-1"))
                    {
                        SyCms.Window.WindowsReturn.WindowsReturnAlert("此卡已停，不能换卡，请先开卡。");
                        Response.End();
                    }
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("会员卡项错误");
                Response.End();
            }
        }
        else
        {
            SyCms.Window.WindowsReturn.WindowsReturnAlert("参数传递错误");
            Response.End();
        }
    }
}