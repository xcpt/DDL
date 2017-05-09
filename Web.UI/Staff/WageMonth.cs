using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.UI.Staff
{
    /// <summary>
    /// 月工资
    /// </summary>
    public class WageMonth
    {
        /// <summary>
        /// 读取员工工资
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="name"></param>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static string View(string storesid, string memberid, string datetime)
        {
            DAL.Staff.WageMonth wmDAL = new DAL.Staff.WageMonth();
            int Page = 1;
            int MaxPage = 1;
            int Total = 0;
            List<Model.Staff.WageMonth> wmList = wmDAL.View(UI.Sys.SiteInfo.GetPageSize(), ref Page, ref MaxPage, ref Total, storesid, memberid, datetime);
            StringBuilder str = new StringBuilder();
            DAL.Staff.WageList wlDAL = new DAL.Staff.WageList();
            str.Append("{");
            str.Append("\"page\":" + Page.ToString() + ",");
            str.Append("\"total\":" + Total.ToString());
            if (wmList.Count > 0)
            {
                str.Append(",\"rows\": [");
                int colcount = wmList.Count;
                foreach (Model.Staff.WageMonth wmModel in wmList)
                {
                    List<Model.Staff.WageList> wlList = wlDAL.ReadList(wmModel.id);

                    str.Append("{\"id\":\"" + wmModel.id + "\", \"cell\":[");
                    str.Append("\"" + wmModel.id + "\",");
                    str.Append("\"" + wmModel.datetime + "\",");
                    str.Append("\"" + Base.Fun.JScript.htmltojavascriptNoD(wmModel.member_name) + "\",");
                    str.Append("\"" + Base.Fun.JScript.htmltojavascriptNoD(wmModel.member_level) + "\",");
                    str.Append("\"" + Base.Fun.JScript.htmltojavascriptNoD(wmModel.salary) + "\",");
                    str.Append("\"" + Base.Fun.JScript.htmltojavascriptNoD(wmModel.deducted) + "\",");

                    foreach (string s in Model.Data.Basic.performanceType.Keys)
                    {
                        Model.Staff.WageList wlModel = wlList.Find(delegate(Model.Staff.WageList wl) { return wl.performanceType.Equals(s); });
                        if (wlModel != null)
                        {
                            str.Append("\"" + Base.Fun.JScript.htmltojavascriptNoD(wlModel.money) + "\",");
                        }
                        else
                        {
                            str.Append("\"\",");
                        }
                    }
                    str.Append("\"" + Base.Fun.JScript.htmltojavascriptNoD(wmModel.wagenum) + "\"");
                    str.Append("]},");
                }
                str.Remove(str.Length - 1, 1);
                str.Append("]");
            }
            str.Append("}");
            return str.ToString();
        }
        /// <summary>
        /// 发工资
        /// </summary>
        /// <param name="datetime"></param>
        public static void SendWage(string storesid, string datetime)
        {
            DAL.Staff.WageMonth wmDAL = new DAL.Staff.WageMonth();
            DAL.Staff.member mDAL = new DAL.Staff.member();
            List<Model.Staff.member> mList = mDAL.ReadList(storesid);
            List<Model.Staff.WageMonth> wmList = wmDAL.ReadList(datetime);
            DAL.Staff.WageList wlDAL = new DAL.Staff.WageList();
            


            double salary = 0;
            double deducted = 0;
            DAL.Staff.performance pmDAL=new DAL.Staff.performance();
            DAL.customer.UserConsumption ucDAL = new DAL.customer.UserConsumption();
            DAL.Staff.position pDAL = new DAL.Staff.position();
            List<Model.Staff.position> pList = pDAL.ReadList(storesid);
            string gzid = "";
            DateTime dt = DateTime.Parse(datetime.Substring(0, 4) + "-" + datetime.Substring(4) + "-1");
            foreach (Model.Staff.member mModel in mList)
            {
                gzid = "";
                salary = 0;
                deducted = 0;
                Model.Staff.WageMonth wmModel = wmList.Find(delegate(Model.Staff.WageMonth wm) { return wm.memberid.Equals(mModel.id); });
                if (wmModel != null)
                {
                    gzid = wmModel.id;
                    salary = double.Parse(wmModel.salary);
                    deducted = double.Parse(wmModel.deducted);
                }
                else
                {
                    Model.Staff.position pModel = pList.Find(delegate(Model.Staff.position p) { return p.id.Equals(mModel.positionid); });
                    if (pModel != null)
                    {
                        salary = double.Parse(pModel.salary);
                        if (mModel.isinsurance.Equals("1"))
                        {
                            deducted = double.Parse(pModel.deducted);
                        }
                    }
                    wmModel = new Model.Staff.WageMonth();
                    wmModel.datetime = datetime;
                    wmModel.deducted = deducted.ToString();
                    wmModel.memberid = mModel.id;
                    wmModel.salary = salary.ToString();
                    wmModel.wagenum = "0";
                    gzid = wmDAL.Insert(wmModel);
                }
                if (Base.Fun.fun.pnumeric(gzid))
                {
                    List<Model.Staff.performance> pmList = pmDAL.ReadList_Member(mModel.id, dt.ToString());

                    List<Model.Staff.WageList> wlList = wlDAL.ReadList(gzid);

                    foreach (string stype in Model.Data.Basic.performanceType.Keys)
                    {
                        List<Model.Staff.performance> pm = pmList.FindAll(delegate(Model.Staff.performance p) { return p.type.Equals(stype); });
                        double typenum = 0;
                        if (stype.Equals("10"))//提添加
                        {
                            typenum += ucDAL.ReadMemberPrice(mModel.storesid, mModel.id, dt.ToString());
                        }
                        foreach (Model.Staff.performance p in pm)
                        {
                            typenum += double.Parse(p.num);
                        }
                        Model.Staff.WageList wlModel = wlList.Find(delegate(Model.Staff.WageList wl) { return wl.performanceType.Equals(stype); });
                        salary += typenum;
                        if (wlModel != null)
                        {
                            wlModel.money = typenum.ToString();
                            wlDAL.Update(wlModel);
                        }
                        else
                        {
                            wlModel = new Model.Staff.WageList();
                            wlModel.money = typenum.ToString();
                            wlModel.performanceType = stype;
                            wlModel.wagemonthid = gzid;
                            wlDAL.Insert(wlModel);
                        }
                    }
                    ///更新总工资
                    wmDAL.Update_wagenum(gzid, (salary - deducted).ToString());
                }
            }
        }
    }
}
