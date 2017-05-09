using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.customer
{
    /// <summary>
    /// 修改满意度
    /// </summary>
    public class UserConsumptionSatisfaction
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="ucsModel"></param>
        /// <returns></returns>
        public string Insert(Model.customer.UserConsumptionSatisfaction ucsModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@UserConsumptionID",ucsModel.UserConsumptionID,DbType.Int32),
                               db.CreateParameter("@oldsatisfactionid",ucsModel.oldsatisfactionid,DbType.String),
                               db.CreateParameter("@satisfactionid",ucsModel.satisfactionid,DbType.String),
                               db.CreateParameter("@content",ucsModel.content,DbType.String),
                               db.CreateParameter("@administratorid",ucsModel.administratorid,DbType.Int32),
                               db.CreateParameter("@addtime",Base.Fun.fun.IsDate(ucsModel.addtime)?ucsModel.addtime:DateTime.Now.ToString(),DbType.DateTime),
                               db.CreateParameter("@num",ucsModel.num,DbType.Int32),
                               db.CreateParameter("@type",ucsModel.type,DbType.Int32)
                               };
            string id = db.GetNewID(@"INSERT INTO [customer_UserConsumptionSatisfaction]
           ([UserConsumptionID]
           ,[oldsatisfactionid]
           ,[satisfactionid]
           ,[content]
           ,[administratorid]
           ,[addtime]
           ,[num]
           ,[type])
     VALUES
           (@UserConsumptionID
           ,@oldsatisfactionid
           ,@satisfactionid
           ,@content
           ,@administratorid
           ,@addtime
           ,@num
           ,@type)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 获得数量
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string View_Num(string storesid, string userid, string UserConsumptionID)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            int icount = int.Parse(Base.Fun.fun.IsZero(db.GetValue("Select count(a.[id]) From [customer_UserConsumptionSatisfaction] as a inner join [customer_UserConsumption] as b on a.[UserConsumptionID]=b.[id] Where b.[storesid]=@storesid and b.[userid]=@userid and a.[UserConsumptionID]=@UserConsumptionID", db.CreateParameter("@storesid", storesid, DbType.Int32), db.CreateParameter("@userid", userid, DbType.Int32), db.CreateParameter("@UserConsumptionID", UserConsumptionID, DbType.Int32)).ToString()));
            db.Dispose();
            return (icount + 1).ToString();
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="storesid">门店ID</param>
        /// <param name="cardNo">卡号</param>
        /// <param name="name">姓名</param>
        /// <param name="administratorid">操作人（员工ID）</param>
        /// <param name="statustime">消费时间</param>
        /// <param name="endtime">消费时间</param>
        /// <param name="adminstatustime">操作时间</param>
        /// <param name="adminendtime">操作时间</param>
        /// <returns></returns>
        public string View(int PageSize, string storesid, string ucid, string cardNo, string name, string administratorid, string statustime, string endtime, string adminstatustime, string adminendtime)
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
                page.TableName = "[customer_UserConsumptionSatisfaction] as z inner join [customer_UserConsumption] as a on z.[UserConsumptionID]=a.[id] inner join [customer_User] as b on a.[userid]=b.[userid] left join [customer_Card] as c on b.[cardid]=c.[cardid] left join [customer_CardType] as d on c.[cardtypeid]=d.[id] left join [Staff_member] as e on a.[swimteacherid]=e.[id] left join [Sys_mamas] as f on a.[mamasid]=f.[id] left join [Sys_Commodity] as g on a.[CommodityID]=g.[id] left join [Users] as y on z.[administratorid]=y.[userid]";
                page.OrderBy = "order by z.[id] desc";
                page.Index = "z.[id]";
                page.Field = "z.[id],z.[UserConsumptionID],c.[cardNo],b.[name],a.[price],a.[addtime],g.[title] as CommodityName,e.[name] as swimteachername,z.[type],y.[username] as adminName,z.[num],z.[addtime],z.[oldsatisfactionid],z.[satisfactionid],z.[content]";
                List<string> Filter = new List<string>();
                if (Base.Fun.fun.pnumeric(ucid))
                {
                    Filter.Add("z.[UserConsumptionID]="+ucid);
                }
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
                if (Base.Fun.fun.pnumeric(administratorid))
                {
                    Filter.Add("a.[administratorid]=" + administratorid);
                }
                if (name.Length > 0)
                {
                    Filter.Add("b.[name] like '%" + name + "%'");
                }

                if (Base.Fun.fun.IsDate(statustime))
                {
                    Filter.Add("datediff(day,a.[addtime],'" + statustime + "')<=0");
                }
                if (Base.Fun.fun.IsDate(endtime))
                {
                    Filter.Add("datediff(day,a.[addtime],'" + endtime + "')>=0");
                }

                if (Base.Fun.fun.IsDate(adminstatustime))
                {
                    Filter.Add("datediff(day,z.[addtime],'" + adminstatustime + "')<=0");
                }
                if (Base.Fun.fun.IsDate(adminendtime))
                {
                    Filter.Add("datediff(day,z.[addtime],'" + adminendtime + "')>=0");
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
