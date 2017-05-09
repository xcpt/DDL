
namespace Web.Model.customer
{
    /// <summary>
    /// 卡日志
    /// </summary>
    public class CardLog
    {
        /// <summary>
        /// 自动编号
        /// </summary>
        public string id = "";
        /// <summary>
        /// 卡ID
        /// </summary>
        public string cardid = "";
        /// <summary>
        /// 操作门店
        /// </summary>
        public string storesid = "";
        /// <summary>
        /// 变更类型{ "1", "续卡" }, { "2", "调整" }, { "3", "建卡" }, { "4", "停卡" }, { "5", "重开卡" }
        /// </summary>
        public string cardlogtype = "";
        /// <summary>
        /// 操作时间
        /// </summary>
        public string addtime = "";
        /// <summary>
        /// 管理员ID
        /// </summary>
        public string administratorid = "";

        /// <summary>
        /// 原过期日期
        /// </summary>
        public string oldendtime = "";
        /// <summary>
        /// 现过期日期
        /// </summary>
        public string newendtime = "";
        /// <summary>
        /// 重新开卡日期
        /// </summary>
        public string opentime = "";
        /// <summary>
        /// 原卡次
        /// </summary>
        public string oldnum = "";
        /// <summary>
        /// 现卡次
        /// </summary>
        public string newnum = "";
        /// <summary>
        /// 原金额
        /// </summary>
        public string oldprice = "";
        /// <summary>
        /// 新增金额
        /// </summary>
        public string newprice = "";
        /// <summary>
        /// 原卡类型
        /// </summary>
        public string oldcardtype = "";
        /// <summary>
        /// 新卡类型
        /// </summary>
        public string newcardtype = "";
    }
}
