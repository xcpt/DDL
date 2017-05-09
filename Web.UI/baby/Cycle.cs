
namespace Web.UI.baby
{
    /// <summary>
    /// 成长周期
    /// </summary>
    public class Cycle
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="title"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string View(string title, string type)
        {
            DAL.baby.Cycle cDAL = new DAL.baby.Cycle();
            return cDAL.View(UI.Sys.SiteInfo.GetPageSize(), title, type);
        }
    }
}
