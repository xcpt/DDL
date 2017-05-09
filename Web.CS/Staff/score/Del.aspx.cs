using System;

public partial class Staff_score_Del : Web.UI.Permissions
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.Staff.score sDAL = new Web.DAL.Staff.score();
            Web.Model.Staff.score sModel = sDAL.Read(id);
            if (sModel.id.Equals(id))
            {
                if (sDAL.Delete(id) > 0)
                {
                    Base.Log.Log.Add(3, "Staff_Score", id);
                    SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "分值删除成功。");
                    Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("scoreGrid", true));
                }
            }
        }
        Response.End();
    }
}