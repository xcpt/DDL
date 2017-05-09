using System;

namespace Web.UI
{
    public class FileUpExt
    {
        /// <summary>
        /// 视频格式（带默认设置）
        /// </summary>
        public static string VideoFileExt
        {
            get { string _VideoFileExt = Base.Fun.fun.getapp("VideoFileExt"); if (_VideoFileExt.Length == 0) { _VideoFileExt = "|wmv|avi|dat|asf|mpg|mpeg|mpegts|ts|mp1|mp2|mp4|m2ts|mm|m4v|mpeg4|rm|rmvb|flv|f4v|3gp|3gpp|3g2|qt|mov|dv|divx|dvix|mkv|vob|ram|cpk|fli|flc|mod|webm|vp8|tta|hd|"; } return _VideoFileExt; }
        }
        /// <summary>
        /// 文件格式（带默认设置）
        /// </summary>
        public static string FileExt
        {
            get { string _FileExt = Base.Fun.fun.getapp("FileExt"); if (_FileExt.Length == 0) { _FileExt = "|7z|aiff|asf|avi|bmp|csv|doc|docx|fla|flv|gif|gz|gzip|jpeg|jpg|mid|mov|mp3|mp4|mpc|mpeg|mpg|ods|odt|pdf|png|ppt|pxd|qt|ram|rar|rm|rmi|rmvb|rtf|sdc|sitd|swf|sxc|sxw|tar|tgz|tif|tiff|txt|vsd|wav|wma|wmv|xls|xml|zip|js|css|"; } return _FileExt; }
        }
        /// <summary>
        /// 获得文件类型
        /// </summary>
        /// <param name="FileExt"></param>
        /// <param name="FileSize"></param>
        public static void FileExtString(ref string FileExt, ref string FileSize)
        {
            if (FileExt.Equals("pic", StringComparison.CurrentCultureIgnoreCase))
            {
                FileExt = "|jpg|bmp|gif|png|";
                FileSize = "1000000";
            }
            else if (FileExt.Equals("word", StringComparison.CurrentCultureIgnoreCase))
            {
                FileExt = "|doc|docx|";
            }
            else if (FileExt.Equals("video", StringComparison.CurrentCultureIgnoreCase))
            {
                FileExt = Web.UI.FileUpExt.VideoFileExt; ;
            }
            else if (FileExt.Equals("file", StringComparison.CurrentCultureIgnoreCase))
            {
                FileExt = Web.UI.FileUpExt.FileExt;
            }
            if (FileSize.Length == 0)
            {
                FileSize = "2048000000";
            }
        }
    }
}
