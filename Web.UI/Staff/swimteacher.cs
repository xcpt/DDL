using System;
using System.Collections.Generic;
using System.Text;

namespace Web.UI.Staff
{
    /// <summary>
    /// 游戏老师
    /// </summary>
    public class swimteacher
    {
        /// <summary>
        /// 下拉
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetOption(string storesid, string id)
        {
            DAL.Staff.swimteacher sDAL = new DAL.Staff.swimteacher();
            List<Model.Staff.swimteacher> sList = sDAL.ReadList(storesid);
            StringBuilder str = new StringBuilder();
            Dictionary<string, string> dList = Staff.department.GetList(storesid);
            string title = "";
            foreach (Model.Staff.swimteacher s in sList)
            {
                title = "";
                if (dList.ContainsKey(s.member_departmentid))
                {
                    title = dList[s.member_departmentid];
                }
                str.Append("<option value=\"" + s.memberid + "\"" + Base.Fun.fun.isSelected(s.memberid, id) + ">" + s.member_name + (title.Length > 0 ? "[" + title + "]" : "") + "</option>");
            }
            return str.ToString();
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="name"></param>
        /// <param name="isopen"></param>
        /// <param name="iswww"></param>
        /// <param name="departmentid"></param>
        /// <returns></returns>
        public static string View(string storesid, string memberid, string isopen, string iswww, string departmentid)
        {
            DAL.Staff.swimteacher sDAL = new DAL.Staff.swimteacher();
            return sDAL.View(UI.Sys.SiteInfo.GetPageSize(), storesid, memberid, isopen, iswww, departmentid);
        }
    }
}
