using System;

public partial class Mobile_MessageTemplate_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string title = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        page = Base.Fun.Fetch.post("page");
        if (!Base.Fun.fun.pnumeric(page))
        {
            page = "1";
        }
        action = Base.Fun.Fetch.getpost("action");
        title = Base.Fun.fun.NoCon(Server.UrlDecode(Base.Fun.Fetch.getpost("title")));
    }
}