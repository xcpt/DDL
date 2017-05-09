<%@ Page Language="C#" AutoEventWireup="true" Inherits="baby_album_Add" %>
<%if(!action.Equals("save")){ %>
<div id="albumAdd">
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">会员姓名：</th>
        <td align="left" colspan="3">
            <input type="text" name="id" onchange="alert($('#albumuserid_yq').val());" id="albumuserid" size="50" />
            <script type="text/javascript">$("#albumuserid").autoSuggest("customer/user/intelligent.aspx", { asHtmlID: 'albumuserid_yq', asHtmlName: 'id', selectedItemProp: "name", maxLength: "1", searchObjProps: "name", ReadAll: false, prePopulate: [[<%=userid%>]], selectOKFunction: function (id) { } });</script>
        </td>
    </tr>
    <tr>
        <th align="right">月龄：</th>
        <td align="left">
            <input type="text" class="validate[required,custom[onlyNumber]]" value="<%=(Base.Fun.fun.pnumeric(userid)?Web.UI.customer.User.GetMonthday(userid):"") %>" name="monthage" id="albummonthage" size="20" />
        </td>
    </tr>
    <tr>
        <th align="right">记录时间：</th>
        <td align="left">
             <input type="text" class="validate[required]" name="addtime" id="albumaddtime" value="<%=DateTime.Now.ToString("yyyy-MM-dd") %>" readonly="readonly" onclick="WdatePicker({ skin: 'ext' })" size="20" />
        </td>
    </tr>
</table>
</div>
<%} %>