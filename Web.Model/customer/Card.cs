
namespace Web.Model.customer
{
    /// <summary>
    /// 会员卡
    /// </summary>
    public class Card
    {
        /// <summary>
        /// 号自动编号
        /// </summary>
        public string cardid = "";
        /// <summary>
        /// 门店ID
        /// </summary>
        public string storesid = "";
        /// <summary>
        /// 卡号
        /// </summary>
        public string cardNo = "";
        /// <summary>
        /// 卡码
        /// </summary>
        public string cardNumber = "";
        /// <summary>
        /// 正价次数
        /// </summary>
        public string positivenum = "0";
        /// <summary>
        /// 已使用正价次数
        /// </summary>
        public string userpositivenum = "0";
        /// <summary>
        /// 剩余正价次数
        /// </summary>
        public string surpluspositivenum = "0";
        /// <summary>
        /// 赠送次数
        /// </summary>
        public string negativenum = "0";
        /// <summary>
        /// 已使用赠送次数
        /// </summary>
        public string usernegativenum = "0";
        /// <summary>
        /// 剩余赠送次数
        /// </summary>
        public string surplusnegativenum = "0";
        /// <summary>
        /// 剩余次数
        /// </summary>
        public string surplusnum = "0";
        /// <summary>
        /// 现有金额
        /// </summary>
        public string price = "0";
        /// <summary>
        /// 已使用金额
        /// </summary>
        public string userprice = "0";
        /// <summary>
        /// 剩余金额
        /// </summary>
        public string surplusprice = "0";
        /// <summary>
        /// 生效日期
        /// </summary>
        public string starttime = "";
        /// <summary>
        /// 失效日期
        /// </summary>
        public string endtime = "";
        /// <summary>
        /// 停止到什么时间
        /// </summary>
        public string stoptime = "";
        /// <summary>
        /// 停止限制
        /// </summary>
        public string isclose = "0";
        /// <summary>
        /// 卡类型
        /// </summary>
        public string cardtypeid = "";
        /// <summary>
        /// 卡状态,1为正常，-1为停卡
        /// </summary>
        public string cardstatus = "1";
        /// <summary>
        /// 添加时间
        /// </summary>
        public string addtime = "";
        /// <summary>
        /// 卡类型Model
        /// </summary>
        public CardType ctModel = new CardType();
    }
}
