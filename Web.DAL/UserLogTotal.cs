using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Web.DAL
{
    public class UserLogTotal
    {
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable Read_DataTable(string sql)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData("Select B.UserName," + Base.DataBase.Difference.Time_Format("", "a.[DateTime]") + ",a.[TableName],a.[AddNum],a.[ModiyNum],a.[DelNum],a.[AuditNum],a.[OtherNum] From [Manager_Users_LogTotal] as a Left join [Manager_Users] as b on (a.[UserID]=b.[UserID]) " + sql + " Order by a.[UserID],a.[TableName],a.[DateTime]");
            db.Dispose();
            return dt;
        }
        /// <summary>
        /// 读取条件，某天总种
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="DateTime"></param>
        /// <returns></returns>
        public DataTable Read_Num(string sql, string DateTime)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt3 = db.GetData("Select '所有','" + DateTime + "','',Sum(a.[AddNum]),Sum(a.[ModiyNum]),Sum(a.[DelNum]),Sum(a.[AuditNum]),Sum(a.[OtherNum]) From [Manager_Users_LogTotal] as a " + sql + " And " + Base.DataBase.Difference.Time_GetDatediff("", Base.DataBase.Difference.Time_DateDiffParameter.Day, "a.[DateTime]", "'" + DateTime + "'") + "=0");
            db.Dispose();
            return dt3;
        }
    }
}
