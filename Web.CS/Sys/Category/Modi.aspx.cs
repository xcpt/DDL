using System;

public partial class Sys_Category_Modi : Web.UI.Permissions
{
    protected string id = "";
    protected Web.Model.Sys.Category cModel = new Web.Model.Sys.Category();
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.Sys.Category cDAL = new Web.DAL.Sys.Category();
            cModel = cDAL.Read(id);
            string action = Base.Fun.Fetch.getpost("action");
            if (action.Equals("save"))
            {
                cModel.classname = Base.Fun.Fetch.getpost("classname");
                cModel.eday = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("eday"));
                cModel.isnavi = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("isnavi"));
                cModel.pic = Base.Fun.Fetch.getpost("pic");
                cModel.sday = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("sday"));
                cModel.content = Base.Fun.Fetch.getpost("content");
                if (cDAL.Update(cModel)>0)
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "修改成功");
                    Response.Write("<script type=\"text/javascript\">$('#WeiXinMenuListView').html(\"" + Base.Fun.JScript.htmltojavascriptNoD(Web.UI.Sys.Category.ViewHtml(cModel.type, IsModi, IsAdd, IsDel)) + "\");$(\".treeTable\").treeTable();$('.treeTable').find('tr.parent').each(function(){$(this).expand();});</script>");
                }
                else
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert("修改错误");
                }
                Response.End();
            }
        }
    }
}