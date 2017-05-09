using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.UI.Mobile
{
    /// <summary>
    /// 短消息模板
    /// </summary>
    public class MessageTemplate
    {
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string View(string storesid, string title)
        {
            DAL.Mobile.MessageTemplate mtDAL = new DAL.Mobile.MessageTemplate();
            return mtDAL.View(UI.Sys.SiteInfo.GetPageSize(), storesid, title);
        }
        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetOption(string storesid, string id)
        {
            StringBuilder str = new StringBuilder();
            DAL.Mobile.MessageTemplate mtDAL = new DAL.Mobile.MessageTemplate();
            List<Model.Mobile.MessageTemplate> mtList = mtDAL.ReadList(storesid);
            foreach (Model.Mobile.MessageTemplate mt in mtList)
            {
                str.Append("<option value=\"" + mt.id + "\"" + Base.Fun.fun.isSelected(mt.id, id) + ">" + mt.title + "</option>");
            }
            return str.ToString();
        }
    }
}
