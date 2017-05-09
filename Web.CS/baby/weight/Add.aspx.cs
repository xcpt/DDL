using System;

public partial class baby_weight_Add : Web.UI.Permissions
{
    protected string action = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        if (action.Equals("save"))
        {
            Web.Model.baby.weight wModel = new Web.Model.baby.weight();
            wModel.monthage = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("monthage"));
            wModel.sex = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("sex"));
            wModel.minnum = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("minnum"));
            wModel.maxnum = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("maxnum"));
            Web.DAL.baby.weight wDAL = new Web.DAL.baby.weight();
            if (wModel.monthage.Length > 0)
            {
                string id = wDAL.Insert(wModel);
                if (Base.Fun.fun.pnumeric(id))
                {
                    Base.Log.Log.Add(1, "baby_weight", id);
                    SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "体重国际添加成功。");
                    Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("weightGrid", id, true));
                }
                else
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert("体重国际添加失败。");
                }
            }
            Response.End();
        }
    }
}