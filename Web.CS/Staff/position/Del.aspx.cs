using System;

public partial class Staff_position_Del : Web.UI.Permissions
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.Staff.position pDAL = new Web.DAL.Staff.position();
            if (pDAL.Delete(StoresID, id) > 0)
            {
                Base.Log.Log.Add(3, "Staff_position", id);
                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "职位删除成功。");
                Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("positionGrid", true));
            }
        }
        Response.End();
    }
}