using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.Mobile
{
    /// <summary>
    /// 购买记录
    /// </summary>
    public class MessageBuy
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="bmModel"></param>
        /// <returns></returns>
        public string Insert(Model.Mobile.MessageBuy bmModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",bmModel.storesid,DbType.Int32),
                               db.CreateParameter("@SetupID",bmModel.SetupID,DbType.Int32),
                               db.CreateParameter("@status",bmModel.status,DbType.Int32),
                               db.CreateParameter("@addtime",bmModel.addtime,DbType.DateTime),
                               db.CreateParameter("@content",bmModel.content,DbType.String),
                               db.CreateParameter("@statuscontent",bmModel.statuscontent,DbType.String)
                               };
            string id = db.GetNewID(@"INSERT INTO [Mobile_MessageBuy]
           ([storesid]
           ,[SetupID]
           ,[status]
           ,[addtime]
           ,[content]
           ,[statuscontent])
     VALUES
           (@storesid
           ,@SetupID
           ,@status
           ,@addtime
           ,@content
           ,@statuscontent)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int Update(string storesid, string id, string status, string statuscontent)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@status",status,DbType.Int32),
                               db.CreateParameter("@statuscontent",statuscontent,DbType.String),
                               db.CreateParameter("@storesid",storesid,DbType.Int32),
                               db.CreateParameter("@id",id,DbType.Int32)
                               };
            int icount = db.GetRowCount(@"UPDATE [Mobile_MessageBuy] SET [status] = @status,[statuscontent]=@statuscontent
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
        public Model.Mobile.MessageBuy Read(string storesid, string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"Select [ID]
           ,[storesid]
           ,[SetupID]
           ,[status]
           ,[addtime]
           ,[content]
           ,[statuscontent] From [Mobile_MessageBuy] Where [storesid]=@storesid and [id]=@id", db.CreateParameter("@storesid", storesid, DbType.Int32), db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            Model.Mobile.MessageBuy mbModel = new Model.Mobile.MessageBuy();
            if (dt.Rows.Count > 0)
            {
                mbModel.id = dt.Rows[0]["id"].ToString();
                mbModel.storesid = dt.Rows[0]["storesid"].ToString();
                mbModel.SetupID = dt.Rows[0]["SetupID"].ToString();
                mbModel.status = dt.Rows[0]["status"].ToString();
                mbModel.addtime = dt.Rows[0]["addtime"].ToString();
                mbModel.content = dt.Rows[0]["content"].ToString();
                mbModel.statuscontent = dt.Rows[0]["statuscontent"].ToString();
            }
            dt.Dispose();
            return mbModel;
        }
        
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="storesid">门店ID</param>
        /// <param name="storesname">门店名称</param>
        /// <param name="setupid">套餐ID</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public string View(int PageSize, string storesid, string setupid, string status)
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
                page.TableName = "[Mobile_MessageBuy] as a inner join [Sys_stores] as b on a.[storesid]=b.[storesid] inner join [Mobile_MessageSetup] as c on a.[SetupID]=c.[id]";
                page.OrderBy = "order by a.[id] desc";
                page.Index = "a.[id]";
                page.Field = "a.[id],b.[title] as storesname,c.[title] as setupname,a.[content],a.[status],a.[statuscontent]";
                List<string> Filter = new List<string>();
                Filter.Add("a.[storesid]=" + storesid);
                if (Base.Fun.fun.pnumeric(setupid))
                {
                    Filter.Add("a.[setupid]=" + setupid);
                }
                if (Base.Fun.fun.IsNumeric(status))
                {
                    Filter.Add("a.[status]=" + status);
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
    }
}
