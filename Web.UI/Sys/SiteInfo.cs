
namespace Web.UI.Sys
{
    public class SiteInfo
    {
        /// <summary>
        /// 分页数量
        /// </summary>
        /// <returns></returns>
        public static int GetPageSize()
        {
            return 15;
        }
        public const string VerSion = "0.0010";
        /// <summary>
        /// 缓存时间
        /// </summary>
        public const int CacheTime=60000;
        /// <summary>
        /// 上传目录
        /// </summary>
        public const string UpFile = "/UpFile/";
        /// <summary>
        /// 最大分页
        /// </summary>
        public static string MaxPage = "1000000";
    }
}
