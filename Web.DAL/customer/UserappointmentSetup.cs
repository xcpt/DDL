using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.customer
{
    /// <summary>
    /// 预约配置
    /// </summary>
    public class UserappointmentSetup
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="usModel"></param>
        /// <returns></returns>
        public string Insert(Model.customer.UserappointmentSetup usModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",usModel.storesid,DbType.Int32),
                               db.CreateParameter("@babytype",usModel.babytype,DbType.Int32),
                               db.CreateParameter("@weeknum",usModel.weeknum,DbType.Int32),
                               db.CreateParameter("@hoursNum",usModel.hoursNum,DbType.Int32),
                               db.CreateParameter("@minute",usModel.minute,DbType.Int32),
                               db.CreateParameter("@num",usModel.num,DbType.Int32)
                               };
            string id = db.GetNewID(@"INSERT INTO [customer_UserappointmentSetup]
           ([storesid]
           ,[babytype]
           ,[weeknum]
           ,[hoursNum]
           ,[minute]
           ,[num])
     VALUES
           (@storesid
           ,@babytype
           ,@weeknum
           ,@hoursNum
           ,@minute
           ,@num)",ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="msModel"></param>
        /// <returns></returns>
        public int Update(Model.customer.UserappointmentSetup usModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@babytype",usModel.babytype,DbType.Int32),
                               db.CreateParameter("@weeknum",usModel.weeknum,DbType.Int32),
                               db.CreateParameter("@hoursNum",usModel.hoursNum,DbType.Int32),
                               db.CreateParameter("@minute",usModel.minute,DbType.Int32),
                               db.CreateParameter("@num",usModel.num,DbType.Int32),
                               db.CreateParameter("@storesid",usModel.storesid,DbType.Int32),
                               db.CreateParameter("@id",usModel.id,DbType.Int32)
                               };
            int icount = db.GetRowCount(@"UPDATE [customer_UserappointmentSetup]
   SET [babytype] = @babytype
      ,[weeknum] = @weeknum
      ,[hoursNum] = @hoursNum
      ,[minute] = @minute
      ,[num] = @num
 WHERE [storesid]=@storesid and [id]=@id", ps);
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
            int icount = db.GetRowCount("DELETE FROM [customer_UserappointmentSetup] WHERE [storesid]=@storesid and [id]=@id", db.CreateParameter("@storesid", storesid, DbType.Int32), db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public List<Model.customer.UserappointmentSetup> ReadList(string storesid, string babytype)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[babytype]
      ,[weeknum]
      ,[hoursNum]
      ,[minute]
      ,[num]
  FROM [customer_UserappointmentSetup] Where [storesid]=@storesid and [babytype]=@babytype order by [weeknum] asc,[hoursNum] asc,[minute] asc", db.CreateParameter("@storesid", storesid, DbType.Int32), db.CreateParameter("@babytype", babytype,DbType.Int32));
            db.Dispose();
            List<Model.customer.UserappointmentSetup> usList = new List<Model.customer.UserappointmentSetup>();
            foreach (DataRow dr in dt.Rows)
            {
                usList.Add(DataRow2Model(dr));
            }
            dt.Dispose();
            return usList;
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.customer.UserappointmentSetup Read(string storesid, string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[babytype]
      ,[weeknum]
      ,[hoursNum]
      ,[minute]
      ,[num]
  FROM [customer_UserappointmentSetup]
  where [storesid]=@storesid and [id]=@id", db.CreateParameter("@storesid", storesid, DbType.Int32), db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            Model.customer.UserappointmentSetup usModel = new Model.customer.UserappointmentSetup();
            if (dt.Rows.Count > 0)
            {
                usModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return usModel;
        }

        /// <summary>
        /// 读取是否存在
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.customer.UserappointmentSetup Read(string storesid, string weeknum, string hoursNum, string minute, string babytype)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[babytype]
      ,[weeknum]
      ,[hoursNum]
      ,[minute]
      ,[num]
  FROM [customer_UserappointmentSetup]
   where [storesid]=@storesid and [weeknum]=@weeknum and [hoursNum]=@hoursNum and [minute]=@minute and [babytype]=@babytype", db.CreateParameter("@storesid", storesid, DbType.Int32), db.CreateParameter("@weeknum", weeknum, DbType.Int32), db.CreateParameter("@hoursNum", hoursNum, DbType.Int32), db.CreateParameter("@minute", minute, DbType.Int32), db.CreateParameter("@babytype", babytype,DbType.Int32));
            db.Dispose();
            Model.customer.UserappointmentSetup usModel = new Model.customer.UserappointmentSetup();
            if (dt.Rows.Count > 0)
            {
                usModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return usModel;
        }

        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private Model.customer.UserappointmentSetup DataRow2Model(DataRow dr)
        {
            Model.customer.UserappointmentSetup usModel = new Model.customer.UserappointmentSetup();
            usModel.id = dr["id"].ToString();
            usModel.storesid = dr["storesid"].ToString();
            usModel.babytype = dr["babytype"].ToString();
            usModel.weeknum = dr["weeknum"].ToString();
            usModel.hoursNum = dr["hoursNum"].ToString();
            usModel.minute = dr["minute"].ToString();
            usModel.num = dr["num"].ToString();
            return usModel;
        }
    }
}
