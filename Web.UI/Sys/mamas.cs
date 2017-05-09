using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.UI.Sys
{
    /// <summary>
    /// 泳圈
    /// </summary>
    public class mamas
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetOption(string storesid, string id)
        {
            DAL.Sys.mamas mDAL = new DAL.Sys.mamas();
            List<Model.Sys.mamas> mList = mDAL.ReadList(storesid);
            StringBuilder str = new StringBuilder();
            foreach (Model.Sys.mamas m in mList)
            {
                str.Append("<option value=\"" + m.id + "\"" + Base.Fun.fun.isSelected(m.id, id) + ">" + m.title + "</option>");
            }
            return str.ToString();
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string View(string storesid, string title)
        {
            DAL.Sys.mamas mDAL = new DAL.Sys.mamas();
            return mDAL.View(UI.Sys.SiteInfo.GetPageSize(), storesid, title);
        }
    }
}
