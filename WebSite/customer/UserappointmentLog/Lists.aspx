<%@ Page Language="C#" AutoEventWireup="true" Inherits="customer_UserappointmentLog_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">预约时间配置:</div>
    <a href="" onclick="AjaxFun('customer/UserappointmentLog/Lists.aspx?action=view&babytype=1','',' ','.Rnr');return false;"<%=babytype.Equals("1")?" class=\"dq\"":"" %>>婴儿</a><a href="" onclick="AjaxFun('customer/UserappointmentLog/Lists.aspx','action=view&babytype=2',' ','.Rnr');return false;"<%=babytype.Equals("1")?"":" class=\"dq\"" %>>幼儿</a>
</div>
<div class="RtbK">
    <table id="UserappointmentLogGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    var gridList= $("#UserappointmentLogGrid").flexigrid
    (
    {
        url: 'customer/UserappointmentLog/Lists.aspx?babytype=<%=babytype%>',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'ID', width: 50,hide:true, sortable: false, align: 'left' },
            { display: '时间段', name: 'time', width: 30,autoSize:true, sortable: false, align: 'center' },
            <%=Web.UI.customer.UserappointmentLog.GetHead()%>
        ],
        showcheckbox:false,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.customer.UserappointmentLog.View(StoresID, babytype)); %>,<%}%>
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

            //if(v.length==5)
            //{
            //    return "<a href='#' onclick=\"GridModiy('"+v[0]+"', 'customer/UserappointmentLog/Modi.aspx','修改预约数量', 'customer/UserappointmentLog/Modi.aspx?action=save', 600, 235,'UserappointmentLogModi');return false;\" ><font color=red>"+(parseInt(v[2])+parseInt(v[3]))+"</font>（APP:"+v[2]+"|PC:"+v[3]+"）</a>";
            //}else{
            //    return "<a href=\"\" onclick=\"CreateWindow('customer/UserappointmentLog/Modi.aspx?babytype=<%=babytype%>&weeknum="+v[0]+"&datetime="+v[2]+"&timestr="+row.cell[1]+"', '修改预约数量','customer/UserappointmentLog/Modi.aspx?action=save',600,235,'UserappointmentLogModi');return false;\"><font color=red>0</font></a>";
            //}

            var time=row.cell[1].split(":");
            if(v.length==5)
            {
                return "<a href=\"\" onclick=\"AjaxFun('customer/Userappointment/Lists.aspx','action=view&cycletype=<%=babytype%>&stime="+v[4]+"&etime="+v[4]+"&datetimehouer="+time[0]+"&datetimeminute="+time[1]+"',' ','.Rnr');return false;\"><font color=red>"+(parseInt(v[2])+parseInt(v[3]))+"</font>（APP:"+v[2]+"|PC:"+v[3]+"）</a>";
            }else{
                return "<a href=\"\" onclick=\"AjaxFun('customer/Userappointment/Lists.aspx','action=view&cycletype=<%=babytype%>&stime="+v[4]+"&etime="+v[4]+"&datetimehouer="+time[0]+"&datetimeminute="+time[1]+"',' ','.Rnr');return false;\"><font color=red>0</font></a>";
            }
        }
    }
GridFun(".Rnr", gridList,90, 2);
</script>
<%}
  else
  {
      Response.Write(Web.UI.customer.UserappointmentLog.View(StoresID, babytype));
  }%>