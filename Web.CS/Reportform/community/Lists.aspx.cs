using System;

public partial class Reportform_community_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string starttime = "", endtime = "", communityid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        page = Base.Fun.Fetch.post("page");
        if (!Base.Fun.fun.pnumeric(page))
        {
            page = "1";
        }
        action = Base.Fun.Fetch.getpost("action");
        communityid = Base.Fun.Fetch.getpost("communityid");
        starttime = Base.Fun.Fetch.getpost("stime");
        endtime = Base.Fun.Fetch.getpost("etime");
        if (starttime.Length == 0 && endtime.Length == 0)
        {
            starttime = endtime = DateTime.Now.ToString("yyyy-MM-dd");
        }
    }
}