using System;

public partial class Staff_swimteacher_Add : Web.UI.Permissions
{
    protected string action = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        if (action.Equals("save"))
        {
            Web.Model.Staff.swimteacher sModel = new Web.Model.Staff.swimteacher();
            sModel.memberid = Base.Fun.Fetch.post("memberid");
            if (Base.Fun.fun.pnumeric(sModel.memberid))
            {
                Web.DAL.Staff.swimteacher sDAL = new Web.DAL.Staff.swimteacher();
                if (Base.Fun.fun.pnumeric(sDAL.Read_Member(sModel.memberid)))
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert("此员工已经是泳师了");
                }
                else
                {
                    sModel.isopen = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("isopen"));
                    sModel.iswww = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("iswww"));
                    string id = sDAL.Insert(sModel);
                    if (Base.Fun.fun.pnumeric(id))
                    {
                        Base.Log.Log.Add(1, "Staff_swimteacher", id);
                        SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "泳师添加成功。");
                        Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("swimteacherGrid", id, true));
                    }
                    else
                    {
                        SyCms.Window.WindowsReturn.WindowsReturnAlert("泳师添加失败。");
                    }
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("错误：员工必须选择。");
            }
            Response.End();
        }
    }
}