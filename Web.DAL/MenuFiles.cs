using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Web.DAL
{
    public class MenuFiles
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="OrderID"></param>
        public void SetOrder(string OrderID, string ID)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            db.ExeSql("UPDATE [MenuFiles] SET [OrderID]=" + OrderID + " WHERE [ID]=" + ID);
            db.Dispose();
        }
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="MFModel"></param>
        /// <returns></returns>
        public Web.Model.MenuFiles Insert(Web.Model.MenuFiles MFModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = {
                                   db.CreateParameter("@mcid",MFModel.Mcid, DbType.Int32),
                                   db.CreateParameter("@fileName",MFModel.FileName, DbType.String),
                                   db.CreateParameter("@orderId",MFModel.OrderId, DbType.Int32),
                                   db.CreateParameter("@ishow",MFModel.Ishow, DbType.Int32),
                                   db.CreateParameter("@issys",MFModel.Issys, DbType.Int32),
                                   db.CreateParameter("@Url", MFModel.Url, DbType.String)
                               };
            string sql = "INSERT INTO [MenuFiles]([mcid],[fileName],[orderId],[ishow],[issys],[Url])VALUES(@mcid,@fileName,@orderId,@ishow,@issys,@Url)";
            MFModel.Id = db.GetNewID(sql, ps).ToString();
            db.Dispose();
            return MFModel;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="MFModel"></param>
        /// <returns></returns>
        public int Update(Web.Model.MenuFiles MFModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = {
                                   db.CreateParameter("@mcid", MFModel.Mcid, DbType.Int32),
                                   db.CreateParameter("@fileName", MFModel.FileName, DbType.String),
                                   db.CreateParameter("@orderId", MFModel.OrderId, DbType.Int32),
                                   db.CreateParameter("@ishow", MFModel.Ishow, DbType.Int32),
                                   db.CreateParameter("@Url", MFModel.Url, DbType.String),
                                   db.CreateParameter("@ID", Base.Fun.fun.IsZero(MFModel.Id), DbType.Int32)
                               };
            string sql = "UPDATE [MenuFiles] SET [mcid] = @mcid,[fileName]=@fileName,[orderId]=@orderId,[ishow]=@ishow,[Url]=@Url WHERE [ID]=@ID";
            int icount = db.GetRowCount(sql, ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int Delete(string ID)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string sql = string.Format("DELETE FROM [MenuFiles] WHERE [ID] in({0}) and [issys]=0", ID);
            int icount = db.GetRowCount(sql);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 获取一个目录下一个文件路径的存在filename,mcid
        /// </summary>
        /// <returns></returns>
        public int GetFileNameCount(string mcid, string fileName)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = {
                                   db.CreateParameter("@fileName", fileName, DbType.String),
                                   db.CreateParameter("@mcid", mcid, DbType.Int32)
                               };
            string sql = "select count(Id) from [MenuFiles] where [fileName]=@fileName and [mcid]=@mcid";
            int i = int.Parse(db.GetValue(sql, ps).ToString());
            db.Dispose();
            return i;
        }
        /// <summary>
        /// 修改分类下面所有的名称
        /// </summary>
        /// <param name="mcid"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public int SetName(string mcid, string name)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            int icount = db.GetRowCount("UPDATE [MenuFiles] SET [fileName]=@name WHERE [mcid]=@ID", db.CreateParameter("@name", name, DbType.String), db.CreateParameter("@ID", mcid, DbType.Int32));
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Web.Model.MenuFiles Read(string id)
        {
            Web.Model.MenuFiles MFModel = null;
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt1 = db.GetData(string.Format("SELECT [ID],[MCID],[FileName],[OrderID],[Ishow],[Url],[AllUrl],[issys] FROM [MenuFiles] where [id]={0}", Base.Fun.fun.IsZero(id)));
            if (dt1.Rows.Count > 0)
            {
                MFModel = DataRowToModel(dt1.Rows[0]);
            }
            db.Dispose();
            return MFModel;
        }
        /// <summary>
        /// 读取分类下文件信息
        /// </summary>
        /// <param name="MCID"></param>
        /// <returns></returns>
        public List<Web.Model.MenuFiles> ReadList(string MCID)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData("select [ID],[MCID],[FileName],[OrderID],[Ishow],[Url],[AllUrl],[issys] from [MenuFiles] where [MCID]=" + MCID + " order by [orderid] asc,[id] asc");
            db.Dispose();
            List<Web.Model.MenuFiles> MFList = new List<Model.MenuFiles>();
            foreach (DataRow dr in dt.Rows)
            {
                MFList.Add(DataRowToModel(dr));
            }
            dt.Dispose();
            return MFList;
        }
        /// <summary>
        /// 读取分类下文件信息
        /// </summary>
        /// <param name="MCID"></param>
        /// <returns></returns>
        public List<Web.Model.MenuFiles> ReadList(string MCID, int roleid, string fileIDS)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData("select [ID],[MCID],[FileName],[OrderID],[Ishow],[Url],[AllUrl],[issys] from [MenuFiles] where [MCID]=" + MCID + " and [ishow]=1" + ((roleid == 0) ? " and [id] in(" + fileIDS + ")" : "") + " order by [orderid] asc,[id] asc");
            db.Dispose();
            List<Web.Model.MenuFiles> MFList = new List<Model.MenuFiles>();
            foreach (DataRow dr in dt.Rows)
            {
                MFList.Add(DataRowToModel(dr));
            }
            dt.Dispose();
            return MFList;
        }
        /// <summary>
        /// 读取分类下文件信息
        /// </summary>
        /// <param name="MCID"></param>
        /// <returns></returns>
        public List<Web.Model.MenuFiles> ReadList()
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData("select [ID],[MCID],[FileName],[OrderID],[Ishow],[Url],[AllUrl],[issys] from [MenuFiles] order by [orderid] asc,[id] asc");
            db.Dispose();
            List<Web.Model.MenuFiles> MFList = new List<Model.MenuFiles>();
            foreach (DataRow dr in dt.Rows)
            {
                MFList.Add(DataRowToModel(dr));
            }
            dt.Dispose();
            return MFList;
        }
        /// <summary>
        /// 设置Ishow的值
        /// </summary>
        /// <param name="Ishow"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int SetShow(string Ishow, string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            int count = db.GetRowCount("Update [MenuFiles] Set [Ishow]=" + Ishow + " Where [id]=" + id);
            db.Dispose();
            return count;
        }
        /// <summary>
        /// 获得同级里面的它上面的ID，如果没有返回父级ID
        /// </summary>
        /// <param name="mcid"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<Web.Model.MenuFiles> GetParentID(string mcid, string orderId)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData("Select [ID],[MCID],[FileName],[OrderID],[Ishow],[Url],[AllUrl],[issys] From [MenuFiles] where [mcid]=" + mcid + " and [orderid]<=" + orderId + " order by [orderid] desc,[id] desc");
            db.Dispose();
            List<Web.Model.MenuFiles> MFList = new List<Model.MenuFiles>();
            foreach (DataRow dr in dt.Rows)
            {
                MFList.Add(DataRowToModel(dr));
            }
            dt.Dispose();
            return MFList;
        }
        /// <summary>
        /// 读取关联的目录信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Web.Model.MenuClassFile ReadAllUrl(string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt1 = db.GetData("SELECT c.[DirectoryName] as PclassDir,b.[DirectoryName] as classDir,a.[Url],a.[id] FROM ([MenuFiles] as a inner join [MenuClass] as b on (a.[mcid]=b.[id])) inner join [MenuClass] as c on (b.[pid]=c.[id]) where a.[id]=" + id);
            db.Dispose();
            Web.Model.MenuClassFile MCFModel = null;
            if (dt1.Rows.Count > 0)
            {
                MCFModel = DataRowToModelClass(dt1.Rows[0]);
            }
            dt1.Dispose();
            return MCFModel;
        }
        /// <summary>
        /// 根据分类ID读取目录信息
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public List<Web.Model.MenuClassFile> ReadAllUrl_a(string cid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt1 = db.GetData("SELECT c.[DirectoryName] as PclassDir,b.[DirectoryName] as classDir,a.[Url],a.[id] FROM ([MenuFiles] as a inner join [MenuClass] as b on (a.[mcid]=b.[id])) inner join [MenuClass] as c on (b.[pid]=c.[id]) where b.[id]=" + cid);
            db.Dispose();
            List<Web.Model.MenuClassFile> MCFModelList = new List<Model.MenuClassFile>();
            if (dt1.Rows.Count > 0)
            {
                foreach (DataRow dr in dt1.Rows)
                {
                    MCFModelList.Add(DataRowToModelClass(dr));
                }
            }
            dt1.Dispose();
            return MCFModelList;
        }
        /// <summary>
        /// 根据父分类ID读取目录信息
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public List<Web.Model.MenuClassFile> ReadAllUrl_b(string pcid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt1 = db.GetData("SELECT c.[DirectoryName],b.[DirectoryName],a.[Url],a.[id] FROM ([MenuFiles] as a inner join [MenuClass] as b on (a.[mcid]=b.[id])) inner join [MenuClass] as c on (b.[pid]=c.[id]) where c.[id]=" + pcid);
            db.Dispose();
            List<Web.Model.MenuClassFile> MCFModelList = new List<Model.MenuClassFile>();
            if (dt1.Rows.Count > 0)
            {
                foreach (DataRow dr in dt1.Rows)
                {
                    MCFModelList.Add(DataRowToModelClass(dr));
                }
            }
            dt1.Dispose();
            return MCFModelList;
        }
        /// <summary>
        /// 更新全路径
        /// </summary>
        /// <param name="id"></param>
        /// <param name="AllUrl"></param>
        /// <returns></returns>
        public int SetUrl(string id, string AllUrl)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { db.CreateParameter("@AllUrl", AllUrl, DbType.String), db.CreateParameter("@id", id, DbType.Int32) };
            int icount = db.GetRowCount("Update [MenuFiles] set [AllUrl]=@AllUrl Where [id]=@id", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 返回MCID下排序后最大的ID号
        /// </summary>
        /// <param name="MCID"></param>
        /// <returns></returns>
        public string GetMCMaxID(string MCID)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string ID = db.GetValue(Base.DataBase.Difference.SelectTop("", "SELECT top 1 [ID] FROM [MenuFiles] where [mcid]=" + MCID + " order by [OrderID] desc,[id] desc")).ToString();
            db.Dispose();
            return ID;
        }
        /// <summary>
        /// 获得目录所对应的文件菜单信息
        /// </summary>
        /// <param name="Dirstr"></param>
        /// <returns></returns>
        public Web.Model.MenuFiles ReadModiAddList(string Dirstr)
        {
            Base.Conn.Database data = new Base.Conn.Database();
            DbParameter[] ps = {
                                        data.CreateParameter("@StrLits", Dirstr + "/Lists", DbType.String),
                                        data.CreateParameter("@StrModi", Dirstr + "/Modi", DbType.String),
                                        data.CreateParameter("@StrAdd", Dirstr + "/Add", DbType.String)
                                    };
            DataTable dt = data.GetData("SELECT [ID],[MCID],[FileName],[OrderID],[Ishow],[Url],[AllUrl],[issys] FROM [MenuFiles] Where (" + Base.DataBase.Difference.CharIndex("", "@StrLits", "'/'+[AllUrl]") + ">0 or " + Base.DataBase.Difference.CharIndex("", "@StrModi", "'/'+[AllUrl]") + ">0 or " + Base.DataBase.Difference.CharIndex("", "@StrAdd", "'/'+[AllUrl]") + ">0)", ps);
            data.Dispose();
            Web.Model.MenuFiles MFModelList = null;
            if (dt.Rows.Count > 0)
            {
                MFModelList = DataRowToModel(dt.Rows[0]);
            }
            dt.Dispose();
            return MFModelList;
        }
        /// <summary>
        /// DataRowToModel
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private Web.Model.MenuClassFile DataRowToModelClass(DataRow dr)
        {
            Web.Model.MenuClassFile MCFModel = new Model.MenuClassFile();
            MCFModel.PClassDir = dr["PclassDir"].ToString();
            MCFModel.ClassDir = dr["ClassDir"].ToString();
            MCFModel.Url = dr["Url"].ToString();
            MCFModel.ID = dr["id"].ToString();
            return MCFModel;
        }
        /// <summary>
        /// DataRowToModel
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private Web.Model.MenuFiles DataRowToModel(DataRow dr)
        {
            Web.Model.MenuFiles MFModel = new Model.MenuFiles();
            MFModel.Id = dr["id"].ToString();
            MFModel.Mcid = dr["MCID"].ToString();
            MFModel.FileName = dr["FileName"].ToString();
            MFModel.OrderId = dr["OrderID"].ToString();
            MFModel.Ishow = dr["Ishow"].ToString();
            MFModel.Url = dr["Url"].ToString();
            MFModel.AllUrl = dr["AllUrl"].ToString();
            MFModel.Issys = dr["issys"].ToString();
            return MFModel;
        }
    }
}
