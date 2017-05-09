using System;
namespace Web.CS.Manager.MenuFiles
{
    public partial class Del : Web.UI.Permissions
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Base.Fun.Fetch.getpost("id");
            if (Base.Fun.fun.pnumeric(id.Replace(",", "")))
            {
                Web.UI.MenuFiles mf = new Web.UI.MenuFiles();
                if (mf.Del(id))
                {
                    Response.Write("['1','文件目录删除成功。']<script type=\"text/javascript\">TreeGridDel('.treeTable', '#node-3-" + id + "');</script>");
                    Response.End();
                }
                else
                {
                    Response.Write("['0','文件目录删除出错。']");
                    Response.End();
                }
            }
            else
            {
                Response.Write("['0','文件目录删除出错。']");
                Response.End();
            }
        }
    }
}