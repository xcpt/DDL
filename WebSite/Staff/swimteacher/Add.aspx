<%@ Page Language="C#" AutoEventWireup="true" Inherits="Staff_swimteacher_Add" %>
<%if(!action.Equals("save")){ %>
<div id="swimteacherAdd">
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">
            老师选择：
        </th>
        <td align="left" colspan="3">
            <select name="memberid" id="swimteachermemberid" style="width:180px;">
                <%=Web.UI.Staff.member.GetOption(StoresID,"") %>
            </select>
        </td>
    </tr>
    <tr>
        <th align="right">
            网上预约：
        </th>
        <td align="left">
            <select name="iswww" id="swimteacheriswww" style="width:100px;">
                <option value="1" selected="selected">可以</option>
                <option value="0">不可以</option>
            </select>
            <script type="text/javascript">$("#swimteacheriswww").chosen({ disable_search_threshold: 10 });</script>
        </td>
    <%if(IsOperate){ %>
        <th align="right">
            状态：
        </th>
        <td align="left">
            <select name="isopen" id="swimteacherisopen" style="width:100px;">
                <option value="1" selected="selected">启用</option>
                <option value="0">禁用</option>
            </select>
            <script type="text/javascript">$("#swimteacherisopen").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <%} %>
</table>
</div>
<%} %>
