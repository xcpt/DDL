using System;
using System.Web;
namespace Web.CS.Manager.MenuClass
{
    public partial class Add : Web.UI.Permissions
    {
        public string id, pid, name, directoryName, orderId, ishow, sty;
        public string strPid;
        public string action = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            action = Base.Fun.Fetch.getpost("action");
            if (action.Equals("save"))
            {
                pid = Base.Fun.fun.NoSql(Base.Fun.Fetch.post("pid"));
                name = Base.Fun.fun.NoSql(Base.Fun.Fetch.post("name"));
                directoryName = Base.Fun.fun.NoSql(Base.Fun.Fetch.post("directoryName"));
                orderId = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("orderId"));
                ishow = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("ishow"));
                if (name.Length > 0)
                {
                    Web.Model.MenuClass mc = new Web.Model.MenuClass("", pid, name, directoryName, orderId, ishow);
                    Web.UI.MenuClass MCUI = new Web.UI.MenuClass();
                    if (MCUI.Add(ref mc))
                    {
                        bool IsAdd = false, IsModi = false, IsDel = false;
                        IsAdd = Web.UI.Users.CheckPermission(HttpContext.Current.Server.UrlDecode(Base.Fun.Fetch.CurrentUrl), 4);
                        IsModi = Web.UI.Users.CheckPermission(HttpContext.Current.Server.UrlDecode(Base.Fun.Fetch.CurrentUrl), 8);
                        IsDel = Web.UI.Users.CheckPermission(HttpContext.Current.Server.UrlDecode(Base.Fun.Fetch.CurrentUrl), 16);
                        string parentid = MCUI.GetParentId(mc.Pid, mc.OrderId, mc.Id);
                        if (Base.Fun.fun.pnumeric(pid))
                        {
                            Response.Write("['1','栏目添加成功']<script type=\"text/javascript\">TreeGridAdd('.treeTable', '#" + parentid + "', \"" + Base.Fun.JScript.htmltojavascript(Web.UI.MenuClass.ViewTreeData(mc, IsAdd, IsModi, IsDel, IsOperate)) + "\",'#node-2-" + mc.Id + "','#node-1-" + pid + "')</script>");
                        }
                        else
                        {
                            Response.Write("['1','栏目添加成功']<script type=\"text/javascript\">TreeGridAdd('.treeTable', '#" + parentid + "', \"" + Base.Fun.JScript.htmltojavascript(Web.UI.MenuClass.ViewTreeData(mc, IsAdd, IsModi, IsDel, IsOperate)) + "\",'#node-1-" + mc.Id + "')</script>");
                        }
                        Response.End();
                    }
                    else
                    {
                        Response.Write("['0','栏目添加出错。']");
                        Response.End();
                    }
                }
                else
                {
                    Response.Write("['0','类别名称必须填写。','name']");
                    Response.End();
                }
            }
            else
            {
                this.InitInfo();
            }
        }
        private void InitInfo()
        {
            pid = Base.Fun.fun.NoSql(Base.Fun.Fetch.get("pid"));
            if (!Base.Fun.fun.pnumeric(pid))
            {
                pid = "0";
            }
            //sty = " style=\"display:none;\"";
            if (pid == "0")
            {
                strPid = "作为一级菜单";
            }
            else
            {
                Web.UI.MenuClass mc = new Web.UI.MenuClass();

                string m = mc.GetName(pid); ;
                if (m != null && m.ToString() != "")
                {
                    strPid = m.ToString();
                }
                else
                {
                    strPid = "作为一级菜单";
                }
            }
        }
    }
}