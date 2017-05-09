
namespace Web.UI.Sys
{
    public class News
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="ClassID"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string View(string storesid, string classid, string title)
        {
            DAL.Sys.News nDAL = new DAL.Sys.News();
            return nDAL.View(UI.Sys.SiteInfo.GetPageSize(), classid, storesid, title);
        }
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="OrderID"></param>
        public static void SetOrder(string OrderID)
        {
            string[] _OrderID = OrderID.Split(',');
            Web.DAL.Sys.News nDAL = new DAL.Sys.News();
            for (int i = 0; i < _OrderID.Length; i = i + 2)
            {
                nDAL.SetOrder(Base.Fun.fun.IsZero(_OrderID[i]), Base.Fun.fun.IsZero(_OrderID[i + 1]));
            }
        }
    }
}
