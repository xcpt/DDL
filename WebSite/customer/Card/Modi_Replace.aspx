<%@ Page Language="C#" AutoEventWireup="true" Inherits="customer_Card_Modi_Replace" %>
<%if(!action.Equals("save")){ %>
<div id="CardModi">
<input type="hidden" name="id" value="<%=cModel.cardid%>" />
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="100" align="right">会员卡号：</th>
        <td align="left"><%=cModel.cardNo %></td>
    </tr>
    <tr>
        <th align="right">新卡号：</th>
        <td align="left"><input type="text" class="validate[required,length[6,6]]" name="CardNo" id="CardCardNo" size="30" /></td>
    </tr>
    <tr>
        <th align="right">卡序号：</th>
        <td align="left"><input type="text" class="validate[required,length[10,10]] text" placeholder="请刷卡" name="CardNumber" id="CardCardNumber" size="50" />
            <script type="text/javascript">
                $("#CardCardNumber").unbind("keydown").keydown(function (event) {
                    if (event.keyCode == 13) {
                        $(this).select();
                        return false;
                    }
                }).focus();
            </script>
        </td>
    </tr>
</table>
</div>
<%} %>