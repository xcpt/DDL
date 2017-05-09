using System;
using System.Text;

namespace Web.CS
{
    public partial class UserMess : System.Web.UI.Page
    {
        protected string userName = "", groupName = "";
        protected StringBuilder createCate = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Base.Fun.fun.IsSelfRefer() || !Base.Fun.fun.ispost())
            {
                Response.End();
            }
            if (Web.UI.Users.CheckLogin())
            {
                Web.Model.UserLogin userInfo = Web.UI.Users.GetUserInfo();
                userName = userInfo.UserName;
                groupName = Web.UI.Users.GetGroupName(userInfo.RoleID);
                if (Base.Fun.fun.pnumeric(userInfo.StoresID))
                {
                    string title = Web.UI.Sys.stores.GetStoresName(userInfo.StoresID);
                    if (title.Length > 0)
                    {
                        if (userInfo.RoleID.Equals("1"))
                        {
                            createCate.Append("<select onchange=\"AjaxFun('Sys/Stores/Select.aspx','id='+$(this).val(),'更换当前门店')\">" + Web.UI.Sys.stores.GetOption(userInfo.StoresID) + "</select>");
                        }
                        else
                        {
                            createCate.Append("【" + title + "】");
                        }
                    }
                    else
                    {
                        createCate.Append("<select onchange=\"AjaxFun('Sys/Stores/Select.aspx','id='+$(this).val(),'更换当前门店')\"><option value=\"0\"></option>" + Web.UI.Sys.stores.GetOption(userInfo.StoresID) + "</select>");
                    }
                }
                else if (userInfo.RoleID.Equals("1"))
                {
                    createCate.Append("【没有门店，请先添加】");
                }
                else
                {
                    createCate.Append("【你没有所属门店】");
                }
            }
            else
            {
                Response.Write("['-1']");
                Response.End();
            }
        }
    }
}
