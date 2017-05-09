using System;

public partial class Reportform_frequency_Lists_Excel : Web.UI.Permissions
{
    protected string starttime = "", endtime = "", cardNo = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        cardNo = Base.Fun.fun.NoCon(Base.Fun.Fetch.getpost("cardNo"));
        starttime = Base.Fun.Fetch.getpost("stime");
        endtime = Base.Fun.Fetch.getpost("etime");
        Web.UI.Reportform.frequency.ViewToExcel(StoresID, UserID, cardNo, starttime, endtime);
        Response.End();
    }
}