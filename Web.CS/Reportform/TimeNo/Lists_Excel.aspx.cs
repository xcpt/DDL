using System;

public partial class Reportform_TimeNo_Lists_Excel : Web.UI.Permissions
{
    protected string num1 = "", num2 = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        num1 = Base.Fun.Fetch.getpost("num");
        num2 = Base.Fun.Fetch.getpost("lastnum");
        Web.UI.Reportform.TimeNo.ViewToExcel(StoresID, UserID, num1, num2);
        Response.End();
    }
}