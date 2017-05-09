using System;

public partial class customer_User_Modi : Web.UI.Permissions
{
    protected string action = "";
    protected bool communityidIsAdd = false;
    protected Web.Model.customer.User uModel = new Web.Model.customer.User();
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.customer.User uDAL = new Web.DAL.customer.User();
            uModel = uDAL.Read(StoresID, id);
            if (uModel.userid.Equals(id))
            {
                if (action.Equals("save"))
                {
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
                    uModel.State = Base.Fun.Fetch.getpost("state");
                    int icount = uDAL.Update(uModel);
                    if (icount > 0)
                    {
                        Base.Log.Log.Add(2, "customer_User", UserID);
                        SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "会员修改成功。");
                        Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("UserGrid", UserID, true));
                    }
                    else
                    {
                        SyCms.Window.WindowsReturn.WindowsReturnAlert("会员修改失败。");
                    }
                }
                else
                {
                    communityidIsAdd = Web.UI.Users.CheckPermission("/Sys/community/Add.aspx", 4);
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("未找到会员信息");
                Response.End();
            }
        }
        else
        {
            SyCms.Window.WindowsReturn.WindowsReturnAlert("参数传递错误");
            Response.End();
        }
    }
}