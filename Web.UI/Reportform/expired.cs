using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Web.UI.Reportform
{
    /// <summary>
    /// 收入分析
    /// </summary>
    public class expired
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="souce"></param>
        /// <returns></returns>
        public static string View(string storesid, string title, string starttime, string endtime, string souce)
        {
            StringBuilder str = new StringBuilder();
            DAL.customer.CardType ctDAL = new DAL.customer.CardType();
            List<Model.customer.CardType> ctList = ctDAL.ReadList(storesid);
            DAL.customer.User uDAL = new DAL.customer.User();
            List<Model.customer.User> uList = uDAL.ReadList_AllNewCard(storesid, starttime, endtime, title, souce);
            int i = 0;
            int icount1 = 0;
            double icount2 = 0;
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
                    i++;
                    str.Append("{\"id\":\"" + i.ToString() + "\", \"cell\":[");
                    str.Append("\"" + i.ToString() + "\",");
                    str.Append("\"&nbsp;&nbsp;&nbsp;&nbsp;" + ct.title + "\",");
                    icount1 += uModelList.Count;
                    str.Append("\"" + uModelList.Count.ToString() + "\",");
                    str.Append("\"" + uNum.ToString() + "\"");
                    icount2 += uNum;
                    str.Append("]},");
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
                i++;
                str.Append("{\"id\":\"" + i.ToString() + "\", \"cell\":[");
                str.Append("\"" + i.ToString() + "\",");
                str.Append("\"&nbsp;&nbsp;&nbsp;&nbsp;续卡\",");
                str.Append("\"" + uList.Count.ToString() + "\",");
                str.Append("\"" + uNum.ToString() + "\"");
                icount2 += uNum;
                str.Append("]},");
            }
            uList = uDAL.ReadList_AllAdjustmentCard(storesid, starttime, endtime, title, souce);
            if (uList.Count > 0)
            {
                double uNum = 0;
                foreach (Model.customer.User u in uList)
                {
                    uNum += double.Parse(u.cModel.price);
                }
                i++;
                str.Append("{\"id\":\"" + i.ToString() + "\", \"cell\":[");
                str.Append("\"" + i.ToString() + "\",");
                str.Append("\"&nbsp;&nbsp;&nbsp;&nbsp;调整\",");
                str.Append("\"" + uList.Count.ToString() + "\",");
                str.Append("\"" + uNum.ToString() + "\"");
                icount2 += uNum;
                str.Append("]},");
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
                    i++;
                    str.Append("{\"id\":\"" + i.ToString() + "\", \"cell\":[");
                    str.Append("\"" + i.ToString() + "\",");
                    str.Append("\"&nbsp;&nbsp;&nbsp;&nbsp;" + c.title + "\",");
                    icount1 += ucModelList.Count;
                    str.Append("\"" + ucModelList.Count.ToString() + "\",");
                    str.Append("\"" + nNum.ToString() + "\"");
                    icount2 += nNum;
                    str.Append("]},");
                }
            }
            i++;
            str.Append("{\"id\":\"" + i.ToString() + "\", \"cell\":[");
            str.Append("\"" + i.ToString() + "\",");
            str.Append("\"<b>总计</b>\",");
            str.Append("\"" + icount1.ToString() + "\",");
            str.Append("\"" + icount2.ToString() + "\"");
            str.Append("]},");

            str.Remove(str.Length - 1, 1);
            return @"{" +
            "\"page\":1," +
            "\"total\":" + i.ToString() +
            ",\"rows\": [" + str.ToString()+"]" +
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
        public static void ViewToExcel(string storesid, string userid, string title, string starttime, string endtime, string souce)
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
            DAL.customer.User uDAL = new DAL.customer.User();
            List<Model.customer.User> uList = uDAL.ReadList_AllNewCard(storesid, starttime, endtime, title, souce);
            int i = 0;
            int icount1 = 0;
            double icount2 = 0;
            foreach (Model.customer.CardType ct in ctList)
            {
                i++;
                List<Model.customer.User> uModelList = uList.FindAll(delegate(Model.customer.User u) { return u.cModel.cardtypeid == ct.id; });
                double uNum = 0;
                foreach (Model.customer.User u in uModelList)
                {
                    uNum += double.Parse(u.cModel.price);
                }
                DataRow dr = dt.NewRow();
                dr[0] = ct.title;
                dr[1] = uModelList.Count.ToString();
                icount1 += uModelList.Count;
                dr[2] = uNum.ToString();
                icount2 += uNum;
                dt.Rows.Add(dr);
            }


            uList = uDAL.ReadList_AllRenewalCard(storesid, starttime, endtime, title, souce);
            if (uList.Count > 0)
            {
                double uNum = 0;
                foreach (Model.customer.User u in uList)
                {
                    uNum += double.Parse(u.cModel.price);
                }
                i++;
                DataRow dr = dt.NewRow();
                dr[0] = "续卡";
                dr[1] = uList.Count.ToString();
                icount1 += uList.Count;
                dr[2] = uNum.ToString();
                icount2 += uNum;
                dt.Rows.Add(dr);
            }
            uList = uDAL.ReadList_AllAdjustmentCard(storesid, starttime, endtime, title, souce);
            if (uList.Count > 0)
            {
                double uNum = 0;
                foreach (Model.customer.User u in uList)
                {
                    uNum += double.Parse(u.cModel.price);
                }
                i++;
                DataRow dr = dt.NewRow();
                dr[0] = "调整";
                dr[1] = uList.Count.ToString();
                icount1 += uList.Count;
                dr[2] = uNum.ToString();
                icount2 += uNum;
                dt.Rows.Add(dr);
            }

            DAL.Sys.Commodity cDAL = new DAL.Sys.Commodity();
            List<Model.Sys.Commodity> cList = cDAL.ReadList(storesid);


            DAL.customer.UserConsumption ucDAL = new DAL.customer.UserConsumption();
            List<Model.customer.UserConsumption> ucList = ucDAL.ReadList_CommodityID(storesid, starttime, endtime, souce);

            foreach (Model.Sys.Commodity c in cList)
            {
                i++;
                List<Model.customer.UserConsumption> ucModelList = ucList.FindAll(delegate(Model.customer.UserConsumption uc) { return uc.CommodityID.Equals(c.id) && uc.IsCash != "0"; });
                double nNum = 0;
                foreach (Model.customer.UserConsumption uc in ucModelList)
                {
                    nNum += double.Parse(uc.price);
                }
                DataRow dr = dt.NewRow();
                dr[0] = c.title;
                dr[1] = ucModelList.Count.ToString();
                icount1 += ucModelList.Count;
                dr[2] = nNum.ToString();
                icount2 += nNum;
                dt.Rows.Add(dr);
            }
            DataRow dr1 = dt.NewRow();
            dr1[0] = "总计";
            dr1[1] = icount1;
            dr1[2] = icount2;
            dt.Rows.Add(dr1);
            if (dt.Rows.Count > 0)
            {
                string FileName = Base.Fun.Management.RealDirectory(Sys.SiteInfo.UpFile + "Files/Expired_" + userid + ".xls");
                Base.IO.Dir.CheckDir(Base.IO.Dir.ReMoveFileName(FileName));
                Base.Office.ExcelHelper.Export(dt, "收入分析", FileName);
                System.Web.HttpContext.Current.Response.Write(SyCms.Window.DownFile.DownFileName(FileName, "收入分析.xls", true));
            }
            dt.Dispose();
        }
    }
}
