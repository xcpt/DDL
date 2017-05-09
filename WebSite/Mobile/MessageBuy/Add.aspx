<%@ Page Language="C#" AutoEventWireup="true" Inherits="Mobile_MessageBuy_Add" %>
<%if(!action.Equals("save")){ %>
<div id="MessageBuyAdd">
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">套餐：</th>
        <td align="left">
            <select name="setupid" class="validate[required]" id="MessageBuysetupid" style="width:280px;">
                <%=Web.UI.Mobile.MessageSetup.GetOption("") %>
            </select>
            <script type="text/javascript">$("#MessageBuysetupid").chosen();</script>
        </td>
    </tr>
    <tr>
        <th align="right">申请备注：</th>
        <td align="left">
            <textarea name="content" id="MessageBuyContent" style="width: 371px; height: 124px;"></textarea>
        </td>
    </tr>
</table>
</div>
<%} %>
