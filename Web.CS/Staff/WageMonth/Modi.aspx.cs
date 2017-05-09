using System;

public partial class Staff_WageMonth_Modi : Web.UI.Permissions
{
    protected string action = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        if (action.Equals("save"))
        {
            string[] satisfactionid = Base.Fun.Fetch.getpost("satisfactionid").Split(',');
            if (satisfactionid.Length == Web.Model.Data.Basic.satisfactionid.Keys.Count)
            {
                int i = 0;
                Web.DAL.Staff.position_Setup psDAL = new Web.DAL.Staff.position_Setup();
                Web.Model.Staff.position_Setup psModel = new Web.Model.Staff.position_Setup();
                psModel.storesid = StoresID;
                foreach (string s in Web.Model.Data.Basic.satisfactionid.Keys)
                {
                    psModel.satisfactionid = s;
                    psModel.price = Base.Fun.fun.IsZero(satisfactionid[i]);
                    if (psDAL.Update(psModel) <= 0)
                    {
                        psDAL.Insert(psModel);
                    }
                    i++;
                }
            }
            SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "配置成功");
            Response.End();
        }
    }
}