using System;

namespace Web.CS
{
    public partial class Banner : System.Web.UI.Page
    {
        protected string str = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Base.Fun.fun.IsSelfRefer() || !Base.Fun.fun.ispost())
            {
                Response.End();
            }
            else
            {
                if (Web.UI.Users.CheckLogin())
                {
                    str = Web.UI.MenuClass.ReadTopBanner("");
                }
                else
                {
                    Response.Write("['-1']");
                    Response.End();
                }
            }
        }
    }
}
