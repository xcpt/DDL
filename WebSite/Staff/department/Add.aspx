<%@ Page Language="C#" AutoEventWireup="true" Inherits="Staff_department_Add" %>
<%if(!action.Equals("save")){ %>
<div id="departmentAdd" style="overflow-y:auto;height:200px;">
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">
            部门名称：
        </th>
        <td align="left">
            <input type="text" class="validate[required,length[1,250]]" name="title" id="departmenttitle" size="50" maxlength="250" />
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            部门主管：
        </th>
        <td align="left">
            <%if(MemberIsAdd){ %>
            <div style="float:right;"><input type="submit" name="button" id="button" onclick="CreateWindow('Staff/member/Add.aspx?idname=departmentheadmemberid', '添加员工', 'Staff/member/Add.aspx?action=save&idname=departmentheadmemberid', 600, 350, 'memberAdd')" icon="icon-user_add" value="添加员工" /></div>
            <%} %>
            <select name="headmemberid" id="departmentheadmemberid" style="width:280px;">
                <option value="0">请选择</option>
                <%=Web.UI.Staff.member.GetOption(StoresID,"") %>
            </select>
            <script type="text/javascript">$("#departmentheadmemberid").data("placeholder", "请选择...").chosen();</script>
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            部门描述：
        </th>
        <td align="left">
            <textarea name="description" id="departmentdescription" style="width: 365px; height: 85px;"></textarea>
        </td>
    </tr>
</table>
</div>
<%} %>
