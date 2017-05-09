using System.Text;

namespace Web.UI.customer
{
    /// <summary>
    /// 用户预约
    /// </summary>
    public class Userappointment
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="cardNo"></param>
        /// <param name="name"></param>
        /// <param name="cycletype"></param>
        /// <param name="swimteacherid"></param>
        /// <param name="status"></param>
        /// <param name="statustime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public static string View(string storesid, string userid, string cardNo, string name, string cycletype, string swimteacherid, string status, string statustime, string endtime, string datetimehouer, string datetimeminute, string Mobile)
        {
            DAL.customer.Userappointment uaDAL = new DAL.customer.Userappointment();
            return uaDAL.View(100, storesid, userid, cardNo, name, cycletype, swimteacherid, status, statustime, endtime, datetimehouer, datetimeminute, Mobile);
        }
        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="IsSupperAdmin"></param>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public static string MainShow()
        {
            Web.Model.UserLogin ulModel = Web.UI.Users.GetUserInfo();

            DAL.customer.Userappointment uaDAL = new DAL.customer.Userappointment();
            StringBuilder str = new StringBuilder();
            int icount = 0;
            int nicount = 0;
            string storesid = ulModel.RoleID.Equals("1") ? "0" : ulModel.StoresID;
            foreach (string t in Web.Model.Data.Basic.BabyType.Keys)
            {
                nicount = int.Parse(uaDAL.GetNowDay(storesid, t));
                icount += nicount;
                str.Append("，" + Web.Model.Data.Basic.BabyType[t] + "区<a href=\"#\" onclick=\"AjaxFun('customer/Userappointment/Lists.aspx','action=view&cycletype=" + t + "','正在打开会员预约管理','.Rnr');return false;\">" + nicount.ToString() + "</a>个会员");
            }
            return "今天一共预约了<a href=\"#\" onclick=\"AjaxFun('customer/Userappointment/Lists.aspx','action=view','正在打开会员预约管理','.Rnr');return false;\">" + icount.ToString() + "</a>个会员" + str.ToString() + "。";
        }
    }
}
