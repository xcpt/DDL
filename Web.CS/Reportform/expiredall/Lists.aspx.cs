using System;

public partial class Reportform_expiredall_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string starttime = "", endtime = "", souce = "", title = "";
    protected void Page_Load(object sender, EventArgs e)
    {
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