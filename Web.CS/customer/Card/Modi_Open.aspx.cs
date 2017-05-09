using System;

public partial class customer_Card_Modi_Open : Web.UI.Permissions
{
    protected string action = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.Model.customer.Card cModel = new Web.Model.customer.Card();
            Web.DAL.customer.Card cDAL = new Web.DAL.customer.Card();
            cModel = cDAL.Read(id);
            if (cModel.cardid.Equals(id))
            {
                if (cModel.cardstatus.Equals("-1"))
                {
                    string endtime = cDAL.Update_Open(id, cModel.stoptime, cModel.endtime);
                    Base.Log.Log.Add(2, "customer_Card", id);
                    Web.Model.customer.CardLog clModel = new Web.Model.customer.CardLog();
                    clModel.storesid = StoresID;
                    clModel.cardid = id;
                    clModel.cardlogtype = "5";
                    clModel.oldendtime = cModel.endtime;
                    clModel.newendtime = endtime;
                    clModel.opentime = DateTime.Now.ToString("yyyy-MM-dd");
                    Web.UI.customer.CardLog.AddCardLog(clModel);
                    SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "重开卡成功");
                    Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("CardGrid", id, true));
                }
                else
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert("没有停卡，不需要重开卡。");
                }
            }
        }
        Response.End();
    }
}