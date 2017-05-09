using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.baby
{
    /// <summary>
    /// 点赞
    /// </summary>
    public class album_Praise
    {
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="apModel"></param>
        /// <returns></returns>
        public string Insert(Model.baby.album_Praise apModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@albumid",apModel.albumid,DbType.Int32),
                               db.CreateParameter("@userid",apModel.userid,DbType.Int32)
                               };
            string id = db.GetNewID(@"INSERT INTO [baby_album_Praise]
           ([albumid]
           ,[userid])
     VALUES
           (@albumid
           ,@userid)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="ap"></param>
        /// <returns></returns>
        public string Read(Model.baby.album_Praise apModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@albumid",apModel.albumid,DbType.Int32),
                               db.CreateParameter("@userid",apModel.userid,DbType.Int32)
                               };
            string id = db.GetValue(@"Select [id] From [baby_album_Praise]
           Where [albumid]=@albumid and [userid]=@userid", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="ap"></param>
        /// <returns></returns>
        public void Delete(Model.baby.album_Praise apModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@albumid",apModel.albumid,DbType.Int32),
                               db.CreateParameter("@userid",apModel.userid,DbType.Int32)
                               };
            db.ExeSql(@"Delete From [baby_album_Praise] Where [albumid]=@albumid and [userid]=@userid", ps);
            db.Dispose();
        }
    }
}
