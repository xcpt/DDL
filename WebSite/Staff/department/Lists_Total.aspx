<%@ Page Language="C#" AutoEventWireup="true" Inherits="Staff_department_Lists_Total" %>
<div id="SearchInputKHValue" style="padding:5px;text-align:left;">
    <div style="float:right"><input type="submit" name="button" id="Submit1" value="搜 索" onclick="AjaxFun('Staff/department/Lists_total.aspx','action=view&id=<%=departmentid%>&'+ReadInputValue('SearchInputKHValue'),' ','#departmentView');" icon="icon-zoom" /></div>
    考核日期：<input type="text" name="stime" id="SearchCardLogstime" value="<%=starttime %>" readonly="readonly" onClick="WdatePicker({ skin: 'ext', maxDate: '#F{$dp.$D(\'SearchCardLogetime\')}' })" size="9"/>-<input type="text" name="etime" id="SearchCardLogetime" readonly="readonly" value="<%=endtime %>" onClick="WdatePicker({ skin: 'ext', minDate: '#F{$dp.$D(\'SearchCardLogstime\')}' })" size="9"/>
</div>
<div id="departmentView" style="overflow-y:auto;height:360px;">
<%=str %>
</div>