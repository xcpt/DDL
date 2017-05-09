<%@ Page Language="C#" AutoEventWireup="true" Inherits="Web.CS.Manager.Roles.Operate" %>
<%if(!action.Equals("save")){ %>
    <div style="overflow-x:none;overflow-y:auto;height:500px;">
        <table width="100%" border="0"  class="treeTable" id="dnd-treeTable" cellpadding="0" cellspacing="0">
        <thead>
          <tr align="center">
            <th style="width:300px;">分类名称<input type="hidden" name="id" id="id" value="<%=roleid %>" /></th>
            <th>权限设置</th>
          </tr>
        </thead>
        <tbody>
            <%=Web.UI.Roles.GetRolePermissions(roleid,UserRoles,SuperAdmin)%>
        </tbody>
        </table>
    </div>
<%} %>    
<script type="text/javascript">
   $(".treeTable").treeTable();
    $("table#dnd-treeTable tbody tr").mousedown(function() {
      $("tr.selected").removeClass("selected");
      $(this).addClass("selected");
    });
    $("table#dnd-treeTable tbody tr span").mousedown(function() {
      $($(this).parents("tr")[0]).trigger("mousedown");
    });
</script>