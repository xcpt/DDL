<%@ Page Language="C#" AutoEventWireup="true" Inherits="Mobile_MessageSetup_Add" %>
<%if(!action.Equals("save")){ %>
<div id="MessageSetupAdd">
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">套餐名称：</th>
        <td align="left"><input type="text" class="validate[required]" name="title" id="MessageSetupTitle" size="50" maxlength="200" /></td>
    </tr>
    <tr>
        <th align="right">短信条数：</th>
        <td align="left"><input type="text" class="validate[required]" name="num" id="MessageSetupnum" size="20" /></td>
    </tr>
    <tr>
        <th align="right">价格：</th>
        <td align="left"><input type="text" name="Price" id="MessageSetupPrice" size="20" /></td>
    </tr>
</table>
</div>
<%} %>
