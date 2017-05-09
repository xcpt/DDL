using System;

public partial class Sys_Message_Lists :Web.UI.Permissions
{
    protected string  name, saddtime, eaddtime, supdatetime, eupdatetime, state;
    protected string action = "",page="";
    protected bool MessageLogAdd = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        page = Base.Fun.Fetch.post("page");
        if (!Base.Fun.fun.pnumeric(page))
        {
            page = "1";
        }
        action = Base.Fun.Fetch.getpost("action");
        name = Server.UrlDecode(Base.Fun.Fetch.getpost("name"));
        saddtime = Base.Fun.Fetch.getpost("saddtime");
        eaddtime = Base.Fun.Fetch.getpost("eaddtime");
        supdatetime = Base.Fun.Fetch.getpost("supdatetime");
        eupdatetime = Base.Fun.Fetch.getpost("eupdatetime");
        state = Base.Fun.Fetch.getpost("state");
        MessageLogAdd = Web.UI.Users.CheckPermission("/mobile/MessageLog/Add.aspx", 4);
    }
}