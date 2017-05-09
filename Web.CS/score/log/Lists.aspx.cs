using System;

public partial class score_log_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string name = "", starttime = "", endtime = "",mobile="", type="";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        page = Base.Fun.Fetch.post("page");
        if (!Base.Fun.fun.pnumeric(page))
        {
            page = "1";
        }
        action = Base.Fun.Fetch.getpost("action");
        name = Base.Fun.fun.NoCon(Server.UrlDecode(Base.Fun.Fetch.getpost("name")));
        mobile = Base.Fun.fun.NoCon(Base.Fun.Fetch.getpost("mobile"));
        type = Base.Fun.Fetch.getpost("type");
        starttime = Base.Fun.Fetch.getpost("stime");
        endtime = Base.Fun.Fetch.getpost("etime");
    }
}