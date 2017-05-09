using System.Text;
using System.Web;

namespace Web.UI
{
    public class Default
    {
        /// <summary>
        /// 首页显示
        /// </summary>
        /// <param name="UserLogin"></param>
        /// <returns></returns>
        public static string View(bool UserLogin)
        {
            StringBuilder str = new StringBuilder();
            str.Append("<script type=\"text/javascript\">\r\n");
            str.Append("var zringCheckUnload = true;\r\n");
            str.Append("window.onbeforeunload = function() { var Url = top.location.href; if (zringCheckUnload && Url.indexOf(\"javascript:void(0)\") == -1) return (\"" + Base.Fun.fun.getapp("comname") + "\"); }\r\n");
            str.Append("var Wh = 0,Ww = 0,LeftH = 99,RightH = 110,RightW = 235;\r\n");
            str.Append("$(document).ready(function() {\r\n");
            str.Append("$(document).delegate(\":text, :password, textarea\", \"blur\", SetoncontextmenuOff);\r\n");
            str.Append("$(document).delegate(\":text, :password, textarea\", \"focus\", SetoncontextmenuOn);");
            str.Append("$(\"#WinLoadViewWait\").hide();\r\n");
            str.Append("var sycmswindow=$(window);");
            str.Append("Wh = sycmswindow.height();\r\n");
            str.Append("Ww = sycmswindow.width();\r\n");
            str.Append("$(\".l_nav\").css(\"height\", Wh - LeftH);\r\n");
            str.Append("$(\".Rnr\").css({\"height\":Wh - RightH,\"width\":Ww - RightW});\r\n");
            str.Append("$(\"#login\").css({\"top\":Wh / 2 - 200,\"left\": Ww / 2 - 200});\r\n");
            str.Append("sycmswindow.resize(function() {\r\n");
            str.Append("WinSizeFun(this);\r\n");
            str.Append("});\r\n");
            str.Append("$('.Ttime').jclock({ withDate: true, withWeek: true });\r\n");
            if (!UserLogin)
            {
                str.Append("UserLogin(1);\r\n");
            }
            else
            {
                str.Append("LoadWindow();\r\n");
            }
            str.Append("});\r\n");
            str.Append("var UseerNameMessage = $(\"#UseerNameMessage\");\r\n");
            str.Append("var UseerNameMessageTime = null;\r\n");
            str.Append("$(\"#UseerNameMessageButton\").bind(\"mouseover\", function () {\r\n");
            str.Append("    var Index = parseInt(UseerNameMessage.css('z-index'));\r\n");
            str.Append("    if (Index < 10)\r\n");
            str.Append("    {\r\n");
            str.Append("        UseerNameMessage.css(\"z-index\", \"90000\");\r\n");
            str.Append("    }\r\n");
            str.Append("});\r\n");
            str.Append("UseerNameMessage.bind(\"mouseout\", function ()\r\n");
            str.Append("{\r\n");
            str.Append("    if (UseerNameMessageTime != null)\r\n");
            str.Append("    {\r\n");
            str.Append("        clearTimeout(UseerNameMessageTime);\r\n");
            str.Append("    }\r\n");
            str.Append("    UseerNameMessageTime=setTimeout(function () {UseerNameMessageTime=UseerNameMessage.css(\"z-index\", \"1\");}, 2000);\r\n");
            str.Append("}).bind(\"mouseover\",function()\r\n");
            str.Append("{\r\n");
            str.Append("    if (UseerNameMessageTime != null)\r\n");
            str.Append("    {\r\n");
            str.Append("        clearTimeout(UseerNameMessageTime);\r\n");
            str.Append("    }\r\n");
            str.Append("});");
            str.Append("$('#SelectCard').btn().init();");
            str.Append("AutoTask();</script>");
            return str.ToString();
        }
    }
}
