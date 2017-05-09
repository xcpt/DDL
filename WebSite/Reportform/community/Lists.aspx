<%@ Page Language="C#" AutoEventWireup="true" Inherits="Reportform_community_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">小区消费汇总:</div>
</div>
<div class="Tgnk">
	<div class="Rtss" style="padding-bottom:5px;">
	  <div style="float:left" id="SearchInputValue">小区名称：<select name="communityid" id="Searchcommunityid" style="width:200px;">
              <option value="">请选择</option>
              <%=Web.UI.Sys.community.GetOption(StoresID,"") %>
            </select>&nbsp;&nbsp;日期：<input type="text" name="stime" value="<%=starttime %>" id="Searchcommunitystime" readonly="readonly" onClick="WdatePicker({skin:'ext',maxDate:'#F{$dp.$D(\'Searchcommunityetime\')}'})" size="9"/>-<input type="text" value="<%=endtime %>" name="etime" id="Searchcommunityetime" readonly="readonly" onClick="WdatePicker({skin:'ext',minDate:'#F{$dp.$D(\'Searchcommunitystime\')}'})" size="9"/>
	  </div>
	  <div style="float:left">
          <input type="submit" name="button" id="SearchButton" value="搜 索" onclick="$('#communityGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" />
          <input type="submit" name="button" id="Submit2" value="导出Excel" onclick="AjaxFun('Reportform/community/Lists_Excel.aspx',ReadInputValue('SearchInputValue'),'正在导出，请稍候...');" icon="icon-xls" />
	  </div>
	</div>
</div>
<div class="RtbK">
    <table id="communityGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#communityGrid").flexigrid
    (
    {
        url: 'Reportform/community/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '小区名称', name: 'communityname', width: 200,autoSize:true, sortable: false, align: 'left'},
            { display: '来客数', name: 'proper', width: 100, sortable: false, align: 'center'},
            { display: '消费金额', name: 'price', width: 100, sortable: false, align: 'center'},
            { display: '客单', name: 'bl1', width: 100, sortable: false, align: 'center'}
        ],
        showcheckbox:false,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.Reportform.community.View(StoresID, communityid, starttime, endtime)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
    }
    );
    GridFun(".Rnr", gridList, 135 , 2);
    $("#Searchcommunityid").chosen({ width:"175px"});
</script>
<%}
  else
  {
      Response.Write(Web.UI.Reportform.community.View(StoresID, communityid, starttime, endtime));
  }%>