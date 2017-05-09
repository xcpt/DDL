<%@ Page Language="C#" AutoEventWireup="true" Inherits="customer_UserConsumptionStores_Add" %>
<%if(!action.Equals("save")){ %>
<div id="UserConsumptionStoresAdd">
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">
            月份：
        </th>
        <td align="left">
            <input type="text" name="datetime" id="WageMonthdatetime" value="<%=DateTime.Now.AddMonths(-1).ToString("yyyy-MM") %>" readonly="readonly" onClick="WdatePicker({ skin: 'ext', dateFmt: 'yyyy-MM', maxDate: '<%=DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd")%>' })" size="9"/>
        </td>
    </tr>
 </table>
</div>
<%} %>