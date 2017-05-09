using System;
using System.Web;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Web.UI.customer
{
    /// <summary>
    /// 会员
    /// </summary>
    public class User
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="cardNo"></param>
        /// <param name="name"></param>
        /// <param name="communityid"></param>
        /// <param name="mobile"></param>
        /// <param name="nickname"></param>
        /// <param name="cycletype"></param>
        /// <param name="statusmonthnum"></param>
        /// <param name="endmonthnum"></param>
        /// <param name="loginnum"></param>
        /// <param name="startnum"></param>
        /// <param name="endnum"></param>
        /// <returns></returns>
        public static string View(string storesid, string cardNo, string name, string communityid, string mobile, string nickname, string cycletype, string statusmonthnum, string endmonthnum,string statusdaynum,string enddaynum,string statusbirthday,string endbirthday, string loginnum, string startnum, string endnum, string cardtypeid, string cardstatus)
        {
            DAL.customer.User uDAL = new DAL.customer.User();
            return uDAL.View(UI.Sys.SiteInfo.GetPageSize(), storesid, cardNo, name, communityid, mobile, nickname, cycletype, statusmonthnum, endmonthnum, statusdaynum, enddaynum, statusbirthday, endbirthday, loginnum, startnum, endnum, cardtypeid, cardstatus);
        }
        /// <summary>
        /// 潜在客户(所有未办卡用户）
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="storesid"></param>
        /// <param name="name"></param>
        /// <param name="nickname"></param>
        /// <param name="communityid"></param>
        /// <param name="mobile"></param>
        /// <param name="cycletype"></param>
        /// <param name="ReturnresultID"></param>
        /// <param name="statusmonthnum"></param>
        /// <param name="endmonthnum"></param>
        /// <returns></returns>
        public static string View_Potential(string storesid, string name, string nickname, string communityid, string mobile, string cycletype, string ReturnresultID, string statusmonthnum, string endmonthnum)
        {
            DAL.customer.User uDAL = new DAL.customer.User();
            return uDAL.View_Potential(UI.Sys.SiteInfo.GetPageSize(), storesid, name, nickname, communityid, mobile, cycletype, ReturnresultID, statusmonthnum, endmonthnum);
        }
        /// <summary>
        /// 咨询未到店
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public static string View_consult(string storesid, string starttime, string endtime)
        {
            DAL.customer.User uDAL = new DAL.customer.User();
            return uDAL.View_consult(UI.Sys.SiteInfo.GetPageSize(), storesid, starttime, endtime);
        }
        /// <summary>
        /// 咨询未办卡
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="storesid"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public static string View_consultNoCard(string storesid, string starttime, string endtime)
        {
            DAL.customer.User uDAL = new DAL.customer.User();
            return uDAL.View_consultNoCard(UI.Sys.SiteInfo.GetPageSize(), storesid, starttime, endtime);
        }
        /// <summary>
        /// 会员卡过期客户
        /// </summary>
        /// <returns></returns>
        public static string View_expired(string storesid, string statusendtime, string endtime)
        {
            DAL.customer.User uDAL = new DAL.customer.User();
            return uDAL.View_expired(UI.Sys.SiteInfo.GetPageSize(), storesid, statusendtime, endtime);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="userid"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetBanner(string storesid, string userid, string url)
        {
            StringBuilder str = new StringBuilder();
            if (Base.Fun.fun.pnumeric(userid))
            {
                DAL.customer.User uDAL = new DAL.customer.User();
                Model.customer.User uModel = uDAL.Read(storesid, userid);
                str.Append("&nbsp;&nbsp;&nbsp;【" + uModel.name + "&nbsp;&nbsp;" + uModel.nickname + "】&nbsp;&nbsp;&nbsp;<div style=\"float:right;\"><a href=\"\" onclick=\"AjaxFun('" + url + "','action=view','正在调入...','.Rnr');return false;\">返回全部</a></div>");
            }
            return str.ToString();
        }
        /// <summary>
        /// 读取月龄
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static string GetMonthday(string userid)
        {
            DAL.customer.User uDAL = new DAL.customer.User();
            return uDAL.Read_MonthAge(userid);
        }
        /// <summary>
        /// 读取婴儿类型
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static string Getcycletype(string userid)
        {
            DAL.customer.User uDAL = new DAL.customer.User();
            return uDAL.Read_cycletype(userid);
        }
        /// <summary>
        /// 读取用户信息及卡信息（修改过了。根本）
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static Model.customer.User Read(string storesid, string userid)
        {
            Model.customer.User uModel = new Model.customer.User();
            DAL.customer.User uDAL = new DAL.customer.User();
            if (Sys.stores.ReadOutlets(storesid))
            {
                uModel = uDAL.Read_Outlets(userid);
            }
            else
            {
                uModel = uDAL.Read(storesid, userid);
            }
            if (uModel.userid.Equals(userid))
            {
                if (Base.Fun.fun.pnumeric(uModel.cardid))
                {
                    DAL.customer.Card cDAL = new DAL.customer.Card();
                    uModel.cModel = cDAL.Read(uModel.cardid);
                    if (Base.Fun.fun.pnumeric(uModel.cModel.cardtypeid))
                    {
                        DAL.customer.CardType ctDAL = new DAL.customer.CardType();
                        uModel.cModel.ctModel = ctDAL.Read(uModel.cModel.cardtypeid);
                    }
                }
            }
            return uModel;
        }
        /// <summary>
        /// 显示(身高）
        /// </summary>
        /// <returns></returns>
        public static string ViewChartOnHeight(string sex, string storesid, string userid)
        {
            StringBuilder strXml = new StringBuilder();
            StringBuilder Dstr = new StringBuilder();
            StringBuilder str1 = new StringBuilder();
            StringBuilder str2 = new StringBuilder();
            StringBuilder str3 = new StringBuilder();
            DAL.baby.height hDAL = new DAL.baby.height();
            List<Model.baby.height> hList = hDAL.ReadList();
            DAL.customer.UserConsumption ucDAL=new DAL.customer.UserConsumption();
            List<Model.customer.UserConsumption> ucList = ucDAL.Read_List_UserIdOnheight(storesid, userid);

            if (hList.Count > 0)
            {
                str1.Append("<dataset seriesName='最小值' color='1D8BD1' anchorBorderColor='1D8BD1' anchorBgColor='1D8BD1'>");
                str2.Append("<dataset seriesName='最大值' color='F1683C' anchorBorderColor='F1683C' anchorBgColor='F1683C'>");
                str3.Append("<dataset seriesName='身高' color='FFFF00' anchorBorderColor='FFFF00' anchorBgColor='FFFF00'>");
                Dstr.Append("<categories>");
                double height = 0;
                int icount = 0;
                double minnum = 1000000;
                double maxnum = 0;
                foreach (Model.baby.height h in hList)
                {
                    if (h.sex.Equals(sex))
                    {
                        height = 0;
                        List<Model.customer.UserConsumption> ucModelList = ucList.FindAll(delegate(Model.customer.UserConsumption uc) { return uc.monthage.Equals(h.monthage); });
                        if (ucModelList.Count > 0)
                        {
                            icount += ucModelList.Count;
                            foreach (Model.customer.UserConsumption uc in ucModelList)
                            {
                                height += double.Parse(uc.height);
                            }
                            height = Math.Round(height / ucModelList.Count, 2);
                        }
                        Dstr.Append("<category name='" + h.monthage + "月' />");
                        str1.Append("<set value='" + h.minnum + "'/>");
                        str2.Append("<set value='" + h.maxnum + "'/>");
                        str3.Append("<set value='" + height.ToString() + "'/>");
                    }
                    if (height > maxnum)
                    {
                        maxnum = height;
                    }
                    if (double.Parse(h.maxnum) > maxnum)
                    {
                        maxnum = double.Parse(h.maxnum);
                    }
                    if (height != 0 && height < minnum)
                    {
                        minnum = height;
                    }
                    if (double.Parse(h.minnum) < minnum)
                    {
                        minnum = double.Parse(h.minnum);
                    }
                    if (icount >= ucList.Count)
                    {
                        break;
                    }
                }
                str3.Append("</dataset>");
                str2.Append("</dataset>");
                str1.Append("</dataset>");
                Dstr.Append("</categories>");
                strXml.Append("<graph lineThickness='0' canvasBorderThickness='0' baseFontSize='12' alternateHGridAlpha='5' canvasBorderColor='666666' divLineColor='ff5904' divLineAlpha='20' showAlternateHGridColor='1' AlternateHGridColor='ff5904' hovercapbg='FFECAA' hovercapborder='F47E00' formatNumberScale='0' decimalPrecision='0' decimals='2' numberSuffix='cm' showvalues='0' numdivlines='6' yAxisMinValue='" + minnum.ToString().Split('.')[0] + "' yAxisMaxValue='" + Math.Ceiling(maxnum) + "' numVdivlines='0' rotateNames='1'>");
                strXml.Append(Dstr.ToString() + str1.ToString() + str2.ToString() + str3.ToString().Replace("value='0'", "value='" + minnum.ToString().Split('.')[0] + "'") + "</graph>");
            }
            return strXml.ToString();
        }

        /// <summary>
        /// 显示(身高）
        /// </summary>
        /// <returns></returns>
        public static string ViewChartOnHeightOnApp(string sex, string storesid, string userid)
        {
            StringBuilder strXml = new StringBuilder();
            StringBuilder str = new StringBuilder();
            DAL.baby.height hDAL = new DAL.baby.height();
            List<Model.baby.height> hList = hDAL.ReadList();
            DAL.customer.UserConsumption ucDAL = new DAL.customer.UserConsumption();
            List<Model.customer.UserConsumption> ucList = ucDAL.Read_List_UserIdOnheight(storesid, userid);

            if (hList.Count > 0)
            {
                double height = 0;
                int icount = 0;
                double minnum = 1000000;
                double maxnum = 0;
                foreach (Model.baby.height h in hList)
                {
                    if (h.sex.Equals(sex))
                    {
                        height = 0;
                        List<Model.customer.UserConsumption> ucModelList = ucList.FindAll(delegate(Model.customer.UserConsumption uc) { return uc.monthage.Equals(h.monthage); });
                        if (ucModelList.Count > 0)
                        {
                            icount += ucModelList.Count;
                            foreach (Model.customer.UserConsumption uc in ucModelList)
                            {
                                height += double.Parse(uc.height);
                            }
                            height = Math.Round(height / ucModelList.Count, 2);
                        }
                        str.Append("{\"monthage\":\"" + h.monthage + "\",");
                        str.Append("\"minnum\":\"" + h.minnum + "\",");
                        str.Append("\"maxnum\":\"" + h.maxnum + "\",");
                        str.Append("\"user\":\"" + height.ToString() + "\"},");
                    }
                    if (height > maxnum)
                    {
                        maxnum = height;
                    }
                    if (double.Parse(h.maxnum) > maxnum)
                    {
                        maxnum = double.Parse(h.maxnum);
                    }
                    if (height != 0 && height < minnum)
                    {
                        minnum = height;
                    }
                    if (double.Parse(h.minnum) < minnum)
                    {
                        minnum = double.Parse(h.minnum);
                    }
                    if (icount >= ucList.Count)
                    {
                        break;
                    }
                }
                string month = DateTime.Now.ToString("yyyyMM");
                List<Model.customer.UserConsumption> ucModelListMonth = ucList.FindAll(delegate(Model.customer.UserConsumption uc) { return DateTime.Parse(uc.addtime).ToString("yyyyMM").Equals(DateTime.Now.ToString("yyyyMM")); });
                double growth = 0;
                if (ucModelListMonth.Count >= 2)
                {
                    growth = double.Parse(ucModelListMonth[ucModelListMonth.Count - 1].height) - double.Parse(ucModelListMonth[ucModelListMonth.Count - 2].height);
                }
                int days = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);

                //strXml.Append("[" + str.ToString().Trim(',') + "]");
                strXml.Append("{\"viewgrowth\":\"" + Math.Round(growth, 1).ToString() + "\", \"viewday\":\"" + ucModelListMonth.Count.ToString() + "/" + days.ToString() + "\",\"userdata\":[" + str.ToString().Trim(',') + "]}");
            }
            return strXml.ToString();
        }


        /// <summary>
        /// 显示(体重）
        /// </summary>
        /// <returns></returns>
        public static string ViewChartOnWeight(string sex, string storesid, string userid)
        {
            StringBuilder strXml = new StringBuilder();
            StringBuilder Dstr = new StringBuilder();
            StringBuilder str1 = new StringBuilder();
            StringBuilder str2 = new StringBuilder();
            StringBuilder str3 = new StringBuilder();
            DAL.baby.weight hDAL = new DAL.baby.weight();
            List<Model.baby.weight> hList = hDAL.ReadList();
            DAL.customer.UserConsumption ucDAL = new DAL.customer.UserConsumption();
            List<Model.customer.UserConsumption> ucList = ucDAL.Read_List_UserIdOnweight(storesid, userid);

            if (hList.Count > 0)
            {
                
                str1.Append("<dataset seriesName='最小值' color='1D8BD1' anchorBorderColor='1D8BD1' anchorBgColor='1D8BD1'>");
                str2.Append("<dataset seriesName='最大值' color='F1683C' anchorBorderColor='F1683C' anchorBgColor='F1683C'>");
                str3.Append("<dataset seriesName='会员体重' color='FFFF00' anchorBorderColor='FFFF00' anchorBgColor='FFFF00'>");
                Dstr.Append("<categories>");
                double weight = 0;
                int icount = 0;
                double minnum = 1000000;
                double maxnum = 0;
                foreach (Model.baby.weight w in hList)
                {
                    if (w.sex.Equals(sex))
                    {
                        weight = 0;
                        List<Model.customer.UserConsumption> ucModelList = ucList.FindAll(delegate(Model.customer.UserConsumption uc) { return uc.monthage.Equals(w.monthage); });
                        if (ucModelList.Count > 0)
                        {
                            icount += ucModelList.Count;
                            foreach (Model.customer.UserConsumption uc in ucModelList)
                            {
                                weight += double.Parse(uc.weight);
                            }
                            weight = Math.Round(weight / ucModelList.Count, 2);
                        }
                        Dstr.Append("<category name='" + w.monthage + "月' />");
                        str1.Append("<set value='" + w.minnum + "'/>");
                        str2.Append("<set value='" + w.maxnum + "'/>");
                        str3.Append("<set value='" + weight.ToString() + "'/>");

                        if (weight > maxnum)
                        {
                            maxnum = weight;
                        }
                        if (double.Parse(w.maxnum) > maxnum)
                        {
                            maxnum = double.Parse(w.maxnum);
                        }
                        if (weight != 0 && weight < minnum)
                        {
                            minnum = weight;
                        }
                        if (double.Parse(w.minnum) < minnum)
                        {
                            minnum = double.Parse(w.minnum);
                        }

                        if (icount >= ucList.Count)
                        {
                            break;
                        }
                    }
                }
                str3.Append("</dataset>");
                str2.Append("</dataset>");
                str1.Append("</dataset>");
                Dstr.Append("</categories>");
                strXml.Append("<graph lineThickness='0' canvasBorderThickness='0' baseFontSize='12' alternateHGridAlpha='5' canvasBorderColor='666666' divLineColor='ff5904' divLineAlpha='20' showAlternateHGridColor='1' AlternateHGridColor='ff5904' hovercapbg='FFECAA' hovercapborder='F47E00' formatNumberScale='0' decimalPrecision='0' decimals='2' numberSuffix='kg' showvalues='0' numdivlines='4' yAxisMinValue='" + minnum.ToString().Split('.')[0] + "' yAxisMaxValue='"+Math.Ceiling(maxnum)+"' numVdivlines='0' rotateNames='1'>");
                strXml.Append(Dstr.ToString() + str1.ToString() + str2.ToString() + str3.ToString().Replace("value='0'", "value='" + minnum.ToString().Split('.')[0] + "'") + "</graph>");
            }
            return strXml.ToString();
        }

        /// <summary>
        /// 显示(体重）
        /// </summary>
        /// <returns></returns>
        public static string ViewChartOnWeightApp(string sex, string storesid, string userid)
        {
            StringBuilder strXml = new StringBuilder();
            StringBuilder str = new StringBuilder();
            DAL.baby.weight hDAL = new DAL.baby.weight();
            List<Model.baby.weight> hList = hDAL.ReadList();
            DAL.customer.UserConsumption ucDAL = new DAL.customer.UserConsumption();
            List<Model.customer.UserConsumption> ucList = ucDAL.Read_List_UserIdOnweight(storesid, userid);

            if (hList.Count > 0)
            {
                double weight = 0;
                int icount = 0;
                double minnum = 1000000;
                double maxnum = 0;
                foreach (Model.baby.weight w in hList)
                {
                    if (w.sex.Equals(sex))
                    {
                        weight = 0;
                        List<Model.customer.UserConsumption> ucModelList = ucList.FindAll(delegate(Model.customer.UserConsumption uc) { return uc.monthage.Equals(w.monthage); });
                        if (ucModelList.Count > 0)
                        {
                            icount += ucModelList.Count;
                            foreach (Model.customer.UserConsumption uc in ucModelList)
                            {
                                weight += double.Parse(uc.weight);
                            }
                            weight = Math.Round(weight / ucModelList.Count, 2);
                        }
                        str.Append("{\"monthage\":\"" + w.monthage + "\",");
                        str.Append("\"minnum\":\"" + w.minnum + "\",");
                        str.Append("\"maxnum\":\"" + w.maxnum + "\",");
                        str.Append("\"user\":\"" + weight.ToString() + "\"},");

                        if (weight > maxnum)
                        {
                            maxnum = weight;
                        }
                        if (double.Parse(w.maxnum) > maxnum)
                        {
                            maxnum = double.Parse(w.maxnum);
                        }
                        if (weight != 0 && weight < minnum)
                        {
                            minnum = weight;
                        }
                        if (double.Parse(w.minnum) < minnum)
                        {
                            minnum = double.Parse(w.minnum);
                        }

                        if (icount >= ucList.Count)
                        {
                            break;
                        }
                    }
                }
                string month = DateTime.Now.ToString("yyyyMM");
                List<Model.customer.UserConsumption> ucModelListMonth = ucList.FindAll(delegate(Model.customer.UserConsumption uc) { return DateTime.Parse(uc.addtime).ToString("yyyyMM").Equals(DateTime.Now.ToString("yyyyMM")); });
                double growth = 0;
                if (ucModelListMonth.Count >= 2)
                {
                    growth = double.Parse(ucModelListMonth[ucModelListMonth.Count - 1].weight) - double.Parse(ucModelListMonth[ucModelListMonth.Count - 2].weight);
                }
                int days = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
                strXml.Append("{\"viewgrowth\":\"" + Math.Round(growth, 1).ToString() + "\", \"viewday\":\"" + ucModelListMonth.Count.ToString() + "/" + days.ToString() + "\",\"userdata\":[" + str.ToString().Trim(',') + "]}");
            }
            return strXml.ToString();
        }


        /// <summary>
        /// 登录绑定OPENID
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserPass"></param>
        /// <returns>0为登录成功，-2为登录失败，-1为锁定</returns>
        public static string Login(string UserName, string UserPass, ref string UserID, ref string IsPush, ref string AppID)
        {
            UserID = "";
            string str = "-2";
            int errorNum = 5;
            int error = 0;
            DAL.customer.User uDAL = new DAL.customer.User();
            Model.customer.User uModel = uDAL.ReadOnLogin(UserName);
            if (Base.Fun.fun.pnumeric(uModel.userid))
            {
                if (uModel.userpass.Equals(UserPass))
                {
                    error = int.Parse(uModel.Error);
                    if (error >= errorNum && Base.Fun.fun.IsDate(uModel.ErrorTime) && Base.Time.Time.TimeBad(uModel.ErrorTime, DateTime.Now.ToString(), "时") <= 24)
                    {
                        str = (24 - Base.Time.Time.TimeBad(uModel.ErrorTime, DateTime.Now.ToString(), "时")).ToString();
                    }
                    else
                    {
                        UserID = uModel.userid;
                        IsPush = uModel.IsPush;
                        AppID = uModel.AppID;
                        str = "0";
                    }
                }
                else
                {
                    error = int.Parse(uModel.Error) + 1;
                    if (error < errorNum && Base.Fun.fun.IsDate(uModel.ErrorTime) && Base.Time.Time.TimeBad(uModel.ErrorTime, DateTime.Now.ToString(), "时") >= 6)
                    {
                        error = 1;
                    }
                    if (error > errorNum)
                    {
                        if (Base.Fun.fun.IsDate(uModel.ErrorTime) && Base.Time.Time.TimeBad(uModel.ErrorTime, DateTime.Now.ToString(), "时") <= 24)
                        {
                            str = (24 - Base.Time.Time.TimeBad(uModel.ErrorTime, DateTime.Now.ToString(), "时")).ToString();
                        }
                        else
                        {
                            uDAL.Update_Error(uModel.userid, "1");
                            str = "-2";
                        }
                    }
                    else
                    {
                        uDAL.Update_Error(uModel.userid, error.ToString());
                        str = "-2";
                    }
                }
            }
            return str;
        }

        /// <summary>
        /// 状态
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static Model.customer.User AppPageLoad(string UserID, string token)
        {
            DAL.customer.User uDAL = new DAL.customer.User();
            Model.customer.User uModel = uDAL.Read(UserID);
            if (!uModel.AppID.Equals(token))
            {
                HttpContext.Current.Response.Write(APP.GetJosn("-1", UserID, "", "0", "请登录", "", token));
                HttpContext.Current.Response.End();
            }
            return uModel;
        }
        /// <summary>
        /// 更新最大间隔
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="userid"></param>
        public static void Updatemaxtimenum(string storesid, string userid)
        {
            List<Model.customer.UserConsumption> ucList = new List<Model.customer.UserConsumption>();
            DAL.customer.UserConsumption ucDAL = new DAL.customer.UserConsumption();
            ucList = ucDAL.ReadList(storesid, userid, 2);
            DAL.customer.User uDAL = new DAL.customer.User();
            if (ucList.Count == 2)
            {
                int daynum = Base.Time.Time.TimeBad(ucList[0].addtime, ucList[1].addtime, "天");
                Model.customer.User uModel = uDAL.Read(userid);
                int maxdaynum = int.Parse(Base.Fun.fun.IsZero(uModel.maxtimenum));
                if (daynum > maxdaynum)
                {
                    uDAL.Updatemaxtimenum(userid, daynum.ToString());
                }
                uDAL.Updatelasttime(userid, ucList[0].addtime);
            }
            else if (ucList.Count == 1)
            {
                uDAL.Updatemaxtimenum(userid, "0");
                uDAL.Updatelasttime(userid, ucList[0].addtime);
            }
        }
        /// <summary>
        /// 读取发送
        /// </summary>
        public static void ReadList_StopOpen()
        {
            DAL.customer.Card cDAL = new DAL.customer.Card();
            DAL.customer.User uDAL = new DAL.customer.User();
            List<Model.customer.User> uList = uDAL.ReadList_StopOpen();
            foreach (Model.customer.User u in uList)
            {
                string endtime = cDAL.Update_Open(u.cardid, u.cModel.stoptime, u.cModel.endtime);
                Web.Model.customer.CardLog clModel = new Web.Model.customer.CardLog();
                clModel.storesid = u.storesid;
                clModel.cardid = u.cardid;
                clModel.cardlogtype = "5";
                clModel.oldendtime = u.cModel.endtime;
                clModel.newendtime = endtime;
                clModel.opentime = DateTime.Now.ToString("yyyy-MM-dd");
                Web.UI.customer.CardLog.SysAddCardLog(clModel);
                Web.UI.Mobile.MessageLog.SendMobile(u.userstoresid, u.mobile, "系统开卡", u.name + "宝宝家长，您的会员卡停卡时间已到，现已开通，会员卡具体信息：剩余游泳" + u.cModel.surplusnum + "次；有效期至" + DateTime.Parse(endtime).ToString("yyyy年MM月dd日") + "，祝您生活愉快！", "", "0");
            }
        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="storesid"></param>
        /// <param name="cardNo"></param>
        /// <param name="name"></param>
        /// <param name="communityid"></param>
        /// <param name="mobile"></param>
        /// <param name="nickname"></param>
        /// <param name="cycletype"></param>
        /// <param name="statusmonthnum"></param>
        /// <param name="endmonthnum"></param>
        /// <param name="statusdaynum"></param>
        /// <param name="enddaynum"></param>
        /// <param name="statusbirthday"></param>
        /// <param name="endbirthday"></param>
        /// <param name="loginnum"></param>
        /// <param name="startnum"></param>
        /// <param name="endnum"></param>
        /// <param name="cardtypeid"></param>
        /// <param name="cardstatus"></param>
        public static void ToExcel(string userid, string storesid, string cardNo, string name, string communityid, string mobile, string nickname, string cycletype, string statusmonthnum, string endmonthnum, string statusdaynum, string enddaynum, string statusbirthday, string endbirthday, string loginnum, string startnum, string endnum, string cardtypeid, string cardstatus)
        {
            Web.DAL.customer.User uDAL = new DAL.customer.User();
            DataTable dt = uDAL.ViewToXLS(storesid, cardNo, name, communityid, mobile, nickname, cycletype, statusmonthnum, endmonthnum, statusdaynum, enddaynum, statusbirthday, endbirthday, loginnum, startnum, endnum, cardtypeid, cardstatus);
            if (dt.Rows.Count > 0)
            {
                string FileName = Base.Fun.Management.RealDirectory(Sys.SiteInfo.UpFile + "Files/User_" + userid + ".xls");
                Base.IO.Dir.CheckDir(Base.IO.Dir.ReMoveFileName(FileName));
                Base.Office.ExcelHelper.Export(dt, "会员", FileName);
                System.Web.HttpContext.Current.Response.Write(SyCms.Window.DownFile.DownFileName(FileName, "会员.xls", true));
            }
            dt.Dispose();
        }
    }
}
