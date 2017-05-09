using System.Collections.Generic;
using System.Text;

namespace Web.UI.Sys
{
    /// <summary>
    /// 小区
    /// </summary>
    public class community
    {
        /// <summary>
        /// 返回名称
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetName(string storesid, string id)
        {
            DAL.Sys.community cDAL = new DAL.Sys.community();
            return cDAL.Read(storesid, id).title;
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string View(string storesid, string title)
        {
            DAL.Sys.community cDAL = new DAL.Sys.community();
            return cDAL.View(UI.Sys.SiteInfo.GetPageSize(), storesid, title);
        }
        /// <summary>
        /// 所有小区
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public static string GetOption(string storesid, string id)
        {
            StringBuilder str = new StringBuilder();
            DAL.Sys.community cDAL = new DAL.Sys.community();
            List<Model.Sys.community> cList = cDAL.ReadList(storesid);
            foreach (Model.Sys.community c in cList)
            {
                str.Append("<option value=\"" + c.id + "\"" + Base.Fun.fun.isSelected(id, c.id) + ">" + c.title + "</option>");
            }
            return str.ToString();
        }
    }
}
