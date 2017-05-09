
namespace Web.Model.customer
{
    /// <summary>
    /// 用户跨店消费
    /// </summary>
    public class User_Stores_Consumption
    {
        /// <summary>
        /// 自动编号
        /// </summary>
        public string id = "";
        /// <summary>
        /// 用户ID
        /// </summary>
        public string userid = "";
        /// <summary>
        /// 用户卡原店ID
        /// </summary>
        public string cardstoresid = "";
        /// <summary>
        /// 消费店ID
        /// </summary>
        public string consumptionstoresid = "";
        /// <summary>
        /// 价格
        /// </summary>
        public string price = "";
        /// <summary>
        /// 添加时间
        /// </summary>
        public string addtime = "";
        /// <summary>
        /// 消费ID
        /// </summary>
        public string consumptionid = "";
        /// <summary>
        /// 交易是否已经结算
        /// </summary>
        public string isclose = "0";
    }
}
