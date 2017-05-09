using System;

public partial class Marketing_consult_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string starttime = "", endtime = "";
    protected bool MessageLogAdd = false;
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
        MessageLogAdd = Web.UI.Users.CheckPermission("/mobile/MessageLog/Add.aspx", 4);
    }
}