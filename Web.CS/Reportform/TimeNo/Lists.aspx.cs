using System;

public partial class Reportform_TimeNo_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string num1 = "", num2 = "";
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
        num1 = Base.Fun.Fetch.getpost("num");
        num2 = Base.Fun.Fetch.getpost("lastnum");
        MessageLogAdd = Web.UI.Users.CheckPermission("/mobile/MessageLog/Add.aspx", 4);
    }
}