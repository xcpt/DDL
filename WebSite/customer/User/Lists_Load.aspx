<%@ Page Language="C#" AutoEventWireup="true" Inherits="customer_User_Lists_Load" %>
<%if(!action.Equals("save")){ %>
<div id="customerUserAdd">
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">会员卡号：</th>
        <td align="left">
            <input type="text" class="validate[required,length[6,10]]" placeholder="输入卡号或刷卡" name="cardNo" id="customerUsercardNo" size="50" maxlength="250" />
            <script type="text/javascript">
                $("#customerUsercardNo").focus();
            </script>
        </td>
    </tr>
</table>
</div>
<%} %>