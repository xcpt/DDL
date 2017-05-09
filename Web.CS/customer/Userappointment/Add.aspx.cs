using System;

public partial class customer_Userappointment_Add : Web.UI.Permissions
{
    protected string action = "";
    protected string userid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        userid = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("id").Trim(','));
        if (action.Equals("save"))
        {
            if (Base.Fun.fun.pnumeric(userid))
            {
                Web.DAL.customer.Userappointment uaDAL = new Web.DAL.customer.Userappointment();
                Web.Model.customer.Userappointment uaModel = new Web.Model.customer.Userappointment();
                uaModel.userid = userid;
                Web.DAL.customer.User uDAL = new Web.DAL.customer.User();
                Web.Model.customer.User uModel = new Web.Model.customer.User();
                if (Web.UI.Sys.stores.ReadOutlets(StoresID))
                {
                    uModel = uDAL.Read_Outlets(uaModel.userid);
                }
                else
                {
                    uModel = uDAL.Read(StoresID, uaModel.userid);
                }
                if (Base.Fun.fun.pnumeric(uModel.cardid))
                {
                    Web.DAL.customer.Card cDAL = new Web.DAL.customer.Card();
                    Web.Model.customer.Card cModel = cDAL.Read(uModel.cardid);
                    if (cModel.cardstatus.Equals("-1"))
                    {
                        SyCms.Window.WindowsReturn.WindowsReturnAlert("此卡已停卡，不能预约消费");
                        Response.End();
                    }
                }
                //if (!Base.Fun.fun.pnumeric(uaDAL.ReadOnUserUserappointment(userid).id))
                //{
                    string datetime = uaModel.datetime;
                    uaModel.storesid = StoresID;
                    uaModel.datetime = Base.Fun.Fetch.getpost("datetime");
                    uaModel.datetimehouer = Base.Fun.Fetch.getpost("datetimehouer");
                    uaModel.datetimeminute = Base.Fun.Fetch.getpost("datetimeminute");
                    uaModel.swimteacherid = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("swimteacherid"));
                    uaModel.mamasid = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("mamasid"));
                    uaModel.istop = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("istop"));
                    uaModel.content = Base.Fun.Fetch.getpost("content");
                    uaModel.status = "0";
                    uaModel.addtime = DateTime.Now.ToString();
                    uaModel.source = "0";
                    string babytype = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("babytype"));
                    uaModel.cycletype = babytype;
                    string ID = uaDAL.Insert(uaModel);
                    if (Base.Fun.fun.pnumeric(ID))
                    {
                        Base.Log.Log.Add(1, "customer_Userappointment", ID);
                        SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "会员预约添加成功。");
                        Web.UI.customer.User_Stores.AddStoresUser(StoresID, uModel.userid);
                        Web.UI.Mobile.MessageLog.SendCancel(uModel, uaModel.datetime);
                        Web.UI.Mobile.MessageLog.SendOk(uModel, uaModel, true);
                        if (!uModel.cycletype.Equals(babytype))
                        {
                            uDAL.Update_cycletype(uaModel.userid, babytype);
                        }

                        //预约日志
                        Web.UI.customer.UserappointmentLog.AddNum(StoresID, Base.Fun.fun.IsZero(Web.UI.customer.User.Getcycletype(userid)), uaModel.datetime, uaModel.datetimehouer, uaModel.datetimeminute, "0", "1");

                        string winlist = Base.Fun.Fetch.getpost("winlist");
                        if (winlist.Equals("user"))
                        {
                            Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("UserGrid", userid, true));
                        }
                        else
                        {
                            Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("UserappointmentGrid", ID, true));
                        }
                    }
                    else
                    {
                        SyCms.Window.WindowsReturn.WindowsReturnAlert("预约添加失败。");
                    }
                //}
                //else
                //{
                //    SyCms.Window.WindowsReturn.WindowsReturnAlert("用户存在一个没有处理的预约。");
                //}
            }
            else {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("会员必须选择");
            }
            Response.End();
        }
    }
}