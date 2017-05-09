using System;

namespace Web.CS
{
    public partial class Left : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Base.Fun.fun.IsSelfRefer() || !Base.Fun.fun.ispost())
            {
                Response.End();
            }
            else
            {
                if (!Web.UI.Users.CheckLogin())
                {
                    Response.Write("['-1']");
                    Response.End();
                }
            }
        }
    }
}
