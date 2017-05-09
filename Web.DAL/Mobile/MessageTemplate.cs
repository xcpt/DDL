using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.Mobile
{
    /// <summary>
    /// 模板
    /// </summary>
    public class MessageTemplate
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="mtModel"></param>
        /// <returns></returns>
        public string Insert(Model.Mobile.MessageTemplate mtModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",mtModel.storesid,DbType.Int32),
                               db.CreateParameter("@title",mtModel.title,DbType.String),
                               db.CreateParameter("@content",mtModel.content,DbType.String)
                               };
            string id = db.GetNewID(@"INSERT INTO [Mobile_MessageTemplate]
           ([storesid]
           ,[title]
           ,[content])
     VALUES
           (@storesid
           ,@title
           ,@content)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="mtModel"></param>
        /// <returns></returns>
        public int Update(Model.Mobile.MessageTemplate mtModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@title",mtModel.title,DbType.String),
                               db.CreateParameter("@content",mtModel.content,DbType.String),
                               db.CreateParameter("@storesid",mtModel.storesid,DbType.Int32),
                               db.CreateParameter("@id",mtModel.id,DbType.String)
                               };
            int icount = db.GetRowCount(@"UPDATE [Mobile_MessageTemplate]
   SET [title] = @title
      ,[content] = @content
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
            int icount = db.GetRowCount(@"DELETE FROM [Mobile_MessageTemplate] WHERE [storesid]=@storesid and [id]=@id", db.CreateParameter("@storesid", storesid, DbType.Int32), db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 单条
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Mobile.MessageTemplate Read(string storesid, string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData("SELECT [id],[storesid],[title],[content] FROM [Mobile_MessageTemplate] WHERE [storesid]=@storesid and [id]=@id", db.CreateParameter("@storesid", storesid, DbType.Int32), db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            Model.Mobile.MessageTemplate mtModel = new Model.Mobile.MessageTemplate();
            if (dt.Rows.Count > 0)
            {
                mtModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return mtModel;
        }
        /// <summary>
        /// 读取所有
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public List<Model.Mobile.MessageTemplate> ReadList(string storesid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData("SELECT [id],[storesid],[title],[content] FROM [Mobile_MessageTemplate] WHERE [storesid]=@storesid", db.CreateParameter("@storesid", storesid, DbType.Int32));
            db.Dispose();
            List<Model.Mobile.MessageTemplate> mtList = new List<Model.Mobile.MessageTemplate>();
            if (dt.Rows.Count > 0)
            {
                mtList.Add(DataRow2Model(dt.Rows[0]));
            }
            dt.Dispose();
            return mtList;
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="storesid">门店ID</param>
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
                page.TableName = "[Mobile_MessageTemplate]";
                page.OrderBy = "order by [id] desc";
                page.Index = "[id]";
                page.Field = "[id],[title],[content]";
                page.Filter = "[storesid]=" + storesid;
                if (title.Length > 0)
                {
                    page.Filter += " and [title] like '%" + title + "%'";
                }
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
        private Model.Mobile.MessageTemplate DataRow2Model(DataRow dr)
        {
            Model.Mobile.MessageTemplate mtModel = new Model.Mobile.MessageTemplate();
            mtModel.id = dr["id"].ToString();
            mtModel.storesid = dr["storesid"].ToString();
            mtModel.title = dr["title"].ToString();
            mtModel.content = dr["content"].ToString();
            return mtModel;
        }
    }
}
