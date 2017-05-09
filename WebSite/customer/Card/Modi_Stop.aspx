<%@ Page Language="C#" AutoEventWireup="true" Inherits="customer_Card_Modi_Stop" %>
<%if(!action.Equals("save")){ %>
<div id="CardModi">
<input type="hidden" name="id" value="<%=cModel.cardid%>" />
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="100" align="right">会员卡号：</th>
        <td align="left"><%=cModel.cardNo %></td>
    </tr>
    <tr>
        <th align="right">卡剩余天数：</th>
        <td align="left"><%=cModel.surplusnum %></td>
    </tr>
    <tr style="display:none;">
        <th align="right">停卡至：</th>
        <td align="left"><input type="text" name="stoptime" id="NewCardStoptime" readonly="readonly" onclick="WdatePicker({ skin: 'ext', minDate: '<%=DateTime.Now.ToString("yyyy-MM-dd")%>' })" size="9" /></td>
    </tr>
</table>
</div>
<%} %>