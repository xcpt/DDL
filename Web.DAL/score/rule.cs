using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.score
{
    /// <summary>
    /// 积分规则
    /// </summary>
    public class rule
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="rModel"></param>
        /// <returns></returns>
        public string Insert(Model.score.rule rModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",rModel.storesid,DbType.Int32),
                               db.CreateParameter("@title",rModel.title,DbType.String),
                               db.CreateParameter("@starttime",rModel.starttime,DbType.DateTime),
                               db.CreateParameter("@endtime",rModel.endtime,DbType.DateTime),
                               db.CreateParameter("@coefficient",rModel.coefficient,DbType.Double),
                               db.CreateParameter("@addtime",DateTime.Now,DbType.DateTime)
                               };
            string id = db.GetNewID(@"INSERT INTO [score_rule]
           ([storesid]
           ,[title]
           ,[starttime]
           ,[endtime]
           ,[coefficient]
           ,[addtime])
     VALUES
           (@storesid
           ,@title
           ,@starttime
           ,@endtime
           ,@coefficient
           ,@addtime)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="rModel"></param>
        /// <returns></returns>
        public int Update(Model.score.rule rModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@title",rModel.title,DbType.String),
                               db.CreateParameter("@starttime",rModel.starttime,DbType.DateTime),
                               db.CreateParameter("@endtime",rModel.endtime,DbType.DateTime),
                               db.CreateParameter("@coefficient",rModel.coefficient,DbType.Double),
                               db.CreateParameter("@addtime",DateTime.Now,DbType.DateTime),
                               db.CreateParameter("@storesid",rModel.storesid,DbType.Int32),
                               db.CreateParameter("@id",rModel.id,DbType.Int32)
                               };
            int icount = db.GetRowCount(@"UPDATE [score_rule]
   SET [title] = @title
      ,[starttime] = @starttime
      ,[endtime] = @endtime
      ,[coefficient]=@coefficient
      ,[addtime] = @addtime
 WHERE [storesid] = @storesid and [id]=@id", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(string storesid, string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            int icount = db.GetRowCount(@"DELETE FROM [score_rule] WHERE [storesid]=@storesid and [id]=@id", db.CreateParameter("@storesid", storesid, DbType.Int32), db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 读取单条
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.score.rule Read(string storesid, string id)
        {
            Model.score.rule rModel = new Model.score.rule();
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[title]
      ,[starttime]
      ,[endtime]
      ,[coefficient]
      ,[addtime]
  FROM [score_rule] Where [storesid]=@storesid and [id]=@id", db.CreateParameter("@storesid", storesid, DbType.Int32), db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            if (dt.Rows.Count > 0)
            {
                rModel.id = dt.Rows[0]["id"].ToString();
                rModel.storesid = dt.Rows[0]["storesid"].ToString();
                rModel.title = dt.Rows[0]["title"].ToString();
                rModel.starttime = dt.Rows[0]["starttime"].ToString();
                rModel.endtime = dt.Rows[0]["endtime"].ToString();
                rModel.coefficient = dt.Rows[0]["coefficient"].ToString();
                rModel.addtime = dt.Rows[0]["addtime"].ToString();
            }
            dt.Dispose();
            return rModel;
        }
        /// <summary>
        /// 读取当前可用的规则的系数
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.score.rule ReadOnNow(string storesid)
        {
            Model.score.rule rModel = new Model.score.rule();
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[title]
      ,[starttime]
      ,[endtime]
      ,[coefficient]
      ,[addtime] FROM [score_rule] Where [storesid]=@storesid and datediff(d,GETDATE(),[starttime])<=0 and datediff(d,GETDATE(),[endtime])>=0 order by [id] desc", db.CreateParameter("@storesid", storesid, DbType.Int32));
            db.Dispose();
            if (dt.Rows.Count > 0)
            {
                rModel.id = dt.Rows[0]["id"].ToString();
                rModel.storesid = dt.Rows[0]["storesid"].ToString();
                rModel.title = dt.Rows[0]["title"].ToString();
                rModel.starttime = dt.Rows[0]["starttime"].ToString();
                rModel.endtime = dt.Rows[0]["endtime"].ToString();
                rModel.coefficient = dt.Rows[0]["coefficient"].ToString();
                rModel.addtime = dt.Rows[0]["addtime"].ToString();
            }
            dt.Dispose();
            return rModel;
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="storesid">门店ID</param>
        /// <param name="title">标题</param>
        /// <param name="starttime">开始时间</param>
        /// <param name="endtime">结束时间</param>
        /// <returns></returns>
        public string View(int PageSize, string storesid, string title, string starttime, string endtime)
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
                page.TableName = "[score_rule]";
                page.OrderBy = "order by [id] desc";
                page.Index = "[id]";
                page.Field = "[id],[title],[coefficient],[starttime],[endtime],[addtime]";
                List<string> Filter = new List<string>();
                Filter.Add("[storesid]=" + storesid);
                if (title.Length > 0)
                {
                    Filter.Add("[title] like '%" + title + "%'");
                }
                if (Base.Fun.fun.IsDate(starttime))
                {
                    Filter.Add("[starttime]<=" + starttime);
                }
                if (Base.Fun.fun.IsDate(endtime))
                {
                    Filter.Add("[endtime]<=" + endtime);
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
