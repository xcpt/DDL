<%@ Page Language="C#" AutoEventWireup="true" Inherits="Reportform_Week_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">会员周消费:</div>
</div>
<div class="Tgnk">
	<div class="Rtss" style="padding-bottom:5px;">
	  <div style="float:left" id="SearchInputValue">日期：<input type="text" name="stime" value="<%=endtime %>" id="SearchWeekstime" readonly="readonly" onClick="WdatePicker({skin:'ext',maxDate:'#F{$dp.$D(\'SearchWeeketime\')}'})" size="9"/>-<input type="text" name="etime" id="SearchWeeketime" readonly="readonly" value="<%=starttime %>" onClick="WdatePicker({skin:'ext',minDate:'#F{$dp.$D(\'SearchWeekstime\')}'})" size="9"/>
	  </div>
	  <div style="float:left">
          <input type="submit" name="button" id="SearchButton" value="搜 索" onclick="$('#WeekGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" />
          <input type="submit" name="button" id="Submit2" value="导出Excel" onclick="AjaxFun('Reportform/Week/Lists_Excel.aspx',ReadInputValue('SearchInputValue'),'正在导出，请稍候...');" icon="icon-xls" />
	  </div>
	</div>
</div>
<div class="RtbK">
    <table id="WeekGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#WeekGrid").flexigrid
    (
    {
        url: 'Reportform/Week/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '星期', name: 'weekname', width: 200,autoSize:true, sortable: false, align: 'left'},
            { display: '消费人数', name: 'proper', width: 100, sortable: false, align: 'center'},
            { display: '消费次数', name: 'num', width: 100, sortable: false, align: 'center'},
            { display: '消费金额', name: 'price', width: 100, sortable: false, align: 'center'},
            { display: '消费次数占比', name: 'bl1', width: 100, sortable: false, align: 'center'},
            { display: '消费金额占比', name: 'bl2', width: 100, sortable: false, align: 'center'}
        ],
        showcheckbox:false,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.Reportform.Week.View(StoresID, starttime, endtime)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
    }
    );
    GridFun(".Rnr", gridList, 135 , 2);
</script>
<%}
  else
  {
      Response.Write(Web.UI.Reportform.Week.View(StoresID, starttime, endtime));
  }%>