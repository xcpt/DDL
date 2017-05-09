using System;
using System.Web;
namespace Web.CS.Manager.MenuClass
{
    public partial class Modi : Web.UI.Permissions
    {
        protected string id, pid, name, directoryName, orderId, ishow, issys;
        protected string action = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            action = Base.Fun.Fetch.getpost("action");
            id = Base.Fun.fun.NoSql(Base.Fun.Fetch.getpost("id"));
            pid = Base.Fun.fun.NoSql(Base.Fun.Fetch.getpost("pid"));
            name = Base.Fun.fun.NoSql(Base.Fun.Fetch.post("name"));
            directoryName = Base.Fun.fun.NoSql(Base.Fun.Fetch.post("directoryName"));
            orderId = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("orderId"));
            ishow = Base.Fun.fun.NoSql(Base.Fun.Fetch.post("ishow"));
            if (action.Equals("save"))
            {
                if (Base.Fun.fun.pnumeric(id))
                {
                    if (name.Length > 0)
                    {
                        Web.UI.MenuClass MCUI = new Web.UI.MenuClass();
                        Web.Model.MenuClass mc = new Web.Model.MenuClass(id, pid, name, directoryName, orderId, ishow);
                        if (MCUI.Modi(mc))
                        {
                            bool IsAdd = false, IsModi = false, IsDel = false;
                            IsAdd = Web.UI.Users.CheckPermission(HttpContext.Current.Server.UrlDecode(Base.Fun.Fetch.CurrentUrl), 4);
                            IsModi = Web.UI.Users.CheckPermission(HttpContext.Current.Server.UrlDecode(Base.Fun.Fetch.CurrentUrl), 8);
                            IsDel = Web.UI.Users.CheckPermission(HttpContext.Current.Server.UrlDecode(Base.Fun.Fetch.CurrentUrl), 16);
                            string parentid = MCUI.GetParentId(mc.Pid, mc.OrderId, mc.Id);
                            if (Base.Fun.fun.pnumeric(pid))
                            {
                                Response.Write("['1','栏目修改成功']<script type=\"text/javascript\">TreeGridModi('.treeTable','#" + parentid + "',\"" + Base.Fun.JScript.htmltojavascript(Web.UI.MenuClass.ViewTreeData(mc, IsAdd, IsModi, IsDel, IsOperate)) + "\",'#node-2-" + id + "');</script>");
                            }
                            else
                            {
                                Response.Write("['1','栏目修改成功']<script type=\"text/javascript\">TreeGridModi('.treeTable','#" + parentid + "',\"" + Base.Fun.JScript.htmltojavascript(Web.UI.MenuClass.ViewTreeData(mc, IsAdd, IsModi, IsDel, IsOperate)) + "\",'#node-1-" + id + "');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("['0','栏目修改出错。']");
                        }
                    }
                    else
                    {
                        Response.Write("['0','类别名称必须填写。','_name']");
                    }
                }
                else
                {
                    Response.Write("['0','类别修改出错。']");
                }
                Response.End();
            }
            else
            {
                if (Base.Fun.fun.pnumeric(id))
                {
                    Web.UI.MenuClass MCUI = new Web.UI.MenuClass();
                    Web.Model.MenuClass mc = MCUI.View(id);
                    if (mc != null)
                    {
                        pid = mc.Pid;
                        name = mc.Name;
                        directoryName = mc.DirectoryName;
                        orderId = mc.OrderId;
                        ishow = mc.Ishow;
                        issys = mc.Issys;
                    }
                    else
                    {
                        Response.Write("['0','类别修改调入出错。']");
                        Response.End();
                    }
                }
                else
                {
                    Response.Write("['0','类别修改调入出错。']");
                    Response.End();
                }
            }
        }
    }
}