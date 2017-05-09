using System;

public partial class baby_height_Add : Web.UI.Permissions
{
    protected string action = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        if (action.Equals("save"))
        {
            Web.Model.baby.height hModel = new Web.Model.baby.height();
            hModel.monthage = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("monthage"));
            hModel.sex = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("sex"));
            hModel.minnum = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("minnum"));
            hModel.maxnum = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("maxnum"));
            Web.DAL.baby.height hDAL = new Web.DAL.baby.height();
            if (hModel.monthage.Length > 0)
            {
                string id = hDAL.Insert(hModel);
                if (Base.Fun.fun.pnumeric(id))
                {
                    Base.Log.Log.Add(1, "baby_height", id);
                    SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "身高国际添加成功。");
                    Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("heightGrid", id, true));
                }
                else
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert("身高国际添加失败。");
                }
            }
            Response.End();
        }
    }
}