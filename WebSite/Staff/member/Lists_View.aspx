<%@ Page Language="C#" AutoEventWireup="true" Inherits="Staff_member_Lists_View" %>
<%if(!action.Equals("save")){ %>
<div id="memberAdd" style="overflow-y:auto;height:350px;">
 <input type="hidden" name="id" value="<%=mModel.id %>" />
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">
            员工姓名：
        </th>
        <td align="left"><%=mModel.name %>
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            英文名称：
        </th>
        <td align="left"><%=mModel.enname %>
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            身份证号：
        </th>
        <td align="left"><%=mModel.cnid %>
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            身份证地址：
        </th>
        <td align="left"><%=mModel.cnidaddress %>
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            手机号码：
        </th>
        <td align="left"><%=mModel.mobile %>
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            信箱：
        </th>
        <td align="left"><%=mModel.email %>
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            QQ：
        </th>
        <td align="left"><%=mModel.qq %>
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            家庭住址：
        </th>
        <td align="left"><%=mModel.homeaddress %>
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            亲属姓名：
        </th>
        <td align="left"><%=mModel.relativesname %>
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            家庭电话：
        </th>
        <td align="left"><%=mModel.hometel %>
        </td>
    </tr>
    <tr>
        <th width="80" align="right">员工职位：</th>
        <td align="left"><%=Web.UI.Staff.position.GetTitle(StoresID,mModel.positionid) %>
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            所属部门：
        </th>
        <td align="left"><%=Web.UI.Staff.department.GetTitle(StoresID, mModel.departmentid) %>
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            员工状态：
        </th>
        <td align="left"><%=Web.Model.Data.Basic.memberstatus[mModel.status] %>
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            性别：
        </th>
        <td align="left"><%=Web.Model.Data.Basic.Sex[mModel.sex] %>
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            员工生日：
        </th>
        <td align="left"><%=Base.Fun.fun.Get_Date(DateTime.Parse(mModel.birthday),"YY04-MM-DD") %></td>
    </tr>
     <tr>
        <th width="80" align="right">
            是否上保险：
        </th>
        <td align="left"><%=mModel.isinsurance.Equals("1")?"是":"否" %>
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            入职时间：
        </th>
        <td align="left"><%=Web.UI.Ami.DateTimeFormat(mModel.entrytime,"YY04-MM-DD") %>
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            离职时间：
        </th>
        <td align="left"><%=Web.UI.Ami.DateTimeFormat(mModel.quittime,"YY04-MM-DD") %>
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            照片头像：
        </th>
        <td align="left"><%if (mModel.userface.Length > 0)
                           {
                               Response.Write("<a href=\"" + mModel.userface + "\" target=\"_blank\">" + mModel.userface + "</a>");
                           }
                           else
                           {
                               Response.Write("无");
                           }%>
        </td>
    </tr>
</table>
</div>
<%} %>