using System;
using System.Text;
using System.Data;

namespace Web.UI.Reportform
{
    /// <summary>
    /// 卡次数
    /// </summary>
    public class CardNumber
    {
        /// <summary>
        /// 卡次数
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public static string View(string storesid, string stime, string etime)
        {
            DAL.customer.Card cDAL = new DAL.customer.Card();
            Model.customer.Card cModel = cDAL.Read_Total(storesid, stime, etime);
            Model.customer.Card cModel2 = cDAL.Read_TotalStatus(storesid, stime, etime);
            string CardNum = cDAL.Read_CardNum(storesid, stime, etime);
            DAL.customer.User uDAL = new DAL.customer.User();
            string UserNum = uDAL.Read_UserCount(storesid, stime, etime);
            string timestr = (Base.Fun.fun.IsDate(stime) ? DateTime.Parse(stime).ToString("yyyy-MM-dd") : "") + "-" + (Base.Fun.fun.IsDate(etime) ? DateTime.Parse(etime).ToString("yyyy-MM-dd") : "");
            StringBuilder str = new StringBuilder();
            str.Append("{");
            str.Append("\"page\":1,");
            str.Append("\"total\":2");
            str.Append(",\"rows\":[");
            str.Append("{\"id\":\"1\", \"cell\":[");
            str.Append("\"1\",");
            str.Append("\"" + timestr + "\",");
            str.Append("\"剩余\",");
            str.Append("\"" + cModel2.surpluspositivenum + "\",");
            str.Append("\"" + cModel2.surplusnegativenum + "\",");
            str.Append("\"" + double.Parse(Base.Fun.fun.IsZero(cModel2.surplusprice)).ToString("f") + "\"");
            str.Append("]},");

            str.Append("{\"id\":\"2\", \"cell\":[");
            str.Append("\"2\",");
            str.Append("\"" + timestr + "\",");
            str.Append("\"使用\",");
            str.Append("\"" + cModel.userpositivenum + "\",");
            str.Append("\"" + cModel.usernegativenum + "\",");
            str.Append("\"" + double.Parse(Base.Fun.fun.IsZero(cModel.userprice)).ToString("f") + "\"");
            str.Append("]},");

            str.Append("{\"id\":\"3\", \"cell\":[");
            str.Append("\"3\",");
            str.Append("\"" + timestr + "\",");
            str.Append("\"办卡率\",");
            str.Append("\"卡片：" + CardNum + "\",");
            str.Append("\"会员：" + UserNum + "\",");
            str.Append("\"" + (Base.Fun.fun.pnumeric(UserNum)?Math.Round(double.Parse(CardNum)*100/double.Parse(UserNum),2):0).ToString() + "%\"");
            str.Append("]}");

            str.Append("]");
            str.Append("}");
            return str.ToString();
        }
        /// <summary>
        /// 卡次数
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public static void ViewToExcel(string storesid, string userid, string stime, string etime)
        {
            DAL.customer.Card cDAL = new DAL.customer.Card();
            Model.customer.Card cModel = cDAL.Read_Total(storesid, stime, etime);
            Model.customer.Card cModel2 = cDAL.Read_TotalStatus(storesid, stime, etime);
            string CardNum = cDAL.Read_CardNum(storesid, stime, etime);
            DAL.customer.User uDAL = new DAL.customer.User();
            string UserNum = uDAL.Read_UserCount(storesid, stime, etime);

            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "项名";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "正价次数";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "赠送次数";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "金额";
            dt.Columns.Add(dc);

            DataRow dr = dt.NewRow();
            dr[0] = "剩余";
            dr[1] = cModel2.surpluspositivenum;
            dr[2] = cModel2.surplusnegativenum;
            dr[3] = double.Parse(Base.Fun.fun.IsZero(cModel2.surplusprice)).ToString("f");
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = "使用";
            dr[1] = cModel.userpositivenum;
            dr[2] = cModel.usernegativenum;
            dr[3] = double.Parse(Base.Fun.fun.IsZero(cModel.userprice)).ToString("f");
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = "办卡率";
            dr[1] = "卡片" + CardNum;
            dr[2] = "会员" + UserNum;
            dr[3] = (Base.Fun.fun.pnumeric(UserNum) ? Math.Round(double.Parse(CardNum) * 100 / double.Parse(UserNum), 2) : 0).ToString()+"%";
            dt.Rows.Add(dr);

            if (dt.Rows.Count > 0)
            {
                string FileName = Base.Fun.Management.RealDirectory(Sys.SiteInfo.UpFile + "Files/CardNumber_" + userid + ".xls");
                Base.IO.Dir.CheckDir(Base.IO.Dir.ReMoveFileName(FileName));
                Base.Office.ExcelHelper.Export(dt, "卡次及金额", FileName);
                System.Web.HttpContext.Current.Response.Write(SyCms.Window.DownFile.DownFileName(FileName, "卡次及金额.xls", true));
            }
            dt.Dispose();
        }
    }
}
