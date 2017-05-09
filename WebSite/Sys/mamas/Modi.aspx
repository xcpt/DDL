<%@ Page Language="C#" AutoEventWireup="true" Inherits="Sys_mamas_Modi" %>
<%if(!action.Equals("save")){ %>
<div id="mamasModi">
<input type="hidden" name="id" value="<%=mModel.id %>" />
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">
            泳圈名称：
        </th>
        <td align="left">
            <input type="text" class="validate[required,length[1,250]]" value="<%=mModel.title %>" name="title" id="mamastitle" size="50" maxlength="250" />
        </td>
    </tr>
</table>
</div>
<%} %>