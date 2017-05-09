using System;

public partial class Staff_position_Modi :Web.UI.Permissions
{
    protected string action = "";
    protected Web.Model.Staff.position pModel = new Web.Model.Staff.position();
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.Staff.position pDAL = new Web.DAL.Staff.position();
            pModel = pDAL.Read(StoresID, id);
            if (action.Equals("save"))
            {
                pModel.title = Base.Fun.Fetch.post("title");
                pModel.level = Base.Fun.Fetch.post("level");
                pModel.salary = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("salary"));
                pModel.deducted = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("deducted"));
                pModel.istake = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("istake"));
                pModel.description = Base.Fun.Fetch.getpost("description");
                int icount = pDAL.Update(pModel);
                if (icount>0)
                {
                    Base.Log.Log.Add(2, "Staff_position", id);
                    SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "职位修改成功。");
                    Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("positionGrid", id, true));
                }
                else
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert("职位修改失败。");
                }
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