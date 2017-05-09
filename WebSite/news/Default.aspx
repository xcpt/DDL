<%@ Page Language="C#" AutoEventWireup="true" Inherits="news_Default" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="apple-touch-fullscreen" content="yes" />
<meta name="format-detection" content="telephone=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<meta name="viewport" content="width=640, user-scalable=no, target-densitydpi=device-dpi"/>
<meta name="apple-mobile-web-app-status-bar-style" content="black" />
<meta name="format-detection" content="telephone=no" />
    <link href="css/video-js.css" rel="stylesheet" type="text/css"/>
    <title><%=nModel.title %></title>
    <script src="../Js/jquery.min.js" type="text/javascript"></script>
    <script src="js/video.js"></script>
    <style type="text/css">
        body {
        padding:20px;
        }
        .title {
        text-align:center;
        }
    </style>
    <script type="text/javascript">
        if (/Android (\d+\.\d+)/.test(navigator.userAgent)) {
            var version = parseFloat(RegExp.$1);
            if (version > 2.3) {
                var phoneScale = parseInt(window.screen.width) / 640;
                $(document.head).find("meta[name='viewport']").remove();
                $(document.head).append('<meta name="viewport" content="width=640, minimum-scale = ' + phoneScale + ', maximum-scale = ' + phoneScale + ', target-densitydpi=device-dpi">');
            }
        }
    videojs.options.flash.swf = "js/video/video-js.swf";
</script>
</head>
<body>
    <div>
        <div class="title"><h1><%=nModel.title %></h1></div>
        <div class="content">
            <%if(nModel.pic.Length>0)
              { %>
            <%if(nModel.fileurl.Length>0)
              { %>
    <video width="620" height="480" class="video-js vjs-default-skin vjs-big-play-centered" controls preload="auto" poster="<%=nModel.pic %>" data-setup="{}">
        <source src="<%=nModel.fileurl %>" type="video/mp4">
    </video>
            <%}else{%>
            <p style="text-align:center"><img src="<%=nModel.pic %>" style="width:420;" /></p>
              <%}
                } %>
            <%=nModel.content %>
        </div>
    </div>
</body>
</html>
