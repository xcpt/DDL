
namespace Web.Model.customer
{
    /// <summary>
    /// 客户信息
    /// </summary>
    public class User
    {
        /// <summary>
        /// 客户自动编号
        /// </summary>
        public string userid = "";
        /// <summary>
        /// 密码
        /// </summary>
        public string userpass = "";
        /// <summary>
        /// 原始注册门店ID
        /// </summary>
        public string storesid = "";
        /// <summary>
        /// 用户默认使用的门店ID
        /// </summary>
        public string userstoresid = "";
        /// <summary>
        /// 会员姓名
        /// </summary>
        public string name = "";
        /// <summary>
        /// 小名
        /// </summary>
        public string nickname = "";
        /// <summary>
        /// 性别
        /// </summary>
        public string sex = "";
        /// <summary>
        /// 生日
        /// </summary>
        public string birthday = "";
        /// <summary>
        /// 家长姓名
        /// </summary>
        public string parentName = "";
        /// <summary>
        /// 联系电话
        /// </summary>
        public string tel = "";
        /// <summary>
        /// 手机号
        /// </summary>
        public string mobile = "";
        /// <summary>
        /// 小区ID
        /// </summary>
        public string communityid = "";
        /// <summary>
        /// 无有病史
        /// </summary>
        public string illness = "0";
        /// <summary>
        /// 有无过敏史
        /// </summary>
        public string allergy = "0";
        /// <summary>
        /// 婴儿类型
        /// </summary>
        public string cycletype = "";
        /// <summary>
        /// 客户来源
        /// </summary>
        public string source = "";
        /// <summary>
        /// 备注信息
        /// </summary>
        public string content = "0";
        /// <summary>
        /// 添加时间
        /// </summary>
        public string addtime = "";
        /// <summary>
        /// 卡号
        /// </summary>
        public string cardid = "0";
        /// <summary>
        /// 是否测量
        /// </summary>
        public string IsMeasure = "0";
        /// <summary>
        /// 是否拍照
        /// </summary>
        public string IsPhoto = "0";
        /// <summary>
        /// 会员积分
        /// </summary>
        public string scorenum = "0";
        /// <summary>
        /// 推荐状态（默认推送）
        /// </summary>
        public string IsPush = "1";
        /// <summary>
        /// 登录错误次数
        /// </summary>
        public string Error="0";
        /// <summary>
        /// 上次错误时间
        /// </summary>
        public string ErrorTime = "";
        /// <summary>
        /// AppID信息（共时只能一个）
        /// </summary>
        public string AppID = "";
        /// <summary>
        /// 客户端标识
        /// </summary>
        public string Client = "";
        /// <summary>
        /// 状态0未办卡，1已办卡，2体验，3咨询未到店，4咨询已到店
        /// </summary>
        public string State="0";
        /// <summary>
        /// 登录设备
        /// </summary>
        public string Model = "";
        /// <summary>
        /// 用户头像
        /// </summary>
        public string userface = "";
        /// <summary>
        /// 相册数量
        /// </summary>
        public string photonum = "0";
        /// <summary>
        /// 最大消费时长
        /// </summary>
        public string maxtimenum = "0";
        /// <summary>
        /// 最后一次消费时间
        /// </summary>
        public string lasttime = "";
        /// <summary>
        /// 卡信息
        /// </summary>
        public Card cModel = new Card();
    }
}
