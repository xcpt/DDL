using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Staff_member_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string name = "", status = "", departmentid = "";
    protected bool WageMonthIsAdd = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        page = Base.Fun.Fetch.post("page");
        if (!Base.Fun.fun.pnumeric(page))
        {
            page = "1";
        }
        action = Base.Fun.Fetch.getpost("action");
        name = Base.Fun.fun.NoCon(Server.UrlDecode(Base.Fun.Fetch.getpost("name")));
        status = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("status"));
        departmentid = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("departmentid"));
        WageMonthIsAdd = Web.UI.Users.CheckPermission("/Staff/WageMonth/Lists.aspx", 1);
    }
}