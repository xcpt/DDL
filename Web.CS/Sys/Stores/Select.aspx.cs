using System;

public partial class Sys_Stores_Select : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.Model.UserLogin ulModel = Web.UI.Users.GetUserInfo();
            if (Base.Fun.fun.pnumeric(ulModel.UserID))
            {
                Web.UI.Users.SetStoresID(id);
                Response.Write("<script type=\"text/javascript\">$(\"#Left_2 li.dq a\").trigger(\"click\");</script>");
            }
        }
        Response.End();
    }
}