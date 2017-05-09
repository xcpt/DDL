using System;

public partial class Mobile_MessageTemplate_Lists_Read : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.Model.UserLogin ulModel = Web.UI.Users.GetUserInfo();
            if (Base.Fun.fun.pnumeric(ulModel.UserID))
            {
                Web.DAL.Mobile.MessageTemplate mtDAL = new Web.DAL.Mobile.MessageTemplate();
                Web.Model.Mobile.MessageTemplate mtModel = mtDAL.Read(ulModel.StoresID, id);
                if (mtModel.id.Equals(id))
                {
                    Response.Write("<script type=\"text/javascipt\">$('#MessageLogcontent').val(\"" + Base.Fun.JScript.htmltojavascriptNoD(mtModel.content) + "\");</script>");
                    Response.Write("<script type=\"text/javascipt\">$('#MessageLogtitle').val(\"" + Base.Fun.JScript.htmltojavascriptNoD(mtModel.title) + "\");</script>");
                }
            }
        }
        Response.End();
    }
}