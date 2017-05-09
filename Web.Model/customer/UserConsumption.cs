
namespace Web.Model.customer
{
    /// <summary>
    /// 用户消费
    /// </summary>
    public class UserConsumption
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
        /// 预约ID
        /// </summary>
        public string appointmentid = "";
        /// <summary>
        /// 用户ID
        /// </summary>
        public string userid = "";
        /// <summary>
        /// 商品ID
        /// </summary>
        public string CommodityID = "";
        /// <summary>
        /// 消费金额（或单价）
        /// </summary>
        public string price = "";
        /// <summary>
        /// 消费时间
        /// </summary>
        public string addtime = "";
        /// <summary>
        /// 游泳时长
        /// </summary>
        public string timenum = "";
        /// <summary>
        /// 预约游泳老师
        /// </summary>
        public string swimteacherid = "";
        /// <summary>
        /// 月龄
        /// </summary>
        public string monthage = "";
        /// <summary>
        /// 泳圈
        /// </summary>
        public string mamasid = "";
        /// <summary>
        /// 身高
        /// </summary>
        public string height = "";
        /// <summary>
        /// 体重
        /// </summary>
        public string weight = "";
        /// <summary>
        /// 体温
        /// </summary>
        public string temperature = "";
        /// <summary>
        /// 满意度
        /// </summary>
        public string satisfactionid = "";
        /// <summary>
        /// 满意度用户ID
        /// </summary>
        public string satisfactionuserid = "0";
        /// <summary>
        /// 备注
        /// </summary>
        public string content = "";
        /// <summary>
        /// 状态1为正常。-1为撤消
        /// </summary>
        public string status = "0";
        /// <summary>
        /// 撤消时间
        /// </summary>
        public string updatetime = "";
        /// <summary>
        /// 撤消原因
        /// </summary>
        public string statuscontent = "";
        /// <summary>
        /// 扣除方式0，会员卡，1为现金，2为刷卡，3为其它
        /// </summary>
        public string IsCash = "";
        /// <summary>
        /// 0正次、1赠送、2为金额,3为线下
        /// </summary>
        public string Consumptiontype = "0";
        /// <summary>
        /// 小区ID
        /// </summary>
        public string _CommunityID = "";
        /// <summary>
        /// 卡类型
        /// </summary>
        public string _CardTypeID = "";
    }
}
