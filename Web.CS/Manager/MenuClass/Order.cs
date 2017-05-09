using System;
namespace Web.CS.Manager.MenuClass
{
    public partial class Order : Web.UI.Permissions
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string OrderID_M = Base.Fun.fun.NoCon(Base.Fun.Fetch.post("OrderID_M"));
            string OrderID = Base.Fun.fun.NoCon(Base.Fun.Fetch.post("OrderID"));
            bool IsOrder = false;
            if (!String.IsNullOrEmpty(OrderID_M))
            {
                Web.UI.MenuClass.SetOrder(OrderID_M);
                IsOrder = true;
            }
            if (!String.IsNullOrEmpty(OrderID))
            {
                Web.UI.MenuFiles.SetOrder(OrderID);
            }
            if (IsOrder)
            {
                Response.Write("<script type=\"text/javascript\">AjaxFun('Manager/MenuClass/Lists.aspx', 'action=view', ' ', '.Rnr');</script>");
            }
            Response.End();
        }
    }
}