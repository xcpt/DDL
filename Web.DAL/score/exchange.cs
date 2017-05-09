using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.score
{
    /// <summary>
    /// 积分兑换
    /// </summary>
    public class exchange
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="eModel"></param>
        /// <returns></returns>
        public string Insert(Model.score.exchange eModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@userid",eModel.userid,DbType.Int32),
                               db.CreateParameter("@usertime",eModel.usertime,DbType.DateTime),
                               db.CreateParameter("@userrule",eModel.userrule,DbType.Int32),
                               db.CreateParameter("@content",eModel.content,DbType.String),
                               db.CreateParameter("@addtime",eModel.addtime,DbType.DateTime)
                               };
            string id = db.GetNewID(@"INSERT INTO [score_exchange]
           ([userid]
           ,[usertime]
           ,[userrule]
           ,[content]
           ,[addtime])
     VALUES
           (@userid
           ,@usertime
           ,@userrule
           ,@content
           ,@addtime)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.score.exchange Read(string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[userid]
      ,[usertime]
      ,[userrule]
      ,[content]
      ,[addtime]
  FROM [score_exchange] Where [id]=@id", db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            Model.score.exchange eModel = new Model.score.exchange();
            if (dt.Rows.Count > 0)
            {
                eModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return eModel;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            int icount = db.GetRowCount(@"DELETE FROM [score_exchange] WHERE [id]=@id", db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="storesid">门店ID</param>
        /// <returns></returns>
        public string View(int PageSize, string storesid, string userid, string name, string title, string starttime, string endtime)
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
                page.TableName = "[score_exchange] as a inner join [customer_User] as b on a.[userid]=b.[userid] left join [Sys_community] as c on b.[communityid]=c.[id]";
                page.OrderBy = "order by a.[id] desc";
                page.Index = "a.[id]";
                page.Field = "a.[id],b.[name],b.[nickname],b.[sex]," + Model.Data.Basic.GetMonth("b.[birthday]") + ",c.[title] as communityname,b.[cycletype],a.[usertime],a.[userrule],a.[content]";
                List<string> Filter = new List<string>();
                Filter.Add("b.[storesid]=" + storesid);
                if (Base.Fun.fun.pnumeric(userid))
                {
                    Filter.Add("a.[userid]=" + userid);
                }
                if (name.Length > 0)
                {
                    Filter.Add("b.[name] like '%" + name + "%'");
                }
                if (title.Length > 0)
                {
                    Filter.Add("a.[content] like '%" + title + "%'");
                }

                if (Base.Fun.fun.IsDate(starttime))
                {
                    Filter.Add("a.[usertime]>=" + starttime);
                }
                if (Base.Fun.fun.IsDate(endtime))
                {
                    Filter.Add("a.[usertime]<=" + endtime);
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
        private Model.score.exchange DataRow2Model(DataRow dr)
        {
            Model.score.exchange eModel = new Model.score.exchange();
            eModel.id = dr["id"].ToString();
            eModel.userid = dr["userid"].ToString();
            eModel.usertime = dr["usertime"].ToString();
            eModel.userrule = dr["userrule"].ToString();
            eModel.content = dr["content"].ToString();
            eModel.addtime = dr["addtime"].ToString();
            return eModel;
        }
    }
}
