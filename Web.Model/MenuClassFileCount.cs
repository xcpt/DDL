
namespace Web.Model
{
    /// <summary>
    /// 带子类数量的分类
    /// </summary>
    public class MenuClassFileCount : MenuClass
    {
        private string filecount = "";
        /// <summary>
        /// 文件数量
        /// </summary>
        public string FileCount
        {
            get { return filecount; }
            set { filecount = value; }
        }
    }
}
