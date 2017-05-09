<%@ Page Language="C#" AutoEventWireup="true" Inherits="Web.CS.AdminFun.UploadFile" %>
<div style="padding:10px;">
    <input type="hidden" id="UploadFileType" value="<%=UploadFileType %>" />
    <input id="SyCmsUpFileExt" type="hidden" value="<%=FileExt %>" />
    <input id="SyCmsUpFileSize" type="hidden" value="<%=FileSize %>" />
    <input id="SyCmsUpFileName" type="hidden" value="<%=(Base.Fun.fun.pnumeric(Listid) || IsStyle.Equals("1"))?"1":"0" %>" />
    <%if(!UploadFileType.Equals("flash")){ %>
    <form id="SyCmsFileUpload" method="post" action="AdminFun/UploadFile.aspx" target="SyCmsFileUploadiFrame" enctype="multipart/form-data">
        <div style="padding:3px;">
            <input type="hidden" name="UploadID" id="UploadID" value="<%=UploadID%>" />
            <input type="hidden" name="action" value="CreateFile" />
            <input type="hidden" name="Listid" value="<%=Listid %>" />
            <input type="hidden" name="Classid" value="<%=Classid %>" />
            <input type="hidden" name="IsStyle" value="<%=IsStyle %>" />
            <input name="type" type="hidden" value="<%=FileType %>" />
            <input name="FileExt" type="hidden" value="<%=FileExt %>" />
            <input name="FileSize" type="hidden" value="<%=FileSize %>" />
            <input name="ObjName" id="ObjName" type="hidden" value="<%=ObjName %>" />
            <input name="IsFullPath" type="hidden" value="<%=IsFullPath %>" />
            <input name="UpMessage" type="hidden" value="<%=UpMessage %>" />
            <input name="IsFun" type="hidden" value="<%=IsFun %>" />
            <input name="InputValue" type="hidden" value="<%=InputValue %>" />
            <input name="FunPara" type="hidden" value="<%=FunPara %>" />
            <input name="file1" id="file1" runat="server" type="file" style="width:260px;" width="260" /><%=(Base.Fun.fun.pnumeric(Listid) || IsStyle.Equals("1")) ? "&nbsp;<font color=red>[原文件名上传]</font>" : "&nbsp;&nbsp;<input type=\"checkbox\" value=\"1\" name=\"OriginalName\" id=\"OriginalName0\" /><label for=\"OriginalName0\">保持原文件名</label>"%>
        </div>
        <div style="clear:both;text-align:left;padding-top:10px;">
            <div>大小：<%=Base.Fun.fun.ByteSize(FileSize)%></div>
            <div style="line-height:20px;word-break:break-all; word-wrap:break-word;height:50px;overflow-x:hidden;overflow-y:auto;">类型：<%=FileExt.Replace("|", ",").TrimEnd(',').TrimStart(',') %></div>
        </div>
    </form>
    <script type="text/javascript">
        $("#SyCmsFileUpload input#file1").trigger("click");
    </script>
    <iframe width="0" height="0" frameborder="0" style="display:none;width:0px;height:0px;" allowtransparency="true" id="SyCmsFileUploadiFrame" Name="SyCmsFileUploadiFrame"></iframe>
    <%}else{ %>
    <div style="padding:3px;">
        <input type="hidden" id="cookiesname" value="<%=cookiesname %>" />
        <input type="hidden" id="InputValue" value="<%=InputValue %>" />
        <input type="file" name="SyCmsUploadify" id="SyCmsUploadify" />
        <div id="SyCmsUploadfileQueue" style="text-align:left;"></div>
    </div>
    <%} %>
</div>