using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Web.UI.Reportform
{
    /// <summary>
    /// 小区商品
    /// </summary>
    public class communityCommodity
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="CommodityID"></param>
        /// <returns></returns>
        public static string View(string storesid, string starttime, string endtime, string CommodityID)
        {
            DAL.customer.UserConsumption ucDAL = new DAL.customer.UserConsumption();
            List<Model.customer.UserConsumption> ucList = ucDAL.ReadList_CommunityID(storesid, starttime, endtime,"");

            DAL.Sys.community cDAL = new DAL.Sys.community();
            List<Model.Sys.community> cList = cDAL.ReadList(storesid);

            DAL.Sys.Commodity cdDAL = new DAL.Sys.Commodity();
            List<Model.Sys.Commodity> cdList = cdDAL.ReadList(storesid);

            int icount = 0;
            int inum = 0;
            double iprice = 0;
            int cinum = 0;
            double ciprice = 0;
            StringBuilder str = new StringBuilder();

            foreach (Model.Sys.community c in cList)
            {
                cinum = 0;
                ciprice = 0;
                foreach (Model.Sys.Commodity cd in cdList)
                {
                    if (Base.Fun.fun.pnumeric(CommodityID))
                    {
                        if (!cd.id.Equals(CommodityID))
                        {
                            continue;
                        }
                    }
                    Dictionary<string, string> ulist = new Dictionary<string, string>();
                    List<Model.customer.UserConsumption> ucModelList = ucList.FindAll(delegate(Model.customer.UserConsumption uc) { return uc._CommunityID.Equals(c.id) && uc.CommodityID.Equals(cd.id); });
                    inum = 0;
                    iprice = 0;
                    foreach (Model.customer.UserConsumption uc in ucModelList)
                    {
                        //if (!ulist.ContainsKey(uc.userid))
                        //{
                        //    ulist.Add(uc.userid, uc.userid);
                            inum++;
                        //}
                        iprice += double.Parse(uc.price);
                    }
                    cinum += inum;
                    ciprice += iprice;
                    if (inum > 0)
                    {
                        icount++;
                        str.Append("{\"id\":\"" + icount.ToString() + "\", \"cell\":[");
                        str.Append("\"" + icount.ToString() + "\",");
                        str.Append("\"\",");
                        str.Append("\"" + c.title + "\",");
                        str.Append("\"" + cd.title + "\",");
                        str.Append("\"" + inum.ToString() + "\",");
                        str.Append("\"" + iprice.ToString() + "\",");
                        str.Append("\"" + Math.Round(iprice/inum,2).ToString() + "\"");
                        str.Append("]},");
                    }
                }
                if (cinum > 0)
                {
                    icount++;
                    str.Append("{\"id\":\"" + icount.ToString() + "\", \"cell\":[");
                    str.Append("\"" + icount.ToString() + "\",");
                    str.Append("\"<b>汇总</b>\",");
                    str.Append("\"\",");
                    str.Append("\"\",");
                    str.Append("\"" + cinum.ToString() + "\",");
                    str.Append("\"" + ciprice.ToString() + "\",");
                    str.Append("\"" + Math.Round(ciprice / cinum, 2).ToString() + "\"");
                    str.Append("]},");
                }
            }
            if (str.Length > 0)
            {
                str.Remove(str.Length - 1, 1);
            }
            return @"{" +
            "\"page\":1," +
            "\"total\":" + icount.ToString() +
            ",\"rows\": [" + str.ToString()+"]" +
            "}";
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="CommodityID"></param>
        /// <returns></returns>
        public static void ViewToExcel(string storesid,string userid, string starttime, string endtime, string CommodityID)
        {
            DAL.customer.UserConsumption ucDAL = new DAL.customer.UserConsumption();
            List<Model.customer.UserConsumption> ucList = ucDAL.ReadList_CommunityID(storesid, starttime, endtime,"");

            DAL.Sys.community cDAL = new DAL.Sys.community();
            List<Model.Sys.community> cList = cDAL.ReadList(storesid);

            DAL.Sys.Commodity cdDAL = new DAL.Sys.Commodity();
            List<Model.Sys.Commodity> cdList = cdDAL.ReadList(storesid);

            int inum = 0;
            double iprice = 0;
            int cinum = 0;
            double ciprice = 0;
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = " ";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "小区名称";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "商品名称";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "客流";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "销售额";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "客单";
            dt.Columns.Add(dc);
            foreach (Model.Sys.community c in cList)
            {
                cinum = 0;
                ciprice = 0;
                foreach (Model.Sys.Commodity cd in cdList)
                {
                    if (Base.Fun.fun.pnumeric(CommodityID))
                    {
                        if (!cd.id.Equals(CommodityID))
                        {
                            continue;
                        }
                    }
                    Dictionary<string, string> ulist = new Dictionary<string, string>();
                    List<Model.customer.UserConsumption> ucModelList = ucList.FindAll(delegate(Model.customer.UserConsumption uc) { return uc._CommunityID.Equals(c.id) && uc.CommodityID.Equals(cd.id); });
                    inum = 0;
                    iprice = 0;
                    foreach (Model.customer.UserConsumption uc in ucModelList)
                    {
                        //if (!ulist.ContainsKey(uc.userid))
                        //{
                        //    ulist.Add(uc.userid, uc.userid);
                            inum++;
                        //}
                        iprice += double.Parse(uc.price);
                    }
                    cinum += inum;
                    ciprice += iprice;
                    if (inum > 0)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = "";
                        dr[1] = c.title;
                        dr[2] = cd.title;
                        dr[3] = inum.ToString();
                        dr[4] = iprice.ToString();
                        dr[5] = Math.Round(iprice / inum, 2).ToString();
                        dt.Rows.Add(dr);
                    }
                }
                if (cinum > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = "汇总";
                    dr[1] = "";
                    dr[2] = "";
                    dr[3] = cinum.ToString();
                    dr[4] = ciprice.ToString();
                    dr[5] = Math.Round(ciprice / cinum, 2).ToString();
                    dt.Rows.Add(dr);
                }
            }
            if (dt.Rows.Count > 0)
            {
                string FileName = Base.Fun.Management.RealDirectory(Sys.SiteInfo.UpFile + "Files/communityCommodity_" + userid + ".xls");
                Base.IO.Dir.CheckDir(Base.IO.Dir.ReMoveFileName(FileName));
                Base.Office.ExcelHelper.Export(dt, "小区销售商品情况", FileName);
                System.Web.HttpContext.Current.Response.Write(SyCms.Window.DownFile.DownFileName(FileName, "小区销售商品情况.xls", true));
            }
            dt.Dispose();
        }
    }
}
