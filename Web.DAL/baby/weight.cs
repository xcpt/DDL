using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Web.DAL.baby
{
    /// <summary>
    /// 体重
    /// </summary>
    public class weight
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="hModel"></param>
        /// <returns></returns>
        public string Insert(Model.baby.weight wModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@monthage",wModel.monthage,DbType.Int32),
                               db.CreateParameter("@sex",wModel.sex,DbType.Int32),
                               db.CreateParameter("@minnum",wModel.minnum,DbType.Double),
                               db.CreateParameter("@maxnum",wModel.maxnum,DbType.Double)
                               };
            string id = db.GetNewID(@"INSERT INTO [baby_weight]
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
        public int Update(Model.baby.weight wModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@monthage",wModel.monthage,DbType.Int32),
                               db.CreateParameter("@sex",wModel.sex,DbType.Int32),
                               db.CreateParameter("@minnum",wModel.minnum,DbType.Double),
                               db.CreateParameter("@maxnum",wModel.maxnum,DbType.Double),
                               db.CreateParameter("@id",wModel.id,DbType.Int32)
                               };
            int icount = db.GetRowCount(@"UPDATE [baby_weight]
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
            int icount = db.GetRowCount(@"DELETE FROM [baby_weight]
      WHERE [ID]=@id", db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Model.baby.weight Read(string ID)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[monthage]
      ,[sex]
      ,[minnum]
      ,[maxnum]
  FROM [baby_weight] Where [id]=@id", db.CreateParameter("@id", ID, DbType.Int32));
            db.Dispose();
            Model.baby.weight wModel = new Model.baby.weight();
            if (dt.Rows.Count > 0)
            {
                wModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return wModel;
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<Model.baby.weight> ReadList()
        {
            List<Model.baby.weight> hList = new List<Model.baby.weight>();
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[monthage]
      ,[sex]
      ,[minnum]
      ,[maxnum]
  FROM [baby_weight] order by [monthage] asc,[ID] desc");
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
                page.TableName = "[baby_weight]";
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
        private Model.baby.weight DataRow2Model(DataRow dr)
        {
            Model.baby.weight wModel = new Model.baby.weight();
            wModel.monthage = dr["monthage"].ToString();
            wModel.sex = dr["sex"].ToString();
            wModel.minnum = dr["minnum"].ToString();
            wModel.maxnum = dr["maxnum"].ToString();
            return wModel;
        }
    }
}
