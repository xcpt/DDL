using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sys_community_Modi :Web.UI.Permissions
{
    protected string action = "";
    protected Web.Model.Sys.community cModel = new Web.Model.Sys.community();
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.Sys.community cDAL = new Web.DAL.Sys.community();
            cModel = cDAL.Read(StoresID, id);
            if (cModel.id.Equals(id))
            {
                if (action.Equals("save"))
                {
                    cModel.title = Base.Fun.Fetch.post("title");
                    cModel.storesid = StoresID;
                    int icount = cDAL.Update(cModel);
                    if (icount > 0)
                    {
                        Base.Log.Log.Add(2, "Sys_community", id);
                        SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "小区修改成功。");
                        Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("communityGrid", id, true));
                    }
                    else
                    {
                        SyCms.Window.WindowsReturn.WindowsReturnAlert("小区修改失败。");
                    }
                    Response.End();
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("错误：未找到小区信息。");
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