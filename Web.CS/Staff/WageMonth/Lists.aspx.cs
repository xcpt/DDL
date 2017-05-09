using System;

public partial class Staff_WageMonth_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string memberid = "", datetime = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        page = Base.Fun.Fetch.post("page");
        if (!Base.Fun.fun.pnumeric(page))
        {
            page = "1";
        }
        action = Base.Fun.Fetch.getpost("action");
        memberid = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("memberid"));
        datetime = Server.UrlDecode(Base.Fun.Fetch.getpost("datetime"));
    }
}