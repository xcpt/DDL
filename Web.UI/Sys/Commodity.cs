using System;
using System.Text;
using System.Collections.Generic;
namespace Web.UI.Sys
{
    /// <summary>
    /// 商品
    /// </summary>
    public class Commodity
    {
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetOption(string storesid, string id)
        {
            StringBuilder str = new StringBuilder();
            DAL.Sys.Commodity cDAL = new DAL.Sys.Commodity();
            List<Model.Sys.Commodity> cList = cDAL.ReadList(storesid);
            foreach (Model.Sys.Commodity c in cList)
            {
                str.Append("<option value=\"" + c.id + "\"" + Base.Fun.fun.isSelected(c.id, id) + ">" + c.title + "[<b>" + c.price + "</b>]</option>");
            }
            return str.ToString();
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetName(string storesid, string id)
        {
            DAL.Sys.Commodity cDAL = new DAL.Sys.Commodity();
            return cDAL.Read(storesid, id).title;
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetPrice(string storesid, string id)
        {
            DAL.Sys.Commodity cDAL = new DAL.Sys.Commodity();
            return cDAL.Read(storesid, id).price;
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string View(string storesid, string title)
        {
            DAL.Sys.Commodity cDAL = new DAL.Sys.Commodity();
            return cDAL.View(Sys.SiteInfo.GetPageSize(), storesid, title);
        }
    }
}
