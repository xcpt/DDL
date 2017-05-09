using System;

public partial class Marketing_Visit_Add :Web.UI.Permissions
{
    protected string action = "";
    protected string userid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        action = Base.Fun.Fetch.getpost("action");
        userid = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(userid))
        {
            if (action.Equals("save"))
            {
                Web.DAL.Marketing.Visit vDAL = new Web.DAL.Marketing.Visit();
                Web.Model.Marketing.Visit vModel = new Web.Model.Marketing.Visit();
                vModel.addtime = Base.Fun.Fetch.getpost("addtime");
                vModel.content = Base.Fun.Fetch.getpost("content");
                vModel.IsGiveup = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("IsGiveup"));
                vModel.memberid = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("memberid"));
                vModel.ReturnresultID = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("ReturnresultID"));
                vModel.num = vDAL.ReadNum(userid);
                vModel.userid = userid;
                string id = vDAL.Insert(vModel);
                if (Base.Fun.fun.pnumeric(id))
                {
                    Base.Log.Log.Add(1, "Marketing_Visit");
                    SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "回访记录添加成功。");
                    Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("VisitGrid", true));
                }
                else
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert("错误：添加回访记录失败。");
                }
                Response.End();
            }
        }
        else {
            SyCms.Window.WindowsReturn.WindowsReturnAlert("参数传递错误");
            Response.End();
        }
    }
}