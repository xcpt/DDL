using System;

public partial class customer_User_Lists_Load : System.Web.UI.Page
{
    protected string action = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        action=Base.Fun.Fetch.getpost("action");
        if (action.Equals("save"))
        {
            string cardNo = Base.Fun.Fetch.getpost("cardNo");
            if (cardNo.Length > 0)
            {
                Response.Write("<script type=\"text/javascript\">CreateWindow('customer/User/Lists_LoadView.aspx?cardNo="+cardNo+"', '会员卡信息', null, 600, 430)</script>");
            }
            Response.End();
        }
    }
}