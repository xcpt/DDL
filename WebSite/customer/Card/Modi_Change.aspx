<%@ Page Language="C#" AutoEventWireup="true" Inherits="customer_Card_Modi_Change" %>
<%if(!action.Equals("save")){ %>
<div id="CardModi">
<input type="hidden" name="id" value="<%=cModel.cardid%>" />
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="100" align="right">会员卡号：</th>
        <td align="left" colspan="3"><%=cModel.cardNo %></td>
    </tr>
    <tr>
        <th align="right">卡类型：</th>
        <td align="left">
            <select disabled="disabled" id="Cardcardtypeid" style="width:200px;">
                <option value="0">请选择</option>
                <%=Web.UI.customer.CardType.GetOption(StoresID,cModel.cardtypeid) %>
            </select>
            <script type="text/javascript">$("#Cardcardtypeid").chosen();</script>
        </td>
        <th align="right">变更类型：</th>
        <td align="left">
            <select name="cardtypeid" id="NewCardcardtypeid" style="width:200px;">
                <option value="0">请选择</option>
                <%=Web.UI.customer.CardType.GetOption(StoresID,cModel.cardtypeid) %>
            </select>
            <script type="text/javascript">$("#NewCardcardtypeid").chosen();</script>
        </td>
    </tr>
    <tr>
        <th align="right">正价次数：</th>
        <td align="left">
            <input type="text" disabled="disabled" id="Cardpositivenum" value="<%=cModel.surpluspositivenum %>" size="20" />
        </td>
        <th align="right" width="100">增加次数：</th>
        <td align="left">
            <input type="text" class="validate[required,custom[Number]]" name="positivenum" value="0" id="NewCardpositivenum" size="5" />增加写正数，减少写负数
        </td>
    </tr>
    <tr>
        <th align="right">赠送次数：</th>
        <td align="left">
            <input type="text" disabled="disabled" id="Cardnegativenum" value="<%=cModel.surplusnegativenum %>" size="20" />
        </td>
        <th align="right">增加次数：</th>
        <td align="left">
            <input type="text" class="validate[required,custom[Number]]" value="0" name="negativenum" id="NewCardnegativenum" size="5" />增加写正数，减少写负数
        </td>
    </tr>
    <tr>
        <th align="right">现有金额：</th>
        <td align="left">
           <input type="text" disabled="disabled" id="Cardprice" value="<%=cModel.surplusprice %>" size="8" />
        </td>
        <th align="right">增加金额：</th>
        <td align="left">
           <input type="text" class="validate[custom[Number]]" value="0" name="price" id="NewCardprice" size="5" />增加写正数，减少写负数
        </td>
    </tr>
    <tr>
        <th align="right">失效日期：</th>
        <td align="left"><input type="text" disabled="disabled" id="Cardendtime" value="<%=Web.UI.Ami.DateTimeFormat(cModel.endtime, "YY04-MM-DD") %>" size="9" /></td>
        <th align="right">变更日期：</th>
        <td align="left"><input type="text" name="endtime" id="NewCardendtime" readonly="readonly" onclick="WdatePicker({ skin: 'ext', minDate: '#F{$dp.$D(\'Cardendtime\')}' })" size="9" /></td>
    </tr>
</table>
</div>
<%} %>