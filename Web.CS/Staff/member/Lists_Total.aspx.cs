using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Staff_member_Lists_Total : Web.UI.Permissions
{
    protected string departmentid = "";
    protected string starttime = "", endtime = "";
    protected string str = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        departmentid = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(departmentid))
        {
            starttime = Base.Fun.Fetch.getpost("stime");
            endtime = Base.Fun.Fetch.getpost("etime");
            if (starttime.Length == 0)
            {
                if (endtime.Length > 0 && Base.Fun.fun.IsDate(endtime))
                {
                    starttime = DateTime.Parse(endtime).AddMonths(-1).ToString("yyyy-MM-dd");
                }
            }
            if (endtime.Length == 0)
            {
                if (starttime.Length > 0 && Base.Fun.fun.IsDate(starttime))
                {
                    endtime = DateTime.Parse(starttime).AddMonths(1).ToString("yyyy-MM-dd");
                }
            }
            str = Web.UI.Staff.department.ViewMember(StoresID, departmentid, starttime, endtime);
            string action = Base.Fun.Fetch.getpost("action");
            if (action.Equals("view"))
            {
                Response.Write(str);
                Response.End();
            }
        }
        else
        {
            Response.End();
        }
    }
}