<%@ Page Language="C#" AutoEventWireup="true" Inherits="Staff_position_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">
        职位管理:</div>
</div>
<div class="Tgnk">
	<div class="Rtss"<%=IsAdd?"":" style=\"padding-bottom:5px;\"" %>>
	  <div style="float:left" id="SearchInputValue">名称：<input name="Title" type="text" id="SearchpositionTitle" size="30" />&nbsp;&nbsp;级别：<input type="text" name="level" id="Searchpositionlevel" size="30"/></div>
	  <div style="float:left"><input type="submit" name="button" id="SearchButton" value="搜 索" onclick="$('#positionGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
    <%if (IsAdd)
      { %>
    <div class="gnANk">
        <input type="submit" name="button" id="button" onclick="CreateWindow('Staff/position/Add.aspx', '添加职位','Staff/position/Add.aspx?action=save',500, 335,'positionAdd')" icon="icon-addNew" value="添加职位" />
    </div>
    <%} %>
</div>
<div class="RtbK">
    <table id="positionGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#positionGrid").flexigrid
    (
    {
        url: 'Staff/position/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '名称', name: 'title', width: 100,autoSize:true, sortable: false, align: 'left'},
            { display: '等级', name: 'level', width: 100, sortable: false, align: 'left'},
            { display: '底薪', name: 'salary', width: 60, sortable: false, align: 'right'},
            { display: '保险', name: 'deducted', width: 60, sortable: false, align: 'right'},
            { display: '提成', name: 'istake', width: 35, sortable: false, align: 'left',process:TakeFun},
            { display: '管理', name: 'Q', width: 90, sortable: false, align: 'left',process:ManagerFun }
        ],
        showcheckbox:false,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.Staff.position.View(StoresID, title, level)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
    }
    );
    function TakeFun(value,id)
    {
        return ShowTrueOrFalse(value);
    }
    function ManagerFun(value,id)
    {
        var str=new Array();
        <%if(IsModi){%>
        str.push("<a href='#' onclick=\"GridModiy('"+id+"', 'Staff/position/Modi.aspx','修改职位信息', 'Staff/position/Modi.aspx?action=save', 500, 335,'positionModi');return false;\" >修改</a>");
        <%}
          if(IsDel){%>
        str.push("<a href=\"\" onclick=\"GridDel('"+id+"','Staff/position/Del.aspx');return false;\">删除</a>");
        <%}%>
        return str.join(" | ");
    }
    GridFun(".Rnr", gridList, <%=IsAdd?"167":"140" %>, 2);
</script>
<%}
  else
  {
      Response.Write(Web.UI.Staff.position.View(StoresID, title, level));
  }%>