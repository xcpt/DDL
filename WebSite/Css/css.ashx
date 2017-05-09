<%@ WebHandler Language="C#" Class="css" %>
using System;
using System.Web;
using System.Collections.Generic;
public class css : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/css";
        List<string> FileList = new List<string>();
        FileList.Add("images/css.css");
        FileList.Add("Css/validationEngine.jquery.css");

        FileList.Add("Css/contextmenu.css");
        FileList.Add("Css/jquery.treeTable.css");
        FileList.Add("Css/Style.css");
        FileList.Add("Css/Menu.css");
        FileList.Add("Css/CssStyle.css");
        FileList.Add("Css/button.css");
        FileList.Add("Css/datepicker.css");
        FileList.Add("Css/Cut2Slice.css");
        FileList.Add("Css/Tree.css");

        FileList.Add("Css/Title.css");
        FileList.Add("Css/autoSuggest.css");
        FileList.Add("Css/jslider.css");

        FileList.Add("Css/jquery.fileGrid.css");
        FileList.Add("Css/jquery.fileTree.css");
        FileList.Add("Css/uploadify/default.css");
        FileList.Add("Css/uploadify/uploadify.css");

        FileList.Add("Css/jquery.notice.css");

        FileList.Add("Css/SortMoveTable.css");
        FileList.Add("Css/flexigrid.css");

        FileList.Add("Css/JTip.css");
        FileList.Add("Css/DiagTable.css");
        FileList.Add("Css/chosen.css");
        FileList.Add("Css/custom.css");
        FileList.Add("Css/css.css");
        string WebPath = Base.Fun.Management.RealManagementDirectory();
        foreach (string FileName in FileList)
        {
            context.Response.Write(Base.IO.File.ReadFile(WebPath + FileName));
        }
    }
    public bool IsReusable {
        get {
            return false;
        }
    }
}