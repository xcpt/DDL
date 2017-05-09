<%@ Page Language="C#" AutoEventWireup="true" Inherits="Mobile_MessageBuy_Modi" %>
<%if(!action.Equals("save")){ %>
<div id="MessageBuyModi">
<input type="hidden" name="id" value="<%=mbModel.id%>" />
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">状态：</th>
        <td align="left">
            <select name="status" id="MessageBuystatus" style="width:280px;">
                <%=Web.UI.Data.Basic.MessageBugStatus(mbModel.status) %>
            </select>
            <script type="text/javascript">$("#MessageBuystatus").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <tr>
        <th align="right">状态说明：</th>
        <td align="left">
            <textarea name="statuscontent" id="MessageBuystatuscontent" style="width: 371px; height: 124px;"><%=mbModel.statuscontent %></textarea>
        </td>
    </tr>
</table>
</div>
<%} %>
