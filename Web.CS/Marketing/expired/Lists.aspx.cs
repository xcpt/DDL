using System;

public partial class Marketing_expired_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string starttime = "", endtime = "";
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
        starttime = Base.Fun.Fetch.getpost("stime");
        endtime = Base.Fun.Fetch.getpost("etime");
        CardIsList = Web.UI.Users.CheckPermission("/customer/card/Lists.aspx", 1);
        MessageLogAdd = Web.UI.Users.CheckPermission("/mobile/MessageLog/Add.aspx", 4);
    }
}