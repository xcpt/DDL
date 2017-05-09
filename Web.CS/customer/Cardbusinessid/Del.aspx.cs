using System;

public partial class customer_Cardbusinessid_Del :Web.UI.Permissions
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.customer.Cardbusinessid cbDAL = new Web.DAL.customer.Cardbusinessid();
            if (cbDAL.Delete(StoresID, id) > 0)
            {
                Base.Log.Log.Add(3, "customer_Cardbusinessid", id);
                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "业务类型删除成功。");
                Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("CardbusinessidGrid", true));
            }
        }
        Response.End();
    }
}