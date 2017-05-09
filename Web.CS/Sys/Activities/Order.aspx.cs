using System;

public partial class Sys_Activities_Order : Web.UI.Permissions
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string OrderID = Base.Fun.Fetch.getpost("OrderID");
        if (Base.Fun.fun.pnumeric(OrderID.Replace(",", "")))
        {
            Web.UI.Sys.News.SetOrder(OrderID);
        }
        Response.End();
    }
}