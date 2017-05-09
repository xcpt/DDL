using System;

public partial class score_exchange_Del : Web.UI.Permissions
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.score.exchange eDAL = new Web.DAL.score.exchange();
            Web.Model.score.exchange eModel = eDAL.Read(id);
            if (eModel.id.Equals(id))
            {
                if (eDAL.Delete(id) > 0)
                {
                    Web.UI.score.log.AddLog(StoresID, eModel.userid, "1", eModel.userrule, "积分兑换删除。积分兑换：" + eModel.content + "；序号：" + id + "；操作人：" + UserName + "；");
                    Base.Log.Log.Add(3, "score_exchange", id);
                    SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "积分兑换记录删除成功。");
                    Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("exchangeGrid", true));
                }
            }
        }
        Response.End();
    }
}