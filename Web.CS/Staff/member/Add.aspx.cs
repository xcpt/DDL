using System;

public partial class Staff_member_Add : Web.UI.Permissions
{
    protected string action = "";
    protected bool departmentIsAdd = false, positionIsAdd = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        string idname = Base.Fun.Fetch.getpost("idname");
        if (action.Equals("save"))
        {
            Web.Model.Staff.member mModel = new Web.Model.Staff.member();
            mModel.storesid = StoresID;
            mModel.name = Base.Fun.Fetch.getpost("name");
            mModel.enname = Base.Fun.Fetch.getpost("enname");
            mModel.cnid = Base.Fun.Fetch.getpost("cnid");
            mModel.cnidaddress = Base.Fun.Fetch.getpost("cnidaddress");
            mModel.mobile = Base.Fun.Fetch.getpost("mobile");
            mModel.email = Base.Fun.Fetch.getpost("email");
            mModel.qq = Base.Fun.Fetch.getpost("qq");
            mModel.homeaddress = Base.Fun.Fetch.getpost("homeaddress");
            mModel.relativesname = Base.Fun.Fetch.getpost("relativesname");
            mModel.hometel = Base.Fun.Fetch.getpost("hometel");
            mModel.positionid = Base.Fun.Fetch.getpost("positionid");
            mModel.departmentid = Base.Fun.Fetch.getpost("departmentid");
            mModel.status = Base.Fun.Fetch.getpost("status");
            mModel.sex = Base.Fun.Fetch.getpost("sex");
            mModel.birthday = Base.Fun.Fetch.getpost("birthday");
            mModel.isinsurance = Base.Fun.Fetch.getpost("isinsurance");
            mModel.entrytime = Base.Fun.Fetch.getpost("entrytime");
            mModel.quittime = Base.Fun.Fetch.getpost("quittime");
            mModel.userface = Base.Fun.Fetch.getpost("userface");
            Web.DAL.Staff.member mDAL = new Web.DAL.Staff.member();
            string id = mDAL.Insert(mModel);
            if (Base.Fun.fun.pnumeric(id))
            {
                Base.Log.Log.Add(1, "Staff_member", id);
                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "员工添加成功。");
                if (idname.Length > 0)
                {
                    Response.Write("<script type=\"text/javascript\">$('#" + idname + "').html(\"" + Base.Fun.JScript.htmltojavascriptNoD(Web.UI.Staff.member.GetOption(StoresID, id)) + "\").trigger(\"chosen:updated\");</script>");
                }
                else
                {
                    Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("memberGrid", id, true));
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("添加员工失败");
                Response.End();
            }
        }
        else
        {
            if (idname.Length == 0)
            {
                departmentIsAdd = Web.UI.Users.CheckPermission("/Staff/department/Add.aspx", 4);
                positionIsAdd = Web.UI.Users.CheckPermission("/Staff/position/Add.aspx", 4);
            }
        }
    }
}