using System;

public partial class Reportform_CardNumber_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "", stime = "", etime = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        page = Base.Fun.Fetch.post("page");
        if (!Base.Fun.fun.pnumeric(page))
        {
            page = "1";
        }
        action = Base.Fun.Fetch.getpost("action");
        stime = Base.Fun.Fetch.getpost("stime");
        etime = Base.Fun.Fetch.getpost("etime");
    }
}