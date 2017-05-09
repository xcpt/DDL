using System;

public partial class Sys_News_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string title = "";
    protected string classid = "";
    protected string classname = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        page = Base.Fun.Fetch.post("page");
        if (!Base.Fun.fun.pnumeric(page))
        {
            page = "1";
        }
        action = Base.Fun.Fetch.getpost("action");
        classid = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("classid"));
        classname = Base.Fun.fun.NoSql(Base.Fun.Fetch.getpost("classname"));
        if (classname.Length == 0)
        {
            classname = "育儿知识";
        }
        title = Base.Fun.fun.NoCon(Server.UrlDecode(Base.Fun.Fetch.getpost("title")));
    }
}