using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Web.UI
{
    /// <summary>
    /// 用户
    /// </summary>
    public class Users
    {
        Web.DAL.Users UserBLL = new DAL.Users();
        /// <summary>
        /// 添加内容
        /// </summary>
        /// <param name="UsersModel">用户模型</param>
        /// <returns>返回真假</returns>
        public bool Add(ref Web.Model.Users UsersModel)
        {
            bool bo = false;
            UsersModel = UserBLL.Insert(UsersModel);
            if (UsersModel.UserID > 0)
            {
                bo = true;
                Base.Log.Log.Add(1, "Users");
            }
            return bo;
        }
        /// <summary>
        /// 用户全局设置-密码，密码修改之后要求重新登录。
        /// </summary>
        /// <param name="Type">0为添加信息，1为读取信息，2为删除信息</param>
        /// <param name="UserId">用户ID</param>
        /// <returns></returns>
        public static bool UserPassApp(int Type, string UserId)
        {
            bool bo = false;
            string str = Base.Fun.Application.GetApplication("AdminUser_UserInfo_Pass");
            switch (Type)
            {
                case 1:
                    {
                        if (("," + str + ",").Contains("," + UserId + ","))     //如果包含，密码修改了
                        {
                            bo = true;
                        }
                        break;
                    }
                case 2:
                    {
                        str = ("," + str + ",").Replace("," + UserId + ",", ",").Trim(',');
                        Base.Fun.Application.AddApplication("AdminUser_UserInfo_Pass", str);
                        bo = true;
                        break;
                    }
                default:
                    {
                        str = (("," + str + ",").Replace("," + UserId + ",", ",").Trim(',') + UserId + ",").Trim(',');
                        Base.Fun.Application.AddApplication("AdminUser_UserInfo_Pass", str);
                        bo = true;
                        break;
                    }
            }
            return bo;
        }

        /// <summary>
        /// 用户全局设置-密码，密码修改之后要求重新登录。
        /// </summary>
        /// <param name="Type">0为添加信息，1为读取信息，2为删除信息</param>
        /// <param name="UserId">用户ID</param>
        /// <returns></returns>
        public static bool UserDelApp(int Type, string UserId)
        {
            bool bo = false;
            string str = Base.Fun.Application.GetApplication("AdminUser_UserInfo_Del");
            switch (Type)
            {
                case 1:
                    {
                        if (("," + str + ",").Contains("," + UserId + ","))     //如果包含，密码修改了
                        {
                            bo = true;
                        }
                        break;
                    }
                case 2:
                    {
                        str = ("," + str + ",").Replace("," + UserId + ",", ",").Trim(',');
                        Base.Fun.Application.AddApplication("AdminUser_UserInfo_Del", str);
                        bo = true;
                        break;
                    }
                default:
                    {
                        str = (("," + str + ",").Replace("," + UserId + ",", ",").Trim(',') + UserId + ",").Trim(',');
                        Base.Fun.Application.AddApplication("AdminUser_UserInfo_Del", str);
                        bo = true;
                        break;
                    }
            }
            return bo;
        }

        /// <summary>
        /// 用户全局设置-锁定，锁定状态修改之后
        /// </summary>
        /// <param name="Type">0为添加信息，1为读取信息，2为删除信息</param>
        /// <param name="UserId">用户ID</param>
        /// <returns></returns>
        public static bool UserLookApp(int Type, string UserId)
        {
            bool bo = false;
            string str = Base.Fun.Application.GetApplication("AdminUser_UserInfo_Look");
            switch (Type)
            {
                case 1:
                    {
                        if (("," + str + ",").Contains("," + UserId + ","))     //如果包含，密码修改了
                        {
                            bo = true;
                        }
                        break;
                    }
                case 2:
                    {
                        str = ("," + str + ",").Replace("," + UserId + ",", ",").Trim(',');
                        Base.Fun.Application.AddApplication("AdminUser_UserInfo_Look", str);
                        bo = true;
                        break;
                    }
                default:
                    {
                        str = (("," + str + ",").Replace("," + UserId + ",", ",").Trim(',') + UserId + ",").Trim(',');
                        Base.Fun.Application.AddApplication("AdminUser_UserInfo_Look", str);
                        bo = true;
                        break;
                    }
            }
            return bo;
        }

        /// <summary>
        /// 用户全局设置-Roles，权限修改之后要求重新登录。
        /// </summary>
        /// <param name="Type">0为添加信息，1为读取信息，2为删除信息</param>
        /// <param name="UserId">用户ID</param>
        /// <returns></returns>
        public static bool UserRolesApp(int Type, string UserId)
        {
            bool bo = false;
            string str = Base.Fun.Application.GetApplication("AdminUser_UserInfo_Roles");
            switch (Type)
            {
                case 1:
                    {
                        if (("," + str + ",").Contains("," + UserId + ","))     //如果包含，密码修改了
                        {
                            bo = true;
                        }
                        break;
                    }
                case 2:
                    {
                        str = ("," + str + ",").Replace("," + UserId + ",", ",").Trim(',');
                        Base.Fun.Application.AddApplication("AdminUser_UserInfo_Roles", str);
                        bo = true;
                        break;
                    }
                default:
                    {
                        str = (("," + str + ",").Replace("," + UserId + ",", ",").Trim(',') + UserId + ",").Trim(',');
                        Base.Fun.Application.AddApplication("AdminUser_UserInfo_Roles", str);
                        bo = true;
                        break;
                    }
            }
            return bo;
        }

        /// <summary>
        /// 修改记录
        /// </summary>
        /// <param name="UserModel">用户模型</param>
        /// <param name="IsOperate">属性</param>
        /// <returns>返回真假</returns>
        public bool Modi(Web.Model.Users UserModel, bool IsOperate)
        {
            bool bo = false;
            if (UserBLL.Update(UserModel, IsOperate) > 0)
            {
                Base.Log.Log.Add(2, "Users");
                bo = true;
                Base.Cache.Cache cache = new Base.Cache.Cache();
                cache.clear("User_FileBar_" + UserModel.UserID.ToString());
                cache.Dispose();
            }
            return bo;
        }

        /// <summary>
        /// 判断除自己之外是否还有其它管理员
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public bool IsAdmin(string userID)
        {
            return UserBLL.IsAdminCount(userID) > 0;
        }

        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns>返回真假</returns>
        public bool Del(string userID)
        {
            bool bo = false;
            if (UserBLL.Delete(userID) > 0)
            {
                Base.Log.Log.DelUserTotal(userID);
                Base.Log.Log.Add(3, "Users");
                UserDelApp(0, userID);
                UserRolesApp(2, userID);
                UserPassApp(2, userID);
                UserLookApp(2, userID);
                bo = true;
            }
            return bo;
        }

        /// <summary>
        /// 读取用户名
        /// </summary>
        /// <param name="id"></param>
        /// <returns>返回string</returns>
        public static string GetuName(string id)
        {
            DAL.Users UserBLL = new DAL.Users();
            Web.Model.Users UserModel = UserBLL.View(id);
            string uName = "";
            if (UserModel != null)
            {
                uName = UserModel.UserName;
            }
            return uName;
        }
        /// <summary>
        /// 读取用户所属门店
        /// </summary>
        /// <param name="id"></param>
        /// <returns>返回string</returns>
        public static string GetStoresID(string id)
        {
            DAL.Users UserBLL = new DAL.Users();
            Web.Model.Users UserModel = UserBLL.View(id);
            string uName = "";
            if (UserModel != null)
            {
                uName = UserModel.StoresID;
            }
            return uName;
        }
        /// <summary>
        /// 显示单条记录
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns>返回真假</returns>
        public Web.Model.Users View(string userID)
        {
            return UserBLL.View(userID);
        }
        /// <summary>
        /// 设置锁定状态
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public string SetLock(string userID)
        {
            string str = "";
            Web.Model.Users UsersModel = View(userID);
            if (UsersModel != null)
            {
                string St = "0";
                if (UsersModel.IsLock.Equals(0))       //如果为没有锁定的时候
                {
                    if (!IsAdmin(userID))
                    {
                        str = "['0','错误：锁定之后就没有超级管理员了。']";
                        return str;
                    }
                }
                if (UsersModel.IsLock.Equals(0))
                {
                    St = "1";
                }
                else
                {
                    St = "0";
                }
                if (UserBLL.SetLock(userID, St) > 0)
                {
                    Base.Log.Log.Add(4, "Users");
                    if (St.Equals("1"))     //锁定用户之后
                    {
                        UserLookApp(0, userID);
                    }
                    else
                    {   //开启之后
                        UserLookApp(2, userID);
                    }
                    str = St;
                }
            }
            return str;
        }

        /// <summary>
        /// 显示列表
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>返回字段串</returns>
        public string ViewList(string userName, string StoresID, bool SuperAdmin)
        {
            string str = UserBLL.View(Sys.SiteInfo.GetPageSize(), userName, StoresID, SuperAdmin);
            return str;
        }

        /// <summary>
        ///根据用户ID获取所属组的名称
        /// </summary>
        /// <returns></returns>
        public static string GetGroupName()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append("GroupName_0:'超级管理员',");
            sb.Append("GroupName_1:'普通管理员'");
            sb.Append("}");
            return sb.ToString();
        }
        /// <summary>
        /// 得到两个日期的天数
        /// </summary>
        /// <param name="dStart"></param>
        /// <returns></returns>
        public static int GetTwoDatMinis(DateTime dStart)
        {
            TimeSpan ts = DateTime.Now.Subtract(dStart);
            double dnum = Math.Round(ts.TotalMinutes, 0);
            return Convert.ToInt32(dnum);
        }
        /// <summary>
        /// 判断用户是否登录，提示信息调用 Web.UI.Admin.Manager.Ami.Message(int,string)，如果错误，错误的次数要累加，并记下上次登录的时间，错误5次，提示5分钟之后在再登录
        /// </summary>
        /// <param name="userName">用户提交的用户名</param>
        /// <param name="userPass">用户提交的密码</param>
        /// <param name="IsLongOnLine">是否关闭浏览器就退出</param>
        /// <returns></returns>
        public static void CheckLogin(string userName, string userPass, bool IsLongOnLine)
        {
            int loginErrorTimes = 0, separated = 0;
            DateTime lastLoginTime;
            DAL.Users UserBLL = new DAL.Users();
            Web.Model.Users UserModel = UserBLL.Read(userName);
            if (UserModel != null)///如果用户名和密码匹配的时候，判断是否锁定，如果不锁定，则提示登录成功！
            {
                if (userPass.Equals(UserModel.UserPass))
                {
                    if (UserModel.IsLock.Equals(1))
                    {
                        Base.Log.Log.Add(0, "Users", 1);
                        SyCms.Window.WindowsReturn.WindowsReturnAlert("对不起，该帐户已被锁定，请联系管理员！");
                        HttpContext.Current.Response.End();
                    }
                    else
                    {
                        string UserIP = Base.Fun.Fetch.UserIp;
                        UserBLL.SaveLoginMessage(UserModel.UserID.ToString(), UserIP);
                        ///保存用户的信息到SESSION
                        Web.Model.UserLogin userInfo = new Web.Model.UserLogin();
                        userInfo.UserID = UserModel.UserID.ToString();
                        userInfo.UserName = UserModel.UserName;
                        userInfo.RoleID = UserModel.RoleID;
                        userInfo.StoresID = Base.Fun.fun.pnumeric(UserModel.StoresID) ? UserModel.StoresID : UI.Sys.stores.GetStoresID();
                        userInfo.IsBoss = UserModel.IsBoss;

                        if (!Base.Fun.fun.pnumeric(UserModel.StoresID))
                        {
                            Web.DAL.Users uDAL = new DAL.Users();
                            uDAL.SetStoresID(UserModel.UserID.ToString(), userInfo.StoresID);
                        }

                        Base.Fun.Session.AddObjSession("AdminUserInfo", userInfo);
                        Base.Fun.Session.AddObjSession("UserInfo", new string[] { UserModel.UserID.ToString(), UserModel.UserName, UserModel.RoleID});
                        Base.Fun.Cookies.ResponseCookies("ManageUserID", UserModel.UserID.ToString(), (IsLongOnLine ? -356 : 0), Base.Fun.Md5.MD5("SyCms_Manage" + HttpContext.Current.Request.Url.AbsoluteUri.ToString().Split('/')[2]));
                        Base.Fun.Cookies.ResponseCookies("ManageUserPass", Base.Fun.Encrypt.Encrypt3DES(userPass, "SyCms" + UserModel.UserID.ToString() + "bj"), (IsLongOnLine ? -356 : 0), Base.Fun.Md5.MD5("SyCms_Manage" + HttpContext.Current.Request.Url.AbsoluteUri.ToString().Split('/')[2]));
                        Base.Log.Log.Add(0, "Users");
                        UserPassApp(2, UserModel.UserID.ToString());
                        UserLookApp(2, UserModel.UserID.ToString());
                        UserRolesApp(2, UserModel.UserID.ToString());
                        if (!UserModel.LastLoginIP.Equals(UserIP))
                        {
                            SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "<b>帐号上次登录信息</b>：<br/><br/>登 &nbsp;录 &nbsp;IP：" + UserModel.LastLoginIP + "<br/>登录时间：" + UserModel.LastLoginTime, true, true);
                        }
                        Ami.Message(1, "");
                    }
                }
                else///不匹配的时候
                {
                    loginErrorTimes = UserModel.LoginErrorTimes;
                    lastLoginTime = DateTime.Parse(UserModel.LastLoginTime);
                    int configLoginTime = 5;
                    if (loginErrorTimes >= configLoginTime)///如果登录的错误次数大于或者等于5的时候
                    {
                        separated = GetTwoDatMinis(lastLoginTime);///获取相隔时间的分钟数
                        if (separated >= 5)
                        {
                            UserBLL.SaveLoginErrorMessage(UserModel.UserID.ToString(), Base.Fun.Fetch.UserIp);
                            ///重新开始登录，递归执行函数
                            CheckLogin(userName, userPass, IsLongOnLine);
                        }
                        else
                        {
                            Base.Log.Log.Add(0, "Users", 1);
                            Ami.Message(0, "对不起，该帐户登录错误次数超过5次，请再过" + (5 - separated) + "分钟再登录！");
                        }
                    }
                    else///如果登录的错误次小于5的时候
                    {
                        UserBLL.SaveLoginErrorNum(UserModel.UserID.ToString(), Base.Fun.Fetch.UserIp);
                        Base.Log.Log.Add(0, "Users", 1);
                        Ami.Message(0, "对不起，输入密码错误，您还有" + (configLoginTime - loginErrorTimes) + "次尝试的机会，请重新输入！");
                    }
                }
            }
            else///用户名不存在的时候
            {
                Base.Log.Log.Add(0, "Users", 1);
                Ami.Message(0, "对不起，该用户名不存在，请重新输入！");
            }
        }
        /// <summary>
        /// 修改门店并保存
        /// </summary>
        /// <param name="StoresID"></param>
        public static bool SetStoresID(string StoresID)
        {
            bool bo = false;
            Web.Model.UserLogin userInfo = GetUserInfo();
            if (Base.Fun.fun.pnumeric(userInfo.UserID))
            {
                bo = true;
                userInfo.StoresID = StoresID;
                Web.DAL.Users uDAL = new DAL.Users();
                uDAL.SetStoresID(userInfo.UserID, StoresID);
                Base.Fun.Session.AddObjSession("AdminUserInfo", userInfo);
            }
            return bo;
        }
        /// <summary>
        /// 管理员门店管理
        /// </summary>
        public static void ReadUserStoresID(string StoresID)
        {
            if (!Base.Fun.fun.pnumeric(StoresID))
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert(false, "错误：请先至少添加一个门店。", true);
                HttpContext.Current.Response.End();
            }
        }
        /// <summary>
        /// 获取一个字符串中对应文件的ID的PVALUE值，如取得|8,30|中30的值
        /// </summary>
        /// <param name="str"></param>
        /// <param name="fileID"></param>
        /// <returns></returns>
        public static int GetFileValue(string str, int fileID)
        {
            int value = 0;
            string[] _str = Regex.Split(str, "\\|" + fileID + ",", RegexOptions.IgnoreCase);
            if (_str.Length > 1)
            {
                value = int.Parse(Base.Fun.fun.IsZero(_str[1].Split('|')[0]));
            }
            return value;
        }
        /// <summary>
        /// 根据当前的URL地址获取对应栏目的ID号表明，以及对应文件名称
        /// </summary>
        /// <param name="fileName">返回文件名</param>
        /// <param name="url">返回地址</param>
        /// <param name="nowUrl">网页地址</param>
        /// <returns></returns>
        public static int GetFileID(out string fileName, out string url, string nowUrl)
        {
            int fileID = 0;
            url = "";
            ///用分隔符号隔开
            nowUrl = nowUrl.Replace("\\", "/");
            string[] _nowUrl = nowUrl.Split('/');
            fileName = _nowUrl[_nowUrl.Length - 1].Split('.')[0];
            if (fileName.Contains("_"))
            {
                fileName = fileName.Split('_')[0];
            }
            if (fileName.Contains("-"))
            {
                fileName = fileName.Split('-')[0];
            }
            int wzi = 2;
            if (Base.Fun.Management.GetDirectory().Equals("/"))
            {
                wzi = 1;
            }
            if (_nowUrl.Length > wzi)
            {
                string str = "";
                for (int i = wzi; i < _nowUrl.Length - 1; i++)
                {
                    str += "/" + _nowUrl[i].Split('?')[0];
                }
                DAL.MenuFiles MFBLL = new DAL.MenuFiles();
                Web.Model.MenuFiles MFList = MFBLL.ReadModiAddList(str);
                if (MFList != null)
                {
                    fileID = int.Parse(Base.Fun.fun.IsZero(MFList.Id));
                    url = MFList.Url.ToLower();
                }
            }
            return fileID;
        }
        /// <summary>
        /// 根据文件名获取权限值 0显示，2属性，4添加，8修改，16删除
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static int GetPermissionsValue(string fileName)
        {
            Web.UI.AdminFileType adminftype = new AdminFileType();
            fileName = fileName.Replace("\\", "/");
            if (fileName.Contains("/"))
            {
                fileName = fileName.Substring(fileName.LastIndexOf("/") + 1);
            }
            int value = adminftype.GetPermissionsValue(fileName);
            return value;
        }
        /// <summary>
        /// 获得上级ID
        /// </summary>
        /// <returns></returns>
        public static string GetFirstBMenuID()
        {
            string roleID = "", bMenuID = "";
            //获取用户登录的信息
            //获取用户对应角色
            roleID = GetUserInfo().RoleID;
            if (Base.Fun.fun.pnumeric(roleID))
            {
                DAL.FilePermissions MFPBLL = new DAL.FilePermissions();
                if (Roles.GetSuperRole(roleID))//如果包含超级管理员权限的时候就有所有的权限
                {
                    bMenuID = MFPBLL.ReadPid();
                }
                else
                {
                    bMenuID = MFPBLL.ReadPid(roleID);
                }
            }
            return bMenuID;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="Storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetOption(string Storesid, string id)
        {
            StringBuilder str = new StringBuilder();
            DAL.Users uDAL = new DAL.Users();
            List<Model.Users> uList = uDAL.Readlist(Storesid);
            foreach (Model.Users u in uList)
            {
                str.Append("<option value=\"" + u.UserID + "\">" + u.UserName + "</option>");
            }
            return str.ToString();
        }

        /// <summary>
        /// 获取对应栏目的ID
        /// </summary>
        ///<param name="fileIDS">菜单文件ID</param>
        ///<param name="sMenuIDS">菜单ID</param>
        ///<param name="bMenuIDS">小菜单ID</param>
        /// <returns>0为普通管理员1为高级管理员</returns>
        public static int GetFileBar(out string fileIDS, out string sMenuIDS, out string bMenuIDS)
        {
            string roleID = "", fileID = "", sMenuID = "", bMenuID = "";
            int roleid = 0;
            fileIDS = ""; sMenuIDS = ""; bMenuIDS = "";
            Web.Model.UserLogin userInfo = Web.UI.Users.GetUserInfo();///获取用户登录的信息
            //获取用户对应角色
            roleID = userInfo.RoleID;
            if (!String.IsNullOrEmpty(roleID))
            {
                if (Roles.GetSuperRole(roleID))//如果包含超级管理员权限的时候就有所有的权限
                {
                    roleid = 1;
                }
                else
                {
                    DAL.FilePermissions MFPBLL = new DAL.FilePermissions();
                    DAL.MenuFiles MFBLL = new DAL.MenuFiles();
                    DAL.MenuClass MCBLL = new DAL.MenuClass();
                    List<Web.Model.FilePermissions> MFPList = MFPBLL.ReadRoleFileID(userInfo.UserID, roleID, Sys.SiteInfo.CacheTime);
                    foreach (Web.Model.FilePermissions mfp in MFPList)
                    {
                        fileID = mfp.FileID;

                        Web.Model.MenuFiles MFModel = MFBLL.Read(fileID);
                        sMenuID = "";
                        bMenuID = "";
                        if (MFModel != null)
                        {
                            sMenuID = MFModel.Mcid;
                            Web.Model.MenuClass MCModel = MCBLL.Read(sMenuID);
                            if (MCModel != null)
                            {
                                bMenuID = MCModel.Pid;
                            }
                        }
                        fileIDS += fileID + ",";
                        if (("," + sMenuIDS + ",").Contains("," + sMenuID + ","))
                        { }
                        else
                        {
                            sMenuIDS += sMenuID + ",";
                        }
                        if (("," + bMenuIDS + ",").Contains("," + bMenuID + ","))
                        { }
                        else
                        {
                            bMenuIDS += bMenuID + ",";
                        }
                    }
                    if (fileIDS.Length > 1) { fileIDS = fileIDS.Substring(0, fileIDS.Length - 1); }
                    //if (sMenuIDS.Length > 1) { sMenuIDS = sMenuIDS.Substring(0, sMenuIDS.Length - 1); }
                    sMenuIDS += "7";
                    //sMenuIDS = ("0," + sMenuIDS + ",0").Replace(",9,", ",");
                    if (bMenuIDS.Length > 1) { bMenuIDS = bMenuIDS.Substring(0, bMenuIDS.Length - 1); }
                }
            }
            if (string.IsNullOrEmpty(fileIDS)) { fileIDS = "0"; }
            if (string.IsNullOrEmpty(sMenuIDS)) { sMenuIDS = "0"; }
            if (string.IsNullOrEmpty(bMenuIDS)) { bMenuIDS = "0"; }
            return roleid;
        }

        /// <summary>
        /// 判断用户是否登录，如果登录，需要计算出对应的角色权限，否则跳转到登录页面 
        /// </summary>
        public static void CheckPermission()
        {
            Web.Model.UserLogin userInfo = Web.UI.Users.GetUserInfo();///获取用户登录的信息
            //获取用户对应角色
            if (!Base.Fun.fun.pnumeric(userInfo.UserID))///如果登录SESSION值为NULL的时候，提示为登录
            {
                Ami.Message(-1, "");
            }
            else
            {
                if (UserPassApp(1, userInfo.UserID))        //密码重新设置了，需要重新登录
                {
                    Ami.Message(-1, "");
                }
                else
                {
                    if (UserLookApp(1, userInfo.UserID))
                    {
                        Ami.Message(0, "错误：您的帐号被锁定，无法使用。");
                    }
                    else
                    {
                        if (UserDelApp(1, userInfo.UserID))
                        {
                            Ami.Message(0, "错误：非法操作。");
                        }
                        else
                        {
                            string roleIDS = "", fileValue = "|", fileName = "", url = "";
                            int value = 0, fileID = 0, permissionsValue = 0;
                            string nowUrl = HttpContext.Current.Request.RawUrl.ToString().ToLower();
                            roleIDS = userInfo.RoleID;
                            if (!string.IsNullOrEmpty(roleIDS))
                            {
                                if (!Roles.GetSuperRole(roleIDS))//如果不包含超级管理员权限的时候就有所有的权限
                                {
                                    GetFileRolePer(roleIDS, ref fileValue);
                                    ///判断当前文件是否具有对应的权限
                                    fileID = GetFileID(out fileName, out url, nowUrl);///获取对应文件的ID和表名和文件名和地址
                                    permissionsValue = GetPermissionsValue(fileName);///获取对应的权限值
                                    value = GetFileValue(fileValue, fileID);///获取用户的针对该文件的权限值
                                    //Base.Error.Error.WriteError(fileID + "|" + permissionsValue + "|" + value + "|" + fileName + "|" + url + "|" + fileValue);
                                    if (fileValue.Contains("|" + fileID + ",") && url.Contains(fileName))///当前存储文件中存在该文件ID
                                    { }
                                    else
                                    {
                                        if ((value & permissionsValue) == permissionsValue)///拥有该文件的权限值时
                                        {
                                        }
                                        else
                                        {
                                            Ami.Message(0, "对不起，您没有操作权限！");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Ami.Message(0, "对不起，您没有操作权限！");
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 获得角色最大权限
        /// </summary>
        /// <param name="roleIDS"></param>
        /// <param name="fileValue"></param>
        private static void GetFileRolePer(string roleIDS, ref string fileValue)
        {
            int value = 0;
            int value_ = 0;
            DAL.FilePermissions MFPBLL = new DAL.FilePermissions();
            List<Web.Model.FilePermissions> MFPList = MFPBLL.ReadList(roleIDS);
            foreach (Web.Model.FilePermissions mfp in MFPList)
            {
                ///文件相同的时候权限值取交集用类似|8,30|6,16|这样的格式保存值
                if (fileValue.Contains("|" + mfp.FileID + ","))///如果包含|8,这样的格式的时候
                {
                    value = GetFileValue(fileValue, int.Parse(mfp.FileID));///获取字符串中存在的文件ID的VALUES值
                    value_ = value | int.Parse(mfp.Pvalue);//取交集后赋予新更新字符床中的值
                    fileValue = fileValue.Replace("|" + mfp.FileID + "," + value + "|", "|" + mfp.FileID + "," + value_ + "|");
                }
                else
                {
                    fileValue += mfp.FileID + "," + mfp.Pvalue + "|";
                }
            }
        }
        /// <summary>
        /// 判断用户是否登录，如果登录，需要计算出对应的角色权限，否则跳转到登录页面 
        /// </summary>
        public static Dictionary<string, Web.Model.AdminFileTypeValue> DALCheckPermission()
        {
            AdminFileType FileType = new AdminFileType();
            Web.Model.UserLogin userInfo = GetUserInfo();///获取用户登录的信息
            //获取用户对应角色
            if (!Base.Fun.fun.pnumeric(userInfo.UserID))///如果登录SESSION值为NULL的时候，提示为登录
            {
                Ami.Message(-1, "");
            }
            else
            {
                if (UserPassApp(1, userInfo.UserID))        //密码重新设置了，需要重新登录
                {
                    Ami.Message(-1, "");
                }
                else
                {
                    if (UserLookApp(1, userInfo.UserID))
                    {
                        HttpContext.Current.Response.Write("['0','错误：您的帐号被锁定，无法使用。','',0]");
                        HttpContext.Current.Response.End();
                    }
                    else
                    {
                        if (UserDelApp(1, userInfo.UserID))
                        {
                            HttpContext.Current.Response.Write("['0','错误：非法操作。','',0]");
                            HttpContext.Current.Response.End();
                        }
                        else
                        {
                            string roleIDS = "", fileValue = "|", fileName = "", url = "";
                            int value = 0, fileID = 0, permissionsValue = 0;
                            string nowUrl = HttpContext.Current.Request.RawUrl.ToString().ToLower();
                            roleIDS = userInfo.RoleID;
                            if (!String.IsNullOrEmpty(roleIDS))
                            {
                                if (!Roles.GetSuperRole(roleIDS))//如果不包含超级管理员权限的时候就有所有的权限
                                {
                                    GetFileRolePer(roleIDS, ref fileValue);
                                    ///判断当前文件是否具有对应的权限
                                    fileID = GetFileID(out fileName, out url, nowUrl);///获取对应文件的ID和表名和文件名和地址
                                    permissionsValue = GetPermissionsValue(fileName);///获取对应的权限值
                                    value = GetFileValue(fileValue, fileID);///获取用户的针对该文件的权限值
                                    //Base.Error.Error.WriteError(fileID + "|" + permissionsValue + "|" + value + "|" + fileName + "|" + url + "|" + fileValue);
                                    int pvalue = 0;
                                    foreach (string key in FileType.FileType.Keys)
                                    {
                                        pvalue = FileType.GetPermissionsValue(key);
                                        if ((value & pvalue) == pvalue)
                                        {
                                            FileType.FileType[key].FilePermissions = true;
                                        }
                                    }
                                    if (fileValue.Contains("|" + fileID + ",") && url.Contains(fileName))///当前存储文件中存在该文件ID
                                    { }
                                    else
                                    {
                                        if ((value & permissionsValue) == permissionsValue)///拥有该文件的权限值时
                                        {
                                        }
                                        else
                                        {
                                            Ami.Message(0, "对不起，您没有操作权限！");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Ami.Message(0, "对不起，您没有操作权限！");
                            }
                        }
                    }
                }
            }
            return FileType.FileType;
        }
        /// <summary>
        /// 权限显示判断
        /// </summary>
        /// <param name="nowUrl">网页地址</param>
        /// <param name="permissionsValue">1为显示，2为属性，4为添加，8为修改，16为删除</param>
        public static bool CheckPermission(string nowUrl, int permissionsValue)
        {
            bool bo = false;
            string roleIDS = "", fileValue = "|", fileName = "", url = "";
            int value = 0, fileID = 0;
            Web.Model.UserLogin userInfo = GetUserInfo();///获取用户登录的信息
            //获取用户对应角色
            roleIDS = userInfo.RoleID;
            if (!String.IsNullOrEmpty(roleIDS))
            {
                if (Roles.GetSuperRole(roleIDS))//如果包含超级管理员权限的时候就有所有的权限
                {
                    bo = true;
                }
                else
                {
                    GetFileRolePer(roleIDS, ref fileValue);
                    ///判断当前文件是否具有对应的权限
                    fileID = GetFileID(out fileName, out url, nowUrl.ToLower());///获取对应文件的ID和表名和文件名和地址
                    value = GetFileValue(fileValue, fileID);///获取用户的针对该文件的权限值
                    //Base.Error.Error.WriteError(fileID + "|" + permissionsValue + "|" + value + "|" + fileName + "|" + url + "|" + fileValue);
                    if (permissionsValue.Equals(1) && fileValue.Contains("|" + fileID + ",") && url.Contains(fileName))///当前存储文件中存在该文件ID
                    {
                        bo = true;
                    }
                    else
                    {
                        if ((value & permissionsValue) == permissionsValue)///拥有该文件的权限值时
                        {
                            bo = true;
                        }
                    }
                }
            }
            return bo;
        }
        /// <summary>
        /// 只针对后台首页的判断登录
        /// </summary>
        /// <returns></returns>
        public static bool CheckLogin()
        {
            bool flag = false;
            string UserID = GetUserInfo().UserID;
            if (Base.Fun.fun.pnumeric(UserID))
            {
                flag = true;
            }
            return flag;
        }
        /// <summary>
        /// 是否超级管理员
        /// </summary>
        /// <returns></returns>
        public static bool UserSuperAdmin()
        {
            return Roles.GetSuperRole(GetUserInfo().RoleID);
        }
        /// <summary>
        /// 获取登录用户的SESSION值保存为数组值分别是userID,userName,roleIDS,groupID
        /// </summary>
        /// <returns></returns>
        public static Web.Model.UserLogin GetUserInfo()
        {
            Web.Model.UserLogin userInfo = new Web.Model.UserLogin();
            DAL.Users UserBLL = new DAL.Users();
            if (Base.Fun.Session.GetObjSession("AdminUserInfo") == null)
            {
                string userID = Base.Fun.Cookies.RequestCookies("ManageUserID", Base.Fun.Md5.MD5("SyCms_Manage" + HttpContext.Current.Request.Url.AbsoluteUri.ToString().Split('/')[2]));
                string userPass = Base.Fun.Cookies.RequestCookies("ManageUserPass", Base.Fun.Md5.MD5("SyCms_Manage" + HttpContext.Current.Request.Url.AbsoluteUri.ToString().Split('/')[2]));
                if (Base.Fun.fun.pnumeric(userID) && !string.IsNullOrEmpty(userPass))
                {
                    Web.Model.Users UserModel = UserBLL.View(userID);
                    if (UserModel != null)
                    {
                        try
                        {
                            userPass = Base.Fun.Encrypt.Decrypt3DES(userPass, "SyCms" + UserModel.UserID.ToString() + "bj");
                            if (UserModel.UserPass.Equals(userPass))///如果用户名和密码匹配的时候，判断是否锁定，如果不锁定，则提示登录成功！
                            {
                                if (UserModel.IsLock.Equals(1))
                                {
                                    Ami.Message(0, "对不起，该帐户已被锁定，请联系管理员！");
                                }
                                else
                                {
                                    userInfo.UserID = userID;
                                    userInfo.UserName = UserModel.UserName;
                                    userInfo.RoleID = UserModel.RoleID;
                                    userInfo.StoresID = Base.Fun.fun.pnumeric(UserModel.StoresID) ? UserModel.StoresID : UI.Sys.stores.GetStoresID();
                                    userInfo.IsBoss = UserModel.IsBoss;
                                    Base.Fun.Session.AddObjSession("AdminUserInfo", userInfo);
                                    Base.Fun.Session.AddObjSession("UserInfo", new string[] { UserModel.UserID.ToString(), UserModel.UserName, UserModel.RoleID });
                                }
                            }
                        }
                        catch (Exception) { }
                    }
                }
            }
            if (Base.Fun.Session.GetObjSession("AdminUserInfo") != null)
            {
                userInfo = Base.Fun.Session.GetObjSession("AdminUserInfo") as Web.Model.UserLogin;
                if (userInfo != null)
                {
                    if (UserRolesApp(1, userInfo.UserID))       //如果修改了权限
                    {
                        Web.Model.Users UserModel = UserBLL.View(userInfo.UserID);
                        if (UserModel != null)
                        {
                            userInfo.RoleID = UserModel.RoleID;
                            Base.Fun.Session.AddObjSession("AdminUserInfo", userInfo);
                        }
                        else
                        {
                            Ami.Message(0, "对不起，管理不存在，请联系管理员！");
                        }
                    }
                }
            }
            return userInfo;
        }
        /// <summary>
        /// 后台用户退出登录，并针对这个用户写入退出时间
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static void LogOut(string userID)
        {
            DAL.Users UserBLL = new DAL.Users();
            UserBLL.UpdateLogout(userID);
            Base.Fun.Session.ClearSession("AdminUserInfo");
            Base.Fun.Cookies.CleanCookies(Base.Fun.Md5.MD5("SyCms_Manage" + HttpContext.Current.Request.Url.AbsoluteUri.ToString().Split('/')[2]));
            HttpContext.Current.Session.Abandon();
        }
        /// <summary>
        /// 根据组ID获取对应的组名称
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public static string GetGroupName(string roleIDS)
        {
            string groupName = "未有权限";
            if (Base.Fun.fun.pnumeric(roleIDS))
            {
                DAL.Roles rDAL = new DAL.Roles();
                Model.Roles rModel = rDAL.View(roleIDS);
                groupName = rModel.RoleName;
            }
            return groupName;
        }

        /// <summary>
        /// 查询用户ID所拥有的角色信息
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <returns>返回dt</returns>
        public static string GetUserRoleIds(string UserID)
        {
            DAL.Users UserBLL = new DAL.Users();
            string RoleIDS = "";
            Web.Model.Users UserModel = UserBLL.View(UserID);
            if (UserModel != null)
            {
                RoleIDS = UserModel.RoleID;
            }
            return RoleIDS;
        }
        /// <summary>
        /// 查询所有角色
        /// </summary>
        /// <returns>返回dt</returns>
        public static int GetUserCount(string userName)
        {
            DAL.Users UserBLL = new DAL.Users();
            return UserBLL.GetUserNameCount(userName);
        }
        /// <summary>
        /// 查询所有角色
        /// </summary>
        /// <returns>返回dt</returns>
        public static int GetUserCount(string userName, string userID)
        {
            DAL.Users UserBLL = new DAL.Users();
            return UserBLL.GetUserNameCount(userName, userID);
        }
        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="userID"></param>
        public static bool ModiPass(string userID, string newPass)
        {
            bool isSucc = false;
            DAL.Users UserBLL = new DAL.Users();
            if (UserBLL.SetUserPass(userID, Base.Fun.Md5.MD5(newPass)) > 0)
            {
                isSucc = true;
            }
            return isSucc;
        }
        /// <summary>
        /// 角色关于文件变化时更新用户角色缓存
        /// </summary>
        /// <param name="RoleIDs">用户角色ID</param>
        public static void UpdateUserRole(string RoleID)
        {
            if (Base.Fun.fun.pnumeric(RoleID))
            {
                Base.Cache.Cache cache = new Base.Cache.Cache();
                DAL.Users UserBLL = new DAL.Users();
                List<Web.Model.Users> UserModelList = UserBLL.ReadOnRoles(RoleID);
                foreach (Web.Model.Users u in UserModelList)
                {
                    cache.clear("User_FileBar_" + u.UserID.ToString());
                }
            }
        }
        /// <summary>
        /// 获得所有没有锁定的用户，li checkbox
        /// </summary>
        /// <param name="InputName"></param>
        /// <param name="SelectUserID"></param>
        /// <returns></returns>
        public static string GetCheckBox(string InputName, string SelectUserID)
        {
            StringBuilder str = new StringBuilder();
            DAL.Users UserBLL = new DAL.Users();
            List<Web.Model.Users> UsersList = UserBLL.Readlist();
            foreach (Web.Model.Users u in UsersList)
            {
                str.Append("<li><input type=\"checkbox\"" + (("," + SelectUserID + ",").Contains("," + u.UserID + ",") ? " checked=\"checked\"" : "") + " name=\"" + InputName + "\" id=\"" + InputName + "_" + u.UserID + "\"><lael for=\"" + InputName + "_" + u.UserID + "\">" + u.UserName + "</label></li>");
            }
            return str.ToString();
        }

        /// <summary>
        /// 获得用户密码
        /// </summary>
        /// <param name="userID">管理员ID</param>
        /// <returns></returns>
        public static string ViewPass(string userID)
        {
            Web.UI.Users UserBLL = new Users();
            Web.Model.Users UserModel = UserBLL.View(userID);
            string PassWord = "";
            if (UserModel != null)
            {
                PassWord = UserModel.UserPass;
            }
            return PassWord;
        }
        /// <summary>
        /// 判断用户密码是否正确
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="PassWord">密码</param>
        public static bool UserPassBool(string userID, string PassWord)
        {
            bool isSucc = false;
            DAL.Users UserBLL = new DAL.Users();
            Web.Model.Users UserModel = UserBLL.View(userID);
            if (UserModel.UserPass.Equals(PassWord))
            {
                isSucc = true;
            }
            return isSucc;
        }
    }
}
