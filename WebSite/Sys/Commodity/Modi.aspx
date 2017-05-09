<%@ Page Language="C#" AutoEventWireup="true" Inherits="Sys_Commodity_Modi" %>
<%if(!action.Equals("save")){ %>
<div id="CommodityModi">
<input type="hidden" name="id" value="<%=cModel.id %>" />
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">
            商品名称：
        </th>
        <td align="left">
            <input type="text" class="validate[required,length[1,250]]" name="title" id="Commoditytitle" value="<%=cModel.title %>" style="width:270px;" size="40" maxlength="250" />
        </td>
    </tr>
    <tr>
        <th align="right">
            商品价格：
        </th>
        <td align="left">
            <input type="text" class="validate[required,custom[Number]]" name="price" id="Commodityprice" size="40" style="width:270px;" value="<%=cModel.price %>" maxlength="250" />
        </td>
    </tr>
    <tr>
        <th align="right">卡次消费：</th>
        <td align="left">
            <input type="checkbox" name="iscard" id="Commodityiscard"<%=Base.Fun.fun.isChecked(cModel.iscard,"1") %> value="1" />，勾选之后此商品可卡次消费。
        </td>
    </tr>
    <tr>
        <th align="right">可得积分：</th>
        <td align="left">
            <input type="text" class="validate[required,custom[Number]]" name="score" id="score" size="10" value="<%=cModel.score %>" maxlength="250" />
        </td>
    </tr>
</table>
</div>
<%} %>
