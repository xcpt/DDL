using System;

public partial class Mobile_MessageTemplate_Add : Web.UI.Permissions
{
    protected string action = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        if (action.Equals("save"))
        {
            Web.Model.Mobile.MessageTemplate mtModel = new Web.Model.Mobile.MessageTemplate();
            mtModel.storesid = StoresID;
            mtModel.title = Base.Fun.Fetch.getpost("title");
            mtModel.content = Base.Fun.Fetch.getpost("content");
            Web.DAL.Mobile.MessageTemplate mtDAL = new Web.DAL.Mobile.MessageTemplate();
            string id = mtDAL.Insert(mtModel);
            if (Base.Fun.fun.pnumeric(id))
            {
                Base.Log.Log.Add(1, "Mobile_MessageTemplate", id);
                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "短信模板添加成功。");
                Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("MessageTemplateGrid", id, true));
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("短信模板添加失败。");
            }
            Response.End();
        }
    }
}