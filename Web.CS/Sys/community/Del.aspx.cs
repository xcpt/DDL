using System;

public partial class Sys_community_Del : Web.UI.Permissions
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.Sys.community cDAL = new Web.DAL.Sys.community();
            if (cDAL.Delete(StoresID, id) > 0)
            {
                Base.Log.Log.Add(3, "Sys_community", id);
                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "小区删除成功。");
                Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("communityGrid", true));
            }
        }
        Response.End();
    }
}