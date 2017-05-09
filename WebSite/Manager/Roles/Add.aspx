<%@ Page Language="C#" AutoEventWireup="true" Inherits="Web.CS.Manager.Roles.Add" %>
<%if(!action.Equals("save")){ %>
<div id="RolesAdd">
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="60" align="right">
            所属部门：
        </th>
        <td align="left">
            <select name="storesid" id="storesid"<%=SuperAdmin?"":" disabled=\"disabled\"" %>>
                <option value="0">全局</option>
                <%=Web.UI.Sys.stores.GetOption(StoresID) %>
            </select>
        </td>
    </tr>
    <tr>
        <th width="60" align="right">
            角色名称：
        </th>
        <td align="left">
            <input type="text" class="validate[required,length[1,50]] text" name="roleName" id="roleName" size="30" maxlength="50" />
        </td>
    </tr>
        <tr>
        <th width="60" align="right">
            描述：
        </th>
        <td align="left">
            <textarea name="roleDescription" cols="30" style="width: 350px; height: 95px;" rows="5" id="roleDescription"></textarea>
        </td>
    </tr>
</table>
</div>
<%} %>