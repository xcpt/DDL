using System;

public partial class baby_album_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string userid = "", CardNo = "", MonthAge = "", starttime = "", endtime = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        page = Base.Fun.Fetch.post("page");
        if (!Base.Fun.fun.pnumeric(page))
        {
            page = "1";
        }
        action = Base.Fun.Fetch.getpost("action");
        userid = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("userid"));
        CardNo = Base.Fun.fun.NoCon(Server.UrlDecode(Base.Fun.Fetch.getpost("CardNo")));
        MonthAge = Base.Fun.Fetch.getpost("MonthAge");
        starttime = Base.Fun.Fetch.getpost("stime");
        endtime = Base.Fun.Fetch.getpost("etime");
    }
}