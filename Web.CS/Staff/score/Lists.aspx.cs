using System;

public partial class Staff_score_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string memberid = "", isadd = "", type = "", starttime = "", endtime = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        page = Base.Fun.Fetch.post("page");
        if (!Base.Fun.fun.pnumeric(page))
        {
            page = "1";
        }
        action = Base.Fun.Fetch.getpost("action");
        memberid = Base.Fun.Fetch.getpost("memberid");
        isadd = Base.Fun.Fetch.getpost("isadd");
        type = Base.Fun.Fetch.getpost("type");
        starttime = Server.UrlDecode(Base.Fun.Fetch.getpost("stime"));
        endtime = Server.UrlDecode(Base.Fun.Fetch.getpost("etime"));
    }
}