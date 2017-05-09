using System;

public partial class customer_UserConsumption_Lists_Cancel : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string cardNo, userid, name, cycletype, swimteacherid, CommodityID, satisfactionid, statustime, endtime, cancelstatustime, cancelendtime;
    protected bool MessageLogIsAdd = false;
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
        userid = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("userid"));
        name = Base.Fun.fun.NoCon(Base.Fun.Fetch.getpost("name"));
        cycletype = Base.Fun.Fetch.getpost("cycletype");
        swimteacherid = Base.Fun.Fetch.getpost("swimteacherid");
        satisfactionid = Base.Fun.Fetch.getpost("satisfactionid");
        CommodityID = Base.Fun.Fetch.getpost("CommodityID");
        statustime = Base.Fun.Fetch.getpost("stime");
        endtime = Base.Fun.Fetch.getpost("etime");
        cancelstatustime = Base.Fun.Fetch.getpost("cstime");
        cancelendtime = Base.Fun.Fetch.getpost("cetime");
    }
}