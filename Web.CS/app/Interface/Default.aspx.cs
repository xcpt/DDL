using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Base.Fun;
using System.Web;
public partial class app_Interface_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int allstopcardnum = 3;
        string UserID = Base.Fun.Fetch.getpost("UserID");
        string token = Base.Fun.fun.NoCon(Base.Fun.Fetch.getpost("token"));
        if (Base.Fun.fun.pnumeric(UserID) && (token.Length == 0x20))
        {
            int num11;
            Web.Model.customer.User uModel = Web.UI.customer.User.AppPageLoad(UserID, token);
            switch (Base.Fun.Fetch.getpost("action"))
            {
                case "push":
                    {
                        string isPush = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("push"));
                        Web.DAL.customer.User user = new Web.DAL.customer.User();
                        if (user.Update_Push(UserID, isPush) > 0)
                        {
                            base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", isPush, "设置成功", "", ""));
                        }
                        break;
                    }
                case "info":
                case "newinfo":
                    {
                        Web.DAL.customer.User user2 = new Web.DAL.customer.User();
                        DataTable dt = user2.Read_AppInfo(UserID);
                        if (dt.Rows.Count > 0)
                        {
                            DataColumn column = new DataColumn
                            {
                                ColumnName = "birthdaystr"
                            };
                            dt.Columns.Add(column);
                            dt.Rows[0]["birthdaystr"] = Web.UI.APP.GetAge(DateTime.Parse(dt.Rows[0]["birthday"].ToString()));
                            column = new DataColumn
                            {
                                ColumnName = "birthdayhappy"
                            };
                            dt.Columns.Add(column);
                            dt.Rows[0]["birthdayhappy"] = Web.UI.APP.GetBirthday(DateTime.Parse(dt.Rows[0]["birthday"].ToString()));
                            column = new DataColumn
                            {
                                ColumnName = "cardstatusstr"
                            };
                            dt.Columns.Add(column);
                            dt.Rows[0]["cardstatusstr"] = dt.Rows[0]["cardstatus"].ToString().Equals("1") ? "正常" : "停卡";
                            column = new DataColumn
                            {
                                ColumnName = "allstopcard"
                            };
                            dt.Columns.Add(column);
                            dt.Rows[0]["allstopcard"] = allstopcardnum;
                            Web.DAL.customer.CardLog log = new Web.DAL.customer.CardLog();
                            column = new DataColumn
                            {
                                ColumnName = "stopcardnum"
                            };
                            dt.Columns.Add(column);
                            dt.Rows[0]["stopcardnum"] = log.View_Num(dt.Rows[0]["cardid"].ToString(), "4");
                            DataTable table2 = new DataTable();
                            Web.DAL.Sys.News news = new Web.DAL.Sys.News();
                            Web.DAL.Sys.stores stores = new Web.DAL.Sys.stores();
                            Web.Model.Sys.stores stores2 = new Web.Model.Sys.stores();
                            if (Base.Fun.fun.pnumeric(uModel.userstoresid))
                            {
                                stores2 = stores.Read(uModel.userstoresid);
                            }
                            table2 = news.ReadListApp(uModel.userstoresid, stores2.Province, "2", 5);
                            string str5 = Web.UI.APP.ToJson(dt, true).Trim().TrimEnd(new char[] { '}' });
                            string lat = Base.Fun.Fetch.getpost("lat");
                            string lng = Base.Fun.Fetch.getpost("lng");
                            str5 = str5 + Web.UI.APP.ReadTQ(lat, lng, stores2.City) + ",\"activity\":" + Web.UI.APP.ToJson(table2, false) + "}";
                            table2.Dispose();
                            List<Web.Model.Sys.Category> list = new Web.DAL.Sys.Category().ReadListOnIndex("1");
                            StringBuilder builder = new StringBuilder();
                            foreach (Web.Model.Sys.Category category2 in list)
                            {
                                builder.Append("{\"classid\":\"" + category2.classid + "\",\"classname\":\"" + category2.classname + "\",\"pic\":\"" + category2.pic + "\",\"content\":\"" + JScript.htmltojavascriptNoD(category2.content) + "\"},");
                            }
                            str5 = str5 + ",\"category\":[" + builder.ToString().TrimEnd(new char[] { ',' }) + "]";
                            int days = Base.Time.Time.TimeBad(dt.Rows[0]["birthday"].ToString(), DateTime.Now.ToString(), "天");
                            table2 = new Web.DAL.Sys.News().ReadListAppIndex(5, days);
                            str5 = str5 + ",\"news\":" + Web.UI.APP.ToJson(table2, false);
                            table2.Dispose();
                            table2 = new Web.DAL.Sys.News().ReadListAppIndex(1, days, "10");
                            str5 = str5 + ",\"video\":" + Web.UI.APP.ToJson(table2, false);
                            table2.Dispose();
                            base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "", str5, ""));
                        }
                        else
                        {
                            base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "未找到用户信息", "", ""));
                        }
                        dt.Dispose();
                        break;
                    }
                case "babyshow":
                    {
                        string page = Base.Fun.Fetch.getpost("Page");
                        DataTable table3 = new Web.DAL.baby.album().Read_AppList(UserID, page);
                        if (table3.Rows.Count <= 0)
                        {
                            base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "已经没有更多相片了", "[]", ""));
                        }
                        else
                        {
                            base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "", Web.UI.APP.ToJson(table3, false), ""));
                        }
                        table3.Dispose();
                        break;
                    }
                case "userphoto":
                    {
                        string Page = Base.Fun.Fetch.getpost("Page");
                        string photoUserID = Base.Fun.Fetch.getpost("photoUserID");
                        if (!Base.Fun.fun.pnumeric(Page))
                        {
                            Page = "1";
                        }
                        if (!Base.Fun.fun.pnumeric(photoUserID))
                        {
                            photoUserID = UserID;
                        }
                        DataTable table4 = new Web.DAL.baby.album().Read_AppList(photoUserID);
                        if (table4.Rows.Count > 0)
                        {
                            int num3 = 10;
                            int num4 = (int)Math.Ceiling((double)(((double)table4.Rows.Count) / ((double)num3)));
                            int num5 = int.Parse(Page);
                            if (num5 > num4)
                            {
                                base.Response.Write(Web.UI.APP.GetJosn("0", photoUserID, "", "", "已经没有更多相册了", "[]", ""));
                            }
                            else
                            {
                                int num6 = (num5 - 1) * num3;
                                int count = num5 * num3;
                                if (count > table4.Rows.Count)
                                {
                                    count = table4.Rows.Count;
                                }
                                base.Response.Write(Web.UI.APP.GetJosn("1", photoUserID, "", "", "", Web.UI.APP.ToJson(table4, num6, count, false), ""));
                            }
                        }
                        else
                        {
                            base.Response.Write(Web.UI.APP.GetJosn("0", photoUserID, "", "", "已经没有更多相册了", "[]", ""));
                        }
                        table4.Dispose();
                        break;
                    }
                case "photolist":
                    {
                        string str11 = Base.Fun.Fetch.getpost("Page");
                        string str12 = Base.Fun.Fetch.getpost("monthage");
                        string str13 = Base.Fun.Fetch.getpost("PhotoUserID");
                        string addtime = Base.Fun.Fetch.getpost("addtime");
                        if (Base.Fun.fun.pnumeric(str13) && Base.Fun.fun.pnumeric(str12))
                        {
                            if (!Base.Fun.fun.pnumeric(str11))
                            {
                                new Web.DAL.customer.User().UpdatePhotoHits(str13);
                                str11 = "1";
                            }
                            DataTable table5 = new Web.DAL.baby.album().Read_AppList(str13, str12, UserID, addtime, str11);
                            if (table5.Rows.Count > 0)
                            {
                                base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "", Web.UI.APP.ToJson(table5, false), ""));
                            }
                            else
                            {
                                base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "已经没有更多相片了", "[]", ""));
                            }
                            table5.Dispose();
                        }
                        else
                        {
                            base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "参数错误", "[]", ""));
                        }
                        break;
                    }
                case "photolove":
                    {
                        string str14 = Base.Fun.Fetch.getpost("id");
                        if (Base.Fun.fun.pnumeric(str14))
                        {
                            Web.DAL.baby.album album4 = new Web.DAL.baby.album();
                            Web.Model.baby.album album5 = album4.Read(str14);
                            if (!album5.UserID.Equals(UserID))
                            {
                                Web.DAL.baby.album_Praise praise = new Web.DAL.baby.album_Praise();
                                Web.Model.baby.album_Praise apModel = new Web.Model.baby.album_Praise
                                {
                                    userid = UserID,
                                    albumid = str14
                                };
                                if (Base.Fun.fun.pnumeric(praise.Read(apModel)))
                                {
                                    praise.Delete(apModel);
                                    album4.Update_PraiseCancel(album5.UserID, str14);
                                    num11 = int.Parse(album5.Praise) - 1;
                                    base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "操作成功", "{\"praise\":\"" + num11.ToString() + "\",\"type\":\"cancel\"}", ""));
                                }
                                else
                                {
                                    praise.Insert(apModel);
                                    album4.Update_Praise(album5.UserID, str14);
                                    num11 = int.Parse(album5.Praise) + 1;
                                    base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "操作成功", "{\"praise\":\"" + num11.ToString() + "\",\"type\":\"add\"}", ""));
                                }
                                break;
                            }
                            base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "自己不能对自己操作", "{}", ""));
                        }
                        break;
                    }
                case "photohits":
                    {
                        string str15 = Base.Fun.Fetch.getpost("id");
                        if (Base.Fun.fun.pnumeric(str15))
                        {
                            Web.DAL.baby.album album6 = new Web.DAL.baby.album();
                            Web.Model.baby.album album7 = album6.Read(str15);
                            if (!album7.UserID.Equals(UserID))
                            {
                                album6.Update_Hits(album7.UserID, str15);
                                num11 = int.Parse(album7.hits) + 1;
                                base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "操作成功", "{\"photohits\":\"" + num11.ToString() + "\"}", ""));
                                break;
                            }
                            base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "自己不能增加自己人气", "{}", ""));
                        }
                        break;
                    }
                case "evaluation":
                    {
                        string str16 = Base.Fun.Fetch.getpost("Page");
                        if (!Base.Fun.fun.pnumeric(str16))
                        {
                            str16 = "1";
                        }
                        DataTable table6 = new Web.DAL.customer.UserConsumption().ReadAppList(UserID, str16);
                        if (table6.Rows.Count > 0)
                        {
                            base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "", Web.UI.APP.ToJson(table6, false), ""));
                        }
                        else
                        {
                            base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "已经没有更多评价信息了", "[]", ""));
                        }
                        table6.Dispose();
                        break;
                    }
                case "evaluationview":
                    {
                        string str17 = Base.Fun.Fetch.getpost("id");
                        if (Base.Fun.fun.pnumeric(str17))
                        {
                            Web.Model.customer.UserConsumption consumption3 = new Web.DAL.customer.UserConsumption().Read(str17);
                            if (!consumption3.id.Equals(str17) || !consumption3.userid.Equals(UserID))
                            {
                                base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "错误", "", ""));
                                break;
                            }
                            Web.Model.Staff.member member2 = new Web.DAL.Staff.member().Read(consumption3.swimteacherid);
                            object[] objArray = new object[0x19];
                            objArray[0] = "{\"id\":\"";
                            objArray[1] = consumption3.id;
                            objArray[2] = "\",\"addtime\":\"";
                            objArray[3] = DateTime.Parse(consumption3.addtime).ToString("yyyy-MM-dd hh:mm:ss");
                            objArray[4] = "\",\"ismodi\":";
                            objArray[5] = (Base.Time.Time.TimeBad(consumption3.addtime, DateTime.Now.ToString(), "天") <= 7) ? "1" : "-1";
                            objArray[6] = ",\"satisfactionid\":\"";
                            num11 = int.Parse(consumption3.satisfactionid) + 1;
                            objArray[7] = num11.ToString();
                            objArray[8] = "\",\"satisfactionuserid\":\"";
                            objArray[9] = consumption3.satisfactionuserid;
                            objArray[10] = "\",\"name\":\"";
                            objArray[11] = member2.name;
                            objArray[12] = "\",\"userface\":\"";
                            objArray[13] = member2.userface;
                            objArray[14] = "\",\"membersatisfactionid\":\"";
                            objArray[15] = int.Parse(member2.membersatisfactionid) + 1;
                            objArray[0x10] = "\",\"storesname\":\"";
                            objArray[0x11] = Web.UI.Sys.stores.GetStoresName(consumption3.storesid);
                            objArray[0x12] = "\",\"weight\":\"";
                            objArray[0x13] = consumption3.weight;
                            objArray[20] = "\",\"height\":\"";
                            objArray[0x15] = consumption3.height;
                            objArray[0x16] = "\",\"timenum\":\"";
                            objArray[0x17] = consumption3.timenum;
                            objArray[0x18] = "\"}";
                            string str18 = string.Concat(objArray);
                            base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "成功", str18.ToString(), ""));
                        }
                        break;
                    }
                case "updateevaluationother":
                    {
                        string str19 = Base.Fun.Fetch.getpost("id");
                        if (!Base.Fun.fun.pnumeric(str19))
                        {
                            base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "参数错误", "", ""));
                            break;
                        }
                        string str20 = Base.Fun.Fetch.getpost("k");
                        string str21 = Base.Fun.Fetch.getpost("v");
                        if (Base.Fun.fun.IsNumeric(str21) && (str20.Length > 0))
                        {
                            Web.DAL.customer.UserConsumption consumption4 = new Web.DAL.customer.UserConsumption();
                            Web.Model.customer.UserConsumption consumption5 = consumption4.Read(str19);
                            if (!consumption5.id.Equals(str19) || !consumption5.userid.Equals(UserID))
                            {
                                break;
                            }
                            if (Base.Time.Time.TimeBad(consumption5.addtime, DateTime.Now.ToString(), "天") > 7)
                            {
                                base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "只能修改一周内的", "", ""));
                                break;
                            }
                            switch (str20)
                            {
                                case "weight":
                                    consumption4.Update_weight(str19, str21);
                                    Web.UI.customer.UserConsumptionSatisfaction.UpdateUserConsumptionSatisfaction(consumption5.storesid, consumption5.userid, "0", str19, "1", consumption5.weight, str21, "用户Web.UI.APP修改");
                                    break;

                                case "height":
                                    consumption4.Update_height(str19, str21);
                                    Web.UI.customer.UserConsumptionSatisfaction.UpdateUserConsumptionSatisfaction(consumption5.storesid, consumption5.userid, "0", str19, "2", consumption5.weight, str21, "用户Web.UI.APP修改");
                                    break;

                                case "timenum":
                                    consumption4.Update_timenum(str19, str21);
                                    Web.UI.customer.UserConsumptionSatisfaction.UpdateUserConsumptionSatisfaction(consumption5.storesid, consumption5.userid, "0", str19, "3", consumption5.weight, str21, "用户Web.UI.APP修改");
                                    break;
                            }
                            base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "修改成功", "", ""));
                        }
                        break;
                    }
                case "updateevaluation":
                    {
                        string str22 = Base.Fun.Fetch.getpost("id");
                        if (Base.Fun.fun.pnumeric(str22))
                        {
                            string str23 = Base.Fun.Fetch.getpost("satisfactionid");
                            if (Base.Fun.fun.pnumeric(str23))
                            {
                                num11 = int.Parse(str23) - 1;
                                str23 = num11.ToString();
                                Web.DAL.customer.UserConsumption consumption6 = new Web.DAL.customer.UserConsumption();
                                Web.Model.customer.UserConsumption consumption7 = consumption6.Read(str22);
                                if (consumption7.id.Equals(str22))
                                {
                                    if (Base.Time.Time.TimeBad(consumption7.addtime, DateTime.Now.ToString(), "天") <= 7)
                                    {
                                        consumption6.Update_satisfactionidOnUser(UserID, str22, str23);
                                        Web.UI.customer.UserConsumption.Update_Member_membersatisfactionid(consumption7.swimteacherid);
                                        Web.UI.customer.UserConsumptionSatisfaction.UpdateUserConsumptionSatisfaction(consumption7.storesid, consumption7.userid, "0", str22, "0", consumption7.satisfactionid, str23, "用户Web.UI.APP修改");
                                        string str24 = Fetch.getpost("weight");
                                        if (fun.IsNumeric(str24))
                                        {
                                            consumption6.Update_weight(str22, str24);
                                            Web.UI.customer.UserConsumptionSatisfaction.UpdateUserConsumptionSatisfaction(consumption7.storesid, consumption7.userid, "0", str22, "1", consumption7.weight, str24, "用户Web.UI.APP修改");
                                        }
                                        string str25 = Fetch.getpost("height");
                                        if (fun.IsNumeric(str25))
                                        {
                                            consumption6.Update_height(str22, str25);
                                            Web.UI.customer.UserConsumptionSatisfaction.UpdateUserConsumptionSatisfaction(consumption7.storesid, consumption7.userid, "0", str22, "2", consumption7.weight, str25, "用户Web.UI.APP修改");
                                        }
                                        string str26 = Fetch.getpost("timenum");
                                        if (fun.IsNumeric(str26))
                                        {
                                            consumption6.Update_timenum(str22, str26);
                                            Web.UI.customer.UserConsumptionSatisfaction.UpdateUserConsumptionSatisfaction(consumption7.storesid, consumption7.userid, "0", str22, "2", consumption7.weight, str26, "用户Web.UI.APP修改");
                                        }
                                        base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "修改成功", "", ""));
                                    }
                                    else
                                    {
                                        base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "只能修改一周内的", "", ""));
                                    }
                                }
                            }
                        }
                        else
                        {
                            base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "参数错误", "", ""));
                        }
                        break;
                    }
                case "appointmentdate":
                    {
                        DateTime now = DateTime.Now;
                        List<Web.Model.customer.Userappointment> list2 = new Web.DAL.customer.Userappointment().ReadOnUserUserappointmentAll(UserID, now);
                        StringBuilder builder2 = new StringBuilder();
                        builder2.Append("[");
                        for (int j = 1; j <= 2; j++)
                        {
                            builder2.Append("{\"babytype\":\"" + ((j == 2) ? "0" : "1") + "\",\"date\":[");
                            for (int i = 0; i <= 7; i++)
                            {
                                DateTime newdt = now.AddDays((double)i);
                                Web.Model.customer.Userappointment userappointment2 = list2.Find(ua => ua.cycletype.Equals(j.ToString()) && DateTime.Parse(ua.datetime).ToString("yyyyMMdd").Equals(newdt.ToString("yyyyMMdd")));
                                builder2.Append("{\"datetime\":\"" + newdt.ToString("yyyy-MM-dd") + "\",\"day\":\"" + newdt.Day.ToString() + "\",\"weekstr\":\"" + fun.WeekValue(newdt) + "\",\"user\":\"" + ((userappointment2 != null) ? userappointment2.id : "") + "\"},");
                            }
                            builder2.Remove(builder2.Length - 1, 1);
                            builder2.Append("]},");
                        }
                        builder2.Remove(builder2.Length - 1, 1);
                        builder2.Append("]");
                        base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "日期结果", builder2.ToString(), ""));
                        break;
                    }
                case "appointment":
                    {
                        string str27;
                        if (!fun.IsZero(Fetch.getpost("babytype")).Equals("0"))
                        {
                            str27 = "1";
                        }
                        else
                        {
                            str27 = "2";
                        }
                        string strDate = Fetch.getpost("datetime");
                        if (fun.IsDate(strDate))
                        {
                            if (double.Parse(DateTime.Now.ToString("yyyyMMdd")) <= double.Parse(DateTime.Parse(strDate).ToString("yyyyMMdd")))
                            {
                                Web.DAL.customer.User user5 = new Web.DAL.customer.User();
                                string userstoresid = user5.Read(UserID).userstoresid;
                                base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "", Web.UI.customer.UserappointmentLog.ViewApp(userstoresid, UserID, str27, DateTime.Parse(strDate)), ""));
                            }
                            else
                            {
                                base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "必须大于今天的日期", "[]", ""));
                            }
                        }
                        else
                        {
                            base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "参数错误", "[]", ""));
                        }
                        break;
                    }
                case "cancelappointment":
                    {
                        string str30 = Fetch.getpost("id");
                        if (fun.pnumeric(str30))
                        {
                            Web.DAL.customer.Userappointment userappointment3 = new Web.DAL.customer.Userappointment();
                            Web.Model.customer.Userappointment userappointment4 = userappointment3.Read(str30);
                            if (userappointment4.userid.Equals(UserID))
                            {
                                if (!userappointment4.status.Equals("0"))
                                {
                                    base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "预约状态不为预约中", "{}", ""));
                                    break;
                                }
                                userappointment3.Update_Status_Cancel(str30, "用户APP取消");
                                Web.UI.Mobile.MessageLog.SendCancel(uModel, userappointment4.datetime);
                                Web.UI.customer.UserappointmentLog.AddNum(userappointment4.storesid, uModel.cycletype, userappointment4.datetime, userappointment4.datetimehouer, userappointment4.datetimeminute, userappointment4.source.Equals("1") ? "-1" : "0", userappointment4.source.Equals("1") ? "0" : "-1");
                                base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "预约取消成功", "{}", ""));
                            }
                        }
                        break;
                    }
                case "appointmentlist":
                    {
                        List<Web.Model.customer.Userappointment> list3 = new Web.DAL.customer.Userappointment().ReadOnUserUserappointment(UserID);
                        StringBuilder builder3 = new StringBuilder();
                        builder3.Append("[");
                        Web.DAL.Staff.member member3 = new Web.DAL.Staff.member();
                        Web.DAL.Staff.department department = new Web.DAL.Staff.department();
                        foreach (Web.Model.customer.Userappointment userappointment6 in list3)
                        {
                            Web.Model.Staff.member member4 = member3.Read(userappointment6.swimteacherid);
                            builder3.Append("{\"id\":\"" + userappointment6.id + "\",\"datetime\":\"" + DateTime.Parse(userappointment6.datetime).ToString("yyyy-MM-dd") + " " + userappointment6.datetimehouer.PadLeft(2, '0') + ":" + userappointment6.datetimeminute.PadLeft(2, '0') + "\",\"storesname\":\"" + Web.UI.Sys.stores.GetStoresName(userappointment6.storesid) + "\",\"name\":\"" + member4.name + "\",\"userface\":\"" + member4.userface + "\",\"department\":\"" + department.Read(member4.departmentid).title + "\"},");
                        }
                        builder3.Append("]");
                        base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "成功", builder3.ToString().Replace("},]", "}]"), ""));
                        break;
                    }
                case "consumptionlist":
                    {
                        string str31 = Fetch.getpost("Page");
                        if (!fun.pnumeric(str31))
                        {
                            str31 = "1";
                        }
                        DataTable table7 = new Web.DAL.customer.UserConsumption().ReadAppListAtStores(UserID, str31);
                        if (table7.Rows.Count > 0)
                        {
                            base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "", Web.UI.APP.ToJson(table7, false), ""));
                        }
                        else
                        {
                            base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "已经没有更多消费信息了", "[]", ""));
                        }
                        table7.Dispose();
                        break;
                    }
                case "swimteacher":
                    {
                        string str32;
                        if (!fun.IsZero(Fetch.getpost("babytype")).Equals("0"))
                        {
                            str32 = "1";
                        }
                        else
                        {
                            str32 = "2";
                        }
                        string s = Fetch.getpost("datetime");
                        string str34 = Fetch.getpost("timestr");
                        if (fun.IsDate(s + " " + str34))
                        {
                            if (double.Parse(DateTime.Now.ToString("yyyyMMdd")) <= double.Parse(DateTime.Parse(s).ToString("yyyyMMdd")))
                            {
                                Web.Model.customer.User user9 = new Web.DAL.customer.User().Read(UserID);
                                if (user9.cycletype.Equals(str32))
                                {
                                    string storesid = user9.userstoresid;
                                    string[] strArray = str34.Split(new char[] { ':' });
                                    strArray[0] = int.Parse(strArray[0]).ToString();
                                    strArray[1] = int.Parse(strArray[1]).ToString();
                                    DataTable table8 = new Web.DAL.Staff.swimteacher().ReadListApp(storesid, UserID, s, strArray[0], strArray[1], str32);
                                    if (table8.Rows.Count > 0)
                                    {
                                        base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "", Web.UI.APP.ToJson(table8, false), ""));
                                    }
                                    else
                                    {
                                        base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "今天没有老师", "[]", ""));
                                    }
                                    table8.Dispose();
                                }
                                else
                                {
                                    base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "您的资料婴儿类型为:" + Web.Model.Data.Basic.BabyType[user9.cycletype] + ";", "[]", ""));
                                }
                            }
                            else
                            {
                                base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "必须大于今天的日期", "[]", ""));
                            }
                        }
                        else
                        {
                            base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "参数错误", "[]", ""));
                        }
                        break;
                    }
                case "addappointment":
                    {
                        string str36;
                        if (!fun.IsZero(Fetch.getpost("babytype")).Equals("0"))
                        {
                            str36 = "1";
                        }
                        else
                        {
                            str36 = "2";
                        }
                        string str37 = Fetch.getpost("datetime");
                        string str38 = Fetch.getpost("timestr");
                        string str39 = Fetch.getpost("swimteacherid");
                        if (fun.pnumeric(str39))
                        {
                            if (fun.IsDate(str37 + " " + str38))
                            {
                                if (double.Parse(DateTime.Now.ToString("yyyyMMdd")) <= double.Parse(DateTime.Parse(str37).ToString("yyyyMMdd")))
                                {
                                    string[] strArray2 = str38.Split(new char[] { ':' });
                                    strArray2[0] = int.Parse(strArray2[0]).ToString();
                                    strArray2[1] = int.Parse(strArray2[1]).ToString();
                                    Web.Model.customer.User user11 = new Web.DAL.customer.User().Read(UserID);
                                    Web.DAL.customer.Card card = new Web.DAL.customer.Card();
                                    Web.Model.customer.Card cModel = card.Read(user11.cardid);
                                    if (cModel.cardstatus.Equals("1"))
                                    {
                                        if (!Base.Fun.fun.IsDate(cModel.endtime) || double.Parse(DateTime.Parse(cModel.endtime).ToString("yyyyMMdd")) >= double.Parse(DateTime.Now.ToString("yyyyMMdd")))
                                        {
                                            if (user11.cycletype.Equals(str36))
                                            {
                                                Web.Model.customer.UserappointmentLog log3 = new Web.DAL.customer.UserappointmentLog().Read(user11.userstoresid, str36, DateTime.Parse(str37).ToString("yyyyMMdd"), strArray2[0], strArray2[1]);
                                                num11 = int.Parse(log3.pcusernum) / 2;
                                                int num9 = int.Parse(num11.ToString().Split(new char[] { '.' })[0]) + int.Parse(log3.appusernum);
                                                if (fun.pnumeric(log3.id) && (num9 >= int.Parse(log3.num)))
                                                {
                                                    base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "你下手慢了，" + str37 + " " + str38 + "已经约完了。", "", ""));
                                                }
                                                else if (Base.Time.Time.TimeBad(DateTime.Now.ToString(), str37 + " " + str38, "时") <= 0)
                                                {
                                                    base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "不能预约小于当前时间的", "", ""));
                                                }
                                                else
                                                {
                                                    Web.DAL.customer.Userappointment userappointment7 = new Web.DAL.customer.Userappointment();
                                                    Web.Model.customer.Userappointment uaModel = new Web.Model.customer.Userappointment
                                                    {
                                                        userid = UserID,
                                                        storesid = user11.userstoresid,
                                                        datetime = str37,
                                                        datetimehouer = int.Parse(strArray2[0]).ToString(),
                                                        datetimeminute = int.Parse(strArray2[1]).ToString(),
                                                        swimteacherid = str39,
                                                        mamasid = Base.Fun.fun.IsZero(Web.UI.customer.UserConsumption.ReadUser_mamasid(UserID)),
                                                        istop = "0",
                                                        content = "",
                                                        status = "0",
                                                        addtime = DateTime.Now.ToString(),
                                                        source = "1",
                                                        cycletype = str36
                                                    };
                                                    Web.Model.customer.Userappointment upModel = userappointment7.ReadOnUserUserappointment(uaModel.datetime, uaModel.datetimehouer, uaModel.datetimeminute, uaModel.swimteacherid);
                                                    if (Base.Fun.fun.pnumeric(upModel.id))
                                                    {
                                                        base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "一天只能预约一个时间段哦！", "", ""));
                                                    }
                                                    else
                                                    {
                                                        Web.Model.customer.Userappointment userappointment9 = userappointment7.ReadOnUserUserappointmentOnUser(uaModel.userid, uaModel.datetime);
                                                        if (!fun.pnumeric(userappointment9.id))
                                                        {
                                                            if (fun.pnumeric(userappointment7.Insert(uaModel)))
                                                            {
                                                                Web.DAL.Staff.member member5 = new Web.DAL.Staff.member();
                                                                string name = member5.Read(user11.userstoresid, uaModel.swimteacherid).name;
                                                                if (name.Length > 0)
                                                                {
                                                                    name = name.Substring(0, 1) + "老师";
                                                                }
                                                                Web.UI.customer.User_Stores.AddStoresUser(user11.userstoresid, user11.userid);
                                                                base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "你已预约成功！\r\n老师：" + name + "；\r\n店面：" + Web.UI.Sys.stores.GetStoresName(user11.userstoresid) + "；\r\n时间：" + DateTime.Parse(str37).ToString("MM月dd日") + ((int.Parse(uaModel.datetimehouer) > 12) ? "下午" : "上午") + uaModel.datetimehouer + "点", "", ""));
                                                                Web.UI.customer.UserappointmentLog.AddNum(user11.userstoresid, str36, uaModel.datetime, uaModel.datetimehouer, uaModel.datetimeminute, "1", "0");
                                                                Web.UI.Mobile.MessageLog.SendOk(user11, uaModel, true);
                                                            }
                                                            else
                                                            {
                                                                base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "预约失败", "", ""));
                                                            }
                                                        }
                                                        else if (user11.userstoresid.Equals(userappointment9.storesid))
                                                        {
                                                            if (userappointment9.datetimehouer.Equals(uaModel.datetimehouer) && userappointment9.datetimeminute.Equals(uaModel.datetimeminute))
                                                            {
                                                                base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "您已经预约了" + uaModel.datetimehouer + ":" + uaModel.datetimeminute + "的老师。", "", ""));
                                                            }
                                                            else
                                                            {
                                                                base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "一天只能预约一个时间段哦！", "", ""));
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (userappointment9.datetimehouer.Equals(uaModel.datetimehouer) && userappointment9.datetimeminute.Equals(uaModel.datetimeminute))
                                                            {
                                                                base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "您已经的【" + Web.UI.Sys.stores.GetStoresName(userappointment9.storesid) + "】预约了" + uaModel.datetimehouer + ":" + uaModel.datetimeminute + "的老师。", "", ""));
                                                            }
                                                            else
                                                            {
                                                                base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "此时间点的老师您已经在【" + Web.UI.Sys.stores.GetStoresName(userappointment9.storesid) + "】预约了。", "", ""));
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "不能跨类型预约", "", ""));
                                            }
                                        }
                                        else
                                        {
                                            base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "此卡已到停卡日期。", "", ""));
                                        }
                                    }
                                    else
                                    {
                                        base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "此卡已停卡，不能预约消费", "", ""));
                                    }
                                }
                                else
                                {
                                    base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "必须大于今天的日期", "", ""));
                                }
                            }
                            else
                            {
                                base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "参数错误", "", ""));
                            }
                        }
                        else
                        {
                            base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "没有老师", "", ""));
                        }
                        break;
                    }
                case "height":
                    {
                        Web.Model.customer.User user13 = new Web.DAL.customer.User().Read(UserID);
                        string str42 = Web.UI.customer.User.ViewChartOnHeightOnApp(user13.sex, user13.userstoresid, user13.userid);
                        if (str42.Length <= 0)
                        {
                            base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "无配置数据", "", ""));
                            break;
                        }
                        base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "", str42, ""));
                        break;
                    }
                case "weight":
                    {
                        Web.Model.customer.User user15 = new Web.DAL.customer.User().Read(UserID);
                        string str43 = Web.UI.customer.User.ViewChartOnWeightApp(user15.sex, user15.userstoresid, user15.userid);
                        if (str43.Length <= 0)
                        {
                            base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "无配置数据", "", ""));
                            break;
                        }
                        base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "", str43, ""));
                        break;
                    }
                case "news":
                    {
                        string classid = Fetch.getpost("classid");
                        if (fun.pnumeric(classid))
                        {
                            bool isp = false;
                            Web.DAL.Sys.Category cDAL = new Web.DAL.Sys.Category();
                            Web.Model.Sys.Category cModel = cDAL.Read(classid);
                            //如果为0
                            string cate = "";
                            if (cModel.parentid.Equals("0"))
                            {
                                isp = true;
                                DataTable dt = cDAL.ReadList("1", cModel.classid);
                                cate = Web.UI.APP.ToJson(dt, false);
                                dt.Dispose();
                            }

                            string Page = Fetch.getpost("Page");
                            if (!fun.pnumeric(Page))
                            {
                                Page = "1";
                            }
                            DataTable table9 = new Web.DAL.Sys.News().ReadListApp("0", classid, Page);
                            if (table9.Rows.Count > 0)
                            {
                                string str = "";
                                if (cate.Length > 0)
                                {
                                    str = Web.UI.APP.ToJson(table9, false) + ",\"cate\":" + cate;
                                }
                                else
                                {
                                    str = Web.UI.APP.ToJson(table9, false) + ",\"cate\":[]";
                                }
                                base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "", str, ""));
                            }
                            else
                            {
                                base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "已经没有更多资讯了", "", ""));
                            }
                            table9.Dispose();
                        }
                        break;
                    }
                case "catenews":
                case "activity":
                    {
                        string str46 = Fetch.getpost("id");
                        if (!fun.pnumeric(str46))
                        {
                            string str47 = Fetch.getpost("num");
                            Web.Model.customer.User user16 = new Web.Model.customer.User();
                            user16 = new Web.DAL.customer.User().Read(UserID);
                            DataTable table11 = new DataTable();
                            if (fun.pnumeric(str47))
                            {
                                Web.DAL.Sys.News news5 = new Web.DAL.Sys.News();
                                Web.DAL.Sys.stores stores3 = new Web.DAL.Sys.stores();
                                Web.Model.Sys.stores stores4 = new Web.Model.Sys.stores();
                                if (fun.pnumeric(user16.userstoresid))
                                {
                                    stores4 = stores3.Read(user16.userstoresid);
                                }
                                table11 = news5.ReadListApp(user16.userstoresid, stores4.Province, "2", int.Parse(str47));
                            }
                            else
                            {
                                string str48 = Fetch.getpost("Page");
                                if (!fun.pnumeric(str48))
                                {
                                    str48 = "1";
                                }
                                table11 = new Web.DAL.Sys.News().ReadListApp(user16.userstoresid, "2", str48);
                            }
                            if (table11.Rows.Count > 0)
                            {
                                base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "", Web.UI.APP.ToJson(table11, false), ""));
                            }
                            else
                            {
                                base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "已经没有更多资讯了", "[]", ""));
                            }
                            table11.Dispose();
                            break;
                        }
                        DataTable table10 = new Web.DAL.Sys.News().Read_DataTable(str46);
                        if (table10.Rows.Count <= 0)
                        {
                            base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "未找到", "{}", ""));
                        }
                        else
                        {
                            table10.Rows[0]["content"] = Base.Fun.fun.Replace(table10.Rows[0]["content"].ToString(), "/UpLoadFile/", "http://112.126.81.86/UpLoadFile/");
                            DataColumn column = new DataColumn
                            {
                                ColumnName = "url"
                            };
                            table10.Columns.Add(column);
                            table10.Rows[0]["url"] = "http://erp.jiayouernv.com/news/?id=" + table10.Rows[0]["id"].ToString();
                            ///更新人气
                            new Web.DAL.Sys.News().UpdateHits(str46);
                            base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "", Web.UI.APP.ToJson(table10, true), ""));
                        }
                        table10.Dispose();
                        break;
                    }
                case "upface":
                    {
                        string userface = "";
                        foreach (string str50 in base.Request.Files)
                        {
                            HttpPostedFile file = base.Request.Files[str50];
                            string str51 = base.Server.MapPath("~");
                            string str52 = Base.UpFiles.UpFiles.FileUploadPath("/UpFile/", Base.IO.File.FileExt(file.FileName));
                            Base.IO.Dir.CheckDir(Base.IO.Dir.ReMoveFileName(str51 + str52));
                            file.SaveAs(str51 + str52);
                            userface = str52;
                            new Web.DAL.customer.User().Update_UserFace(UserID, userface);
                        }
                        if (userface.Length > 0)
                        {
                            base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "", "{\"userfaceurl\":\"" + userface + "\"}", ""));
                        }
                        else
                        {
                            base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "上传失败", "", ""));
                        }
                        break;
                    }
                case "addmess":
                    {
                        string str53 = Fetch.post("content");
                        if (str53.Length > 0)
                        {
                            Web.Model.Sys.Message mModel = new Web.Model.Sys.Message
                            {
                                userid = UserID,
                                addtime = DateTime.Now.ToString(),
                                state = "0",
                                content = str53
                            };
                            Web.DAL.Sys.Message message2 = new Web.DAL.Sys.Message();
                            if (!fun.pnumeric(message2.Insert(mModel)))
                            {
                                base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "反馈失败", "", ""));
                                break;
                            }
                            base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "反馈成功", "", ""));
                        }
                        break;
                    }
                case "messlist":
                    {
                        string str54 = Fetch.getpost("Page");
                        if (!fun.pnumeric(str54))
                        {
                            str54 = "1";
                        }
                        DataTable table12 = new Web.DAL.Sys.Message().Read_AppList(UserID, str54);
                        if (table12.Rows.Count > 0)
                        {
                            base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "", Web.UI.APP.ToJson(table12, false), ""));
                        }
                        else
                        {
                            base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "已经没有更多反馈信息了", "[]", ""));
                        }
                        table12.Dispose();
                        break;
                    }
                case "version":
                    {
                        Web.Model.customer.User user20 = new Web.DAL.customer.User().Read(UserID);
                        Web.Model.Sys.News news8 = new Web.DAL.Sys.News().Read("3", user20.Model);
                        if (!fun.pnumeric(news8.id))
                        {
                            base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "已为最新版本。", "", ""));
                            break;
                        }
                        base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "", "{\"ver\":\"" + news8.tag + "\",\"verstr\":\"" + news8.title + "\",\"url\":\"" + news8.fileurl + "\",\"content\":\"" + JScript.htmltojavascriptNoD(news8.content) + "\"}", ""));
                        break;
                    }
                case "notice":
                    {
                        string str55 = Fetch.getpost("Page");
                        if (!fun.pnumeric(str55))
                        {
                            str55 = "1";
                        }
                        Web.DAL.Mobile.MessageLog log4 = new Web.DAL.Mobile.MessageLog();
                        Web.Model.customer.User user22 = new Web.DAL.customer.User().Read(UserID);
                        DataTable table13 = log4.ReadList(user22.Client, str55);
                        if (table13.Rows.Count > 0)
                        {
                            base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "", Web.UI.APP.ToJson(table13, false), ""));
                        }
                        else
                        {
                            base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "没有通知信息", "[]", ""));
                        }
                        table13.Dispose();
                        break;
                    }
                case "photoupload":
                    {
                        string str56 = "";
                        foreach (string str57 in base.Request.Files)
                        {
                            HttpPostedFile file2 = base.Request.Files[str57];
                            string path = base.Server.MapPath("~");
                            string url = Base.UpFiles.UpFiles.FileUploadPath("/UpFile/", Base.IO.File.FileExt(file2.FileName));
                            Base.IO.Dir.CheckDir(Base.IO.Dir.ReMoveFileName(path + url));
                            file2.SaveAs(path + url);
                            string str60 = url;
                            int[] numArray = picfun.picfun.FileWidthHeight(path + url);
                            string str61 = numArray[0].ToString();
                            string str62 = numArray[1].ToString();
                            str60 = picfun.GetSrc.HtmlSrcUrl(path, url, str61, str62, "CEN", true);
                            Web.DAL.baby.album album8 = new Web.DAL.baby.album();
                            Web.Model.baby.album aModel = new Web.Model.baby.album
                            {
                                addtime = DateTime.Now.ToString(),
                                hits = "0",
                                monthage = Web.UI.customer.User.GetMonthday(UserID),
                                picmd5 = "",
                                picurl = str60,
                                Praise = "0",
                                UserID = UserID
                            };
                            str56 = album8.Insert(aModel);
                        }
                        if (str56.Length > 0)
                        {
                            base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "上传照片成功", "", ""));
                        }
                        else
                        {
                            base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "上传失败", "", ""));
                        }
                        break;
                    }
                case "cardstop":
                    {
                        Web.Model.customer.User user24 = new Web.DAL.customer.User().Read(UserID);
                        if (!fun.pnumeric(user24.cardid))
                        {
                            base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "", "", ""));
                            break;
                        }
                        Web.DAL.customer.Card card3 = new Web.DAL.customer.Card();
                        Web.Model.customer.Card card4 = card3.Read(user24.cardid);
                        if (!card4.cardstatus.Equals("1"))
                        {
                            base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "", "", ""));
                            break;
                        }
                        Web.DAL.customer.CardLog log5 = new Web.DAL.customer.CardLog();
                        if (int.Parse(log5.View_Num(user24.cardid, "4")) >= allstopcardnum)
                        {
                            base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "停卡次数已超" + allstopcardnum.ToString() + "次", "", ""));
                            break;
                        }
                        string stoptime = DateTime.Now.ToString("yyyy-MM-dd");
                        if (card3.Update_StopCard(user24.cardid, stoptime, card4.endtime) <= 0)
                        {
                            base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "", "", ""));
                            break;
                        }
                        Web.Model.customer.CardLog clModel = new Web.Model.customer.CardLog
                        {
                            storesid = user24.userstoresid,
                            cardid = user24.cardid,
                            cardlogtype = "4",
                            opentime = stoptime
                        };
                        Web.UI.customer.CardLog.AppAddCardLog(clModel);
                        base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "停卡成功，你可随时开卡", "", ""));
                        break;
                    }
                case "cardopen":
                    {
                        Web.Model.customer.User user26 = new Web.DAL.customer.User().Read(UserID);
                        if (!fun.pnumeric(user26.cardid))
                        {
                            base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "", "", ""));
                            break;
                        }
                        Web.DAL.customer.Card card5 = new Web.DAL.customer.Card();
                        Web.Model.customer.Card card6 = card5.Read(user26.cardid);
                        if (!card6.cardstatus.Equals("-1"))
                        {
                            base.Response.Write(Web.UI.APP.GetJosn("0", UserID, "", "", "", "", ""));
                            break;
                        }
                        string str64 = card5.Update_Open(card6.cardid, card6.stoptime, card6.endtime);
                        Web.Model.customer.CardLog log7 = new Web.Model.customer.CardLog
                        {
                            storesid = user26.userstoresid,
                            cardid = user26.cardid,
                            cardlogtype = "5",
                            oldendtime = card6.endtime,
                            newendtime = str64,
                            opentime = DateTime.Now.ToString("yyyy-MM-dd")
                        };
                        Web.UI.customer.CardLog.AppAddCardLog(log7);
                        base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "开卡成功", "", ""));
                        break;
                    }
                case "cate":
                    {
                        string classid = Base.Fun.Fetch.getpost("classid");
                        if (Base.Fun.fun.pnumeric(classid))
                        {
                            string page = Fetch.getpost("Page");
                            if (!fun.pnumeric(page))
                            {
                                page = "1";
                            }
                            Web.DAL.customer.User uDAL = new Web.DAL.customer.User();
                            int days = Base.Time.Time.TimeBad(uModel.birthday, DateTime.Now.ToString(), "天");
                            DataTable dt1 = new Web.DAL.Sys.News().ReadListApp("", classid, days, page);
                            string str = Web.UI.APP.ToJson(dt1, false);
                            dt1.Dispose();
                            Web.DAL.Sys.Category cDAL = new Web.DAL.Sys.Category();
                            dt1 = cDAL.ReadList("1", classid);
                            str += ",\"cate\":" + Web.UI.APP.ToJson(dt1, false);
                            dt1.Dispose();
                            base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "成功", str, ""));
                        }
                        else
                        {
                            Web.DAL.Sys.Category cDAL = new Web.DAL.Sys.Category();
                            DataTable dt = cDAL.ReadList("1", "0");
                            base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "成功", Web.UI.APP.ToJson(dt, false), ""));
                            dt.Dispose();
                        }
                        break;
                    }
                case "catelist":
                    {
                        string classid = Base.Fun.Fetch.getpost("classid");
                        if (Base.Fun.fun.pnumeric(classid))
                        {
                            string str = "";
                            int month = int.Parse(Web.UI.customer.User.GetMonthday(UserID));
                            if (classid == "8")
                            {
                                /*0-1岁的宝宝最适合开始认知的培养；轻柔的舒缓音乐会使宝宝更感兴趣！
1-2岁的宝宝最适合开始建立音乐感受；欢快的交响音乐会使宝宝更快乐！
2-3岁的宝宝最适合开始情商的培养；柔美的古典音乐会使宝宝更加活泼开朗！

4-5岁的宝宝最适合开始陶冶性情；无论是舒缓的钢琴曲还是柔美的古典乐都是不错的选择！
5-6岁的宝宝最适合开始兴趣的培养；这时候，可试着给宝宝听各种音乐，启发音乐才智！*/
                                if (month >= 5 * 12)
                                {
                                    str += ",\"catemess\":\"5-6岁的宝宝最适合开始兴趣的培养；这时候，可试着给宝宝听各种音乐，启发音乐才智！\"";
                                }
                                else if (month >= 4 * 12 && month < 5 * 12)
                                {
                                    str += ",\"catemess\":\"4-5岁的宝宝最适合开始陶冶性情；无论是舒缓的钢琴曲还是柔美的古典乐都是不错的选择！\"";
                                }
                                else if (month >= 3* 12 && month < 4 * 12)
                                {
                                    str += ",\"catemess\":\"3-4岁的宝宝最适合开始IQ的培养；豪放的现代乐曲会使带宝宝更聪明！\"";
                                }
                                else if (month >= 2 * 12 && month < 3 * 12)
                                {
                                    str += ",\"catemess\":\"2-3岁的宝宝最适合开始情商的培养；柔美的古典音乐会使宝宝更加活泼开朗！\"";
                                }
                                else if (month >= 1 * 12 && month < 2 * 12)
                                {
                                    str += ",\"catemess\":\"1-2岁的宝宝最适合开始建立音乐感受；欢快的交响音乐会使宝宝更快乐！\"";
                                }
                                else
                                {
                                    str += ",\"catemess\":\"0-1岁的宝宝最适合开始认知的培养；轻柔的舒缓音乐会使宝宝更感兴趣！\"";
                                }
                            }
                            else if (classid == "9")
                            {
                                /*0-1岁已经可以初步认知世界了，快给我讲一些小动物们的童话故事吧！
1-2岁喜欢色彩丰富的图书，买些内容浅显、色彩明亮的故事书给我读读吧！
2-3岁孔融让梨的故事我能听懂了呢，麻麻要多培养我的品德哟！
3-4岁是爱运动的小宝宝，帮我讲些兔子跳跳的故事嘛！
4-5岁大人们能分出的善恶好坏我都明白了，哲理小故事我很喜爱呢。
5-6岁探索新奇是我的最爱，讲讲旅行记小故事会让我非常高兴呢。
6岁以上能独立自主啦！让我自己去挑选故事书吧，请你不要干涉我哦！*/
                                if (month >= 6 * 12)
                                {
                                    str += ",\"catemess\":\"6岁以上能独立自主啦！让我自己去挑选故事书吧，请你不要干涉我哦！\"";
                                }else if (month >= 5 * 12 && month < 6 * 12)
                                {
                                    str += ",\"catemess\":\"5-6岁探索新奇是我的最爱，讲讲旅行记小故事会让我非常高兴呢。\"";
                                }
                                else if (month >= 4 * 12 && month < 5 * 12)
                                {
                                    str += ",\"catemess\":\"4-5岁大人们能分出的善恶好坏我都明白了，哲理小故事我很喜爱呢。\"";
                                }
                                else if (month >= 3 * 12 && month < 4 * 12)
                                {
                                    str += ",\"catemess\":\"3-4岁是爱运动的小宝宝，帮我讲些兔子跳跳的故事嘛！\"";
                                }
                                else if (month >= 2 * 12 && month < 3 * 12)
                                {
                                    str += ",\"catemess\":\"2-3岁孔融让梨的故事我能听懂了呢，麻麻要多培养我的品德哟！\"";
                                }
                                else if (month >= 1 * 12 && month < 2 * 12)
                                {
                                    str += ",\"catemess\":\"1-2岁喜欢色彩丰富的图书，买些内容浅显、色彩明亮的故事书给我读读吧！\"";
                                }
                                else
                                {
                                    str += ",\"catemess\":\"0-1岁已经可以初步认知世界了，快给我讲一些小动物们的童话故事吧！\"";
                                }
                            }
                            Web.DAL.Sys.Category cDAL = new Web.DAL.Sys.Category();
                            DataTable dt1 = cDAL.ReadList("1", classid);
                            str = Web.UI.APP.ToJson(dt1, false)+str;
                            dt1.Dispose();
                            base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "成功", str, ""));
                        }
                        break;
                    }
                case "outletslist":
                    {
                        Web.DAL.Sys.stores sDAL = new Web.DAL.Sys.stores();
                        List<Web.Model.Sys.stores> sList = sDAL.ReadList();
                        StringBuilder str = new StringBuilder();
                        str.Append("[");
                        foreach (Web.Model.Sys.stores s in sList)
                        {
                            if (s.Isoutlets.Equals("1") && s.IsCross.Equals("1"))
                            {
                                str.Append("{\"storesid\":\"" + s.storesid + "\",\"storesname\":\"" + s.title + "\",\"tel\":\"" + s.tel + "\"},");
                            }
                        }
                        str.Append("]");
                        base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "成功", str.ToString().Replace("},]", "}]"), ""));
                        break;
                    }
                case "updateuserstores":
                    {
                        string storesid = Base.Fun.Fetch.getpost("storesid");
                        if (Base.Fun.fun.pnumeric(storesid))
                        {
                            if (Web.UI.Sys.stores.ReadOutlets(storesid))
                            {
                                Web.DAL.customer.User uDAL = new Web.DAL.customer.User();
                                if (uDAL.SetUserStoresid(UserID, storesid))
                                {
                                    base.Response.Write(Web.UI.APP.GetJosn("1", UserID, "", "", "店面切换成功", "", ""));
                                }
                            }
                        }
                        break;
                    }
            }
        }
        base.Response.End();
    }
}