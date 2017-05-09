<%@ Page Language="C#" AutoEventWireup="true" Inherits="Web.CS.Banner" %>
<%=str %>
<script type="text/javascript">
    $("#TopMenu a").click(function() {
        $("#TopMenu a").removeClass("dq");
        $(this).addClass("dq");
        var activeTab = "/" + $(this).attr("href");
        if ($("#Left_1").css("display") == "none") {
            CloseLeft($(".L_an img").get(0));
        }
        AjaxFun("Left.aspx", activeTab.substring(activeTab.lastIndexOf("/") + 1), " ", ".l_nav");
        $(this).blur();
        return false;
    });
</script>