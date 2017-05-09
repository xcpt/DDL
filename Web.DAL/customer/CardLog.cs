using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.customer
{
    /// <summary>
    /// 卡日志
    /// </summary>
    public class CardLog
    {
        /// <summary>
        /// 插入日志
        /// </summary>
        /// <param name="clModel"></param>
        /// <returns></returns>
        public string Insert(Model.customer.CardLog clModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@cardid",clModel.cardid,DbType.Int32),
                               db.CreateParameter("@storesid",clModel.storesid,DbType.Int32),
                               db.CreateParameter("@addtime",Base.Fun.fun.IsDate(clModel.addtime)?clModel.addtime:DateTime.Now.ToString(),DbType.DateTime),
                               db.CreateParameter("@administratorid",clModel.administratorid,DbType.Int32),
                               db.CreateParameter("@cardlogtype",clModel.cardlogtype,DbType.Int32),
                               db.CreateParameter("@oldendtime",Base.Fun.fun.IsDate(clModel.oldendtime)?clModel.oldendtime:null,DbType.DateTime),
                               db.CreateParameter("@newendtime",Base.Fun.fun.IsDate(clModel.newendtime)?clModel.newendtime:null,DbType.DateTime),
                               db.CreateParameter("@opentime",Base.Fun.fun.IsDate(clModel.opentime)?clModel.opentime:null,DbType.DateTime),
                               db.CreateParameter("@oldnum",clModel.oldnum,DbType.String),
                               db.CreateParameter("@newnum",clModel.newnum,DbType.String),
                               db.CreateParameter("@oldprice",clModel.oldprice,DbType.String),
                               db.CreateParameter("@newprice",clModel.newprice,DbType.String),
                               db.CreateParameter("@oldcardtype",clModel.oldcardtype,DbType.String),
                               db.CreateParameter("@newcardtype",clModel.newcardtype,DbType.String)
                               };
            string id = db.GetNewID(@"INSERT INTO [customer_CardLog]
           ([cardid]
           ,[storesid]
           ,[addtime]
           ,[administratorid]
           ,[cardlogtype]
           ,[oldendtime]
           ,[newendtime]
           ,[opentime]
           ,[oldnum]
           ,[newnum]
           ,[oldprice]
           ,[newprice]
           ,[oldcardtype]
           ,[newcardtype])
     VALUES
           (@cardid
           ,@storesid
           ,@addtime
           ,@administratorid
           ,@cardlogtype
           ,@oldendtime
           ,@newendtime
           ,@opentime
           ,@oldnum
           ,@newnum
           ,@oldprice
           ,@newprice
           ,@oldcardtype
           ,@newcardtype)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 显示内容
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="storesid">门店ID</param>
        /// <param name="cardNo">卡号</param>
        /// <param name="starttime">开始时间</param>
        /// <param name="endtime">结束时间</param>
        /// <param name="cardlogtype">操作类型</param>
        /// <returns></returns>
        public string View(int PageSize, string storesid, string cardNo, string starttime, string endtime, string cardlogtype)
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
                page.TableName = "[customer_CardLog] as a inner join [customer_Card] as b on a.[cardid]=b.[cardid] left join [Users] as c on a.[administratorid]=c.[userid]";
                page.OrderBy = "order by a.[id] desc";
                page.Index = "a.[id]";
                page.Field = "a.[id],b.[cardNo],a.[oldendtime],a.[newendtime],a.[opentime],a.[oldnum],a.[newnum],a.[oldprice],a.[newprice],a.[oldcardtype],a.[newcardtype],a.[administratorid],c.[username],a.[addtime],a.[cardlogtype]";
                List<string> Filter = new List<string>();
                Filter.Add("b.[storesid]=" + storesid);
                if (cardNo.Length > 0)
                {
                    if (cardNo.Length >= 10)
                    {
                        Filter.Add("b.[cardNumber]='" + cardNo + "'");
                    }
                    else
                    {
                        Filter.Add("b.[CardNo]='" + cardNo + "'");
                    }
                }
                if (Base.Fun.fun.IsDate(starttime))
                {
                    Filter.Add("datediff(day,a.[addtime],'" + starttime + "')<=0");
                }
                if (Base.Fun.fun.IsDate(endtime))
                {
                    Filter.Add("datediff(day,a.[addtime],'" + endtime + "')>=0");
                }
                if (Base.Fun.fun.IsNumeric(cardlogtype))
                {
                    Filter.Add("a.[cardlogtype]=" + cardlogtype);
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
        /// 统计数量
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="cardlogtype"></param>
        /// <returns></returns>
        public string View_Num(string storesid, string starttime, string endtime, string cardlogtype)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string count = db.GetValue("Select count([ID]) From [customer_CardLog] Where [storesid]=@storesid and [cardlogtype]=@cardlogtype and datediff(month,[addtime],'" + starttime + "')<=0 and datediff(month,[addtime],'" + endtime + "')>=0", db.CreateParameter("@storesid", storesid, DbType.Int32), db.CreateParameter("@cardlogtype", cardlogtype, DbType.Int32)).ToString();
            db.Dispose();
            return count;
        }
        /// <summary>
        /// 统计用户操作数量
        /// </summary>
        /// <param name="cardid"></param>
        /// <param name="cardlogtype"></param>
        /// <returns></returns>
        public string View_Num(string cardid, string cardlogtype)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string count = db.GetValue("Select count([ID]) From [customer_CardLog] Where [cardid]=@cardid and [administratorid]=-1 and [cardlogtype]=@cardlogtype", db.CreateParameter("@cardid", cardid, DbType.Int32), db.CreateParameter("@cardlogtype", cardlogtype, DbType.Int32)).ToString();
            db.Dispose();
            return count;
        }
        /// <summary>
        /// 统计续卡总金额
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="cardlogtype"></param>
        /// <returns></returns>
        public string View_Price(string storesid, string starttime, string endtime)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string count = db.GetValue("Select sum(convert(decimal(10,2),[newprice])-convert(decimal(10,2),[oldprice])) From [customer_CardLog] Where [storesid]=@storesid and [cardlogtype]=1 and datediff(month,[addtime],'" + starttime + "')<=0 and datediff(month,[addtime],'" + endtime + "')>=0 and [newprice]<>''", db.CreateParameter("@storesid", storesid, DbType.Int32)).ToString();
            db.Dispose();
            return count;
        }
        /// <summary>
        /// 统计调整总金额
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="cardlogtype"></param>
        /// <returns></returns>
        public string View_TiaoZhengPrice(string storesid, string starttime, string endtime)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string count = db.GetValue("Select sum(convert(decimal(10,2),[newprice])-convert(decimal(10,2),[oldprice])) From [customer_CardLog] Where [storesid]=@storesid and [cardlogtype]=2 and datediff(month,[addtime],'" + starttime + "')<=0 and datediff(month,[addtime],'" + endtime + "')>=0 and [newprice]<>''", db.CreateParameter("@storesid", storesid, DbType.Int32)).ToString();
            db.Dispose();
            return count;
        }
        /// <summary>
        /// 读取新开卡金额
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="cardNo"></param>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        public void Read_NewCardAllPrice(string storesid, string starttime, string endtime, ref int icount, ref double price)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT COUNT(id),sum(cast([newprice] as decimal(18, 0)))
  FROM [customer_CardLog]
where [cardlogtype]=3 and storesid=@storesid and datediff(month,[addtime],'" + starttime + "')<=0 and datediff(month,[addtime],'" + endtime + "')>=0 and [newprice]<>''", db.CreateParameter("@storesid", storesid, DbType.Int32));
            db.Dispose();
            icount = 0;
            price = 0;
            if (dt.Rows.Count > 0)
            {
                icount = int.Parse(dt.Rows[0][0].ToString());
                price = double.Parse(Base.Fun.fun.IsZero(dt.Rows[0][1].ToString()));
            }
            dt.Dispose();
        }
    }
}
