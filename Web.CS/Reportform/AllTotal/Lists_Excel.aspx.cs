using System;

public partial class Reportform_AllTotal_Lists_Excel : Web.UI.Permissions
{
    protected string starttime = "", endtime = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        starttime = Base.Fun.Fetch.getpost("stime");
        endtime = Base.Fun.Fetch.getpost("etime");
        Web.UI.Reportform.AllTotal.ViewToExcel(StoresID, UserID, starttime, endtime);
        Response.End();
    }
}