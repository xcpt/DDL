using System;

public partial class Mobile_MessageTemplate_Del : Web.UI.Permissions
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.Mobile.MessageTemplate mtDAL = new Web.DAL.Mobile.MessageTemplate();
            mtDAL.Delete(StoresID, id);
            Base.Log.Log.Add(3, "Mobile_MessageTemplate", id);
            Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("MessageTemplateGrid", true));
        }
        Response.End();
    }
}