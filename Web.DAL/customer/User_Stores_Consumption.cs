using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.customer
{
    /// <summary>
    /// 跨店消费
    /// </summary>
    public class User_Stores_Consumption
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="uscModel"></param>
        /// <returns></returns>
        public string Insert(Model.customer.User_Stores_Consumption uscModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@userid",uscModel.userid,DbType.Int32),
                               db.CreateParameter("@cardstoresid",uscModel.cardstoresid,DbType.Int32),
                               db.CreateParameter("@consumptionstoresid",uscModel.consumptionstoresid,DbType.Int32),
                               db.CreateParameter("@price",uscModel.price,DbType.Double),
                               db.CreateParameter("@addtime",Base.Fun.fun.IsDate(uscModel.addtime)?uscModel.addtime:DateTime.Now.ToString(),DbType.DateTime),
                               db.CreateParameter("@consumptionid",uscModel.consumptionid,DbType.Int32),
                               db.CreateParameter("@isclose",uscModel.isclose,DbType.Int32)
                               };
            string id = db.GetNewID(@"INSERT INTO [customer_User_Stores_Consumption]
           ([userid]
           ,[cardstoresid]
           ,[consumptionstoresid]
           ,[price]
           ,[addtime]
           ,[consumptionid]
           ,[isclose])
     VALUES
           (@userid
           ,@cardstoresid
           ,@consumptionstoresid
           ,@price
           ,@addtime
           ,@consumptionid
           ,@isclose)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 读取跨店消费
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="cardstoresid"></param>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public string View(int PageSize, string storesid, string userid, string cardNo, string CommodityID, string swimteacherid, string name, string satisfactionid, string constoresid, string statustime, string endtime)
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
                page.TableName = "[customer_User_Stores_Consumption] as z inner join [customer_UserConsumption] as a on z.[consumptionid]=a.[id] inner join [customer_User] as b on a.[userid]=b.[userid] left join [Sys_Stores] as s on z.[consumptionstoresid]=s.[storesid] left join [customer_Card] as c on b.[cardid]=c.[cardid] left join [customer_CardType] as d on c.[cardtypeid]=d.[id] left join [Staff_member] as e on a.[swimteacherid]=e.[id] left join [Sys_mamas] as f on a.[mamasid]=f.[id] left join [Sys_Commodity] as g on a.[CommodityID]=g.[id]";
                page.OrderBy = "order by z.[id] desc";
                page.Index = "z.[id]";
                page.Field = "a.[id],c.[cardNo],d.[title] as cardtype,z.[consumptionstoresid],s.[title],b.[name],b.[nickname],a.[monthage],a.[price],a.[IsCash],a.[addtime],c.[surplusnum],a.[Consumptiontype],g.[title] as CommodityName,e.[name] as swimteachername,a.[satisfactionid],a.[weight],a.[height],a.[temperature],f.[title] as mamasname,a.[timenum],b.[IsMeasure],b.[IsPhoto],a.[content],z.[isclose]";
                List<string> Filter = new List<string>();
                Filter.Add("z.[cardstoresid]=" + storesid + " and a.[status]=1");
                if (Base.Fun.fun.pnumeric(userid))
                {
                    Filter.Add("a.[userid]=" + userid);
                }
                if (Base.Fun.fun.pnumeric(constoresid))
                {
                    Filter.Add("z.[consumptionstoresid]=" + constoresid);
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
                if (Base.Fun.fun.pnumeric(satisfactionid))
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
                if (dt.Rows.Count > 0)
                {
                    Base.Conn.Database db = new Base.Conn.Database();
                    string sql = "Select sum(a.[price]) From [customer_User_Stores_Consumption] as z inner join [customer_UserConsumption] as a on z.[consumptionid]=a.[id] inner join [customer_User] as b on a.[userid]=b.[userid] left join [Sys_Stores] as s on z.[consumptionstoresid]=s.[storesid] left join [customer_Card] as c on b.[cardid]=c.[cardid] left join [customer_CardType] as d on c.[cardtypeid]=d.[id] left join [Staff_member] as e on a.[swimteacherid]=e.[id] left join [Sys_mamas] as f on a.[mamasid]=f.[id] left join [Sys_Commodity] as g on a.[CommodityID]=g.[id] Where " + page.Filter;
                    string price = db.GetValue(sql).ToString();
                    db.Dispose();
                    DataRow dr = dt.NewRow();
                    dr[5] = "<b>总计</b>";
                    dr[8] = price;
                    dt.Rows.Add(dr);
                }
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
        /// 结算某月费用
        /// </summary>
        /// <param name="cardstoresid"></param>
        /// <param name="datetime"></param>
        public int Update_IsClose(string cardstoresid, string datetime)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            int icount = db.GetRowCount("Update [customer_User_Stores_Consumption] set [isclose]=1 where [cardstoresid]=" + cardstoresid + " and datediff(m,[addtime],'" + datetime + "')=0");
            db.Dispose();
            return icount;
        }
    }
}
