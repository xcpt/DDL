using System;

public partial class Sys_Stores_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string title = "", stime = "", etime = "", Province = "", City = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        page = Base.Fun.Fetch.post("page");
        if (!Base.Fun.fun.pnumeric(page))
        {
            page = "1";
        }
        action = Base.Fun.Fetch.getpost("action");
        title = Base.Fun.fun.NoCon(Server.UrlDecode(Base.Fun.Fetch.getpost("title")));
        stime = Base.Fun.fun.NoCon(Server.UrlDecode(Base.Fun.Fetch.getpost("stime")));
        etime = Base.Fun.fun.NoCon(Server.UrlDecode(Base.Fun.Fetch.getpost("etime")));
        Province = Base.Fun.fun.NoCon(Server.UrlDecode(Base.Fun.Fetch.getpost("Province")));
        City = Base.Fun.fun.NoCon(Server.UrlDecode(Base.Fun.Fetch.getpost("City")));
    }
}