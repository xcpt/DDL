using System;
using System.Data;
using System.Web;
using System.Text;
namespace Web.CS.Manager.Log
{
    public partial class Lists_Export : Web.UI.Permissions
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Base.Fun.Fetch.getpost("action");
            DataTable dt = null;
            switch (action)
            {
                case "page":
                    {
                        string id = Base.Fun.Fetch.getpost("id");
                        if (Base.Fun.fun.pnumeric(id.Replace(",", "")))
                        {
                            Base.Conn.Database db = new Base.Conn.Database();
                            dt = db.GetData("SELECT [LogID] as '编号',[Name] as '操作人',[IP] as 'IP地址',[AddTime] as '操作时间'," + Base.DataBase.Difference.ToString("", "[TypeID]") + " as '操作类型',[TableName] as '表名称',[url] as '操作地址',[Description] as '对象ID' From [Manager_Log] Where LogID in(" + id + ") order by LogID desc");
                            db.Dispose();
                        }
                        else
                        {
                            SyCms.Window.WindowsReturn.WindowsReturnAlert("错误：参数传递错误。");
                        }
                        break;
                    }
                case "page10":
                    {
                        int pagesize = 10;
                        int pageInt = 0;
                        string page = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("page"));
                        if (Base.Fun.fun.pnumeric(page))
                        {
                            pageInt = int.Parse(page) - 1;
                        }
                        StringBuilder sqlwhile = new StringBuilder();
                        string Name = Base.Fun.fun.NoCon(Base.Fun.Fetch.getpost("Name"));
                        if (Name.Length > 0)
                        {
                            sqlwhile.Append(" and [Name] like " + Base.DataBase.Difference.BigN("") + "'%" + Name + "%'");
                        }
                        string TableName = Base.Fun.fun.NoCon(Base.Fun.Fetch.getpost("TableName"));
                        if (TableName.Length > 0)
                        {
                            string Description = Base.Fun.fun.NoCon(Base.Fun.Fetch.getpost("Description"));
                            if (Description.Length > 0)
                            {
                                sqlwhile.Append(" and [TableName] = " + Base.DataBase.Difference.BigN("") + "'" + TableName + "'");
                                sqlwhile.Append(" and [Description]=" + Base.DataBase.Difference.BigN("") + "'" + Description + "'");
                            }
                            else
                            {
                                sqlwhile.Append(" and [TableName] like " + Base.DataBase.Difference.BigN("") + "'%" + TableName + "%'");
                            }
                        }
                        string Url = Base.Fun.fun.NoCon(Base.Fun.Fetch.getpost("SUrl"));
                        if (Url.Length > 0)
                        {
                            sqlwhile.Append(" and [Url] Like " + Base.DataBase.Difference.BigN("") + "'%" + Url + "%'");
                        }
                        string Stime = Base.Fun.Fetch.getpost("Stime");
                        if (Base.Fun.fun.IsDate(Stime))
                        {
                            string StimeH = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("StimeH"));
                            sqlwhile.Append(" and " + Base.DataBase.Difference.Time_GetDatediff("", Base.DataBase.Difference.Time_DateDiffParameter.Hour, "[AddTime]", "'" + Stime + " " + StimeH + ":00:00'") + "<=0");
                        }
                        string Etime = Base.Fun.Fetch.getpost("Etime");
                        if (Base.Fun.fun.IsDate(Etime))
                        {
                            string EtimeH = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("EtimeH"));
                            sqlwhile.Append(" and " + Base.DataBase.Difference.Time_GetDatediff("", Base.DataBase.Difference.Time_DateDiffParameter.Second, "[AddTime]", "'" + Etime + " " + EtimeH + ":00:00'") + ">=0");
                        }

                        Base.Conn.Database db = new Base.Conn.Database();
                        if (pageInt == 0)
                        {
                            dt = db.GetData("SELECT top " + (pagesize * Web.UI.Sys.SiteInfo.GetPageSize()).ToString() + " [LogID] as '编号',[Name] as '操作人',[IP] as 'IP地址',[AddTime] as '操作时间'," + Base.DataBase.Difference.ToString("", "[TypeID]") + " as '操作类型',[TableName] as '表名称',[url] as '操作地址',[Description] as '对象ID' From [Manager_Log] Where 1=1" + sqlwhile.ToString() + " order by [LogID] desc");
                        }
                        else
                        {
                            dt = db.GetData("SELECT top " + (pagesize * Web.UI.Sys.SiteInfo.GetPageSize()).ToString() + " [LogID] as '编号',[Name] as '操作人',[IP] as 'IP地址',[AddTime] as '操作时间'," + Base.DataBase.Difference.ToString("", "[TypeID]") + " as '操作类型',[TableName] as '表名称',[url] as '操作地址',[Description] as '对象ID' From [Manager_Log] Where LogID not in(Select top " + (pageInt * Web.UI.Sys.SiteInfo.GetPageSize()).ToString() + " LogID From [Manager_Log] Where 1=1" + sqlwhile.ToString() + ")" + sqlwhile.ToString() + " order by [LogID] desc");
                        }
                        db.Dispose();
                        break;
                    }
            }
            if (dt != null)
            {
                int icount = dt.Rows.Count;
                Base.Conn.Database db = new Base.Conn.Database();
                for (int i = 0; i < icount; i++)
                {
                    dt.Rows[i]["表名称"] = Base.Log.Log.ChineseTableName(i, "TableName", dt.Rows[i]["表名称"].ToString(), db);
                    dt.Rows[i]["操作类型"] = Base.Log.Log.GetOperateName(int.Parse(Base.Fun.fun.IsZero(dt.Rows[i]["操作类型"].ToString())));
                }
                db.Dispose();
                string FileName = Base.Fun.Management.RealDirectory(Web.UI.Sys.SiteInfo.UpFile + "Log_" + UserID + ".xls");
                Base.Office.ExcelHelper.Export(dt, "后台操作日志", FileName);
                HttpContext.Current.Response.Write(SyCms.Window.DownFile.DownFileName(FileName));
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("无日志可导出。");
            }
            Response.End();
        }
    }
}