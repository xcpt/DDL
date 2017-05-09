using System.Collections.Generic;
using System.Text;

namespace Web.UI.Staff
{
    /// <summary>
    /// 员工
    /// </summary>
    public class member
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="name"></param>
        /// <param name="status"></param>
        /// <param name="departmentid"></param>
        /// <returns></returns>
        public static string View(string storesid, string name, string status, string departmentid)
        {
            DAL.Staff.member mDAL = new DAL.Staff.member();
            return mDAL.View(UI.Sys.SiteInfo.GetPageSize(), storesid, name, status, departmentid);
        }
        /// <summary>
        /// 修改综合评价
        /// </summary>
        /// <param name="id"></param>
        /// <param name="membersatisfactionid"></param>
        public static void Update_membersatisfactionid(string id, string membersatisfactionid)
        {
            DAL.Staff.member mDAL = new DAL.Staff.member();
            mDAL.Update_membersatisfactionid(id, membersatisfactionid);
        }
        /// <summary>
        /// 返回Option
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public static string GetOption(string storesid, string memberid)
        {
            StringBuilder str = new StringBuilder();
            DAL.Staff.member mDAL = new DAL.Staff.member();
            Dictionary<string, string> dlist = Staff.department.GetList(storesid);
            List<Model.Staff.member> mList = mDAL.ReadList(storesid);
            string title="";
            foreach (Model.Staff.member m in mList)
            {
                title = "";
                if (dlist.ContainsKey(m.departmentid))
                {
                    title = dlist[m.departmentid];
                }
                str.Append("<option value=\"" + m.id + "\"" + (m.id.Equals(memberid) ? " selected=\"selected\"" : "") + ">" + m.name + (title.Length > 0 ? "[" + title + "]" : "") + "</option>");
            }
            return str.ToString();
        }
    }
}
