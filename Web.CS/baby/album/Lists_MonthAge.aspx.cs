using System;

public partial class baby_album_Lists_MonthAge : Web.UI.Permissions
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Base.Fun.Fetch.getpost("id").Replace(",", "");
        if (Base.Fun.fun.pnumeric(id))
        {
            Response.Write(Web.UI.customer.User.GetMonthday(id));
        }
        Response.End();
    }
}