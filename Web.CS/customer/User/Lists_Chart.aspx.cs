using System;

public partial class customer_User_Lists_Chart : Web.UI.Permissions
{
    protected string sex = "";
    protected string id = "";
    protected string str = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Base.Fun.Fetch.getpost("id");
        string action = Base.Fun.Fetch.getpost("action");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.customer.User uDAL = new Web.DAL.customer.User();
            Web.Model.customer.User uModel = uDAL.Read(StoresID, id);
            if (uModel.userid.Equals(id))
            {
                if (action.Equals("weight"))
                {
                    str = Web.UI.customer.User.ViewChartOnWeight(uModel.sex, StoresID, id);
                }
                else {
                    str = Web.UI.customer.User.ViewChartOnHeight(uModel.sex, StoresID, id);
                }
            }
            else
            {
                Response.End();
            }
        }
        else
        {
            Response.End();
        }
    }
}