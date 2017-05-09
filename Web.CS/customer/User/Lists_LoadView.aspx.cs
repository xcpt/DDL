using System;

public partial class customer_User_Lists_LoadView : Web.UI.Permissions
{
    protected Web.Model.customer.User uModel = new Web.Model.customer.User();
    protected bool UserappointmentIsAdd = false;
    protected bool UserConsumptionIsAdd = false;
    protected bool exchangeIsAdd = false;
    protected bool UserappointmentIsList = false;
    protected bool UserConsumptionIsList = false;
    protected string np = "0", nn = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        string cardNo = Base.Fun.Fetch.getpost("cardNo");
        if (cardNo.Length>0)
        {
            Web.DAL.customer.User uDAL = new Web.DAL.customer.User();
            if (Web.UI.Sys.stores.ReadOutlets(StoresID))
            {
                uModel = uDAL.Read_CardNo_Outlets(cardNo);
            }
            else
            {
                uModel = uDAL.Read_CardNo(StoresID, cardNo);
            }
            if (!Base.Fun.fun.pnumeric(uModel.userid))
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("未找到会员信息");
                Response.End();
            }
            else
            {
                Web.DAL.customer.User_Stores usDAL = new Web.DAL.customer.User_Stores();
                usDAL.ReadNum(StoresID, uModel.userid, ref np, ref nn);
                Web.DAL.customer.Card cDAL = new Web.DAL.customer.Card();
                uModel.cModel = cDAL.Read(uModel.cardid);

                UserappointmentIsAdd = Web.UI.Users.CheckPermission("/customer/Userappointment/Add.aspx", 4);
                UserConsumptionIsAdd = Web.UI.Users.CheckPermission("/customer/UserConsumption/Add.aspx", 4);
                UserappointmentIsList = Web.UI.Users.CheckPermission("/customer/Userappointment/Lists.aspx", 1);
                exchangeIsAdd = Web.UI.Users.CheckPermission("/score/exchange/Add.aspx", 4);
                UserConsumptionIsList = Web.UI.Users.CheckPermission("/customer/UserConsumption/Lists.aspx", 1);
            }
        }
        else
        {
            SyCms.Window.WindowsReturn.WindowsReturnAlert("参数传递错误");
            Response.End();
        }
    }
}