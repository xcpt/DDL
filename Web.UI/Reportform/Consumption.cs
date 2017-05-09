using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Web.UI.Reportform
{
    /// <summary>
    /// 门店客流客单查询
    /// </summary>
    public class Consumption
    {
        /// <summary>
        /// 门店客流客单查询
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

            DateTime dt = DateTime.Parse(starttime);
            DateTime endDate = DateTime.Parse(endtime);
            int num = endDate.Year * 12 + endDate.Month - dt.Year * 12 - dt.Month;
            str.Append("{");
            str.Append("\"page\":1,");
            str.Append("\"total\":" + num);
            if (num > 0)
            {
                str.Append(",\"rows\":[");
                int icount = 0;
                for (int i = 0; i <= num; i++)
                {
                    DateTime dtn = dt.AddMonths(i);
                    List<Model.customer.UserConsumption> ucModelList = ucList.FindAll(delegate(Model.customer.UserConsumption uc) { return DateTime.Parse(uc.addtime).ToString("yyyyMM").Equals(dtn.ToString("yyyyMM")); });
                    double uNum = 0;
                    foreach (Model.customer.UserConsumption uc in ucModelList)
                    {
                        uNum += double.Parse(uc.price);
                    }
                    icount++;

                    str.Append("{\"id\":\"" + icount.ToString() + "\", \"cell\":[");
                    str.Append("\"" + icount.ToString() + "\",");
                    str.Append("\"" + dtn.ToString("yyyy-MM") + "\",");
                    str.Append("\"" + String.Format("{0:N2}",uNum) + "\",");
                    str.Append("\"" + ucModelList.Count.ToString() + "\",");
                    str.Append("\"" + (uNum > 0 ? String.Format("{0:N2}",Math.Round(uNum / ucModelList.Count, 2)) : "0") + "\"");
                    str.Append("]},");
                }
                str.Remove(str.Length - 1, 1);
                str.Append("]");
            }
            str.Append("}");
            return str.ToString();
        }

        /// <summary>
        /// 门店客流客单查询(导出Excel)
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public static void View_ToExcel(string storesid,string userid, string starttime, string endtime)
        {
            DataTable dte = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "月份";
            dc.DefaultValue = "";
            dte.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "消费金额";
            dc.DefaultValue = "";
            dte.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "客流";
            dc.DefaultValue = "";
            dte.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "客单";
            dc.DefaultValue = "";
            dte.Columns.Add(dc);
            DAL.customer.UserConsumption ucDAL = new DAL.customer.UserConsumption();
            List<Model.customer.UserConsumption> ucList = ucDAL.ReadList_CommodityID(storesid, starttime, endtime, "");
            DateTime dt = DateTime.Parse(starttime);
            DateTime endDate = DateTime.Parse(endtime);
            int num = endDate.Year * 12 + endDate.Month - dt.Year * 12 - dt.Month;


            if (num > 0)
            {
                int icount = 0;
                for (int i = 0; i <= num; i++)
                {
                    icount++;
                    DateTime dtn = dt.AddMonths(i);
                    List<Model.customer.UserConsumption> ucModelList = ucList.FindAll(delegate(Model.customer.UserConsumption uc) { return uc.IsCash != "0" && DateTime.Parse(uc.addtime).ToString("yyyyMM").Equals(dtn.ToString("yyyyMM")); });
                    double uNum = 0;
                    foreach (Model.customer.UserConsumption uc in ucModelList)
                    {
                        uNum += double.Parse(uc.price);
                    }
                    DataRow dr = dte.NewRow();
                    dr[0] = dtn.ToString("yyyy-MM");
                    dr[1] = String.Format("{0:N2}",uNum);
                    dr[2] = ucModelList.Count.ToString();
                    dr[3] = (uNum > 0 ? String.Format("{0:N2}",Math.Round(uNum / ucModelList.Count, 2)) : "0");
                    dte.Rows.Add(dr);
                }
            }
            if (dte.Rows.Count > 0)
            {
                string FileName = Base.Fun.Management.RealDirectory(Sys.SiteInfo.UpFile + "Files/Consumption_" + userid + ".xls");
                Base.IO.Dir.CheckDir(Base.IO.Dir.ReMoveFileName(FileName));
                Base.Office.ExcelHelper.Export(dte, "门店客流客单查询", FileName);
                System.Web.HttpContext.Current.Response.Write(SyCms.Window.DownFile.DownFileName(FileName, "门店客流客单查询.xls", true));
            }
            dte.Dispose();
        }
    }
}
