using System;

public partial class Reportform_frequency_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string cardNo = "", starttime = "", endtime = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        page = Base.Fun.Fetch.post("page");
        if (!Base.Fun.fun.pnumeric(page))
        {
            page = "1";
        }
        action = Base.Fun.Fetch.getpost("action");
        cardNo = Base.Fun.fun.NoCon(Base.Fun.Fetch.getpost("cardNo"));
        starttime = Base.Fun.Fetch.getpost("stime");
        endtime = Base.Fun.Fetch.getpost("etime");
        if (starttime.Length == 0 && endtime.Length == 0)
        {
            endtime = DateTime.Now.ToString("yyyy-MM-dd");
            starttime = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
        }
    }
}