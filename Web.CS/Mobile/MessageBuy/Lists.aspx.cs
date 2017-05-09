using System;

public partial class Mobile_MessageBuy_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string setupid = "", status = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        page = Base.Fun.Fetch.post("page");
        if (!Base.Fun.fun.pnumeric(page))
        {
            page = "1";
        }
        action = Base.Fun.Fetch.getpost("action");
        setupid = Base.Fun.Fetch.getpost("setupid");
        status = Base.Fun.Fetch.getpost("status");
    }
}