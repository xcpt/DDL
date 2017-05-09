using System;
using System.Collections.Generic;
using System.Web;

namespace Web.UI
{
    /// <summary>
    /// 后台权限判断，把cs页面的 System.Web.UI.Page替换为Web.UI.Permissions即可。
    /// </summary>
    public class Permissions : System.Web.UI.Page
    {
        private bool superadmin = false;
        /// <summary>
        /// 是否超级管理员
        /// </summary>
        public bool SuperAdmin
        {
            get { return superadmin; }
            set { superadmin = value; }
        }

        private string userid = "";
        /// <summary>
        /// 后台登录用户ID
        /// </summary>
        public string UserID {
            get { return userid; }
            set { userid = value; }
        }
        private string username = "";
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }
        private string userroles = "";
        /// <summary>
        /// 用户角色
        /// </summary>
        public string UserRoles {
            get {return userroles; }
            set { userroles = value; }
        }
        private string _StoresID = "";
        /// <summary>
        /// 门店ID
        /// </summary>
        public string StoresID
        {
            get { return _StoresID; }
            set { _StoresID = value; }
        }
        /// <summary>
        /// 是否有添加权限（当前目录下Add开头的文件）
        /// </summary>
        public bool IsAdd = false;
        /// <summary>
        /// 是否有修改权限（当前目录下Modi开头的文件）
        /// </summary>
        public bool IsModi = false;
        /// <summary>
        /// 是否有删除权限（当前目录下Del开头的文件）
        /// </summary>
        public bool IsDel = false;
        /// <summary>
        /// 是否有属性权限（当前目录下Operate开头的文件）
        /// </summary>
        public bool IsOperate = false;
        /// <summary>
        /// 是否有审核权限（当前目录下Audit开头的文件）
        /// </summary>
        public bool IsAudit = false;
        /// <summary>
        /// 是否有布局权限（当前目录下Layout开头的文件）
        /// </summary>
        public bool IsLayout = false;
        /// <summary>
        /// 是否有排序权限
        /// </summary>
        public bool IsOrder = false;
        /// <summary>
        /// 是否有回收站权限
        /// </summary>
        public bool IsRecycle = false;
        /// <summary>
        /// 是否有还原权限
        /// </summary>
        public bool IsRestore = false;
        /// <summary>
        /// 是否有推送权限
        /// </summary>
        public bool IsPush = false;
        /// <summary>
        /// 是否access数据库
        /// </summary>
        public bool IsOleDb = false;
        /// <summary>
        /// 引用调用
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            Web.Model.UserLogin user = Users.GetUserInfo();
            if (!Base.Fun.fun.pnumeric(user.UserID))///如果登录SESSION值为NULL的时候，提示为登录
            {
                HttpContext.Current.Response.Write("['-1']");
                HttpContext.Current.Response.End();
            }
            else
            {
                if (Base.DataBase.Difference.GetDataBaseType("SyCms").Equals(Base.DataBase.Difference.DataBaseType.Access))
                {
                    IsOleDb = true;
                }
                superadmin = Web.UI.Users.UserSuperAdmin();
                userid = user.UserID;
                username = user.UserName;
                userroles = user.RoleID;
                StoresID = user.StoresID;
                if (superadmin)
                {
                    IsAdd = true;
                    IsModi = true;
                    IsDel = true;
                    IsOperate = true;
                    IsAudit = true;
                    IsLayout = true;
                    IsOrder = true;
                    IsRecycle = true;
                    IsRestore = true;
                    IsPush = true;
                }
                else
                {
                    Dictionary<string, Web.Model.AdminFileTypeValue> FileType = Web.UI.Users.DALCheckPermission();
                    IsAdd = FileType["Add"].FilePermissions;
                    IsModi = FileType["Modi"].FilePermissions;
                    IsDel = FileType["Del"].FilePermissions;
                    IsOperate = FileType["Operate"].FilePermissions;
                    IsAudit = FileType["Audit"].FilePermissions;
                    IsLayout = FileType["Layout"].FilePermissions;
                    IsOrder = FileType["Order"].FilePermissions;
                    IsRecycle = FileType["Recycle"].FilePermissions;
                    IsRestore = FileType["Restore"].FilePermissions;
                    IsPush = FileType["Push"].FilePermissions;
                }
                base.OnLoad(e);
            }
        }
    }
}
