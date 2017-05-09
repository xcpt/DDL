using System;

public partial class Staff_member_Modi :Web.UI.Permissions
{
    protected string action = "";
    protected bool departmentIsAdd = false, positionIsAdd = false;
    protected Web.Model.Staff.member mModel = new Web.Model.Staff.member();
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.Staff.member mDAL = new Web.DAL.Staff.member();
            mModel = mDAL.Read(StoresID, id);
            if (mModel.id.Equals(id))
            {
                if (action.Equals("save"))
                {
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

                    int icount = mDAL.Update(mModel);
                    if(icount>0)
                    {
                        Base.Log.Log.Add(2, "Staff_member", id);
                        SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "员工修改成功。");
                        Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("memberGrid", id, true));
                    }
                    else
                    {
                        SyCms.Window.WindowsReturn.WindowsReturnAlert("修改员工失败");
                        Response.End();
                    }
                }
                else
                {
                    departmentIsAdd = Web.UI.Users.CheckPermission("/department/Add.aspx", 4);
                    positionIsAdd = Web.UI.Users.CheckPermission("/position/Add.aspx", 4);
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("未找到员工信息");
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