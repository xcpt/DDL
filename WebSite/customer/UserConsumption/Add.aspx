<%@ Page Language="C#" AutoEventWireup="true" Inherits="customer_UserConsumption_Add" %>
<%if(!action.Equals("save")){ %>
<div id="UserConsumptionAdd">
<input type="hidden" name="appointmentid" value="<%=appointmentid %>" />
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th align="right" width="80">会员姓名：</th>
        <td align="left" colspan="3">
            <input type="text" name="id" id="UserConsumptionuserid" size="50" />
            <script type="text/javascript">$("#UserConsumptionuserid").autoSuggest("customer/user/intelligent.aspx", {
    asHtmlID: 'UserConsumptionuserid_yq', asHtmlName: 'id', selectedItemProp: "name", maxLength: "1", searchObjProps: "name", ReadAll: false, prePopulate: [[<%=uaModel.userid%>]], selectOKFunction: function (v) {
        AjaxFun("customer/user/intelligent_mamas.aspx", "userid=" + v, "", function (hv) {
            $("#UserConsumptionmamasid").val(hv).trigger("chosen:updated");
        });
    }
});</script>
        </td>
    </tr>
    <tr>
        <th align="right">消费商品：</th>
        <td align="left" colspan="3">
            <select name="CommodityID" class="validate[required]" id="UserConsumptionCommodityID" style="width:200px;">
                <%=Web.UI.Sys.Commodity.GetOption(StoresID,"67") %>
            </select>
            <script type="text/javascript">$("#UserConsumptionCommodityID").chosen().on("change", function ()
{
    var id = $(this).val();
    $("#UserConsumptionCommodityIDView").html("请选择消费商品");
    $("#UserConsumptionPrice").val("");
    if (id.length > 0)
    {
        AjaxFun("Sys/Commodity/Lists_view.aspx", "idname=UserConsumptionPrice&id=" + id, " ", function (html) {
            $("#UserConsumptionCommodityIDView").html(html);
        });
    }
}); AjaxFun("Sys/Commodity/Lists_view.aspx", "idname=UserConsumptionPrice&id=" + $("#UserConsumptionCommodityID option:selected") .val(), " ", function (html) {
    $("#UserConsumptionCommodityIDView").html(html);
});</script>
        </td>
    </tr>
    <tr>
        <th align="right">消费提示：</th>
        <td align="left" id="UserConsumptionCommodityIDView" colspan="3">请选择消费商品</td>
    </tr>
    <tr>
        <th align="right">消费金额：</th>
        <td align="left"><input type="text" class="validate[required,custom[Decimal]]" name="price" id="UserConsumptionPrice" size="20" />元</td>
        <th align="right">消费方式：</th>
        <td align="left"><select name="IsCash" id="UserConsumptionIsCash" style="width:120px;">
                <%=Web.UI.Data.Basic.IsCash("0") %>
            </select>
            <script type="text/javascript">$("#UserConsumptionIsCash").chosen({ disable_search_threshold: 10 });</script></td>
    </tr>
    <tr>
        <th align="right">服务泳师：</th>
        <td align="left"><select name="swimteacherid" id="UserConsumptionswimteacherid" style="width:180px;">
                <%=Web.UI.Staff.swimteacher.GetOption(StoresID,uaModel.swimteacherid) %>
            </select>
            <script type="text/javascript">$("#UserConsumptionswimteacherid").chosen({ disable_search_threshold: 10 });</script>
        </td>
        <th align="right">满意度：</th>
        <td align="left"><select name="satisfactionid" id="UserConsumptionsatisfactionid" style="width:120px;">
                <%=Web.UI.Data.Basic.satisfactionid("1") %>
            </select>
            <script type="text/javascript">$("#UserConsumptionsatisfactionid").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <tr>
        <th align="right">泳圈型号：</th>
        <td align="left" colspan="3"><select name="mamasid" id="UserConsumptionmamasid" style="width:150px;">
                <option value="">请选择</option>
                <%=Web.UI.Sys.mamas.GetOption(StoresID,uaModel.mamasid) %>
            </select>
            <script type="text/javascript">$("#UserConsumptionmamasid").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <tr>
        <th align="right">游泳时长：</th>
        <td align="left"><input type="text" class="validate[custom[onlyNumber]]" name="timenum" id="UserConsumptiontimenum" size="20" />分钟</td>
        <th align="right">身高：</th>
        <td align="left"><input type="text" class="validate[custom[Decimal]]" name="height" id="UserConsumptionheight" size="20" />厘米</td>
    </tr>
     <tr>
        <th align="right">体重：</th>
        <td align="left"><input type="text" class="validate[custom[Decimal]]" name="weight" id="UserConsumptionweight" size="20" />千克</td>
        <th align="right">体温：</th>
        <td align="left"><input type="text" class="validate[custom[Decimal]]" name="temperature" id="UserConsumptiontemperature" size="20" />度</td>
    </tr>
    <tr>
        <th align="right">备注：</th>
        <td align="left" colspan="3">
            <textarea name="content" id="UserConsumptioncontent" style="width: 489px; height: 92px;"></textarea>
        </td>
    </tr>
</table>
</div>
<%} %>