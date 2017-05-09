using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.Sys
{
    /// <summary>
    /// 栏目
    /// </summary>
    public class Category
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="cModel"></param>
        /// <returns></returns>
        public string Insert(Model.Sys.Category cModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@ClassName",cModel.classname,DbType.String),
                               db.CreateParameter("@Pic",cModel.pic,DbType.String),
                               db.CreateParameter("@IsNavi",cModel.isnavi,DbType.Int32),
                               db.CreateParameter("@ParentID",cModel.parentid,DbType.Int32),
                               db.CreateParameter("@Type",cModel.type,DbType.Int32),
                               db.CreateParameter("@SDay",cModel.sday,DbType.Int32),
                               db.CreateParameter("@EDay",cModel.eday,DbType.Int32),
                               db.CreateParameter("@depth",cModel.depth,DbType.Int32),
                               db.CreateParameter("@orderid",cModel.orderid,DbType.Int32),
                               db.CreateParameter("@content",cModel.content,DbType.String)
                               };
            string id = db.GetNewID(@"INSERT INTO [Sys_Category]
           ([ClassName]
           ,[Pic]
           ,[IsNavi]
           ,[ParentID]
           ,[Type]
           ,[SDay]
           ,[EDay]
           ,[depth]
           ,[orderid]
           ,[content])
     VALUES
           (@ClassName
           ,@Pic
           ,@IsNavi
           ,@ParentID
           ,@Type
           ,@SDay
           ,@EDay
           ,@depth
           ,@orderid
           ,@content)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="cModel"></param>
        /// <returns></returns>
        public int Update(Model.Sys.Category cModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@ClassName",cModel.classname,DbType.String),
                               db.CreateParameter("@Pic",cModel.pic,DbType.String),
                               db.CreateParameter("@IsNavi",cModel.isnavi,DbType.Int32),
                               db.CreateParameter("@ParentID",cModel.parentid,DbType.Int32),
                               db.CreateParameter("@Type",cModel.type,DbType.Int32),
                               db.CreateParameter("@SDay",cModel.sday,DbType.Int32),
                               db.CreateParameter("@EDay",cModel.eday,DbType.Int32),
                               db.CreateParameter("@depth",cModel.depth,DbType.Int32),
                               db.CreateParameter("@orderid",cModel.orderid,DbType.Int32),
                               db.CreateParameter("@content",cModel.content,DbType.String),
                               db.CreateParameter("@classid",cModel.classid,DbType.Int32)
                               };
            int icount = db.GetRowCount(@"UPDATE [Sys_Category]
   SET [ClassName] = @ClassName
      ,[Pic] = @Pic
      ,[IsNavi] = @IsNavi
      ,[ParentID] = @ParentID
      ,[Type] = @Type
      ,[SDay] = @SDay
      ,[EDay] = @EDay
      ,[depth] = @depth
      ,[orderid] = @orderid
      ,[content] = @content
 WHERE [classid]=@classid", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 删除栏目
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public int Delete(string classid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            int icount = db.GetRowCount("@Delete From [Sys_Category] Where [classid]=@classid", db.CreateParameter("@classid", classid, DbType.Int32));
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 更新排序号
        /// </summary>
        /// <param name="classid"></param>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public int Update_OrderID(string classid, string orderid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@orderid",orderid,DbType.Int32),
                               db.CreateParameter("@classid",classid,DbType.Int32)
                               };
            int icount = db.GetRowCount("Update [Sys_Category] Set [orderid]=@orderid where [classid]=@classid", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 更新导航显示
        /// </summary>
        /// <param name="classid"></param>
        /// <param name="isnavi"></param>
        /// <returns></returns>
        public int Update_IsNavi(string classid, string isnavi)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@isnavi",isnavi,DbType.Int32),
                               db.CreateParameter("@classid",classid,DbType.Int32)
                               };
            int icount = db.GetRowCount("Update [Sys_Category] Set [isnavi]=@isnavi where [classid]=@classid", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<Model.Sys.Category> ReadList(string type)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [ClassID]
      ,[ClassName]
      ,[Pic]
      ,[IsNavi]
      ,[ParentID]
      ,[Type]
      ,[SDay]
      ,[EDay]
      ,[depth]
      ,[orderid]
      ,[content]
  FROM [Sys_Category] Where [type]=@type order by [depth] asc,[orderid] asc", db.CreateParameter("@type", type, DbType.Int32));
            db.Dispose();
            List<Model.Sys.Category> cList = new List<Model.Sys.Category>();
            foreach (DataRow dr in dt.Rows)
            {
                cList.Add(DataRow2Model(dr));
            }
            dt.Dispose();
            return cList;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataTable ReadList(string type, string ParentID)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [classid]
      ,[classname]
      ,[pic]
      ,[content]
  FROM [Sys_Category] Where [type]=@type and [ParentID]=@ParentID order by [depth] asc,[orderid] asc", db.CreateParameter("@type", type, DbType.Int32), db.CreateParameter("@ParentID", ParentID, DbType.Int32));
            db.Dispose();
            return dt;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<Model.Sys.Category> ReadListOnIndex(string type)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [ClassID]
      ,[ClassName]
      ,[Pic]
      ,[IsNavi]
      ,[ParentID]
      ,[Type]
      ,[SDay]
      ,[EDay]
      ,[depth]
      ,[orderid]
      ,[content]
  FROM [Sys_Category] Where [type]=@type and [IsNavi]=1 order by [depth] asc,[orderid] asc", db.CreateParameter("@type", type, DbType.Int32));
            db.Dispose();
            List<Model.Sys.Category> cList = new List<Model.Sys.Category>();
            foreach (DataRow dr in dt.Rows)
            {
                cList.Add(DataRow2Model(dr));
            }
            return cList;
        }
        /// <summary>
        /// 读取单条
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public Model.Sys.Category Read(string classid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [ClassID]
      ,[ClassName]
      ,[Pic]
      ,[IsNavi]
      ,[ParentID]
      ,[Type]
      ,[SDay]
      ,[EDay]
      ,[depth]
      ,[orderid]
      ,[content]
  FROM [Sys_Category] Where [classid]=@classid", db.CreateParameter("@classid", classid, DbType.Int32));
            db.Dispose();
            Model.Sys.Category cModel = new Model.Sys.Category();
            if (dt.Rows.Count > 0)
            {
                cModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return cModel;
        }
        /// <summary>
        /// 转码
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private Model.Sys.Category DataRow2Model(DataRow dr)
        {
            Model.Sys.Category cModel = new Model.Sys.Category();
            cModel.classid = dr["classid"].ToString();
            cModel.classname = dr["classname"].ToString();
            cModel.pic = dr["pic"].ToString();
            cModel.isnavi = dr["isnavi"].ToString();
            cModel.parentid = dr["parentid"].ToString();
            cModel.type = dr["type"].ToString();
            cModel.sday = dr["sday"].ToString();
            cModel.eday = dr["eday"].ToString();
            cModel.depth = dr["depth"].ToString();
            cModel.orderid = dr["orderid"].ToString();
            cModel.content = dr["content"].ToString();
            return cModel;
        }
    }
}