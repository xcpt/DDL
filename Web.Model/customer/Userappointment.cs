
namespace Web.Model.customer
{
    /// <summary>
    /// 用户预约
    /// </summary>
    public class Userappointment
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
        /// 门店ID
        /// </summary>
        public string storesid = "";
        /// <summary>
        /// 预约日期
        /// </summary>
        public string datetime = "";
        /// <summary>
        /// 添加时间
        /// </summary>
        public string addtime = "";
        /// <summary>
        /// 预约时
        /// </summary>
        public string datetimehouer = "";
        /// <summary>
        /// 预约分钟
        /// </summary>
        public string datetimeminute = "";
        /// <summary>
        /// 预约游泳老师
        /// </summary>
        public string swimteacherid = "";
        /// <summary>
        /// 泳圈
        /// </summary>
        public string mamasid = "";
        /// <summary>
        /// 是否特殊标识
        /// </summary>
        public string istop = "0";
        /// <summary>
        /// 备注
        /// </summary>
        public string content = "";
        /// <summary>
        /// 状态0预约中，1已完成，2取消，
        /// </summary>
        public string status = "0";
        /// <summary>
        /// 结算时间
        /// </summary>
        public string updatetime = "";
        /// <summary>
        /// 来源
        /// </summary>
        public string source = "";
        /// <summary>
        /// 婴儿类型
        /// </summary>
        public string cycletype = "";
    }
}
