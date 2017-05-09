using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.Staff
{
    /// <summary>
    /// 工资分类显示
    /// </summary>
    public class WageList
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="wlModel"></param>
        /// <returns></returns>
        public string Insert(Model.Staff.WageList wlModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@wagemonthid",wlModel.wagemonthid,DbType.Int32),
                               db.CreateParameter("@performanceType",wlModel.performanceType,DbType.Int32),
                               db.CreateParameter("@money",wlModel.money,DbType.Double)
                               };
            string id = db.GetNewID(@"INSERT INTO [Staff_WageList]
           ([wagemonthid]
           ,[performanceType]
           ,[money])
     VALUES
           (@wagemonthid
           ,@performanceType
           ,@money)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="wlModel"></param>
        /// <returns></returns>
        public int Update(Model.Staff.WageList wlModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@wagemonthid",wlModel.wagemonthid,DbType.Int32),
                               db.CreateParameter("@performanceType",wlModel.performanceType,DbType.Int32),
                               db.CreateParameter("@money",wlModel.money,DbType.Double),
                               db.CreateParameter("@id",wlModel.id,DbType.Int32)
                               };
            int icount = db.GetRowCount(@"UPDATE [Staff_WageList]
   SET [wagemonthid] = @wagemonthid
      ,[performanceType] = @performanceType
      ,[money] = @money
 WHERE [id]=@id", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 读取信息
        /// </summary>
        /// <param name="wagemonthid"></param>
        /// <param name="performanceType"></param>
        /// <returns></returns>
        public Model.Staff.WageList Read(string wagemonthid, string performanceType)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@wagemonthid",wagemonthid,DbType.Int32),
                               db.CreateParameter("@performanceType",performanceType,DbType.Int32)
                               };
            DataTable dt = db.GetData(@"SELECT [id]
      ,[wagemonthid]
      ,[performanceType]
      ,[money]
  FROM [Staff_WageList] Where [wagemonthid]=@wagemonthid and [performanceType]=@performanceType", ps);
            db.Dispose();
            Model.Staff.WageList wlModel = new Model.Staff.WageList();
            if (dt.Rows.Count > 0)
            {
                wlModel.wagemonthid = dt.Rows[0]["wagemonthid"].ToString();
                wlModel.performanceType = dt.Rows[0]["performanceType"].ToString();
                wlModel.money = dt.Rows[0]["money"].ToString();
                wlModel.id = dt.Rows[0]["id"].ToString();
            }
            dt.Dispose();
            return wlModel;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="wagemonthid"></param>
        /// <returns></returns>
        public List<Model.Staff.WageList> ReadList(string wagemonthid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@wagemonthid",wagemonthid,DbType.Int32)
                               };
            DataTable dt = db.GetData(@"SELECT [id]
      ,[wagemonthid]
      ,[performanceType]
      ,[money]
  FROM [Staff_WageList] Where [wagemonthid]=@wagemonthid order by [performanceType],[id] desc", ps);
            db.Dispose();
            List<Model.Staff.WageList> wlList = new List<Model.Staff.WageList>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Model.Staff.WageList wlModel = new Model.Staff.WageList();
                    wlModel.wagemonthid = dr["wagemonthid"].ToString();
                    wlModel.performanceType = dr["performanceType"].ToString();
                    wlModel.money = dr["money"].ToString();
                    wlModel.id = dr["id"].ToString();
                    wlList.Add(wlModel);
                }
            }
            dt.Dispose();
            return wlList;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int Delete(string ids)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            int icount = db.GetRowCount(@"DELETE FROM [Staff_WageList] WHERE [id] in(" + ids + ")");
            db.Dispose();
            return icount;
        }
    }
}
