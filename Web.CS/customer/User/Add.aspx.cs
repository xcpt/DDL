using System;

public partial class customer_User_Add : Web.UI.Permissions
{
    protected string action = "";
    protected bool communityidIsAdd = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        if (action.Equals("save"))
        {
            Web.DAL.customer.User uDAL = new Web.DAL.customer.User();
            Web.Model.customer.User uModel = new Web.Model.customer.User();
            uModel.storesid = StoresID;
            uModel.name = Base.Fun.Fetch.getpost("name");
            uModel.nickname = Base.Fun.Fetch.getpost("nickname");
            uModel.sex = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("sex"));
            uModel.birthday = Base.Fun.Fetch.getpost("birthday");
            uModel.parentName = Base.Fun.Fetch.getpost("ParentName");
            uModel.tel = Base.Fun.Fetch.getpost("tel");
            uModel.mobile = Base.Fun.Fetch.getpost("mobile");
            uModel.communityid = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("communityid"));
            uModel.illness = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("illness"));
            uModel.allergy = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("allergy"));
            uModel.cycletype = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("cycletype"));
            uModel.IsMeasure = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("IsMeasure"));
            uModel.IsPhoto = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("IsPhoto"));
            uModel.source = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("Usersource"));
            uModel.content = Base.Fun.Fetch.getpost("content");
            uModel.State = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("State"));
            string UserID = uDAL.Insert(uModel);
            if (Base.Fun.fun.pnumeric(UserID))
            {
                Base.Log.Log.Add(1, "customer_User", UserID);
                Web.UI.customer.User_Stores.AddStoresUser(StoresID, UserID);
                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "会员添加成功。");
                Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("UserGrid", UserID, true));
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("会员添加失败。");
            }
        }
        else
        {
            communityidIsAdd = Web.UI.Users.CheckPermission("/Sys/community/Add.aspx", 4);
        }
    }
}