
namespace Web.Model
{
    /// <summary>
    /// 角色
    /// </summary>
    public class Roles
    {
        private string id;
        private string roleName;
        private string roleDescription;
        private string storesID="";

        /// <summary>
        /// 自动编号
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName
        {
            get { return roleName; }
            set { roleName = value; }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string RoleDescription
        {
            get { return roleDescription; }
            set { roleDescription = value; }
        }
        /// <summary>
        /// 分店ID
        /// </summary>
        public string StoresID
        {
            get { return storesID; }
            set { storesID = value; }
        }
        /// <summary>
        /// 无参数构造
        /// </summary>
        public Roles()
        { }
        /// <summary>
        /// 有参数构造
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roleName"></param>
        /// <param name="roleDescription"></param>
        public Roles(string id, string roleName, string roleDescription, string storesID)
        {
            this.id = id;
            this.roleName = roleName;
            this.roleDescription = roleDescription;
            this.storesID = storesID;
        }
    }
}
