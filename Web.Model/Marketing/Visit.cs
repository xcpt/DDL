
namespace Web.Model.Marketing
{
    /// <summary>
    /// 回访记录
    /// </summary>
    public class Visit
    {
        /// <summary>
        /// 自动编号
        /// </summary>
        public string id = "";
        /// <summary>
        /// 会员ID
        /// </summary>
        public string userid = "";
        /// <summary>
        /// 回访时间
        /// </summary>
        public string addtime = "";
        /// <summary>
        /// 回访员工
        /// </summary>
        public string memberid = "";
        /// <summary>
        /// 回复结果
        /// </summary>
        public string ReturnresultID = "0";
        /// <summary>
        /// 是否放弃此客户
        /// </summary>
        public string IsGiveup = "0";
        /// <summary>
        /// 次数
        /// </summary>
        public string num = "1";
        /// <summary>
        /// 备注
        /// </summary>
        public string content = "";
    }
}
