using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.UI.customer
{
    /// <summary>
    /// 预约配置
    /// </summary>
    public class UserappointmentSetup
    {
        /// <summary>
        /// 返回数量
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="weeknum"></param>
        /// <param name="hoursNum"></param>
        /// <param name="minute"></param>
        /// <returns></returns>
        public static string Read(string storesid, string weeknum, string hoursNum, string minute, string babytype)
        {
            DAL.customer.UserappointmentSetup usDAL = new DAL.customer.UserappointmentSetup();
            return Base.Fun.fun.IsZero(usDAL.Read(storesid, weeknum, hoursNum, minute, babytype).num);
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="babytype"></param>
        /// <returns></returns>
        public static string View(string storesid, string babytype)
        {
            DAL.customer.UserappointmentSetup msDAL = new DAL.customer.UserappointmentSetup();
            List<Model.customer.UserappointmentSetup> usList = msDAL.ReadList(storesid, babytype);
            SortedDictionary<string, string[]> house = new SortedDictionary<string, string[]>();
            string strtime = "";
            foreach (Model.customer.UserappointmentSetup us in usList)
            {
                strtime = us.hoursNum.PadLeft(2, '0') + ":" + us.minute.PadLeft(2, '0');
                if (!house.ContainsKey(strtime))
                {
                    house.Add(strtime, new string[] { us.hoursNum, us.minute });
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
                    List<Model.customer.UserappointmentSetup> usModelList = usList.FindAll(delegate(Model.customer.UserappointmentSetup us) { return us.hoursNum == house[time][0] && us.minute == house[time][1]; });
                    str.Append("{\"id\":\"" + i.ToString() + "\", \"cell\":[");
                    int usi = 0;
                    str.Append("\"" +i.ToString() + "\",");
                    str.Append("\"" + time + "\",");
                    for (int j = 1; j <= 7; j++)
                    {
                        if (usModelList.Count > usi && usModelList[usi].weeknum == j.ToString())
                        {
                            str.Append("\"" + usModelList[usi].id + "," + usModelList[usi].num + "\",");
                            usi++;
                        }
                        else
                        {
                            str.Append("\""+j.ToString()+"\",");
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
    }
}
