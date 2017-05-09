using System;

public partial class baby_Cycle_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string title="", type = "";
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
        type = Base.Fun.Fetch.getpost("type");
    }
}