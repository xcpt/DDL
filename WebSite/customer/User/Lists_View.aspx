<%@ Page Language="C#" AutoEventWireup="true" Inherits="customer_User_Lists_View" %>
<%if(!action.Equals("save")){ %>
<div id="UserAdd" style="height:450px;overflow-x:hidden;overflow-y:auto;">
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">会员姓名：</th>
        <td align="left" colspan="3"><%=uModel.name %></td>
    </tr>
    <tr>
        <th align="right">会员小名：</th>
        <td align="left" colspan="3"><%=uModel.nickname %></td>
    </tr>
    <tr>
        <th align="right">性别：</th>
        <td align="left"><%=(uModel.sex.Equals("0")?"男":"女") %></td>
        <th align="right" width="80">生日：</th>
        <td align="left"><%=Web.UI.Ami.DateTimeFormat(uModel.birthday,"YY04-MM-DD") %></td>
    </tr>
    <tr>
        <th align="right">家长姓名：</th>
        <td align="left"><%=uModel.parentName %></td>
        <th align="right">联系电话：</th>
        <td align="left"><%=uModel.tel %></td>
    </tr>
    <tr>
        <th align="right">妈妈手机：</th>
        <td align="left" colspan="3"><%=uModel.mobile %></td>
    </tr>
    <tr>
        <th align="right">所在小区：</th>
        <td align="left" colspan="3"><%=Web.UI.Sys.community.GetName(StoresID, uModel.communityid) %></td>
    </tr>
    <tr>
        <th align="right">有无病史：</th>
        <td align="left"><%=Web.UI.Data.Basic.Getillness(uModel.illness) %></td>
        <th align="right">有无过敏史：</th>
        <td align="left"><%=Web.UI.Data.Basic.Getallergy(uModel.allergy) %></td>
    </tr>
     <tr>
        <th align="right">婴儿类型：</th>
        <td align="left"><%=Web.UI.Data.Basic.GetBabyType(uModel.cycletype) %></td>
        <th align="right">客户来源：</th>
        <td align="left"><%=Web.UI.Data.Basic.GetUsersource(uModel.source) %></td>
    </tr>
    <tr>
        <th align="right">是否测量：</th>
        <td align="left"><%=(uModel.IsMeasure.Equals("0")?"不需要":"需要") %>
            </td>
        <th align="right">是否照相：</th>
        <td align="left"><%=(uModel.IsPhoto.Equals("0")?"不需要":"需要") %></td>
    </tr>
    <tr>
        <th align="right">备注：</th>
        <td align="left" colspan="3"><%=Base.Fun.fun.NoSql(uModel.content) %></td>
    </tr>
</table>
</div>
<%} %>