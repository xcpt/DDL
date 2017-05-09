using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.UI.Staff
{
    /// <summary>
    /// 积分
    /// </summary>
    public class score
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="name"></param>
        /// <param name="isadd"></param>
        /// <param name="type"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public static string View(string storesid, string memberid, string isadd, string type, string starttime, string endtime)
        {
            DAL.Staff.score sDAL = new DAL.Staff.score();
            return sDAL.View(UI.Sys.SiteInfo.GetPageSize(), storesid, memberid, isadd, type, starttime, endtime);
        }
    }
}
