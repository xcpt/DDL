using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.UI.Staff
{
    /// <summary>
    /// 职位工资
    /// </summary>
    public class position
    {
        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="title"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        public static string View(string storesid, string title, string level)
        {
            DAL.Staff.position pDAL = new DAL.Staff.position();
            return pDAL.View(UI.Sys.SiteInfo.GetPageSize(), storesid, title, level);
        }
        /// <summary>
        /// 获得职位名称
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetTitle(string storesid, string id)
        {
            if (Base.Fun.fun.pnumeric(id))
            {
                DAL.Staff.position pDAL = new DAL.Staff.position();
                return pDAL.Read(storesid, id).title;
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 所有
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetOption(string storesid, string id)
        {
            StringBuilder str = new StringBuilder();
            DAL.Staff.position pDAL = new DAL.Staff.position();
            List<Model.Staff.position> pList = pDAL.ReadList(storesid);
            foreach (Model.Staff.position pModel in pList)
            {
                str.Append("<option value=" + pModel.id + "" + (pModel.id.Equals(id) ? " selected=\"selected\"" : "") + ">" + pModel.title + "</option>");
            }
            return str.ToString();
        }
    }
}
