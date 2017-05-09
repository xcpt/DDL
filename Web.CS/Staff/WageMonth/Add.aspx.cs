using System;

public partial class Staff_WageMonth_Add : Web.UI.Permissions
{
    protected string action = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        if (action.Equals("save"))
        {
            string datetime = Base.Fun.Fetch.getpost("datetime");
            if (Base.Fun.fun.pnumeric(datetime))
            {
                if (double.Parse(datetime) >= double.Parse(DateTime.Now.ToString("yyyyMM")))
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert("本月还没有结束，暂不能生成本月工资。");
                }
                else
                {
                    Web.UI.Staff.WageMonth.SendWage(StoresID, datetime);
                    SyCms.Window.WindowsReturn.WindowsReturnAlert(true, datetime + " 工资生成成功。");
                    Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("WageMonthGrid", true));
                }
            }
            Response.End();
        }
    }
}