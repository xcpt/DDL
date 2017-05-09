using System;

public partial class customer_Cardbusinessid_Modi : Web.UI.Permissions
{
    protected string action = "";
    protected Web.Model.customer.Cardbusinessid cbModel = new Web.Model.customer.Cardbusinessid();
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.customer.Cardbusinessid cbDAL = new Web.DAL.customer.Cardbusinessid();
            cbModel = cbDAL.Read(StoresID, id);
            if (cbModel.id.Equals(id))
            {
                if (action.Equals("save"))
                {
                    cbModel.title = Base.Fun.Fetch.getpost("title");
                    int icount = cbDAL.Update(cbModel);
                    if (icount>0)
                    {
                        Base.Log.Log.Add(2, "customer_Cardbusinessid", id);
                        SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "业务类型修改成功。");
                        Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("CardbusinessidGrid", id, true));
                    }
                    else
                    {
                        SyCms.Window.WindowsReturn.WindowsReturnAlert("业务类型修改失败。");
                    }
                    Response.End();
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("未找到业务类型信息");
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