using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Web.DAL
{
    public class MenuClass
    {
        /// <summary>
        /// 更新排序
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="ID"></param>
        public void SetOrder(string OrderID, string ID)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            db.ExeSql("UPDATE [MenuClass] SET [OrderID]=" + OrderID + " WHERE [ID]=" + ID);
            db.Dispose();
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="MCModel"></param>
        /// <returns></returns>
        public Web.Model.MenuClass Insert(Web.Model.MenuClass MCModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                                   db.CreateParameter("@pid",MCModel.Pid,DbType.Int32),
                                   db.CreateParameter("@name",MCModel.Name,DbType.String),
                                   db.CreateParameter("@directoryName",MCModel.DirectoryName,DbType.String),
                                   db.CreateParameter("@orderId",MCModel.OrderId,DbType.Int32),
                                   db.CreateParameter("@issys",MCModel.Issys,DbType.Int32),
                                   db.CreateParameter("@ishow",MCModel.Ishow,DbType.Int32)
                                   };
            string sql = "INSERT INTO [MenuClass]([pid],[name],[directoryName],[orderId],[issys],[ishow])VALUES(@pid,@name,@directoryName,@orderId,@issys,@ishow)";
            MCModel.Id = db.GetNewID(sql, ps).ToString();
            db.Dispose();
            return MCModel;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="MCModel"></param>
        /// <returns></returns>
        public int Update(Web.Model.MenuClass MCModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                                   db.CreateParameter("@pid",MCModel.Pid,DbType.Int32),
                                   db.CreateParameter("@name",MCModel.Name,DbType.String),
                                   db.CreateParameter("@directoryName",MCModel.DirectoryName,DbType.String),
                                   db.CreateParameter("@orderId",MCModel.OrderId,DbType.Int32),
                                   db.CreateParameter("@ishow",MCModel.Ishow,DbType.Int32),
                                   db.CreateParameter("@ID",Base.Fun.fun.IsZero(MCModel.Id),DbType.Int32)
                                   };
            string sql = "UPDATE [MenuClass] SET [pid] = @pid,[name]=@name,[directoryName]=@directoryName,[orderId]=@orderId,[ishow]=@ishow WHERE [ID]=@ID";
            int icount = db.GetRowCount(sql, ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 查找插件里的某个目录，返回ID号
        /// </summary>
        /// <param name="directoryName">路径名称</param>
        /// <returns></returns>
        public string Select_Plus(string directoryName)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string id = db.GetValue("Select ID From [MenuClass] Where [pid]=" + GetDirectoryID("plus", "0") + " and [DirectoryName]=@DirectoryName", db.CreateParameter("@DirectoryName", directoryName, DbType.String)).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 查找某个PID下是否存在名称为什么的项目，返回ID号
        /// </summary>
        /// <param name="Name">名称</param>
        /// <param name="Pid">上级ID</param>
        /// <returns></returns>
        public string Select_ID(string Name, string Pid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string id = db.GetValue("Select ID From [MenuClass] Where [pid]=" + Pid + " and [name]=@name", db.CreateParameter("@name", Name, DbType.String)).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 根据目录之类的。PID，返回ID信息
        /// </summary>
        /// <param name="DirectoryName">路径</param>
        /// <param name="Pid">上级ID</param>
        /// <returns></returns>
        public string GetDirectoryID(string DirectoryName, string Pid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string id = db.GetValue("Select ID From [MenuClass] Where [pid]=" + Pid + " and [DirectoryName]=@DirectoryName", db.CreateParameter("@DirectoryName", DirectoryName, DbType.String)).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 修改名称
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public int SetName(string id, string name)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            int icount = db.GetRowCount("UPDATE [MenuClass] SET [name]=@name WHERE [ID]=@ID", db.CreateParameter("@name", name, DbType.String), db.CreateParameter("@ID", id, DbType.Int32));
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 返回分类名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetName(string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string cname = db.GetValue("select [name] from [MenuClass] where [id]=" + id).ToString();
            db.Dispose();
            return cname;
        }
        /// <summary>
        /// 删除类关联的文件信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteOnClassFile(string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            int icount = db.GetRowCount(string.Format("Delete From [MenuFiles] Where ([mcid] in ({0}) or [mcid] in(select [id] From [MenuClass] where [pid] in ({0})))", id));
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 删除类及类下类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteOnClass(string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            int icount = db.GetRowCount(string.Format("DELETE FROM [MenuClass] WHERE [pid] in({0}) or [ID] in({0})", id));
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="roleid"></param>
        /// <param name="MoldId"></param>
        /// <param name="sMenuIDS"></param>
        /// <returns></returns>
        public List<Web.Model.MenuClass> ReadList(int roleid, string MoldId, string sMenuIDS)
        {
            string strSQL = "select [id],[Pid],[Name],[directoryName],[orderId],[ishow],[issys] from [MenuClass] where [pid]=" + Base.Fun.fun.IsZero(MoldId) + " and [Ishow]=1 ";
            if (roleid == 0)
            {
                if (Base.Fun.fun.pnumeric(sMenuIDS.Replace(",", "")))
                {
                    strSQL += " and [id] in(" + sMenuIDS + ")";
                }
                else
                {
                    strSQL += " and [id] in(0)";
                }
            }
            strSQL += " order by [orderid] asc,[id] asc";
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(strSQL);
            db.Dispose();
            List<Web.Model.MenuClass> MCModelList = new List<Model.MenuClass>();
            foreach (DataRow dr in dt.Rows)
            {
                MCModelList.Add(DataRowToModel(dr));
            }
            dt.Dispose();
            return MCModelList;
        }
        /// <summary>
        /// 读取所有分类信息
        /// </summary>
        /// <returns></returns>
        public List<Web.Model.MenuClass> ReadList()
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData("select [ID],[PID],[Name],[DirectoryName],[OrderID],[Ishow],[IsSys] from [MenuClass] order by [orderid] asc,[id] asc");
            db.Dispose();
            List<Web.Model.MenuClass> MCList = new List<Model.MenuClass>();
            foreach (DataRow dr in dt.Rows)
            {
                MCList.Add(DataRowToModel(dr));
            }
            dt.Dispose();
            return MCList;
        }
        /// <summary>
        /// 读取单条
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Web.Model.MenuClass Read(string ID)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt1 = new DataTable();
            dt1 = db.GetData(string.Format("SELECT [ID],[PID],[Name],[DirectoryName],[OrderID],[Ishow],[IsSys] FROM [MenuClass] where [id]={0}", Base.Fun.fun.IsZero(ID)));
            db.Dispose();
            Web.Model.MenuClass MCModel = null;
            if (dt1.Rows.Count > 0)
            {
                MCModel = DataRowToModel(dt1.Rows[0]);
            }
            dt1.Dispose();
            return MCModel;
        }
        /// <summary>
        /// 查询一级栏目以及子栏目
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetPidList(string id)
        {
            string str = "";
            if (int.Parse(id) != 0)
            {
                string sql = "select " + Base.DataBase.Difference.SplitJointString("", "(select [name] from [MenuClass] where [id]=a.[pid])", "'&nbsp;&gt;&nbsp;'", "[name]") + " as name from [MenuClass] as a where [id]=" + id;
                Base.Conn.Database db = new Base.Conn.Database();
                str = db.GetValue(sql).ToString();
                db.Dispose();
            }
            return str;
        }
        /// <summary>
        /// 设置是否可见的值
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Ishow"></param>
        /// <returns></returns>
        public int SetIshow(string id, string Ishow)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            int count = db.GetRowCount("Update [MenuClass] Set [Ishow]=" + Ishow + " Where [id]=" + id);
            db.Dispose();
            return count;
        }
        /// <summary>
        /// 读取一个分类下面的子类，排序小于现在排序的2个信息
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public List<Web.Model.MenuClass> ReadClassPIDTwo(string pid, string orderId)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(Base.DataBase.Difference.SelectTop("", "select top 2 [ID],[PID],[Name],[DirectoryName],[OrderID],[Ishow],[IsSys] From [MenuClass] where [pid]=" + Base.Fun.fun.IsZero(pid) + " and [orderid]<=" + orderId + " order by [orderid] desc,[id] desc"));
            db.Dispose();
            List<Web.Model.MenuClass> MCList = new List<Model.MenuClass>();
            foreach (DataRow dr in dt.Rows)
            {
                MCList.Add(DataRowToModel(dr));
            }
            dt.Dispose();
            return MCList;
        }
        /// <summary>
        /// 读取带子菜单数量的上级菜单
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public List<Web.Model.MenuClassFileCount> ReadClassCount(string pid, int roleid, string bMenuIDS)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = new DataTable();
            if (Base.Fun.fun.pnumeric(pid))
            {
                dt = db.GetData("select a.[ID],a.[PID],a.[Name],a.[DirectoryName],a.[OrderID],a.[Ishow],a.[IsSys],(select count(b.[id]) from [MenuFiles] as b where b.[mcid]=a.[id]) as FileCount From [MenuClass] as a where a.[Ishow]=1 and a.[pid]=" + pid + (roleid == 0 ? " and a.[id] in(" + bMenuIDS + ")" : "") + " order by a.[orderid],a.[id]");
            }
            else
            {
                dt = db.GetData("select a.[ID],a.[PID],a.[Name],a.[DirectoryName],a.[OrderID],a.[Ishow],a.[IsSys],(select count(b.[id]) from [MenuClass] as b where b.[pid]=a.[id]) as FileCount From [MenuClass] as a where a.[Ishow]=1 and a.[pid]=" + pid + (roleid == 0 ? " and a.[id] in(" + bMenuIDS + ")" : "") + " order by a.[orderid],a.[id]");
            }
            db.Dispose();
            List<Web.Model.MenuClassFileCount> MCFCList = new List<Model.MenuClassFileCount>();
            foreach (DataRow dr in dt.Rows)
            {
                Web.Model.MenuClassFileCount MCFC = new Model.MenuClassFileCount();
                MCFC.Id = dr["id"].ToString();
                MCFC.Pid = dr["PID"].ToString();
                MCFC.Name = dr["Name"].ToString();
                MCFC.DirectoryName = dr["DirectoryName"].ToString();
                MCFC.OrderId = dr["OrderId"].ToString();
                MCFC.Ishow = dr["Ishow"].ToString();
                MCFC.Issys = dr["Issys"].ToString();
                MCFC.FileCount = dr["FileCount"].ToString();
                MCFCList.Add(MCFC);
            }
            dt.Dispose();
            return MCFCList;
        }
        /// <summary>
        /// DataRowToModel
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private Web.Model.MenuClass DataRowToModel(DataRow dr)
        {
            Web.Model.MenuClass MCModel = new Model.MenuClass();
            MCModel.Id = dr["id"].ToString();
            MCModel.Pid = dr["PID"].ToString();
            MCModel.Name = dr["Name"].ToString();
            MCModel.DirectoryName = dr["DirectoryName"].ToString();
            MCModel.OrderId = dr["OrderId"].ToString();
            MCModel.Ishow = dr["Ishow"].ToString();
            MCModel.Issys = dr["Issys"].ToString();
            return MCModel;
        }
    }
}
