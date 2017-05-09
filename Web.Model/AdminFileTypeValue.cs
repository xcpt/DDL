
namespace Web.Model
{
    /// <summary>
    /// 文件信息
    /// </summary>
    public class AdminFileTypeValue
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public AdminFileTypeValue() { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="FileValue"></param>
        /// <param name="FileName"></param>
        /// <param name="FilePermissions"></param>
        public AdminFileTypeValue(int FileValue, string FileName, bool FilePermissions)
        {
            this.FileValue = FileValue;
            this.FileName = FileName;
            this.FilePermissions = FilePermissions;
        }
        /// <summary>
        /// 2为属性，4为添加，8为修改，16为删除，32为审核，64排序，128布局，256为推送
        /// </summary>
        public int FileValue = 0;
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName = "";
        /// <summary>
        /// 权限
        /// </summary>
        public bool FilePermissions = false;
    }
}
