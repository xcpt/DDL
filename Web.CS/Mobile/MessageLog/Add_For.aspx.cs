using System;

public partial class Mobile_MessageLog_Add_For : Web.UI.Permissions
{
    protected string action = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        if (action.Equals("save"))
        {
            string content = Base.Fun.Fetch.getpost("content");
            string title = Base.Fun.Fetch.getpost("title");
            if (content.Length > 0 && Base.Fun.Fetch.FontSize(content) <= 75)
            {
                string sendtime = Base.Fun.Fetch.getpost("sendtime");
                string sendtype = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("sendtype"));
                string UserConsumptionTime = Base.Fun.Fetch.getpost("UserConsumptionTime");
                string CardNum = Base.Fun.Fetch.getpost("CardNum");
                string CardEndTime = Base.Fun.Fetch.getpost("CardEndTime");
                string CardType = Base.Fun.Fetch.getpost("CardType");
                string CardState = Base.Fun.Fetch.getpost("CardState");
                string yueling1 = Base.Fun.Fetch.getpost("yueling1");
                string yueling2 = Base.Fun.Fetch.getpost("yueling2");
                Base.Log.Log.Add(1, "Mobile_MessageLog");
                string str = Web.UI.Mobile.MessageLog.SendMobileFor(StoresID, title, content, sendtime, sendtype, UserConsumptionTime, CardNum, CardEndTime, CardType, CardState, yueling1, yueling2);
                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, str.ToString(), true);
                Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("MessageLogGrid", true));
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("发送内容为空或者不符合要求");
            }
            Response.End();
        }
    }
}