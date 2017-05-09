using System;
using System.Web;
using System.Collections.Generic;
using System.Text;
namespace Web.UI.Mobile
{
    /// <summary>
    /// 发送日志
    /// </summary>
    public class MessageLog
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="mobile"></param>
        /// <param name="title"></param>
        /// <param name="statustime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public static string View(string storesid, string mobile, string title, string statustime, string endtime)
        {
            DAL.Mobile.MessageLog mlDAL = new DAL.Mobile.MessageLog();
            return mlDAL.View(UI.Sys.SiteInfo.GetPageSize(), storesid, mobile, title, statustime, endtime);
        }
        /// <summary>
        /// 预约成功发送
        /// </summary>
        /// <param name="uModel"></param>
        /// <param name="uaModel"></param>
        /// <param name="IsApp">APP立即发送</param>
        public static void SendOk(Model.customer.User uModel, Model.customer.Userappointment uaModel, bool IsApp)
        {
            string SendTime = DateTime.Parse(uaModel.datetime).AddDays(-1).ToString("yyyy-MM-dd") + " 18:00:00";
            if (IsApp)
            {
                SendMobile(uModel.userstoresid, uModel.mobile, "预约成功", uModel.name + "宝宝家长，您已经成功预约《"+UI.Sys.stores.GetStoresName(uaModel.storesid)+"》" + DateTime.Parse(uaModel.datetime).ToString("yyyy年MM月dd日") + (int.Parse(uaModel.datetimehouer) <= 12 ? "上午" : "下午") + "" + uaModel.datetimehouer + "点" + uaModel.datetimeminute + "分的水育课，请您带上浴巾、衣服、水杯、点心等，我们期待您的到来。", SendTime,"0");
                SendMobile(uModel.userstoresid, uModel.mobile, "预约成功", uModel.name + "宝宝家长，您已经成功预约" + DateTime.Parse(uaModel.datetime).ToString("yyyy年MM月dd日") + (int.Parse(uaModel.datetimehouer) <= 12 ? "上午" : "下午") + "" + uaModel.datetimehouer + "点" + uaModel.datetimeminute + "分的水育课，请您安排好自己的时间，老师期待您的到来哦！","", "1");
            }
            else
            {
                SendMobile(uModel.userstoresid, uModel.mobile, "预约成功", uModel.name + "宝宝家长，您已经成功预约" + DateTime.Parse(uaModel.datetime).ToString("yyyy年MM月dd日") + (int.Parse(uaModel.datetimehouer) <= 12 ? "上午" : "下午") + "" + uaModel.datetimehouer + "点" + uaModel.datetimeminute + "分的水育课，请您安排好自己的时间，老师期待您的到来哦！", SendTime, "2");
            }
        }
        /// <summary>
        /// 预约成功发送
        /// </summary>
        /// <param name="uModel"></param>
        /// <param name="datetime"></param>
        /// <param name="SendType">0为手机1为app2为全部</param>
        public static void SendBirthOk(Model.customer.User uModel,string datetime,string SendType)
        {
            DateTime dt = DateTime.Parse(datetime);
            string SendTime = dt.AddDays(-5).ToString("yyyy-MM-dd") + " 09:00:00";
            SendMobile(uModel.userstoresid, uModel.mobile, "生日提醒", "宝宝家长您好，" + dt.ToString("MM月dd日") + "是" + uModel.name + "宝宝的生日哦，" + Base.Fun.fun.getapp("comkeyname") + "全体员工祝宝宝生日快乐，茁壮成长！", SendTime, SendType);
        }
        /// <summary>
        /// 预约成功发送
        /// </summary>
        /// <param name="uModel"></param>
        /// <param name="datetime"></param>
        /// <param name="SendType">0为手机1为app2为全部</param>
        public static void SendCardOk(Model.customer.User uModel,string datetime,string SendType)
        {
            DateTime dt=DateTime.Parse(datetime);
            string SendTime = dt.AddDays(-30).ToString("yyyy-MM-dd") + " 09:00:00";
            SendMobile(uModel.userstoresid, uModel.mobile, "充值提醒", "宝宝家长您好，您在" + Base.Fun.fun.getapp("comkeyname") + "办理的会员卡将于" + dt.ToString("yyyy年MM月dd日") + "到期，有效期还有" + Base.Time.Time.TimeBad(DateTime.Now.ToString(), datetime, "天") + "天，非常感谢您对我们的支持与配合！", SendTime, SendType);
        }
        /// <summary>
        /// 预约发送的撤销
        /// </summary>
        /// <param name="uModel"></param>
        /// <param name="uaModel"></param>
        public static void SendCancel(Model.customer.User uModel, string datetime)
        {
            Web.DAL.Mobile.MessageLog mlDAL = new DAL.Mobile.MessageLog();
            string SendTime = DateTime.Parse(datetime).AddDays(-1).ToString("yyyy-MM-dd") + " 18:00:00";
            mlDAL.Delete(uModel.mobile, SendTime);
            if (uModel.Client.Length > 0)
            {
                mlDAL.Delete(uModel.Client, SendTime);
            }
        }
        /// <summary>
        /// 预约发送的撤销
        /// </summary>
        /// <param name="uModel"></param>
        /// <param name="uaModel"></param>
        public static void SendCancel(Model.customer.User uModel, DateTime datetime, string timestr)
        {
            Web.DAL.Mobile.MessageLog mlDAL = new DAL.Mobile.MessageLog();
            string SendTime = datetime.ToString("yyyy-MM-dd") + " " + timestr + ":00:00";
            mlDAL.Delete(uModel.mobile, SendTime);
            if (uModel.Client.Length > 0)
            {
                mlDAL.Delete(uModel.Client, SendTime);
            }
        }
        /// <summary>
        /// 获得指定日期是否有发送日志
        /// </summary>
        /// <param name="uModel"></param>
        /// <param name="uaModel"></param>
        public static string SelectID(Model.customer.User uModel, string datetime)
        {
            Web.DAL.Mobile.MessageLog mlDAL = new DAL.Mobile.MessageLog();
            string SendTime = DateTime.Parse(datetime).AddDays(-1).ToString("yyyy-MM-dd") + " 18:00:00";
            string ID = mlDAL.SelectID(uModel.mobile, SendTime);
            if (uModel.Client.Length > 0 && !Base.Fun.fun.pnumeric(ID))
            {
                ID = mlDAL.SelectID(uModel.Client, SendTime);
            }
            return ID;
        }
        /// <summary>
        /// 获得指定日期是否有发送日志
        /// </summary>
        /// <param name="uModel"></param>
        /// <param name="uaModel"></param>
        public static string SelectID(Model.customer.User uModel, DateTime datetime, string timestr)
        {
            Web.DAL.Mobile.MessageLog mlDAL = new DAL.Mobile.MessageLog();
            string SendTime = datetime.ToString("yyyy-MM-dd") + " " + timestr + ":00:00";
            string ID = mlDAL.SelectID(uModel.mobile, SendTime);
            if (uModel.Client.Length > 0 && !Base.Fun.fun.pnumeric(ID))
            {
                ID = mlDAL.SelectIDNoStatus(uModel.Client, SendTime);
            }
            return ID;
        }
        /// <summary>
        /// 获得指定日期是否有发送日志
        /// </summary>
        /// <param name="uModel"></param>
        /// <param name="uaModel"></param>
        public static string SelectIDOnApp(Model.customer.User uModel, DateTime datetime, string timestr)
        {
            Web.DAL.Mobile.MessageLog mlDAL = new DAL.Mobile.MessageLog();
            string SendTime = datetime.ToString("yyyy-MM-dd") + " " + timestr + ":00:00";
            string ID = "";
            if (uModel.Client.Length > 0)
            {
                ID = mlDAL.SelectIDNoStatus(uModel.Client, SendTime);
            }
            return ID;
        }
        /// <summary>
        /// 条件发送
        /// </summary>
        public static string SendMobileFor(string storesid, string title, string Content, string sendtime, string sendtype, string UserConsumptionTime, string CardNum, string CardEndTime, string CardType, string CardState, string yueling1, string yueling2)
        {
            StringBuilder str = new StringBuilder();
            DAL.customer.User uDAL = new DAL.customer.User();
            List<Model.customer.User> uList = uDAL.Read_SendMobileApp(storesid, UserConsumptionTime, CardNum, CardEndTime, CardType, CardState, yueling1, yueling2);
            int icount = uList.Count;
            DAL.Mobile.MessageLog mlDAL = new DAL.Mobile.MessageLog();
            List<Model.Mobile.MessageLog> mlList = new List<Model.Mobile.MessageLog>();
            Model.Mobile.MessageLog mlModel = new Model.Mobile.MessageLog();
            mlModel.storesid = storesid;
            mlModel.status = "0";
            mlModel.title = title;
            if (sendtime.Length > 0 && Base.Fun.fun.IsDate(sendtime))
            {
                mlModel.sendtime = sendtime;
                str.Append("队列发送记录：<b>" + icount + "</b>个<br/>");
            }
            else
            {
                mlModel.sendtime = "";
                str.Append("条件发送记录：<b>" + icount + "</b>个<br/>");
            }
            mlModel.addtime = DateTime.Now.ToString();
            mlModel.content = Content;
            int mobilecount = 0;
            int appcount = 0;
            foreach(Model.customer.User u in uList)
            {
                if (sendtype.Equals("0") || sendtype.Equals("2"))
                {
                    mlModel.mobile = u.mobile;
                    mlModel.sendtype = "0";
                    mlModel.id = mlDAL.Insert(mlModel);
                    mobilecount++;
                    if (mlModel.sendtype.Length == 0)
                    {
                        mlList.Add(mlModel);
                    }
                }
                if (sendtype.Equals("1") || sendtype.Equals("2"))
                {
                    if (u.Client.Length > 0)
                    {
                        mlModel.mobile = u.Client;
                        mlModel.sendtype = "1";
                        mlModel.id = mlDAL.Insert(mlModel);
                        appcount++;
                        if (mlModel.sendtype.Length == 0)
                        {
                            mlList.Add(mlModel);
                        }
                    }
                }
            }
            if (sendtype.Equals("0") || sendtype.Equals("2"))
            {
                str.Append("手机发送：<b>" + mobilecount.ToString() + "</b>个；<br>");
            }
            if (sendtype.Equals("1") || sendtype.Equals("2"))
            {
                str.Append("App发送：<b>" + appcount.ToString() + "</b>个；<br/>");
            }
            if (mlList.Count > 0)
            {
                foreach (Model.Mobile.MessageLog ml in mlList)
                {
                    SendMessage(ml);
                }
            }
            if (sendtype.Equals("0") || sendtype.Equals("2"))
            {
                str.Append("<br/>剩余短消息：<b>" + Message.GetNum(storesid) + "</b>条[及时发送]");
            }
            return str.ToString();
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="Mobile"></param>
        /// <param name="Content"></param>
        /// <param name="sendtime"></param>
        /// <returns></returns>
        public static void SendMobile()
        {
            DAL.Mobile.MessageLog mlDAL = new DAL.Mobile.MessageLog();
            List<Model.Mobile.MessageLog> mlList = mlDAL.ReadList();
            Dictionary<string,int> storessend=new Dictionary<string,int>();
            foreach (Model.Mobile.MessageLog ml in mlList)
            {
                SendMessage(ml);                
            }
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="Mobile"></param>
        /// <param name="title"></param>
        /// <param name="Content"></param>
        /// <param name="sendtime"></param>
        /// <param name="sendtype">0为手机，1为app，2为全部</param>
        /// <returns></returns>
        public static string SendMobile(string storesid, string Mobile, string title, string Content, string sendtime, string sendtype)
        {
            DAL.Mobile.MessageLog mlDAL = new DAL.Mobile.MessageLog();
            List<Model.Mobile.MessageLog> mlList = new List<Model.Mobile.MessageLog>();
            Model.Mobile.MessageLog mlModel = new Model.Mobile.MessageLog();
            Model.Mobile.MessageLog AppmlModel = new Model.Mobile.MessageLog();
            AppmlModel.storesid = mlModel.storesid = storesid;
            AppmlModel.status = mlModel.status = "0";
            AppmlModel.title = mlModel.title = title;
            if (sendtime.Length > 0 && Base.Fun.fun.IsDate(sendtime))
            {
                AppmlModel.sendtime = mlModel.sendtime = sendtime;
            }
            else
            {
                AppmlModel.sendtime = mlModel.sendtime = "";
            }
            AppmlModel.addtime = mlModel.addtime = DateTime.Now.ToString();
            AppmlModel.content = mlModel.content = Content;
            string[] mobileList = Mobile.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            DAL.customer.User uDAL = new DAL.customer.User();
            string client = "";
            StringBuilder str = new StringBuilder();
            if (mlModel.sendtime.Length > 0)
            {
                if (sendtype.Equals("0") || sendtype.Equals("2"))
                {
                    str.Append("队列发送手机号：<b>" + mobileList.Length + "</b>个<br/>");
                }
                else if (sendtype.Equals("1") || sendtype.Equals("2"))
                {
                    str.Append("队列App发送：<b>" + mobileList.Length + "</b>个<br/>");
                }
            }
            int mobilecount = 0;
            int appcount = 0;
            foreach (string m in mobileList)
            {
                if (sendtype.Equals("0") || sendtype.Equals("2"))
                {
                    mlModel.mobile = m;
                    mlModel.sendtype = "0";
                    mlModel.id = mlDAL.Insert(mlModel);
                    mobilecount++;
                    if (mlModel.sendtime.Length == 0)
                    {
                        mlList.Add(mlModel);
                    }
                }
                if (sendtype.Equals("1") || sendtype.Equals("2"))
                {
                    client = uDAL.ReadOnMobile(storesid, m);
                    if (client.Length > 0)
                    {
                        AppmlModel.mobile = client;
                        AppmlModel.sendtype = "1";
                        AppmlModel.id = mlDAL.Insert(AppmlModel);
                        appcount++;
                        if (AppmlModel.sendtime.Length == 0)
                        {
                            mlList.Add(AppmlModel);
                        }
                    }
                }
            }
            if (sendtype.Equals("0") || sendtype.Equals("2"))
            {
                str.Append("手机发送：<b>" + mobilecount.ToString() + "</b>个；<br>");
            }
            if (sendtype.Equals("1") || sendtype.Equals("2"))
            {
                str.Append("App发送：<b>" + appcount.ToString() + "</b>个；<br/>");
            }
            if (mlList.Count > 0)
            {
                foreach (Model.Mobile.MessageLog ml in mlList)
                {
                    SendMessage(ml);
                }
            }
            if (sendtype.Equals("0") || sendtype.Equals("2"))
            {
                str.Append("<br/>剩余短消息：<b>" + Message.GetNum(storesid) + "</b>条[及时发送]");
            }
            return str.ToString();
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="id"></param>
        public static bool SendMobile(string storesid, string id)
        {
            bool bo = false;
            DAL.Mobile.MessageLog mlDAL = new DAL.Mobile.MessageLog();
            Model.Mobile.MessageLog mlModel = mlDAL.Read(storesid, id);
            if (mlModel.id.Equals(id))
            {
                bo = SendMessage(mlModel);
            }
            return bo;
        }


        /// <summary>
        /// 发送
        /// </summary>
        /// <param name="ml"></param>
        private static bool SendMessage(Model.Mobile.MessageLog ml)
        {
            bool bo = false;
            string mess = "";
            bool isend = false;
            if (ml.sendtype.Equals("0"))
            {
                if (Message.GetNum(ml.storesid) > 0)
                {
                    string zh = Base.Fun.fun.getapp("zh");
                    string mm = Base.Fun.fun.getapp("mm");
                    string ud = Base.Fun.fun.getapp("ud");
                    string comkey = Base.Fun.fun.getapp("comkey");
                    if (zh.Length > 0 && mm.Length > 0)
                    {
                        mess = Base.Web.WebContent.getPage("http://115.28.172.169:8888/sms.aspx", "action=send&userid=" + ud + "&account=" + zh + "&password=" + mm + "&mobile=" + ml.mobile + "&content=" + HttpUtility.UrlEncode("【" + comkey + "】" + ml.content) + "&sendTime=&extno=");
                        bo = mess.IndexOf("status", StringComparison.CurrentCultureIgnoreCase) != -1 ? true : false;
                        mess = Base.Fun.Regxp.ReadRegex(mess, "message", "", false, 1);
                        isend = true;
                        Message.SetNum(ml.storesid);
                    }
                }
                else
                {
                    isend = true;
                    bo = false;
                    mess = "请购买短消息数量";
                }
            }
            else
            {
                string str = Base.Fun.fun.getapp("APIAppKey");
                string str2 = Base.Fun.fun.getapp("APIMasterSecret");
                if ((str.Length > 0) && (str2.Length > 0))
                {
                    string platform = "android,ios,winphone";
                    string client = ml.mobile;
                    if (ml.mobile.Contains("appandroid"))
                    {
                        platform = "android";
                    }
                    else if (ml.mobile.Contains("appios"))
                    {
                        platform = "ios";
                    }
                    client = client.Split('_')[1];
                    StringBuilder builder = new StringBuilder();
                    int receiver_type = 3;
                    string str4 = "1" + Base.Fun.fun.GetGuidRandom(9, "1");
                    string str5 = Base.Fun.Md5.MD5(str4 + receiver_type.ToString() + client + str2).ToUpper();
                    builder.Append("sendno=" + str4 + "&app_key=" + str + "&receiver_type=" + receiver_type.ToString() + "&receiver_value=" + client + "&verification_code=" + str5 + "&msg_type=1&msg_content=" + HttpUtility.UrlEncode("{\"n_content\":\"" +Base.Fun.JScript.htmltojavascriptNoD(ml.content) + "\"" + (ml.title.Length > 0 ? ", \"n_title\":\"" + ml.title + "\"" : "") + ", \"n_extras\":{" + (platform.Contains("ios") ? "\"ios\":{\"sound\":\"happy\"}" : "") + "}}") + "&platform=" + platform);
                    mess = Base.Web.WebContent.getPage("https://api.jpush.cn:443/v2/push", builder.ToString());
                    bo = mess.Contains("Succeed") ? true : false;
                    isend = true;
                }
            }
            if (isend)
            {
                DAL.Mobile.MessageLog mlDAL = new DAL.Mobile.MessageLog();
                mlDAL.Update(ml.storesid, ml.id, bo ? "1" : "-1", mess);
            }
            return bo;
        }
        /// <summary>
        /// 返回余额
        /// </summary>
        /// <returns></returns>
        public static string SmsNum()
        {
            string mess = "";
            string zh = Base.Fun.fun.getapp("zh");
            string mm = Base.Fun.fun.getapp("mm");
            string ud = Base.Fun.fun.getapp("ud");
            if (zh.Length > 0 && mm.Length > 0)
            {
                mess = Base.Web.WebContent.getPage("http://115.28.172.169:8888/sms.aspx", "action=overage&userid=" + ud + "&account=" + zh + "&password=" + mm);
                if (mess.IndexOf("status", StringComparison.CurrentCultureIgnoreCase) != -1)
                {
                    mess = Base.Fun.Regxp.ReadRegex(mess, "overage", "", false, 1);
                }
            }
            return mess;
        }
    }
}
