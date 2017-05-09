using System;

public partial class Sys_mamas_Modi : Web.UI.Permissions
{
    protected string action = "";
    protected Web.Model.Sys.mamas mModel = new Web.Model.Sys.mamas();
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.Sys.mamas mDAL = new Web.DAL.Sys.mamas();
            mModel = mDAL.Read(StoresID, id);
            if (mModel.id.Equals(id))
            {
                if (action.Equals("save"))
                {
                    mModel.title = Base.Fun.Fetch.post("title");
                    mModel.storesid = StoresID;
                    mModel.isdel = "0";
                    int icount = mDAL.Update(mModel);
                    if (icount > 0)
                    {
                        Base.Log.Log.Add(2, "Sys_mamas", id);
                        SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "泳圈修改成功。");
                        Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("mamasGrid", id, true));
                    }
                    else
                    {
                        SyCms.Window.WindowsReturn.WindowsReturnAlert("泳圈修改失败。");
                    }
                    Response.End();
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("错误：未找到泳圈信息。");
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