
namespace Web.UI.score
{
    public class exchange
    {
        /// <summary>
        /// 积分对换
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="name"></param>
        /// <param name="title"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public static string View(string storesid, string userid, string name, string title, string starttime, string endtime)
        {
            DAL.score.exchange eDAL = new DAL.score.exchange();
            return eDAL.View(UI.Sys.SiteInfo.GetPageSize(), storesid, userid, name, title, starttime, endtime);
        }
    }
}
