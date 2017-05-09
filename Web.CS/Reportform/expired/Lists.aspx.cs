using System;

public partial class Reportform_expired_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string starttime = "", endtime = "", souce = "", title="";
    protected string storesid = "";
    protected string storesname = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        storesid=Base.Fun.Fetch.getpost("storesid");
        if (Base.Fun.fun.pnumeric(storesid))
        {
            StoresID = storesid;
            storesname = "【" + Web.UI.Sys.stores.GetStoresName(storesid) + "】";
        }
        Web.UI.Users.ReadUserStoresID(StoresID);
        page = Base.Fun.Fetch.post("page");
        if (!Base.Fun.fun.pnumeric(page))
        {
            page = "1";
        }
        action = Base.Fun.Fetch.getpost("action");
        title = Server.UrlDecode(Base.Fun.Fetch.getpost("title"));
        starttime = Base.Fun.Fetch.getpost("stime");
        endtime = Base.Fun.Fetch.getpost("etime");
        souce = Base.Fun.Fetch.getpost("souce");
        if (starttime.Length == 0 && endtime.Length == 0)
        {
            starttime = endtime = DateTime.Now.ToString("yyyy-MM-dd");
        }
    }
}