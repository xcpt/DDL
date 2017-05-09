<%@ Page Language="C#" AutoEventWireup="true" Inherits="customer_Cardbusinessid_Modi" %>
<%if(!action.Equals("save")){ %>
<div id="CardbusinessidModi">
<input type="hidden" name="id" value="<%=cbModel.id %>" />
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">名称：</th>
        <td align="left">
            <input type="text" class="validate[required]" name="title" value="<%=cbModel.title %>" id="Cardbusinessidtitle" size="50" />
        </td>
    </tr>
</table>
</div>
<%} %>
