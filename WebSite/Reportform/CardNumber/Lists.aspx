<%@ Page Language="C#" AutoEventWireup="true" Inherits="Reportform_CardNumber_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">卡次及金额:</div>
</div>
<div class="Tgnk">
    <div class="Rtss" style="padding-bottom:5px;">
	  <div style="float:left" id="SearchInputValue">日期：<input type="text" name="stime" id="SearchCardNumberstime" readonly="readonly" onClick="WdatePicker({skin:'ext',maxDate:'#F{$dp.$D(\'SearchCardNumberetime\')}'})" size="9"/>-<input type="text" name="etime" id="SearchCardNumberetime" readonly="readonly" onClick="WdatePicker({skin:'ext',minDate:'#F{$dp.$D(\'SearchCardNumberstime\')}'})" size="9"/></div>
	  <div style="float:left">
          <input type="submit" name="button" id="SearchButton" value="搜 索" onclick="$('#CardNumberGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" />
          <input type="submit" name="button" id="Submit2" value="导出Excel" onclick="AjaxFun('Reportform/CardNumber/Lists_Excel.aspx','','正在导出，请稍候...');" icon="icon-xls" />
	  </div>
	</div>
</div>
<div class="RtbK">
    <table id="CardNumberGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#CardNumberGrid").flexigrid
    (
    {
        url: 'Reportform/CardNumber/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '日期范围', name: 'time', width: 200, sortable: false, align: 'left'},
            { display: '类型', name: 'title', width: 200,autoSize:true, sortable: false, align: 'left'},
            { display: '正价次数', name: 'price0', width: 100, sortable: false, align: 'center'},
            { display: '赠送次数', name: 'price1', width: 100, sortable: false, align: 'center'},
            { display: '金额', name: 'iscard', width: 100, sortable: false, align: 'right'}
        ],
        showcheckbox:false,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.Reportform.CardNumber.View(StoresID, stime, etime)); %>,<%}%>
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
      Response.Write(Web.UI.Reportform.CardNumber.View(StoresID, stime, etime));
  }%>