using System;

public partial class app_login_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string UserName = Base.Fun.Fetch.getpost("UserName");
        string UserPass = Base.Fun.Fetch.getpost("UserPass");
        string UserStr = Base.Fun.Fetch.getpost("UserStr");
        string Model = Base.Fun.Fetch.getpost("Model");
        string IsPush = "0";
        if (UserName.Length > 0 && UserStr.Length > 0 && UserPass.Length > 0)
        {
            string WebUserStr = Base.Fun.Md5.MD5("webapp" + UserName + "login" + UserPass + "20150119");
            if (WebUserStr.Equals(UserStr))
            {
                string UserID = "";
                string AppID = "";
                string Start = Web.UI.customer.User.Login(UserName, UserPass, ref UserID, ref IsPush, ref AppID);
                if (Base.Fun.fun.pnumeric(UserID))
                {
                    if (Start.Equals("0"))
                    {
                        if (AppID.Length == 0)
                        {
                            AppID = Base.Fun.Md5.MD5("webapp-" + UserID + "-" + UserPass + "-yq-" + DateTime.Now.ToString() + "-baby");
                        }
                        Web.DAL.customer.User uDAL = new Web.DAL.customer.User();
                        string client = "app" + Model + "_" + UserName;
                        uDAL.SetAppID(UserID, client, AppID, Model);
                        Response.Write(Web.UI.APP.GetJosn("1", UserID, client, IsPush, "登录成功", "", AppID));
                    }
                    else
                    {
                        Response.Write(Web.UI.APP.GetJosn("0", "0", "", "0", "错误：您被锁定，请联系客服人员。", "", ""));
                    }
                }
                else
                {
                    Response.Write(Web.UI.APP.GetJosn("0", "0", "", "0", "未找到您的帐号信息。", "", ""));
                }
            }
            else
            {
                Response.Write(Web.UI.APP.GetJosn("0", "0", "", "0", "错误：参数不全。", "", ""));
            }
        }
        else
        {
            Response.Write(Web.UI.APP.GetJosn("0", "0", "", "0", "错误：参数不全。", "", ""));
        }
        Response.End();
    }
}