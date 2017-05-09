
namespace Web.Model.customer
{
    /// <summary>
    /// 用户关联直营店
    /// </summary>
    public class User_Stores
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
        /// 正价次数
        /// </summary>
        public int positivenum = 0;
        /// <summary>
        /// 已使用正价次数
        /// </summary>
        public int userpositivenum = 0;
        /// <summary>
        /// 剩余正价次数
        /// </summary>
        public int surpluspositivenum = 0;
        /// <summary>
        /// 赠送次数
        /// </summary>
        public int negativenum = 0;
        /// <summary>
        /// 已使用赠送次数
        /// </summary>
        public int usernegativenum = 0;
        /// <summary>
        /// 剩余赠送次数
        /// </summary>
        public int surplusnegativenum = 0;
        /// <summary>
        /// 剩余次数
        /// </summary>
        public int surplusnum = 0;
        /// <summary>
        /// 卡类型
        /// </summary>
        public string cardtypeid = "";
    }
}
