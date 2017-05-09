using System;

public partial class Staff_swimteacher_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string memberid = "", isopen = "", iswww = "", departmentid = "";
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
        isopen = Base.Fun.Fetch.getpost("isopen");
        iswww = Base.Fun.Fetch.getpost("iswww");
        departmentid = Base.Fun.Fetch.getpost("departmentid");
    }
}