using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.Sys
{
    public class Message
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="mModel"></param>
        /// <returns></returns>
        public string Insert(Model.Sys.Message mModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = {
                               db.CreateParameter("@userid",mModel.userid,DbType.Int32),
                               db.CreateParameter("@addtime",mModel.addtime,DbType.DateTime),
                               db.CreateParameter("@updatetime",Base.Fun.fun.IsDate(mModel.updatetime)?mModel.updatetime:null,DbType.DateTime),
                               db.CreateParameter("@content",mModel.content,DbType.String),
                               db.CreateParameter("@hfcontent",mModel.hfcontent,DbType.String),
                               db.CreateParameter("@state",mModel.state,DbType.Int32)
                               };
            string id = db.GetNewID(@"INSERT INTO [Sys_Message]
           ([userid]
           ,[addtime]
           ,[updatetime]
           ,[content]
           ,[hfcontent]
           ,[state])
     VALUES
           (@userid
           ,@addtime
           ,@updatetime
           ,@content
           ,@hfcontent
           ,@state)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 回复
        /// </summary>
        /// <param name="hfContent"></param>
        /// <returns></returns>
        public int Update(string hfContent, string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@hfcontent",hfContent,DbType.String),
                               db.CreateParameter("@state",1,DbType.Int32),
                               db.CreateParameter("@updatetime",DateTime.Now,DbType.DateTime),
                               db.CreateParameter("@id",id,DbType.Int32)
                               };
            int icount = db.GetRowCount("Update [Sys_Message] set [hfcontent]=@hfcontent,[state]=@state,[updatetime]=@updatetime Where [ID]=@id", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Sys.Message Read(string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[userid]
      ,[addtime]
      ,[updatetime]
      ,[content]
      ,[hfcontent]
      ,[state]
  FROM [Sys_Message] Where [id]=@id", db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            Model.Sys.Message mModel = new Model.Sys.Message();
            if (dt.Rows.Count > 0)
            {
                mModel.id = dt.Rows[0]["id"].ToString();
                mModel.userid = dt.Rows[0]["userid"].ToString();
                mModel.addtime = dt.Rows[0]["addtime"].ToString();
                mModel.updatetime = dt.Rows[0]["updatetime"].ToString();
                mModel.content = dt.Rows[0]["content"].ToString();
                mModel.hfcontent = dt.Rows[0]["hfcontent"].ToString();
                mModel.state = dt.Rows[0]["state"].ToString();
            }
            dt.Dispose();
            return mModel;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public DataTable Read_AppList(string UserID, string Page)
        {
            Base.Page.Dividepage page = new Base.Page.Dividepage();
            page.TableName = "[Sys_Message]";
            page.OrderBy = "order by [id] desc";
            page.Index = "[id]";
            page.Filter = "[userid]=" + UserID;
            page.Field = @"[id]
      ,[addtime]
      ,[updatetime]
      ,[content]
      ,[hfcontent]
      ,[state]";
            page.PageSize = 10;
            DataTable dt = page.getrows();
            int maxpage = page.MaxPage;
            page.Dispose();
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
        /// 所有
        /// </summary>
        /// <returns></returns>
        public string GetNowDay()
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string icount = db.GetValue("Select count([id]) From [Sys_Message] Where Datediff(day,[addtime],getdate())=0").ToString();
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public string View(int PageSize, string storesid, string name, string saddtime, string eaddtime, string supdatetime, string eupdatetime, string state)
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
                page.TableName = "[Sys_Message] as a inner join [customer_User] as b on a.[userid]=b.[userid] left join [customer_Card] as c on b.[CardID]=c.[CardID]";
                page.OrderBy = "order by a.[id] desc";
                page.Index = "a.[id]";
                page.Field = "a.[id],c.[CardNo],b.[name],b.[parentName],b.[mobile],a.[content],a.[addtime],a.[state],a.[updatetime]";
                List<string> Filter = new List<string>();
                Filter.Add("b.[storesid]=" + storesid);
                if (name.Length > 0)
                {
                    Filter.Add("b.[name] like '%" + name + "%'");
                }
                if (Base.Fun.fun.IsDate(saddtime))
                {
                    Filter.Add("datediff(day,a.[addtime],'" + saddtime + "')<=0");
                }
                if (Base.Fun.fun.IsDate(eaddtime))
                {
                    Filter.Add("datediff(day,a.[addtime],'" + eaddtime + "')>=0");
                }
                if (Base.Fun.fun.IsDate(supdatetime))
                {
                    Filter.Add("datediff(day,a.[updatetime],'" + supdatetime + "')<=0");
                }
                if (Base.Fun.fun.IsDate(eupdatetime))
                {
                    Filter.Add("datediff(day,a.[updatetime],'" + eupdatetime + "')>=0");
                }
                if (Base.Fun.fun.IsNumeric(state))
                {
                    Filter.Add("a.[state]=" + state);
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
