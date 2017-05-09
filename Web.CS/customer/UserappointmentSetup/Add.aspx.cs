using System;

public partial class customer_UserappointmentSetup_ADD : Web.UI.Permissions
{
    protected string action = "";
    protected string babytype = "";
    protected string weeknum = "", hoursNum = "", minute = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        babytype = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("babytype"));
        weeknum = Base.Fun.Fetch.getpost("weeknum");
        if (action.Equals("save"))
        {
            Web.Model.customer.UserappointmentSetup msModel = new Web.Model.customer.UserappointmentSetup();
            msModel.storesid = StoresID;
            msModel.babytype = babytype;
            msModel.hoursNum = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("hoursNum"));
            msModel.minute = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("minute"));
            msModel.num = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("num"));
            msModel.weeknum = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("weeknum"));
            Web.DAL.customer.UserappointmentSetup msDAL = new Web.DAL.customer.UserappointmentSetup();

            string id = msDAL.Read(StoresID, msModel.weeknum, msModel.hoursNum, msModel.minute, msModel.babytype).id;
            if (Base.Fun.fun.pnumeric(id))
            {
                if (Base.Fun.fun.pnumeric(msModel.num))
                {
                    msModel.id = id;
                    if (msDAL.Update(msModel) > 0)
                    {
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
                        SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "预约配置删除成功。");
                        Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("UserappointmentSetupGrid", id, true));
                    }
                    else
                    {
                        SyCms.Window.WindowsReturn.WindowsReturnAlert("预约配置删除失败。");
                    }
                }
            }
            else
            {
                id = msDAL.Insert(msModel);
                if (Base.Fun.fun.pnumeric(id))
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "预约配置添加成功。");
                    Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("UserappointmentSetupGrid", id, true));
                }
                else
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert("预约配置添加失败。");
                }
            }
            Response.End();
        }
        else {
            string timestr = Base.Fun.Fetch.getpost("timestr");
            if (timestr.Length > 0 && timestr.Contains(":"))
            {
                string[] timestrarr = timestr.Split(':');
                hoursNum = timestrarr[0];
                minute = timestrarr[1];
            }
        }
    }
}