
namespace Web.Model.customer
{
    /// <summary>
    /// 用户消费修改
    /// </summary>
    public class UserConsumptionSatisfaction
    {
        /// <summary>
        /// 自动编号
        /// </summary>
        public string id = "";
        /// <summary>
        /// 用户消费ID
        /// </summary>
        public string UserConsumptionID = "";
        /// <summary>
        /// 原值
        /// </summary>
        public string oldsatisfactionid = "";
        /// <summary>
        /// 现在值
        /// </summary>
        public string satisfactionid = "";
        /// <summary>
        /// 修改说明
        /// </summary>
        public string content = "";
        /// <summary>
        ///修改管理员
        /// </summary>
        public string administratorid = "";
        /// <summary>
        /// 添加时间
        /// </summary>
        public string addtime = "";
        /// <summary>
        /// 第几次修改
        /// </summary>
        public string num = "1";
        /// <summary>
        /// 0满意度，1为体重，2为身高，3为游戏时长
        /// </summary>
        public string type = "0";
    }
}
