<%@ Page Language="C#" AutoEventWireup="true" Inherits="Web.CS.Manager.Log.Lists_Error" %>
<div class="Rtop">
    <div class="RlmM">
        日志管理：</div><a href="#" onclick="AjaxFun('Manager/Log/lists.aspx?action=view', '', ' ', '.Rnr', '.Rnr');return false;">操作日志</a><a href="#" class="dq" onclick="return false;">错误日志</a>
</div>
<div class="Tgnk">
    <div class="gnANk"><%if (IsDel)
      { %>
        <input icon="icon-delete" type="button" name="button" value="删除1周前" onclick="AjaxFun('Manager/Log/Del_Error.aspx','action=week','正在删除1周前日志');" />
        <input icon="icon-delete" type="button" name="button" value="删除1月前" onclick="AjaxFun('Manager/Log/Del_Error.aspx', 'action=month', '正在删除1月前日志');" />
        <input icon="icon-delete" type="button" name="button" value="删除所有" onclick="AjaxFun('Manager/Log/Del_Error.aspx', 'action=all', '正在删除所有日志');" />
        <span style="float:left;">&nbsp;&nbsp;</span>
        <%} %></div>
</div>
<div class="RtbK TreeViewTable" style="overflow-x:none;overflow-y:auto">
        <table width="100%" border="0" class="treeTable" id="dnd-treeTable" cellpadding="0" cellspacing="0">
            <thead>
                <tr><th style="width:30px;">编号</th><th align="left" style="text-align:left;padding-left:5px;">日志</th><th style="width:130px">操作</th></tr>
            </thead>
            <tbody>
            <%
                Response.Write(Base.Error.Error.LogErrorList());
            %>
            </tbody>
        </table>
</div>
<script type="text/javascript">
    ScrollFun(".Rnr", ".TreeViewTable", 70);
</script>
