<%@ Page Language="C#" AutoEventWireup="true" Inherits="Staff_performance_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">绩效管理:</div>
</div>
<div class="Tgnk">
	<div class="Rtss"<%=IsAdd?"":" style=\"padding-bottom:5px;\"" %>>
	  <div style="float:left" id="SearchInputValue">姓名：<select name="memberid" id="Searchperformancememberid">
          <option value="">&nbsp;</option>
          <%=Web.UI.Staff.member.GetOption(StoresID,"") %>
        </select>&nbsp;&nbsp;时间：<input type="text" name="stime" id="Searchperformancestime" readonly="readonly" onClick="WdatePicker({skin:'ext',maxDate:'#F{$dp.$D(\'Searchperformanceetime\')}'})" size="9"/>-<input type="text" name="etime" id="Searchperformanceetime" readonly="readonly" onClick="WdatePicker({skin:'ext',minDate:'#F{$dp.$D(\'Searchperformancestime\')}'})" size="9"/></div>
	  <div style="float:left"><input type="submit" name="button" id="SearchButton" value="搜 索" onclick="$('#performanceGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
    <%if (IsAdd)
      { %>
    <div class="gnANk">
        <input type="submit" name="button" id="button" onclick="CreateWindow('Staff/performance/Add.aspx', '添加绩效','Staff/performance/Add.aspx?action=save',500, 290,'performanceAdd')" icon="icon-addNew" value="添加绩效" />
    </div>
    <%} %>
</div>
<div class="RtbK">
    <table id="performanceGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#performanceGrid").flexigrid
    (
    {
        url: 'Staff/performance/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '姓名', name: 'Name', width: 100,autoSize:true, sortable: false, align: 'left'},
            { display: '类型', name: 'type', width: 100, sortable: false, align: 'left',process:TypeFun},
            { display: '时间', name: 'datetime', width: 70, sortable: false, align: 'left',process:TimeFun},
            { display: '金额', name: 'price', width: 60, sortable: false, align: 'right',process:PriceFun},
            { display: '摘要', name: 'content', width: 350, sortable: false, align: 'left'},
            { display: '管理', name: 'Q', width: 30, sortable: false, align: 'left',process:ManagerFun }
        ],
        showcheckbox:false,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.Staff.performance.View(StoresID, memberid, statustime, endtime)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
    }
    );
    function TypeFun(value,id)
    {
        var s=<%=Web.UI.Data.Basic.performanceTypeToJs("performanceType")%>;
        return s["performanceType"+value];
    }
    function TimeFun(value,id)
    {
        if(value.length>0)
        {
            value=value.split(' ')[0].replace("/","-").replace("/","-");
        }
        return value;
    }
    function PriceFun(value,id)
    {
        if(value.indexOf("-")!=-1)
        {
            return "<font color=\"red\">"+value+"</font>";
        }else{
            return "<font color=\"blue\">"+value+"</font>";
        }
    }
    function ManagerFun(value,id)
    {
        var str=new Array();
        <%if(IsDel){%>
        str.push("<a href=\"\" onclick=\"GridDel('"+id+"','Staff/performance/Del.aspx');return false;\">删除</a>");
        <%}%>
        return str.join(" | ");
    }
    GridFun(".Rnr", gridList, <%=IsAdd?"167":"140" %>, 2);
    $("#Searchperformancememberid").chosen({ width:"120px"});
</script>
<%}
  else
  {
      Response.Write(Web.UI.Staff.performance.View(StoresID,memberid, statustime, endtime));
  }%>