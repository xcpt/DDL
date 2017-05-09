using System;

public partial class customer_CardLog_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string cardNo = "", starttime = "", endtime = "", cardlogtype = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        page = Base.Fun.Fetch.post("page");
        if (!Base.Fun.fun.pnumeric(page))
        {
            page = "1";
        }
        action = Base.Fun.Fetch.getpost("action");
        cardNo = Base.Fun.fun.NoCon(Server.UrlDecode(Base.Fun.Fetch.getpost("cardNo")));
        starttime = Base.Fun.Fetch.getpost("stime");
        endtime = Base.Fun.Fetch.getpost("etime");
        cardlogtype = Base.Fun.Fetch.getpost("cardlogtype");
    }
}