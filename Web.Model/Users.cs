
namespace Web.Model
{
    /// <summary>
    /// 用户
    /// </summary>
    public class Users
    {
        private int userID = 0;
        private string userName;
        private string userPass;
        private string roleID;
        private int isLock;
        private int loginTimes;
        private string lastLoginTime;
        private string lastLoginIP;
        private string lastLoginOutTime;
        private int loginErrorTimes;
        private string storesid;
        private string _IsBoss = "0";
        /// <summary>
        /// 自动编号
        /// </summary>
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        /// <summary>
        /// 密码
        /// </summary>
        public string UserPass
        {
            get { return userPass; }
            set { userPass = value; }
        }
        /// <summary>
        /// 用户对应的权限值
        /// </summary>
        public string RoleID
        {
            get { return roleID; }
            set { roleID = value; }
        }

        /// <summary>
        /// 是否锁定    0--不锁  1--锁定
        /// </summary>
        public int IsLock
        {
            get { return isLock; }
            set { isLock = value; }
        }

        /// <summary>
        /// 登录次数
        /// </summary>
        public int LoginTimes
        {
            get { return loginTimes; }
            set { loginTimes = value; }
        }

        /// <summary>
        /// 上次登录时间
        /// </summary>
        public string LastLoginTime
        {
            get { return lastLoginTime; }
            set { lastLoginTime = value; }
        }

        /// <summary>
        /// 上次登录IP
        /// </summary>
        public string LastLoginIP
        {
            get { return lastLoginIP; }
            set { lastLoginIP = value; }
        }

        /// <summary>
        /// 上次退出时间
        /// </summary>
        public string LastLoginOutTime
        {
            get { return lastLoginOutTime; }
            set { lastLoginOutTime = value; }
        }

        /// <summary>
        /// 登录错误的次数
        /// </summary>
        public int LoginErrorTimes
        {
            get { return loginErrorTimes; }
            set { loginErrorTimes = value; }
        }
        /// <summary>
        /// 所属门店ID
        /// </summary>
        public string StoresID
        {
            get { return storesid; }
            set { storesid = value; }
        }
        /// <summary>
        /// 是否Boss
        /// </summary>
        public string IsBoss
        {
            get { return _IsBoss; }
            set { _IsBoss = value; }
        }
        /// <summary>
        /// 无参数构造函数
        /// </summary>
        public Users()
        {

        }
        /// <summary>
        /// 有参数构造函数
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="departmentid">departmentid</param>
        /// <param name="userName"></param>
        /// <param name="userPass"></param>
        /// <param name="groupId"></param>
        /// <param name="roleIDS"></param>
        /// <param name="isLock"></param>
        /// <param name="loginTimes"></param>
        /// <param name="lastLoginTime"></param>
        /// <param name="lastLoginIP"></param>
        /// <param name="lastLoginOutTime"></param>
        /// <param name="loginErrorTimes"></param>
        /// <param name="email"></param>
        public Users(int userID, string StoresID, string isBoss, string userName, string userPass, string roleID, int isLock, int loginTimes, string lastLoginTime, string lastLoginIP, string lastLoginOutTime, int loginErrorTimes)
        {
            this.userID = userID;
            this.userName = userName;
            this.userPass = userPass;
            this.roleID = roleID;
            this.isLock = isLock;
            this.loginTimes = loginTimes;
            this.lastLoginTime = lastLoginTime;
            this.lastLoginIP = lastLoginIP;
            this.lastLoginOutTime = lastLoginOutTime;
            this.loginErrorTimes = loginErrorTimes;
            this.StoresID = StoresID;
            this.IsBoss = isBoss;
        }
    }
}
