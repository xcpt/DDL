<%@ Page Language="C#" AutoEventWireup="true" Inherits="Sys_Category_Lists" %>
<div class="Rtop">
    <div class="RlmM"><%=typename %>管理:</div>
</div>
<div class="Tgnk">
    <div class="gnANk">
    <%if (IsAdd)
          {%>
        <input type="submit" name="button" value="添加一级菜单" onclick="CreateWindow('Sys/Category/Add.aspx?type=<%=type %>', '添加一级栏目', '/Sys/Category/Add.aspx?action=save&type=<%=type %>', 500, 230, 'WeiXin_MenuAdd')" icon="icon-folder_add" />
        <%}
          if(IsOrder)
          {%>
        <input type="button" name="button" value="保存排序" onclick="AjaxFun('Sys/Category/Order.aspx?type=<%=type%>', ReadInputValue('dnd-treeTable'), ' ', '');" icon="icon-table_Sort" />
        <%} %>
    </div>
</div>
    <div class="RtbK TreeViewTable" style="overflow-x:none;overflow-y:auto">
        <table width="100%" border="0" class="treeTable" id="dnd-treeTable" cellpadding="0" cellspacing="0">
        <thead>
          <tr align="center">
            <th>菜单名称</th>
            <th style="width:100px" width="100px">首页</th>
            <th style="width:280px" width="280px">管理</th>
          </tr>
        </thead>
        <tbody id="WeiXinMenuListView">
        <%=Web.UI.Sys.Category.ViewHtml(type,IsModi,IsAdd,IsDel)%>
        </tbody>
        </table>
</div>
<script type="text/javascript">
    $(".treeTable").treeTable();
    $(".treeTable").find("tr.parent").each(function () { $(this).expand(); });
    ScrollFun(".Rnr", ".TreeViewTable", 70);
</script>