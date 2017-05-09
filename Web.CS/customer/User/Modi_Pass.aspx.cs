using System;

public partial class customer_User_ModiPass : Web.UI.Permissions
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.customer.User uDAL = new Web.DAL.customer.User();
            Web.Model.customer.User uModel = uDAL.Read(StoresID, id);
            if (Base.Fun.fun.pnumeric(uModel.cardid))
            {
                Web.DAL.customer.Card cDAL=new Web.DAL.customer.Card();
                Web.Model.customer.Card cModel = cDAL.Read(uModel.cardid);
                string userpass = cModel.cardNo.Substring(cModel.cardNo.Length - 6);
                if (uDAL.Update_PassWord(id, Base.Fun.Md5.MD5(userpass)) > 0)
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "密码重置成功，密码为：" + userpass, true);
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("无卡用户，暂不能重置密码。");
            }
        }
        Response.End();
    }
}