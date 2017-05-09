
namespace Web.Model.Sys
{
    /// <summary>
    /// 商品
    /// </summary>
    public class Commodity
    {
        /// <summary>
        /// 自动编号
        /// </summary>
        public string id = "";
        /// <summary>
        /// 店店ID
        /// </summary>
        public string storesid = "";
        /// <summary>
        /// 商品名称
        /// </summary>
        public string title = "";
        /// <summary>
        /// 商品价格
        /// </summary>
        public string price = "";
        /// <summary>
        /// 卡次消费
        /// </summary>
        public string iscard = "0";
        /// <summary>
        /// 添加时间
        /// </summary>
        public string addtime = "";
        /// <summary>
        /// 删除0，1
        /// </summary>
        public string isdel = "0";
        /// <summary>
        /// 添加积分数
        /// </summary>
        public string score = "0";
    }
}
