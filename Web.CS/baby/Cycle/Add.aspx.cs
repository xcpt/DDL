using System;

public partial class baby_Cycle_Add : Web.UI.Permissions
{
    protected string action = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        if (action.Equals("save"))
        {
            Web.Model.baby.Cycle cModel = new Web.Model.baby.Cycle();
            cModel.title = Base.Fun.Fetch.post("title");
            cModel.type = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("type"));
            cModel.startday = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("startday"));
            cModel.endday = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("endday"));
            Web.DAL.baby.Cycle cDAL = new Web.DAL.baby.Cycle();
            if (cModel.title.Length > 0)
            {
                string id = cDAL.Insert(cModel);
                if (Base.Fun.fun.pnumeric(id))
                {
                    Base.Log.Log.Add(1, "baby_Cycle", id);
                    SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "成长周期添加成功。");
                    Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("CycleGrid", id, true));
                }
                else
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert("成长周期添加失败。");
                }
            }
            Response.End();
        }
    }
}