<%@ Page Language="C#" AutoEventWireup="true" Inherits="Staff_WageMonth_Add" %>
<%if(!action.Equals("save")){ %>
<div id="WageMonthAdd">
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">
            月份：
        </th>
        <td align="left">
            <input type="text" name="datetime" id="WageMonthdatetime" value="<%=DateTime.Now.AddMonths(-1).ToString("yyyyMM") %>" readonly="readonly" onClick="WdatePicker({ skin: 'ext', dateFmt: 'yyyyMM', maxDate: '<%=DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd")%>' })" size="9"/>
        </td>
    </tr>
 </table>
</div>
<%} %>