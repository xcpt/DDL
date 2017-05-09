using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Web.UI.Reportform
{
    /// <summary>
    /// 会员消费频次
    /// </summary>
    public class frequency
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public static string View(string storesid,string cardNo, string starttime, string endtime)
        {
            DAL.customer.UserConsumption ucDAL = new DAL.customer.UserConsumption();
            List<Model.customer.UserConsumption> ucList = ucDAL.ReadList_XiaoFei(storesid, starttime, endtime, cardNo);
            Dictionary<string, int> MyDictionary = new Dictionary<string, int>();
            Dictionary<string, string> minTime = new Dictionary<string, string>();
            Dictionary<string, string> maxTime = new Dictionary<string, string>();
            List<string> idList = new List<string>();
            foreach (Model.customer.UserConsumption uc in ucList)
            {
                if (MyDictionary.ContainsKey(uc.userid))
                {
                    MyDictionary[uc.userid]++;
                    if (Base.Time.Time.TimeBad(uc.addtime, minTime[uc.userid], "天") > 0)
                    {
                        minTime[uc.userid] = uc.addtime;
                    }
                    if (Base.Time.Time.TimeBad(uc.addtime, maxTime[uc.userid], "天") < 0)
                    {
                        maxTime[uc.userid] = uc.addtime;
                    }
                }
                else
                {
                    idList.Add(uc.userid);
                    MyDictionary.Add(uc.userid, 1);
                    minTime.Add(uc.userid, uc.addtime);
                    maxTime.Add(uc.userid, uc.addtime);
                }
                if (idList.Count >= 100)
                {
                    break;
                }
            }
            StringBuilder str = new StringBuilder();
            str.Append("{");
            str.Append("\"page\":1,");
            str.Append("\"total\":" + idList.Count.ToString());
            if (idList.Count > 0)
            {
                str.Append(",\"rows\":[");
                MyDictionary = (from entry in MyDictionary
                                orderby entry.Value descending
                                select entry).ToDictionary(pair => pair.Key, pair => pair.Value);
                DAL.customer.User uDAL = new DAL.customer.User();
                List<Model.customer.User> uList = uDAL.ReadList_All(storesid, string.Join(",", idList.ToArray()));
                int i = 0;
                foreach (string userid in MyDictionary.Keys)
                {

                    Model.customer.User uModel = uList.Find(delegate(Model.customer.User u) { return u.userid.Equals(userid); });
                    if (uModel != null)
                    {
                        i++;
                        str.Append("{\"id\":\"" + i.ToString() + "\", \"cell\":[");
                        str.Append("\"" + i.ToString() + "\",");
                        str.Append("\"" + uModel.cModel.cardNo + "\",");
                        str.Append("\"" + uModel.name + "\",");
                        str.Append("\"" + uModel.nickname + "\",");
                        str.Append("\"" + MyDictionary[userid].ToString() + "\",");
                        str.Append("\"" + Ami.DateTimeFormat(minTime[userid], "YY04-MM-DD") + "\",");
                        str.Append("\"" + Ami.DateTimeFormat(maxTime[userid], "YY04-MM-DD") + "\"");
                        str.Append("]},");
                    }
                }
                str.Remove(str.Length - 1, 1);
                str.Append("]");
            }
            str.Append("}");
            return str.ToString();
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public static void ViewToExcel(string storesid, string userid, string cardNo, string starttime, string endtime)
        {
            DAL.customer.UserConsumption ucDAL = new DAL.customer.UserConsumption();
            List<Model.customer.UserConsumption> ucList = ucDAL.ReadList_XiaoFei(storesid, starttime, endtime, cardNo);
            Dictionary<string, int> MyDictionary = new Dictionary<string, int>();
            Dictionary<string, string> minTime = new Dictionary<string, string>();
            Dictionary<string, string> maxTime = new Dictionary<string, string>();
            List<string> idList = new List<string>();
            foreach (Model.customer.UserConsumption uc in ucList)
            {
                if (MyDictionary.ContainsKey(uc.userid))
                {
                    MyDictionary[uc.userid]++;
                    if (Base.Time.Time.TimeBad(uc.addtime, minTime[uc.userid], "天") > 0)
                    {
                        minTime[uc.userid] = uc.addtime;
                    }
                    if (Base.Time.Time.TimeBad(uc.addtime, maxTime[uc.userid], "天") < 0)
                    {
                        maxTime[uc.userid] = uc.addtime;
                    }
                }
                else
                {
                    idList.Add(uc.userid);
                    MyDictionary.Add(uc.userid, 1);
                    minTime.Add(uc.userid, uc.addtime);
                    maxTime.Add(uc.userid, uc.addtime);
                }
                if (idList.Count >= 100)
                {
                    break;
                }
            }
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "会员卡号";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "会员名";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "小名";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "次数";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "首次消费时间";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "末次消费时间";
            dt.Columns.Add(dc);

            if (idList.Count > 0)
            {
                MyDictionary = (from entry in MyDictionary
                                orderby entry.Value descending
                                select entry).ToDictionary(pair => pair.Key, pair => pair.Value);
                DAL.customer.User uDAL = new DAL.customer.User();
                List<Model.customer.User> uList = uDAL.ReadList_All(storesid, string.Join(",", idList.ToArray()));
                foreach (string uid in MyDictionary.Keys)
                {

                    Model.customer.User uModel = uList.Find(delegate(Model.customer.User u) { return u.userid.Equals(uid); });
                    if (uModel != null)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = uModel.cModel.cardNo;
                        dr[1] = uModel.name;
                        dr[2] = uModel.nickname;
                        dr[3] = MyDictionary[uid].ToString();
                        dr[4] = Ami.DateTimeFormat(minTime[uid], "YY04-MM-DD");
                        dr[5] = Ami.DateTimeFormat(maxTime[uid], "YY04-MM-DD");
                        dt.Rows.Add(dr);
                    }
                }
            }
            if (dt.Rows.Count > 0)
            {
                string FileName = Base.Fun.Management.RealDirectory(Sys.SiteInfo.UpFile + "Files/Frequency_" + userid + ".xls");
                Base.IO.Dir.CheckDir(Base.IO.Dir.ReMoveFileName(FileName));
                Base.Office.ExcelHelper.Export(dt, "员会消费频次排行", FileName);
                System.Web.HttpContext.Current.Response.Write(SyCms.Window.DownFile.DownFileName(FileName, "员会消费频次排行.xls", true));
            }
            dt.Dispose();
        }
    }
}
