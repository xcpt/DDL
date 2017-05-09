using System;

public partial class customer_UserConsumptionSatisfaction_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string ucid, cardNo, name, administratorid, statustime, endtime, adminstatustime, adminendtime;
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        page = Base.Fun.Fetch.post("page");
        if (!Base.Fun.fun.pnumeric(page))
        {
            page = "1";
        }
        action = Base.Fun.Fetch.getpost("action");
        ucid = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("ucid"));
        cardNo = Base.Fun.fun.NoCon(Base.Fun.Fetch.getpost("cardNo"));
        name = Base.Fun.fun.NoCon(Base.Fun.Fetch.getpost("name"));
        administratorid = Base.Fun.Fetch.getpost("administratorid");
        statustime = Base.Fun.Fetch.getpost("stime");
        endtime = Base.Fun.Fetch.getpost("etime");
        adminstatustime = Base.Fun.Fetch.getpost("astime");
        adminendtime = Base.Fun.Fetch.getpost("aetime");
    }
}