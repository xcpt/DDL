using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.Staff
{
    /// <summary>
    /// 员工分值管理
    /// </summary>
    public class score
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="sModel"></param>
        /// <returns></returns>
        public string Insert(Model.Staff.score sModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@memberid",sModel.memberid,DbType.Int32),
                               db.CreateParameter("@type",sModel.type,DbType.Int32),
                               db.CreateParameter("@datetime",sModel.datetime,DbType.DateTime),
                               db.CreateParameter("@addtime",sModel.addtime,DbType.DateTime),
                               db.CreateParameter("@isadd",sModel.isadd,DbType.Int32),
                               db.CreateParameter("@num",sModel.num,DbType.Int32),
                               db.CreateParameter("@content",sModel.content,DbType.String)
                               };
            string id = db.GetNewID(@"INSERT INTO [Staff_score]
           ([memberid]
           ,[type]
           ,[datetime]
           ,[addtime]
           ,[isadd]
           ,[num]
           ,[content])
     VALUES
           (@memberid
           ,@type
           ,@datetime
           ,@addtime
           ,@isadd
           ,@num
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
            int icount = db.GetRowCount("DELETE FROM [Store20150104].[dbo].[Staff_score] WHERE [id]=@id", db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Staff.score Read(string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[memberid]
      ,[type]
      ,[datetime]
      ,[addtime]
      ,[isadd]
      ,[num]
      ,[content]
  FROM [Staff_score] Where [id]=@id", db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            Model.Staff.score sModel = new Model.Staff.score();
            if (dt.Rows.Count > 0)
            {
                sModel.id = dt.Rows[0]["id"].ToString();
                sModel.memberid = dt.Rows[0]["memberid"].ToString();
                sModel.type = dt.Rows[0]["type"].ToString();
                sModel.datetime = dt.Rows[0]["datetime"].ToString();
                sModel.addtime = dt.Rows[0]["addtime"].ToString();
                sModel.isadd = dt.Rows[0]["isadd"].ToString();
                sModel.num = dt.Rows[0]["num"].ToString();
                sModel.content = dt.Rows[0]["content"].ToString();
            }
            dt.Dispose();
            return sModel;
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="storesid">门店ID</param>
        /// <param name="name">姓名</param>
        /// <param name="isadd">是否增加</param>
        /// <param name="type">考勤类型</param>
        /// <param name="starttime">开始时间</param>
        /// <param name="endtime">结束时间</param>
        /// <returns></returns>
        public string View(int PageSize, string storesid, string memberid, string isadd, string type, string starttime, string endtime)
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
                page.TableName = "[Staff_score] as a inner join [Staff_Member] as b on a.[memberid]=b.[id]";
                page.OrderBy = "order by a.[id] desc";
                page.Index = "a.[id]";
                page.Field = "a.[id],b.[name],a.[type],a.[datetime],a.[isadd],a.[num]";
                List<string> Filter = new List<string>();
                Filter.Add("b.[storesid]=" + storesid);
                if (Base.Fun.fun.pnumeric(memberid))
                {
                    Filter.Add("a.[memberid]=" + memberid);
                }
                if (Base.Fun.fun.IsNumeric(isadd))
                {
                    Filter.Add("a.[isadd]=" + isadd);
                }
                if (Base.Fun.fun.IsNumeric(type))
                {
                    Filter.Add("a.[type]=" + type);
                }
                if (Base.Fun.fun.IsDate(starttime))
                {
                    Filter.Add("a.[datetime]>='" + starttime + "'");
                }
                if (Base.Fun.fun.IsDate(endtime))
                {
                    Filter.Add("a.[datetime]<='" + endtime + "'");
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
