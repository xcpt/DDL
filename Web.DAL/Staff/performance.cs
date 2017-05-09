using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.Staff
{
    /// <summary>
    /// 绩效
    /// </summary>
    public class performance
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="pModel"></param>
        /// <returns></returns>
        public string Insert(Model.Staff.performance pModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@memberid",pModel.memberid,DbType.Int32),
                               db.CreateParameter("@type",pModel.type,DbType.Int32),
                               db.CreateParameter("@datetime",pModel.datetime,DbType.DateTime),
                               db.CreateParameter("@addtime",pModel.addtime,DbType.DateTime),
                               db.CreateParameter("@num",pModel.num,DbType.Double),
                               db.CreateParameter("@content",pModel.content,DbType.String)
                               };
            string id = db.GetNewID(@"INSERT INTO [Staff_performance]
           ([memberid]
           ,[type]
           ,[datetime]
           ,[addtime]
           ,[num]
           ,[content])
     VALUES
           (@memberid
           ,@type
           ,@datetime
           ,@addtime
           ,@num
           ,@content)",ps).ToString();
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
            int icount = db.GetRowCount(@"DELETE FROM [Staff_performance] WHERE [id]=@id", db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 读取单条
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Staff.performance Read(string id)
        {
            Model.Staff.performance pModel = new Model.Staff.performance();
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[memberid]
      ,[type]
      ,[datetime]
      ,[addtime]
      ,[num]
      ,[content]
  FROM [Staff_performance] Where [id]=@id", db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            if (dt.Rows.Count > 0)
            {
                pModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return pModel;
        }
        /// <summary>
        /// 查询员工绩效
        /// </summary>
        /// <param name="MemberID"></param>
        /// <returns></returns>
        public List<Model.Staff.performance> ReadList_Member(string MemberID, string MonthStr)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[memberid]
      ,[type]
      ,[datetime]
      ,[addtime]
      ,[num]
      ,[content]
  FROM [Staff_performance] Where [memberid]=" + MemberID + (Base.Fun.fun.IsDate(MonthStr) ? " and DateDiff(MONTH,[datetime],'" + MonthStr + "')=0" : "") + "  order by [type]");
            db.Dispose();
            List<Model.Staff.performance> pList = new List<Model.Staff.performance>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    pList.Add(DataRow2Model(dr));
                }
            }
            dt.Dispose();
            return pList;
        }
        /// <summary>
        /// 查询员工绩效
        /// </summary>
        /// <param name="MemberID"></param>
        /// <returns></returns>
        public List<Model.Staff.performance> ReadList_Member(string MemberID, string statustime, string endtime)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[memberid]
      ,[type]
      ,[datetime]
      ,[addtime]
      ,[num]
      ,[content]
  FROM [Staff_performance] Where [memberid]=" + MemberID + (Base.Fun.fun.IsDate(statustime) ? " and [datetime]>='" + statustime + "'" : "") + (Base.Fun.fun.IsDate(endtime) ? " and [datetime]<='" + endtime + "'" : "") + "  order by [type]");
            db.Dispose();
            List<Model.Staff.performance> pList = new List<Model.Staff.performance>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    pList.Add(DataRow2Model(dr));
                }
            }
            dt.Dispose();
            return pList;
        }

        /// <summary>
        /// 查询部门绩效
        /// </summary>
        /// <param name="MemberID"></param>
        /// <returns></returns>
        public List<Model.Staff.performance> ReadList_department(string departmentid, string statustime, string endtime)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT a.[id]
      ,a.[memberid]
      ,a.[type]
      ,a.[datetime]
      ,a.[addtime]
      ,a.[num]
      ,a.[content]
  FROM [Staff_performance] as a inner join [Staff_member] as b on a.[memberid]=b.[id] Where b.[departmentid]=" + departmentid + (Base.Fun.fun.IsDate(statustime) ? " and [datetime]>='" + statustime + "'" : "") + (Base.Fun.fun.IsDate(endtime) ? " and [datetime]<='" + endtime + "'" : "") + "  order by [type]");
            db.Dispose();
            List<Model.Staff.performance> pList = new List<Model.Staff.performance>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    pList.Add(DataRow2Model(dr));
                }
            }
            dt.Dispose();
            return pList;
        }


        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="storesid">门店ID</param>
        /// <param name="name">名称</param>
        /// <param name="statustime">开始时间</param>
        /// <param name="endtime">结束时间</param>
        /// <returns></returns>
        public string View(int PageSize, string storesid, string memberid, string statustime, string endtime)
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
                page.TableName = "[Staff_performance] as a inner join [Staff_member] as b on a.[memberid]=b.[id]";
                page.OrderBy = "order by a.[id] desc";
                page.Index = "a.[id]";
                page.Field = "a.[id],b.[name],a.[type],a.[datetime],a.[num],a.[content]";
                List<string> Filter = new List<string>();
                Filter.Add("b.[storesid]=" + storesid);
                if (Base.Fun.fun.pnumeric(memberid))
                {
                    Filter.Add("a.[memberid]=" + memberid);
                }
                if (Base.Fun.fun.IsDate(statustime))
                {
                    Filter.Add("DATEDIFF(DAY,'" + statustime + "',a.[datetime])>=0");
                }
                if (Base.Fun.fun.IsDate(endtime))
                {
                    Filter.Add("DATEDIFF(DAY,'" + endtime + "',a.[datetime])<=0");
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
        private Model.Staff.performance DataRow2Model(DataRow dr)
        {
            Model.Staff.performance pModel = new Model.Staff.performance();
            pModel.id = dr["id"].ToString();
            pModel.memberid = dr["memberid"].ToString();
            pModel.type = dr["type"].ToString();
            pModel.datetime = dr["datetime"].ToString();
            pModel.addtime = dr["addtime"].ToString();
            pModel.num = dr["num"].ToString();
            pModel.content = dr["content"].ToString();
            return pModel;
        }
    }
}
