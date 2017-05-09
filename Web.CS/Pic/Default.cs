using System;
namespace Web.CS.Pic
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            picfun.GetSrc.GetSrcUrl();
            Response.End();
        }
    }
}