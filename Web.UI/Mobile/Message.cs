
namespace Web.UI.Mobile
{
    public class Message
    {
        /// <summary>
        /// 读取剩余数量
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public static int GetNum(string storesid)
        {
            DAL.Mobile.Message mDAL = new DAL.Mobile.Message();
            Model.Mobile.Message mModel = mDAL.Read(storesid);
            return int.Parse(Base.Fun.fun.IsZero(mModel.num)) - int.Parse(Base.Fun.fun.IsZero(mModel.usernum));
        }
        /// <summary>
        /// 写入用１次
        /// </summary>
        /// <param name="storesid"></param>
        public static void SetNum(string storesid)
        {
            DAL.Mobile.Message mDAL = new DAL.Mobile.Message();
            mDAL.Update_UserNum(storesid, "1");
        }
    }
}
