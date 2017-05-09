using System;
namespace Web.CS.Manager.Users
{
    public partial class Lists_Per : Web.UI.Permissions
    {
        protected string action = "", UserID = "";
        protected int PageSize = 15;
        protected string Stime = "", Etime = "", TableName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            action = Base.Fun.Fetch.getpost("action");
            UserID = Base.Fun.Fetch.getpost("ID");
            if (!Base.Fun.fun.pnumeric(UserID))
            {
                Response.End();
            }
            PageSize = Web.UI.Sys.SiteInfo.GetPageSize();
            Stime = Base.Fun.Fetch.getpost("Stime");
            Etime = Base.Fun.Fetch.getpost("Etime");
            TableName = Base.Fun.fun.NoCon(Base.Fun.Fetch.getpost("TableName"));
        }
    }
}