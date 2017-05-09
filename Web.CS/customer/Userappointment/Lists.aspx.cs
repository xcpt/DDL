using System;
using System.Text;
public partial class customer_Userappointment_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string cardNo, userid, name, cycletype, swimteacherid, status, statustime, endtime, datetimehouer, datetimeminute, Mobile;
    protected bool UserConsumptionIsAdd = false;
    protected StringBuilder str = new StringBuilder();
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        page = Base.Fun.Fetch.post("page");
        if (!Base.Fun.fun.pnumeric(page))
        {
            page = "1";
        }
        action = Base.Fun.Fetch.getpost("action");
        cardNo = Base.Fun.fun.NoCon(Server.UrlDecode(Base.Fun.Fetch.getpost("cardNo")));
        Mobile = Base.Fun.fun.NoCon(Base.Fun.Fetch.getpost("Mobile"));
        userid = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("userid"));
        name = Base.Fun.fun.NoCon(Server.UrlDecode(Base.Fun.Fetch.getpost("name")));
        cycletype = Base.Fun.Fetch.getpost("cycletype");
        swimteacherid = Base.Fun.Fetch.getpost("swimteacherid");
        status = Base.Fun.Fetch.getpost("status");
        statustime = Base.Fun.Fetch.getpost("stime");
        endtime = Base.Fun.Fetch.getpost("etime");
        datetimehouer = Base.Fun.Fetch.getpost("datetimehouer");
        datetimeminute = Base.Fun.Fetch.getpost("datetimeminute");
        if (!Base.Fun.fun.pnumeric(userid))
        {
            if (statustime.Length == 0 && endtime.Length == 0)
            {
                statustime = endtime = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
        UserConsumptionIsAdd = Web.UI.Users.CheckPermission("/customer/UserConsumption/Add.aspx", 4);
        DateTime dt = DateTime.Now;
        string dtstr = "";
        str.Append("<div style=\"float:left;padding:5px;\">");
        for (int i = 0; i <= 7;i++ )
        {
            dt = DateTime.Now.AddDays(i);
            dtstr = dt.ToString("yyyy-MM-dd");
            str.Append("<a href=\"\" onclick=\"$('#SearchUserappointmentstime').val('" + dtstr + "');$('#SearchUserappointmentetime').val('" + dtstr + "');$('#UserappointmentGrid').flexReload('stime=" + dtstr + "&etime=" + dtstr + "');return false;\">");
            if (i == 0)
            {
                str.Append(dt.ToString("MM-dd") + "&nbsp;今天");
            }
            else {
                str.Append(dt.ToString("MM-dd") + "&nbsp;" + Base.Fun.fun.WeekValue(dt));
            }
            str.Append("</a>&nbsp;&nbsp;&nbsp;");
        }
        str.Append("</div>");
    }
}