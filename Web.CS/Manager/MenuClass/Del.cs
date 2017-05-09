using System;
namespace Web.CS.Manager.MenuClass
{
    public partial class Del : Web.UI.Permissions
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Base.Fun.Fetch.getpost("id");
            if (Base.Fun.fun.pnumeric(id))
            {
                Web.UI.MenuClass MCUI = new Web.UI.MenuClass();
                Web.Model.MenuClass mc = MCUI.View(id);
                if (mc != null)
                {
                    if (MCUI.Del(id))
                    {
                        if (Base.Fun.fun.pnumeric(mc.Pid))
                        {
                            Response.Write("['1','栏目删除成功。']<script type=\"text/javascript\">TreeGridDel('.treeTable', '#node-2-" + id + "');</script>");
                        }
                        else
                        {
                            Response.Write("['1','栏目删除成功。']<script type=\"text/javascript\">TreeGridDel('.treeTable', '#node-1-" + id + "');</script>");
                        }
                        Response.End();
                    }
                    else
                    {
                        Response.Write("['0','栏目删除出错。']");
                        Response.End();
                    }
                }
            }
            else
            {
                Response.Write("['0','栏目删除出错。']");
                Response.End();
            }
        }
    }
}