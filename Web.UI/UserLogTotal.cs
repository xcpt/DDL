using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using System.Data.Common;

namespace Web.UI
{
    public class UserLogTotal
    {
        /// <summary>
        /// 用户读取显示
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="TableName"></param>
        /// <param name="Stime"></param>
        /// <param name="Etime"></param>
        /// <returns></returns>
        public static string UserViewChart(string UserID, string TableName, string Stime, string Etime)
        {
            StringBuilder strXml = new StringBuilder();
            Base.Conn.Database db = new Base.Conn.Database();
            string sql = " Where UserID=" + UserID;
            if (TableName.Length > 0)
            {
                sql += " and TableName Like " + Base.DataBase.Difference.BigN("") + "'%" + TableName + "%'";
            }
            if (Base.Fun.fun.IsDate(Stime))
            {
                sql += " and " + Base.DataBase.Difference.Time_GetDatediff("", Base.DataBase.Difference.Time_DateDiffParameter.Day, "'" + Stime + "'", "[DateTime]") + ">=0";
            }
            if (Base.Fun.fun.IsDate(Etime))
            {
                sql += " and " + Base.DataBase.Difference.Time_GetDatediff("", Base.DataBase.Difference.Time_DateDiffParameter.Day, "'" + Etime + "'", "[DateTime]") + "<=0";
            }
            DataTable dt = db.GetData("Select distinct top 30 " + Base.DataBase.Difference.Time_Format("", "[DateTime]") + " as AddTime From [Manager_Users_LogTotal] " + sql + " Order by AddTime");
            if (dt.Rows.Count > 0)
            {
                strXml.Append("<graph lineThickness='0' canvasBorderThickness='0' alternateHGridAlpha='5' canvasBorderColor='666666' divLineColor='ff5904' divLineAlpha='20' showAlternateHGridColor='1' AlternateHGridColor='ff5904' hovercapbg='FFECAA' hovercapborder='F47E00' formatNumberScale='0' decimalPrecision='0' showvalues='0' numdivlines='4' numVdivlines='0' rotateNames='0'>");
                StringBuilder Dstr = new StringBuilder();
                StringBuilder str1 = new StringBuilder();
                StringBuilder str2 = new StringBuilder();
                StringBuilder str3 = new StringBuilder();
                StringBuilder str4 = new StringBuilder();
                StringBuilder str5 = new StringBuilder();
                str1.Append("<dataset seriesName='Add' color='1D8BD1' anchorBorderColor='1D8BD1' anchorBgColor='1D8BD1'>");
                str2.Append("<dataset seriesName='Modiy' color='F1683C' anchorBorderColor='F1683C' anchorBgColor='F1683C'>");
                str3.Append("<dataset seriesName='Del' color='2AD62A' anchorBorderColor='2AD62A' anchorBgColor='2AD62A'>");
                str4.Append("<dataset seriesName='Audit' color='000000' anchorBorderColor='000000' anchorBgColor='000000'>");
                str5.Append("<dataset seriesName='Other' color='FFFF00' anchorBorderColor='FFFF00' anchorBgColor='FFFF00'>");
                Dstr.Append("<categories>");
                foreach (DataRow dr in dt.Rows)
                {
                    Dstr.Append("<category name='" + DateTime.Parse(dr[0].ToString()).ToString("MM-dd") + "' />");
                    DataTable dt1 = db.GetData("Select Sum(AddNum),Sum(ModiyNum),Sum(DelNum),Sum(AuditNum),Sum(OtherNum) From [Manager_Users_LogTotal] " + sql + " And " + Base.DataBase.Difference.Time_GetDatediff("", Base.DataBase.Difference.Time_DateDiffParameter.Day, "DateTime", "'" + dr[0].ToString() + "'") + "=0");
                    foreach (DataRow dr1 in dt1.Rows)
                    {
                        str1.Append("<set value='" + dr1[0].ToString() + "'/>");
                        str2.Append("<set value='" + dr1[1].ToString() + "'/>");
                        str3.Append("<set value='" + dr1[2].ToString() + "'/>");
                        str4.Append("<set value='" + dr1[3].ToString() + "'/>");
                        str5.Append("<set value='" + dr1[4].ToString() + "'/>");
                    }
                    dt1.Dispose();
                }
                str5.Append("</dataset>");
                str4.Append("</dataset>");
                str3.Append("</dataset>");
                str2.Append("</dataset>");
                str1.Append("</dataset>");
                Dstr.Append("</categories>");
                strXml.Append(Dstr.ToString() + str1.ToString() + str2.ToString() + str3.ToString() + str4.ToString() + str5.ToString() + "</graph>");
            }
            dt.Dispose();
            db.Dispose();
            return strXml.ToString();
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="StoresID"></param>
        /// <param name="TableName"></param>
        /// <param name="Stime"></param>
        /// <param name="Etime"></param>
        public static string ViewChart(string StoresID, string TableName, string Stime, string Etime)
        {
            StringBuilder strXml = new StringBuilder();
            Base.Conn.Database db = new Base.Conn.Database();
            string sql = " Where a.UserID in(SELECT [UserID] FROM [Manager_Users] Where [StoresID]=" + StoresID + ")";
            if (TableName.Length > 0)
            {
                sql += " and a.TableName Like "+Base.DataBase.Difference.BigN("")+"'%" + TableName + "%'";
            }
            if (Base.Fun.fun.IsDate(Stime))
            {
                sql += " and " + Base.DataBase.Difference.Time_GetDatediff("", Base.DataBase.Difference.Time_DateDiffParameter.Day, "'" + Stime + "'", "a.[DateTime]") + ">=0";
            }
            if (Base.Fun.fun.IsDate(Etime))
            {
                sql += " and " + Base.DataBase.Difference.Time_GetDatediff("", Base.DataBase.Difference.Time_DateDiffParameter.Day, "'" + Etime + "'", "a.[DateTime]") + "<=0";
            }
            DataTable dt = db.GetData("Select distinct " + Base.DataBase.Difference.Time_Format("", "a.[DateTime]") + " as AddTime From [Manager_Users_LogTotal] as a " + sql + " Order by AddTime");
            if (dt.Rows.Count > 0)
            {
                strXml.Append("<graph lineThickness='0' canvasBorderThickness='0' alternateHGridAlpha='5' canvasBorderColor='666666' divLineColor='ff5904' divLineAlpha='20' showAlternateHGridColor='1' AlternateHGridColor='ff5904' hovercapbg='FFECAA' hovercapborder='F47E00' formatNumberScale='0' decimalPrecision='0' showvalues='0' numdivlines='4' numVdivlines='0' rotateNames='0'>");
                StringBuilder Dstr = new StringBuilder();
                StringBuilder str1 = new StringBuilder();
                StringBuilder str2 = new StringBuilder();
                StringBuilder str3 = new StringBuilder();
                StringBuilder str4 = new StringBuilder();
                StringBuilder str5 = new StringBuilder();
                str1.Append("<dataset seriesName='Add' color='1D8BD1' anchorBorderColor='1D8BD1' anchorBgColor='1D8BD1'>");
                str2.Append("<dataset seriesName='Modiy' color='F1683C' anchorBorderColor='F1683C' anchorBgColor='F1683C'>");
                str3.Append("<dataset seriesName='Del' color='2AD62A' anchorBorderColor='2AD62A' anchorBgColor='2AD62A'>");
                str4.Append("<dataset seriesName='Audit' color='000000' anchorBorderColor='000000' anchorBgColor='000000'>");
                str5.Append("<dataset seriesName='Other' color='FFFF00' anchorBorderColor='FFFF00' anchorBgColor='FFFF00'>");
                Dstr.Append("<categories>");
                foreach (DataRow dr in dt.Rows)
                {
                    Dstr.Append("<category name='" + DateTime.Parse(dr[0].ToString()).ToString("MM-dd") + "' />");
                    DataTable dt1 = db.GetData("Select Sum(a.AddNum),Sum(a.ModiyNum),Sum(a.DelNum),Sum(a.AuditNum),Sum(a.OtherNum) From [Manager_Users_LogTotal] as a " + sql + " And " + Base.DataBase.Difference.Time_GetDatediff("", Base.DataBase.Difference.Time_DateDiffParameter.Day, "a.DateTime", "'" + dr[0].ToString() + "'") + "=0");
                    foreach (DataRow dr1 in dt1.Rows)
                    {
                        str1.Append("<set value='" + dr1[0].ToString() + "'/>");
                        str2.Append("<set value='" + dr1[1].ToString() + "'/>");
                        str3.Append("<set value='" + dr1[2].ToString() + "'/>");
                        str4.Append("<set value='" + dr1[3].ToString() + "'/>");
                        str5.Append("<set value='" + dr1[4].ToString() + "'/>");
                    }
                    dt1.Dispose();
                }
                str5.Append("</dataset>");
                str4.Append("</dataset>");
                str3.Append("</dataset>");
                str2.Append("</dataset>");
                str1.Append("</dataset>");
                Dstr.Append("</categories>");
                strXml.Append(Dstr.ToString() + str1.ToString() + str2.ToString() + str3.ToString() + str4.ToString() + str5.ToString() + "</graph>");
            }
            dt.Dispose();
            db.Dispose();
            return strXml.ToString();
        }
        /// <summary>
        /// 用户
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="TableName"></param>
        /// <param name="Stime"></param>
        /// <param name="Etime"></param>
        public static void UserExportExcel(string UserID,string TableName,string Stime,string Etime)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string sql = " Where UserID=" + UserID;
            if (TableName.Length > 0)
            {
                sql += " and TableName Like " + Base.DataBase.Difference.BigN("") + "'%" + TableName + "%'";
            }
            if (Base.Fun.fun.IsDate(Stime))
            {
                sql += " and " + Base.DataBase.Difference.Time_GetDatediff("", Base.DataBase.Difference.Time_DateDiffParameter.Day, "'" + Stime + "'", "[DateTime]") + ">=0";
            }
            if (Base.Fun.fun.IsDate(Etime))
            {
                sql += " and " + Base.DataBase.Difference.Time_GetDatediff("", Base.DataBase.Difference.Time_DateDiffParameter.Day, "'" + Etime + "'", "[DateTime]") + "<=0";
            }
            DataTable dt = db.GetData("Select " + Base.DataBase.Difference.Time_Format("", "[DateTime]") + ",[TableName],[AddNum],[ModiyNum],[DelNum],[AuditNum],[OtherNum] From [Manager_Users_LogTotal] " + sql + " Order by TableName,DateTime");
            if (dt.Rows.Count > 0)
            {
                dt.Columns[0].ColumnName = "时间";
                dt.Columns[1].ColumnName = "对应表";
                dt.Columns[2].ColumnName = "添加";
                dt.Columns[3].ColumnName = "修改";
                dt.Columns[4].ColumnName = "删除";
                dt.Columns[5].ColumnName = "审核";
                dt.Columns[6].ColumnName = "其它";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["TableName"] = Base.Log.Log.ChineseTableName(1, "TableName", dt.Rows[i]["TableName"].ToString(), db);
                }
                string UserName = Web.UI.Users.GetuName(UserID) + "绩效记录";
                string FileName = Base.Fun.Management.RealDirectory(Sys.SiteInfo.UpFile + "UserID_" + UserID + ".xls");
                Base.Office.ExcelHelper.Export(dt, UserName, FileName);
                HttpContext.Current.Response.Write(SyCms.Window.DownFile.DownFileName(FileName));
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("无数据导出。");
            }
            dt.Dispose();
            db.Dispose();
        }
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="StoresID"></param>
        /// <param name="UserID"></param>
        /// <param name="TableName"></param>
        /// <param name="Stime"></param>
        /// <param name="Etime"></param>
        public static void ExportExcel(string StoresID, string UserID, string TableName, string Stime, string Etime)
        {
            Web.DAL.UserLogTotal ULTBLL = new DAL.UserLogTotal();
            string sql = " Where a.UserID in(SELECT [UserID] FROM [Manager_Users] Where [StoresID]=" + StoresID + ")";
            if (TableName.Length > 0)
            {
                sql += " and a.TableName Like " + Base.DataBase.Difference.BigN("") + "'%" + TableName + "%'";
            }
            if (Base.Fun.fun.IsDate(Stime))
            {
                sql += " and " + Base.DataBase.Difference.Time_GetDatediff("", Base.DataBase.Difference.Time_DateDiffParameter.Day, "'" + Stime + "'", "[DateTime]") + ">=0";
            }
            if (Base.Fun.fun.IsDate(Etime))
            {
                sql += " and " + Base.DataBase.Difference.Time_GetDatediff("", Base.DataBase.Difference.Time_DateDiffParameter.Day, "'" + Etime + "'", "[DateTime]") + "<=0";
            }
            DataTable dt = ULTBLL.Read_DataTable(sql);
            if (dt.Rows.Count > 0)
            {
                dt.Columns[1].ColumnName = "姓名";
                dt.Columns[1].ColumnName = "时间";
                dt.Columns[2].ColumnName = "对应表";
                dt.Columns[3].ColumnName = "添加";
                dt.Columns[4].ColumnName = "修改";
                dt.Columns[5].ColumnName = "删除";
                dt.Columns[6].ColumnName = "审核";
                dt.Columns[7].ColumnName = "其它";
                SortedDictionary<string, string> Time = new SortedDictionary<string, string>();
                Base.Conn.Database db = new Base.Conn.Database();
                string TimeStr = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TimeStr = DateTime.Parse(dt.Rows[i]["DateTime"].ToString()).ToString("yyyy-MM-DD");
                    if (!Time.ContainsKey(TimeStr))
                    {
                        Time.Add(TimeStr, "");
                    }
                    dt.Rows[i]["TableName"] = Base.Log.Log.ChineseTableName(1, "TableName", dt.Rows[i]["TableName"].ToString(), db);
                }
                db.Dispose();

                if (Time.Count > 0)
                {
                    foreach (string t in Time.Keys)
                    {
                        DataTable dt3 = ULTBLL.Read_Num(sql, t);
                        object[] obj = new object[dt3.Columns.Count];
                        foreach (DataRow dr1 in dt3.Rows)
                        {
                            dr1.ItemArray.CopyTo(obj, 0);
                            dt.Rows.Add(obj);
                        }
                        obj = null;
                        dt3.Dispose();
                    }
                }
                string DepName = "部门绩效记录";
                string FileName = Base.Fun.Management.RealDirectory(Sys.SiteInfo.UpFile + "DepartmentID_" + UserID + ".xls");
                Base.Office.ExcelHelper.Export(dt, DepName, FileName);
                HttpContext.Current.Response.Write(SyCms.Window.DownFile.DownFileName(FileName));
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("无数据导出。");
            }
        }
    }
}
