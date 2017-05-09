using System;

public partial class Mobile_MessageTemplate_Modi : Web.UI.Permissions
{
    protected string action = "";
    protected Web.Model.Mobile.MessageTemplate mtModel = new Web.Model.Mobile.MessageTemplate();
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.Mobile.MessageTemplate mtDAL = new Web.DAL.Mobile.MessageTemplate();
            mtModel = mtDAL.Read(StoresID, id);
            if (mtModel.id.Equals(id))
            {
                if (action.Equals("save"))
                {
                    mtModel.title = Base.Fun.Fetch.getpost("title");
                    mtModel.content = Base.Fun.Fetch.getpost("content");
                    int icount = mtDAL.Update(mtModel);
                    if (icount>0)
                    {
                        Base.Log.Log.Add(2, "Mobile_MessageTemplate", id);
                        SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "短信模板修改成功。");
                        Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("MessageTemplateGrid", id, true));
                    }
                    else
                    {
                        SyCms.Window.WindowsReturn.WindowsReturnAlert("短信模板修改失败。");
                    }
                    Response.End();
                }
            }
            else {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("未找到相关信息");
                Response.End();
            }
        }
        else {
            SyCms.Window.WindowsReturn.WindowsReturnAlert("参数传递错误。");
            Response.End();
        }
    }
}