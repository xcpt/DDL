using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sys_mamas_Del : Web.UI.Permissions
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.Sys.mamas mDAL = new Web.DAL.Sys.mamas();
            if (mDAL.Delete(StoresID, id) > 0)
            {
                Base.Log.Log.Add(3, "Sys_mamas", id);
                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "泳圈删除成功。");
                Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("mamasGrid", true));
            }
        }
        Response.End();
    }
}