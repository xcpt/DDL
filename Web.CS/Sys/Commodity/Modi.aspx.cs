using System;

public partial class Sys_Commodity_Modi : Web.UI.Permissions
{
    protected string action = "";
    protected Web.Model.Sys.Commodity cModel = new Web.Model.Sys.Commodity();
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.Sys.Commodity cDAL = new Web.DAL.Sys.Commodity();
            cModel = cDAL.Read(StoresID, id);
            if (cModel.id.Equals(id))
            {
                action = Base.Fun.Fetch.getpost("action");
                if (action.Equals("save"))
                {
                    cModel.title = Base.Fun.Fetch.post("title");
                    cModel.price = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("price"));
                    cModel.iscard = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("iscard"));
                    cModel.score = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("score"));
                    cModel.isdel = "0";
                    int icout = cDAL.Update(cModel);
                    if (icout>0)
                    {
                        Base.Log.Log.Add(2, "Sys_Commodity", id);
                        SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "商品修改成功。");
                        Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("CommodityGrid", id, true));
                    }
                    else
                    {
                        SyCms.Window.WindowsReturn.WindowsReturnAlert("商品修改失败。");
                    }
                    Response.End();
                }
            }
            else {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("错误：未找到商品信息。");
                Response.End();
            }
        }
        else {
            SyCms.Window.WindowsReturn.WindowsReturnAlert("错误：参数传递错误。");
            Response.End();
        }
    }
}