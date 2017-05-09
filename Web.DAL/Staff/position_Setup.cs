using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.Staff
{
    public class position_Setup
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="psModel"></param>
        /// <returns></returns>
        public string Insert(Model.Staff.position_Setup psModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@satisfactionid",psModel.satisfactionid,DbType.Int32),
                               db.CreateParameter("@price",psModel.price,DbType.Double),
                               db.CreateParameter("@storesid",psModel.satisfactionid,DbType.Int32)
                               };
            string id = db.GetNewID(@"INSERT INTO [Staff_position_Setup]
           ([satisfactionid]
           ,[price]
           ,[storesid])
     VALUES
           (@satisfactionid
           ,@price
           ,@storesid)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="psModel"></param>
        /// <returns></returns>
        public int Update(Model.Staff.position_Setup psModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@price",psModel.price,DbType.Double),
                               db.CreateParameter("@satisfactionid",psModel.satisfactionid,DbType.Int32),
                               db.CreateParameter("@storesid",psModel.satisfactionid,DbType.Int32)
                               };
            int icount = db.GetRowCount(@"UPDATE [Staff_position_Setup]
   SET [price] = @price
 WHERE [satisfactionid] = @satisfactionid and [storesid] = @storesid", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 读取列表
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public List<Model.Staff.position_Setup> ReadList(string storesid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [satisfactionid]
      ,[price]
      ,[storesid]
  FROM [Staff_position_Setup] Where [storesid]=@storesid order by [satisfactionid] asc", db.CreateParameter("@storesid", storesid, DbType.Int32));
            db.Dispose();
            List<Model.Staff.position_Setup> psList = new List<Model.Staff.position_Setup>();
            foreach (DataRow dr in dt.Rows)
            {
                Model.Staff.position_Setup psModel = new Model.Staff.position_Setup();
                psModel.satisfactionid = dr["satisfactionid"].ToString();
                psModel.price = dr["price"].ToString();
                psModel.storesid = dr["storesid"].ToString();
                psList.Add(psModel);
            }
            dt.Dispose();
            return psList;
        }
    }
}
