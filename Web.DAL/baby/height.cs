using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.baby
{
    /// <summary>
    /// 身高
    /// </summary>
    public class height
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="hModel"></param>
        /// <returns></returns>
        public string Insert(Model.baby.height hModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@monthage",hModel.monthage,DbType.Int32),
                               db.CreateParameter("@sex",hModel.sex,DbType.Int32),
                               db.CreateParameter("@minnum",hModel.minnum,DbType.Double),
                               db.CreateParameter("@maxnum",hModel.maxnum,DbType.Double)
                               };
            string id = db.GetNewID(@"INSERT INTO [baby_height]
           ([monthage]
           ,[sex]
           ,[minnum]
           ,[maxnum])
     VALUES
           (@monthage
           ,@sex
           ,@minnum
           ,@maxnum)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="hModel"></param>
        /// <returns></returns>
        public int Update(Model.baby.height hModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@monthage",hModel.monthage,DbType.Int32),
                               db.CreateParameter("@sex",hModel.sex,DbType.Int32),
                               db.CreateParameter("@minnum",hModel.minnum,DbType.Double),
                               db.CreateParameter("@maxnum",hModel.maxnum,DbType.Double),
                               db.CreateParameter("@id",hModel.id,DbType.Int32)
                               };
            int icount = db.GetRowCount(@"UPDATE [baby_height]
   SET [monthage] = @monthage
      ,[sex] = @sex
      ,[minnum] = @minnum
      ,[maxnum] = @maxnum
 WHERE [id]=@id", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            int icount = db.GetRowCount(@"DELETE FROM [baby_height]
      WHERE [ID]=@id", db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Model.baby.height Read(string ID)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[monthage]
      ,[sex]
      ,[minnum]
      ,[maxnum]
  FROM [baby_height] Where [id]=@id", db.CreateParameter("@id", ID, DbType.Int32));
            db.Dispose();
            Model.baby.height hModel = new Model.baby.height();
            if (dt.Rows.Count > 0)
            {
                hModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return hModel;
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<Model.baby.height> ReadList()
        {
            List<Model.baby.height> hList = new List<Model.baby.height>();
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt= db.GetData(@"SELECT [id]
      ,[monthage]
      ,[sex]
      ,[minnum]
      ,[maxnum]
  FROM [baby_height] order by [monthage] asc,[ID] desc");
            db.Dispose();
            foreach (DataRow dr in dt.Rows)
            {
                hList.Add(DataRow2Model(dr));
            }
            dt.Dispose();
            return hList;
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
        public string View(int PageSize, string monthage, string sex)
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
                page.TableName = "[baby_height]";
                page.OrderBy = "order by [id] desc";
                page.Index = "[ID]";
                page.Field = "[ID],[monthage],[sex],[minnum],[maxnum]";
                List<string> Filter = new List<string>();
                if (monthage.Length > 0)
                {
                    Filter.Add("[monthage]=" + monthage);
                }
                if (Base.Fun.fun.IsNumeric(sex))
                {
                    Filter.Add("[sex]=" + sex);
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
        /// 信息
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private Model.baby.height DataRow2Model(DataRow dr)
        {
            Model.baby.height hModel = new Model.baby.height();
            hModel.monthage = dr["monthage"].ToString();
            hModel.sex = dr["sex"].ToString();
            hModel.minnum = dr["minnum"].ToString();
            hModel.maxnum = dr["maxnum"].ToString();
            return hModel;
        }
    }
}