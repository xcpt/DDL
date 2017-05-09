using System;

public partial class customer_Card_Push : Web.UI.Permissions
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string cardNo = Base.Fun.fun.NoCon(Base.Fun.Fetch.getpost("cardNo"));
        string name = Base.Fun.fun.NoCon(Server.UrlDecode(Base.Fun.Fetch.getpost("name")));
        string Mobile = Base.Fun.fun.NoCon(Base.Fun.Fetch.getpost("Mobile"));
        string userid = Base.Fun.Fetch.getpost("userid");
        string cardtypeid = Base.Fun.Fetch.getpost("cardtypeid");
        string cycletype = Base.Fun.Fetch.getpost("cycletype");
        string startnum = Base.Fun.Fetch.getpost("startnum");
        string endnum = Base.Fun.Fetch.getpost("endnum");
        string cardstatus = Base.Fun.Fetch.getpost("cardstatus");
        Web.UI.customer.Card.ViewToXls(UserID, StoresID, cardNo, userid, name, cardtypeid, cycletype, startnum, endnum, cardstatus, Mobile);
        Response.End();
    }
}