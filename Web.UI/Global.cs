using System;
using System.Timers;
using System.Net;
using System.IO;
using System.Web;

namespace SyCms
{
    /// <summary>
    ///Global 的摘要说明
    /// </summary>
    public partial class Global : System.Web.HttpApplication
    {
        public Global()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public string mp = "";
        public System.Timers.Timer myTimer = new System.Timers.Timer();
        void Application_Start(object sender, EventArgs e)
        {
            //在应用程序启动时运行的代码
            //定义定时器 
            mp = this.Server.MapPath("~/");
            double Time = double.Parse(Base.Fun.fun.IsZero(Base.Fun.fun.getapp("AutoTimePlay")));//分
            if (Time > 0)
            {
                myTimer.Elapsed += new ElapsedEventHandler(myTimer_Elapsed);
                myTimer.Enabled = true;
                myTimer.AutoReset = true;
                myTimer.Interval = Time * 60 * 1000;
                myTimer.Start();
            }
        }
        void myTimer_Elapsed(object source, ElapsedEventArgs e)
        {
            try
            {
                YourTask();
            }
            catch (Exception ex)
            {
                Base.Error.Error.WriteError(ex, mp);
            }
        }

        void YourTask()
        {
            //因在此执行需要特殊的目录执行权限，所以提到了页面中执行。
            //在这里写你需要执行的任务
            string url = Base.Fun.fun.getapp("AutoTimePlayUrl");
            if (url.Length > 0)
            {
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url + "AdminFun/AutoPlay.aspx?autoplay=SyCmsAutoPlay&WebPath=" + HttpUtility.UrlEncode(mp));
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                Stream receiveStream = myHttpWebResponse.GetResponseStream();//得到回写的字节流
                myHttpWebResponse.Close();
                receiveStream.Close();
            }
        }

        void Application_End(object sender, EventArgs e)
        {
            //在应用程序关闭时运行的代码
            //在应用程序关闭时运行的代码
            System.Threading.Thread.Sleep(1000);
            ////这里设置你的web地址，可以随便指向你的任意一个aspx页面甚至不存在的页面，目的是要激发Application_Start
            double Time = double.Parse(Base.Fun.fun.IsZero(Base.Fun.fun.getapp("AutoTimePlay")));//分
            if (Time > 0)
            {
                YourTask();
            }
        }

        void Application_Error(object sender, EventArgs e)
        {
            if (Base.Fun.fun.getapp("AppErrorLog").Equals("1"))
            {
                //在出现未处理的错误时运行的代码
                Exception objErr = Server.GetLastError().GetBaseException();
                Base.Error.Error.WriteError(objErr, mp);
                Server.ClearError();
                if (!objErr.Message.Contains("正在中止线程"))
                {
                    string strErr = "错误：网页有错误，暂不能访问。" + Base.Fun.fun.NoSql(objErr.Message);
                    Response.Write("['0','" + Base.Fun.JScript.htmltojavascriptNoS(strErr) + "']");
                    Response.Write("<html><body style=\"padding:0px;margin:0px;overflow:hidden\"><div style=\"width:100%;position:absolute;top:0px;left:0px;font-size:12px;color:red;border:1px red solid;background-color:yellow;padding:8px;\">" + strErr + "</div></body></html>");
                }
            }
        }

        void Session_Start(object sender, EventArgs e)
        {
            //在新会话启动时运行的代码
            string sessionId = Session.SessionID;
        }

        void Session_End(object sender, EventArgs e)
        {
            //在会话结束时运行的代码。 
            // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
            // InProc 时，才会引发 Session_End 事件。如果会话模式 
            //设置为 StateServer 或 SQLServer，则不会引发该事件。

        }
    }
}