using System;
using System.Text;

public partial class customer_UserConsumption_Add : Web.UI.Permissions
{
    protected string action = "";
    protected string userid = "";
    protected string appointmentid = "";
    protected Web.Model.customer.Userappointment uaModel = new Web.Model.customer.Userappointment();
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        userid = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("id").Trim(','));
        appointmentid = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("appointmentid"));
        if (Base.Fun.fun.pnumeric(appointmentid))
        {
            Web.DAL.customer.Userappointment upDAL = new Web.DAL.customer.Userappointment();
            Web.Model.customer.Userappointment upModel = upDAL.Read(appointmentid);
            if (!upModel.status.Equals("0"))
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert(false, "此预约已经结算。", true);
                Response.End();
            }
        }
        if (action.Equals("save"))
        {
            if (Base.Fun.fun.pnumeric(userid))
            {
                string CommodityID = Base.Fun.Fetch.getpost("CommodityID");
                if (Base.Fun.fun.pnumeric(CommodityID))
                {
                    Web.DAL.Sys.Commodity cDAL = new Web.DAL.Sys.Commodity();
                    Web.Model.Sys.Commodity cModel = cDAL.Read(StoresID, CommodityID);
                    if (cModel.id.Equals(CommodityID))
                    {
                        string IsCash = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("IsCash"));
                        double price = double.Parse(Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("price")));
                        Web.Model.customer.User uModel = Web.UI.customer.User.Read(StoresID, userid);
                        int xffs = -1;
                        string fstr = "";
                        if (IsCash.Equals("0"))
                        {
                            if (Base.Fun.fun.pnumeric(uModel.cModel.cardid))
                            {
                                if (Web.UI.customer.Card.GetGo(uModel.cModel, ref fstr))
                                {
                                    if (uModel.cModel.ctModel.paidmode.Equals("0"))
                                    {
                                        if (cModel.iscard.Equals("1"))
                                        {
                                            if (double.Parse(uModel.cModel.surpluspositivenum) > 0)
                                            {
                                                xffs = 1;
                                            }
                                            else if (double.Parse(uModel.cModel.surplusnegativenum) > 0)
                                            {
                                                xffs = 2;
                                            }
                                            else
                                            {
                                                SyCms.Window.WindowsReturn.WindowsReturnAlert(false, "会员卡中已经没有可用次数。", true);
                                                Response.End();
                                            }
                                            //price = Web.UI.customer.CardType.ReadPriceAndCardNum(StoresID, userid, uModel.cModel.ctModel);
                                        }
                                        else
                                        {
                                            SyCms.Window.WindowsReturn.WindowsReturnAlert(false, "会员卡为按次消费，而此消费项为金额消费，请选择消费方式为“会员卡”之外的消费。", true);
                                            Response.End();
                                        }
                                    }
                                    else
                                    {
                                        if (double.Parse(uModel.cModel.surplusprice) <= 0)
                                        {
                                            SyCms.Window.WindowsReturn.WindowsReturnAlert(false, "会员卡已没有余额。", true);
                                            Response.End();
                                        }
                                        else
                                        {
                                            xffs = 3;
                                        }
                                    }
                                }
                                else
                                {
                                    SyCms.Window.WindowsReturn.WindowsReturnAlert(false, fstr, true);
                                    Response.End();
                                }
                            }
                            else
                            {
                                SyCms.Window.WindowsReturn.WindowsReturnAlert(false, "无会员卡不能使用卡消费，请修改“消费方式”。", true);
                                Response.End();
                            }
                        }
                        Web.Model.customer.UserConsumption ucModel = new Web.Model.customer.UserConsumption();
                        ucModel.storesid = StoresID;
                        ucModel.userid = userid;
                        ucModel.monthage = Web.UI.customer.User.GetMonthday(userid);
                        ucModel.addtime = DateTime.Now.ToString();
                        ucModel.appointmentid = appointmentid;
                        ucModel.CommodityID = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("CommodityID"));
                        ucModel.price = price.ToString();
                        if (xffs == 1)
                        {
                            ucModel.Consumptiontype = "0";
                            //ucModel.price = Web.UI.customer.CardType.ReadPriceAndCardNum(StoresID, userid, uModel.cModel.ctModel).ToString();
                        }
                        else if (xffs == 2)
                        {
                            ucModel.Consumptiontype = "1";
                            //ucModel.price = Web.UI.customer.CardType.ReadPriceAndCardNum(StoresID, userid, uModel.cModel.ctModel).ToString();
                        }
                        else if (xffs == 3)
                        {
                            ucModel.Consumptiontype = "2";
                        }
                        else
                        {
                            ucModel.Consumptiontype = "3";
                        }
                        ucModel.content = Base.Fun.Fetch.getpost("content");
                        ucModel.height = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("height"));
                        ucModel.IsCash = IsCash;
                        ucModel.mamasid = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("mamasid"));
                        ucModel.satisfactionid = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("satisfactionid"));
                        ucModel.status = "1";
                        ucModel.statuscontent = "";
                        ucModel.swimteacherid = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("swimteacherid"));
                        ucModel.temperature = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("temperature"));
                        ucModel.timenum = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("timenum"));
                        ucModel.weight = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("weight"));
                        Web.DAL.customer.UserConsumption ucDAL = new Web.DAL.customer.UserConsumption();
                        string ID = ucDAL.Insert(ucModel);
                        if (Base.Fun.fun.pnumeric(ID))
                        {
                            if (ucModel.Consumptiontype.Equals("0"))
                            {
                                ucDAL.Update_Price(Web.UI.customer.User_Stores.UserConsumption(StoresID, userid, uModel.cardid, ID, true), ID);
                            }
                            else if (ucModel.Consumptiontype.Equals("1"))
                            {
                                ucDAL.Update_Price(Web.UI.customer.User_Stores.UserConsumption(StoresID, userid, uModel.cardid, ID, false), ID);
                            }
                            ///添加综合评价
                            if (Base.Fun.fun.pnumeric(ucModel.swimteacherid) && Base.Fun.fun.pnumeric(ucModel.satisfactionid))
                            {
                                Web.UI.customer.UserConsumption.Update_Member_membersatisfactionid(ucModel.swimteacherid);
                            }
                            StringBuilder str = new StringBuilder();
                            str.Append("姓&nbsp;&nbsp;&nbsp;&nbsp;名：" + uModel.name + "<br/>手机号：" + uModel.mobile + (uModel.cModel.cardNo.Length > 0 ? "<br/>卡&nbsp;&nbsp;&nbsp;&nbsp;号：" + uModel.cModel.cardNo + "<br/>" : "") + "<br/>");
                            Base.Log.Log.Add(1, "customer_UserConsumption", ID);
                            if (Base.Fun.fun.pnumeric(appointmentid))
                            {
                                Web.DAL.customer.Userappointment uaDAl = new Web.DAL.customer.Userappointment();
                                uaDAl.Update_Status(appointmentid, "1");
                            }
                            if (xffs == 1)
                            {
                                str.Append("正价次数：" + uModel.cModel.positivenum + "&nbsp;&nbsp;剩余：" + (int.Parse(uModel.cModel.surpluspositivenum) - 1).ToString() + "&nbsp;&nbsp;使用：" + (int.Parse(uModel.cModel.userpositivenum) + 1).ToString() + "<br/>");
                                str.Append("赠送次数：" + uModel.cModel.negativenum + "&nbsp;&nbsp;剩余：" + uModel.cModel.surplusnegativenum + "&nbsp;&nbsp;使用：" + uModel.cModel.usernegativenum + "<br/>");
                                str.Append("<font color=blue><b>正价次数消费</b></font>&nbsp;&nbsp;总剩余" + (int.Parse(uModel.cModel.surpluspositivenum) + int.Parse(uModel.cModel.surplusnegativenum) - 1) + "次");
                                Web.UI.customer.Card.Update_positivenum(uModel.cardid);
                            }
                            else if (xffs == 2)
                            {
                                str.Append("正价次数：" + uModel.cModel.positivenum + "&nbsp;&nbsp;剩余：" + uModel.cModel.surpluspositivenum + "&nbsp;&nbsp;使用：" + uModel.cModel.userpositivenum + "<br/>");
                                str.Append("赠送次数：" + uModel.cModel.negativenum + "&nbsp;&nbsp;剩余：" + (int.Parse(uModel.cModel.surplusnegativenum) - 1).ToString() + "&nbsp;&nbsp;使用：" + (int.Parse(uModel.cModel.usernegativenum) + 1).ToString() + "<br/>");
                                str.Append("<font color=blue><b>赠送交数消费</b></font>&nbsp;&nbsp;总剩余" + (int.Parse(uModel.cModel.surpluspositivenum) + int.Parse(uModel.cModel.surplusnegativenum) - 1) + "次");
                                Web.UI.customer.Card.Update_negativenum(uModel.cardid);
                            }
                            else if (xffs == 3)
                            {
                                if (double.Parse(uModel.cModel.surplusprice) >= price)
                                {
                                    Web.UI.customer.Card.Update_price(uModel.cardid, price.ToString());
                                    str.Append("正价次数：" + uModel.cModel.price + "&nbsp;&nbsp;剩余：" + (double.Parse(uModel.cModel.surplusprice) - price).ToString() + "&nbsp;&nbsp;使用：" + (double.Parse(uModel.cModel.userprice) + price).ToString() + "<br/>");
                                    str.Append("<font color=blue>卡内金额消费，消费金额：<b>" + price.ToString() + "</b>元</font>");
                                }
                                else
                                {
                                    Web.UI.customer.Card.Update_price(uModel.cardid, uModel.cModel.surplusprice);
                                    str.Append("总消费：" + price + "元，卡内金额消费" + uModel.cModel.surplusprice + "元，");
                                    price -= double.Parse(uModel.cModel.surplusprice);
                                    str.Append("差：<font color=blue>" + price.ToString() + "</font>元。");
                                }
                            }
                            Web.UI.score.rule.UserRule(ucModel.storesid, userid, ucModel, "会员消费");
                            Web.UI.customer.User_Stores.AddStoresUser(StoresID, userid);
                            Web.UI.customer.User.Updatemaxtimenum(StoresID, userid);
                            Base.Log.Log.Add(1, "customer_UserConsumption", ID);
                            str.Append("<p><span style=\"float:right;\"><input type=\"button\" onclick=\"AjaxFun('customer/UserConsumption/Lists_print.aspx', 'id=" + ID + "', '正在发起打印请求...');\" icon=\"icon-print\" value=\"打印小票\" /></span></p>");
                            SyCms.Window.WindowsReturn.WindowsReturnAlert(true, str.ToString(), true);
                            if (Base.Fun.fun.pnumeric(appointmentid))
                            {
                                Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("UserappointmentGrid", appointmentid, true));
                            }
                            else
                            {
                                string winlist = Base.Fun.Fetch.getpost("winlist");
                                if (winlist.Equals("user"))
                                {
                                    Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("UserGrid", userid, true));
                                }
                                else
                                {
                                    Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("UserConsumptionGrid", ID, true));
                                }
                            }
                        }
                        else
                        {
                            SyCms.Window.WindowsReturn.WindowsReturnAlert("消费添加失败。");
                        }
                    }
                }
                else
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert("消费商品必须选择");
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("会员必须选择");
            }
            Response.End();
        }
        else
        {
            Web.DAL.customer.Userappointment uaDAL = new Web.DAL.customer.Userappointment();
            if (!Base.Fun.fun.pnumeric(appointmentid))
            {
                uaModel = uaDAL.ReadOnUserID(userid);
                if (Base.Fun.fun.pnumeric(uaModel.id))
                {
                    appointmentid = uaModel.id;
                }
                else
                {
                    uaModel = new Web.Model.customer.Userappointment();
                    uaModel.userid = userid;
                }
            }
            else
            {
                uaModel = uaDAL.Read(appointmentid);
                if (Base.Fun.fun.pnumeric(userid))
                {
                    if (!uaModel.userid.Equals(userid))
                    {
                        uaModel = new Web.Model.customer.Userappointment();
                        uaModel.userid = userid;
                    }
                }
            }
        }
    }
}