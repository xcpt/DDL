using System;

public partial class Sys_Commodity_Add : Web.UI.Permissions
{
    protected string action = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        if (action.Equals("save"))
        {
            Web.Model.Sys.Commodity cModel = new Web.Model.Sys.Commodity();
            cModel.title = Base.Fun.Fetch.post("title");
            cModel.price = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("price"));
            cModel.iscard = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("iscard"));
            cModel.isdel = "0";
            cModel.score = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("score"));
            cModel.storesid = StoresID;
            cModel.addtime = DateTime.Now.ToString();
            Web.DAL.Sys.Commodity cDAL = new Web.DAL.Sys.Commodity();
            string id = cDAL.Insert(cModel);
            if (Base.Fun.fun.pnumeric(id))
            {
                Base.Log.Log.Add(1, "Sys_Commodity", id);
                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "商品添加成功。");
                Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("CommodityGrid", id, true));
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("商品添加失败。");
            }
            Response.End();
        }
    }
}