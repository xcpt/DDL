using System;
namespace Web.CS.Manager.Users
{
    public partial class Del : Web.UI.Permissions
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Base.Fun.Fetch.getpost("id");
            if (Base.Fun.fun.pnumeric(id.Replace(",", "")))
            {
                Web.UI.Users us = new Web.UI.Users();
                if (us.IsAdmin(id))
                {
                    if (us.Del(id))
                    {
                        SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "用户删除成功。");
                    }
                    else
                    {
                        SyCms.Window.WindowsReturn.WindowsReturnAlert("删除用户数据出错。");
                    }
                }
                else
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert("错误：删除之后就没有超级管理员了。");
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("删除用户数据出错。");
            }
            Response.End();
        }
    }
}