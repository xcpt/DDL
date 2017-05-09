using System;

public partial class Mobile_MessageBuy_Add : Web.UI.Permissions
{
    protected string action = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        if (action.Equals("save"))
        {
            Web.Model.Mobile.MessageBuy mbModel = new Web.Model.Mobile.MessageBuy();
            mbModel.storesid = StoresID;
            mbModel.addtime = DateTime.Now.ToString();
            mbModel.status = "0";
            mbModel.SetupID = Base.Fun.Fetch.post("setupid");
            if (Base.Fun.fun.pnumeric(mbModel.SetupID))
            {
                mbModel.content = Base.Fun.Fetch.getpost("content");
                Web.DAL.Mobile.MessageBuy mbDAL = new Web.DAL.Mobile.MessageBuy();
                string id = mbDAL.Insert(mbModel);
                if (Base.Fun.fun.pnumeric(id))
                {
                    Base.Log.Log.Add(1, "Mobile_MessageBuy", id);
                    SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "购买申请添加成功。");
                    Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("MessageBuyGrid", id, true));
                }
                else
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert("购买申请添加失败。");
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("错误：套餐必须选择。");
            }
            Response.End();
        }
    }
}