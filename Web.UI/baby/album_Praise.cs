
namespace Web.UI.baby
{
    /// <summary>
    /// 点赞
    /// </summary>
    public class album_Praise
    {
        /// <summary>
        /// 保存赞
        /// </summary>
        /// <param name="albumid"></param>
        /// <param name="userid"></param>
        public static void SetLove(string albumid, string userid)
        {
            Model.baby.album_Praise apModel = new Model.baby.album_Praise();
            apModel.albumid = albumid;
            apModel.userid = userid;
            DAL.baby.album_Praise apDAL = new DAL.baby.album_Praise();
            if (!Base.Fun.fun.pnumeric(apDAL.Read(apModel)))
            {
                DAL.baby.album aDAL = new DAL.baby.album();
                aDAL.Update_Praise(userid, albumid);
            }
        }
    }
}
