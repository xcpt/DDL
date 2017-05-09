var Menu_Plus = new Array();
//T不输出显示全部，为1显示条件2显示党规
//a:插件
//b:if语句
//c:fof语句
//d:or语句
//e:标签语句
//f:导航语句
//g:网页传值
//h:系统
//hh:跳转地址
//i:缓存
//j:选择变量
//k:新建变量
//l:基础样式
//m:插入模块
//n:新建模块
//o:分页信息
//p:SEO优化
//q:表达式计算
//r:跳转
//u:存在的时候，是关闭分页的信息
//x:上传图片
//y:选择图片
//z:查找替换

function TextMenuOtherMenu(obj, str, YqListid, taskBar)
{
    if (str.length > 10)
    {
        var FileUrl = "";
        var FileType = "0";
        var s=str.toLowerCase();
        if (s.Left(7) == "http://" || s.Left(8) == "https://")
        {
            var dianwz = s.split(".");
            if ("|jpg|jpeg|gif|png|bmp|js|css|".indexOf(dianwz[dianwz.length - 1]) != -1)
            {
                FileUrl = s;
            }
        } else if (str.replace(/<script[^>]+>(.*?)<\/script>/gm, '').length == 0) {
            var myRegExp = new RegExp("src=(\"|'|)([^\"'<>]+)", "img");
            myRegExp.exec(str);
            var src = RegExp.$2;
            if (src.length > 0) {
                FileType = "1";
                FileUrl = src;
            }
        } else if (str.replace(/<link[^>]+>/gm, '').length == 0) {
            var myRegExp = new RegExp("href=(\"|'|)([^\"'<>]+)", "img");
            myRegExp.exec(str);
            var src = RegExp.$2;
            if (src.length > 0) {
                FileType = "1";
                FileUrl = src;
            }
        }
        if (FileUrl.length > 0) {
            if (taskBar[taskBar.length - 1].sub.length > 0) {
                taskBar[taskBar.length - 1].sub.push({ line: true });
            }
            taskBar[taskBar.length - 1].sub.push({
                text: (FileType == "1" ? "编辑文件" : "查看并下载"), ico: (FileType == "1" ? 'images/icon/script_code.png' : 'images/icon/picture.png'), cmd: function () {
                    //地址格式[$Path$]
                    if (FileType == "1") {
                        CreateWindow("Tem/List/Modi_File.aspx?ListID=" + YqListid + "&FileName=" + encodeURIComponent(FileUrl), "编辑文件", "Tem/List/Modi_File.aspx?ListID=" + YqListid + "&action=save&FileName=" + encodeURIComponent(FileUrl), "500", "500", "FileContentModi");
                    } else {
                        CreateWindow("Tem/List/Modi_File.aspx?ListID=" + YqListid + "&FileName=" + encodeURIComponent(FileUrl), "查看并下载", "", 500, 400, "FileContentModi", {
                            Name: '下到模板下', Url: "Tem/List/Modi_File.aspx?ListID=" + YqListid + "&action=down&FileName=" + encodeURIComponent(FileUrl), PostReturnFunction: function (html) {
                                if (html.length > 0) {
                                    InsertAtCaret(obj, html);
                                }
                            }
                        });
                    }
                }
            });
        }
    }
    return taskBar;
}

function TextMenu(obj, T, SelectType, MemberList) {
    var str = obj.selectStr || "";
    var Ostr = obj.selectOStr || "";
    var taskBar = [];
    var YqListid = $(obj).attr("ListID");
    var YqClassID = $(obj).attr("ClassID");
    if (!YqListid || isNaN(parseInt(YqListid))) {
        YqListid = $("#YQ_listID").val();
    }
    if (SelectType) {
        if (obj.MenuTrue == "1") {
            if (str.length > 0) {
                taskBar.push({ text: SycmsLanguage.MenuList.l1, ico: 'images/icon/css.png', cmd: function () { CssFunction(str, obj); } });
            } else {
                taskBar.push({ text: SycmsLanguage.MenuList.l2, ico: 'images/icon/css.png', cmd: function () { CssFunction(str, obj); } });
            }
            taskBar.push({ text: SycmsLanguage.MenuList.l3, ico: 'images/icon/css.png', cmd: function () { obj.MenuTrue = "0"; } });
        } else {
            taskBar.push({ text: SycmsLanguage.MenuList.l4, ico: 'images/icon/css.png', cmd: function () { obj.MenuTrue = "1"; } });
        }
        if (!YqListid) {
            YqListid = "0";
        }
        if (!YqClassID) {
            YqClassID = "0";
        }
        taskBar.push({ line: true });
        taskBar.push({ text: SycmsLanguage.MenuList.l5, ico: 'images/icon/picture_add.png', cmd: function () {
            UploadFile(obj.id, "PIC", "IsStyle=1&Listid=" + YqListid + "&ClassID=" + YqClassID);
        }
        });
        taskBar.push({ line: true });
        taskBar.push({ text: SycmsLanguage.MenuList.l6, ico: 'images/icon/picture.png', cmd: function () {
            DirImgWin(obj, (YqClassID != "0" ? YqClassID : YqListid), "IsStyle=1" + (YqClassID != "0" ? "&ListType=1" : ""));
        }
        });
        taskBar.push({ line: true });
        taskBar.push({ text: SycmsLanguage.MenuList.l7, ico: 'images/icon/text_replace.png', cmd: function () {
            ReplaceTextArea($(obj));
        }
        });
        menuAdmin.del(obj.id + "TextCss_Menu");
        RemoveMenu();
        if (taskBar.length > 0) {
            var m1 = new popUpMenu(taskBar, null, null, obj.id + "TextCss_Menu");
            menuAdmin.init().add(obj, m1);
            m1 = null;
        };
    } else {
        var Type = "";
        var ID = "";
        if (str.length > 0) {
            var xml = new XML();
            xml.SetXML("<?xml version='1.0' encoding='utf-8'?><xml>" + str + "</xml>");
            Type = unescape(xml.getAttrib("xml/sycms", "type"));
            Ytype = Type;
            Type = Type.toLowerCase();
            if (Type == "template") {
                ID = unescape(xml.getAttrib("xml/sycms", "id"));
            }
            xml = null;
        }
        if (obj) {
            if (T) {
                var TCount = 0;
                for (var j = 97; j <= 122; j++) {
                    if (T[String.fromCharCode(j)]) {
                        TCount++;
                    }
                }
                if (str.length == 0) {
                    if (CmsLabelViewUser(YqListid)) {
                        taskBar.push({
                            text: SycmsLanguage.MenuList.l56, ico: 'images/icon/user.png', sub: [
                                { text: SycmsLanguage.MenuList.l57, ico: 'images/icon/user_tick.png', cmd: function () { LabelFun("", obj, "User_Login"); } }
                            ]
                        });
                    }
                    if (T.a) {
                        var Pf = true;
                        taskBar.push({ text: SycmsLanguage.MenuList.l44, ico: 'images/icon/script_code.png', cmd: function () { Menu_PlusFun(obj); } });
                        if (FormList.length > 0) {
                            taskBar.push({ text: SycmsLanguage.MenuList.l51, ico: 'images/icon/table.png', cmd: function () { Menu_FormFun(obj); } });
                            Pf = true;
                        }
                        if (Pf) {
                            TCount--;
                            if (TCount > 0) {
                                taskBar.push({ line: true });
                            }
                        }
                    }
                    if (T.m) {
                        TCount--;
                        taskBar.push({ text: SycmsLanguage.MenuList.l22, ico: 'images/icon/shapes_many.png', cmd: function () { MenuReadFun_Add(obj); } });
                    }
                    if (T.n) {
                        TCount--;
                        taskBar.push({
                            text: SycmsLanguage.MenuList.l23, ico: 'images/icon/shape_square_add.png', sub: [
                        { text: SycmsLanguage.MenuList.l61, ico: 'images/icon/shape_shade_a.png', cmd: function () { MenuReadFun_New(obj); } },
                        { text: SycmsLanguage.MenuList.l62, ico: 'images/icon/share.png', cmd: function () { MenuReadFun_New(obj, "Nav"); } },
                        { text: SycmsLanguage.MenuList.l63, ico: 'images/icon/shape_shadow_toggle.png', cmd: function () { MenuReadFun_New(obj, "Sys"); } },
                            ]
                        });
                    }
                    if (T.m || T.n) {
                        if (TCount > 0) {
                            taskBar.push({ line: true });
                        }
                    }
                    if (T.b || T.c || T.d) {
                        taskBar.push({ text: SycmsLanguage.MenuList.l8, ico: 'images/icon/page_white_coldfusion.png', sub: [
					{ text: SycmsLanguage.MenuList.l9, ico: 'images/icon/chart_organisation.png', disabled: (T.b ? false : true), cmd: function () { LabelFun("", obj, "Factor_If"); } },
					{ text: SycmsLanguage.MenuList.l10, ico: 'images/icon/chart_org_inverted.png', disabled: (T.c ? false : true), cmd: function () { LabelFun("", obj, "Factor_For"); } },
					{ text: SycmsLanguage.MenuList.l11, ico: 'images/icon/arrow_switch.png', disabled: (T.d ? false : true), cmd: function () { LabelFun("", obj, "Factor_OR"); } }
				]
                        });
                        if (T.b) {
                            TCount--;
                        }
                        if (T.c) {
                            TCount--;
                        }
                        if (T.d) {
                            TCount--;
                        }
                        if (T.b || T.c || T.d) {
                            taskBar[taskBar.length - 1].sub.push({ line: true });
                            taskBar[taskBar.length - 1].sub.push({ text: SycmsLanguage.MenuList.l48, ico: 'images/icon/text_columns.png', cmd: function () { CommonlyUsedLabelFun(obj,null,null,null,T.b, T.c, T.d); } });
                        }
                        if (TCount > 0) {
                            taskBar.push({ line: true });
                        }
                    }
                    if (T.e || T.f || T.p) {
                        taskBar.push({ text: SycmsLanguage.MenuList.l12, ico: 'images/icon/page_white_freehand.png', sub: [
					    { text: SycmsLanguage.MenuList.l13, ico: 'images/icon/layout_content.png', disabled: (T.e ? false : true), cmd: function () { LabelFun("", obj, "List"); } },
                        { line: true },
					    { text: SycmsLanguage.MenuList.l14, ico: 'images/icon/layout_header.png', disabled: (T.f ? false : true), cmd: function () { LabelFun("", obj, "Navigate"); } },
                        { text: SycmsLanguage.MenuList.l50, ico: 'images/icon/layout_header.png', disabled: (T.p ? false : true), cmd: function () { LabelFun("", obj, "Seo"); } },
                        { line: true },
                        { text: SycmsLanguage.MenuList.l54, ico: 'images/icon/calculator.png', disabled: (T.q ? false : true), cmd: function () { LabelFun("", obj, "Count"); } }
				    ]
                        });
                        if (T.e) {
                            TCount--;
                        }
                        if (T.f) {
                            TCount--;
                        }
                        if (T.p) {
                            TCount--;
                        }
                        if (T.q)
                        {
                            TCount--;
                        }
                        if (T.e || T.f || T.p || T.q) {
                            taskBar[taskBar.length-1].sub.push({ line: true });
                            taskBar[taskBar.length - 1].sub.push({ text: SycmsLanguage.MenuList.l47, ico: 'images/icon/text_columns.png', cmd: function () { CommonlyUsedLabelFun(obj,T.e, T.f, T.p); } });
                        }
                        if (TCount > 0) {
                            taskBar.push({ line: true });
                        }
                    }
                    if (T.g || T.h || T.hh || T.i)
                    {
                        taskBar.push({ text:SycmsLanguage.MenuList.l53, ico: 'images/icon/text_columns.png', sub: [] });
                        if (T.g) {
                            taskBar[taskBar.length-1].sub.push({ text: SycmsLanguage.MenuList.l15, ico: 'images/icon/page_forward.png', cmd: function () { LabelFun("", obj, "Get"); } });
                            TCount--;
                        }
                        if (T.h) {
                            taskBar[taskBar.length - 1].sub.push({ text: SycmsLanguage.MenuList.l16, ico: 'images/icon/page_gear.png', cmd: function () { LabelFun("", obj, "Sys"); } });
                            TCount--;
                        }
                        if (T.hh) {
                            taskBar[taskBar.length - 1].sub.push({ text: SycmsLanguage.MenuList.l59, ico: 'images/icon/world_go.png', cmd: function () { LabelFun("", obj, "Sys_GoToUrl"); } });
                            TCount--;
                        }
                        if (T.g || T.h || T.hh) {
                            if (TCount > 0) {
                                taskBar[taskBar.length - 1].sub.push({ line: true });
                            }
                        }
                        if (T.i) {
                            taskBar[taskBar.length - 1].sub.push({ text: SycmsLanguage.MenuList.l17, ico: 'images/icon/disk_upload.png', cmd: function () { LabelFun("", obj, "Cookie"); } });
                            TCount--;
                            if (TCount > 0) {
                                taskBar.push({ line: true });
                            }
                        }
                    }

                    if (T.j || T.k) {
                        if (T.j) {
                            TCount--;
                        }
                        if (T.k) {
                            TCount--;
                        }
                        var LabelClassName = $(obj).attr("LabelListClass");
                        if (LabelClassName) {
                            taskBar.push({ text: SycmsLanguage.MenuList.l46, ico: 'images/icon/text_columns.png', cmd: function () { LabelFieldFunHtmlFun(obj); } });
                            taskBar.push({ line: true });
                        }
                        var VarList = obj.MemberList;
                        if (VarList != null && VarList != undefined && VarList && (VarList instanceof Array) && VarList.length > 0) {
                            if (obj.type == "text" && T.j) {
                                taskBar.push({ text: SycmsLanguage.MenuList.l18, ico: 'images/icon/text_list_numbers.png', sub: [
					        { text: SycmsLanguage.MenuList.l19, ico: 'images/icon/page_break_insert.png', cmd: function () { LabelFun("", obj, "Var"); } }
					        ]
                                });
                                if (TCount > 0) {
                                    taskBar.push({ line: true });
                                }
                            } else {
                                taskBar.push({ text: SycmsLanguage.MenuList.l18, ico: 'images/icon/text_list_numbers.png', sub: [
					        { text: SycmsLanguage.MenuList.l20, disabled: (T.k ? false : true), ico: 'images/icon/page_break_insert.png', cmd: function () { LabelFun("", obj, "VarValue"); } },
					        { text: SycmsLanguage.MenuList.l19, disabled: (T.j ? false : true), ico: 'images/icon/page_break_insert.png', cmd: function () { LabelFun("", obj, "Var"); } }
					        ]
                                });
                                if (TCount > 0) {
                                    taskBar.push({ line: true });
                                }
                            }
                        } else if (obj.type == "textarea") {
                            if (T.k) {
                                taskBar.push({ text: SycmsLanguage.MenuList.l18, ico: 'images/icon/text_list_numbers.png', sub: [
				            { text: SycmsLanguage.MenuList.l20, ico: 'images/icon/page_break_insert.png', cmd: function () { LabelFun("", obj, "VarValue"); } }
				            ]
                                });
                                if (TCount > 0) {
                                    taskBar.push({ line: true });
                                }
                            }
                        }
                    }
                    if (T.l) {
                        taskBar.push({ text: SycmsLanguage.MenuList.l21, ico: 'images/icon/chart_organisation.png', cmd: function () { LabelFun("", obj, "BasicTem"); } });
                        TCount--;
                        if (TCount > 0) {
                            taskBar.push({ line: true });
                        }
                    }
                    if (T.o) {
                        if (T.u) {
                            taskBar.push({
                                text: SycmsLanguage.MenuList.l24, ico: 'images/icon/page_break.png', sub: [
                            { text: SycmsLanguage.MenuList.l26, ico: 'images/icon/text_linespacing.png', cmd: function () { InsertAtCaret(obj, "<sycms type=\"PageList\" name=\"Index\"/>"); } },
                            { text: SycmsLanguage.MenuList.l31, ico: 'images/icon/text_list_numbers.png', cmd: function () { InsertAtCaret(obj, "<sycms type=\"PageList\" name=\"MaxCount\"/>"); } }
                                ]
                            });

                        } else {
                            taskBar.push({
                                text: SycmsLanguage.MenuList.l24, ico: 'images/icon/page_break.png', sub: [
                            { text: SycmsLanguage.MenuList.l26, ico: 'images/icon/text_linespacing.png', cmd: function () { InsertAtCaret(obj, "<sycms type=\"PageList\" name=\"Index\"/>"); } },
                            { text: SycmsLanguage.MenuList.l31, ico: 'images/icon/text_list_numbers.png', cmd: function () { InsertAtCaret(obj, "<sycms type=\"PageList\" name=\"MaxCount\"/>"); } },
                            { line: true },
                            { text: SycmsLanguage.MenuList.l25, ico: 'images/icon/page_break_insert.png', cmd: function () { InsertAtCaret(obj, "<sycms type=\"PageList\" name=\"PageString\"/>"); } },
                            { text: SycmsLanguage.MenuList.l27, ico: 'images/icon/text_padding_top.png', cmd: function () { InsertAtCaret(obj, "<sycms type=\"PageList\" name=\"PageStartRecord\"/>"); } },
                            { text: SycmsLanguage.MenuList.l28, ico: 'images/icon/text_padding_bottom.png', cmd: function () { InsertAtCaret(obj, "<sycms type=\"PageList\" name=\"PageEndRecord\"/>"); } },
                            { text: SycmsLanguage.MenuList.l29, ico: 'images/icon/text_horizontalrule.png', cmd: function () { InsertAtCaret(obj, "<sycms type=\"PageList\" name=\"PageIndex\"/>"); } },
                            { text: SycmsLanguage.MenuList.l30, ico: 'images/icon/text_letter_omega.png', cmd: function () { InsertAtCaret(obj, "<sycms type=\"PageList\" name=\"MaxPage\"/>"); } },
                            { text: SycmsLanguage.MenuList.l32, ico: 'images/icon/text_signature.png', cmd: function () { InsertAtCaret(obj, "<sycms type=\"PageList\" name=\"Page\"/>"); } }
                                ]
                            });
                        }
                        TCount--
                        if (TCount > 0) {
                            taskBar.push({ line: true });
                        }
                    }
                } else {
                    switch (Type) {
                        case "user_gourl":
                        case "user_login":
                            {
                                if (CmsLabelViewUser(YqListid)) {
                                    taskBar.push({ text: SycmsLanguage.MenuList.l56, ico: 'images/icon/user.png', cmd: function () { LabelFun(str, obj, Ytype); } });
                                }
                                break;
                            }
                        case "sys_gotourl":
                            {
                                taskBar.push({ text: SycmsLanguage.MenuList.l59, ico: 'images/icon/world_go.png', cmd: function () { LabelFun(str, obj, Ytype); } });
                                break;
                            }
                        case "plus":
                            {
                                taskBar.push({ text: SycmsLanguage.MenuList.l45, ico: 'images/icon/script_code.png', cmd: function () { Menu_PlusFun(obj, str); } });
                                break;
                            }
                        case "form":
                            {
                                if (FormList.length > 0) {
                                    taskBar.push({ text: SycmsLanguage.MenuList.l52, ico: 'images/icon/table.png', cmd: function () { Menu_FormFun(obj, str); } });
                                }
                                break;
                            }
                        case "seo":
                        case "list":
                        case "navigate":
                            {
                                taskBar.push({ text: SycmsLanguage.MenuList.l34, ico: 'images/icon/page_white_freehand.png', cmd: function () { LabelFun(str, obj, Ytype); } });
                                break;
                            }
                        case "word":
                            {
                                taskBar.push({ text: SycmsLanguage.MenuList.l35, ico: 'images/icon/page_paintbrush.png', cmd: function () { LabelFun(str, obj, Ytype); } });
                                break;
                            }
                        case "pagelist":
                            {
                                taskBar.push({ text: SycmsLanguage.MenuList.l24, ico: 'images/icon/page_break.png', cmd: function () { LabelFun(str, obj, Ytype); } });
                                break;
                            }
                        case "template":
                            {
                                taskBar.push({ text: SycmsLanguage.MenuList.l36, ico: 'images/icon/shape_square_edit.png', cmd: function () { MenuReadFun_Modi(obj, str); } });
                                if (ID) {
                                    taskBar.push({ text: SycmsLanguage.MenuList.l43, ico: 'images/icon/eye.png', cmd: function () { LoadTemEye(ID, YqListid); } });
                                }
                                break;
                            }
                        case "get":
                            {
                                taskBar.push({ text: SycmsLanguage.MenuList.l37, ico: 'images/icon/page_forward.png', cmd: function () { LabelFun(str, obj, Ytype); } });
                                break;
                            }
                        case "sys": 
                            {
                                taskBar.push({ text: SycmsLanguage.MenuList.l38, ico: 'images/icon/page_gear.png', cmd: function () { LabelFun(str, obj, Ytype); } });
                                break;
                            }
                        case "basictem":
                            {
                                taskBar.push({ text: SycmsLanguage.MenuList.l39, ico: 'images/icon/chart_organisation.png', cmd: function () { LabelFun(str, obj, Ytype); } });
                                break;
                            }
                        case "cookie":
                            {
                                taskBar.push({ text: SycmsLanguage.MenuList.l40, ico: 'images/icon/disk_upload.png', cmd: function () { LabelFun(str, obj, Ytype); } });
                                break;
                            }
                        case "varvalue":
                            {
                                taskBar.push({ text: SycmsLanguage.MenuList.l41, ico: 'images/icon/text_list_numbers.png', cmd: function () { LabelFun(str, obj, Ytype); } });
                                break;
                            }
                        case "var":
                            {
                                taskBar.push({ text: SycmsLanguage.MenuList.l42, ico: 'images/icon/text_list_numbers.png', cmd: function () { LabelFun(str, obj, Ytype); } });
                                break;
                            }
                        default:
                            {
                                if (Type.Left(7) == "factor_") {
                                    taskBar.push({ text: SycmsLanguage.MenuList.l33, ico: 'images/icon/page_white_coldfusion.png', cmd: function () { LabelFun(str, obj, Ytype); } });
                                }
                                break;
                            }
                    }
                    taskBar.push({ line: true });
                }
                if ((obj.type == "textarea" && (T.x || T.y)) || T.z) {
                    taskBar.push({ text: '辅助功能', ico: 'images/icon/text_signature.png', sub: [] });
                    if (T.x) {
                        taskBar[taskBar.length - 1].sub.push({
                            text: SycmsLanguage.MenuList.l5, ico: 'images/icon/picture_add.png', cmd: function () {
                                UploadFile(obj.id, "PIC", (T != "Up" ? "IsStyle=1&" : "") + "Listid=" + YqListid);
                            }
                        });
                        TCount--
                    }
                    if (T.y) {
                        taskBar[taskBar.length - 1].sub.push({
                            text: SycmsLanguage.MenuList.l6, ico: 'images/icon/picture.png', cmd: function () {
                                DirImgWin(obj, YqListid, (T != "Up" ? "IsStyle=1" : ""));
                            }
                        });
                        TCount--
                    }
                    if (T.x || T.y) {
                        if (TCount > 0) {
                            taskBar[taskBar.length - 1].sub.push({ line: true });
                        }
                    }
                    if (T.z) {
                        taskBar[taskBar.length - 1].sub.push({
                            text: SycmsLanguage.MenuList.l7, ico: 'images/icon/text_replace.png', cmd: function () {
                                ReplaceTextArea($(obj));
                            }
                        });
                        taskBar[taskBar.length - 1].sub.push({
                            text: SycmsLanguage.MenuList.l55, ico: 'images/icon/text_horizontalrule.png', cmd: function () {
                                InsertAtCaret(obj, "[$Path$]");
                            }
                        });
                        if (Type.length == 0) {
                            taskBar[taskBar.length - 1].sub.push({
                                text: SycmsLanguage.MenuList.l49, ico: 'images/icon/html.png', cmd: function () {
                                    TemInsertHtml(obj, str);
                                }
                            });
                        }
                    }
                    if (str.length == 0) {
                        taskBar = TextMenuOtherMenu(obj, Ostr, YqListid, taskBar);
                    }
                }
                menuAdmin.del(obj.id + "Text_Menu");
                RemoveMenu();
                IECollectGarbage();
                if (taskBar.length > 0) {
                    var m1 = new popUpMenu(taskBar, null, null, obj.id + "Text_Menu");
                    menuAdmin.init().add(obj, m1);
                }
            }
        }
    }
}