using System;

namespace Web.CS
{
    public partial class Default : System.Web.UI.Page
    {
        protected bool UserLogin = false;
        protected bool customerUserIsList = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            UserLogin = Web.UI.Users.CheckLogin();
            Base.Fun.Management.SetDirectory();
            if (Base.Fun.fun.ispost())
            {
                if (Base.Fun.fun.IsSelfRefer())
                {
                    string userName = "", userPass = "", code = "";
                    userName = Base.Fun.fun.NoSql(Base.Fun.Fetch.post("userName"));
                    userPass = Base.Fun.Fetch.post("userPass");
                    code = Base.Fun.fun.NoSql(Base.Fun.Fetch.post("Code"));
                    string CmsGetCode = Base.Fun.Session.GetSession("CmsGetCode");
                    string logindays = Base.Fun.Fetch.getpost("logindays");
                    if (userName.Length > 0)
                    {
                        if (code != "" && CmsGetCode.Equals(code))
                        {
                            Web.UI.Users.CheckLogin(userName, Base.Fun.Md5.MD5(userPass), logindays.Equals("1"));
                        }
                        else
                        {
                            Web.UI.Ami.Message(0, "验证码错误，请重新输入！");
                        }
                    }
                    else
                    {
                        Web.UI.Ami.Message(0, "请重新输入！");
                    }
                }
                Response.End();
            }
            customerUserIsList = Web.UI.Users.CheckPermission("/customer/User/Lists.aspx", 1);
        }
    }
}
