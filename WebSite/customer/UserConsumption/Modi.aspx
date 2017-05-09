<%@ Page Language="C#" AutoEventWireup="true" Inherits="customer_UserConsumption_Modi" %>
<%if(!action.Equals("save")){ %>
<div id="UserConsumptionModi">
 <input type="hidden" name="id" value="<%=id %>" />
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th align="right" width="80">撤消原因：</th>
        <td align="left" colspan="3">
            <textarea name="content" class="validate[required,length[1,500]]" id="UserConsumptioncontent" style="width: 287px; height: 80px;"></textarea>
        </td>
    </tr>
</table>
</div>
<%} %>
