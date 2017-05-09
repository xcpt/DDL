using System;

public partial class customer_UserappointmentLog_Modi : Web.UI.Permissions
{
    protected string action = "";
    protected string babytype = "", datetime = "";
    protected string weeknum = "", hoursNum = "", minute = "", allnum = "", appnum = "", pcnum = "", usernum = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        babytype = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("babytype"));
        weeknum = Base.Fun.Fetch.getpost("weeknum");
        if (action.Equals("save"))
        {
            Web.Model.customer.UserappointmentLog ulModel = new Web.Model.customer.UserappointmentLog();
            ulModel.storesid = StoresID;
            ulModel.babytype = babytype;
            ulModel.hoursNum = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("hoursNum"));
            ulModel.minute = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("minute"));
            ulModel.num = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("num"));
            ulModel.weeknum = Base.Fun.fun.IsZero(weeknum);
            ulModel.datetime = Base.Fun.Fetch.getpost("datetime");
            ulModel.datenum = DateTime.Parse(ulModel.datetime).ToString("yyyyMMdd");
            Web.DAL.customer.UserappointmentLog ulDAL = new Web.DAL.customer.UserappointmentLog();
            Web.Model.customer.UserappointmentLog yulModel = ulDAL.Read(StoresID, babytype, ulModel.datenum, ulModel.hoursNum, ulModel.minute);
            if (Base.Fun.fun.pnumeric(yulModel.id))
            {
                if (ulDAL.Update(StoresID, yulModel.id, (int.Parse(yulModel.num) + int.Parse(ulModel.num)).ToString()) > 0)
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "预约数量修改成功。");
                    Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("UserappointmentLogGrid", true));
                }
                else
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert("预约数量修改失败。");
                }
            }
            else
            {
                string id = ulDAL.Insert(ulModel);
                if (Base.Fun.fun.pnumeric(id))
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "预约数量修改成功。");
                    Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("UserappointmentLogGrid", id, true));
                }
                else
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert("预约数量修改失败。");
                }
            }
            Response.End();
        }else{
            string id = Base.Fun.Fetch.getpost("id");
            if (Base.Fun.fun.pnumeric(id))
            {
                Web.DAL.customer.UserappointmentLog ulDAL = new Web.DAL.customer.UserappointmentLog();
                Web.Model.customer.UserappointmentLog ulModel = ulDAL.Read(StoresID, id);
                if (ulModel.id.Equals(id))
                {
                    babytype = ulModel.babytype;
                    datetime = ulModel.datetime;
                    weeknum = ulModel.weeknum;
                    hoursNum = ulModel.hoursNum;
                    minute = ulModel.minute;
                    allnum = ulModel.num;
                    appnum = ulModel.appusernum;
                    pcnum = ulModel.pcusernum;
                    usernum = (int.Parse(ulModel.num) - int.Parse(ulModel.usernum)).ToString();
                }
                else
                {
                    Response.End();
                }
            }
            else
            {
                string timestr = Base.Fun.Fetch.getpost("timestr");
                datetime = Base.Fun.Fetch.getpost("datetime");
                if (Base.Fun.fun.pnumeric(babytype) && datetime.Length>0 && Base.Fun.fun.IsDate(datetime) && Base.Fun.fun.pnumeric(weeknum) && timestr.Length > 0 && timestr.Contains(":"))
                {
                    string[] timestrarr = timestr.Split(':');
                    hoursNum = timestrarr[0];
                    minute = timestrarr[1];

                    Web.DAL.customer.UserappointmentSetup usDAL = new Web.DAL.customer.UserappointmentSetup();
                    Web.Model.customer.UserappointmentSetup usModel = usDAL.Read(StoresID, weeknum, hoursNum, minute, babytype);
                    allnum = usModel.num;
                    appnum = "0";
                    pcnum = "0";
                    usernum = usModel.num;
                }
                else
                {
                    Response.End();
                }
            }
        }
    }
}