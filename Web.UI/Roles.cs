using System;
using System.Collections.Generic;
using System.Text;

namespace Web.UI
{
    public class Roles
    {
        Web.DAL.Roles RoleBLL = new Web.DAL.Roles();
        /// <summary>
        /// 添加内容
        /// </summary>
        /// <returns>返回真假</returns>
        public bool Add(ref Web.Model.Roles RoleModel)
        {
            bool bo = false;
            RoleModel = RoleBLL.Insert(RoleModel);
            if (Base.Fun.fun.pnumeric(RoleModel.Id))
            {
                bo = true;
                Base.Log.Log.Add(1, "Roles");
            }
            return bo;
        }
        /// <summary>
        /// 修改记录
        /// </summary>
        /// <returns>返回真假</returns>
        public bool Modi(Web.Model.Roles RoleModel)
        {
            bool bo = false;
            if (RoleBLL.Update(RoleModel) > 0)
            {
                Base.Log.Log.Add(2, "Roles");
                bo = true;
            }
            return bo;
        }
        /// <summary>
        /// 删除信息
        /// </summary>
        /// <returns>返回真假</returns>
        public bool Del(string ids)
        {
            bool bo = false;
            if (RoleBLL.Delete(ids) > 0)
            {
                Web.DAL.FilePermissions MFBLL = new DAL.FilePermissions();
                MFBLL.Delete(ids);
                Users.UpdateUserRole(ids);
                Base.Log.Log.Add(3, "Roles");
                bo = true;
            }
            return bo;
        }
        /// <summary>
        /// 读取角色名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns>返回string</returns>
        public string GetRName(string id)
        {
            Web.Model.Roles RoleModel = View(id);
            string rName = "";
            if (RoleModel != null)
            {
                rName = RoleModel.RoleName;
            }
            return rName;
        }
        /// <summary>
        /// 判断名称是否存在
        /// </summary>
        /// <param name="RoleName"></param>
        /// <returns></returns>
        public bool GetRID(string RoleName)
        {
            return Base.Fun.fun.pnumeric(RoleBLL.GetRID(RoleName));
        }
        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="RoleName"></param>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public bool GetRID(string RoleName, string storesid)
        {
            return Base.Fun.fun.pnumeric(RoleBLL.GetRID(RoleName, storesid));
        }
        /// <summary>
        /// 判断名称是否存在
        /// </summary>
        /// <param name="RoleName"></param>
        /// <returns></returns>
        public bool GetRID(string RoleName, string storesid, string RoleID)
        {
            return Base.Fun.fun.pnumeric(RoleBLL.GetRID(RoleName, storesid, RoleID));
        }
        /// <summary>
        /// 显示单条记录
        /// </summary>
        /// <returns>返回真假</returns>
        public Web.Model.Roles View(string id)
        {
            return RoleBLL.View(id);
        }
        /// <summary>
        /// 显示列表
        /// </summary>
        /// <param name="PageSize">每页数量</param>
        /// <returns>返回字段串</returns>
        public string ViewList(string roleName, bool IsSupperAdmin, string storesid)
        {
            return RoleBLL.View(Sys.SiteInfo.GetPageSize(), IsSupperAdmin, storesid, roleName);
        }

        /// <summary>
        /// 针对角色设置权限
        /// </summary>
        /// <returns></returns>
        public static string GetRolePermissions(string roleid, string UserRoles, bool SupperAdmin)
        {
            Web.DAL.MenuClass MCBLL = new DAL.MenuClass();
            Web.DAL.MenuFiles MFBLL = new DAL.MenuFiles();
            StringBuilder reval = new StringBuilder();

            Web.Model.FilePermissions FilePer = Web.UI.FilePermissions.GetFilePermissions(roleid);
            Web.Model.FilePermissions FilePer_Admin = Web.UI.FilePermissions.GetFilePermissions(UserRoles);
            List<Web.Model.MenuClass> MCModelList = MCBLL.ReadList();
            List<Web.Model.MenuFiles> MFModelList = MFBLL.ReadList();

            List<Web.Model.MenuClass> MCModelList_s1 = MCModelList.FindAll(delegate(Web.Model.MenuClass mc) { return mc.Pid == "0"; });

            foreach (Web.Model.MenuClass mc1 in MCModelList_s1)
            {
                List<Web.Model.MenuClass> MCModelList_s2 = MCModelList.FindAll(delegate(Web.Model.MenuClass mc) { return mc.Pid == mc1.Id; });
                if (MCModelList_s2.Count > 0)
                {
                    reval.Append("          <tr align=\"center\" id=\"node-" + mc1.Id + "\">\n");
                    reval.Append("            <td align=\"left\"><span class=\"folder\"><a href=\"\" onclick=\"Check_Menu(this,'menu1_" + mc1.Id + "',1);return false;\">全选</a>&nbsp;" + mc1.Name + "</span></td>\n");
                    reval.Append("            <td>&nbsp;</td>\n");
                    reval.Append("          </tr>\n");
                    foreach (Web.Model.MenuClass mc2 in MCModelList_s2)
                    {
                        List<Web.Model.MenuFiles> MFModelList_s3 = MFModelList.FindAll(delegate(Web.Model.MenuFiles mf) { return mf.Mcid == mc2.Id; });
                        if (MFModelList_s3.Count > 0)
                        {
                            reval.Append("          <tr align=\"center\" id=\"node-" + mc1.Id + "-" + mc2.Id + "\" class=\"child-of-node-" + mc1.Id + "\" style='display:none;'>\n");
                            reval.Append("            <td align=\"left\"><span class=\"folder\"><a href=\"\" onClick=\"Check_Menu(this,'menu2_" + mc2.Id + "',1);return false;\">全选</a>&nbsp;" + mc2.Name + "</span></td>\n");
                            reval.Append("            <td>&nbsp;</td>\n");
                            reval.Append("          </tr>\n");
                            string MDName = "";
                            string mdname = "";
                            string kg = "";
                            foreach (Web.Model.MenuFiles mf3 in MFModelList_s3)
                            {
                                mdname = mf3.Url.TrimStart('/').Split('/')[0];
                                if (MDName.Equals(mdname))
                                {
                                    kg = Base.Fun.fun.RepeatString("&nbsp;", 5) + "├";
                                }
                                else
                                {
                                    kg = "";
                                    MDName = mdname;
                                }
                                ///判断在上面继续
                                if (SupperAdmin || FilePer_Admin.FileID.Contains("|" + mf3.Id + "|"))
                                {
                                string strrole = GetPermission(mf3.AllUrl, mc1.Id + "|" + mc2.Id + "|" + mf3.Id, FilePer.Pvalue, SupperAdmin ? "all" : FilePer_Admin.Pvalue).Replace("<input ", "<input onclick=\"Check_Menu3('menu3_" + mf3.Id + "')\" ");

                                reval.Append("          <tr align=\"center\" id=\"node-" + mc1.Id + "-" + mc2.Id + "-" + mf3.Id + "\" class=\"child-of-node-" + mc1.Id + "-" + mc2.Id + "\" style='display:none;'>\n");
                                reval.Append("            <td align=\"left\"><span class=\"file\"><input name=\"chk_3\" type=\"checkbox\" " + GetCheckStr(FilePer.FileID, mf3.Id) + " class='menu1_" + mc1.Id + " menu2_" + mc2.Id + "' id=\"menu3_" + mf3.Id + "\" onClick=\"Check_Menu(this,'menu3_" + mf3.Id + "')\" value='" + mf3.Id + "'/>&nbsp;" + kg + mf3.FileName + "</span></td>\n");
                                reval.Append("            <td align=\"left\">&nbsp;" + strrole + "</td>\n");
                                reval.Append("          </tr>\n");
                                }
                            }
                        }
                    }
                }
            }
            return reval.ToString();
        }
        /// <summary>
        /// 复制权限到另一角色
        /// </summary>
        /// <param name="FromID">来源角色ID</param>
        /// <param name="ToID">目标角色ID</param>
        public static void CopyFilePermissions(string FromID, string ToID)
        {
            CopyFilePermissions(FromID, ToID);
        }
        /// <summary>
        /// 获取详细属性的值
        /// </summary>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public static string GetPermission(string FilePath, string obj, string str, string Pvalue)
        {
            AdminFileType filetype = new AdminFileType();
            return filetype.FileRoles(FilePath, obj, str, Pvalue);
        }

        /// <summary>
        /// 根据登录用户的信息获取对应的权限，如果是超级管理员就返回真，否则返回假
        /// </summary>
        /// <returns></returns>
        public static bool GetRolePer()
        {
            Web.Model.UserLogin userInfo = Web.UI.Users.GetUserInfo();
            string roleIDS = userInfo.RoleID;
            if (String.IsNullOrEmpty(roleIDS))
            {
                roleIDS = "0";
            }
            return GetSuperRole(roleIDS);
        }
        /// <summary>
        /// 是否超级用户组
        /// </summary>
        /// <returns></returns>
        public static bool GetSuperRole(string roleID)
        {
            bool bo = false;
            if (roleID.Equals("1"))//如果包含超级管理员权限的时候就有所有的权限
            {
                bo = true;
            }
            return bo;
        }
        /// <summary>
        /// 根据角色判断文件是否选中和操作
        /// </summary>
        /// <param name="str">|2|3|4|</param>
        /// <param name="fid"></param>
        /// <returns></returns>
        public static string GetCheckStr(string str_, string fid)
        {
            string str = "";
            if (str_.Contains("|" + fid + "|"))
            {
                str = "checked";
            }
            else
            {
                str = "";
            }
            return str;
        }
        /// <summary>
        /// 根据角色判断文件是否选中和操作|1,30|2,30|3,30| 
        /// </summary>
        /// <param name="str">|2,10|3,30|</param>
        /// <param name="fid"></param>
        /// <returns></returns>
        public static string GetCheckStr(string str_, string fid, int fvalue)
        {
            string str = "";
            int _fvalue = 0;
            int i = str_.IndexOf("|" + fid + ",");
            if (i > -1)
            {
                _fvalue = Users.GetFileValue(str_, int.Parse(fid));
                if ((_fvalue & fvalue) == fvalue)
                {
                    str = "checked";
                }
                else
                {
                    str = "";
                }
            }
            else
            {
                str = "";
            }
            return str;
        }

        /// <summary>
        /// 查询角色ID查询角色信息
        /// </summary>
        /// <param name="roleIds"></param>
        /// <returns>返回dt</returns>
        public static List<Web.Model.Roles> GetRoleIds(string roleIds)
        {
            Web.DAL.Roles RoleBLL = new DAL.Roles();
            List<Web.Model.Roles> RolesModelList = new List<Web.Model.Roles>();
            if (Base.Fun.fun.pnumeric(roleIds.Replace(",", "")))
            {
                RolesModelList = RoleBLL.ReadList(roleIds);
            }
            return RolesModelList;
        }
        /// <summary>
        /// 查询角色ID查询角色信息
        /// </summary>
        /// <param name="roleIds"></param>
        /// <param name="In_roleIds">包含角色ID</param>
        /// <returns>返回dt</returns>
        public static List<Web.Model.Roles> GetRoleIds(string roleIds, string In_roleIds)
        {
            Web.DAL.Roles RoleBLL = new DAL.Roles();
            List<Web.Model.Roles> RolesModelList = new List<Web.Model.Roles>();
            if (Base.Fun.fun.pnumeric(roleIds.Replace(",", "")) && Base.Fun.fun.pnumeric(In_roleIds.Replace(",", "")))
            {
                RolesModelList = RoleBLL.ReadList(roleIds);
                if (RolesModelList.Count > 0)
                {
                    RolesModelList.FindAll(delegate(Web.Model.Roles r) { return ("," + In_roleIds + ",").Contains("," + r.Id + ","); });
                }
            }
            return RolesModelList;
        }
        /// <summary>
        /// 根据角色ID查询其它角色信息
        /// </summary>
        /// <param name="roleIds"></param>
        /// <param name="In_roleIds">包含角色ID</param>
        /// <returns></returns>
        public static List<Web.Model.Roles> GetNoRoleIds(string roleIds, string In_roleIds)
        {
            Web.DAL.Roles RoleBLL = new DAL.Roles();
            List<Web.Model.Roles> RolesModelList = new List<Web.Model.Roles>();
            if (Base.Fun.fun.pnumeric(In_roleIds.Replace(",", "")))
            {
                RolesModelList = RoleBLL.ReadList(In_roleIds);
                if (Base.Fun.fun.pnumeric(roleIds.Replace(",", "")))
                {
                    RolesModelList = RolesModelList.FindAll(delegate(Web.Model.Roles r) { return !("," + roleIds + ",").Contains("," + r.Id + ","); });
                }
            }
            return RolesModelList;
        }

        /// <summary>
        /// 根据角色ID查询其它角色信息
        /// </summary>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        public static List<Web.Model.Roles> GetNoRoleIds(string roleIds)
        {
            Web.DAL.Roles RoleBLL = new DAL.Roles();
            List<Web.Model.Roles> RolesModelList = new List<Web.Model.Roles>();
            if (Base.Fun.fun.pnumeric(roleIds.Replace(",", "")))
            {
                RolesModelList = RoleBLL.ReadListNoIDS(roleIds);
            }
            return RolesModelList;
        }
        /// <summary>
        /// 查询所有角色
        /// </summary>
        /// <returns>返回dt</returns>
        public static List<Web.Model.Roles> GetRoleLists()
        {
            Web.DAL.Roles RoleBLL = new DAL.Roles();
            return RoleBLL.ReadList();
        }
        /// <summary>
        /// 获取所有权限
        /// </summary>
        /// <returns></returns>
        public static string GetManagerRole()
        {
            StringBuilder sb = new StringBuilder();
            Web.DAL.Roles RoleBLL = new DAL.Roles();
            List<Web.Model.Roles> RolesModelList = RoleBLL.ReadList();
            sb.Append("{");
            int i = 0;
            foreach (Web.Model.Roles r in RolesModelList)
            {
                sb.Append("RoleName_" + r.Id + ":'" + r.RoleName + "'" + ((i + 1) != RolesModelList.Count ? "," : ""));
                i++;
            }
            sb.Append("}");
            return sb.ToString();
        }
        /// <summary>
        /// 获取所有权限
        /// </summary>
        /// <returns></returns>
        public static string GetManagerRole(string RoleID, string StoresID, bool SupperAdmin)
        {
            StringBuilder sb = new StringBuilder();
            Web.DAL.Roles RoleBLL = new DAL.Roles();
            List<Web.Model.Roles> RolesModelList = RoleBLL.ReadList();
            foreach (Web.Model.Roles r in RolesModelList)
            {
                if (RoleID.Equals(r.Id) || (SupperAdmin && !Base.Fun.fun.pnumeric(r.StoresID)) || r.StoresID.Equals(StoresID))
                {
                    sb.Append("<option value=\"" + r.Id + "\"" + (r.Id.Equals(RoleID) ? " selected=\"selected\"" : "") + ">" + r.RoleName + (Base.Fun.fun.pnumeric(r.StoresID) ? "[门店角色]" : "") + "</option>");
                }
            }
            return sb.ToString();
        }
    }
}
