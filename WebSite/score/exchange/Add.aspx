<%@ Page Language="C#" AutoEventWireup="true" Inherits="score_exchange_Add" %>
<%if(!action.Equals("save")){ %>
<div id="exchangeAdd" style="overflow-y:auto;height:200px;">
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">
            会员姓名：
        </th>
        <td align="left">
            <input type="text" name="id" id="exchangeuserid" size="50" />
            <script type="text/javascript">$("#exchangeuserid").autoSuggest("customer/user/intelligent.aspx", { asHtmlID: 'exchangeuserid_yq', asHtmlName: 'id', selectedItemProp: "name", maxLength: "1", searchObjProps: "name", ReadAll: false, prePopulate: [[<%=userid%>]] });</script>
        </td>
    </tr>
    <tr>
        <th align="right">
            兑换日期：
        </th>
        <td align="left"><input type="text" class="validate[required]" name="usertime" id="exchangeusertime" readonly="readonly" value="<%=DateTime.Now.ToString("yyyy-MM-dd")%>" onclick="WdatePicker({ skin: 'ext' })" size="9" />
        </td>
    </tr>
    <tr>
        <th align="right">
            消耗积分：
        </th>
        <td align="left">
            <input type="text" name="userrule" class="validate[required,custom[onlyNumber]]" id="exchangeuserrule" size="10" />
        </td>
    </tr>
    <tr>
        <th align="right">
            兑换内容：
        </th>
        <td align="left">
            <input type="text" name="content" class="validate[required]" id="exchangecontent" size="50"/>
        </td>
    </tr>
</table>
</div>
<%} %>
