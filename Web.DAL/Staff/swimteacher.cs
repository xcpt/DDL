using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.Staff
{
    public class swimteacher
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="sModel"></param>
        /// <returns></returns>
        public string Insert(Model.Staff.swimteacher sModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                             db.CreateParameter("@memberid",sModel.memberid,DbType.Int32),
                             db.CreateParameter("@isopen",sModel.isopen,DbType.Int32),
                             db.CreateParameter("@iswww",sModel.iswww,DbType.Int32)
                             };
            string id = db.GetNewID(@"INSERT INTO [Staff_swimteacher]
           ([memberid]
           ,[isopen]
           ,[iswww])
     VALUES
           (@memberid
           ,@isopen
           ,@iswww)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isopen"></param>
        /// <returns></returns>
        public int Update_IsOpen(string id,string isopen)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@isopen",isopen,DbType.Int32),
                               db.CreateParameter("@id",id,DbType.Int32)
                               };
            int icount = db.GetRowCount("UPDATE [Staff_swimteacher] SET [isopen] = @isopen WHERE [ID]=@id", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isopen"></param>
        /// <returns></returns>
        public int Update_IsWWW(string id, string isWWW)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@isWWW",isWWW,DbType.Int32),
                               db.CreateParameter("@id",id,DbType.Int32)
                               };
            int icount = db.GetRowCount("UPDATE [Staff_swimteacher] SET [isWWW] = @isWWW WHERE [ID]=@id", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Staff.swimteacher Read(string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[memberid]
      ,[isopen]
      ,[iswww]
  FROM [Staff_swimteacher] Where [id]=@id", db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            Model.Staff.swimteacher sModel = new Model.Staff.swimteacher();
            if (dt.Rows.Count > 0)
            {
                sModel.id = dt.Rows[0]["id"].ToString();
                sModel.memberid = dt.Rows[0]["memberid"].ToString();
                sModel.isopen = dt.Rows[0]["isopen"].ToString();
                sModel.iswww = dt.Rows[0]["iswww"].ToString();
            }
            return sModel;
        }

        /// <summary>
        /// 读取所有
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Model.Staff.swimteacher> ReadList(string storesid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT a.[id]
      ,a.[memberid]
      ,a.[isopen]
      ,a.[iswww]
      ,b.[name]
      ,b.[departmentid]
  FROM [Staff_swimteacher] as a inner join [Staff_Member] as b on a.[memberid]=b.[id] Where b.[storesid]=@storesid", db.CreateParameter("@storesid", storesid, DbType.Int32));
            db.Dispose();
            List<Model.Staff.swimteacher> sList = new List<Model.Staff.swimteacher>();
            foreach(DataRow dr in dt.Rows)
            {
                Model.Staff.swimteacher sModel = new Model.Staff.swimteacher();
                sModel.id = dr["id"].ToString();
                sModel.memberid = dr["memberid"].ToString();
                sModel.member_name = dr["name"].ToString();
                sModel.member_departmentid = dr["departmentid"].ToString();
                sModel.isopen = dr["isopen"].ToString();
                sModel.iswww = dr["iswww"].ToString();
                sList.Add(sModel);
            }
            return sList;
        }
        /// <summary>
        /// 读取所有
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable ReadListApp(string storesid, string UserID, string datetime, string datetimehouer, string datetimeminute, string babytype)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT b.[id],b.[name],b.[userface],(select count([id]) From [customer_UserConsumption] Where [swimteacherid]=a.[memberid] and [userid]=" + UserID + ") as num FROM [Staff_swimteacher] as a inner join [Staff_Member] as b on a.[memberid]=b.[id] inner join [Staff_department] as c on b.[departmentid]=c.[id] where (c.[title]='" + (babytype == "1" ? "婴儿区" : "幼儿区") + "' or b.[name]='其他') and (b.[name]='其他' or (select COUNT(id) from [customer_Userappointment] as c where c.[swimteacherid]=a.[memberid] and c.[status]=0 and c.[userid]<>" + UserID + " and datediff(day,c.[datetime],'" + datetime + "')=0 and c.[datetimehouer]=" + datetimehouer + " and c.[datetimeminute]=" + datetimeminute + ")=0) and b.[storesid]=@storesid and a.[isopen]=1 and a.[iswww]=1 order by num desc", db.CreateParameter("@UserID", UserID, DbType.Int32), db.CreateParameter("@storesid", storesid, DbType.Int32));
            db.Dispose();
            return dt;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Read_Member(string memberid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string id = db.GetValue(@"SELECT [id] FROM [Staff_swimteacher] Where [memberid]=@memberid", db.CreateParameter("@memberid", memberid, DbType.Int32)).ToString();
            db.Dispose();
            return id;
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
        public string View(int PageSize, string storesid, string memberid, string isopen, string iswww, string departmentid)
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
                page.TableName = "[Staff_swimteacher] as a inner join [Staff_Member] as b on a.[memberid]=b.[id] left join [Staff_department] as c on b.[departmentid]=c.[id]";
                page.OrderBy = "order by a.[id] desc";
                page.Index = "a.[id]";
                page.Field = "a.[id],b.[name],b.[sex],c.[title] as departmentname,a.[iswww],a.[isopen]";
                List<string> Filter = new List<string>();
                Filter.Add("b.[storesid]=" + storesid);
                if (Base.Fun.fun.pnumeric(memberid))
                {
                    Filter.Add("a.[memberid]=" + memberid);
                }
                if (Base.Fun.fun.IsNumeric(isopen))
                {
                    Filter.Add("a.[isopen]=" + isopen);
                }
                if (Base.Fun.fun.IsNumeric(iswww))
                {
                    Filter.Add("a.[iswww]=" + iswww);
                }
                if (Base.Fun.fun.pnumeric(departmentid))
                {
                    Filter.Add("b.[departmentid]=" + departmentid);
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
