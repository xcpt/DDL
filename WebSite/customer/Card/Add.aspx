<%@ Page Language="C#" AutoEventWireup="true" Inherits="customer_Card_Add" %>
<%if(!action.Equals("save")){ %>
<div id="CardAdd">
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="100" align="right">会员卡号：</th>
        <td align="left" colspan="3">
            <input type="text" class="validate[required,length[6,6]]" name="cardNo" value="<%=cardNo %>" id="CardcardNo" size="30" maxlength="250" />
        </td>
    </tr>
    <tr>
        <th width="100" align="right">卡序号：</th>
        <td align="left" colspan="3">
            <input type="text" name="cardNumber" class="validate[required,length[10,10]] text" placeholder="输入卡序号" id="CardcardNumber" size="50" maxlength="250" /> 
            <script type="text/javascript">
                $("#CardcardNumber").unbind("keydown").keydown(function (event) {
                    if (event.keyCode == 13) {
                        $(this).select();
                        return false;
                    }
                }).focus();
            </script>
        </td>
    </tr>
    <tr>
        <th align="right">卡类型：</th>
        <td align="left" colspan="3">
            <%if (cardTypeIsAdd)
              { %>
            <div style="float:right;"><input type="submit" name="button" id="button" onclick="CreateWindow('customer/CardType/Add.aspx', '添加卡类型', 'customer/CardType/Add.aspx?action=save&idname=Cardcardtypeid', 600, 380, 'CardTypeAdd')" icon="icon-addNew" value="添加卡类型" /></div>
            <%} %>
            <select name="cardtypeid" id="Cardcardtypeid" style="width:200px;">
                <option value="0">请选择</option>
                <%=Web.UI.customer.CardType.GetOption(StoresID,"") %>
            </select>
            <script type="text/javascript">$("#Cardcardtypeid").chosen().on("change", function () {
    AjaxFun("customer/CardType/Lists_Read.aspx", "id="+$(this).val(), " ");
});</script>
        </td>
    </tr>
    <tr>
        <th align="right">消费类型：</th>
        <td align="left" id="Cardcardpaidmode" colspan="3">&nbsp</td>
    </tr>
    <tr>
        <th align="right">会员姓名：</th>
        <td align="left" colspan="3">
            <input type="text" name="id" id="Carduserid" size="50" />
            <script type="text/javascript">$("#Carduserid").autoSuggest("customer/user/intelligent.aspx?action=nocard", { asHtmlID: 'Carduserid_yq', asHtmlName: 'id', selectedItemProp: "name", maxLength: "1", searchObjProps: "name", ReadAll: false,prePopulate:[[<%=userid%>]] });</script>
        </td>
    </tr>
    <tr>
        <th align="right">正价次数：</th>
        <td align="left">
            <input type="text" class="validate[required,custom[onlyNumber]]" name="positivenum" id="Cardpositivenum" size="20" />
        </td>
        <th align="right">赠送次数：</th>
        <td align="left">
            <input type="text" class="validate[required,custom[onlyNumber]]" name="negativenum" id="Cardnegativenum" size="20" />
        </td>
    </tr>
    <tr>
        <th align="right">停卡限制：</th>
        <td align="left" colspan="3">
            <input type="checkbox" value="1" name="isclose" id="Cardisclose"/>
        </td>
    </tr>
    <tr>
        <th align="right">总金额：</th>
        <td align="left">
           <input type="text" class="validate[custom[Decimal]]" name="price" id="Cardprice" size="8" />按次不用输入金额
        </td>
        <th align="right">开卡送积分：</th>
        <td align="left">
           <input type="text" class="validate[required,custom[onlyNumber]]" value="0" name="openCardScore" id="CardopenCardScore" size="10" />
        </td>
    </tr>
    <tr>
        <th align="right">生效日期：</th>
        <td align="left"><input type="text" name="starttime" id="Cardstarttime" readonly="readonly" value="<%=DateTime.Now.ToString("yyyy-MM-dd")%>" onclick="WdatePicker({ skin: 'ext', maxDate: '#F{$dp.$D(\'Cardendtime\')}' })" size="9" /></td>
        <th align="right">失效日期：</th>
        <td align="left"><input type="text" name="endtime" id="Cardendtime" readonly="readonly" onclick="WdatePicker({ skin: 'ext', minDate: '#F{$dp.$D(\'Cardstarttime\')}' })" size="9" /></td>
    </tr>
    <tr>
        <th align="right">备注：</th>
        <td align="left" colspan="3">
            <textarea name="content" id="Cardcontent" style="width: 466px; height: 45px;"><%=content %></textarea>
        </td>
    </tr>
</table>
</div>
<%} %>