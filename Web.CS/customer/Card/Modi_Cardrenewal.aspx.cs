using System;
using System.Text;

public partial class customer_Card_Modi_Cardrenewal : Web.UI.Permissions
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
                    string cardtypeid = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("cardtypeid"));
                    StringBuilder str = new StringBuilder();
                    Web.DAL.customer.CardType ctDAL=new Web.DAL.customer.CardType();
                    Web.Model.customer.CardType oldCt = ctDAL.Read(cModel.cardtypeid);
                    Web.Model.customer.CardType newCt = ctDAL.Read(cardtypeid);
                    if (oldCt.paidmode.Equals(newCt.paidmode))
                    {
                        Web.Model.customer.CardLog clModel = new Web.Model.customer.CardLog();
                        clModel.storesid = StoresID;
                        clModel.cardid = id;
                        clModel.cardlogtype = "1";
                        clModel.oldcardtype = oldCt.title;
                        clModel.newcardtype = newCt.title;

                        str.Append("原卡：" + oldCt.title + "；");
                        str.Append("续卡："+newCt.title+"；");
                        cModel.cardtypeid = cardtypeid;
                        clModel.oldendtime = cModel.endtime;
                        if (Base.Time.Time.TimeBad(DateTime.Now.ToString(), cModel.endtime, "天") >= 0)
                        {
                            cModel.endtime = DateTime.Parse(cModel.endtime).AddMonths(int.Parse(newCt.effectivetime)).ToString();
                        }
                        else
                        {
                            cModel.endtime = DateTime.Now.AddMonths(int.Parse(newCt.effectivetime)).ToString();
                        }
                        
                        clModel.newendtime = cModel.endtime;
                        if (newCt.paidmode.Equals("0"))
                        {
                            clModel.oldnum = cModel.surpluspositivenum + "/" + cModel.surplusnegativenum;
                            clModel.newnum = (int.Parse(cModel.surpluspositivenum) + int.Parse(newCt.positivenum)).ToString() + "/" + (int.Parse(cModel.surplusnegativenum) + int.Parse(newCt.negativenum)).ToString();
                            clModel.oldprice = cModel.price;
                            clModel.newprice = (double.Parse(cModel.price) + double.Parse(newCt.price)).ToString();
                            cModel.positivenum = newCt.positivenum;
                            cModel.negativenum = newCt.negativenum;
                            str.Append("正价次数：" + newCt.positivenum + "；");
                            str.Append("赠送次数：" + newCt.negativenum + "；");
                            cModel.price = newCt.price;
                        }
                        else
                        {
                            str.Append("增加金额：" + newCt.price + "；");
                            cModel.positivenum = "0";
                            cModel.negativenum = "0";
                            clModel.oldprice = cModel.price;
                            clModel.newprice = (double.Parse(cModel.price) + double.Parse(newCt.price)).ToString(); ;
                            cModel.price = clModel.newprice;
                        }
                        if (cDAL.Update(cModel) > 0)
                        {
                            Web.Model.customer.User uModel = new Web.DAL.customer.User().Read1_CardID(cModel.cardid);
                            if(Base.Fun.fun.pnumeric(uModel.userid))
                            {
                                //变更卡类型的时候增加金额
                                Web.UI.customer.User_Card_Log.AddPrice(StoresID, uModel.userid, int.Parse(cModel.positivenum) + int.Parse(cModel.negativenum), cModel.cardtypeid);
                                //增
                                Web.UI.customer.User_Stores.AddStores(StoresID, uModel.userid, int.Parse(cModel.positivenum), int.Parse(cModel.negativenum), cModel.cardtypeid);
                            }
                            Base.Log.Log.Add(2, "customer_Card", id);
                            Web.UI.customer.CardLog.AddCardLog(clModel);
                            SyCms.Window.WindowsReturn.WindowsReturnAlert(true, str.ToString(), true);
                            Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("CardGrid", id, true));
                        }
                        else
                        {
                            SyCms.Window.WindowsReturn.WindowsReturnAlert("续卡失败");
                        }
                    }
                    else
                    {
                        if (oldCt.paidmode.Equals("0"))
                        {
                            if (double.Parse(cModel.surplusnum) > 0)
                            {
                                SyCms.Window.WindowsReturn.WindowsReturnAlert(false, "错误：持卡类型与续卡类型消费方式不同，持卡次数为：" + cModel.surplusnum + "；不能强制续卡。", true);
                            }
                        }
                        else
                        {
                            if (double.Parse(cModel.surplusprice) > 0)
                            {
                                SyCms.Window.WindowsReturn.WindowsReturnAlert(false, "错误：持卡类型与续卡类型消费方式不同，持卡金额为：" + cModel.surplusprice + "；不能强制续卡。", true);
                            }
                        }
                    }
                    Response.End();
                }
                else
                {
                    if (cModel.cardstatus.Equals("-1"))
                    {
                        SyCms.Window.WindowsReturn.WindowsReturnAlert("此卡已停，请先开卡。");
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