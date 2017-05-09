using System;

public partial class customer_UserConsumptionStores_Add : Web.UI.Permissions
{
    protected string action = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        action = Base.Fun.Fetch.getpost("action");
        if (action.Equals("save"))
        {
            string datetime = Base.Fun.Fetch.getpost("datetime");
            if (datetime.Length > 0)
            {
                datetime += "-1";
                if (Base.Fun.fun.IsDate(datetime))
                {
                    if (double.Parse(DateTime.Parse(datetime).ToString("yyyyMM")) >= double.Parse(DateTime.Now.ToString("yyyyMM")))
                    {
                        SyCms.Window.WindowsReturn.WindowsReturnAlert("本月还没有结束，暂不能结算。");
                    }
                    else
                    {
                        Web.DAL.customer.User_Stores_Consumption uscDAL = new Web.DAL.customer.User_Stores_Consumption();
                        int icount = uscDAL.Update_IsClose(StoresID, datetime);
                        SyCms.Window.WindowsReturn.WindowsReturnAlert(true, datetime + " 结算成功，结算" + icount.ToString() + "条。");
                        Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("UserConsumptionStoresGrid", true));
                    }
                }
            }
            Response.End();
        }
    }
}