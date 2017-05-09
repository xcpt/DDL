<%@ Page Language="C#" AutoEventWireup="true" Inherits="Sys_News_Add" %>
<%if(!action.Equals("save")){ %>
<div id="NewsAdd">
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">栏目：</th>
        <td align="left" colspan="3">
            <select name="classid" id="classid" style="width:200px;">
                <option value="0">请选择</option>
                <%=Web.UI.Sys.Category.ViewOption("1",classid) %>
            </select>
            <script type="text/javascript">$("#classid").chosen();</script>
        </td>
    </tr>
    <tr>
        <th width="80" align="right">名称：</th>
        <td align="left" colspan="3">
            <input type="text" class="validate[required,length[1,250]]" name="title" id="Newstitle" size="50" maxlength="250" />
        </td>
    </tr>
   <tr>
        <th align="right">适用范围：</th>
        <td align="left">
            <input type="text" name="sday" id="sday" value="0" size="8" />-<input type="text" name="eday" id="eday" size="8" value="0" />天
        </td>
        <th align="right">作者：</th>
        <td align="left">
            <input type="text" name="author" id="Newsauthor" size="40" value="<%=Base.Fun.fun.getapp("comkey")%>" maxlength="250" />
        </td>
  </tr>
    <tr>
        <th align="right">标签：</th>
        <td align="left" colspan="3">
            <input type="text" name="tag" id="Newstag" size="50" maxlength="250" />
        </td>
    </tr>
    <tr>
        <th align="right">配图：</th>
        <td align="left" colspan="3">
            <div style="float:right"><input type="button" value="上传配图" onclick="UploadFile('Newspic', 'PIC');" icon="icon-picture_add" /></div>
            <input type="text" class="validate[required] jTip" style="width:270px;" name="pic" id="Newspic" size="50" maxlength="250" />
        </td>
    </tr>
    <tr>
        <th align="right">文件地址：</th>
        <td align="left" colspan="3">
            <div style="float:right"><input type="button" value="上传文件" onclick="UploadFile('NewsFileurl', 'FILE');" icon="icon-folder_up" /></div>
            <input type="text" style="width:270px;" name="fileurl" id="NewsFileurl" size="50" maxlength="250" />
        </td>
    </tr>
    <tr>
        <th align="right">内容：</th>
        <td align="left" colspan="3">
            <input type="hidden" name="content___Config" id="content___Config" value="1" />
            <textarea id="content" name="content" style="display:none;"></textarea>
            <script type="text/javascript">
                CkeditorView("content", { skin: 'v2', toolbar: 'Default', height: '210' });
            </script></td>
    </tr>
</table>
</div>
<%} %>
