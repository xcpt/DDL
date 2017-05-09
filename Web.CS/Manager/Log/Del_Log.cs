using System;
namespace Web.CS.Manager.Log
{
    public partial class Del_Log : Web.UI.Permissions
    {
        protected string action = "";
        protected string del = "", timecontent = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            action = Base.Fun.Fetch.getpost("action");
            string Type = Base.Fun.Fetch.getpost("Type");
            if (!Base.Fun.fun.pnumeric(del))
            {
                del = "7";
            }
        }
    }
}