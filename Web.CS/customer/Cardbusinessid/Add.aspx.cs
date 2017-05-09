using System;

public partial class customer_Cardbusinessid_Add : Web.UI.Permissions
{
    protected string action = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        if (action.Equals("save"))
        {
            Web.Model.customer.Cardbusinessid cbModel = new Web.Model.customer.Cardbusinessid();
            cbModel.title = Base.Fun.Fetch.getpost("title");
            cbModel.storesid = StoresID;
            Web.DAL.customer.Cardbusinessid cbDAL = new Web.DAL.customer.Cardbusinessid();
            string id = cbDAL.Insert(cbModel);
            if (Base.Fun.fun.pnumeric(id))
            {
                Base.Log.Log.Add(1, "customer_Cardbusinessid", id);
                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "业务类型添加成功。");
                string idname = Base.Fun.Fetch.getpost("idname");
                if (idname.Length > 0)
                {
                    Response.Write("<script type=\"text/javascript\">$('#" + idname + "').html(\"" + Base.Fun.JScript.htmltojavascriptNoD(Web.UI.customer.Cardbusinessid.GetOption(StoresID, id)) + "\").trigger(\"chosen:updated\");</script>");
                }
                else
                {
                    Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("CardbusinessidGrid", id, true));
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("业务类型添加失败。");
            }
            Response.End();
        }
    }
}