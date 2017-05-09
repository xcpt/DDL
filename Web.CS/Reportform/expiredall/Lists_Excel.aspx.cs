using System;

public partial class Reportform_expiredall_Lists_Excel : Web.UI.Permissions
{
    protected string starttime = "", endtime = "", souce = "", title = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        title = Server.UrlDecode(Base.Fun.Fetch.getpost("title"));
        starttime = Base.Fun.Fetch.getpost("stime");
        endtime = Base.Fun.Fetch.getpost("etime");
        souce = Base.Fun.Fetch.getpost("souce");
        Web.UI.Reportform.expiredall.ViewToExcel(UserID, title, starttime, endtime, souce);
        Response.End();
    }
}