<%@ Page Language="C#" AutoEventWireup="true" Inherits="Staff_member_Modi" %>
<%if(!action.Equals("save")){ %>
<div id="memberModi" style="overflow-y:auto;height:555px;">
<input type="hidden" name="id" value="<%=mModel.id %>" />
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">
            员工姓名：
        </th>
        <td align="left">
            <input type="text" class="validate[required,length[1,250]]" name="name" id="membername" value="<%=mModel.name %>" size="30" maxlength="250" />
        </td>
        <th width="80" align="right">
            英文名称：
        </th>
        <td align="left">
            <input type="text" class="validate[length[0,250]]" name="enname" id="memberenname" value="<%=mModel.enname %>" size="30" maxlength="250" />
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            身份证号：
        </th>
        <td align="left" colspan="3">
            <input type="text" class="validate[required,length[1,250]]" name="cnid" id="membercnid" value="<%=mModel.cnid %>" size="50" maxlength="250" />
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            身份证地址：
        </th>
        <td align="left" colspan="3">
            <input type="text" class="validate[required,length[1,250]]" name="cnidaddress" id="membercnidaddress" value="<%=mModel.cnidaddress %>" size="50" maxlength="250" />
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            手机号码：
        </th>
        <td align="left">
            <input type="text" class="validate[required,custom[mobilephone]]" name="mobile" id="membermobile" value="<%=mModel.mobile %>" size="30" maxlength="250" />
        </td>
        <th width="80" align="right">
            信箱：
        </th>
        <td align="left">
            <input type="text" class="validate[custom[email]]" name="email" id="memberemail" size="30" value="<%=mModel.email %>" maxlength="250" />
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            QQ：
        </th>
        <td align="left">
            <input type="text" class="validate[custom[onlyNumber]]" name="qq" id="memberqq" size="30" value="<%=mModel.qq %>" maxlength="250" />
        </td>
        <th width="80" align="right">
            家庭住址：
        </th>
        <td align="left">
            <input type="text" name="homeaddress" id="memberhomeaddress" size="30" value="<%=mModel.homeaddress %>" maxlength="250" />
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            亲属姓名：
        </th>
        <td align="left">
            <input type="text" name="relativesname" id="memberrelativesname" size="30" value="<%=mModel.relativesname %>" maxlength="250" />
        </td>
        <th width="80" align="right">
            家庭电话：
        </th>
        <td align="left">
            <input type="text" name="hometel" id="memberhometel" size="30" maxlength="250" value="<%=mModel.hometel %>" />
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
                <%=Web.UI.Staff.position.GetOption(StoresID,mModel.positionid)%>
            </select>
            <script type="text/javascript">$("#memberpositionid").chosen();</script>
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
                <%=Web.UI.Staff.department.GetOption(StoresID,mModel.departmentid) %>
            </select>
            <script type="text/javascript">$("#memberdepartmentid").chosen();</script>
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            员工状态：
        </th>
        <td align="left">
            <select name="status" id="memberstatus" style="width:100px;">
                <option value="1"<%=Base.Fun.fun.isSelected(mModel.status,"1") %>>全职</option>
                <option value="0"<%=Base.Fun.fun.isSelected(mModel.status,"0") %>>兼职</option>
                <option value="2"<%=Base.Fun.fun.isSelected(mModel.status,"2") %>>离职</option>
                <option value="3"<%=Base.Fun.fun.isSelected(mModel.status,"3") %>>退休</option>
            </select>
            <script type="text/javascript">$("#memberstatus").chosen({ disable_search_threshold: 10 });</script>
        </td>
        <th width="80" align="right">
            性别：
        </th>
        <td align="left">
            <select name="sex" id="membersex" style="width:100px;">
                <option value="0"<%=Base.Fun.fun.isSelected(mModel.sex,"0") %>>男</option>
                <option value="1"<%=Base.Fun.fun.isSelected(mModel.sex,"1") %>>女</option>
            </select>
            <script type="text/javascript">$("#membersex").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            员工生日：
        </th>
        <td align="left"><input type="text" class="validate[required]" name="birthday" value="<%=Base.Fun.fun.Get_Date(DateTime.Parse(mModel.birthday),"YY04-MM-DD") %>" id="memberbirthday" readonly="readonly" onclick="WdatePicker({ skin: 'ext' })" size="10" maxlength="250" /></td>
        <th width="80" align="right">
            是否上保险：
        </th>
        <td align="left">
            <select name="isinsurance" id="memberisinsurance" style="width:100px;">
                <option value="1"<%=Base.Fun.fun.isSelected(mModel.isinsurance,"1") %>>是</option>
                <option value="0"<%=Base.Fun.fun.isSelected(mModel.isinsurance,"0") %>>否</option>
            </select>
            <script type="text/javascript">$("#memberisinsurance").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            入职时间：
        </th>
        <td align="left"><input type="text" name="entrytime" id="memberentrytime" value="<%=Web.UI.Ami.DateTimeFormat(mModel.entrytime,"YY04-MM-DD") %>" readonly="readonly" onclick="WdatePicker({ skin: 'ext' })" size="10" maxlength="250" /></td>
        <th width="80" align="right">
            离职时间：
        </th>
        <td align="left"><input type="text" name="quittime" id="memberquittime" value="<%=Web.UI.Ami.DateTimeFormat(mModel.quittime,"YY04-MM-DD") %>" readonly="readonly" onclick="WdatePicker({ skin: 'ext' })" size="10" maxlength="250" /></td>
    </tr>
    <tr>
        <th width="80" align="right">
            照片头像：
        </th>
        <td align="left" colspan="3">
            <div style="float:right;"><input type="button" value="上传头像" onclick="UploadFile('memberuserface', 'PIC');" icon="icon-picture_add" /></div><input type="text" name="userface" id="memberuserface" size="50" value="<%=mModel.userface %>" maxlength="250" class="jTip" />
        </td>
    </tr>
</table>
</div>
<%} %>