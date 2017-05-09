using System;
namespace Web.CS.Manager.Users
{
    public partial class Modi : Web.UI.Permissions
    {
        protected string action = "", id, userName, userPass, ss, userCPass, roleId = "0", isLock, loginTimes, lastLoginTime, lastLoginIP, lastLoginOutTime, loginErrorTimes, sty, email;
        protected string StoresID = "", IsBoss = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            action = Base.Fun.Fetch.getpost("action");
            id = Base.Fun.Fetch.getpost("id");
            if (action.Equals("save"))
            {
                userName = Base.Fun.fun.NoCon(Base.Fun.Fetch.post("userName"));
                userPass = Base.Fun.Fetch.post("uPass");
                userCPass = Base.Fun.Fetch.post("userCPass");
                isLock = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("isLock"));
                roleId = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("roleId"));
                string oldroles = Base.Fun.fun.NoCon(Base.Fun.Fetch.post("oldroles"));
                email = Base.Fun.fun.NoCon(Base.Fun.Fetch.post("email"));
                StoresID = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("StoresID"));
                IsBoss = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("IsBoss"));
                if (Base.Fun.fun.pnumeric(id))
                {
                    Web.UI.Users UserUI = new Web.UI.Users();
                    Web.Model.Users us = new Web.Model.Users();
                    us.UserID = int.Parse(id);
                    us.UserName = userName;
                    us.UserPass = userPass;
                    us.IsLock = int.Parse(isLock);
                    us.RoleID = roleId;
                    us.StoresID = StoresID;
                    us.IsBoss = IsBoss;
                    if (Base.Fun.fun.IsNumeric(roleId))
                    {
                        if (!Base.Fun.fun.isempty(userPass))
                        {
                            if (Base.Fun.fun.isempty(userCPass))
                            {
                                Web.UI.Ami.Message(0, "请输入确认密码！");
                            }
                            else
                            {
                                if (userCPass.Equals(userPass))
                                {
                                    if (UserUI.IsAdmin(id) || ("," + roleId + ",").Contains(",1,"))
                                    {
                                        if (Web.UI.Users.GetUserCount(userName,id) <= 0)
                                        {
                                            if (UserUI.Modi(us, IsOperate))
                                            {
                                                Web.UI.Users.UserPassApp(0, id);
                                                if (IsOperate)
                                                {
                                                    if (isLock.Equals("1")) //锁定
                                                    {
                                                        Web.UI.Users.UserLookApp(0, id);
                                                    }
                                                    else
                                                    {      //开启
                                                        Web.UI.Users.UserLookApp(2, id);
                                                    }
                                                }
                                                string[] oldrolesArr = oldroles.Split(',');
                                                roleId = "," + roleId + ",";
                                                for (int i = 0; i < oldrolesArr.Length; i++)
                                                {
                                                    roleId = roleId.Replace("," + oldrolesArr[i].ToString() + ",", ",");
                                                }
                                                roleId = roleId.TrimEnd(',').TrimStart(',');
                                                if (roleId != "")
                                                {
                                                    Web.UI.Users.UserRolesApp(0, id);
                                                }
                                                else
                                                {
                                                    Web.UI.Users.UserRolesApp(2, id);
                                                }
                                                Web.UI.Ami.Message(1, "用户修改成功！", "<script type=\"text/javascript\">$('#flex1').flexReload(null,'" + us.UserID + "');</script>");
                                            }
                                            else
                                            {
                                                Web.UI.Ami.Message(0, "用户修改出错！");
                                            }
                                        }
                                        else
                                        {
                                            Web.UI.Ami.Message(0, "用户名已经在！");
                                        }
                                    }
                                    else
                                    {
                                        Web.UI.Ami.Message(0, "错误：修改之后就没有超级管理员了。");
                                    }
                                }
                                else
                                {
                                    Web.UI.Ami.Message(0, "两者密码不一致！");
                                }
                            }
                        }
                        else
                        {
                            if (UserUI.IsAdmin(id) || ("," + roleId + ",").Contains(",1,"))
                            {
                                if (Web.UI.Users.GetUserCount(userName, id) <= 0)
                                {
                                    if (UserUI.Modi(us, IsOperate))
                                    {
                                        if (IsOperate)
                                        {
                                            if (isLock.Equals("1")) //锁定
                                            {
                                                Web.UI.Users.UserLookApp(0, id);
                                            }
                                            else
                                            {      //开启
                                                Web.UI.Users.UserLookApp(2, id);
                                            }
                                        }
                                        string[] oldrolesArr = oldroles.Split(',');
                                        roleId = "," + roleId + ",";
                                        for (int i = 0; i < oldrolesArr.Length; i++)
                                        {
                                            roleId = roleId.Replace("," + oldrolesArr[i].ToString() + ",", ",");
                                        }
                                        roleId = roleId.TrimEnd(',').TrimStart(',');
                                        if (roleId != "")
                                        {
                                            Web.UI.Users.UserRolesApp(0, id);
                                        }
                                        else
                                        {
                                            Web.UI.Users.UserRolesApp(2, id);
                                        }
                                        Web.UI.Ami.Message(1, "用户修改成功！", "<script type=\"text/javascript\">$('#flex1').flexReload(null,'" + us.UserID + "');</script>");
                                    }
                                    else
                                    {
                                        Web.UI.Ami.Message(0, "用户修改出错！");
                                    }
                                }
                                else
                                {
                                    Web.UI.Ami.Message(0, "用户名已存在！");
                                }
                            }
                            else
                            {
                                Web.UI.Ami.Message(0, "错误：修改之后就没有超级管理员了。");
                            }
                        }
                    }
                    else
                    {
                        Web.UI.Ami.Message(0, "请至少选择一个角色！");
                    }
                }
                else
                {
                    Web.UI.Ami.Message(0, "用户修改出错！");
                }
            }
            else
            {
                if (Base.Fun.fun.pnumeric(id))
                {
                    Web.UI.Users UserUI = new Web.UI.Users();
                    Web.Model.Users user = UserUI.View(id);
                    if (user != null)
                    {
                        userName = user.UserName;
                        roleId = user.RoleID;
                        isLock = user.IsLock.ToString();
                        loginTimes = user.LoginTimes.ToString();
                        lastLoginTime = user.LastLoginTime;
                        lastLoginIP = user.LastLoginIP;
                        lastLoginOutTime = user.LastLoginOutTime;
                        loginErrorTimes = user.LoginErrorTimes.ToString();
                        StoresID = user.StoresID;
                        IsBoss= user.IsBoss;
                    }
                    else
                    {
                        SyCms.Window.WindowsReturn.WindowsReturnAlert("用户修改调入出错！");
                        Response.End();
                    }
                }
                else
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert("用户修改调入出错！");
                    Response.End();
                }
            }
        }
    }
}