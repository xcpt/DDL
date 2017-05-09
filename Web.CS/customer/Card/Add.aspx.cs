using System;

public partial class customer_Card_Add : Web.UI.Permissions
{
    protected string action = "";
    protected string userid = "";
    protected string content = "";
    protected string cardNo = "";
    protected string cardNumber = "";
    protected string IsAddCard = "";
    protected bool cardTypeIsAdd = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        userid = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("id").Trim(','));
        cardNo = Base.Fun.Fetch.getpost("cardNo");
        cardNumber = Base.Fun.Fetch.getpost("cardNumber");
        action = Base.Fun.Fetch.getpost("action");
        IsAddCard = Base.Fun.Fetch.getpost("IsAddCard");
        if (action.Equals("save"))
        {
            if (Base.Fun.fun.pnumeric(userid))
            { 
                if (cardNo.Length > 0)
                {
                    Web.DAL.customer.Card cDAL = new Web.DAL.customer.Card();
                    if (Web.UI.customer.Card.IsCardIs(StoresID, cardNo, cardNumber))
                    {
                        SyCms.Window.WindowsReturn.WindowsReturnAlert("会员卡号或卡序号已经存在");
                    }
                    else
                    {
                        string openCardScore = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("openCardScore"));
                        string content = Base.Fun.Fetch.getpost("content");
                        Web.Model.customer.Card cModel = new Web.Model.customer.Card();
                        cModel.storesid = StoresID;
                        cModel.cardNo = cardNo;
                        cModel.cardNumber = cardNumber;
                        cModel.cardtypeid = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("cardtypeid"));
                        cModel.surpluspositivenum = cModel.positivenum = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("positivenum"));
                        cModel.surplusnegativenum = cModel.negativenum = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("negativenum"));
                        cModel.isclose = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("isclose"));
                        cModel.surplusnum = (int.Parse(cModel.positivenum) + int.Parse(cModel.negativenum)).ToString();
                        cModel.surplusprice = cModel.price = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("price"));
                        cModel.starttime = Base.Fun.Fetch.getpost("starttime");
                        cModel.endtime = Base.Fun.Fetch.getpost("endtime");
                        string CardID = cDAL.Insert(cModel);
                        if (Base.Fun.fun.pnumeric(CardID))
                        {
                            if (Base.Fun.fun.pnumeric(openCardScore))
                            {
                                Web.UI.score.log.AddLog(StoresID, userid, "0", openCardScore, "开卡送积分");
                            }
                            Web.Model.customer.CardLog clModel = new Web.Model.customer.CardLog();
                            clModel.storesid = StoresID;
                            clModel.cardid = CardID;
                            clModel.cardlogtype = "3";
                            clModel.newcardtype = Web.UI.customer.CardType.GetName(cModel.cardtypeid);
                            clModel.newnum = cModel.positivenum + "/" + cModel.negativenum;
                            clModel.newprice = cModel.price;
                            Web.UI.customer.CardLog.AddCardLog(clModel);
                            Web.DAL.customer.User uDAL = new Web.DAL.customer.User();
                            uDAL.Update_CordIDAndContent(userid, CardID, content);
                            uDAL.Update_PassWord(userid, Base.Fun.Md5.MD5(cardNo.Substring(cardNo.Length - 6)));

                            //增加记录开卡金额记录
                            Web.UI.customer.User_Card_Log.AddPrice(cModel.storesid, userid, int.Parse(cModel.surplusnum), cModel.cardtypeid);
                            //增加卡次
                            Web.UI.customer.User_Stores.AddStores(cModel.storesid, userid, int.Parse(cModel.positivenum), int.Parse(cModel.negativenum), cModel.cardtypeid);
                            Base.Log.Log.Add(1, "customer_Card", CardID);
                            SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "会员卡建卡成功。<br/>APP登录信息<br/>用户名为：会员手机号<br/>密码为：" + cardNo.Substring(cardNo.Length - 6), true);
                            string winlist = Base.Fun.Fetch.getpost("winlist");
                            if (winlist.Equals("user"))
                            {
                                Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("UserGrid", userid, true));
                            }
                            else
                            {
                                Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("CardGrid", CardID, true));
                            }
                        }
                        else
                        {
                            SyCms.Window.WindowsReturn.WindowsReturnAlert("会员卡添加失败。");
                        }
                    }
                }
                else
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert("会员卡信息没有填写");
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("会员必须选择");
            }
            Response.End();
        }
        else
        {
            cardTypeIsAdd = Web.UI.Users.CheckPermission("/customer/CardType/Add.aspx", 4);
            if (Base.Fun.fun.pnumeric(userid))
            {
                Web.DAL.customer.User uDAL = new Web.DAL.customer.User();
                Web.Model.customer.User uModel = uDAL.Read(StoresID, userid);
                content = uModel.content;
                if (Base.Fun.fun.pnumeric(uModel.cardid))
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert("错误：会员已经建卡。");
                    Response.End();
                }
            }
        }
    }
}