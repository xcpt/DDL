using System;

public partial class score_log_Del : Web.UI.Permissions
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.score.log lDAL = new Web.DAL.score.log();
            Web.Model.score.log lModel = lDAL.Read(id);
            if (lModel.id.Equals(id))
            {
                if (lDAL.Delete(id) > 0)
                {
                    if (double.Parse(lModel.rulenum) > 0)
                    {
                        Web.DAL.customer.User uDAL = new Web.DAL.customer.User();
                        Web.Model.customer.User uModel = uDAL.Read(StoresID, lModel.userid);
                        if (double.Parse(uModel.scorenum) < double.Parse(lModel.rulenum))
                        {
                            SyCms.Window.WindowsReturn.WindowsReturnAlert("此会员的积分只有：" + uModel.scorenum + "分，不够减少。");
                            Response.End();
                        }
                    }
                    Web.UI.score.log.AddLog(StoresID, lModel.userid, "0", (0 - int.Parse(lModel.rulenum)).ToString(), "积分日志删除。前备注：【" + lModel.content + "】；序号：" + id + "；操作人：" + UserName + "；");
                    Base.Log.Log.Add(3, "score_log", id);
                    SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "积分日志记录删除成功。");
                    Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("logGrid", true));
                }
            }
        }
        Response.End();
    }
}