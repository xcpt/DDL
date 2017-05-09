using System;

public partial class Sys_Category_Del : Web.UI.Permissions
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.Sys.Category cDAL = new Web.DAL.Sys.Category();
            Web.Model.Sys.Category cModel = new Web.Model.Sys.Category();
            cModel = cDAL.Read(id);
            if (cDAL.Delete(id) > 0)
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "删除成功");
                Response.Write("<script type=\"text/javascript\">$('#WeiXinMenuListView').html(\"" + Base.Fun.JScript.htmltojavascriptNoD(Web.UI.Sys.Category.ViewHtml(cModel.type, IsModi, IsAdd, IsDel)) + "\");$(\".treeTable\").treeTable();$('.treeTable').find('tr.parent').each(function(){$(this).expand();});</script>");
            }
        }
        Response.End();
    }
}