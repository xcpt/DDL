using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.customer
{
    /// <summary>
    /// 预约日志
    /// </summary>
    public class UserappointmentLog
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="ulModel"></param>
        /// <returns></returns>
        public string Insert(Model.customer.UserappointmentLog ulModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",ulModel.storesid,DbType.Int32),
                               db.CreateParameter("@babytype",ulModel.babytype,DbType.Int32),
                               db.CreateParameter("@datenum",ulModel.datenum,DbType.Int32),
                               db.CreateParameter("@datetime",ulModel.datetime,DbType.DateTime),
                               db.CreateParameter("@weeknum",ulModel.weeknum,DbType.Int32),
                               db.CreateParameter("@hoursNum",ulModel.hoursNum,DbType.Int32),
                               db.CreateParameter("@minute",ulModel.minute,DbType.Int32),
                               db.CreateParameter("@num",ulModel.num,DbType.Int32),
                               db.CreateParameter("@usernum",ulModel.usernum,DbType.Int32),
                               db.CreateParameter("@appusernum",ulModel.appusernum,DbType.Int32),
                               db.CreateParameter("@pcusernum",ulModel.pcusernum,DbType.Int32)
                               };
            string id = db.GetNewID(@"INSERT INTO [customer_UserappointmentLog]
           ([storesid]
           ,[babytype]
           ,[datenum]
           ,[datetime]
           ,[weeknum]
           ,[hoursNum]
           ,[minute]
           ,[num]
           ,[usernum]
           ,[appusernum]
           ,[pcusernum])
     VALUES
           (@storesid
           ,@babytype
           ,@datenum
           ,@datetime
           ,@weeknum
           ,@hoursNum
           ,@minute
           ,@num
           ,@usernum
           ,@appusernum
           ,@pcusernum)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 更新数量
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public int Update(string storesid, string id, string num)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps ={
                             db.CreateParameter("@num",num,DbType.Int32),
                             db.CreateParameter("@storesid",storesid,DbType.Int32),
                             db.CreateParameter("@id",id,DbType.Int32)
                             };
            int icount = db.GetRowCount(@"UPDATE [customer_UserappointmentLog]
   SET [num] = @num
 WHERE [storesid]=@storesid and [id]=@id", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.customer.UserappointmentLog Read(string storesid, string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps ={
                             db.CreateParameter("@storesid",storesid,DbType.Int32),
                             db.CreateParameter("@id",id,DbType.Int32)
                             };
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[babytype]
      ,[datenum]
      ,[datetime]
      ,[weeknum]
      ,[hoursNum]
      ,[minute]
      ,[num]
      ,[usernum]
      ,[appusernum]
      ,[pcusernum]
  FROM [customer_UserappointmentLog] WHERE [storesid]=@storesid and [id]=@id", ps);
            db.Dispose();
            Model.customer.UserappointmentLog ulModel = new Model.customer.UserappointmentLog();
            if (dt.Rows.Count > 0)
            {
                ulModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return ulModel;
        }

        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Model.customer.UserappointmentLog> Read(string storesid, string babytype, string datenum)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps ={
                             db.CreateParameter("@storesid",storesid,DbType.Int32),
                             db.CreateParameter("@babytype",babytype,DbType.Int32),
                             db.CreateParameter("@datenum",datenum,DbType.Int32)
                             };
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[babytype]
      ,[datenum]
      ,[datetime]
      ,[weeknum]
      ,[hoursNum]
      ,[minute]
      ,[num]
      ,[usernum]
      ,[appusernum]
      ,[pcusernum]
  FROM [customer_UserappointmentLog] WHERE [storesid]=@storesid and [babytype]=@babytype and [datenum]>=@datenum order by [datenum] asc,[hoursNum] asc,[minute] asc", ps);
            db.Dispose();
            List<Model.customer.UserappointmentLog> ulList = new List<Model.customer.UserappointmentLog>();
            foreach(DataRow dr in dt.Rows)
            {
                ulList.Add(DataRow2Model(dr));
            }
            dt.Dispose();
            return ulList;
        }

        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Model.customer.UserappointmentLog> ReadOnDateNum(string storesid, string babytype, string datenum)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps ={
                             db.CreateParameter("@storesid",storesid,DbType.Int32),
                             db.CreateParameter("@babytype",babytype,DbType.Int32),
                             db.CreateParameter("@datenum",datenum,DbType.Int32)
                             };
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[babytype]
      ,[datenum]
      ,[datetime]
      ,[weeknum]
      ,[hoursNum]
      ,[minute]
      ,[num]
      ,[usernum]
      ,[appusernum]
      ,[pcusernum]
  FROM [customer_UserappointmentLog] WHERE [storesid]=@storesid and [babytype]=@babytype and [datenum]=@datenum order by [hoursNum] asc,[minute] asc", ps);
            db.Dispose();
            List<Model.customer.UserappointmentLog> ulList = new List<Model.customer.UserappointmentLog>();
            foreach (DataRow dr in dt.Rows)
            {
                ulList.Add(DataRow2Model(dr));
            }
            dt.Dispose();
            return ulList;
        }

        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.customer.UserappointmentLog Read(string storesid, string babytype, string datenum, string hoursNum, string minute)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps ={
                             db.CreateParameter("@storesid",storesid,DbType.Int32),
                             db.CreateParameter("@babytype",babytype,DbType.Int32),
                             db.CreateParameter("@datenum",datenum,DbType.Int32),
                             db.CreateParameter("@hoursNum",hoursNum,DbType.Int32),
                             db.CreateParameter("@minute",minute,DbType.Int32)
                             };
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[babytype]
      ,[datenum]
      ,[datetime]
      ,[weeknum]
      ,[hoursNum]
      ,[minute]
      ,[num]
      ,[usernum]
      ,[appusernum]
      ,[pcusernum]
  FROM [customer_UserappointmentLog] WHERE [storesid]=@storesid and [babytype]=@babytype and [datenum]=@datenum and [hoursNum]=@hoursNum and [minute]=@minute", ps);
            db.Dispose();
            Model.customer.UserappointmentLog ulModel = new Model.customer.UserappointmentLog();
            if (dt.Rows.Count > 0)
            {
                ulModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return ulModel;
        }
        /// <summary>
        /// 更新使用数量
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <param name="appusernum"></param>
        /// <param name="picusernum"></param>
        /// <returns></returns>
        public int Update_User(string storesid, string id, string appusernum, string pcusernum)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",storesid,DbType.Int32),
                               db.CreateParameter("@id",id,DbType.Int32),
                               db.CreateParameter("@appusernum",appusernum,DbType.Int32),
                               db.CreateParameter("@pcusernum",pcusernum,DbType.Int32)
                               };
            int icount = db.GetRowCount(@"UPDATE [customer_UserappointmentLog]
   SET [usernum] = [usernum]+@appusernum+@pcusernum
      ,[appusernum] =[appusernum]+ @appusernum
      ,[pcusernum] = [pcusernum]+@pcusernum
 WHERE [storesid]=@storesid and [id]=@id", ps);
            db.ExeSql(@"UPDATE [customer_UserappointmentLog]
   SET [usernum] = [pcusernum]
      ,[appusernum] =0
 WHERE [storesid]=@storesid and [id]=@id and [appusernum]<0",db.CreateParameter("@storesid",storesid,DbType.Int32),db.CreateParameter("@id",id,DbType.Int32));
            db.ExeSql(@"UPDATE [customer_UserappointmentLog]
   SET [usernum] = [appusernum]
      ,[pcusernum] =0
 WHERE [storesid]=@storesid and [id]=@id and [pcusernum]<0",db.CreateParameter("@storesid",storesid,DbType.Int32),db.CreateParameter("@id",id,DbType.Int32));
            db.Dispose();
            return icount;
        }

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private Model.customer.UserappointmentLog DataRow2Model(DataRow dr)
        {
            Model.customer.UserappointmentLog ulModel = new Model.customer.UserappointmentLog();
            ulModel.id = dr["id"].ToString();
            ulModel.storesid = dr["storesid"].ToString();
            ulModel.babytype = dr["babytype"].ToString();
            ulModel.datenum = dr["datenum"].ToString();
            ulModel.datetime = dr["datetime"].ToString();
            ulModel.weeknum = dr["weeknum"].ToString();
            ulModel.hoursNum = dr["hoursNum"].ToString();
            ulModel.minute = dr["minute"].ToString();
            ulModel.num = dr["num"].ToString();
            ulModel.usernum = dr["usernum"].ToString();
            ulModel.appusernum = dr["appusernum"].ToString();
            ulModel.pcusernum = dr["pcusernum"].ToString();
            return ulModel;
        }
    }
}
