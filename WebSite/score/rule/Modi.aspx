<%@ Page Language="C#" AutoEventWireup="true" Inherits="score_rule_Modi" %>
<%if(!action.Equals("save")){ %>
<div id="ruleModi" style="overflow-y:auto;height:200px;">
<input type="hidden" name="id" value="<%=rModel.id %>" />
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">
            名称：
        </th>
        <td align="left">
            <input type="text" class="validate[required]" name="title" value="<%=rModel.title %>" id="ruletitle" size="50" />
        </td>
    </tr>
    <tr>
        <th align="right">
            系数：
        </th>
        <td align="left">
            <input type="text" name="coefficient" value="<%=rModel.coefficient %>" class="validate[required,custom[Decimal]]" id="rulecoefficient" size="10" />
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            时间范围：
        </th>
        <td align="left">
            <input type="text" name="starttime" class="validate[required]" value="<%=Web.UI.Ami.DateTimeFormat(rModel.starttime,"YY04-MM-DD") %>" id="rulestarttime" readonly="readonly" onClick="WdatePicker({ skin: 'ext', maxDate: '#F{$dp.$D(\'ruleendtime\')}' })" size="9"/>-<input type="text" name="endtime" id="ruleendtime" class="validate[required]" readonly="readonly" value="<%=Web.UI.Ami.DateTimeFormat(rModel.endtime,"YY04-MM-DD") %>" onClick="WdatePicker({ skin: 'ext', minDate: '#F{$dp.$D(\'rulestarttime\')}' })" size="9"/>
        </td>
    </tr>
</table>
</div>
<%} %>
