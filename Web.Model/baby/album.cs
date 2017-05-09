
namespace Web.Model.baby
{
    /// <summary>
    /// 成长相册
    /// </summary>
    public class album
    {
        /// <summary>
        /// 自动编号
        /// </summary>
        public string id = "";
        /// <summary>
        /// 月龄
        /// </summary>
        public string monthage = "";
        /// <summary>
        /// 客户ID
        /// </summary>
        public string UserID = "";
        /// <summary>
        /// 图片地址
        /// </summary>
        public string picurl = "";
        /// <summary>
        /// 图片MD5
        /// </summary>
        public string picmd5 = "";
        /// <summary>
        /// 照片时间
        /// </summary>
        public string addtime = "";
        /// <summary>
        /// 点赞
        /// </summary>
        public string Praise = "0";
        /// <summary>
        /// 单照片人气
        /// </summary>
        public string hits = "0";
    }
}
