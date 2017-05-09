using System;
namespace Web.CS.Manager.Users
{
    public partial class Operate : Web.UI.Permissions
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string UserID = Base.Fun.Fetch.post("UserID");
            if (Base.Fun.fun.pnumeric(UserID))
            {
                Web.UI.Users user = new Web.UI.Users();
                string str = user.SetLock(UserID);
                if (str.Length > 0)
                {
                    Response.Write(str);
                }
                else
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert("错误：修改锁定状态失败。");
                }
            }
            Response.End();
        }
    }
}