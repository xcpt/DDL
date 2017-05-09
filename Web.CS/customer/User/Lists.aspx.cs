using System;

public partial class customer_User_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string cardNo = "", name = "", communityid = "", mobile = "", cardtypeid = "", nickname = "", cycletype = "", cardstatus="", statusmonthnum = "", endmonthnum = "", statusdaynum = "", enddaynum = "", statusbirthday = "", endbirthday = "", loginnum = "", startnum = "", endnum = "";
    protected bool CardIsAdd = false;
    protected bool CardIsList = false;
    protected bool MessageLogAdd = false;
    protected bool scoreIsAdd = false;
    protected bool exchangeIsList = false;
    protected bool exchangeIsAdd = false;
    protected bool UserappointmentIsAdd = false;
    protected bool UserappointmentIsList = false;
    protected bool UserConsumptionIsAdd = false;
    protected bool UserConsumptionIsList = false;
    protected bool albumIsAdd = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        page = Base.Fun.Fetch.post("page");
        if (!Base.Fun.fun.pnumeric(page))
        {
            page = "1";
        }
        action = Base.Fun.Fetch.getpost("action");
        cardNo = Base.Fun.fun.NoCon(Base.Fun.Fetch.getpost("cardNo"));
        name = Base.Fun.fun.NoCon(Server.UrlDecode(Base.Fun.Fetch.getpost("name")));
        mobile = Base.Fun.fun.NoCon(Base.Fun.Fetch.getpost("mobile"));
        nickname = Base.Fun.fun.NoCon(Server.UrlDecode(Base.Fun.Fetch.getpost("nickname")));
        cardtypeid = Base.Fun.Fetch.getpost("cardtypeid");
        cardstatus = Base.Fun.Fetch.getpost("cardstatus");
        communityid = Base.Fun.Fetch.getpost("communityid");
        cycletype = Base.Fun.Fetch.getpost("cycletype");
        startnum = Base.Fun.Fetch.getpost("startnum");
        endnum = Base.Fun.Fetch.getpost("endnum");
        statusmonthnum = Base.Fun.Fetch.getpost("statusmonthnum");
        endmonthnum = Base.Fun.Fetch.getpost("endmonthnum");
        statusdaynum = Base.Fun.Fetch.getpost("statusdaynum");
        enddaynum = Base.Fun.Fetch.getpost("enddaynum");
        statusbirthday = Base.Fun.Fetch.getpost("stime");
        endbirthday = Base.Fun.Fetch.getpost("etime");
        loginnum = Base.Fun.Fetch.getpost("loginnum");
        CardIsAdd = Web.UI.Users.CheckPermission("/customer/card/Add.aspx", 4);
        CardIsList = Web.UI.Users.CheckPermission("/customer/card/Lists.aspx",1);
        MessageLogAdd = Web.UI.Users.CheckPermission("/mobile/MessageLog/Add.aspx", 4);
        scoreIsAdd = Web.UI.Users.CheckPermission("/score/log/Add.aspx", 4);
        exchangeIsList = Web.UI.Users.CheckPermission("/score/exchange/Lists.aspx", 1);
        exchangeIsAdd = Web.UI.Users.CheckPermission("/score/exchange/Add.aspx", 4);
        UserappointmentIsAdd = Web.UI.Users.CheckPermission("/customer/Userappointment/Add.aspx", 4);
        UserappointmentIsList = Web.UI.Users.CheckPermission("/customer/Userappointment/Lists.aspx", 1);

        UserConsumptionIsAdd = Web.UI.Users.CheckPermission("/customer/UserConsumption/Add.aspx", 4);
        UserConsumptionIsList = Web.UI.Users.CheckPermission("/customer/UserConsumption/Lists.aspx", 1);

        albumIsAdd = Web.UI.Users.CheckPermission("/baby/album/Add.aspx", 4);
    }
}