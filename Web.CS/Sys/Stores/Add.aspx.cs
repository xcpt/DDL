using System;

public partial class Sys_Stores_Add : Web.UI.Permissions
{
    protected string action = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        action = Base.Fun.Fetch.getpost("action");
        if (action.Equals("save"))
        {
            Web.Model.Sys.stores sModel = new Web.Model.Sys.stores();
            sModel.title = Base.Fun.Fetch.post("title");
            sModel.opentime = Base.Fun.Fetch.post("opentime");
            sModel.Province = Base.Fun.Fetch.post("Province");
            sModel.City = Base.Fun.Fetch.post("city");
            sModel.address = Base.Fun.Fetch.post("address");
            sModel.Worktime = Base.Fun.Fetch.post("Worktime");
            sModel.Closingtime = Base.Fun.Fetch.post("Closingtime");
            sModel.tel = Base.Fun.Fetch.post("tel");
            sModel.Isoutlets = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("Isoutlets"));
            sModel.IsCross = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("IsCross"));
            Web.DAL.Sys.stores sDAL = new Web.DAL.Sys.stores();
            string id = sDAL.Insert(sModel);
            if (Base.Fun.fun.pnumeric(id))
            {
                Base.Log.Log.Add(1, "Sys_Stores", id);
                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "门店添加成功。");
                Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("storesGrid", id, true));
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("门店添加失败。");
            }
            Response.End();
        }
    }
}