using System;
namespace Web.CS.Manager.Roles
{
    public partial class Operate : Web.UI.Permissions
    {
        public string roleid = "";
        public string action = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            roleid = Base.Fun.Fetch.getpost("id");
            action = Base.Fun.Fetch.getpost("action");
            if (Base.Fun.fun.pnumeric(roleid))
            {
                if (action.Equals("save"))
                {
                    string chk_3 = Base.Fun.Fetch.post("chk_3");
                    if (!String.IsNullOrEmpty(chk_3))///获取的文件不为空的时候
                    {
                        Response.Write(Web.UI.FilePermissions.Update(roleid, chk_3));
                    }
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("错误：参数传递错误。");
                Response.End();
            }
        }
    }
}