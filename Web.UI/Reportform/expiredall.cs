using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Web.UI.Reportform
{
    public class expiredall
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="souce"></param>
        /// <returns></returns>
        public static string View(string title, string starttime, string endtime, string souce)
        {
            StringBuilder str = new StringBuilder();
            DAL.customer.CardType ctDAL = new DAL.customer.CardType();

            Web.DAL.Sys.stores sDAL = new DAL.Sys.stores();
            List<Web.Model.Sys.stores> sList = sDAL.ReadList();
            int i = 0;
            double icount1 = 0;
            double icount2 = 0;
            foreach (Web.Model.Sys.stores s in sList)
            {
                if (s.Isoutlets.Equals("1"))
                {
                    string storesid = s.storesid;

                    List<Model.customer.CardType> ctList = ctDAL.ReadList(storesid);
                    DAL.customer.User uDAL = new DAL.customer.User();
                    List<Model.customer.User> uList = uDAL.ReadList_AllNewCard(storesid, starttime, endtime, title, souce);
  
                    
                    icount2 = 0;
                    foreach (Model.customer.CardType ct in ctList)
                    {
                        List<Model.customer.User> uModelList = uList.FindAll(delegate(Model.customer.User u) { return u.cModel.cardtypeid == ct.id; });
                        double uNum = 0;
                        foreach (Model.customer.User u in uModelList)
                        {
                            uNum += double.Parse(u.cModel.price);
                        }
                        if (uNum > 0)
                        {
                            icount2 += uNum;
                        }
                    }
                    uList = uDAL.ReadList_AllRenewalCard(storesid, starttime, endtime, title, souce);
                    if (uList.Count > 0)
                    {
                        double uNum = 0;
                        foreach (Model.customer.User u in uList)
                        {
                            uNum += double.Parse(u.cModel.price);
                        }
                        icount2 += uNum;
                    }
                    uList = uDAL.ReadList_AllAdjustmentCard(storesid, starttime, endtime, title, souce);
                    if (uList.Count > 0)
                    {
                        double uNum = 0;
                        foreach (Model.customer.User u in uList)
                        {
                            uNum += double.Parse(u.cModel.price);
                        }
                        icount2 += uNum;
                    }


                    DAL.Sys.Commodity cDAL = new DAL.Sys.Commodity();
                    List<Model.Sys.Commodity> cList = cDAL.ReadList(storesid);


                    DAL.customer.UserConsumption ucDAL = new DAL.customer.UserConsumption();
                    List<Model.customer.UserConsumption> ucList = ucDAL.ReadList_CommodityID(storesid, starttime, endtime, souce);
                    foreach (Model.Sys.Commodity c in cList)
                    {
                        List<Model.customer.UserConsumption> ucModelList = ucList.FindAll(delegate(Model.customer.UserConsumption uc) { return uc.CommodityID.Equals(c.id) && uc.IsCash != "0"; });
                        double nNum = 0;
                        foreach (Model.customer.UserConsumption uc in ucModelList)
                        {
                            nNum += double.Parse(uc.price);
                        }
                        if (nNum > 0)
                        {
                            icount2 += nNum;
                        }
                    }
                    i++;
                    str.Append("{\"id\":\"" + s.storesid + "\", \"cell\":[");
                    str.Append("\"" + i.ToString() + "\",");
                    str.Append("\"" + s.title + "\",");
                    str.Append("\"" + icount2.ToString() + "\"");
                    str.Append("]},");
                    icount1 += icount2;
                    
                }
            }
            str.Append("{\"id\":\"\", \"cell\":[");
            str.Append("\"\",");
            str.Append("\"<b>总计</b>\",");
            str.Append("\"" + icount1.ToString() + "\",");
            str.Append("]}");
            return @"{" +
                    "\"page\":1," +
                    "\"total\":" + i.ToString() +
                    ",\"rows\": [" + str.ToString() + "]" +
                    "}";
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="souce"></param>
        /// <returns></returns>
        public static void ViewToExcel(string userid, string title, string starttime, string endtime, string souce)
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "直营店名称";
            dc.DefaultValue = "";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "金额";
            dt.Columns.Add(dc);

            DAL.customer.CardType ctDAL = new DAL.customer.CardType();

            Web.DAL.Sys.stores sDAL = new DAL.Sys.stores();
            List<Web.Model.Sys.stores> sList = sDAL.ReadList();
            int i = 0;
            double icount1 = 0;
            double icount2 = 0;
            foreach (Web.Model.Sys.stores s in sList)
            {
                if (s.Isoutlets.Equals("1"))
                {
                    string storesid = s.storesid;
                    icount2 = 0;
                    List<Model.customer.CardType> ctList = ctDAL.ReadList(storesid);
                    DAL.customer.User uDAL = new DAL.customer.User();
                    List<Model.customer.User> uList = uDAL.ReadList_AllNewCard(storesid, starttime, endtime, title, souce);
                    foreach (Model.customer.CardType ct in ctList)
                    {
                        List<Model.customer.User> uModelList = uList.FindAll(delegate(Model.customer.User u) { return u.cModel.cardtypeid == ct.id; });
                        double uNum = 0;
                        foreach (Model.customer.User u in uModelList)
                        {
                            uNum += double.Parse(u.cModel.price);
                        }
                        icount2 += uNum;
                    }


                    uList = uDAL.ReadList_AllRenewalCard(storesid, starttime, endtime, title, souce);
                    if (uList.Count > 0)
                    {
                        double uNum = 0;
                        foreach (Model.customer.User u in uList)
                        {
                            uNum += double.Parse(u.cModel.price);
                        }
                        icount2 += uNum;
                    }
                    uList = uDAL.ReadList_AllAdjustmentCard(storesid, starttime, endtime, title, souce);
                    if (uList.Count > 0)
                    {
                        double uNum = 0;
                        foreach (Model.customer.User u in uList)
                        {
                            uNum += double.Parse(u.cModel.price);
                        }
                        icount2 += uNum;
                    }

                    DAL.Sys.Commodity cDAL = new DAL.Sys.Commodity();
                    List<Model.Sys.Commodity> cList = cDAL.ReadList(storesid);


                    DAL.customer.UserConsumption ucDAL = new DAL.customer.UserConsumption();
                    List<Model.customer.UserConsumption> ucList = ucDAL.ReadList_CommodityID(storesid, starttime, endtime, souce);

                    foreach (Model.Sys.Commodity c in cList)
                    {
                        List<Model.customer.UserConsumption> ucModelList = ucList.FindAll(delegate(Model.customer.UserConsumption uc) { return uc.CommodityID.Equals(c.id) && uc.IsCash != "0"; });
                        double nNum = 0;
                        foreach (Model.customer.UserConsumption uc in ucModelList)
                        {
                            nNum += double.Parse(uc.price);
                        }
                        icount2 += nNum;
                    }
                    DataRow dr1 = dt.NewRow();
                    dr1[0] = s.title;
                    dr1[1] = icount2;
                    dt.Rows.Add(dr1);
                    icount1 += icount2;
                }
            }
            DataRow dr = dt.NewRow();
            dr[0] = "总计";
            dr[1] = icount1;
            dt.Rows.Add(dr);

            if (dt.Rows.Count > 0)
            {
                string FileName = Base.Fun.Management.RealDirectory(Sys.SiteInfo.UpFile + "Files/ExpiredAll_" + userid + ".xls");
                Base.IO.Dir.CheckDir(Base.IO.Dir.ReMoveFileName(FileName));
                Base.Office.ExcelHelper.Export(dt, "直营店收入分析", FileName);
                System.Web.HttpContext.Current.Response.Write(SyCms.Window.DownFile.DownFileName(FileName, "直营店收入分析.xls", true));
            }
            dt.Dispose();
        }
    }
}
