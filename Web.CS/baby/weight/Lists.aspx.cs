using System;

public partial class baby_weight_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string monthage = "", sex = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        page = Base.Fun.Fetch.post("page");
        if (!Base.Fun.fun.pnumeric(page))
        {
            page = "1";
        }
        action = Base.Fun.Fetch.getpost("action");
        monthage = Base.Fun.Fetch.getpost("monthage");
        sex = Base.Fun.Fetch.getpost("sex");
    }
}