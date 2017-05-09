using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.customer
{
    /// <summary>
    /// 用户消费
    /// </summary>
    public class UserConsumption
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="ucModel"></param>
        /// <returns></returns>
        public string Insert(Model.customer.UserConsumption ucModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",ucModel.storesid,DbType.Int32),
                               db.CreateParameter("@appointmentid",ucModel.appointmentid,DbType.Int32),
                               db.CreateParameter("@userid",ucModel.userid,DbType.Int32),
                               db.CreateParameter("@CommodityID",ucModel.CommodityID,DbType.Int32),
                               db.CreateParameter("@price",ucModel.price,DbType.Double),
                               db.CreateParameter("@addtime",Base.Fun.fun.IsDate(ucModel.addtime)?ucModel.addtime:DateTime.Now.ToString(),DbType.DateTime),
                               db.CreateParameter("@timenum",ucModel.timenum,DbType.Int32),
                               db.CreateParameter("@swimteacherid",ucModel.swimteacherid,DbType.Int32),
                               db.CreateParameter("@mamasid",ucModel.mamasid,DbType.Int32),
                               db.CreateParameter("@monthage",ucModel.monthage,DbType.Int32),
                               db.CreateParameter("@height",ucModel.height,DbType.Double),
                               db.CreateParameter("@weight",ucModel.weight,DbType.Double),
                               db.CreateParameter("@temperature",ucModel.temperature,DbType.Double),
                               db.CreateParameter("@satisfactionid",ucModel.satisfactionid,DbType.Int32),
                               db.CreateParameter("@satisfactionuserid",ucModel.satisfactionuserid,DbType.Int32),
                               db.CreateParameter("@content",ucModel.content,DbType.String),
                               db.CreateParameter("@status",ucModel.status,DbType.Int32),
                               db.CreateParameter("@updatetime",Base.Fun.fun.IsDate(ucModel.updatetime)?ucModel.updatetime:null,DbType.DateTime),
                               db.CreateParameter("@statuscontent",ucModel.statuscontent,DbType.String),
                               db.CreateParameter("@IsCash",ucModel.IsCash,DbType.Int32),
                               db.CreateParameter("@Consumptiontype",ucModel.Consumptiontype,DbType.Int32)
                               };
            string id = db.GetNewID(@"INSERT INTO [customer_UserConsumption]
           ([storesid]
           ,[appointmentid]
           ,[userid]
           ,[CommodityID]
           ,[price]
           ,[addtime]
           ,[timenum]
           ,[swimteacherid]
           ,[mamasid]
           ,[monthage]
           ,[height]
           ,[weight]
           ,[temperature]
           ,[satisfactionid]
           ,[satisfactionuserid]
           ,[content]
           ,[status]
           ,[updatetime]
           ,[statuscontent]
           ,[IsCash]
           ,[Consumptiontype])
     VALUES
           (@storesid
           ,@appointmentid
           ,@userid
           ,@CommodityID
           ,@price
           ,@addtime
           ,@timenum
           ,@swimteacherid
           ,@mamasid
           ,@monthage
           ,@height
           ,@weight
           ,@temperature
           ,@satisfactionid
           ,@satisfactionuserid
           ,@content
           ,@status
           ,@updatetime
           ,@statuscontent
           ,@IsCash
           ,@Consumptiontype)", ps).ToString();
            db.Dispose();
            return id;
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="ucModel"></param>
        /// <returns></returns>
        public int Update(Model.customer.UserConsumption ucModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@CommodityID",ucModel.CommodityID,DbType.Int32),
                               db.CreateParameter("@timenum",ucModel.timenum,DbType.Int32),
                               db.CreateParameter("@swimteacherid",ucModel.swimteacherid,DbType.Int32),
                               db.CreateParameter("@mamasid",ucModel.mamasid,DbType.Int32),
                               db.CreateParameter("@height",ucModel.height,DbType.Double),
                               db.CreateParameter("@weight",ucModel.weight,DbType.Double),
                               db.CreateParameter("@temperature",ucModel.temperature,DbType.Double),
                               db.CreateParameter("@content",ucModel.content,DbType.String),
                               db.CreateParameter("@id",ucModel.id,DbType.Int32)
                               };
            int icount = db.GetRowCount(@"Update [customer_UserConsumption]
           set [CommodityID]=@CommodityID
           ,[timenum]=@timenum
           ,[swimteacherid]=@swimteacherid
           ,[mamasid]=@mamasid
           ,[height]=@height
           ,[weight]=@weight
           ,[temperature]=@temperature
           ,[content]=@content
           where [id]=@id", ps);
            db.Dispose();
            return icount;
        }

        /// <summary>
        /// 读取单条
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.customer.UserConsumption Read(string storesid, string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[appointmentid]
      ,[userid]
      ,[CommodityID]
      ,[price]
      ,[addtime]
      ,[timenum]
      ,[swimteacherid]
      ,[mamasid]
      ,[monthage]
      ,[height]
      ,[weight]
      ,[temperature]
      ,[satisfactionid]
      ,[satisfactionuserid]
      ,[content]
      ,[status]
      ,[updatetime]
      ,[statuscontent]
      ,[Consumptiontype]
      ,[IsCash]
  FROM [customer_UserConsumption] Where [storesid]=@storesid and [id]=@id", db.CreateParameter("@storesid", storesid, DbType.Int32), db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            Model.customer.UserConsumption ucModel = new Model.customer.UserConsumption();
            if (dt.Rows.Count > 0)
            {
                ucModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return ucModel;
        }
        /// <summary>
        /// 读取单条
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.customer.UserConsumption Read(string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[appointmentid]
      ,[userid]
      ,[CommodityID]
      ,[price]
      ,[addtime]
      ,[timenum]
      ,[swimteacherid]
      ,[mamasid]
      ,[monthage]
      ,[height]
      ,[weight]
      ,[temperature]
      ,[satisfactionid]
      ,[satisfactionuserid]
      ,[content]
      ,[status]
      ,[updatetime]
      ,[statuscontent]
      ,[Consumptiontype]
      ,[IsCash]
  FROM [customer_UserConsumption] Where [id]=@id", db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            Model.customer.UserConsumption ucModel = new Model.customer.UserConsumption();
            if (dt.Rows.Count > 0)
            {
                ucModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return ucModel;
        }
        /// <summary>
        /// 读取单条
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Model.customer.UserConsumption> ReadList(string ids)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[appointmentid]
      ,[userid]
      ,[CommodityID]
      ,[price]
      ,[addtime]
      ,[timenum]
      ,[swimteacherid]
      ,[mamasid]
      ,[monthage]
      ,[height]
      ,[weight]
      ,[temperature]
      ,[satisfactionid]
      ,[satisfactionuserid]
      ,[content]
      ,[status]
      ,[updatetime]
      ,[statuscontent]
      ,[Consumptiontype]
      ,[IsCash]
  FROM [customer_UserConsumption] Where [id] in(" + ids + ")");
            db.Dispose();
            List<Model.customer.UserConsumption> ucList = new List<Model.customer.UserConsumption>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ucList.Add(DataRow2Model(dr));
                }
            }
            dt.Dispose();
            return ucList;
        }
        /// <summary>
        /// 读取单条
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.customer.UserConsumption ReadOnUserID(string UserID)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[appointmentid]
      ,[userid]
      ,[CommodityID]
      ,[price]
      ,[addtime]
      ,[timenum]
      ,[swimteacherid]
      ,[mamasid]
      ,[monthage]
      ,[height]
      ,[weight]
      ,[temperature]
      ,[satisfactionid]
      ,[satisfactionuserid]
      ,[content]
      ,[status]
      ,[updatetime]
      ,[statuscontent]
      ,[Consumptiontype]
      ,[IsCash]
  FROM [customer_UserConsumption] Where [userid]=@UserID order by [id] desc", db.CreateParameter("@UserID", UserID, DbType.Int32));
            db.Dispose();
            Model.customer.UserConsumption ucModel = new Model.customer.UserConsumption();
            if (dt.Rows.Count > 0)
            {
                ucModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return ucModel;
        }
        /// <summary>
        /// 读取最后几条
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Model.customer.UserConsumption> ReadList(string storesid, string UserID, int Num)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT top " + Num.ToString() + @" [id]
      ,[storesid]
      ,[appointmentid]
      ,[userid]
      ,[CommodityID]
      ,[price]
      ,[addtime]
      ,[timenum]
      ,[swimteacherid]
      ,[mamasid]
      ,[monthage]
      ,[height]
      ,[weight]
      ,[temperature]
      ,[satisfactionid]
      ,[satisfactionuserid]
      ,[content]
      ,[status]
      ,[updatetime]
      ,[statuscontent]
      ,[Consumptiontype]
      ,[IsCash]
  FROM [customer_UserConsumption] Where [storesid]=@storesid and [UserID]=@UserID order by [id] desc", db.CreateParameter("@storesid", storesid, DbType.Int32), db.CreateParameter("@UserID", UserID, DbType.Int32));
            db.Dispose();
            List<Model.customer.UserConsumption> ucList = new List<Model.customer.UserConsumption>();
            foreach (DataRow dr in dt.Rows)
            {
                ucList.Add(DataRow2Model(dr));
            }
            dt.Dispose();
            return ucList;
        }
        /// <summary>
        /// 读取(高
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Model.customer.UserConsumption> Read_List_UserIdOnheight(string storesid, string UserId)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[appointmentid]
      ,[userid]
      ,[CommodityID]
      ,[price]
      ,[addtime]
      ,[timenum]
      ,[swimteacherid]
      ,[mamasid]
      ,[monthage]
      ,[height]
      ,[weight]
      ,[temperature]
      ,[satisfactionid]
      ,[satisfactionuserid]
      ,[content]
      ,[status]
      ,[updatetime]
      ,[statuscontent]
      ,[Consumptiontype]
      ,[IsCash]
  FROM [customer_UserConsumption] Where [storesid]=@storesid and [UserId]=@UserId and [height]>0 order by [monthage] asc", db.CreateParameter("@storesid", storesid, DbType.Int32), db.CreateParameter("@UserId", UserId, DbType.Int32));
            db.Dispose();
            List<Model.customer.UserConsumption> ucList = new List<Model.customer.UserConsumption>();
            foreach(DataRow dr in dt.Rows)
            {
                ucList.Add(DataRow2Model(dr));
            }
            dt.Dispose();
            return ucList;
        }
        /// <summary>
        /// 读取（体重
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Model.customer.UserConsumption> Read_List_UserIdOnweight(string storesid, string UserId)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[appointmentid]
      ,[userid]
      ,[CommodityID]
      ,[price]
      ,[addtime]
      ,[timenum]
      ,[swimteacherid]
      ,[mamasid]
      ,[monthage]
      ,[height]
      ,[weight]
      ,[temperature]
      ,[satisfactionid]
      ,[satisfactionuserid]
      ,[content]
      ,[status]
      ,[updatetime]
      ,[statuscontent]
      ,[Consumptiontype]
      ,[IsCash]
  FROM [customer_UserConsumption] Where [storesid]=@storesid and [UserId]=@UserId and [weight]>0 order by [monthage] asc", db.CreateParameter("@storesid", storesid, DbType.Int32), db.CreateParameter("@UserId", UserId, DbType.Int32));
            db.Dispose();
            List<Model.customer.UserConsumption> ucList = new List<Model.customer.UserConsumption>();
            foreach(DataRow dr in dt.Rows)
            {
                ucList.Add(DataRow2Model(dr));
            }
            dt.Dispose();
            return ucList;
        }
        /// <summary>
        /// 设置为取消
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <param name="statuscontent"></param>
        /// <returns></returns>
        public int Update_Cancel(string storesid, string id, string statuscontent)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@status",-1,DbType.Int32),
                               db.CreateParameter("@updatetime",DateTime.Now,DbType.DateTime),
                               db.CreateParameter("@statuscontent",statuscontent,DbType.String),
                               db.CreateParameter("@storesid",storesid,DbType.Int32),
                               db.CreateParameter("@id",id,DbType.Int32)
                               };
            int icout = db.GetRowCount(@"UPDATE [customer_UserConsumption]
   SET [status] = @status
      ,[updatetime]=@updatetime
      ,[statuscontent] = @statuscontent
 WHERE [storesid]=@storesid and [id]=@id", ps);
            db.Dispose();
            return icout;
        }
        /// <summary>
        /// 设置为取消
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <param name="statuscontent"></param>
        /// <returns></returns>
        public int Update_Price(string price, string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@price",price,DbType.Double),
                               db.CreateParameter("@id",id,DbType.Int32)
                               };
            int icout = db.GetRowCount(@"UPDATE [customer_UserConsumption] SET [price] = @price WHERE [id]=@id", ps);
            db.Dispose();
            return icout;
        }
        /// <summary>
        /// 修改满意度
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <param name="satisfactionid"></param>
        /// <returns></returns>
        public int Update_satisfactionid(string storesid, string id, string satisfactionid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@satisfactionid",satisfactionid,DbType.Int32),
                               db.CreateParameter("@storesid",storesid,DbType.Int32),
                               db.CreateParameter("@id",id,DbType.Int32)
                               };
            int icout = db.GetRowCount(@"UPDATE [customer_UserConsumption]
   SET [satisfactionid] = @satisfactionid
 WHERE [storesid]=@storesid and [id]=@id", ps);
            db.Dispose();
            return icout;
        }
        /// <summary>
        /// 修改满意度（用户）
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <param name="satisfactionid"></param>
        /// <returns></returns>
        public int Update_satisfactionidOnUser(string UserID, string id, string satisfactionid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@satisfactionid",satisfactionid,DbType.Int32),
                               db.CreateParameter("@satisfactionUserid",UserID,DbType.Int32),
                               db.CreateParameter("@id",id,DbType.Int32)
                               };
            int icout = db.GetRowCount(@"UPDATE [customer_UserConsumption]
   SET [satisfactionid] = @satisfactionid,[satisfactionUserid]=@satisfactionUserid
 WHERE [id]=@id", ps);
            db.Dispose();
            return icout;
        }
        /// <summary>
        /// 修改体重（用户）
        /// </summary>
        /// <param name="id"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public int Update_weight(string id, string weight)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@weight",weight,DbType.Double),
                               db.CreateParameter("@id",id,DbType.Int32)
                               };
            int icout = db.GetRowCount(@"UPDATE [customer_UserConsumption]
   SET [weight] = @weight
 WHERE [id]=@id", ps);
            db.Dispose();
            return icout;
        }
        /// <summary>
        /// 修改身高（用户）
        /// </summary>
        /// <param name="id"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public int Update_height(string id, string height)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@height",height,DbType.Double),
                               db.CreateParameter("@id",id,DbType.Int32)
                               };
            int icout = db.GetRowCount(@"UPDATE [customer_UserConsumption]
   SET [height] = @height
 WHERE [id]=@id", ps);
            db.Dispose();
            return icout;
        }
        /// <summary>
        /// 修改游戏时长（用户）
        /// </summary>
        /// <param name="id"></param>
        /// <param name="timenum"></param>
        /// <returns></returns>
        public int Update_timenum(string id, string timenum)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@timenum",timenum,DbType.Double),
                               db.CreateParameter("@id",id,DbType.Int32)
                               };
            int icout = db.GetRowCount(@"UPDATE [customer_UserConsumption]
   SET [timenum] = @timenum
 WHERE [id]=@id", ps);
            db.Dispose();
            return icout;
        }
        /// <summary>
        /// 读取用户消费
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Page"></param>
        /// <returns></returns>
        public DataTable ReadAppList(string UserID, string Page)
        {
            Base.Page.Dividepage page = new Base.Page.Dividepage();
            page.TableName = "[customer_UserConsumption] as a left join [Staff_member] as b on a.[swimteacherid]=b.[id]";
            page.OrderBy = "Order by a.[id] desc";
            page.Index = "a.[id]";
            page.Filter = "a.[userid]=" + UserID+" and a.[Status]=1";
            page.Field = "a.[id],a.[addtime],case when DATEDIFF(DAY,GETDATE(),[addtime])<-7 then '-1' else '1' end as ismodi,(a.[satisfactionid]+1) as satisfactionid,a.[satisfactionuserid],b.[name],b.[userface],(b.[membersatisfactionid]+1) as membersatisfactionid";
            page.PageSize = 10;
            DataTable dt = page.getrows();
            int maxpage = page.MaxPage;
            if (int.Parse(Page) > maxpage)
            {
                return new DataTable();
            }
            else {
                return dt;
            }
        }
        /// <summary>
        /// 读取用户消费
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Page"></param>
        /// <returns></returns>
        public DataTable ReadAppListAtStores(string UserID, string Page)
        {
            Base.Page.Dividepage page = new Base.Page.Dividepage();
            page.TableName = "[customer_UserConsumption] as a left join [Staff_member] as b on a.[swimteacherid]=b.[id] left join [Sys_stores] as s on a.[storesid]=s.[storesid] left join [Staff_department] as d on b.[departmentid]=d.[id]";
            page.OrderBy = "Order by a.[id] desc";
            page.Index = "a.[id]";
            page.Filter = "a.[userid]=" + UserID + " and a.[Status]=1";
            page.Field = "a.[id],CONVERT(varchar,a.[addtime],120) as datetime,case when DATEDIFF(DAY,GETDATE(),[addtime])<-7 then '-1' else '1' end as ismodi,b.[name],b.[userface],s.[title] as storesname,d.[title] as department";
            page.PageSize = 10;
            DataTable dt = page.getrows();
            int maxpage = page.MaxPage;
            if (int.Parse(Page) > maxpage)
            {
                return new DataTable();
            }
            else
            {
                return dt;
            }
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="storesid">门店ID</param>
        /// <param name="cardNo">卡号</param>
        /// <param name="CommodityID">商品ID</param>
        /// <param name="swimteacherid">游泳老师ID</param>
        /// <param name="name">姓名</param>
        /// <param name="satisfactionid">满意度</param>
        /// <param name="statustime">开始时间</param>
        /// <param name="endtime">结束时间</param>
        /// <returns></returns>
        public string View(int PageSize, string storesid, string userid, string cardNo, string CommodityID, string swimteacherid, string name, string satisfactionid, string statustime, string endtime)
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
                page.TableName = "[customer_UserConsumption] as a inner join [customer_User] as b on a.[userid]=b.[userid] left join [Sys_Stores] as s on b.[storesid]=s.[storesid] left join [customer_Card] as c on b.[cardid]=c.[cardid] left join [customer_CardType] as d on c.[cardtypeid]=d.[id] left join [Staff_member] as e on a.[swimteacherid]=e.[id] left join [Sys_mamas] as f on a.[mamasid]=f.[id] left join [Sys_Commodity] as g on a.[CommodityID]=g.[id]";
                page.OrderBy = "order by a.[id] desc";
                page.Index = "a.[id]";
                page.Field = "a.[id],c.[cardNo],d.[title] as cardtype,b.[storesid],s.[title],b.[name],b.[nickname],a.[monthage],a.[price],a.[IsCash],a.[addtime],c.[surplusnum],a.[Consumptiontype],g.[title] as CommodityName,e.[name] as swimteachername,a.[satisfactionid],a.[weight],a.[height],a.[temperature],f.[title] as mamasname,a.[timenum],b.[IsMeasure],b.[IsPhoto],a.[content],b.[mobile]";
                List<string> Filter = new List<string>();
                Filter.Add("a.[status]=1 and a.[storesid]=" + storesid);
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
                if (Base.Fun.fun.pnumeric(CommodityID))
                {
                    Filter.Add("a.[CommodityID]=" + CommodityID);
                }
                if (Base.Fun.fun.IsNumeric(swimteacherid))
                {
                    Filter.Add("a.[swimteacherid]=" + swimteacherid);
                }
                if (name.Length > 0)
                {
                    Filter.Add("(b.[name] like '%" + name + "%' or b.[nickname] like '%" + name + "%')");
                }
                if (Base.Fun.fun.IsNumeric(satisfactionid))
                {
                    Filter.Add("a.[satisfactionid]=" + satisfactionid);
                }

                if (Base.Fun.fun.IsDate(statustime))
                {
                    Filter.Add("datediff(day,a.[addtime],'" + statustime + "')<=0");
                }
                if (Base.Fun.fun.IsDate(endtime))
                {
                    Filter.Add("datediff(day,a.[addtime],'" + endtime + "')>=0");
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
        /// 显示
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="storesid">门店ID</param>
        /// <param name="cardNo">卡号</param>
        /// <param name="CommodityID">商品ID</param>
        /// <param name="swimteacherid">游泳老师ID</param>
        /// <param name="name">姓名</param>
        /// <param name="satisfactionid">满意度</param>
        /// <param name="statustime">开始时间</param>
        /// <param name="endtime">结束时间</param>
        /// <returns></returns>
        public string View_Cancel(int PageSize, string storesid, string cardNo, string CommodityID, string swimteacherid, string name, string satisfactionid, string statustime, string endtime, string cancelstatustime, string cancelendtime)
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
                page.TableName = "[customer_UserConsumption] as a inner join [customer_User] as b on a.[userid]=b.[userid] left join [customer_Card] as c on b.[cardid]=c.[cardid] left join [customer_CardType] as d on c.[cardtypeid]=d.[id] left join [Staff_member] as e on a.[swimteacherid]=e.[id] left join [Sys_mamas] as f on a.[mamasid]=f.[id] left join [Sys_Commodity] as g on a.[CommodityID]=g.[id]";
                page.OrderBy = "order by a.[id] desc";
                page.Index = "a.[id]";
                page.Field = "a.[id],c.[cardNo],d.[title] as cardtype,b.[name],b.[nickname],a.[monthage],a.[price],a.[IsCash],a.[addtime],a.[updatetime],c.[surplusnum],a.[Consumptiontype],g.[title] as CommodityName,e.[name] as swimteachername,a.[satisfactionid],a.[weight],a.[height],a.[temperature],f.[title] as mamasname,a.[timenum],b.[IsMeasure],b.[IsPhoto],a.[content],a.[statuscontent]";
                List<string> Filter = new List<string>();
                Filter.Add("a.[status]=-1");
                Filter.Add("b.[storesid]=" + storesid);
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
                if (Base.Fun.fun.pnumeric(CommodityID))
                {
                    Filter.Add("a.[CommodityID]=" + CommodityID);
                }
                if (Base.Fun.fun.pnumeric(swimteacherid))
                {
                    Filter.Add("a.[swimteacherid]=" + swimteacherid);
                }
                if (name.Length > 0)
                {
                    Filter.Add("b.[name] like '%" + name + "%'");
                }
                if (Base.Fun.fun.pnumeric(satisfactionid))
                {
                    Filter.Add("a.[satisfactionid]=" + satisfactionid);
                }
                if (Base.Fun.fun.IsDate(statustime))
                {
                    Filter.Add("a.[datetime]>='" + statustime+"'");
                }
                if (Base.Fun.fun.IsDate(endtime))
                {
                    Filter.Add("a.[datetime]<='" + endtime+"'");
                }
                if (Base.Fun.fun.IsDate(cancelstatustime))
                {
                    Filter.Add("a.[updatetime]>='" + statustime+"'");
                }
                if (Base.Fun.fun.IsDate(cancelendtime))
                {
                    Filter.Add("a.[updatetime]<='" + cancelendtime+"'");
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
        /// 读取(按部门读取
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Model.customer.UserConsumption> ReadList_department(string departmentid, string statustime, string endtime)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT a.[id]
      ,a.[storesid]
      ,a.[appointmentid]
      ,a.[userid]
      ,a.[CommodityID]
      ,a.[price]
      ,a.[addtime]
      ,a.[timenum]
      ,a.[swimteacherid]
      ,a.[mamasid]
      ,a.[monthage]
      ,a.[height]
      ,a.[weight]
      ,a.[temperature]
      ,a.[satisfactionid]
      ,a.[satisfactionuserid]
      ,a.[content]
      ,a.[status]
      ,a.[updatetime]
      ,a.[statuscontent]
      ,a.[Consumptiontype]
      ,a.[IsCash]
  FROM [customer_UserConsumption] as a inner join [Staff_member] as b on a.[swimteacherid]=b.[id] Where a.[status]=1 and b.[departmentid]=" + departmentid + (Base.Fun.fun.IsDate(statustime) ? " and [addtime]>='" + statustime + "'" : "") + (Base.Fun.fun.IsDate(endtime) ? " and [addtime]<='" + endtime + "'" : ""));
            db.Dispose();
            List<Model.customer.UserConsumption> ucList = new List<Model.customer.UserConsumption>();
            foreach (DataRow dr in dt.Rows)
            {
                ucList.Add(DataRow2Model(dr));
            }
            dt.Dispose();
            return ucList;
        }

        /// <summary>
        /// 读取(按员工读取
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Model.customer.UserConsumption> ReadList_member(string memberid, string statustime, string endtime)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT a.[id]
      ,a.[storesid]
      ,a.[appointmentid]
      ,a.[userid]
      ,a.[CommodityID]
      ,a.[price]
      ,a.[addtime]
      ,a.[timenum]
      ,a.[swimteacherid]
      ,a.[mamasid]
      ,a.[monthage]
      ,a.[height]
      ,a.[weight]
      ,a.[temperature]
      ,a.[satisfactionid]
      ,a.[satisfactionuserid]
      ,a.[content]
      ,a.[status]
      ,a.[updatetime]
      ,a.[statuscontent]
      ,a.[Consumptiontype]
      ,a.[IsCash]
  FROM [customer_UserConsumption] as a Where a.[swimteacherid]=" + memberid + " and a.[status]=1 " + (Base.Fun.fun.IsDate(statustime) ? " and [addtime]>='" + statustime + "'" : "") + (Base.Fun.fun.IsDate(endtime) ? " and [addtime]<='" + endtime + "'" : ""));
            db.Dispose();
            List<Model.customer.UserConsumption> ucList = new List<Model.customer.UserConsumption>();
            foreach (DataRow dr in dt.Rows)
            {
                ucList.Add(DataRow2Model(dr));
            }
            dt.Dispose();
            return ucList;
        }

        /// <summary>
        /// 读取(按员工读取
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public string ReadList_member(string memberid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT count([id])
      ,sum([satisfactionid])
  FROM [customer_UserConsumption] Where [swimteacherid]=" + memberid + " and [status]=1");
            db.Dispose();
            string membersatisfactionid = "0";
            if (dt.Rows.Count > 0)
            {
                if (Base.Fun.fun.pnumeric(dt.Rows[0][1].ToString()) && Base.Fun.fun.pnumeric(dt.Rows[0][0].ToString()))
                {
                    membersatisfactionid = Math.Ceiling(double.Parse(dt.Rows[0][1].ToString()) / double.Parse(dt.Rows[0][0].ToString())).ToString();
                }
            }
            dt.Dispose();
            return membersatisfactionid;
        }
        /// <summary>
        /// 读取条件范围内的所有消费
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Model.customer.UserConsumption> ReadList_CommodityID(string storesid, string statustime, string endtime, string source)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT a.[id]
      ,a.[storesid]
      ,a.[appointmentid]
      ,a.[userid]
      ,a.[CommodityID]
      ,a.[price]
      ,a.[addtime]
      ,a.[timenum]
      ,a.[swimteacherid]
      ,a.[mamasid]
      ,a.[monthage]
      ,a.[height]
      ,a.[weight]
      ,a.[temperature]
      ,a.[satisfactionid]
      ,a.[satisfactionuserid]
      ,a.[content]
      ,a.[status]
      ,a.[updatetime]
      ,a.[statuscontent]
      ,a.[Consumptiontype]
      ,a.[IsCash]
  FROM [customer_UserConsumption] as a Inner Join [customer_User] as b on a.[userid]=b.[userid] Where a.[storesid]=" + storesid + " and a.[status]=1 " + (Base.Fun.fun.IsDate(statustime) ? " and datediff(day,a.[addtime],'" + statustime + "')<=0" : "") + (Base.Fun.fun.IsDate(endtime) ? " and datediff(day,a.[addtime],'" + endtime + "')>=0" : "") + (Base.Fun.fun.IsNumeric(source) ? " and b.[source]=" + source : ""));
            db.Dispose();
            List<Model.customer.UserConsumption> ucList = new List<Model.customer.UserConsumption>();
            foreach (DataRow dr in dt.Rows)
            {
                ucList.Add(DataRow2Model(dr));
            }
            dt.Dispose();
            return ucList;
        }
        /// <summary>
        /// 读取条件范围内的所有消费（有卡的）
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Model.customer.UserConsumption> ReadList_Card(string storesid, string statustime, string endtime, string source)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT a.[id]
      ,a.[storesid]
      ,a.[appointmentid]
      ,a.[userid]
      ,a.[CommodityID]
      ,a.[price]
      ,a.[addtime]
      ,a.[timenum]
      ,a.[swimteacherid]
      ,a.[mamasid]
      ,a.[monthage]
      ,a.[height]
      ,a.[weight]
      ,a.[temperature]
      ,a.[satisfactionid]
      ,a.[satisfactionuserid]
      ,a.[content]
      ,a.[status]
      ,a.[updatetime]
      ,a.[statuscontent]
      ,a.[Consumptiontype]
      ,a.[IsCash],c.[cardtypeid]
  FROM [customer_UserConsumption] as a Inner Join [customer_User] as b on a.[userid]=b.[userid] inner join [customer_Card] as c on b.[CardID]=c.[cardid] Where a.[storesid]=" + storesid + " and a.[status]=1 " + (Base.Fun.fun.IsDate(statustime) ? " and Datediff(DAY,'" + statustime + "',a.[addtime])>=0" : "") + (Base.Fun.fun.IsDate(endtime) ? " and Datediff(DAY,'" + endtime + "',a.[addtime])<=0" : "") + (Base.Fun.fun.IsNumeric(source) ? " and b.[source]=" + source : ""));
            db.Dispose();
            List<Model.customer.UserConsumption> ucList = new List<Model.customer.UserConsumption>();
            foreach (DataRow dr in dt.Rows)
            {
                Model.customer.UserConsumption ucModel = DataRow2Model(dr);
                ucModel._CardTypeID = dr["cardtypeid"].ToString();
                ucList.Add(ucModel);
            }
            dt.Dispose();
            return ucList;
        }
        /// <summary>
        /// 读取条件范围内的所有消费
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Model.customer.UserConsumption> ReadList_XiaoFei(string storesid, string statustime, string endtime, string cardNo)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT a.[id]
      ,a.[storesid]
      ,a.[appointmentid]
      ,a.[userid]
      ,a.[CommodityID]
      ,a.[price]
      ,a.[addtime]
      ,a.[timenum]
      ,a.[swimteacherid]
      ,a.[mamasid]
      ,a.[monthage]
      ,a.[height]
      ,a.[weight]
      ,a.[temperature]
      ,a.[satisfactionid]
      ,a.[satisfactionuserid]
      ,a.[content]
      ,a.[status]
      ,a.[updatetime]
      ,a.[statuscontent]
      ,a.[Consumptiontype]
      ,a.[IsCash]
  FROM [customer_UserConsumption] as a Inner Join [customer_User] as b on a.[userid]=b.[userid]" + (cardNo.Length > 0 ? " Inner join [customer_Card] as c on b.[CardID]=c.[CardID]" : "") + " Where a.[storesid]=" + storesid + " and a.[status]=1 " + (Base.Fun.fun.IsDate(statustime) ? " and Datediff(DAY,'" + statustime + "',a.[addtime])>=0" : "") + (Base.Fun.fun.IsDate(endtime) ? " and Datediff(DAY,'" + endtime + "',a.[addtime])<=0" : "") + (cardNo.Length > 0 ? (cardNo.Length >= 10 ? " and c.[cardNumber]='" + Base.Fun.fun.NoCon(cardNo) + "'" : " and c.[cardNo]='" + Base.Fun.fun.NoCon(cardNo) + "'") : ""));
            db.Dispose();
            List<Model.customer.UserConsumption> ucList = new List<Model.customer.UserConsumption>();
            foreach (DataRow dr in dt.Rows)
            {
                ucList.Add(DataRow2Model(dr));
            }
            dt.Dispose();
            return ucList;
        }

        /// <summary>
        /// 读取条件范围内的所有消费（小区）
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Model.customer.UserConsumption> ReadList_CommunityID(string storesid, string statustime, string endtime, string communityid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT a.[id]
      ,a.[storesid]
      ,a.[appointmentid]
      ,a.[userid]
      ,a.[CommodityID]
      ,a.[price]
      ,a.[addtime]
      ,a.[timenum]
      ,a.[swimteacherid]
      ,a.[mamasid]
      ,a.[monthage]
      ,a.[height]
      ,a.[weight]
      ,a.[temperature]
      ,a.[satisfactionid]
      ,a.[satisfactionuserid]
      ,a.[content]
      ,a.[status]
      ,a.[updatetime]
      ,a.[statuscontent]
      ,a.[Consumptiontype]
      ,a.[IsCash],b.[CommunityID]
  FROM [customer_UserConsumption] as a Inner Join [customer_User] as b on a.[userid]=b.[userid]" + (Base.Fun.fun.pnumeric(communityid) ? " inner join [Sys_community] as c on b.[communityid]=c.[id]" : "") + " Where a.[storesid]=" + storesid + " and a.[status]=1 " + (Base.Fun.fun.IsDate(statustime) ? " and Datediff(DAY,'" + statustime + "',a.[addtime])>=0" : "") + (Base.Fun.fun.IsDate(endtime) ? " and Datediff(DAY,'" + endtime + "',a.[addtime])<=0" : "") + (Base.Fun.fun.pnumeric(communityid) ? " and c.[id]=" + communityid : ""));
            db.Dispose();
            List<Model.customer.UserConsumption> ucList = new List<Model.customer.UserConsumption>();
            foreach (DataRow dr in dt.Rows)
            {
                ucList.Add(DataRow2Model(dr));
                ucList[ucList.Count - 1]._CommunityID = dr["CommunityID"].ToString();
            }
            dt.Dispose();
            return ucList;
        }
        /// <summary>
        /// 读取提成满意度
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="Memberid"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public double ReadMemberPrice(string storesid, string Memberid, string time)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string price = Base.Fun.fun.IsZero(db.GetValue("SELECT SUM(b.[price]) FROM [customer_UserConsumption] as a inner join [Staff_position_Setup] as b on a.[satisfactionid]=b.[satisfactionid] and b.[storesid]=@storesid where a.[swimteacherid]=@Memberid and datediff(month,[addtime],@time)=0", db.CreateParameter("@storesid", storesid, DbType.Int32), db.CreateParameter("@Memberid", Memberid, DbType.Int32), db.CreateParameter("@time", time, DbType.DateTime)).ToString());
            db.Dispose();
            return double.Parse(price);
        }

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private Model.customer.UserConsumption DataRow2Model(DataRow dr)
        {
            Model.customer.UserConsumption ucModel = new Model.customer.UserConsumption();
            ucModel.id = dr["id"].ToString();
            ucModel.storesid = dr["storesid"].ToString();
            ucModel.appointmentid = dr["appointmentid"].ToString();
            ucModel.userid = dr["userid"].ToString();
            ucModel.CommodityID = dr["CommodityID"].ToString();
            ucModel.price = dr["price"].ToString();
            ucModel.addtime = dr["addtime"].ToString();
            ucModel.timenum = dr["timenum"].ToString();
            ucModel.swimteacherid = dr["swimteacherid"].ToString();
            ucModel.mamasid = dr["mamasid"].ToString();
            ucModel.monthage = dr["monthage"].ToString();
            ucModel.height = dr["height"].ToString();
            ucModel.weight = dr["weight"].ToString();
            ucModel.temperature = dr["temperature"].ToString();
            ucModel.satisfactionid = dr["satisfactionid"].ToString();
            ucModel.satisfactionuserid = dr["satisfactionuserid"].ToString();
            ucModel.content = dr["content"].ToString();
            ucModel.status = dr["status"].ToString();
            ucModel.updatetime = dr["updatetime"].ToString();
            ucModel.statuscontent = dr["statuscontent"].ToString();
            ucModel.Consumptiontype = dr["Consumptiontype"].ToString();
            ucModel.IsCash = dr["IsCash"].ToString();
            return ucModel;
        }
    }
}