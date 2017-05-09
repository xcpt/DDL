using System;

public partial class customer_CardType_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string title = "", paidmode = "", businessid = "";
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
        paidmode = Base.Fun.Fetch.getpost("paidmode");
        businessid = Base.Fun.Fetch.getpost("businessid");
    }
}