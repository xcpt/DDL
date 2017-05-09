using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Web.UI.Reportform
{
    public class AllTotal
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
            int num = 0;
            if (Base.Fun.fun.IsDate(starttime + "-1") && Base.Fun.fun.IsDate(endtime + "-1"))
            {
                DateTime dt1 = DateTime.Parse(starttime + "-1");
                DateTime dt2 = DateTime.Parse(endtime + "-1");
                num = ((dt2.Year - dt1.Year) * 12) + (dt2.Month - dt1.Month);
                DAL.customer.User uDAL = new DAL.customer.User();
                DAL.customer.CardType ctDAL = new DAL.customer.CardType();
                DAL.customer.Card cDAL = new DAL.customer.Card();
                DAL.customer.CardLog clDAL = new DAL.customer.CardLog();
                List<Model.customer.CardType> ctList = ctDAL.ReadList(storesid);
                for (int i = 0; i <= num; i++)
                {
                    str.Append("{\"id\":\"" + (i + 1).ToString() + "\", \"cell\":[");
                    str.Append("\"" + (i + 1).ToString() + "\",");
                    str.Append("\"" + dt1.AddMonths(i).ToString("yyyy-MM") + "\",");

                    starttime = dt1.AddMonths(i).ToString("yyyy-MM-dd");

                    string 资未达 = uDAL.View_consultTotal(storesid, starttime, starttime);
                    str.Append("\"" + 资未达 + "\",");
                    string 体未办 = uDAL.View_consultNoCardTotal(storesid, starttime, starttime);
                    str.Append("\"" + 体未办 + "\",");


                    double allprice = 0;
                    int numall = 0;
                    clDAL.Read_NewCardAllPrice(storesid, starttime, starttime, ref numall, ref allprice);
                    foreach (Model.customer.CardType ct in ctList)
                    {
                        string numstr = cDAL.Read_CardNum(storesid, ct.id, starttime, starttime);
                        str.Append("\"" + numstr + "\",");
                    }
                    //建卡总数
                    str.Append("\"" + numall.ToString() + "\",");

                    //续卡总数
                    string xknum = clDAL.View_Num(storesid, starttime, starttime, "1");
                    str.Append("\"" + xknum + "\",");
                    
                    
                    //合计
                    str.Append("\"" + (numall + int.Parse(xknum)).ToString() + "\",");

                    //新来店总数
                    string newprope = uDAL.View_Total(storesid, starttime, starttime);
                    str.Append("\"" + newprope + "\",");
                    //新建卡总收入
                    str.Append("\"" + allprice.ToString("f") + "\",");

                    //新建卡客单价
                    double dj = 0;
                    if (numall > 0)
                    {
                        dj = allprice / numall;
                    }
                    str.Append("\"" + dj.ToString("f") + "\",");


                    //续卡总收入
                    string xkprice = clDAL.View_Price(storesid, starttime, starttime);
                    str.Append("\"" + xkprice + "\",");
                    //续卡客单价
                    double xkdj = 0;
                    xkdj = double.Parse(Base.Fun.fun.IsZero(xkprice)) / double.Parse(Base.Fun.fun.IsZero(xknum));
                    str.Append("\"" + xkdj.ToString("f") + "\",");


                    string tzprice = clDAL.View_TiaoZhengPrice(storesid, starttime, starttime);
                    str.Append("\"" + tzprice + "\",");
                    str.Append("\"" + (allprice + double.Parse(Base.Fun.fun.IsZero(xkprice)) + double.Parse(Base.Fun.fun.IsZero(tzprice))) + "\",");

                    //办卡成功率
                    double bkl = 0;
                    if (Base.Fun.fun.pnumeric(newprope))
                    {
                        bkl = numall * 100 / double.Parse(Base.Fun.fun.IsZero(newprope));
                    }
                    str.Append("\"" + bkl.ToString("f") + "%\"");
                    str.Append("]},");
                }
                if (str.Length > 0)
                {
                    str.Remove(str.Length - 1, 1);
                }
            }
            return @"{" +
                "\"page\":1," +
                "\"total\":" + num.ToString() +
                ",\"rows\": [" + str.ToString() + "]" +
                "}";
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public static void ViewToExcel(string storesid, string userid, string starttime, string endtime)
        {
            int num = 0;
            if (Base.Fun.fun.IsDate(starttime + "-1") && Base.Fun.fun.IsDate(endtime + "-1"))
            {
                DateTime dt1 = DateTime.Parse(starttime + "-1");
                DateTime dt2 = DateTime.Parse(endtime + "-1");
                num = ((dt2.Year - dt1.Year) * 12) + (dt2.Month - dt1.Month);
                DAL.customer.User uDAL = new DAL.customer.User();
                DAL.customer.CardType ctDAL = new DAL.customer.CardType();
                DAL.customer.Card cDAL = new DAL.customer.Card();
                List<Model.customer.CardType> ctList = ctDAL.ReadList(storesid);

                DataTable dt = new DataTable();
                DataColumn dc = new DataColumn();
                dc.ColumnName = "编号";
                dc.DefaultValue = "";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "月份";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "咨未达";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "休未达";
                dt.Columns.Add(dc);
                foreach (Model.customer.CardType ct in ctList)
                {
                    dc = new DataColumn();
                    dc.ColumnName = ct.title;
                    dt.Columns.Add(dc);
                }
                dc = new DataColumn();
                dc.ColumnName = "建卡总数";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "续卡总数";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "合计";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "新来店总数";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "新建卡总收入";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "新建卡客单价";
                dt.Columns.Add(dc);
                dc.ColumnName = "续卡总收入";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "续卡客单价";
                dt.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "调整";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "合计";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "办卡成功率";
                dt.Columns.Add(dc);
                DAL.customer.CardLog clDAL = new DAL.customer.CardLog();

                for (int i = 0; i <= num; i++)
                {
                    DataRow dr = dt.NewRow();

                    dr[0] = (i + 1).ToString();
                    dr[1] = dt1.AddMonths(i).ToString("yyyy-MM");

                    starttime = dt1.AddMonths(i).ToString("yyyy-MM-dd");
                    string 资未达 = uDAL.View_consultTotal(storesid, starttime, starttime);
                    dr[2] = 资未达;
                    string 休未办 = uDAL.View_consultNoCardTotal(storesid, starttime, starttime);
                    dr[3] = 休未办;

                    int numall = 0;
                    double allprice = 0;
                    clDAL.Read_NewCardAllPrice(storesid, starttime, starttime, ref numall, ref allprice);
                    int i1 = 0;
                    foreach (Model.customer.CardType ct in ctList)
                    {
                        string numstr = cDAL.Read_CardNum(storesid, ct.id, starttime, starttime);
                        dr[i1 + 4] = numstr;
                        i1++;
                    }
                    dr[i1 + 5] = numall.ToString();
                    
                    string xknum = clDAL.View_Num(storesid, starttime, starttime, "1");
                    dr[i1 + 6] = xknum;

                    dr[i1 + 7] = (numall + int.Parse(xknum)).ToString();
                    string newprope = uDAL.View_Total(storesid, starttime, endtime);
                    dr[i1 + 8] = newprope;
                    dr[i1 + 9] = allprice;
                    double dj = 0;
                    if (numall > 0)
                    {
                        dj = allprice / numall;
                    }
                    dr[i1 + 10] = dj.ToString("f");
                    double bkl = 0;
                    if (Base.Fun.fun.pnumeric(newprope))
                    {
                        bkl = numall * 100 / double.Parse(Base.Fun.fun.IsZero(newprope));
                    }

                    //续卡总收入
                    string xkprice = clDAL.View_Price(storesid, starttime, starttime);
                    dr[i1 + 11] = xkprice;
                    //续卡客单价
                    double xkdj = 0;
                    xkdj = double.Parse(Base.Fun.fun.IsZero(xkprice)) / double.Parse(Base.Fun.fun.IsZero(xknum));
                    dr[i1 + 12] = xkdj.ToString("f");

                    string tzprice = clDAL.View_TiaoZhengPrice(storesid, starttime, starttime);
                    dr[i1 + 13] = tzprice;
                    dr[i1 + 14] = allprice + double.Parse(Base.Fun.fun.IsZero(xkprice)) + double.Parse(Base.Fun.fun.IsZero(tzprice));
                    dr[i1 + 15] = bkl.ToString("f");
                }
                if (dt.Rows.Count > 0)
                {
                    string FileName = Base.Fun.Management.RealDirectory(Sys.SiteInfo.UpFile + "Files/AllTotal_" + userid + ".xls");
                    Base.IO.Dir.CheckDir(Base.IO.Dir.ReMoveFileName(FileName));
                    Base.Office.ExcelHelper.Export(dt, "办卡率统计", FileName);
                    System.Web.HttpContext.Current.Response.Write(SyCms.Window.DownFile.DownFileName(FileName, "办卡率统计.xls", true));
                }
                dt.Dispose();
            }
        }
    }
}
