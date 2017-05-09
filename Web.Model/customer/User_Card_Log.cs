
namespace Web.Model.customer
{
    /// <summary>
    /// 用户卡日志
    /// </summary>
    public class User_Card_Log
    {
        /// <summary>
        /// ID
        /// </summary>
        public string id = "";
        /// <summary>
        /// 用户ID
        /// </summary>
        public string userid = "";
        /// <summary>
        /// 店ID
        /// </summary>
        public string storesid = "";
        /// <summary>
        /// 卡类型
        /// </summary>
        public string cardtypeid = "";
        /// <summary>
        /// 剩余数量
        /// </summary>
        public int num = 0;
        /// <summary>
        /// 价格
        /// </summary>
        public double price = 0;
        /// <summary>
        /// 总数量
        /// </summary>
        public int cardnum = 0;
        /// <summary>
        /// 总价格
        /// </summary>
        public double cardprice = 0;
    }
}
