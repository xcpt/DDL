<%@ Page Language="C#" AutoEventWireup="true" Inherits="Web.CS.Left" %>
<ul>
    <li class="Thg"></li>
    <li class="one li_0"><a href="main.aspx">管理首页</a></li>
    <%=Web.UI.MenuClass.LeftTreeList() %>
</ul>
<script type="text/javascript">
    var UlList = $("#Left_2 ul");
    UlList.find(".one").click(function () {
        var obj = $(this);
        if (obj.hasClass("Lndq")) {
            obj.removeClass("Lndq");
            obj.find("ul").hide();
        } else {
            UlList.find(".Lndq").find("ul").hide();
            UlList.find(".one").removeClass("Lndq");
            obj.addClass("Lndq");
            obj.find("ul").show();
            var activeTab = $(this).find("a").eq(0).attr("href");
            if (activeTab.indexOf("(") != -1) {
                eval(obj.find("a").eq(0).attr("url"));
            } else {
                activeTab = activeTab.split("?");
                if (activeTab[0].Right(1) != "#") {
                    AjaxFun(activeTab[0], (activeTab.length > 2 ? activeTab[2] : ""), " ", ".Rnr");
                }
            }
            obj.find("a").blur();
        }
        return false;
    });
    UlList.find(".two,.three").click(function () {
        UlList.find(".two,.three").removeClass("dq");
        var obj = $(this);
        obj.addClass("dq");
        var activeTab = obj.find("a").eq(0).attr("href");
        if (activeTab.indexOf("(") != -1) {
            eval(obj.find("a").eq(0).attr("url"));
        } else {
            activeTab = activeTab.split("?");
            if (activeTab[0] != "#") {
                AjaxFun(activeTab[0], (activeTab.length >= 2 ? activeTab[1] : ""), " ", ".Rnr");
            }
        }
        obj.find("a").blur();
        return false;
    });
</script>