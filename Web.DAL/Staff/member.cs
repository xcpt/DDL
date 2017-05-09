using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.Staff
{
    /// <summary>
    /// 员工
    /// </summary>
    public class member
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="mModel"></param>
        /// <returns></returns>
        public string Insert(Model.Staff.member mModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",mModel.storesid,DbType.Int32),
                               db.CreateParameter("@name",mModel.name,DbType.String),
                               db.CreateParameter("@enname",mModel.enname,DbType.String),
                               db.CreateParameter("@cnid",mModel.cnid,DbType.String),
                               db.CreateParameter("@cnidaddress",mModel.cnidaddress,DbType.String),
                               db.CreateParameter("@mobile",mModel.mobile,DbType.String),
                               db.CreateParameter("@email",mModel.email,DbType.String),
                               db.CreateParameter("@qq",mModel.qq,DbType.String),
                               db.CreateParameter("@homeaddress",mModel.homeaddress,DbType.String),
                               db.CreateParameter("@relativesname",mModel.relativesname,DbType.String),
                               db.CreateParameter("@hometel",mModel.hometel,DbType.String),
                               db.CreateParameter("@positionid",Base.Fun.fun.IsZero(mModel.positionid),DbType.Int32),
                               db.CreateParameter("@departmentid",Base.Fun.fun.IsZero(mModel.departmentid),DbType.Int32),
                               db.CreateParameter("@status",mModel.status,DbType.Int32),
                               db.CreateParameter("@sex",mModel.sex,DbType.Int32),
                               db.CreateParameter("@birthday",mModel.birthday,DbType.DateTime),
                               db.CreateParameter("@isinsurance",mModel.isinsurance,DbType.Int32),
                               db.CreateParameter("@entrytime",mModel.entrytime,DbType.DateTime),
                               db.CreateParameter("@quittime",mModel.quittime,DbType.DateTime),
                               db.CreateParameter("@userface",mModel.userface,DbType.String),
                               db.CreateParameter("@membersatisfactionid",mModel.membersatisfactionid,DbType.Int32)
                               };
            string id = db.GetNewID(@"INSERT INTO [Staff_member]
           ([storesid]
           ,[name]
           ,[enname]
           ,[cnid]
           ,[cnidaddress]
           ,[mobile]
           ,[email]
           ,[qq]
           ,[homeaddress]
           ,[relativesname]
           ,[hometel]
           ,[positionid]
           ,[departmentid]
           ,[status]
           ,[sex]
           ,[birthday]
           ,[isinsurance]
           ,[entrytime]
           ,[quittime]
           ,[userface]
           ,[membersatisfactionid])
     VALUES
           (@storesid
           ,@name
           ,@enname
           ,@cnid
           ,@cnidaddress
           ,@mobile
           ,@email
           ,@qq
           ,@homeaddress
           ,@relativesname
           ,@hometel
           ,@positionid
           ,@departmentid
           ,@status
           ,@sex
           ,@birthday
           ,@isinsurance
           ,@entrytime
           ,@quittime
           ,@userface
           ,@membersatisfactionid)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="mModel"></param>
        /// <returns></returns>
        public int Update(Model.Staff.member mModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@name",mModel.name,DbType.String),
                               db.CreateParameter("@enname",mModel.enname,DbType.String),
                               db.CreateParameter("@cnid",mModel.cnid,DbType.String),
                               db.CreateParameter("@cnidaddress",mModel.cnidaddress,DbType.String),
                               db.CreateParameter("@mobile",mModel.mobile,DbType.String),
                               db.CreateParameter("@email",mModel.email,DbType.String),
                               db.CreateParameter("@qq",mModel.qq,DbType.String),
                               db.CreateParameter("@homeaddress",mModel.homeaddress,DbType.String),
                               db.CreateParameter("@relativesname",mModel.relativesname,DbType.String),
                               db.CreateParameter("@hometel",mModel.hometel,DbType.String),
                               db.CreateParameter("@positionid",Base.Fun.fun.IsZero(mModel.positionid),DbType.Int32),
                               db.CreateParameter("@departmentid",Base.Fun.fun.IsZero(mModel.departmentid),DbType.Int32),
                               db.CreateParameter("@status",mModel.status,DbType.Int32),
                               db.CreateParameter("@sex",mModel.sex,DbType.Int32),
                               db.CreateParameter("@birthday",mModel.birthday,DbType.DateTime),
                               db.CreateParameter("@isinsurance",mModel.isinsurance,DbType.Int32),
                               db.CreateParameter("@entrytime",mModel.entrytime,DbType.DateTime),
                               db.CreateParameter("@quittime",mModel.quittime,DbType.DateTime),
                               db.CreateParameter("@userface",mModel.userface,DbType.String),
                               db.CreateParameter("@storesid",mModel.storesid,DbType.Int32),
                               db.CreateParameter("@id",mModel.id,DbType.Int32)
                               };
            int icount = db.GetRowCount(@"UPDATE [Staff_member]
   SET [name] = @name
      ,[enname] = @enname
      ,[cnid] = @cnid
      ,[cnidaddress] = @cnidaddress
      ,[mobile] = @mobile
      ,[email] = @email
      ,[qq] = @qq
      ,[homeaddress] = @homeaddress
      ,[relativesname] = @relativesname
      ,[hometel] = @hometel
      ,[positionid] = @positionid
      ,[departmentid] = @departmentid
      ,[status] = @status
      ,[sex] = @sex
      ,[birthday] = @birthday
      ,[isinsurance] = @isinsurance
      ,[entrytime] = @entrytime
      ,[quittime] = @quittime
      ,[userface] = @userface
 WHERE [storesid] = @storesid and [id]=@id", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 修改统合评价
        /// </summary>
        /// <param name="id"></param>
        /// <param name="membersatisfactionid"></param>
        /// <returns></returns>
        public int Update_membersatisfactionid(string id, string membersatisfactionid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            int icount = db.GetRowCount(@"UPDATE [Staff_member]
   SET [membersatisfactionid] = @membersatisfactionid Where [id]=@id", db.CreateParameter("@membersatisfactionid", membersatisfactionid, DbType.Int32), db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(string storesid,string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            int icount = db.GetRowCount("DELETE FROM [Staff_member] WHERE [storesid] = @storesid and [id]=@id", db.CreateParameter("@storesid", storesid, DbType.Int32), db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Staff.member Read(string storesid, string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[name]
      ,[enname]
      ,[cnid]
      ,[cnidaddress]
      ,[mobile]
      ,[email]
      ,[qq]
      ,[homeaddress]
      ,[relativesname]
      ,[hometel]
      ,[positionid]
      ,[departmentid]
      ,[status]
      ,[sex]
      ,[birthday]
      ,[isinsurance]
      ,[entrytime]
      ,[quittime]
      ,[userface]
      ,[membersatisfactionid]
  FROM [Staff_member] where [storesid] = @storesid and [id]=@id", db.CreateParameter("@storesid", storesid, DbType.Int32), db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            Model.Staff.member mModel = new Model.Staff.member();
            if (dt.Rows.Count > 0)
            {
                mModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return mModel;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Staff.member Read(string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[name]
      ,[enname]
      ,[cnid]
      ,[cnidaddress]
      ,[mobile]
      ,[email]
      ,[qq]
      ,[homeaddress]
      ,[relativesname]
      ,[hometel]
      ,[positionid]
      ,[departmentid]
      ,[status]
      ,[sex]
      ,[birthday]
      ,[isinsurance]
      ,[entrytime]
      ,[quittime]
      ,[userface]
      ,[membersatisfactionid]
  FROM [Staff_member] where [id]=@id", db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            Model.Staff.member mModel = new Model.Staff.member();
            if (dt.Rows.Count > 0)
            {
                mModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return mModel;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Model.Staff.member> ReadList(string storesid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[name]
      ,[enname]
      ,[cnid]
      ,[cnidaddress]
      ,[mobile]
      ,[email]
      ,[qq]
      ,[homeaddress]
      ,[relativesname]
      ,[hometel]
      ,[positionid]
      ,[departmentid]
      ,[status]
      ,[sex]
      ,[birthday]
      ,[isinsurance]
      ,[entrytime]
      ,[quittime]
      ,[userface]
      ,[membersatisfactionid]
  FROM [Staff_member] where [storesid] = @storesid", db.CreateParameter("@storesid", storesid, DbType.Int32));
            db.Dispose();
            List<Model.Staff.member> mList = new List<Model.Staff.member>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    mList.Add(DataRow2Model(dr));
                }
            }
            dt.Dispose();
            return mList;
        }
        /// <summary>
        /// 读取部门下员工
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Model.Staff.member> ReadList_department(string storesid, string departmentid, string statustime,string endtime)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[name]
      ,[enname]
      ,[cnid]
      ,[cnidaddress]
      ,[mobile]
      ,[email]
      ,[qq]
      ,[homeaddress]
      ,[relativesname]
      ,[hometel]
      ,[positionid]
      ,[departmentid]
      ,[status]
      ,[sex]
      ,[birthday]
      ,[isinsurance]
      ,[entrytime]
      ,[quittime]
      ,[userface]
      ,[membersatisfactionid]
  FROM [Staff_member] where [storesid] = @storesid and [departmentid]=@departmentid" + (Base.Fun.fun.IsDate(statustime) ? " and ([entrytime]>='" + statustime + "' or [quittime]>='" + statustime + "')" : "") + (Base.Fun.fun.IsDate(endtime) ? " and ([entrytime]<='" + endtime + "' or [quittime]<='" + endtime + "')" : ""), db.CreateParameter("@storesid", storesid, DbType.Int32), db.CreateParameter("@departmentid", departmentid, DbType.Int32));
            db.Dispose();
            List<Model.Staff.member> mList = new List<Model.Staff.member>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    mList.Add(DataRow2Model(dr));
                }
            }
            dt.Dispose();
            return mList;
        }
        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private Model.Staff.member DataRow2Model(DataRow dr)
        {
            Model.Staff.member mModel = new Model.Staff.member();
            mModel.id = dr["id"].ToString();
            mModel.storesid = dr["storesid"].ToString();
            mModel.name = dr["name"].ToString();
            mModel.enname = dr["enname"].ToString();
            mModel.cnid = dr["cnid"].ToString();
            mModel.cnidaddress = dr["cnidaddress"].ToString();
            mModel.mobile = dr["mobile"].ToString();
            mModel.email = dr["email"].ToString();
            mModel.qq = dr["qq"].ToString();
            mModel.homeaddress = dr["homeaddress"].ToString();
            mModel.relativesname = dr["relativesname"].ToString();
            mModel.hometel = dr["hometel"].ToString();
            mModel.positionid = dr["positionid"].ToString();
            mModel.departmentid = dr["departmentid"].ToString();
            mModel.status = dr["status"].ToString();
            mModel.sex = dr["sex"].ToString();
            mModel.birthday = dr["birthday"].ToString();
            mModel.isinsurance = dr["isinsurance"].ToString();
            mModel.entrytime = dr["entrytime"].ToString();
            mModel.quittime = dr["quittime"].ToString();
            mModel.userface = dr["userface"].ToString();
            mModel.membersatisfactionid = dr["membersatisfactionid"].ToString();
            return mModel;
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="storesid"></param>
        /// <param name="name">名字</param>
        /// <param name="status">状态</param>
        /// <param name="departmentid">部门ID</param>
        /// <returns></returns>
        public string View(int PageSize, string storesid, string name, string status, string departmentid)
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
                page.TableName = "[Staff_member] as a left join [Staff_department] as b on a.[departmentid]=b.[id] left join [Staff_position] as c on a.[positionid]=c.[id]";
                page.OrderBy = "order by a.[id] desc";
                page.Index = "a.[id]";
                page.Field = "a.[id],a.[name],a.[enname],a.[sex],a.[mobile],a.[email],a.[qq],b.[title],b.[headmemberid],a.[birthday],Datediff(YEAR,a.[birthday],getdate()),c.[title] as positionname,c.[level],a.[status],a.[isinsurance],a.[entrytime],a.[quittime]";
                List<string> Filter = new List<string>();
                Filter.Add("a.[storesid]=" + storesid);
                if (name.Length > 0)
                {
                    Filter.Add("a.[name] like '%" + name + "%'");
                }
                if (Base.Fun.fun.pnumeric(departmentid))
                {
                    Filter.Add("a.[departmentid]=" + departmentid);
                }
                page.Filter = string.Join(" and ", Filter.ToArray());
                dt = page.getrows();
                Base.Error.Error.WriteError(page.SqlString);
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
