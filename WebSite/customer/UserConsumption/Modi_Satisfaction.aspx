<%@ Page Language="C#" AutoEventWireup="true" Inherits="customer_UserConsumption_Modi_Satisfaction" %>
<%if(!action.Equals("save")){ %>
<div id="UserConsumptionModi">
<input type="hidden" name="id" value="<%=id %>" />
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th align="right">原满意度：</th>
        <td align="left"><select id="UserConsumptionoldsatisfactionid" disabled="disabled" style="width:120px;">
                <%=Web.UI.Data.Basic.satisfactionid(satisfactionid) %>
            </select>
            <script type="text/javascript">$("#UserConsumptionoldsatisfactionid").chosen({ disable_search_threshold: 10 });</script>
        </td>
        <th align="right">新满意度：</th>
        <td align="left"><select name="satisfactionid" id="UserConsumptionsatisfactionid" style="width:120px;">
                <%=Web.UI.Data.Basic.satisfactionid("1") %>
            </select>
            <script type="text/javascript">$("#UserConsumptionsatisfactionid").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <tr>
        <th align="right" width="80">修改原因：</th>
        <td align="left" colspan="3">
            <textarea name="content" class="validate[required,length[1,500]]" id="UserConsumptioncontent" style="width: 387px; height: 134px;"></textarea>
        </td>
    </tr>
</table>
</div>
<%} %>