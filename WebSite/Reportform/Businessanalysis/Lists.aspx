<%@ Page Language="C#" AutoEventWireup="true" Inherits="Reportform_Businessanalysis_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">营业收入:</div>
</div>
<div class="Tgnk">
	<div class="Rtss" style="padding-bottom:5px;">
	  <div style="float:left" id="SearchInputValue">日期：<input type="text" name="stime" id="SearchBusinessanalysisstime" value="<%=starttime %>" readonly="readonly" onClick="WdatePicker({skin:'ext',maxDate:'#F{$dp.$D(\'SearchBusinessanalysisetime\')}'})" size="9"/>-<input type="text" name="etime" id="SearchBusinessanalysisetime" readonly="readonly" value="<%=endtime %>" onClick="WdatePicker({skin:'ext',minDate:'#F{$dp.$D(\'SearchBusinessanalysisstime\')}'})" size="9"/>
          &nbsp;&nbsp;来源：<select name="source" id="SearchBusinessanalysissource" style="width:200px;">
              <option value="">请选择</option>
                <%=Web.UI.Data.Basic.Usersource("") %>
            </select>
	  </div>
	  <div style="float:left">
          <input type="submit" name="button" id="SearchButton" value="搜 索" onclick="$('#BusinessanalysisGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" />
          <input type="submit" name="button" id="Submit2" value="导出Excel" onclick="AjaxFun('Reportform/Businessanalysis/Lists_Excel.aspx',ReadInputValue('SearchInputValue'),'正在导出，请稍候...');" icon="icon-xls" />
	  </div>
	</div>
</div>
<div class="RtbK">
    <table id="BusinessanalysisGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#BusinessanalysisGrid").flexigrid
    (
    {
        url: 'Reportform/Businessanalysis/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '消费类别', name: 'title', width: 200,autoSize:true, sortable: false, align: 'left'},
            { display: '次数', name: 'price', width: 100, sortable: false, align: 'center'},
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
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.Reportform.Businessanalysis.View(StoresID, starttime, endtime, souce)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
    }
    );
    GridFun(".Rnr", gridList, 135 , 2);
    $("#SearchBusinessanalysissource").chosen({ disable_search_threshold: 10 ,width:"175px"});
</script>
<%}
  else
  {
      Response.Write(Web.UI.Reportform.Businessanalysis.View(StoresID, starttime, endtime, souce));
  }%>