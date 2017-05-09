using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.baby
{
    /// <summary>
    /// 成长周期
    /// </summary>
    public class Cycle
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="cModel"></param>
        /// <returns></returns>
        public string Insert(Model.baby.Cycle cModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@title",cModel.title,DbType.String),
                               db.CreateParameter("@type",cModel.type,DbType.Int32),
                               db.CreateParameter("@startday",cModel.startday,DbType.Int32),
                               db.CreateParameter("@endday",cModel.endday,DbType.Int32)
                               };
            string id = db.GetNewID(@"INSERT INTO [baby_Cycle]
           ([title]
           ,[type]
           ,[startday]
           ,[endday])
     VALUES
           (@title
           ,@type
           ,@startday
           ,@endday)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 读取单条
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.baby.Cycle Read(string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[title]
      ,[type]
      ,[startday]
      ,[endday]
  FROM [baby_Cycle] Where [ID]=@id", db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            Model.baby.Cycle cModel = new Model.baby.Cycle();
            if (dt.Rows.Count > 0)
            {
                cModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return cModel;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            int icount = db.GetRowCount("DELETE FROM [baby_Cycle] WHERE [id]=@id", db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="cModel"></param>
        /// <returns></returns>
        public int Update(Model.baby.Cycle cModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@title",cModel.title,DbType.String),
                               db.CreateParameter("@type",cModel.type,DbType.Int32),
                               db.CreateParameter("@startday",cModel.startday,DbType.Int32),
                               db.CreateParameter("@endday",cModel.endday,DbType.Int32),
                               db.CreateParameter("@id",cModel.id,DbType.Int32)
                               };
            int icount = db.GetRowCount(@"UPDATE [baby_Cycle]
   SET [title] = @title
      ,[type] = @type
      ,[startday] = @startday
      ,[endday] = @endday
 WHERE [id]=@id", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 读取所有
        /// </summary>
        /// <returns></returns>
        public List<Model.baby.Cycle> ReadList()
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[title]
      ,[type]
      ,[startday]
      ,[endday]
  FROM [baby_Cycle]");
            db.Dispose();
            List<Model.baby.Cycle> cList = new List<Model.baby.Cycle>();
            foreach (DataRow dr in dt.Rows)
            {
                cList.Add(DataRow2Model(dr));
            }
            dt.Dispose();
            return cList;
        }
        /// <summary>
        /// 显示内容
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="CardNo"></param>
        /// <param name="MonthAge"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        public string View(int PageSize, string title, string type)
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
                page.TableName = "[baby_Cycle]";
                page.OrderBy = "order by [id] desc";
                page.Index = "[ID]";
                page.Field = "[ID],[title],[startday],[endday],[type]";
                List<string> Filter = new List<string>();
                if (title.Length > 0)
                {
                    Filter.Add("[title] like '%" + title + "%'");
                }
                if (Base.Fun.fun.pnumeric(type))
                {
                    Filter.Add("[type]=" + type);
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
        /// Model
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private Model.baby.Cycle DataRow2Model(DataRow dr)
        {
            Model.baby.Cycle cModel = new Model.baby.Cycle();
            cModel.id = dr["id"].ToString();
            cModel.title = dr["title"].ToString();
            cModel.type = dr["type"].ToString();
            cModel.startday = dr["startday"].ToString();
            cModel.endday = dr["endday"].ToString();
            return cModel;
        }
    }
}
