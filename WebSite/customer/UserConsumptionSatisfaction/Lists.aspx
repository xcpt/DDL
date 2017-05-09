<%@ Page Language="C#" AutoEventWireup="true" Inherits="customer_UserConsumptionSatisfaction_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">消费修改记录管理:</div>
</div>
<div class="Tgnk">
	<div class="Rtss" style="padding-bottom:50px;">
	  <div style="float:left;line-height:30px;" id="SearchInputValue">会员卡号：<input name="cardNo" placeholder="输入卡号或刷卡" type="text" id="SearchSatisfactioncardNo" size="30" />&nbsp;&nbsp;会员姓名：<input name="Name" type="text" id="SearchSatisfactionName" size="30" />
          &nbsp;&nbsp;消费日期：<input type="text" name="stime" id="SearchUserConsumptionstime" readonly="readonly" onClick="WdatePicker({skin:'ext',maxDate:'#F{$dp.$D(\'SearchUserConsumptionetime\')}'})" size="9"/>-<input type="text" name="etime" id="SearchUserConsumptionetime" readonly="readonly" onClick="WdatePicker({skin:'ext',minDate:'#F{$dp.$D(\'SearchUserConsumptionstime\')}'})" size="9"/><br/>
          操作日期：<input type="text" name="astime" id="SearchUserConsumptioncstime" readonly="readonly" onClick="WdatePicker({skin:'ext',maxDate:'#F{$dp.$D(\'SearchUserConsumptioncetime\')}'})" size="9"/>-<input type="text" name="aetime" id="SearchUserConsumptioncetime" readonly="readonly" onClick="WdatePicker({skin:'ext',minDate:'#F{$dp.$D(\'SearchUserConsumptioncstime\')}'})" size="9"/>
	  </div>
	  <div style="float:left;padding-top:35px;"><input type="button" name="button" id="SearchButton" value="搜 索" onclick="$('#UserConsumptionSatisfactionGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
</div>
<div class="RtbK">
    <table id="UserConsumptionSatisfactionGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#UserConsumptionSatisfactionGrid").flexigrid
    (
    {
        url: 'customer/UserConsumptionSatisfaction/Lists.aspx?ucid=<%=ucid%>',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '消费ID', name: 'xfid', width: 50, sortable: false, align: 'left' },
            { display: '卡号', name: 'cardNo', width: 50, sortable: false, align: 'left'},
            { display: '会员', name: 'Name', width: 40, sortable: false, align: 'left'},
            { display: '金额', name: 'price', width: 60, sortable: false, align: 'right'},
            { display: '消费时间', name: 'addtime', width: 110, sortable: false, align: 'left'},
            { display: '消费商品', name: 'CommodityName', width: 80, sortable: false, align: 'left'},
            { display: '服务泳师', name: 'swimteachername', width: 80, sortable: false, align: 'left'},
            { display: '类型', name: 'Type', width: 60, sortable: false, align: 'left',process:TypeFun},
            { display: '操作人', name: 'adminName', width: 80, sortable: false, align: 'left'},
            { display: '第几次修改', name: 'num', width: 60, sortable: false, align: 'left'},
            { display: '操作时间', name: 'addtime', width: 110, sortable: false, align: 'left'},
            { display: '修改前', name: 'oldsatisfactionid', width: 60, sortable: false, align: 'left',process:satisfactionidFun},
            { display: '修改后', name: 'satisfactionid', width: 60, sortable: false, align: 'left',process:satisfactionidFun},
            { display: '修改原因', name: 'content', width: 110,autoSize:true, sortable: false, align: 'left'}
        ],
        showcheckbox:false,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.customer.UserConsumptionSatisfaction.View(StoresID, ucid, cardNo, name, administratorid, statustime, endtime, adminstatustime, adminendtime)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
    }
    );
    function TypeFun(value,id)
    {
        switch(value)
        {
            case "0":
                {
                    return "满意度";break;
                }
            case "1":
                {
                    return "体重";break;
                }
            case "2":
                {
                    return "身高";break;
                }
            case "3":
                {
                    return "游戏时长";break;
                }
        }
    }
    function satisfactionidFun(value,id,row)
    {
        var s=<%=Web.UI.Data.Basic.satisfactionidToJs("satisfactionid")%>;
        if(row.cell[8]=="0")
        {
            return s["satisfactionid"+value];
        }else{
            return value;
        }
    }
    GridFun(".Rnr", gridList, 180, 2);
    $("#Searchadministratorid").chosen({ disable_search_threshold: 10 ,width:"100px"});
</script>
<%}
  else
  {
      Response.Write(Web.UI.customer.UserConsumptionSatisfaction.View(StoresID, ucid, cardNo, name, administratorid, statustime, endtime, adminstatustime, adminendtime));
  }%>