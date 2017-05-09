<%@ Page Language="C#" AutoEventWireup="true" Inherits="score_rule_Add" %>
<%if(!action.Equals("save")){ %>
<div id="ruleAdd" style="overflow-y:auto;height:200px;">
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">
            名称：
        </th>
        <td align="left">
            <input type="text" class="validate[required]" name="title" id="ruletitle" size="50" />
        </td>
    </tr>
    <tr>
        <th align="right">
            系数：
        </th>
        <td align="left">
            <input type="text" name="coefficient" value="1.1" class="validate[required,custom[Decimal]]" id="rulecoefficient" size="10" />
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            时间范围：
        </th>
        <td align="left">
            <input type="text" name="starttime" class="validate[required]" value="<%=DateTime.Now.ToString("yyyy-MM-dd") %>" id="rulestarttime" readonly="readonly" onClick="WdatePicker({ skin: 'ext', maxDate: '#F{$dp.$D(\'ruleendtime\')}' })" size="9"/>-<input type="text" name="endtime" id="ruleendtime" class="validate[required]" readonly="readonly" onClick="WdatePicker({ skin: 'ext', minDate: '#F{$dp.$D(\'rulestarttime\')}' })" size="9"/>
        </td>
    </tr>
</table>
</div>
<%} %>
