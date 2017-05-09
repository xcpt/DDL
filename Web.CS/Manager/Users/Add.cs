using System;
using System.Collections.Generic;
namespace Web.CS.Manager.Users
{
    public partial class Add : Web.UI.Permissions
    {
        protected string action = "", roleId="";
        protected void Page_Load(object sender, EventArgs e)
        {
            action = Base.Fun.Fetch.getpost("action");
            if (action.Equals("save"))
            {
                string userName = Base.Fun.fun.NoSql(Base.Fun.Fetch.post("userName"));
                string userPass = Base.Fun.Md5.MD5(Base.Fun.Fetch.post("uPass"));
                string userCPass = Base.Fun.Md5.MD5(Base.Fun.Fetch.post("userCPass"));
                string isLock = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("isLock"));
                roleId = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("roleId"));
                string StoresID = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("StoresID"));
                string IsBoos = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("IsBoos"));
                if (Web.UI.Users.GetUserCount(userName) <= 0)
                {
                    if (Base.Fun.fun.IsNumeric(roleId))
                    {
                        Web.UI.Users UserUI = new Web.UI.Users();
                        Web.Model.Users us = new Web.Model.Users(0, StoresID, IsBoos, userName, userPass, roleId, 0, 0, DateTime.Now.ToString(), Base.Fun.Fetch.UserIp, DateTime.Now.ToString(), 0);
                        if (UserUI.Add(ref us))
                        {
                            SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "添加成功！");
                            Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("flex1", us.UserID.ToString(), Web.UI.Sys.SiteInfo.MaxPage, true));
                        }
                        else
                        {
                            SyCms.Window.WindowsReturn.WindowsReturnAlert("用户添加出错！");
                        }
                    }
                    else
                    {
                        SyCms.Window.WindowsReturn.WindowsReturnAlert("请至少选择一个角色！");
                    }

                }
                else
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert("用户名已存在！");
                }
                Response.End();
            }
        }
    }
}