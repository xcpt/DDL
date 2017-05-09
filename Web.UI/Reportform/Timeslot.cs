using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Web.UI.Reportform
{
    /// <summary>
    /// 营业时间段
    /// </summary>
    public class Timeslot
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public static string View(string storesid, string starttime, string endtime)
        {
            StringBuilder str = new StringBuilder();
            DAL.customer.UserConsumption ucDAL = new DAL.customer.UserConsumption();
            List<Model.customer.UserConsumption> ucList = ucDAL.ReadList_CommodityID(storesid, starttime, endtime, "");
            int startNum = 0;
            int endNum = 0;
            Sys.stores.GetWorkTime(storesid, ref startNum, ref endNum);
            Dictionary<int, int> dateNum = new Dictionary<int, int>();
            int month = 0;
            foreach (Model.customer.UserConsumption uc in ucList)
            {
                month = DateTime.Parse(uc.addtime).Hour;
                if (dateNum.ContainsKey(month))
                {
                    dateNum[month]++;
                }
                else
                {
                    dateNum.Add(month, 1);
                }
                if (month < startNum)
                {
                    startNum = month;
                }
                if (month > endNum)
                {
                    endNum = month;
                }
            }
            int icount = 0;
            str.Append("{");
            str.Append("\"page\":1,");
            str.Append("\"total\":" + (endNum - startNum).ToString());
            str.Append(",\"rows\":[");
            for (int i = startNum; i <= endNum; i++)
            {
                icount++;
                str.Append("{\"id\":\"" + icount.ToString() + "\", \"cell\":[");
                str.Append("\"" + icount.ToString() + "\",");
                str.Append("\"" + i.ToString() + "点 - " + (i + 1).ToString() + "点" + "\",");
                str.Append("\"" + (dateNum.ContainsKey(i) ? dateNum[i] : 0).ToString() + "\"");
                str.Append("]},");
            }
            str.Remove(str.Length - 1, 1);
            str.Append("]}");

            return str.ToString();
        }


        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public static void ViewToExcel(string storesid,string userid, string starttime, string endtime)
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "时间段";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "消费人数";
            dt.Columns.Add(dc);
            DAL.customer.UserConsumption ucDAL = new DAL.customer.UserConsumption();
            List<Model.customer.UserConsumption> ucList = ucDAL.ReadList_CommodityID(storesid, starttime, endtime, "");
            int startNum = 0;
            int endNum = 0;
            Sys.stores.GetWorkTime(storesid, ref startNum, ref endNum);
            Dictionary<int, int> dateNum = new Dictionary<int, int>();
            int month = 0;
            foreach (Model.customer.UserConsumption uc in ucList)
            {
                month = DateTime.Parse(uc.addtime).Hour;
                if (dateNum.ContainsKey(month))
                {
                    dateNum[month]++;
                }
                else
                {
                    dateNum.Add(month, 1);
                }
                if (month < startNum)
                {
                    startNum = month;
                }
                if (month > endNum)
                {
                    endNum = month;
                }
            }
            for (int i = startNum; i <= endNum; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = i.ToString() + "点 - " + (i + 1).ToString() + "点";
                dr[1] = (dateNum.ContainsKey(i) ? dateNum[i] : 0).ToString();
                dt.Rows.Add(dr);
            }
            if (dt.Rows.Count > 0)
            {
                string FileName = Base.Fun.Management.RealDirectory(Sys.SiteInfo.UpFile + "Files/Timeslot_" + userid + ".xls");
                Base.IO.Dir.CheckDir(Base.IO.Dir.ReMoveFileName(FileName));
                Base.Office.ExcelHelper.Export(dt, "营业时段分析", FileName);
                System.Web.HttpContext.Current.Response.Write(SyCms.Window.DownFile.DownFileName(FileName, "营业时段分析.xls", true));
            }
            dt.Dispose();
        }
    }
}