<%@ Page Language="C#" AutoEventWireup="true" Inherits="customer_UserConsumption_Modi_Info" %>
<%if(!action.Equals("save")){ %>
<div id="UserConsumptionModi">
<input type="hidden" name="id" value="<%=ucModel.id %>" />
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th align="right" width="80">会员姓名：</th>
        <td align="left" colspan="3">
            <input type="text" name="userid" id="UserConsumptionuserid" size="50" />
            <script type="text/javascript">
                $("#UserConsumptionuserid").autoSuggest("customer/user/intelligent.aspx", { asHtmlID: 'UserConsumptionuserid_yq', asHtmlName: 'userid', selectedItemProp: "name", maxLength: "1", searchObjProps: "name", ReadAll: false, prePopulate: [[<%=ucModel.userid%>]], isdel: false });
            </script>
        </td>
    </tr>
    <tr>
        <th align="right">消费商品：</th>
        <td align="left" colspan="3">
            <select name="CommodityID"　class="validate[required]" disabled="disabled" id="UserConsumptionCommodityID" style="width:200px;">
                <%=Web.UI.Sys.Commodity.GetOption(StoresID,ucModel.CommodityID) %>
            </select>
            <script type="text/javascript">$("#UserConsumptionCommodityID").chosen().on("change", function () {
    var id = $(this).val();
    $("#UserConsumptionCommodityIDView").html("请选择消费商品");
    $("#UserConsumptionPrice").val("");
    if (id.length > 0) {
        AjaxFun("Sys/Commodity/Lists_view.aspx", "idname=UserConsumptionPrice&id=" + id, " ", function (html) {
            $("#UserConsumptionCommodityIDView").html(html);
        });
    }
});</script>
        </td>
    </tr>
    <tr>
        <th align="right">消费提示：</th>
        <td align="left" id="UserConsumptionCommodityIDView" colspan="3"></td>
    </tr>
    <tr>
        <th align="right">消费金额：</th>
        <td align="left"><input type="text" class="validate[required,custom[Decimal]]" disabled="disabled" value="<%=ucModel.price %>" name="price" id="UserConsumptionPrice" size="20" />元</td>
        <th align="right">消费方式：</th>
        <td align="left"><select name="IsCash" id="UserConsumptionIsCash" disabled="disabled" style="width:120px;">
                <%=Web.UI.Data.Basic.IsCash(ucModel.IsCash) %>
            </select>
            <script type="text/javascript">$("#UserConsumptionIsCash").chosen({ disable_search_threshold: 10 });</script></td>
    </tr>
    <tr>
        <th align="right">服务泳师：</th>
        <td align="left"><select name="swimteacherid" id="UserConsumptionswimteacherid" style="width:120px;">
                <%=Web.UI.Staff.swimteacher.GetOption(StoresID,ucModel.swimteacherid) %>
            </select>
            <script type="text/javascript">$("#UserConsumptionswimteacherid").chosen({ disable_search_threshold: 10 });</script>
        </td>
        <th align="right">满意度：</th>
        <td align="left"><select name="satisfactionid" id="UserConsumptionsatisfactionid" disabled="disabled" style="width:120px;">
                <%=Web.UI.Data.Basic.satisfactionid(ucModel.satisfactionid) %>
            </select>
            <script type="text/javascript">$("#UserConsumptionsatisfactionid").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <tr>
        <th align="right">泳圈型号：</th>
        <td align="left" colspan="3"><select name="mamasid" id="UserConsumptionmamasid" style="width:150px;">
                <option value="">请选择</option>
                <%=Web.UI.Sys.mamas.GetOption(StoresID,ucModel.mamasid) %>
            </select>
            <script type="text/javascript">$("#UserConsumptionmamasid").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <tr>
        <th align="right">游泳时长：</th>
        <td align="left"><input type="text" class="validate[custom[onlyNumber]]" value="<%=ucModel.timenum %>" name="timenum" id="UserConsumptiontimenum" size="20" />分钟</td>
        <th align="right">身高：</th>
        <td align="left"><input type="text" class="validate[custom[Decimal]]" value="<%=ucModel.height %>" name="height" id="UserConsumptionheight" size="20" />厘米</td>
    </tr>
     <tr>
        <th align="right">体重：</th>
        <td align="left"><input type="text" class="validate[custom[Decimal]]" value="<%=ucModel.weight %>" name="weight" id="UserConsumptionweight" size="20" />千克</td>
        <th align="right">体温：</th>
        <td align="left"><input type="text" class="validate[custom[Decimal]]" value="<%=ucModel.temperature %>" name="temperature" id="UserConsumptiontemperature" size="20" />度</td>
    </tr>
    <tr>
        <th align="right">备注：</th>
        <td align="left" colspan="3">
            <textarea name="content" id="UserConsumptioncontent" style="width: 489px; height: 92px;"><%=ucModel.content %></textarea>
        </td>
    </tr>
</table>
</div>
<%} %>