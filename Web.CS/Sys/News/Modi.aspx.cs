using System;

public partial class Sys_News_Modi : Web.UI.Permissions
{
    protected string action = "";
    protected Web.Model.Sys.News nModel = new Web.Model.Sys.News();
    protected void Page_Load(object sender, EventArgs e)
    {
        action = Base.Fun.Fetch.getpost("action");
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.Sys.News nDAL = new Web.DAL.Sys.News();
            nModel = nDAL.Read(id);
            if (nModel.id.Equals(id))
            {
                if (action.Equals("save"))
                {
                    nModel.title = Base.Fun.Fetch.post("title");
                    nModel.tag = Base.Fun.Fetch.post("tag");
                    nModel.pic = Base.Fun.Fetch.post("pic");
                    nModel.content = Base.Fun.Fetch.post("content");
                    nModel.fileurl = Base.Fun.Fetch.post("fileurl");
                    nModel.content = Base.Fun.Fetch.post("content");
                    nModel.author = Base.Fun.Fetch.post("author");
                    nModel.classid = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("classid"));
                    int icount = nDAL.Update(nModel);
                    if (icount>0)
                    {
                        Base.Log.Log.Add(2, "Sys_News", id);
                        SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "修改成功。");
                        Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("NewsGrid", id, true));
                    }
                    else
                    {
                        SyCms.Window.WindowsReturn.WindowsReturnAlert("修改失败。");
                    }
                    Response.End();
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("未找到相关记录");
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