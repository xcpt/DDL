using System;

public partial class score_exchange_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string title = "", userid = "", name = "", starttime = "", endtime = "";
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
        name = Base.Fun.fun.NoCon(Server.UrlDecode(Base.Fun.Fetch.getpost("name")));
        userid = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("userid"));
        starttime = Base.Fun.Fetch.getpost("stime");
        endtime = Base.Fun.Fetch.getpost("etime");
    }
}