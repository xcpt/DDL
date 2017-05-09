using System;
using System.Web;
namespace Web.CS.Manager.MenuFiles
{
    public partial class Modi : Web.UI.Permissions
    {
        public string id, mcid, fileName, fileUrl, orderId, ishow, mid;
        public string action = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            action = Base.Fun.Fetch.getpost("action");
            IsOperate = Web.UI.Users.CheckPermission(HttpContext.Current.Server.UrlDecode(Base.Fun.Fetch.CurrentUrl), 2);
            id = Base.Fun.fun.NoSql(Base.Fun.Fetch.getpost("id"));
            mcid = Base.Fun.fun.NoSql(Base.Fun.Fetch.getpost("mcid"));
            if (Base.Fun.fun.pnumeric(id))
            {
                if (action.Equals("save"))
                {
                    fileName = Base.Fun.fun.NoSql(Base.Fun.Fetch.post("fileName"));
                    orderId = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("orderId"));
                    ishow = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("ishow"));
                    fileUrl = Base.Fun.fun.NoCon(Base.Fun.Fetch.post("fileUrl"));
                    if (fileName.Length > 0)
                    {
                        if (fileUrl.Length <= 0)
                        {
                            Web.UI.Ami.Message(0, "文件地址必须填写。");
                        }
                        else
                        {
                            Web.Model.MenuFiles mf = new Web.Model.MenuFiles(id, mcid, fileName, fileUrl, orderId, ishow);
                            Web.UI.MenuFiles MFUI = new Web.UI.MenuFiles();
                            if (MFUI.Modi(mf))
                            {
                                mf = MFUI.View(mf.Id);
                                string parentid = MFUI.GetParentId(mf.Mcid, mf.Id, mf.OrderId);
                                bool IsAdd = false, IsModi = false, IsDel = false;
                                IsAdd = Web.UI.Users.CheckPermission(HttpContext.Current.Server.UrlDecode(Base.Fun.Fetch.CurrentUrl), 4);
                                IsModi = Web.UI.Users.CheckPermission(HttpContext.Current.Server.UrlDecode(Base.Fun.Fetch.CurrentUrl), 8);
                                IsDel = Web.UI.Users.CheckPermission(HttpContext.Current.Server.UrlDecode(Base.Fun.Fetch.CurrentUrl), 16);
                                Response.Write("['1','文件修改成功']<script type=\"text/javascript\">TreeGridModi('.treeTable','#" + parentid + "',\"" + Base.Fun.JScript.htmltojavascript(Web.UI.MenuFiles.ViewTreeData(mf, IsAdd, IsModi, IsDel, IsOperate)) + "\",'#node-3-" + id + "');</script>");
                            }
                            else
                            {
                                Response.Write("['0','文件修改出错。']");
                            }
                        }
                    }
                    else
                    {
                        Response.Write("['0','文件名称必须填写。','fileName']");
                    }
                    Response.End();
                }
                else
                {
                    Web.UI.MenuFiles MFUI = new Web.UI.MenuFiles();
                    Web.Model.MenuFiles mf = MFUI.View(id);
                    if (mf != null)
                    {
                        mcid = mf.Mcid;
                        fileName = mf.FileName;
                        orderId = mf.OrderId;
                        ishow = mf.Ishow;
                        fileUrl = mf.Url;
                        Web.UI.MenuClass mcl = new Web.UI.MenuClass();
                        mid = mcl.GetPidList(mcid);
                    }
                    else
                    {
                        Response.Write("['0','文件修改调入出错。']");
                        Response.End();
                    }
                }
            }
            else
            {
                Response.Write("['0','错误：调入错误。']");
                Response.End();
            }
        }
    }
}