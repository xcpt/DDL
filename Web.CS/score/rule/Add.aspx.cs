using System;

public partial class score_rule_Add : Web.UI.Permissions
{
    protected string action = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        if (action.Equals("save"))
        {
            string coefficient = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("coefficient"));
            if (double.Parse(coefficient) > 1)
            {
                Web.Model.score.rule rModel = new Web.Model.score.rule();
                rModel.addtime = DateTime.Now.ToString();
                rModel.coefficient = coefficient;
                rModel.endtime = Base.Fun.Fetch.getpost("endtime");
                rModel.starttime = Base.Fun.Fetch.getpost("starttime");
                rModel.storesid = StoresID;
                rModel.title = Base.Fun.Fetch.getpost("title");
                Web.DAL.score.rule rDAL = new Web.DAL.score.rule();
                string id = rDAL.Insert(rModel);
                if (Base.Fun.fun.pnumeric(id))
                {
                    Base.Log.Log.Add(1, "score_rule", id);
                    SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "增加积分规则成功。");
                    Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("ruleGrid", id, true));
                }
                else
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert("增加积分规则失败。");
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("请输入大于1的系数");
            }
            Response.End();
        }
    }
}