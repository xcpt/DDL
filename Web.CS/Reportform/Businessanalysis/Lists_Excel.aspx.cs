using System;

public partial class Reportform_Businessanalysis_Lists_Excel : Web.UI.Permissions
{
    protected string starttime = "", endtime = "", souce = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        starttime = Base.Fun.Fetch.getpost("stime");
        endtime = Base.Fun.Fetch.getpost("etime");
        souce = Base.Fun.Fetch.getpost("souce");
        Web.UI.Reportform.Businessanalysis.ViewToExcel(StoresID, UserID, starttime, endtime, souce);
        Response.End();
    }
}