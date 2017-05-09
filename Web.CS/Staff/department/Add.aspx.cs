using System;

public partial class Staff_department_Add : Web.UI.Permissions
{
    protected string action = "";
    protected bool MemberIsAdd = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        string idname = Base.Fun.Fetch.getpost("idname");
        if (action.Equals("save"))
        {
            Web.Model.Staff.department dModel = new Web.Model.Staff.department();
            dModel.title = Base.Fun.Fetch.post("title");
            dModel.headmemberid = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("headmemberid"));
            dModel.description = Base.Fun.Fetch.post("description");
            dModel.storesid = StoresID;
            Web.DAL.Staff.department dDAL = new Web.DAL.Staff.department();
            string id = dDAL.Insert(dModel);
            if (Base.Fun.fun.pnumeric(id))
            {
                Base.Log.Log.Add(1, "Staff_department", id);
                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "部门添加成功。");
                if (idname.Length > 0)
                {
                    Response.Write("<script type=\"text/javascript\">$('#" + idname + "').html(\"" + Base.Fun.JScript.htmltojavascriptNoD(Web.UI.Staff.department.GetOption(StoresID, id)) + "\").trigger(\"chosen:updated\");</script>");
                }
                else
                {
                    Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("departmentGrid", id, true));
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("部门添加失败。");
            }
            Response.End();
        }
        else
        {
            if (idname.Length == 0)
            {
                MemberIsAdd = Web.UI.Users.CheckPermission("/Staff/member/Add.aspx", 4);
            }
        }
    }
}