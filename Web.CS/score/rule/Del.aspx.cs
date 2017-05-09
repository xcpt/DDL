using System;

public partial class score_rule_Del : Web.UI.Permissions
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.score.rule rDAL = new Web.DAL.score.rule();
            if (rDAL.Delete(StoresID, id) > 0)
            {
                Base.Log.Log.Add(3, "score_rule", id);
                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "积分规则记录删除成功。");
                Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("ruleGrid", true));
            }
        }
        Response.End();
    }
}