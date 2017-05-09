<%@ Page Language="C#" AutoEventWireup="true" Inherits="Reportform_AllTotal_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">办卡成功率:</div>
</div>
<div class="Tgnk">
	<div class="Rtss" style="padding-bottom:5px;">
	  <div style="float:left" id="SearchInputValue">日期：<input type="text" name="stime" id="Searchexpiredstime" value="<%=starttime %>" readonly="readonly" onClick="WdatePicker({skin:'ext',dateFmt:'yyyy-MM'})" size="9"/>-<input type="text" name="etime" id="Searchexpiredetime" readonly="readonly" value="<%=endtime %>" onClick="WdatePicker({skin:'ext',dateFmt:'yyyy-MM'})" size="9"/>
	  </div>
	  <div style="float:left">
          <input type="button" name="button" id="SearchButton" value="搜 索" onclick="$('#AllTotalGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" />
          <input type="button" name="button" id="Submit2" value="导出Excel" onclick="AjaxFun('Reportform/AllTotal/Lists_Excel.aspx',ReadInputValue('SearchInputValue'),'正在导出，请稍候...');" icon="icon-xls" />
	  </div>
	</div>
</div>
<div class="RtbK">
    <table id="AllTotalGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#AllTotalGrid").flexigrid
    (
    {
        url: 'Reportform/AllTotal/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '月份', name: 'title', width: 60,autoSize:true, sortable: false, align: 'left'},
            { display: '咨未达', name: 'price', width: 40, sortable: false, align: 'center'},
            { display: '体未达', name: 'iscard', width: 40, sortable: false, align: 'center'},
            <%=Web.UI.customer.CardType.GetJson(StoresID)%>
            { display: '建卡总数', name: 'iscard', width: 60, sortable: false, align: 'center'},
            { display: '续卡总数', name: 'iscard', width: 60, sortable: false, align: 'center'},
            { display: '合计', name: 'iscard', width: 50, sortable: false, align: 'center'},
            { display: '新来店总数', name: 'iscard', width: 70, sortable: false, align: 'center'},
            { display: '新建卡总收入', name: 'iscard', width: 75, sortable: false, align: 'center'},
            { display: '新建卡客单价', name: 'iscard', width: 75, sortable: false, align: 'center'},
            { display: '续卡总收入', name: 'iscard', width: 75, sortable: false, align: 'center'},
            { display: '续卡客单价', name: 'iscard', width: 75, sortable: false, align: 'center'},
            { display: '调整', name: 'iscard', width: 75, sortable: false, align: 'center'},
            { display: '合计', name: 'iscard', width: 75, sortable: false, align: 'center'},
            { display: '办卡成功率', name: 'iscard', width: 70, sortable: false, align: 'center'}
        ],
        showcheckbox:false,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.Reportform.AllTotal.View(StoresID, starttime, endtime)); %>,<%}%>
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
      Response.Write(Web.UI.Reportform.AllTotal.View(StoresID, starttime, endtime));
  }%>