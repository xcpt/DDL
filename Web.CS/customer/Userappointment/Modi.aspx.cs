using System;

public partial class customer_Userappointment_Modi : Web.UI.Permissions
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.customer.Userappointment uaDAL = new Web.DAL.customer.Userappointment();
            Web.Model.customer.Userappointment uaModel = uaDAL.Read(id);
            if (uaModel.id.Equals(id))
            {
                if (uaModel.status.Equals("0"))
                {
                    Web.DAL.customer.User uDAL = new Web.DAL.customer.User();
                    Web.Model.customer.User uModel = uDAL.Read(uaModel.userid);
                    Web.UI.Mobile.MessageLog.SendCancel(uModel, uaModel.datetime);
                    uaDAL.Update_Status(id, "2");
                    Base.Log.Log.Add(2, "customer_Userappointment", id);
                    //预约删除个数
                    Web.UI.customer.UserappointmentLog.AddNum(uaModel.storesid, Web.UI.customer.User.Getcycletype(uaModel.userid), uaModel.datetime, uaModel.datetimehouer, uaModel.datetimeminute, (uaModel.source.Equals("0") ? "0" : "-1"), (uaModel.source.Equals("0") ? "-1" : "0"));

                    SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "预约取消成功。");
                    Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("UserappointmentGrid", id, true));
                }
            }
        }
        Response.End();
    }
}