using System;

public partial class Sys_Category_Add : Web.UI.Permissions
{
    protected string parentid = "", type = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        parentid = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("parentid"));
        type = Base.Fun.Fetch.getpost("type");
        string action = Base.Fun.Fetch.getpost("action");
        if (action.Equals("save"))
        {
            int depth = 0;
            Web.DAL.Sys.Category cDAL = new Web.DAL.Sys.Category();
            if (Base.Fun.fun.pnumeric(parentid))
            {
                Web.Model.Sys.Category cModel = cDAL.Read(parentid);
                type = cModel.type;
                depth = 1;
            }
            Web.Model.Sys.Category c = new Web.Model.Sys.Category();
            c.classname = Base.Fun.Fetch.getpost("classname");
            c.depth = depth.ToString();
            c.eday = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("eday"));
            c.isnavi = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("isnavi"));
            c.orderid = "0";
            c.parentid = parentid;
            c.pic = Base.Fun.Fetch.getpost("pic");
            c.sday = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("sday"));
            c.content = Base.Fun.Fetch.getpost("content");
            c.type = type;
            if (Base.Fun.fun.pnumeric(cDAL.Insert(c)))
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "添加成功");
                Response.Write("<script type=\"text/javascript\">$('#WeiXinMenuListView').html(\"" + Base.Fun.JScript.htmltojavascriptNoD(Web.UI.Sys.Category.ViewHtml(type, IsModi, IsAdd, IsDel)) + "\");$(\".treeTable\").treeTable();$('.treeTable').find('tr.parent').each(function(){$(this).expand();});</script>");
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("添加错误");
            }
            Response.End();
        }
    }
}