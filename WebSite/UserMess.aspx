<%@ Page Language="C#" AutoEventWireup="true" Inherits="Web.CS.UserMess" %>
<div>
    <div class="usermess"><span class="right">&nbsp;</span><span class="left">&nbsp;</span>
    <b><%=userName %></b><span><%=groupName %></span>&nbsp;&nbsp;<a href="" onclick="AjaxFun('Main.aspx','',' ','.Rnr');return false;">管理首页</a>&nbsp;&nbsp;<%=createCate %>&nbsp;&nbsp;|<a href="#" onclick="Dialog.confirm('您确定要退出登录吗？',function(){UserLogOut();});return false;">退出登录</a></div>
</div>