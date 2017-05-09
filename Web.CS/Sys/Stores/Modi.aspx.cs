using System;

public partial class Sys_Stores_Modi : Web.UI.Permissions
{
    protected string action = "";
    protected string id = "";
    protected Web.Model.Sys.stores sModel = new Web.Model.Sys.stores();
    protected void Page_Load(object sender, EventArgs e)
    {
        action = Base.Fun.Fetch.getpost("action");
        id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.Sys.stores sDAL = new Web.DAL.Sys.stores();
            sModel = sDAL.Read(id);
            if (sModel.storesid.Equals(id))
            {
                if (action.Equals("save"))
                {
                    sModel.title = Base.Fun.Fetch.post("title");
                    sModel.opentime = Base.Fun.Fetch.post("opentime");
                    sModel.Province = Base.Fun.Fetch.post("Province");
                    sModel.City = Base.Fun.Fetch.post("city");
                    sModel.address = Base.Fun.Fetch.post("address");
                    sModel.Worktime = Base.Fun.Fetch.post("Worktime");
                    sModel.Closingtime = Base.Fun.Fetch.post("Closingtime");
                    sModel.Isoutlets = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("Isoutlets"));
                    sModel.IsCross = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("IsCross"));
                    sModel.tel = Base.Fun.Fetch.post("tel");
                    int icount = sDAL.Update(sModel);
                    if (icount>0)
                    {
                        Base.Log.Log.Add(2, "Sys_Stores", id);
                        SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "门店修改成功。");
                        Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("storesGrid", id, true));
                    }
                    else
                    {
                        SyCms.Window.WindowsReturn.WindowsReturnAlert("门店修改失败。");
                    }
                    Response.End();
                }
            }
            else {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("错误：未找到门店信息。");
                Response.End();
            }
        }
        else {
            SyCms.Window.WindowsReturn.WindowsReturnAlert("错误：参数传递错误。");
            Response.End();
        }
    }
}