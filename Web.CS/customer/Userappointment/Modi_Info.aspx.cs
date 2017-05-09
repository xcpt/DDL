using System;

public partial class customer_Userappointment_Modi_Info : Web.UI.Permissions
{
    protected string action = "";
    protected string id = "";
    protected Web.Model.customer.Userappointment uaModel = new Web.Model.customer.Userappointment();
    protected string cycletype = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.customer.Userappointment uaDAL = new Web.DAL.customer.Userappointment();
            uaModel = uaDAL.Read(id);
            if (uaModel.id.Equals(id))
            {
                if (uaModel.status.Equals("0"))
                {
                    action = Base.Fun.Fetch.getpost("action");
                    if (action.Equals("save"))
                    {
                        string datetime = uaModel.datetime;
                        string datetimehouer = uaModel.datetimehouer;
                        string datetimeminute = uaModel.datetimeminute;
                        //if (!Base.Fun.fun.pnumeric(uaDAL.ReadOnUserUserappointment(userid).id))
                        //{
                        uaModel.datetime = Base.Fun.Fetch.getpost("datetime");
                        uaModel.datetimehouer = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("datetimehouer"));
                        uaModel.datetimeminute = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("datetimeminute"));
                        uaModel.swimteacherid = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("swimteacherid"));
                        uaModel.mamasid = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("mamasid"));
                        uaModel.istop = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("istop"));
                        uaModel.content = Base.Fun.Fetch.getpost("content");
                        cycletype = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("babytype"));
                        if (uaDAL.Update(uaModel) > 0)
                        {
                            Base.Log.Log.Add(2, "customer_Userappointment", uaModel.id);
                            SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "会员预约修改成功。");

                            Web.DAL.customer.User uDAL = new Web.DAL.customer.User();
                            Web.Model.customer.User uModel = uDAL.Read(uaModel.userid);
                            if (!uModel.cycletype.Equals(cycletype))
                            {
                                uDAL.Update_cycletype(uaModel.userid, cycletype);
                            }


                            if (!DateTime.Parse(uaModel.datetime).ToString("yyyyMMdd").Equals(DateTime.Parse(datetime).ToString("yyyyMMdd")) || !uaModel.datetimehouer.Equals(datetimehouer) || !uaModel.datetimeminute.Equals(datetimeminute))
                            {
                                //取消之前的发送
                                Web.UI.Mobile.MessageLog.SendCancel(uModel, datetime);
                                //重新发送
                                Web.UI.Mobile.MessageLog.SendOk(uModel, uaModel, true);

                                string babytype = Base.Fun.fun.IsZero(Web.UI.customer.User.Getcycletype(uaModel.userid));
                                Web.UI.customer.UserappointmentLog.AddNum(uaModel.storesid, babytype, datetime, datetimehouer, datetimeminute, (uaModel.source.Equals("0") ? "0" : "-1"), (uaModel.source.Equals("0") ? "-1" : "0"));
                                Web.UI.customer.UserappointmentLog.AddNum(uaModel.storesid, babytype, uaModel.datetime, uaModel.datetimehouer, uaModel.datetimeminute, (uaModel.source.Equals("0") ? "0" : "1"), (uaModel.source.Equals("0") ? "1" : "0"));
                            }
                            //预约日志
                            Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("UserappointmentGrid", uaModel.id, true));
                        }
                        else
                        {
                            SyCms.Window.WindowsReturn.WindowsReturnAlert("预约修改失败。");
                        }
                        //}
                        //else
                        //{
                        //    SyCms.Window.WindowsReturn.WindowsReturnAlert("用户存在一个没有处理的预约。");
                        //}
                        Response.End();
                    }
                    else {
                        Web.DAL.customer.User uDAL = new Web.DAL.customer.User();
                        Web.Model.customer.User uModel = uDAL.Read(uaModel.userid);
                        cycletype = uModel.cycletype;
                    }
                }
                else
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert("状态为预约中才可修改");
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("未找到相关信息");
            }
        }
        else {
            SyCms.Window.WindowsReturn.WindowsReturnAlert("参数传递错误");
        }
    }
}