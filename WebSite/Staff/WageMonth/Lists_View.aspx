<%@ Page Language="C#" AutoEventWireup="true" Inherits="Staff_WageMonth_Lists_View" %>
<div id="swimteacherAdd">
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th>月份</th><th>工资</th><th>保险</th><th>实发</th>
    </tr>
    <tr align="right">
        <td><%=wmModel.datetime %></td><td><%=wmModel.salary %></td><td><%=wmModel.deducted %></td><td><%=wmModel.wagenum %></td>
    </tr>
    <tr>
        <th align="center" colspan="4"><b>绩效列表</b></th>
    </tr>
</table>
<div class="RtbK">
    <table id="performanceViewGrid" style="display: none;"></table>
</div>
<script type="text/javascript">
    var gridList= $("#performanceViewGrid").flexigrid
    (
    {
        url: 'Staff/performance/Lists.aspx',
        newp:1,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '姓名', name: 'Name',hide:true, width: 100,autoSize:true, sortable: false, align: 'left'},
            { display: '类型', name: 'type', width: 100, sortable: false, align: 'left',process:TypeFun},
            { display: '时间', name: 'datetime', width: 65, sortable: false, align: 'left',process:TimeFun},
            { display: '金额', name: 'price', width: 60, sortable: false, align: 'right',process:PriceFun},
            { display: '摘要', name: 'content', width: 250, sortable: false, align: 'left'}
        ],
        showcheckbox:false,
        sortname: "id",
        sortorder: "asc",
        usepager: false,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        PageOneValue:<%Response.Write(Web.UI.Staff.performance.View_Member(StoresID, wmModel.memberid, wmModel.datetime)); %>,
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 600,
        height: 265
    }
    );
    function TypeFun(value,id)
    {
        var s=<%=Web.UI.Data.Basic.performanceTypeToJs("performanceType")%>;
        return s["performanceType"+value];
    }
    function TimeFun(value,id)
    {
        if(value.length>0)
        {
            value=value.split(' ')[0].replace("/","-").replace("/","-");
        }
        return value;
    }
    function PriceFun(value,id)
    {
        if(value.indexOf("-")!=-1)
        {
            return "<font color=\"red\">"+value+"</font>";
        }else{
            return "<font color=\"blue\">"+value+"</font>";
        }
    }
</script>
</div>