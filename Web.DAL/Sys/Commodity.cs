using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.Sys
{
    /// <summary>
    /// 商品
    /// </summary>
    public class Commodity
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="cdModel"></param>
        /// <returns></returns>
        public string Insert(Model.Sys.Commodity cdModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",cdModel.storesid,DbType.Int32),
                               db.CreateParameter("@title",cdModel.title,DbType.String),
                               db.CreateParameter("@price",cdModel.price,DbType.Double),
                               db.CreateParameter("@addtime",cdModel.addtime,DbType.DateTime),
                               db.CreateParameter("@iscard",cdModel.iscard,DbType.Int32),
                               db.CreateParameter("@isdel",cdModel.isdel,DbType.Int32),
                               db.CreateParameter("@score",cdModel.score,DbType.Int32)
                               };
            string id = db.GetNewID(@"INSERT INTO [Sys_Commodity]
           ([storesid]
           ,[title]
           ,[price]
           ,[addtime]
           ,[iscard]
           ,[isdel]
           ,[score])
     VALUES
           (@storesid
           ,@title
           ,@price
           ,@addtime
           ,@iscard
           ,@isdel
           ,@score)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="cdModel"></param>
        /// <returns></returns>
        public int Update(Model.Sys.Commodity cdModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@title",cdModel.title,DbType.String),
                               db.CreateParameter("@price",cdModel.price,DbType.Double),
                               db.CreateParameter("@iscard",cdModel.iscard,DbType.Int32),
                               db.CreateParameter("@score",cdModel.score,DbType.Int32),
                               db.CreateParameter("@storesid",cdModel.storesid,DbType.Int32),
                               db.CreateParameter("@id",cdModel.id,DbType.Int32)
                               };
            int icount = db.GetRowCount(@"UPDATE [Sys_Commodity]
   SET [title] = @title
      ,[price] = @price
      ,[iscard]=@iscard
      ,[score]=@score
 WHERE [storesid] = @storesid and [id]=@id", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="cdModel"></param>
        /// <returns></returns>
        public int Delete(string storesid, string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",storesid,DbType.Int32),
                               db.CreateParameter("@id",id,DbType.Int32)
                               };
            int icount = db.GetRowCount(@"Update [Sys_Commodity] set [isdel]=1 WHERE [storesid] = @storesid and [id]=@id", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public List<Model.Sys.Commodity> ReadList(string storesid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[title]
      ,[price]
      ,[addtime]
      ,[iscard]
      ,[isdel]
      ,[score]
  FROM [Sys_Commodity] Where [isdel]=0 and [storesid] = @storesid", db.CreateParameter("@storesid", storesid, DbType.Int32));
            db.Dispose();
            List<Model.Sys.Commodity> cList = new List<Model.Sys.Commodity>();
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
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Sys.Commodity Read(string storesid, string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[title]
      ,[price]
      ,[addtime]
      ,[iscard]
      ,[isdel]
      ,[score]
  FROM [Sys_Commodity] Where [isdel]=0 and [storesid] = @storesid and [id]=@id", db.CreateParameter("@storesid", storesid, DbType.Int32), db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            Model.Sys.Commodity cModel = new Model.Sys.Commodity();
            if(dt.Rows.Count>0)
            {
                cModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return cModel;
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="storesid">门店ID</param>
        /// <param name="title">商品名称</param>
        /// <returns></returns>
        public string View(int PageSize, string storesid, string title)
        {
            StringBuilder str = new StringBuilder();
            DataTable dt = new DataTable();
            Base.Page.Dividepage page = new Base.Page.Dividepage();
            try
            {
                if (PageSize <= 0)
                {
                    PageSize = 15;
                }
                page.PageSize = PageSize;
                page.TableName = "[Sys_Commodity]";
                page.OrderBy = "order by [id] desc";
                page.Index = "[id]";
                page.Field = "[id],[title],[price],[score],[iscard]";
                List<string> Filter = new List<string>();
                Filter.Add("[isdel]=0 and [storesid]=" + storesid);
                if (title.Length > 0)
                {
                    Filter.Add("[title] like '%" + title + "%'");
                }
                page.Filter = string.Join(" and ", Filter.ToArray());
                dt = page.getrows();
                str.Append(Base.Conn.Json.DataTable2Json(page.Page, page.TotalRow, dt, null));
            }
            catch (Exception e)
            {
                Base.Error.Error.WriteError(e);
                //错误记录
            }
            finally
            {
                dt.Dispose();
                page.Dispose();
            }
            return str.ToString();
        }
        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private Model.Sys.Commodity DataRow2Model(DataRow dr)
        {
            Model.Sys.Commodity cModel = new Model.Sys.Commodity();
            cModel.id = dr["id"].ToString();
            cModel.storesid = dr["storesid"].ToString();
            cModel.title = dr["title"].ToString();
            cModel.price = dr["price"].ToString();
            cModel.iscard = dr["iscard"].ToString();
            cModel.addtime = dr["addtime"].ToString();
            cModel.isdel = dr["isdel"].ToString();
            cModel.score = dr["score"].ToString();
            return cModel;
        }
    }
}
