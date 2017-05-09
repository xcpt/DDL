using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.customer
{
    /// <summary>
    /// 用户预约
    /// </summary>
    public class Userappointment
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="uaModel"></param>
        /// <returns></returns>
        public string Insert(Model.customer.Userappointment uaModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",uaModel.storesid,DbType.Int32),
                               db.CreateParameter("@userid",uaModel.userid,DbType.Int32),
                               db.CreateParameter("@datetime",uaModel.datetime,DbType.DateTime),
                               db.CreateParameter("@addtime",Base.Fun.fun.IsDate(uaModel.addtime)?uaModel.addtime:DateTime.Now.ToString(),DbType.DateTime),
                               db.CreateParameter("@datetimehouer",uaModel.datetimehouer,DbType.Int32),
                               db.CreateParameter("@datetimeminute",uaModel.datetimeminute,DbType.Int32),
                               db.CreateParameter("@swimteacherid",uaModel.swimteacherid,DbType.Int32),
                               db.CreateParameter("@mamasid",uaModel.mamasid,DbType.Int32),
                               db.CreateParameter("@istop",uaModel.istop,DbType.Int32),
                               db.CreateParameter("@content",uaModel.content,DbType.String),
                               db.CreateParameter("@status",uaModel.status,DbType.Int32),
                               db.CreateParameter("@updatetime",null,DbType.DateTime),
                               db.CreateParameter("@source",uaModel.source,DbType.Int32),
                               db.CreateParameter("@cycletype",uaModel.cycletype,DbType.Int32)
                               };
            string id = db.GetNewID(@"INSERT INTO [customer_Userappointment]
           ([storesid]
           ,[userid]
           ,[datetime]
           ,[addtime]
           ,[datetimehouer]
           ,[datetimeminute]
           ,[swimteacherid]
           ,[mamasid]
           ,[istop]
           ,[content]
           ,[status]
           ,[updatetime]
           ,[source]
           ,[cycletype])
     VALUES
           (@storesid
           ,@userid
           ,@datetime
           ,@addtime
           ,@datetimehouer
           ,@datetimeminute
           ,@swimteacherid
           ,@mamasid
           ,@istop
           ,@content
           ,@status
           ,@updatetime
           ,@source
           ,@cycletype)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="uaModel"></param>
        /// <returns></returns>
        public int Update(Model.customer.Userappointment uaModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@userid",uaModel.userid,DbType.Int32),
                               db.CreateParameter("@datetime",uaModel.datetime,DbType.DateTime),
                               db.CreateParameter("@datetimehouer",uaModel.datetimehouer,DbType.Int32),
                               db.CreateParameter("@datetimeminute",uaModel.datetimeminute,DbType.Int32),
                               db.CreateParameter("@swimteacherid",uaModel.swimteacherid,DbType.Int32),
                               db.CreateParameter("@mamasid",uaModel.mamasid,DbType.Int32),
                               db.CreateParameter("@istop",uaModel.istop,DbType.Int32),
                               db.CreateParameter("@content",uaModel.content,DbType.String),
                               db.CreateParameter("@id",uaModel.id,DbType.Int32)
                               };
            int icount = db.GetRowCount(@"Update [customer_Userappointment]
           set [userid]=@userid
           ,[datetime]=@datetime
           ,[datetimehouer]=@datetimehouer
           ,[datetimeminute]=@datetimeminute
           ,[swimteacherid]=@swimteacherid
           ,[mamasid]=@mamasid
           ,[istop]=@istop
           ,[content]=@content
           where [id]=@id", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 修改预约状态信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public int Update_Status(string id, string Status)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@status",Status,DbType.Int32),
                               db.CreateParameter("@updatetime",(Status.Equals("1")? DateTime.Now.ToString():null),DbType.DateTime),
                               db.CreateParameter("@id",id,DbType.Int32)
                               };
            int icount = db.GetRowCount("UPDATE [customer_Userappointment] SET [status] = @status,[updatetime]=@updatetime WHERE [id]=@id", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 修改预约状态信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public int Update_Status_Cancel(string id, string content)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@status",2,DbType.Int32),
                               db.CreateParameter("@content",content,DbType.String),
                               db.CreateParameter("@id",id,DbType.Int32)
                               };
            int icount = db.GetRowCount("UPDATE [customer_Userappointment] SET [status] = @status,[content]=@content WHERE [id]=@id", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 读取单条
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.customer.Userappointment Read(string id)
        {
            Model.customer.Userappointment uaModel = new Model.customer.Userappointment();
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[userid]
      ,[datetime]
      ,[addtime]
      ,[datetimehouer]
      ,[datetimeminute]
      ,[swimteacherid]
      ,[mamasid]
      ,[istop]
      ,[content]
      ,[status]
      ,[updatetime]
      ,[source]
      ,[cycletype]
  FROM [customer_Userappointment] Where isDel=0 and [id]=@id", db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            if (dt.Rows.Count > 0)
            {
                uaModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return uaModel;
        }

        /// <summary>
        /// 读取用户今天的第一个没有处理的预约
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.customer.Userappointment ReadOnUserID(string userid)
        {
            Model.customer.Userappointment uaModel = new Model.customer.Userappointment();
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[userid]
      ,[datetime]
      ,[addtime]
      ,[datetimehouer]
      ,[datetimeminute]
      ,[swimteacherid]
      ,[mamasid]
      ,[istop]
      ,[content]
      ,[status]
      ,[updatetime]
      ,[source]
      ,[cycletype]
  FROM [customer_Userappointment] Where [userid]=@userid and isDel=0 and [status]=0 and datediff(DAY,getdate(),[datetime])=0 order by [id] asc", db.CreateParameter("@userid", userid, DbType.Int32));
            db.Dispose();
            if (dt.Rows.Count > 0)
            {
                uaModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return uaModel;
        }
        /// <summary>
        /// 读取用户没有处理的预约
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Model.customer.Userappointment> ReadOnUserUserappointment(string userid, DateTime dtime)
        {
            Model.customer.Userappointment uaModel = new Model.customer.Userappointment();
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[userid]
      ,[datetime]
      ,[addtime]
      ,[datetimehouer]
      ,[datetimeminute]
      ,[swimteacherid]
      ,[mamasid]
      ,[istop]
      ,[content]
      ,[status]
      ,[updatetime]
      ,[source]
      ,[cycletype]
  FROM [customer_Userappointment] Where [userid]=@userid and isDel=0 and datediff(day,[datetime],'" + dtime.ToString() + "')=0 and [status]=0 order by [id] asc", db.CreateParameter("@userid", userid, DbType.Int32));
            db.Dispose();
            List<Model.customer.Userappointment> uaList = new List<Model.customer.Userappointment>();
            foreach(DataRow dr in dt.Rows)
            {
                uaList.Add(DataRow2Model(dr));
            }
            dt.Dispose();
            return uaList;
        }
        /// <summary>
        /// 读取用户没有处理的预约
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public List<Model.customer.Userappointment> ReadOnUserUserappointment(string userid)
        {
            Model.customer.Userappointment uaModel = new Model.customer.Userappointment();
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[userid]
      ,[datetime]
      ,[addtime]
      ,[datetimehouer]
      ,[datetimeminute]
      ,[swimteacherid]
      ,[mamasid]
      ,[istop]
      ,[content]
      ,[status]
      ,[updatetime]
      ,[source]
      ,[cycletype]
  FROM [customer_Userappointment] Where [userid]=@userid and isDel=0 and [status]=0 and datediff(day,getdate(),[datetime])>=0 order by [datetime],[id] asc", db.CreateParameter("@userid", userid, DbType.Int32));
            db.Dispose();
            List<Model.customer.Userappointment> uaList = new List<Model.customer.Userappointment>();
            foreach (DataRow dr in dt.Rows)
            {
                uaList.Add(DataRow2Model(dr));
            }
            dt.Dispose();
            return uaList;
        }
        /// <summary>
        /// 查看是否有未处理的
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.customer.Userappointment ReadOnUserUserappointmentOnUser(string UserID, string dtime)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT a.[id]
      ,a.[storesid]
      ,a.[userid]
      ,a.[datetime]
      ,a.[addtime]
      ,a.[datetimehouer]
      ,a.[datetimeminute]
      ,a.[swimteacherid]
      ,a.[mamasid]
      ,a.[istop]
      ,a.[content]
      ,a.[status]
      ,a.[updatetime]
      ,a.[source]
      ,a.[cycletype] FROM [customer_Userappointment] as a inner join [Staff_member] as b on a.[swimteacherid]=b.[id] Where a.[UserID]=" + UserID + " and a.isDel=0 and datediff(day,a.[datetime],'" + dtime + "')=0 and a.[status]=0");
            db.Dispose();
            Model.customer.Userappointment uaModel = new Model.customer.Userappointment();
            if (dt.Rows.Count > 0)
            {
                uaModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return uaModel;
        }
        /// <summary>
        /// 查看是否有未处理的预约某老师及时间点的
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.customer.Userappointment ReadOnUserUserappointment(string dtime, string datetimehouer, string datetimeminute, string swimteacherid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT a.[id]
      ,a.[storesid]
      ,a.[userid]
      ,a.[datetime]
      ,a.[addtime]
      ,a.[datetimehouer]
      ,a.[datetimeminute]
      ,a.[swimteacherid]
      ,a.[mamasid]
      ,a.[istop]
      ,a.[content]
      ,a.[status]
      ,a.[updatetime]
      ,a.[source]
      ,a.[cycletype] FROM [customer_Userappointment] as a inner join [Staff_member] as b on a.[swimteacherid]=b.[id] Where a.[datetimehouer]=" + datetimehouer + " and a.isDel=0 and a.[datetimeminute]=" + datetimeminute + " and a.[swimteacherid]=" + swimteacherid + " and b.[name]!='其他' and datediff(day,a.[datetime],'" + dtime + "')=0 and a.[status]=0");
            db.Dispose();
            Model.customer.Userappointment uaModel = new Model.customer.Userappointment();
            if (dt.Rows.Count > 0)
            {
                uaModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return uaModel;
        }
        /// <summary>
        /// 读取用户没有处理的预约 包含婴儿类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Model.customer.Userappointment> ReadOnUserUserappointmentAll(string userid, DateTime dtime)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT a.[id]
      ,a.[storesid]
      ,a.[userid]
      ,a.[datetime]
      ,a.[addtime]
      ,a.[datetimehouer]
      ,a.[datetimeminute]
      ,a.[swimteacherid]
      ,a.[mamasid]
      ,a.[istop]
      ,a.[content]
      ,a.[status]
      ,a.[updatetime]
      ,a.[source]
      ,a.[cycletype]
  FROM [customer_Userappointment] as a Where a.[userid]=@userid and a.isDel=0 and datediff(day,'" + dtime.ToString() + "',a.[datetime])>=0 and a.[status]=0 order by a.[id] asc", db.CreateParameter("@userid", userid, DbType.Int32));
            db.Dispose();
            List<Model.customer.Userappointment> uaList = new List<Model.customer.Userappointment>();
            foreach (DataRow dr in dt.Rows)
            {
                Model.customer.Userappointment uaModel = DataRow2Model(dr);
                uaList.Add(uaModel);
            }
            dt.Dispose();
            return uaList;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(string id, string delname)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            int icount = db.GetRowCount("Update [customer_Userappointment] set isDel=1,delname=@delname Where [ID]=@id", db.CreateParameter("@id", id, DbType.Int32),db.CreateParameter("@delname",delname,DbType.String));
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 预约数量（因为多店修改）
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public string GetNowDay(string storesid, string cycletype)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string icount = db.GetValue("Select count(a.[id]) From [customer_Userappointment] as a Where a.isDel=0 and a.[cycletype]=" + cycletype + (Base.Fun.fun.pnumeric(storesid) ? " and a.[StoresID]=" + storesid : "") + " and DateDiff(day,[datetime],getdate())=0").ToString();
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="storesid">门店ID</param>
        /// <param name="cardNo">卡号</param>
        /// <param name="name">姓名</param>
        /// <param name="cycletype">婴儿类型</param>
        /// <param name="swimteacherid">游泳老师名称</param>
        /// <param name="status">状态</param>
        /// <param name="statustime">预约开始时间</param>
        /// <param name="endtime">预约结束时间</param>
        /// <returns></returns>
        public string View(int PageSize, string storesid, string userid, string cardNo, string name, string cycletype, string swimteacherid, string status, string statustime, string endtime, string datetimehouer, string datetimeminute, string Mobile)
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
                page.TableName = "[customer_Userappointment] as a inner join [customer_User] as b on a.[userid]=b.[userid] left join [Sys_stores] as s on b.[storesid]=s.[storesid] left join [customer_Card] as c on b.[cardid]=c.[cardid] left join [customer_CardType] as d on c.[cardtypeid]=d.[id] left join [Staff_member] as e on a.[swimteacherid]=e.[id] left join [Sys_mamas] as f on a.[mamasid]=f.[id]";
                page.OrderBy = "order by a.[cycletype],a.[datetime] asc,a.[datetimehouer] asc,a.[datetimeminute] asc";
                page.Index = "a.[id]";
                page.Field = "a.[id],(select top 1 [picurl] from [baby_album] Where [userid]=a.[userid] order by [id] desc),c.[cardNo],a.[istop],b.[storesid],s.[title],b.[name],b.[nickname],d.[title] as cardtype,a.[cycletype]," + Model.Data.Basic.GetMonth("b.[birthday]") + ",datediff(DAY,a.[datetime],getdate()),a.[datetime],a.[datetimehouer],a.[datetimeminute],a.[updatetime],a.[status],e.[name] as swimteachername,f.[title] as mamasname,a.[addtime],a.[source],a.[content]";
                List<string> Filter = new List<string>();
                Filter.Add("a.isDel=0 and a.[storesid]=" + storesid);
                if (Base.Fun.fun.pnumeric(userid))
                {
                    Filter.Add("a.[userid]=" + userid);
                }
                if (cardNo.Length > 0)
                {
                    if (cardNo.Length >= 10)
                    {
                        Filter.Add("c.[cardNumber]='" + cardNo + "'");
                    }
                    else
                    {
                        Filter.Add("c.[CardNo]='" + cardNo + "'");
                    }
                }
                if (Mobile.Length > 0)
                {
                    Filter.Add("b.[Mobile]='" + Mobile + "'");
                }
                if (name.Length > 0)
                {
                    Filter.Add("(b.[name] like '%" + name + "%' or b.[nickname] like '%" + name + "%')");
                }
                if (Base.Fun.fun.IsNumeric(cycletype))
                {
                    Filter.Add("a.[cycletype]=" + cycletype);
                }
                if (Base.Fun.fun.pnumeric(swimteacherid))
                {
                    Filter.Add("a.[swimteacherid]=" + swimteacherid);
                }
                if (Base.Fun.fun.IsNumeric(status))
                {
                    Filter.Add("a.[status]=" + status);
                }
                if (Base.Fun.fun.IsDate(statustime))
                {
                    Filter.Add("datediff(day,a.[datetime],'" + statustime + "')<=0");
                }
                if (Base.Fun.fun.IsDate(endtime))
                {
                    Filter.Add("datediff(day,a.[datetime],'" + endtime + "')>=0");
                }
                if (Base.Fun.fun.IsNumeric(datetimehouer))
                {
                    Filter.Add("a.[datetimehouer]=" + datetimehouer);
                }
                if (Base.Fun.fun.IsNumeric(datetimeminute))
                {
                    Filter.Add("a.[datetimeminute]=" + datetimeminute);
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
        /// 
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private Model.customer.Userappointment DataRow2Model(DataRow dr)
        {
            Model.customer.Userappointment uaModel = new Model.customer.Userappointment();
            uaModel.id = dr["id"].ToString();
            uaModel.storesid = dr["storesid"].ToString();
            uaModel.userid = dr["userid"].ToString();
            uaModel.datetime = dr["datetime"].ToString();
            uaModel.addtime = dr["addtime"].ToString();
            uaModel.datetimehouer = dr["datetimehouer"].ToString();
            uaModel.datetimeminute = dr["datetimeminute"].ToString();
            uaModel.swimteacherid = dr["swimteacherid"].ToString();
            uaModel.mamasid = dr["mamasid"].ToString();
            uaModel.istop = dr["istop"].ToString();
            uaModel.content = dr["content"].ToString();
            uaModel.status = dr["status"].ToString();
            uaModel.updatetime = dr["updatetime"].ToString();
            uaModel.source = dr["source"].ToString();
            uaModel.cycletype = dr["cycletype"].ToString();
            return uaModel;
        }
    }
}
