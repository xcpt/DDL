if (typeof (SycmsLanguage) == "undefined") {
    document.write("<scr" + "ipt src=\"../../js/Function.js\" type=\"text/javascript\"></scr" + "ipt>");
    document.write("<scr" + "ipt src=\"../../js/Lang/zh.js\" type=\"text/javascript\"></scr" + "ipt>");
    document.write("<scr" + "ipt src=\"../../js/TempFun.js\" type=\"text/javascript\"></scr" + "ipt>");
    document.write("<scr" + "ipt src=\"../../js/Admin.js\" type=\"text/javascript\"></scr" + "ipt>");
    document.write("<scr" + "ipt src=\"../../js/jtip.js\" type=\"text/javascript\"></scr" + "ipt>");
    document.write("<scr" + "ipt src=\"../../js/pico-button.js\" type=\"text/javascript\"></scr" + "ipt>");
    document.write("<scr" + "ipt src=\"../../js/zDialog.js\" type=\"text/javascript\"></scr" + "ipt>");
    document.write("<scr" + "ipt src=\"../../js/zDrag.js\" type=\"text/javascript\"></scr" + "ipt>");
}
var ViewMemberList = new Array();
var isIE = navigator.userAgent.indexOf('MSIE') != -1;
var isFirefox = navigator.userAgent.indexOf('Firefox') != -1;
var ModuleOpenWin = null;
var settimeoutFun = null;
//IE释放内容
function IECollectGarbage() {
    if (isIE) {
        setTimeout(CollectGarbage, 2);
    }
}
function ViewMemberListFun(name) {
    var nameArray = name.split(",");
    for (var j = 0; j < nameArray.length; j++) {
        if (nameArray[j].length > 0) {
            ViewMemberList.push([1, nameArray[j], false]);
        }
    }
}

function ModuleOpenWinCloseButton()
{
    ModuleOpenWin.okButton.style.display = 'none';
    ModuleOpenWin.cancelButton.value = "关闭";
    $("#ModuleOpenWinButton1").btn().disable();
    $("#ModuleOpenWinButton2").btn().disable();
}

function ModuleCreate(Url, listID, Title) {
    ModuleOpenWin = new Dialog();
    ModuleOpenWin.Title = (Title ? "[" + Title + "]" : "") + SycmsLanguage.Module.ModuleCreate.l1;
    ModuleOpenWin.URL = Url;
    ModuleOpenWin.Width = "500";
    ModuleOpenWin.Drag = false;
    ModuleOpenWin.Height = "500";
    ModuleOpenWin.MessageTitle = SycmsLanguage.Module.ModuleCreate.l2;
    ModuleOpenWin.Message = "<span style=\"float:right;padding-right:5px;\"><input type=\"button\" id=\"ModuleOpenWinButton1\" value=\"" + SycmsLanguage.Module.ModuleCreate.l3 + "\" onclick=\"var LoadMess = LoadWarting('', '" + SycmsLanguage.Module.ModuleCreate.l4 + "');setTimeout(function() {var html = '';if (document.all) {html=FormatHTML.GetXHTML(ModuleOpenWin.innerFrame.contentWindow.document.documentElement);} else {html = ModuleOpenWin.innerFrame.contentWindow.document.documentElement.innerHTML;} html = ModuleCreateIframe(html,ModuleOpenWin.innerFrame.src);LoadMess.close();AjaxFun('" + Url + "', 'action=save&winview=no&html=' + encodeURIComponent(html), '" + SycmsLanguage.Module.ModuleCreate.l5 + "', function(html) { AllHtmlWinFun('" + listID + "',function(){ModuleOpenWin.innerFrameLoad.style.display='';ModuleOpenWin.innerFrame.src=ModuleOpenWin.URL+'?time'+Math.random();},'" + (Title ? Title : "") + "'); });},100);\" icon=\"icon-html\"/><input type=\"button\" id=\"ModuleOpenWinButton2\" value=\"" + SycmsLanguage.Module.ModuleCreate.l6 + "\" onclick=\"var LoadMess = LoadWarting('', '" + SycmsLanguage.Module.ModuleCreate.l7 + "');setTimeout(function() {var html = '';if (document.all) {html=FormatHTML.GetXHTML(ModuleOpenWin.innerFrame.contentWindow.document.documentElement);} else {html = ModuleOpenWin.innerFrame.contentWindow.document.documentElement.innerHTML;}html = ModuleCreateIframe(html,ModuleOpenWin.innerFrame.src);LoadMess.close();AjaxFun('" + Url + "', 'action=save&winview=no&html=' + encodeURIComponent(html), '" + SycmsLanguage.Module.ModuleCreate.l8 + "', function(html) { AllCssWinFun('" + listID + "',function(){ModuleOpenWin.innerFrameLoad.style.display='';ModuleOpenWin.innerFrame.src=ModuleOpenWin.URL+'?time'+Math.random();},'" + (Title ? Title : "") + "'); });},100);\" icon=\"icon-css\"/></span>" + SycmsLanguage.Module.ModuleCreate.l9;
    ModuleOpenWin.OKEvent = function () {
        var LoadMess = LoadWarting("", SycmsLanguage.Module.ModuleCreate.l10);
        setTimeout(function () {
            var html = "";
            if (document.all) {
                html = ModuleOpenWin.innerFrame.contentWindow.document.documentElement.innerHTML;
            } else {
                html = ModuleOpenWin.innerFrame.contentWindow.document.documentElement.innerHTML;
            }
            html = ModuleCreateIframe(html, ModuleOpenWin.innerFrame.src);
            LoadMess.close();
            LoadMess = null;
            AjaxFun(Url, "action=save&html=" + encodeURIComponent(html), SycmsLanguage.Module.ModuleCreate.l11, function (html, ModuleOpenWin) {
                ModuleOpenWin.close();
            }, null, ModuleOpenWin);
            html = null;
        }, 100);
    };
    ModuleOpenWin.show();
    IECollectGarbage();
}
///移除相关信息
function IframeRemove(iframe) {
    iframe.find("link[id='TemModuleStyle']").remove();
    iframe.find("link[name='SyCmsDemo']").remove();
    iframe.find("#ScriptViewJs").remove();
    iframe.find("head *[SyCms!='Yes']").remove();
    iframe.find("body *[SyCms!='Yes']").remove();
    iframe.find("html *[SyCms!='Yes']").remove();
    iframe.find("*[SyCms='Yes']").removeAttr("SyCms");
}
//建立Iframe
function ModuleCreateIframe(Html, Url) {
    var IframeObj = document.createElement("iframe");
    IframeObj.width = 0;
    IframeObj.height = 0;
    IframeObj.frameborder = 0;
    IframeObj.style.display = "none";
    IframeObj.src = "about:blank";
    document.body.appendChild(IframeObj);

    var iObj = IframeObj.contentWindow;
    iObj.document.designMode = 'On';
    iObj.document.contentEditable = true;
    iObj.document.open();
    iObj.document.writeln(Html);
    iObj.document.close();
    var iframe = $(IframeObj.contentWindow.document);

    iframe.find(".Containers_Create").remove();
    iframe.find(".Containers_CreateText").remove();
    var TemModuleStyle = iframe.find("#TemModuleStyle");
    if (TemModuleStyle.length > 0) {
        var ParentNode = TemModuleStyle.prev("sycms");
        var ParentNodeArr = [];
        while (ParentNode.length > 0) {
            ParentNodeArr.push(ParentNode);
            ParentNode = ParentNode.prev("sycms");
        }
        var Head = iframe.find("head");
        for (var i = 0; i < ParentNodeArr.length; i++) {
            ParentNodeArr[i].appendTo(Head);
        }
        TemModuleStyle.remove();
    }
    IframeRemove(iframe);
    DeleteScript(IframeObj.contentWindow.document);
    if (document.all) {
        Html = FormatHTML.GetXHTML(IframeObj.contentWindow.document.documentElement);
    } else {
        Html = IframeObj.contentWindow.document.documentElement.innerHTML;
    }
    Html = DelUrl(Html, Url);
    IframeObj.parentNode.removeChild(IframeObj);
    IECollectGarbage();
    iframe = null;
    IframeObj = null;
    iObj = null;
    return FormatHtml(Html);
}


function DelUrl(html, Url) {
    Url = Url.replace("&", "&amp;");
    do {
        html = html.replace(Url, "");
    } while (html.indexOf(Url) != -1)

    var u = Url.split("/");
    if (u.length > 4) {
        var u1 = "http://" + u[2] + "[$Path$]";
        do {
            html = html.replace(u1, "");
        } while (html.indexOf(u1) != -1)
        u1 = null;
    }
    return html;
}


///格式化HTML
function FormatHtml(html) {
    html = FormatHtmlValue(html);
    html = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n" + html + "\r\n</html>";
    IECollectGarbage();
    return html;
}
//删除后台的JS
function DeleteScript(parentWin) {
    var obj = $(parentWin).find("head").find("script");
    var FrontJS = "";
    for (var i = 0; i < obj.length; i++) {
        objsrc = obj.eq(i).attr("src");
        if (objsrc) {
            objsrc = objsrc.toLowerCase();
            if (objsrc.indexOf("frontjs.js")) {
                FrontJS = objsrc.replace("frontjs.js", "");
                break;
            }
        }
    }
    var WebJSPath = "";
    WebJSPath = top.location.href.toLowerCase();
    WebJSPath = "http://" + WebJSPath.replace("http://", "").split("/")[0] + "/js/";
    var objsrc = "";
    for (var i = 0; i < obj.length; i++) {
        objsrc = obj.eq(i).attr("auto");
        if (objsrc && objsrc.toLowerCase() == "true") {
            obj.eq(i).remove();
            continue;
        }
        objsrc = obj.eq(i).attr("src");
        if (objsrc) {
            objsrc = objsrc.toLowerCase();
            if (objsrc.Left(FrontJS.length) == FrontJS || objsrc.Left(WebJSPath.length) == WebJSPath) {
                obj.eq(i).remove();
                continue;
            }
        }
    }
    var obj = $(parentWin).find("head").find("link");
    var objsrc = "";
    for (var i = 0; i < obj.length; i++) {
        objsrc = obj.eq(i).attr("auto");
        if (objsrc && objsrc.toLowerCase() == "true") {
            obj.eq(i).remove();
            continue;
        }
    }
}
//格式化HTML
function FormatHtmlValue(html) {
    var myRegExp = new RegExp(' jQuery(\\d)*?="(\\d)*?"', "img");
    html = html.replace(myRegExp, "");
    myRegExp = new RegExp(' LoadIng="(\\d)*?"', "img");
    html = html.replace(myRegExp, "");
    html = html.replace(new RegExp("<meta name=[\"]?GENERATOR[\"]? content=\"MSHTML.*?\"[ /]?>", "img"), "");
    html = html.replace(new RegExp("<link(.*?)href=\"\"(.*?)>", "img"), "");      //删除所有样式连接   非所有的。后台增加的
    html = html.replace(new RegExp("sizcache=\"(\\d)\" sizset=\"(\\d)\"", "img"), "");
    //html = html.replace(/<script src[^>]*>([\s\S]*?)<\/script>/gi, "");     //删除所有JS
    //html = html.replace(/<script type=[^>]*>([\s\S]*?)<\/script>/gi, "");     //删除所有JS
    html = html.replace(new RegExp("<sycms></sycms>", "gi"), "");
    html = parent.style_html(html, "1", '\t', 80);
    html = html.replace(new RegExp("\n(\t)+/>", "gi"), "/>");
    html = html.replace(/(<\/?)([a-z\d\:]+)((\s+.+?)?>)/gi, function (s, a, b, c) { return a + b.toLowerCase() + c; });
    html = html.replace(new RegExp("<title>([\f\n\r\t\v ]*)(.*?)([\f\n\r\t\v ]*)</title>", "img"), "<title>$2</title>");
    html = html.replace(new RegExp("<sycms([^>]+)>([\f\n\r\t\v ]*)(.*?)([\f\n\r\t\v ]*)</sycms>", "img"), "<sycms$1>$3</sycms>");
    myRegExp = null;
    IECollectGarbage();
    return html;
}

///可视化布局使用
function ContainersCreateFun() {
    var DivList = $("div");
    var DivPage = DivList.filter(".sycmspage");

    if (DivPage && DivPage.length > 0) {

        var LayoutHtml = "<div class=\"Containers_Create\" style=\"display:none;border:1px solid #96D9F9;position:absolute;top:0px;left:0px;font-size:12px;\"><div class=\"Containers_Title\" style=\"position:relative;height:25px;border-bottom:1px solid #96D9F9;background:#D5EFFC;text-align:right;\"><a href=\"\" title=\"添加布局\" class=\"layoutadd\" style=\"float:left;display:none;\"><img src=\"../../images/icon/layout_add.png\" style=\"border:0px;padding:3px;cursor:pointer\" alt=\"添加布局\"></a><a href=\"\" title=\"修改布局\" class=\"layoutedit\" style=\"float:left;display:none;\"><img src=\"../../images/icon/layout_edit.png\" alt=\"修改布局\" style=\"border:0px;padding:3px;cursor:pointer\"></a><a href=\"\" title=\"删除布局\" class=\"layoutdel\" style=\"float:left;display:none;\"><img src=\"../../images/icon/layout_delete.png\" alt=\"删除布局\" style=\"border:0px;padding:3px;cursor:pointer\"></a><span style=\"float:left;\">&nbsp;&nbsp;</span><a href=\"\" title=\"向上移动\" class=\"layoutup\" style=\"float:left;display:none;\"><img src=\"../../images/icon/arrow_up.png\" alt=\"向上移动\" style=\"border:0px;padding:3px;cursor:pointer\"></a><a href=\"\" title=\"向下移动\" class=\"layoutdown\" style=\"float:left;display:none;\"><img src=\"../../images/icon/arrow_down.png\" alt=\"向下移动\" style=\"border:0px;padding:3px;cursor:pointer\"></a></div><div id=\"Containers_Create_Bg\" style=\"width:100%;height:100%;filter:alpha(opacity=50);-moz-opacity:0.50;opacity: 0.50;background:#E8F6FD\"></div></div>";
        var CreateLayout = new Array();
        CreateLayout[0] = '<div class="Containers_Group" sycms="Yes"><table width="100%" cellspacing="0" cellpadding="0" class="layout_block_table" sycms="Yes"><tbody sycms="Yes"><tr sycms="Yes">';
        CreateLayout[1] = '<td width="100%" valign="top" align="left" class="layout_block_col" sycms="Yes"><div class="Container" sycms="Yes"></div></td>';
        CreateLayout[2] = '</tr></tbody></table></div>';

        var parentWin = window.parent;
        var $body = $("body");
        var CreateLayoutRemove = function () {
            $body.find(".Containers_Create").remove();
        }
        var CreateTable = function (layout, Tobj, Type) {
            if (layout && layout.length > 0) {
                var layoutArray = layout.split(',');
                var LayoutDiv = new Array();
                LayoutDiv.push(CreateLayout[0]);
                for (var i = 0; i < layoutArray.length; i++) {
                    LayoutDiv.push(CreateLayout[1].replace("100%", layoutArray[i] + "%"));
                }
                LayoutDiv.push(CreateLayout[2]);
                if (Type == "1") {
                    CreateLayoutRemove();
                    Tobj.append(LayoutDiv.join(""));
                    ContainersCreateFun();
                } else {
                    Tobj.after(LayoutDiv.join(""));
                }
            } else {
                EditTableLayout(null, null, null, Tobj, Type);
            }
        }
        var EditTableLayoutWidth = function (Width, LayoutEditView) {
            var WidthHtml = new Array();
            for (var i = 0; i < Width.length; i++) {
                WidthHtml.push("<input type=\"text\" size=\"4\" value=\"" + Width[i].replace("%", "") + "\" name=\"LayoutWidth\">%&nbsp;");
            }
            LayoutEditView.find(".LayoutWidthView").html(WidthHtml.join(""));
        }
        //弹出自定义修改布局信息
        var EditTableLayout = function (Width, Mtop, Mbotom, ObjT, Type) {
            var diagEdit = new parentWin.Dialog();
            diagEdit.Width = htmlLayoutModiyFunHtml[1];
            diagEdit.Height = htmlLayoutModiyFunHtml[2];
            diagEdit.Title = htmlLayoutModiyFunHtml[0];
            diagEdit.InnerHtml = htmlLayoutModiyFunHtml[4];
            diagEdit.OKEvent = function () {
                var LayoutEditView = $(parentWin.document).find("#LayoutEditView");
                var LayoutWidthList = LayoutEditView.find("input[name='LayoutWidth']");
                var EditWidth = new Array();
                var WidthCount = 0;
                LayoutWidthList.each(function () {
                    EditWidth.push(parentWin.NumFun(this.value));
                    WidthCount += EditWidth[EditWidth.length - 1];
                })
                if (WidthCount <= 100) {
                    var margintop = parentWin.NumFun(LayoutEditView.find("#margintop").val());
                    var marginbottom = parentWin.NumFun(LayoutEditView.find("#marginbottom").val());
                    if (Type || Type == "0") {
                        CreateTable(EditWidth.join(","), ObjT, Type);
                        if (Type == "1") {
                            ObjT.find("div.Containers_Group").css({ "margin-top": margintop + "px", "margin-bottom": marginbottom + "px" });
                        } else {
                            ObjT.next().css({ "margin-top": margintop + "px", "margin-bottom": marginbottom + "px" });
                        }
                    } else {
                        ObjTtdList = ObjT.find("table.layout_block_table>tbody>tr>td");
                        if (ObjTtdList.length >= EditWidth.length) {
                            for (var i = 0; i < EditWidth.length; i++) {
                                ObjTtdList.eq(i).attr("width", EditWidth[i] + "%");
                            }
                            for (var i = EditWidth.length; i < ObjTtdList.length; i++) {
                                ObjTtdList.eq(i).remove();
                            }
                        } else {
                            var LayoutDiv = new Array();
                            for (var i = 0; i < EditWidth.length; i++) {
                                if (i < ObjTtdList.length) {
                                    ObjTtdList.eq(i).attr("width", EditWidth[i] + "%");
                                } else {
                                    LayoutDiv.push(CreateLayout[1].replace("100%", EditWidth[i] + "%"));
                                }
                            }
                            ObjTtdList.eq(ObjTtdList.length - 1).after(LayoutDiv.join(""));
                        }
                        ObjT.css({ "margin-top": margintop + "px", "margin-bottom": marginbottom + "px" });
                    }
                    diagEdit.close();
                }
            }
            diagEdit.show();
            var LayoutEditView = $(parentWin.document).find("#LayoutEditView");
            var LayoutNumList = LayoutEditView.find("input[name='LayoutNum']");
            if (Width) {
                LayoutNumList.eq(Width.length - 1).attr("checked", "checked");
                EditTableLayoutWidth(Width, LayoutEditView);
            }
            if (Mtop) {
                LayoutEditView.find("#margintop").val(Mtop);
            }
            if (Mbotom) {
                LayoutEditView.find("#marginbottom").val(Mbotom);
            }
            LayoutNumList.unbind().bind("click", function () {
                switch (this.value) {
                    case "1":
                        EditTableLayoutWidth(["100"], LayoutEditView);
                        break;
                    case "2":
                        EditTableLayoutWidth(["50", "50"], LayoutEditView);
                        break;
                    case "3":
                        EditTableLayoutWidth(["33", "33", "33"], LayoutEditView);
                        break;
                    case "4":
                        EditTableLayoutWidth(["25", "25", "25", "25"], LayoutEditView);
                        break;
                }
            });
        }
        var HtmlLayoutFunWin = function (Tobj, Type) {
            var diag = new parentWin.Dialog();
            diag.Width = htmlLayoutFunHtml[1];
            diag.Height = htmlLayoutFunHtml[2];
            diag.Title = htmlLayoutFunHtml[0];
            diag.InnerHtml = htmlLayoutFunHtml[4];
            diag.show();
            $(parentWin.document).find("#LayoutSelectView a").unbind().bind("click", function () {
                var Layout = $(this).attr("layout");
                CreateTable(Layout, Tobj, Type);
                return false;
            });
        }

        var WzHeight = function (DivPage) {
            var s = getElCoordinate(DivPage.get(0));
            Tobj = DivPage.find(".Containers_Create");
            Tobj.css({ "top": s.top, "left": s.left, "width": s.width - 2, "height": s.height - 2 });
            Tobj.find("#Containers_Create_Bg").css("height", s.height - 2 - 25);
            return Tobj;
        }
        ///显示
        var LayoutView = function (objectDiv, Tobj) {
            var s = getElCoordinate(objectDiv);
            Tobj.css({ "top": s.top, "left": s.left, "width": s.width - 2, "height": s.height - 2 });
            Tobj.find("#Containers_Create_Bg").css("height", s.height - 2 - 25);
            Tobj.show();
        }
        //无子节点的时候
        if (DivPage.children().length == 0) {
            DivPage.append(LayoutHtml);
            var Tobj = WzHeight(DivPage);
            Tobj.find(".layoutadd").show().unbind().bind("click", function () {
                HtmlLayoutFunWin($(this).parent().parent().parent(), 1);
                return false;
            });
            Tobj.show();
        } else {
            $body.append(LayoutHtml);
            var Containers_Create = $body.find(".Containers_Create");
            Containers_Create.unbind().bind("mouseout", function () {
                $(this).hide();
            });
            ///添加
            Containers_Create.find(".layoutadd").show().bind("click", function () {
                if (Containers_Create.get(0).objID) {
                    HtmlLayoutFunWin($(Containers_Create.get(0).objID), 0);
                }
                return false;
            });
            //修改布局
            Containers_Create.find(".layoutedit").show().bind("click", function () {
                if (Containers_Create.get(0).objID) {
                    var ObjT = $(Containers_Create.get(0).objID);
                    var Width = new Array();
                    ObjT.find("table.layout_block_table>tbody>tr>td").each(function () {
                        Width.push($(this).attr("width"));
                    });
                    var Mtop = parentWin.NumFun(ObjT.css("margin-top"));
                    var Mbotom = parentWin.NumFun(ObjT.css("margin-bottom"));
                    EditTableLayout(Width, Mtop, Mbotom, ObjT);
                }
                return false;
            });
            //删除
            Containers_Create.find(".layoutdel").show().bind("click", function () {
                if (Containers_Create.get(0).objID) {
                    var ObjT = $(Containers_Create.get(0).objID);
                    var ObjN = ObjT.next(".Containers_Group");
                    ObjT.remove();
                    if (ObjN && ObjN.eq(0).get(0) != undefined && ObjN.length > 0) {
                        Containers_Create.get(0).objID = ObjN.eq(0).get(0);
                        LayoutView(ObjN.eq(0).get(0), Containers_Create);
                    } else {
                        Containers_Create.hide();
                        Containers_Create.find(".layoutdown").hide();
                        if (DivPage.find(".Containers_Group").length == 0) {
                            Containers_Create.remove();
                            CreateLayoutRemove();
                            ContainersCreateFun();
                        }
                    }
                }
                return false;
            });
            //向上
            Containers_Create.find(".layoutup").bind("click", function () {
                if (Containers_Create.get(0).objID) {
                    var ObjT = $(Containers_Create.get(0).objID);
                    var ObjP = ObjT.prev(".Containers_Group");
                    if (ObjP.length > 0) {
                        ObjT.after(ObjP.eq(ObjP.length - 1));
                        Containers_Create.get(0).objID = ObjP.eq(ObjP.length - 1).get(0);
                        LayoutView(ObjP.eq(ObjP.length - 1).get(0), Containers_Create);
                    }
                }
                return false;
            });
            ///向下
            Containers_Create.find(".layoutdown").bind("click", function () {
                if (Containers_Create.get(0).objID) {
                    var ObjT = $(Containers_Create.get(0).objID);
                    var ObjN = ObjT.next(".Containers_Group");
                    if (ObjN.length > 0) {
                        ObjT.before(ObjN.eq(0));
                        Containers_Create.get(0).objID = ObjN.eq(0).get(0);
                        LayoutView(ObjN.eq(0).get(0), Containers_Create);
                    }
                }
                return false;
            });
            DivPage.delegate(".Containers_Group", "mouseover", function () {
                LayoutView(this, Containers_Create);
                Containers_Create.get(0).objID = this;
                var ObjT = $(this);
                var ObjP = ObjT.prev(".Containers_Group");
                if (ObjP.length > 0) {
                    Containers_Create.find(".layoutup").show();
                } else {
                    Containers_Create.find(".layoutup").hide()
                }
                var ObjN = ObjT.next(".Containers_Group");
                if (ObjN.length > 0) {
                    Containers_Create.find(".layoutdown").show();
                } else {
                    Containers_Create.find(".layoutdown").hide()
                }
            });
        }
    }
    DivList = null;
    IECollectGarbage();
}



//格式化模块
function ModuleOpen(Url, listID, Title) {
    ModuleOpenWin = new Dialog();
    ModuleOpenWin.Title = (Title ? "[" + Title + "]" : "") + SycmsLanguage.Module.ModuleOpen.l1 + "<input type=\"hidden\" value=\"" + listID + "\" name=\"YQ_listID\" id=\"YQ_listID\" />";
    ModuleOpenWin.URL = Url;
    ModuleOpenWin.Width = "500";
    ModuleOpenWin.Drag = false;
    ModuleOpenWin.Height = "500";
    ModuleOpenWin.MessageTitle = SycmsLanguage.Module.ModuleOpen.l2;
    ModuleOpenWin.Message = "<span style=\"float:right;padding-right:5px;\"><input type=\"button\" id=\"ModuleOpenWinButton1\" value=\"" + SycmsLanguage.Module.ModuleOpen.l3 + "\" onclick=\"var LoadMess = LoadWarting('', '" + SycmsLanguage.Module.ModuleOpen.l4 + "<div style=height:12px id=spaceused1>0%</div>');setTimeout(function() {var html = ModuleOpenIframe(ModuleOpenWin);LoadMess.close();AjaxFun('" + Url + "', 'action=save&winview=no&htmlcontent=' + encodeURIComponent(html), '" + SycmsLanguage.Module.ModuleOpen.l5 + "', function(html) {AllHtmlWinFun('" + listID + "',function(){ModuleOpenWin.innerFrameLoad.style.display='';ModuleOpenWin.innerFrame.src=ModuleOpenWin.URL+'?time'+Math.random();},'" + (Title ? Title : "") + "');});},100);\" icon=\"icon-html\"/><input type=\"button\" id=\"ModuleOpenWinButton2\" value=\"" + SycmsLanguage.Module.ModuleOpen.l6 + "\" onclick=\"var LoadMess = LoadWarting('', '" + SycmsLanguage.Module.ModuleOpen.l7 + "<div style=height:12px; id=spaceused1>0%</div>');var html = ModuleOpenIframe(ModuleOpenWin);LoadMess.close();AjaxFun('" + Url + "', 'action=save&winview=no&htmlcontent=' + encodeURIComponent(html), '" + SycmsLanguage.Module.ModuleOpen.l8 + "', function(html) {AllCssWinFun('" + listID + "',function(){ModuleOpenWin.innerFrameLoad.style.display='';ModuleOpenWin.innerFrame.src=ModuleOpenWin.URL+'?time'+Math.random();},'" + (Title ? Title : "") + "');});\" icon=\"icon-css\"></span>" + SycmsLanguage.Module.ModuleOpen.l9;
    ModuleOpenWin.OKEvent = function () {
        var LoadMess = LoadWarting("", SycmsLanguage.Module.ModuleOpen.l10 + "<div style=\"height:12px;\" id=\"spaceused1\">0%</div>");
        setTimeout(function () {
            var html = ModuleOpenIframe(ModuleOpenWin);
            LoadMess.close();
            LoadMess = null;
            AjaxFun(Url, "action=save&htmlcontent=" + encodeURIComponent(html), SycmsLanguage.Module.ModuleOpen.l11, function (html, ModuleOpenWin) {
                ModuleOpenWin.close();
            }, null, ModuleOpenWin);
        }, 100);
    };
    ModuleOpenWin.CancelEvent = function () {
        ModuleOpenWin.close();
        AjaxFun('Tem/List/Modi_Cancel.aspx', "id=" + listID, null, null, null, null, null, null, null, null, true);
    }
    ModuleOpenWin.show();
    IECollectGarbage();
}


//建立Iframe
function ModuleOpenIframe(ModuleOpenWin) {
    var ModuleOpenWinFrame = ModuleOpenWin.innerFrame;
    var Url = ModuleOpenWinFrame.src;
    $("#_DialogDiv_" + ModuleOpenWin.ID).hide();
    var iframe = $(ModuleOpenWinFrame.contentWindow.document);
    var MoArrayList = new Array();
    iframe.find(".Container_Win").remove();
    iframe.find("#TemModuleStyle").remove();
    IframeRemove(iframe);
    var Molist = iframe.find("*[For]");
    var MoStr = "";
    for (var j = 0; j < Molist.length; j++) {
        $("#spaceused1").progressBar(((50 * (j + 1)) / Molist.length));
        MoStr = decodeURIComponent(decodeURIComponent(Molist.eq(j).attr("For")));
        if (MoStr && MoStr != "undefined") {
            if (document.all) {
                MoArrayList.push(MoStr);
                Molist.eq(j).before("<meta name=\"" + MoArrayList.length + "\" />");
            } else {
                Molist.eq(j).before(MoStr);
            }
            Molist.eq(j).remove();
        } else {
            //Molist.eq(j).remove();
        }
    }


    var Molist = iframe.find("div[ChildFor]");

    var MoStr = "";
    for (var j = 0; j < Molist.length; j++) {
        $("#spaceused1").progressBar(((80 * (j + 1)) / Molist.length));
        MoStr = decodeURIComponent(decodeURIComponent(Molist.eq(j).attr("ChildFor")));
        if (MoStr && MoStr != "undefined") {
            if (document.all) {
                MoArrayList.push(MoStr);
                Molist.eq(j).parent().before("<meta name=\"" + MoArrayList.length + "\" />");
            } else {
                Molist.eq(j).parent().before(MoStr);
            }
            Molist.eq(j).parent().remove();
        } else {
            //Molist.eq(j).remove();
        }
    }
    //修复title找不到的问题
    var TitleObj = iframe.find("title");
    if (TitleObj && TitleObj.length > 0) {
        var mArr = String(TitleObj.eq(0).html()).match(new RegExp("ChildFor=\".*?\"", "g"));
        if (mArr) {
            var MoStr = mArr[0];
            if (MoStr && MoStr.length > 0) {
                MoStr = MoStr.substr(10);
                MoStr = MoStr.substr(0, MoStr.length - 1);
                MoStr = decodeURIComponent(decodeURIComponent(MoStr));
                if (document.all) {
                    MoArrayList.push(MoStr);
                    TitleObj.eq(0).before("<meta name=\"" + MoArrayList.length + "\" />");
                } else {
                    TitleObj.eq(0).before(MoStr);
                }
                TitleObj.remove();
            }
        }
    }
    $("#spaceused1").progressBar(100);
    iframe.find("*[LinkedDel=Del]").remove();
    DeleteScript(ModuleOpenWinFrame.contentWindow.document);
    if (document.all) {
        Html = FormatHTML.GetXHTML(ModuleOpenWinFrame.contentWindow.document.documentElement);
    } else {
        Html = ModuleOpenWinFrame.contentWindow.document.documentElement.innerHTML;
    }
    Html = DelUrl(Html, Url);
    MoStr = null;
    Molist = null;
    iObj = null;
    Html = FormatHtml(Html);
    if (document.all) {
        for (var j = 0; j < MoArrayList.length; j++) {
            Html = Html.replace("<meta name=\"" + (j + 1) + "\" />", MoArrayList[j]);
        }
        MoArrayList = null;
    }
    IECollectGarbage();
    return Html;
}

//格式化模块
function ContainersReadFun(ListId) {

    var Winobj = $("#Container_Win");
    if (Winobj.length == 0) {
        $("body").append("<div id=\"Container_Win\" class=\"Container_Win\" style=\"z-index:1000000;display:none;border:1px solid #6DBAE1;position:absolute;top:0px;left:0px;font-size:12px;\"><div style=\"position:relative;height:25px;border-bottom:1px solid #6DBAE1;background:#6DBAE1;text-align:right;\"><div style=\"float:right;\"><a href=\"#nogo\" title=\"" + SycmsLanguage.Module.ContainersReadFun.l1 + "\" id=\"new\" style=\"float:left;\"><img src=\"../../images/icon/application_osx.png\" style=\"border:0px;padding:3px;cursor:pointer\" alt=\"" + SycmsLanguage.Module.ContainersReadFun.l1 + "\"></a><a href=\"#nogo\" title=\"" + SycmsLanguage.Module.ContainersReadFun.l11 + "\" id=\"newNav\" style=\"float:left;\"><img src=\"../../images/icon/application_osx_home.png\" style=\"border:0px;padding:3px;cursor:pointer\" alt=\"" + SycmsLanguage.Module.ContainersReadFun.l11 + "\"></a><a href=\"#nogo\" title=\"" + SycmsLanguage.Module.ContainersReadFun.l12 + "\" id=\"newSys\" style=\"float:left;\"><img src=\"../../images/icon/application_osx_cascade.png\" style=\"border:0px;padding:3px;cursor:pointer\" alt=\"" + SycmsLanguage.Module.ContainersReadFun.l12 + "\"></a><a href=\"#nogo\" title=\"" + SycmsLanguage.Module.ContainersReadFun.l2 + "\" id=\"add\" style=\"float:left;\"><img src=\"../../images/icon/application_osx_add.png\" style=\"border:0px;padding:3px;cursor:pointer\" alt=\"" + SycmsLanguage.Module.ContainersReadFun.l2 + "\"></a><a href=\"#nogo\" id=\"del\" title=\"" + SycmsLanguage.Module.ContainersReadFun.l3 + "\" style=\"float:left;\"><img src=\"../../images/icon/application_osx_delete.png\" alt=\"" + SycmsLanguage.Module.ContainersReadFun.l3 + "\" style=\"border:0px;padding:3px;cursor:pointer\"></a><a href=\"#nogo\" title=\"" + SycmsLanguage.Module.ContainersReadFun.l4 + "\" id=\"format\" style=\"float:left;display:none;\"><img src=\"../../images/icon/application_osx_start.png\" alt=\"" + SycmsLanguage.Module.ContainersReadFun.l4 + "\" style=\"border:0px;padding:3px;cursor:pointer\"></a><a href=\"#nogo\" title=\"" + SycmsLanguage.Module.ContainersReadFun.l5 + "\" id=\"modi\" style=\"float:left;\"><img src=\"../../images/icon/application_osx_modi.png\" alt=\"" + SycmsLanguage.Module.ContainersReadFun.l5 + "\" style=\"border:0px;padding:3px;cursor:pointer\"></a><a href=\"#nogo\" title=\"" + SycmsLanguage.Module.ContainersReadFun.l6 + "\" id=\"prev\" style=\"float:left;\"><img src=\"../../images/icon/application_osx_prev.png\" alt=\"" + SycmsLanguage.Module.ContainersReadFun.l6 + "\" style=\"border:0px;padding:3px;cursor:pointer\"></a><a href=\"#nogo\" id=\"next\" title=\"" + SycmsLanguage.Module.ContainersReadFun.l7 + "\" style=\"float:left;\"><img src=\"../../images/icon/application_osx_next.png\" alt=\"" + SycmsLanguage.Module.ContainersReadFun.l7 + "\" style=\"border:0px;padding:3px;cursor:pointer\"></a></div><div id=\"Container_WinName\" style=\"padding:5px;text-align:left;color:#ffffff;font-weight:Bold;height:15px;overflow:hidden\"></div></div><div id=\"Container_Win_Bg\" style=\"filter:alpha(opacity=50);-moz-opacity:0.50;opacity: 0.50;width:100%;height:100%;background:#59B0E1\"></div></div>")
        Winobj = $("#Container_Win");
    }
    var Winobj_name = Winobj.find("#Container_WinName");
    var Winobj_new = Winobj.find("#new");
    var Winobj_newNav = Winobj.find("#newNav");
    var Winobj_newSys = Winobj.find("#newSys");
    var Winobj_add = Winobj.find("#add");
    var Winobj_del = Winobj.find("#del");
    var Winobj_modi = Winobj.find("#modi");
    var Winobj_format = Winobj.find("#format");
    var Winobj_prev = Winobj.find("#prev");
    var Winobj_next = Winobj.find("#next");
    Winobj.bind("mouseout", function () {
        var tobj = $(this);
        settimeoutFun = setTimeout(function () { tobj.hide(); tobj = null; }, 600);        //时间延时消失
    });
    Winobj.bind("mouseover", function () {
        clearInterval(settimeoutFun);
    });

    //格式化容器
    var Tem = $("*[ChildFor]");
    Tem.each(function () {
        var p = $(this).parent().parent();
        if (p && !p.hasClass("Container")) {
            p.addClass("Container");
        }
    });
    var Tem = $("*[For]");
    Tem.each(function () {
        var p = $(this).parent();
        if (p && !p.hasClass("Container")) {
            p.addClass("Container");
        }
    });

    var ContainerObj = $(".Container");
    ContainerObj.attr("LoadIng", "-1");
    ContainerObj.unbind().each(function () {
        var Tobj = $(this);
        WinCreateChild(Tobj, ListId);
        Tobj = null;
    }).bind("mouseover", function () {
        clearInterval(settimeoutFun);
        var Tobj = $(this);
        if (Tobj.attr("LoadIng") == "-1" || Tobj.attr("LoadIng") == "0") {
            var N = this.className.replace("Container ", "").replace(" Container", "").replace("Container", "");
            var I = this.id;
            var str = SycmsLanguage.Module.ContainersReadFun.l8;
            if (N.length > 0) {
                str += "&nbsp;&nbsp;" + SycmsLanguage.Module.ContainersReadFun.l9 + "：" + N;
            }
            if (I.length > 0) {
                str += "&nbsp;&nbsp;" + SycmsLanguage.Module.ContainersReadFun.l10 + "：" + I;
            }
            Winobj_name.html(str).attr("title", str);
            WinCreateChild(Tobj, ListId);
        }
    });
    IECollectGarbage();
}

///插入
function InsertHtml(Pobj, str, Type) {
    var Tobj = null;
    str = RunJavaScript(str);
    var obj = $(str);
    for (var i = 1; i < obj.length; i++) {
        obj.eq(i).attr("LinkedDel", "Del");
    }
    if (Type == "before") {
        //把自己的下级节点是自己模块里面的都相应删除
        var TobjNext = Pobj.nextAll();
        if (TobjNext) {
            for (var i = 0; i < TobjNext.length; i++) {
                if (TobjNext.eq(i).attr("LinkedDel") == "Del") {
                    TobjNext.eq(i).remove();
                } else {
                    break;
                }
            }
        }
        Tobj = Pobj.html("").before(obj);
        Pobj.remove();
    } else if (Type == "after") {
        Tobj = Pobj.after(obj);
    } else if (Type = "append") {
        Tobj = Pobj.append(obj);
    }
    return Tobj;
}

function ReloadModuleCss(css, ListId) {
//不使用这种。因为删除一个样式的时候，容易删除不掉。
//    var style = new parent.styleSheet("/Modi_Module_Css.aspx", parent.ModuleOpenWin.innerFrame.contentWindow);
//    style.addRuleArray(css);

//    return;
    var src = "Modi_Module_Css.aspx";
    var obj = $(document).find("link");
    var objBO = false;
    var objJs = null;
    var Tem = $("*[For]");
    var TemID = new Array();
    var xml = new window.parent.XML();
    for (var i = 0; i < Tem.length; i++) {
        var TemFor = decodeURIComponent(decodeURIComponent(Tem.eq(i).attr("For")));
        if(TemFor.length>0 && TemFor.indexOf("<sycms ")!=-1 && TemFor.indexOf("type=\"Template\"")!=-1)
        {
            xml.SetXML("<?xml version='1.0' encoding='utf-8'?><xml>" + TemFor + "</xml>");
            TemID.push(xml.getAttrib("xml/sycms", "id"));
        }
    }
    xml = null;
    var Ssrc = src.toLowerCase();
    for (var i = 0; i < obj.length; i++) {
        var objsrc = obj.eq(i).attr("href");
        if (objsrc) {
            if (objsrc.toLowerCase().indexOf(Ssrc) != -1) {
                objJs = obj.eq(i);
                objJs.after("<link type=\"text/css\" name=\"SyCmsDemo\" rel=\"stylesheet\" href=\"" + src + "?id=" + ListId + "&temid="+TemID.join(",")+"&time=" + Math.random() + "\"/>");
                setTimeout(function () { objJs.remove(); }, 3000);
                break;
            }
        }
    }
}


//添加新
function ReadFun_New(Tobj, ListId, AddType, TwoType) {
    Tobj.MemberList = ViewMemberList;
    parent.LabelFun("", function (objid, returnValue, diag) {
        var parentWin = $(window.parent.document);
        var title = parentWin.find("#" + objid + "T0").val();
        var content = parentWin.find("#" + objid + "T1").val();
        var css = parentWin.find("#" + objid + "T3").val();
        if (title.length > 0) {
            if (content.Trim().length > 0) {
                if (!ShowCallBack_LabelSave(parentWin.find("#" + objid + "T1").get(0))) {
                    parent.AjaxFun("Tem/Tem/Add.aspx", "action=winsave&ListId=" + ListId + "&id=" + ListId + "&title=" + encodeURIComponent(title) + "&content=" + encodeURIComponent(content) + "&css=" + encodeURIComponent(css) + "&label=" + encodeURIComponent(returnValue), SycmsLanguage.Module.ReadFun_New.l1, function (html, objdiag) {
                        var htmljson = parent.String2Json(html);
                        var css = parent.ReadClass("Style", htmljson);
                        var str = parent.ReadClass("Html", htmljson);
                        if (Tobj.hasClass("Container")) {
                            Tobj.append(str).attr("LoadIng", "-1");
                            WinCreateChild(Tobj, ListId);
                        } else {
                            var Tparent = Tobj.parent();
                            if (AddType && AddType == "1") {
                                InsertHtml(Tobj, str, "before");
                            } else {
                                InsertHtml(Tobj, str, "after");
                            }
                            Tparent.attr("LoadIng", "-1");
                            WinCreateChild(Tparent, ListId);
                            Tparent = null;
                        }
                        if (css.Trim().length > 0) {
                            ReloadModuleCss(css,ListId);
                        }
                        objdiag.close();
                        objdiag = null;
                        htmljson = null;
                        css = null;
                        str = null;
                    }, null, diag);
                }
            } else {
                parent.Dialog.error(SycmsLanguage.Module.ReadFun_New.l2, function () {
                    parentWin.find("#" + objid + "T1").focus();
                });
            }
        } else {
            parent.Dialog.error(SycmsLanguage.Module.ReadFun_New.l3, function () {
                parentWin.find("#" + objid + "T0").focus();
            });
        }
    }, "Template", function (objid) {
        var parentWin = $(window.parent.document);
        parentWin.find("#" + objid + "T3").attr("ListID", ListId);
        parent.TextClickCss(parentWin.find("#" + objid + "T3").get(0));
        if (AddType && AddType == "1") {
            $("#ViewQueryDiv").html("").append(Tobj.clone(true));
            var html = $("#ViewQueryDiv").html();
            $("#ViewQueryDiv").html("");
            parentWin.find("#" + objid + "T1").val(FormatHtmlValue(html));
            html = null;
        }
    }, null, Tobj, TwoType);
    IECollectGarbage();
    return false;
}
//添加现有
function ReadFun_Add(Tobj, ListId) {
    var parentWin = $(window.parent.document);
    parent.CreateWindow("Tem/Tem/Lists_View.aspx?id=" + ListId, SycmsLanguage.Module.ReadFun_Add.l1, function (diagwin) {
        parent.AjaxFun("Tem/Tem/Lists_Tem.aspx", "action=install&ListId=" + ListId + "&id=" + parentWin.find("#ListViewTem #MoId").val(), SycmsLanguage.Module.ReadFun_Add.l2, function (html, diagwin) {
            var htmljson = parent.String2Json(html);
            var css = parent.ReadClass("Style", htmljson);
            var str = parent.ReadClass("Html", htmljson);
            if (Tobj.hasClass("Container")) {
                InsertHtml(Tobj, str, "append").attr("LoadIng", "-1");
                WinCreateChild(Tobj, ListId);
            } else {
                InsertHtml(Tobj, str, "after").parent().attr("LoadIng", "-1");
                WinCreateChild($(Tobj).parent(), ListId);
            }
            if (css.Trim().length > 0) {
                ReloadModuleCss(css,ListId);
            }
            diagwin.close();
            diagwin = null;
            str = null;
            css = null;
            htmljson = null;
        }, null, diagwin);
    }, 700, 500, "ListViewTem");
    IECollectGarbage();
}
//修改
function ReadFun_Modi(Tobj, ListId) {
    var For = decodeURIComponent(decodeURIComponent(Tobj.attr("For")));
    if (!(For != "undefined" && For != null && For.length > 0)) {
        For = decodeURIComponent(decodeURIComponent(Tobj.find("div[ChildFor]").attr("ChildFor")));
    }
    Tobj.MemberList = ViewMemberList;
    parent.LabelFun(For, function (objid, returnValue, diag) {
        var parentWin = $(window.parent.document);
        var title = parentWin.find("#" + objid + "T0").val();
        var content = parentWin.find("#" + objid + "T1").val();
        var css = parentWin.find("#" + objid + "T3").val();
        var TemId = parentWin.find("#TemId").val();
        if (title.length > 0) {
            if (content.Trim().length > 0) {
                if (!ShowCallBack_LabelSave(parentWin.find("#" + objid + "T1").get(0))) {
                    parent.AjaxFun("Tem/Tem/Modi.aspx", "action=winsave&ListId=" + ListId + "&id=" + TemId + "&title=" + encodeURIComponent(title) + "&content=" + encodeURIComponent(content) + "&css=" + encodeURIComponent(css) + "&label=" + encodeURIComponent(returnValue), SycmsLanguage.Module.ReadFun_New.l1, function (html, objdiag) {
                        var htmljson = parent.String2Json(html);
                        var css = parent.ReadClass("Style", htmljson);
                        var str = parent.ReadClass("Html", htmljson);
                        var $Tobj = $(Tobj);
                        var ParentObj = $Tobj.parent();
                        $Tobj.removeAttr("For");
                        var DivList = $("*[For]");
                        var ArrayDiv = new Array();
                        if (DivList.length > 1) {
                            var ForValue = "";
                            var ModiForValue = $Tobj.attr("For");
                            var xml = new parent.XML();
                            xml.SetXML("<?xml version='1.0' encoding='utf-8'?><xml>" + returnValue + "</xml>");
                            var ID = xml.getAttrib("xml/sycms", "id");
                            if (ID.length > 0) {
                                for (var i = 0; i < DivList.length; i++) {
                                    ForValue = decodeURIComponent(decodeURIComponent(DivList.eq(i).attr("For")));
                                    xml.SetXML("<?xml version='1.0' encoding='utf-8'?><xml>" + ForValue + "</xml>");
                                    if (xml.getAttrib("xml/sycms", "id") == ID) {
                                        ArrayDiv.push([DivList.eq(i), ForValue, ID]);
                                    }
                                }
                            }
                            xml = null;
                        }
                        InsertHtml($Tobj, str, "before");
                        ParentObj.attr("LoadIng", "-1");
                        WinCreateChild(ParentObj, ListId);
                        if (ArrayDiv.length > 0) {
                            var AjaxFunWindow = LoadWarting("", "正在更新关联区块，请稍候......");
                            var AjaxI = 0;
                            var LoadDivHtml = function () {
                                parent.AjaxFun("Tem/Tem/Lists_Tem.aspx", "action=install&ListId=" + ListId + "&id=" + ArrayDiv[AjaxI][2] + "&Label=" + encodeURIComponent(ArrayDiv[AjaxI][1]), '', function (html) {
                                    var htmljson = parent.String2Json(html);
                                    var str = parent.ReadClass("Html", htmljson);
                                    ParentObj=ArrayDiv[AjaxI][0].parent();
                                    InsertHtml(ArrayDiv[AjaxI][0], str, "before");
                                    str = null;
                                    ParentObj.attr("LoadIng", "-1");
                                    WinCreateChild(ParentObj, ListId);
                                    htmljson = null;
                                    AjaxI++;
                                    if (AjaxI < ArrayDiv.length) {
                                        LoadDivHtml();
                                    } else {
                                        AjaxFunWindow.close();
                                        ArrayDiv = null;
                                        AjaxI = null;
                                    }
                                });
                            }
                            LoadDivHtml();
                        }
                        if (css.Trim().length > 0) {
                            ReloadModuleCss(css,ListId);
                        }
                        objdiag.close();
                        objdiag = null;
                        htmljson = null;
                        css = null;
                        str = null;
                        ParentObj = null;
                    }, null, diag);
                }
            } else {
                parent.Dialog.error(SycmsLanguage.Module.ReadFun_New.l2, function () {
                    parentWin.find("#" + objid + "T1").focus();
                });
            }
        } else {
            parent.Dialog.error(SycmsLanguage.Module.ReadFun_New.l3, function () {
                parentWin.find("#" + objid + "T0").focus();
            });
        }
    }, "Template", function (objid) {
        var parentWin = $(window.parent.document);
        parentWin.find("#" + objid + "T3").attr("ListID", ListId);
        parent.TextClickCss(parentWin.find("#" + objid + "T3").get(0));
        parentWin = null;
    }, function (objid, returnValue, diag) {
        var parentWin = $(window.parent.document);
        var title = parentWin.find("#" + objid + "T0").val();
        var content = parentWin.find("#" + objid + "T1").val();
        var css = parentWin.find("#" + objid + "T3").val();
        if (title.length > 0) {
            if (content.Trim().length > 0) {
                if (!ShowCallBack_LabelSave(parentWin.find("#" + objid + "T1").get(0))) {
                    parent.AjaxFun("Tem/Tem/Add.aspx", "action=winsave&ListId=" + ListId + "&id=" + ListId + "&title=" + encodeURIComponent(title) + "&content=" + encodeURIComponent(content) + "&css=" + encodeURIComponent(css) + "&label=" + encodeURIComponent(returnValue), SycmsLanguage.Module.ReadFun_New.l1, function (html, objdiag) {
                        var htmljson = parent.String2Json(html);
                        var css = parent.ReadClass("Style", htmljson);
                        var str = parent.ReadClass("Html", htmljson);
                        var ParentObj = $(Tobj).parent();
                        InsertHtml($(Tobj), str, "before");
                        ParentObj.attr("LoadIng", "-1");
                        WinCreateChild(ParentObj, ListId);
                        if (css.Trim().length > 0) {
                            ReloadModuleCss(css,ListId);
                        }
                        objdiag.close();
                        objdiag = null;
                        htmljson = null;
                        css = null;
                        str = null;
                        ParentObj = null;
                    }, null, diag);
                }
            } else {
                parent.Dialog.error(SycmsLanguage.Module.ReadFun_New.l2, function () {
                    parentWin.find("#" + objid + "T1").focus();
                });
            }
        } else {
            parent.Dialog.error(SycmsLanguage.Module.ReadFun_New.l3, function () {
                parentWin.find("#" + objid + "T0").focus();
            });
        }
    }, Tobj);
    IECollectGarbage();
}
function OpenLabelItemLog(action) {
    GridModiy(action, 'Tem/StyleModule/Lists_Log.aspx', '使用记录', null, 650, 350);
}
function OpenTemLog(id) {
    GridModiy(id, 'Tem/Tem/Lists_Log.aspx', SycmsLanguage.Module.WinCreateChild.l1+'使用记录', null, 650, 350);
}
//弹出菜单的修改
function MenuReadFun_Modi(Tobj, For) {
    var ListId = $("#YQ_listID").val();
    LabelFun(For, function (objid, returnValue, diag) {
        var isjs = "0";
        isjs = $("#" + objid + "T0_1").val();
        var title = $("#" + objid + "T0").val();
        var content = $("#" + objid + "T1").val();
        var css = $("#" + objid + "T3").val();
        var TemId = $("#TemId").val();
        if (title.length > 0) {
            if (content.Trim().length > 0) {
                if (!ShowCallBack_LabelSave($id(objid + "T1"))) {
                    AjaxFun("Tem/Tem/Modi.aspx", "action=menuwinsave&isjs=" + isjs + "&id=" + TemId + "&title=" + encodeURIComponent(title) + "&content=" + encodeURIComponent(content) + "&css=" + encodeURIComponent(css) + "&label=" + encodeURIComponent(returnValue), SycmsLanguage.Module.ReadFun_New.l1, function (html, objdiag) {
                        InsertAtCaret(Tobj, returnValue);
                        objdiag.close();
                        objdiag = null;
                    }, null, diag);
                }
            } else {
                Dialog.error(SycmsLanguage.Module.ReadFun_New.l2, function () {
                    $("#" + objid + "T1").focus();
                });
            }
        } else {
            Dialog.error(SycmsLanguage.Module.ReadFun_New.l3, function () {
                $("#" + objid + "T0").focus();
            });
        }
    }, "Template", function (objid) {
        $("#" + objid + "T3").attr("ListID", ListId);
        TextClickCss($("#" + objid + "T3").get(0));
    }, function (objid, returnValue, diag) {
        var isjs = "0";
        isjs = $("#" + objid + "T0_1").val();
        var title = $("#" + objid + "T0").val();
        var content = $("#" + objid + "T1").val();
        var css = $("#" + objid + "T3").val();
        if (title.length > 0) {
            if (content.Trim().length > 0) {
                if (!ShowCallBack_LabelSave($id(objid + "T1"))) {
                    AjaxFun("Tem/Tem/Add.aspx", "action=menuwinsave&isjs=" + isjs + "&id=" + ListId + "&title=" + encodeURIComponent(title) + "&content=" + encodeURIComponent(content) + "&css=" + encodeURIComponent(css) + "&label=" + encodeURIComponent(returnValue), SycmsLanguage.Module.ReadFun_New.l1, function (html, objdiag) {
                        InsertAtCaret(Tobj, html);
                        objdiag.close();
                        objdiag = null;
                    }, null, diag);
                }
            } else {
                Dialog.error(SycmsLanguage.Module.ReadFun_New.l2, function () {
                    $("#" + objid + "T1").focus();
                });
            }
        } else {
            Dialog.error(SycmsLanguage.Module.ReadFun_New.l3, function () {
                $("#" + objid + "T0").focus();
            });
        }
    }, Tobj);
    IECollectGarbage();
}

//添加新（弹出菜单里）
function MenuReadFun_New(Tobj, TwoType) {
    var ListId = $("#YQ_listID").val();
    LabelFun("", function (objid, returnValue, diag) {
        var title = $("#" + objid + "T0").val();
        var content = $("#" + objid + "T1").val();
        var css = $("#" + objid + "T3").val();
        var isjs = "0";
        isjs = $("#" + objid + "T0_1").val();
        if (title.length > 0) {
            if (content.Trim().length > 0) {
                AjaxFun("Tem/Tem/Add.aspx", "action=menuwinsave&isjs=" + isjs + "&id=" + ListId + "&title=" + encodeURIComponent(title) + "&content=" + encodeURIComponent(content) + "&css=" + encodeURIComponent(css) + "&label=" + encodeURIComponent(returnValue), SycmsLanguage.Module.ReadFun_New.l1, function (html, objdiag) {
                    InsertAtCaret(Tobj, html);
                    objdiag.close();
                    objdiag = null;
                }, null, diag);
            } else {
                parent.Dialog.error(SycmsLanguage.Module.ReadFun_New.l2, function () {
                    $(window.parent.document).find("#" + objid + "T1").focus();
                });
            }
        } else {
            parent.Dialog.error(SycmsLanguage.Module.ReadFun_New.l3, function () {
                $(window.parent.document).find("#" + objid + "T0").focus();
            });
        }
    }, "Template", function (objid) {
        var parentWin = $(window.parent.document);
        parentWin.find("#" + objid + "T3").attr("ListID", ListId);
        parent.TextClickCss(parentWin.find("#" + objid + "T3").get(0));
        var objselectStr = Tobj.selectOStr;
        if (objselectStr) {
            var jlxx = TextXXTab(Tobj.value, Tobj.selectionStartPoint);
            if (jlxx.length > 0) {
                jlxx = TabSpace(jlxx).replace(/\t/g, "        ");
                objselectStr = TextSpaceTabReplace(objselectStr, jlxx)
            }
        }
        parentWin.find("#" + objid + "T1").val(objselectStr);
        parentWin = null;
    }, null, Tobj, TwoType);
    IECollectGarbage();
}

function WinCreateChild(Tobj, ListId) {
    var Winobj = $("#Container_Win");
    var Winobj_name = Winobj.find("#Container_WinName");
    var Winobj_new = Winobj.find("#new");
    var Winobj_newNav = Winobj.find("#newNav");
    var Winobj_newSys = Winobj.find("#newSys");
    var Winobj_add = Winobj.find("#add");
    var Winobj_del = Winobj.find("#del");
    var Winobj_modi = Winobj.find("#modi");
    var Winobj_format = Winobj.find("#format");
    var Winobj_prev = Winobj.find("#prev");
    var Winobj_next = Winobj.find("#next");
    if (Tobj.attr("LoadIng") == "-1") {
        var ChlidDiv = Tobj.children("[tem!=no][id!=Container_Win]");
        var ChildDivLength = 0;
        ChlidDiv.each(function () {
            if ($(this).find(".Container").length != 0 || $(this).hasClass("Container") || $(this).attr("LinkedDel") == "Del") {
                ChildDivLength++;
            }
        });
        Tobj.attr("LoadIng", ChlidDiv.length - ChildDivLength);
        if (ChlidDiv.length - ChildDivLength == 0) {
            WinLocation(Winobj, Tobj.get(0), 0, Winobj_new, Winobj_newNav, Winobj_newSys, Winobj_add, Winobj_del, Winobj_modi, Winobj_format, Winobj_prev, Winobj_next, ListId);
        } else {
        ChlidDiv.unbind().bind("mouseover", function (e) {
            if ($(this).find(".Container").length == 0 && !$(this).hasClass("Container")) {       //如果下级有窗口不转换
                clearInterval(settimeoutFun);
                var str = SycmsLanguage.Module.WinCreateChild.l1;
                var Obj1 = $(this);
                while (Obj1.attr("LinkedDel") == "Del") {
                    Obj1 = Obj1.prev();
                }
                var Obj2 = Obj1.attr("For");
                if (!Obj2) {
                    var Obj1Z = Obj1.find("div[ChildFor]");
                    if (Obj1Z && Obj1Z.length > 0) {
                        Obj2 = Obj1Z.attr("ChildFor");
                    }
                }
                var N = Obj1.get(0).className.replace("Container ", "").replace(" Container", "").replace("Container", "");
                var I = Obj1.get(0).id;
                if (Obj2) {
                    Obj2 = decodeURIComponent(Obj2);
                    var re = new RegExp(">([\\s\\S]*?)<", "img");
                    var mArr1 = Obj2.match(re);
                    if (mArr1) {
                        mArr1[0] = decodeURIComponent(mArr1[0]).Trim();
                        str += "{<font color=blue>" + mArr1[0].substr(1, mArr1[0].length - 2) + "</font>}";
                    }
                    re = null;
                } else {
                    str = "<font color=red>" + SycmsLanguage.Module.WinCreateChild.l1 + "</font>";
                }
                if (N.length > 0) {
                    str += "&nbsp;" + SycmsLanguage.Module.WinCreateChild.l2 + "：<font color=blue>" + N + "</font>";
                }
                if (I.length > 0) {
                    str += "&nbsp;" + SycmsLanguage.Module.WinCreateChild.l3 + "：<font color=blue>" + I + "</font>";
                }

                var tobj1 = $(this).parent().get(0);
                var N = tobj1.className.replace("Container ", "").replace(" Container", "").replace("Container", "");
                var I = tobj1.id;
                str += "[" + SycmsLanguage.Module.WinCreateChild.l0;
                if (N.length > 0) {
                    str += "&nbsp;" + SycmsLanguage.Module.WinCreateChild.l2 + "：<font color=blue>" + N + "</font>";
                }
                if (I.length > 0) {
                    str += "&nbsp;" + SycmsLanguage.Module.WinCreateChild.l3 + "：<font color=blue>" + I + "</font>";
                }
                str += "]";

                Winobj_name.html(str).attr("title", str.ClearHtml());
                WinLocation(Winobj, this, 1, Winobj_new, Winobj_newNav, Winobj_newSys, Winobj_add, Winobj_del, Winobj_modi, Winobj_format, Winobj_prev, Winobj_next, ListId);

                IECollectGarbage();
            }
        });
        }
        ChlidDiv = null;
    } else {
        if (Tobj.attr("LoadIng") == "0") {
            WinLocation(Winobj, Tobj.get(0), 0, Winobj_new, Winobj_newNav, Winobj_newSys, Winobj_add, Winobj_del, Winobj_modi, Winobj_format, Winobj_prev, Winobj_next, ListId);
        } else {
            WinLocation(Winobj, Tobj.get(0), 0, Winobj_new, Winobj_newNav, Winobj_newSys, Winobj_add, Winobj_del, Winobj_modi, Winobj_format, Winobj_prev, Winobj_next, ListId);
        }
    }
    IECollectGarbage();
}


//Winobj为浮动窗口，obj为当前容器或者是模块，Tobj为obj转换后的JQUERY对象，Type 0为容器  1为模块，窗口上的各个A
function WinLocation(Winobj, obj, Type, Winobj_new, Winobj_newNav, Winobj_newSys, Winobj_add, Winobj_del, Winobj_modi, Winobj_format, Winobj_prev, Winobj_next, ListId) {
    var Tobj = $(obj);
    var TobjLength = Tobj.find("div[childfor]");
    if (TobjLength.length > 1) {
        Winobj.hide();
        return;
    }
    if (Tobj.attr("LinkedDel") == "Del")       //如果为模块内DIV时
    {
        while (Tobj.attr("LinkedDel") == "Del") {
            Tobj = Tobj.prev();
        }
        obj = Tobj.get(0);
    }
    var s = getElCoordinate(obj);
    var w = s.width;
    var h = s.height;
    var t = s.top;
    var l = s.left;

    var Pleft = NumFun(Tobj.css("padding-left"));
    var Pright = NumFun(Tobj.css("padding-right"));
    var Ptop = NumFun(Tobj.css("padding-top"));
    var Pbotom = NumFun(Tobj.css("padding-bottom"));

    var Mleft = NumFun(Tobj.css("margin-left"));
    var Mright = NumFun(Tobj.css("margin-right"));
    var Mtop = NumFun(Tobj.css("margin-top"));
    var Mbotom = NumFun(Tobj.css("margin-bottom"));

    w = w - Pleft - 2;
    h = h - Ptop - 2;
    t = t + Ptop;
    l = l + Pleft;
    var TobjNextArray = new Array();
    var TobjNext = Tobj.next();
    while (TobjNext.length > 0 && TobjNext.attr("LinkedDel") == "Del") {
        TobjNextArray.push(TobjNext);
        var s1 = getElCoordinate(TobjNext.get(0));

        Mleft = NumFun(TobjNext.css("margin-left"));
        Mright = NumFun(TobjNext.css("margin-right"));
        Mtop = NumFun(TobjNext.css("margin-top"));
        Mbotom = NumFun(TobjNext.css("margin-bottom"));

        var w1 = s1.width - 2;
        var h1 = s1.height - 2;
        var t1 = s1.top;
        var l1 = s1.left;

        if (w1 + l1 > w) {
            w = w1 + l1 - l;
        }
        if (h1 + t1 > h) {
            h = h1 + t1 - t;
        }
        s1 = null;
        TobjNext = TobjNext.next();
    }
    if (w < 150) { w = 150; }
    if (h < 25) { h = 25; }

    Winobj.css({ "top": t, "left": l, "width": w, "height": h });
    Winobj.find("#Container_Win_Bg").css("height", h - 25);

    Winobj_new.unbind().bind("click", function () {
        ReadFun_New(Tobj, ListId);
        Winobj.hide();
        return false;
    });
    Winobj_newNav.unbind().bind("click", function () {
        ReadFun_New(Tobj, ListId, null, "Nav");
        Winobj.hide();
        return false;
    });
    Winobj_newSys.unbind().bind("click", function () {
        ReadFun_New(Tobj, ListId, null, "Sys");
        Winobj.hide();
        return false;
    });
    Winobj_add.unbind().bind("click", function () {
        ReadFun_Add(Tobj, ListId);
        Winobj.hide();
        return false;
    });

    if (Type == 0) {
        Winobj_del.hide();
        Winobj_modi.hide();
        Winobj_prev.hide();
        Winobj_next.hide();
        Winobj.show();
    } else if (Type == 1) {
        Winobj_modi.unbind().bind("click", function () {
            ReadFun_Modi(Tobj, ListId);
            Winobj.hide();
            return false;
        });
        Winobj_format.unbind().bind("click", function () {
            ReadFun_New(Tobj, ListId, 1);
            Winobj.hide();
            return false;
        });
        Winobj_del.show();
        var For = Tobj.attr("For");
        var ChildFor = Tobj.find("div[ChildFor]");
        if ((For && For != undefined && For.length > 0) || (ChildFor && ChildFor != undefined && ChildFor.length > 0)) {
            Winobj_format.hide();
            Winobj_modi.show();
        } else {
            Winobj_modi.hide();
            Winobj_format.show();
        }

        var NextTobj = Tobj.next();
        while (NextTobj && NextTobj.attr("LinkedDel") == "Del") {
            NextTobj = NextTobj.next();
        }
        if (NextTobj.length > 0) {
            Winobj_next.show();
            Winobj_next.unbind();
            Winobj_next.bind("click", function () {
                NextTobj.after(Tobj);
                if (TobjNextArray.length > 0) {
                    for (var i = TobjNextArray.length - 1; i >= 0; i--) {
                        Tobj.after(TobjNextArray[i]);
                    }
                }
                Winobj.hide();
                return false;
            });
        } else {
            Winobj_next.hide();
        }

        var PrevTobj = Tobj.prev();
        while (PrevTobj && PrevTobj.attr("LinkedDel") == "Del") {
            PrevTobj = PrevTobj.prev();
        }

        if (PrevTobj.length > 0) {
            Winobj_prev.show();
            Winobj_prev.unbind();
            Winobj_prev.bind("click", function () {
                PrevTobj.before(Tobj);
                if (TobjNextArray.length > 0) {
                    for (var i = TobjNextArray.length - 1; i >= 0; i--) {
                        Tobj.after(TobjNextArray[i]);
                    }
                }
                Winobj.hide();
                return false;
            });
        } else {
            Winobj_prev.hide();
        }
        Winobj_del.unbind();
        Winobj_del.bind("click", function () {
            var TobjParent = Tobj.parent();
            if (TobjNextArray.length > 0) {
                $(TobjNextArray).each(function () {
                    $(this).find("*").remove();
                    $(this).remove();
                });
            }
            TobjNext = null;
            Tobj.find("*").remove();
            Tobj.remove();
            Winobj.hide();
            TobjParent.attr("LoadIng", "-1");
            WinCreateChild(TobjParent, ListId)
            TobjParent = null;
            return false;
        });
        Winobj.show();
    }
    IECollectGarbage();
}
//把PX等里面数字转回去。
function NumFun(NumStr) {
    javarun = NumStr.replace(/[^0-9]/ig, "");
    return parseInt(javarun);
}



///下载框改变值时 为当前自己 要取的地址  要改变的下拉框  要显示等待的层
function LoadChange(obj, url, objName) {
    var objv = null;
    if (typeof (obj) == "string" && obj.isDigit()) {
        objv = obj;
    } else {
        objv = $(obj).val();
    }
    if (typeof (objName) == "string") {
        $(objName).empty();
    }
    if (objv.length > 0) {
        AjaxFun(url, "id=" + objv, " ", function (html) {
            if (typeof (objName) == "string") {
                $(objName).append(html);
            } else {
                objName(html);
            }
        });
    }
    objv = null;
}

//显示模块样式
function LoadTemEye(id, listid) {
    var TemEyeOpenWin = new Dialog();
    TemEyeOpenWin.Title = SycmsLanguage.Module.WinCreateChild.l1+"浏览";
    TemEyeOpenWin.URL = "about:blank";
    TemEyeOpenWin.Width = 700;
    TemEyeOpenWin.Drag = false;
    TemEyeOpenWin.Height = 500;
    TemEyeOpenWin.show();
    LoadTem(id, listid, TemEyeOpenWin.innerFrame);
}

//调入浏览模块
function LoadTem(objv,listid,iframeObj) {
    if (objv.length > 0) {
        AjaxFun('Tem/Tem/Lists_Tem.aspx', "id=" + objv + "&listid=" + listid, SycmsLanguage.Module.LoadTem.l1, function (html) {
            var doc = null;
            if (iframeObj) {
                doc = iframeObj.contentWindow.document;
            } else {
                doc = $(".ListViewTem #iframe").get(0).contentWindow.document;
            }
            //doc.designMode = 'On';
            //doc.contentEditable = true;
            doc.open();
            if (!isIE) {
                doc.close();
            }
            doc.write(html);
            setTimeout(function () {
                $(doc).find("a").bind("click", function () { return false; });
            }, 500);
            //doc.contentEditable = false;
            //doc.designMode = 'Off';
            if (!isIE) {
                doc.close();
            }
            doc = null;
        }, null, null, null, null, null, "no");
    }
    v = null;
}

//调入浏览模块
function LoadTemSpread(obj, listid, ParentObjID) {
    if (!ParentObjID)
    {
        ParentObjID = "";
    }
    var v = $(obj).val();
    if (v.length > 0) {
        AjaxFun('Tem/Spread/Lists_Tem.aspx', "listid=" + listid + "&spid=" + v, SycmsLanguage.Module.LoadTem.l1, function (html) {
            var doc = $(".ListViewTem #iframe" + ParentObjID).get(0).contentWindow.document;
            doc.open();
            doc.clear();
            doc.write(html);
            doc.close();
            setTimeout(function () {
                $(doc).find("a").bind("click", function () { return false; });
            }, 500);
        }, null, null, null, null, null, "no");
    }
    v = null;
}

//添加扩展样式
function AddSpread(StyleModelId, listid, obj, ParentObjName, ParentObjID) {
    if (!ParentObjID)
    {
        ParentObjID = "";
    }
    var id = $(StyleModelId).val();
    if (id && id.length > 0) {
        AjaxFun("Tem/Spread/Lists_View.aspx", "yid=" + id + "&Listid=" + listid + "&objid=" + encodeURIComponent(ParentObjID), SycmsLanguage.Module.AddSpread.l1, function (html) {
            $((ParentObjName ? ParentObjName + " " : "") + "#SpreadView" + ParentObjID).html("");
            $((ParentObjName ? ParentObjName + " " : "") + "#SpreadView" + ParentObjID).prepend(html).btnForMat();
            var ObjCss = $id("CssContent");
            if (ObjCss) {
                TextClickCss(ObjCss);
            }
            if (obj) {
                var objButton = $((ParentObjName ? ParentObjName + " " : "") + "#SelectStyleModelModi" + ParentObjID);
                if (objButton && objButton.length > 0) {
                    objButton.get(0).MemberList = obj.MemberList;
                    objButton.get(0).WordSelectObj = obj.WordSelectObj;
                }
            }
        });
    }
    id = null;
}
///调入扩展样式
function LoadSpreadView(CssName, ListId, ObjName) {
    var Cssn = $("#" + CssName).val();
    if (Cssn && Cssn.length > 0) {
        AjaxFun('Tem/List/Lists_SpreadCss.aspx', "ID=" + ListId + "&CssName=" + Cssn, SycmsLanguage.Module.LoadSpreadView.l1, function (html) {
            if (html.length > 0) {
                $("#" + ObjName).val(html);
            }
        });
    }
    Cssn = null;
}
//查看
function SpreadView(StyleId, Listid, spid) {
    var id = "";
    if (StyleId.isDigit()) {
        id = StyleId;
    } else {
        id = $(StyleId).val();
    }
    if (id.length > 0) {
        var cssname = $("#SpreadView #CssName").val();
        var css = $("#SpreadView #CssContent").val();
        if (AddReturnValidationEngine("#SpreadView")) {
            AjaxFun('Tem/Spread/Lists_Tem.aspx', "id=" + id + "&spid=" + spid + "&Listid=" + Listid + "&cssname=" + encodeURIComponent(cssname) + "&css=" + encodeURIComponent(css), SycmsLanguage.Module.SpreadView.l1, function (html) {
                TemEyediag = new Dialog();
                TemEyediag.Title = SycmsLanguage.Module.SpreadView.l2;
                TemEyediag.URL = "about:blank";
                TemEyediag.Width = 500;
                TemEyediag.Drag = false;
                TemEyediag.Height = 500;
                TemEyediag.show();
                var doc = TemEyediag.innerFrame.contentWindow.document;
                doc.open();
                doc.write(html);
                doc.close();
                setTimeout(function () {
                    $(TemEyediag.innerFrame.contentWindow.document).find("a").bind("click", function () { return false; });
                }, 500);
                doc = null;
            }, null, null, null, null, null, "no");
        } else {
            setTimeout(function () { $.validationEngine.closePrompt('.formError', true) }, 2000);
        }
        cssname = null;
        css = null;
    }
    IECollectGarbage();
}



//列表中添加模块
function AddTemFun(id) {
    LabelFun("", function (objid, returnValue, diag) {
        var isjs = "0";
        isjs = $("#" + objid + "T0_1").val();
        var title = $("#" + objid + "T0").val();
        var content = $("#" + objid + "T1").val();
        var css = $("#" + objid + "T3").val();
        if (title.length > 0) {
            if (content.Trim().length > 0) {
                AjaxFun("Tem/Tem/Add.aspx", "id=" + id + "&isjs=" + isjs + "&title=" + encodeURIComponent(title) + "&content=" + encodeURIComponent(content) + "&css=" + encodeURIComponent(css) + "&label=" + encodeURIComponent(returnValue), SycmsLanguage.Module.ReadFun_New.l1, function (html) {
                    diag.close();
                    diag = null;
                    $('#flex1').flexReload();
                }, null, diag);
            } else {
                Dialog.error(SycmsLanguage.Module.ReadFun_New.l2, function () {
                    $("#" + objid + "T1").focus();
                });
            }
        } else {
            Dialog.error(SycmsLanguage.Module.ReadFun_New.l3, function () {
                $("#" + objid + "T0").focus();
            });
        }
    }, "Template", function (objid) {
        $("#" + objid + "T3").attr("ListID", id);
        TextClickCss($("#" + objid + "T3").get(0));
    });
}

//Html列表中修改模块
function ModiyTemFun(Label, gridList) {
    var itemlist = "";
    if (typeof (gridList) == "string") {
        itemlist = gridList;
    } else {
        if ($('.trSelected', gridList).length > 0) {
            var items = $('.trSelected', gridList);
            for (i = 0; i < items.length; i++) {
                itemlist += items[i].id.substr(3) + ",";
            }
            itemlist = itemlist.Left(itemlist.length - 1);
            if (Label.length == 0) {        //取选定项的指定列值
                if (document.all) {
                    Label = FormatHTML.GetXHTML(items.children().eq(4).find("> div").get(0));
                } else {
                    Label = items.children().eq(4).find("> div").html();
                }
                Label = Label.replace(new RegExp("<sycms></sycms>", "gi"), "");
            }
            items = null;
        } else {
            Dialog.alert(SycmsLanguage.Module.ModiyTemFun.l1);
        }
    }
    if (Label.length > 0) {
        if (Label.Left(8) == "%3Csycms")
        {
            Label = decodeURIComponent(Label);
        }
        if (Label.Right(5) == "</tr>") {
            Label = Label.Left(Label.length - 5) + "</sycms>";
        }
    }
    if (itemlist.length > 0) {
        LabelFun(Label, function (objid, returnValue, diag) {
            var isjs = "0";
            isjs = $("#" + objid + "T0_1").val();
            var title = $("#" + objid + "T0").val();
            var content = $("#" + objid + "T1").val();
            var css = $("#" + objid + "T3").val();
            if (title.length > 0) {
                if (content.Trim().length > 0) {
                    AjaxFun("Tem/Tem/Modi.aspx", "action=save&isjs=" + isjs + "&id=" + itemlist + "&title=" + encodeURIComponent(title) + "&content=" + encodeURIComponent(content) + "&css=" + encodeURIComponent(css) + "&label=" + encodeURIComponent(returnValue), SycmsLanguage.Module.ReadFun_New.l1, function (html) {
                        diag.close();
                        diag = null;
                        $('#flex1').flexReload();
                    }, null, diag);
                } else {
                    Dialog.error(SycmsLanguage.Module.ReadFun_New.l2, function () {
                        $("#" + objid + "T1").focus();
                    });
                }
            } else {
                Dialog.error(SycmsLanguage.Module.ReadFun_New.l3, function () {
                    $("#" + objid + "T0").focus();
                });
            }
        }, "Template", null, function (objid, returnValue, diag) {
            var listID = $("#YQ_listID").val();
            if (listID) {
                var isjs = "0";
                isjs = $("#" + objid + "T0_1").val();
                var title = $("#" + objid + "T0").val();
                var content = $("#" + objid + "T1").val();
                var css = $("#" + objid + "T3").val();
                if (title.length > 0) {
                    if (content.Trim().length > 0) {
                        AjaxFun("Tem/Tem/Add.aspx", "action=save&isjs=" + isjs + "&id=" + listID + "&title=" + encodeURIComponent(title) + "&content=" + encodeURIComponent(content) + "&css=" + encodeURIComponent(css) + "&label=" + encodeURIComponent(returnValue), SycmsLanguage.Module.ReadFun_New.l1, function (html) {
                            diag.close();
                            diag = null;
                            $('#flex1').flexReload();
                        }, null, diag);
                    } else {
                        Dialog.error(SycmsLanguage.Module.ReadFun_New.l2, function () {
                            $("#" + objid + "T1").focus();
                        });
                    }
                } else {
                    Dialog.error(SycmsLanguage.Module.ReadFun_New.l3, function () {
                        $("#" + objid + "T0").focus();
                    });
                }
            }
            listID = null;
        });
    }
}

///html列表中插入现有
function MenuReadFun_Add(Tobj) {
    var ListId = $("#YQ_listID").val();
    if (ListId) {
        CreateWindow("Tem/Tem/Lists_View.aspx?id=" + ListId, SycmsLanguage.Module.ReadFun_Add.l1, function (diagwin) {
            var ObjNum = $("#ListViewTem #MoId").val();
            if (ObjNum != "") {
                AjaxFun("Tem/Tem/Lists_Tem.aspx", "action=htmlinstall&ListID=" + ListId + "&id=" + ObjNum, SycmsLanguage.Module.ReadFun_Add.l2, function (html, diagwin) {
                    InsertAtCaret(Tobj, html);
                    diagwin.close();
                    diagwin = null;
                }, null, diagwin);
            }
        }, 700, 500, "ListViewTem");
    }
    ListId = null;
}

///调入样式
function LoadTemCss(ObjName, Action) {
    AjaxFun('Tem/List/Lists_Css.aspx?IEtype=' + getBrowserOS(), Action, SycmsLanguage.Module.LoadTemCss.l1, ObjName);
}

///模板查看效果
function ListView(Type, ObjName, ListId) {
    var str = "Listid=" + ListId + "&Type=" + Type;
    if (ObjName && ObjName.length > 0) {
        var obj = $(ObjName);
        if (obj.length > 0) {
            if (Type == "0") {      //为内容
                str += "&Content=" + encodeURIComponent(obj.val());
            } else if (Type == "1") {      //为样式
                str += "&CssContent=" + encodeURIComponent(obj.val());
            }
        }
        obj = null;
    }
    AjaxFun('Tem/List/Lists_View.aspx', str, SycmsLanguage.Module.ListView.l1, function (html) {
        TemEyediag = new Dialog();
        TemEyediag.Title = SycmsLanguage.Module.ListView.l2;
        TemEyediag.URL = "about:blank";
        TemEyediag.Width = "500";
        TemEyediag.Drag = false;
        TemEyediag.Height = "500";
        TemEyediag.show();
        var doc = TemEyediag.innerFrame.contentWindow.document;
        doc.open();
        doc.write(html);
        doc.close();
        setTimeout(function () {
            $(TemEyediag.innerFrame.contentWindow.document).find("a").bind("click", function () { return false; });
        }, 500);
        doc = null;
    }, null, null, null, null, null, "no");
    str = null;
    IECollectGarbage();
}
//显示SqlTime框架页
function ListTime(ListID) {
    ModuleOpenWin = new Dialog();
    ModuleOpenWin
    ModuleOpenWin.Title = "SQL执行时间，开发人员使用";
    ModuleOpenWin.URL = "Tem/List/Modi_SqlTime.aspx?Listid=" + ListID+"&Time="+Math.random(),
    ModuleOpenWin.Width = "500";
    ModuleOpenWin.Drag = false;
    ModuleOpenWin.Height = "500";
    ModuleOpenWin.show();
}
//显示
function ListTimeSqlView(ListID,getpoststring, string)
{
    var msg = "<div style=\"width:580px;height:100px;overflow-x:none;overflow-y:auto;\" id=\"SqlTimeContentForm\">" + getpoststring + "</div><div style='width:580px;height:280px;overflow-x:none;overflow-y:auto;line-height:150%;white-space: pre-wrap;white-space: -moz-pre-wrap !important;white-space: -pre-wrap; white-space: -o-pre-wrap;word-wrap: break-word;' id='SqlTimeContentPrint'>" + string + "</div>";
    var diag = new Dialog({
        Width: 600,
        Height: 400
    });
    diag.ShowButtonRow = true;
    diag.Title = "Sql执行列表";
    diag.Icon = "";
    diag.CancelEvent = function ()
    {
        diag.close();
        window.parent.ModuleOpenWin.close();
    }
    diag.OKEvent = function () {
        var code = "<html><body><style type=\"text/css\">*{font-size:12px;}hr{height:1px;}.red{color:red;}.blue{color:blue;}</style>" + window.parent.document.getElementById("SqlTimeContentPrint").innerHTML + "<script type='text/javascript'>window.print();</script></body></html>";
        var newwin = window.open('', '', '');
        newwin.opener = null;
        newwin.document.write(code);
        window.document.close();
    };
    diag.InnerHtml = '<table height="100%" border="0" align="center" width="100%" cellpadding="10" cellspacing="0">\
		<tr><td align="left" id="Message_' + this.ID + '" style="font-size:9pt">' + msg + '</td></tr>\
	</table>';
    diag.show();
    diag.cancelButton.value = "关 闭";
    diag.okButton.value = "打 印";
    diag.addButton("next", "表单传值", function () {
        location.href = "?Listid=" + ListID + "&" + ReadInputValue(window.parent.document.getElementById("SqlTimeContentForm"));
        diag.close();
    });
    diag.cancelButton.focus();
}

//修改组样式
function AllClassCssWinFun(id, Title) {
    GridModiy(id, 'Tem/Class/Lists_Css.aspx?action=view', '模板组样式' + (Title ? "[" + Title + "]" : ""), null, 700, 350);
}

//修改全局样式
function AllCssWinFun(id, TypeFun, Title) {
    GridModiy(id, 'Tem/List/Modi_Css.aspx', '修改' + (Title ? "[" + Title + "]" : "") + '模板Css', 'Tem/List/Modi_Css.aspx?action=save', "50", "50", null, null, null, "修改Css样式", "<span style=\"float:right;padding-right:5px;\"><input type=\"button\" value=\"调用同组第一个模板样式\" onclick=\"LoadTemCss('#csscontent','listid=" + id + "&Type=0');\" icon=\"icon-css_go\"><input type=\"button\" value=\"单击查看效果\" onclick=\"ListView('1', '#csscontent'," + id + ");\" icon=\"icon-eye\"></span>此Css样式为此模板的样式，定义了容器，容器外架构的Css，如果有图片的时候前面要加[$Path$]，如[$Path$]/Images/.JPG", null, TypeFun);
}
//修改全局html
function AllHtmlWinFun(id, TypeFun, Title) {
    GridModiy(id, 'Tem/List/Modi_Html.aspx', '修改' + (Title ? "[" + Title + "]" : "") + 'HTML', 'Tem/List/Modi_Html.aspx?action=save', "50", "50", null, null, null, "修改HTML模板页", "<span style=\"float:right;padding-right:5px;\"><input type=\"button\" value=\"单击查看效果\" onclick=\"ListView('0', '#htmlcontent'," + id + ");\" icon=\"icon-eye\"></span>此为模板的HTML显示，如果有图片的时候前面要[$Path$]，如[$Path$]/Images/.JPG。如果不希望容器里的元素参加模板管理可在最外层加上tem=\"no\"即可。在样式里加'Container'即可成为容器。", null, TypeFun, null, function (FromName) {
        if (!ShowCallBack_LabelSave($id("htmlcontent"))) {
            return true;
        } else {
            return false;
        }
    }, function () { AjaxFun("Tem/List/Modi_Cancel.aspx", "id=" + id, null, null, null, null, null, null, null, null, true); });
}

//模板内模块查看效果

function TemViewEye(id) {
    TemEyediag = new Dialog();
    TemEyediag.Title = "浏览查看";
    TemEyediag.URL = "Tem/Tem/Lists_Tem.aspx?id=" + id;
    TemEyediag.Width = 500;
    TemEyediag.Drag = false;
    TemEyediag.Height = 500;
    TemEyediag.show();
}

//模板 相关

function TemAddView(classid, height) {
    CreateWindow('Tem/List/Add.aspx?classid=' + classid, '添加模板', 'Tem/List/Add.aspx?action=save', 500, height?height:140, 'TemAdd', null, null, null, null, function (objwin) {
        var obj = $('#TemAdd #TemAddvanced');
        if (obj) {
            obj.unbind().bind("click", function () {
                var tobj = $(this);
                var iobj = tobj.find('input');
                var dobj = $('#TemAdd #TemAddvanced_Div');
                var url = iobj.css('background-image');
                if (iobj.val().indexOf("打开") != -1) {
                    iobj.val("关闭关联生成（与关联模板同步生成）");
                    url = url.replace("remove_blue", "add_blue");
                    objwin.setSize(500, 350);
                    dobj.show();
                } else {
                    iobj.val("打开关联生成（与关联模板同步生成）");
                    url = url.replace("add_blue", "remove_blue");
                    objwin.setSize(500, 140);
                    dobj.hide();
                }
                iobj.css({ "background-image": url });
            });
        }
    });
}
//模板修改显示
function TemModiView(idobject,height) {
    GridModiy(idobject, 'Tem/List/Modi.aspx', '修改模板', 'Tem/List/Modi.aspx?action=save', 500, height?height:100, 'TemAdd', null, null, null, null, function (objwin) {
        var obj = $('#TemAdd #TemAddvanced');
        if (obj) {
            obj.unbind().bind("click", function () {
                var tobj = $(this);
                var iobj = tobj.find('input');
                var dobj = $('#TemAdd #TemAddvanced_Div');
                var url = iobj.css('background-image');
                if (iobj.val().indexOf("打开") != -1) {
                    iobj.val("关闭关联生成（与关联模板同步生成）");
                    url = url.replace("remove_blue", "add_blue");
                    objwin.setSize(500, 300);
                    dobj.show();
                } else {
                    iobj.val("打开关联生成（与关联模板同步生成）");
                    url = url.replace("add_blue", "remove_blue");
                    objwin.setSize(500, 100);
                    dobj.hide();
                }
                iobj.css("background-image", url);
            });
        }
    })
}
//插入HTML代码
function TemInsertHtml(obj, str) {
    if (!str)
    {
        str = getSelectedText(obj);
    }
    var StyleModuleWin = new Dialog();
    StyleModuleWin.Title = "HTML代码输出";
    StyleModuleWin.InnerHtml = "<div><textarea id=\"CkeditorHtml\"></textarea></div>";
    StyleModuleWin.Width = 600;
    StyleModuleWin.Drag = false;
    StyleModuleWin.Height = 300;
    StyleModuleWin.OKEvent = function () {
        str = CkeditorGetHtml("CkeditorHtml");
        CkeditorRemove("CkeditorHtml");
        StyleModuleWin.close();
        InsertAtCaret(obj, str);
    };
    StyleModuleWin.CloseEvent = function () {
        CkeditorRemove("CkeditorHtml");
        StyleModuleWin.close();
    };
    StyleModuleWin.show();
    $("#CkeditorHtml").val(str);
    CkeditorView("CkeditorHtml", { skin: 'v2', toolbar: 'Default', height: '190',width: '600' });
}