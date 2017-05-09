using System;
using System.Text;
namespace Web.CS.Manager.Log
{
    public partial class Lists : Web.UI.Permissions
    {
        protected string page = "";
        protected string action = "";
        protected string Name = "", TableName = "", Url = "", Stime = "", Etime = "", StimeH = "", EtimeH = "";
        protected string AutoTaskPlay = "";
        protected StringBuilder strHour = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            action = Base.Fun.Fetch.getpost("action");
            page = Base.Fun.Fetch.post("page");
            if (!Base.Fun.fun.pnumeric(page))
            {
                page = "1";
            }
            Name = Base.Fun.fun.NoCon(Server.UrlDecode(Base.Fun.Fetch.getpost("Name")));
            TableName = Base.Fun.fun.NoCon(Server.UrlDecode(Base.Fun.Fetch.getpost("TableName")));
            Url = Base.Fun.fun.NoCon(Server.UrlDecode(Base.Fun.Fetch.getpost("SUrl")));
            Stime = Base.Fun.Fetch.getpost("Stime");
            Etime = Base.Fun.Fetch.getpost("Etime");
            StimeH = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("StimeH"));
            EtimeH = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("EtimeH"));
            if (action.Equals("view"))
            {
                AutoTaskPlay = Base.Fun.fun.getapp("AutoTimePlay");
                for (int i = 0; i <= 23; i++)
                {
                    strHour.Append("<option value=\"" + i.ToString() + "\">" + i.ToString() + "</option>");
                }
            }
        }
    }
}