using System;

public partial class Reportform_community_Lists_Excel : Web.UI.Permissions
{
    protected string starttime = "", endtime = "", communityid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        communityid = Base.Fun.Fetch.getpost("communityid");
        starttime = Base.Fun.Fetch.getpost("stime");
        endtime = Base.Fun.Fetch.getpost("etime");
        Web.UI.Reportform.community.ViewToExcel(StoresID, UserID, communityid, starttime, endtime);
        Response.End();
    }
}