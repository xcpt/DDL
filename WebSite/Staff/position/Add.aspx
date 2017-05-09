<%@ Page Language="C#" AutoEventWireup="true" Inherits="Staff_position_Add" %>
<%if(!action.Equals("save")){ %>
<div id="positionAdd">
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">
            职位：
        </th>
        <td align="left">
            <input type="text" class="validate[required]" name="title" id="positiontitle" size="50" maxlength="50" />
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            级别：
        </th>
        <td align="left">
            <select name="level" id="positionlevel" style="width:100px;">
                <option value="初级">初级</option>
                <option value="中级">中级</option>
                <option value="高级">高级</option>
            </select>
            <script type="text/javascript">$("#positionlevel").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            底薪：
        </th>
        <td align="left">
            <input type="text" class="validate[required]" name="salary" id="positionsalary" size="50" maxlength="50" />
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            保险：
        </th>
        <td align="left">
            <input type="text" class="validate[required]" name="deducted" id="positiondeducted" size="50" maxlength="50" />
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            提成：
        </th>
        <td align="left">
            <select name="istake" id="positionistake" style="width:100px;">
                <option value="0">无</option>
                <option value="1">有</option>
            </select>
            <script type="text/javascript">$("#positionistake").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <tr>
        <th width="80" align="right">职责描述：</th>
        <td align="left">
            <textarea name="description" id="positiondescription" style="width: 365px; height: 85px;"></textarea>
        </td>
    </tr>
</table>
</div>
<%} %>
