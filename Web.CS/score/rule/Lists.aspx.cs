using System;

public partial class score_rule_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string title = "", starttime = "", endtime = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        page = Base.Fun.Fetch.post("page");
        if (!Base.Fun.fun.pnumeric(page))
        {
            page = "1";
        }
        action = Base.Fun.Fetch.getpost("action");
        title = Base.Fun.fun.NoCon(Server.UrlDecode(Base.Fun.Fetch.getpost("title")));
        starttime = Base.Fun.Fetch.getpost("stime");
        endtime = Base.Fun.Fetch.getpost("etime");
    }
}