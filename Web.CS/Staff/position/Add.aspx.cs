using System;

public partial class Staff_position_Add : Web.UI.Permissions
{
    protected string action = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        if (action.Equals("save"))
        {
            Web.Model.Staff.position pModel = new Web.Model.Staff.position();
            pModel.storesid = StoresID;
            pModel.title = Base.Fun.Fetch.post("title");
            pModel.level = Base.Fun.Fetch.post("level");
            pModel.salary = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("salary"));
            pModel.deducted = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("deducted"));
            pModel.istake = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("istake"));
            pModel.description = Base.Fun.Fetch.getpost("description");
            Web.DAL.Staff.position pDAL = new Web.DAL.Staff.position();
            string id = pDAL.Insert(pModel);
            if (Base.Fun.fun.pnumeric(id))
            {
                Base.Log.Log.Add(1, "Staff_position", id);
                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "职位添加成功。");
                Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("positionGrid", id, true));
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("职位添加失败。");
            }
            Response.End();
        }
    }
}