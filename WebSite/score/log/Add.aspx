<%@ Page Language="C#" AutoEventWireup="true" Inherits="score_log_Add" %>
<%if(!action.Equals("save")){ %>
<div id="logAdd" style="overflow-y:auto;height:200px;">
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">
            会员姓名：
        </th>
        <td align="left">
            <input type="text" name="id" id="loguserid" size="50" />
            <script type="text/javascript">$("#loguserid").autoSuggest("customer/user/intelligent.aspx", { asHtmlID: 'loguserid_yq', asHtmlName: 'id', selectedItemProp: "name", maxLength: "1", searchObjProps: "name", ReadAll: false ,prePopulate: [[<%=userid%>]]});</script>
        </td>
    </tr>
    <tr>
        <th align="right">
            增加分值：
        </th>
        <td align="left">
            <input type="text" name="rulenum" class="validate[required,custom[onlyNumber]]" id="logrulenum" size="10" />
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            备注：
        </th>
        <td align="left">
            <textarea name="content" id="logcontent" style="width: 365px; height: 85px;"></textarea>
        </td>
    </tr>
</table>
</div>
<%} %>
