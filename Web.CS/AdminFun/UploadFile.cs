using System;
using HelpSoft;
using System.IO;
using System.Web;
namespace Web.CS.AdminFun
{
    public partial class UploadFile : System.Web.UI.Page
    {
        protected string ObjName = "", FileExt = "", FileSize = "", FileType = "", Listid = "", Classid = "", IsStyle = "", UpMessage = "", IsFun = "", InputValue = "", FunPara = "";
        protected string IsFullPath = "";
        private string _uploadID = string.Empty;
        protected string UploadFileType = "flash";
        protected string cookiesname = "";
        public string UploadID
        {
            get
            {
                return this._uploadID;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string cookies = Base.Fun.Fetch.post("cookies");
            cookies = Server.UrlDecode(cookies);
            if (Web.UI.Users.CheckLogin() || (cookies.Length > 0 && Web.UI.Ami.NoUserSessionGetStringBool(cookies)))
            {
                try
                {
                    ObjName = Server.UrlDecode(Base.Fun.Fetch.getpost("ObjName"));
                    IsFullPath = Base.Fun.Fetch.getpost("IsFullPath");
                    string OriginalName = Base.Fun.Fetch.getpost("OriginalName");
                    Listid = Base.Fun.Fetch.getpost("Listid");
                    Classid = Base.Fun.Fetch.getpost("Classid");
                    IsStyle = Base.Fun.Fetch.getpost("IsStyle");
                    UpMessage = Base.Fun.Fetch.getpost("UpMessage");
                    IsFun = Base.Fun.Fetch.getpost("IsFun");
                    FunPara = Base.Fun.Fetch.getpost("FunPara");
                    InputValue = Base.Fun.Fetch.getpost("InputValue");
                    string UrlFileSize = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("FileSize"));
                    string UrlFileType = Base.Fun.Fetch.getpost("FileExt");
                    string syscutpic = Server.UrlDecode(Base.Fun.Fetch.getpost("syscutpic"));
                    if (ObjName.Length > 0)
                    {
                        string action = Base.Fun.Fetch.getpost("action");
                        FileType = Base.Fun.Fetch.getpost("Type");
                        string UploadPath = "";
                        string RealPath = Base.Fun.Management.RealDirectory();
                        Web.UI.FileUpExt.FileExtString(ref FileType, ref FileSize);
                        FileExt = FileType;
                        UploadPath = Web.UI.Sys.SiteInfo.UpFile;
                        string fpath = RealPath + UploadPath;
                        fpath = fpath.Replace(@"\/", @"/");

                        if (Base.Fun.fun.pnumeric(UrlFileSize))
                        {
                            FileSize = UrlFileSize;
                        }
                        if (UrlFileType.Length > 0)
                        {
                            FileExt = UrlFileType;
                        }

                        if (action.Equals("CreateFile"))
                        {
                            if (InputValue.Equals(Base.Fun.Md5.MD5(ObjName + "-" + Listid + "-" + Classid + "-" + IsStyle + "-" + UpMessage)))
                            {
                                string syscutpic_type = "";
                                string syscutpic_logo = "";
                                string syscutpic_width = "";
                                string syscutpic_height = "";
                                if (syscutpic.Length > 0)
                                {
                                    string[] syscutpicStr = syscutpic.Split('|');
                                    syscutpic_type = syscutpicStr[0];
                                    syscutpic_logo = syscutpicStr[1];
                                    syscutpic_width = syscutpicStr[2];
                                    syscutpic_height = syscutpicStr[3];
                                }
                                if (UploadFileType.Equals("flash"))
                                {
                                    HttpPostedFile file = Request.Files["Filedata"];
                                    if (file != null)
                                    {
                                        string FileName = file.FileName;
                                        string[] FileName1 = FileName.Split('\\');
                                        FileName = FileName1[FileName1.Length - 1];
                                        string FilenameExt = Base.IO.File.FileExt(FileName);
                                        if (!("|" + FileExt + "|").ToLower().Contains("|" + FilenameExt.ToLower() + "|"))
                                        {
                                            Response.Write("0");
                                        }
                                        else
                                        {
                                            string saveFileNameUrl = "";
                                            string saveFileName = "";
                                            GetFileName(OriginalName, UploadPath, FileName, FilenameExt, ref saveFileNameUrl, ref saveFileName);
                                            file.SaveAs(saveFileNameUrl);
                                            Response.Write(saveFileName);
                                        }
                                    }
                                }
                                else
                                {
                                    string uploadID = Base.Fun.Fetch.post("UploadID");
                                    UploadContext context1 = UploadContextFactory.GetUploadContext(uploadID);
                                    if (context1 != null)
                                    {
                                        if (context1.Status == uploadStatus.Complete)
                                        {
                                            int FileCount = context1.TotalLength;
                                            string FileName = context1.CurrentFile;
                                            string[] FileName1 = FileName.Split('\\');
                                            FileName = FileName1[FileName1.Length - 1];
                                            string FilenameExt = Base.IO.File.FileExt(FileName);
                                            if (!("|" + FileExt + "|").ToLower().Contains("|" + FilenameExt.ToLower() + "|"))
                                            {
                                                UploadContext context = UploadContextFactory.InitUploadContext(this, fpath);
                                                Response.Write("<script type=\"text/javascript\">parent.Dialog.error('文件类型不正确。');parent.UploadFileCancel('" + uploadID + "');parent.document.getElementById(\"UploadID\").value=\"" + context.GUID + "\";</script>");
                                            }
                                            else if (FileCount > long.Parse(FileSize))
                                            {
                                                UploadContext context = UploadContextFactory.InitUploadContext(this, fpath);
                                                Response.Write("<script type=\"text/javascript\">parent.Dialog.error('文件过大。');parent.UploadFileCancel('" + uploadID + "');parent.document.getElementById(\"UploadID\").value=\"" + context.GUID + "\";</script>");
                                            }
                                            else
                                            {
                                                string saveFileNameUrl = "";
                                                string saveFileName = "";
                                                GetFileName(OriginalName, UploadPath, FileName, FilenameExt, ref saveFileNameUrl, ref saveFileName);
                                                context1.SaveFile("file1", saveFileNameUrl);
                                                Response.Write("<script type=\"text/javascript\">parent.UploadFileOk('" + ObjName + "','" + saveFileName + "',null,'" + IsFun + "','" + FunPara + "','');</script>");
                                            }
                                        }
                                        else
                                        {
                                            Response.Write("<script type=\"text/javascript\">parent.Dialog.error('" + context1.FormatStatus + "');parent.UploadFileCancel('" + uploadID + "');</script>");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (UploadFileType.Equals("flash"))
                                {
                                    Response.Write("0");
                                }
                                else
                                {
                                    Response.Write("<script type=\"text/javascript\">parent.Dialog.error('上传校验未通过。');parent.UploadFileCancel('');</script>");
                                }
                            }
                            Response.End();
                        }
                        else
                        {
                            InputValue = Base.Fun.Md5.MD5(ObjName + "-" + Listid + "-" + Classid + "-" + IsStyle + "-" + UpMessage);
                            if (!Directory.Exists(fpath))
                                Directory.CreateDirectory(fpath);
                            if (!UploadFileType.Equals("flash"))
                            {
                                UploadContext context = UploadContextFactory.InitUploadContext(this, fpath);
                                this._uploadID = context.GUID;
                            }
                            else
                            {
                                cookiesname = Web.UI.Ami.NoUserSessionSetString(Web.UI.Users.GetUserInfo().UserID, Web.UI.Sys.SiteInfo.VerSion);
                                FileExt = ("|" + FileExt.Trim('|')).Replace("|", ";*.").TrimStart(';');
                            }
                        }
                    }
                    else
                    {
                        Response.End();
                    }
                }
                catch (Exception ex)
                {
                    Base.Error.Error.WriteError(ex);
                }
            }
            else {
                Response.End();
            }
        }
        /// <summary>
        /// 获得文件名
        /// </summary>
        /// <param name="OriginalName"></param>
        /// <param name="UploadPath"></param>
        /// <param name="FileName"></param>
        /// <param name="FilenameExt"></param>
        private void GetFileName(string OriginalName, string UploadPath, string FileName, string FilenameExt, ref string saveFileNameUrl, ref string saveFileName)
        {
            saveFileName = "";
            if (Base.Fun.fun.pnumeric(Listid) || IsStyle.Equals("1"))
            {
                saveFileName = UploadPath + "/" + FileName.Split('.')[0] + "." + FilenameExt;
            }
            else
            {
                if (OriginalName.Equals("1"))
                {
                    saveFileName = Base.UpFiles.UpFiles.FileUploadPath(UploadPath, FilenameExt);
                    saveFileName = saveFileName.Substring(0, saveFileName.LastIndexOf("/")) + "/" + FileName.Split('.')[0] + "." + FilenameExt;
                }
                else
                {
                    saveFileName = Base.UpFiles.UpFiles.FileUploadPath(UploadPath, FilenameExt);
                }
            }
            string TruePath = Base.Fun.Management.RealDirectory();
            saveFileNameUrl = TruePath + saveFileName;
            Base.IO.Dir.CheckDir(Base.IO.Dir.ReMoveFileName(saveFileNameUrl));
        }
    }
}