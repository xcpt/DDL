<%@ Page Language="C#" AutoEventWireup="true" Inherits="Staff_score_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">分值管理:</div>
</div>
<div class="Tgnk">
	<div class="Rtss"<%=IsAdd?"":" style=\"padding-bottom:5px;\"" %>>
	  <div style="float:left" id="SearchInputValue">姓名：<select name="memberid" id="Searchscorememberid">
          <option value="">&nbsp;</option>
          <%=Web.UI.Staff.member.GetOption(StoresID,"") %>
        </select>&nbsp;&nbsp;增减：<select name="isadd" id="Searchscoreisadd" style="width:70px;">
                <option value="" selected="selected">&nbsp;</option>
                <option value="1">增加</option>
                <option value="0">扣减</option>
            </select>&nbsp;&nbsp;考勤类型：<select name="type" id="Searchscoretype" style="width:100px;">
                <option value="" selected="selected">&nbsp;</option>
                <%=Web.UI.Data.Basic.performanceType("") %>
            </select>&nbsp;&nbsp;时间：<input type="text" name="stime" id="Searchperformancestime" readonly="readonly" onClick="WdatePicker({skin:'ext',maxDate:'#F{$dp.$D(\'Searchperformanceetime\')}'})" size="9"/>-<input type="text" name="etime" id="Searchperformanceetime" readonly="readonly" onClick="WdatePicker({skin:'ext',minDate:'#F{$dp.$D(\'Searchperformancestime\')}'})" size="9"/></div>
	  <div style="float:left"><input type="submit" name="button" id="SearchButton" value="搜 索" onclick="$('#positionGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
    <%if (IsAdd)
      { %>
    <div class="gnANk">
        <input type="submit" name="button" id="button" onclick="CreateWindow('Staff/score/Add.aspx', '扣减、增加分值','Staff/score/Add.aspx?action=save',500, 335,'scoreAdd')" icon="icon-addNew" value="扣减、增加分值" />
    </div>
    <%} %>
</div>
<div class="RtbK">
    <table id="scoreGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#scoreGrid").flexigrid
    (
    {
        url: 'Staff/score/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '员工姓名', name: 'name', width: 100,autoSize:true, sortable: false, align: 'left'},
            { display: '考勤类型', name: 'type', width: 100, sortable: false, align: 'left',process:TypeFun},
            { display: '记录时间', name: 'datetime', width: 70, sortable: false, align: 'left',process:TimeFun},
            { display: '增减', name: 'isadd', width: 30,hide:true, sortable: false, align: 'right'},
            { display: '分值', name: 'num', width: 60, sortable: false, align: 'right',process:numFun},
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
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.Staff.score.View(StoresID, memberid, isadd, type, starttime, endtime)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
    }
    );
    function TimeFun(value,id)
    {
        if(value.length>0)
        {
            value=value.split(' ')[0].replace("/","-").replace("/","-");
        }
        return value;
    }
    function TypeFun(value,id)
    {
        var s=<%=Web.UI.Data.Basic.performanceTypeToJs("performanceType")%>;
        return s["performanceType"+value];
    }
    function numFun(value,id,row)
    {
        if(row.cell[4]=="1")
        {
            return "<font color=blue>"+value+"</font>";
        }else{
            return "<font color=red>"+value+"</font>";
        }
    }
    function ManagerFun(value,id)
    {
        var str=new Array();
        <%if(IsDel){%>
        str.push("<a href=\"\" onclick=\"GridDel('"+id+"','Staff/score/Del.aspx');return false;\">删除</a>");
        <%}%>
        return str.join(" | ");
    }
    GridFun(".Rnr", gridList, <%=IsAdd?"167":"140" %>, 2);
    $("#Searchscorememberid").chosen({ width:"120px"});
    $("#Searchscoreisadd").chosen({ disable_search_threshold: 10 ,width:"60px"});
    $("#Searchscoretype").chosen({ disable_search_threshold: 10 ,width:"90px"});
</script>
<%}
  else
  {
      Response.Write(Web.UI.Staff.score.View(StoresID, memberid, isadd, type, starttime, endtime));
  }%>