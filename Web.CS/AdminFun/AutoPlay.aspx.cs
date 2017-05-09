using System;
using System.Collections.Generic;

public partial class AdminFun_AutoPlay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.Window.AutoPlay.AutoPlayTrue();

        //添加其它发送
        if (Base.Fun.Session.PreventRefresh(360000, "BrithdayUser"))
        {
            Web.DAL.customer.User uDAL = new Web.DAL.customer.User();
            List<Web.Model.customer.User> uList = uDAL.ReadBirthday2_10();
            string mlID = "";
            DateTime SendTime;
            foreach (Web.Model.customer.User u in uList)
            {
                if (u.Client.Length > 0)
                {
                    SendTime = DateTime.Parse(u.birthday).AddDays(-5);
                    mlID = Web.UI.Mobile.MessageLog.SelectIDOnApp(u, SendTime, "9");
                    if (!Base.Fun.fun.pnumeric(mlID))
                    {
                        Web.UI.Mobile.MessageLog.SendBirthOk(u, u.birthday, "1");
                        //不存在就添加
                    }
                }
            }
            uList = uDAL.ReadCardEndTime30();
            foreach (Web.Model.customer.User u in uList)
            {
                if (u.Client.Length > 0)
                {
                    SendTime = DateTime.Parse(u.cModel.endtime).AddDays(-30);
                    mlID = Web.UI.Mobile.MessageLog.SelectIDOnApp(u, SendTime, "9");
                    if (!Base.Fun.fun.pnumeric(mlID))
                    {
                        Web.UI.Mobile.MessageLog.SendCardOk(u, u.cModel.endtime, "1");
                        //不存在就添加
                    }
                }
            }
        }
        //string Time = Base.Fun.Application.GetApplication("SystemStopUser");
        //int h = DateTime.Now.Hour;
        //if (h >= 8 && h <= 20 && (!Base.Fun.fun.IsDate(Time) || Base.Time.Time.TimeBad(Time, DateTime.Now.ToString(), "时") >= 2))
        //{
        //    Base.Fun.Application.AddApplication("SystemStopUser", DateTime.Now.ToString());
        //    Web.UI.customer.User.ReadList_StopOpen();
        //}
        Web.UI.Mobile.MessageLog.SendMobile();
        Response.End();
    }
}