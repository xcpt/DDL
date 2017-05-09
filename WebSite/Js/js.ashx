<%@ WebHandler Language="C#" Class="js" %>
using System;
using System.Web;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
public class js : IHttpHandler , System.Web.SessionState.IRequiresSessionState, System.Web.SessionState.IReadOnlySessionState {
    private const bool DO_GZIP = true;
    private void WriteBytes(byte[] bytes, HttpContext context,bool isCompressed, string contentType)
    {
        HttpResponse response = context.Response;
        response.AppendHeader("Content-Length", bytes.Length.ToString());
        response.ContentType = contentType;
        if (isCompressed)
            response.AppendHeader("Content-Encoding", "gzip");
        response.OutputStream.Write(bytes, 0, bytes.Length);
        response.Flush();
    }
    public void ProcessRequest (HttpContext context) {
        HttpRequest request = context.Request;
        bool isCompressed = DO_GZIP && Base.Fun.fun.CanGZip(context.Request);
        UTF8Encoding encoding = new UTF8Encoding(false);
        ///文件输出编译
        string contentType = "text/javascript";
        string version = Base.Fun.Fetch.getpost("version");
            using (MemoryStream memoryStream = new MemoryStream(5000))
            {
                // Decide regular stream or GZipStream based on whether the response
                // can be cached or not
                using (Stream writer = isCompressed ?(Stream)(new GZipStream(memoryStream, CompressionMode.Compress)) :memoryStream)
                {
                    List<string> JsFile = new List<string>();
                    JsFile.Add("js/Lang/zh.js");
                    JsFile.Add("js/event.js");
                    JsFile.Add("js/option.js");
                    JsFile.Add("js/CssFun.js");
                    JsFile.Add("js/function.js");
                    JsFile.Add("js/word.js");
                    JsFile.Add("js/jquery.min.js");
                    JsFile.Add("js/jquery.ui.js");
                    JsFile.Add("js/xml.js");
                    JsFile.Add("js/zDialog.js");
                    JsFile.Add("js/zDrag.js");
                    JsFile.Add("js/MouseSelect.js");
                    JsFile.Add("js/TempFun.js");
                    JsFile.Add("js/TempPage.js");
                    JsFile.Add("js/TempHtml.js");
                    JsFile.Add("js/LoadImg.js");
                    JsFile.Add("js/TextArea.js");
                    JsFile.Add("js/Menu.js");
                    JsFile.Add("js/MenuList.js");
                    JsFile.Add("js/Model.js");
                    JsFile.Add("js/Clock.js");
                    JsFile.Add("js/jquery.validationEngine-cn.js");
                    JsFile.Add("js/jquery.validationEngine.js");
                    JsFile.Add("js/jquery.flexigrid.js");
                    JsFile.Add("js/jquery.contextmenu.js");
                    JsFile.Add("js/jquery.treeTable.js");
                    JsFile.Add("js/Utility/jsformat.js");
                    JsFile.Add("js/Utility/htmlformat.js");
                    JsFile.Add("js/pico-button.js");
                    JsFile.Add("js/jquery.progressbar.js");
                    JsFile.Add("js/toxhtml.js");
                    JsFile.Add("js/Cut2Slice.js");
                    JsFile.Add("js/jquery.tree.js");
                    JsFile.Add("js/System.js");
                    JsFile.Add("js/jquery.FormPrompt.js");
                    JsFile.Add("js/Admin.js");
                    JsFile.Add("js/Category.js");
                    JsFile.Add("js/Arti.js");
                    JsFile.Add("js/OtherJS.js");
                    JsFile.Add("js/Expand.js");
                    JsFile.Add("js/Module.js");
                    JsFile.Add("js/color.js");
                    JsFile.Add("js/csscreate.js");
                    JsFile.Add("js/jquery.autoSuggest.js");
                    JsFile.Add("js/jquery.dependClass.js");
                    JsFile.Add("js/jquery.slider.js");
                    JsFile.Add("js/File/jquery.fileGrid.js");
                    JsFile.Add("js/File/jquery.fileTree.js");
                    JsFile.Add("js/File/jquery.File.js");
                    JsFile.Add("js/jquery.LoadImage.js");
                    JsFile.Add("js/File/uploadify/jquery.uploadify-3.1.min.js");
                    JsFile.Add("js/jquery.notice.js");
                    JsFile.Add("js/jtip.js");
                    JsFile.Add("js/SortMoveTable/PageSort.js");
                    JsFile.Add("js/Plus.js");
                    JsFile.Add("js/Form.js");
                    JsFile.Add("js/User.js");
                    JsFile.Add("js/DiagTable.js");
                    JsFile.Add("js/chosen.jquery.js");
                    JsFile.Add("js/custom.js");
                    JsFile.Add("js/colResizable-1.3.js");
                    JsFile.Add("js/jquery_md5.js");
                    JsFile.Add("js/jquery.scrollLoading.js");
                    string WebPath = Base.Fun.Management.RealManagementDirectory();
                    foreach (string fileName in JsFile)
                    {
                        if (File.Exists(WebPath + fileName))
                        {
                            byte[] fileBytes = this.GetFileBytes(context, WebPath + fileName, encoding);
                            writer.Write(fileBytes, 0, fileBytes.Length);
                        }
                    }
                    writer.Close();
                }

                // Cache the combined response so that it can be directly written
                // in subsequent calls 
                byte[] responseBytes = memoryStream.ToArray();
                this.WriteBytes(responseBytes, context, isCompressed, contentType);
            }
    }
    private byte[] GetFileBytes(HttpContext context, string virtualPath, Encoding encoding)
    {
        byte[] bytes = File.ReadAllBytes(virtualPath);
        // TODO: Convert unicode files to specified encoding. For now, assuming
        // files are either ASCII or UTF8
        return bytes;
    }
    public bool IsReusable {
        get {
            return false;
        }
    }
}