<%@ Page Language="C#" AutoEventWireup="true" Inherits="Web.CS.Manager.Users.Add" %>
<%if(!action.Equals("save")){ %>
<div id="UsersAdd">
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">
            用户名：
        </th>
        <td align="left">
            <input type="text" class="validate[required,length[1,50]]" name="userName" id="userName" size="30" maxlength="50" />
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            密码：
        </th>
        <td align="left">
            <input type="password" class="validate[required,length[1,50]]" name="uPass" id="uPass" size="30" maxlength="50" />
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            确认密码：
        </th>
        <td align="left">
            <input type="password" class="validate[required,confirm[uPass],length[1,50]]" name="userCPass" id="userCPass" size="30" maxlength="50" />
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            所属角色：
        </th>
        <td align="left">
            <select name="RoleID" id="RoleID">
            <option value="0">请选择</option>
            <%=Web.UI.Roles.GetManagerRole(UserRoles,StoresID,SuperAdmin) %>
            </select>
        </td>
    </tr>
    <%if(IsOperate){ %>
    <tr>
        <th width="80" align="right">
            是否锁定：
        </th>
        <td align="left">
			<input type="radio" name="isLock" id="isLock_2" value="1" /><label for="isLock_2">是</label>
            <input type="radio" name="isLock"  id="isLock_1" value="0" checked/><label for="isLock_1">否</label>
        </td>
    </tr>
    <%} %>
    <tr>
        <th width="80" align="right">
            所属门店：
        </th>
        <td align="left"><select name="StoresID"><%if (SuperAdmin) { Response.Write("<option value=\"0\">请选择</option>" + Web.UI.Sys.stores.GetOption("")); } else { Response.Write(Web.UI.Sys.stores.GetOptionIsBoss(StoresID)); } %></select>
        </td>
    </tr>
    <%if(SuperAdmin){ %>
    <tr>
        <th width="80" align="right">
            门店店长：
        </th>
        <td align="left">
			<input type="radio" name="IsBoss" id="IsBoss0" value="1" /><label for="IsBoss0">是</label>
            <input type="radio" name="IsBoss"  id="IsBoss1" checked="checked" value="0"/><label for="IsBoss1">否</label>
        </td>
    </tr>
    <%} %>
</table>
</div>
<%} %>