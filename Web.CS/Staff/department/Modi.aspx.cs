using System;

public partial class Staff_department_Modi : Web.UI.Permissions
{
    protected string action = "";
    protected bool MemberIsAdd = false;
    protected Web.Model.Staff.department dModel = new Web.Model.Staff.department();
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.Staff.department dDAL = new Web.DAL.Staff.department();
            dModel = dDAL.Read(StoresID, id);
            if (dModel.id.Equals(id))
            {
                action = Base.Fun.Fetch.getpost("action");
                if (action.Equals("save"))
                {
                    dModel.title = Base.Fun.Fetch.post("title");
                    dModel.headmemberid = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("headmemberid"));
                    dModel.description = Base.Fun.Fetch.post("description");
                    int icount = dDAL.Update(dModel);
                    if (icount > 0)
                    {
                        Base.Log.Log.Add(2, "Staff_department", id);
                        SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "部门修改成功。");
                        Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("departmentGrid", id, true));
                    }
                    else
                    {
                        SyCms.Window.WindowsReturn.WindowsReturnAlert("部门修改失败。");
                    }
                    Response.End();
                }
                else {
                    MemberIsAdd = Web.UI.Users.CheckPermission("/member/Add.aspx", 4);
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("未找到部门信息。");
                Response.End();
            }
        }
        else
        {
            SyCms.Window.WindowsReturn.WindowsReturnAlert("参数传递错误。");
            Response.End();
        }
    }
}