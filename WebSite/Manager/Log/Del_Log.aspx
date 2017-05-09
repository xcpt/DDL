<%@ Page Language="C#" AutoEventWireup="true" Inherits="Web.CS.Manager.Log.Del_Log" %>
<div id="AutoTask_DataBase" style="height:170px;">
<table class="table StyleView" width="100%" height="100%">
    <tr>
        <th width="70" align="right">计划任务</th>
        <td align="left"><textarea style="display:none;" id="AutoTime" name="AutoTime"><%=timecontent %></textarea><div><input type="button" value="设置时间计划" icon="icon-time" onclick="AutoTaskFun($id('AutoTime'), 10, 600);" /><input type="button" value="删除时间计划" id="AutoTime_Button" icon="icon-time_delete"<%=(string.IsNullOrEmpty(timecontent)?" disabled=\"disabled\"":"") %> onclick="DelAutoTaskFun('AutoTime');" /></div>
        <div id="AutoTime_View" style="height:75px;overflow-x:none;overflow-y:auto;clear:both;text-align:left;"></div></td>
    </tr>
    <tr>
        <th align="right">删除日志</th>
        <td align="left">删除<span style="display:inline-block;width:150px;padding:10px 5px 0px"><input type="hidden" value="<%=del %>" name="delday" id="delday" /></span>天前的日志文件。</td>
    </tr>
</table>
</div>
<script type="text/javascript">
    ViewTaskTime($id("AutoTime"));
    jQuery("#delday").slider({ from: 2, to: 100, step: 1, smooth: true, round: 0, dimension: "&nbsp;", skin: "round" });
</script>