using System;

public partial class customer_User_Lists_View : Web.UI.Permissions
{
    protected string action = "";
    protected Web.Model.customer.User uModel = new Web.Model.customer.User();
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.customer.User uDAL = new Web.DAL.customer.User();
            uModel = uDAL.Read(StoresID, id);
            if (!uModel.userid.Equals(id))
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("未找到会员信息");
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