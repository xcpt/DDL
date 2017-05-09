using System;
using System.Text;
namespace Web.CS.Manager.Log
{
    public partial class Lists_Modi : Web.UI.Permissions
    {
        protected string TableName = "", Stime = "", Etime = "", StimeH = "", EtimeH = "";
        protected string Description = "";
        protected string action = "";
        protected StringBuilder strHour = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            action = Base.Fun.Fetch.getpost("action");
            TableName = Base.Fun.Fetch.getpost("TableName");
            Description = Base.Fun.Fetch.getpost("Description");
            if (TableName.Length > 0 && Description.Length > 0)
            {
                Stime = Base.Fun.Fetch.getpost("Stime");
                Etime = Base.Fun.Fetch.getpost("Etime");
                StimeH = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("StimeH"));
                EtimeH = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("EtimeH"));
                if (action.Equals("view"))
                {
                    for (int i = 0; i <= 23; i++)
                    {
                        strHour.Append("<option value=\"" + i.ToString() + "\">" + i.ToString() + "</option>");
                    }
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("参数传递错误。");
                Response.End();
            }
        }
    }
}