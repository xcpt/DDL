using System;
namespace Web.CS.Manager.Log
{
    public partial class Del : Web.UI.Permissions
    {
        protected string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Base.Fun.Fetch.getpost("action");
            if (action.Equals("del"))
            {
                if (Base.Log.Log.DelLog())
                {
                    Web.UI.Ami.Message(1, "删除成功！");
                }
                else
                {
                    Web.UI.Ami.Message(0, "删除失败！");
                }
            }
            else if (action.Equals("all"))
            {
                if (Base.Log.Log.DelAllLog())
                {
                    Web.UI.Ami.Message(1, "删除成功！");
                }
                else
                {
                    Web.UI.Ami.Message(0, "删除失败！");
                }
            }
            else
            {
                id = Base.Fun.Fetch.getpost("id");
                string FileName = Base.Fun.Fetch.getpost("FileName");
                if (Base.Fun.fun.pnumeric(id.Replace(",", "")))
                {
                    bool isSucc = Base.Log.Log.DelLog(id);
                    if (isSucc)
                    {
                        Web.UI.Ami.Message(1, "删除成功！");
                    }
                    else
                    {
                        Web.UI.Ami.Message(0, "删除失败！");
                    }
                }
                else if (FileName.Length > 0)
                {
                    Base.IO.File.DelFileNoDir(Base.Fun.Management.RealDirectory() + "Log/Error/" + FileName);
                }
            }
        }
    }
}