using System;
namespace Web.CS.Manager.MenuClass
{
    public partial class Operate : Web.UI.Permissions
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ID = Base.Fun.Fetch.post("ID");
            if (Base.Fun.fun.pnumeric(ID))
            {
                Web.UI.MenuClass Mclass = new Web.UI.MenuClass();
                string str = Mclass.SetShow(ID);
                if (str.Length > 0)
                {
                    Response.Write(str);
                }
                else
                {
                    Response.Write("['0','错误：修改锁定状态失败。']");
                }
            }
            Response.End();
        }
    }
}