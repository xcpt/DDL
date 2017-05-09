using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Web.Window
{
    /// <summary>
    /// 自动执行函数前面引用方法
    /// </summary>
    public class AutoPlay
    {
        /// <summary>
        /// 判断是否继续执行的自动函数（以防止外部调用）
        /// </summary>
        public static void AutoPlayTrue()
        {
            string autoplay = Base.Fun.Fetch.get("autoplay");
            if (!autoplay.Equals("SyCmsAutoPlay"))
            {
                HttpContext.Current.Response.End();
            }
        }
        /// <summary>
        /// 获得网站目录
        /// </summary>
        /// <returns></returns>
        public static string WebPath()
        {
            string WebPath = Base.Fun.Fetch.getpost("WebPath");
            if (WebPath.Length > 0)
            {
                int PathDepth = int.Parse(Base.Fun.fun.IsZero(Base.Fun.fun.getapp("HtmlPathDepth")));
                if (PathDepth > 0)
                {
                    WebPath = Base.Fun.Management.ParentPath(WebPath, PathDepth);
                }
            }
            return WebPath;
        }
    }
}
