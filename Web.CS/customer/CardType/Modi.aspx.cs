using System;

public partial class customer_CardType_Modi : Web.UI.Permissions
{
    protected string action = "";
    protected bool businessidIsAdd = false;
    protected Web.Model.customer.CardType ctModel = new Web.Model.customer.CardType();
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.customer.CardType ctDAL = new Web.DAL.customer.CardType();
            ctModel = ctDAL.Read(id);
            if (ctModel.id.Equals(id))
            {
                if (action.Equals("save"))
                {
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
                    int icount = ctDAL.Update(ctModel);
                    if (icount>0)
                    {
                        Base.Log.Log.Add(2, "customer_CardType", id);
                        SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "会员卡类型修改成功。");
                        Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("CardTypeGrid", ID, true));
                    }
                    else
                    {
                        SyCms.Window.WindowsReturn.WindowsReturnAlert("会员卡类型修改失败。");
                    }
                    Response.End();
                }
                else
                {
                    businessidIsAdd = Web.UI.Users.CheckPermission("/customer/Cardbusinessid/Add.aspx", 4);
                }
            }
            else {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("未找到相关记录");
                Response.End();
            }
        }
        else {
            SyCms.Window.WindowsReturn.WindowsReturnAlert("参数传递错误");
            Response.End();
        }
    }
}