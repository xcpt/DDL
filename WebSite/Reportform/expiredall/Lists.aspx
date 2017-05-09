<%@ Page Language="C#" AutoEventWireup="true" Inherits="Reportform_expiredall_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">收入分析:</div>
</div>
<div class="Tgnk">
	<div class="Rtss" style="padding-bottom:5px;">
	  <div style="float:left" id="SearchInputValue">小区名称：<input name="title" type="text" id="Searchexpiredtitle" size="30" />&nbsp;&nbsp;日期：<input type="text" name="stime" id="Searchexpiredstime" value="<%=starttime %>" readonly="readonly" onClick="WdatePicker({skin:'ext'})" size="9"/>-<input type="text" name="etime" id="Searchexpiredetime" readonly="readonly" value="<%=endtime %>" onClick="WdatePicker({skin:'ext'})" size="9"/>
          &nbsp;&nbsp;来源：<select name="source" id="Searchexpiredsource" style="width:200px;">
              <option value="">请选择</option>
              <%=Web.UI.Data.Basic.Usersource("") %>
            </select>
	  </div>
	  <div style="float:left">
          <input type="submit" name="button" id="SearchButton" value="搜 索" onclick="$('#expiredGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" />
          <input type="submit" name="button" id="Submit2" value="导出Excel" onclick="AjaxFun('Reportform/expiredall/Lists_Excel.aspx',ReadInputValue('SearchInputValue'),'正在导出，请稍候...');" icon="icon-xls" />
	  </div>
	</div>
</div>
<div class="RtbK">
    <table id="expiredGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#expiredGrid").flexigrid
    (
    {
        url: 'Reportform/expiredall/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '店名称', name: 'title', width: 200,autoSize:true, sortable: false, align: 'left'},
            { display: '金额', name: 'price', width: 100, sortable: false, align: 'right',process:priceFun},
            { display: '管理', name: 'ad', width: 50, sortable: false, align: 'left',process:adFun}
        ],
        showcheckbox:false,
        sortname: "price",
        sortorder: "desc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.Reportform.expiredall.View(title, starttime, endtime, souce)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
    }
    );
    function priceFun(value,id)
    {
        return parseFloat(value).toFixed(2);
    }
    function adFun(value,id)
    {
        if(id.length>0)
        {
            return "<a href=\"\" onclick=\"AjaxFun('/Reportform/expired/Lists.aspx?action=view','storesid="+id+"&"+ReadInputValue('SearchInputValue')+"',' ','.Rnr');return false;\">查看</a>";
        }
    }
    GridFun(".Rnr", gridList, 135 , 2);
    $("#Searchexpiredsource").chosen({ disable_search_threshold: 10 ,width:"175px"});
</script>
<%}
  else
  {
      Response.Write(Web.UI.Reportform.expiredall.View(title, starttime, endtime, souce));
  }%>