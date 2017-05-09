using System;

public partial class Mobile_MessageBuy_Modi : Web.UI.Permissions
{
    protected string action = "";
    protected Web.Model.Mobile.MessageBuy mbModel = new Web.Model.Mobile.MessageBuy();
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.Mobile.MessageBuy mbDAL = new Web.DAL.Mobile.MessageBuy();
            mbModel = mbDAL.Read(StoresID, id);
            if (mbModel.id.Equals(id))
            {
                if (action.Equals("save"))
                {
                    if (!mbModel.status.Equals("1"))
                    {
                        mbModel.status = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("status"));
                        mbModel.statuscontent = Base.Fun.Fetch.getpost("statuscontent");
                        int icount = mbDAL.Update(StoresID, id, mbModel.status, mbModel.statuscontent);
                        if (icount > 0)
                        {
                            if (mbModel.status.Equals("1"))
                            {
                                Web.UI.Mobile.MessageBuy.AddMessageNum(StoresID, mbModel.SetupID);
                            }
                            Base.Log.Log.Add(2, "Mobile_MessageBuy", id);
                            SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "购买申请状态修改成功。");
                            Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("MessageBuyGrid", id, true));
                        }
                        else
                        {
                            SyCms.Window.WindowsReturn.WindowsReturnAlert("购买申请状态修改失败。");
                        }
                    }
                    else
                    {
                        SyCms.Window.WindowsReturn.WindowsReturnAlert("已为通过状态不能再修改。");
                    }
                    Response.End();
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("未找到相关记录");
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