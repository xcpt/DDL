using System;

public partial class Staff_performance_Add : Web.UI.Permissions
{
    protected string action = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        if (action.Equals("save"))
        {
            Web.Model.Staff.performance pModel = new Web.Model.Staff.performance();
            pModel.memberid = Base.Fun.Fetch.post("memberid");
            if (Base.Fun.fun.pnumeric(pModel.memberid))
            {
                pModel.type = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("type"));
                pModel.datetime = Base.Fun.Fetch.getpost("datetime");
                pModel.num = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("num"));
                pModel.addtime = DateTime.Now.ToString();
                pModel.content = Base.Fun.Fetch.getpost("content");
                Web.DAL.Staff.performance pDAL = new Web.DAL.Staff.performance();
                string id = pDAL.Insert(pModel);
                if (Base.Fun.fun.pnumeric(id))
                {
                    Base.Log.Log.Add(1, "Staff_performance", id);
                    SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "考勤添加成功。");
                    Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("performanceGrid", id, true));
                }
                else
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert("考勤添加失败。");
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("错误：员工必须选择。");
            }
            Response.End();
        }
    }
}