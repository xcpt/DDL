using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.UI.Marketing
{
    public class Visit
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="userid"></param>
        /// <param name="name"></param>
        /// <param name="ReturnresultID"></param>
        /// <param name="IsGiveup"></param>
        /// <param name="memberid"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public static string View(string storesid, string userid, string name, string ReturnresultID, string IsGiveup, string memberid, string starttime, string endtime)
        {
            DAL.Marketing.Visit vDAL = new DAL.Marketing.Visit();
            return vDAL.View(UI.Sys.SiteInfo.GetPageSize(), storesid, userid, name, ReturnresultID, IsGiveup, memberid, starttime, endtime);
        }
    }
}
