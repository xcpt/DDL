using System.Collections.Generic;
using System.Text;

namespace Web.UI
{
    /// <summary>
    /// 菜单组
    /// </summary>
    public class MenuClass
    {
        Web.DAL.MenuClass MCBLL = new Web.DAL.MenuClass();
        Web.DAL.MenuFiles MFBLL = new Web.DAL.MenuFiles();
        /// <summary>
        /// 更新排序
        /// </summary>
        /// <param name="OrderID"></param>
        public static void SetOrder(string OrderID)
        {
            string[] _OrderID_M = OrderID.Split(',');
            StringBuilder str = new StringBuilder();
            Web.DAL.MenuClass MCBLL = new DAL.MenuClass();
            for (int i = 0; i < _OrderID_M.Length; i = i + 2)
            {
                MCBLL.SetOrder(Base.Fun.fun.IsZero(_OrderID_M[i]), _OrderID_M[i + 1]);
            }
        }
        /// <summary>
        /// 获得插件的ID号
        /// </summary>
        /// <returns></returns>
        public static string GetPlusID()
        {
            Web.DAL.MenuClass MCBLL = new DAL.MenuClass();
            return MCBLL.GetDirectoryID("plus", "0");
        }
        /// <summary>
        /// 获得左边的菜单显示
        /// </summary>
        /// <param name="MoldId">大类菜单ID</param>
        /// <returns></returns>
        public static string LeftTreeList()
        {
            string fileIDS = "", sMenuIDS = "", bMenuIDS = "";
            Web.DAL.MenuClass MCBLL = new DAL.MenuClass();
            Web.DAL.MenuFiles MFBLL = new Web.DAL.MenuFiles();
            int roleid = Web.UI.Users.GetFileBar(out fileIDS, out sMenuIDS, out bMenuIDS);
            StringBuilder str = new StringBuilder();
            List<string> MoldIdList = Web.UI.MenuClass.ReadTopBannerID();
            foreach (string MoldId in MoldIdList)
            {
                List<Web.Model.MenuClass> MCModelList = MCBLL.ReadList(roleid, MoldId, sMenuIDS);
                if (MCModelList.Count > 0)
                {
                    foreach (Web.Model.MenuClass mc in MCModelList)
                    {
                        str.Append("<li class=\"one li_" +  mc.Id + "\"><a href=\"#\">" + mc.Name + "</a>");
                        str.Append("<ul style=\"display:none\">");
                        List<Web.Model.MenuFiles> MFList = MFBLL.ReadList(mc.Id, roleid, fileIDS);
                        if (MFList.Count > 0)
                        {
                            foreach (Web.Model.MenuFiles mf in MFList)
                            {
                                str.Append("<li class=\"two\"><a href=\"" + (mf.AllUrl.Length > 0 ? mf.AllUrl.Substring(1) : "") + "\">" + mf.FileName + "</a></li>");
                            }
                        }
                        str.Append("</ul>");
                        str.Append("</li>");
                    }
                }
            }
            return str.ToString();
        }
        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <param name="IsAdd">权限值</param>
        /// <param name="IsModi">权限值</param>
        /// <param name="IsDel">权限值</param>
        /// <param name="IsOperate">权限值</param>
        /// <returns></returns>
        public static string GetMenuClass(bool IsAdd, bool IsModi, bool IsDel, bool IsOperate)
        {
            Web.DAL.MenuClass MCBLL = new DAL.MenuClass();
            Web.DAL.MenuFiles MFBLL = new Web.DAL.MenuFiles();
            StringBuilder reval = new StringBuilder();
            List<Web.Model.MenuClass> MCList = MCBLL.ReadList();
            List<Web.Model.MenuClass> SMCList1 = MCList.FindAll(delegate(Web.Model.MenuClass mc) { return mc.Pid == "0"; });
            foreach (Web.Model.MenuClass mc1 in SMCList1)
            {
                reval.Append(ViewTreeData(mc1, IsAdd, IsModi, IsDel, IsOperate));
                List<Web.Model.MenuClass> SMCList2 = MCList.FindAll(delegate(Web.Model.MenuClass mc) { return mc.Pid == mc1.Id; });
                foreach (Web.Model.MenuClass mc2 in SMCList2)
                {
                    reval.Append(ViewTreeData(mc2, IsAdd, IsModi, IsDel, IsOperate));
                    List<Web.Model.MenuFiles> MFList = MFBLL.ReadList(mc2.Id);
                    foreach (Web.Model.MenuFiles mf in MFList)
                    {
                        reval.Append(Web.UI.MenuFiles.ViewTreeData(mf, IsAdd, IsModi, IsDel, IsOperate));
                    }
                }
            }
            return reval.ToString();
        }

        #region 添加内容
        /// <summary>
        /// 添加内容
        /// </summary>
        /// <returns>返回真假</returns>
        public bool Add(ref Web.Model.MenuClass MCModel)
        {
            bool bo = true;
            MCModel = MCBLL.Insert(MCModel);
            if (Base.Fun.fun.pnumeric(MCModel.Id))
            {
                ModiyAllUrl(MCModel.Id);
                Base.Log.Log.Add(1, "MenuClass");
            }
            else
            {
                bo = false;
            }
            return bo;
        }
        #endregion

        #region 修改记录
        /// <summary>
        /// 修改记录
        /// </summary>
        /// <returns>返回真假</returns>

        public bool Modi(Web.Model.MenuClass MCModel)
        {
            bool bo = true;
            int icount = MCBLL.Update(MCModel);
            if (icount == 0)
            {
                bo = false;
            }
            else
            {
                ModiyAllUrl(MCModel.Id);
                Base.Log.Log.Add(2, "MenuClass");
            }
            return bo;
        }
        #endregion

        /// <summary>
        /// 判断DirectoryName是否存在
        /// </summary>
        /// <returns></returns>
        public bool DirectoryNameIsExist(string directoryName)
        {
            bool bo = false;
            string id = MCBLL.Select_Plus(directoryName);
            if (Base.Fun.fun.pnumeric(id))
            {
                bo = true;
            }
            return bo;
        }
        /// <summary>
        /// 根据目录找到相应表单 菜单，修改名称
        /// </summary>
        /// <returns></returns>
        public bool PathModiName(string name, string directoryName)
        {
            bool bo = false;
            string id = MCBLL.Select_Plus(directoryName);
            if (Base.Fun.fun.pnumeric(id))
            {
                bo = true;
                if (MCBLL.SetName(id, name) > 0)
                {
                    MFBLL.SetName(id, name);
                }
            }
            return bo;
        }
        /// <summary>
        /// 根据目录找到相应插件删除
        /// </summary>
        /// <returns></returns>
        public bool PathDel(string directoryName)
        {
            bool bo = true;
            string id = MCBLL.Select_Plus(directoryName);
            if (Base.Fun.fun.pnumeric(id))
            {
                MCBLL.DeleteOnClassFile(id);
                MCBLL.DeleteOnClass(id);
                Base.Log.Log.Add(3, "MenuClass");
            }
            return bo;
        }

        #region 删除信息
        /// <summary>
        /// 删除信息
        /// </summary>
        /// <returns>返回真假</returns>
        public bool Del(string id)
        {
            bool bo = true;
            MCBLL.DeleteOnClassFile(id);
            MCBLL.DeleteOnClass(id);
            Base.Log.Log.Add(3, "MenuClass");
            return bo;
        }
        #endregion

        #region 读取网站上部导航（未完成，需要管理员权限管理）
        /// <summary>
        /// 读取网站上部导航（未完成，需要管理员权限管理）
        /// </summary>
        /// <returns>返回string</returns>
        public static string ReadTopBanner(string pid)
        {
            string fileIDS = "", sMenuIDS = "", bMenuIDS = "";
            int roleid = Web.UI.Users.GetFileBar(out fileIDS, out sMenuIDS, out bMenuIDS);
            string str = "";
            Web.DAL.MenuClass MCBLL = new DAL.MenuClass();
            List<Web.Model.MenuClassFileCount> MCFCList = MCBLL.ReadClassCount(Base.Fun.fun.IsZero(pid), roleid, bMenuIDS);
            int i = 0;
            foreach (Web.Model.MenuClassFileCount mcfc in MCFCList)
            {
                if (Base.Fun.fun.pnumeric(mcfc.FileCount))
                {
                    str += "<a href=\"id=" + mcfc.Id + "\"" + (i == 0 ? " class=\"dq\"" : "") + ">" + mcfc.Name + "</a>";
                }
                i++;
            }
            return str;
        }
        #endregion


        #region 读取网站上部导航（未完成，需要管理员权限管理）
        /// <summary>
        /// 读取网站上部导航（未完成，需要管理员权限管理）
        /// </summary>
        /// <returns>返回string</returns>
        public static List<string> ReadTopBannerID()
        {
            string fileIDS = "", sMenuIDS = "", bMenuIDS = "";
            int roleid = Web.UI.Users.GetFileBar(out fileIDS, out sMenuIDS, out bMenuIDS);
            List<string> str = new List<string>();
            Web.DAL.MenuClass MCBLL = new DAL.MenuClass();
            List<Web.Model.MenuClassFileCount> MCFCList = MCBLL.ReadClassCount("0", roleid, bMenuIDS);
            foreach (Web.Model.MenuClassFileCount mcfc in MCFCList)
            {
                if (Base.Fun.fun.pnumeric(mcfc.FileCount))
                {
                    str.Add(mcfc.Id);
                }
            }
            return str;
        }
        #endregion

        #region 读取类别
        /// <summary>
        /// 读取类别
        /// </summary>
        /// <returns>返回string</returns>
        public string GetName(string pid)
        {
            return MCBLL.GetName(pid);
        }
        #endregion

        #region 读取栏目表数据
        /// <summary>
        /// 读取栏目表数据
        /// </summary>
        /// <returns>返回dt</returns>
        public List<Web.Model.MenuClass> GetMClass(string pid)
        {
            return MCBLL.ReadList();
        }
        #endregion

        #region 显示单条记录
        /// <summary>
        /// 显示单条记录
        /// </summary>
        /// <returns>返回真假</returns>
        public Web.Model.MenuClass View(string ID)
        {
            return MCBLL.Read(ID);
        }
        #endregion

        #region 查询一级栏目以及子栏目
        /// <summary>
        /// 查询一级栏目以及子栏目
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetPidList(string id)
        {
            return MCBLL.GetPidList(id);
        }
        #endregion


        /// <summary>
        /// 显示树形数据
        /// </summary>
        /// <returns></returns>
        public static string ViewTreeData(Web.Model.MenuClass mc, bool IsAdd, bool IsModi, bool IsDel, bool IsOperate)
        {
            StringBuilder reval = new StringBuilder();
            if (Base.Fun.fun.pnumeric(mc.Pid))
            {
                reval.Append("<tr align=\"center\" id=\"node-2-" + mc.Id + "\" class=\"child-of-node-1-" + mc.Pid + "\" Depth=\"1\">\n");
                reval.Append("<td align=\"left\"  style=\"padding-left: 37px\">");
            }
            else
            {
                reval.Append("<tr align=\"center\" id=\"node-1-" + mc.Id + "\" Depth=\"0\">\n");
                reval.Append("<td align=\"left\">");
            }
            reval.Append("<span class=\"folder\">");
            if (IsOperate)
            {
                reval.Append("排序：<input name=\"OrderID_M\" type=\"text\" class=\"Ipx\" id=\"OrderID_M\" size=\"5\" value=\"" + mc.OrderId + "\" onKeyUp=\"this.value=this.value.replace(/\\D/g,'')\" onafterpaste=\"this.value=this.value.replace(/\\D/g,'')\"/><INPUT type='hidden' name='OrderID_M' id='OrderID_M' value='" + mc.Id + "' />&nbsp;");
            }
            reval.Append(mc.Name + "</span></td>\n");
            if (Base.Fun.fun.pnumeric(mc.Pid))
            {
                if (IsAdd)
                {
                    reval.Append("<td>&nbsp;<a href=\"#\" onclick=\"CreateWindow('Manager/MenuFiles/Add.aspx?mcid=" + mc.Id + "', '添加文件','Manager/MenuFiles/Add.aspx?action=save',400, 240,'MenuFilesAdd');return false;\" ><img src='images/icon/page_add.png' /></a></td>\n");
                }
                else
                {
                    reval.Append("<td>&nbsp;</td>\n");
                }
            }
            else
            {
                if (IsAdd)
                {
                    reval.Append("<td>&nbsp;<a href=\"#\" onclick=\"CreateWindow('Manager/MenuClass/Add.aspx?pid=" + mc.Id + "', '添加二级栏目','Manager/MenuClass/Add.aspx?action=save',400, 240,'MenuClassAdd');return false;\" ><img src='images/icon/folder_add.png' /></a></td>\n");
                }
                else
                {
                    reval.Append("<td>&nbsp;</td>\n");
                }
            }
            if (IsOperate)
            {
                if (mc.Issys.Equals("0"))
                {
                    reval.Append("<td><a href=\"#\" onclick=\"var obj=this;AjaxFun('Manager/MenuClass/Operate.aspx', 'id=" + mc.Id + "', '正在设置属性，请稍候...',function(html){if (html){$(obj).html(html);}});return false;\" ><img src='images/icon/" + Ami.GetStateStr(mc.Ishow) + ".png' /></a></td>\n");
                }
                else
                {
                    if (mc.Id.Equals("10") || mc.Id.Equals("2"))
                    {
                        reval.Append("<td><img src='images/icon/" + Ami.GetStateStr(mc.Ishow) + "_Gray.png' /></td>\n");
                    }
                    else
                    {
                        reval.Append("<td><a href=\"#\" onclick=\"var obj=this;AjaxFun('Manager/MenuClass/Operate.aspx', 'id=" + mc.Id + "', '正在设置属性，请稍候...',function(html){if (html){$(obj).html(html);}});return false;\" ><img src='images/icon/" + Ami.GetStateStr(mc.Ishow) + ".png' /></a></td>\n");
                    }
                }
            }
            else
            {
                reval.Append("<td><img src='images/icon/" + Ami.GetStateStr(mc.Ishow) + "_Gray.png' /></td>\n");
            }
            if (IsModi && mc.Issys.Equals("0"))
            {
                reval.Append("<td><a href=\"#\" onclick=\"GridModiy('" + mc.Id + "', 'Manager/MenuClass/Modi.aspx','修改', 'Manager/MenuClass/Modi.aspx?action=save', 400, 200, 'MenuClassModi');return false\" ><img src='images/icon/folder_edit.png' /></a></td>\n");
            }
            else
            {
                reval.Append("<td>&nbsp;</td>\n");
            }
            if (IsDel)
            {
                reval.Append("<td>" + (mc.Issys.Equals("0") ? "<a href=\"#\" onclick=\"GridDel('" + mc.Id + "','Manager/MenuClass/Del.aspx');return false;\" ><img src='images/icon/folder_delete.png' /></a>" : "&nbsp;") + "</td>\n");
            }
            else
            {
                reval.Append("<td>&nbsp;</td>\n");
            }
            reval.Append("</tr>\n");
            return reval.ToString();
        }
        /// <summary>
        /// 设置是否可见
        /// </summary>
        /// <returns></returns>
        public string SetShow(string ID)
        {
            string str = "";
            Web.Model.MenuClass MCModel = View(ID);
            if (MCModel != null)
            {
                string St = (MCModel.Ishow.Equals("0") ? "1" : "0");
                if (MCBLL.SetIshow(ID, St) > 0)
                {
                    str = "<img src=images/icon/" + (St == "1" ? "true" : "false") + ".png width=16 height=16 />";
                }
            }
            return str;
        }

        /// <summary>
        /// 获得同级里面的它上面的ID，如果没有返回父级ID
        /// </summary>
        /// <returns></returns>
        public string GetParentId(string pid, string orderId, string id)
        {
            string str = "";
            pid = Base.Fun.fun.IsZero(pid);
            string nid = MFBLL.GetMCMaxID(pid);
            if (Base.Fun.fun.pnumeric(nid))
            {
                str = "node-3-" + nid;
            }
            else
            {
                List<Web.Model.MenuClass> MCList = MCBLL.ReadClassPIDTwo(pid, orderId);
                if (MCList.Count > 0)
                {
                    Web.Model.MenuClass SMC1 = MCList.Find(delegate(Web.Model.MenuClass mc) { return mc.OrderId == orderId && int.Parse(mc.Id) < int.Parse(id); });
                    if (SMC1 != null)
                    {
                        if (Base.Fun.fun.pnumeric(pid))
                        {
                            nid = MFBLL.GetMCMaxID(SMC1.Id);
                            if (Base.Fun.fun.pnumeric(nid))
                            {
                                str = "node-3-" + nid;
                            }
                            else
                            {
                                str = "node-2-" + SMC1.Id;
                            }
                        }
                        else
                        {
                            str = "node-1-" + SMC1.Id;
                        }
                    }
                    else
                    {
                        Web.Model.MenuClass SMC2 = MCList.Find(delegate(Web.Model.MenuClass mc) { return int.Parse(mc.OrderId) < int.Parse(orderId); });
                        if (SMC2 != null)
                        {
                            if (Base.Fun.fun.pnumeric(pid))
                            {
                                nid = MFBLL.GetMCMaxID(SMC2.Id);
                                if (Base.Fun.fun.pnumeric(nid))
                                {
                                    str = "node-3-" + nid;
                                }
                                else
                                {
                                    str = "node-2-" + SMC2.Id;
                                }
                            }
                            else
                            {
                                str = "node-1-" + SMC2.Id;
                            }
                        }
                        else
                        {
                            if (Base.Fun.fun.pnumeric(pid))
                            {
                                str = "node-1-" + pid;
                            }
                        }
                    }
                }
                else
                {
                    if (Base.Fun.fun.pnumeric(pid))
                    {
                        str = "node-1-" + pid;
                    }
                }
            }
            return str;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        private void ModiyAllUrl(string id)
        {
            Web.Model.MenuClass clist = View(id);
            if (clist != null)
            {
                List<Web.Model.MenuClassFile> MCFMoelList = new List<Web.Model.MenuClassFile>();
                if (Base.Fun.fun.pnumeric(clist.Pid))
                {
                    MCFMoelList = MFBLL.ReadAllUrl_a(id);
                }
                else
                {
                    MCFMoelList = MFBLL.ReadAllUrl_b(id);
                }
                foreach (Web.Model.MenuClassFile mcf in MCFMoelList)
                {
                    MFBLL.SetUrl(mcf.ID, Web.UI.MenuFiles.AllUrl(mcf.PClassDir, mcf.ClassDir, mcf.Url));
                }
            }
        }
    }
}
