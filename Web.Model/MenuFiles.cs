
namespace Web.Model
{
    /// <summary>
    /// 文件地址对应文件
    /// </summary>
    public class MenuFiles
    {
        private string id;
        private string mcid;
        private string fileName;
        private string url;
        private string allurl = "";
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
        /// 与栏目表ID相对应
        /// </summary>
        public string Mcid
        {
            get { return mcid; }
            set { mcid = value; }
        }

        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        /// <summary>
        /// 对应地址
        /// </summary>
        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        /// <summary>
        /// 完成路径
        /// </summary>
        public string AllUrl
        {
            get { return allurl; }
            set { allurl = value; }
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

        public MenuFiles(string id, string mcid, string fileName, string url, string orderId, string ishow)
        {
            this.id = id;
            this.mcid = mcid;
            this.fileName = fileName;
            this.orderId = orderId;
            this.ishow = ishow;
            this.url = url;
        }
        public MenuFiles(string id, string mcid, string fileName, string url, string orderId, string ishow, string issys)
        {
            this.id = id;
            this.mcid = mcid;
            this.fileName = fileName;
            this.orderId = orderId;
            this.ishow = ishow;
            this.issys = issys;
            this.url = url;
        }
        public MenuFiles()
        {

        }
    }
}
