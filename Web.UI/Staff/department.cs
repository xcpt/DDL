using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.UI.Staff
{
    /// <summary>
    /// 部门
    /// </summary>
    public class department
    {
        /// <summary>
        /// 读取名称
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetTitle(string storesid, string id)
        {
            if (Base.Fun.fun.pnumeric(id))
            {
                DAL.Staff.department dDAL = new DAL.Staff.department();
                return dDAL.Read(storesid, id).title;
            }
            else {
                return "";
            }
        }
        /// <summary>
        /// 全部
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetOption(string storesid, string id)
        {
            StringBuilder str = new StringBuilder();
            DAL.Staff.department dDAL = new DAL.Staff.department();
            List<Model.Staff.department> dList = dDAL.ReadList(storesid);
            foreach (Model.Staff.department dModel in dList)
            {
                str.Append("<option value=\"" + dModel.id + "\"" + (dModel.id.Equals(id) ? " selected=\"selected\"" : "") + ">" + dModel.title + "</option>");
            }
            return str.ToString();
        }
        /// <summary>
        /// 全部
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public static Dictionary<string,string> GetList(string storesid)
        {
            Dictionary<string, string> dcList = new Dictionary<string, string>();
            DAL.Staff.department dDAL = new DAL.Staff.department();
            List<Model.Staff.department> dList = dDAL.ReadList(storesid);
            foreach (Model.Staff.department dModel in dList)
            {
                dcList.Add(dModel.id, dModel.title);
            }
            return dcList;
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string View(string storesid,string title)
        {
            DAL.Staff.department dDAL = new DAL.Staff.department();
            return dDAL.View(UI.Sys.SiteInfo.GetPageSize(), storesid, title);
        }

        /// <summary>
        /// 会是一个月内的
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="departmentid"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public static string ViewDepartment(string storesid, string departmentid, string starttime, string endtime)
        {
            Web.DAL.Staff.performance pDAL = new DAL.Staff.performance();
            List<Model.Staff.performance> pList = pDAL.ReadList_department(departmentid, starttime, endtime);
            Dictionary<string, int> jxcs = new Dictionary<string, int>();
            int icount = 0;
            foreach (Model.Staff.performance p in pList)
            {
                icount++;
                if (jxcs.ContainsKey(p.type))
                {
                    jxcs[p.type]++;
                }
                else
                {
                    jxcs.Add(p.type, 1);
                }
            }
            StringBuilder str = new StringBuilder();
            str.Append("<table class=\"table StyleView\" border=\"0\" cellspacing=\"0\" scellpadding=\"0\" width=\"100%\">");
            str.Append("<tr><th colspan=\"2\">考勤情况</th></tr>");
            foreach (string s in Model.Data.Basic.performanceType.Keys)
            {
                str.Append(@"<tr>
        <th width=""100"" align=""right"">" + Model.Data.Basic.performanceType[s] + @"：</th>
        <td align=""left"">" + (jxcs.ContainsKey(s) ? jxcs[s] : 0).ToString() + @"</td></tr>");
            }
            str.Append(@"<tr>
        <th width=""100"" align=""right"">总计：</th>
        <td align=""left"">" + icount.ToString() + @"</td></tr>");

            Web.DAL.customer.UserConsumption ucDAL = new DAL.customer.UserConsumption();
            List<Web.Model.customer.UserConsumption> ucList = ucDAL.ReadList_department(departmentid, starttime, endtime);
            Dictionary<string, int> xfcs = new Dictionary<string, int>();
            icount = 0;
            foreach (Model.customer.UserConsumption uc in ucList)
            {
                icount++;
                if (xfcs.ContainsKey(uc.satisfactionid))
                {
                    xfcs[uc.satisfactionid]++;
                }
                else
                {
                    xfcs.Add(uc.satisfactionid, 1);
                }
            }
            str.Append("<tr><th colspan=\"2\">客户满意度</th></tr>");
            foreach (string s in Model.Data.Basic.satisfactionid.Keys)
            {
                str.Append(@"<tr>
        <th width=""100"" align=""right"">" + Model.Data.Basic.satisfactionid[s] + @"：</th>
        <td align=""left"">" + (xfcs.ContainsKey(s) ? xfcs[s] : 0).ToString() + @"</td></tr>");
            }
            str.Append(@"<tr>
        <th width=""100"" align=""right"">总计：</th>
        <td align=""left"">" + icount.ToString() + @"</td></tr>");
            if (xfcs.ContainsKey("3") && icount > 0)
            {
                str.Append(@"<tr>
        <th width=""100"" align=""right"">表扬率：</th>
        <td align=""left"">" + Math.Round((double)xfcs["3"] * 100 / icount, 2).ToString() + @"%</td></tr>");
            }

            DAL.Staff.member mDAL = new DAL.Staff.member();
            List<Model.Staff.member> mList = mDAL.ReadList_department(storesid, departmentid, starttime, endtime);
            int icount1 = 0;
            icount = 0;
            foreach (Model.Staff.member m in mList)
            {
                icount++;
                if (m.status.Equals("2"))
                {
                    icount1++;
                }
            }
            str.Append("<tr><th colspan=\"2\">部门员工流失率</th></tr>");
            str.Append(@"<tr>
        <th width=""100"" align=""right"">总人数：</th>
        <td align=""left"">" + icount.ToString() + @"</td></tr>");
            str.Append(@"<tr>
        <th width=""100"" align=""right"">流失人数：</th>
        <td align=""left"">" + icount.ToString() + @"</td></tr>");
            if (icount > 0)
            {
                str.Append(@"<tr>
        <th width=""100"" align=""right"">流失率：</th>
        <td align=""left"">" + Math.Round((double)icount1 * 100 / icount, 2).ToString() + @"%</td></tr>");
            }
            str.Append("</table>");
            return str.ToString();
        }

        /// <summary>
        /// 会是一个月内的
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="departmentid"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public static string ViewMember(string storesid, string memberid, string starttime, string endtime)
        {
            Web.DAL.Staff.performance pDAL = new DAL.Staff.performance();
            List<Model.Staff.performance> pList = pDAL.ReadList_Member(memberid, starttime, endtime);
            Dictionary<string, int> jxcs = new Dictionary<string, int>();
            int icount = 0;
            foreach (Model.Staff.performance p in pList)
            {
                icount++;
                if (jxcs.ContainsKey(p.type))
                {
                    jxcs[p.type]++;
                }
                else
                {
                    jxcs.Add(p.type, 1);
                }
            }
            StringBuilder str = new StringBuilder();
            str.Append("<table class=\"table StyleView\" border=\"0\" cellspacing=\"0\" scellpadding=\"0\" width=\"100%\">");
            str.Append("<tr><th colspan=\"2\">考勤情况</th></tr>");
            foreach (string s in Model.Data.Basic.performanceType.Keys)
            {
                str.Append(@"<tr>
        <th width=""100"" align=""right"">" + Model.Data.Basic.performanceType[s] + @"：</th>
        <td align=""left"">" + (jxcs.ContainsKey(s) ? jxcs[s] : 0).ToString() + @"</td></tr>");
            }
            str.Append(@"<tr>
        <th width=""100"" align=""right"">总计：</th>
        <td align=""left"">" + icount.ToString() + @"</td></tr>");

            Web.DAL.customer.UserConsumption ucDAL = new DAL.customer.UserConsumption();
            List<Web.Model.customer.UserConsumption> ucList = ucDAL.ReadList_member(memberid, starttime, endtime);
            Dictionary<string, int> xfcs = new Dictionary<string, int>();
            icount = 0;
            foreach (Model.customer.UserConsumption uc in ucList)
            {
                icount++;
                if (xfcs.ContainsKey(uc.satisfactionid))
                {
                    xfcs[uc.satisfactionid]++;
                }
                else
                {
                    xfcs.Add(uc.satisfactionid, 1);
                }
            }
            str.Append("<tr><th colspan=\"2\">客户满意度</th></tr>");
            foreach (string s in Model.Data.Basic.satisfactionid.Keys)
            {
                str.Append(@"<tr>
        <th width=""100"" align=""right"">" + Model.Data.Basic.satisfactionid[s] + @"：</th>
        <td align=""left"">" + (xfcs.ContainsKey(s) ? xfcs[s] : 0).ToString() + @"</td></tr>");
            }
            str.Append(@"<tr>
        <th width=""100"" align=""right"">总计：</th>
        <td align=""left"">" + icount.ToString() + @"</td></tr>");
            if (xfcs.ContainsKey("3") && icount > 0)
            {
                str.Append(@"<tr>
        <th width=""100"" align=""right"">表扬率：</th>
        <td align=""left"">" + Math.Round((double)xfcs["3"] * 100 / icount, 2).ToString() + @"%</td></tr>");
            }
            str.Append("</table>");
            return str.ToString();
        }

    }
}
