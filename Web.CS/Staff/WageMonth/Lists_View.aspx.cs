using System;

public partial class Staff_WageMonth_Lists_View : Web.UI.Permissions
{
    protected Web.Model.Staff.WageMonth wmModel = new Web.Model.Staff.WageMonth();
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        string id = Base.Fun.Fetch.getpost("id");
        if (!Base.Fun.fun.pnumeric(id))
        {
            SyCms.Window.WindowsReturn.WindowsReturnAlert("参数传递错误");
            Response.End();
        }
        else
        {
            Web.DAL.Staff.WageMonth wmDAL = new Web.DAL.Staff.WageMonth();
            wmModel = wmDAL.Read(id);
            if (!wmModel.id.Equals(id))
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("未找到相关信息");
                Response.End();
            }
        }
    }
}