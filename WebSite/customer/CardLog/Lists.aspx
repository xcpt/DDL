<%@ Page Language="C#" AutoEventWireup="true" Inherits="customer_CardLog_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">卡变更日志管理:</div>
</div>
<div class="Tgnk">
	<div class="Rtss" style="padding-bottom:5px;">
	  <div style="float:left" id="SearchInputValue">会员卡号：<input name="CardNo" placeholder="输入卡号或刷卡" type="text" id="CardLogCardNo" size="30" />&nbsp;&nbsp;时间：<input type="text" name="stime" id="SearchCardLogstime" readonly="readonly" onClick="WdatePicker({skin:'ext',maxDate:'#F{$dp.$D(\'SearchCardLogetime\')}'})" size="9"/>-<input type="text" name="etime" id="SearchCardLogetime" readonly="readonly" onClick="WdatePicker({skin:'ext',minDate:'#F{$dp.$D(\'SearchCardLogstime\')}'})" size="9"/>&nbsp;&nbsp;
          变更类型：<select name="cardlogtype" id="Searchcardlogtype">
          <option value="">&nbsp;</option>
          <%=Web.UI.Data.Basic.cardlogtypeType("") %>
        </select>
	  </div>
	  <div style="float:left"><input type="button" name="button" id="SearchButton" value="搜 索" onclick="$('#CardLogGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
</div>
<div class="RtbK">
    <table id="CardLogGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#CardLogGrid").flexigrid
(
{
    url: 'customer/CardLog/Lists.aspx',
    newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '卡号', name: 'cardNo', width: 50, sortable: false,autoSize:true, align: 'left'},
            { display: '原过期日期', name: 'oldendtime', width:70, sortable: false, align: 'left',process:TimeFun},
            { display: '现过期日期', name: 'newendtime', width:70, sortable: false, align: 'left',process:TimeFun},
            { display: '重开卡日期', name: 'opentime', width:70, sortable: false, align: 'left',process:TimeFun},
            { display: '原卡次', name: 'oldnum', width:40, sortable: false, align: 'left'},
            { display: '现卡次', name: 'newnum', width:40, sortable: false, align: 'left'},
            { display: '原金额', name: 'oldprice', width:50, sortable: false, align: 'left'},
            { display: '新增金额', name: 'newprice', width:50, sortable: false, align: 'left'},
            { display: '原卡类型', name: 'oldcardtype', width:60, sortable: false, align: 'left'},
            { display: '现卡类型', name: 'newcardtype', width:60, sortable: false, align: 'left'},
            { display: '操作人', name: 'username', width: 100, sortable: false, align: 'left',hide:true},
            { display: '操作人', name: 'username', width: 100, sortable: false, align: 'left',process:usernameFun},
            { display: '操作时间', name: 'addtime', width: 110, sortable: false, align: 'left'},
            { display: '类型', name: 'cardlogtype', width: 35, sortable: false, align: 'left',process:cardlogtypeFun}
        ],
        showcheckbox:false,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.customer.CardLog.View(StoresID, cardNo, starttime, endtime, cardlogtype)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
    }
    );
    function usernameFun(value,id,row)
    {
        if(row.cell[11]=="0"){
            return "<font color=red>系统</font>";
        }else if(row.cell[11]=="-1"){
            return "<font color=blue>会员</font>";
        }else{
            return value;
        }
    }
    function TimeFun(value,id)
    {
        if(value.length>0)
        {
            value=value.split(' ')[0].replace("/","-").replace("/","-");
        }
        return value;
    }
    function cardlogtypeFun(value,id)
    {
        var s=<%=Web.UI.Data.Basic.cardlogtypeToJs("cardlogtype")%>;
        return s["cardlogtype"+value];
    }
    GridFun(".Rnr", gridList, 135, 2);
    $("#Searchcardlogtype").chosen({ disable_search_threshold: 10 ,width:"120px"});
</script>
<%}
  else
  {
      Response.Write(Web.UI.customer.CardLog.View(StoresID, cardNo, starttime, endtime, cardlogtype));
  }%>