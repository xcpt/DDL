using System;

public partial class baby_height_Lists_Chart : Web.UI.Permissions
{
    protected string sex = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        sex = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("sex"));
    }
}