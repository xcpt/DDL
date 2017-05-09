<%@ Page Language="C#" AutoEventWireup="true" Inherits="Staff_performance_Add" %>
<%if(!action.Equals("save")){ %>
<div id="performanceAdd">
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="100" align="right">
            员工姓名：
        </th>
        <td align="left">
            <select name="memberid" id="performancememberid" style="width:280px;">
                <%=Web.UI.Staff.member.GetOption(StoresID,"") %>
            </select>
            <script type="text/javascript">$("#performancememberid").chosen();</script>
        </td>
    </tr>
    <tr>
        <th align="right">
            考勤类型：
        </th>
        <td align="left">
            <select name="type" id="performancetype" style="width:100px;">
            <%=Web.UI.Data.Basic.performanceType("") %>
            </select>
            <script type="text/javascript">$("#performancetype").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <tr>
        <th align="right">
            考勤日期：
        </th>
        <td align="left">
            <input type="text" class="validate[required]" name="datetime" id="performancedatetime" readonly="readonly" onclick="WdatePicker({ skin: 'ext' })" size="10" />
        </td>
    </tr>
    <tr>
        <th align="right">
            当月工资变更：
        </th>
        <td align="left">
            <input type="text" class="validate[required]" name="num" id="performancenum" size="50" maxlength="50" />
        </td>
    </tr>
    <tr>
        <th align="right">备注：</th>
        <td align="left">
            <textarea name="content" id="performancecontent" style="width: 365px; height: 85px;"></textarea>
        </td>
    </tr>
</table>
</div>
<%} %>
