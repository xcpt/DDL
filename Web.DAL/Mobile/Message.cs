using System.Data;
using System.Data.Common;

namespace Web.DAL.Mobile
{
    /// <summary>
    /// 门店短消息数量
    /// </summary>
    public class Message
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="mModel"></param>
        /// <returns></returns>
        public string Insert(Model.Mobile.Message mModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",mModel.storesid,DbType.Int32),
                               db.CreateParameter("@num",mModel.num,DbType.Int32),
                               db.CreateParameter("@usernum",mModel.usernum,DbType.Int32)
                               };
            string id = db.GetNewID(@"INSERT INTO [Mobile_Message]
           ([storesid]
           ,[num]
           ,[usernum])
     VALUES
           (@storesid
           ,@num
           ,@usernum)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 添加发送次数
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="usernum"></param>
        /// <returns></returns>
        public int Update_UserNum(string storesid, string usernum)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@usernum",usernum,DbType.Int32),
                               db.CreateParameter("@storesid",storesid,DbType.Int32)
                               };
            int icount = db.GetRowCount(@"UPDATE [Mobile_Message]
   SET [usernum] = [usernum]+@usernum
 WHERE [storesid] = @storesid", ps);
            db.Dispose();
            return icount;
        }

        /// <summary>
        /// 添加总发送次数
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="usernum"></param>
        /// <returns></returns>
        public int Update_Num(string storesid, string num)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@num",num,DbType.Int32),
                               db.CreateParameter("@storesid",storesid,DbType.Int32)
                               };
            int icount = db.GetRowCount(@"UPDATE [Mobile_Message]
   SET [num] = [num]+@num
 WHERE [storesid] = @storesid", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 读取单条
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public Model.Mobile.Message Read(string storesid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[num]
      ,[usernum]
  FROM [Mobile_Message] Where [storesid]=@storesid", db.CreateParameter("@storesid", storesid, DbType.Int32));
            db.Dispose();
            Model.Mobile.Message mModel = new Model.Mobile.Message();
            if (dt.Rows.Count > 0)
            {
                mModel.id = dt.Rows[0]["id"].ToString();
                mModel.storesid = dt.Rows[0]["storesid"].ToString();
                mModel.num = dt.Rows[0]["num"].ToString();
                mModel.usernum = dt.Rows[0]["usernum"].ToString();
            }
            dt.Dispose();
            return mModel;
        }
    }
}
