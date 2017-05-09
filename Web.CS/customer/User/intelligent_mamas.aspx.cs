using System;

public partial class customer_User_intelligent_mamas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.Model.UserLogin ulModel = Web.UI.Users.GetUserInfo();
        if (Base.Fun.fun.pnumeric(ulModel.UserID))
        {
            string userid = Base.Fun.Fetch.getpost("userid").Trim(',');
            if (Base.Fun.fun.pnumeric(userid))
            {
                Web.DAL.customer.UserConsumption ucDAL = new Web.DAL.customer.UserConsumption();
                Web.Model.customer.UserConsumption ucModel = ucDAL.ReadOnUserID(userid);
                Response.Write(ucModel.mamasid);
            }
        }
        Response.End();
    }
}