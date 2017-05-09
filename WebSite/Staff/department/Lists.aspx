<%@ Page Language="C#" AutoEventWireup="true" Inherits="Staff_department_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">部门管理:</div>
</div>
<div class="Tgnk">
	<div class="Rtss"<%=IsAdd?"":" style=\"padding-bottom:5px;\"" %>>
	  <div style="float:left" id="SearchInputValue">部门名称：<input name="Title" type="text" id="departmentTitle" size="30" /></div>
	  <div style="float:left"><input type="submit" name="button" id="SearchButton" value="搜 索" onclick="$('#departmentGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
    <%if (IsAdd)
      { %>
    <div class="gnANk">
        <input type="submit" name="button" id="button" onclick="CreateWindow('Staff/department/Add.aspx', '添加部门','Staff/department/Add.aspx?action=save',500, 200,'departmentAdd')" icon="icon-vcard_add" value="添加部门" />
    </div>
    <%} %>
</div>
<div class="RtbK">
    <table id="departmentGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#departmentGrid").flexigrid
    (
    {
        url: 'Staff/department/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '名称', name: 'title', width: 200, sortable: false, align: 'left'},
            { display: '部门负责人', name: 'Name', width: 200, sortable: false, align: 'left'},
            { display: '描述', name: 'description', width: 200,autoSize:true, sortable: false, align: 'left'},
            { display: '操作管理', name: 'Q', width: 130, sortable: false, align: 'left',process:ManagerFun }
        ],
        showcheckbox:false,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.Staff.department.View(StoresID, title)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
    }
    );
    function ManagerFun(value,id)
    {
        var str=new Array();
        str.push("<a href='#' onclick=\"GridModiy('"+id+"', 'Staff/department/Lists_Total.aspx','部门绩效考核', null, 500, 400);return false;\" >绩效考核</a>");
        <%if(IsModi){%>
        str.push("<a href='#' onclick=\"GridModiy('"+id+"', 'Staff/department/Modi.aspx','修改小区', 'Staff/department/Modi.aspx?action=save', 500, 200,'departmentModi');return false;\" >修改</a>");
        <%}
          if(IsDel){%>
        str.push("<a href=\"\" onclick=\"GridDel('"+id+"','Staff/department/Del.aspx');return false;\" >删除</a>");
        <%}%>
        return str.join(" | ");
    }
    GridFun(".Rnr", gridList, <%=IsAdd?"167":"140" %>, 2);
</script>
<%}
  else
  {
      Response.Write(Web.UI.Staff.department.View(StoresID, title));
  }%>