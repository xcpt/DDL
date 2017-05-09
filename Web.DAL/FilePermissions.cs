using System.Collections.Generic;
using System.Data;

namespace Web.DAL
{
    /// <summary>
    /// 文件菜单权限
    /// </summary>
    public class FilePermissions
    {
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public int Delete(string roleid)
        {
            Base.Conn.Database data = new Base.Conn.Database();
            int icount = data.GetRowCount("DELETE FROM [FilePermissions] WHERE [ROLEID] in(" + roleid + ")");
            data.Dispose();
            return icount;
        }
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="RoleID"></param>
        /// <param name="FileID"></param>
        /// <param name="PValue"></param>
        /// <returns></returns>
        public int Insert(string RoleID, string FileID, string PValue)
        {
            Base.Conn.Database data = new Base.Conn.Database();
            int icount = data.GetRowCount("INSERT INTO [FilePermissions]([RoleID],[FileID],[PValue]) VALUES(" + RoleID + "," + FileID + "," + PValue + ")");
            data.Dispose();
            return icount;
        }
        /// <summary>
        /// 读取Role下的信息
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public List<Model.FilePermissions> ReadList(string roleid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData("SELECT [FileID],[Pvalue] FROM [FilePermissions] WHERE [RoleID] in(" + roleid + ") ORDER BY [ID] ASC");
            db.Dispose();
            List<Model.FilePermissions> MFModelList = new List<Model.FilePermissions>();
            foreach (DataRow dr in dt.Rows)
            {
                Model.FilePermissions MFModel = new Model.FilePermissions();
                MFModel.FileID = dr["FileID"].ToString();
                MFModel.Pvalue = dr["Pvalue"].ToString();
                MFModelList.Add(MFModel);
            }
            dt.Dispose();
            return MFModelList;
        }
        /// <summary>
        /// 通过取值关联读取菜单大项的PID
        /// </summary>
        /// <returns></returns>
        public string ReadPid(string roleIDS)
        {
            Base.Conn.Database data = new Base.Conn.Database();
            string strSQL = Base.DataBase.Difference.SelectTop("", "select top 1 [id] from [MenuClass] where [id] in (select [pid] from [MenuClass] where [id] in (select top 1 [mcid] from [MenuFiles] where [id] in(select top 1 [fileid] from [FilePermissions] where [RoleID] in(" + roleIDS + ")))) order by [OrderID],[ID]");
            string bMenuID = data.GetValue(strSQL).ToString();
            data.Dispose();
            return bMenuID;
        }
        /// <summary>
        /// 通过取值关联读取菜单大项的PID
        /// </summary>
        /// <returns></returns>
        public string ReadPid()
        {
            Base.Conn.Database data = new Base.Conn.Database();
            string strSQL = Base.DataBase.Difference.SelectTop("", "select top 1 [id] from [MenuClass] where [id] in (select [pid] from [MenuClass] where [id] in (select [mcid] from [MenuFiles])) order by [OrderID],[ID]");
            string bMenuID = data.GetValue(strSQL).ToString();
            data.Dispose();
            return bMenuID;
        }
        /// <summary>
        /// 获得用户角色所对应的菜单项ID
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="roleIDS"></param>
        /// <param name="CacheTime"></param>
        /// <returns></returns>
        public List<Model.FilePermissions> ReadRoleFileID(string userID, string roleIDS, int CacheTime)
        {
            Base.Cache.Cache cache = new Base.Cache.Cache();
            DataTable dt = cache.getrows("User_FileBar_" + userID, "select distinct [FileID] from [FilePermissions] where [RoleID] in(" + roleIDS + ")", CacheTime);
            cache.Dispose();
            List<Model.FilePermissions> MFPList = new List<Model.FilePermissions>();
            foreach (DataRow dr in dt.Rows)
            {
                Model.FilePermissions MFP = new Model.FilePermissions();
                MFP.FileID = dr["FileID"].ToString();
                MFPList.Add(MFP);
            }
            dt.Dispose();
            return MFPList;
        }
        public class Manager_FilePermissions
        {
            /// <summary>
            /// 删除
            /// </summary>
            /// <param name="roleid"></param>
            /// <returns></returns>
            public int Delete(string roleid)
            {
                Base.Conn.Database data = new Base.Conn.Database();
                int icount = data.GetRowCount("DELETE FROM [FilePermissions] WHERE [ROLEID] in(" + roleid + ")");
                data.Dispose();
                return icount;
            }
            /// <summary>
            /// 插入
            /// </summary>
            /// <param name="RoleID"></param>
            /// <param name="FileID"></param>
            /// <param name="PValue"></param>
            /// <returns></returns>
            public int Insert(string RoleID, string FileID, string PValue)
            {
                Base.Conn.Database data = new Base.Conn.Database();
                int icount = data.GetRowCount("INSERT INTO [FilePermissions]([RoleID],[FileID],[PValue]) VALUES(" + RoleID + "," + FileID + "," + PValue + ")");
                data.Dispose();
                return icount;
            }
            /// <summary>
            /// 读取Role下的信息
            /// </summary>
            /// <param name="roleid"></param>
            /// <returns></returns>
            public List<Model.FilePermissions> ReadList(string roleid)
            {
                Base.Conn.Database db = new Base.Conn.Database();
                DataTable dt = db.GetData("SELECT [FileID],[Pvalue] FROM [FilePermissions] WHERE [RoleID] in(" + roleid + ") ORDER BY [ID] ASC");
                db.Dispose();
                List<Model.FilePermissions> MFModelList = new List<Model.FilePermissions>();
                foreach (DataRow dr in dt.Rows)
                {
                    Model.FilePermissions MFModel = new Model.FilePermissions();
                    MFModel.FileID = dr["FileID"].ToString();
                    MFModel.Pvalue = dr["Pvalue"].ToString();
                    MFModelList.Add(MFModel);
                }
                dt.Dispose();
                return MFModelList;
            }
            /// <summary>
            /// 通过取值关联读取菜单大项的PID
            /// </summary>
            /// <returns></returns>
            public string ReadPid(string roleIDS)
            {
                Base.Conn.Database data = new Base.Conn.Database();
                string strSQL = Base.DataBase.Difference.SelectTop("", "select top 1 [id] from [MenuClass] where [id] in (select [pid] from [MenuClass] where [id] in (select top 1 [mcid] from [MenuFiles] where [id] in(select top 1 [fileid] from [FilePermissions] where [RoleID] in(" + roleIDS + ")))) order by [OrderID],[ID]");
                string bMenuID = data.GetValue(strSQL).ToString();
                data.Dispose();
                return bMenuID;
            }
            /// <summary>
            /// 通过取值关联读取菜单大项的PID
            /// </summary>
            /// <returns></returns>
            public string ReadPid()
            {
                Base.Conn.Database data = new Base.Conn.Database();
                string strSQL = Base.DataBase.Difference.SelectTop("", "select top 1 [id] from [MenuClass] where [id] in (select [pid] from [MenuClass] where [id] in (select [mcid] from [MenuFiles])) order by [OrderID],[ID]");
                string bMenuID = data.GetValue(strSQL).ToString();
                data.Dispose();
                return bMenuID;
            }
            /// <summary>
            /// 获得用户角色所对应的菜单项ID
            /// </summary>
            /// <param name="userID"></param>
            /// <param name="roleIDS"></param>
            /// <param name="CacheTime"></param>
            /// <returns></returns>
            public List<Model.FilePermissions> ReadRoleFileID(string userID, string roleIDS, int CacheTime)
            {
                Base.Cache.Cache cache = new Base.Cache.Cache();
                DataTable dt = cache.getrows("User_FileBar_" + userID, "select distinct [FileID] from [FilePermissions] where [RoleID] in(" + roleIDS + ")", CacheTime);
                cache.Dispose();
                List<Model.FilePermissions> MFPList = new List<Model.FilePermissions>();
                foreach (DataRow dr in dt.Rows)
                {
                    Model.FilePermissions MFP = new Model.FilePermissions();
                    MFP.FileID = dr["FileID"].ToString();
                    MFPList.Add(MFP);
                }
                dt.Dispose();
                return MFPList;
            }
        }
    }
}
