using System;
using System.Text;
using System.Web;
using System.Data;

namespace Web.UI
{
    /// <summary>
    /// App输入
    /// </summary>
    public class APP
    {
        /// <summary>
        /// 返回正常状态及错误状态提示信息
        /// </summary>
        /// <param name="state"></param>
        /// <param name="UserID"></param>
        /// <param name="client"></param>
        /// <param name="push"></param>
        /// <param name="message"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string GetJosn(string state, string UserID, string client, string push, string message, string list, string token)
        {
            return "{\"state\":\"" + state + "\",\"userid\":\"" + UserID + "\",\"client\":\"" + client + "\",\"push\":\"" + push + "\",\"message\":\"" + Base.Fun.JScript.htmltojavascriptNoD(message) + "\"" + (state.Equals("-1") ? "" : ",\"list\":" + (list.Length > 0 ? list : "{}")) + ",\"token\":\"" + token + "\",\"datetime\":\"" + Base.Time.Time.ConvertDateTimeMilliInt(DateTime.Now).ToString() + "\"}";
        }
        /// <summary>
        /// 表格转成JSon
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToJson(DataTable dt, bool IsOne)
        {
            StringBuilder str = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                if (!IsOne)
                {
                    str.Append("[");
                }
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("{");
                    foreach (DataColumn dc in dt.Columns)
                    {
                        str.Append("\"" + dc.ColumnName.ToLower() + "\":\"" + Base.Fun.JScript.htmltojavascriptNoD(dr[dc].ToString()) + "\",");
                    }
                    str.Remove(str.Length - 1, 1);
                    str.Append("}" + ((!IsOne && (i + 1) < dt.Rows.Count) ? "," : ""));
                    i++;
                }
                if (!IsOne)
                {
                    str.Append("]");
                }
            }
            else {
                if (IsOne)
                {
                    str.Append("{}");
                }
                else {
                    str.Append("[]");
                }
            }
            return str.ToString();
        }
        /// <summary>
        /// 表格转成JSon
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToJson(DataTable dt, int Start_I, int End_I, bool IsOne)
        {
            StringBuilder str = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                if (!IsOne)
                {
                    str.Append("[");
                }
                for (int i = Start_I; i < End_I; i++)
                {
                    str.Append("{");
                    foreach (DataColumn dc in dt.Columns)
                    {
                        str.Append("\"" + dc.ColumnName.ToLower() + "\":\"" + Base.Fun.JScript.htmltojavascriptNoD(dt.Rows[i][dc].ToString()) + "\",");
                    }
                    str.Remove(str.Length - 1, 1);
                    str.Append("}" + ((!IsOne && (i + 1) < End_I) ? "," : ""));
                }
                if (!IsOne)
                {
                    str.Append("]");
                }
            }
            else
            {
                if (IsOne)
                {
                    str.Append("{}");
                }
                else
                {
                    str.Append("[]");
                }
            }
            return str.ToString();
        }
        /// <summary>
        /// 离过生日还有
        /// </summary>
        /// <param name="dtBirthday"></param>
        /// <returns></returns>
        public static string GetBirthday(DateTime dtBirthday)
        {
            int year = DateTime.Now.Year;
            int day = Base.Time.Time.TimeBad(DateTime.Now.ToString("yyyy-MM-dd"), year.ToString() + "-" + dtBirthday.ToString("MM-dd"), "天");
            if (day < 0)
            {
                day = Base.Time.Time.TimeBad(DateTime.Now.ToString("yyyy-MM-dd"), (year + 1).ToString() + "-" + dtBirthday.ToString("MM-dd"), "天");
            }
            return day.ToString();
        }
        /// <summary>
        /// 返回大小
        /// </summary>
        /// <param name="dtBirthday"></param>
        /// <param name="dtNow"></param>
        /// <returns></returns>
        public static string GetAge(DateTime dtBirthday)
        {
            string strAge = "";                         // 年龄的字符串表示
            DateTime dtNow = DateTime.Now;
            int intYear = 0;                                    // 岁
            int intMonth = 0;                                    // 月
            int intDay = 0;                                    // 天
            // 计算天数
            intDay = dtNow.Day - dtBirthday.Day;
            if (intDay < 0)
            {
                dtNow = dtNow.AddMonths(-1);
                intDay += DateTime.DaysInMonth(dtNow.Year, dtNow.Month);
            }

            // 计算月数
            intMonth = dtNow.Month - dtBirthday.Month;
            if (intMonth < 0)
            {
                intMonth += 12;
                dtNow = dtNow.AddYears(-1);
            }

            // 计算年数
            intYear = dtNow.Year - dtBirthday.Year;

            // 格式化年龄输出
            if (intYear >= 1)                                            // 年份输出
            {
                strAge = intYear.ToString() + "岁";
            }

            if (intMonth > 0)                           // 五岁以下可以输出月数
            {
                strAge += intMonth.ToString() + "个月";
            }
            if (intDay > 0)                              // 一岁以下可以输出天数
            {
                strAge += intDay.ToString() + "天";
            }
            return strAge;
        }
        /// <summary>
        /// 天气预约
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        /// <returns></returns>
        public static string ReadTQ(string lat, string lng, string City)
        {
            StringBuilder str = new StringBuilder();
            string city = "";
            string district = "";
            string Content = "";
            if (lat.Length > 0 && lng.Length > 0)
            {
                string url = @"http://api.map.baidu.com/geocoder/v2/?ak=25NLKrX1seThVnAHogE8DVtt&callback=renderReverse&location=" + lat + "," + lng + @"&output=xml&pois=1";
                Content = Base.Web.WebContent.Read(url);
                string country = Base.Fun.Regxp.ReadRegex(Content, "country", "", false, 1);
                string province = Base.Fun.Regxp.ReadRegex(Content, "province", "", false, 1);
                city = Base.Fun.Regxp.ReadRegex(Content, "city", "", false, 1);
                district = Base.Fun.Regxp.ReadRegex(Content, "district", "", false, 1);
            }
            else if (City.Length > 0)
            {
                city = City;
            }
            string tqurl = @"http://api.map.baidu.com/telematics/v3/weather?location={0}&output=json&ak=25NLKrX1seThVnAHogE8DVtt";
            if (district.Length > 0)
            {
                Content = Base.Web.WebContent.Read(string.Format(tqurl, district));
            }
            else
            {
                Content = Base.Web.WebContent.Read(string.Format(tqurl, city));
            }
            string pic = "";
            if (Content.Length > 0)
            {
                try
                {
                    Model.Baidu.Tq tq = new Model.Baidu.Tq();
                    tq = Base.Fun.JsonHelper.ParseFormJson<Model.Baidu.Tq>(Content);
                    if (tq != null && tq.results != null && tq.results.Count > 0 && tq.results[0].weather_data != null && tq.results[0].weather_data.Count > 0)
                    {
                        str.Append(tq.results[0].weather_data[0].date + " " + tq.results[0].weather_data[0].temperature.Replace(" ~ ", "/") + " " + tq.results[0].weather_data[0].wind + (tq.results[0].index.Count > 0 ? " 体感:" + tq.results[0].index[0].zs : ""));
                        int h = int.Parse(DateTime.Now.ToString("HH"));
                        if (h >= 8 && h <= 18)
                        {
                            pic = tq.results[0].weather_data[0].dayPictureUrl;
                        }
                        else
                        {
                            pic = tq.results[0].weather_data[0].nightPictureUrl;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Base.Error.Error.WriteError(ex);
                }
            }
            return ",\"weather\":\"" + str.ToString() + "\",\"weatherpic\":\"" + pic + "\"";
        }
    }
}
