<%@ Page Language="C#" AutoEventWireup="true" Inherits="Marketing_consultNoCard_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">咨询未办卡:</div>
</div>
<div class="Tgnk">
	<div class="Rtss" style="padding-bottom:5px;">
	  <div style="float:left" id="SearchInputValue">创建日期：<input type="text" name="stime" id="SearchCardLogstime" readonly="readonly" onClick="WdatePicker({skin:'ext',maxDate:'#F{$dp.$D(\'SearchCardLogetime\')}'})" size="9"/>-<input type="text" name="etime" id="SearchCardLogetime" readonly="readonly" onClick="    WdatePicker({skin:'ext',minDate:'#F{$dp.$D(\'SearchCardLogstime\')}'})" size="9"/></div>
	  <div style="float:left"><input type="button" name="button" id="SearchButton" value="搜 索" onclick="$('#consultNoCardGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
</div>
<div class="RtbK">
    <table id="consultNoCardGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#consultNoCardGrid").flexigrid
    (
    {
        url: 'Marketing/consultNoCard/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '会员姓名', name: 'name', width: 100, sortable: false, align: 'left'},
            { display: '会员小名', name: 'nickname', width: 100, sortable: false, align: 'left'},
            { display: '性别', name: 'sex', width: 25, sortable: false, align: 'left',process:SexFun},
            { display: '月龄', name: 'age', width: 20, sortable: false, align: 'left'},
            { display: '家长姓名', name: 'ParentName', width: 100, sortable: false, align: 'left'},
            { display: '固定电话', name: 'tel', width: 100, sortable: false, align: 'left'},
            { display: '联系手机', name: 'mobile', width: 100, sortable: false, align: 'left',process:MobileSendFun},
            { display: '所属小区', name: 'xq', width: 100, sortable: false, align: 'left'},
            { display: '婴儿类型', name: 'BabyType', width: 50, sortable: false, align: 'left',process:BabyTypeFun},
            { display: '创建日期', name: 'addtime', width: 130, sortable: false, align: 'left'},
            { display: '备注', name: 'description', width: 100,autoSize:true, sortable: false, align: 'left'}
        ],
        showcheckbox:false,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.customer.User.View_consultNoCard(StoresID, starttime, endtime)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
    }
    );
    function MobileSendFun(value,id)
    {
        <%if(MessageLogAdd){%>
        return "<a href=\"\" onclick=\"CreateWindow('Mobile/MessageLog/Add.aspx?mobile="+value+"', '发送消息','Mobile/MessageLog/Add.aspx?action=save',600, 400,'MessageLogAdd');return false;\" title=\"发送手机消息\">"+value+"</a>";
        <%}else{%>
        return value;
        <%}%>
    }
    function BabyTypeFun(value,id)
    {
        var s=<%=Web.UI.Data.Basic.BabyTypeToJs("BabyType")%>;
        return s["BabyType"+value];
    }
    function SexFun(value,id)
    {
        if(value=="0")
        {
            value="男";
        }else{
            value="女";
        }
        return value;
    }
    GridFun(".Rnr", gridList,135, 2);
</script>
<%}
  else
  {
      Response.Write(Web.UI.customer.User.View_consultNoCard(StoresID, starttime, endtime));
  }%>