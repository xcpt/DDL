using System;

public partial class score_exchange_Add : Web.UI.Permissions
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
            Web.Model.score.exchange eModel = new Web.Model.score.exchange();
            eModel.userid = userid;
            if (Base.Fun.fun.pnumeric(eModel.userid))
            {
                eModel.addtime = DateTime.Now.ToString();
                eModel.usertime = Base.Fun.Fetch.getpost("usertime");
                eModel.userrule = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("userrule"));
                if (double.Parse(eModel.userrule) > 0)
                {
                    Web.DAL.customer.User uDAL = new Web.DAL.customer.User();
                    Web.Model.customer.User uModel = uDAL.Read(StoresID, eModel.userid);
                    if (double.Parse(uModel.scorenum) < double.Parse(eModel.userrule))
                    {
                        SyCms.Window.WindowsReturn.WindowsReturnAlert("此会员的积分只有：" + uModel.scorenum + "分，不够兑换。");
                        Response.End();
                    }
                }
                eModel.content = Base.Fun.Fetch.getpost("content");
                Web.DAL.score.exchange eDAL = new Web.DAL.score.exchange();
                string id = eDAL.Insert(eModel);
                if (Base.Fun.fun.pnumeric(id))
                {
                    Web.UI.score.log.AddLog(StoresID, eModel.userid, "1", (0 - int.Parse(eModel.userrule)).ToString(), "积分对换：" + eModel.content + "；序号：" + id + "；操作人：" + UserName + "；");
                    Base.Log.Log.Add(1, "score_exchange", id);
                    SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "积分对换成功。");
                    string winlist = Base.Fun.Fetch.getpost("winlist");
                    if (winlist.Equals("user"))
                    {
                        Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("UserGrid", userid, true));
                    }
                    else
                    {
                        Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("exchangeGrid", id, true));
                    }
                }
                else
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert("积分对换失败。");
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("错误：会员必须选择。");
            }
            Response.End();
        }
    }
}