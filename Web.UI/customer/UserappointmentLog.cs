using System;
using System.Collections.Generic;
using System.Text;

namespace Web.UI.customer
{
    /// <summary>
    /// 预约
    /// </summary>
    public class UserappointmentLog
    {
        /// <summary>
        /// 返回表头
        /// </summary>
        /// <returns></returns>
        public static string GetHead()
        {
            StringBuilder str = new StringBuilder();
            DateTime dt=DateTime.Now;
            for (int i = 0; i <= 7; i++)
            {
                str.Append("{ display: '" + dt.AddDays(i).ToString("MM-dd") + " " + Base.Fun.fun.WeekValue(dt.AddDays(i)) + "', name: 'week" + i.ToString() + "', width: 120, sortable: false, align: 'center',process:WeekFun},");
            }
            return str.ToString().TrimEnd(',');
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="babytype"></param>
        /// <param name="hoursNum"></param>
        /// <param name="minute"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static void UpdateAll(string storesid, string babytype, string weeknum, string hoursNum, string minute, string num)
        {
            DAL.customer.UserappointmentLog ulDAL = new DAL.customer.UserappointmentLog();
            DateTime dt = DateTime.Now;
            List<Model.customer.UserappointmentLog> ulList = ulDAL.Read(storesid, babytype, dt.AddDays(1).ToString("yyyyMMdd"));
            List<Model.customer.UserappointmentLog> ulModelList = ulList.FindAll(delegate(Model.customer.UserappointmentLog ul) { return ul.weeknum == weeknum && ul.hoursNum == hoursNum && ul.minute == minute; });
            foreach (Model.customer.UserappointmentLog ul in ulModelList)
            {
                ulDAL.Update(storesid, ul.id, num);
            }
        }
        /// <summary>
        /// 读取显示
        /// </summary>
        /// <returns></returns>
        public static string View(string storesid,string babytype)
        {
            DAL.customer.UserappointmentLog ulDAL = new DAL.customer.UserappointmentLog();
            DateTime dt = DateTime.Now;
            List<Model.customer.UserappointmentLog> ulList = ulDAL.Read(storesid, babytype, dt.AddDays(0).ToString("yyyyMMdd"));

            DAL.customer.UserappointmentSetup msDAL = new DAL.customer.UserappointmentSetup();
            List<Model.customer.UserappointmentSetup> usList = msDAL.ReadList(storesid, babytype);
            SortedDictionary<string, string[]> house = new SortedDictionary<string, string[]>();
            Dictionary<string, int> dayNum = new Dictionary<string, int>();
            string strtime = "";
            foreach (Model.customer.UserappointmentSetup us in usList)
            {
                strtime = us.hoursNum.PadLeft(2, '0') + ":" + us.minute.PadLeft(2, '0');
                if (!house.ContainsKey(strtime))
                {
                    house.Add(strtime, new string[] { us.hoursNum, us.minute });
                }
                strtime = us.weeknum + "_" + strtime;
                if (!dayNum.ContainsKey(strtime))
                {
                    dayNum.Add(strtime, int.Parse(us.num));
                }
            }
            StringBuilder str = new StringBuilder();

            str.Append("{");
            str.Append("\"page\":1,");
            str.Append("\"total\":" + house.Count.ToString());
            if (house.Count > 0)
            {
                str.Append(",\"rows\": [");
                int i = 0;
                foreach (string time in house.Keys)
                {
                    i++;
                    List<Model.customer.UserappointmentLog> ulModelList = ulList.FindAll(delegate(Model.customer.UserappointmentLog ul) { return ul.hoursNum == house[time][0] && ul.minute == house[time][1]; });
                    str.Append("{\"id\":\"" + i.ToString() + "\", \"cell\":[");
                    int usi = 0;
                    str.Append("\"" + i.ToString() + "\",");
                    str.Append("\"" + time + "\",");
                    for (int j = 0; j <= 7; j++)
                    {
                        DateTime dtstr = dt.AddDays(j);
                        int weeknum = Base.Fun.fun.Week2Int(dtstr);
                        if (ulModelList.Count > usi && ulModelList[usi].datenum == dtstr.ToString("yyyyMMdd"))
                        {
                            str.Append("\"" + ulModelList[usi].id + "," + ulModelList[usi].num + "," + ulModelList[usi].appusernum + "," + ulModelList[usi].pcusernum + "," + dtstr.ToString("yyyy-MM-dd") + "\",");
                            usi++;
                        }
                        else
                        {
                            strtime = weeknum.ToString() + "_" + time;
                            if (dayNum.ContainsKey(strtime))
                            {
                                str.Append("\"" + weeknum + "," + dayNum[strtime].ToString() + "," + dtstr.ToString("yyyy-MM-dd") + "," + dtstr.ToString("yyyy-MM-dd") + "\",");
                            }
                            else
                            {
                                str.Append("\"\",");
                            }
                        }
                    }
                    str.Remove(str.Length - 1, 1);
                    str.Append("]},");
                }
                str.Remove(str.Length - 1, 1);
                str.Append("]");
            }
            str.Append("}");
            return str.ToString();
        }


        /// <summary>
        /// 读取显示
        /// </summary>
        /// <returns></returns>
        public static string ViewApp(string storesid, string userid, string babytype, DateTime dt)
        {
            DAL.customer.UserappointmentLog ulDAL = new DAL.customer.UserappointmentLog();
            List<Model.customer.UserappointmentLog> ulList = ulDAL.ReadOnDateNum(storesid, babytype, dt.ToString("yyyyMMdd"));

            DAL.customer.UserappointmentSetup msDAL = new DAL.customer.UserappointmentSetup();
            List<Model.customer.UserappointmentSetup> usList = msDAL.ReadList(storesid, babytype);
            SortedDictionary<string, string[]> house = new SortedDictionary<string, string[]>();
            Dictionary<string, int> dayNum = new Dictionary<string, int>();
            string strtime = "";
            foreach (Model.customer.UserappointmentSetup us in usList)
            {
                strtime = us.hoursNum.PadLeft(2, '0') + ":" + us.minute.PadLeft(2, '0');
                if (!house.ContainsKey(strtime))
                {
                    house.Add(strtime, new string[] { us.hoursNum, us.minute });
                }
                strtime = us.weeknum + "_" + strtime;
                if (!dayNum.ContainsKey(strtime))
                {
                    dayNum.Add(strtime, int.Parse(us.num));
                }
            }
            StringBuilder str = new StringBuilder();
            str.Append("[");
            if (house.Count > 0)
            {
                int i = 0;
                DAL.customer.Userappointment uaDAL = new DAL.customer.Userappointment();
                List<Model.customer.Userappointment> uaList = uaDAL.ReadOnUserUserappointment(userid, dt);

                foreach (string time in house.Keys)
                {
                    i++;
                    List<Model.customer.UserappointmentLog> ulModelList = ulList.FindAll(delegate(Model.customer.UserappointmentLog ul) { return ul.hoursNum == house[time][0] && ul.minute == house[time][1]; });

                    Model.customer.Userappointment uaModel = uaList.Find(delegate(Model.customer.Userappointment ua) { return ua.datetimehouer == house[time][0] && ua.datetimeminute == house[time][1] && ua.cycletype.Equals(babytype); });
                    string UAuserid = "";
                    int UApcnum = 0;
                    int UAappnum = 0;
                    if (uaModel != null)
                    {
                        UAuserid = uaModel.id;
                        if (uaModel.source.Equals("0"))
                        {
                            UApcnum = 1;
                        }
                        else
                        {
                            UAappnum = 1;
                        }
                    }

                    int usi = 0;
                    str.Append("{\"time\":\"" + time + "\",");
                    int weeknum = Base.Fun.fun.Week2Int(dt);
                    string content = "";
                    if (ulModelList.Count > usi)
                    {
                        int num = int.Parse(ulModelList[usi].num);
                        int pcnum = int.Parse(ulModelList[usi].pcusernum) - UApcnum;
                        int appnum = int.Parse(ulModelList[usi].appusernum) - UAappnum;
                        int usernum = 0;
                        if (appnum >= num)
                        {
                            usernum = num;
                        }
                        else
                        {
                            usernum = pcnum + appnum;
                            if (usernum >= num)
                            {
                                usernum = num;
                            }
                            else if (usernum <= 0)
                            {
                                usernum = 0;
                            }
                        }
                        int synum=(int.Parse(ulModelList[usi].num) - usernum);
                        if (synum == 0)
                        {
                            content = "你来晚了，已经预约满喽！";
                        }
                        else if (synum == 1)
                        {
                            content = "还有1个名额哦！";
                        }
                        else if (num > 0)
                        {
                            content = "还有" + synum.ToString() + "个名额哦！";
                        }
                        else {
                            content = "你来晚了，已经预约满喽！";
                        }
                        str.Append("\"allnum\":\"" + synum.ToString() + "\",\"usernum\":\"" + ulModelList[usi].usernum + "\"");
                        usi++;
                    }
                    else
                    {
                        strtime = weeknum.ToString() + "_" + time;
                        if (dayNum.ContainsKey(strtime))
                        {
                            if (dayNum[strtime] == 0)
                            {
                                content = "你来晚了，已经预约满喽！";
                            }
                            else if (dayNum[strtime] == 1)
                            {
                                content = "还有1个名额哦！";
                            }
                            else
                            {
                                content = "还有" + dayNum[strtime].ToString().ToString() + "个名额哦！";
                            }
                            str.Append("\"allnum\":\"" + dayNum[strtime].ToString() + "\",\"usernum\":\"0\"");
                        }
                        else
                        {
                            content = "你来晚了，已经预约满喽！";
                            str.Append("\"allnum\":\"0\",\"usernum\":\"0\"");
                        }
                    }
                    if (Base.Fun.fun.pnumeric(UAuserid))
                    {
                        str.Append(",\"user\":\"" + UAuserid + "\",\"content\":\"您已经预约了！\"");
                    }
                    else
                    {
                        str.Append(",\"user\":\"\",\"content\":\"" + content + "\"");
                    }
                    str.Append("},");
                }
                str.Remove(str.Length - 1, 1);
            }
            str.Append("]");
            return str.ToString();
        }


        /// <summary>
        /// 更新数量
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="datetime"></param>
        /// <param name="appusernum"></param>
        /// <param name="pcusernum"></param>
        /// <returns></returns>
        public static void AddNum(string storesid, string babytype, string datetime, string hoursNum, string minute, string appusernum, string pcusernum)
        {
            DAL.customer.UserappointmentLog ulDAL = new DAL.customer.UserappointmentLog();
            string datenum = DateTime.Parse(datetime).ToString("yyyyMMdd");
            Model.customer.UserappointmentLog ulModel = ulDAL.Read(storesid, babytype, datenum, hoursNum, minute);
            if (Base.Fun.fun.pnumeric(ulModel.id))
            {
                ulDAL.Update_User(storesid, ulModel.id, appusernum, pcusernum);
            }
            else
            {
                ulModel.storesid = storesid;
                ulModel.appusernum = appusernum;
                ulModel.babytype = Base.Fun.fun.IsZero(babytype);
                ulModel.datetime = datetime;
                ulModel.datenum = datenum;
                ulModel.hoursNum = hoursNum;
                ulModel.minute = minute;
                ulModel.weeknum = Base.Fun.fun.Week2Int(DateTime.Parse(datetime)).ToString();
                ulModel.num = Base.Fun.fun.IsZero(UI.customer.UserappointmentSetup.Read(storesid, ulModel.weeknum, hoursNum, minute, babytype));
                ulModel.pcusernum = pcusernum;
                ulModel.usernum = (int.Parse(appusernum) + int.Parse(pcusernum)).ToString();
                ulDAL.Insert(ulModel);
            }
        }
    }
}
