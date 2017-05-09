<%@ Page Language="C#" AutoEventWireup="true" Inherits="score_rule_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">积分规则:</div>
</div>
<div class="Tgnk">
	<div class="Rtss"<%=IsAdd?"":" style=\"padding-bottom:5px;\"" %>>
	  <div style="float:left" id="SearchInputValue">名称：<input name="Title" type="text" id="SearchruleTitle" size="30" />&nbsp;&nbsp;时间：<input type="text" name="stime" id="Searchrulestime" readonly="readonly" onClick="WdatePicker({skin:'ext',maxDate:'#F{$dp.$D(\'Searchruleetime\')}'})" size="9"/>-<input type="text" name="etime" id="Searchruleetime" readonly="readonly" onClick="WdatePicker({skin:'ext',minDate:'#F{$dp.$D(\'Searchrulestime\')}'})" size="9"/>
	  </div>
	  <div style="float:left"><input type="submit" name="button" id="SearchButton" value="搜 索" onclick="$('#ruleGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
    <%if (IsAdd)
      { %>
    <div class="gnANk">
        <input type="submit" name="button" id="button" onclick="CreateWindow('score/rule/Add.aspx', '添加积分规则','score/rule/Add.aspx?action=save',500, 140,'ruleAdd')" icon="icon-addNew" value="添加积分规则" />
    </div>
    <%} %>
</div>
<div class="RtbK">
    <table id="ruleGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#ruleGrid").flexigrid
    (
    {
        url: 'score/rule/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '名称', name: 'title',autoSize:true, width: 100, sortable: false, align: 'left'},
            { display: '系数', name: 'coefficient', width: 30, sortable: false, align: 'left'},
            { display: '开始时间', name: 'starttime', width: 100, sortable: false, align: 'left',process:TimeFun},
            { display: '结束时间', name: 'endtime', width: 100, sortable: false, align: 'left',process:TimeFun},
            { display: '添加时间', name: 'addtime', width: 130, sortable: false, align: 'right'},
            { display: '管理', name: 'Q', width: 34, sortable: false, align: 'left',process:ManagerFun }
        ],
        showcheckbox:false,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.score.rule.View(StoresID, title, starttime, endtime)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
    }
    );
    function TimeFun(value,id)
    {
        return value.split(' ')[0].split('/').join('-');
    }
    function ManagerFun(value,id,row)
    {
        var str=new Array();
        <%if(IsModi){%>
        str.push("<a href='#' onclick=\"GridModiy('"+id+"', 'score/rule/Modi.aspx','修改积分规则', 'score/rule/Modi.aspx?action=save', 500, 140,'ruleModi');return false;\" >修改</a>");
        <%}
        if(IsDel){%>
        if(row.cell[4]=="2")
        {
            str.push("<a href=\"\" onclick=\"GridDel('"+id+"','score/rule/Del.aspx');return false;\" >删除</a>");
        }
        <%}%>
        return str.join(" | ");
    }
    GridFun(".Rnr", gridList, <%=IsAdd?"167":"140" %>, 2);
</script>
<%}
  else
  {
      Response.Write(Web.UI.score.rule.View(StoresID, title, starttime, endtime));
  }%>