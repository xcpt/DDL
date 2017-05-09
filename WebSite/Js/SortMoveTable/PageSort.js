function PageTableImg(obj) {
    if (obj.src.indexOf("true") != -1) {
        PageTableFriefox($(obj).parent().parent(), 1);
    } else {
        PageTableFriefox($(obj).parent().parent());
    }
}

//显示消失
function PageTableVisible(CssName, obj, textobj, index, arraystring) {
    var objstr = "";
    if (typeof (obj) == "object") {
        objstr = obj.src;
        PageTableImg(obj);
    } else {
        objstr = obj;
    }
    if (objstr.indexOf("true") != -1 || objstr == "0" || objstr == "") {
        if (CssName) {
            if (index != null) {
                $(CssName).eq(index).hide();
            } else {
                $(CssName).hide();
            }
        }
        if (textobj) {
            $(textobj).val("0");
        }
        if (arraystring) {
            if (arraystring.length == 3) {
                var str = "";
                for (var i = 0; i < arraystring[0].length; i++) {
                    if (i != arraystring[2]) {
                        if (typeof (arraystring[0][i]) == "object") {
                            if (arraystring[0][i].get(0).disabled != true || objstr == "1") {
                                str += arraystring[0][i].val();
                            }
                        } else {
                            str += arraystring[0][i];
                        }
                    }
                }
                $(arraystring[1]).html(str);
            }
        }
    } else {
        if (CssName) {
            if (index != null) {
                $(CssName).eq(index).show();
            } else {
                $(CssName).show();
            }
        }
        if (textobj) {
            $(textobj).val("1");
        }
        if (arraystring) {
            if (arraystring) {
                if (arraystring.length == 3) {
                    var str = "";
                    for (var i = 0; i < arraystring[0].length; i++) {
                        if (typeof (arraystring[0][i]) == "object") {
                            if (arraystring[0][i].get(0).disabled != true || objstr == "1") {
                                str += arraystring[0][i].val();
                            }
                        } else {
                            str += arraystring[0][i];
                        }
                    }
                    $(arraystring[1]).html(str);
                }
            }
        }
    }
}

function PageTableType(lx) {
    var s1 = "";
    if ($("#Pstate_0Name").get(0).disabled != true) {
        s1 = "<span class=\"Pstate\">" + $("#Pstate_0Name").val() + "</span>";
    } else {
        s1 = "<span class=\"Pstate\" style=\"display:none;\">" + $("#Pstate_0Name").val() + "</span>";
    }
    var s2 = "";
    if ($("#Pstate_1Name").get(0).disabled != true) {
        s2 = "<span class=\"Pstate\">" + $("#Pstate_1Name").val() + "</span>";
    } else {
        s2 = "<span class=\"Pstate\" style=\"display:none;\">" + $("#Pstate_1Name").val() + "</span>";
    }
    var s3 = "";
    if ($("#AllPageImg").attr("src").indexOf("true") != -1) {
        s3 = "<span class=\"AllPage\">/77</span>";
    } else {
        s3 = "<span class=\"AllPage\" style=\"display:none;\">/77</span>"
    }
    if (lx == 1) {
        $("#defaultTable #Ppagelist").html("<span class=\"Ppagelist\">" + s1 + "<span class=\"Ppage\"><a href=\"\" onclick=\"return false;\">1</a></span><span class=\"Ppage\"><a href=\"\" onclick=\"return false;\">2</a></span><span>...</span><span class=\"Ppage\"><a href=\"\" onclick=\"return false;\">5</a></span><span class=\"Ppage\"><a href=\"\" onclick=\"return false;\">6</a></span><span class=\"Ppage\"><a href=\"\" onclick=\"return false;\" class=\"Pmodern\">7</a>" + s3 + "</span><span class=\"Ppage\"><a href=\"\" onclick=\"return false;\">8</a></span><span class=\"Ppage\"><a href=\"\" onclick=\"return false;\">9</a></span><span>...</span><span class=\"Ppage\"><a href=\"\" onclick=\"return false;\">76</a></span><span class=\"Ppage\"><a href=\"\" onclick=\"return false;\">77</a></span>" + s2 + "</span>");
    } else {
        $("#defaultTable #Ppagelist").html("<span class=\"Ppagelist\">" + s1 + "<span class=\"Ppage\"><a href=\"\" onclick=\"return false;\">2</a></span><span class=\"Ppage\"><a href=\"\" onclick=\"return false;\">3</a></span><span class=\"Ppage\"><a href=\"\" onclick=\"return false;\">4</a></span><span class=\"Ppage\"><a href=\"\" onclick=\"return false;\">5</a></span><span class=\"Ppage\"><a href=\"\" onclick=\"return false;\">6</a></span><span class=\"Ppage\"><a href=\"\" onclick=\"return false;\" class=\"Pmodern\">7</a>" + s3 + "</span><span class=\"Ppage\"><a href=\"\" onclick=\"return false;\">8</a></span><span class=\"Ppage\"><a href=\"\" onclick=\"return false;\">9</a></span><span class=\"Ppage\"><a href=\"\" onclick=\"return false;\">10</a></span><span class=\"Ppage\"><a href=\"\" onclick=\"return false;\">11</a></span>" + s2 + "</span>");
    }
}

function PageTableAhtml(Name, Value, Type) {
    if (Type) {
        $(Name).val(Value);
    } else {
        $(Name).html(Value.replace(/[ ]/g, "&nbsp;"));
    }
}

function PageTableFriefox(obj, type) {
    if (type) {
        obj.attr("disabled", "disabled").addClass("disabled");
        obj.find("*").attr("disabled", "disabled").addClass("disabled");
        obj.find("img").each(function (Index) {
            if (Index == 0) {
                $(this).removeAttr("disabled").removeClass("disabled");
                this.src = this.src.replace("true", "false");
            } else {
                if (this.src.indexOf("_Gray") == -1) {
                    this.src = this.src.replace("true", "true_Gray");
                    this.src = this.src.replace("false", "false_Gray");
                }
            }
        });
    } else {
        obj.removeAttr("disabled").removeClass("disabled");
        obj.find("*").removeAttr("disabled").removeClass("disabled");
        obj.find("img").each(function (Index) {
            if (Index == 0) {
                $(this).removeAttr("disabled").removeClass("disabled");
                this.src = this.src.replace("false", "true");
            } else {
                this.src = this.src.replace("_Gray", "");
                this.src = this.src.replace("_Gray", "");
            }
        });
    }
}


//加载样式
function appendRule(ss, selector, ruleBody) {
    if (ss.insertRule)
        ss.insertRule(selector + "{" + ruleBody + "}", ss.cssRules.length)
    else if (ss.addRule)
        ss.addRule(selector, ruleBody);
}
function PageTabeCss(content,TemPath,WebTemPath) {
    if ($("#PageStyle").length > 0) {
        $("#PageStyle").remove();
    }
    var style = document.createElement("style");
    style.id = "PageStyle";
    $(".PageViewModiy").get(0).appendChild(style);
    var csscon = "";
    if (WebTemPath.length > 1) {
        content = content.split("[$TemPath$]").join(WebTemPath);
    } else {
        content = content.split("[$TemPath$]").join(TemPath);
    }
    if (content.Trim().length > 0) {
        if (content.indexOf("[$Path$]") != -1) {
            FirefoxDisabled("ModelClassTemView", 1);
            var TemClassPath = $("#ModelClassTem").val();
            if (TemClassPath && TemClassPath.length > 0) {
                if (WebTemPath.length > 1) {
                    content = content.split("[$Path$]").join(WebTemPath + TemClassPath);
                } else {
                    content = content.split("[$Path$]").join(TemPath + TemClassPath);
                }
            }
        }
        var con = content.split("}");
        for (var i = 0; i < con.length; i++) {
            if (con[i].replace("\r", "").replace("\n", "").Trim().length > 0) {
                var con1 = con[i].split("{");
                var con2 = con1[0].split(",");
                for (var j = 0; j < con2.length; j++) {
                    if (con2[j].length > 0) {
                        appendRule(document.styleSheets[document.styleSheets.length - 1], ".PageViewModiy " + con2[j], con1[1].replace("\r", "").replace("\n", ""));
                    }
                }
            }
        }
    }
}