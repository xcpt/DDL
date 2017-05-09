
namespace Web.Model.score
{
    /// <summary>
    /// 积分日志
    /// </summary>
    public class log
    {
        /// <summary>
        /// 自动编号
        /// </summary>
        public string id = "";
        /// <summary>
        /// 客户ID
        /// </summary>
        public string userid = "";
        /// <summary>
        /// 门店ID
        /// </summary>
        public string storesid = "";
        /// <summary>
        /// 积分数量
        /// </summary>
        public string rulenum = "";
        /// <summary>
        /// 添加时间
        /// </summary>
        public string addtime = "";
        /// <summary>
        /// 添加类型0为系统自动，1为积分兑换，2为手动增加
        /// </summary>
        public string type= "";
        /// <summary>
        /// 备注信息
        /// </summary>
        public string content = "";
    }
}
