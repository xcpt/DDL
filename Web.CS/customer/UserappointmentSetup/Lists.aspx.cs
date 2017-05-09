using System;

public partial class customer_UserappointmentSetup_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string babytype = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        page = Base.Fun.Fetch.post("page");
        if (!Base.Fun.fun.pnumeric(page))
        {
            page = "1";
        }
        action = Base.Fun.Fetch.getpost("action");
        babytype = Base.Fun.Fetch.getpost("babytype");
        if (!Base.Fun.fun.pnumeric(babytype))
        {
            babytype = "1";
        }
    }
}