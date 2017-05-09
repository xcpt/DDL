using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Web.UI.Reportform
{
    /// <summary>
    /// 小区办卡
    /// </summary>
    public class communityCard
    {
        /// <summary>
        /// 小区办卡
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="cardtypeId"></param>
        /// <returns></returns>
        public static string View(string storesid, string communityid, string starttime, string endtime, string cardtypeId)
        {
            DAL.customer.User uDAL = new DAL.customer.User();
            List<Model.customer.User> uList = uDAL.ReadList_AllNewCard(storesid, starttime, endtime, communityid, "");

            DAL.Sys.community cDAL = new DAL.Sys.community();
            List<Model.Sys.community> cList = cDAL.ReadList(storesid);

            DAL.customer.CardType ctDAL = new DAL.customer.CardType();
            List<Model.customer.CardType> ctList = ctDAL.ReadList(storesid);

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
                foreach (Model.customer.CardType ct in ctList)
                {
                    if (Base.Fun.fun.pnumeric(cardtypeId))
                    {
                        if (!ct.id.Equals(cardtypeId))
                        {
                            continue;
                        }
                    }

                    List<Model.customer.User> uModelList = uList.FindAll(delegate(Model.customer.User u) { return u.communityid.Equals(c.id) && u.cModel.cardtypeid.Equals(ct.id); });
                    inum = 0;
                    iprice = 0;
                    foreach (Model.customer.User u in uModelList)
                    {
                        inum++;
                        iprice += double.Parse(u.cModel.ctModel.price);
                    }
                    cinum += inum;
                    ciprice += iprice;
                    if (inum > 0)
                    {
                        icount++;
                        str.Append("{\"id\":\"" + icount.ToString() + "\", \"cell\":[");
                        str.Append("\"" + icount.ToString() + "\",");
                        str.Append("\"明细\",");
                        str.Append("\"" + c.title + "\",");
                        str.Append("\"" + ct.title + "\",");
                        str.Append("\"" + inum.ToString() + "\",");
                        str.Append("\"" + iprice.ToString() + "\"");
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
                    str.Append("\"" + ciprice.ToString() + "\"");
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
        /// 小区办卡
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="cardtypeId"></param>
        /// <returns></returns>
        public static void ViewToExcel(string storesid, string communityid, string userid, string starttime, string endtime, string cardtypeId)
        {
            DAL.customer.User uDAL = new DAL.customer.User();
            List<Model.customer.User> uList = uDAL.ReadList_AllNewCard(storesid, starttime, endtime, communityid, "");

            DAL.Sys.community cDAL = new DAL.Sys.community();
            List<Model.Sys.community> cList = cDAL.ReadList(storesid);

            DAL.customer.CardType ctDAL = new DAL.customer.CardType();
            List<Model.customer.CardType> ctList = ctDAL.ReadList(storesid);

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
            dc.ColumnName = "卡类型";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "次数";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "金额";
            dt.Columns.Add(dc);
            foreach (Model.Sys.community c in cList)
            {
                cinum = 0;
                ciprice = 0;
                foreach (Model.customer.CardType ct in ctList)
                {
                    if (Base.Fun.fun.pnumeric(cardtypeId))
                    {
                        if (!ct.id.Equals(cardtypeId))
                        {
                            continue;
                        }
                    }

                    List<Model.customer.User> uModelList = uList.FindAll(delegate(Model.customer.User u) { return u.communityid.Equals(c.id) && u.cModel.cardtypeid.Equals(ct.id); });
                    inum = 0;
                    iprice = 0;
                    foreach (Model.customer.User u in uModelList)
                    {
                        inum++;
                        iprice += double.Parse(u.cModel.ctModel.price);
                    }
                    cinum += inum;
                    ciprice += iprice;
                    if (inum > 0)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = "";
                        dr[1] = c.title;
                        dr[2] = ct.title;
                        dr[3] = inum.ToString();
                        dr[4] = iprice.ToString();
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
                    dt.Rows.Add(dr);
                }
            }
            if (dt.Rows.Count > 0)
            {
                string FileName = Base.Fun.Management.RealDirectory(Sys.SiteInfo.UpFile + "Files/communityCard_" + userid + ".xls");
                Base.IO.Dir.CheckDir(Base.IO.Dir.ReMoveFileName(FileName));
                Base.Office.ExcelHelper.Export(dt, "小区办卡情况", FileName);
                System.Web.HttpContext.Current.Response.Write(SyCms.Window.DownFile.DownFileName(FileName, "小区办卡情况.xls", true));
            }
            dt.Dispose();
        }
    }
}
