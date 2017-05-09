
namespace Web.Model.customer
{
    /// <summary>
    /// 换卡日志
    /// </summary>
    public class CardNoLog
    {
        /// <summary>
        /// 自动编号
        /// </summary>
        public string id = "";
        /// <summary>
        /// 操作门店ID
        /// </summary>
        public string storesid = "";
        /// <summary>
        /// 老卡ID
        /// </summary>
        public string oldcardNo = "";
        /// <summary>
        /// 新卡ID
        /// </summary>
        public string newcardNo = "";
        /// <summary>
        /// 时间
        /// </summary>
        public string addtime = "";
        /// <summary>
        /// 操作人
        /// </summary>
        public string administratorid = "";
    }
}
