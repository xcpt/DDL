using System;

namespace Web.CS
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Web.Model.UserLogin userInfo = Web.UI.Users.GetUserInfo();///去对应的登录用户信息，保存在数组中
            Web.UI.Users.LogOut(userInfo.UserID);
            Response.Write("['1']");
        }
    }
}
