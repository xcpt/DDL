<%@ Page Language="C#" AutoEventWireup="true" Inherits="Staff_score_Add" %>
<%if(!action.Equals("save")){ %>
<div id="scoreAdd">
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="100" align="right">
            员工姓名：
        </th>
        <td align="left">
            <select name="memberid" id="scorememberid" style="width:280px;">
                <%=Web.UI.Staff.member.GetOption(StoresID,"") %>
            </select>
            <script type="text/javascript">$("#scorememberid").chosen();</script>
        </td>
    </tr>
    <tr>
        <th align="right">
            考勤类型：
        </th>
        <td align="left">
            <select name="type" id="scoretype" style="width:100px;">
            <%=Web.UI.Data.Basic.performanceType("") %>
            </select>
            <script type="text/javascript">$("#scoretype").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <tr>
        <th align="right">
            考勤日期：
        </th>
        <td align="left">
            <input type="text" class="validate[required]" name="datetime" id="scoreisdatetime" readonly="readonly" onclick="WdatePicker({ skin: 'ext' })" size="10" />
        </td>
    </tr>
    <tr>
        <th align="right">
            扣减/增加：
        </th>
        <td align="left">
            <select name="isadd" id="scoreisadd" style="width:70px;">
                <option value="1" selected="selected">增加</option>
                <option value="0">扣减</option>
            </select>
            <script type="text/javascript">$("#scoreisadd").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <tr>
        <th align="right">
            分值：
        </th>
        <td align="left">
            <input type="text" class="validate[required]" name="num" id="scoreisnum" size="50" maxlength="50" />
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
