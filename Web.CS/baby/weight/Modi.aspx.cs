using System;

public partial class baby_weight_Modi : Web.UI.Permissions
{
    protected string action = "";
    protected Web.Model.baby.weight wModel = new Web.Model.baby.weight();
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.baby.weight wDAL = new Web.DAL.baby.weight();
            wModel = wDAL.Read(id);
            if (wModel.id.Equals(id))
            {
                if (action.Equals("save"))
                {

                    wModel.monthage = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("monthage"));
                    wModel.sex = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("sex"));
                    wModel.minnum = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("minnum"));
                    wModel.maxnum = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("maxnum"));

                    if (wModel.monthage.Length > 0)
                    {
                        int icount = wDAL.Update(wModel);
                        if (icount > 0)
                        {
                            Base.Log.Log.Add(2, "baby_height", id);
                            SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "体重国际修改成功。");
                            Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("heightGrid", id, true));
                        }
                        else
                        {
                            SyCms.Window.WindowsReturn.WindowsReturnAlert("体重国际修改失败。");
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