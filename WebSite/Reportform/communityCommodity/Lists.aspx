<%@ Page Language="C#" AutoEventWireup="true" Inherits="Reportform_communityCommodity_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">小区销售商品汇总:</div>
</div>
<div class="Tgnk">
	<div class="Rtss" style="padding-bottom:5px;">
	  <div style="float:left" id="SearchInputValue">日期：<input type="text" name="stime" id="SearchcommunityCommoditystime" readonly="readonly" value="<%=starttime %>" onClick="WdatePicker({skin:'ext',maxDate:'#F{$dp.$D(\'SearchcommunityCommodityetime\')}'})" size="9"/>-<input type="text" name="etime" id="SearchcommunityCommodityetime" readonly="readonly" value="<%=endtime %>" onClick="WdatePicker({skin:'ext',minDate:'#F{$dp.$D(\'SearchcommunityCommoditystime\')}'})" size="9"/>
          &nbsp;&nbsp;商品：<select name="CommodityID" id="SearchcommunityCommodityID" style="width:200px;">
              <option value=""></option>
                <%=Web.UI.Sys.Commodity.GetOption(StoresID,"") %>
            </select>
	  </div>
	  <div style="float:left">
          <input type="submit" name="button" id="SearchButton" value="搜 索" onclick="$('#communityCommodityGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" />
          <input type="submit" name="button" id="Submit2" value="导出Excel" onclick="AjaxFun('Reportform/communityCommodity/Lists_Excel.aspx',ReadInputValue('SearchInputValue'),'正在导出，请稍候...');" icon="icon-xls" />
	  </div>
	</div>
</div>
<div class="RtbK">
    <table id="communityCommodityGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#communityCommodityGrid").flexigrid
    (
    {
        url: 'Reportform/communityCommodity/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '', name: 'title', width: 200, sortable: false, align: 'left'},
            { display: '小区名称', name: 'cname', width: 200,autoSize:true, sortable: false, align: 'left'},
            { display: '商品名称', name: 'spname', width: 100, sortable: false, align: 'center'},
            { display: '客流', name: 'proper', width: 100, sortable: false, align: 'right'},
            { display: '销售额', name: 'price', width: 100, sortable: false, align: 'right'},
            { display: '客单', name: 'dprice', width: 100, sortable: false, align: 'right'}
        ],
        showcheckbox:false,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.Reportform.communityCommodity.View(StoresID, starttime, endtime, CommodityID)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
    }
    );
    GridFun(".Rnr", gridList, 135 , 2);
    $("#SearchcommunityCommodityID").chosen({ disable_search_threshold: 10 ,width:"175px"});
</script>
<%}
  else
  {
      Response.Write(Web.UI.Reportform.communityCommodity.View(StoresID, starttime, endtime, CommodityID));
  }%>