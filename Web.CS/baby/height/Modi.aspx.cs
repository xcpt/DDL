using System;

public partial class baby_height_Modi : Web.UI.Permissions
{
    protected string action = "";
    protected Web.Model.baby.height hModel = new Web.Model.baby.height();
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.baby.height hDAL = new Web.DAL.baby.height();
            hModel = hDAL.Read(id);
            if (hModel.id.Equals(id))
            {
                if (action.Equals("save"))
                {

                    hModel.monthage = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("monthage"));
                    hModel.sex = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("sex"));
                    hModel.minnum = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("minnum"));
                    hModel.maxnum = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("maxnum"));

                    if (hModel.monthage.Length > 0)
                    {
                        int icount = hDAL.Update(hModel);
                        if (icount > 0)
                        {
                            Base.Log.Log.Add(2, "baby_height", id);
                            SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "身高国际修改成功。");
                            Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("heightGrid", id, true));
                        }
                        else
                        {
                            SyCms.Window.WindowsReturn.WindowsReturnAlert("身高国际修改失败。");
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