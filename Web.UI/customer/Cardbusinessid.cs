using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.UI.customer
{
   /// <summary>
   /// 卡业务类型
   /// </summary>
    public class Cardbusinessid
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string View(string storesid, string title)
        {
            Web.DAL.customer.Cardbusinessid cbDAL = new DAL.customer.Cardbusinessid();
            return cbDAL.View(UI.Sys.SiteInfo.GetPageSize(), storesid, title);
        }
        /// <summary>
        /// 选项
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetOption(string storesid, string id)
        {
            StringBuilder str = new StringBuilder();
            DAL.customer.Cardbusinessid cbDAL = new DAL.customer.Cardbusinessid();
            List<Model.customer.Cardbusinessid> cbList = cbDAL.ReadList(storesid);
            foreach (Model.customer.Cardbusinessid cb in cbList)
            {
                str.Append("<option value=\"" + cb.id + "\"" + Base.Fun.fun.isSelected(cb.id, id) + ">" + cb.title + "</option>");
            }
            return str.ToString();
        }
    }
}
