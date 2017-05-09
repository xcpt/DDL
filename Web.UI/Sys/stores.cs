using System.Collections.Generic;
using System.Text;

namespace Web.UI.Sys
{
    /// <summary>
    /// 门店
    /// </summary>
    public class stores
    {
        /// <summary>
        /// 获得上下班时间
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public static void GetWorkTime(string storesid, ref int starttime, ref int endtime)
        {
            DAL.Sys.stores sDAL = new DAL.Sys.stores();
            Model.Sys.stores sModel = sDAL.Read(storesid);
            starttime = int.Parse(sModel.Worktime);
            endtime = int.Parse(sModel.Closingtime);
        }
        /// <summary>
        /// 获得小时
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public static string GetOption_datetimehouer(string storesid, string houer)
        {
            DAL.Sys.stores sDAL = new DAL.Sys.stores();
            Model.Sys.stores sModel = sDAL.Read(storesid);
            int starttime = int.Parse(sModel.Worktime);
            int endtime = int.Parse(sModel.Closingtime);
            StringBuilder str = new StringBuilder();
            for (int i = starttime; i <= endtime; i++)
            {
                str.Append("<option value=\"" + i.ToString() + "\"" + Base.Fun.fun.isSelected(houer, i.ToString()) + ">" + i.ToString() + "点</option>");
            }
            return str.ToString();
        }
        /// <summary>
        /// 获得分钟
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public static string GetOption_datetimeminute(string minute)
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i <= 59; i += 15)
            {
                str.Append("<option value=\"" + i.ToString() + "\"" + Base.Fun.fun.isSelected(minute, i.ToString()) + ">" + i.ToString() + "分</option>");
            }
            return str.ToString();
        }
        /// <summary>
        /// 获得最早的一个门店ID
        /// </summary>
        /// <returns></returns>
        public static string GetStoresID()
        {
            DAL.Sys.stores sDAL = new DAL.Sys.stores();
            return sDAL.ReadOne().storesid;
        }
        /// <summary>
        /// 读取门店名称
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public static string GetStoresName(string storesid)
        {
            DAL.Sys.stores sDAL = new DAL.Sys.stores();
            return sDAL.Read(storesid).title;
        }
        /// <summary>
        /// 读取分页
        /// </summary>
        /// <param name="title"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="Province"></param>
        /// <param name="City"></param>
        /// <returns></returns>
        public static string View(string title, string starttime, string endtime, string Province, string City)
        {
            DAL.Sys.stores sDAL = new DAL.Sys.stores();
            return sDAL.View(Sys.SiteInfo.GetPageSize(), title, starttime, endtime, Province, City);
        }
        /// <summary>
        /// 返回门店ID
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public static string GetOption(string storesid)
        {
            List<Model.Sys.stores> sList = new List<Model.Sys.stores>();
            DAL.Sys.stores sDAL = new DAL.Sys.stores();
            sList = sDAL.ReadList();
            StringBuilder str = new StringBuilder();
            foreach (Model.Sys.stores sModel in sList)
            {
                str.Append("<option value=\"" + sModel.storesid + "\"" + (storesid.Equals(sModel.storesid) ? " selected=\"selected\"" : "") + ">" + sModel.title + "</option>");
            }
            return str.ToString();
        }
        /// <summary>
        /// 返回门店ID
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public static string GetOutletsOption(string storesid)
        {
            List<Model.Sys.stores> sList = new List<Model.Sys.stores>();
            DAL.Sys.stores sDAL = new DAL.Sys.stores();
            sList = sDAL.ReadList();
            StringBuilder str = new StringBuilder();
            foreach (Model.Sys.stores sModel in sList)
            {
                if (sModel.Isoutlets.Equals("1"))
                {
                    str.Append("<option value=\"" + sModel.storesid + "\"" + (storesid.Equals(sModel.storesid) ? " selected=\"selected\"" : "") + ">" + sModel.title + "</option>");
                }
            }
            return str.ToString();
        }
        /// <summary>
        /// 返回门店ID
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public static string GetOptionIsBoss(string storesid)
        {
            Model.Sys.stores sModel = new Model.Sys.stores();
            DAL.Sys.stores sDAL = new DAL.Sys.stores();
            sModel = sDAL.Read(storesid);
            StringBuilder str = new StringBuilder();
            if (Base.Fun.fun.pnumeric(sModel.storesid))
            {
                str.Append("<option value=\"" + sModel.storesid + "\"" + (storesid.Equals(sModel.storesid) ? " selected=\"selected\"" : "") + ">" + sModel.title + "</option>");
            }
            return str.ToString();
        }
        /// <summary>
        /// 是否直营店
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public static bool ReadOutlets(string storesid)
        {
            DAL.Sys.stores sDAL = new DAL.Sys.stores();
            return sDAL.Read(storesid).Isoutlets.Equals("1");
        }
    }
}
