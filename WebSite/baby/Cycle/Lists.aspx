<%@ Page Language="C#" AutoEventWireup="true" Inherits="baby_Cycle_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">婴儿成长周期:</div>
</div>
<div class="Tgnk">
	<div class="Rtss"<%=IsAdd?"":" style=\"padding-bottom:5px;\"" %>>
	  <div style="float:left" id="SearchInputValue">名称：<input name="title" type="text" id="SearchCycleTitle" size="30" />&nbsp;&nbsp;婴儿类型：<select name="type" id="SearchCycletype">
          <option value="">&nbsp;</option>
          <%=Web.UI.Data.Basic.CycleType("") %>
        </select></div>
	  <div style="float:left"><input type="button" name="button" id="SearchButton" value="搜 索" onclick="$('#CycleGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
        <%if (IsAdd)
    { %>
    <div class="gnANk">
        <input type="submit" name="button" id="button" onclick="CreateWindow('baby/Cycle/Add.aspx', '成长周期','baby/Cycle/Add.aspx?action=save',400,185,'CycleAdd')" icon="icon-addNew" value="新增" />
    </div>
    <%} %>
</div>
<div class="RtbK">
    <table id="CycleGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#CycleGrid").flexigrid
    (
    {
        url: 'baby/Cycle/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '名称', name: 'title', width: 100,autoSize:true, sortable: false, align: 'left'},
            { display: '起始日龄', name: 'statusAge', width: 100, sortable: false, align: 'left'},
            { display: '截止日龄', name: 'endAge', width: 100, sortable: false, align: 'left'},
            { display: '类型', name: 'type', width: 60, sortable: false, align: 'left',process:BabyTypeFun},
            { display: '管理', name: 'Q', width: 70, sortable: false, align: 'left',process:ManagerFun }
        ],
        showcheckbox:false,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.baby.Cycle.View(title, type)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
    }
    );
    function BabyTypeFun(value,id)
    {
        var s=<%=Web.UI.Data.Basic.CycleTypeToJs("CycleType")%>;
        return s["CycleType"+value];
    }
    function ManagerFun(value,id,row)
    {
        var str=new Array();
        <%if(IsModi){%>
        str.push("<a href='#' onclick=\"GridModiy('"+id+"', 'baby/Cycle/Modi.aspx','修改成长周期', 'baby/Cycle/Modi.aspx?action=save', 400, 185,'CycleModi');return false;\" >修改</a>");
        <%}
        if(IsDel){%>
        str.push("<a href=\"\" onclick=\"GridDel('"+id+"','baby/Cycle/Del.aspx');return false;\" >删除</a>");
        <%}%>
        return str.join(" | ");
    }
    GridFun(".Rnr", gridList, <%=IsAdd?"167":"135" %>, 2);
    $("#SearchCycletype").chosen({ disable_search_threshold: 10 , width:"100px"});
</script>
<%}
  else
  {
      Response.Write(Web.UI.baby.Cycle.View(title, type));
  }%>