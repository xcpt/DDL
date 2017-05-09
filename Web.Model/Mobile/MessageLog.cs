
namespace Web.Model.Mobile
{
    /// <summary>
    /// 发送日志
    /// </summary>
    public class MessageLog
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
        /// 手机号
        /// </summary>
        public string mobile = "";
        /// <summary>
        /// 标题
        /// </summary>
        public string title = "";
        /// <summary>
        /// 发送内容
        /// </summary>
        public string content = "";
        /// <summary>
        /// 添加时间
        /// </summary>
        public string addtime = "";
        /// <summary>
        /// 是否定时发送
        /// </summary>
        public string sendtime = "";
        /// <summary>
        /// 发送状态0等等，1成功，-1失败
        /// </summary>
        public string status = "0";
        /// <summary>
        /// 发送方式0为手机，1为APP
        /// </summary>
        public string sendtype = "";
        /// <summary>
        /// 发送返回
        /// </summary>
        public string message = "";
    }
}
