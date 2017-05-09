using System;

public partial class customer_CardType_Del : Web.UI.Permissions
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.customer.CardType ctDAL = new Web.DAL.customer.CardType();
            if (ctDAL.Delete(StoresID, id) > 0)
            {
                Base.Log.Log.Add(3, "customer_CardType", id);
                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "卡类型删除成功。");
                Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("CardTypeGrid", true));
            }
        }
        Response.End();
    }
}