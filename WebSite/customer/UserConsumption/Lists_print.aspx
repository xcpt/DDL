<%@ Page Language="C#" AutoEventWireup="true" Inherits="customer_UserConsumption_Lists_print" %>
<script type="text/javascript">
    var str = [<%=string.Join(",", al.ToArray())%>];
    function printalert(v) {
        alert(v);
    }
    //thisMoivie 参数：是swf文件 的id   
    function thisMovie(movieName) {
        if (navigator.appName.indexOf("Microsoft") != -1) {
            return window[movieName];
        }
        else {
            return document.getElementById(movieName + "f");
        }
    }
    try{
        thisMovie("printflash").printtext(str);
    } catch (e) { alert(e); }
</script>