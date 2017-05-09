<%@ Page Language="C#" AutoEventWireup="true" Inherits="Marketing_expired_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">20天内过期及过期客户管理:</div>
</div>
<div class="Tgnk">
	<div class="Rtss" style="padding-bottom:5px;">
	  <div style="float:left;" id="SearchInputValue">过期时间：<input type="text" name="stime" id="SearchCardLogstime" readonly="readonly" onClick="WdatePicker({skin:'ext',maxDate:'#F{$dp.$D(\'SearchCardLogetime\')}'})" size="9"/>-<input type="text" name="etime" id="SearchCardLogetime" readonly="readonly" onClick="WdatePicker({skin:'ext',minDate:'#F{$dp.$D(\'SearchCardLogstime\')}'})" size="9"/>
	  </div>
	  <div style="float:left;"><input type="button" name="button" id="SearchButton" value="搜 索" onclick="$('#UserGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
</div>
<div class="RtbK">
    <table id="UserGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#UserGrid").flexigrid
    (
    {
        url: 'Marketing/expired/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '卡号', name: 'cardNo', width: 80, sortable: false, align: 'left'},
            { display: '姓名', name: 'Name', width: 50, sortable: false, align: 'left'},
            { display: '小名', name: 'niceName', width: 50, sortable: false, align: 'left'},
            { display: '性别', name: 'sex', width: 25, sortable: false, align: 'left',process:SexFun},
            { display: '月龄', name: 'age', width: 25, sortable: false, align: 'left'},
            { display: '家长姓名', name: 'parentName', width: 50, sortable: false, align: 'left'},
            { display: '妈妈手机', name: 'mobile', width: 80, sortable: false, align: 'left',process:MobileSendFun},
            { display: '所属小区', name: 'communityName', width: 100, sortable: false, align: 'left'},
            { display: '婴儿类型', name: 'BabyType', width: 50, sortable: false, align: 'left',process:BabyTypeFun},
            { display: '积分', name: 'scorenum', width: 25, sortable: false, align: 'left'},
            { display: '有效期', name: 'yxq', width: 35, sortable: false, align: 'right',process:yxqFun},
            { display: '测量', name: 'IsMeasure', width: 35, sortable: false, align: 'center',process:IsMeasureFun},
            { display: '拍照', name: 'IsPhoto', width: 35, sortable: false, align: 'center',process:IsMeasureFun},
            { display: '建档时间', name: 'addtime', width: 120, sortable: false, align: 'left',process:TimeFun},
            { display: '备注', name: 'content', width: 100,autoSize:true, sortable: false, align: 'left'},
            { display: '管理', name: 'Q', width: 30, sortable: false, align: 'left',process:ManagerFun }
        ],
        showcheckbox:true,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.customer.User.View_expired(StoresID, starttime, endtime)); %>,<%}%>
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
    function IsMeasureFun(value,id)
    {
        if(value=="1")
        {
            return "<font color=blue>需要</font>";
        }else{
            return "不需要";
        }
    }
    function cardstatusFun(value,id)
    {
        if(value=="1")
        {
            return "正常";
        }else{
            return "停卡";
        }
    }
    function yxqFun(value,id)
    {
        if(value.indexOf("-")!=-1)
        {
            return "<font color=red>"+value+"</font>";
        }
        return value;
    }
    function TimeFun(value,id)
    {
        if(value.length>0)
        {
            value=value.replace("/","-").replace("/","-");
        }
        return value;
    }
    function BabyTypeFun(value,id)
    {
        var s=<%=Web.UI.Data.Basic.BabyTypeToJs("BabyType")%>;
        return s["BabyType"+value];
    }
    function ManagerFun(value,id,row)
    {
        var str=new Array();
        <%if(CardIsList){%>
        str.push("<a href=\"\" onclick=\"AjaxFun('customer/Card/Lists.aspx', 'action=view&userid="+id+"', ' ', '.Rnr');return false;\">查卡</a>");
        <%}%>
        return str.join(" | ");
    }
    GridFun(".Rnr", gridList, 135, 2);
</script>
<%}
  else
  {
      Response.Write(Web.UI.customer.User.View_expired(StoresID, starttime, endtime));
  }%>