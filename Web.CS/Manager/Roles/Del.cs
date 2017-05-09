using System;
namespace Web.CS.Manager.Roles
{
    public partial class Del : Web.UI.Permissions
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Base.Fun.Fetch.getpost("id");
            if (Base.Fun.fun.pnumeric(id.Replace(",", "")))
            {
                Web.UI.Roles role = new Web.UI.Roles();
                if (role.Del(id))
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "角色删除成功。");
                    Response.End();
                }
                else
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert("角色删除调入出错。");
                    Response.End();
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("角色删除调入出错。");
                Response.End();
            }
        }
    }
}