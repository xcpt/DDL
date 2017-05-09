using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.UI.Mobile
{
    public class MessageSetup
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string View(string title)
        {
            DAL.Mobile.MessageSetup msDAL = new DAL.Mobile.MessageSetup();
            return msDAL.View(UI.Sys.SiteInfo.GetPageSize(), title);
        }
        /// <summary>
        /// 读取下拉
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetOption(string id)
        {
            DAL.Mobile.MessageSetup msDAL = new DAL.Mobile.MessageSetup();
            List<Model.Mobile.MessageSetup> msList = msDAL.ReadList();
            StringBuilder str = new StringBuilder();
            foreach (Model.Mobile.MessageSetup ms in msList)
            {
                if (ms.isopen.Equals("1"))
                {
                    str.Append("<option value=\"" + ms.id + "\"" + (ms.id.Equals(id) ? " selected=\"selected\"" : "") + ">" + ms.title + "</option>");
                }
            }
            return str.ToString();
        }
    }
}
