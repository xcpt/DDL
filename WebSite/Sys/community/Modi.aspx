<%@ Page Language="C#" AutoEventWireup="true" Inherits="Sys_community_Modi" %>
<%if(!action.Equals("save")){ %>
<div id="communityModi">
<input type="hidden" name="id" value="<%=cModel.id %>" />
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">
            小区名称：
        </th>
        <td align="left">
            <input type="text" class="validate[required,length[1,250]]" value="<%=cModel.title %>" name="title" id="communitytitle" size="50" maxlength="250" />
        </td>
    </tr>
</table>
</div>
<%} %>