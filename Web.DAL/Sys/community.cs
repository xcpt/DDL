using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.Sys
{
    /// <summary>
    /// 小区
    /// </summary>
    public class community
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="cyModel"></param>
        /// <returns></returns>
        public string Insert(Model.Sys.community cyModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",cyModel.storesid,DbType.Int32),
                               db.CreateParameter("@title",cyModel.title,DbType.String),
                               db.CreateParameter("@addtime",cyModel.addtime,DbType.DateTime)
                               };
            string id = db.GetNewID(@"INSERT INTO [Sys_community]
           ([storesid]
           ,[title]
           ,[addtime])
     VALUES
           (@storesid
           ,@title
           ,@addtime)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="cyModel"></param>
        /// <returns></returns>
        public int Update(Model.Sys.community cyModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@title",cyModel.title,DbType.String),
                               db.CreateParameter("@storesid",cyModel.storesid,DbType.Int32),
                               db.CreateParameter("@id",cyModel.id,DbType.Int32)
                               };
            int icount = db.GetRowCount(@"UPDATE [Sys_community]
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
            int icount = db.GetRowCount(@"DELETE FROM [Sys_community]
      WHERE [storesid] = @storesid and [id]=@id", db.CreateParameter("@storesid", storesid, DbType.Int32), db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public List<Model.Sys.community> ReadList(string storesid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[title]
      ,[addtime]
  FROM [Sys_community] where [storesid]=@storesid", db.CreateParameter("@storesid", storesid, DbType.Int32));
            db.Dispose();
            List<Model.Sys.community> cyList = new List<Model.Sys.community>();
            foreach (DataRow dr in dt.Rows)
            {
                cyList.Add(DataRow2Model(dr));
            }
            dt.Dispose();
            return cyList;
        }
        /// <summary>
        /// 读取单条
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Sys.community Read(string storesid, string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[title]
      ,[addtime]
  FROM [Sys_community] where [storesid]=@storesid and [id]=@id", db.CreateParameter("@storesid", storesid, DbType.Int32), db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            Model.Sys.community cyModel = new Model.Sys.community();
            if(dt.Rows.Count>0)
            {
                cyModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return cyModel;
        }
        /// <summary>
        /// 读取单条
        /// </summary>
        /// <param name="title"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Sys.community Read_title(string title, string storesid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[title]
      ,[addtime]
  FROM [Sys_community] where [storesid]=@storesid and [title]=@title", db.CreateParameter("@storesid", storesid, DbType.Int32), db.CreateParameter("@title", title, DbType.String));
            db.Dispose();
            Model.Sys.community cyModel = new Model.Sys.community();
            if (dt.Rows.Count > 0)
            {
                cyModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return cyModel;
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
                page.TableName = "[Sys_community]";
                page.OrderBy = "order by [id] desc";
                page.Index = "[id]";
                page.Field = "[id],[title]";
                List<string> Filter = new List<string>();
                Filter.Add("[storesid]=" + storesid);
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
        private Model.Sys.community DataRow2Model(DataRow dr)
        {
            Model.Sys.community cModel = new Model.Sys.community();
            cModel.id = dr["id"].ToString();
            cModel.storesid = dr["storesid"].ToString();
            cModel.title = dr["title"].ToString();
            cModel.addtime = dr["addtime"].ToString();
            return cModel;
        }
    }
}
