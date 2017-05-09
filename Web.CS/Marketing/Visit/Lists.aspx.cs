using System;

public partial class Marketing_Visit_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string userid, name, ReturnresultID, IsGiveup, memberid, starttime, endtime = "";
    protected bool MessageLogAdd = false;
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
        name = Base.Fun.fun.NoCon(Server.UrlDecode(Base.Fun.Fetch.getpost("name")));
        IsGiveup = Base.Fun.Fetch.getpost("IsGiveup");
        starttime = Base.Fun.Fetch.getpost("stime");
        endtime = Base.Fun.Fetch.getpost("etime");
        ReturnresultID = Base.Fun.Fetch.getpost("ReturnresultID");
        memberid = Base.Fun.Fetch.getpost("memberid");
        MessageLogAdd = Web.UI.Users.CheckPermission("/mobile/MessageLog/Add.aspx", 4);
    }
}