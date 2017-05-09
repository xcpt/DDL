using System;

public partial class customer_Card_Modi_Stop : Web.UI.Permissions
{
    protected string action = "";
    protected Web.Model.customer.Card cModel = new Web.Model.customer.Card();
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.customer.Card cDAL = new Web.DAL.customer.Card();
            cModel = cDAL.Read(id);
            if (cModel.cardid.Equals(id))
            {
                if (action.Equals("save"))
                {
                    string stoptime = DateTime.Now.ToString("yyyy-MM-dd");//Base.Fun.Fetch.getpost("stoptime");
                    if(Base.Fun.fun.IsDate(stoptime))
                    {
                        if (cDAL.Update_StopCard(id, stoptime, cModel.endtime) > 0)
                        {
                            Base.Log.Log.Add(2, "customer_Card", id);
                            Web.Model.customer.CardLog clModel = new Web.Model.customer.CardLog();
                            clModel.storesid = StoresID;
                            clModel.cardid = id;
                            clModel.cardlogtype = "4";
                            clModel.opentime = stoptime;
                            Web.UI.customer.CardLog.AddCardLog(clModel);
                            SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "停卡成功，停卡至：" + stoptime, true);
                            Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("CardGrid", id, true));
                        }
                        else
                        {
                            SyCms.Window.WindowsReturn.WindowsReturnAlert("停卡失败");
                        }
                    }
                    Response.End();
                }
                else
                {
                    if (cModel.cardstatus.Equals("-1"))
                    {
                        SyCms.Window.WindowsReturn.WindowsReturnAlert("此卡已停，不需要重复停卡。");
                        Response.End();
                    }
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("会员卡项错误");
                Response.End();
            }
        }
        else
        {
            SyCms.Window.WindowsReturn.WindowsReturnAlert("参数传递错误");
            Response.End();
        }
    }
}