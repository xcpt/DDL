using System;

public partial class Sys_mamas_Add :Web.UI.Permissions
{
    protected string action = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        if (action.Equals("save"))
        {
            Web.Model.Sys.mamas mModel = new Web.Model.Sys.mamas();
            mModel.title = Base.Fun.Fetch.getpost("title");
            mModel.storesid = StoresID;
            mModel.isdel = "0";
            Web.DAL.Sys.mamas mDAL = new Web.DAL.Sys.mamas();
            string id = mDAL.Insert(mModel);
            if (Base.Fun.fun.pnumeric(id))
            {
                Base.Log.Log.Add(1, "Sys_mamas", id);
                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "泳圈添加成功。");
                Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("mamasGrid", id, true));
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("泳圈添加失败。");
            }
            Response.End();
        }
    }
}