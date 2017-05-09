using System;

namespace Web.CS
{
    public partial class Main : System.Web.UI.Page
    {
        protected bool customerUserIsList = false;
        protected bool UserConsumptionIsList = false;
        protected bool UserappointmentIsList = false;
        protected bool UserConsumptionIsAdd = false;
        protected bool UserMessageIsList = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Base.Fun.fun.IsSelfRefer() || !Base.Fun.fun.ispost())
            {
                Response.End();
            }
            else
            {
                if (Web.UI.Users.CheckLogin())
                {
                    customerUserIsList = Web.UI.Users.CheckPermission("/customer/User/Lists.aspx", 1);
                    UserConsumptionIsList = Web.UI.Users.CheckPermission("/customer/UserConsumption/Lists.aspx", 1);
                    UserappointmentIsList = Web.UI.Users.CheckPermission("/customer/Userappointment/Lists.aspx", 1);
                    UserMessageIsList = Web.UI.Users.CheckPermission("/Sys/Message/Lists.aspx", 1);

                    
                    UserConsumptionIsAdd = Web.UI.Users.CheckPermission("/customer/UserConsumption/Add.aspx",4);
                }
                else
                {
                    Response.Write("['-1']");
                    Response.End();
                }
            }
        }
    }
}
