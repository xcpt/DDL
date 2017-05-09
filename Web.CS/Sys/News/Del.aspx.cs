using System;

public partial class Sys_News_Del : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.Sys.News nDAL = new Web.DAL.Sys.News();
            if (nDAL.Delete(id) > 0)
            {
                Base.Log.Log.Add(3, "Sys_News", id);
                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "删除成功。");
                Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("NewsGrid", true));
            }
        }
        Response.End();
    }
}