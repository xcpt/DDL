using System;

namespace Web.Model
{
    [Serializable]
    public class UserLogin
    {
        private string userid = "0";
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserID
        {
            get { return userid; }
            set { userid = value; }
        }
        //userID,userName,roleIDS,groupID
        private string username = "";
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }
        private string roleid = "0";
        /// <summary>
        /// 角色所属用户组ID
        /// </summary>
        public string RoleID
        {
            get { return roleid; }
            set { roleid = value; }
        }
        /// <summary>
        /// 门店ID
        /// </summary>
        public string StoresID = "";
        /// <summary>
        /// 是否Boss
        /// </summary>
        public string IsBoss = "";
    }
}
