using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.customer
{
    /// <summary>
    /// 用户关联直营店
    /// </summary>
    public class User_Stores
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="usModel"></param>
        /// <returns></returns>
        public string Insert(Model.customer.User_Stores usModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@userid",usModel.userid,DbType.Int32),
                               db.CreateParameter("@storesid",usModel.storesid,DbType.Int32),
                               db.CreateParameter("@positivenum",usModel.positivenum,DbType.Int32),
                               db.CreateParameter("@userpositivenum",usModel.userpositivenum,DbType.Int32),
                               db.CreateParameter("@surpluspositivenum",usModel.surpluspositivenum,DbType.Int32),
                               db.CreateParameter("@negativenum",usModel.negativenum,DbType.Int32),
                               db.CreateParameter("@usernegativenum",usModel.usernegativenum,DbType.Int32),
                               db.CreateParameter("@surplusnegativenum",usModel.surplusnegativenum,DbType.Int32),
                               db.CreateParameter("@surplusnum",usModel.surplusnum,DbType.Int32),
                               db.CreateParameter("@cardtypeid",usModel.cardtypeid,DbType.Int32)
                               };
            string id = db.GetValue(@"INSERT INTO [customer_User_Stores]
           ([userid]
           ,[storesid]
           ,[positivenum]
           ,[userpositivenum]
           ,[surpluspositivenum]
           ,[negativenum]
           ,[usernegativenum]
           ,[surplusnegativenum]
           ,[surplusnum]
           ,[cardtypeid])
     VALUES
           (@userid
           ,@storesid
           ,@positivenum
           ,@userpositivenum
           ,@surpluspositivenum
           ,@negativenum
           ,@usernegativenum
           ,@surplusnegativenum
           ,@surplusnum
           ,@cardtypeid)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public Model.customer.User_Stores Read(string storesid, string userid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",storesid,DbType.Int32),
                               db.CreateParameter("@userid",userid,DbType.Int32)
                               };
            DataTable dt = db.GetData(@"SELECT [id]
      ,[userid]
      ,[storesid]
      ,[positivenum]
      ,[userpositivenum]
      ,[surpluspositivenum]
      ,[negativenum]
      ,[usernegativenum]
      ,[surplusnegativenum]
      ,[surplusnum]
      ,[cardtypeid]
  FROM [customer_User_Stores] Where [storesid]=@storesid and [userid]=@userid", ps);
            db.Dispose();
            Model.customer.User_Stores usModel = new Model.customer.User_Stores();
            if (dt.Rows.Count > 0)
            {
                usModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return usModel;
        }
        /// <summary>
        /// 读取非本店的其它店的卡信息，并且有次数的
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public Model.customer.User_Stores ReadOther(string StoresID, string userid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@userid",userid,DbType.Int32),
                               db.CreateParameter("@StoresID",StoresID,DbType.Int32)
                               };
            DataTable dt = db.GetData(@"SELECT top 1 [id]
      ,[userid]
      ,[storesid]
      ,[positivenum]
      ,[userpositivenum]
      ,[surpluspositivenum]
      ,[negativenum]
      ,[usernegativenum]
      ,[surplusnegativenum]
      ,[surplusnum]
      ,[cardtypeid]
  FROM [customer_User_Stores] Where [userid]=@userid and [StoresID]<>@StoresID and [surplusnum]>0 order by [id] asc", ps);
            db.Dispose();
            Model.customer.User_Stores usModel = new Model.customer.User_Stores();
            if (dt.Rows.Count > 0)
            {
                usModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return usModel;
        }

        /// <summary>
        /// 读取非本店的其它店的次数
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public void ReadNum(string storesid, string userid, ref string surpluspositivenum, ref string surplusnegativenum)
        {
            surplusnegativenum = "0";
            surpluspositivenum = "0";
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@userid",userid,DbType.Int32),
                               db.CreateParameter("@storesid",storesid,DbType.Int32)
                               };
            DataTable dt = db.GetData(@"SELECT sum([surpluspositivenum])
      ,sum([surplusnegativenum])
  FROM [customer_User_Stores] Where [userid]=@userid and [storesid]<>@storesid", ps);
            db.Dispose();
            if (dt.Rows.Count > 0)
            {
                surplusnegativenum = Base.Fun.fun.IsZero(dt.Rows[0][1].ToString());
                surpluspositivenum = Base.Fun.fun.IsZero(dt.Rows[0][0].ToString());
            }
            dt.Dispose();
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="usModel"></param>
        /// <returns></returns>
        public int Update(Model.customer.User_Stores usModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@positivenum",usModel.positivenum,DbType.Int32),
                               db.CreateParameter("@surpluspositivenum",usModel.surpluspositivenum,DbType.Int32),
                               db.CreateParameter("@negativenum",usModel.negativenum,DbType.Int32),
                               db.CreateParameter("@surplusnegativenum",usModel.surplusnegativenum,DbType.Int32),
                               db.CreateParameter("@surplusnum",usModel.surplusnum,DbType.Int32),
                               db.CreateParameter("@cardtypeid",usModel.cardtypeid,DbType.Int32),
                               db.CreateParameter("@id",usModel.id,DbType.Int32)
                               };
            int icount = db.GetRowCount(@"UPDATE [customer_User_Stores]
   SET [positivenum] = @positivenum
      ,[surpluspositivenum] = @surpluspositivenum
      ,[negativenum] = @negativenum
      ,[surplusnegativenum] = @surplusnegativenum
      ,[surplusnum] = @surplusnum
      ,[cardtypeid] = @cardtypeid
 WHERE [id]=@id", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 更新使用正价次数1次
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Update_UserPositivenum(string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            int icount = db.GetRowCount(@"UPDATE [customer_User_Stores]
   SET [positivenum] = [positivenum]-1
      ,[userpositivenum] = [userpositivenum]+1
      ,[surpluspositivenum] = [surpluspositivenum]-1
      ,[surplusnum] = [surplusnum]-1
 WHERE [id]=@id", db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 更新使用赠送次数1次
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Update_UserNegativenum(string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            int icount = db.GetRowCount(@"UPDATE [customer_User_Stores]
   SET [negativenum] = [negativenum]-1
      ,[usernegativenum] = [usernegativenum]+1
      ,[surplusnegativenum] = [surplusnegativenum]-1
      ,[surplusnum] = [surplusnum]-1
 WHERE [id]=@id", db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private Model.customer.User_Stores DataRow2Model(DataRow dr)
        {
            Model.customer.User_Stores usModel = new Model.customer.User_Stores();
            usModel.id = dr["id"].ToString();
            usModel.userid = dr["userid"].ToString();
            usModel.storesid = dr["storesid"].ToString();
            usModel.positivenum = int.Parse(dr["positivenum"].ToString());
            usModel.userpositivenum = int.Parse(dr["userpositivenum"].ToString());
            usModel.surpluspositivenum = int.Parse(dr["surpluspositivenum"].ToString());
            usModel.negativenum = int.Parse(dr["negativenum"].ToString());
            usModel.usernegativenum = int.Parse(dr["usernegativenum"].ToString());
            usModel.surplusnegativenum = int.Parse(dr["surplusnegativenum"].ToString());
            usModel.surplusnum = int.Parse(dr["surplusnum"].ToString());
            usModel.cardtypeid = dr["cardtypeid"].ToString();
            return usModel;
        }
    }
}
