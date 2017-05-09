using System;

public partial class baby_album_Add : Web.UI.Permissions
{
    protected string userid = "";
    protected string action = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        userid = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("id").Trim(','));
        action=Base.Fun.Fetch.getpost("action");
        string monthage = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("monthage"));
        string addtime = Base.Fun.Fetch.getpost("addtime");
        if (action.Equals("save"))
        {
            if (Base.Fun.fun.pnumeric(userid))
            {
                Response.Write("<script type=\"text/javascript\">");

                string PassWord = Web.UI.Users.ViewPass(UserID);
                string cookiesname = Base.Fun.fun.GetRealIP() + "_" + UserID + "_" + PassWord + "_" + Web.UI.Sys.SiteInfo.VerSion + "_" + DateTime.Now.ToString();
                cookiesname = Base.Fun.Zip.Compress(cookiesname);
                cookiesname = Server.UrlEncode(Server.UrlEncode(cookiesname));
                string FileExt = "pic";
                string FileSize = "";
                Web.UI.FileUpExt.FileExtString(ref FileExt, ref FileSize);
                Response.Write(@"SyCmsFileUploadWin(""上传照片"", { ""cookies"": """ + cookiesname + @""", ""IsDir"": 1 }, """", function (urldata,CreateWindowdiag) {
        AjaxFun('baby/album/add.aspx','action=upfile&id=" + userid + "&monthage=" + monthage + "&addtime=" + Server.UrlEncode(addtime) + @"&fileurl='+urldata.join('|'));
CreateWindowdiag.close();
    }, null,'*." + string.Join(";*.", FileExt.Trim('|').Split('|')) + @"','" + FileSize + "');");
                Response.Write("</script>");
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("会员没有选择");
            }
            Response.End();
        }
        else if (action.Equals("upfile"))
        {
            if (Base.Fun.fun.pnumeric(userid))
            {
                string url = Base.Fun.Fetch.getpost("fileurl");
                if (url.Length > 0)
                {
                    Web.Model.baby.album aModel = new Web.Model.baby.album();
                    Web.DAL.baby.album aDAL = new Web.DAL.baby.album();
                    aModel.addtime = addtime;
                    aModel.monthage = monthage;
                    aModel.UserID = userid;
                    string[] urlA = url.Split('|');
                    string userface = "";
                    string urlpath = "";
                    string PicWidth = "";
                    string PicHeight = "";
                    string PicCut = "CEN"; 
                    string TruePath = Server.MapPath("~/");
                    foreach (string url1 in urlA)
                    {
                        //切图
                        urlpath = url1.Split(',')[0];
                        int[] PicWidthHeight = picfun.picfun.FileWidthHeight(TruePath + urlpath);
                        PicWidth = PicWidthHeight[0].ToString();
                        PicHeight = PicWidthHeight[1].ToString();
                        urlpath = picfun.GetSrc.HtmlSrcUrl(TruePath, urlpath, PicWidth, PicHeight, PicCut, true);
                        //切图结束
                        aModel.picurl = urlpath;
                        userface = aModel.picurl;
                        aDAL.Insert(aModel);
                    }
                    string Num = aDAL.Read_PhotoNum(userid);
                    Web.DAL.customer.User uDAL = new Web.DAL.customer.User();
                    Web.Model.customer.User uModel = uDAL.Read(userid);
                    if (uModel.userface.Length == 0)
                    {
                        uDAL.Update_UserFaceAndPhotoNum(userid, userface, Num);
                    }
                    else
                    {
                        uDAL.Update_UserFaceAndPhotoNum(userid, uModel.userface, Num);
                    }
                    Base.Log.Log.Add(1, "baby_album", userid);
                    SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "成长相册添加成功。");
                    Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("UserGrid", userid, true));
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("会员没有选择");
            }
            Response.End();
        }
    }
}