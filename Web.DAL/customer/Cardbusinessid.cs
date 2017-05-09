using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.customer
{
    /// <summary>
    /// 卡业务类型
    /// </summary>
    public class Cardbusinessid
    {
        /// <summary>
        /// 插入卡类型
        /// </summary>
        /// <param name="cbModel"></param>
        /// <returns></returns>
        public string Insert(Model.customer.Cardbusinessid cbModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",cbModel.storesid,DbType.Int32),
                               db.CreateParameter("@title",cbModel.title,DbType.String)
                               };
            string id = db.GetNewID(@"INSERT INTO [customer_Cardbusinessid]
           ([storesid]
           ,[title])
     VALUES
           (@storesid
           ,@title)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="cbModel"></param>
        /// <returns></returns>
        public int Update(Model.customer.Cardbusinessid cbModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@title",cbModel.title,DbType.String),
                               db.CreateParameter("@id",cbModel.id,DbType.Int32)
                               };
            int icount = db.GetRowCount(@"UPDATE [customer_Cardbusinessid]
   SET [title] = @title
 WHERE [id]=@id", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(string storesid, string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            int icount = db.GetRowCount(@"DELETE FROM [customer_Cardbusinessid]
      WHERE [storesid] = @storesid and [id]=@id", db.CreateParameter("@storesid", storesid, DbType.Int32), db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 读取单条
        /// </summary>
        /// <param name="storesid">门店ID</param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.customer.Cardbusinessid Read(string storesid, string id)
        {
            Model.customer.Cardbusinessid cbModel = new Model.customer.Cardbusinessid();
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[title]
  FROM [customer_Cardbusinessid]
where [storesid]=@storesid and [id]=@id", db.CreateParameter("@storesid", storesid, DbType.Int32), db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            if (dt.Rows.Count > 0)
            {
                cbModel = DataRow2Model(dt.Rows[0]);
            }
            return cbModel;
        }
        /// <summary>
        /// 读取所有
        /// </summary>
        /// <param name="storesid">门店ID</param>
        /// <returns></returns>
        public List<Model.customer.Cardbusinessid> ReadList(string storesid)
        {
            List<Model.customer.Cardbusinessid> cbList = new List<Model.customer.Cardbusinessid>();
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[title]
  FROM [customer_Cardbusinessid] Where [storesid]=@storesid order by [id] asc", db.CreateParameter("@storesid", storesid, DbType.Int32));
            db.Dispose();
            foreach (DataRow dr in dt.Rows)
            {
                cbList.Add(DataRow2Model(dr));
            }
            return cbList;
        }

        /// <summary>
        /// 显示内容
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="storesid">门店</param>
        /// <param name="title">标题</param>
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
                page.TableName = "[customer_Cardbusinessid]";
                page.OrderBy = "order by [id] desc";
                page.Index = "[ID]";
                page.Field = "[ID],[title]";
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
        private Model.customer.Cardbusinessid DataRow2Model(DataRow dr)
        {
            Model.customer.Cardbusinessid cbModel = new Model.customer.Cardbusinessid();
            cbModel.id = dr["id"].ToString();
            cbModel.storesid = dr["storesid"].ToString();
            cbModel.title = dr["title"].ToString();
            return cbModel;
        }
    }
}
