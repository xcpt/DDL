using System;

public partial class Reportform_Consumption_Lists_Excel : Web.UI.Permissions
{
    protected string starttime = "", endtime = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        starttime = Base.Fun.Fetch.getpost("stime");
        endtime = Base.Fun.Fetch.getpost("etime");
        if (starttime.Length == 0 && endtime.Length == 0)
        {
            endtime = DateTime.Now.ToString("yyyy-MM-dd");
            starttime = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
        }
        if (!Base.Fun.fun.IsDate(starttime))
        {
            SyCms.Window.WindowsReturn.WindowsReturnAlert("开始时间必须填写。");
            Response.End();
        }
        if (!Base.Fun.fun.IsDate(endtime))
        {
            SyCms.Window.WindowsReturn.WindowsReturnAlert("结束时间必须填写。");
            Response.End();
        }
        Web.UI.Reportform.Consumption.View_ToExcel(StoresID, UserID, starttime, endtime);
        Response.End();
    }
}