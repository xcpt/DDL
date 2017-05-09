using System;

public partial class Reportform_CardNumber_Lists_Excel : Web.UI.Permissions
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        string stime = Base.Fun.Fetch.getpost("stime");
        string etime = Base.Fun.Fetch.getpost("etime");
        Web.UI.Reportform.CardNumber.ViewToExcel(StoresID, UserID, stime, etime);
        Response.End();
    }
}