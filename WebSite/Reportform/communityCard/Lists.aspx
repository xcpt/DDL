<%@ Page Language="C#" AutoEventWireup="true" Inherits="Reportform_communityCard_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">小区办卡:</div>
</div>
<div class="Tgnk">
	<div class="Rtss" style="padding-bottom:5px;">
	  <div style="float:left" id="SearchInputValue">小区名称：<select name="communityid" id="Searchcommunityid" style="width:200px;">
              <option value="">请选择</option>
              <%=Web.UI.Sys.community.GetOption(StoresID,"") %>
            </select>&nbsp;&nbsp;日期：<input type="text" name="stime" id="SearchcommunityCardstime" readonly="readonly" value="<%=starttime %>" onClick="WdatePicker({skin:'ext',maxDate:'#F{$dp.$D(\'SearchcommunityCardetime\')}'})" size="9"/>-<input type="text" name="etime" id="SearchcommunityCardetime" value="<%=endtime %>" readonly="readonly" onClick="WdatePicker({skin:'ext',minDate:'#F{$dp.$D(\'SearchcommunityCardstime\')}'})" size="9"/>
          &nbsp;&nbsp;卡类型：<select name="cardtypeid" id="SearchcommunityCardcardtypeid" style="width:200px;">
              <option value="">请选择</option>
                <%=Web.UI.customer.CardType.GetOption(StoresID,"") %>
            </select>
	  </div>
	  <div style="float:left">
          <input type="submit" name="button" id="SearchButton" value="搜 索" onclick="$('#communityCardGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" />
          <input type="submit" name="button" id="Submit2" value="导出Excel" onclick="AjaxFun('Reportform/communityCard/Lists_Excel.aspx',ReadInputValue('SearchInputValue'),'正在导出，请稍候...');" icon="icon-xls" />
	  </div>
	</div>
</div>
<div class="RtbK">
    <table id="communityCardGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#communityCardGrid").flexigrid
    (
    {
        url: 'Reportform/communityCard/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '', name: 'formanem', width: 200,autoSize:true, sortable: false, align: 'left'},
            { display: '小区名称', name: 'name', width: 100, sortable: false, align: 'center'},
            { display: '卡类型', name: 'cardtype', width: 100, sortable: false, align: 'center'},
            { display: '次数', name: 'num', width: 100, sortable: false, align: 'center'},
            { display: '金额', name: 'price', width: 100, sortable: false, align: 'right'}
        ],
        showcheckbox:false,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.Reportform.communityCard.View(StoresID, communityid, starttime, endtime, cardtypeid)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
    }
    );
    GridFun(".Rnr", gridList, 135 , 2);
    $("#Searchcommunityid").chosen({ width:"175px"});
    $("#SearchcommunityCardcardtypeid").chosen({ disable_search_threshold: 10 ,width:"175px"});
</script>
<%}
  else
  {
      Response.Write(Web.UI.Reportform.communityCard.View(StoresID, communityid, starttime, endtime, cardtypeid));
  }%>