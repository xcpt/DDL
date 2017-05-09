<%@ WebHandler Language="C#" Class="UploadHandler" %>

using System;
using System.Web;

public class UploadHandler : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        if (Base.Fun.fun.ispost())
        {
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";
            string cookies = Base.Fun.Fetch.post("cookies");
            if (cookies.Length > 0)
            {
                cookies = HttpUtility.UrlDecode(HttpUtility.UrlDecode(cookies));
                if (Web.UI.Ami.NoUserSessionGetStringBool(cookies))
                {
                    HttpPostedFile file = context.Request.Files["Filedata"];
                    string Listid = Base.Fun.Fetch.post("ListID");
                    string IsType = Base.Fun.Fetch.post("IsType");
                    string IsStyle = Base.Fun.Fetch.post("IsStyle");
                    string Path = Base.Fun.Fetch.post("Path");
                    string UploadPath = Base.Fun.Fetch.post("UploadPath");
                    string IsDir = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("IsDir"));
                    string syscutpic = Base.Fun.Fetch.post("syscutpic");
                    if (string.IsNullOrEmpty(UploadPath))
                    {

                        UploadPath = Web.UI.Sys.SiteInfo.UpFile;
                        if (UploadPath.Length == 0)
                        {
                            UploadPath = "UpLoadFile";
                        }
                    }
                        UploadPath = UploadPath.Replace("\\", "/");
                        UploadPath = "/" + UploadPath.TrimStart('/');
                    if (file != null)
                    {
                        string FileExt = Base.IO.File.FileExt(file.FileName);
                        if (Web.UI.FileUpExt.FileExt.Contains("|" + FileExt + "|"))
                        {
                            string FileName = "";
                            if (IsType.Equals("1"))
                            {
                                if (IsDir.Equals("1"))
                                {
                                    FileName = Base.UpFiles.UpFiles.FileUploadPath(UploadPath + Path, FileExt, 1);
                                    FileName = FileName.Substring(0, FileName.LastIndexOf("/")) + "/" + file.FileName;
                                }
                                else
                                {
                                    FileName = UploadPath + Path + "/" + file.FileName;
                                }
                            }
                            else
                            {
                                FileName = Base.UpFiles.UpFiles.FileUploadPath(UploadPath + Path, FileExt, int.Parse(IsDir));
                            }
                            FileName = FileName.Replace("//", "/");
                            string TruePath = Base.Fun.Management.RealDirectory();
                            //Web.UI.File.DelFile(picfun.picfun.DelFile(TruePath, FileName));
                            Base.IO.Dir.CheckDir(Base.IO.Dir.ReMoveFileName(FileName));
                            file.SaveAs(TruePath + FileName);
                            context.Response.Write(FileName);
                        }
                        else
                        {
                            context.Response.Write("0");
                        }
                    }
                    else
                    {
                        context.Response.Write("0");
                    }
                }
                else
                {
                    context.Response.Write("0");
                }
            }
            else
            {
                context.Response.Write("0");
            }
        }
        else
        {
            context.Response.Write("0");
        }
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}