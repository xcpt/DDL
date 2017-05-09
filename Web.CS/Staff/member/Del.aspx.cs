using System;

public partial class Staff_member_Del : Web.UI.Permissions
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.Staff.member mDAL = new Web.DAL.Staff.member();
            if (mDAL.Delete(StoresID, id) > 0)
            {
                Base.Log.Log.Add(3, "Staff_member", id);
                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "员工删除成功。");
                Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("memberGrid", true));
            }
        }
        Response.End();
    }
}