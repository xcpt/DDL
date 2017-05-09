using System;

public partial class Sys_Commodity_Lists_View : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.Model.UserLogin ulModel = Web.UI.Users.GetUserInfo();
        if (Base.Fun.fun.pnumeric(ulModel.UserID))
        {
            string id = Base.Fun.Fetch.getpost("id");
            Web.DAL.Sys.Commodity cDAL = new Web.DAL.Sys.Commodity();
            Web.Model.Sys.Commodity cModel = new Web.Model.Sys.Commodity();
            cModel = cDAL.Read(ulModel.StoresID, id);
            if (cModel.id.Equals(id))
            {
                Response.Write("消费方式：按会员卡类型。" + (cModel.iscard.Equals("1") ? "可卡次消费，卡次消费时，金额会取单价（填写无用）。" : "卡内金额消费，并按折扣计算。"));
                string idname = Base.Fun.Fetch.getpost("idname");
                if (idname.Length > 0)
                {
                    Response.Write("<script type=\"text/javascript\">$('#" + idname + "').val('" + cModel.price + "');$('#UserConsumptionIsCash').val('" + (cModel.iscard.Equals("1") ? "0" : "1") + "').trigger(\"chosen:updated\");</script>");
                }
            }
        }
        Response.End();
    }
}