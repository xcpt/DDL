using System;

public partial class score_log_Add : Web.UI.Permissions
{
    protected string action = "";
    protected string userid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        userid = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("id").Trim(','));
        if (action.Equals("save"))
        {
            if (Base.Fun.fun.pnumeric(userid))
            {
                string rulenum = Base.Fun.Fetch.getpost("rulenum");
                if (Base.Fun.fun.pnumeric(rulenum))
                {
                    string id = Web.UI.score.log.AddLog(StoresID, userid, "2", rulenum, Base.Fun.Fetch.getpost("content") + " 操作人：" + UserName + "；");
                    if (Base.Fun.fun.pnumeric(id))
                    {
                        Base.Log.Log.Add(1, "score_log", id);
                        SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "手动增加会员积分成功。");
                        string winlist = Base.Fun.Fetch.getpost("winlist");
                        if (winlist.Equals("user"))
                        {
                            Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("UserGrid", userid, true));
                        }
                        else
                        {
                            Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("logGrid", id, true));
                        }
                    }
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("错误：客户必须选择。");
            }
            Response.End();
        }
    }
}