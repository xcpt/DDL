using System;

public partial class Reportform_communityCard_Lists_Excel : Web.UI.Permissions
{
    protected string starttime = "", endtime = "", cardtypeid = "", communityid="";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        starttime = Base.Fun.Fetch.getpost("stime");
        endtime = Base.Fun.Fetch.getpost("etime");
        cardtypeid = Base.Fun.Fetch.getpost("cardtypeid");
        communityid = Base.Fun.Fetch.getpost("communityid");
        Web.UI.Reportform.communityCard.ViewToExcel(StoresID, communityid, UserID, starttime, endtime, cardtypeid);
        Response.End();
    }
}