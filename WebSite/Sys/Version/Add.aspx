<%@ Page Language="C#" AutoEventWireup="true" Inherits="Sys_News_Add" %>
<%if(!action.Equals("save")){ %>
<div id="NewsAdd">
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">版本名称：</th>
        <td align="left">
            <input type="text" class="validate[required,length[1,250]]" name="title" id="Newstitle" size="50" maxlength="250" />
        </td>
    </tr>
    <tr>
        <th align="right">版本：</th>
        <td align="left">
            <input type="text" class="validate[required,custom[Number]]" name="tag" id="Newstag" size="30" maxlength="250" />正整数
        </td>
    </tr>
    <tr>
        <th align="right">系统：</th>
        <td align="left">
            <select id="NewsPic" name="Pic" style="width:100px;"><option value="ios">苹果</option><option value="android">安卓</option></select>
            <script type="text/javascript">$("#NewsPic").chosen({ max_selected_options: 10 });</script>
        </td>
    </tr>
    <tr>
        <th align="right">下载地址：</th>
        <td align="left">
            <div style="float:right"><input type="button" value="上传文件" onclick="UploadFile('fileurl', 'FILE');" icon="icon-folder_up" /></div>
            <input type="text" class="validate[required]" style="width:270px;" name="fileurl" id="fileurl" size="50" maxlength="250" />
        </td>
    </tr>
    <tr>
        <th align="right">版本说明：</th>
        <td align="left">
            <textarea id="content" name="content" style="width:400px;height:80px;"></textarea>
        </td>
    </tr>
</table>
</div>
<%} %>
