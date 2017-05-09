<%@ Page Language="C#" AutoEventWireup="true" Inherits="Reportform_Timeslot_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">营业时间段分析:</div>
</div>
<div class="Tgnk">
	<div class="Rtss" style="padding-bottom:5px;">
	  <div style="float:left" id="SearchInputValue">日期：<input type="text" name="stime" id="SearchTimeslotstime" value="<%=starttime %>" readonly="readonly" onClick="WdatePicker({skin:'ext',maxDate:'#F{$dp.$D(\'SearchTimeslotetime\')}'})" size="9"/>-<input type="text" name="etime" id="SearchTimeslotetime" readonly="readonly" value="<%=endtime %>" onClick="WdatePicker({skin:'ext',minDate:'#F{$dp.$D(\'SearchTimeslotstime\')}'})" size="9"/>
	  </div>
	  <div style="float:left">
          <input type="submit" name="button" id="SearchButton" value="搜 索" onclick="$('#TimeslotGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" />
          <input type="submit" name="button" id="Submit2" value="导出Excel" onclick="AjaxFun('Reportform/Timeslot/Lists_Excel.aspx',ReadInputValue('SearchInputValue'),'正在导出，请稍候...');" icon="icon-xls" />
	  </div>
	</div>
</div>
<div class="RtbK">
    <table id="TimeslotGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#TimeslotGrid").flexigrid
    (
    {
        url: 'Reportform/Timeslot/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '时间段', name: 'title', width: 200,autoSize:true, sortable: false, align: 'left'},
            { display: '消费人数', name: 'price', width: 100, sortable: false, align: 'center'}
        ],
        showcheckbox:false,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.Reportform.Timeslot.View(StoresID, starttime, endtime)); %>,<%}%>
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
      Response.Write(Web.UI.Reportform.Timeslot.View(StoresID, starttime, endtime));
  }%>