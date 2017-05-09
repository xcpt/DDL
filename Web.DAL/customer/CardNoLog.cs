using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.customer
{
    /// <summary>
    /// 换卡日志
    /// </summary>
    public class CardNoLog
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="cnlModel"></param>
        /// <returns></returns>
        public string Insert(Model.customer.CardNoLog cnlModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",cnlModel.storesid,DbType.Int32),
                               db.CreateParameter("@oldcardNo",cnlModel.oldcardNo,DbType.String),
                               db.CreateParameter("@newcardNo",cnlModel.newcardNo,DbType.String),
                               db.CreateParameter("@addtime",DateTime.Now,DbType.DateTime),
                               db.CreateParameter("@administratorid",cnlModel.administratorid,DbType.Int32),
                               };
            string id = db.GetNewID(@"INSERT INTO [customer_CardNoLog]
           ([storesid]
           ,[oldcardNo]
           ,[newcardNo]
           ,[addtime]
           ,[administratorid])
     VALUES
           (@storesid
           ,@oldcardNo
           ,@newcardNo
           ,@addtime
           ,@administratorid)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="storesid">门店ID</param>
        /// <param name="oldcardNo">老卡号</param>
        /// <param name="newcardNo">新卡号</param>
        /// <param name="starttime">开始时间</param>
        /// <param name="endtime">结束时间</param>
        /// <returns></returns>
        public string View(int PageSize, string storesid, string oldcardNo, string newcardNo, string starttime, string endtime)
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
                page.TableName = "[customer_CardNoLog] as a left join [Users] as c on a.[administratorid]=c.[userid]";
                page.OrderBy = "order by a.[id] desc";
                page.Index = "a.[id]";
                page.Field = "a.[id],a.[oldcardNo],a.[newcardNo],c.[username],a.[addtime]";
                List<string> Filter = new List<string>();
                Filter.Add("a.[storesid]=" + storesid);
                if (oldcardNo.Length > 0)
                {
                    Filter.Add("a.[oldcardNo]='" + oldcardNo + "'");
                }
                if (newcardNo.Length > 0)
                {
                    Filter.Add("a.[newcardNo]='" + newcardNo + "'");
                }
                if (Base.Fun.fun.IsDate(starttime))
                {
                    Filter.Add("a.[addtime]>=" + starttime);
                }
                if (Base.Fun.fun.IsDate(endtime))
                {
                    Filter.Add("a.[addtime]<=" + endtime);
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
