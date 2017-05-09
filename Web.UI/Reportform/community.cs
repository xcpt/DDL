using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;

namespace Web.UI.Reportform
{
    /// <summary>
    /// 小区消费
    /// </summary>
    public class community
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public static string View(string storesid, string communityid, string starttime, string endtime)
        {
            DAL.customer.UserConsumption ucDAL = new DAL.customer.UserConsumption();
            List<Model.customer.UserConsumption> ucList = ucDAL.ReadList_CommunityID(storesid, starttime, endtime, communityid);
            Dictionary<string, int> proper = new Dictionary<string, int>();
            Dictionary<string,string> user=new Dictionary<string,string>();
            Dictionary<string, double> price = new Dictionary<string, double>();

            foreach (Model.customer.UserConsumption uc in ucList)
            {
                //if (uc.IsCash != "0")
                //{
                if (price.ContainsKey(uc._CommunityID))
                {
                    price[uc._CommunityID] += double.Parse(uc.price);
                }
                else
                {
                    price.Add(uc._CommunityID, double.Parse(uc.price));
                }
                if (!user.ContainsKey(uc.userid))
                {
                    user.Add(uc.userid, "");
                    if (proper.ContainsKey(uc._CommunityID))
                    {
                        proper[uc._CommunityID]++;
                    }
                    else
                    {
                        proper.Add(uc._CommunityID, 1);
                    }
                }
                //}
            }
            price = (from entry in price
                            orderby entry.Value descending
                            select entry).ToDictionary(pair => pair.Key, pair => pair.Value);

            DAL.Sys.community cDAL = new DAL.Sys.community();
            List<Model.Sys.community> cModel = cDAL.ReadList(storesid);
            StringBuilder str = new StringBuilder();
            int icount = 0;
            str.Append("{");
            str.Append("\"page\":1,");
            str.Append("\"total\":" + price.Count.ToString());
            str.Append(",\"rows\":[");
            foreach (string id in price.Keys)
            {
                Model.Sys.community cm = cModel.Find(delegate(Model.Sys.community c) { return c.id.Equals(id); });
                if (cm != null)
                {
                    icount++;
                    str.Append("{\"id\":\"" + icount.ToString() + "\", \"cell\":[");
                    str.Append("\"" + icount.ToString() + "\",");
                    str.Append("\"" + cm.title + "\",");
                    str.Append("\"" + proper[id].ToString() + "\",");
                    str.Append("\"" + price[id].ToString() + "\",");
                    str.Append("\"" + (proper[id] > 0 ? Math.Round(price[id] / proper[id], 2).ToString() : "") + "\"");
                    str.Append("]},");
                }
            }
            if (icount > 0)
            {
                str.Remove(str.Length - 1, 1);
            }
            str.Append("]");
            str.Append("}");
            return str.ToString();
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public static void ViewToExcel(string storesid, string userid, string communityid, string starttime, string endtime)
        {
            DAL.customer.UserConsumption ucDAL = new DAL.customer.UserConsumption();
            List<Model.customer.UserConsumption> ucList = ucDAL.ReadList_CommunityID(storesid, starttime, endtime, communityid);
            Dictionary<string, int> proper = new Dictionary<string, int>();
            Dictionary<string, string> user = new Dictionary<string, string>();
            Dictionary<string, double> price = new Dictionary<string, double>();

            foreach (Model.customer.UserConsumption uc in ucList)
            {
                //if (uc.IsCash != "0")
                //{
                if (price.ContainsKey(uc._CommunityID))
                {
                    price[uc._CommunityID] += double.Parse(uc.price);
                }
                else
                {
                    price.Add(uc._CommunityID, double.Parse(uc.price));
                }
                if (!user.ContainsKey(uc.userid))
                {
                    user.Add(uc.userid, "");
                    if (proper.ContainsKey(uc._CommunityID))
                    {
                        proper[uc._CommunityID]++;
                    }
                    else
                    {
                        proper.Add(uc._CommunityID, 1);
                    }
                }
                //}
            }
            price = (from entry in price
                     orderby entry.Value descending
                     select entry).ToDictionary(pair => pair.Key, pair => pair.Value);

            DAL.Sys.community cDAL = new DAL.Sys.community();
            List<Model.Sys.community> cModel = cDAL.ReadList(storesid);
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "小区名称";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "来客数";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "消费金额";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "客单";
            dt.Columns.Add(dc);
            foreach (string id in price.Keys)
            {
                Model.Sys.community cm = cModel.Find(delegate(Model.Sys.community c) { return c.id.Equals(id); });
                if (cm != null)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = cm.title;
                    dr[1] = proper[id].ToString();
                    dr[2] = price[id].ToString();
                    dr[3] = (proper[id] > 0 ? Math.Round(price[id] / proper[id], 2).ToString() : "") + "%";
                    dt.Rows.Add(dr);
                }
            }
            if (dt.Rows.Count > 0)
            {
                string FileName = Base.Fun.Management.RealDirectory(Sys.SiteInfo.UpFile + "Files/community_" + userid + ".xls");
                Base.IO.Dir.CheckDir(Base.IO.Dir.ReMoveFileName(FileName));
                Base.Office.ExcelHelper.Export(dt, "小区消费汇总", FileName);
                System.Web.HttpContext.Current.Response.Write(SyCms.Window.DownFile.DownFileName(FileName, "小区消费汇总.xls", true));
            }
            dt.Dispose();
        }
    }
}
