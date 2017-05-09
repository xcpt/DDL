using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class customer_CardNoLog_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string OldcardNo = "", NewcardNo = "", starttime = "", endtime = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        page = Base.Fun.Fetch.post("page");
        if (!Base.Fun.fun.pnumeric(page))
        {
            page = "1";
        }
        action = Base.Fun.Fetch.getpost("action");
        OldcardNo = Base.Fun.fun.NoCon(Server.UrlDecode(Base.Fun.Fetch.getpost("OldcardNo")));
        NewcardNo = Base.Fun.fun.NoCon(Server.UrlDecode(Base.Fun.Fetch.getpost("NewcardNo")));
        starttime = Base.Fun.Fetch.getpost("stime");
        endtime = Base.Fun.Fetch.getpost("etime");
    }
}