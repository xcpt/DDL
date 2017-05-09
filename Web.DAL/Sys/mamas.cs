using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.Sys
{
    /// <summary>
    /// 泳圈
    /// </summary>
    public class mamas
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="mModel"></param>
        /// <returns></returns>
        public string Insert(Model.Sys.mamas mModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",mModel.storesid,DbType.Int32),
                               db.CreateParameter("@title",mModel.title,DbType.String),
                               db.CreateParameter("@isdel",mModel.isdel,DbType.Int32),
                               };
            string id = db.GetNewID(@"INSERT INTO [Sys_mamas]
           ([storesid]
           ,[title]
           ,[isdel])
     VALUES
           (@storesid
           ,@title
           ,@isdel)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="mModel"></param>
        /// <returns></returns>
        public int Update(Model.Sys.mamas mModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@title",mModel.title,DbType.String),
                               db.CreateParameter("@storesid",mModel.storesid,DbType.Int32),
                               db.CreateParameter("@id",mModel.id,DbType.Int32)
                               };
            int icount = db.GetRowCount(@"UPDATE [Sys_mamas]
   SET [title] = @title
 WHERE [storesid] = @storesid and [id]=@id", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(string storesid, string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",storesid,DbType.Int32),
                               db.CreateParameter("@id",id,DbType.Int32)
                               };
            int icount = db.GetRowCount(@"UPDATE [Sys_mamas]
   SET [isdel] = 1
 WHERE [storesid] = @storesid and [id]=@id", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Sys.mamas Read(string storesid, string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",storesid,DbType.Int32),
                               db.CreateParameter("@id",id,DbType.Int32)
                               };
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[title]
      ,[isdel]
  FROM [Sys_mamas] WHERE [storesid] = @storesid and [id]=@id", ps);
            db.Dispose();
            Model.Sys.mamas mModel = new Model.Sys.mamas();
            if (dt.Rows.Count > 0)
            {
                mModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return mModel;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public List<Model.Sys.mamas> ReadList(string storesid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",storesid,DbType.Int32)
                               };
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[title]
      ,[isdel]
  FROM [Sys_mamas] WHERE [storesid] = @storesid and [isdel]=0", ps);
            db.Dispose();
            List<Model.Sys.mamas> mList = new List<Model.Sys.mamas>();
            foreach (DataRow dr in dt.Rows)
            {
                mList.Add(DataRow2Model(dr));
            }
            dt.Dispose();
            return mList;
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="storesid">门店ID</param>
        /// <param name="title">名称</param>
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
                page.TableName = "[Sys_mamas]";
                page.OrderBy = "order by [id] desc";
                page.Index = "[id]";
                page.Field = "[id],[title]";
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
        private Model.Sys.mamas DataRow2Model(DataRow dr)
        {
            Model.Sys.mamas mModel = new Model.Sys.mamas();
            mModel.id = dr["id"].ToString();
            mModel.storesid = dr["storesid"].ToString();
            mModel.title = dr["title"].ToString();
            mModel.isdel = dr["isdel"].ToString();
            return mModel;
        }
    }
}
