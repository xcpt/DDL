using System;

public partial class baby_weight_Del : Web.UI.Permissions
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.baby.weight wDAL = new Web.DAL.baby.weight();
            if (wDAL.Delete(id) > 0)
            {
                Base.Log.Log.Add(3, "baby_weight", id);
                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "删除成功。");
                Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("weightGrid", true));
            }
        }
        Response.End();
    }
}