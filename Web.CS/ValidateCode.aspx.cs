using System;

namespace Web.CS
{
    public partial class ValidateCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Response.ContentType = "image/JPEG";
                Base.VerifyCode.VerifyCode v = new Base.VerifyCode.VerifyCode();
                string code = v.CreateVerifyCode(4);//验证码长度
                v.CreateImageOnPage(code, this.Context);
                Base.Fun.Session.ClearSession("CmsGetCode");
                Session["CmsGetCode"] = code;
                Response.End();
            }
            catch (Exception ex)
            {
                Base.Error.Error.WriteError(ex);
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
