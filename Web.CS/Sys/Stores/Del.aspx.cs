using System;

public partial class Sys_Stores_Del : Web.UI.Permissions
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.Sys.stores sDAL = new Web.DAL.Sys.stores();
            if (sDAL.Delete(id)>0)
            {
                Base.Log.Log.Add(3, "Sys_Stores", id);
                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "门店删除成功。");
                Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("storesGrid", true));
            }
        }
        Response.End();
    }
}