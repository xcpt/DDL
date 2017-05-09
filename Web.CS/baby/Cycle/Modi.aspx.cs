using System;

public partial class baby_Cycle_Modi : Web.UI.Permissions
{
    protected string action = "";
    protected Web.Model.baby.Cycle cModel = new Web.Model.baby.Cycle();
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.baby.Cycle cDAL = new Web.DAL.baby.Cycle();
            cModel = cDAL.Read(id);
            if (cModel.id.Equals(id))
            {
                if (action.Equals("save"))
                {
                    cModel.title = Base.Fun.Fetch.post("title");
                    cModel.type = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("type"));
                    cModel.startday = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("startday"));
                    cModel.endday = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("endday"));

                    if (cModel.title.Length > 0)
                    {
                        int icount = cDAL.Update(cModel);
                        if (icount > 0)
                        {
                            Base.Log.Log.Add(2, "baby_Cycle", id);
                            SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "成长周期修改成功。");
                            Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("CycleGrid", id, true));
                        }
                        else
                        {
                            SyCms.Window.WindowsReturn.WindowsReturnAlert("成长周期修改失败。");
                        }
                    }
                    Response.End();
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("未找到相关信息");
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