using System;

public partial class Mobile_MessageSetup_Modi : Web.UI.Permissions
{
    protected string action = "";
    protected Web.Model.Mobile.MessageSetup msModel = new Web.Model.Mobile.MessageSetup();
    protected void Page_Load(object sender, EventArgs e)
    {
        action = Base.Fun.Fetch.getpost("action");
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.Mobile.MessageSetup msDAL = new Web.DAL.Mobile.MessageSetup();
            msModel = msDAL.Read(id);
            if (msModel.id.Equals(id))
            {
                if (action.Equals("save"))
                {
                    msModel.title = Base.Fun.Fetch.getpost("title");
                    msModel.num = Base.Fun.Fetch.getpost("num");
                    if (Base.Fun.fun.pnumeric(msModel.num))
                    {
                        msModel.price = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("price"));
                        int icount = msDAL.Update(msModel);
                        if (icount>0)
                        {
                            Base.Log.Log.Add(2, "Mobile_MessageSetup", id);
                            SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "短信套餐修改成功。");
                            Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("MessageSetupGrid", id, true));
                        }
                        else
                        {
                            SyCms.Window.WindowsReturn.WindowsReturnAlert("短信套餐修改失败。");
                        }
                    }
                    else
                    {
                        SyCms.Window.WindowsReturn.WindowsReturnAlert("短信数量必须大于1");
                    }
                    Response.End();
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("未找到套餐信息");
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