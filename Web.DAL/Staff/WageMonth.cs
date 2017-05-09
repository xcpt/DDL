using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.Staff
{
    /// <summary>
    /// 员工月工资
    /// </summary>
    public class WageMonth
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="wlModel"></param>
        /// <returns></returns>
        public string Insert(Model.Staff.WageMonth wlModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@memberid",wlModel.memberid,DbType.Int32),
                               db.CreateParameter("@datetime",wlModel.datetime,DbType.Int32),
                               db.CreateParameter("@salary",wlModel.salary,DbType.Double),
                               db.CreateParameter("@deducted",wlModel.deducted,DbType.Double),
                               db.CreateParameter("@wagenum",wlModel.wagenum,DbType.Double)
                               };
            string id = db.GetNewID(@"INSERT INTO [Staff_WageMonth]
           ([memberid]
           ,[datetime]
           ,[salary]
           ,[deducted]
           ,[wagenum])
     VALUES
           (@memberid
           ,@datetime
           ,@salary
           ,@deducted
           ,@wagenum)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Staff.WageMonth Read(string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[memberid]
      ,[datetime]
      ,[salary]
      ,[deducted]
      ,[wagenum]
  FROM [Staff_WageMonth] Where [id]=@id", db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            Model.Staff.WageMonth wwModel = new Model.Staff.WageMonth();
            if (dt.Rows.Count > 0)
            {
                wwModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return wwModel;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="wmModel"></param>
        /// <returns></returns>
        public int Update(Model.Staff.WageMonth wmModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@salary",wmModel.salary,DbType.Double),
                               db.CreateParameter("@deducted",wmModel.deducted,DbType.Double),
                               db.CreateParameter("@wagenum",wmModel.wagenum,DbType.Double),
                               db.CreateParameter("@memberid",wmModel.memberid,DbType.Int32),
                               db.CreateParameter("@datetime",wmModel.datetime,DbType.Int32)
                               };
            int icount = db.GetRowCount(@"UPDATE [Staff_WageMonth]
   SET [salary] = @salary
      ,[deducted] = @deducted
      ,[wagenum] = @wagenum
 WHERE [memberid] = @memberid and [datetime] = @datetime", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="wmModel"></param>
        /// <returns></returns>
        public int Update_wagenum(string id, string wagenum)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@wagenum",wagenum,DbType.Double),
                               db.CreateParameter("@id",id,DbType.Int32)
                               };
            int icount = db.GetRowCount(@"UPDATE [Staff_WageMonth]
   SET [wagenum] = @wagenum
 WHERE [id] = @id", ps);
            db.Dispose();
            return icount;
        }

        /// <summary>
        /// 读取员工某月工资
        /// </summary>
        /// <param name="datetime"></param>
        /// <param name="memberid"></param>
        /// <returns></returns>
        public Model.Staff.WageMonth Read_Member(string datetime, string memberid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[memberid]
      ,[datetime]
      ,[salary]
      ,[deducted]
      ,[wagenum]
  FROM [Staff_WageMonth] Where [datetime]=@datetime and [memberid]=@memberid", db.CreateParameter("@datetime", datetime, DbType.Int32), db.CreateParameter("@memberid", memberid, DbType.Int32));
            db.Dispose();
            Model.Staff.WageMonth wwModel = new Model.Staff.WageMonth();
            if (dt.Rows.Count > 0)
            {
                wwModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return wwModel;
        }
        /// <summary>
        /// 读取某月工资
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public List<Model.Staff.WageMonth> ReadList(string datetime)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[memberid]
      ,[datetime]
      ,[salary]
      ,[deducted]
      ,[wagenum]
  FROM [Staff_WageMonth] Where [datetime]=@datetime", db.CreateParameter("@datetime", datetime, DbType.Int32));
            db.Dispose();
            List<Model.Staff.WageMonth> wmList = new List<Model.Staff.WageMonth>();
            foreach (DataRow dr in dt.Rows)
            {
                wmList.Add(DataRow2Model(dr));
            }
            dt.Dispose();
            return wmList;
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="storesid"></param>
        /// <param name="name"></param>
        /// <param name="isopen"></param>
        /// <param name="iswww"></param>
        /// <param name="departmentid"></param>
        /// <returns></returns>
        public List<Model.Staff.WageMonth> View(int PageSize, ref int Page, ref int MaxPage, ref int Total, string storesid, string memberid, string datetime)
        {
            List<Model.Staff.WageMonth> wmList = new List<Model.Staff.WageMonth>();
            DataTable dt = new DataTable();
            Base.Page.Dividepage page = new Base.Page.Dividepage();
            try
            {
                if (PageSize <= 0)
                {
                    PageSize = 15;
                }
                page.PageSize = PageSize;
                page.TableName = "[Staff_WageMonth] as a Left join [Staff_Member] as b on a.[memberid]=b.[id] left join [Staff_position] as c on b.[positionid]=c.[id]";
                page.OrderBy = "order by a.[id] desc";
                page.Index = "a.[id]";
                page.Field = "a.[id],a.[memberid],b.[name],a.[datetime],c.[level],a.[salary],a.[deducted],a.[wagenum]";
                List<string> Filter = new List<string>();
                Filter.Add("b.[storesid]=" + storesid);
                if (Base.Fun.fun.pnumeric(memberid))
                {
                    Filter.Add("a.[memberid]=" + memberid);
                }
                if (Base.Fun.fun.IsNumeric(datetime))
                {
                    Filter.Add("a.[datetime]=" + datetime);
                }
                page.Filter = string.Join(" and ", Filter.ToArray());
                dt = page.getrows();
                Page = page.Page;
                MaxPage = page.MaxPage;
                Total = page.TotalRow;
                foreach (DataRow dr in dt.Rows)
                {
                    Model.Staff.WageMonth wmModel = new Model.Staff.WageMonth();
                    wmModel.id = dr["id"].ToString();
                    wmModel.memberid = dr["memberid"].ToString();
                    wmModel.member_name = dr["name"].ToString();
                    wmModel.datetime = dr["datetime"].ToString();
                    wmModel.member_level = dr["level"].ToString();
                    wmModel.salary = dr["salary"].ToString();
                    wmModel.deducted = dr["deducted"].ToString();
                    wmModel.wagenum = dr["wagenum"].ToString();
                    wmList.Add(wmModel);
                }
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
            return wmList;
        }



        /// <summary>
        /// 读取月
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private Model.Staff.WageMonth DataRow2Model(DataRow dr)
        {
            Model.Staff.WageMonth wmModel = new Model.Staff.WageMonth();
            wmModel.id = dr["id"].ToString();
            wmModel.memberid = dr["memberid"].ToString();
            wmModel.datetime = dr["datetime"].ToString();
            wmModel.salary = dr["salary"].ToString();
            wmModel.deducted = dr["deducted"].ToString();
            wmModel.wagenum = dr["wagenum"].ToString();
            return wmModel;
        }
    }
}
