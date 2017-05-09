using System;
using System.IO;
namespace Web.CS.Manager.Log
{
    public partial class Del_Error : Web.UI.Permissions
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Base.Fun.Fetch.getpost("action");
            if (action.Length > 0)
            {
                DirectoryInfo d = new DirectoryInfo(Base.Fun.Management.RealDirectory("Log/Error/"));
                try
                {
                    FileInfo[] f = d.GetFiles("*.txt");
                    foreach (FileInfo _f in f)
                    {
                        if (action.Equals("all") || (action.Equals("month") && Base.Time.Time.TimeBad(_f.CreationTime.ToString(), DateTime.Now.ToString(), "天") > 30) || (action.Equals("work") && Base.Time.Time.TimeBad(_f.CreationTime.ToString(), DateTime.Now.ToString(), "天") > 7))
                        {
                            _f.Delete();
                        }
                    }
                    f = null;
                }
                catch (Exception)
                { }
                finally
                {
                    d = null;
                }
                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "删除成功，刷新列表");
                Response.Write("<script type=\"text/javascript\">AjaxFun('Manager/Log/Lists_Error.aspx',null,'','.Rnr');</script>");
            }
            Response.End();
        }
    }
}