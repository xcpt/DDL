using System;

public partial class Marketing_Visit_Del : Web.UI.Permissions
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.Marketing.Visit vDAL = new Web.DAL.Marketing.Visit();
            if (vDAL.Delete(id) > 0)
            {
                Base.Log.Log.Add(3, "Marketing_Visit");
                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "回访记录删除成功。");
                Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("VisitGrid", true));
            }
        }
        Response.End();
    }
}