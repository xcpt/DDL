
namespace Web.Model
{
    /// <summary>
    /// 读取全地址的时候使用
    /// </summary>
    public class MenuClassFile
    {
        private string PclassDir = "";
        /// <summary>
        /// 文件目录
        /// </summary>
        public string PClassDir
        {
            get { return PclassDir; }
            set { PclassDir = value; }
        }
        private string classDir = "";
        /// <summary>
        /// 类目录
        /// </summary>
        public string ClassDir
        {
            get { return classDir; }
            set { classDir = value; }
        }
        private string url = "";
        /// <summary>
        /// 文件地址
        /// </summary>
        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        private string id = "";
        /// <summary>
        /// id
        /// </summary>
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
    }
}
