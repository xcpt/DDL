using System;
namespace Web.CS.Manager.Users
{
    public partial class Lists_Excel : Web.UI.Permissions
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string UserID = Base.Fun.Fetch.getpost("ID");
            string Stime = Base.Fun.Fetch.getpost("Stime");
            string Etime = Base.Fun.Fetch.getpost("Etime");
            string TableName = Base.Fun.fun.NoCon(Base.Fun.Fetch.getpost("TableName"));
            if (Base.Fun.fun.pnumeric(UserID))
            {
                Web.UI.UserLogTotal.UserExportExcel(UserID, TableName, Stime, Etime);
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("无数据导出。");
            }
            Response.End();
        }
    }
}