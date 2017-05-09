using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class customer_UserappointmentSetup_Modi : Web.UI.Permissions
{
    protected string action = "";
    protected Web.Model.customer.UserappointmentSetup msModel = new Web.Model.customer.UserappointmentSetup();
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.customer.UserappointmentSetup msDAL = new Web.DAL.customer.UserappointmentSetup();
            msModel = msDAL.Read(StoresID, id);
            if (msModel.id.Equals(id))
            {
                if (action.Equals("save"))
                {
                    msModel.storesid = StoresID;
                    msModel.babytype = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("babytype"));
                    msModel.hoursNum = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("hoursNum"));
                    msModel.minute = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("minute"));
                    msModel.num = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("num"));
                    msModel.weeknum = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("weeknum"));

                    if (Base.Fun.fun.pnumeric(msModel.num))
                    {
                        if (msDAL.Update(msModel) > 0)
                        {
                            Web.UI.customer.UserappointmentLog.UpdateAll(StoresID, msModel.babytype, msModel.weeknum, msModel.hoursNum, msModel.minute, msModel.num);
                            SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "预约配置修改成功。");
                            Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("UserappointmentSetupGrid", id, true));
                        }
                        else
                        {
                            SyCms.Window.WindowsReturn.WindowsReturnAlert("预约配置修改失败。");
                        }
                    }
                    else
                    {
                        if (msDAL.Delete(StoresID, id) > 0)
                        {
                            Web.UI.customer.UserappointmentLog.UpdateAll(StoresID, msModel.babytype, msModel.weeknum, msModel.hoursNum, msModel.minute, "0");
                            SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "预约配置删除成功。");
                            Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("UserappointmentSetupGrid", id, true));
                        }
                        else
                        {
                            SyCms.Window.WindowsReturn.WindowsReturnAlert("预约配置删除失败。");
                        }
                    }

                    Response.End();
                }
            }
        }
    }
}