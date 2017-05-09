using System;

public partial class customer_User_intelligent_babytype : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.Model.UserLogin ulModel = Web.UI.Users.GetUserInfo();
        if (Base.Fun.fun.pnumeric(ulModel.UserID))
        {
            string userid = Base.Fun.Fetch.getpost("userid").Trim(',');
            if (Base.Fun.fun.pnumeric(userid))
            { 
                Web.DAL.customer.User uDAL=new Web.DAL.customer.User();
                Web.Model.customer.User uModel = uDAL.Read(userid);
                Response.Write(uModel.cycletype);
            }
        }
        Response.End();
    }
}