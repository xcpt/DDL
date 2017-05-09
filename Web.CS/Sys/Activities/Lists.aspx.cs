using System;

public partial class Sys_Activities_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string classid = "";
    protected string classname = "";
    protected string title = "";
    protected string StoresID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        page = Base.Fun.Fetch.post("page");
        if (!Base.Fun.fun.pnumeric(page))
        {
            page = "1";
        }
        action = Base.Fun.Fetch.getpost("action");
        classid = Base.Fun.Fetch.getpost("classid");
        StoresID = Base.Fun.Fetch.getpost("StoresID");
        if (!Base.Fun.fun.pnumeric(classid))
        {
            SyCms.Window.WindowsReturn.WindowsReturnAlert("参数错误");
            Response.End();
        }
        classname = Base.Fun.Fetch.getpost("classname");
        title = Base.Fun.fun.NoCon(Server.UrlDecode(Base.Fun.Fetch.getpost("title")));
    }
}