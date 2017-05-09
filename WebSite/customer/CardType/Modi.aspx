<%@ Page Language="C#" AutoEventWireup="true" Inherits="customer_CardType_Modi" %>
<%if(!action.Equals("save")){ %>
<div id="CardTypeModi">
<input type="hidden" value="<%=ctModel.id %>" name="id" />
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th align="right" width="80">卡类型名称：</th>
        <td align="left" colspan="3">
            <input type="text" class="validate[required,length[1,250]]" name="title" value="<%=ctModel.title %>" id="CardTypeTitle" size="50" maxlength="250" />
        </td>
    </tr>
    <tr>
        <th align="right">业务类型：</th>
        <td align="left" colspan="3">
            <%if (businessidIsAdd)
              { %>
            <div style="float:right;"><input type="button" name="button" id="Submit1" onclick="CreateWindow('customer/Cardbusinessid/Add.aspx?idname=CardTypebusinessid', '添加卡业务', 'customer/Cardbusinessid/Add.aspx?action=save&idname=CardTypebusinessid', 400, 50, 'memberAdd')" icon="icon-addNew" value="添加卡业务" /></div>
            <%} %>
            <select name="businessid" class="validate[required,length[1,250]]" id="CardTypebusinessid" style="width:200px;">
                <%=Web.UI.customer.Cardbusinessid.GetOption(StoresID,ctModel.businessid) %>
            </select>
            <script type="text/javascript">$("#CardTypebusinessid").chosen();</script>
        </td>
    </tr>
    <tr>
        <th align="right">有 效 期：</th>
        <td align="left">
            <select name="effectivetime" class="validate[required,length[1,250]]" id="CardTypeeffectivetime" style="width:100px;">
                <%=Web.UI.Data.Basic.effectivetime(ctModel.effectivetime) %>
            </select>
            <script type="text/javascript">$("#CardTypeeffectivetime").chosen();</script>
        </td>
        <th align="right" width="80">计费方式：</th>
        <td align="left"><select name="paidmode" class="validate[required,length[1,250]]" id="CardTypepaidmode">
            <option value="0"<%=Base.Fun.fun.isSelected(ctModel.paidmode,"0") %>>按次</option>
            <option value="1"<%=Base.Fun.fun.isSelected(ctModel.paidmode,"1") %>>按金额</option>
        </select><script type="text/javascript">$("#CardTypepaidmode").chosen({ SearchCardTypepaidmode: 10 });</script></td>
    </tr>
    <tr>
        <th align="right">正价次数：</th>
        <td align="left">
            <input type="text" class="validate[required,custom[onlyNumber]]" value="<%=ctModel.positivenum %>" name="positivenum" id="CardTypepositivenum" size="20" />
        </td>
        <th align="right">赠送次数：</th>
        <td align="left">
            <input type="text" class="validate[required,custom[onlyNumber]]" value="<%=ctModel.negativenum %>" name="negativenum" id="CardTypenegativenum" size="20" />
        </td>
    </tr>
    <tr>
        <th align="right">金额：</th>
        <td align="left">
           <input type="text" class="validate[required,custom[Decimal]]" value="<%=ctModel.price %>" name="price" id="CardTypeprice" size="20" />
        </td>
        <th align="right">折扣比例：</th>
        <td align="left">
           <input type="text" class="validate[required,custom[Decimal]]" name="discount" id="CardTypediscount" value="<%=ctModel.discount %>" size="10" />金额消费时有效
        </td>
    </tr>
    <tr>
        <th align="right">开卡送积分：</th>
        <td align="left" colspan="3">
           <input type="text" class="validate[required,custom[onlyNumber]]" value="<%=ctModel.opencardexchange %>" name="opencardexchange" id="CardTypeopenCardScore" size="20" />
        </td>
    </tr>
    <tr>
        <th align="right">备注：</th>
        <td align="left" colspan="3">
            <textarea name="content" id="CardTypecontent" style="width: 480px; height: 84px;"><%=ctModel.content %></textarea>
        </td>
    </tr>
</table>
</div>
<%} %>