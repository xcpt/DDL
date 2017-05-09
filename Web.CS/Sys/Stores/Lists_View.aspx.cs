using System;

public partial class Sys_Stores_Lists_View :Web.UI.Permissions
{
    protected string action = "";
    protected string id = "";
    protected Web.Model.Sys.stores sModel = new Web.Model.Sys.stores();
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.Sys.stores sDAL = new Web.DAL.Sys.stores();
            sModel = sDAL.Read(id);
            if (!sModel.storesid.Equals(id))
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("错误：未找到门店信息。");
                Response.End();
            }
        }
        else
        {
            SyCms.Window.WindowsReturn.WindowsReturnAlert("错误：参数传递错误。");
            Response.End();
        }
    }
}