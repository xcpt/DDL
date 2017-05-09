
namespace Web.Model.customer
{
    /// <summary>
    /// 预约日志
    /// </summary>
    public class UserappointmentLog
    {
        /// <summary>
        /// 自动编号
        /// </summary>
        public string id = "";
        /// <summary>
        /// 门店ID
        /// </summary>
        public string storesid = "";
        /// <summary>
        /// 类型
        /// </summary>
        public string babytype = "0";
        /// <summary>
        /// 时间值
        /// </summary>
        public string datenum = "";
        /// <summary>
        /// 时间串
        /// </summary>
        public string datetime = "";
        /// <summary>
        /// 星期几
        /// </summary>
        public string weeknum = "1";
        /// <summary>
        /// 小时时间段
        /// </summary>
        public string hoursNum = "9";
        /// <summary>
        /// 分钟
        /// </summary>
        public string minute = "0";
        /// <summary>
        /// 可预约数据
        /// </summary>
        public string num = "0";

        /// <summary>
        /// 已使用数量
        /// </summary>
        public string usernum = "0";
        /// <summary>
        /// APP已经预约数
        /// </summary>
        public string appusernum = "0";
        /// <summary>
        /// 电脑已经预约数
        /// </summary>
        public string pcusernum = "0";
    }
}
