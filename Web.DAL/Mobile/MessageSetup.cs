using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.Mobile
{
    /// <summary>
    /// 短消息套餐显示
    /// </summary>
    public class MessageSetup
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="msModel"></param>
        /// <returns></returns>
        public string Insert(Model.Mobile.MessageSetup msModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@title",msModel.title,DbType.String),
                               db.CreateParameter("@num",msModel.num,DbType.Int32),
                               db.CreateParameter("@price",msModel.price,DbType.Double),
                               db.CreateParameter("@isopen",msModel.isopen,DbType.Int32)
                               };
            string id = db.GetNewID(@"INSERT INTO [Mobile_MessageSetup]
           ([title]
           ,[num]
           ,[price]
           ,[isopen])
     VALUES
           (@title
           ,@num
           ,@price
           ,@isopen)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="msModel"></param>
        /// <returns></returns>
        public int Update(Model.Mobile.MessageSetup msModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@title",msModel.title,DbType.String),
                               db.CreateParameter("@num",msModel.num,DbType.Int32),
                               db.CreateParameter("@price",msModel.price,DbType.Double),
                               db.CreateParameter("@isopen",msModel.isopen,DbType.Int32),
                               db.CreateParameter("@id",msModel.id,DbType.Int32)
                               };
            int icount = db.GetRowCount(@"UPDATE [Mobile_MessageSetup]
   SET [title] = @title
      ,[num] = @num
      ,[price]=@price
      ,[isopen]=@isopen
 WHERE [ID]=@id", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 修改打开状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="IsOpen"></param>
        /// <returns></returns>
        public int Update_IsOpen(string id, string IsOpen)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            int icount = db.GetRowCount(@"UPDATE [Mobile_MessageSetup]
   SET [isopen] = @isopen
 WHERE [id]=@id");
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 读取单条
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Mobile.MessageSetup Read(string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[title]
      ,[num]
      ,[price]
      ,[isopen]
  FROM [Mobile_MessageSetup] Where [id]=@id", db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            Model.Mobile.MessageSetup msModel = new Model.Mobile.MessageSetup();
            if (dt.Rows.Count > 0)
            {
                msModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return msModel;
        }
        /// <summary>
        /// 读取所有
        /// </summary>
        /// <returns></returns>
        public List<Model.Mobile.MessageSetup> ReadList()
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt= db.GetData(@"SELECT [id]
      ,[title]
      ,[num]
      ,[price]
      ,[isopen]
  FROM [Mobile_MessageSetup] Where [IsOpen]=1");
            db.Dispose();
            List<Model.Mobile.MessageSetup> msList = new List<Model.Mobile.MessageSetup>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    msList.Add(DataRow2Model(dr));
                }
            }
            dt.Dispose();
            return msList;
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="storesid">门店ID</param>
        /// <returns></returns>
        public string View(int PageSize, string title)
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
                page.TableName = "[Mobile_MessageSetup]";
                page.OrderBy = "order by [id] desc";
                page.Index = "[id]";
                page.Field = "[id],[title],[num],[price],[IsOpen]";
                if (title.Length > 0)
                {
                    page.Filter = " [title] like '%" + title + "%'";
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
        private Model.Mobile.MessageSetup DataRow2Model(DataRow dr)
        {
            Model.Mobile.MessageSetup msModel = new Model.Mobile.MessageSetup();
            msModel.id = dr["id"].ToString();
            msModel.title = dr["title"].ToString();
            msModel.num = dr["num"].ToString();
            msModel.price = dr["price"].ToString();
            msModel.isopen = dr["isopen"].ToString();
            return msModel;
        }
    }
}
