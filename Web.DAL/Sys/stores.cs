using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.Sys
{
    /// <summary>
    /// 门店
    /// </summary>
    public class stores
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="sModel"></param>
        /// <returns></returns>
        public string Insert(Model.Sys.stores sModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@title",sModel.title,DbType.String),
                               db.CreateParameter("@opentime",sModel.opentime,DbType.DateTime),
                               db.CreateParameter("@address",sModel.address,DbType.String),
                               db.CreateParameter("@Province",sModel.Province,DbType.String),
                               db.CreateParameter("@City",sModel.City,DbType.String),
                               db.CreateParameter("@Worktime",sModel.Worktime,DbType.Int32),
                               db.CreateParameter("@Closingtime",sModel.Closingtime,DbType.Int32),
                               db.CreateParameter("@tel",sModel.tel,DbType.String),
                               db.CreateParameter("@Isoutlets",sModel.Isoutlets,DbType.Int32),
                               db.CreateParameter("@IsCross",sModel.IsCross,DbType.Int32)
                               };
            string id = db.GetNewID(@"INSERT INTO [Sys_stores]
           ([title]
           ,[opentime]
           ,[address]
           ,[Province]
           ,[City]
           ,[Worktime]
           ,[Closingtime]
           ,[tel]
           ,[Isoutlets]
           ,[IsCross])
     VALUES
           (@title
           ,@opentime
           ,@address
           ,@Province
           ,@City
           ,@Worktime
           ,@Closingtime
           ,@tel
           ,@Isoutlets
           ,@IsCross)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sModel"></param>
        /// <returns></returns>
        public int Update(Model.Sys.stores sModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@title",sModel.title,DbType.String),
                               db.CreateParameter("@opentime",sModel.opentime,DbType.DateTime),
                               db.CreateParameter("@address",sModel.address,DbType.String),
                               db.CreateParameter("@Province",sModel.Province,DbType.String),
                               db.CreateParameter("@City",sModel.City,DbType.String),
                               db.CreateParameter("@Worktime",sModel.Worktime,DbType.Int32),
                               db.CreateParameter("@Closingtime",sModel.Closingtime,DbType.Int32),
                               db.CreateParameter("@tel",sModel.tel,DbType.String),
                               db.CreateParameter("@Isoutlets",sModel.Isoutlets,DbType.Int32),
                               db.CreateParameter("@IsCross",sModel.IsCross,DbType.Int32),
                               db.CreateParameter("@storesid",sModel.storesid,DbType.Int32)
                               };
            int icount = db.GetRowCount(@"UPDATE [Sys_stores]
   SET [title] = @title
      ,[opentime] = @opentime
      ,[address] = @address
      ,[Province] = @Province
      ,[City] = @City
      ,[Worktime] = @Worktime
      ,[Closingtime] = @Closingtime
      ,[tel]=@tel
      ,[Isoutlets]=@Isoutlets
      ,[IsCross]=@IsCross
 WHERE [storesid]=@storesid", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public int Delete(string storesid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            int icount = db.GetRowCount("DELETE FROM [Sys_stores] WHERE [storesid]=@storesid", db.CreateParameter("@storesid", storesid, DbType.Int32));
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <returns></returns>
        public List<Model.Sys.stores> ReadList()
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [storesid]
      ,[title]
      ,[opentime]
      ,[address]
      ,[Province]
      ,[City]
      ,[Worktime]
      ,[Closingtime]
      ,[tel]
      ,[Isoutlets]
      ,[IsCross]
  FROM [Sys_stores]");
            db.Dispose();
            List<Model.Sys.stores> sList = new List<Model.Sys.stores>();
            foreach (DataRow dr in dt.Rows)
            {
                sList.Add(DataRow2Model(dr));
            }
            dt.Dispose();
            return sList;
        }
        /// <summary>
        /// 读取单条
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public Model.Sys.stores Read(string storesid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt= db.GetData(@"SELECT [storesid]
      ,[title]
      ,[opentime]
      ,[address]
      ,[Province]
      ,[City]
      ,[Worktime]
      ,[Closingtime]
      ,[tel]
      ,[Isoutlets]
      ,[IsCross]
  FROM [Sys_stores] where [storesid]=@storesid", db.CreateParameter("@storesid", storesid, DbType.Int32));
            db.Dispose();
            Model.Sys.stores sModel = new Model.Sys.stores();
            if (dt.Rows.Count > 0)
            {
                sModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return sModel;
        }

        /// <summary>
        /// 读取单条
        /// </summary>
        /// <returns></returns>
        public Model.Sys.stores ReadOne()
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT top 1 [storesid]
      ,[title]
      ,[opentime]
      ,[address]
      ,[Province]
      ,[City]
      ,[Worktime]
      ,[Closingtime]
      ,[tel]
      ,[Isoutlets]
      ,[IsCross]
  FROM [Sys_stores] order by [storesid] desc");
            db.Dispose();
            Model.Sys.stores sModel = new Model.Sys.stores();
            if (dt.Rows.Count > 0)
            {
                sModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return sModel;
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="storesid">门店ID</param>
        /// <param name="title">名称</param>
        /// <returns></returns>
        public string View(int PageSize, string title, string starttime, string endtime, string Province, string City)
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
                page.TableName = "[Sys_stores]";
                page.OrderBy = "order by [storesid] desc";
                page.Index = "[storesid]";
                page.Field = "[storesid],[title],[opentime],[Province],[City],[address],[Isoutlets],[IsCross]";
                List<string> Filter = new List<string>();
                if (title.Length > 0)
                {
                    Filter.Add("[title] like '%" + title + "%'");
                }
                if (Base.Fun.fun.IsDate(starttime))
                {
                    Filter.Add("[opentime]>='" + starttime + "'");
                }
                if (Base.Fun.fun.IsDate(endtime))
                {
                    Filter.Add("[opentime]<='" + endtime + "'");
                }
                if (Province.Length > 0)
                {
                    Filter.Add("[Province] = '" + Province + "'");
                }
                if (City.Length > 0)
                {
                    Filter.Add("[City] = '" + City + "'");
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
        private Model.Sys.stores DataRow2Model(DataRow dr)
        {
            Model.Sys.stores sModel = new Model.Sys.stores();
            sModel.storesid = dr["storesid"].ToString();
            sModel.Isoutlets = dr["Isoutlets"].ToString();
            sModel.IsCross = dr["IsCross"].ToString();
            sModel.title = dr["title"].ToString();
            sModel.opentime = dr["opentime"].ToString();
            sModel.address = dr["address"].ToString();
            sModel.Province = dr["Province"].ToString();
            sModel.City = dr["City"].ToString();
            sModel.Worktime = dr["Worktime"].ToString();
            sModel.Closingtime = dr["Closingtime"].ToString();
            sModel.tel = dr["tel"].ToString();
            return sModel;
        }
    }
}
