using System;

public partial class Sys_Activities_Add : Web.UI.Permissions
{
    protected string action = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        action = Base.Fun.Fetch.getpost("action");
        string classid = Base.Fun.Fetch.getpost("classid");
        if (Base.Fun.fun.pnumeric(classid))
        {
            if (action.Equals("save"))
            {
                Web.Model.Sys.News nModel = new Web.Model.Sys.News();
                nModel.title = Base.Fun.Fetch.post("title");
                nModel.tag = Base.Fun.Fetch.post("tag");
                nModel.pic = Base.Fun.Fetch.post("pic");
                nModel.fileurl = Base.Fun.Fetch.post("fileurl");
                nModel.content = Base.Fun.Fetch.post("content");
                nModel.Province = Base.Fun.Fetch.post("Province");
                nModel.storesid = Base.Fun.fun.IsZero(Base.Fun.Fetch.post("storesid"));
                nModel.classid = classid;
                nModel.addtime = DateTime.Now.ToString();
                Web.DAL.Sys.News nDAL = new Web.DAL.Sys.News();
                string id = nDAL.Insert(nModel);
                if (Base.Fun.fun.pnumeric(id))
                {
                    Base.Log.Log.Add(1, "Sys_News", id);
                    SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "添加成功。");
                    Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("ActivitiesGrid", id, true));
                }
                else
                {
                    SyCms.Window.WindowsReturn.WindowsReturnAlert("添加失败。");
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