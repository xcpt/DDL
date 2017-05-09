<%@ Page Language="C#" AutoEventWireup="true" Inherits="Sys_Message_Modi" %>
<%if(!action.Equals("save")){ %>
<div id="MessageModi">
<input type="hidden" name="id" value="<%=mModel.id %>" />
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">建议内容：</th>
        <td align="left"><div style="height:100px;overflow-x:hidden;overflow-y:auto;"><%=Base.Fun.fun.NoSql(mModel.content) %></div></td>
    </tr>
    <tr>
        <th width="80" align="right">处理结果：</th>
        <td align="left"> <textarea name="hfcontent" id="Messagehfcontent" style="width: 400px; height: 156px;"><%=mModel.hfcontent %></textarea></td>
    </tr>
</table>
</div>
<%} %>