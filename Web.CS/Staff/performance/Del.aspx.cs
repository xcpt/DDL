using System;

public partial class Staff_performance_Del : Web.UI.Permissions
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.Staff.performance pDAL = new Web.DAL.Staff.performance();
            if (pDAL.Delete(id) > 0)
            {
                Base.Log.Log.Add(3, "Staff_performance", id);
                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "绩效删除成功。");
                Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("performanceGrid", true));
            }
        }
        Response.End();
    }
}