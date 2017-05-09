using System;
namespace Web.CS.Manager.Users
{
    public partial class Lists : Web.UI.Permissions
    {
        protected string page = "";
        protected string action = "";
        protected string UserName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            page = Base.Fun.Fetch.post("page");
            if (!Base.Fun.fun.pnumeric(page))
            {
                page = "1";
            }
            action = Base.Fun.Fetch.getpost("action");
            UserName = Base.Fun.fun.NoCon(Server.UrlDecode(Base.Fun.Fetch.getpost("UserName")));
        }
    }
}