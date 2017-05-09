
namespace Web.Model.customer
{
    /// <summary>
    /// 卡类型
    /// </summary>
    public class CardType
    {
        /// <summary>
        /// 自动编号
        /// </summary>
        public string id = "";
        /// <summary>
        /// 门店ID
        /// </summary>
        public string storesid = "0";
        /// <summary>
        /// 卡名称
        /// </summary>
        public string title = "";
        /// <summary>
        /// 业务类型
        /// </summary>
        public string businessid = "0";
        /// <summary>
        /// 有效时长
        /// </summary>
        public string effectivetime = "";
        /// <summary>
        /// 0按次,按金额
        /// </summary>
        public string paidmode = "0";
        /// <summary>
        /// 正价次数
        /// </summary>
        public string positivenum = "0";
        /// <summary>
        /// 赠送次数
        /// </summary>
        public string negativenum = "0";
        /// <summary>
        /// 金额
        /// </summary>
        public string price = "0";
        /// <summary>
        /// 折扣
        /// </summary>
        public string discount = "100";
        /// <summary>
        /// 开卡送积分
        /// </summary>
        public string opencardexchange = "0";
        /// <summary>
        /// 备注
        /// </summary>
        public string content = "";
    }
}
