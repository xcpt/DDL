using System;

public partial class Staff_department_Del : Web.UI.Permissions
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.Staff.department dDAL = new Web.DAL.Staff.department();
            if (dDAL.Delete(StoresID, id) > 0)
            {
                Base.Log.Log.Add(3, "Staff_department", id);
                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "部门删除成功。");
                Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("departmentGrid", true));
            }
        }
        Response.End();
    }
}