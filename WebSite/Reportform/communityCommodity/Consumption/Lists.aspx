<%@ Page Language="C#" AutoEventWireup="true" Inherits="Reportform_Consumption_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">门店客流客单查询:</div>
</div>
<div class="Tgnk">
	<div class="Rtss" style="padding-bottom:5px;">
	  <div style="float:left" id="SearchInputValue">日期：<input type="text" class="validate[required,length[1,10]]" name="stime" value="<%=starttime %>" id="SearchConsumptionstime" readonly="readonly" onClick="WdatePicker({skin:'ext',maxDate:'#F{$dp.$D(\'SearchConsumptionetime\')}'})" size="9"/>-<input type="text" name="etime" id="SearchConsumptionetime" readonly="readonly" value="<%=endtime %>" class="validate[required,length[1,10]]" onClick="WdatePicker({skin:'ext',minDate:'#F{$dp.$D(\'SearchConsumptionstime\')}'})" size="9"/>
	  </div>
	  <div style="float:left">
          <input type="submit" name="button" id="SearchButton" value="搜 索" onclick="$('#ConsumptionGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" />
          <input type="submit" name="button" id="Submit2" value="导出Excel" onclick="AjaxFun('Reportform/Consumption/Lists_Excel.aspx',ReadInputValue('SearchInputValue'),'正在导出，请稍候...');" icon="icon-xls" />
	  </div>
	</div>
</div>
<div class="RtbK">
    <table id="ConsumptionGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#ConsumptionGrid").flexigrid
    (
    {
        url: 'Reportform/Consumption/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '月份', name: 'datetime', width: 200,autoSize:true, sortable: false, align: 'left'},
            { display: '消费金额', name: 'allprice', width: 100, sortable: false, align: 'right'},
            { display: '客流', name: 'price', width: 100, sortable: false, align: 'center'},
            { display: '客单', name: 'num', width: 100, sortable: false, align: 'right'}
        ],
        showcheckbox:false,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.Reportform.Consumption.View(StoresID, starttime, endtime)); %>,<%}%>
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
      Response.Write(Web.UI.Reportform.Consumption.View(StoresID, starttime, endtime));
  }%>