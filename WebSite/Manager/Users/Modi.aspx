<%@ Page Language="C#" AutoEventWireup="true" Inherits="Web.CS.Manager.Users.Modi" %>
<%if(!action.Equals("save")){ %>
<div id="UsersModi">
<input type="hidden" value="<%=id %>" name="id" id="id" />
<table class="table StyleView" width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <th width="80" align="right">
            用户名：
        </th>
        <td align="left">
            <input type="text" class="validate[required,length[1,50]]" name="userName" id="userName" value="<%=userName %>" size="30" maxlength="50" />
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            新密码：
        </th>
        <td align="left">
            <input type="password" name="uPass" id="uPass" size="30" class="validate[length[0,50]]"  maxlength="50" />
        </td>
    </tr>
     <tr>
        <th width="80" align="right">
            确认新密码：
        </th>
        <td align="left">
            <input type="password" name="userCPass" id="userCPass" class="validate[length[0,50],confirm[uPass]]" size="30" maxlength="50" />
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            所属角色：
        </th>
        <td align="left"><select name="RoleID" id="RoleID">
            <option value="0">请选择</option><%=Web.UI.Roles.GetManagerRole(roleId,StoresID,SuperAdmin) %></select>
        </td>
    </tr>
    <%if (IsOperate)
      { %>
     <tr>
        <th width="80" align="right">
            是否锁定：
        </th>
        <td align="left">
			<input type="radio" name="isLock" id="isLock_2" value="1" <%=Base.Fun.fun.isChecked("1",isLock) %> /><label for="isLock_2">是</label>
            <input type="radio" name="isLock" id="isLock_1" value="0" <%=Base.Fun.fun.isChecked("0",isLock) %> /><label for="isLock_1">否</label>
        </td>
    </tr>
    <%} %>
    <tr>
        <th width="80" align="right">
            所属门店：
        </th>
        <td align="left"><select name="StoresID" id="StoresID"><%if (SuperAdmin) { Response.Write("<option value=\"0\">请选择</option>" + Web.UI.Sys.stores.GetOption(StoresID)); } else { Response.Write(Web.UI.Sys.stores.GetOptionIsBoss(StoresID)); } %></select>
        </td>
    </tr>
    <%if (IsOperate)
      { %>
     <tr>
        <th width="80" align="right">
            门店店长：
        </th>
        <td align="left">
			<input type="radio" name="IsBoss" id="IsBoss0" value="1" <%=Base.Fun.fun.isChecked("1",IsBoss) %> /><label for="IsBoss0">是</label>
            <input type="radio" name="IsBoss" id="IsBoss1" value="0" <%=Base.Fun.fun.isChecked("0",IsBoss) %> /><label for="IsBoss1">否</label>
        </td>
    </tr>
    <%} %>
    </table>
</div>
<%} %>