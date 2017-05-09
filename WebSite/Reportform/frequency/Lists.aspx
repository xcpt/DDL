<%@ Page Language="C#" AutoEventWireup="true" Inherits="Reportform_frequency_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">会员消费频次排行:</div>
</div>
<div class="Tgnk">
	<div class="Rtss" style="padding-bottom:5px;">
	  <div style="float:left" id="SearchInputValue">会员卡号：<input name="cardNo" placeholder="输入卡号或刷卡" type="text" id="SearchfrequencycardNo" size="30" />&nbsp;&nbsp;日期：<input type="text" name="stime" value="<%=starttime %>" id="Searchfrequencystime" readonly="readonly" onClick="WdatePicker({skin:'ext',maxDate:'#F{$dp.$D(\'Searchfrequencyetime\')}'})" size="9"/>-<input type="text" name="etime" id="Searchfrequencyetime" readonly="readonly" value="<%=endtime %>" onClick="WdatePicker({skin:'ext',minDate:'#F{$dp.$D(\'Searchfrequencystime\')}'})" size="9"/>
	  </div>
	  <div style="float:left">
          <input type="submit" name="button" id="SearchButton" value="搜 索" onclick="$('#frequencyGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" />
          <input type="submit" name="button" id="Submit2" value="导出Excel" onclick="AjaxFun('Reportform/frequency/Lists_Excel.aspx',ReadInputValue('SearchInputValue'),'正在导出，请稍候...');" icon="icon-xls" />
	  </div>
	</div>
</div>
<div class="RtbK">
    <table id="frequencyGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#frequencyGrid").flexigrid
    (
    {
        url: 'Reportform/frequency/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '会员卡号', name: 'cardNo', width: 200,autoSize:true, sortable: false, align: 'left'},
            { display: '会员名', name: 'name', width: 100, sortable: false, align: 'left'},
            { display: '小名', name: 'nickname', width: 100, sortable: false, align: 'left'},
            { display: '消费次数', name: 'num', width: 60, sortable: false, align: 'left'},
            { display: '首次消费时间', name: 'time1', width: 100, sortable: false, align: 'left'},
            { display: '末次消费时间', name: 'time2', width: 100, sortable: false, align: 'left'}
        ],
        showcheckbox:false,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.Reportform.frequency.View(StoresID, cardNo, starttime, endtime)); %>,<%}%>
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
      Response.Write(Web.UI.Reportform.frequency.View(StoresID, cardNo, starttime, endtime));
  }%>