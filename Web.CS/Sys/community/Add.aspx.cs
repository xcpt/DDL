using System;

public partial class Sys_community_Add : Web.UI.Permissions
{
    protected string action = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        if (action.Equals("save"))
        {
            Web.Model.Sys.community cModel = new Web.Model.Sys.community();
            cModel.title = Base.Fun.Fetch.post("title");
            cModel.storesid = StoresID;
            cModel.addtime = DateTime.Now.ToString();
            Web.DAL.Sys.community cDAL = new Web.DAL.Sys.community();
            string id = cDAL.Insert(cModel);
            if (Base.Fun.fun.pnumeric(id))
            {
                Base.Log.Log.Add(1, "Sys_community", id);
                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "小区添加成功。");
                string idname = Base.Fun.Fetch.getpost("idname");
                if (idname.Length > 0)
                {
                    Response.Write("<script type=\"text/javascript\">$('#" + idname + "').html(\"" + Base.Fun.JScript.htmltojavascriptNoD(Web.UI.Sys.community.GetOption(StoresID, id)) + "\").trigger(\"chosen:updated\");</script>");
                }
                else
                {
                    Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("communityGrid", id, true));
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("小区添加失败。");
            }
            Response.End();
        }
    }
}