using System;

public partial class Marketing_Potential_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string name = "", nickname = "", communityid = "", mobile = "", cycletype = "", ReturnresultID = "", statusmonthnum = "", endmonthnum = "";
    protected bool MessageLogAdd = false;
    protected bool IsVisitIsAdd = false;
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
        nickname = Base.Fun.fun.NoCon(Server.UrlDecode(Base.Fun.Fetch.getpost("nickname")));
        communityid = Base.Fun.Fetch.getpost("communityid");
        mobile = Base.Fun.fun.NoCon(Base.Fun.Fetch.getpost("mobile"));
        cycletype = Base.Fun.Fetch.getpost("cycletype");
        ReturnresultID = Base.Fun.Fetch.getpost("ReturnresultID");
        statusmonthnum = Base.Fun.Fetch.getpost("statusmonthnum");
        endmonthnum = Base.Fun.Fetch.getpost("endmonthnum");
        MessageLogAdd = Web.UI.Users.CheckPermission("/mobile/MessageLog/Add.aspx", 4);

        IsVisitIsAdd = Web.UI.Users.CheckPermission("/Marketing/Visit/Add.aspx", 4);
    }
}