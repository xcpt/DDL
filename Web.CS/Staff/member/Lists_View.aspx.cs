using System;

public partial class Staff_member_Lists_View : Web.UI.Permissions
{
    protected string action = "";
    protected Web.Model.Staff.member mModel = new Web.Model.Staff.member();
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.Staff.member mDAL = new Web.DAL.Staff.member();
            mModel = mDAL.Read(StoresID, id);
            if (!mModel.id.Equals(id))
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("未找到员工信息");
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