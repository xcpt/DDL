<%@ Page Language="C#" AutoEventWireup="true" Inherits="Sys_News_Modi" %>
<%if(!action.Equals("save")){ %>
<div id="NewsModi">
    <input type="hidden" name="id" value="<%=nModel.id %>" />
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">版本名称：</th>
        <td align="left">
            <input type="text" class="validate[required,length[1,250]]" name="title" id="Newstitle" value="<%=nModel.title %>" size="50" maxlength="250" />
        </td>
    </tr>
    <tr>
        <th align="right">版本：</th>
        <td align="left">
            <input type="text" class="validate[required,custom[Number]]" name="tag" id="Newstag" value="<%=nModel.tag %>" size="30" maxlength="250" />正整数
        </td>
    </tr>
    <tr>
        <th align="right">系统：</th>
        <td align="left">
            <select id="NewsPic" name="Pic" style="width:100px;"><option value="ios"<%=Base.Fun.fun.isSelected("ios",nModel.pic) %>>苹果</option><option value="android"<%=Base.Fun.fun.isSelected("android",nModel.pic) %>>安卓</option></select>
            <script type="text/javascript">$("#NewsPic").chosen({ max_selected_options: 10 });</script>
        </td>
    </tr>
    <tr>
        <th align="right">下载地址：</th>
        <td align="left">
            <div style="float:right"><input type="button" value="上传文件" onclick="UploadFile('fileurl', 'FILE');" icon="icon-folder_up" /></div>
            <input type="text" class="validate[required]" style="width:270px;" name="fileurl" value="<%=nModel.fileurl %>" id="fileurl" size="50" maxlength="250" />
        </td>
    </tr>
    <tr>
        <th align="right">版本说明：</th>
        <td align="left">
            <textarea id="content" name="content" style="width:400px;height:80px;"><%=nModel.content %></textarea>
        </td>
    </tr>
</table>
</div>
<%} %>
