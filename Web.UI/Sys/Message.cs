
namespace Web.UI.Sys
{
    public class Message
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="name"></param>
        /// <param name="saddtime"></param>
        /// <param name="eaddtime"></param>
        /// <param name="supdatetime"></param>
        /// <param name="eupdatetime"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public static string View(string storesid, string name, string saddtime, string eaddtime, string supdatetime, string eupdatetime, string state)
        {
            DAL.Sys.Message mDAL = new DAL.Sys.Message();
            return mDAL.View(Web.UI.Sys.SiteInfo.GetPageSize(), storesid, name, saddtime, eaddtime, supdatetime, eupdatetime, state);
        }
        /// <summary>
        /// Main调用
        /// </summary>
        /// <returns></returns>
        public static string MainShow()
        {
            Web.DAL.Sys.Message mDAL = new DAL.Sys.Message();
            string icount = mDAL.GetNowDay();
            return "有<a href=\"#\" onclick=\"AjaxFun('Sys/Message/Lists.aspx','action=view','正在打开会员反馈管理','.Rnr');return false;\">" + icount + "</a>条反馈信息。";
        }
    }
}
