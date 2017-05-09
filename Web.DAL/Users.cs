using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL
{
    public class Users
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="UserModel"></param>
        /// <returns></returns>
        public Web.Model.Users Insert(Web.Model.Users UserModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = {    db.CreateParameter("@userName", UserModel.UserName, DbType.String),
                                        db.CreateParameter("@userPass", UserModel.UserPass, DbType.String), 
                                        db.CreateParameter("@roleID", UserModel.RoleID, DbType.Int32),
                                        db.CreateParameter("@isLock", UserModel.IsLock, DbType.Int32),
                                        db.CreateParameter("@loginTimes", UserModel.LoginTimes, DbType.Int32),
                                        db.CreateParameter("@lastLoginTime",Base.Fun.fun.IsDate(UserModel.LastLoginTime)?UserModel.LastLoginTime:null, DbType.DateTime),
                                        db.CreateParameter("@lastLoginIP", UserModel.LastLoginIP, DbType.String),
                                        db.CreateParameter("@lastLoginOutTime", Base.Fun.fun.IsDate(UserModel.LastLoginOutTime)?UserModel.LastLoginOutTime:null, DbType.DateTime),
                                        db.CreateParameter("@loginErrorTimes", UserModel.LoginErrorTimes, DbType.Int32),
                                        db.CreateParameter("@StoresID", UserModel.StoresID, DbType.Int32),
                                        db.CreateParameter("@IsBoss",UserModel.IsBoss,DbType.Int32)
                               };
            string sql = "INSERT INTO [Users]([userName],[userPass],[roleID],[isLock],[loginTimes],[lastLoginTime],[lastLoginIP],[lastLoginOutTime],[loginErrorTimes],[StoresID],[IsBoss]) VALUES(@userName,@userPass,@roleID,@isLock,@loginTimes,@lastLoginTime,@lastLoginIP,@lastLoginOutTime,@loginErrorTimes,@StoresID,@IsBoss)";
            UserModel.UserID = int.Parse(Base.Fun.fun.IsZero(db.GetNewID(sql, ps).ToString()));
            db.Dispose();
            return UserModel;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="UserModel"></param>
        /// <param name="IsOperate"></param>
        /// <returns></returns>
        public int Update(Web.Model.Users UserModel, bool IsOperate)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = {
                                   db.CreateParameter("@userName", UserModel.UserName, DbType.String),
                                   db.CreateParameter("@roleID", UserModel.RoleID, DbType.Int32),
                                   db.CreateParameter("@StoresID", UserModel.StoresID, DbType.Int32),
                                   db.CreateParameter("@IsBoss",UserModel.IsBoss,DbType.Int32),
                                   db.CreateParameter("@userID",UserModel.UserID, DbType.Int32)
                               };
            string sql = "UPDATE [Users] SET [userName]=@userName,[roleID]=@RoleID" + (IsOperate ? ",[isLock]=" + UserModel.IsLock.ToString() : "") + (string.IsNullOrEmpty(UserModel.UserPass) ? "" : ",[userPass]='" + Base.Fun.Md5.MD5(UserModel.UserPass) + "'") + ",[StoresID]=@StoresID,[IsBoss]=@IsBoss where [userID]=@userID";
            int icount = db.GetRowCount(sql, ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 判断除自己之外其它高级管理员的数量
        /// </summary>
        /// <returns></returns>
        public int IsAdminCount(string userID)
        {
            int count = 0;
            Base.Conn.Database db = new Base.Conn.Database();
            try
            {
                string sql = "Select Count([Userid]) From [Users] where [IsLock]=0 and [RoleID]=1 and [UserID] not in(" + userID + ")";
                count = int.Parse(Base.Fun.fun.IsZero(db.GetValue(sql).ToString()));
            }
            catch (Exception ex)
            {
                Base.Error.Error.WriteError(ex);
            }
            finally
            {
                db.Dispose();
            }
            return count;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int Delete(string userID)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string sql = string.Format("DELETE FROM [Users] WHERE [userID] in({0})", userID);
            int icount = db.GetRowCount(sql);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 更新它的值为0
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int Update_DepartmentID(string DepartmentID)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            int count = db.GetRowCount("Update [Users] Set [DepartmentID]=0 Where [DepartmentID]=" + DepartmentID);
            db.Dispose();
            return count;
        }
        /// <summary>
        /// 设置用户的锁定状态
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="IsLock"></param>
        /// <returns></returns>
        public int SetLock(string userID, string IsLock)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            int count = db.GetRowCount("Update [Users] Set [IsLock]=" + IsLock + " Where [UserId]=" + userID);
            db.Dispose();
            return count;
        }
        /// <summary>
        /// 显示单条记录
        /// </summary>
        /// <returns>返回真假</returns>
        public Web.Model.Users View(string userID)
        {
            Web.Model.Users UserModel = null;
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt1 = new DataTable();
            try
            {
                dt1 = db.GetData(string.Format("SELECT [userID],[UserName],[UserPass],[RoleID],[IsLock],[LoginTimes],[LastLoginTime],[LastLoginIP],[LastLoginOutTime],[LoginErrorTimes],[StoresID],[IsBoss] FROM [Users] where [userID]={0}", userID));
                if (dt1.Rows.Count > 0)
                {
                    UserModel = DatRowToModel(dt1.Rows[0]);
                }
            }
            catch (Exception ex)
            {
                Base.Error.Error.WriteError(ex);
            }
            finally
            {
                dt1.Dispose();
                db.Dispose();
            }
            return UserModel;
        }
        /// <summary>
        /// 根据用户名和密码读取用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPass"></param>
        /// <returns></returns>
        public Web.Model.Users Read(string userName)
        {
            Base.Conn.Database data = new Base.Conn.Database();
            DbParameter[] ps = {
                                       data.CreateParameter("@UserName", userName, DbType.String)
                                   };
            DataTable dt = data.GetData("SELECT [userID],[UserName],[UserPass],[RoleID],[IsLock],[LoginTimes],[LastLoginTime],[LastLoginIP],[LastLoginOutTime],[LoginErrorTimes],[StoresID],[IsBoss] FROM [Users] WHERE [UserName]=@UserName", ps);
            data.Dispose();
            Web.Model.Users UserModel = null;
            if (dt.Rows.Count > 0)
            {
                UserModel = DatRowToModel(dt.Rows[0]);
            }
            dt.Dispose();
            return UserModel;
        }
        /// <summary>
        /// 保存 登录信息
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="LastLoginIP"></param>
        /// <returns></returns>
        public int SaveLoginMessage(string userID, string LastLoginIP)
        {
            Base.Conn.Database data = new Base.Conn.Database();
            DbParameter[] ps1 = {
                                    data.CreateParameter("@LastLoginTime",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),DbType.DateTime),
                                    data.CreateParameter("@LastLoginIP", LastLoginIP, DbType.String),
                                    data.CreateParameter("@userID", userID, DbType.Int32)
                                };
            int icount = data.GetRowCount("UPDATE [Users] SET [LoginTimes]=[LoginTimes]+1,[LastLoginTime]=@LastLoginTime,[LastLoginIP]=@LastLoginIP,[LoginErrorTimes]=0 WHERE [userID]=@userID", ps1);
            data.Dispose();
            return icount;
        }
        /// <summary>
        /// 错误次数归零，到时间
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="LastLoginIP"></param>
        /// <returns></returns>
        public int SaveLoginErrorMessage(string userID, string LastLoginIP)
        {
            Base.Conn.Database data = new Base.Conn.Database();
            DbParameter[] ps1 = {
                                        data.CreateParameter("@LastLoginTime",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),DbType.DateTime),
                                        data.CreateParameter("@LastLoginIP", LastLoginIP, DbType.String)
                                };
            int icount = data.GetRowCount("UPDATE [Users] SET [LastLoginTime]=@LastLoginTime,[LastLoginIP]=@LastLoginIP,[LoginErrorTimes]=0 WHERE [userID]=" + userID, ps1);
            return icount;
        }
        /// <summary>
        /// 添加错误次数
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="Last"></param>
        /// <returns></returns>
        public int SaveLoginErrorNum(string userID, string LastLoginIP)
        {
            Base.Conn.Database data = new Base.Conn.Database();
            DbParameter[] ps1 = {
                                    data.CreateParameter("@LastLoginTime",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),DbType.DateTime),
                                    data.CreateParameter("@LastLoginIP", LastLoginIP, DbType.String)
                                };
            int icount = data.GetRowCount("UPDATE [Users] SET [LoginErrorTimes]=[LoginErrorTimes]+1,[LastLoginTime]=@LastLoginTime,[LastLoginIP]=@LastLoginIP WHERE [userID]=" + userID, ps1);///错误次数+1，记录上次登录的时间和IP
            data.Dispose();
            return icount;
        }
        /// <summary>
        /// 显示列表
        /// </summary>
        /// <param name="PageSize">每页数量</param>
        /// <param name="userName">搜索用户名</param>
        /// <param name="UserID">非高级管理员填写当前用户ID</param>
        /// <param name="admindepartmentid">所属部门</param>
        /// <returns>返回字段串</returns>
        public string View(int PageSize, string userName, string StoresID, bool SuperAdmin)
        {
            StringBuilder str = new StringBuilder();
            DataTable dt = new DataTable();
            Base.Page.Dividepage page = new Base.Page.Dividepage();
            try
            {
                page.PageSize = PageSize;
                page.TableName = "[Users] as a left join [Sys_Stores] as b on (a.[StoresID]=b.[StoresID])";
                page.OrderBy = "order by a.[userID]";
                page.Index = "a.[userID]";
                page.Field = "a.[userID],b.[Title],a.[userName],a.[RoleID],a.[LastLoginIP],a.[LastLoginTime],a.[LoginTimes],a.[islock],a.[LoginErrorTimes]";
                page.Filter = "1=1 ";
                if (userName.Length > 0)
                {
                    page.CreateParameter("@UserName", userName, DbType.String);
                    page.Filter += " and a.[UserName] Like " + Base.DataBase.Difference.SplitJointString("", "'%'", "@UserName", "'%'");
                }
                if (!SuperAdmin)
                {
                    page.Filter += "and a.[RoleID]<>1 and a.[StoresID]=" + StoresID;
                }
                dt = page.getrows();
                str.Append(Base.Conn.Json.DataTable2Json(page.Page, page.TotalRow, dt, null));
            }
            catch (Exception ex)
            {
                //错误记录
                Base.Error.Error.WriteError(ex);
            }
            finally
            {
                dt.Dispose();
                page.Dispose();
            }
            return str.ToString();
        }
        /// <summary>
        /// 更新退出信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int UpdateLogout(string userID)
        {
            Base.Conn.Database data = new Base.Conn.Database();
            ///编写SQL语句
            DbParameter[] ps = {
                                   data.CreateParameter("@LastLoginOutTime",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),DbType.DateTime),
                                   data.CreateParameter("@userID",userID,DbType.Int32)
                                   };
            string strSQL = "UPDATE [Users] SET [LastLoginOutTime]=@LastLoginOutTime WHERE [userID]=@userID";
            int icount = data.GetRowCount(strSQL, ps);
            data.Dispose();
            return icount;
        }
        /// <summary>
        /// 返回重名的数量
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public int GetUserNameCount(string userName)
        {
            Base.Conn.Database data = new Base.Conn.Database();
            DbParameter[] ps = {
                                        data.CreateParameter("@userName", userName, DbType.String)
                                    };
            int icount = int.Parse(data.GetValue("select count([UserID]) From [Users] where [userName]=@userName", ps).ToString());
            data.Dispose();
            return icount;
        }
        /// <summary>
        /// 返回重名的数量
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public int GetUserNameCount(string userName, string userID)
        {
            Base.Conn.Database data = new Base.Conn.Database();
            DbParameter[] ps = {
                                   data.CreateParameter("@userID",userID,DbType.Int32),
                                   data.CreateParameter("@userName", userName, DbType.String)
                                };
            int icount = int.Parse(data.GetValue("select count([UserID]) From [Users] where [userID]<>@userID and [userName]=@userName", ps).ToString());
            data.Dispose();
            return icount;
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="newPass"></param>
        /// <returns></returns>
        public int SetUserPass(string userID, string newPass)
        {
            Base.Conn.Database data = new Base.Conn.Database();
            DbParameter[] ps = {
                                        data.CreateParameter("@UserPass", newPass, DbType.String),
                                        data.CreateParameter("@userid", userID, DbType.Int32)
                                    };
            string strSQL = "update [Users] set [UserPass]=@UserPass where [userid]=@userid";
            int icount = data.GetRowCount(strSQL, ps);
            data.Dispose();
            return icount;
        }

        /// <summary>
        /// 修改门店
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="newPass"></param>
        /// <returns></returns>
        public int SetStoresID(string userID, string StoresID)
        {
            Base.Conn.Database data = new Base.Conn.Database();
            DbParameter[] ps = {
                                data.CreateParameter("@StoresID", StoresID, DbType.Int32),
                                data.CreateParameter("@userid", userID, DbType.Int32)
                                };
            string strSQL = "update [Users] set [StoresID]=@StoresID where [userid]=@userid";
            int icount = data.GetRowCount(strSQL, ps);
            data.Dispose();
            return icount;
        }

        /// <summary>
        /// 获得包含某个角色的所有用户ID 模型只UserID有值
        /// </summary>
        /// <returns></returns>
        public List<Web.Model.Users> ReadOnRoles(string RoleID)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData("SELECT [UserID] FROM [Users] Where [RoleID]=" + RoleID);
            db.Dispose();
            List<Web.Model.Users> UserModelList = new List<Model.Users>();
            foreach (DataRow dr in dt.Rows)
            {
                Web.Model.Users UserModel = new Model.Users();
                UserModel.UserID = int.Parse(dr["UserID"].ToString());
                UserModelList.Add(UserModel);
            }
            dt.Dispose();
            return UserModelList;
        }
        /// <summary>
        /// 读取没有被锁定的用户列表
        /// </summary>
        /// <returns></returns>
        public List<Web.Model.Users> Readlist()
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData("SELECT [UserID],[RoleID],[UserName] FROM [Users] where [islock]=0");
            db.Dispose();
            List<Web.Model.Users> UsersList = new List<Model.Users>();
            foreach (DataRow dr in dt.Rows)
            {
                Web.Model.Users UsersModel = new Model.Users();
                UsersModel.UserID = int.Parse(dr["UserID"].ToString());
                UsersModel.UserName = dr["UserName"].ToString();
                UsersModel.RoleID = dr["RoleID"].ToString();
                UsersList.Add(UsersModel);
            }
            dt.Dispose();
            return UsersList;
        }
        /// <summary>
        /// 读取没有被锁定的用户列表
        /// </summary>
        /// <returns></returns>
        public List<Web.Model.Users> Readlist(string StoresID)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData("SELECT [UserID],[RoleID],[UserName] FROM [Users] where [StoresID]=@StoresID", db.CreateParameter("@StoresID", StoresID, DbType.Int32));
            db.Dispose();
            List<Web.Model.Users> UsersList = new List<Model.Users>();
            foreach (DataRow dr in dt.Rows)
            {
                Web.Model.Users UsersModel = new Model.Users();
                UsersModel.UserID = int.Parse(dr["UserID"].ToString());
                UsersModel.UserName = dr["UserName"].ToString();
                UsersModel.RoleID = dr["RoleID"].ToString();
                UsersList.Add(UsersModel);
            }
            dt.Dispose();
            return UsersList;
        }
        /// <summary>
        /// datarow to model
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private Web.Model.Users DatRowToModel(DataRow dr)
        {
            Web.Model.Users UserModel = new Model.Users();
            UserModel.UserID = int.Parse(dr["UserID"].ToString());
            UserModel.UserName = dr["UserName"].ToString();
            UserModel.UserPass = dr["UserPass"].ToString();
            UserModel.RoleID = dr["RoleID"].ToString();
            UserModel.IsLock = int.Parse(Base.Fun.fun.IsZero(dr["IsLock"].ToString()));
            UserModel.LoginTimes = int.Parse(Base.Fun.fun.IsZero(dr["LoginTimes"].ToString()));
            UserModel.LastLoginTime = dr["LastLoginTime"].ToString();
            UserModel.LastLoginIP = dr["LastLoginIP"].ToString();
            UserModel.LastLoginOutTime = dr["LastLoginOutTime"].ToString();
            UserModel.LoginErrorTimes = int.Parse(Base.Fun.fun.IsZero(dr["LoginErrorTimes"].ToString()));
            UserModel.StoresID = dr["StoresID"].ToString();
            UserModel.IsBoss = dr["IsBoss"].ToString();
            return UserModel;
        }
    }
}
