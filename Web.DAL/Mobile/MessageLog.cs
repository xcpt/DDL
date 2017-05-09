using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.Mobile
{
    /// <summary>
    /// 发送日志
    /// </summary>
    public class MessageLog
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="mlModel"></param>
        /// <returns></returns>
        public string Insert(Model.Mobile.MessageLog mlModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",mlModel.storesid,DbType.Int32),
                               db.CreateParameter("@mobile",mlModel.mobile,DbType.String),
                               db.CreateParameter("@title",mlModel.title,DbType.String),
                               db.CreateParameter("@content",mlModel.content,DbType.String),
                               db.CreateParameter("@addtime",mlModel.addtime,DbType.DateTime),
                               db.CreateParameter("@sendtime",Base.Fun.fun.IsDate(mlModel.sendtime)?mlModel.sendtime:null,DbType.DateTime),
                               db.CreateParameter("@status",mlModel.status,DbType.Int32),
                               db.CreateParameter("@message",mlModel.message,DbType.String),
                               db.CreateParameter("@sendtype",mlModel.sendtype,DbType.Int32)
                               };
            string id = db.GetNewID(@"INSERT INTO [Mobile_MessageLog]
           ([storesid]
           ,[mobile]
           ,[title]
           ,[content]
           ,[addtime]
           ,[sendtime]
           ,[status]
           ,[message]
           ,[sendtype])
     VALUES
           (@storesid
           ,@mobile
           ,@title
           ,@content
           ,@addtime
           ,@sendtime
           ,@status
           ,@message
           ,@sendtype)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 读取单条未发送
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public Model.Mobile.MessageLog Read(string storesid, string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"Select [id]
           ,[storesid]
           ,[mobile]
           ,[title]
           ,[content]
           ,[addtime]
           ,[sendtime]
           ,[status]
           ,[message]
           ,[sendtype] From [Mobile_MessageLog] Where [storesid]=@storesid and [status]=0 and [id]=@id", db.CreateParameter("@storesid", storesid, DbType.Int32), db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
                Model.Mobile.MessageLog mlModel = new Model.Mobile.MessageLog();
            if(dt.Rows.Count>0)
            {
                mlModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return mlModel;
        }

        /// <summary>
        /// 读取可发送的短消息
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public List<Model.Mobile.MessageLog> ReadList()
        {
            List<Model.Mobile.MessageLog> mlList = new List<Model.Mobile.MessageLog>();
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"Select [id]
           ,[storesid]
           ,[mobile]
           ,[title]
           ,[content]
           ,[addtime]
           ,[sendtime]
           ,[status]
           ,[message]
           ,[sendtype] From [Mobile_MessageLog] Where [status]=0 and datediff(second,'" + DateTime.Now.ToString() + "',[sendtime])<=0 order by [id] asc");
            db.Dispose();
            foreach (DataRow dr in dt.Rows)
            {
                mlList.Add(DataRow2Model(dr));
            }
            dt.Dispose();
            return mlList;
        }
        /// <summary>
        /// 读取用户相关的发送记录
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public DataTable ReadList(string mobile, string Page)
        {
            Base.Page.Dividepage page = new Base.Page.Dividepage();
            page.TableName = "[Mobile_MessageLog]";
            page.OrderBy = "order by [id] desc";
            page.Index = "[id]";
            page.Filter = "[status]=1 and [sendtype]=1 and [mobile]='" + mobile + "'";
            page.Field = @"[title],[content],[addtime] as sendtime";
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
        /// 删除要发送的等待记录
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public void Delete(string mobile, string SendTime)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            db.ExeSql(@"delete From [Mobile_MessageLog] Where [status]=0 and [mobile]=@mobile and datediff(HOUR,[sendtime],'"+SendTime+"')=0", db.CreateParameter("@mobile", mobile, DbType.String));
            db.Dispose();
        }
        /// <summary>
        /// 判断要等待的生日存在不存在
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public string SelectID(string mobile, string SendTime)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string ID = db.GetValue(@"Select [id] From [Mobile_MessageLog] Where [status]<>-1 and [mobile]=@mobile and datediff(HOUR,[sendtime],'" + SendTime + "')=0", db.CreateParameter("@mobile", mobile, DbType.String)).ToString();
            db.Dispose();
            return ID;
        }
        /// <summary>
        /// 判断要等待的生日存在不存在
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public string SelectIDNoStatus(string mobile, string SendTime)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string ID = db.GetValue(@"Select top 1 [id] From [Mobile_MessageLog] Where [mobile]=@mobile and datediff(HOUR,[sendtime],'" + SendTime + "')=0", db.CreateParameter("@mobile", mobile, DbType.String)).ToString();
            db.Dispose();
            return ID;
        }
        /// <summary>
        /// 转码
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private Model.Mobile.MessageLog DataRow2Model(DataRow dr)
        {
            Model.Mobile.MessageLog mlModel = new Model.Mobile.MessageLog();
            mlModel.id = dr["id"].ToString();
            mlModel.storesid = dr["storesid"].ToString();
            mlModel.mobile = dr["mobile"].ToString();
            mlModel.title = dr["title"].ToString();
            mlModel.content = dr["content"].ToString();
            mlModel.addtime = dr["addtime"].ToString();
            mlModel.sendtime = dr["sendtime"].ToString();
            mlModel.status = dr["status"].ToString();
            mlModel.message = dr["message"].ToString();
            mlModel.sendtype = dr["sendtype"].ToString();
            return mlModel;
        }
        /// <summary>
        /// 更新状态
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public int Update(string storesid, string id, string status, string message)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps ={
                             db.CreateParameter("@status",status,DbType.Int32),
                             db.CreateParameter("@message",message,DbType.String),
                             db.CreateParameter("@storesid", storesid, DbType.Int32),
                             db.CreateParameter("@id", id, DbType.Int32)
                             };
            int icount=db.GetRowCount("Update [Mobile_MessageLog] set [status]=@status,[message]=@message Where [storesid]=@storesid and [id]=@id",ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="storesid">门店ID</param>
        /// <param name="mobile">手机号</param>
        /// <param name="title">内容</param>
        /// <param name="statustime">开始时间</param>
        /// <param name="endtime">结束时间</param>
        /// <returns></returns>
        public string View(int PageSize, string storesid, string mobile, string title, string statustime, string endtime)
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
                page.TableName = "[Mobile_MessageLog]";
                page.OrderBy = "order by [id] desc";
                page.Index = "[id]";
                page.Field = "[id],[mobile],[sendtime],[addtime],[content],[sendtype],[status],[message]";
                List<string> Filter = new List<string>();
                Filter.Add("[storesid]=" + storesid);
                if (mobile.Length>0)
                {
                    Filter.Add("[mobile]='" + mobile + "'");
                }
                if (title.Length>0)
                {
                    Filter.Add("[content] like '%" + title + "%'");
                }
                if (Base.Fun.fun.IsDate(statustime))
                {
                    Filter.Add("[addtime]>='" + statustime + "'");
                }
                if (Base.Fun.fun.IsDate(endtime))
                {
                    Filter.Add("[addtime]<='" + endtime + "'");
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
