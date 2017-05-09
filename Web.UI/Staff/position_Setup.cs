using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.UI.Staff
{
    /// <summary>
    /// 配置信息
    /// </summary>
    public class position_Setup
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public static string View(string storesid)
        {
            StringBuilder str = new StringBuilder();
            DAL.Staff.position_Setup psDAL = new DAL.Staff.position_Setup();
            List<Model.Staff.position_Setup> psList = psDAL.ReadList(storesid);
            foreach (string s in Model.Data.Basic.satisfactionid.Keys)
            {
                Model.Staff.position_Setup psModel = psList.Find(delegate(Model.Staff.position_Setup ps) { return ps.satisfactionid.Equals(s); });
                if (psModel != null)
                {
                    str.Append(@"<tr>
        <th width=""80"" align=""right"">" + Model.Data.Basic.satisfactionid[s] + @"：</th>
        <td align=""left"">
            <input type=""text"" name=""satisfactionid"" value=""" + psModel.price + @""" size=""30""/>
        </td>
    </tr>");
                }
                else
                {
                    str.Append(@"<tr>
        <th width=""80"" align=""right"">" + Model.Data.Basic.satisfactionid[s] + @"：</th>
        <td align=""left"">
            <input type=""text"" name=""satisfactionid"" value=""0"" size=""30""/>
        </td>
    </tr>");
                }
            }
            return str.ToString();
        }
    }
}
