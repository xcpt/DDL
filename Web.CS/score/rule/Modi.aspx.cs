using System;

public partial class score_rule_Modi : Web.UI.Permissions
{
    protected string action = "";
    protected Web.Model.score.rule rModel = new Web.Model.score.rule();
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.score.rule rDAL = new Web.DAL.score.rule();
            rModel = rDAL.Read(StoresID, id);
            if (rModel.id.Equals(id))
            {
                if (action.Equals("save"))
                {
                    string coefficient = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("coefficient"));
                    if (double.Parse(coefficient) > 1)
                    {
                        rModel.coefficient = coefficient;
                        rModel.endtime = Base.Fun.Fetch.getpost("endtime");
                        rModel.starttime = Base.Fun.Fetch.getpost("starttime");
                        rModel.title = Base.Fun.Fetch.getpost("title");

                        int icount = rDAL.Update(rModel);
                        if (icount>0)
                        {
                            Base.Log.Log.Add(2, "score_rule", id);
                            SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "修改积分规则成功。");
                            Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("ruleGrid", id, true));
                        }
                        else
                        {
                            SyCms.Window.WindowsReturn.WindowsReturnAlert("修改积分规则失败。");
                        }
                    }
                    else
                    {
                        SyCms.Window.WindowsReturn.WindowsReturnAlert("请输入大于1的系数");
                    }
                    Response.End();
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("未找到相关规则记录");
                Response.End();
            }
        }
        else
        {
            SyCms.Window.WindowsReturn.WindowsReturnAlert("参数传递错误");
            Response.End();
        }
    }
}