using System;

public partial class Mobile_MessageSetup_Add : Web.UI.Permissions
{
    protected string action = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        action = Base.Fun.Fetch.getpost("action");
        if (action.Equals("save"))
        {
            Web.Model.Mobile.MessageSetup msModel = new Web.Model.Mobile.MessageSetup();
            msModel.title = Base.Fun.Fetch.getpost("title");
            msModel.num = Base.Fun.Fetch.getpost("num");
            if (Base.Fun.fun.pnumeric(msModel.num))
            {
                msModel.price = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("price"));
                Web.DAL.Mobile.MessageSetup msDAL = new Web.DAL.Mobile.MessageSetup();
                string id = msDAL.Insert(msModel);
                if (Base.Fun.fun.pnumeric(id))
                {
                    Base.Log.Log.Add(1, "Mobile_MessageSetup", id);
                    SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "短信套餐添加成功。");
                    Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("MessageSetupGrid", id, true));
                }
                else
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert("短信套餐添加失败。");
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("短信数量必须大于1");
            }
            Response.End();
        }
    }
}