
namespace Web.Model
{
    /// <summary>
    /// 文件菜单权限
    /// </summary>
    public class FilePermissions
    {
        private string id = "";
        /// <summary>
        /// 自动编号
        /// </summary>
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        private string roleid = "";
        /// <summary>
        /// 角色ID
        /// </summary>
        public string RoleID
        {
            get { return roleid; }
            set { roleid = value; }
        }
        //[FileID],[Pvalue]
        private string fileid = "";
        /// <summary>
        /// 文件ID
        /// </summary>
        public string FileID
        {
            get { return fileid; }
            set { fileid = value; }
        }
        private string pvalue = "";
        /// <summary>
        /// 属性值
        /// </summary>
        public string Pvalue
        {
            get { return pvalue; }
            set { pvalue = value; }
        }
    }
}
