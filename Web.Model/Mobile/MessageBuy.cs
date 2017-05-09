
namespace Web.Model.Mobile
{
    /// <summary>
    /// 短消息购买
    /// </summary>
    public class MessageBuy
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
        /// 购买的是哪个短消息服务
        /// </summary>
        public string SetupID = "";
        /// <summary>
        /// 0为处理中，1为处理成功，-1为放弃，2为未通过
        /// </summary>
        public string status = "";
        /// <summary>
        /// 处理结果
        /// </summary>
        public string statuscontent = "";
        /// <summary>
        /// 添加时间
        /// </summary>
        public string addtime = "";
        /// <summary>
        /// 备注
        /// </summary>
        public string content = "";
    }
}
