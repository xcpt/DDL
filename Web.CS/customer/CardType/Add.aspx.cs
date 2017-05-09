using System;

public partial class customer_CardType_Add : Web.UI.Permissions
{
    protected string action = "";
    protected bool businessidIsAdd = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        if (action.Equals("save"))
        {
            Web.Model.customer.CardType ctModel = new Web.Model.customer.CardType();
            ctModel.storesid = StoresID;
            ctModel.title = Base.Fun.Fetch.getpost("title");
            ctModel.effectivetime = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("effectivetime"));
            ctModel.businessid = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("businessid"));
            ctModel.paidmode = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("paidmode"));
            ctModel.positivenum = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("positivenum"));
            ctModel.negativenum = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("negativenum"));
            ctModel.price = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("price"));
            ctModel.content = Base.Fun.Fetch.getpost("content");
            ctModel.opencardexchange = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("opencardexchange"));
            ctModel.discount = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("discount"));
            Web.DAL.customer.CardType ctDAL = new Web.DAL.customer.CardType();
            string ID = ctDAL.Insert(ctModel);
            if (Base.Fun.fun.pnumeric(ID))
            {
                Base.Log.Log.Add(1, "customer_CardType", ID);
                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "会员卡类型添加成功。");
                string idname = Base.Fun.Fetch.getpost("idname");
                if (idname.Length > 0)
                {
                    Response.Write("<script type=\"text/javascript\">$('#" + idname + "').html(\"" + Base.Fun.JScript.htmltojavascriptNoD(Web.UI.customer.CardType.GetOption(StoresID, ID)) + "\").trigger(\"chosen:updated\");</script>");
                }
                else
                {
                    Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("CardTypeGrid", ID, true));
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("会员卡类型添加失败。");
            }
            Response.End();
        }
        else
        {
            businessidIsAdd = Web.UI.Users.CheckPermission("/customer/Cardbusinessid/Add.aspx", 4);
        }
    }
}