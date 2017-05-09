
function System_Files_Modi(obj) {
    var objI = $(obj).find("input");
    if (objI.length > 0) {
        AjaxFun('System/Files/Modi.aspx',null, '修改是否自动删除关联图片', function () {
            if (objI.val().indexOf("自动删除关联图片")!=-1) {
                objI.val("手动删除关联图片");
            } else {
                objI.val("自动删除关联图片");
            }
        });
    }
}
function StyleModuleIsExit(action, Dir, MdbId) {
    Dialog.confirm("查找到你的样式模块中已经存在此样式模块插件。<br>“继续”：与以前的使用相同的js、图片、样式文件。<br>“新建”：此次使用新的js、图片、样式文件。", function () {
        AjaxFun('Tem/StyleModule/Add_Down.aspx', 'create=1&MdbId=' + MdbId + '&action=' + action + '&Dir=' + Dir, '正在下载并安装，请稍候...');
    }, null, 400, 70, "继续", null, "新建", function (diag) {
        diag.close();
        AjaxFun('Tem/StyleModule/Add_Down.aspx', 'create=1&newcreate=1&MdbId=' + MdbId + '&action=' + action + '&Dir=' + Dir, '正在下载并安装，请稍候...');
    });
}
function StyleModuleWHelpView(action,IsSysID) {
    AjaxFun('Tem/StyleModule/Lists_help.aspx', "action=" + action, "正在调入显示，请稍候...", function (html) {
        var TemEyediag = new Dialog();
        TemEyediag.Title = "帮助说明显示";
        TemEyediag.URL = "about:blank";
        TemEyediag.Width = 800;
        TemEyediag.Drag = false;
        TemEyediag.Height = 500;
        if (IsSysID == "1") {
            TemEyediag.MessageTitle = "相关文件路径说明";
            TemEyediag.Message = "图片、样式、Flash等文件在图片上传目录里StyleModule的" + action + "目录里。JS文件在网站目录JS目录里StyleModule的" + action + "目录里";
        }
        TemEyediag.show();
        var doc = TemEyediag.innerFrame.contentWindow.document;
        doc.open();
        doc.write(html);
        doc.close();
    });
}

function StyleModuleWHelpDemo(Url) {
    ModuleOpenWin = new Dialog();
    ModuleOpenWin.Title = "插件显示效果";
    ModuleOpenWin.URL = Url;
    ModuleOpenWin.Width = 800;
    ModuleOpenWin.Drag = true;
    ModuleOpenWin.Height = 600;
    ModuleOpenWin.Message = "可以在下面页面中单击右键查看源代码（firefox中请选择“本帧”）。";
    ModuleOpenWin.show();
}


///插件管理
function Menu_PlusFun(obj, str) {
    var xml = null;
    if (str) {
        xml = new XML();
        xml.SetXML("<?xml version='1.0' encoding='utf-8'?><xml>" + str + "</xml>");
    }
    var H = parseInt(PlusFunHtml[2]);
    if (H + 90 > Wh) {
        H = Wh - 90;
    }
    var objid = obj.id;
    var diag = new Dialog();
    diag.Width = PlusFunHtml[1];
    diag.Height = H;
    diag.Title = PlusFunHtml[0];
    diag.InnerHtml = ReplaceRegExpValue(PlusFunHtml[4].replace(/\$\$/g, objid), H);
    diag.OKEvent = function () {
        AjaxFun("Plus/Management/Lists_Insert.aspx?Path=" + ($("#" + objid + "TT001").val()), ReadInputValue("#" + objid + "TT002"), "正在生成插件代码...", function (html) {
            if (html.length > 0) {
                InsertAtCaret(obj, decodeURIComponent(html));
            }
        });
        diag.close();
    };        //点击确定后调用的方法
    diag.show();
    var SelectObj = $("#" + objid + "TT001");
    SelectObj.append("<option value=\"\">请选择</option>");
    SelectObj.append("<option value=\"user\">会员</option>");
    SelectObj.append("<option value=\"DownFile\">多文件下载</option>");
    for (var i = 0; i < Menu_Plus.length; i++) {
        SelectObj.append("<option value=\"" + Menu_Plus[i][0] + "\">" + Menu_Plus[i][1] + "</option>");
    }
    if (xml) {
        var plusname = xml.getAttrib("xml/sycms", "plusname");
        SelectObj.val(plusname);
        AjaxFun("Plus/Management/Lists_Read.aspx", "Path="+plusname, "读取插件设置信息", function (html) {
            if (html.length > 0) {
                var DivTT002 = $("#" + objid + "TT002");
                DivTT002.html(html).btnForMat();
                var PageList = DivTT002.find("select.PageStyle");
                PageList.each(function () {
                    addItem(this, "请选择分页", "");
                    PageListSelect(this);
                });
                var icount = xml.getNodeslength("xml/sycms/item"); //循环实体
                for (var i = 1; i < icount; i++) {
                    var value1 = xml.getChild("xml/sycms/item", i + 1);
                    var id1 = xml.getAttrib("xml/sycms/item", "value", i + 1);
                    if (id1 && value1) {
                        var Obj1 = DivTT002.find("[name=" + id1 + "]");
                        value1 = decodeURIComponent(value1);
                        if (Obj1.get(0).type == "checkbox") {
                            Obj1.each(function () {
                                if (("," + value1 + ",").indexOf("," + this.value + ",")!=-1) {
                                    this.checked = true;
                                } else {
                                    this.checked = false;
                                }
                            });
                        } else if (Obj1.get(0).type == "radio") {
                            Obj1.each(function () {
                                if (("," + value1 + ",").indexOf("," + this.value + ",")!=-1) {
                                    this.checked = true;
                                }
                            });
                        } else {
                            Obj1.val(value1);
                        }
                    }
                }
            }
        });
    }
    SelectObj.bind("change", function () {
        var id = ($(this).val());
        if (id.length > 0) {
            AjaxFun("Plus/Management/Lists_Read.aspx", "Path="+id, "正在调入...", function (html) {
                if (html.length > 0) {
                    var DivTT002 = $("#" + objid + "TT002");
                    DivTT002.html(html).btnForMat();
                    var PageList = DivTT002.find("select.PageStyle");
                    PageList.each(function () {
                        addItem(this, "请选择分页", "");
                        PageListSelect(this);
                    });

                }
            });
        }
    });
}
///显示时间计划显示
function ViewTaskTime(obj) {
    if (obj) {
        var str = obj.value;
        var htmlstr = new Array();
        var objid = obj.id;
        if (str) {
            var xml = new XML();
            ///<sycms day="" daycontent="" minute="" minutecontent=""><itme value=\"6-9\">ddd</itme></sycms>
            xml.SetXML("<?xml version='1.0' encoding='utf-8'?><xml>" + str + "</xml>");
            var day = xml.getAttrib("xml/sycms", "name");
            var daycontent = decodeURIComponent(xml.getAttrib("xml/sycms", "daycontent"));
            if (day) {
                htmlstr.push("<fieldset style=\"padding:5px;margin:5px;\">");
                if (day == "week") {
                    htmlstr.push("<legend>星期" + daycontent.replace("1", "一").replace("2", "二").replace("3", "三").replace("4", "四").replace("5", "五").replace("6", "六").replace("7", "日").split(",").join("，") + "执行任务</legend>");
                } else {
                    htmlstr.push("<legend>每隔" + daycontent + "天执行任务</legend>");
                }
                var minute = xml.getAttrib("xml/sycms", "minute");
                var minutecontent = decodeURIComponent(xml.getAttrib("xml/sycms", "minutecontent"));
                if (minute) {
                    if (minute == "loop") {
                        htmlstr.push("<div>每" + minutecontent + "分钟循环执行。</div>");
                        var icount = xml.getNodeslength("xml/sycms/item"); //循环实体
                        if (icount > 0) {
                            htmlstr.push("<ol>");
                            for (var i = 0; i < icount; i++) {
                                var x = decodeURIComponent(xml.getAttrib("xml/sycms/item", "value", i + 1));
                                var x3 = decodeURIComponent(xml.getChild("xml/sycms/item", i + 1));
                                htmlstr.push("<li>在" + x.replace("-", "点到") + "点之间，每" + x3 + "分钟循环执行。</li>");
                            }
                            htmlstr.push("</ol>");
                        }
                    } else {
                        htmlstr.push("<div>在" + minutecontent.replace(":", "点") + "分时执行。</div>");
                    }
                }
                htmlstr.push("</fieldset>");
            }
            xml.Dispose();
            xml = null;
            if (htmlstr.length == 0) {
                $("#" + objid + "_View").html("暂无执行计划");
                $("#" + objid + "_Button").btn().disable();
            } else {
                $("#" + objid + "_View").html(htmlstr.join(""));
                $("#" + objid + "_Button").btn().enable();
            }
        } else {
            $("#" + objid + "_View").html("暂无执行计划");
            $("#" + objid + "_Button").btn().disable();
        }
    }
}
//自动执行任务
function AutoTaskFun(obj, min, max) {
    if (!min) {
        min = 1;
    }
    if (!max) {
        max = 120;
    }
    var str = obj.value;
    var objid = obj.id;
    var xml = new XML();
    if (str) {
        xml.SetXML("<?xml version='1.0' encoding='utf-8'?><xml>" + str + "</xml>");
    } else {
        xml.SetXML("<?xml version='1.0' encoding='utf-8'?><xml><sycms name=\"\"></sycms></xml>");
    }
    var H = parseInt(AutoTaskFunHtml[2]);
    if (H + 90 > Wh) {
        H = Wh - 90;
    }
    var diag = new Dialog();
    diag.Width = AutoTaskFunHtml[1];
    diag.Height = H;
    diag.Title = AutoTaskFunHtml[0];
    diag.InnerHtml = ReplaceRegExpValue(AutoTaskFunHtml[4].replace(/\$\$/g, objid).replace("$Min$", min).replace("$Max$", max), H);
    diag.OKEvent = function () {
        var xml2 = new XML();
        xml2.SetXML("<?xml version=\"1.0\" encoding=\"utf-8\"?><xml><sycms name=\"\"></sycms></xml>");
        var str = "";
        var bo = true;
        //读取信息保存成一个格式返回
        if ($id(objid + "T01_0").checked) {
            xml2.setAttrib("xml/sycms", "name", "week");
            var daycontent = "";
            for (var i = 1; i <= 7; i++) {
                if ($id(objid + "T011_" + i).checked) {
                    daycontent += i + ",";
                }
            }
            if (daycontent) {
                daycontent = daycontent.substr(0, daycontent.length - 1);
                xml2.setAttrib("xml/sycms", "daycontent", encodeURIComponent(daycontent));
            } else {
                bo = false;
            }
        } else {
            xml2.setAttrib("xml/sycms", "name", "day");
            var daycontent = $id(objid + "T012").value;
            if (daycontent) {
                xml2.setAttrib("xml/sycms", "daycontent", encodeURIComponent(daycontent));
            } else {
                bo = false;
            }
        }
        if ($id(objid + "T02_0").checked) {
            xml2.setAttrib("xml/sycms", "minute", "loop");
            xml2.setAttrib("xml/sycms", "minutecontent", encodeURIComponent($id(objid + "T021").value));
            $("#" + objid + "T021Div>div").each(function () {
                var value = $(this).attr("value");
                if (value) {
                    var value1 = value.split(",");
                    xml2.InsertBeforeChild("xml/sycms", "item", encodeURIComponent(value1[1]), [{ name: "value", value: encodeURIComponent(value1[0])}]);
                }
            });
        } else {
            xml2.setAttrib("xml/sycms", "minute", "time");
            var minutecontent = "";
            minutecontent = $("#" + objid + "T022_0").val() + ":" + $("#" + objid + "T022_1").val();
            xml2.setAttrib("xml/sycms", "minutecontent", encodeURIComponent(minutecontent));
        }
        if (bo) {
            obj.value = xml2.GetString("xml/sycms");
            ViewTaskTime(obj);
            diag.close();
        }
        xml2.Dispose();
        xml2 = null;
    };
    diag.show();

    for (var i = 0; i <= 23; i++) {
        $("#" + objid + "T022_0").append("<option value=\"" + i + "\">" + i + "</option>");
    }
    for (var i = 0; i <= 59; i++) {
        $("#" + objid + "T022_1").append("<option value=\"" + i + "\">" + ("0"+i).Right(2) + "</option>");
    }
    //<sycms day="" daycontent="" minute="" minutecontent=""><itme value=\"6-9\">ddd</itme></sycms>
    FirefoxDisabled(objid + 'T01_1View');
    FirefoxDisabled(objid + 'T02_1View');
    if (xml != null) {
        var day = xml.getAttrib("xml/sycms", "name");
        if (day != "") {
            var daycontent = decodeURIComponent(xml.getAttrib("xml/sycms", "daycontent"));
            if (day == "week") {
                $id(objid + "T01_0").checked = true;
                $("#" + objid + "T01_0").trigger("click");
                for (var i = 1; i <= 7; i++) {
                    if (daycontent.indexOf(i) != -1) {
                        $id(objid + "T011_" + i).checked = true;
                    } else {
                        $id(objid + "T011_" + i).checked = false;
                    }
                }
            } else {
                $id(objid + "T01_1").checked = true;
                $("#" + objid + "T01_1").trigger("click");
                if (daycontent) {
                    $id(objid + "T012").value = daycontent;
                }
            }
            var minute = xml.getAttrib("xml/sycms", "minute");
            var minutecontent = decodeURIComponent(xml.getAttrib("xml/sycms", "minutecontent"));
            if (minute) {
                if (minute == "loop") {
                    $id(objid + "T02_0").checked = true;
                    $("#" + objid + "T02_0").trigger("click");
                    if (minutecontent) {
                        $id(objid + "T021").value = minutecontent;
                    }
                    var icount = xml.getNodeslength("xml/sycms/item"); //循环实体
                    if (icount > 0) {
                        for (var i = 0; i < icount; i++) {
                            var x = decodeURIComponent(xml.getAttrib("xml/sycms/item", "value", i + 1));
                            var xx = x.split("-");
                            var x1 = xx[0];
                            var x2 = xx[1];
                            var x3 = decodeURIComponent(xml.getChild("xml/sycms/item", i + 1));
                            $("#" + objid + "T021Div").append("<div value=\"" + x + "," + x3 + "\" style=\"clear:both;\"><span style=\"float:right;padding-right:10px;\"><input type=\"button\" icon=\"icon-time_delete\" onclick=\"$(this).parent().parent().remove();\" value=\"删除\"/></span>" + x1 + "点至" + x2 + "点，每隔" + x3 + "分钟执行一次。</div>").btnForMat();
                        }
                    }
                } else {
                    $id(objid + "T02_1").checked = true;
                    $("#" + objid + "T02_1").trigger("click");
                    if (minutecontent) {
                        var hf = minutecontent.split(":");
                        $("#" + objid + "T022_0").val(hf[0]);
                        $("#" + objid + "T022_1").val(hf[1]);
                    }
                }
            }
        }
    }
    xml.Dispose();
    xml = null;
    jQuery("#" + objid + "T021").slider({ from: min, to: max, step: min, smooth: true, round: 0, dimension: "&nbsp;", skin: "round" });
    jQuery("#" + objid + "T012").slider({ from: 7, to: 120, step: min, smooth: true, round: 0, dimension: "&nbsp;", skin: "round" });
}
function DelAutoTaskFun(objname) {
    $id(objname).value = "";
    $id(objname + "_View").innerHTML = "暂无执行计划";
    $("#" + objname + "_Button").btn().disable();

}
function AutoTaskChildFun(obj, objview, min, max) {
    var objid = obj.id;
    var H = parseInt(AutoTaskChildFunHtml[2]);
    if (H + 90 > Wh) {
        H = Wh - 90;
    }
    var diag = new Dialog();
    diag.Width = AutoTaskChildFunHtml[1];
    diag.Height = H;
    diag.Title = AutoTaskChildFunHtml[0];
    diag.InnerHtml = ReplaceRegExpValue(AutoTaskChildFunHtml[4].replace(/\$\$/g, objid), H);
    diag.OKEvent = function () {
        var x1 = $("#" + objid + "T1").val();
        var x2 = $("#" + objid + "T2").val();
        var x3 = $("#" + objid + "T3").val();
        if (Math.round(x1) <= Math.round(x2)) {
            $("#" + objview).append("<div value=\"" + x1 + "-" + x2 + "," + x3 + "\" style=\"clear:both;\"><span style=\"float:right;padding-right:10px;\"><input type=\"button\" icon=\"icon-time_delete\" onclick=\"$(this).parent().parent().remove();\" value=\"删除\"/></span>" + x1 + "点至" + x2 + "点，每隔" + x3 + "分钟执行一次。</div>").btnForMat();
            diag.close();
        }
    };                    //点击确定后调用的方法
    diag.show();
    for (var i = 0; i <= 23; i++) {
        $("#" + objid + "T1").append("<option value=\"" + i + "\">" + i + "</option>");
        $("#" + objid + "T2").append("<option value=\"" + i + "\">" + i + "</option>");
    }
    jQuery("#" + objid + "T3").slider({ from: min, to: max, step: 1, smooth: true, round: 0, dimension: "&nbsp;", skin: "round" });
}
//自动更新版本
function AutoInstallVersion(str) {
    AjaxFun("System/Update/Version.aspx", "SyContent=" + str);
}
//生成模板的样式信息，出现提示，防止太时间长的等等。
function CreateTemCss(TemID,Action,RunOkFunction) {
    setTimeout(function () { CreateTemCssNe(TemID, null, Action, RunOkFunction); }, (ErrViewTime - 1) * 1000);
}
function CreateTemCssNe(TemID, NoCreate, Action, RunOkFunction, TemCreateMess, Num) {
    if (TemID) {
        var ArrTemID = TemID.split(",");
        TemID = ArrTemID[0];
        if (NoCreate != 1) {
            Num = ArrTemID.length;
            TemCreateMess = new Dialog();
            TemCreateMess.Title = "";
            TemCreateMess.Width = 500;
            TemCreateMess.Height = 60;
            TemCreateMess.Drag = false;
            TemCreateMess.InnerHtml = '<table height="100%" width="100%" border="0" align="center" cellpadding="10" cellspacing="0">\
		    <tr><td align="right" width="40"><img src="' + IMAGESPATH + 'icon_alert.png" width="32" height="32" align="absmiddle"></td>\
			    <td align="left" style="font-size:9pt"><div style="width:550px;"><div style="float:right;width:290px;"><div style="text-align:left;width:250px;" align="left" id="UpdateSycms_View"></div></div><div style="float:left;">生成模板样式，请稍候......</div></div><div style="clear:left;height:20px;width:550px;" id="Createspaceused1">样式发生改变，生成相关联的模板样式，还有<font color=red>' + ArrTemID.length + '[' + Num + ']</font>个要生成。</div></td></tr>\
	        </table>';
            TemCreateMess.show();
            $("#UpdateSycms_View").progressBar(0);
        }
        ArrTemID = ArrTemID.slice(0, 0).concat(ArrTemID.slice(0 + 1));
        AjaxFun("Tem/List/Modi_Cancel.aspx", Action + "&id=" + TemID, null, function () {
            if (ArrTemID.length > 0) {
                CreateTemCssNe(ArrTemID.join(","), 1, Action, RunOkFunction, TemCreateMess, Num);
                $("#UpdateSycms_View").progressBar((Num - ArrTemID.length) * 100 / Num);
                $("#Createspaceused1").html("样式发生改变，生成相关联的模板样式，还有<font color=red>" + ArrTemID.length + "[" + Num + "]</font>个要生成。");
            } else {
                if (RunOkFunction) {
                    (RunOkFunction)();
                }
                TemCreateMess.close();
                TemCreateMess = null;
            }
        });
    }
}
///安装插件
function InstallPlus(PlusString) {
    AjaxFun('Plus/Management/Lists_InsertReady.aspx', 'PlusString=' + encodeURIComponent(PlusString), "正在读取未安装的插件信息。");
}
//关联生成
function AssociateClassID(Url,action) {
    var objvalue = $('#CategorySpecialAssociateClassID').val();
    if (objvalue.length > 0) {
        AjaxFun(Url, 'ClassID=' + encodeURIComponent(objvalue) + (action ? "&" + action : ""), "正在读取栏目信息。", function (html) {
            if (html) {
                $("#CategorySpecialAssociate").append(html);
            }
        });
    }
}

//表单的
function FormListSearch(FormName, GridName) {
    if (AddReturnValidationEngine("#" + FormName)) {
        $(GridName).flexReload(ReadInputValue(FormName));
    } else {
        setTimeout(function () { $.validationEngine.closePrompt('.formError', true) }, 2000);
    }
}
function FormLayoutFieldFun(diag, modelID) {
    var objList = $("#_DialogTable_" + diag.ID);
    var str1 = "";
    var str2 = new Array();
    str2.push("<fields>");
    var divTh = objList.find("div.hDivBox");
    var thList = divTh.find("tr>th:visible");
    thList.each(function () {
        var obj = $(this);
        if (this.Field) {
            var objd = obj.find("div");
            if (obj.hasClass("sorted")) {
                str1 = "<order by=\"" + objd.attr("class").replace("sdesc", "desc").replace("sasc", "asc") + "\">" + this.Field + "</order>";
            }
            if (this.Field != "0") {
                str2.push("<field width=\"" + objd.width() + "\" autosize=\"" + (this.autoSize ? "1" : "0") + "\">" + this.Field + "</field>");
            }
        }
    });
    str2.push("</fields>");
    AjaxFun("System/UniversalFrom/Layout_Field.aspx", 'action=save&modelID=' + encodeURIComponent(modelID) + "&content=" + encodeURIComponent(str1 + str2.join("")), "正在读取栏目信息。");
    diag.close();
}
///插件管理
function Menu_FormFun(obj, str) {
    var xml = null;
    if (str) {
        xml = new XML();
        xml.SetXML("<?xml version='1.0' encoding='utf-8'?><xml>" + str + "</xml>");
    }
    var H = parseInt(FormFunHtml[2]);
    if (H + 90 > Wh) {
        H = Wh - 90;
    }
    var objid = obj.id;
    var diag = new Dialog();
    diag.Width = FormFunHtml[1];
    diag.Height = H;
    diag.Title = FormFunHtml[0];
    diag.InnerHtml = ReplaceRegExpValue(FormFunHtml[4].replace(/\$\$/g, objid), H);
    diag.OKEvent = function () {
        var SelectObj = $("#" + objid + "TT001");
        var SelectWebType = $("#" + objid + "TT002");
        var Selectlanguage = $("#" + objid + "TT003");
        var FormPath = SelectObj.val();
        if (FormPath != "") {
            i = parseInt(FormPath);
            var xml2 = new XML();
            xml2.SetXML("<?xml version=\"1.0\" encoding=\"utf-8\"?><xml><sycms type=\"Form\" name=\"" + FormList[i][0] + "\"></sycms></xml>");
            xml2.setAttrib("xml/sycms", "path", FormList[i][1]);
            xml2.setAttrib("xml/sycms", "formtype", SelectWebType.val());
            xml2.setAttrib("xml/sycms", "language", Selectlanguage.val());
            InsertAtCaret(obj, xml2.GetString("xml/sycms"));
        }
        diag.close();
    };               //点击确定后调用的方法
    diag.show();
    var path="";
    var webform = "";
    var language = "";
    if (xml) {
        path = xml.getAttrib("xml/sycms", "path");
        webform = xml.getAttrib("xml/sycms", "formtype");
        language = xml.getAttrib("xml/sycms", "language");
    }
    var SelectWebType = $("#" + objid + "TT002");
    SelectWebType.append("<option value=\"Add\">提交表单</option>");
    SelectWebTypeOption = SelectWebType.find("option");
    var SelectObj = $("#" + objid + "TT001");
    SelectObj.append("<option value=\"\">请选择</option>");
    for (var i = 0; i < FormList.length; i++) {
        SelectObj.append("<option value=\"" + i + "\"" + (path == FormList[i][1] ? " selected=\"selected\"" : "") + ">" + FormList[i][0] + "</option>");
        if (path == FormList[i][1]) {
            SelectWebTypeOption.attr("display", "display");
            for (var i1 = 0; i1 < FormList[i][2].length; i1++) {
                if (FormList[i][2][i1] == SelectWebTypeOption.eq(i).attr("value")) {
                    SelectWebTypeOption.eq(i1).reveAttr("display");
                    if (FormList[i][2][i1] == webform) {
                        SelectWebTypeOption.eq(i1).attr("selected", "selected");
                    }
                }
            }
        }
    }
    SelectObj.bind("change", function () {
        SelectWebTypeOption.attr("display", "display");
        SelectWebTypeOption.removeAttr("selected");
        if ($(this).val() != "") {
            var id = parseInt($(this).val());
            for (var i = 0; i < FormList[id][2].length; i++) {
                if (FormList[id][2][i] == SelectWebTypeOption.eq(i).attr("value")) {
                    SelectWebTypeOption.eq(i).reveAttr("display");
                }
            }
        }
    });
    AjaxFun("AdminFun/FromSubmitLanguage.aspx", null, "正在读取语言支持包", function (html) {
        $("#" + objid + "TT003").html(html).val(language);
    });
}
//采集-功能
function Acquisition_MainFun(ID, XmlValue) {
    var Add_AcquisitionDIV;
    var Acquisition_0DIV;
    var Acquisition_1DIV;
    var AjaxFunWindow = null;
    var Acquisition_ListObj;
    var Acquisition_PageObj;
    var Acquisition_ContentObj;
    var Acquisition_ContentPageObj;
    var htmlbody;
    var sycms_HTMLDIV = "<div id=\"$SyCms$\" style=\"border:1px solid #96D9F9;overflow:hidden;position:absolute;top:0px;left:0px;filter:alpha(opacity=70);background: rgba(#colorrgb#, 0.7) !important;background:#color#\"></div>";
    var htmliframe;
    var divList;
    var Sycms_Content;
    var Add_AcquisitionValue;
    var Sycms_Html = new Array();
    var LoadListFunction = function () {
        var AjaxFunWindow = LoadWarting("", "正在调入，请稍候......", "", "");
        var siteTime = null;
        Add_AcquisitionDIV.find("#SycmsHtmlWinIframe").attr("src", "System/Acquisition/Lists_View.aspx?" + ReadInputValue("Add_Acquisition", null, null, true)).unbind().bind("load", function () {
            $(this).unbind("load");
            if (siteTime != null) {
                clearTimeout(siteTime);
                siteTime = null;
            }
            Acquisition_LoadSycmsHtml(this, Add_AcquisitionDIV, true);
            LoadOldListFunction("lists", "0");
            LoadOldListFunction("page", "1");
            AjaxFunWindow.close();
        });
        siteTime = setTimeout(function () {
            Add_AcquisitionDIV.find("#SycmsHtmlWinIframe").unbind("load");
            Acquisition_LoadSycmsHtml(Add_AcquisitionDIV.find("#SycmsHtmlWinIframe").get(0), Add_AcquisitionDIV, true);
            LoadOldListFunction("lists", "0");
            LoadOldListFunction("page", "1");
            AjaxFunWindow.close();
        }, 10000);
    };
    var LoadContentFunction = function (IsLoadUrl) {
        var AjaxFunWindow = LoadWarting("", "正在调入，请稍候......", "", "");
        if (ID && IsLoadUrl) {
            AjaxFun("System/Acquisition/Lists_Html.aspx?action=linklist", Add_AcquisitionValue + "&Message=" + encodeURIComponent(GetTextareaValue("0")), "", function () {
                setTimeout(function () { LoadContentFunction_2(AjaxFunWindow); }, 1000);
            });
        } else {
            LoadContentFunction_2(AjaxFunWindow);
        }
    }
    var LoadContentFunction_2 = function (AjaxFunWindow) {
        var siteTime = null;
        Add_AcquisitionDIV.find("#SycmsHtmlWinIframe").attr("src", "System/Acquisition/Lists_View.aspx?" + ReadInputValue("Add_Acquisition", null, null, true) + "&action=content").unbind().bind("load", function () {
            $(this).unbind("load");
            if (siteTime != null) {
                clearTimeout(siteTime);
                siteTime = null;
            }
            Acquisition_LoadSycmsHtml(this, Add_AcquisitionDIV, true);
            LoadOldContentFunction();
            LoadOldListFunction("contentpage", "3");
            AjaxFunWindow.close();
        });
        siteTime = setTimeout(function () {
            Add_AcquisitionDIV.find("#SycmsHtmlWinIframe").unbind("load");
            Acquisition_LoadSycmsHtml(Add_AcquisitionDIV.find("#SycmsHtmlWinIframe").get(0), Add_AcquisitionDIV, true);
            LoadOldContentFunction();
            LoadOldListFunction("contentpage", "3");
            AjaxFunWindow.close();
        }, 10000);
    }
    //调入
    var LoadSelectDiv = function (objp) {
        objp = objp.parent();
        while (objp && objp.attr("id") != "Sycms_Content") {
            var objimg = objp.find("img:first");
            if (objimg.attr("src").indexOf("add.") != -1) {
                objimg.trigger("click");
            }
            objp = objp.parent();
        }
    }
    //内容的调入
    var LoadOldContentFunction = function () {
        var value = GetTextareaValue("2");
        if (value && value.length > 0) {
            var xml = new XML();
            xml.SetXML(value);
            var save = false;
            var inodecount = xml.getNodeslength("fields/field");
            for (var i = 0; i < inodecount; i++) {
                if (LoadOldFunction(xml.getNodeIndex("fields/field", i + 1), xml, "2") == false) {
                    xml.delNode("fields/field", i + 1);
                    inodecount--;
                    i--;
                    save = true;
                }
            }
            if (save) {
                var Value = xml.GetString("fields/field");
                if (Value.length > 0) {
                    Value = "<fields>" + Value + "</fields>";
                }
                Acquisition_ContentObj.val(encodeURIComponent(Value));
            }
            xml.Dispose();
        }
    }
    //列表，分页，内容分页调入
    var LoadOldListFunction = function (nodeName, TypeValue) {
        var value = GetTextareaValue(TypeValue);
        var save = false;
        if (value && value.length > 0) {
            var xml = new XML();
            xml.SetXML(value);
            if (LoadOldFunction(nodeName, xml, TypeValue) == false) {
                save = true;
            }
            xml.Dispose();
            if (save) {
                switch (TypeValue) {
                    case "0":
                        {
                            Dialog.confirm("未找到" + SetSycmsHtml(TypeValue) + "标识信息，是否清除重新选择？", function () {
                                Acquisition_ListObj.val("");
                            });
                            break;
                        }
                    case "1":
                        {
                            Dialog.confirm("未找到" + SetSycmsHtml(TypeValue) + "标识信息，是否清除重新选择？", function () {
                                Acquisition_PageObj.val("");
                            });
                            break;
                        }
                    case "3":
                        {
                            Dialog.confirm("未找到" + SetSycmsHtml(TypeValue) + "标识信息，是否清除重新选择？", function () {
                                Acquisition_ContentPageObj.val("");
                            });
                            break;
                        }
                }
            }
        }
    }
    //解释xml函数
    var LoadOldFunction = function (nodeName, xml, TypeValue) {
        var inodecount = xml.getNodeslength(nodeName + "/option");
        var tagname = "";
        var tagmessage = "";
        var num = 0;
        var all = "";
        var objfile = htmlbody;
        var findvalue = true;
        for (var i = inodecount - 1; i >= 0; i--) {
            tagname = xml.getAttrib(nodeName + "/option", "tagname", i + 1);
            num = xml.getAttrib(nodeName + "/option", "num", i + 1);
            all = xml.getAttrib(nodeName + "/option", "all", i + 1);
            tagmessage = xml.getChild(nodeName + "/option", i + 1);
            if (tagmessage) {
                tagmessage = "[" + tagmessage.split("\"").join("'") + "]";
            } else {
                tagmessage = "";
            }
            if (i == 0) {
                if (all == "1") {//无内容事
                    objfile.find(tagname + tagmessage).each(function (index) {
                        var sycms = $(this).attr("sycms");
                        if (sycms) {
                            var idname = sycms.replace("sycms_sycms_", "sycms_");
                            var objp = divList.filter("#" + idname);
                            var objthis = objp.find("span.sycmshtml:first");
                            DivSelect(objthis, objp, $(this), TypeValue);
                            if (index == 0) {
                                LoadSelectDiv(objp);
                            }
                        }
                    });
                } else {
                    objfile = objfile.find(tagname + tagmessage + ":eq(" + num + ")");
                    var sycms = objfile.attr("sycms");
                    if (sycms) {
                        var idname = sycms.replace("sycms_sycms_", "sycms_");
                        var objp = divList.filter("#" + idname);
                        var objthis = objp.find("span.sycmshtml:first");
                        DivSelect(objthis, objp, objfile, TypeValue);
                        LoadSelectDiv(objp);
                        if (TypeValue == "2") {
                            var valuenodecount = xml.getNodeslength(nodeName + "/value");
                            var FieldName = new Array();
                            for (var i1 = 0; i1 < valuenodecount; i1++) {
                                FieldName.push(xml.getAttrib(nodeName + "/value", "name", i1 + 1));
                            }
                            objp.attr("fieldname", FieldName.join(","));
                            DivSelectSetValue(objp, TypeValue);
                        }
                    }
                }
            } else {
                objfile = objfile.find(tagname + tagmessage + ":eq(" + num + ")");
            }
            if (!objfile || objfile.length == 0) {
                findvalue = false;
                break;
            }
        }
        return findvalue;
    }
    CreateWindow('System/Acquisition/' + (ID ? "Modi.aspx?ID=" + ID : "Add.aspx"), (ID ? '修改内容采集' : '添加内容采集'), function (CreateWindowdiag) {
        CreateWindowdiag.otherButton[0].style.display = "";
        if (ID) {
            CreateWindowdiag.otherButton[1].style.display = "none";
            CreateWindowdiag.otherButton[2].style.display = "none";
        }
        if (CreateWindowdiag.okButton.value == "确定") {
            AjaxFun("System/Acquisition/" + (ID ? "Modi.aspx?ID=" + ID + "&action=save" : "Add.aspx?action=save"), ReadInputValue("Add_Acquisition"), " ", function () {
                CreateWindowdiag.close();
            });
        } else {
            if (Acquisition_0DIV.get(0).style.display != "none") {
                Acquisition_0DIV.hide();
                Acquisition_1DIV.show();
                CreateWindowdiag.setSize(Ww - 15, Wh - 75);
                Acquisition_1DIV.html("<table width=\"100%\"><tr><td valign=\"top\"><iframe src=\"System/Acquisition/Lists_View.aspx\" id=\"SycmsHtmlWinIframe\" style=\"border:0px;width:100%;height:" + (Wh - 100) + "px;\" width=\"100%\"></iframe></td><td valign=\"top\" style=\"width:400px;\"><div><textarea id=\"Acquisition_List\" name=\"Acquisition_List\" style=\"display:none;\"></textarea><textarea id=\"Acquisition_Page\" name=\"Acquisition_Page\" style=\"display:none;\"></textarea><textarea id=\"Acquisition_Content\" name=\"Acquisition_Content\" style=\"display:none;\"></textarea><textarea id=\"Acquisition_ContentPage\" name=\"Acquisition_ContentPage\" style=\"display:none;\"></textarea><span id=\"AcquisitionType_0Span\"><input type=\"radio\" checked=\"checked\" value=\"0\" name=\"AcquisitionType\" id=\"AcquisitionType_0\"/><label for=\"AcquisitionType_0\">列表</label></span><span id=\"AcquisitionType_1Span\"><input type=\"radio\" value=\"1\" name=\"AcquisitionType\" id=\"AcquisitionType_1\"/><label for=\"AcquisitionType_1\">分页</label></span><span id=\"AcquisitionType_2Span\" style=\"display:none;\"><select style=\"width:300px;\" name=\"AcquisitionContentUrl\" id=\"AcquisitionContentUrl\"></select><input type=\"radio\" value=\"2\" name=\"AcquisitionType\" id=\"AcquisitionType_2\"/><label for=\"AcquisitionType_2\">内容</label></span><span id=\"AcquisitionType_3Span\" style=\"display:none;\"><input type=\"radio\" value=\"3\" name=\"AcquisitionType\" id=\"AcquisitionType_3\"/><label for=\"AcquisitionType_3\">分页</label></span><hr/></div><div id=\"Sycms_Content\" class=\"Sycms_Content\" style=\"height:" + (Wh - 120) + "px;overflow:hidden;overflow-y:auto;word-break:break-all;text-align:left;\"></div></td></tr></table>");
                Acquisition_ListObj = Add_AcquisitionDIV.find("#Acquisition_List");
                Acquisition_PageObj = Add_AcquisitionDIV.find("#Acquisition_Page");
                Acquisition_ContentObj = Add_AcquisitionDIV.find("#Acquisition_Content");
                Acquisition_ContentPageObj = Add_AcquisitionDIV.find("#Acquisition_ContentPage");

                if (XmlValue) {
                    var xml = new XML();
                    xml.SetXML("<xml>" + decodeURIComponent(XmlValue) + "</xml>");
                    Acquisition_ListObj.val(encodeURIComponent(xml.GetString("xml/lists")));
                    Acquisition_PageObj.val(encodeURIComponent(xml.GetString("xml/page")));
                    Acquisition_ContentObj.val(encodeURIComponent(xml.GetString("xml/fields")));
                    Acquisition_ContentPageObj.val(encodeURIComponent(xml.GetString("xml/contentpage")));
                    xml.Dispose();
                }
                Sycms_Content = Add_AcquisitionDIV.find("#Sycms_Content");
                $("#AcquisitionContentUrl").unbind().bind("change", function () {
                    LoadContentFunction();
                })
                LoadListFunction();
            } else if (Acquisition_1DIV.get(0).style.display != "none") {
                var Acquisition_List = GetTextareaValue("0");
                if (Acquisition_List.length > 0) {
                    $("#AcquisitionType_0Span").hide();
                    $("#AcquisitionType_1Span").hide();
                    $("#AcquisitionType_2Span").show();
                    $("#AcquisitionType_2").attr("checked", "checked");
                    $("#AcquisitionType_3Span").show();
                    LoadContentFunction($("#AcquisitionContentUrl").find("option").length == 0);
                    CreateWindowdiag.okButton.value = "确定";
                } else {
                    Dialog.error("错误：请选择[列表]项选择。");
                }
            }
        }
    }, 500, 290, "Add_Acquisition", { Name: '上一步', Url: function (CreateWindowdiag) {
        if ($("#AcquisitionType_2Span").get(0).style.display != "none") {
            CreateWindowdiag.okButton.value = "下一步";
            LoadListFunction();
            $("#AcquisitionType_0Span").show();
            $("#AcquisitionType_1Span").show();
            $("#AcquisitionType_2Span").hide();
            $("#AcquisitionType_0").attr("checked", "checked");
            $("#AcquisitionType_3Span").hide();

        } else if (Acquisition_1DIV.get(0).style.display != "none") {
            Acquisition_0DIV.show();
            Acquisition_1DIV.hide();
            CreateWindowdiag.setSize(500, 290);
            CreateWindowdiag.otherButton[0].style.display = "none";
            Add_AcquisitionDIV.find("textarea").each(function () {
                this.value = "";
            });
        }
    }
    }, null, null, null, function (CreateWindowdiag) {
        CreateWindowdiag.otherButton[0].style.display = "none";
        CreateWindowdiag.okButton.value = "下一步";
        Add_AcquisitionDIV = $("#Add_Acquisition");
        Acquisition_0DIV = $("#Acquisition_0");
        Acquisition_1DIV = $("#Acquisition_1");
        if (ID) {
            CreateWindowdiag.addButton("modisave", "确定", function () {
                AjaxFun("System/Acquisition/Modi.aspx?ID=" + ID + "&action=save&Type=1", ReadInputValue("Add_Acquisition"), " ", function () {
                    CreateWindowdiag.close();
                });
            });
            CreateWindowdiag.addButton("addsave", "另存为", function () {
                AjaxFun("System/Acquisition/Add.aspx?ID=" + ID + "&action=save", ReadInputValue("Add_Acquisition"), " ", function () {
                    CreateWindowdiag.close();
                });
            });
        }
    });
    var Acquisition_topleft = function (obj) {
        var wz = getElCoordinate(obj.get(0));
        obj.children(":visible").each(function () {
            var wz1 = getElCoordinate(this);
            if (wz1.top + wz1.height > wz.top + wz.height) {
                wz.height = wz1.top + wz1.height - wz.top;
            }
            if (wz1.left + wz1.width > wz.left + wz.width) {
                wz.width = wz1.left + wz1.width - wz.left;
            }
        });
        return wz;
    }
    var Acquisition_LoadSycmsHtml = function (objIframe, Add_AcquisitionDIV, IsFrame) {
        Add_AcquisitionValue = ReadInputValue("Add_Acquisition");
        if (IsFrame) {
            htmlbody = $(objIframe.contentWindow.document.body);
            htmliframe = $(objIframe.contentWindow);
        }
        htmlbody.find("a").bind("click", function () {
            return false;
        });
        Sycms_Html = new Array();
        if (htmlbody && htmlbody.length == 1) {
            htmlbody.delegate(".Sycms_List", "mouseover", function () {
                var id = this.id;
            });
            var children = htmlbody.children(":visible");
            var childrencount = children.length;
            for (var i1 = 0; i1 < childrencount; i1++) {
                Acquisition_HtmlMessage(children.eq(i1), 0, "sycms_" + i1, "", "body");
            }
            Sycms_Content.html(Sycms_Html.join(""));
            htmlbody.append(sycms_HTMLDIV.replace("$SyCms$", "Sycms_Containers_Create").replace("#color#", "#96D9F9").replace("#colorrgb#", "150,217,249"));
            Sycms_Containers_Create = htmlbody.find("#Sycms_Containers_Create");

            divList = Sycms_Content.find("div");
            divList.find("span.sycmshtml").bind("mouseover", function () {
                var objp = $(this).parent();
                $(this).addClass("overselect");
                var name = objp.attr("name");
                if (name) {
                    var obj = htmlbody.find(decodeURIComponent(name));
                    if (obj && obj.length == 1) {
                        var wzobj = Acquisition_topleft(obj);
                        var IframeTop = htmliframe.scrollTop();
                        if (wzobj.top > IframeTop || IframeTop > wzobj.top) {
                            htmliframe.scrollTop(wzobj.top - 50);
                        }
                        Sycms_Containers_Create.css({ "top": wzobj.top, "left": wzobj.left, "width": wzobj.width, "height": wzobj.height }).show();
                    }
                }
            }).bind("mouseout", function () {
                $(this).removeClass("overselect");
                Sycms_Containers_Create.hide();
            }).bind("click", function () {
                var objthis = $(this);
                var objp = objthis.parent();
                var name = objp.attr("name");
                if (name) {
                    name = decodeURIComponent(name);
                    var notableTagname = "|tbody|thead|tfoot|";
                    if (notableTagname.indexOf("|" + name.split('[')[0] + "|") == -1) {
                        var obj = htmlbody.find(decodeURIComponent(name));
                        if (obj && obj.length == 1) {
                            var TypeValue = ReadAcqTypeValue();
                            Add_AcquisitionValue = ReadInputValue("Add_Acquisition");
                            if (objp.attr("isdic") || !ParentPathIsExit(objp)) {
                                var Acquisition_Value = GetAcqTypeinputValue(TypeValue).value;
                                var DivMessage = ReadDivMessage(obj, objp, TypeValue);
                                var FieldName = objp.attr("fieldname");
                                if (!objp.attr("isdic")) {
                                    if (Acquisition_Value.length > 0) {
                                        if (TypeValue == "2") {
                                            if (FieldName && FieldName.length > 0) {
                                                var FieldNameArr = FieldName.split(",");
                                                var FieldNameString = "<ul><li><input type=\"radio\" checked=\"checked\" value=\"\" name=\"Acquisition_Content\" id=\"Acquisition_Content_\"/><label for=\"Acquisition_Content_\">新增</label></li>";
                                                for (var i = 0; i < FieldNameArr.length; i++) {
                                                    FieldNameString += "<li><input type=\"radio\" value=\"" + FieldNameArr[i] + "\" name=\"Acquisition_Content\" id=\"Acquisition_Content_" + i + "\"/><label for=\"Acquisition_Content_" + i + "\">【" + decodeURIComponent(FieldNameArr[i]) + "】</label></li>";
                                                }
                                                FieldNameString += "</ul>";
                                                Dialog.confirm("已经存在" + SetSycmsHtml(TypeValue) + "的功能选择。" + FieldNameString, function () {
                                                    DivClickFun(objthis, objp, obj, TypeValue, DivMessage, $("input[name='Acquisition_Content']:checked").val());
                                                }, null, 300, 100, "确定", "取消", "移除", function (WinDiag) {
                                                    var objvalue = $("input[name='Acquisition_Content']:checked").val();
                                                    if (objvalue.length > 0) {
                                                        RemoveAllSelect(obj, objp, TypeValue, DivMessage, objvalue);
                                                    }
                                                    WinDiag.close();
                                                });
                                            } else {
                                                DivClickFun(objthis, objp, obj, TypeValue, DivMessage, "");
                                            }
                                        } else {
                                            Dialog.confirm("已经存在" + SetSycmsHtml(TypeValue) + "的功能选择。", function () {
                                                OtherRemoveAllSelect(TypeValue, DivMessage, "");
                                                DivClickFun(objthis, objp, obj, TypeValue, DivMessage);
                                            }, null, 300, 50, "替换", "取消");
                                        }
                                    } else {
                                        DivClickFun(objthis, objp, obj, TypeValue, DivMessage, "");
                                    }
                                } else {
                                    if (Acquisition_Value.length > 0) {
                                        if (TypeValue == "2") {
                                            if (FieldName && FieldName.length > 0) {
                                                var FieldNameArr = FieldName.split(",");
                                                var FieldNameString = "<ul><li><input type=\"radio\" checked=\"checked\" value=\"\" name=\"Acquisition_Content\" id=\"Acquisition_Content_\"/><label for=\"Acquisition_Content_\">新增</label></li>";
                                                for (var i = 0; i < FieldNameArr.length; i++) {
                                                    FieldNameString += "<li><input type=\"radio\" value=\"" + FieldNameArr[i] + "\" name=\"Acquisition_Content\" id=\"Acquisition_Content_" + i + "\"/><label for=\"Acquisition_Content_" + i + "\">" + decodeURIComponent(FieldNameArr[i]) + "</label></li>";
                                                }
                                                FieldNameString += "</ul>";
                                                Dialog.confirm("当前为" + SetSycmsHtml(TypeValue) + "的功能选择。" + FieldNameString, function () {
                                                    DivClickFun(objthis, objp, obj, objp.attr("isdic"), DivMessage, $("input[name='Acquisition_Content']:checked").val());
                                                }, null, 300, 100, "确定", "取消", "移除", function (WinDiag) {
                                                    var objvalue = $("input[name='Acquisition_Content']:checked").val();
                                                    if (objvalue.length > 0) {
                                                        RemoveAllSelect(obj, objp, TypeValue, DivMessage, objvalue);
                                                    }
                                                    WinDiag.close();
                                                });
                                            } else {
                                                DivClickFun(objthis, objp, obj, TypeValue, DivMessage, "");
                                            }
                                        } else {
                                            Dialog.confirm("当前为" + SetSycmsHtml(TypeValue) + "的功能选择。", function () {
                                                DivClickFun(objthis, objp, obj, objp.attr("isdic"), DivMessage, "");
                                            }, null, 300, 50, "修改", "取消", "移除", function (WinDiag) {
                                                RemoveAllSelect(obj, objp, TypeValue, DivMessage);
                                                WinDiag.close();
                                            });
                                        }
                                    } else {
                                        DivClickFun(objthis, objp, obj, TypeValue, DivMessage, "");
                                    }
                                }
                            }
                        }
                    } else {
                        Dialog.error("不要单击，以下标签，因为有可能不存在，请选择其它的。" + notableTagname);
                    }
                }
                return false;
            });
            divList.find("img").bind("click", function () {
                var obj = $(this);
                var id = obj.parent().parent().parent().attr("id");
                if (id) {
                    var src = obj.attr("src")
                    if (src.indexOf("add.") != -1) {
                        divList.filter("." + id).show();
                        obj.attr("src", src.replace("add.", "rem."));
                    } else if (src.indexOf("rem.") != -1) {
                        divList.filter("div." + id).hide();
                        obj.attr("src", src.replace("rem.", "add."));
                    }
                }
                return false;
            });
        }
    }
    //显示结构
    var Acquisition_HtmlMessage = function (obj, depth, idname, clssname, ParentTagName) {
        var tagname = ReadtagName(obj);
        var str = "";
        var noindex = "|meta|link|style|title|base|iframe|noscript|script|br|input|hr|";
        if (noindex.indexOf("|" + tagname + "|") == -1) {
            var children = obj.children(":visible");
            var childrencount = children.length;
            obj.attr("sycms", "sycms_" + idname);
            var id = obj.attr("id");
            var classStr = obj.attr("class");

            str = "<div sycms=\"\" name=\"" + encodeURIComponent(tagname + "[sycms='" + "sycms_" + idname + "']") + "\" id=\"" + idname + "\"" + (clssname.length > 0 ? " class=\"" + clssname + "\"" : "") + (depth == 0 ? "" : " style=\"display:none;\"") + "><span class=\"sycmshtml\"><span style=\"float:left;\">" + Acquisition_Html_depth("&nbsp;&nbsp;", depth) + "</span><span class=\"imgadd\">" + (childrencount > 0 ? "<img src=\"images/Acquisition/add.png\" align=\"absmiddle\" />" : "&nbsp;") + "</span><span>&lt;<span class=\"blue\">" + tagname + "</span></span>";
            if (id && id.length > 0) {
                str += " id=\"<span class=\"red\">" + id + "\"</span>";
            }
            if (classStr && classStr.length > 0) {
                str += " class=\"<span class=\"red\">" + classStr + "\"</span>";
            }
            str += "&gt;";
            if (tagname == "a") {
                var href = obj.attr("href");
                if (href) {
                    str += href;
                }
            } else if (tagname == "img") {
                var src = obj.attr("src");
                if (src) {
                    str += src
                }
            }
            str += "</span><span class=\"htmlalt\">[列表]</span>";
            Sycms_Html.push(str);
            if (childrencount > 0) {
                for (var i1 = 0; i1 < childrencount; i1++) {
                    Acquisition_HtmlMessage(children.eq(i1), depth + 2, idname + "_" + i1, idname, ParentTagName + ">" + tagname);
                }
            }
            Sycms_Html.push("</div>");
        }
    }
    //循环输出一个字符串
    var Acquisition_Html_depth = function (string, depth) {
        var DepthArr = new Array();
        for (var i1 = 0; i1 < depth; i1++) {
            DepthArr.push(string);
        }
        return DepthArr.join("");
    }
    var ReadDivMessage2 = function (name, value, obj, objp, TypeValue, i) {
        var AttrName = "";
        var AttrValue = "";
        if (name && name.length > 0) {
            AttrName = name;
            AttrValue = value;
        }
        var wz = 0;
        var allnum = 1;
        var Acq_List_All = 0;
        var IdList = obj.prev();
        var objp1 = objp.prev();
        var bo = false;
        var allfalse = false;
        var DivSelectArray = new Array();
        while (IdList && IdList.length > 0) {
            bo = false;
            if (name && name.length > 0) {
                if (IdList.attr(name) == value) {
                    bo = true;
                }
            } else {
                if (ReadtagName(IdList) == value) {
                    bo = true;
                }
            }
            if (bo) {
                if (objp1.attr("isdic")) {
                    allfalse = true;
                }
                wz++;
                allnum++;
                if (i == 0) {
                    DivSelectArray.push({ objp: objp1, obj1: IdList });
                }
            }
            IdList = IdList.prev();
            objp1 = objp1.prev();
        }
        var IdList = obj.next();
        if (wz > 0 || (name && name.length > 0 && IdList && IdList.attr(name) == value)) {
            Acq_List_All = 1;
        }
        var objp1 = objp.next();
        while (IdList && IdList.length > 0) {
            bo = false;
            if (name && name.length > 0) {
                if (IdList.attr(name) == value) {
                    bo = true;
                }
            } else {
                if (ReadtagName(IdList) == value) {
                    bo = true;
                }
            }
            if (bo) {
                if (objp1.attr("isdic")) {
                    allfalse = true;
                }
                allnum++;
                if (i == 0) {
                    DivSelectArray.push({ objp: objp1, obj1: IdList });
                }
                if (Acq_List_All != 1) {
                    Acq_List_All = 1;
                }
            }
            IdList = IdList.next();
            objp1 = objp1.next();
        }
        var jx = 0;
        if (name && name.length > 0) {
            var findnum = htmlbody.find(ReadtagName(obj) + "[" + name + "='" + value + "'" + "]");
            if (findnum && findnum.length != 0 && findnum.length != allnum) {
                jx = 1;
            }
        }
        if (allfalse) {
            Acq_List_All = 0;
        } else {
            if (i == 0 && objp.attr("isdic")) {

            } else {
                for (var i1 = 0; i1 < DivSelectArray.length; i1++) {
                    DivSelect(DivSelectArray[i1].objp.find("span.sycmshtml:first"), DivSelectArray[i1].objp, DivSelectArray[i1].obj1, TypeValue);
                }
            }
        }
        return { wz: wz, all: (i == 0 ? Acq_List_All : 0), AttrName: AttrName, AttrValue: AttrValue, jx: jx };
    }
    ///获得信息
    var ReadDivMessage = function (obj, objp, TypeValue) {
        var wz = 0;
        var Acq_List_All = 0;
        var ObjOtherMessage = "";
        var ObjTagName = ReadtagName(obj);
        var ArrayDivMessage = new Array();
        var notableTagname = "|tbody|thead|tfoot|center|b|br|";
        for (var i = 0; i < 30 && obj && ObjTagName != "body"; i++) {
            var id = obj.attr("id");
            var classStr = obj.attr("class");
            if (id && id.length > 0) {
                if (notableTagname.indexOf("|" + ObjTagName + "|") == -1) {
                    var message = ReadDivMessage2("id", id, obj, objp, TypeValue, i);
                    ArrayDivMessage.push({ wz: message.wz, all: message.all, tagname: ObjTagName, AttrName: message.AttrName, AttrValue: message.AttrValue });
                    if (message.jx == 0) {
                        break;
                    }
                }
            } else if (classStr && classStr.length > 0) {
                if (notableTagname.indexOf("|" + ObjTagName + "|") == -1) {
                    var message = ReadDivMessage2("class", classStr, obj, objp, TypeValue, i);
                    ArrayDivMessage.push({ wz: message.wz, all: message.all, tagname: ObjTagName, AttrName: message.AttrName, AttrValue: message.AttrValue });
                    if (message.jx == 0) {
                        break;
                    }
                }
            }
            //} else {
            //    if (notableTagname.indexOf("|" + ObjTagName + "|") == -1) {
            //        var message = ReadDivMessage2(null, ObjTagName, obj, objp, TypeValue, i);
            //        ArrayDivMessage.push({ wz: message.wz, all: message.all, tagname: ObjTagName, AttrName: message.AttrName, AttrValue: message.AttrValue });
            //    }
            //}
            obj = obj.parent();
            if (obj) {
                ObjTagName = ReadtagName(obj);
                var sycmstr = obj.attr("sycms");
                if (sycmstr) {
                    objp = divList.filter("#" + sycmstr.replace("sycms_sycms_", "sycms_"));
                    if (!(objp && objp.length == 1)) {
                        break;
                    }
                } else {
                    break;
                }
            } else {
                break;
            }
        }
        return ArrayDivMessage;
    }
    //事件返回值
    var DivClickFunAction = function (TypeValue) {
        var str = "list";
        switch (TypeValue) {
            case "3":
                {
                    str = "contentpage";
                    break;
                }
            case "2":
                {
                    str = "content";
                    break;
                }
        }
        return str;
    }
    //单击
    var DivClickFun = function (objthis, objp, obj, TypeValue, DivMessage, FieldName) {
        DivSelect(objthis, objp, obj, TypeValue);
        var ListMessage = GetAcqTypeinputValue(TypeValue, DivMessage);
        CreateWindow("System/Acquisition/Lists_Html.aspx?action=" + DivClickFunAction(TypeValue), "设置规则", function (winDiagWin) {
            if (SetAcqTypeinputValue(objp, TypeValue, ListMessage.value, FieldName, DivMessage)) {
                objp.attr("isok", "1");
                AddSelectOK(obj, objp, TypeValue, DivMessage);
                winDiagWin.close();
            }
        }, 800, 600, null, null, null, null, null, function () {
            if (TypeValue == "0") {
                var Acq_List_All = $("#Acq_List_All");
                Acq_List_All.bind("click", function () {
                    if (this.checked) {
                        AddSelect(obj, objp, TypeValue, DivMessage);
                        AjaxFun("System/Acquisition/Lists_Html.aspx?action=link", Add_AcquisitionValue + "&okurl=" + encodeURIComponent($("#Acq_List_RegeOk").val()) + "&nourl=" + encodeURIComponent($("#Acq_List_RegeNo").val()) + "&optionmd5=" + ListMessage.md5 + "&Message=" + encodeURIComponent(ListMessage.value.replace("Acq_List_All", "1")), " ", "#Acq_List_View");
                    } else {
                        RemoveSelect(obj, objp, TypeValue, DivMessage, "");
                        AjaxFun("System/Acquisition/Lists_Html.aspx?action=link", Add_AcquisitionValue + "&okurl=" + encodeURIComponent($("#Acq_List_RegeOk").val()) + "&nourl=" + encodeURIComponent($("#Acq_List_RegeNo").val()) + "&optionmd5=" + ListMessage.md5 + "&Message=" + encodeURIComponent(ListMessage.value.replace("Acq_List_All", "0")), " ", "#Acq_List_View");
                    }
                });
                $("#Acq_List_RegeOk,#Acq_List_RegeNo").bind("blur", function () {
                    AjaxFun("System/Acquisition/Lists_Html.aspx?action=link", Add_AcquisitionValue + "&okurl=" + encodeURIComponent($("#Acq_List_RegeOk").val()) + "&nourl=" + encodeURIComponent($("#Acq_List_RegeNo").val()) + "&optionmd5=" + ListMessage.md5 + "&Message=" + encodeURIComponent(ListMessage.value.replace("Acq_List_All", (Acq_List_All && Acq_List_All.length > 0 && Acq_List_All.get(0).checked ? "1" : "0"))), " ", "#Acq_List_View");
                });
            }
        }, null, null, null, null, null, Add_AcquisitionValue + (FieldName ? "&FieldName=" + FieldName : "") + "&optionmd5=" + ListMessage.md5 + "&Message=" + encodeURIComponent(ListMessage.value.replace("Acq_List_All", DivMessage[0].all)), function () {
            if (objp.attr("isok") != "1") {
                RemoveAllSelect(obj, objp, TypeValue, DivMessage, FieldName);
            }
        });
    }
    ///取的信息值
    var GetTextareaValue = function (TypeValue) {
        var strvalue = "";
        switch (TypeValue) {
            case "0"://列表
                {
                    if (Acquisition_ListObj) {
                        strvalue = decodeURIComponent(Acquisition_ListObj.val());
                    }
                    break;
                }
            case "1"://列表分页
                {
                    if (Acquisition_PageObj) {
                        strvalue = decodeURIComponent(Acquisition_PageObj.val());
                    }
                    break;
                }
            case "2"://内容
                {
                    if (Acquisition_ContentObj) {
                        strvalue = decodeURIComponent(Acquisition_ContentObj.val());
                    }
                    break;
                }
            case "3"://内容分页
                {
                    if (Acquisition_ContentPageObj) {
                        strvalue = decodeURIComponent(Acquisition_ContentPageObj.val());
                    }
                    break;
                }
        }
        return strvalue;
    }
    var GetDivMessage = function (DivMessage, TypeValue) {
        var optionvalue = "";
        var optionvaluemd5 = "";
        for (var i = 0; i < DivMessage.length; i++) {
            optionvalue += "<option num=\"" + DivMessage[i].wz + "\" all=\"" + (i == 0 && (TypeValue == "0" || TypeValue == "3") ? "Acq_List_All" : DivMessage[i].all) + "\" tagname=\"" + DivMessage[i].tagname + "\">" + (DivMessage[i].AttrName.length > 0 ? ("<![CDATA[" + DivMessage[i].AttrName + "=\"" + DivMessage[i].AttrValue + "\"" + "]]>") : "") + "</option>";
            optionvaluemd5 += DivMessage[i].tagname + "sy" + DivMessage[i].AttrName + "cms" + DivMessage[i].AttrValue;
        }
        optionvaluemd5 = $.md5(optionvaluemd5);
        return { option: optionvalue, md5: optionvaluemd5 };
    }
    //取值
    var GetAcqTypeinputValue = function (TypeValue, DivMessage) {
        var strvalue = GetTextareaValue(TypeValue);
        var md5str = "";
        if (DivMessage) {
            var optionvalue = GetDivMessage(DivMessage, TypeValue);
            md5str = optionvalue.md5;
            if (strvalue.length == 0) {
                switch (TypeValue) {
                    case "0":
                        {
                            strvalue = "<lists type=\"" + optionvalue.md5 + "\">" + optionvalue.option + "</lists>";
                            break;
                        }
                    case "1":
                        {
                            strvalue = "<page type=\"" + optionvalue.md5 + "\">" + optionvalue.option + "</page>";
                            break;
                        }
                    case "2":
                        {
                            strvalue = "<fields><field type=\"" + optionvalue.md5 + "\">" + optionvalue.option + "</field></fields>";
                            break;
                        }
                    case "3":
                        {
                            strvalue = "<contentpage type=\"" + optionvalue.md5 + "\">" + optionvalue.option + "</contentpage>";
                        }
                }
            } else if (TypeValue == "2") {
                var xml = new XML();
                xml.SetXML(strvalue);
                if (xml.getNodeslength("fields/field[@type='" + optionvalue.md5 + "']") == 0) {
                    strvalue = "<fields>" + xml.GetString("fields/field") + "<field type=\"" + optionvalue.md5 + "\">" + optionvalue.option + "</field></fields>";
                }
                xml.Dispose();
            }
        }
        return { md5: md5str, value: strvalue };
    }
    ///移除
    var FieldNameReplace = function (FieldName, ReplaceName)
    {
        var FieldNameArray = FieldName.split(",");
        for (var i = 0; i < FieldNameArray.length; i++)
        {
            if (FieldNameArray[i] == ReplaceName)
            {
                FieldName = FieldNameArray.slice(i + 1).join(",");
                break;
            }
        }
        return FieldName;
    }
    //赋值
    var SetAcqTypeinputValue = function (objp, TypeValue, Value, FieldName, DivMessage) {
        switch (TypeValue) {
            case "0":
                {
                    if (Value.length > 0) {
                        var xml = new XML();
                        var Acq_List_All = $("#Acq_List_All");
                        Value = Value.replace("Acq_List_All", ((Acq_List_All && Acq_List_All.length > 0 && Acq_List_All.get(0).checked) ? "1" : "0"));
                        xml.SetXML(Value);
                        var Acq_List_RegeOk = $("#Acq_List_RegeOk").val();
                        xml.delNode("lists/ok");
                        if (Acq_List_RegeOk.length > 0) {
                            xml.InsertBeforeChild("lists", "ok", Acq_List_RegeOk);
                        }
                        var Acq_List_RegeNo = $("#Acq_List_RegeNo").val();
                        xml.delNode("lists/no");
                        if (Acq_List_RegeNo.length > 0) {
                            xml.InsertBeforeChild("lists", "no", Acq_List_RegeNo);
                        }
                        Value = xml.GetString("lists");
                        xml.Dispose();
                    }
                    Acquisition_ListObj.val(encodeURIComponent(Value));
                    break;
                }
            case "1":
                {
                    if (Value.length > 0) {
                        var xml = new XML();
                        xml.SetXML(Value);
                        if ($("#Acq_Page_Type_0").get(0).checked) {
                            xml.delNode("page/create");
                            xml.InsertBeforeChild("page", "create", encodeURIComponent($("#Acq_Page_Url").val()), [{ name: "start", value: encodeURIComponent($("#Acq_Page_Start").val()) }, { name: "end", value: encodeURIComponent($("#Acq_Page_End").val()) }, { name: "num", value: encodeURIComponent($("#Acq_Page_Add").val()) }, { name: "digit", value: encodeURIComponent($("#Acq_Page_Digit").val())}]);
                        }
                        var Acq_Page_UrlList = $("#Acq_Page_UrlList").val();
                        xml.delNode("page/list");
                        if (Acq_Page_UrlList.length > 0) {
                            xml.InsertBeforeChild("page", "list", encodeURIComponent(Acq_Page_UrlList));
                        }
                        Value = xml.GetString("page");
                        xml.Dispose();
                    }
                    Acquisition_PageObj.val(encodeURIComponent(Value));
                    break;
                }
            case "2":
                {
                    var YValue = GetTextareaValue(TypeValue);
                    if (Value.length > 0 && !FieldName) {
                        var xml = new XML();
                        xml.SetXML(Value);
                        var Content_FieldName = $("#Content_FieldName").val();
                        var OldContent_FieldName = $("#OldContent_FieldName").val();
                        if (Content_FieldName.Trim().length == 0) {
                            Dialog.error("字段名称必须填写。", function () { $("#Content_FieldName").focus(); });
                            return false;
                        }
                        var fieldname = objp.attr("fieldname");
                        if (!fieldname) {
                            fieldname = "";
                        }
                        if (OldContent_FieldName && OldContent_FieldName.length > 0) {
                            xml.delNode("fields/field/value[@name='" + encodeURIComponent(OldContent_FieldName) + "']");
                            fieldname = FieldNameReplace(fieldname, encodeURIComponent(OldContent_FieldName));
                            if (fieldname.length <= 1) {
                                fieldname = "";
                            }
                        }
                        if (OldContent_FieldName != Content_FieldName);
                        {
                            if (xml.getNodeslength("fields/field/value[@name='" + encodeURIComponent(Content_FieldName) + "']") > 0) {
                                Dialog.error("存在“" + Content_FieldName + "”这样的字段名称。", function () { $("#Content_FieldName").focus(); });
                                return false;
                            }
                        }
                        var wz = 1;
                        if (DivMessage && YValue.length > 0) {
                            var objName = GetDivMessage(DivMessage, TypeValue);
                            var icount = xml.getNodeslength("fields/field");
                            for (var i = 0; i < icount; i++) {
                                if (xml.GetString("fields/field", i + 1).indexOf("type=\"" + objName.md5 + "\"") != -1) {
                                    wz = i + 1;
                                    break;
                                }
                            }
                        }
                        fieldname += (fieldname.length > 0 ? "," : "") + encodeURIComponent(Content_FieldName);
                        objp.attr("fieldname", fieldname);
                        DivSelectSetValue(objp, TypeValue);
                        var objlist = $("#AcqContentHtml input[name=Content_FieldHtml]");
                        var htmlcode = "";
                        objlist.each(function () {
                            if (this.checked) {
                                htmlcode += this.value + ",";
                            }
                        });
                        xml.InsertBeforeChild("fields/field", "value", null, [{ name: "name", value: encodeURIComponent(Content_FieldName) }, { name: "page", value: $("#OldContent_FieldAdd").get(0).checked ? "1" : "0" }, { name: "delall", value: $("#Content_FieldAllHtml").get(0).checked ? "1" : "0" }, { name: "htmlcode", value: htmlcode }, { name: "htmltype", value: $("#Content_FieldHtmlType").get(0).checked ? "0" : "1"}], wz);
                        var wz1 = xml.getNodeslength(xml.getNodeIndex("fields/field", wz) + "/value");
                        if (!wz1 || wz1 == 0) {
                            wz1 = 1;
                        }
                        for (var i = 0; i < 2; i++) {
                            var Content_FieldSplit = $("#Content_FieldSplit_" + i).val();
                            if (Content_FieldSplit.length > 0) {
                                xml.InsertBeforeChild(xml.getNodeIndex("fields/field", wz) + "/value", "list", encodeURIComponent(Content_FieldSplit), [{ name: "num", value: encodeURIComponent($("#Content_FieldRead_" + i).val()) }, { name: "exist", value: ($("#Content_FieldExist_" + i).get(0).checked ? "1" : "0") }], wz1);
                            }
                        }
                        var Content_Pic = ($("#Content_Pic").get(0).checked ? "1" : "0");
                        var Content_Join = $("#Content_Pic").val();

                        if (Content_Pic == "1" && Content_Join.length > 0)
                        {
                            xml.InsertBeforeChild(xml.getNodeIndex("fields/field", wz) + "/value", "imgsrc", encodeURIComponent(Content_Join), [{ name: "open", value: "1" }], wz1);
                        }
                        var Content_FieldDefault = $("#Content_FieldDefault").val();
                        if (Content_FieldDefault.length > 0) {
                            xml.InsertBeforeChild(xml.getNodeIndex("fields/field", wz) + "/value", "default", Content_FieldDefault, null, wz1);
                        }
                        var Content_FieldReplace = $("#Content_FieldReplace").val();
                        if (Content_FieldReplace.length > 0) {
                            xml.InsertBeforeChild(xml.getNodeIndex("fields/field", wz) + "/value", "replace", Content_FieldReplace, null, wz1);
                        }
                        if (YValue.length > 0) {
                            var icount = xml.getNodeslength("fields/field");
                            if (icount > 1) {
                                for (var i = 0; i < icount; i++) {
                                    if (xml.GetString("fields/field", i + 1).indexOf("<value") == -1) {
                                        xml.delNode("fields/field", i + 1);
                                        i--;
                                        icount--;
                                    }
                                }
                            }
                        }
                        Value = xml.GetString("fields/field");
                        xml.Dispose();
                    } else {
                        if (FieldName && YValue.length > 0) {
                            var xml = new XML();
                            xml.SetXML(YValue);
                            xml.delNode("fields/field/value[@name='" + FieldName + "']");
                            var icount = xml.getNodeslength("xml/field");
                            for (var i = 0; i < icount; i++) {
                                if (xml.GetString("fields/field", i + 1).indexOf("<value") == -1) {
                                    xml.delNode("fields/field", i + 1);
                                    i--;
                                    icoun--;
                                }
                            }
                            Value = xml.GetString("fields/field");
                            xml.Dispose();
                        }
                    }
                    if (Value.length > 0 && Value.Trim().Left(8) != "<fields>") {
                        Value = "<fields>" + Value + "</fields>";
                    }
                    Acquisition_ContentObj.val(encodeURIComponent(Value));
                    break;
                }
            case "3": //内容分页
                {
                    if (Value.length > 0) {
                        var xml = new XML();
                        var AcqContentPageAll = $("#AcqContentPageAll");
                        Value = Value.replace("AcqContentPageAll", ((AcqContentPageAll && AcqContentPageAll.length > 0 && AcqContentPageAll.get(0).checked) ? "1" : "0"));
                        xml.SetXML(Value);
                        var AcqContentPageNext = $("#AcqContentPageNext");
                        if (AcqContentPageNext && AcqContentPageNext.length > 0) {
                            xml.addAttrib("contentpage", "page", AcqContentPageNext.get(0).chekced ? "1" : "0");
                        } else {
                            xml.delAttrib("contentpage", "page");
                        }
                        var AcqContentPageCreate = $("#AcqContentPageCreate");
                        if (AcqContentPageCreate && AcqContentPageCreate.length > 0) {
                            xml.addAttrib("contentpage", "createpage", AcqContentPageCreate.get(0).chekced ? "1" : "0");
                        } else {
                            xml.delAttrib("contentpage", "createpage");
                        }
                        Value = xml.GetString("contentpage");
                        xml.Dispose();
                    }
                    Acquisition_ContentPageObj.val(encodeURIComponent(Value));
                    break;
                }
        }
        return true;
    }
    //读取信息值
    var ReadAcqTypeValue = function () {
        var RadioValue = "0";
        var RadioList = Add_AcquisitionDIV.find("input[name='AcquisitionType']:checked");
        if (RadioList.length > 0) {
            RadioValue = RadioList.eq(0).val();
        }
        return RadioValue;
    }
    //判断当前控件名称
    var SetSycmsHtml = function (TypeValue) {
        var str = "";
        switch (TypeValue) {
            case "0":
                {
                    str = "[列表]";
                    break;
                }
            case "1":
                {
                    str = "[分页]";
                    break;
                }
            case "2":
                {
                    str = "[内容]";
                    break;
                }
            case "3":
                {
                    str = "[内容分页]";
                    break;
                }
        }
        return str;
    }
    //单击其它地方移除另外的
    var OtherRemoveAllSelect = function (TypeValue, DivMessage, fieldName) {
        var divIsDicList = divList.filter("[isdic='" + TypeValue + "']:first");
        if (divIsDicList.length > 0) {
            var name = divIsDicList.attr("name");
            if (name) {
                name = decodeURIComponent(name);
                var obj = htmlbody.find(decodeURIComponent(name));
                if (obj && obj.length == 1) {
                    RemoveAllSelect(obj, divIsDicList, TypeValue, DivMessage, fieldName)
                }
            }
        }
    }
    //移除所有选择
    var RemoveAllSelect = function (obj, objp, TypeValue, DivMessage, fieldName) {
        RemoveSelectDivPre(objp, obj, TypeValue, fieldName);
        RemoveSelect(obj, objp, TypeValue, DivMessage, fieldName);
        SetAcqTypeinputValue(objp, TypeValue, TypeValue == "2" ? GetTextareaValue(TypeValue) : "", fieldName);
    }
    var AddSelectOK_2 = function (DivMessage, IdList, objp1) {
        if (DivMessage[0].AttrName.length > 0) {
            if (IdList.attr(DivMessage[0].AttrName) == DivMessage[0].AttrValue) {
                objp1.attr("isok", "1");
            }
        } else {
            if (ReadtagName(IdList) == DivMessage[0].tagname) {
                objp1.attr("isok", "1");
            }
        }
    }
    //增加OK标示
    var AddSelectOK = function (obj, objp, TypeValue, DivMessage) {
        if (DivMessage.length > 0 && RemoveSelect_OnRemoveAll(TypeValue, DivMessage).bo) {
            var IdList = obj.prev();
            var objp1 = objp.prev();
            while (IdList && IdList.length > 0) {
                AddSelectOK_2(DivMessage, IdList, objp1);
                IdList = IdList.prev();
                objp1 = objp1.prev();
            }
            var IdList = obj.next();
            var objp1 = objp.next();
            while (IdList && IdList.length > 0) {
                AddSelectOK_2(DivMessage, IdList, objp1);
                IdList = IdList.next();
                objp1 = objp1.next();
            }
        }
    }
    var AddSelect_2 = function (IdList, objp1, TypeValue, DivMessage) {
        if (DivMessage[0].AttrName.length > 0) {
            if (IdList.attr(DivMessage[0].AttrName) == DivMessage[0].AttrValue) {
                DivSelect(objp1.find("span.sycmshtml:first"), objp1, IdList, TypeValue);
                objp1.attr("isok", "1");
            }
        } else {
            if (ReadtagName(IdList) == DivMessage[0].tagname) {
                DivSelect(objp1.find("span.sycmshtml:first"), objp1, IdList, TypeValue);
                objp1.attr("isok", "1");
            }
        }
    }
    ///增加选中
    var AddSelect = function (obj, objp, TypeValue, DivMessage) {
        if (DivMessage.length > 0) {
            var IdList = obj.prev();
            var objp1 = objp.prev();
            while (IdList && IdList.length > 0) {
                AddSelect_2(IdList, objp1, TypeValue, DivMessage);
                IdList = IdList.prev();
                objp1 = objp1.prev();
            }
            var IdList = obj.next();
            var objp1 = objp.next();
            while (IdList && IdList.length > 0) {
                AddSelect_2(IdList, objp1, TypeValue, DivMessage);
                IdList = IdList.next();
                objp1 = objp1.next();
            }
        }
    }
    //移除
    var RemoveSelectDivPre = function (objp, obj, TypeValue, fieldName) {
        if (TypeValue == "2")//内容的
        {
            var fieldnameObj = objp.attr("fieldname");
            if (fieldnameObj) {
                fieldnameObj = FieldNameReplace(fieldnameObj, fieldName);
                if (fieldnameObj.length <= 1) {
                    RemoveSelectDivPre2(objp, obj);
                } else {
                    objp.attr("fieldname", fieldnameObj);
                }
            } else {
                RemoveSelectDivPre2(objp, obj);
            }
            DivSelectSetValue(objp, TypeValue);
        } else {
            RemoveSelectDivPre2(objp, obj);
        }
    }
    //移除状态值信息
    var RemoveSelectDivPre2 = function (objp, obj) {
        objp.removeAttr("isdic");
        objp.removeAttr("isok");
        objp.removeAttr("fieldname");
        objp.find(".htmlalt:first").hide();
        objp.find("span.sycmshtml:first").removeClass("select");
        htmlbody.find("#" + obj.attr("sycms") + "_SycmsDIV").remove();
    }
    //移除的时候判断一下是否移除全部
    var RemoveSelect_OnRemoveAll = function (TypeValue, DivMessage) {
        var bo = false;
        var nodeName = "";
        var attrName = "";
        var attrValue = "";
        var tagName = "";
        switch (TypeValue) {
            case "0": //列表
                {
                    nodeName = "lists";
                    break;
                }
            case "3": //内容分页
                {
                    nodeName = "contentpage";
                    break;
                }
        }
        if (nodeName.length > 0) {
            var Value = GetTextareaValue(TypeValue);
            if (Value.length > 0) {
                var xml = new XML();
                xml.SetXML(Value);
                if (xml.getAttrib(nodeName + "/option", "all", 1) == "1") {
                    bo = true;
                }
                tagName = xml.getAttrib(nodeName + "/option", "tagname", 1);
                var message = xml.getChild(nodeName + "/option", 1);
                if (message) {
                    var messageArray = message.split("=\"");
                    if (message.length == 2) {
                        attrName = message[0];
                        attrValue = message[1].Left(message[1].length - 1);
                    }
                }
                xml.Dispose();
            } else {
                if (DivMessage.length > 0) {
                    if (DivMessage[0].all == 1) {
                        bo = true;
                        attrName = DivMessage[0].AttrName;
                        attrValue = DivMessage[0].AttrValue;
                        tagName = DivMessage[0].tagname;
                    }
                }
            }
        }
        return { bo: bo, AttrName: attrName, AttrValue: attrValue, tagname: tagName };
    }
    //读取tagname
    var ReadtagName=function(obj)
    {
        return obj.get(0).tagName.toLowerCase();
    }
    //移除选中
    var RemoveSelect = function (obj, objp, TypeValue, DivMessage, fieldName) {
        var message = RemoveSelect_OnRemoveAll(TypeValue, DivMessage);
        if (message.bo) {
            var IdList = obj.prev();
            var objp1 = objp.prev();
            while (IdList && IdList.length > 0) {
                if (message.AttrName.length > 0) {
                    if (IdList.attr(message.AttrName) == message.AttrValue) {
                        RemoveSelectDivPre(objp1, IdList, TypeValue, fieldName);
                    }
                } else {
                    if (ReadtagName(IdList) == message.tagname) {
                        RemoveSelectDivPre(objp1, IdList, TypeValue, fieldName);
                    }
                }
                IdList = IdList.prev();
                objp1 = objp1.prev();
            }
            var IdList = obj.next();
            var objp1 = objp.next();
            while (IdList && IdList.length > 0) {
                if (message.AttrName.length > 0) {
                    if (IdList.attr(message.AttrName) == message.AttrValue) {
                        RemoveSelectDivPre(objp1, IdList, TypeValue, fieldName);
                    }
                } else {
                    if (ReadtagName(IdList) == message.tagname) {
                        RemoveSelectDivPre(objp1, IdList, TypeValue, fieldName);
                    }
                }
                IdList = IdList.next();
                objp1 = objp1.next();
            }
        }
    }
    ///添加选中 span参数 上面的div obj为窗口
    var DivSelect = function (objthis, objp, obj, TypeValue) {
        if (!objp.attr("isdic")) {
            var sycms = obj.attr("sycms");
            var htmlalt = SetSycmsHtml(TypeValue);
            htmlbody.append(sycms_HTMLDIV.replace("$SyCms$", sycms + "_SycmsDIV").replace("#color#", "#E8F6FD").replace("#colorrgb#", "232,246,253"));
            var wzobj = Acquisition_topleft(obj);
            objp.attr("isdic", TypeValue);
            objp.find(".htmlalt:first").html(htmlalt).show();
            objthis.addClass("select");
            htmlbody.find("#" + sycms + "_SycmsDIV").css({ "top": wzobj.top, "left": wzobj.left, "width": wzobj.width, "height": wzobj.height }).addClass("Sycms_List").attr("name", objp.attr("id")).html("<span style=\"background:#96D9F9;padding:1px;color:blue;position:relative;float:left;\">" + htmlalt + "</span>").show();
        }
    }
    //内容的时候修改里面的值
    var DivSelectSetValue = function (objp, TypeValue) {
        var id = "sycms_" + objp.attr("id") + "_SycmsDIV";
        var FieldName = objp.attr("fieldname");
        if (FieldName) {
            FieldName = decodeURIComponent(objp.attr("fieldname"));
            FieldName = "<font color=red>" + FieldName + "</font>";
        } else {
            FieldName = "";
        }
        htmlbody.find("#" + id + " span").html(SetSycmsHtml(TypeValue) + (FieldName ? ("--" + FieldName) : ""));
    }
    ///判断是否上级有选中。
    var ParentPathIsExit = function (obj) {
        if (!obj.attr("isdic")) {
            var obj1 = obj.parent();
            while (obj1 && obj1.length > 0 && obj1.attr("id") && obj1.attr("id").length > 0) {
                if (obj1.attr("isdic")) {
                    return true;
                }
                obj1 = obj1.parent();
            }
        } else {
            return true;
        }
        var obj1 = obj.find("div");
        if (obj1 && obj1.length > 0) {
            for (var i = 0; i < obj1.length; i++) {
                if (obj1.eq(i).attr("isdic")) {
                    return true;
                }
            }
        }
        return false;
    }
}
function AcquisitionContentReload(id) {
    $('#flex1').flexReload(null, id);
}
function AcquisitionContentExportFun(id) {
    CreateWindow('System/Acquisition/Content/Add.aspx?id=' + id, '导出', function (CreateWin) {
        if ($("#AcquisitionContentExport_0").get(0).style.display == "none") {//为提交
            AjaxFun("System/Acquisition/Content/Add.aspx?action=two&id=" + id + "&modelid=" + encodeURIComponent($("#modelid").val()), ReadInputValue("AcquisitionContentExportDiv"), "正在提交，请稍候......", function (html) {
                CreateWin.close();
            });
        } else {
            AjaxFun("System/Acquisition/Content/Add.aspx?action=one&id=" + id, "modelid=" + encodeURIComponent($("#modelid").val()), ' ', function (html) {
                $("#AcquisitionContentExport_0").hide();
                $("#AcquisitionContentExport_1").html(html);
                CreateWin.setSize(600, 400);
            });
        }
    }, 400, 45, 'AcquisitionContentExportDiv');
}

///显示修改的历史版本信息
function SystemOldLogModiList(TableName, Description, Title) {
    GridModiy('1', 'Manager/Log/Lists_Modi.aspx?action=view&TableName=' + TableName + "&Description=" + encodeURIComponent(Description), (Title ? Title : "历史版本"), null, 500, 350);
}

///工作流 开始
function WorkFlowSelect(objID, objName, Num) {
    var obj = $("#" + objID);
    for (var i = 1; i <= 9 ; i++)
    {
        if (i <= parseInt(Num)) {
            obj.find("." + objName + i).show();
        } else {
            obj.find("." + objName + i).hide();
        }
    }
}
///工作流 结束

///读取单个控件的值
function ReadFromOneValue(FromName)
{
    var InputValue = ReadInputValue(FromName);
    if (InputValue.length > 0) {
        InputValue = InputValue.split('=')[1];
    }
    return InputValue;
}
//值，0为radio，1为select 2为checked
function WriteFromValue(FromName, val, type) {
    if(val.length>0)
    {
        switch (type) {
            case "0":
                {
                    var $obj = $(FromName).find("input[type='radio'][value='" + val.replace("'", "") + "']");
                    if ($obj && $obj.length > 0)
                    {
                        $obj.attr("checked", "checked");
                        $obj.next().addClass("checked");
                    }
                    break;
                }
            case "1":
                {
                    $(FromName).find("select").val(val);
                    break;
                }
            case "2":
                {
                    val = "," + val + ",";
                    $(FromName).find("input[type='checkbox']").each(function () {
                        var $obj = $(this);
                        if (val.indexOf("," + $obj.val() + ",") != -1) {
                            $obj.attr("checked", "checked");
                            $obj.next().addClass("checked");
                            val = val.replace("," + $obj.val() + ",", ",");
                        }
                        if (val.length <= 1)
                        {
                            return false;
                        }
                    });
                    break;
                }
        }
    }
}

///写入控件值


//导入网站备份文件
function WebFileZip(WebFile) {
    AjaxFun("System/WebFile/Modi_Reduction.aspx", "action=one&WebFile=" + encodeURIComponent(WebFile), "正在执行还原操作，可能需要一段时间，请稍候......");
}

//导入网站数据库文件
function DataBaseFileZip(FileName, FunPara)
{
    AjaxFun("System/DataBase/Modi_Restore.aspx", "action=save&FileName=" + encodeURIComponent(FileName) + "&mdbname=" + FunPara, "正在执行还原操作，可能需要一段时间，请稍候......");
}

//导入插件文件
function InsertPlusFileZip(PlusFile) {

    AjaxFun("Plus/Management/Add.aspx", "action=two&PlusFile=" + encodeURIComponent(PlusFile), "正在执行安装操作，可能需要一段时间，请稍候......");
}

//导入Word文档
function InsertWordFileZip(WordFileUrl, FunPara)
{
    AjaxFun('AdminFun/WordToHtml.aspx', 'WordFileUrl=' + WordFileUrl, '正在导入Word内容。', function (html) { var instance1 = CKEDITOR.instances[FunPara]; if (instance1) { instance1.insertHtml(html); } else { $('#' +FunPara).val(html) } });
}


//计划任务总的添加
function AddClassIdOnTask(ObjName) {
    CreateWindow("System/Task/Add_CategoryTree.aspx?AllClassid=" + $("#" + ObjName).val(), "选择栏目", function (CreateWindowdiag) {
        var CheckList = $("#ClassCheckList input").filter("[name='AddClassId']:checked");
        var CheckValue = new Array();
        CheckList.each(function() {
            CheckValue.push(encodeURIComponent($(this).val()));
        });
        $("#" + ObjName).val(CheckValue.join(','));
        CreateWindowdiag.close();
        CreateWindowdiag = null;
        CheckList = null;
        CheckValue = null;
    }, 500, 500, 'ClassCheckList');
}