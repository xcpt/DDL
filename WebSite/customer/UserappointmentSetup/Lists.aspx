<%@ Page Language="C#" AutoEventWireup="true" Inherits="customer_UserappointmentSetup_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">预约基础配置:</div>
    <a href="" onclick="AjaxFun('customer/UserappointmentSetup/Lists.aspx?action=view&babytype=1','',' ','.Rnr');return false;"<%=babytype.Equals("1")?" class=\"dq\"":"" %>>婴儿</a><a href="" onclick="AjaxFun('customer/UserappointmentSetup/Lists.aspx','action=view&babytype=2',' ','.Rnr');return false;"<%=babytype.Equals("1")?"":" class=\"dq\"" %>>幼儿</a>
</div>
<div class="Tgnk">
    <%if (IsAdd)
      { %>
    <div class="gnANk" style="padding-top:8px;">
        <input type="submit" name="button" id="button" onclick="CreateWindow('customer/UserappointmentSetup/Add.aspx?babytype=<%=babytype%>', '新增基础配置','customer/UserappointmentSetup/Add.aspx?action=save',600,300,'UserappointmentSetupAdd')" icon="icon-addNew" value="新增" />
    </div>
    <%} %>
</div>
<div class="RtbK">
    <table id="UserappointmentSetupGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    var gridList= $("#UserappointmentSetupGrid").flexigrid
    (
    {
        url: 'customer/UserappointmentSetup/Lists.aspx?babytype=<%=babytype%>',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'ID', width: 50, sortable: false, align: 'left' },
            { display: '时间段', name: 'time', width: 50,autoSize:true, sortable: false, align: 'center' },
            { display: '星期一', name: 'week1', width: 80, sortable: false, align: 'center',process:WeekFun},
            { display: '星期二', name: 'week2', width: 80, sortable: false, align: 'center',process:WeekFun},
            { display: '星期三', name: 'week3', width: 80, sortable: false, align: 'center',process:WeekFun},
            { display: '星期四', name: 'week4', width: 80, sortable: false, align: 'center',process:WeekFun},
            { display: '星期五', name: 'week5', width: 80, sortable: false, align: 'center',process:WeekFun},
            { display: '星期六', name: 'week6', width: 80, sortable: false, align: 'center',process:WeekFun},
            { display: '星期日', name: 'week7', width: 80, sortable: false, align: 'center',process:WeekFun}
        ],
        showcheckbox:false,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.customer.UserappointmentSetup.View(StoresID, babytype)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
    }
    );
    function WeekFun(value,id,row)
    {
        if(value.indexOf(",")!=-1)
        {
            var v=value.split(',');
            return "<a href='#' onclick=\"GridModiy('"+v[0]+"', 'customer/UserappointmentSetup/Modi.aspx','修改预约规则', 'customer/UserappointmentSetup/Modi.aspx?action=save', 600, 300,'UserappointmentSetupModi');return false;\" >"+v[1]+"</a>";
        }else{
            return "<a href=\"\" onclick=\"CreateWindow('customer/UserappointmentSetup/Add.aspx?babytype=<%=babytype%>&weeknum="+value+"&timestr="+row.cell[1]+"', '新增基础配置','customer/UserappointmentSetup/Add.aspx?action=save',600,300,'UserappointmentSetupAdd');return false;\">新增</a>";
        }
    }
    GridFun(".Rnr", gridList, 130, 2);
</script>
<%}
  else
  {
      Response.Write(Web.UI.customer.UserappointmentSetup.View(StoresID, babytype));
  }%>