using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class news_Default : System.Web.UI.Page
{
    protected Web.Model.Sys.News nModel = new Web.Model.Sys.News();
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.Sys.News nDAL = new Web.DAL.Sys.News();
            nModel = nDAL.Read(id);
            if (!nModel.id.Equals(id))
            {
                Response.End();
            }
        }
        else
        {
            Response.End();
        }
    }
}