using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.Staff
{
    /// <summary>
    /// 部门
    /// </summary>
    public class department
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="dModel"></param>
        /// <returns></returns>
        public string Insert(Model.Staff.department dModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",dModel.storesid,DbType.Int32),
                               db.CreateParameter("@title",dModel.title,DbType.String),
                               db.CreateParameter("@headmemberid",dModel.headmemberid,DbType.Int32),
                               db.CreateParameter("@description",dModel.description,DbType.String)
                               };
            string id = db.GetNewID(@"INSERT INTO [Staff_department]
           ([storesid]
           ,[title]
           ,[headmemberid]
           ,[description])
     VALUES
           (@storesid
           ,@title
           ,@headmemberid
           ,@description)",ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dModel"></param>
        /// <returns></returns>
        public int Update(Model.Staff.department dModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@title",dModel.title,DbType.String),
                               db.CreateParameter("@headmemberid",dModel.headmemberid,DbType.Int32),
                               db.CreateParameter("@description",dModel.description,DbType.String),
                               db.CreateParameter("@storesid",dModel.storesid,DbType.Int32),
                               db.CreateParameter("@id",dModel.id,DbType.Int32)
                               };
            int icount = db.GetRowCount(@"UPDATE [Staff_department]
   SET [title]=@title
      ,[headmemberid] = @headmemberid
      ,[description] = @description
 WHERE [storesid] = @storesid and [id]=@id",ps);
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
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",storesid,DbType.Int32),
                               db.CreateParameter("@id",id,DbType.Int32)
                               };
            int icount = db.GetRowCount(@"DELETE FROM [Staff_department] WHERE [storesid] = @storesid and [id]=@id", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public Model.Staff.department Read(string storesid, string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[title]
      ,[headmemberid]
      ,[description]
  FROM [Staff_department] Where [storesid]=@storesid and [id]=@id", db.CreateParameter("@storesid", storesid, DbType.Int32), db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            Model.Staff.department dModel = new Model.Staff.department();
            if (dt.Rows.Count > 0)
            {
                dModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return dModel;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Staff.department Read(string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[title]
      ,[headmemberid]
      ,[description]
  FROM [Staff_department] Where [id]=@id", db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            Model.Staff.department dModel = new Model.Staff.department();
            if (dt.Rows.Count > 0)
            {
                dModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return dModel;
        }
        /// <summary>
        /// 读取所有
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public List<Model.Staff.department> ReadList(string storesid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[title]
      ,[headmemberid]
      ,[description]
  FROM [Staff_department] Where [storesid]=@storesid", db.CreateParameter("@storesid", storesid, DbType.Int32));
            db.Dispose();
            List<Model.Staff.department> dList = new List<Model.Staff.department>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dList.Add(DataRow2Model(dr));
                }
            }
            dt.Dispose();
            return dList;
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
        public string View(int PageSize, string storesid, string title)
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
                page.TableName = "[Staff_department] as a left join [Staff_member] as b on a.[headmemberid]=b.[id]";
                page.OrderBy = "order by a.[id] desc";
                page.Index = "a.[id]";
                page.Field = "a.[id],a.[title],b.[name],a.[description]";
                List<string> Filter = new List<string>();
                Filter.Add("a.[storesid]=" + storesid);
                if (title.Length > 0)
                {
                    Filter.Add("a.[title] like '%" + title + "%'");
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
        public Model.Staff.department DataRow2Model(DataRow dr)
        {
            Model.Staff.department dModel = new Model.Staff.department();
            dModel.id = dr["id"].ToString();
            dModel.title = dr["title"].ToString();
            dModel.storesid = dr["storesid"].ToString();
            dModel.headmemberid = dr["headmemberid"].ToString();
            dModel.description = dr["description"].ToString();
            return dModel;
        }
    }
}
