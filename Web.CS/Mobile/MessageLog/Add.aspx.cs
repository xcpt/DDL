using System;

public partial class Mobile_MessageLog_Add : Web.UI.Permissions
{
    protected string action = "";
    protected string mobile = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        mobile = Base.Fun.Fetch.getpost("mobile");
        if (action.Equals("save"))
        {
            string content = Base.Fun.Fetch.getpost("content");
            string title = Base.Fun.Fetch.getpost("title");
            if (content.Length > 0 && Base.Fun.Fetch.FontSize(content) <= 150)
            {
                string sendtime = Base.Fun.Fetch.getpost("sendtime");
                string sendtype = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("sendtype"));
                if (mobile.Length > 0)
                {
                    Base.Log.Log.Add(1, "Mobile_MessageLog");
                    string str = Web.UI.Mobile.MessageLog.SendMobile(StoresID, mobile, title, content, sendtime, sendtype);
                    SyCms.Window.WindowsReturn.WindowsReturnAlert(true, str.ToString(), true);
                    Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("MessageLogGrid", true));
                }
                else
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert("手机号必须输入");
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("发送内容为空或者不符合要求");
            }
            Response.End();
        }
    }
}