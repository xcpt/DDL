using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.UI.Staff
{
    /// <summary>
    /// 绩效
    /// </summary>
    public class performance
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="name"></param>
        /// <param name="statustime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public static string View(string storesid, string memberid, string statustime, string endtime)
        {
            DAL.Staff.performance pDAL = new DAL.Staff.performance();
            return pDAL.View(UI.Sys.SiteInfo.GetPageSize(), storesid, memberid, statustime, endtime);
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="memberid"></param>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static string View_Member(string storesid, string memberid, string datetime)
        {
            DateTime dt = DateTime.Parse(datetime.Substring(0, 4) + "-" + datetime.Substring(4) + "-1");
            DateTime startMonth = dt.AddDays(1 - dt.Day);  //本月月初
            DateTime endMonth = startMonth.AddMonths(1).AddDays(-1);  //本月月末
            DAL.Staff.performance pDAL = new DAL.Staff.performance();
            return pDAL.View(10000, storesid, memberid, startMonth.ToString("yyyy-MM-dd"), endMonth.ToString("yyyy-MM-dd"));
        }
    }
}
