using System;
namespace Web.CS.Manager.Users
{
    public partial class Lists_Chart : System.Web.UI.Page
    {
        protected string strXml = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string UserID = Base.Fun.Fetch.getpost("ID");
            string Stime = Base.Fun.Fetch.getpost("Stime");
            string Etime = Base.Fun.Fetch.getpost("Etime");
            string TableName = Base.Fun.fun.NoCon(Base.Fun.Fetch.getpost("TableName"));
            if (Base.Fun.fun.pnumeric(UserID))
            {
                strXml = Web.UI.UserLogTotal.UserViewChart(UserID, TableName, Stime, Etime);
                if (string.IsNullOrEmpty(strXml))
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert("无数据显示。");
                    Response.End();
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("无数据显示。");
                Response.End();
            }
        }
    }
}