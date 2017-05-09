using System;

public partial class Reportform_communityCommodity_Lists_Excel : Web.UI.Permissions
{
    protected string starttime = "", endtime = "", CommodityID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        starttime = Base.Fun.Fetch.getpost("stime");
        endtime = Base.Fun.Fetch.getpost("etime");
        CommodityID = Base.Fun.Fetch.getpost("CommodityID");
        Web.UI.Reportform.communityCommodity.ViewToExcel(StoresID, UserID, starttime, endtime, CommodityID);
        Response.End();
    }
}