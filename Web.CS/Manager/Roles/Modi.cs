using System;
namespace Web.CS.Manager.Roles
{
    public partial class Modi : Web.UI.Permissions
    {
        public string action = "", roleName, storesid, id, roleDescription;
        protected void Page_Load(object sender, EventArgs e)
        {
            action = Base.Fun.Fetch.getpost("action");
            id = Base.Fun.Fetch.getpost("id");
            if (action.Equals("save"))
            {
                if (Base.Fun.fun.pnumeric(id))
                {
                    roleName = Base.Fun.fun.NoSql(Base.Fun.Fetch.post("roleName"));
                    storesid = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("storesid"));
                    roleDescription = Base.Fun.fun.NoSql(Base.Fun.Fetch.post("roleDescription"));
                    if (roleName.Length > 0)
                    {
                        Web.UI.Roles RoleUI = new Web.UI.Roles();
                        Web.Model.Roles roles = new Web.Model.Roles(id, roleName, roleDescription, storesid);
                        if (RoleUI.GetRID(roleName, StoresID, id))
                        {
                            SyCms.Window.WindowsReturn.WindowsReturnAlert("角色名称已经存在。");
                            Response.End();
                        }
                        else
                        {
                            if (RoleUI.Modi(roles))
                            {
                                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "角色修改成功。");
                                Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("flex1", roles.Id, true));
                                Response.End();
                            }
                            else
                            {
                                SyCms.Window.WindowsReturn.WindowsReturnAlert("角色修改出错。");
                                Response.End();
                            }
                        }
                    }
                    else
                    {
                        SyCms.Window.WindowsReturn.WindowsReturnAlert("角色名称必须填写。", "roleName");
                        Response.End();
                    }
                }
                else
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert("角色修改出错。");
                    Response.End();
                }

            }
            else
            {
                if (Base.Fun.fun.pnumeric(id))
                {
                    Web.UI.Roles RoleUI = new Web.UI.Roles();
                    Web.Model.Roles role = RoleUI.View(id);
                    if (role != null)
                    {
                        roleName = role.RoleName;
                        roleDescription = role.RoleDescription;
                        storesid = role.StoresID;
                    }
                    else
                    {
                        SyCms.Window.WindowsReturn.WindowsReturnAlert("角色修改调入出错。");
                        Response.End();
                    }
                }
                else
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert("角色修改调入出错。");
                    Response.End();
                }
            }
        }
    }
}