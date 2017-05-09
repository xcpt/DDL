using System;

public partial class Sys_News_Add : Web.UI.Permissions
{
    protected string action = "", classid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        action = Base.Fun.Fetch.getpost("action");
        classid = Base.Fun.Fetch.getpost("classid");
        if (action.Equals("save"))
        {
            Web.Model.Sys.News nModel = new Web.Model.Sys.News();
            nModel.title = Base.Fun.Fetch.post("title");
            nModel.tag = Base.Fun.Fetch.post("tag");
            nModel.pic = Base.Fun.Fetch.post("pic");
            nModel.content = Base.Fun.Fetch.post("content");
            nModel.fileurl = Base.Fun.Fetch.post("fileurl");
            nModel.classid = Base.Fun.fun.IsZero(classid);
            nModel.content = Base.Fun.Fetch.post("content");
            nModel.addtime = DateTime.Now.ToString();
            nModel.author = Base.Fun.Fetch.post("author");
            Web.DAL.Sys.News nDAL = new Web.DAL.Sys.News();
            string id = nDAL.Insert(nModel);
            if (Base.Fun.fun.pnumeric(id))
            {
                Base.Log.Log.Add(1, "Sys_News", id);
                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "添加成功。");
                Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("NewsGrid", id, true));
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("添加失败。");
            }
            Response.End();
        }
    }
}