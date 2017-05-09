<%@ Page Language="C#" AutoEventWireup="true" Inherits="Sys_community_Add" %>
<%if(!action.Equals("save")){ %>
<div id="communityAdd">
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">
            小区名称：
        </th>
        <td align="left">
            <input type="text" class="validate[required,length[1,250]]" name="title" id="communitytitle" size="50" maxlength="250" />
        </td>
    </tr>
</table>
</div>
<%} %>
