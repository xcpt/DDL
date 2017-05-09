
namespace Web.Model.Staff
{
    /// <summary>
    /// 职位工资
    /// </summary>
    public class position
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
        /// 职位名称
        /// </summary>
        public string title = "";
        /// <summary>
        /// 级别
        /// </summary>
        public string level = "";
        /// <summary>
        /// 底薪
        /// </summary>
        public string salary = "";
        /// <summary>
        /// 保险扣除金额
        /// </summary>
        public string deducted = "";
        /// <summary>
        /// 有无提成0，1
        /// </summary>
        public string istake = "0";
        /// <summary>
        /// 责任描述
        /// </summary>
        public string description = "";
    }
}
