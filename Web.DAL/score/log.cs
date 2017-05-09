using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.score
{
    /// <summary>
    /// 积分变更日志
    /// </summary>
    public class log
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="lModel"></param>
        /// <returns></returns>
        public string Insert(Model.score.log lModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",lModel.userid,DbType.Int32),
                               db.CreateParameter("@userid",lModel.userid,DbType.Int32),
                               db.CreateParameter("@rulenum",lModel.rulenum,DbType.Int32),
                               db.CreateParameter("@addtime",DateTime.Now,DbType.DateTime),
                               db.CreateParameter("@type",lModel.type,DbType.Int32),
                               db.CreateParameter("@content",lModel.content,DbType.String)
                               };
            string id = db.GetNewID(@"INSERT INTO [score_log]
           ([storesid]
           ,[userid]
           ,[rulenum]
           ,[addtime]
           ,[type]
           ,[content])
     VALUES
           (@storesid
           ,@userid
           ,@rulenum
           ,@addtime
           ,@type
           ,@content)", ps).ToString();
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
            int icount = db.GetRowCount("DELETE FROM [score_log] WHERE [id]=@id", db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 读取单条
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.score.log Read(string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"Select [id]
           ,[storesid]
           ,[userid]
           ,[rulenum]
           ,[addtime]
           ,[type]
           ,[content] From [score_log] Where [id]=@id", db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            Model.score.log lModel = new Model.score.log();
            if (dt.Rows.Count > 0)
            {
                lModel.id = dt.Rows[0]["id"].ToString();
                lModel.storesid = dt.Rows[0]["storesid"].ToString();
                lModel.userid = dt.Rows[0]["userid"].ToString();
                lModel.rulenum = dt.Rows[0]["rulenum"].ToString();
                lModel.addtime = dt.Rows[0]["addtime"].ToString();
                lModel.type = dt.Rows[0]["type"].ToString();
                lModel.content = dt.Rows[0]["content"].ToString();
            }
            dt.Dispose();
            return lModel;
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="storesid">门店ID</param>
        /// <returns></returns>
        public string View(int PageSize, string storesid, string name, string mobile, string type, string starttime, string endtime)
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
                page.TableName = "[score_log] as a inner join [customer_User] as b on a.[userid]=b.[userid]";
                page.OrderBy = "order by a.[id] desc";
                page.Index = "a.[id]";
                page.Field = "a.[id],b.[name],b.[mobile],a.[addtime],a.[type],a.[rulenum],a.[content]";
                List<string> Filter = new List<string>();
                Filter.Add("a.[storesid]=" + storesid);
                if (name.Length > 0)
                {
                    Filter.Add("b.[name] like '%" + name + "%'");
                }
                if (mobile.Length == 11 && Base.Fun.fun.pnumeric(mobile))
                {
                    Filter.Add("b.[mobile]='" + mobile + "'");
                }
                if (Base.Fun.fun.IsNumeric(type))
                {
                    Filter.Add("a.[type]=" + type);
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
