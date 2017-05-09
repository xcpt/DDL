<%@ Page Language="C#" AutoEventWireup="true" Inherits="baby_album_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">成长相册:<%=Web.UI.customer.User.GetBanner(StoresID,userid,"baby/album/Lists.aspx") %></div>
</div>
<div class="Tgnk">
	<div class="Rtss" style="padding-bottom:5px;">
	  <div style="float:left" id="SearchInputValue">卡号：<input name="CardNo" type="text" id="SearchrulealbumCardNo" size="30" />&nbsp;&nbsp;月龄：<input name="MonthAge" type="text" id="SearchalbumMonthAge" size="30" />&nbsp;&nbsp;时间：<input type="text" name="stime" id="Searchalbumstime" readonly="readonly" onClick="WdatePicker({skin:'ext',maxDate:'#F{$dp.$D(\'Searchalbumetime\')}'})" size="9"/>-<input type="text" name="etime" id="Searchalbumetime" readonly="readonly" onClick="WdatePicker({skin:'ext',minDate:'#F{$dp.$D(\'Searchalbumstime\')}'})" size="9"/>
	  </div>
	  <div style="float:left"><input type="button" name="button" id="SearchButton" value="搜 索" onclick="$('#albumGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
</div>
<div class="RtbK">
    <table id="albumGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#albumGrid").flexigrid
    (
    {
        url: 'baby/album/Lists.aspx?userid=<%=userid%>',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '图片地址', name: 'PicUrl', width: 100,autoSize:true, sortable: false, align: 'left',process:PicUrlFun},
            { display: '卡号', name: 'CardNo', width: 100, sortable: false, align: 'left'},
            { display: '会员姓名', name: 'Name', width: 100, sortable: false, align: 'left'},
            { display: '小名', name: 'niceName', width: 100, sortable: false, align: 'left'},
            { display: '性别', name: 'sex', width: 30, sortable: false, align: 'left',process:SexFun},
            { display: '月龄', name: 'age', width: 30, sortable: false, align: 'left'},
            { display: '添加时间', name: '记录时间', width: 70, sortable: false, align: 'left',process:TimeFun},
            { display: '红心', name: 'hx', width: 35, sortable: false, align: 'left'},
            { display: '管理', name: 'Q', width: 70, sortable: false, align: 'left',process:ManagerFun }
        ],
        showcheckbox:false,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.baby.album.View(StoresID,userid, CardNo, MonthAge, starttime, endtime)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        showOkFun:function(obj){obj.find("img.jTip").JT_init();},
        height: 200
    }
    );
    function PicUrlFun(value,id)
    {
        return "<img src='/pic/?src="+value+"&width=100&height=100&cut=h&save=false' height=100 style=\"padding:5px;\" align=\"absmiddle\" name=\"会员照片\" />";
    }
    function TimeFun(value,id)
    {
        return value.split(' ')[0].split('/').join('-');
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
    function ManagerFun(value,id,row)
    {
        var str=new Array();
        str.push("<a href='"+value+"' target=\"_blank\" >查看</a>");
        <%if(IsDel){%>
        str.push("<a href=\"\" onclick=\"GridDel('"+id+"','baby/album/Del.aspx');return false;\" >删除</a>");
        <%}%>
        return str.join(" | ");
    }
    GridFun(".Rnr", gridList, 135, 2);
</script>
<%}
  else
  {
      Response.Write(Web.UI.baby.album.View(StoresID, userid, CardNo, MonthAge, starttime, endtime));
  }%>