<%@ Page Language="C#" AutoEventWireup="true" Inherits="Staff_member_Add" %>
<%if(!action.Equals("save")){ %>
<div id="memberAdd" style="overflow-y:auto;height:555px;">
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">
            员工姓名：
        </th>
        <td align="left">
            <input type="text" class="validate[required,length[1,250]]" name="name" id="membername" size="20" maxlength="250" />
        </td>
        <th width="80" align="right">
            英文名称：
        </th>
        <td align="left">
            <input type="text" class="validate[length[0,250]]" name="enname" id="memberenname" size="20" maxlength="250" />
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            身份证号：
        </th>
        <td align="left" colspan="3">
            <input type="text" class="validate[required,length[1,250]]" name="cnid" id="membercnid" size="50" maxlength="250" />
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            身份证地址：
        </th>
        <td align="left" colspan="3">
            <input type="text" class="validate[required,length[1,250]]" name="cnidaddress" id="membercnidaddress" size="50" maxlength="250" />
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            手机号码：
        </th>
        <td align="left">
            <input type="text" class="validate[required,custom[mobilephone]]" name="mobile" id="membermobile" size="30" maxlength="250" />
        </td>
        <th width="80" align="right">
            信箱：
        </th>
        <td align="left">
            <input type="text" class="validate[custom[email]]" name="email" id="memberemail" size="30" maxlength="250" />
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            QQ：
        </th>
        <td align="left">
            <input type="text" class="validate[custom[onlyNumber]]" name="qq" id="memberqq" size="30" maxlength="250" />
        </td>
        <th width="80" align="right">
            家庭住址：
        </th>
        <td align="left">
            <input type="text" name="homeaddress" id="memberhomeaddress" size="30" maxlength="250" />
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            亲属姓名：
        </th>
        <td align="left">
            <input type="text" name="relativesname" id="memberrelativesname" size="30" maxlength="250" />
        </td>
        <th width="80" align="right">
            家庭电话：
        </th>
        <td align="left">
            <input type="text" name="hometel" id="memberhometel" size="30" maxlength="250" />
        </td>
    </tr>
    <tr>
        <th width="80" align="right">员工职位：</th>
        <td align="left" colspan="3">
            <%if (positionIsAdd)
              { %>
            <div style="float:right;"><input type="button" name="button" id="Submit1" onclick="CreateWindow('Staff/position/Add.aspx?idname=memberpositionid', '添加职位', 'Staff/position/Add.aspx?action=save&idname=memberpositionid', 500, 200, 'memberAdd')" icon="icon-addNew" value="添加职位" /></div>
            <%} %>
            <select name="positionid" id="memberpositionid" style="width:200px;">
                <option value="0">请选择职位</option>
                <%=Web.UI.Staff.position.GetOption(StoresID, "")%>
            </select>
            <script type="text/javascript">$("#memberpositionid").data("placeholder", "请选择...").chosen();</script>
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            所属部门：
        </th>
        <td align="left" colspan="3">
            <%if (departmentIsAdd)
              { %>
            <div style="float:right;"><input type="button" name="button" id="button" onclick="CreateWindow('Staff/department/Add.aspx?idname=memberdepartmentid', '添加部门', 'Staff/department/Add.aspx?action=save&idname=memberdepartmentid', 500, 200, 'memberAdd')" icon="icon-vcard_add" value="添加部门" /></div>
            <%} %>
            <select name="departmentid" id="memberdepartmentid" style="width:200px;">
                <option value="0">请选择部门</option>
                <%=Web.UI.Staff.department.GetOption(StoresID,"") %>
            </select>
            <script type="text/javascript">$("#memberdepartmentid").data("placeholder", "请选择...").chosen();</script>
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            员工状态：
        </th>
        <td align="left">
            <select name="status" id="memberstatus" style="width:100px;">
                <option value="1">全职</option>
                <option value="0">兼职</option>
                <option value="2">离职</option>
                <option value="3">退休</option>
            </select>
            <script type="text/javascript">$("#memberstatus").chosen({ disable_search_threshold: 10 });</script>
        </td>
        <th width="80" align="right">
            性别：
        </th>
        <td align="left">
            <select name="sex" id="membersex" style="width:100px;">
                <option value="0">男</option>
                <option value="1" selected="selected">女</option>
            </select>
            <script type="text/javascript">$("#membersex").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            员工生日：
        </th>
        <td align="left"><input type="text" class="validate[required]" name="birthday" id="memberbirthday" readonly="readonly" onclick="WdatePicker({ skin: 'ext' })" size="10" /></td>
        <th width="80" align="right">
            是否上保险：
        </th>
        <td align="left">
            <select name="isinsurance" id="memberisinsurance" style="width:100px;">
                <option value="1">是</option>
                <option value="0">否</option>
            </select>
            <script type="text/javascript">$("#memberisinsurance").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            入职时间：
        </th>
        <td align="left"><input type="text" name="entrytime" id="memberentrytime" readonly="readonly" value="<%=DateTime.Now.ToString("yyyy-MM-dd")%>" onclick="WdatePicker({ skin: 'ext' })" size="10" maxlength="250" /></td>
        <th width="80" align="right">
            离职时间：
        </th>
        <td align="left"><input type="text" name="quittime" id="memberquittime" readonly="readonly" onclick="WdatePicker({ skin: 'ext' })" size="10" maxlength="250" /></td>
    </tr>
    <tr>
        <th width="80" align="right">
            照片头像：
        </th>
        <td align="left" colspan="3">
            <div style="float:right;"><input type="button" value="上传头像" onclick="UploadFile('memberuserface', 'PIC');" icon="icon-picture_add" /></div><input type="text" name="userface" id="memberuserface" size="50" maxlength="250" class="jTip" />
        </td>
    </tr>
</table>
</div>
<%} %>
