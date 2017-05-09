<%@ Page Language="C#" AutoEventWireup="true" Inherits="Reportform_TimeNo_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">时间段内未到店:</div>
</div>
<div class="Tgnk">
	<div class="Rtss" style="padding-bottom:5px;">
	  <div style="float:left" id="SearchInputValue">曾到店间隔天数：<input name="num" type="text" id="SearchTimeNonum" size="9" />&nbsp;&nbsp;未到店间隔天数：<input type="text" name="lastnum" id="SearchTimeNolastnum" size="9"/>
	  </div>
	  <div style="float:left">
          <input type="submit" name="button" id="SearchButton" value="搜 索" onclick="$('#TimeNoGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" />
          <input type="submit" name="button" id="Submit2" value="导出Excel" onclick="AjaxFun('Reportform/TimeNo/Lists_Excel.aspx',ReadInputValue('SearchInputValue'),'正在导出，请稍候...');" icon="icon-xls" />
	  </div>
	</div>
</div>
<div class="RtbK">
    <table id="TimeNoGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#TimeNoGrid").flexigrid
    (
    {
        url: 'Reportform/TimeNo/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '会员姓名', name: 'name', width: 100, sortable: false, align: 'left'},
            { display: '会员小名', name: 'nickname', width: 100, sortable: false, align: 'left'},
            { display: '性别', name: 'sex', width: 55, sortable: false, align: 'left',process:SexFun},
            { display: '月龄', name: 'age', width: 55, sortable: false, align: 'left'},
            { display: '家长姓名', name: 'mobile', width: 100, sortable: false, align: 'left'},
            { display: '家长手机', name: 'mobile', width: 130, sortable: false, align: 'left',process:MobileSendFun},
            { display: '所属小区', name: 'name', width: 160, sortable: false, align: 'left'},
            { display: '婴儿类型', name: 'BabyType', width: 80, sortable: false, align: 'left',process:BabyTypeFun},
            { display: '备注', name: 'content', width: 130,autoSize:true, sortable: false, align: 'left'}
        ],
        showcheckbox:false,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.Reportform.TimeNo.View(StoresID, num1, num2)); %>,<%}%>
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
    function BabyTypeFun(value,id)
    {
        var s=<%=Web.UI.Data.Basic.BabyTypeToJs("BabyType")%>;
        return s["BabyType"+value];
    }
    GridFun(".Rnr", gridList, 135 , 2);
</script>
<%}
  else
  {
      Response.Write(Web.UI.Reportform.TimeNo.View(StoresID, num1, num2));
  }%>