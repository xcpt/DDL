using System;

public partial class Mobile_MessageLog_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string mobile = "", title = "", statustime = "", endtime = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        page = Base.Fun.Fetch.post("page");
        if (!Base.Fun.fun.pnumeric(page))
        {
            page = "1";
        }
        action = Base.Fun.Fetch.getpost("action");
        mobile = Base.Fun.Fetch.getpost("mobile");
        title = Base.Fun.fun.NoCon(Server.UrlDecode(Base.Fun.Fetch.getpost("title")));
        statustime = Base.Fun.Fetch.getpost("stime");
        endtime = Base.Fun.Fetch.getpost("etime");
    }
}