using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.customer
{
    /// <summary>
    /// 用户卡日志
    /// </summary>
    public class User_Card_Log
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="uclModel"></param>
        /// <returns></returns>
        public string Insert(Model.customer.User_Card_Log uclModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps ={
                             db.CreateParameter("@userid",uclModel.userid,DbType.Int32),
                             db.CreateParameter("@storesid",uclModel.storesid,DbType.Int32),
                             db.CreateParameter("@cardtypeid",uclModel.cardtypeid,DbType.Int32),
                             db.CreateParameter("@num",uclModel.num,DbType.Int32),
                             db.CreateParameter("@price",uclModel.price.ToString("f2"),DbType.Double),
                             db.CreateParameter("@cardnum",uclModel.cardnum,DbType.Int32),
                             db.CreateParameter("@cardprice",uclModel.cardprice.ToString("f2"),DbType.Double),
                             db.CreateParameter("@updatetime",DateTime.Now,DbType.DateTime)
                             };
            string id = db.GetNewID(@"INSERT INTO [customer_User_Card_Log]
           ([userid]
           ,[storesid]
           ,[cardtypeid]
           ,[num]
           ,[price]
           ,[cardnum]
           ,[cardprice]
           ,[updatetime])
     VALUES
           (@userid
           ,@storesid
           ,@cardtypeid
           ,@num
           ,@price
           ,@cardnum
           ,@cardprice
           ,@updatetime)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="uclModel"></param>
        /// <returns></returns>
        public int Update(Model.customer.User_Card_Log uclModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps ={
                              db.CreateParameter("@userid",uclModel.userid,DbType.Int32),
                              db.CreateParameter("@storesid",uclModel.storesid,DbType.Int32),
                              db.CreateParameter("@cardtypeid",uclModel.cardtypeid,DbType.Int32),
                              db.CreateParameter("@num",uclModel.num,DbType.Int32),
                              db.CreateParameter("@price",uclModel.price.ToString("f2"),DbType.Double),
                              db.CreateParameter("@cardnum",uclModel.cardnum,DbType.Int32),
                              db.CreateParameter("@cardprice",uclModel.cardprice.ToString("f2"),DbType.Double),
                              db.CreateParameter("@updatetime",DateTime.Now,DbType.DateTime),
                              db.CreateParameter("@id",uclModel.id,DbType.Int32)
                             };
            int icount = db.GetRowCount(@"UPDATE [customer_User_Card_Log]
   SET [userid] = @userid
      ,[storesid]=@storesid
      ,[cardtypeid] = @cardtypeid
      ,[num] = @num
      ,[price] = @price
      ,[cardnum] = @cardnum
      ,[cardprice] = @cardprice
      ,[updatetime] = @updatetime
 WHERE [id]=@id", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="cardtypeid"></param>
        /// <returns></returns>
        public Model.customer.User_Card_Log Select(string UserID, string storesid, string cardtypeid, int cardnum, double cardprice)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@userid",UserID,DbType.Int32),
                               db.CreateParameter("@storesid",storesid,DbType.Int32),
                               db.CreateParameter("@cardtypeid",cardtypeid,DbType.Int32),
                               db.CreateParameter("@cardnum",cardnum,DbType.Int32),
                               db.CreateParameter("@cardprice",cardprice,DbType.Double)
                               };
            DataTable dt = db.GetData(@"SELECT [id]
      ,[userid]
      ,[storesid]
      ,[cardtypeid]
      ,[num]
      ,[price]
      ,[cardnum]
      ,[cardprice]
      ,[updatetime]
  FROM [customer_User_Card_Log] Where [userid]=@userid and [storesid]=@storesid and [cardtypeid]=@cardtypeid and [cardnum]=@cardnum and [cardprice]=@cardprice", ps);
            db.Dispose();
            Model.customer.User_Card_Log uclModel = new Model.customer.User_Card_Log();
            if (dt.Rows.Count > 0)
            {
                uclModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return uclModel;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="cardtypeid"></param>
        /// <returns></returns>
        public Model.customer.User_Card_Log Select(string UserID, string storesid, string cardtypeid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@userid",UserID,DbType.Int32),
                               db.CreateParameter("@storesid",storesid,DbType.Int32),
                               db.CreateParameter("@cardtypeid",cardtypeid,DbType.Int32)
                               };
            DataTable dt = db.GetData(@"SELECT [id]
      ,[userid]
      ,[storesid]
      ,[cardtypeid]
      ,[num]
      ,[price]
      ,[cardnum]
      ,[cardprice]
      ,[updatetime]
  FROM [customer_User_Card_Log] Where [userid]=@userid and [storesid]=@storesid and [cardtypeid]=@cardtypeid order by [id] desc", ps);
            db.Dispose();
            Model.customer.User_Card_Log uclModel = new Model.customer.User_Card_Log();
            if (dt.Rows.Count > 0)
            {
                uclModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return uclModel;
        }
        /// <summary>
        /// 读取,最早的可用的用户卡信息
        /// </summary>
        /// <returns></returns>
        public Model.customer.User_Card_Log Read(string storesid,string UserID)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@userid",UserID,DbType.Int32),
                               db.CreateParameter("@storesid",storesid,DbType.Int32)
                               };
            DataTable dt = db.GetData(@"SELECT top 1 [id]
      ,[userid]
      ,[storesid]
      ,[cardtypeid]
      ,[num]
      ,[price]
      ,[cardnum]
      ,[cardprice]
      ,[updatetime]
  FROM [customer_User_Card_Log] Where [userid]=@userid and [storesid]=@storesid and [num]>0 order by [updatetime] asc", ps);
            db.Dispose();
            Model.customer.User_Card_Log uclModel = new Model.customer.User_Card_Log();
            if (dt.Rows.Count > 0)
            {
                uclModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return uclModel;
        }
        /// <summary>
        /// 更新消费一次
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Update_Consumption(string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            int icount = db.GetRowCount(@"UPDATE [customer_User_Card_Log]
   SET [num] = [num]-1
 WHERE [id]=@id", db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 转码
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private Model.customer.User_Card_Log DataRow2Model(DataRow dr)
        {
            Model.customer.User_Card_Log uclModel = new Model.customer.User_Card_Log();
            uclModel.id = dr["id"].ToString();
            uclModel.userid = dr["userid"].ToString();
            uclModel.storesid = dr["storesid"].ToString();
            uclModel.cardtypeid = dr["cardtypeid"].ToString();
            uclModel.num = int.Parse(dr["num"].ToString());
            uclModel.price = float.Parse(dr["price"].ToString());
            uclModel.cardnum = int.Parse(dr["cardnum"].ToString());
            uclModel.cardprice = float.Parse(dr["cardprice"].ToString());
            return uclModel;
        }
    }
}