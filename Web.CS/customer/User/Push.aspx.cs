using System;

public partial class customer_User_Push : Web.UI.Permissions
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string cardNo = Base.Fun.fun.NoCon(Base.Fun.Fetch.getpost("cardNo"));
        string name = Base.Fun.fun.NoCon(Server.UrlDecode(Base.Fun.Fetch.getpost("name")));
        string mobile = Base.Fun.fun.NoCon(Base.Fun.Fetch.getpost("mobile"));
        string nickname = Base.Fun.fun.NoCon(Server.UrlDecode(Base.Fun.Fetch.getpost("nickname")));
        string cardtypeid = Base.Fun.Fetch.getpost("cardtypeid");
        string cardstatus = Base.Fun.Fetch.getpost("cardstatus");
        string communityid = Base.Fun.Fetch.getpost("communityid");
        string cycletype = Base.Fun.Fetch.getpost("cycletype");
        string startnum = Base.Fun.Fetch.getpost("startnum");
        string endnum = Base.Fun.Fetch.getpost("endnum");
        string statusmonthnum = Base.Fun.Fetch.getpost("statusmonthnum");
        string endmonthnum = Base.Fun.Fetch.getpost("endmonthnum");
        string statusdaynum = Base.Fun.Fetch.getpost("statusdaynum");
        string enddaynum = Base.Fun.Fetch.getpost("enddaynum");
        string statusbirthday = Base.Fun.Fetch.getpost("stime");
        string endbirthday = Base.Fun.Fetch.getpost("etime");
        string loginnum = Base.Fun.Fetch.getpost("loginnum");
        Web.UI.customer.User.ToExcel(UserID, StoresID, cardNo, name, communityid, mobile, nickname, cycletype, statusmonthnum, endmonthnum, statusdaynum, enddaynum, statusbirthday, endbirthday, loginnum, startnum, endnum, cardtypeid, cardstatus);
        Response.End();
    }
}