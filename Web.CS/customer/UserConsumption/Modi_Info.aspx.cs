using System;

public partial class customer_UserConsumption_Modi_Info : Web.UI.Permissions
{
    protected string action = "";
    protected string id = "";
    protected Web.Model.customer.UserConsumption ucModel = new Web.Model.customer.UserConsumption();
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.customer.UserConsumption ucDAL = new Web.DAL.customer.UserConsumption();
            ucModel = ucDAL.Read(StoresID, id);
            if (ucModel.id.Equals(id))
            {
                if (action.Equals("save"))
                {
                    string CommodityID = Base.Fun.Fetch.getpost("CommodityID");
                    if (Base.Fun.fun.pnumeric(CommodityID))
                    {
                        Web.DAL.Sys.Commodity cDAL = new Web.DAL.Sys.Commodity();
                        Web.Model.Sys.Commodity cModel = cDAL.Read(StoresID, CommodityID);
                        if (cModel.id.Equals(CommodityID))
                        {
                            ucModel.CommodityID = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("CommodityID"));
                            ucModel.content = Base.Fun.Fetch.getpost("content");
                            ucModel.height = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("height"));
                            ucModel.mamasid = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("mamasid"));
                            ucModel.swimteacherid = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("swimteacherid"));
                            ucModel.temperature = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("temperature"));
                            ucModel.timenum = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("timenum"));
                            ucModel.weight = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("weight"));
                            if (ucDAL.Update(ucModel) > 0)
                            {
                                Base.Log.Log.Add(1, "customer_UserConsumption", ucModel.id);
                                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "消费资料修改成功");
                                Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("UserConsumptionGrid", ucModel.id, true));
                            }
                            else
                            {
                                SyCms.Window.WindowsReturn.WindowsReturnAlert("消费修改失败。");
                            }
                        }
                    }
                    else
                    {
                        SyCms.Window.WindowsReturn.WindowsReturnAlert("消费商品必须选择");
                    }
                    Response.End();
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("消费记录未找到");
                Response.End();
            }
        }
    }
}