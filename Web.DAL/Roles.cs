using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL
{
    /// <summary>
    /// 角色
    /// </summary>
    public class Roles
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="RoleModel"></param>
        /// <returns></returns>
        public Web.Model.Roles Insert(Web.Model.Roles RoleModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                                   db.CreateParameter("@roleName", RoleModel.RoleName, DbType.String), 
                                   db.CreateParameter("@roleDescription", RoleModel.RoleDescription, DbType.String),
                                   db.CreateParameter("@storesID",RoleModel.StoresID,DbType.Int32)
                               };
            string sql = "INSERT INTO [Roles]([roleName],[roleDescription],[storesID])VALUES(@roleName,@roleDescription,@storesID)";
            RoleModel.Id = db.GetNewID(sql, ps).ToString();
            db.Dispose();
            return RoleModel;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="RoleModel"></param>
        /// <returns></returns>
        public int Update(Web.Model.Roles RoleModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                                   db.CreateParameter("@roleName", RoleModel.RoleName, DbType.String), 
                                   db.CreateParameter("@roleDescription", RoleModel.RoleDescription, DbType.String), 
                                   db.CreateParameter("@storesID",RoleModel.StoresID,DbType.Int32),
                                   db.CreateParameter("@ID", Base.Fun.fun.IsZero(RoleModel.Id), DbType.Int32) 
                               };
            string sql = "UPDATE [Roles] SET [roleName]=@roleName,[roleDescription]=@roleDescription,[storesID]=@storesID WHERE [ID]=@ID";
            int icount = db.GetRowCount(sql, ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int Delete(string ids)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string sql = string.Format("DELETE FROM [Roles] WHERE [ID] in({0}) and [id]<>1", ids);
            int icount = db.GetRowCount(sql);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 获得用户角色名存在不存在ID
        /// </summary>
        /// <param name="RoleName"></param>
        /// <returns></returns>
        public string GetRID(string RoleName)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string sql = "Select [ID] FROM [Roles] WHERE [RoleName]=@RoleName";
            string ID = db.GetValue(sql, db.CreateParameter("@RoleName", RoleName, DbType.String)).ToString();
            db.Dispose();
            return ID;
        }
        /// <summary>
        /// 获得用户角色名存在不存在ID
        /// </summary>
        /// <param name="RoleName"></param>
        /// <returns></returns>
        public string GetRID(string RoleName, string StoresID)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string sql = "Select [ID] FROM [Roles] WHERE [StoresID]=@StoresID and [RoleName]=@RoleName";
            string ID = db.GetValue(sql, db.CreateParameter("@StoresID", StoresID, DbType.Int32), db.CreateParameter("@RoleName", RoleName, DbType.String)).ToString();
            db.Dispose();
            return ID;
        }
        /// <summary>
        /// 获得用户角色名存在不存在ID
        /// </summary>
        /// <param name="RoleName"></param>
        /// <returns></returns>
        public string GetRID(string RoleName, string StoresID, string RoleID)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string sql = "Select [ID] FROM [Roles] WHERE [StoresID]=@StoresID and [RoleID]<>@RoleID and [RoleName]=@RoleName";
            string ID = db.GetValue(sql, db.CreateParameter("@StoresID", StoresID, DbType.Int32), db.CreateParameter("@RoleID", RoleID, DbType.Int32), db.CreateParameter("@RoleName", RoleName, DbType.String)).ToString();
            db.Dispose();
            return ID;
        }
        /// <summary>
        /// 显示单条记录
        /// </summary>
        /// <returns>返回真假</returns>
        public Web.Model.Roles View(string id)
        {
            Web.Model.Roles RoleModel = null;
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt1 = new DataTable();
            try
            {
                dt1 = db.GetData(string.Format("SELECT [Id],[RoleName],[RoleDescription],[storesID] FROM [Roles] where [id]={0}", Base.Fun.fun.IsZero(id)));
                if (dt1.Rows.Count > 0)
                {
                    RoleModel = new Model.Roles();
                    RoleModel.Id = dt1.Rows[0]["ID"].ToString();
                    RoleModel.RoleName = dt1.Rows[0]["RoleName"].ToString();
                    RoleModel.RoleDescription = dt1.Rows[0]["RoleDescription"].ToString();
                    RoleModel.StoresID = dt1.Rows[0]["storesID"].ToString();
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
            return RoleModel;
        }
        /// <summary>
        /// 读取相应ID的信息 id rolename
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public List<Web.Model.Roles> ReadList()
        {
            Base.Conn.Database data = new Base.Conn.Database();
            DataTable dt = new DataTable();
            dt = data.GetData("select [id],[roleName],[storesID] From [Roles] order by [id] asc");
            data.Dispose();
            List<Web.Model.Roles> RolesModelList = new List<Model.Roles>();
            foreach (DataRow dr in dt.Rows)
            {
                Web.Model.Roles RoleModel = new Model.Roles();
                RoleModel.Id = dr["ID"].ToString();
                RoleModel.RoleName = dr["RoleName"].ToString();
                RoleModel.StoresID = dr["storesID"].ToString();
                RolesModelList.Add(RoleModel);
            }
            dt.Dispose();
            return RolesModelList;
        }
        /// <summary>
        /// 读取相应ID的信息 id rolename
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public List<Web.Model.Roles> ReadList(string Ids)
        {
            Base.Conn.Database data = new Base.Conn.Database();
            DataTable dt = new DataTable();
            dt = data.GetData("select [id],[roleName],[storesID] From [Roles] where [id] in (" + Ids + ") order by [id] asc");
            data.Dispose();
            List<Web.Model.Roles> RolesModelList = new List<Model.Roles>();
            foreach (DataRow dr in dt.Rows)
            {
                Web.Model.Roles RoleModel = new Model.Roles();
                RoleModel.Id = dr["ID"].ToString();
                RoleModel.RoleName = dr["RoleName"].ToString();
                RoleModel.StoresID = dr["storesID"].ToString();
                RolesModelList.Add(RoleModel);
            }
            dt.Dispose();
            return RolesModelList;
        }
        /// <summary>
        /// 读取相应ID的信息 id rolename
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public List<Web.Model.Roles> ReadListNoIDS(string Ids)
        {
            Base.Conn.Database data = new Base.Conn.Database();
            DataTable dt = new DataTable();
            dt = data.GetData("select [id],[roleName],[storesID] From [Roles] where [id] not in (" + Ids + ") order by [id] asc");
            data.Dispose();
            List<Web.Model.Roles> RolesModelList = new List<Model.Roles>();
            foreach (DataRow dr in dt.Rows)
            {
                Web.Model.Roles RoleModel = new Model.Roles();
                RoleModel.Id = dr["ID"].ToString();
                RoleModel.RoleName = dr["RoleName"].ToString();
                RoleModel.StoresID = dr["storesID"].ToString();
                RolesModelList.Add(RoleModel);
            }
            dt.Dispose();
            return RolesModelList;
        }
        /// <summary>
        /// 显示列表
        /// </summary>
        /// <param name="PageSize">每页数量</param>
        /// <returns>返回字段串</returns>
        public string View(int PageSize, bool IsSupperAdmin, string storesid, string roleName)
        {
            StringBuilder str = new StringBuilder();
            DataTable dt = new DataTable();
            Base.Page.Dividepage page = new Base.Page.Dividepage();
            try
            {
                page.PageSize = PageSize;
                page.TableName = "[Roles] as a Left join [Sys_stores] as b on a.[storesID]=b.[storesid]";
                page.OrderBy = "order by a.[id]";
                page.Index = "a.[id]";
                page.Field = "a.[Id],b.[Title] as storesName,a.[RoleName],a.[RoleDescription]";
                List<string> WhereStr = new List<string>();
                if (!IsSupperAdmin)
                {
                    WhereStr.Add("a.[storesID]=" + storesid);
                }
                if (roleName.Length > 0)
                {
                    page.CreateParameter("@RoleName", roleName, DbType.String);
                    WhereStr.Add(" a.[RoleName] like " + Base.DataBase.Difference.SplitJointString("", "'%'", "@RoleName", "'%'"));
                }
                page.Filter = string.Join(" and ", WhereStr.ToArray());
                dt = page.getrows();
                str.Append(Base.Conn.Json.DataTable2Json(page.Page, page.TotalRow, dt, null));
            }
            catch (Exception ex)
            {
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
        /// 复制权限到另一角色
        /// </summary>
        /// <param name="FromID">来源角色ID</param>
        /// <param name="ToID">目标角色ID</param>
        public int CopyFilePermissions(string FromID, string ToID)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            int icount = db.GetRowCount("INSERT INTO [FilePermissions] ([Roleid],[FileID],[Pvalue]) select " + ToID + ",[FileID],[Pvalue] from [FilePermissions] where [Roleid]=" + FromID);
            db.Dispose();
            return icount;
        }
    }
}