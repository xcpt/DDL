using System;
using System.Web;
namespace Web.CS.Manager.MenuFiles
{
    public partial class Add : Web.UI.Permissions
    {
        public string mcid, name, fileName, fileUrl, orderId, ishow, mid;
        public string id;
        public string strPid;
        public string action = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            action = Base.Fun.Fetch.getpost("action");
            mcid = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("mcid"));
            if (Base.Fun.fun.pnumeric(mcid))
            {
                if (action.Equals("save"))
                {
                    fileName = Base.Fun.fun.NoSql(Base.Fun.Fetch.post("fileName"));
                    fileUrl = Base.Fun.fun.NoCon(Base.Fun.Fetch.post("fileUrl"));
                    orderId = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("orderId"));
                    ishow = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("ishow"));

                    if (fileName.Length > 0)
                    {
                        if (fileUrl.Length <= 0)
                        {
                            Web.UI.Ami.Message(0, "文件地址必须填写。");
                        }
                        else
                        {
                            Web.Model.MenuFiles mfile = new Web.Model.MenuFiles("", mcid, fileName, fileUrl, orderId, ishow);
                            Web.UI.MenuFiles MFUI = new Web.UI.MenuFiles();
                            if (MFUI.Add(ref mfile))
                            {
                                string ParentId = MFUI.GetParentId(mfile.Mcid, mfile.Id, mfile.OrderId);
                                bool IsAdd = false, IsModi = false, IsDel = false;
                                IsAdd = Web.UI.Users.CheckPermission(HttpContext.Current.Server.UrlDecode(Base.Fun.Fetch.CurrentUrl), 4);
                                IsModi = Web.UI.Users.CheckPermission(HttpContext.Current.Server.UrlDecode(Base.Fun.Fetch.CurrentUrl), 8);
                                IsDel = Web.UI.Users.CheckPermission(HttpContext.Current.Server.UrlDecode(Base.Fun.Fetch.CurrentUrl), 16);
                                string reval = Web.UI.MenuFiles.ViewTreeData(mfile, IsAdd, IsModi, IsDel, IsOperate);
                                Response.Write("['1','文件添加成功']<script type=\"text/javascript\">TreeGridAdd('.treeTable', '#" + ParentId + "', \"" + Base.Fun.JScript.htmltojavascript(reval) + "\",'#node-3-" + mfile.Id + "','#node-2-" + mcid + "');</script>");
                                Response.End();
                            }
                            else
                            {
                                Response.Write("['0','文件添加出错。']");
                                Response.End();
                            }
                        }
                    }
                    else
                    {
                        Response.Write("['0','文件名称必须填写。','fileName']");
                        Response.End();
                    }
                }
                else
                {
                    Web.UI.MenuClass mcl = new Web.UI.MenuClass();
                    mid = mcl.GetPidList(mcid);
                }
            }
            else
            {
                Response.Write("['0','错误：参数传递错误。']");
                Response.End();
            }
        }
    }
}