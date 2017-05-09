<%@ Page Language="C#" AutoEventWireup="true" Inherits="Web.CS.Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>家有儿女-国际艺术早教领导品牌</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link href="css/css.ashx" rel="stylesheet" type="text/css" />
<link href="css/login.css" rel="stylesheet" type="text/css" />
<link rel="shortcut icon" href="images/favicon.ico" />
</head>
<body scroll="no" style="overflow:hidden;" class="LGbg">
<noscript>您的浏览器不支持 Javascript<iframe src="*.html" style="width:0px;height:0px;"></iframe></noscript>
<div style="padding:auto;margin:auto;" id="WinLoadViewWait"><div style="height:12px;padding:20px;" id="LoadImgspaceused1"><img style="width:0px;height:0px;" src="images/progress/progressbar.gif"/><img style="width:0px;height:0px;" src="images/progress/progressbg_black.gif"/><img style="width:0px;height:0px;" src="images/progress/progressbg_green.gif"/><img style="width:0px;height:0px;" src="images/progress/progressbg_orange.gif"/><img style="width:0px;height:0px;" src="images/progress/progressbg_red.gif"/><img style="width:0px;height:0px;" src="images/progress/progressbg_yellow.gif" /></div></div>
<div id="tooltip" style="display:none;"><p></p></div>
<div id="login" style="display:none;">
<div class="login">
	<div class="name"><input id="userName" class="validate[required,length[1,20]] Linp1" type="text" size="22" maxlength="20" tabindex="1" name="userName"/></div>
	<div class="name"><input id="userPass" class="validate[required,length[1,32]] Linp1" type="password" size="22" maxlength="32" tabindex="2" name="userPass"/></div>
	<div class="yzm"><input id="Code" class="validate[required,length[4,4]] Linp1" type="text" size="4" maxlength="4" tabindex="3" name="Code"/><img id="chk_img" onclick="checkwd_reload()" alt="单击换一个验证码" class="Linp1" style="width:78px;height:22px;border:0px;" /><a onclick="checkwd_reload();return false;" href="#"><img src="images/shuaxin.png" alt=""/></a></div>
    <div class="online"><input type="checkbox" value="1" name="logindays" id="logindays"/><label for="logindays">保持一直在线</label></div>
    <div class="denglu"><input id="LoginButton" class="Lbot1" type="submit" value="登 录" tabindex="4" name="LoginButton"/></div>
</div>
<div class="copy"><p>Copyright 2015 北京家有儿女水育科技有限公司版权所有</p><p>总部地址：北京市丰台区总部基地时代财富天地D栋15层     电话：4000 668 188    官网：www.jiayouernv.com</p></div>
</div>
<div id="AdminMessage" style="display:none;">
<div id="header">
	<div class="logo"><a href="" onclick="AjaxFun('Main.aspx',null,' ','.Rnr');return false;"><img src="images/logo.gif" alt="logo" /></a></div>
    <div class="TgnButton" id="UseerNameMessageButton">&nbsp;</div>
    <div class="Tgn" id="UseerNameMessage"></div>
    <div class="Ttime"></div>
    <%if(customerUserIsList){ %>
    <div class="Tnav" style="right:10px;padding-top:51px;display:block;"><input type="button" value="快速扫描会员卡" onclick="CreateWindow('customer/User/Lists_Load.aspx', '快速扫描会员卡', 'customer/User/Lists_Load.aspx?action=save', 400, 50, 'customerUserAdd')" icon="icon-zoom" id="SelectCard" /></div>
    <%} %>
</div>
<table width="100%" border="0" cellpadding="0" cellspacing="0" style="margin:0px;padding:0px;">
  <tr>
    <td valign="top" style="margin:0px;padding:0px;width:215px;">

        <div class="l_nav" id="Left_2" style="height:500px;overflow-y:auto">

        </div></td>
    <td valign="top"><div class="Rnr">
 
      </div></td>
  </tr>
</table>
<script src="js/js.js" type="text/javascript"></script>
<%=Web.UI.Default.View(UserLogin)%>
<iframe src="" id="DownFileWin" name="DownFileWin" style="width:0px;height:0px;display:none;"></iframe>
    <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0" width="0" height="0" id="printflash">  
         <param name="movie" value="images/printflash.swf" />  
         <param name="allowScriptAccess" value="always" />  
         <param name="allowFullScreen" value="false" />  
         <param name="quality" value="high" />  
         <param name="wmode" value="window" />  
         <embed src="images/printflash.swf" id="printflashf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" width="0" height="0" allowScriptAccess="always" wmode="window" ></embed>  
    </object>
<img src="http://112.126.81.86/images/erwm.jpg" style="width:0px;height:0px;" />
</div>
</body>
</html>