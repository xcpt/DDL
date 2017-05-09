using System;

public partial class Sys_Commodity_Del : Web.UI.Permissions
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.Sys.Commodity cDAL = new Web.DAL.Sys.Commodity();
            if (cDAL.Delete(StoresID, id) > 0)
            {
                Base.Log.Log.Add(3, "Sys_Commodity", id);
                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "商品删除成功。");
                Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("CommodityGrid", true));
            }
        }
        Response.End();
    }
}