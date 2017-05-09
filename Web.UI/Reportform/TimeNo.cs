using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Web.UI.Reportform
{
    /// <summary>
    /// 时间段内未到店
    /// </summary>
    public class TimeNo
    {
        /// <summary>
        /// 输出
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static string View(string storesid, string num1, string num2)
        {
            DAL.customer.User uDAL = new DAL.customer.User();
            return uDAL.View_LastTimeUser(Web.UI.Sys.SiteInfo.GetPageSize(), storesid, Base.Fun.fun.IsZero(num1), Base.Fun.fun.IsZero(num2));
        }

        /// <summary>
        /// 输出
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static void ViewToExcel(string storesid, string userid, string num1, string num2)
        {
            DAL.customer.User uDAL = new DAL.customer.User();
            DataTable dt = uDAL.View_LastTimeUser＿DataTable(Web.UI.Sys.SiteInfo.GetPageSize(), storesid, Base.Fun.fun.IsZero(num1), Base.Fun.fun.IsZero(num2));
            if (dt.Rows.Count > 0)
            {
                dt.TableName = "User";
                dt.Columns[0].ColumnName = "编号";
                dt.Columns[1].ColumnName = "会员姓名";
                dt.Columns[2].ColumnName = "会员小名";
                dt.Columns[3].ColumnName = "性别";
                dt.Columns[4].ColumnName = "月龄";
                dt.Columns[5].ColumnName = "家长姓名";
                dt.Columns[6].ColumnName = "家长手机";
                dt.Columns[7].ColumnName = "所属小区";
                dt.Columns[8].ColumnName = "婴儿类型";
                dt.Columns[9].ColumnName = "备注";
                string FileName = Base.Fun.Management.RealDirectory(Sys.SiteInfo.UpFile + "Files/TimeNo_" + userid + ".xls");
                Base.IO.Dir.CheckDir(Base.IO.Dir.ReMoveFileName(FileName));
                Base.Office.ExcelHelper.Export(dt, "时间段内未到店客户", FileName);
                System.Web.HttpContext.Current.Response.Write(SyCms.Window.DownFile.DownFileName(FileName, "时间段内未到店客户.xls", true));
            }
            dt.Dispose();
        }
    }
}
