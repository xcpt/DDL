using System;
namespace Web.CS.Manager.Log
{
    public partial class Lists_Error : Web.UI.Permissions
    {
        public string page = "";
        public string action = "";
        public string Stime = "", Etime = "";
        public string AutoTaskPlay = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            page = Base.Fun.Fetch.post("page");
            if (!Base.Fun.fun.pnumeric(page))
            {
                page = "1";
            }
            action = Base.Fun.Fetch.getpost("action");
            Stime = Base.Fun.Fetch.getpost("Stime");
            Etime = Base.Fun.Fetch.getpost("Etime");
            AutoTaskPlay = Base.Fun.fun.getapp("AutoTimePlay");
        }
    }
}