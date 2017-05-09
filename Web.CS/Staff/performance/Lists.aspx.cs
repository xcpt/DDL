using System;

public partial class Staff_performance_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string memberid = "", statustime = "", endtime = "";
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
        statustime = Base.Fun.Fetch.getpost("stime");
        endtime = Base.Fun.Fetch.getpost("etime");
    }
}