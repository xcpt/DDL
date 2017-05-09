using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.Staff
{
    /// <summary>
    /// 职位工资
    /// </summary>
    public class position
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="pModel"></param>
        /// <returns></returns>
        public string Insert(Model.Staff.position pModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",pModel.storesid,DbType.Int32),
                               db.CreateParameter("@title",pModel.title,DbType.String),
                               db.CreateParameter("@level",pModel.level,DbType.String),
                               db.CreateParameter("@salary",pModel.salary,DbType.Double),
                               db.CreateParameter("@deducted",pModel.deducted,DbType.Double),
                               db.CreateParameter("@istake",pModel.istake,DbType.Int32),
                               db.CreateParameter("@description",pModel.description,DbType.String)
                               };
            string id = db.GetNewID(@"INSERT INTO [Staff_position]
           ([storesid]
           ,[title]
           ,[level]
           ,[salary]
           ,[deducted]
           ,[istake]
           ,[description])
     VALUES
           (@storesid
           ,@title
           ,@level
           ,@salary
           ,@deducted
           ,@istake
           ,@description)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="pModel"></param>
        /// <returns></returns>
        public int Update(Model.Staff.position pModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@title",pModel.title,DbType.String),
                               db.CreateParameter("@level",pModel.level,DbType.String),
                               db.CreateParameter("@salary",pModel.salary,DbType.Double),
                               db.CreateParameter("@deducted",pModel.deducted,DbType.Double),
                               db.CreateParameter("@istake",pModel.istake,DbType.Int32),
                               db.CreateParameter("@description",pModel.description,DbType.String),
                               db.CreateParameter("@storesid",pModel.storesid,DbType.Int32),
                               db.CreateParameter("@id",pModel.id,DbType.Int32)
                               };
            int icount = db.GetRowCount(@"UPDATE [Staff_position]
   SET [title] = @title
      ,[level] = @level
      ,[salary] = @salary
      ,[deducted] = @deducted
      ,[istake] = @istake
      ,[description] = @description
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
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",storesid,DbType.Int32),
                               db.CreateParameter("@id",id,DbType.Int32)
                               };
            int icount = db.GetRowCount("DELETE FROM [Staff_position] WHERE [storesid] = @storesid and [id]=@id", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 读取单条
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Staff.position Read(string storesid, string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",storesid,DbType.Int32),
                               db.CreateParameter("@id",id,DbType.Int32)
                               };
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[title]
      ,[level]
      ,[salary]
      ,[deducted]
      ,[istake]
      ,[description]
  FROM [Staff_position] WHERE [storesid] = @storesid and [id]=@id", ps);
            db.Dispose();
            Model.Staff.position pModel = new Model.Staff.position();
            if (dt.Rows.Count > 0)
            {
                pModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return pModel;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public List<Model.Staff.position> ReadList(string storesid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[title]
      ,[level]
      ,[salary]
      ,[deducted]
      ,[istake]
      ,[description]
  FROM [Staff_position] WHERE [storesid] = @storesid", db.CreateParameter("@storesid", storesid, DbType.Int32));
            db.Dispose();
            List<Model.Staff.position> pList = new List<Model.Staff.position>();
            foreach (DataRow dr in dt.Rows)
            {
                pList.Add(DataRow2Model(dr));
            }
            dt.Dispose();
            return pList;
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
        public string View(int PageSize, string storesid, string title, string level)
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
                page.TableName = "[Staff_position]";
                page.OrderBy = "order by [id] desc";
                page.Index = "[id]";
                page.Field = "[id],[title],[level],[salary],[deducted],[istake]";
                List<string> Filter = new List<string>();
                Filter.Add("[storesid]=" + storesid);
                if (title.Length > 0)
                {
                    Filter.Add("[title] like '%" + title + "%'");
                }
                if (level.Length>0)
                {
                    Filter.Add("[level] like '%" + level + "%'");
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
        /// DataRow2Model
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private Model.Staff.position DataRow2Model(DataRow dr)
        {
            Model.Staff.position pModel = new Model.Staff.position();
            pModel.id = dr["id"].ToString();
            pModel.storesid = dr["storesid"].ToString();
            pModel.title = dr["title"].ToString();
            pModel.level = dr["level"].ToString();
            pModel.salary = dr["salary"].ToString();
            pModel.deducted = dr["deducted"].ToString();
            pModel.istake = dr["istake"].ToString();
            pModel.description = dr["description"].ToString();
            return pModel;
        }
    }
}
