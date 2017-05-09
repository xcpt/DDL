using System;

public partial class customer_Card_Lists : Web.UI.Permissions
{
    protected string page = "";
    protected string action = "";
    protected string cardNo = "", userid = "", name = "", cardtypeid = "", cycletype = "", startnum = "", endnum = "", cardstatus = "", Mobile="";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        page = Base.Fun.Fetch.post("page");
        if (!Base.Fun.fun.pnumeric(page))
        {
            page = "1";
        }
        action = Base.Fun.Fetch.getpost("action");
        cardNo = Base.Fun.fun.NoCon(Base.Fun.Fetch.getpost("cardNo"));
        name = Base.Fun.fun.NoCon(Server.UrlDecode(Base.Fun.Fetch.getpost("name")));
        Mobile = Base.Fun.fun.NoCon(Base.Fun.Fetch.getpost("Mobile"));
        userid = Base.Fun.Fetch.getpost("userid");
        cardtypeid = Base.Fun.Fetch.getpost("cardtypeid");
        cycletype = Base.Fun.Fetch.getpost("cycletype");
        startnum = Base.Fun.Fetch.getpost("startnum");
        endnum = Base.Fun.Fetch.getpost("endnum");
        cardstatus = Base.Fun.Fetch.getpost("cardstatus");
    }
}