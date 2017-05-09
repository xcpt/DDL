<%@ Page Language="C#" AutoEventWireup="true" Inherits="customer_Card_Modi_Cardrenewal" %>
<%if(!action.Equals("save")){ %>
<div id="CardModi">
<input type="hidden" name="id" value="<%=cModel.cardid%>" />
<table class="table StyleView" border="0" cellspacing="0" height="100%" scellpadding="0" width="100%">
    <tr>
        <th width="100" align="right">会员卡号：</th>
        <td align="left"><%=cModel.cardNo %></td>
    </tr>
    <tr>
        <th align="right">卡类型：</th>
        <td align="left">
            <select disabled="disabled" id="Cardcardtypeid" style="width:200px;">
                <%=Web.UI.customer.CardType.GetOption(StoresID,cModel.cardtypeid) %>
            </select>
            <script type="text/javascript">$("#Cardcardtypeid").chosen();</script>
        </td>
    </tr>
    <tr>
        <th align="right">续卡类型：</th>
        <td align="left">
            <select name="cardtypeid" id="NewCardcardtypeid" style="width:200px;">
                <%=Web.UI.customer.CardType.GetOption(StoresID,cModel.cardtypeid) %>
            </select>
            <script type="text/javascript">$("#NewCardcardtypeid").chosen();</script>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="line-height:150%;">
            注：
            1.续卡即修改原有卡类型。<br/>
            2.并增加续卡类型的正价及赠送次数到用户持有卡上<br/>
            3.续卡必须与原卡类型一样（如都是卡次消费或者是金额消费）<br/>
            3.1如续卡与原卡类型不一样时，在正价及赠送次数或者是金额为零时可转<br/>
            4.续卡不影响正常使用<br/>
            5.此操作不可逆，如需减少，请在变更中修改。
        </td>
    </tr>
</table>
</div>
<%} %>