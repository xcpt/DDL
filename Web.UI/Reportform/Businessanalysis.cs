using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Web.UI.Reportform
{
    public class Businessanalysis
    {
        /// <summary>
        /// 经营收入
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public static string View(string storesid, string starttime, string endtime, string source)
        {
            StringBuilder str = new StringBuilder();
            DAL.customer.UserConsumption ucDAL = new DAL.customer.UserConsumption();
            List<Model.customer.UserConsumption> ucList = ucDAL.ReadList_Card(storesid, starttime, endtime, source);
            DAL.customer.CardType ctDAL = new DAL.customer.CardType();
            List<Model.customer.CardType> ctList = ctDAL.ReadList(storesid);

            int i = 0;
            int icount1 = 0;
            double icount2 = 0;
            double dprice = 0;
            foreach (Model.customer.CardType ct in ctList)
            {
                i++;
                dprice = double.Parse(ct.price) / (double.Parse(ct.positivenum) + double.Parse(ct.negativenum));
                List<Model.customer.UserConsumption> ucModelList = ucList.FindAll(delegate(Model.customer.UserConsumption uc) { return uc._CardTypeID == ct.id && uc.IsCash.Equals("0") && uc.Consumptiontype.Equals("0"); });
                double uNum = 0;
                int znum = 0;
                int fnum = 0;
                foreach (Model.customer.UserConsumption uc in ucModelList)
                {
                    uNum += dprice;
                    znum++;
                }
                ucModelList = ucList.FindAll(delegate(Model.customer.UserConsumption uc) { return uc._CardTypeID == ct.id && uc.IsCash.Equals("0") && uc.Consumptiontype.Equals("1"); });
                foreach (Model.customer.UserConsumption uc in ucModelList)
                {
                    uNum += dprice;
                    fnum++;
                }
                str.Append("{\"id\":\"" + i.ToString() + "\", \"cell\":[");
                str.Append("\"" + i.ToString() + "\",");
                str.Append("\"&nbsp;&nbsp;&nbsp;&nbsp;" + ct.title + "\",");
                icount1 += znum + fnum;
                str.Append("\"" + znum.ToString() + "/" + fnum.ToString() + "\",");
                str.Append("\"" + string.Format("{0:N2}", uNum) + "\"");
                icount2 += uNum;
                str.Append("]},");
            }

            i++;
            str.Append("{\"id\":\"" + i.ToString() + "\", \"cell\":[");
            str.Append("\"" + i.ToString() + "\",");
            str.Append("\"<b>总计</b>\",");
            str.Append("\"" + icount1.ToString() + "\",");
            str.Append("\"" + string.Format("{0:N2}", icount2) + "\"");
            str.Append("]},");

            str.Remove(str.Length - 1, 1);
            return @"{" +
            "\"page\":1," +
            "\"total\":" + i.ToString() +
            ",\"rows\": [" + str.ToString() + "]" +
            "}";
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="souce"></param>
        /// <returns></returns>
        public static void ViewToExcel(string storesid, string userid, string starttime, string endtime, string souce)
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "消费类别";
            dc.DefaultValue = "";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "次数";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "金额";
            dt.Columns.Add(dc);


            DAL.customer.CardType ctDAL = new DAL.customer.CardType();
            List<Model.customer.CardType> ctList = ctDAL.ReadList(storesid);
            DAL.customer.UserConsumption ucDAL = new DAL.customer.UserConsumption();
            List<Model.customer.UserConsumption> ucList = ucDAL.ReadList_Card(storesid, starttime, endtime, souce);
            int i = 0;
            int icount1 = 0;
            double icount2 = 0;
            double dprice = 0;
            foreach (Model.customer.CardType ct in ctList)
            {
                i++;
                dprice = double.Parse(ct.price) / (double.Parse(ct.positivenum) + double.Parse(ct.negativenum));
                List<Model.customer.UserConsumption> ucModelList = ucList.FindAll(delegate(Model.customer.UserConsumption uc) { return uc._CardTypeID == ct.id && uc.IsCash.Equals("0") && uc.Consumptiontype.Equals("0"); });
                double uNum = 0;
                int znum = 0;
                int fnum = 0;
                foreach (Model.customer.UserConsumption uc in ucModelList)
                {
                    uNum += dprice;
                    znum++;
                }
                ucModelList = ucList.FindAll(delegate(Model.customer.UserConsumption uc) { return uc._CardTypeID == ct.id && uc.IsCash.Equals("0") && uc.Consumptiontype.Equals("1"); });
                foreach (Model.customer.UserConsumption uc in ucModelList)
                {
                    uNum += dprice;
                    fnum++;
                }
                DataRow dr = dt.NewRow();
                dr[0] = ct.title;
                dr[1] = znum.ToString() + "/" + fnum.ToString();
                icount1 += znum + fnum;
                dr[2] = string.Format("{0:N2}", uNum);
                icount2 += uNum;
                dt.Rows.Add(dr);
            }
            DataRow dr1 = dt.NewRow();
            dr1[0] = "总计";
            dr1[1] = icount1;
            dr1[2] = string.Format("{0:N2}", icount2);
            dt.Rows.Add(dr1);
            if (dt.Rows.Count > 0)
            {
                string FileName = Base.Fun.Management.RealDirectory(Sys.SiteInfo.UpFile + "Files/Businessanalysis_" + userid + ".xls");
                Base.IO.Dir.CheckDir(Base.IO.Dir.ReMoveFileName(FileName));
                Base.Office.ExcelHelper.Export(dt, "营业分析", FileName);
                System.Web.HttpContext.Current.Response.Write(SyCms.Window.DownFile.DownFileName(FileName, "营业分析.xls", true));
            }
            dt.Dispose();
        }
    }
}
