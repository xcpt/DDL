using System;
namespace Web.CS.Manager.Roles
{
    public partial class Add : Web.UI.Permissions
    {
        public string action = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            action = Base.Fun.Fetch.getpost("action");
            if (action.Equals("save"))
            {
                string roleName = Base.Fun.fun.NoSql(Base.Fun.Fetch.post("roleName"));
                string storesid = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("storesid"));
                string roleDescription = Base.Fun.fun.NoSql(Base.Fun.Fetch.post("roleDescription"));
                string ID = Base.Fun.Fetch.getpost("id");
                if (roleName.Length > 0)
                {
                    Web.Model.Roles role = new Web.Model.Roles("", roleName, roleDescription, storesid);
                    Web.UI.Roles RoleUI = new Web.UI.Roles();
                    if (RoleUI.GetRID(roleName, storesid))
                    {
                        SyCms.Window.WindowsReturn.WindowsReturnAlert("角色名称已经存在。");
                        Response.End();
                    }
                    else
                    {
                        if (RoleUI.Add(ref role))
                        {
                            if (Base.Fun.fun.pnumeric(ID))
                            {
                                Web.UI.Roles.CopyFilePermissions(ID, role.Id);
                                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "角色另存成功。");
                            }
                            else
                            {
                                Response.Write("<script type=\"text/javascript\">GridModiy('" + role.Id + "', 'Manager/Roles/Operate.aspx','设置权限', 'Manager/Roles/Operate.aspx?action=save', 700, 500);</script>");
                            }
                            Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("flex1", role.Id, true));
                            Response.End();
                        }
                        else
                        {
                            SyCms.Window.WindowsReturn.WindowsReturnAlert("角色添加出错。");
                            Response.End();
                        }
                    }
                }
                else
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert("角色添加出错。", "roleName");
                    Response.End();
                }
            }
        }
    }
}