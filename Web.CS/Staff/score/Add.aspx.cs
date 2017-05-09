using System;

public partial class Staff_score_Add : Web.UI.Permissions
{
    protected string action = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        if (action.Equals("save"))
        {
            Web.Model.Staff.score sModel = new Web.Model.Staff.score();
            sModel.memberid = Base.Fun.Fetch.post("memberid");
            if (Base.Fun.fun.pnumeric(sModel.memberid))
            {
                sModel.type = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("type"));
                sModel.datetime = Base.Fun.Fetch.getpost("datetime");
                sModel.num = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("num"));
                sModel.addtime = DateTime.Now.ToString();
                sModel.isadd = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("isadd"));
                sModel.content = Base.Fun.Fetch.getpost("content");
                Web.DAL.Staff.score sDAL = new Web.DAL.Staff.score();
                string id = sDAL.Insert(sModel);
                if (Base.Fun.fun.pnumeric(id))
                {
                    Base.Log.Log.Add(1, "Staff_score", id);
                    SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "积分添加成功。");
                    Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("scoreGrid", id, true));
                }
                else
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert("积分添加失败。");
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