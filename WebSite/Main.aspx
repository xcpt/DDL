<%@ Page Language="C#" AutoEventWireup="true" Inherits="Web.CS.Main" %>
<div class="Rtop">
    <div class="RlmM">管理首页：</div>
</div>
<div class="RtbK" id="SYCMSViewStyleMess" style="overflow-x:none;overflow-y:auto;position:relative;">
    <div class="admin_nr">
	<ul class="admin_list">
    	<li class="bg1">
        <%if(customerUserIsList){ %>
                <a href="" onclick="CreateWindow('customer/User/Lists_Load.aspx', '快速扫描会员卡', 'customer/User/Lists_Load.aspx?action=save', 400, 50, 'customerUserAdd');return false;">快速刷卡</a>
                <%}else{ %>
            <a href="#" class="grayscale" onclick="return false;">快速刷卡</a>
                <%} %>
        </li>
        <li class="bg2"><%if (UserappointmentIsList){ %>
                <a href="" onclick="AjaxFun('customer/Userappointment/Lists.aspx','action=view','正在打开会员预约管理','.Rnr');return false;">会员预约</a>
                <%}else{ %>
              <a href="#" class="grayscale" onclick="return false;">会员预约</a>
        <%} %></li>
        <li class="bg3"><%if(customerUserIsList){ %>
                <a href="" onclick="AjaxFun('customer/User/Lists.aspx','action=view','正在打开会员管理','.Rnr');return false;">会员管理</a>
                <%}else{ %>
              <a href="#" class="grayscale" onclick="return false;">会员管理</a>
                <%} %>
            </li>
        <li class="bg4"><%if(UserConsumptionIsList){ %>
                <a href="" onclick="AjaxFun('customer/UserConsumption/Lists.aspx','action=view','正在打开消费管理','.Rnr');return false;">会员消费</a>
                <%}else{ %>
                <a href="#" class="grayscale" onclick="return false;">会员消费</a>
                <%} %></li>
        <li class="bg5"><%if (UserMessageIsList)
                          { %>
                <a href="" onclick="AjaxFun('Sys/Message/Lists.aspx','action=view','正在打开会员反馈管理','.Rnr');return false;">会员评价</a>
                <%}else{ %>
                <a href="#" class="grayscale" onclick="return false;">会员评价</a>
                <%} %></li>
    </ul>
    <div class="face">
    	<div class="face_fl">
        	<div class="welcome">
                <h2>欢迎使用家有儿女管理系统</h2>
                <p>系统使用流程：</p>
                <ul>
                    <li><%if(customerUserIsList){ %>
                <a href="" onclick="AjaxFun('customer/User/Lists.aspx','action=view','正在打开会员管理','.Rnr');return false;">会员管理</a>
                <%}else{ %>
              <a href="#" class="grayscale" onclick="return false;">会员管理</a>
                <%} %></li>
                    <li><%if (UserappointmentIsList){ %>
                <a href="" onclick="AjaxFun('customer/Userappointment/Lists.aspx','action=view','正在打开会员预约管理','.Rnr');return false;">预约管理</a>
                <%}else{ %>
              <a href="#" class="grayscale" onclick="return false;">预约管理</a>
        <%} %></li>
                    <li><a href="#" class="grayscale" onclick="return false;">运营分析</a></li>
                </ul>
            </div>
        </div>
        <div class="face_fr">
            <%if (UserappointmentIsList){ %>
        	<div class="mess">
            	<h2>预约人数</h2>
                <div class="text"><%=Web.UI.customer.Userappointment.MainShow()%></div>
            </div>
            <%} %>
            <%if (UserMessageIsList)
                          { %>
            <div class="mess">
            	<h2>APP意见反馈</h2>
                <div class="text"><%=Web.UI.Sys.Message.MainShow() %></div>
            </div>
            <%} %>
        </div>
    </div>
</div>
</div>
<script type="text/javascript">
    ScrollFun(".Rnr", "#SYCMSViewStyleMess", 40);
</script>
