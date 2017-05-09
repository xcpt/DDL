using System;
namespace Web.CS.AdminFun
{
    public partial class DownFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Base.Fun.fun.IsSelfRefer())
            {
                if (Web.UI.Users.CheckLogin())
                {
                    string fileUrl = Base.Fun.Fetch.getpost("FileName");
                    string SaveFileName = Base.Fun.Fetch.getpost("SaveFileName");
                    if (fileUrl.Length > 0 && (fileUrl.Contains(":/") || fileUrl.Contains(":\\")))
                    {
                        string Filename = SaveFileName;
                        if (Filename.Length == 0)
                        {
                            Filename = Base.IO.File.GetFileName(fileUrl);
                        }
                        Base.IO.File.DownFile(fileUrl, Filename);
                    }
                }
            }
            Response.End();
        }
    }
}