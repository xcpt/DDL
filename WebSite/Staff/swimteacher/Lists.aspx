<%@ Page Language="C#" AutoEventWireup="true" Inherits="Staff_swimteacher_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">泳师管理:</div>
</div>
<div class="Tgnk">
	<div class="Rtss"<%=IsAdd?"":" style=\"padding-bottom:5px;\"" %>>
	  <div style="float:left" id="SearchInputValue">姓名：<select name="memberid" id="Searchswimteachermemberid">
          <option value="">&nbsp;</option>
          <%=Web.UI.Staff.member.GetOption(StoresID,"") %>
        </select>&nbsp;&nbsp;状态：<select name="isopen" id="SearchswimteacherIsOpen" style="width:70px;">
                <option value="" selected="selected">&nbsp;</option>
                <option value="1">启用</option>
                <option value="0">禁用</option>
            </select>&nbsp;&nbsp;网上预约：<select name="iswww" id="Searchswimteacheriswww" style="width:70px;">
                <option value="" selected="selected">&nbsp;</option>
                <option value="1">能</option>
                <option value="0">不能</option>
            </select>&nbsp;&nbsp;部门：<select name="departmentid" id="Searchswimteacherdepartmentid" style="width:150px;">
                <option value="" selected="selected">&nbsp;</option>
                <%=Web.UI.Staff.department.GetOption(StoresID,"") %>
            </select></div>
	  <div style="float:left"><input type="submit" name="button" id="SearchButton" value="搜 索" onclick="$('#swimteacherGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
    <%if (IsAdd)
      { %>
    <div class="gnANk">
        <input type="submit" name="button" id="button" onclick="CreateWindow('Staff/swimteacher/Add.aspx', '添加泳师','Staff/swimteacher/Add.aspx?action=save',400, 140,'swimteacherAdd')" icon="icon-addNew" value="添加泳师" />
    </div>
    <%} %>
</div>
<div class="RtbK">
    <table id="swimteacherGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#swimteacherGrid").flexigrid
    (
    {
        url: 'Staff/swimteacher/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '姓名', name: 'name', width: 100,autoSize:true, sortable: false, align: 'left'},
            { display: '性别', name: 'type', width: 35, sortable: false, align: 'left',process:SexFun},
            { display: '部门', name: 'datetime', width: 120, sortable: false, align: 'left'},
            { display: '网预', name: 'iswww', width: 35, sortable: false, align: 'center',process:OperateImgFun},
            { display: '状态', name: 'IsOpen', width: 35, sortable: false, align: 'center',process:IsAuditImgFun}
        ],
        showcheckbox:false,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.Staff.swimteacher.View(StoresID, memberid, isopen, iswww, departmentid)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
    }
    );
    function OperateImgFun(value,id)
    {
        <%if(IsOperate){ %>
        return "<a href=\"#\" onclick=\"var obj=this;AjaxFun('Staff/swimteacher/Operate.aspx', 'id="+id+"', '正在设置属性，请稍候...',function(html){if (html){$(obj).html(ShowTrueOrFalse(html,''));}});return false;\">"+ShowTrueOrFalse(value,"")+"</a>";
        <%}else{ %>
        return ShowTrueOrFalse(value);
        <%} %>
    }
    function IsAuditImgFun(value,id)
    {
        <%if(IsAudit){ %>
        return "<a href=\"#\" onclick=\"var obj=this;AjaxFun('Staff/swimteacher/Audit.aspx', 'id="+id+"', '正在设置属性，请稍候...',function(html){if (html){$(obj).html(ShowTrueOrFalse(html,''));}});return false;\">"+ShowTrueOrFalse(value,"")+"</a>";
        <%}else{ %>
        return ShowTrueOrFalse(value);
        <%} %>
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
    GridFun(".Rnr", gridList, <%=IsAdd?"167":"140" %>, 2);
    $("#Searchswimteachermemberid").chosen({ width:"120px"});
    $("#SearchswimteacherIsOpen").chosen({ disable_search_threshold: 10 ,width:"60px"});
    $("#Searchswimteacheriswww").chosen({ disable_search_threshold: 10 ,width:"60px"});
    $("#Searchswimteacherdepartmentid").chosen({ width:"120px"});
</script>
<%}
  else
  {
      Response.Write(Web.UI.Staff.swimteacher.View(StoresID, memberid, isopen, iswww, departmentid));
  }%>