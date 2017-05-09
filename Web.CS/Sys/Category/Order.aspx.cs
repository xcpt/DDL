using System;

public partial class Sys_Category_Order :Web.UI.Permissions
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string type = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("type"));
        string orderid = Base.Fun.Fetch.getpost("orderid");
        if (orderid.Length > 0)
        {
            string[] orderArr = orderid.Split(',');
            Web.DAL.Sys.Category cDAL = new Web.DAL.Sys.Category();
            for (int i = 0; i < orderArr.Length; i += 2)
            {
                cDAL.Update_OrderID(orderArr[i], orderArr[i + 1]);
            }
            SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "排序成功");
            Response.Write("<script type=\"text/javascript\">$('#WeiXinMenuListView').html(\"" + Base.Fun.JScript.htmltojavascriptNoD(Web.UI.Sys.Category.ViewHtml(type, IsModi, IsAdd, IsDel)) + "\");$(\".treeTable\").treeTable();$('.treeTable').find('tr.parent').each(function(){$(this).expand();});</script>");
        }
        Response.End();
    }
}