using System;

public partial class Mobile_MessageLog_Add_Send : Web.UI.Permissions
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Base.Log.Log.Add(4, "Mobile_MessageLog", id);
            if (Web.UI.Mobile.MessageLog.SendMobile(StoresID, id))
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "发送成功。");
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("发送失败。");
            }
            Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("MessageLogGrid", id, true));
        }
    }
}