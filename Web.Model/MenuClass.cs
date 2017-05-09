
namespace Web.Model
{
    /// <summary>
    /// 文件分类
    /// </summary>
    public class MenuClass
    {
        private string id;
        private string pid = "0";
        private string name = "";
        private string directoryName = "";
        private string orderId = "0";
        private string ishow = "1";
        private string issys = "0";

        /// <summary>
        /// 自动编号
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 上级栏目ID
        /// </summary>
        public string Pid
        {
            get { return pid; }
            set { pid = value; }
        }

        /// <summary>
        /// 栏目名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// 对应目录
        /// </summary>
        public string DirectoryName
        {
            get { return directoryName; }
            set { directoryName = value; }
        }

        /// <summary>
        /// 排序ID
        /// </summary>
        public string OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }

        /// <summary>
        /// 是否显示
        /// </summary>
        public string Ishow
        {
            get { return ishow; }
            set { ishow = value; }
        }
        /// <summary>
        /// 是否系统
        /// </summary>
        public string Issys
        {
            get { return issys; }
            set { issys = value; }
        }


        public MenuClass(string id, string pid, string name, string directoryName, string orderId, string ishow)
        {
            this.id = id;
            this.pid = pid;
            this.name = name;
            this.directoryName = directoryName;
            this.orderId = orderId;
            this.ishow = ishow;
        }
        public MenuClass(string id, string pid, string name, string directoryName, string orderId, string ishow, string issys)
        {
            this.id = id;
            this.pid = pid;
            this.name = name;
            this.directoryName = directoryName;
            this.orderId = orderId;
            this.ishow = ishow;
            this.issys = issys;
        }
        public MenuClass()
        {

        }
    }
}
