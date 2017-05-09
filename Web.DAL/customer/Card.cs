using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.customer
{
    public class Card
    {
        private static string SqlStr = @"SELECT [cardid]
      ,[storesid]
      ,[cardNo]
      ,[cardNumber]
      ,[positivenum]
      ,[userpositivenum]
      ,[surpluspositivenum]
      ,[negativenum]
      ,[usernegativenum]
      ,[surplusnegativenum]
      ,[surplusnum]
      ,[price]
      ,[userprice]
      ,[surplusprice]
      ,[starttime]
      ,[endtime]
      ,[isclose]
      ,[cardtypeid]
      ,[cardstatus]
      ,[stoptime]
      ,[addtime]
  FROM [customer_Card] Where ";
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="cModel"></param>
        /// <returns></returns>
        public string Insert(Model.customer.Card cModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",cModel.storesid,DbType.Int32),
                               db.CreateParameter("@cardNo",cModel.cardNo,DbType.String),
                               db.CreateParameter("@cardNumber",cModel.cardNumber,DbType.String),
                               db.CreateParameter("@positivenum",cModel.positivenum,DbType.Int32),
                               db.CreateParameter("@userpositivenum",cModel.userpositivenum,DbType.Int32),
                               db.CreateParameter("@surpluspositivenum",cModel.surpluspositivenum,DbType.Int32),
                               db.CreateParameter("@negativenum",cModel.negativenum,DbType.Int32),
                               db.CreateParameter("@usernegativenum",cModel.usernegativenum,DbType.Int32),
                               db.CreateParameter("@surplusnegativenum",cModel.surplusnegativenum,DbType.Int32),
                               db.CreateParameter("@surplusnum",cModel.surplusnum,DbType.Int32),
                               db.CreateParameter("@price",cModel.price,DbType.Double),
                               db.CreateParameter("@userprice",cModel.userprice,DbType.Double),
                               db.CreateParameter("@surplusprice",cModel.surplusprice,DbType.Double),
                               db.CreateParameter("@starttime",Base.Fun.fun.IsDate(cModel.starttime)?cModel.starttime:null,DbType.DateTime),
                               db.CreateParameter("@endtime",Base.Fun.fun.IsDate(cModel.endtime)?cModel.endtime:null,DbType.DateTime),
                               db.CreateParameter("@stoptime",Base.Fun.fun.IsDate(cModel.stoptime)?cModel.stoptime:null,DbType.DateTime),
                               db.CreateParameter("@isclose",cModel.isclose,DbType.Int32),
                               db.CreateParameter("@cardtypeid",cModel.cardtypeid,DbType.Int32),
                               db.CreateParameter("@cardstatus",cModel.cardstatus,DbType.Int32),
                               db.CreateParameter("@addtime",(Base.Fun.fun.IsDate(cModel.addtime)?cModel.addtime:DateTime.Now.ToString()),DbType.DateTime)
                               };
            string id = db.GetNewID(@"INSERT INTO [customer_Card]
           ([storesid]
           ,[cardNo]
           ,[cardNumber]
           ,[positivenum]
           ,[userpositivenum]
           ,[surpluspositivenum]
           ,[negativenum]
           ,[usernegativenum]
           ,[surplusnegativenum]
           ,[surplusnum]
           ,[price]
           ,[userprice]
           ,[surplusprice]
           ,[starttime]
           ,[endtime]
           ,[stoptime]
           ,[isclose]
           ,[cardtypeid]
           ,[cardstatus]
           ,[addtime])
     VALUES
           (@storesid
           ,@cardNo
           ,@cardNumber
           ,@positivenum
           ,@userpositivenum
           ,@surpluspositivenum
           ,@negativenum
           ,@usernegativenum
           ,@surplusnegativenum
           ,@surplusnum
           ,@price
           ,@userprice
           ,@surplusprice
           ,@starttime
           ,@endtime
           ,@stoptime
           ,@isclose
           ,@cardtypeid
           ,@cardstatus
           ,@addtime)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="cModel"></param>
        /// <returns></returns>
        public int Update(Model.customer.Card cModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@positivenum",cModel.positivenum,DbType.Int32),
                               db.CreateParameter("@negativenum",cModel.negativenum,DbType.Int32),
                               db.CreateParameter("@price",cModel.price,DbType.Double),
                               db.CreateParameter("@endtime",Base.Fun.fun.IsDate(cModel.endtime)?cModel.endtime:null,DbType.DateTime),
                               db.CreateParameter("@cardtypeid",cModel.cardtypeid,DbType.Int32),
                               db.CreateParameter("@cardid",cModel.cardid,DbType.Int32)
                               };
            int icount = db.GetRowCount(@"UPDATE [customer_Card]
   SET [positivenum] =[positivenum] + @positivenum
      ,[surpluspositivenum]=[surpluspositivenum]+@positivenum
      ,[negativenum] =[negativenum]+ @negativenum
      ,[surplusnegativenum]=[surplusnegativenum]+@negativenum
      ,[surplusnum]=[surplusnum]+@positivenum+@negativenum
      ,[price] =[price]+ @price
      ,[surplusprice]=[surplusprice]+@price
      ,[endtime] = @endtime
      ,[cardtypeid] = @cardtypeid
 WHERE [cardid]=@cardid", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 修改卡类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Update_cardtypeid(string storesid,string cardid, string cardtypeid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            int icount = db.GetRowCount(@"UPDATE [customer_Card]
   SET [cardtypeid] = @cardtypeid
 WHERE [storesid]=@storesid and [cardid]=@cardid", db.CreateParameter("@cardtypeid", cardtypeid, DbType.Int32), db.CreateParameter("@storesid", storesid,DbType.Int32), db.CreateParameter("@cardid", cardid, DbType.Int32));
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 正价次数使用1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Update_positivenum(string cardid)
        {
            string positivenum = "1";
            Base.Conn.Database db = new Base.Conn.Database();
            int icount = db.GetRowCount(@"UPDATE [customer_Card]
   SET [userpositivenum] = [userpositivenum]+@positivenum,[surpluspositivenum]=[surpluspositivenum]-@positivenum,[surplusnum]=[surplusnum]-@positivenum
 WHERE [cardid]=@cardid", db.CreateParameter("@positivenum", positivenum, DbType.Int32), db.CreateParameter("@cardid", cardid, DbType.Int32));
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 正价次数使用1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Update_Addpositivenum(string cardid)
        {
            string positivenum = "-1";
            Base.Conn.Database db = new Base.Conn.Database();
            int icount = db.GetRowCount(@"UPDATE [customer_Card]
   SET [userpositivenum] = [userpositivenum]+@positivenum,[surpluspositivenum]=[surpluspositivenum]-@positivenum,[surplusnum]=[surplusnum]-@positivenum
 WHERE [cardid]=@cardid", db.CreateParameter("@positivenum", positivenum, DbType.Int32), db.CreateParameter("@cardid", cardid, DbType.Int32));
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 赠送次数使用1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Update_negativenum(string cardid)
        {
            string positivenum = "1";
            Base.Conn.Database db = new Base.Conn.Database();
            int icount = db.GetRowCount(@"UPDATE [customer_Card]
   SET [usernegativenum] = [usernegativenum]+@positivenum,[surplusnegativenum]=[surplusnegativenum]-@positivenum,[surplusnum]=[surplusnum]-@positivenum
 WHERE [cardid]=@cardid", db.CreateParameter("@positivenum", positivenum, DbType.Int32), db.CreateParameter("@cardid", cardid, DbType.Int32));
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 赠送次数使用1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Update_Addnegativenum(string cardid)
        {
            string positivenum = "-1";
            Base.Conn.Database db = new Base.Conn.Database();
            int icount = db.GetRowCount(@"UPDATE [customer_Card]
   SET [usernegativenum] = [usernegativenum]+@positivenum,[surplusnegativenum]=[surplusnegativenum]-@positivenum,[surplusnum]=[surplusnum]-@positivenum
 WHERE [cardid]=@cardid", db.CreateParameter("@positivenum", positivenum, DbType.Int32),  db.CreateParameter("@cardid", cardid, DbType.Int32));
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 金额1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Update_price(string cardid, string price)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            int icount = db.GetRowCount(@"UPDATE [customer_Card]
   SET [userprice] = [userprice]+@positivenum,[surplusprice]=[surplusprice]-@positivenum
 WHERE [cardid]=@cardid", db.CreateParameter("@price", price, DbType.Int32), db.CreateParameter("@cardid", cardid, DbType.Int32));
            db.Dispose();
            return icount;
        }
        
        /// <summary>
        /// 停卡
        /// </summary>
        /// <param name="cardid"></param>
        /// <param name="cardstatus"></param>
        /// <returns></returns>
        public int Update_StopCard(string cardid, string stoptime, string endtime)
        {
            Base.Conn.Database db = new Base.Conn.Database();

            int Day = Base.Time.Time.TimeBad(DateTime.Now.ToString(), stoptime, "天");
            endtime = DateTime.Parse(endtime).AddDays(Day).ToString("yyyy-MM-dd");

            int icount = db.GetRowCount(@"UPDATE [customer_Card]
   SET [cardstatus] = @cardstatus,[stoptime]=@stoptime,[endtime]=@endtime
 WHERE [cardid]=@cardid", db.CreateParameter("@cardstatus", -1, DbType.Int32), db.CreateParameter("@stoptime", stoptime, DbType.DateTime), db.CreateParameter("@endtime", endtime,DbType.DateTime), db.CreateParameter("@cardid", cardid, DbType.Int32));
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 重新开卡
        /// </summary>
        /// <param name="cardid"></param>
        /// <returns></returns>
        public string Update_Open(string cardid, string stoptime, string endtime)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            int Day = Base.Time.Time.TimeBad(stoptime, DateTime.Now.ToString(), "天");
            endtime = DateTime.Parse(endtime).AddDays(Day).ToString("yyyy-MM-dd");
            int icount = db.GetRowCount(@"UPDATE [customer_Card]
   SET [cardstatus] = @cardstatus,[stoptime]=@stoptime,[endtime]=@endtime
 WHERE [cardid]=@cardid", db.CreateParameter("@cardstatus", 1, DbType.Int32), db.CreateParameter("@stoptime", null, DbType.DateTime), db.CreateParameter("@endtime", endtime, DbType.DateTime),  db.CreateParameter("@cardid", cardid, DbType.Int32));
            db.Dispose();
            return endtime;
        }
        /// <summary>
        /// 换卡
        /// </summary>
        /// <param name="cardid"></param>
        /// <param name="CardNo"></param>
        /// <param name="CardNumber"></param>
        /// <returns></returns>
        public int Update_CardNo(string cardid, string CardNo, string CardNumber)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            int icount = db.GetRowCount(@"UPDATE [customer_Card]
   SET [cardNo] = @cardNo,[cardNumber]=@cardNumber
 WHERE [cardid]=@cardid", db.CreateParameter("@cardNo", CardNo, DbType.String), db.CreateParameter("@cardNumber", CardNumber, DbType.String), db.CreateParameter("@cardid", cardid, DbType.Int32));
            db.Dispose();
            return icount;
        }

        /// <summary>
        /// 读取获得卡信息
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="cardNo"></param>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        public string Read_CardNo(string storesid, string cardNo, string cardNumber)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string cardID = db.GetValue(@"SELECT top 1 [cardid] FROM [customer_Card] Where [storesid]=@storesid and ([cardNo]=@cardNo or [cardNumber]=@cardNumber)", db.CreateParameter("@storesid", storesid, DbType.Int32), db.CreateParameter("@cardNo", cardNo, DbType.String), db.CreateParameter("@cardNumber", cardNumber,DbType.String)).ToString();
            db.Dispose();
            return cardID;
        }
        /// <summary>
        /// 读取获得卡信息
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="cardNo"></param>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        public string Read_CardNo(string storesid, string cardNo)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string cardID = db.GetValue(@"SELECT top 1 [cardid] FROM [customer_Card] Where [storesid]=@storesid and [cardNo]=@cardNo", db.CreateParameter("@storesid", storesid, DbType.Int32), db.CreateParameter("@cardNo", cardNo, DbType.String)).ToString();
            db.Dispose();
            return cardID;
        }
        /// <summary>
        /// 读取获得卡信息
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="cardNo"></param>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        public string Read_CardNo_Outlets(string cardNo, string cardNumber)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string cardID = db.GetValue(@"SELECT top 1 a.[cardid] FROM [customer_Card] as a inner join [Sys_stores] as b on a.[storesid]=b.[storesid] Where b.[isoutlets]=1 and (a.[cardNo]=@cardNo or a.[cardNumber]=@cardNumber)", db.CreateParameter("@cardNo", cardNo, DbType.String), db.CreateParameter("@cardNumber", cardNumber, DbType.String)).ToString();
            db.Dispose();
            return cardID;
        }

        /// <summary>
        /// 读取卡次及金额统计信息
        /// </summary>
        /// <param name="cardid"></param>
        /// <returns></returns>
        public Model.customer.Card Read_Total(string storesid, string stime, string etime)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT sum(a.surpluspositivenum),sum(a.userpositivenum),sum(a.surplusnegativenum),sum(a.usernegativenum),ROUND(sum((a.[surpluspositivenum]+a.[surplusnegativenum])*b.[price]/(b.[positivenum]+b.[negativenum])),2),ROUND(sum((a.[userpositivenum]+a.[usernegativenum])*b.[price]/(b.[positivenum]+b.[negativenum])),2) FROM [customer_Card] as a inner join [customer_CardType] as b on a.[cardtypeid]=b.[id] Where a.[storesid]=@storesid and datediff(day,a.[endtime],'"+stime+"')<=0" + (Base.Fun.fun.IsDate(stime) ? " and datediff(day,a.[addtime],'" + stime + "')<=0" : "") + (Base.Fun.fun.IsDate(etime) ? " and datediff(day,a.[addtime],'" + etime + "')>=0" : ""), db.CreateParameter("@storesid", storesid, DbType.Int32));
            db.Dispose();
            Model.customer.Card cModel = new Model.customer.Card();
            if (dt.Rows.Count > 0)
            {
                cModel.surpluspositivenum = dt.Rows[0][0].ToString();
                cModel.userpositivenum = dt.Rows[0][1].ToString();
                cModel.surplusnegativenum = dt.Rows[0][2].ToString();
                cModel.usernegativenum = dt.Rows[0][3].ToString();
                cModel.surplusprice = dt.Rows[0][4].ToString();
                cModel.userprice = dt.Rows[0][5].ToString();
            }
            dt.Dispose();
            return cModel;
        }
        /// <summary>
        /// 读取卡次及金额统计信息
        /// </summary>
        /// <param name="cardid"></param>
        /// <returns></returns>
        public Model.customer.Card Read_TotalStatus(string storesid, string stime, string etime)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT sum(a.surpluspositivenum),sum(a.userpositivenum),sum(a.surplusnegativenum),sum(a.usernegativenum),ROUND(sum((a.[surpluspositivenum]+a.[surplusnegativenum])*b.[price]/(b.[positivenum]+b.[negativenum])),2),ROUND(sum((a.[userpositivenum]+a.[usernegativenum])*b.[price]/(b.[positivenum]+b.[negativenum])),2) FROM [customer_Card] as a inner join [customer_CardType] as b on a.[cardtypeid]=b.[id] Where a.[storesid]=@storesid and a.[cardstatus]=1 and datediff(day,a.[endtime],'"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"')>=0 and datediff(day,a.[endtime],'" + stime + "')<=0" + (Base.Fun.fun.IsDate(stime) ? " and datediff(day,a.[addtime],'" + stime + "')<=0" : "") + (Base.Fun.fun.IsDate(etime) ? " and datediff(day,a.[addtime],'" + etime + "')>=0" : ""), db.CreateParameter("@storesid", storesid, DbType.Int32));
            db.Dispose();
            Model.customer.Card cModel = new Model.customer.Card();
            if (dt.Rows.Count > 0)
            {
                cModel.surpluspositivenum = dt.Rows[0][0].ToString();
                cModel.userpositivenum = dt.Rows[0][1].ToString();
                cModel.surplusnegativenum = dt.Rows[0][2].ToString();
                cModel.usernegativenum = dt.Rows[0][3].ToString();
                cModel.surplusprice = dt.Rows[0][4].ToString();
                cModel.userprice = dt.Rows[0][5].ToString();
            }
            dt.Dispose();
            return cModel;
        }
        /// <summary>
        /// 读取总卡信息
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="cardNo"></param>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        public string Read_CardNum(string storesid, string starttime, string endtime)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string cardID = db.GetValue(@"SELECT count([cardid]) FROM [customer_Card] Where [storesid]=@storesid" + (Base.Fun.fun.IsDate(starttime) ? " and datediff(month,[addtime],'" + starttime + "')<=0" : "") + (Base.Fun.fun.IsDate(endtime) ? " and datediff(month,[addtime],'" + endtime + "')>=0" : ""), db.CreateParameter("@storesid", storesid, DbType.Int32)).ToString();
            db.Dispose();
            return cardID;
        }

        /// <summary>
        /// 读取总卡信息
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="cardNo"></param>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        public string Read_CardNum(string storesid, string cardtypeid, string starttime, string endtime)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string cardID = db.GetValue(@"SELECT count([cardid]) FROM [customer_Card] Where [storesid]=@storesid and [cardtypeid]=@cardtypeid and datediff(month,[addtime],'" + starttime + "')<=0 and datediff(month,[addtime],'" + endtime + "')>=0", db.CreateParameter("@storesid", storesid, DbType.Int32), db.CreateParameter("@cardtypeid", cardtypeid, DbType.Int32)).ToString();
            db.Dispose();
            return cardID;
        }
        /// <summary>
        /// 读取单条信息
        /// </summary>
        /// <param name="cardid"></param>
        /// <returns></returns>
        public Model.customer.Card Read(string cardid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(SqlStr + "[cardid]=@cardid", db.CreateParameter("@cardid", cardid, DbType.Int32));
            db.Dispose();
            Model.customer.Card cModel = new Model.customer.Card();
            if (dt.Rows.Count > 0)
            {
                cModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return cModel;
        }
        /// <summary>
        /// 显示内容
        /// </summary>
        /// <param name="PageSize">分页数量</param>
        /// <param name="cardNo">卡号</param>
        /// <param name="name">会员姓名</param>
        /// <param name="cardtype">卡类型</param>
        /// <param name="cycletype">婴儿类型</param>
        /// <param name="startnum">开始剩余次数</param>
        /// <param name="endnum">结束剩余次数</param>
        /// <param name="cardstatus">卡状态</param>
        /// <returns></returns>
        public string View(int PageSize, string storesid, string cardNo, string userid, string name, string cardtypeid, string cycletype, string startnum, string endnum, string cardstatus,string Mobile)
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
                page.TableName = "[customer_Card] as a inner join [customer_User] as b on a.[cardid]=b.[cardid] inner join [customer_User_Stores] as s on b.[userid]=s.[userid] and s.[storesid]=" + storesid + " left join [Sys_Stores] as ss on b.[storesid]=ss.[storesid] left join [customer_CardType] as c on a.[cardtypeid]=c.[id]";
                page.OrderBy = "order by a.[cardid] desc";
                page.Index = "a.[cardid]";
                page.Field = "a.[cardid],a.[cardNo],c.[title] as cardtypeName,b.[storesid],ss.[title],b.[name]," + Model.Data.Basic.GetMonth("b.[birthday]") + ",b.[cycletype],a.[positivenum],a.[negativenum],a.[surpluspositivenum],a.[surplusnegativenum],(select sum([surpluspositivenum]) From [customer_User_Stores] Where [storesid]!=" + storesid + " and [userid]=b.[userid]),(select sum([surplusnegativenum]) From [customer_User_Stores] Where [storesid]!=" + storesid + " and [userid]=b.[userid]),a.[price],a.[starttime],a.[endtime],Case a.[cardstatus] When -1 then DATEDIFF(day,(select top 1 [AddTime] From [customer_CardLog] Where [storesid]=a.[storesid] and [cardid]=a.[cardid] and [cardlogtype]=4 order by [id] desc),a.[endtime]) else DATEDIFF(day,getdate(),a.[endtime]) end enddaynum,a.[cardstatus],a.[stoptime],b.[content],b.[userid]";
                List<string> Filter = new List<string>();
                if (Base.Fun.fun.pnumeric(userid))
                {
                    Filter.Add("b.[userid]=" + userid);
                }
                if (cardNo.Length > 0)
                {
                    if (cardNo.Length >= 10)
                    {
                        Filter.Add("a.[cardNumber]='" + cardNo + "'");
                    }
                    else
                    {
                        Filter.Add("a.[CardNo]='" + cardNo + "'");
                    }
                }
                if (Mobile.Length > 0)
                {
                    Filter.Add("b.[Mobile]='" + Mobile + "'");
                }
                if (name.Length > 0)
                {
                    Filter.Add("b.[name]='" + name + "'");
                }
                if (Base.Fun.fun.IsNumeric(cardtypeid))
                {
                    Filter.Add("a.[cardtypeid]=" + cardtypeid);
                }
                if (Base.Fun.fun.IsNumeric(cycletype))
                {
                    Filter.Add("b.[cycletype]=" + cycletype);
                }
                if (Base.Fun.fun.IsNumeric(startnum))
                {
                    Filter.Add("a.[surplusnum]>=" + startnum);
                }
                if (Base.Fun.fun.IsNumeric(endnum))
                {
                    Filter.Add("a.[surplusnum]<=" + endnum);
                }
                if (Base.Fun.fun.IsNumeric(cardstatus))
                {
                    Filter.Add("a.[cardstatus]=" + cardstatus);
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
        /// 显示内容
        /// </summary>
        /// <param name="PageSize">分页数量</param>
        /// <param name="cardNo">卡号</param>
        /// <param name="name">会员姓名</param>
        /// <param name="cardtype">卡类型</param>
        /// <param name="cycletype">婴儿类型</param>
        /// <param name="startnum">开始剩余次数</param>
        /// <param name="endnum">结束剩余次数</param>
        /// <param name="cardstatus">卡状态</param>
        /// <returns></returns>
        public DataTable ViewToXls(string storesid, string cardNo, string userid, string name, string cardtypeid, string cycletype, string startnum, string endnum, string cardstatus, string Mobile)
        {
            DataTable dt = new DataTable();
            Base.Conn.Database db = new Base.Conn.Database();
            List<string> Filter = new List<string>();
            if (Base.Fun.fun.pnumeric(userid))
            {
                Filter.Add("b.[userid]=" + userid);
            }
            if (cardNo.Length > 0)
            {
                if (cardNo.Length >= 10)
                {
                    Filter.Add("a.[cardNumber]='" + cardNo + "'");
                }
                else
                {
                    Filter.Add("a.[CardNo]='" + cardNo + "'");
                }
            }
            if (Mobile.Length > 0)
            {
                Filter.Add("b.[Mobile]='" + Mobile + "'");
            }
            if (name.Length > 0)
            {
                Filter.Add("b.[name]='" + name + "'");
            }
            if (Base.Fun.fun.IsNumeric(cardtypeid))
            {
                Filter.Add("a.[cardtypeid]=" + cardtypeid);
            }
            if (Base.Fun.fun.IsNumeric(cycletype))
            {
                Filter.Add("b.[cycletype]=" + cycletype);
            }
            if (Base.Fun.fun.IsNumeric(startnum))
            {
                Filter.Add("a.[surplusnum]>=" + startnum);
            }
            if (Base.Fun.fun.IsNumeric(endnum))
            {
                Filter.Add("a.[surplusnum]<=" + endnum);
            }
            if (Base.Fun.fun.IsNumeric(cardstatus))
            {
                Filter.Add("a.[cardstatus]=" + cardstatus);
            }
            string filt = string.Join(" and ", Filter.ToArray());
            dt = db.GetData("select a.[cardid] as 卡ID,a.[cardNo] as 卡号,c.[title] as 卡类型,b.[storesid] as 店ID,ss.[title] as 店名称,b.[name] as 姓名," + Model.Data.Basic.GetMonth("b.[birthday]") + " as 月龄,b.[cycletype] as 婴儿类型,a.[positivenum] as 正价次数,a.[negativenum] as 赠送次数,a.[surpluspositivenum] as 剩余正价,a.[surplusnegativenum] as 剩余赠送,(select sum([surpluspositivenum]) From [customer_User_Stores] Where [storesid]!=" + storesid + " and [userid]=b.[userid]) as 非本店剩余正价,(select sum([surplusnegativenum]) From [customer_User_Stores] Where [storesid]!=" + storesid + " and [userid]=b.[userid]) as 非本店剩余赠送,a.[price] as 金额,a.[starttime] as 开始时间,a.[endtime] as 结束时间,Case a.[cardstatus] When -1 then DATEDIFF(day,(select top 1 [AddTime] From [customer_CardLog] Where [storesid]=a.[storesid] and [cardid]=a.[cardid] and [cardlogtype]=4 order by [id] desc),a.[endtime]) else DATEDIFF(day,getdate(),a.[endtime]) end 剩余天数,a.[cardstatus] as 卡状态,a.[stoptime] as 停止时间,b.[content] as 备注 From [customer_Card] as a inner join [customer_User] as b on a.[cardid]=b.[cardid] inner join [customer_User_Stores] as s on b.[userid]=s.[userid] and s.[storesid]=" + storesid + " left join [Sys_Stores] as ss on b.[storesid]=ss.[storesid] left join [customer_CardType] as c on a.[cardtypeid]=c.[id]" + (filt.Length > 0 ? " Where " + filt : "") + " order by a.[cardid] desc");
            db.Dispose();
            return dt;
        }
        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private Model.customer.Card DataRow2Model(DataRow dr)
        {
            Model.customer.Card cModel = new Model.customer.Card();
            cModel.cardid = dr["cardid"].ToString();
            cModel.storesid = dr["storesid"].ToString();
            cModel.cardNo = dr["cardNo"].ToString();
            cModel.cardNumber = dr["cardNumber"].ToString();
            cModel.positivenum = dr["positivenum"].ToString();
            cModel.userpositivenum = dr["userpositivenum"].ToString();
            cModel.surpluspositivenum = dr["surpluspositivenum"].ToString();
            cModel.negativenum = dr["negativenum"].ToString();
            cModel.usernegativenum = dr["usernegativenum"].ToString();
            cModel.surplusnegativenum = dr["surplusnegativenum"].ToString();
            cModel.surplusnum = dr["surplusnum"].ToString();
            cModel.price = dr["price"].ToString();
            cModel.userprice = dr["userprice"].ToString();
            cModel.surplusprice = dr["surplusprice"].ToString();
            cModel.starttime = dr["starttime"].ToString();
            cModel.endtime = dr["endtime"].ToString();
            cModel.isclose = dr["isclose"].ToString();
            cModel.cardtypeid = dr["cardtypeid"].ToString();
            cModel.cardstatus = dr["cardstatus"].ToString();
            cModel.stoptime = dr["stoptime"].ToString();
            cModel.addtime = dr["addtime"].ToString();
            return cModel;
        }
    }
}
