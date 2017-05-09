using System;

public partial class Sys_Message_Modi : Web.UI.Permissions
{
    protected string action = "";
    protected Web.Model.Sys.Message mModel = new Web.Model.Sys.Message();
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.Sys.Message mDAL = new Web.DAL.Sys.Message();
            mModel = mDAL.Read(id);
            if (mModel.id.Equals(id))
            {
                if (action.Equals("save"))
                {
                    string hfContent = Base.Fun.Fetch.post("hfContent");
                    if (hfContent.Length > 0)
                    {
                        int icount = mDAL.Update(hfContent, id);
                        if (icount > 0)
                        {
                            Base.Log.Log.Add(2, "Sys_Message", id);
                            SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "留言反馈回复成功。");
                            Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("MessageGrid", id, true));
                        }
                        else
                        {
                            SyCms.Window.WindowsReturn.WindowsReturnAlert("留言反馈回复失败。");
                        }
                    }
                    Response.End();
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("错误：未找到留言反馈回复信息。");
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