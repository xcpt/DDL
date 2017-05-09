function ArtiSearch(FormName,ClassID) {
    if (AddReturnValidationEngine("#" + FormName)) {
        var it0 = $("#itemList0");
        var it1 = $("#itemList1");
        if (it0.length > 0 && it1.length > 0) {
            if (it0.is(":hidden")) {
                $("#itemLinkList0").addClass("dq");
                $("#itemLinkList1").removeClass("dq");
                it0.show();
                it1.hide();
            }
        }
        it0 = null;
        it1 = null;
        $('#flex' + ClassID).flexReload(ReadInputValue(FormName));
    } else {
        setTimeout(function() { $.validationEngine.closePrompt('.formError', true) }, 2000);
    }
}
//修改时标题
function Arti_TitleFunList(value, id, ClassID, Type, IsAdd, IsModi, FieldID, UploadWebUrl, UploadUrl, WinWidth, WinHeight, WinMove) {
    FieldID = FieldID ? FieldID : "";
    if (value.indexOf("|$|||||$|") != -1) {
        var val = value.split("|$|||||$|");
        value = "";
        if (val[0].length > 0) {
            value = "<img src=images/icon/picture.png width=16 height=16 align=\"absmiddle\" alt=\"" + ((UploadWebUrl && UploadUrl) ? (val[0].toLowerCase().replace(UploadUrl.toLowerCase(), UploadWebUrl)) : val[0]) + "?width=200&height=200\" class=\"jTip\" name=\"" + SycmsLanguage.Arti.Arti_TitleFunList.l1 + "\" />";
        }
        value += val[1];
        if (IsModi) {
            return "<a href=\"\" onclick=\"return CategoryModiArti('" + ClassID + "','" + id + "'," + Type + "," + IsAdd + ",'" + FieldID + "'," + WinWidth + "," + WinHeight + "," + WinMove + ");\" title='" + val[1] + "'>" + value + "</a>";
        } else {
            return value;
        }
    } else {
        if (IsModi) {
            return "<a href=\"\" onclick=\"return CategoryModiArti('" + ClassID + "','" + id + "'," + Type + "," + IsAdd + ",'" + FieldID + "'," + WinWidth + "," + WinHeight + "," + WinMove + ");\" title='" + value + "'>" + value + "</a>";
        } else {
            return value;
        }
    }
}
//查看时标题
function Arti_TitleFunListView(value, id, modelID, Type, IsField, UploadWebUrl, UploadUrl) {
    if (value.indexOf("|$|||||$|") != -1) {
        var val = value.split("|$|||||$|");
        value = "";
        if (val[0].length > 0) {
            value = "<img src=images/icon/picture.png width=16 height=16 align=\"absmiddle\" alt=\"" + ((UploadWebUrl && UploadUrl) ? (val[0].toLowerCase().replace(UploadUrl.toLowerCase(), UploadWebUrl)) : val[0]) + "?width=200&height=200\" class=\"jTip\" name=\"" + SycmsLanguage.Arti.Arti_TitleFunListView.l1 + "\" />";
        }
        value += val[1];
        if (IsField) {
            value = "<a href=\"\" onclick=\"AjaxFun('ArtiList/Lists_View.aspx','action=one&id=" + id + "&Modelid=" + modelID + "&Type=" + Type + "','');return false;\" title='" + val[1] + "'>" + value + "</a>";
        } else {
            var val = value.split("</a>｝");
            value = val[0] + "</a>｝<a href=\"\" onclick=\"AjaxFun('ArtiList/Lists_View.aspx','action=one&id=" + id + "&Modelid=" + modelID + "&Type=" + Type + "','');return false;\" title='" + val[1] + "'>" + val[1] + "</a>";
        }
        value = value.replace(",id);", "," + id + ");");
        return value;
    } else {
        if (IsField) {
            value = "<a href=\"\" onclick=\"AjaxFun('ArtiList/Lists_View.aspx','action=one&id=" + id + "&Modelid=" + modelID + "&Type=" + Type + "','');return false;\" title='" + value + "'>" + value + "</a>";
        } else {
            var val = value.split("</a>｝");
            value = val[0] + "</a>｝<a href=\"\" onclick=\"AjaxFun('ArtiList/Lists_View.aspx','action=one&id=" + id + "&Modelid=" + modelID + "&Type=" + Type + "','');return false;\" title='" + val[1] + "'>" + val[1] + "</a>";
        }
        value = value.replace(",id);", "," + id + ");");
        return value;
    }
}

function Content_Arti_AddField(objname, objvalue, FieldID, Type) {
    $id(objname).value += objvalue + ",";
    FileUpdateRecord(null, "-1," + objvalue + "," + FieldID + "," + Type, 0);
}
function Content_Arti_RemoveField(objname, objvalue) {
    var objvalue1 = objvalue.split(",");
    var objvalue2 = $id(objname).value;
    for (var i = 0; i < objvalue1.length; i++) {
        objvalue2 = objvalue2.replace("," + objvalue1[i] + ",", ",");
    }
    $id(objname).value = objvalue2;
}

//内容本地文件
function Contentlocal_Arti_FileUpdate(cookies, LocalhostUrl, FileExtArr, HtmlContent, ObjName) {
    SyCmsFileUploadWin("上传多文件", { "cookies": encodeURIComponent(cookies), "IsDir": 1, "IsType": 0 }, "", function (sc, CreateWindowdiag) {
        if (sc && sc.length > 0) {
            for (var i = 0; i < sc.length; i++) {
                FileUpdateRecord(null, sc[i][0]);
                HtmlContent = HtmlContent.replace("file:///" + LocalhostUrl + sc[i][1], sc[i][0]);
            }
            $($("#cke_contents_" + ObjName + " iframe").get(0).contentWindow.document.body).html(HtmlContent);
            CkeditorSetHtml(ObjName, HtmlContent)
        }
        CreateWindowdiag.close();
    }, null, FileExtArr);
}

// 模型里上传多文件
function Content_Arti_FileUpdate(cookies, IsType, objName, ModelID, FileExt, FileSize, syscutpic) {
    var objT = $("#" + objName + "_" + ModelID + "_Select");
    var objTT = objT.find("option:selected").text();
    var objTV = objT.val();
    if (objTV == "" || objTV == "0") {
        objTT = "";
    }
    SyCmsFileUploadWin("上传多文件", { "cookies": encodeURIComponent(cookies), "IsDir": 1, "IsType": IsType }, "", null, function (url) {
        FileUpdateRecord(null, url);
        var objNV1 = url.split("/");
        var objNV = objNV1[objNV1.length - 1].split(".")[0];
        AjaxFun("AdminFun/ArtiFile.aspx", "Type=" + encodeURIComponent(objTV) + "&Name=" + encodeURIComponent(objNV) + "&Url=" + encodeURIComponent(url), "", function (html) {
            if (html.length > 0) {
                var ID = html;
                var str = "<fieldset><legend><div style=\"float:left;padding-left:3px;\"><input type=\"button\" value=\"" + SycmsLanguage.Arti.Content_Arti_FileUpdate.l1 + "\" onclick=\"FileUploadModi('" + ID + "','" + objTV + "', '" + objNV + "', '" + url + "','" + objName + "','" + ModelID + "');\" icon=\"icon-table_edit\" /></div><div style=\"float:left;padding-left:3px;\"><input type=\"button\" value=\"" + SycmsLanguage.Arti.Content_Arti_FileUpdate.l2 + "\" onclick=\"$('#ArtiFile_" + ID + "_Con').remove();AjaxFun('AdminFun/ArtiFile.aspx','action=del&id=" + html + "');\" icon=\"icon-delete\" /></div></legend><input type=\"hidden\" name=\"" + objName + "_" + ModelID + "\" value=\"" + html + "\" /><div style=\"float:left;padding-top:3px;vertical-align:middle;\">" + SycmsLanguage.Arti.Content_Arti_FileUpdate.l3 + objTT + "&nbsp;&nbsp;" + SycmsLanguage.Arti.Content_Arti_FileUpdate.l4 + objNV + "&nbsp;&nbsp;" + SycmsLanguage.Arti.Content_Arti_FileUpdate.l5.replace("$$", FileUploadView(url)) + url + "&nbsp;&nbsp;" + SycmsLanguage.Arti.Content_Arti_FileUpdate.l6 + "0</div></fieldset>";
                $("#" + objName + "_" + ModelID + "_configView").append("<div style=\"margin:3px;clear:both;\" id=\"ArtiFile_" + ID + "_Con\"><div id=\"ArtiFile_" + ID + "_Modiy\"></div><div id=\"ArtiFile_" + ID + "_View\">" + str + "</div></div>").btnForMat().find(".jTip").JT_init();
                Content_ArtiFileAllOrder(objName, ModelID);
            }
        });
    }, FileExt ? ("*." + FileExt.split("|").join(";*.")) : "", FileSize, syscutpic);
}
//多文件选择
function Content_Arti_FileAll(cookies, objName, ModelID, FileExt, FileSize, syscutpic) {
    DirImgWin(function (UrlAll) {
        if (UrlAll) {
            var objT = $("#" + objName + "_" + ModelID + "_Select");
            var objTT = objT.find("option:selected").text();
            var objTV = objT.val();
            if (objTV == "" || objTV == "0") {
                objTT = "";
            }
            AjaxFun("AdminFun/ArtiFile.aspx", "Type=" + encodeURIComponent(objTV) + "&Name=&Url=" + encodeURIComponent(UrlAll), " ", function (html) {
                if (html.length > 0) {
                    var htmlArr = html.split(",");
                    var UrlAllArr = UrlAll.split(",");
                    var str = new Array();
                    var ID = "";
                    var url = "";
                    var objNV1 = "";
                    var objNV = "";
                    for (var i = 0; i < htmlArr.length; i++) {
                        ID = htmlArr[i];
                        url = UrlAllArr[i];
                        objNV1 = url.split("/");
                        objNV = objNV1[objNV1.length - 1].split(".")[0];
                        str.push("<div style=\"margin:3px;clear:both;\" id=\"ArtiFile_" + ID + "_Con\"><div id=\"ArtiFile_" + ID + "_Modiy\"></div><div id=\"ArtiFile_" + ID + "_View\"><fieldset><legend><div class=\"FileMove\" style=\"cursor: move;float:left;padding:5px;\"><img src=\"images/icon/arrow_nsew.png\"/></div><div style=\"float:left;padding-left:3px;\"><input type=\"button\" value=\"" + SycmsLanguage.Arti.Content_Arti_FileUpdate.l1 + "\" onclick=\"FileUploadModi('" + ID + "','" + objTV + "', '" + objNV + "', '" + url + "','" + objName + "','" + ModelID + "');\" icon=\"icon-table_edit\" /></div><div style=\"float:left;padding-left:3px;\"><input type=\"button\" value=\"" + SycmsLanguage.Arti.Content_Arti_FileUpdate.l2 + "\" onclick=\"$('#ArtiFile_" + ID + "_Con').remove();AjaxFun('AdminFun/ArtiFile.aspx','action=del&id=" + html + "');\" icon=\"icon-delete\" /></div></legend><input type=\"hidden\" name=\"" + objName + "_" + ModelID + "\" value=\"" + html + "\" /><div style=\"float:left;padding-top:3px;vertical-align:middle;\">" + SycmsLanguage.Arti.Content_Arti_FileUpdate.l3 + objTT + "&nbsp;&nbsp;" + SycmsLanguage.Arti.Content_Arti_FileUpdate.l4 + objNV + "&nbsp;&nbsp;" + SycmsLanguage.Arti.Content_Arti_FileUpdate.l5.replace("$$", FileUploadView(url)) + url + "&nbsp;&nbsp;" + SycmsLanguage.Arti.Content_Arti_FileUpdate.l6 + "0</div></fieldset></div></div>");
                    }
                    $("#" + objName + "_" + ModelID + "_configView").append(str.join("")).btnForMat().find(".jTip").JT_init();
                    Content_ArtiFileAllOrder(objName, ModelID);
                    str = null;
                }
            });
        }
    }, 0, "IsNum=1" + (FileSize ? "&FileSize=" + FileSize : ""), syscutpic);
}
///多文件排序
function Content_ArtiFileAllOrder(objName, ModelID)
{
    $("#" + objName + "_" + ModelID + "_configView").sortable({
        handle: '.FileMove', stop: function (event, ui) {
            var SortList = new Array();
            ui.item.parent().find("input[name='" + objName + "_" + ModelID + "']").each(function (i) {
                SortList.push($(this).val());
            });
            AjaxFun("AdminFun/ArtiFile.aspx", "action=order&id=" + SortList.join(","));
            SortList = null;
        }
    });
}
//判断文章是否存在。
function ArtiContentExist(ClassPathName, Type, ExistType, FormName, ClassID, PicName, UrlName, ModelID, PicValue, UrlValue) {
    var msg = "";
    if (Type == "1") {
        if (ExistType == "1") {
            msg = SycmsLanguage.Arti.ArtiContentExist.l1.replace("$$", ClassPathName);
        } else {
            msg = SycmsLanguage.Arti.ArtiContentExist.l2.replace("$$", ClassPathName);
        }
    } else {
        if (ExistType == "1") {
            msg = SycmsLanguage.Arti.ArtiContentExist.l3.replace("$$", ClassPathName);
        } else {
            msg = SycmsLanguage.Arti.ArtiContentExist.l1.replace("$$", ClassPathName);
        }
    }
    if (UrlName.length > 0 && UrlValue.length > 0) {
        msg += SycmsLanguage.Arti.ArtiContentExist.l4.replace("$$", UrlValue);
        if (PicName.length > 0 && PicValue.length > 0) {
            msg += SycmsLanguage.Arti.ArtiContentExist.l5;
            Dialog.confirm(msg, function () {
                $("#" + FormName + "_" + UrlName + "_" + ClassID + "_" + ModelID).val(UrlValue);
                ChangeUrl(".Sycms_" + FormName + "_Template", "2");
            }, null, 420, 110, SycmsLanguage.Arti.ArtiContentExist.l6, SycmsLanguage.Arti.ArtiContentExist.l7, SycmsLanguage.Arti.ArtiContentExist.l8, function (diag) {
                diag.close();
                $("#" + FormName + "_" + UrlName + "_" + ClassID + "_" + ModelID).val(UrlValue);
                ChangeUrl(".Sycms_" + FormName + "_Template", "2");
                $("#" + FormName + "_" + PicName + "_" + ClassID + "_" + ModelID).val(PicValue);
            });
        } else {
            Dialog.confirm(msg, function () {
                $("#" + FormName + "_" + UrlName + "_" + ClassID + "_" + ModelID).val(UrlValue);
                ChangeUrl(".Sycms_" + FormName + "_Template", "2");
            }, null, 420, 90, SycmsLanguage.Arti.ArtiContentExist.l6, SycmsLanguage.Arti.ArtiContentExist.l7);
        }
    } else {
        Dialog.alert(msg, null, 420, 60);
    }
}

///修改设置属性
function ArtiOperate(ObjValue, Obj, Audit) {
    AjaxFun(((Audit) ? 'Arti/Audit_Property.aspx' : 'Arti/Operate_Property.aspx'), "action=property&" + ObjValue, SycmsLanguage.Category.ArtiOperate.l1, function (html) {
        if (html) {
            $(Obj).html(ShowTrueOrFalse(html, ''));
        }
    })
}
///修改属性属性
function ArtiOperate_List(ObjValue, Obj) {
    AjaxFun('ArtiList/Operate_Property.aspx', "action=property&" + ObjValue, SycmsLanguage.Category.ArtiOperateAudit.l1, function (html) {
        if (html) {
            $(Obj).html(ShowTrueOrFalse(html, ''));
        }
    })
}
//文章列表
function ArtiList(Type, ClassId, ID) {
    AjaxFun("Arti/Lists.aspx", "action=view&Type=" + Type + "&classid=" + ClassId + (ID ? "&ListArtiID="+ID : ""), " ", ".Rnr", ".Rnr");
    return false;
}

///上传flv
function FlvTextChange(FormName, fieldName, classID, modelID, fieldID1, fieldID2, fieldID3) {
    var lock = false;
    var obj = $("#" + FormName + "_" + fieldName + "_" + classID + "_" + modelID);
    if (obj) {
        var objv = obj.val().Trim();
        if (objv.length > 0) {
            if (objv.indexOf("://") == -1 && objv.indexOf("_auto.flv") == -1) {
                var obj_Old = $("#" + FormName + "_" + fieldName + "_" + classID + "_" + modelID + "_Old");
                var objv_Old = "";
                if (obj_Old) {
                    objv_Old = obj_Old.val().Trim();
                }
                if (objv != objv_Old) {
                    lock = true;
                }
            }
        }
    }
    if (lock) {
        if (fieldID1) {
            FirefoxDisabled($("table.Field_" + modelID + "_" + fieldID1));
        }
        if (fieldID2) {
            FirefoxDisabled($("table.Field_" + modelID + "_" + fieldID2));
        }
        if (fieldID3) {
            FirefoxDisabled($("table.Field_" + modelID + "_" + fieldID3));
        }
    } else {
        if (fieldID1) {
            FirefoxDisabled($("table.Field_" + modelID + "_" + fieldID1), 1);
        }
        if (fieldID2) {
            FirefoxDisabled($("table.Field_" + modelID + "_" + fieldID2), 1);
        }
        if (fieldID3) {
            FirefoxDisabled($("table.Field_" + modelID + "_" + fieldID3), 1);
        }
    }
}
//导入模板组
function ArtiContentFileListZip(FileUrl, FunPara) {
    AjaxFun("Arti/Lists_FileList.aspx", "FileUrl=" + encodeURIComponent(FileUrl) + "&FunPara=" + encodeURIComponent(FunPara), "正在解压并保存图片...");
}
//导入图片到编辑器多个。
function EditorAddMorePic(cookies, editor, FileExt, FileSize)
{
    SyCmsFileUploadWin("上传多图片", { "cookies": encodeURIComponent(cookies), "IsDir": 1, "IsType": 0 }, "", null, function (url) {
        FileUpdateRecord(null, url);
        CkeditorInsertHtml(editor, "<p style=\"text-align: center;\"><img src=\"" + url + "\"/></p>");
    }, FileExt ? ("*." + FileExt.split("|").join(";*.")) : "", FileSize);
}
//选择多个图片到编辑器
function EditorSelectMorePic(editor, FileExt, FileSize)
{
    DirImgWin(function (UrlAll) {
        if (UrlAll) {
            var UrlAllArr = UrlAll.split(",");
            var pArr = new Array();
            for (var i = 0; i < UrlAllArr.length; i++)
            {
                pArr.push("<p style=\"text-align: center;\"><img src=\"" + url + "\"/></p>");
            }
            CkeditorInsertHtml(editor, pArr.join(""));
        }
    }, 0, "IsNum=1" + (FileExt ? "&FileExt=" + ("*." + FileExt.split("|").join(";*.")) : "") + (FileSize ? "&FileSize=" + FileSize : ""));
}
function OnKeyDown(obj, isenter)
{
    obj.select();
}