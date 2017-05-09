using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Web.UI.Reportform
{
    /// <summary>
    /// 会员周消费
    /// </summary>
    public class Week
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
            DAL.customer.UserConsumption ucDAL = new DAL.customer.UserConsumption();
            List<Model.customer.UserConsumption> ucList = ucDAL.ReadList_CommodityID(storesid, starttime, endtime, "");
            Dictionary<int, Dictionary<string, string>> uesr = new Dictionary<int, Dictionary<string, string>>();
            Dictionary<int, int> weekpopre = new Dictionary<int, int>();
            Dictionary<int, int> weekicount = new Dictionary<int, int>();
            Dictionary<int, double> weekprice = new Dictionary<int, double>();
            int ipopre = 0;
            int icount = 0;
            double iprice=0;
            foreach (Model.customer.UserConsumption uc in ucList)
            {
                icount++;
                int week = Base.Fun.fun.Week2Int(DateTime.Parse(uc.addtime));
                if (uc.IsCash != "0")
                {
                    iprice += double.Parse(uc.price);
                    if (weekprice.ContainsKey(week))
                    {
                        weekprice[week] += double.Parse(uc.price);
                    }
                    else
                    {
                        weekprice.Add(week, double.Parse(uc.price));
                    }
                }
                if (weekicount.ContainsKey(week))
                {
                    weekicount[week]++;
                }
                else
                {
                    weekicount.Add(week, 1);
                    uesr.Add(week, new Dictionary<string, string>());
                    weekpopre.Add(week, 0);
                }
                if (!uesr[week].ContainsKey(uc.userid))
                {
                    ipopre++;
                    uesr[week].Add(uc.userid, uc.userid);
                    weekpopre[week]++;
                }
            }
            StringBuilder str = new StringBuilder();
                        str.Append("{");
            str.Append("\"page\":1,");
            str.Append("\"total\":7,");
            str.Append("\"rows\":[");
            for (int i = 1; i <= 7; i++)
            {
                str.Append("{\"id\":\"" + i.ToString() + "\", \"cell\":[");
                str.Append("\"" + i.ToString() + "\",");
                str.Append("\"&nbsp;&nbsp;&nbsp;&nbsp;星期" + WeekStr(i) + "\",");
                str.Append("\"" + (weekpopre.ContainsKey(i)?weekpopre[i]:0) + "\",");
                str.Append("\"" + (weekicount.ContainsKey(i)?weekicount[i]:0) + "\",");
                str.Append("\"" + (weekprice.ContainsKey(i) ? weekprice[i] : 0) + "\",");
                str.Append("\"" + (weekicount.ContainsKey(i) ? Math.Round((double)weekicount[i] * 100 / icount, 2) : 0).ToString() + "%\",");
                str.Append("\"" + (weekprice.ContainsKey(i) ? Math.Round(weekprice[i] * 100 / iprice, 2) : 0).ToString() + "%\"");
                str.Append("]},");
            }
            str.Append("{\"id\":\"8\", \"cell\":[");
            str.Append("\"8\",");
            str.Append("\"<b>总计</b>\",");
            str.Append("\"" + ipopre.ToString() + "\",");
            str.Append("\"" + icount.ToString() + "\",");
            str.Append("\"" + iprice.ToString() + "\",");
            str.Append("\"\",");
            str.Append("\"\"");
            str.Append("]}");
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
            DAL.customer.UserConsumption ucDAL = new DAL.customer.UserConsumption();
            List<Model.customer.UserConsumption> ucList = ucDAL.ReadList_CommodityID(storesid, starttime, endtime, "");
            Dictionary<int, Dictionary<string, string>> uesr = new Dictionary<int, Dictionary<string, string>>();
            Dictionary<int, int> weekpopre = new Dictionary<int, int>();
            Dictionary<int, int> weekicount = new Dictionary<int, int>();
            Dictionary<int, double> weekprice = new Dictionary<int, double>();
            int ipopre = 0;
            int icount = 0;
            double iprice = 0;
            foreach (Model.customer.UserConsumption uc in ucList)
            {
                icount++;
                int week = Base.Fun.fun.Week2Int(DateTime.Parse(uc.addtime));
                if (uc.IsCash != "0")
                {
                    iprice += double.Parse(uc.price);
                    if (weekprice.ContainsKey(week))
                    {
                        weekprice[week] += double.Parse(uc.price);
                    }
                    else
                    {
                        weekprice.Add(week, double.Parse(uc.price));
                    }
                }
                if (weekicount.ContainsKey(week))
                {
                    weekicount[week]++;
                }
                else
                {
                    weekicount.Add(week, 1);
                    uesr.Add(week, new Dictionary<string, string>());
                    weekpopre.Add(week, 0);
                }
                if (!uesr[week].ContainsKey(uc.userid))
                {
                    ipopre++;
                    uesr[week].Add(uc.userid, uc.userid);
                    weekpopre[week]++;
                }
            }
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "星期";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "消费人数";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "消费次数";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "消费金额";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "消费次数占比";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "消费金额占比";
            dt.Columns.Add(dc);
            for (int i = 1; i <= 7; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = "星期" + WeekStr(i);
                dr[1] = weekpopre.ContainsKey(i) ? weekpopre[i] : 0;
                dr[2] = weekicount.ContainsKey(i) ? weekicount[i] : 0;
                dr[3] = weekprice.ContainsKey(i) ? weekprice[i] : 0;
                dr[4] = (weekicount.ContainsKey(i) ? Math.Round((double)weekicount[i] * 100 / icount, 2) : 0).ToString() + "%";
                dr[5] = (weekprice.ContainsKey(i) ? Math.Round(weekprice[i] * 100 / iprice, 2) : 0).ToString() + "%";
                dt.Rows.Add(dr);
            }

            DataRow dr1 = dt.NewRow();
            dr1[0] = "总计";
            dr1[1] = ipopre.ToString();
            dr1[2] = icount.ToString();
            dr1[3] = iprice.ToString();
            dr1[4] = "";
            dr1[5] = "";
            dt.Rows.Add(dr1);
            if (dt.Rows.Count > 0)
            {
                string FileName = Base.Fun.Management.RealDirectory(Sys.SiteInfo.UpFile + "Files/Week_" + userid + ".xls");
                Base.IO.Dir.CheckDir(Base.IO.Dir.ReMoveFileName(FileName));
                Base.Office.ExcelHelper.Export(dt, "会员周消费", FileName);
                System.Web.HttpContext.Current.Response.Write(SyCms.Window.DownFile.DownFileName(FileName, "会员周消费.xls", true));
            }
            dt.Dispose();
        }
        private static string WeekStr(int i)
        {
            string str = "";
            switch (i)
            {
                case 1:
                    {
                        str = "一";
                        break;
                    }
                case 2:
                    {
                        str = "二";
                        break;
                    }
                case 3:
                    {
                        str = "三";
                        break;
                    }
                case 4:
                    {
                        str = "四";
                        break;
                    }
                case 5:
                    {
                        str = "五";
                        break;
                    }
                case 6:
                    {
                        str = "六";
                        break;
                    }
                case 7:
                    {
                        str = "日";
                        break;
                    }
            }
            return str;
        }
    }
}
