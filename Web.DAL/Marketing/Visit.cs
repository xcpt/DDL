using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.Marketing
{
    /// <summary>
    /// 回该
    /// </summary>
    public class Visit
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="vModel"></param>
        /// <returns></returns>
        public string Insert(Model.Marketing.Visit vModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@userid",vModel.userid,DbType.Int32),
                               db.CreateParameter("@addtime",DateTime.Now,DbType.DateTime),
                               db.CreateParameter("@memberid",vModel.memberid,DbType.Int32),
                               db.CreateParameter("@ReturnresultID",vModel.ReturnresultID,DbType.Int32),
                               db.CreateParameter("@IsGiveup",vModel.IsGiveup,DbType.Int32),
                               db.CreateParameter("@content",vModel.content,DbType.String),
                               db.CreateParameter("@num",vModel.num,DbType.Int32)
                               };
            string id = db.GetNewID(@"INSERT INTO [Marketing_Visit]
           ([userid]
           ,[addtime]
           ,[memberid]
           ,[ReturnresultID]
           ,[IsGiveup]
           ,[content]
           ,[num])
     VALUES
           (@userid
           ,@addtime
           ,@memberid
           ,@ReturnresultID
           ,@IsGiveup
           ,@content
           ,@num)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            int icount = db.GetRowCount(@"DELETE FROM [Marketing_Visit] WHERE [id]=@id", db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 读取几次回该 
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string ReadNum(string userid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            int count = int.Parse(Base.Fun.fun.IsZero(db.GetValue("Select Count([ID]) From [Marketing_Visit] Where [UserID]=@UserID", db.CreateParameter("@userid", userid, DbType.Int32)).ToString()));
            db.Dispose();
            return (count + 1).ToString();
        }
        /// <summary>
        /// 回访日志
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="storesid"></param>
        /// <param name="userid"></param>
        /// <param name="name">姓名</param>
        /// <param name="ReturnresultID">回访结果</param>
        /// <param name="IsGiveup">是否放弃</param>
        /// <param name="memberid">员工ID</param>
        /// <param name="starttime">回访开始时间</param>
        /// <param name="endtime">回访结束时间</param>
        /// <returns></returns>
        public string View(int PageSize, string storesid, string userid, string name, string ReturnresultID, string IsGiveup, string memberid, string starttime, string endtime)
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
                page.TableName = "[Marketing_Visit] as z inner join [customer_User] as a on z.[userid]=a.[userid] left join [Sys_community] as c on a.[communityid]=c.[id] left join [Staff_Member] as e on z.[memberid]=e.[id]";
                page.OrderBy = "order by z.[id] desc";
                page.Index = "z.[id]";
                page.Field = "z.[id],a.[name],a.[mobile],a.[sex]," + Model.Data.Basic.GetMonth("a.[birthday]") + ",c.[title] as communityname,a.[cycletype],z.[addtime],e.[name] as membername,z.[num],z.[ReturnresultID],z.[IsGiveup],z.[content]";
                List<string> Filter = new List<string>();
                Filter.Add("a.[storesid]=" + storesid);
                Filter.Add("a.[State]<>1");
                if (Base.Fun.fun.pnumeric(userid))
                {
                    Filter.Add("a.[userid]=" + userid);
                }
                if (name.Length > 0)
                {
                    Filter.Add("a.[name] like '%" + name + "%'");
                }
                if (Base.Fun.fun.pnumeric(memberid))
                {
                    Filter.Add("z.[memberid]=" + memberid);
                }
                if (Base.Fun.fun.IsDate(starttime))
                {
                    Filter.Add("datediff(day,'" + starttime + "',z.[addtime])>=0");
                }
                if (Base.Fun.fun.IsDate(endtime))
                {
                    Filter.Add("datediff(day,'" + endtime + "',z.[addtime])<=0");
                }
                if (Base.Fun.fun.IsNumeric(ReturnresultID))
                {
                    Filter.Add("z.[ReturnresultID]=" + ReturnresultID);
                }
                if (Base.Fun.fun.IsNumeric(IsGiveup))
                {
                    Filter.Add("z.[IsGiveup]=" + IsGiveup);
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
