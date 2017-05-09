using System;

public partial class Sys_Category_Lists : Web.UI.Permissions
{
    protected string type = "", typename = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        type = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("type"));
        typename = Base.Fun.Fetch.getpost("typename");

    }
}