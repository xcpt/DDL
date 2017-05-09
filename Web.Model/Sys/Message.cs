
namespace Web.Model.Sys
{
    /// <summary>
    /// 留言处理
    /// </summary>
    public class Message
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
        /// 添加时间
        /// </summary>
        public string addtime = "";
        /// <summary>
        /// 处理时间
        /// </summary>
        public string updatetime = "";
        /// <summary>
        /// 问题
        /// </summary>
        public string content = "";
        /// <summary>
        /// 回复问题
        /// </summary>
        public string hfcontent = "";
        /// <summary>
        /// 0未处理，1已处理
        /// </summary>
        public string state = "0";
    }
}
