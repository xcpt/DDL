using System;

public partial class Reportform_communityCard_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string starttime = "", endtime = "", cardtypeid = "", communityid="";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        page = Base.Fun.Fetch.post("page");
        if (!Base.Fun.fun.pnumeric(page))
        {
            page = "1";
        }
        action = Base.Fun.Fetch.getpost("action");
        starttime = Base.Fun.Fetch.getpost("stime");
        endtime = Base.Fun.Fetch.getpost("etime");
        cardtypeid = Base.Fun.Fetch.getpost("cardtypeid");
        communityid = Base.Fun.Fetch.getpost("communityid");
        if (starttime.Length == 0 && endtime.Length == 0)
        {
            starttime = endtime = DateTime.Now.ToString("yyyy-MM-dd");
        }
    }
}