using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.customer
{
    /// <summary>
    /// 卡类型
    /// </summary>
    public class CardType
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="ctModel"></param>
        /// <returns></returns>
        public string Insert(Model.customer.CardType ctModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",ctModel.storesid,DbType.Int32),
                               db.CreateParameter("@title",ctModel.title,DbType.String),
                               db.CreateParameter("@businessid",ctModel.businessid,DbType.Int32),
                               db.CreateParameter("@effectivetime",ctModel.effectivetime,DbType.Int32),
                               db.CreateParameter("@paidmode",ctModel.paidmode,DbType.Int32),
                               db.CreateParameter("@positivenum",ctModel.positivenum,DbType.Int32),
                               db.CreateParameter("@negativenum",ctModel.negativenum,DbType.Int32),
                               db.CreateParameter("@price",ctModel.price,DbType.Double),
                               db.CreateParameter("@discount",ctModel.discount,DbType.Double),
                               db.CreateParameter("@opencardexchange",ctModel.opencardexchange,DbType.Int32),
                               db.CreateParameter("@content",ctModel.content,DbType.String)
                               };
            string id = db.GetNewID(@"INSERT INTO [customer_CardType]
           ([storesid]
           ,[title]
           ,[businessid]
           ,[effectivetime]
           ,[paidmode]
           ,[positivenum]
           ,[negativenum]
           ,[price]
           ,[discount]
           ,[opencardexchange]
           ,[content])
     VALUES
           (@storesid
           ,@title
           ,@businessid
           ,@effectivetime
           ,@paidmode
           ,@positivenum
           ,@negativenum
           ,@price
           ,@discount
           ,@opencardexchange
           ,@content)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="ctModel"></param>
        /// <returns></returns>
        public int Update(Model.customer.CardType ctModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@title",ctModel.title,DbType.String),
                               db.CreateParameter("@businessid",ctModel.businessid,DbType.Int32),
                               db.CreateParameter("@effectivetime",ctModel.effectivetime,DbType.Int32),
                               db.CreateParameter("@paidmode",ctModel.paidmode,DbType.Int32),
                               db.CreateParameter("@positivenum",ctModel.positivenum,DbType.Int32),
                               db.CreateParameter("@negativenum",ctModel.negativenum,DbType.Int32),
                               db.CreateParameter("@price",ctModel.price,DbType.Double),
                               db.CreateParameter("@discount",ctModel.discount,DbType.Double),
                               db.CreateParameter("@opencardexchange",ctModel.opencardexchange,DbType.Int32),
                               db.CreateParameter("@content",ctModel.content,DbType.String),
                               db.CreateParameter("@storesid",ctModel.storesid,DbType.Int32),
                               db.CreateParameter("@id",ctModel.id,DbType.Int32)
                               };
            int icount = db.GetRowCount(@"UPDATE [customer_CardType]
   SET [title] = @title
      ,[businessid] = @businessid
      ,[effectivetime] = @effectivetime
      ,[paidmode] = @paidmode
      ,[positivenum] = @positivenum
      ,[negativenum] = @negativenum
      ,[price] = @price
      ,[discount] = @discount
      ,[opencardexchange] = @opencardexchange
      ,[content] = @content
 WHERE [storesid] = @storesid and [id]=@id", ps);
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
            int icount = db.GetRowCount("DELETE FROM [customer_CardType] WHERE [storesid]=@storesid and [id]=@id", db.CreateParameter("@storesid", storesid, DbType.Int32), db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 读取单条
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.customer.CardType Read(string id)
        {
            Model.customer.CardType ctModel = new Model.customer.CardType();
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[title]
      ,[businessid]
      ,[effectivetime]
      ,[paidmode]
      ,[positivenum]
      ,[negativenum]
      ,[price]
      ,[discount]
      ,[opencardexchange]
      ,[content]
  FROM [customer_CardType] where [id]=@id", db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            if (dt.Rows.Count > 0)
            {
                ctModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return ctModel;
        }
        /// <summary>
        /// 读取单条
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.customer.CardType Read_title(string title, string storesid)
        {
            Model.customer.CardType ctModel = new Model.customer.CardType();
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[title]
      ,[businessid]
      ,[effectivetime]
      ,[paidmode]
      ,[positivenum]
      ,[negativenum]
      ,[price]
      ,[discount]
      ,[opencardexchange]
      ,[content]
  FROM [customer_CardType] where [title]=@title and [storesid]=@storesid", db.CreateParameter("@title", title, DbType.String), db.CreateParameter("@storesid", storesid, DbType.Int32));
            db.Dispose();
            if (dt.Rows.Count > 0)
            {
                ctModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return ctModel;
        }
        /// <summary>
        /// 读取所有
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public List<Model.customer.CardType> ReadList(string storesid)
        {
            List<Model.customer.CardType> ctList = new List<Model.customer.CardType>();
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[title]
      ,[businessid]
      ,[effectivetime]
      ,[paidmode]
      ,[positivenum]
      ,[negativenum]
      ,[price]
      ,[discount]
      ,[opencardexchange]
      ,[content]
  FROM [customer_CardType] where [storesid]=@storesid order by [id] desc", db.CreateParameter("@storesid", storesid, DbType.Int32));
            db.Dispose();
            foreach(DataRow dr in dt.Rows)
            {
                ctList.Add(DataRow2Model(dr));
            }
            dt.Dispose();
            return ctList;
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="storesid">门店</param>
        /// <param name="title">标题</param>
        /// <param name="paidmode">模式0，1</param>
        /// <param name="businessid">业务类型</param>
        /// <returns></returns>
        public string View(int PageSize, string storesid, string title, string paidmode, string businessid)
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
                page.TableName = "[customer_CardType] as a left join [customer_Cardbusinessid] as b on a.[businessid]=b.[id]";
                page.OrderBy = "order by a.[id] desc";
                page.Index = "a.[id]";
                page.Field = "a.[id],a.[title],b.[title] as ywtitle,a.[effectivetime],a.[paidmode],a.[positivenum],a.[negativenum],a.[price],a.[discount],a.[opencardexchange]";
                List<string> Filter = new List<string>();
                Filter.Add("a.[storesid]=" + storesid);
                if (title.Length > 0)
                {
                    Filter.Add("a.[title] like '%" + title + "%'");
                }
                if (Base.Fun.fun.IsNumeric(paidmode))
                {
                    Filter.Add("a.[paidmode]=" + paidmode);
                }
                if (Base.Fun.fun.IsNumeric(businessid))
                {
                    Filter.Add("a.[businessid]=" + businessid);
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
        private Model.customer.CardType DataRow2Model(DataRow dr)
        {
            Model.customer.CardType ctModel = new Model.customer.CardType();
            ctModel.id = dr["id"].ToString();
            ctModel.storesid = dr["storesid"].ToString();
            ctModel.title = dr["title"].ToString();
            ctModel.businessid = dr["businessid"].ToString();
            ctModel.effectivetime = dr["effectivetime"].ToString();
            ctModel.paidmode = dr["paidmode"].ToString();
            ctModel.positivenum = dr["positivenum"].ToString();
            ctModel.negativenum = dr["negativenum"].ToString();
            ctModel.price = dr["price"].ToString();
            ctModel.discount = dr["discount"].ToString();
            ctModel.opencardexchange = dr["opencardexchange"].ToString();
            ctModel.content = dr["content"].ToString();
            return ctModel;
        }
    }
}
