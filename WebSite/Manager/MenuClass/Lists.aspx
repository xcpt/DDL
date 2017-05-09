<%@ Page Language="C#" AutoEventWireup="true" Inherits="Web.CS.Manager.MenuClass.Lists" %>
<div class="Rtop">
    <div class="RlmM">
        栏目管理:</div>
</div>
<div class="Tgnk">
    <div class="gnANk">
    <%if (IsOperate)
      { %>
        <input type="submit" name="button" id="button" value="保存排序" icon="icon-table_Sort" onclick="SaveCategoryOrder();" />
        <%} %>
       <%-- <input type="submit" name="button" id="button" onclick="CreateWindow('Manager/MenuClass/Add.aspx', '添加','Manager/MenuClass/Add.aspx?action=save',500, 500,'MenuClassAdd')" value="添加" />--%>
    </div>
</div>
    <div class="RtbK" style="overflow-x:none;overflow-y:auto" id="menuclass">
        <table width="100%" border="0"  class="treeTable" id="dnd-treeTable" cellpadding="0" cellspacing="0">
        <thead>
          <tr align="center">
            <th>分类名称</th>
            <th style="width:60px">添加子类</th>
            <th style="width:40px">显示</th>
            <th style="width:40px">编辑</th>
            <th style="width:40px">删除</th>
          </tr>
        </thead>
        <tbody>
            <%=Web.UI.MenuClass.GetMenuClass(IsAdd,IsModi,IsDel,IsOperate) %>
        </tbody>
        </table>
</div>
<script type="text/javascript">
   $(".treeTable").treeTable();
   ScrollFun(".Rnr", "#menuclass", 70);
</script>

