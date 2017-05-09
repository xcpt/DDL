var HelpView = 1;                   //是否显示帮助提示
var HtmlCreateList = new Array();   //生成HTML的数组
var UploadFileMess = null;          //上传显示
var UploadFileMessDiag = null;      //上传显示框
var UploadFileMessDiagTime = null;  //上传那个啥
var UploadFileAllMess = null;       //多图上传
var ErrViewTime = 2;                //错误提示时间
var MessViewWin = 0;                 //成功或者是错误提示方式0为普通1为特殊
var SyCmsRunMessage = "";
//获取浏览器标识
var getBrowserOStr = getBrowserOS();
///loadjs 重新调入JS文件
function LoadJS(src) {
    if (document.getElementById("scriptjsname") != null) {
        document.getElementById("scriptjsname").parentNode.removeChild(document.getElementById("scriptjsname"));
    }
    var headObj = document.getElementsByTagName("head")[0];
    srciptObj = document.createElement("script");
    srciptObj.language = "javaScript";
    srciptObj.type = "text/JavaScript";
    srciptObj.src = src + "?time=" + Math.random();
    srciptObj.id = "scriptjsname";
    headObj.appendChild(srciptObj);
    headObj = null;
    srciptObj = null;
}
///加载css文件
function ReLoadCss(src, Reload) {
    var obj = $("link");
    var objBO = false;
    var objJs = null;
    var Ssrc = src.toLowerCase();
    for (var i = 0; i < obj.length; i++) {
        var objsrc = obj.eq(i).attr("href");
        if (objsrc) {
            if (objsrc.toLowerCase().indexOf(Ssrc) != -1) {
                objBO = true;
                objJs = obj.eq(i).get(0);
                break;
            }
        }
    }
    if (objBO && Reload) {
        objJs.parentNode.removeChild(objJs);
        objBO = false;
    }
    if (!objBO) {
        var headObj = document.getElementsByTagName("body")[0];
        srciptObj = document.createElement("link");
        srciptObj.type = "text/css";
        srciptObj.href = src + (src.indexOf("?") != -1 ? "&" : "?") + "time=" + Math.random();
        headObj.appendChild(srciptObj);
        headObj = null;
        srciptObj = null;
    }
}
///加载JS文件
function ReLoadJS(src, Reload) {
    var obj = $("script");
    var objBO = false;
    var objJs = null;
    var Ssrc = src.toLowerCase();
    for (var i = 0; i < obj.length; i++) {
        var objsrc = obj.eq(i).attr("src");
        if (objsrc) {
            if (objsrc.toLowerCase().indexOf(Ssrc) != -1) {
                objBO = true;
                objJs = obj.eq(i).get(0);
                break;
            }
        }
    }
    if (objBO && Reload) {
        objJs.parentNode.removeChild(objJs);
        objBO = false;
    }
    if (!objBO) {
        var headObj = document.getElementsByTagName("body")[0];
        srciptObj = document.createElement("script");
        srciptObj.language = "javaScript";
        srciptObj.type = "text/JavaScript";
        srciptObj.src = src + (src.indexOf("?") != -1 ? "&" : "?") + "time=" + Math.random();
        headObj.appendChild(srciptObj);
        headObj = null;
        srciptObj = null;
    }
}

//读取ID值所对应的在Str中的值
//ID为name
//Str为{name:"dddddd",id:"zgq"}
//结果为dddddd
function ReadClass(id, Str) {
    try{
        return eval("Str."+id);
    }catch(e){
        return "";
    }
}
//字符串转成JSon
function String2Json(Str)
{
    return eval("(" + Str + ")");
}
//读取选中的ID
function GridReadID(gridList, NoAlert) {
    var itemlist = new Array();
    if (typeof (gridList) != "object") {
        itemlist.push(gridList);
    } else {
        var items = $('input.itemchk:checked', gridList);
        if (items.length > 0) {
            for (i = 0; i < items.length; i++) {
                itemlist.push(items.eq(i).val());
            }
        } else {
            if (!NoAlert) {
                Dialog.alert(SycmsLanguage.Admin.GridDel.l1);
            }
        }
    }
    return itemlist.join(",");
}

//读取当前页的ID
function GridReadCheckBoxID(gridList) {
    var itemlist = new Array();
    if (typeof (gridList) != "object") {
        itemlist.push(gridList);
    } else {
        var items=$('input.itemchk', gridList);
        if (items.length > 0) {
            for (i = 0; i < items.length; i++) {
                itemlist.push(items.eq(i).val());
            }
        }
    }
    return itemlist.join(",");
}

///表格删除所用
function GridDel(gridList, Url, ParentName, ClassID, alttitle, loadtitle) {
    var itemlist = GridReadID(gridList);
    if (itemlist.length > 0) {
        Dialog.confirm(alttitle ? alttitle : SycmsLanguage.Admin.GridDel.l2, function () {
            AjaxFun(Url, "id=" + itemlist, loadtitle ? loadtitle : SycmsLanguage.Admin.GridDel.l3, function (html) {
                if (typeof (gridList) != "string") {
                    gridList.flexReload();
                } else {
                    if (ClassID) {
                        $('#flex' + ClassID).flexReload(null, '0');
                    } else {
                        $('#flex1').flexReload(null, '0');
                    }
                }
            }, ParentName);
        });
    }
}
//修改属性
function GridProperty(gridList, Url, ParentName, Content, ClassID) {
    var itemlist = GridReadID(gridList);
    if (itemlist.length > 0) {
        AjaxFun(Url, "id=" + itemlist, Content, function(html) {
            if (typeof (gridList) != "string") {
                gridList.flexReload(null, itemlist);
            } else {
                if (ClassID) {
                    $('#flex' + ClassID).flexReload(null, itemlist);
                } else {
                    $('#flex1').flexReload(null, itemlist);
                }
            }
        }, ParentName);
    }
}

///修改记录的时候
// 列表对象或者是字符串 打开的地址，窗口标题，保存返回地址（可以是函数），宽，高，控件外包着的DIV的ID，是否有另存为格式{Name:'名称',Url:'地址',Function:函数}，遮罩名称，标题内容，内容显示，窗口显示完之后执行函数
function GridModiy(gridList, Url, Title, ReturnUrl, W, H, FormName, OtherSave, ParentName, MessageTitle, Message, ShowFunction, PostReturnFunction, SelectEd, PostFunction, CancelEvent, Diag) {
    var itemlist = "";
    if (typeof (gridList) == "string") {
        itemlist = gridList;
    } else {
        if (SelectEd) {
            var items = $('.trSelected', gridList);
            for (i = 0; i < items.length; i++) {
                itemlist += items[i].id.substr(3) + ",";
            }
            items = null;
            if (itemlist.length > 0) {
                itemlist = itemlist.Left(itemlist.length - 1);
            } else {
                Dialog.alert(SycmsLanguage.Admin.GridProperty.l1);
            }
        } else {
            if ($('.trSelected', gridList).length == 1) {
                var items = $('.trSelected', gridList);
                for (i = 0; i < items.length; i++) {
                    itemlist += items[i].id.substr(3) + ",";
                }
                items = null;
                itemlist = itemlist.Left(itemlist.length - 1);
            } else {
                Dialog.alert(SycmsLanguage.Admin.GridModiy.l1);
            }
        }
    }
    if (itemlist.length > 0) {
        if (typeof (Url) == "string") {
            if (Url.indexOf("?") == -1) {
                Url += "?id=" + itemlist;
            } else {
                Url += "&id=" + itemlist;
            }
            if (OtherSave) {
                if (OtherSave.Url.indexOf("?") == -1) {
                    OtherSave.Url += "?id=" + itemlist;
                } else {
                    OtherSave.Url += "&id=" + itemlist;
                }
            }
            CreateWindow(Url, Title, ReturnUrl, W, H, FormName, OtherSave, ParentName, MessageTitle, Message, ShowFunction, PostReturnFunction, null, null, PostFunction, Diag, null, CancelEvent);
        } else { 
            (Url)(itemlist);
        }
    }
}

//列表里面取值之后打开界面右边
function GridList(gridList, Url, Content) {
    var itemlist = '';
    if (typeof (gridList) == "string") {
        itemlist = gridList;
    } else {
        if ($('.trSelected', gridList).length == 1) {
            var items = $('.trSelected', gridList);
            for (i = 0; i < items.length; i++) {
                itemlist += items[i].id.substr(3) + ",";
            }
            items = null;
            itemlist = itemlist.Left(itemlist.length - 1);
        } else {
            Dialog.alert(SycmsLanguage.Admin.GridList.l1);
        }
    }
    if (itemlist.length > 0) {
        if (Url.indexOf("?") == -1) {
            Url += "?id=" + itemlist;
        } else {
            Url += "&id=" + itemlist;
        }
        AjaxFun(Url, "", Content, ".Rnr", ".Rnr");
    }
}


//取FORMName 一个ID 内所有 控件的值 。。
function ReadInputValue(FormName, IsNoInput, IsNoSelect, IsNoTextArea, ObjName) {
    var ReturnVal = new Array();
    var FormObj;
    if (FormName) {
        if (typeof (FormName) == "object") {
            FormObj = $(FormName);
        } else {
            if (FormName.Left(1) != "#" && FormName.Left(1) != ".") {
                FormObj = $("#" + FormName);
            } else {
                FormObj = $(FormName);
            }
        }
    } else {
        FormObj = $(document.body);
    }
    if (!IsNoInput) {
        var InputName = new Array();
        var InputList = FormObj.find("input");
        InputList.each(function () {
            var InputObj = $(this);
            var InputN = InputObj.attr("name");
            if (InputN) {
                if (("," + InputName + ",").indexOf("," + InputN + ",") == -1 && (!ObjName || ObjName == InputN)) {
                    InputName.push(InputN);
                    switch (InputObj.attr("type")) {
                        case "button":
                        case "file":
                        case "image":
                        case "reset":
                        case "submit":
                            {
                                break;
                            }
                        case "checkbox":
                            {
                                var CheckList = InputList.filter("[name='" + InputN + "']:checked");
                                var CheckValue = new Array();
                                CheckList.each(function () {
                                    CheckValue.push(encodeURIComponent($(this).val()));
                                });
                                if (CheckValue.length > 0) {
                                    ReturnVal.push(InputN + "=" + CheckValue.join(","));
                                }
                                CheckList = null;
                                CheckValue = null;
                                break;
                            }
                        case "radio":
                            {
                                var RadioList = InputList.filter("input[name='" + InputN + "']:checked");
                                if (RadioList.length > 0) {
                                    var RadioValue = encodeURIComponent(RadioList.eq(0).val());
                                    if (RadioValue) {
                                        ReturnVal.push(InputN + "=" + RadioValue);
                                    }
                                }
                                break;
                            }
                        default:
                            {
                                var InputValue = InputList.filter("[name='" + InputN + "']");
                                if (InputValue.length > 0) {
                                    var Ivalue = new Array();
                                    InputValue.each(function () {
                                        var IvalueFck = $("#" + InputN + "___Config").length;
                                        if (IvalueFck > 0) {
                                            var ValueFck = "";
                                            try {
                                                ValueFck = CkeditorGetHtml(InputN);
                                            } catch (e) {
                                                ValueFck = $(this).val();
                                            }
                                            var regExp = new RegExp('\\?imgLoad=(.*?)imgLoad', "img");
                                            ValueFck = ValueFck.replace(regExp, "");
                                            if (ValueFck != null && ValueFck != undefined) {
                                                Ivalue.push(encodeURIComponent(ValueFck));
                                            }
                                        } else {
                                            Ivalue.push(encodeURIComponent($(this).val()));
                                        }
                                    });
                                    if (Ivalue.length > 0) {
                                        ReturnVal.push(InputN + "=" + Ivalue.join(","));
                                    }
                                    Ivalue = null;
                                }
                                InputValue = null;
                                break;
                            }
                    }
                }
            }
            InputObj = null;
            InputN = null;
        });
        InputName = null;
        InputList = null;
    }
    if (!IsNoSelect) {
        var SelectList = FormObj.find("select");
        SelectList.each(function () {
            var SelectObj = $(this);
            var SelectN = SelectObj.attr("name");
            if (SelectN && (!ObjName || ObjName == SelectN)) {
                var SelectType = SelectObj.attr("Type");
                if (SelectType && SelectType == "Select") {
                    var SIvalue = new Array();
                    var OptionSelect = SelectObj.find("option");
                    OptionSelect.each(function () {
                        var v = $(this).val();
                        if (v.length > 0) {
                            SIvalue.push(encodeURIComponent(v));
                        }
                    });
                    if (SIvalue.length > 0) {
                        ReturnVal.push(SelectN + "=" + SIvalue.join(","));
                    }
                    SIvalue = null;
                    OptionSelect = null;
                } else {
                    var val = SelectObj.val();
                    if (val != null && val != undefined && val.length > 0) {
                        ReturnVal.push(SelectN + "=" + encodeURIComponent(val))
                    }
                    val = null;
                }
                SelectType = null;
            }
            SelectObj = null;
            SelectN = null;
        });
        SelectList = null;
    }
    if (!IsNoTextArea) {
        var TextAreaList = FormObj.find("textarea");
        TextAreaList.each(function () {
            var SelectObj = $(this);
            var SelectN = SelectObj.attr("name");
            if (SelectN && (!ObjName || ObjName == SelectN)) {
                var IvalueFck = $("#" + SelectN + "___Config").length;
                var val = "";
                var cc = "#" + IvalueFck + "-";
                if (IvalueFck > 0) {
                    try {
                        val = CkeditorGetHtml(SelectN);
                        //if (val == null || val == undefined) {
                        //    val = SelectObj.val();
                        //}
                        var regExp = new RegExp('\\?imgLoad=(.*?)imgLoad', "img");
                        val = val.replace(regExp, "");
                    } catch (e) {
                        val = SelectObj.val();
                    }
                } else {
                    val = SelectObj.val();
                }
                if (val != null && val != undefined && val.length > 0) {
                    ReturnVal.push(SelectN + "=" + encodeURIComponent(val));
                }
                val = null;
                IvalueFck = null;
            }
            SelectN = null;
            SelectObj = null;
        });
        TextAreaList = null;
    }
    IECollectGarbage();
    return ReturnVal.join("&");
}
//判断验证
function AddReturnValidationEngine(FormName)
{
    return $(FormName).validationEngine({ returnIsValid: true });
}

//关闭提示窗口
function RemoveAltValidationEngine(FormName) {
    $.validationEngine.closePrompt('.formError', true);
}

//窗口显示调用函数 要显示的地址  窗口标题  确定地址  宽  高  控件外面包着的ID名称  其它按钮的名称格式为格式{Name:'名称',Url:'地址',Function:函数,FormName:名称,PostReturnFunction:函数}  遮罩的名称 显示内容的标题 显示的内容 显示之后运行的函数 提交之后运行的函数
function CreateWindow(Url, Title, ReturnUrl, W, H, FormName, OtherSave, ParentName, MessageTitle, Message, ShowFunction, PostReturnFunction, HtmlFunction, HtmlCon, PostFunction, Drag, UrlData, CancelEvent, AjaxTitle) {
    var AjaxCreateWindow = function (html) {
        var CreateWindowdiag = new Dialog();
        CreateWindowdiag.Width = W;
        CreateWindowdiag.Height = H;
        CreateWindowdiag.Title = Title;
        CreateWindowdiag.Drag = (Drag != undefined ? Drag : false);
        CreateWindowdiag.ShowButtonRow = true;
        CreateWindowdiag.MessageTitle = MessageTitle;
        CreateWindowdiag.Message = Message;
        if (HtmlFunction) {
            if (typeof (HtmlFunction) == "function") {
                html = HtmlFunction(html);
            }
        }
        CreateWindowdiag.InnerHtml = html;
        if (ReturnUrl) {
            CreateWindowdiag.OKEvent = function () {
                var jx = true;
                if (PostFunction) {
                    if (typeof (PostFunction) == "function") {
                        jx = PostFunction(FormName);
                    }
                }
                if (jx) {
                    if (FormName) {
                        if (AddReturnValidationEngine("#" + FormName)) {
                            if (typeof (ReturnUrl) == "string") {
                                CreateWindowFun(ReturnUrl, FormName, CreateWindowdiag, ParentName, PostReturnFunction, null, AjaxTitle);
                            } else if (typeof (ReturnUrl) == "function") {
                                ReturnUrl(CreateWindowdiag, FormName, ParentName, PostReturnFunction);
                            }
                        } else {
                            setTimeout(function () { RemoveAltValidationEngine("#" + FormName);}, 1000 * ErrViewTime);
                        }
                    } else {
                        if (typeof (ReturnUrl) == "string") {
                            CreateWindowFun(ReturnUrl, FormName, CreateWindowdiag, ParentName, PostReturnFunction, null, AjaxTitle);
                        } else if (typeof (ReturnUrl) == "function") {
                            ReturnUrl(CreateWindowdiag, FormName, ParentName, PostReturnFunction);
                        }
                    }
                }
                $(".popUpMenu").hide();
            };
        }
        CreateWindowdiag.CancelEvent = function () {
            $(".popUpMenu").hide();
            if (FormName) {
                RemoveAltValidationEngine("#" + FormName);
                if ($("#" + FormName).is_form_changed()) { //有改变
                    Dialog.confirm(SycmsLanguage.Admin.CreateWindow.l1, function () {
                        var ImgList = $("#" + FormName + " #ImgListInput").val();
                        if (ImgList && ImgList.length > 0) {
                            AjaxFun('AdminFun/Del_Pic.aspx', "PicUrl=" + encodeURIComponent(ImgList), SycmsLanguage.Admin.CreateWindow.l2, null, 'False', null, null, '100%', 30, 1, 1);
                        }
                        CreateWindowdiag.close();
                    });
                } else {
                    var ImgList = $("#" + FormName + " #ImgListInput").val();
                    if (ImgList && ImgList.length > 0) {
                        AjaxFun('AdminFun/Del_Pic.aspx', "PicUrl=" + encodeURIComponent(ImgList), SycmsLanguage.Admin.CreateWindow.l2, null, 'False', null, null, '100%', 30, 1, 1);
                    }
                    CreateWindowdiag.close();
                    CreateWindowdiag = null;
                }
            } else {
                CreateWindowdiag.close();
                CreateWindowdiag = null;
            }
            ImgListForm = null;
            if (CancelEvent) {
                if (typeof (CancelEvent) == "function") {
                    CancelEvent();
                }
            }
        }
        CreateWindowdiag.show();
        if (!ReturnUrl) {
            CreateWindowdiag.okButton.style.display = "none";
            CreateWindowdiag.cancelButton.value = SycmsLanguage.Admin.CreateWindow.l3;
        }
        if (FormName) {
            $("#" + FormName).enable_changed_form();
        }
        if (OtherSave) {
            CreateWindowdiag.addButton("next", OtherSave.Name, function () {
                if (OtherSave.Function) {
                    if (typeof (OtherSave.Function) == "function") {
                        OtherSave.Function(CreateWindowdiag, FormName);
                    }
                }
                if (FormName) {
                    if (AddReturnValidationEngine("#" + FormName)) {
                        if (typeof (OtherSave.Url) == "string") {
                            CreateWindowFun(OtherSave.Url, FormName, CreateWindowdiag, ParentName, (OtherSave.PostReturnFunction ? OtherSave.PostReturnFunction : PostReturnFunction), OtherSave.FormName, OtherSave.AjaxTitle);
                        } else if (typeof (OtherSave.Url) == "function") {
                            OtherSave.Url(CreateWindowdiag, FormName, ParentName, (OtherSave.PostReturnFunction ? OtherSave.PostReturnFunction : PostReturnFunction));
                        }
                    } else {
                        setTimeout(function () { RemoveAltValidationEngine("#" + FormName); }, 1000 * ErrViewTime);
                    }
                } else {
                    if (typeof (OtherSave.Url) == "string") {
                        CreateWindowFun(OtherSave.Url, FormName, CreateWindowdiag, ParentName, (OtherSave.PostReturnFunction ? OtherSave.PostReturnFunction : PostReturnFunction), null, OtherSave.AjaxTitle);
                    } else if (typeof (OtherSave.Url) == "function") {
                        OtherSave.Url(CreateWindowdiag, FormName, ParentName, (OtherSave.PostReturnFunction ? OtherSave.PostReturnFunction : PostReturnFunction));
                    }
                }
                $(".popUpMenu").hide();
            });
        }
        if (FormName) {
            $("#" + FormName).find("input[type=text]").bind("keydown", function () {
                e = getEvent();
                var a = e.keyCode;
                if (a == 13) { CreateWindowdiag.OKEvent(); return false; }
                e = null;
                a = null;
            });
            $("#" + FormName).find("textarea").bind("keydown", function () {
                e = getEvent();
                var a = e.keyCode;
                if (e.altKey && a == 13) { CreateWindowdiag.OKEvent(); return false; }
                e = null;
                a = null;
            });
        }
        if (ShowFunction) {
            if (typeof (ShowFunction) == "function") {
                ShowFunction(CreateWindowdiag);
            }
        }
    }
    if (Url) {
        AjaxFun(Url, UrlData, SycmsLanguage.Admin.CreateWindow.l4, function (html) { AjaxCreateWindow(html); }, ParentName);
    }else if(HtmlCon)
    {
        AjaxCreateWindow(HtmlCon);
    }
}

function WindowsReturnHeight(str, width) {
    var temp = document.createElement("div");
    temp.innerHTML = "<div class=\"DialogContent\" style=\"font-size:12px;word-wrap:break-word;word-break:break-all;width:" + width + "px\">" + str + "</div>";
    document.body.appendChild(temp);
    var height = temp.offsetHeight;
    temp.parentNode.removeChild(temp);
    if (height < 60) {
        height = 60;
    } else {
        height += 40;
    }
    return height;
}


//弹出窗口判断错误或者是结果窗口


//返回类型为   ['1'，'错误代码语言','input控件ID',"0"]
//-1为要求登录。
//0为错误
//1为成功。

//最后面0为弹出关闭的窗口，不自动关闭

function WindowsReturn(html, ParentName) {
    var Return = { ok: true, html: html };
    var regExp = /<script[^>]*>([\s\S]*?)<\/script>/gi;
    var ReturnValue = html.replace(regExp, "");
    var FristIndex = ReturnValue.lastIndexOf("[");
    if (FristIndex != -1 && FristIndex <= 5)
    {
        ReturnValue = ReturnValue.substr(FristIndex);
    }
    var LastIndex = ReturnValue.lastIndexOf("]");
    if (LastIndex != -1) {
        ReturnValue = ReturnValue.substr(0, LastIndex) + "]";
    }
    if (ReturnValue.length > 0 && ReturnValue.substr(0, 1) == "[" && ReturnValue.indexOf("[") != -1 && ReturnValue.indexOf("]") != -1) {
        var ReturnValueArray = ReturnValue.split(']');
        for (var i = 0; i < ReturnValueArray.length; i++) {
            if (ReturnValueArray[i].length > 0) {
                try {
                    ReturnValue = eval(ReturnValueArray[i] + "]");
                } catch (e) { }
                if (typeof (ReturnValue) == "object") {
                    var isreplace = false;
                    try {
                        if (ReturnValue[0] == "-1")        //调用登录
                        {
                            UserLogin();
                            Return.ok = false;
                            isreplace = true;
                        } else if (ReturnValue[0] == "0") {
                            isreplace = true;
                            if (ReturnValue[3] == "0") {
                                LoadWarting(SycmsLanguage.Admin.WindowsReturn.l1, ReturnValue[1], "error", 0, ParentName, null, null, 400, WindowsReturnHeight(ReturnValue[1], 300), ReturnValue[4]);
                            } else {
                                LoadWarting(" ", ReturnValue[1], (ReturnValue[3] ? "" : "error"), (ReturnValue[3] ? 0 : ErrViewTime), ParentName, null, null, null, null, ReturnValue[4]);
                            }
                            if (ReturnValue[2]) {
                                setTimeout(function () { $('#' + ReturnValue[2]).focus(); }, 4000);
                            }
                            if (!ReturnValue[4]) {
                                Return.ok = false;
                            }
                        } else if (ReturnValue[0] == "1") {
                            isreplace = true;
                            if (ReturnValue[1] && ReturnValue[1].length > 0) {
                                if (ReturnValue[3] == "0") {
                                    LoadWarting(SycmsLanguage.Admin.WindowsReturn.l2, ReturnValue[1], "success", 0, ParentName, null, null, 400, WindowsReturnHeight(ReturnValue[1], 300), ReturnValue[4]);
                                } else {
                                    LoadWarting(" ", ReturnValue[1], (ReturnValue[3] ? "" : "success"), (ReturnValue[3] ? 0 : ErrViewTime), ParentName, null, null, null, null, ReturnValue[4]);
                                }
                            }
                        } else if (ReturnValue[0] == "2") {
                            isreplace = true;
                            ReturnValue[1] = decodeURIComponent(ReturnValue[1]);
                            if (!ReturnValue[2] || ReturnValue[2] == "0") {
                                evalJavaScript(ReturnValue[1]);
                            } else {
                                SyCmsRunMessage = ReturnValue[1];
                                setTimeout(function () { evalJavaScript(SyCmsRunMessage); SyCmsRunMessage = "";}, parseInt(ReturnValue[2]));
                            }
                        }
                        if (isreplace)
                        {
                            html = html.replace(ReturnValueArray[i] + "]", "");
                            Return.html = html;
                        }
                    } catch (e) {
                        LoadWarting(" ", e.MessageBox, "error", ErrViewTime, ParentName);
                        Return.ok = false;
                    }
                }
            }
        }
    }
    regExp = null;
    ReturnValue = null;
    return Return;
}
//保存回调函数
function CreateWindowFun(ReturnUrl, DivFormName, CreateWindowdiag, ParentName, PostReturnFunction, FormName, AjaxTitle) {
    var load = LoadWarting('', SycmsLanguage.Admin.CreateWindowFun.l1);
    setTimeout(function () {
        var PostValue = ReadInputValue(DivFormName);
        load.close();
        load = null;
        AjaxFun(ReturnUrl, PostValue, AjaxTitle ? AjaxTitle : SycmsLanguage.Admin.CreateWindowFun.l2, function (html, Windowdiag) {
            if (FormName) {
                $("#" + FormName).get(0).reset();
                //删除记录的文件信息。
                $("#" + FormName).find("#ImgListInput").val("");
                if (typeof (PostReturnFunction) == "function") {
                    PostReturnFunction(html, Windowdiag);
                }
            } else {
                if (typeof (PostReturnFunction) == "function") {
                    PostReturnFunction(html, Windowdiag);
                }
                if (Windowdiag) {
                    Windowdiag.close();
                    Windowdiag = null;
                }
            }
        }, null, CreateWindowdiag);
        PostValue = null;
    }, 200);
}

//显示load窗口  标题  内容  内容前图片地址  自动关闭时间   父级div(如果为False时关闭背景图）
function LoadWarting(Title, Content, Url, Time, ParentNode, X, Y, W, H, ObjMessViewWin, ObjMessViewWinID) {
    if (MessViewWin == 1 || ObjMessViewWin) {
        if (Time) {
            jQuery.noticeAdd({
                text: Content,
                stay: false,
                stayTime: Time * 1000,
                type: Url,
                id: ObjMessViewWinID ? ObjMessViewWinID : false
            });
        } else {
            jQuery.noticeAdd({
                text: Content,
                stay: true,
                type: Url,
                id: ObjMessViewWinID ? ObjMessViewWinID : false
            });
        }
        return null;
    } else {
        var LoadWartingdiag1 = new Dialog();
        if (Time) {
            LoadWartingdiag1.AutoClose = parseInt(Time);
            LoadWartingdiag1.ShowCloseButton = false;
        }
        if (!Url) {
            Url = "load";
        }
        if (!X) {
            X = 0;
        }
        if (!Y) {
            Y = 0;
        }
        if (ParentNode) {
            if (ParentNode == "False") {
                LoadWartingdiag1.Modal = false;
            } else {
                try {
                    $(ParentNode).get(0).obj.close();
                } catch (e) { }
                //var S = getElCoordinate($(ParentNode).get(0));
                //if (Content && Content.Trim().length > 0) {
                //    Y = S.top + (S.height / 2) - 40;
                //    X = S.left + (S.width / 2) - 150;
                //} else {
                //    Y = S.top + (S.height / 2) - 40;
                //    X = S.left + (S.width / 2) - 50;
                //}
                //$(ParentNode).get(0).obj = LoadWartingdiag1;
                //if (X < 0) {
                //    X = 0;
                //}
                //if (Y < 0) {
                //    Y = 0;
                //}
                //LoadWartingdiag1.ModalParent = $(ParentNode).get(0);
                //S = null;
            }
        }
        if (X) {
            LoadWartingdiag1.Left = X;
        }
        if (Y) {
            LoadWartingdiag1.Top = Y;
        }
        LoadWartingdiag1.Title = Title;
        if (Content.Trim()) {
            if (W && H) {
                LoadWartingdiag1.Width = W;
                LoadWartingdiag1.Height = H;
            } else {
                LoadWartingdiag1.Width = 260;
                var height = WindowsReturnHeight(Content.Trim(), 200);
                if (height > 100) {
                    LoadWartingdiag1.Width = 450;
                    height = WindowsReturnHeight(Content.Trim(), 400);
                }
                LoadWartingdiag1.Height = height;
            }
            LoadWartingdiag1.InnerHtml = '<table height="100%" width="100%" border="0" align="center" cellpadding="10" cellspacing="0">\
		    <tr><td align="right" width="60">' + (Url == "load" ? '<div style="background:url(' + IMAGESPATH + 'icon_' + Url + '.gif) center no-repeat;width:32px;height:32px;"> </div>' : '<img src="' + IMAGESPATH + 'icon_' + Url + '.png" width="32" height="32" align="absmiddle">') + '</td>\
			    <td align="left" class="DialogContent" style="font-size:12px;word-wrap:break-word;word-break:break-all">' + Content + '</td></tr>\
	        </table>';
        } else {
            if (W && H) {
                LoadWartingdiag1.Width = W;
                LoadWartingdiag1.Height = H;
            } else {
                LoadWartingdiag1.Width = 80;
                LoadWartingdiag1.Height = 60;
            }
            LoadWartingdiag1.InnerHtml = '<table height="100%" width="100%" border="0" align="center" cellpadding="10" cellspacing="0">\
		    <tr><td align="center">' + (Url == "load" ? '<div style="background:url(' + IMAGESPATH + 'icon_' + Url + '.gif) center no-repeat;width:32px;height:32px;"> </div>' : '<img src="' + IMAGESPATH + 'icon_' + Url + '.png" width="32" height="32" align="absmiddle">') + '</td></tr>\
	        </table>';
        }
        LoadWartingdiag1.Drag = false;
        LoadWartingdiag1.show();
        return LoadWartingdiag1;
    }
}
//改变大小
function WinSizeFun(objWin) {
    if (navigator.userAgent.indexOf('MSIE 6.0') != -1) {        //ie6要判断
        $(objWin).unbind();
    }
    Wh = $(objWin).height();
    Ww = $(objWin).width();
    var obj = $(".l_nav");
    if (obj.length > 0) {
        obj.css("height", Wh - 99);
    }
    //$("#login").css("top", Wh / 2 - 200);
    //$("#login").css("left", Ww / 2 - 200);
    RightFun(obj);
    if (navigator.userAgent.indexOf('MSIE 6.0') != -1) {    //ie6要判断
        setTimeout(function() {
            $(objWin).resize(function() {
                WinSizeFun(objWin);
            });
        }, 50);
    }
    obj=null;
    IECollectGarbage();
}
//左边宽度
function RightFun(obj) {
    var objd = obj[0].style.display;
    if (objd == "none") {
        RightW = 60;
    } else {
        RightW = 235;
    }
    obj = $(".Rnr")
    if (obj.length > 0) {
        obj.css("height", Wh - RightH);
        obj.css("width", Ww - RightW);
    }
    var AddSizeList = null;
    try {
        AddSizeList = $(window).attr("AddSizeList");
    } catch (e) { }
    if (AddSizeList) {
        for (var i = 0; i < AddSizeList.length; i++) {
            if (AddSizeList[i][0].length > 0) {
                var $Pobj = $(AddSizeList[i][0]);
                if ($Pobj.length > 0) {
                    var h = 0, w = 0;
                    if (AddSizeList[i][0] == ".Rnr") {
                        h = Wh - RightH;
                        w = Ww - RightW;
                    } else {
                        h = $Pobj.height();
                        w = $Pobj.width();
                    }
                    if (AddSizeList[i][4] == "1") {
                        AddSizeList[i][1].flexResize(w - AddSizeList[i][3], h - AddSizeList[i][2]);
                    } else {
                        var $obj1 = $(AddSizeList[i][1]);
                        if ($obj1.length > 0) {
                            $obj1.css("height", h - AddSizeList[i][2]);
                        } else {
                            AddSizeList[i][0] = "";
                        }
                        $obj1=null;
                    }
                    h=null;
                    w=null;
                } else {
                    AddSizeList[i][0] = "";
                }
                $Pobj=null;
            }
        }
    }
    AddSizeList=null;
    objd=null;
    IECollectGarbage();
}

//打开关闭左边
function CloseLeft(obj) {
    var leftDiv = $(obj).parent().parent().parent().parent();
    if (obj.src.indexOf("images/L_an1.gif") != -1) {
        obj.src = "images/L_an2.gif";
        $("#Left_1").hide();
        $("#Left_2").hide();
        leftDiv.attr("width","40");
    } else {
        obj.src = "images/L_an1.gif";
        $("#Left_1").show();
        $("#Left_2").show();
        leftDiv.attr("width", "");
    }
    RightFun($(".l_nav"));
}

///换验证码
function checkwd_reload() {
    $id("chk_img").src = 'ValidateCode.aspx?' + new Date();
}

//登录窗口  initialize为进系统调用
function UserLogin(initialize) {
    var obj = $("#login");
    obj.show();
    obj.find("#userName").val("").bind("keydown", function() {
        e = getEvent();
        var a = e.keyCode;
        if (a == 13) { $("#LoginButton").get(0).click(); return false; }
        e=null;
        a=null;
    });
    obj.find("#userPass").val("").bind("keydown", function() {
        e = getEvent();
        var a = e.keyCode;
        if (a == 13) { $("#LoginButton").get(0).click(); return false; }
        e=null;
        a=null;
    });
    obj.find("#Code").val("").bind("keydown", function() {
        e = getEvent();
        var a = e.keyCode;
        if (a == 13) { $("#LoginButton").get(0).click(); return false; }
        e=null;
        a=null;
    });

    var zindex=100;
    if (topWin.Dialog._Array.length > 0) {
        zindex = topWin.Dialog._Array[topWin.Dialog._Array.length - 1].zindex + 2;
    }

    //获得弹出层的z-index
    
    $id("chk_img").src = 'ValidateCode.aspx?' + new Date();
    obj.css("z-index", zindex);
    obj.find("#userName").focus();
    $("#AdminMessage").hide();
    $("#LoginButton").unbind().bind("click", function() {
        this.blur();
        if (AddReturnValidationEngine('#login')) {
            var Data = ReadInputValue("login");
            if (initialize) {
                AjaxFun("Default.aspx", Data, SycmsLanguage.Admin.UserLogin.l1, function (html) {
                    LoadWindow();
                });
            } else {
                AjaxFun("Default.aspx", Data, SycmsLanguage.Admin.UserLogin.l1, function (html) {
                    $("#login").hide();
                    $("#AdminMessage").show();
                });
            }
            Data=null;
        } else {
            setTimeout(function () { RemoveAltValidationEngine("#login"); }, 1000 * ErrViewTime);
        }
    });
    obj=null;
    zindex=null;
}
///用户退出
function UserLogOut() {
    zringCheckUnload = false;
    AjaxFun("LogOut.aspx", "", SycmsLanguage.Admin.UserLogOut.l1, function (html) {
        window.location.reload();
    });
}

///第一次调用登录
function LoadWindow() {
    var LoadMess = LoadWarting("", SycmsLanguage.Admin.LoadWindow.l1 + "<div style=\"height:12px;\" id=\"spaceused1\">0%</div>");
    $("#spaceused1").progressBar(1);
    $('#spaceused1').progressBar(20);
    AjaxFun("UserMess.aspx", "", "", function (html) {
        $("#UseerNameMessage").html(html);
        $('#spaceused1').progressBar(40);
        AjaxFun("Left.aspx", "", "", function (html) {
            $(".l_nav").html(html);
            $('#spaceused1').progressBar(60);
            AjaxFun("Main.aspx", "", "", function (html) {
                $(".Rnr").hide().html(html).btnForMat().inputForMat().show();
                $('#spaceused1').progressBar(80);
                LoadWindowOk(LoadMess);
                IECollectGarbage();
                setTimeout(function () {
                    if (getBrowserOStr != "Firefox") {
                        LoadWarting(SycmsLanguage.Admin.LoadWindow.l2, SycmsLanguage.Admin.LoadWindow.l3, "success", 0, null, null, null, 400, null, 1);
                    }
                }, 1000);
            });

        });
    });
}

//自动调用函数
function AutoTask(ObjHtml)
{
    AutoTask_Two(ObjHtml);
}
//自动调用函数
function AutoTask_Two(ObjHtml) {
    var Str = new Array();
    var icount = 0;
    if (ObjHtml) {
        for (var i = 0; i < ObjHtml.length; i++) {
            switch (ObjHtml[i].MessType) {
                case "0":
                    {
                        LoadWarting(" ", decodeURIComponent(ObjHtml[i].Content), "", 0, null, null, null, null, null, 1);
                        break;
                    }
                case "1":
                    {
                        ReLoadJS(ObjHtml[i].Content, true);
                        break;
                    }
                case "2":
                    {
                        icount++;
                        Str.push("<li><span style=\"float:right;\"><a href=\"\" onclick=\"SystemAuditCreateWin('Arti',1," + ObjHtml[i].Type + "," + ObjHtml[i].ClassID + ",0," + ObjHtml[i].ArtiID + ",'');return false;\">&nbsp;&nbsp; 审核</a></span><font color=\"#F5B50D\">待审</font>：<a href=\"\" onclick=\"return ArtiList(" + ObjHtml[i].Type + "," + ObjHtml[i].ClassID + "," + ObjHtml[i].ArtiID + ");\">" + decodeURIComponent(ObjHtml[i].Content.replace("+", " ")) + "</a></li>");
                        break;
                    }
                case "3":
                    {
                        icount++;
                        Str.push("<li><span style=\"float:right;\"><a href=\"\" onclick=\"SystemAuditCreateWin('Arti',0," + ObjHtml[i].Type + "," + ObjHtml[i].ClassID + ",0," + ObjHtml[i].ArtiID + ",'');return false;\">&nbsp;&nbsp; 查看</a></span><font color=\"red\">驳回</font>：<a href=\"\" onclick=\"return ArtiList(" + ObjHtml[i].Type + "," + ObjHtml[i].ClassID + "," + ObjHtml[i].ArtiID + ");\">" + decodeURIComponent(ObjHtml[i].Content.replace("+", " ")) + "</a></li>");
                        break;
                    }
            }
        }
    }
    var SycmsTaskMess = $("#notice_SycmsTaskMess");
    if (Str.length > 0) {
        var SycmsTaskMessView = $("#SycmsTaskMessView");
        if (SycmsTaskMess && SycmsTaskMess.length > 0) {
            SycmsTaskMessView.html("<ol>" + Str.join("") + "</ol>");
            if (icount > 10) {
                SycmsTaskMessView.addClass("taskmess");
            } else {
                SycmsTaskMessView.removeClass("taskmess");
            }
        } else {
            LoadWarting(" ", "<div id=\"SycmsTaskMessView\"" + (icount > 10 ? " class=\"taskmess\"" : "") + "><ol>" + Str.join("") + "</ol></div>", "", 0, null, null, null, 300, 200, 1, "SycmsTaskMess");
        }
    } else {
        SycmsTaskMess.remove();
    }
}

function LoadWindowOk(LoadMess) {
//预加载图片
    $('#spaceused1').progressBar(100);
    setTimeout(function() {
        LoadMess.close();
        LoadMess=null;
    }, 1000);
    $("#AdminMessage").show();
    $("#login").hide();
}


//绑定滚动条    上级DIV   下级DIV  高差度
function ScrollFun(ParentObj, Obj, H) {
    if (!H) {
        H = 0;
    }
    var $Pobj = $(ParentObj);
    var $obj1 = $(Obj);
    var h = $Pobj.height();
    $obj1.css("height", h - H);

    var AddSizeList = null;
    try {
        AddSizeList = $(window).attr("AddSizeList");
    } catch (e) { }
    if (!AddSizeList) {
        AddSizeList = new Array();
    }
    DelAddSizeList(AddSizeList, ParentObj,"0");
    AddSizeList.push([ParentObj, Obj, H, 0, "0"]);
    //$(window).attr("AddSizeList", AddSizeList);
    $Pobj=null;
    $obj1=null;
    AddSizeList=null;
    h=null;
}
///删除事件连锁
function DelAddSizeList(AddSizeList, ParentObj,Type) {
    for (var i = 0; i < AddSizeList.length; i++) {
        if ((AddSizeList[i][0] == ParentObj && AddSizeList[i][4] == Type) || AddSizeList[i][0].length==0) { 
            AddSizeList.splice(i,1);
            break;
        }
    }
}

//绑定上级DIV Grid
function GridFun(ParentObj, GridObj, H, W) {
    if (!H) {
        H = 0;
    }
    if (!W) {
        W = 0;
    }
    var AddSizeList = null;
    try {
        $(window).attr("AddSizeList");
    } catch (e) { }
    if (!AddSizeList) {
        AddSizeList = new Array();
    }
    DelAddSizeList(AddSizeList, ParentObj, "1");
    AddSizeList.push([ParentObj, GridObj, H, W, "1"]);
    $(window).attr("AddSizeList", AddSizeList);
    var $Pobj = $(ParentObj);
    var h = $Pobj.height();
    var w = $Pobj.width();
    GridObj.flexResize(w - W, h - H);
    $Pobj = null;
    h = null;
    w = null;
    AddSizeList = null;
}
//提示JS
function DoLoadJs(str) {
    var regExp_src = /<script[^<>]*src\s*=\s*["']([^"']*)["'].*>[^<>]*<\/script>/gi;
    var matchArray_src = str.match(regExp_src);
    if (matchArray_src) {
        for (var i = 0; i < matchArray_src.length; i++) {
            var str_temp = matchArray_src[i].toString();
            var regExp_src_temp = /src=("|'|)([^"'<>]+)(\1)/img;
            var matchArray_src1 = str_temp.match(regExp_src_temp);
            for (var j = 0; j < matchArray_src1.length; j++) {
                ReLoadJS(matchArray_src1[j].replace(regExp_src_temp, "$2"));
            }
        }
        str = str.replace(regExp_src, "");
    }
    return str;
}
//提示样式
function DoLoadCss(str) {
    var regExp_src = /<link[^<>]*href\s*=\s*["']([^"']*)["'][^<>]*\/>/gi;
    var matchArray_src = str.match(regExp_src);
    if (matchArray_src) {
        for (var i = 0; i < matchArray_src.length; i++) {
            var str_temp = matchArray_src[i].toString();
            var regExp_src_temp = /href=("|'|)([^"'<>]+)(\1)/img;
            var matchArray_src1 = str_temp.match(regExp_src_temp);
            for (var j = 0; j < matchArray_src1.length; j++) {
                var src = matchArray_src1[j].replace(regExp_src_temp, "$2");
                if (src.indexOf(".css") != -1) {
                    ReLoadCss(matchArray_src1[j].replace(regExp_src_temp, "$2"));
                }
            }
        }
        str = str.replace(regExp_src, "");
    }
    return str;
}

//执行代码之后返回HTML  Ajax配置使用
function RunJavaScript(Html, Function, NoScript, NoLoad) {
    var regExp = /<script[^>.]*>([\s\S]*?)<\/script>/gi;
    var ajaxjavascript1 = /<script.+?>/gi;
    var ajaxjavascript2 = /<\/script>/gi;
    var returnValue = Html;
    if (!NoScript && !NoLoad) {
        returnValue = DoLoadJs(returnValue);
        returnValue = DoLoadCss(returnValue);
    }
    var jlzrun = "";
    var javarun = returnValue.replace("\n", "").replace("\r", "").match(regExp);
    if (!NoScript && javarun != null) {
        returnValue = returnValue.replace(regExp, "");
        for (var j = 0; j < javarun.length; j++)
            jlzrun = jlzrun + javarun[j];
        if (jlzrun != "") {
            jlzrun = jlzrun.replace(ajaxjavascript1, "");
            jlzrun = jlzrun.replace(ajaxjavascript2, "");
            setTimeout(function () {
                evalJavaScript(jlzrun);
                jlzrun = null;
                IECollectGarbage();
            }, (getBrowserOStr == "Chrome" ? 100 : 1));          //18毫秒后执行
        }
    }
    if (Function) {
        if (typeof (Function) == "string") {
            $(Function).hide();
            setTimeout(function () {
                $(Function).btnForMat().inputForMat().show();
                if (HelpView) {
                    $(Function).find(".jTip").JT_init();
                }
            }, (getBrowserOStr == "Chrome" ? 20 : 5));
        }
    }
    regExp=null;
    ajaxjavascript1=null;
    ajaxjavascript2=null;
    return returnValue;
}
function evalJavaScript(scripts) {
    if (scripts)
        (new Function(scripts))();
    //        (window.execScript) ? window.execScript(scripts) : window.setTimeout(scripts, 0);
}
///非新开页面提交数据保存
//FormName jquery对象格式
//Url 要保存的地址  为FORM对象时可以为空
//Content提示窗口内容 不填写提示"正在提交，请稍候......"
//Function 成功后执行的函数
//ParentNode 弹出的层覆盖的大小
//Window  传入的其它打开的窗口
//ErrorFunction  错误的时候提示
//Alert_X, Alert_Y, NoScript  弹出坐标 不执行脚本
function AjaxForm(FormName, Url, Content, Function, ParentNode, Window, ErrorFunction, Alert_X, Alert_Y, NoScript) {
    if (AddReturnValidationEngine(FormName)) {
        if (!Content) {
            Content = SycmsLanguage.Admin.AjaxForm.l1;
        }
        if (!Url) {
            Url = $(FormName).attr("action");
        }
        AjaxFun(Url, ReadInputValue(FormName), Content, Function, ParentNode, Window, ErrorFunction, Alert_X, Alert_Y, NoScript);
    }
    else {
        setTimeout(function () { RemoveAltValidationEngine(FormName); }, 2000);
    }
    return false;
}

//Ajax调入 地址   传送数据    弹出窗口显示内容   函数/#.格式的字段串    要显示的上级DIV     Window
//ParentNode 和Alert_X Alert_Y 冲突，如果前面有按前面走。
//IsLoadCompante 是否等于结束
function AjaxFun(Url, Data, Content, Function, ParentNode, Window, ErrorFunction, Alert_X, Alert_Y, NoScript, NoError, IsLoadCompante, NoLoad) {
    var AjaxFunWindow = null;
    if (Content) {
        AjaxFunWindow = LoadWarting("", Content, "", "", ParentNode, Alert_X, Alert_Y);
    }
    var yUrl = Url;
    var Type = "POST";
    if (Url.indexOf(".htm") == -1) {
        if (Url.indexOf("?") == -1) {
            Url += "?SyCmstime=" + Math.random();
        } else {
            Url += "&SyCmstime=" + Math.random();
        }
    } else {
        Type = "GET";
    }
    if (typeof (Function) == "string") {
        if (Function == ".Rnr") {
            $("#AdminCommon").show().unbind().bind("click", function () {
                var CommName = $(Function + " .Rtop .RlmM").html();
                if (CommName) {
                    CommName = CommName.ClearHtml().Trim();
                } else {
                    CommName = "";
                }
                CreateWindow("AdminFun/Add_Comm.aspx?CommName=" + encodeURIComponent(CommName) + "&CommUrl=" + encodeURIComponent(yUrl) + "&CommPost=" + encodeURIComponent(Data), SycmsLanguage.Admin.AjaxFun.l1, "AdminFun/Add_Comm.aspx?action=save", 400, 140, "AddComm");
            });
        } else {
            $("#AdminCommon").hide();
        }
    }
    $.ajax({
        type: Type,
        url: Url,
        async: IsLoadCompante ? false : true,
        data: (Data ? Data : ""),
        cache: false,
        timeout: 600000000,
        dataType: "html",
        success: function (html) {
            if (Content) {
                AjaxFunWindow.close();
                AjaxFunWindow = null;
            }
            var WindowsReturnVar = WindowsReturn(html, ParentNode);
            if (WindowsReturnVar.ok) {
                html = WindowsReturnVar.html;
                if (Function) {
                    if (typeof (Function) == "string") {
                        $(Function).html(RunJavaScript(html, Function, NoScript, NoLoad));
                        if (Window) {
                            Window.close();
                            Window = null;
                        }
                    } else if (typeof (Function) == "function") {
                        Function(RunJavaScript(html, Function, NoScript, NoLoad), Window);
                    }
                } else {
                    RunJavaScript(html, null, NoScript, NoLoad);
                }
            } else {
                if (ErrorFunction) {
                    if (typeof (ErrorFunction) == "function") {
                        ErrorFunction(Window);
                    }
                }
            }
        },
        error: function (a, b, c) {
            if (!NoError) {
                if (Window) {
                    Window.close();
                    Window = null;
                }
                if (Content) {
                    AjaxFunWindow.close();
                    AjaxFunWindow = null;
                }
                if (b == "timeout") {
                    LoadWarting("", SycmsLanguage.Admin.AjaxFun.l2, "error", ErrViewTime, ParentNode);
                } else {
                    LoadWarting("", SycmsLanguage.Admin.AjaxFun.l3, "error", ErrViewTime, ParentNode);
                }
                if (ErrorFunction) {
                    if (typeof (ErrorFunction) == "function") {
                        ErrorFunction(Window);
                    }
                }
            }
        }
    });
    IECollectGarbage();
}
///Select颜色
function SelectColor(obj) {
    objS = $(obj);
    var OColor = objS.find('option[selected]').val();
    OColor = OColor.replace("Color:", "").replace(";","");
    try {
        objS.css('background-color', OColor);
    } catch (e)
    { }
    OColor=null;
    objS.blur();
}
///相同生成任务的时候
function CreateHtmlConfim(ViewHtmlCon, PostValue, PidValue)
{
    Dialog.confirm("<div style=\"width:430px;height:180px;overflow-x:hidden;overflow-y:auto;\">存在相同或近似生成任务：<ol>" + ViewHtmlCon + "</ol></div>", function () {
        CreateHtml(PostValue + "&PID=" + encodeURIComponent(PidValue) + "&createtype=close");
    }, null, 500, 200, "关闭继续", "关闭", "等待继续", function (diag) {
        CreateHtml(PostValue + "&PID=" + encodeURIComponent(PidValue) + "&createtype=wait");
        diag.close();
    });
}
///生成静态页面
function CreateHtml(PostValue) {
    $("#CreateHtmlDiv1").show();
    if (HtmlCreateList.length == 0) {
        $("#CreateHtmlDiv1").progressBar(1);
    }
    setTimeout(function() {
        HtmlCreateList[HtmlCreateList.length] = PostValue;
        CreatePostGet(PostValue);
    }, 20);
}
//生成提交方式
function CreatePostGet(PostValue) {
    var Iframe = $("#CreateHtmlDivFrame");
    if (Iframe.length == 0) {
        $("#CreateHtmlDivFrameDiv").html("<iframe src=\"js/blank.html\" id=\"CreateHtmlDivFrame\" name=\"CreateHtmlDivFrame\" style=\"width:0px;height:0px;display:none;\"></iframe><div style=\"display:none;width:0px;height:0px;\" id=\"CreateHtmlDivFormDiv\" ></div>");
        Iframe = $("#CreateHtmlDivFrame");
    }
    var src = Iframe.attr("src");
    if (src.indexOf("js/blank.html") != -1) {
        if (PostValue.length > 1500) {
            var Pv = PostValue.split("&");
            var str = "<form id=\"CreateHtmlDivForm\" name=\"CreateHtmlDivForm\" method=\"post\" action=\"AdminFun/CreateHtml.aspx\" target=\"CreateHtmlDivFrame\">";
            for (var i = 0; i < Pv.length; i++) {
                var Pv1 = Pv[i].split("=");
                str += "<input type=\"hidden\" name=\"" + unescape(Pv1[0]) + "\" value=\"" + unescape(Pv1[1]) + "\" />";
            }
            str += "</form>";
            $("#CreateHtmlDivFormDiv").html(str);
            $("#CreateHtmlDivForm").submit();
        } else {
            Iframe.attr("src", "AdminFun/CreateHtml.aspx?" + PostValue + "&SyCmstime=" + Math.random());
        }
    }
    src = null;
    Iframe = null;
}

///重新函数
function CreateHtmlFro() {
    if (HtmlCreateList.length > 0) {
        CreatePostGet(HtmlCreateList[0]);
    } else {
        $("#CreateHtmlDivFrame").remove();
        $("#CreateHtmlDivFormDiv").remove();
        $("#CreateHtmlDiv1").hide().progressBar(1);
        IECollectGarbage();
    }
}
//进度条
function CreateHtmlTree(i, t) {
    $("#CreateHtmlDiv1").progressBar(i * 100 / t / HtmlCreateList.length);
    if (i == t) {
        $("#CreateHtmlDivFrame").attr("src", "js/blank.html");
        HtmlCreateList.splice(0, 1);
        setTimeout(CreateHtmlFro, 20);
    }
}

function UploadFile_showProgressBar() {
    var UpFrom=$("#SyCmsFileUpload");
    var ipts = UpFrom.find("input[type='file']");
    var FileExt = $("#SyCmsUpFileExt").val();
    var UploadID = UpFrom.find("#UploadID").val();
    var openBar = false;
    var filei = 0;
    var filecount = ipts.length;
    for (var i = 0; i < filecount; i++) {
        var obj = ipts.eq(i).get(0);
        filei++;
        if (obj.value != '') {
            var v = obj.value.split('.');
            if (("|" + FileExt + "|").indexOf("|" + v[v.length - 1].toLowerCase() + "|") != -1) {
                openBar = true;
            } else {
                if (filecount > 1) {
                    parent.Dialog.error("第" + filei + "个文件类型不正确。");
                } else {
                    parent.Dialog.error("文件类型不正确。");
                }
                openBar = false;
                break;
            }
        }
    }
    if (openBar) {
        getProgressInfoWin(UploadID);
        document.getElementById("SyCmsFileUpload").submit();
        try {
            ReunFileUpload(UploadID);
        } catch (e) {
        }
    }
}
function FlashUploadData(FormData)
{
    var evalstr = new Array();
    var str = FormData.split('&');
    for (var i = 0; i < str.length; i++)
    {
        var str_1 = str[i].split('=');
        if (str_1.length == 2 && str_1[0].length > 0 && str_1[1].length > 0)
        {
            evalstr.push("'" + str_1[0] + "':'" + str_1[1] + "'");
        }
    }
    return eval("({" + evalstr.join(',') + "})");
}
//第一个参数。是要回写的控件ID，第二个为类型PIC/FILE
function UploadFile(ObjName, Type, Action, IsFun, FunPara, Title, FileExt, FileSize) {
    var FormData = "Type=" + Type + "&ObjName=" + ObjName + (IsFun ? "&IsFun=1" : "") + (FileExt ? "&FileExt=" + FileExt : "") + (FileSize ? "&FileSize=" + FileSize : "") + (FunPara ? "&FunPara=" + FunPara : "") + (Action ? "&" + Action : "");
    //{'public_path'  :   PUBLIC}
    AjaxFun("AdminFun/UploadFile.aspx", FormData, ' ', function (html) {
        UploadFileMessDiag = new Dialog();
        UploadFileMessDiag.Width = 410;
        UploadFileMessDiag.Height = 120;
        UploadFileMessDiag.ShowButtonRow = true;
        UploadFileMessDiag.Title = Title ? Title : SycmsLanguage.Admin.UploadFile.l1.replace("$$", (Type == "PIC" ? "图片" : "文件"));
        UploadFileMessDiag.InnerHtml = html;
        UploadFileMessDiag.show();
        var UploadFileType = $("#UploadFileType").val();
        if (UploadFileType == "flash") {
            $(UploadFileMessDiag.okButton).hide();
            var FileExt = $("#SyCmsUpFileExt").val();
            var FileSize = parseInt($("#SyCmsUpFileSize").val())/1024;
            var SyCmsUpFileName = $("#SyCmsUpFileName").val();
            var cookiesname = $("#cookiesname").val();
            var InputValue = $("#InputValue").val();
            $('#SyCmsUploadify').uploadify({
                'swf': 'JS/File/uploadify/uploadify.swf',
                'expressInstall': 'JS/File/uploadify/expressInstall.swf',
                'uploader': 'AdminFun/UploadFile.aspx',
                'method': 'post',
                'queueID': "SyCmsUploadfileQueue",
                'queueSizeLimit': '1',
                'formData': FlashUploadData("action=CreateFile&cookies=" + cookiesname + "&InputValue=" + InputValue + "&" + FormData),
                'width': 120,
                'height': 30,
                'cancelImage': 'images/uploadify/cancel.png',
                'buttonImage': 'images/uploadify/select.png',
                'fileSizeLimit': FileSize,
                'auto': false,
                'overrideEvents': ['onSelectError', 'onDialogClose', 'onQueueComplete', 'onCancel'],
                'onFallback': function () {
                    LoadWarting("插件未安装", "您未安装FLASH控件，无法上传！请安装FLASH控件后再试。", "error", 5);
                },
                'onCancel': function (event)
                {
                    $(UploadFileMessDiag.okButton).hide();
                    $(UploadFileMessDiag.otherButton[0]).hide();
                },
                'onSelectError': function (file, errorCode, errorMsg) {
                    switch (errorCode) {
                        case -100:
                            {
                                LoadWarting("文件数错误", "最多同时只能传1个。", "error", 5);
                                break;
                            }
                        case -110:
                            {
                                LoadWarting("文件大小错误", "最大" + FileSize + "kb。", "error", 5);
                                break;
                            }
                    }
                },
                onDialogClose: function (swfuploadifyQueue) {
                    if (swfuploadifyQueue.queueLength > 0) {
                        $(UploadFileMessDiag.okButton).show();
                        $(UploadFileMessDiag.otherButton[0]).show();
                    }
                },
                'removeTimeout': 0.01,
                'auto': false,
                'fileTypeDesc': '支持格式',
                'fileTypeExts': FileExt ? ("*." + FileExt.split("|").join(";*.")).replace("*.*.", "*.") : '*.7z;*.aiff;*.asf;*.avi;*.bmp;*.csv;*.doc;*.docx;*.fla;*.flv;*.gif;*.gz;*.gzip;*.jpeg;*.jpg;*.mid;*.mov;*.mp3;*.mp4;*.mpc;*.mpeg;*.mpg;*.ods;*.odt;*.pdf;*.png;*.ppt;*.pxd;*.qt;*.ram;*.rar;*.rm;*.rmi;*.rmvb;*.rtf;*.sdc;*.sitd;*.swf;*.sxc;*.sxw;*.tar;*.tgz;*.tif;*.tiff;*.txt;*.vsd;*.wav;*.wma;*.wmv;*.xls;*.xml;*.zip;*.js;*.css',
                'multi': true,
                'onQueueComplete': function () { UploadFileMessDiag.close(); },
                'onUploadSuccess': function (file, data, response) {
                    var SysCutPic = "";
                    if (data.indexOf("(") !=-1 && data.indexOf(")") != -1)
                    {
                        var data1 = data.split(")");
                        SysCutPic = data1[0].substr(1);
                        data = data1[1];
                    }
                    UploadFileOk(ObjName, data, null, IsFun, FunPara, SysCutPic);
                }
            });
            UploadFileMessDiag.okButton.onclick = function () {
                if (SyCmsUpFileName == "1") {
                    $("#SyCmsUploadify").uploadify("settings", "formData", FlashUploadData("action=CreateFile&OriginalName=1&cookies=" + cookiesname + "&InputValue=" + InputValue + "&" + FormData));
                }
                $('#SyCmsUploadify').uploadify("upload", "*");
            }
            if (SyCmsUpFileName == "1") {
                UploadFileMessDiag.okButton.value = SycmsLanguage.Admin.UploadFile.l3;
            } else {
                UploadFileMessDiag.okButton.value = SycmsLanguage.Admin.UploadFile.l2;
                UploadFileMessDiag.addButton("otheruploadfile", SycmsLanguage.Admin.UploadFile.l3, function () {
                    $("#SyCmsUploadify").uploadify("settings", "formData", FlashUploadData("action=CreateFile&OriginalName=1&cookies=" + cookiesname + "&InputValue=" + InputValue + "&" + FormData));
                    $('#SyCmsUploadify').uploadify("upload", "*");
                });
                $(UploadFileMessDiag.otherButton[0]).hide();
            }
        } else {
            UploadFileMessDiag.okButton.onclick = function () {
                UploadFile_showProgressBar();
            };
            UploadFileMessDiag.CancelEvent = function () {
                try {
                    UploadFileCancel($("#SyCmsFileUpload").find("#UploadID").val());
                } catch (e)
                { }
            };
            UploadFileMessDiag.okButton.value = SycmsLanguage.Admin.UploadFile.l2;
        }
    });
}
//上传进度
function ReunFileUpload(UploadID) {
    UploadFileMessDiagTime = setInterval(function () { getProgressInfo(UploadID); }, 100);
}
//取消上传（有可能是错误上传）
function UploadFileCancel(UploadID) {
    var p = window;
    if (parent) {
        p = parent;
    }
    if (UploadID.length > 0) {
        $.ajax({
            type: "GET",
            url: "AdminFun/GetUploadProgressInfo.aspx",
            data: "UploadID=" + UploadID + "&cmd=Cancel&temp=" + Math.random(),
            cache: false
        });
        if (p.UploadFileMessDiagTime) {
            clearInterval(p.UploadFileMessDiagTime);
            p.UploadFileMessDiagTime = null;
        }
        if (p.UploadFileMess) {
            p.UploadFileMess.close();
            p.UploadFileMess = null;
        }
        p.UploadFileMessDiag.close();
    } else {
        $('#SyCmsUploadify').uploadify("stop");
        $('#SyCmsUploadify').uploadify("cancel");
        if (p.UploadFileMess) {
            p.UploadFileMess.close();
            p.UploadFileMess = null;
        }
        p.UploadFileMessDiag.close();
    }
    IECollectGarbage();
}

function getProgressInfoWin(UploadID) {
    UploadFileMess = LoadWarting("", "<div>" + SycmsLanguage.Admin.getProgressInfoWin.l1 + "</div><div style=\"height:12px;\" id=\"FileUploadInfo\">0%</div><div id=\"FileUploadInfoDiv\"></div><div style=\"padding:5px;\"><span style=\"float:right;\"><a href=\"\" onclick=\"UploadFileCancel('" + UploadID + "');return false;\">" + SycmsLanguage.Admin.getProgressInfoWin.l2 + "</a></span></div>", null, null, null, null, null, 400, 150);
    // $("#FileUploadInfo").progressBar(1);
}

///显示进度条信息
function getProgressInfo(UploadID) {
    $.ajax({
        type: "GET",
        url: "AdminFun/GetUploadProgressInfo.aspx",
        data: "UploadID=" + UploadID + "&cmd=Update&temp=" + Math.random(),
        cache: false,
        success: function(html) {
            showResponse(html);
        }
    });
}

//显示进度
function showResponse(Html) {
    var str = eval(Html);
    if (str[0] == "Error") {
        try {
            UploadFileMessDiag.close();
            UploadFileMess.close();
            UploadFileMessDiag = null;
            UploadFileMess = null;
        } catch (e)
        { }
    } else {
        if (str[1] && str[1] != "0") {
            var html = "<div class=\"info\">" + SycmsLanguage.Admin.showResponse.l1.replace("$$", (str[0] == "Uploading" ? str[1] + "% 完成" : str[0])) + "</div>";
            html += "<div class=\"info\"><nobr>" + SycmsLanguage.Admin.showResponse.l2.replace("$$", (str[0] == "Completed" ? str[5] + " 个文件成功上传 !" : "文件上传中")) + "</nobr></div>";
            html += "<div class=\"info\">" + SycmsLanguage.Admin.showResponse.l3.replace("$$", (str[0] == "Initializing" ? "" : str[3])) + "</div>";
            html += "<div class=\"info\">" + SycmsLanguage.Admin.showResponse.l4.replace("$$", (str[0] == "Initializing" ? "" : str[4])) + "</div>";
            $("#FileUploadInfoDiv").html(html);
            html = null;
            $("#FileUploadInfo").progressBar(parseInt(str[1]));
        }
    }
    str = null;
    parentWin = null;
}
//上传文件回写，框架内回写
function UploadFileOk(ObjName, FileUrl, Type, IsFun, FunPara, SysCutPic) {
    if (parent.UploadFileMessDiagTime) {
        clearInterval(parent.UploadFileMessDiagTime);
        parent.UploadFileMessDiagTime = null;
    }
    if (!Type) {
        parent.UploadFileMessDiag.close();
        parent.UploadFileMessDiag = null;
    }
    if (parent.UploadFileMess) {
        parent.UploadFileMess.close();
        parent.UploadFileMess = null;
    }
    if (ObjName) {
        if (SysCutPic && SysCutPic.length > 0) {
            CutPicFun(function (html) {
                UploadFileOk_2(ObjName, html, IsFun, FunPara);
            }, FileUrl, null, 1, SysCutPic);
        } else {
            UploadFileOk_2(ObjName, FileUrl, IsFun, FunPara);
        }
    }
}
//上传成功第二步
function UploadFileOk_2(ObjName, FileUrl, IsFun, FunPara)
{
    if (IsFun) {
        evalJavaScript(ObjName + "('" + FileUrl + "','" + FunPara + "');");
    } else {
        var Obj = parent.$id(ObjName);
        if (Obj.type == "textarea") {
            InsertAtCaret(Obj, FileUrl);
        } else {
            Obj.value = FileUrl;
            Obj.focus();
        }
        Obj = null;
        FileUpdateRecord(parent, FileUrl);
    }
}

//添加记录上传文件添加时触发
function FileUpdateRecord(ParentObj, FileUrl, IsTop) {
    var obj = null;
    if (IsTop) {
        if (ParentObj) {
            obj = $(ParentObj).find("input[id='ImgListInput']").get(IsTop);
        } else {
            obj = $("input[id='ImgListInput']").get(IsTop);
        }
    } else {
        if (ParentObj) {
            obj = ParentObj.$id("ImgListInput");
        } else {
            obj = $id("ImgListInput");
        }
    }
    if (obj) {
        if (("|" + obj.value).indexOf("|" + FileUrl + "|") == -1) {
            obj.value += FileUrl + "|";
        }
    }
    obj = null;
}

//图片切图
function CutPicFun(ObjName, ObjUrl, Action, IsDel, SysCutPic) {
    var PicUrl = "";
    if (!ObjUrl && typeof (ObjName) == "string") {
        PicUrl = $("#" + ObjName).val();
    } else {
        PicUrl = ObjUrl;
    }
    if (PicUrl.length > 0) {
        if (PicUrl.indexOf("://") != -1) {
            AjaxFun("AdminFun/ReadFileUrl.aspx", "FileUrl=" + encodeURIComponent(PicUrl), " ", function (html) {
                if (html.length > 0 && html.indexOf("://") == -1) {
                    CutPicFun_2(ObjName, html, Action, IsDel, SysCutPic);
                }
            });
        } else {
            CutPicFun_2(ObjName, PicUrl, Action, IsDel, SysCutPic);
        }
    }
}

function CutPicFun_2(ObjName, PicUrl, Action, IsDel, SysCutPic) {
    var v = PicUrl.split('.');
    if ("|jpg|gif|bmp|png|jpeg|".indexOf("|" + v[v.length-1].toLowerCase() + "|") != -1) {
        var Ic = null;
        CreateWindow('AdminFun/CutPic.aspx', SycmsLanguage.Admin.CutPicFun.l1, function (ObjWin) {
            var str = "";
            str = parseInt(Ic.dragLeft * Ic.viewComparison / 100) + "," + parseInt(Ic.dragTop * Ic.viewComparison / 100) + "," + parseInt(Ic.dragWidth * Ic.viewComparison / 100) + "," + parseInt(Ic.dragHeight * Ic.viewComparison / 100) + "," + parseInt(Ic.dragWidth * Ic.viewComparison / 100) + "," + parseInt(Ic.dragHeight * Ic.viewComparison / 100);
            AjaxFun('AdminFun/CutPic.aspx', 'action=save' + (SysCutPic ? "&SysCutPic=" + SysCutPic : "") + '&url=' + PicUrl + "&picParameter=" + str + (Action ? Action : "") + "&" + ReadInputValue('Cut2Slice'), SycmsLanguage.Admin.CutPicFun.l2, function (html, Win) {
                ObjWin.close();
                if (html.length > 0) {
                    if (typeof (ObjName) == "string") {
                        $("#" + ObjName).val(html);
                    } else if (typeof (ObjName) == "function") {
                        (ObjName)(html);
                    }
                    FileUpdateRecord(parent.parent, html);
                }
            }, null, ObjWin);
            str = null;
        }, 750, 450, null, null, null, null, null, function (ObjWin) {
            var logo = "";
            var width =100;
            var height = 100;
            var Scale = false;
            if (SysCutPic && SysCutPic.length > 0) {
                var SysCutPic1 = SysCutPic.split("|");
                logo = SysCutPic1[0];
                width = parseFloat(SysCutPic1[1]);
                height = parseFloat(SysCutPic1[2]);
                if (!(isNaN(width) || width == 0) && !(isNaN(height) || height == 0)) {
                    Scale = true;
                }
                if (isNaN(width) || width == 0) {
                    width = 100;
                }
                if (isNaN(height) || height == 0) {
                    height = 100;
                }
            }
            if (IsDel) {
                if (IsDel == 1) {
                    FirefoxDisabled("DelFile");
                } else {
                    $("#DelFile").removeAttr("checked");
                    FirefoxDisabled("DelFile");
                }
            }
            if (logo)
            {
                $("#LoginView").attr("checked", "checked"); FirefoxDisabled("LoginView");
            }
            Ic = new ImgCropper("bgDiv", "dragDiv", PicUrl, 500, 350, {
                dragTop: 0, dragLeft: 0, dragWidth: width, dragHeight: height, Scale: Scale, Right: "rRight", Left: "rLeft", Up: "rUp", Down: "rDown", RightDown: "rRightDown", LeftDown: "rLeftDown", RightUp: "rRightUp", LeftUp: "rLeftUp", View: "viewDiv", ViewSize: "viewDivSize", viewWidth: 200, viewHeight: 200, ErrorFun: function () {
                    ObjWin.close();
                    LoadWarting(SycmsLanguage.Admin.CutPicFun.l3, SycmsLanguage.Admin.CutPicFun.l4, "error", ErrViewTime);
                }
            });
        }, null, null, null, null, null, null, function ()
        {
            if (IsDel && IsDel == 1)
            {
                AjaxFun('AdminFun/Del_Pic.aspx', "PicUrl=" + encodeURIComponent(PicUrl), SycmsLanguage.Admin.CreateWindow.l2, null, 'False', null, null, '100%', 30, 1, 1);
            }
        });
    }
    v = null;
}

//最低宽度

function SmallFun(ObjName,Width,SmallWidth) {
    var W = $(ObjName).width();
    W = W - Width;
    if (W < SmallWidth) {
        W = SmallWidth;
    }
    return W;
}


//弹出替换窗口
function ReplaceTextArea(Obj) {
    var ObjValue = Obj.val();
    Obj.indexofvalue = 0;
    if (ObjValue.Trim().length > 0) {
        var ReplaceTextAreadiag = new Dialog();
        ReplaceTextAreadiag.Width = 300;
        ReplaceTextAreadiag.Height = 80;
        ReplaceTextAreadiag.Title = SycmsLanguage.Admin.ReplaceTextArea.l1;
        ReplaceTextAreadiag.InnerHtml = '<div style="text-align:left;padding:8px;line-height:35px;">' + SycmsLanguage.Admin.ReplaceTextArea.l2 + '<input type=\"text\" value=\"\" size=\"27\" id=\"ReplaceNameString\" name=\"ReplaceNameString\" /><br/>' + SycmsLanguage.Admin.ReplaceTextArea.l3 + '<input type=\"text\" value=\"[$Path$]\" size=\"27\" id=\"ReplaceNameString1\" name=\"ReplaceNameString1\"></div>'
        ReplaceTextAreadiag.OKEvent = function() {
            var v = $("#ReplaceNameString").val();
            var v1 = $("#ReplaceNameString1").val();
            if (v.length > 0) {
                ObjValue = ObjValue.split(v).join(v1);
                Obj.val(ObjValue);
            }
            ReplaceTextAreadiag.close();
            ReplaceTextAreadiag = null;
            v = null;
            v1 = null;
        };
        ReplaceTextAreadiag.show();
        ReplaceTextAreadiag.okButton.value = SycmsLanguage.Admin.ReplaceTextArea.l4;
        ReplaceTextAreadiag.addButton("next", SycmsLanguage.Admin.ReplaceTextArea.l5, function () {
            var v = $("#ReplaceNameString").val();
            var v1 = ObjValue.indexOf(v, Obj.indexofvalue);
            if (v1 != -1) {
                Obj.indexofvalue = v1 + v.length;
                setCursorPosition(Obj.get(0), v1, Obj.indexofvalue);
            } else {
                var v2 = ObjValue.length;
                setCursorPosition(Obj.get(0), v2, v2);
            }
        });
        $("#ReplaceNameString").val(Obj.get(0).selectOStr);
    }
}
//TAB键超出判断
function MenuFunction(objname,height) {
    var obj = $id(objname);
    if (obj.scrollHeight > height) {
        $("#" + objname + "_View").show();
        obj.style.width = (obj.offsetWidth - 20) + "px";
        var a1 = $(obj).find(".dq");
        if (a1.length > 0) {
            var wz = a1.position().top - 113;
            if (wz > 0) {
                obj.scrollTop = wz;
            }
        }
        var obj1 = $id(objname + "_Top");
        var obj2 = $id(objname + "_Bottom");
        if (obj1) {
            obj1.onclick = function() {
                obj.scrollTop -= height;
                $id(objname + "_View").style.top = obj.scrollTop + "px";
                return false;
            }
        }
        if (obj2) {
            obj2.onclick = function() {
                obj.scrollTop += height;
                $id(objname + "_View").style.top = obj.scrollTop + "px";
                return false;
            }
        }
    } else {
        $("#" + objname + "_View").hide();
    }
}
//更新进度条
function ProgressShow(objid,num) {
    $(objid).progressBar(num);
}

//编辑器
function CkeditorView(ObjName, CkeditorObject, CkeditorPageList, isReadOnly) {
    var instance1 = CKEDITOR.instances[ObjName];
    if (instance1) {
        CKEDITOR.remove(instance1);
    }
    if (isReadOnly) {
        CKEDITOR.config.readOnly = true;
    } else {
        CKEDITOR.config.readOnly = false;
    }
    var instance1 = CKEDITOR.replace(ObjName, CkeditorObject);
    if (CkeditorPageList) {
        //					        instance1.on('afterCommandExec', function (e) {
        //					            if (e.data.name == "pagebreak") {
        //					                CkeditorPageView(ObjName, e.editor.getData(), CkeditorPageList);
        //					            }
        //					        });
        instance1.on('elementsPathUpdate', function (e) {
            CkeditorPageView(ObjName, e.editor.getData(), CkeditorPageList);
        });
        instance1.on('blur', function (e) {
            var HtmlContent = e.editor.getData();
            CkeditorPageView(ObjName, HtmlContent, CkeditorPageList);
            CkeditorContentImg(HtmlContent, ObjName);
        });
    }
}
function CkeditorRemove(ObjName)
{
    var instance1 = CKEDITOR.instances[ObjName];
    if (instance1) {
        CKEDITOR.remove(instance1);
    }
}
function CkeditorSetHtml(ObjName, Html) {
    var instance1 = CKEDITOR.instances[ObjName];
    if (instance1) {
        instance1.setData(Html);
    }
}
function CkeditorGetHtml(ObjName) {
    var oEditor = CKEDITOR.instances[ObjName];
    var val = "";
    if (oEditor) {
        val = oEditor.getSyData();
    }
    return val;
}
function CkeditorInsertHtml(ObjName, Html) {
    var instance1 = CKEDITOR.instances[ObjName];
    if (instance1) {
        instance1.insertHtml(Html);
    }
}


function CkeditorContentImg(HtmlContent, ObjName) {
    var re = /<img.+?src=(['"]?)([^>\s]+)\1.*?>/ig;
    var PageArr = HtmlContent.match(re);
    if ((PageArr instanceof Array)) {
        var FileUrl = "";
        var LocalhostFile = new Array();
        var LocalhostUrl = "";
        for (var i = 0; i < PageArr.length; i++) {
            FileUrl = PageArr[i].replace(re, "$2");
            if (FileUrl.indexOf("data:image/") != -1) {
                LoadWarting("图片地址错误", "内容里有Word图片格式，请上传图片。", "error", 5);
                return false;
            } else if (FileUrl.indexOf("file:///") == -1) {
                FileUpdateRecord(parent.parent, FileUrl);
            } else {
                if (LocalhostUrl == "") {
                    LocalhostUrl = FileUrl.substr(8, FileUrl.lastIndexOf('\\') - 7);
                }
                LocalhostFile.push(FileUrl.substr(8).replace(LocalhostUrl, ""));
            }
        }
        if (LocalhostFile.length > 0) {
            var str = "<ol style=\"height:180px;overflow:hidden;overflow-y:auto\">";
            var FileExt = "";
            var FileExtArr = "";
            for (var i = 0; i < LocalhostFile.length; i++) {
                FileExt = LocalhostFile[i].substr(LocalhostFile[i].lastIndexOf("."));
                if ((";" + FileExtArr).indexOf(";*" + FileExt + ";") == -1) {
                    FileExtArr += "*" + FileExt + ";";
                }
                str += "<li>" + LocalhostFile[i] + "</li>";
            }
            str += "</ol>";
            Dialog.confirm("检查到使用了本地图片（请复制此目录，方便上传图片）<br/>目录：<input type=\"text\" value=\"" + LocalhostUrl + "\" style=\"width:260px;\" onfocus=\"this.select()\" onclick=\"this.select()\"/><br/>" + str, function () {
                AjaxFun("AdminFun/CkeditorReplace.aspx", "", "调入上传图片......", function (html) {
                    if (html) {
                        if (FileExtArr.length > 0) {
                            FileExtArr = FileExtArr.substr(0, FileExtArr.length - 1);
                        }
                        Contentlocal_Arti_FileUpdate(html, LocalhostUrl, FileExtArr, HtmlContent, ObjName);
                    }
                });
            }, null, 400, 250, "上传图片", "取消");
        }
    }
}

function CkeditorPageView(ObjName, Content, CkeditorPageList) {
    var regExp = new RegExp('<div([ ]+)style([ ]?)=([ ]?)"([ ]?)page-break-after([ ]?):([ ]?)always([ ]?);([ ]?)"([ ]?)>([\\s\\S]*?)<\\/span>([\\s\\S]*?)<\\/div>', "img");
    var PageArr = String(Content).match(regExp);
    var PageNum = 0;
    if ((PageArr instanceof Array)) {
        PageNum = PageArr.length + 1;
    }
    PageArr = null;
    var NumObj = document.getElementById(ObjName + "__Num");
    var YPage = 0;
    if (NumObj) {
        YPage = parseInt(NumObj.value);
        if (isNaN(YPage)) {
            YPage = 0;
        }
        NumObj.value = PageNum;
    }
    var ParentPageList = $(CkeditorPageList);
    if (PageNum <= 0) {
        ParentPageList.hide();
    } else {
        ParentPageList.show();
    }
    if (PageNum != YPage) {
        var objPathList = ParentPageList.find("ol li");
        if (YPage < PageNum) {
            for (var i = YPage; i < PageNum; i++) {
                if (i >= objPathList.length) {
                    ParentPageList.find("ol").append("<li><input id=\"" + ObjName + "_Page" + i + "\" name=\"" + ObjName + "_Page" + i + "\" type=\"text\"></li>");
                } else {
                    objPathList.eq(i).show();
                }
            }
        } else {
            if (objPathList.length > PageNum) {
                for (var i = PageNum; i < objPathList.length; i++) {
                    objPathList.eq(i).hide();
                }
            }
        }
    }
}
//地址判断
function UrlFormatAlt(ObjSelect, ObjUrl) {
    var selectValue = $("#" + ObjSelect).val();
    var urlValue = $("#" + ObjUrl).val();
    if (urlValue.indexOf("://") == -1) {
        if (selectValue.length>0 && selectValue.isDigit()) {
            if (urlValue.indexOf(":") != -1 || urlValue.indexOf("*") != -1 || urlValue.indexOf("?") != -1 || urlValue.indexOf("\"") != -1 || urlValue.indexOf("<") != -1 || urlValue.indexOf(">") != -1 || urlValue.indexOf("|") != -1) {
                Dialog.error("错误：地址中含有以下非法字符<br/> | : * ? \" &lt; &gt;");
            }
        }
    }
}
//高级URL规则
function OpenUrlAdvanced(Type, ModelID, UrlObjName) {
    CreateWindow(Type + "/Lists_Advanced.aspx?ModelID=" + encodeURIComponent(ModelID) + "&Type=" + encodeURIComponent(Type), "高级URL规则定义", function (CreateWindowdiag) {
        $("#" + UrlObjName).val($("#ContentURLText").val());
        CreateWindowdiag.close();
    }, 500, 400, null, null, null, null, null, function () {
        $("#ContentURLText").val($("#" + UrlObjName).val());
    });
}