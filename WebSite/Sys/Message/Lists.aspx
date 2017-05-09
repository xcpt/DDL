<%@ Page Language="C#" AutoEventWireup="true" Inherits="Sys_Message_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">留言反馈管理:</div>
</div>
<div class="Tgnk">
	<div class="Rtss" style="padding-bottom:5px;">
	  <div style="float:left;" id="SearchInputValue">
          用户：<input name="name" type="text" id="SearchMessageName" size="30" />
          &nbsp;&nbsp;创建时间：<input type="text" name="saddtime" id="SearchMessagesaddtime" readonly="readonly" onClick="WdatePicker({skin:'ext',maxDate:'#F{$dp.$D(\'SearchMessageeaddtime\')}'})" size="9"/>-<input type="text" name="eaddtime" id="SearchMessageeaddtime" readonly="readonly" onClick="WdatePicker({skin:'ext',minDate:'#F{$dp.$D(\'SearchMessagesaddtime\')}'})" size="9"/>
          &nbsp;&nbsp;处理时间：<input type="text" name="supdatetime" id="SearchMessagesupdatetime" readonly="readonly" onClick="WdatePicker({skin:'ext',maxDate:'#F{$dp.$D(\'SearchMessageeupdatetime\')}'})" size="9"/>-<input type="text" name="eupdatetime" id="SearchMessageeupdatetime" readonly="readonly" onClick="WdatePicker({skin:'ext',minDate:'#F{$dp.$D(\'SearchMessagesupdatetime\')}'})" size="9"/>
          &nbsp;&nbsp;<select name="state" id="SearchMessagestate">
          <option value="">&nbsp;</option>
          <option value="0">处理中</option>
          <option value="1">已处理</option>
        </select>
	  </div>
	  <div style="float:left"><input type="submit" name="button" id="SearchButton" value="搜 索" onclick="$('#MessageGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
</div>
<div class="RtbK">
    <table id="MessageGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#MessageGrid").flexigrid
    (
    {
        url: 'Sys/Message/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '卡号', name: 'CardNo', width: 60, sortable: false, align: 'left' },
            { display: '会员姓名', name: 'Name', width: 80, sortable: false, align: 'left'},
            { display: '家长姓名', name: 'ParentName', width: 80, sortable: false, align: 'left'},
            { display: '电话', name: 'Mobile', width: 80, sortable: false, align: 'left',process:MobileSendFun},
            { display: '内容', name: 'Content', width: 150,autoSize:true, sortable: false, align: 'left'},
            { display: '提交时间', name: 'addtime', width: 130, sortable: false, align: 'left'},
            { display: '处理状态', name: 'state', width: 60, sortable: false, align: 'left',process:StateFun},
            { display: '处理时间', name: 'updatetime', width: 110, sortable: false, align: 'left'},
            { display: '管理', name: 'Q', width: 35, sortable: false, align: 'left',process:ManagerFun }
        ],
        showcheckbox:false,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.Sys.Message.View(StoresID, name, saddtime, eaddtime, supdatetime, eupdatetime, state)); %>,<%}%>
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
    function StateFun(value,id,row)
    {
        if(value=="1")
        {
            return "已处理";
        }else{
            return "<font color=red>处理中</font>";
        }
    }
    function ManagerFun(value,id)
    {
        var str=new Array();
        <%if(IsModi){%>
        str.push("<a href='#' onclick=\"GridModiy('"+id+"', 'Sys/Message/Modi.aspx','处理', 'Sys/Message/Modi.aspx?action=save', 500, 285,'MessageModi');return false;\" >处理</a>");
        <%}%>
        return str.join(" | ");
    }
    GridFun(".Rnr", gridList, 132, 2);
    $("#SearchMessagestate").chosen({ disable_search_threshold: 10 , width:"130px"});
</script>
<%}
  else
  {
      Response.Write(Web.UI.Sys.Message.View(StoresID, name, saddtime, eaddtime, supdatetime, eupdatetime, state));
  }%>