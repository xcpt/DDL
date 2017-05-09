
namespace Web.UI.baby
{
    /// <summary>
    /// 成长相册
    /// </summary>
    public class album
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="CardNo"></param>
        /// <param name="MonthAge"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        public static string View(string storesid, string userid, string CardNo, string MonthAge, string StartTime, string EndTime)
        {
            DAL.baby.album aDAL = new DAL.baby.album();
            return aDAL.View(UI.Sys.SiteInfo.GetPageSize(), storesid, userid, CardNo, MonthAge, StartTime, EndTime);
        }
    }
}
