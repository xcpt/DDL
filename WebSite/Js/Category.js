///显示
function CategoryList(str, NoTreeList, IsAdd, IsModi, IsDel, IsOperate, IsOrder, ArtiIsView, ArtiIsAdd, ArtiIsDel, WebPathUrl) {
    var reval = new Array();
    $(str).each(function () {
        var C = this;
        if (C.Parentid != 0) {
            reval.push("<tr id=\"node-" + C.Depth + "-" + C.Classid + "\" Depth=\"" + C.Depth + "\" class=\"child-of-node-" + (parseInt(C.Depth) - 1) + "-" + C.Parentid + "\">");
        } else {
            reval.push("<tr id=\"node-" + C.Depth + "-" + C.Classid + "\" Depth=\"" + C.Depth + "\">");
        }
        reval.push("<td align=\"left\"><span class=\"" + (C.DoMainID == 1 ? "world" : (C.Type == 0 ? (C.ChildNum > 0 ? "folder" : "folder_Arti") : (C.Type == 1 ? "file" : "link"))) + "\">[" + C.Classid + "]" + ((C.ChildNum > 0 || C.Type != 0) ? C.ClassName : ((ArtiIsView && (C.Admin || (!C.Admin && C.User && C.IsArtiList))) ? "<a href=\"\" onclick=\"return ArtiViewList(" + C.Classid + ",'" + (NoTreeList ? "&NoTreeList=" + NoTreeList : "") + "');\">" + C.ClassName + "</a>" : C.ClassName)) + "</span></td><td>" + C.Hits + "</td><td align=\"left\">");

        if (C.Admin || (C.User && C.IsOperate)) {
            if (IsOperate) {
                reval.push("<a href=\"#\" onclick=\"CategoryOperate('action=property&wordtype=IsNavi&classid=" + C.Classid + "',this);return false;\" ><img src=\"images/icon/" + (C.IsNavi == 1 ? "true" : "false") + ".png\" /></a>");
            } else {
                reval.push("<img src=\"images/icon/" + (C.IsNavi == 1 ? "true" : "false") + "_Gray.png\" />");
            }
        } else {
            reval.push("<img src=\"images/icon/" + (C.IsNavi == 1 ? "true" : "false") + "_Gray.png\" />");
        }
        reval.push("</td><td>" + ((C.Admin && C.ChildNum <= 0) ? "<img src=\"images/icon/edit.png\" style=\"float:right;\" class=\"imgbutton\" title=\"" + SycmsLanguage.Category.CategoryList.l10 + "\" onclick=\"return CategoryModiType(" + C.Classid + "," + C.Type + ");\"/>" : "") + C.TypeName + "</td><td>&nbsp;" + ((C.Type == 0) ? C.ModelName : "&nbsp;") + "</td><td valign=\"middle\" align=\"left\" class=\"img\">");
        if (C.Admin) {
            if (C.Type == 0) {
                reval.push((IsAdd ? "<img src=\"images/icon/folder_add.png\" title=\"" + SycmsLanguage.Category.CategoryList.l1 + "\" onclick=\"return CategoryAdd('" + C.Classid + "');\"/>" : "<img src=\"images/icon/folder_add.png\" title=\"" + SycmsLanguage.Category.CategoryList.l1 + "\" class=\"tm\" />") + (C.ChildNum > 0 || !ArtiIsAdd ? "<img src=\"images/icon/folder_page.png\" title=\"" + SycmsLanguage.Category.CategoryList.l2 + "\" class=\"tm\"/>" : "<img src=\"images/icon/folder_page.png\" title=\"" + SycmsLanguage.Category.CategoryList.l2 + "\" onclick=\"return CategoryAddArtiOne(" + C.Classid + ",'0','category');\" />") + (IsModi ? "<img src=\"images/icon/folder_edit.png\" title=\"" + SycmsLanguage.Category.CategoryList.l3 + "\" onclick=\"return CategoryModi(" + C.Classid + "," + C.Type + "," + IsAdd + ");\" />" : "<img src=\"images/icon/folder_edit.png\" title=\"" + SycmsLanguage.Category.CategoryList.l3 + "\" class=\"tm\" />") + (IsOperate ? "<img src=\"images/icon/folder_up.png\" onclick=\"return CategoryMove(" + C.Classid + ");\" title=\"" + SycmsLanguage.Category.CategoryList.l4 + "\" />" : "<img src=\"images/icon/folder_up.png\" class=\"tm\" title=\"" + SycmsLanguage.Category.CategoryList.l4 + "\" />") + (ArtiIsDel && C.ChildNum == 0 ? "<img src=\"images/icon/folder_bookmark.png\" onclick=\"return CategoryClear(" + C.Classid + ");\" title=\"" + SycmsLanguage.Category.CategoryList.l5 + "\" />" : "<img src=\"images/icon/folder_bookmark.png\" class=\"tm\" title=\"" + SycmsLanguage.Category.CategoryList.l5 + "\" />") + (IsDel ? "<img src=\"images/icon/folder_delete.png\" onclick=\"return CategoryDel(" + C.Classid + ");\" title=\"" + SycmsLanguage.Category.CategoryList.l6 + "\"/>" : "<img src=\"images/icon/folder_delete.png\" class=\"tm\" title=\"" + SycmsLanguage.Category.CategoryList.l6 + "\"/>"));
            }
            else {
                reval.push("<img src=\"images/icon/folder_add.png\" title=\"" + SycmsLanguage.Category.CategoryList.l1 + "\" class=\"tm\" /><img src=\"images/icon/folder_page.png\" title=\"" + SycmsLanguage.Category.CategoryList.l2 + "\" class=\"tm\" />" + (IsModi ? "<img src=\"images/icon/folder_edit.png\" onclick=\"return CategoryModi(" + C.Classid + "," + C.Type + "," + IsAdd + ");\" title=\"" + SycmsLanguage.Category.CategoryList.l3 + "\" />" : "<img src=\"images/icon/folder_edit.png\" class=\"tm\" title=\"" + SycmsLanguage.Category.CategoryList.l3 + "\" />") + (IsOperate ? "<img src=\"images/icon/folder_up.png\" onclick=\"return CategoryMove(" + C.Classid + ");\" title=\"" + SycmsLanguage.Category.CategoryList.l4 + "\"/>" : "<img src=\"images/icon/folder_up.png\" class=\"tm\" title=\"" + SycmsLanguage.Category.CategoryList.l4 + "\"/>") + "<img src=\"images/icon/folder_bookmark.png\" title=\"" + SycmsLanguage.Category.CategoryList.l5 + "\" class=\"tm\" />" + (IsDel ? "<img src=\"images/icon/folder_delete.png\" onclick=\"return CategoryDel(" + C.Classid + ");\" title=\"" + SycmsLanguage.Category.CategoryList.l6 + "\" />" : "<img src=\"images/icon/folder_delete.png\" class=\"tm\" title=\"" + SycmsLanguage.Category.CategoryList.l6 + "\" />"));
            }
            if (C.OrderId == 0 && C.OrderId != C.MaxOrderId) {
                reval.push("<img src=\"images/icon/arrow_up.png\" title=\"" + SycmsLanguage.Category.CategoryList.l7 + "\" class=\"tm\" />");
            }
            else {
                if (C.OrderId != 0 && IsOperate) {
                    reval.push("<img src=\"images/icon/arrow_up.png\" title=\"" + SycmsLanguage.Category.CategoryList.l7 + "\" onclick=\"return CategoryUp(" + C.Classid + ");\" />");
                }
                else {
                    reval.push("<img src=\"images/icon/arrow_up.png\" title=\"" + SycmsLanguage.Category.CategoryList.l7 + "\" class=\"tm\" />");
                }
            }
            if (C.OrderId < C.MaxOrderId && IsOperate) {
                reval.push("<img src=\"images/icon/arrow_down.png\" title=\"" + SycmsLanguage.Category.CategoryList.l8 + "\" onclick=\"return CtegoryDown(" + C.Classid + ");\" />");
            }
            else {
                reval.push("<img src=\"images/icon/arrow_down.png\" title=\"" + SycmsLanguage.Category.CategoryList.l8 + "\" class=\"tm\"/>");
            }
            if (C.IsUrl == 1) {
                reval.push("<img src=\"images/icon/folder_go.png\" title=\"" + SycmsLanguage.Category.CategoryList.l9 + "\" onclick=\"CreateHtml('action=class&classid=" + C.Classid + "',1);\">");
            }
            if (C.IsTem == 1 && WebPathUrl) {
                reval.push("<a href=\"" + WebPathUrl + "&ClassID=" + C.Classid + "\" target=\"_blank\"><img src=\"images/icon/folder_link.png\" title=\"" + SycmsLanguage.Category.CategoryList.l11 + "\"/></a>");
            }
        }
        else {
            if (C.User) {
                if (C.Type == 0) {
                    reval.push((IsAdd && C.IsAdd ? "<img src=\"images/icon/folder_add.png\" title=\"" + SycmsLanguage.Category.CategoryList.l1 + "\" onclick=\"return CategoryAdd('" + C.Classid + "');\"/>" : "<img src=\"images/icon/folder_add.png\" title=\"" + SycmsLanguage.Category.CategoryList.l1 + "\" class=\"tm\" />") + (C.ChildNum > 0 ? "<img src=\"images/icon/folder_page.png\" title=\"" + SycmsLanguage.Category.CategoryList.l2 + "\" class=\"tm\"/>" : (ArtiIsAdd && C.IsArtiAdd ? "<img src=\"images/icon/folder_page.png\" title=\"" + SycmsLanguage.Category.CategoryList.l2 + "\" onclick=\"return CategoryAddArtiOne(" + C.Classid + ", 0, 'category');\" />" : "<img src=\"images/icon/folder_page.png\" title=\"" + SycmsLanguage.Category.CategoryList.l2 + "\" class=\"tm\"/>")) + (IsModi && C.IsModi ? "<img onclick=\"return CategoryModi(" + C.Classid + "," + C.Type + "," + (IsAdd && C.IsAdd ? "1" : "0") + ");\" src=\"images/icon/folder_edit.png\" title=\"" + SycmsLanguage.Category.CategoryList.l3 + "\" />" : "<img src=\"images/icon/folder_edit.png\" title=\"" + SycmsLanguage.Category.CategoryList.l3 + "\" class=\"tm\" />") + (IsDel && ArtiIsDel && C.IsArtiDel && C.ChildNum == 0 ? "<img src=\"images/icon/folder_bookmark.png\" onclick=\"return CategoryClear(" + C.Classid + ");\" title=\"" + SycmsLanguage.Category.CategoryList.l5 + "\" />" : "<img src=\"images/icon/folder_bookmark.png\" class=\"tm\" title=\"" + SycmsLanguage.Category.CategoryList.l5 + "\" />") + (IsDel && C.IsDel ? "<img src=\"images/icon/folder_delete.png\" onclick=\"return CategoryDel(" + C.Classid + ");\" title=\"" + SycmsLanguage.Category.CategoryList.l6 + "\"/>" : "<img src=\"images/icon/folder_delete.png\" class=\"tm\" title=\"" + SycmsLanguage.Category.CategoryList.l6 + "\"/>"));
                }
                else {
                    reval.push("<img src=\"images/icon/folder_add.png\" title=\"" + SycmsLanguage.Category.CategoryList.l1 + "\" class=\"tm\" /><img src=\"images/icon/folder_page.png\" title=\"" + SycmsLanguage.Category.CategoryList.l2 + "\" class=\"tm\"/>" + (IsModi && C.IsModi ? "<img src=\"images/icon/folder_edit.png\" title=\"" + SycmsLanguage.Category.CategoryList.l3 + "\" onclick=\"return CategoryModi(" + C.Classid + "," + C.Type + "," + (IsAdd && C.IsAdd ? "1" : "0") + ");\" />" : "<img src=\"images/icon/folder_edit.png\" class=\"tm\" title=\"" + SycmsLanguage.Category.CategoryList.l3 + "\" />") + "<img src=\"images/icon/folder_bookmark.png\" title=\"" + SycmsLanguage.Category.CategoryList.l5 + "\" class=\"tm\" />" + (IsDel && C.IsDel ? "<img src=\"images/icon/folder_delete.png\" onclick=\"return CategoryDel(" + C.Classid + ");\" title=\"" + SycmsLanguage.Category.CategoryList.l6 + "\" />" : "<img src=\"images/icon/folder_delete.png\" class=\"tm\" title=\"" + SycmsLanguage.Category.CategoryList.l6 + "\" />"));
                }
                if (C.OrderId == 0 && C.OrderId != C.MaxOrderId || IsOrder == 0) {
                    reval.push("<img src=\"images/icon/arrow_up.png\" title=\"" + SycmsLanguage.Category.CategoryList.l7 + "\" class=\"tm\" />");
                }
                else {
                    if (C.OrderId != 0 && IsOperate && IsOrder == 1 && C.IsOrder == 1) {
                        reval.push("<img src=\"images/icon/arrow_up.png\" title=\"" + SycmsLanguage.Category.CategoryList.l7 + "\" onclick=\"return CategoryUp(" + C.Classid + ");\" />");
                    }
                    else {
                        reval.push("<img src=\"images/icon/arrow_up.png\" title=\"" + SycmsLanguage.Category.CategoryList.l7 + "\" class=\"tm\" />");
                    }
                }
                if (C.OrderId < C.MaxOrderId && IsOperate && IsOrder == 1 && C.IsOrder == 1) {
                    reval.push("<img src=\"images/icon/arrow_down.png\" title=\"" + SycmsLanguage.Category.CategoryList.l8 + "\" onclick=\"return CtegoryDown(" + C.Classid + ");\" />");
                }
                else {
                    reval.push("<img src=\"images/icon/arrow_down.png\" title=\"" + SycmsLanguage.Category.CategoryList.l8 + "\" class=\"tm\"/>");
                }
                if (C.IsUrl == 1) {
                    reval.push("<img src=\"images/icon/folder_go.png\" title=\"" + SycmsLanguage.Category.CategoryList.l9 + "\" onclick=\"CreateHtml('action=class&classid=" + C.Classid + "',1);\">");
                }
                if (C.IsTem == 1 && WebPathUrl) {
                    reval.push("<a href=\"" + WebPathUrl + "&ClassID=" + C.Classid + "\" target=\"_blank\"><img src=\"images/icon/folder_link.png\" title=\"" + SycmsLanguage.Category.CategoryList.l11 + "\"/></a>");
                }
            }
            else {
                reval.push("&nbsp;");
            }
        }
        reval.push("</td></tr>\n");
    });
    return reval.join("");
}

//查找栏目
function CategoryListFind()
{
    Dialog.confirm("请输入要查找的栏目的名称或ID<br/><input type=\"text\" name=\"CategoryList_Name\" id=\"CategoryList_Name\" value=\"\">", function () {
        var objValue = $("#CategoryList_Name").val();
        ShowCategory(objValue);
    });
}


//在栏目添加时的过渡
function CategoryAddArtiOne(classID, Type, View) {
    AjaxFun("Arti/Add_One.aspx", "Type=" + Type + "&ClassID=" + classID + "&AddType=" + View, " ");
    return false;
}

///栏目内容添加
function CategoryAddArti(classID, Type, fieldID, ID, View, WinWidth, WinHeight, WinMove) {
    CreateWindow("Arti/Add.aspx?Type=" + Type + "&ClassID=" + classID + (fieldID ? "&fieldID=" + fieldID : "") + (ID ? "&ArtiID=" + ID : "") + (View ? View : ""), SycmsLanguage.Category.CategoryAddArti.l1, "Arti/Add.aspx?Type=" + Type + "&ClassID=" + classID + (fieldID ? "&fieldID=" + fieldID : "") + (ID ? "&ArtiID=" + ID : "") + "&action=save", WinWidth, WinHeight, "ArtiAdd" + classID + "_" + Type + "_" + (fieldID ? fieldID : ""), { Name: SycmsLanguage.Category.CategoryAddArti.l2, Url: "Arti/Add.aspx?CloseWin=false&Type=" + Type + "&ClassID=" + classID + (fieldID ? "&fieldID=" + fieldID : "") + (ID ? "&ArtiID=" + ID : "") + "&action=save", Function: function (objwin, objFromName) {
        var obj = $("#" + objFromName);
        var objs = obj.find(".otherSaveAUrl");
        objs.trigger("click");
    }, FormName: "ArtiAdd" + classID + "_" + Type + "_" + (fieldID ? fieldID : "") + "Form", PostReturnFunction: function (html, WindowsDiag) {
        var obj1 = $("#ArtiAdd" + classID + "_" + Type + "_" + (fieldID ? fieldID : ""));
        var obj = obj1.find("input.FieldIDModelInput_" + classID + "_" + Type + (fieldID ? ("_" + fieldID) : ""));
        obj.each(function () {
            $(this.value).flexReload();
        });
        obj1.find(".FileListDiv>div").remove();
        obj1.find("li.custom-radio,li.custom-checkbox").each(function () {
            if ($(this).find("input").attr("_value") == "off") {
                $(this).find("label").removeClass("checked");
            } else {
                $(this).find("label").addClass("checked");
            }
        });
        obj1.find("select.chzn-done").each(function ()
        {
            var o = $(this);
            var chzn = $("#" + o.attr("id") + "_chzn");
            var option = o.find("option[value='" + o.attr("_value") + "']");
            if (option.length > 0) {
                chzn.find("a.chzn-single span").html(option.text());
                chzn.find("li#" + o.attr("id") + "_chzn_o_" + option.Index()).addClass("highlighted");
            } else {
                chzn.find("a.chzn-single span").html("");
            }
            chzn.find("li.highlighted").removeClass("highlighted");
        });
        obj1.find("ul.as-selections").each(function ()
        {
            var id = $(this).attr("id").replace("as-selections-", "");
            var v = "," + $("#" + id).attr("_value") + ",";
            $(this).find("li.as-selection-item").each(function () {
                if (v.indexOf("," + $(this).attr("value") + ",") == -1) {
                    $(this).find("a").trigger("click");
                }
            });
        });
        obj = obj1.find("textarea.FieldIDEditorTextArea");
        obj.each(function () {
            var instance1 = CKEDITOR.instances[this.id];
            if (instance1) {
                instance1.setMode("source");
                instance1.setData("");
                instance1.setMode("wysiwyg");
            }
        });
    }
    }, null, null, null, null, null, null, null, null, WinMove);
    return false;
}

//栏目内容修改
function CategoryModiArti(Classid, Id, Type, IsAdd, FieldID, WinWidth, WinHeight, WinMove, OtherMessage) {
    FieldID = (FieldID ? FieldID : "");
    ActFieldID = (FieldID ? ("&FieldID=" + FieldID) : "");
    if (IsAdd) {
        GridModiy(Id, "Arti/Modi.aspx?ClassID=" + Classid + "&Type=" + Type + ActFieldID, SycmsLanguage.Category.CategoryModiArti.l1, "Arti/Modi.aspx?ClassID=" + Classid + "&Type=" + Type + ActFieldID + "&action=save", WinWidth, WinHeight, "ArtiModi_" + Classid + "_" + Type + "_" + FieldID, { Name: SycmsLanguage.Category.CategoryModiArti.l2, Url: "Arti/Add.aspx?ClassID=" + Classid + ActFieldID + "&Type=" + Type + "&saveas=true&action=save", Function: function (objwin, objFromName) {
            var obj = $("#" + objFromName);
            var objs = obj.find(".otherSaveAUrl");
            objs.trigger("click");
        }
        }, null, null, null, null, null, null, null, null, WinMove);
    } else {
        GridModiy(Id, "Arti/Modi.aspx?ClassID=" + Classid + ActFieldID + "&Type=" + Type + (OtherMessage ? OtherMessage : ""), SycmsLanguage.Category.CategoryModiArti.l1, "Arti/Modi.aspx?ClassID=" + Classid + ActFieldID + "&Type=" + Type + (OtherMessage ? OtherMessage : "") + "&action=save", WinWidth, WinHeight, "ArtiModi_" + Classid + "_" + Type + "_" + FieldID, null, null, null, null, null, null, null, null, null, WinMove);
    }
    return false;
}
//栏目内容显示
function ArtiViewList(Classid,action) {
    AjaxFun("Arti/Lists.aspx", "action=view&classid=" + Classid + (action ? action : ""), " ", ".Rnr");
    return false;
}
//栏目向上移动
function CategoryUp(Classid) {
    AjaxFun("Category/Order.aspx", "action=up&Classid=" + Classid, SycmsLanguage.Category.CategoryUp.l1);
    return false;
}
function CtegoryDown(Classid) {
    AjaxFun("Category/Order.aspx", "action=down&Classid=" + Classid + "", SycmsLanguage.Category.CtegoryDown.l1);
    return false;
}
///栏目添加
function CategoryModiType(ClassID, Type) {
    CreateWindow('Category/Modi_Type.aspx?ClassID=' + ClassID, SycmsLanguage.Category.CategoryModiType.l1, 'Category/Modi_Type.aspx?action=save', 600, (Type==0?175:130), 'ClassModiyType', null, null, null, null, function (objwin) {
        objwin.okButton.value = SycmsLanguage.Category.CategoryModiType.l2;
        $('#ClassModiyType #Type_0').bind('click', function () {
            objwin.setSize(600, 175);
            $('#ClassModiyType #ModelView').show();
        });
        $('#ClassModiyType #Type_1').bind('click', function () {
            objwin.setSize(600, 130);
            $('#ClassModiyType #ModelView').hide();
        });
        $('#ClassModiyType #Type_2').bind('click', function () {
            objwin.setSize(600, 130);
            $('#ClassModiyType #ModelView').hide();
        });
    }, null, null, null, function (FormName) {
        if ($('#' + FormName + " input[name='Type']:checked").val() == "0") {
            var selectVal = $('#' + FormName + " select[name='modelid']").val();
            if (selectVal == "0" || selectVal == "") {
                Dialog.error("错误：模型必须选择。", null, null, 50);
                return false;
            }
        }
        return true;
    });
    return false;
}
function CategoryAddFast(Parentid) {
    CreateWindow('Category/Add_Fast.aspx?Parentid=' + Parentid, SycmsLanguage.Category.CategoryAddFast.l1, 'Category/Add_Fast.aspx?action=save', 600, 450, 'ClassAdd');

}
///栏目添加
function CategoryAdd(Parentid) {
    CreateWindow('Category/Add.aspx?Parentid=' + Parentid, SycmsLanguage.Category.CategoryAdd.l1, 'Category/Add_Two.aspx', 600, 215, 'ClassAdd', null, null, null, null, function (objwin) {
        objwin.okButton.value = SycmsLanguage.Category.CategoryAdd.l2;
        $('#ClassAdd #Type_0').bind('click', function () {
            objwin.setSize(600, 215);
            $('#ClassAdd #ModelView').show();
        });
        $('#ClassAdd #Type_1').bind('click', function () {
            objwin.setSize(600, 170);
            $('#ClassAdd #ModelView').hide();
        });
        $('#ClassAdd #Type_2').bind('click', function () {
            objwin.setSize(600, 170);
            $('#ClassAdd #ModelView').hide();
        });
    }, null, null, null, function (FormName) {
        if ($('#' + FormName + " input[name='Type']:checked").val() == "0") {
            var selectVal = $('#' + FormName + " select[name='modelid']").val();
            if (selectVal == "0" || selectVal == "") {
                Dialog.error("错误：模型必须选择。",null,null,50);
                return false;
            }
        }
        return true;
    });
    return false;
}
///栏目添加
function CategoryAdd_Two(ParentId, Type, Modelid, SchemeClassID) {
    switch (Type) {
        case 0:
            {
                CreateWindow("Category/Add_Two.aspx?action=view&parentid=" + ParentId + "&type=" + Type + "&modelid=" + Modelid + "&SchemeClassID=" + SchemeClassID, "添加栏目 >> 第二步", "Category/Add_Two.aspx?action=save", 700, 285, 'ClassAddTwo', null, null, null, null, function (objwin) {
                    CategorySpecialWindowSize(0, objwin);
                });
                break;
            }
        case 1:
            {
                CreateWindow("Category/Add_Two.aspx?action=view&parentid=" + ParentId + "&type=" + Type + "&modelid=" + Modelid + "&SchemeClassID=" + SchemeClassID, "添加栏目 >> 第二步", "Category/Add_Two.aspx?action=save", 700, 370, 'ClassAddTwo', null, null, null, null, function (objwin) {
                    CategorySpecialWindowSize(1, objwin);
                });
                break;
            }
        case 2:
            {
                CreateWindow("Category/Add_Two.aspx?action=view&parentid=" + ParentId + "&type=" + Type + "&modelid=" + Modelid + "&SchemeClassID=" + SchemeClassID, "添加栏目 >> 第二步", "Category/Add_Two.aspx?action=save", 700, 230, 'ClassAddTwo', null, null, null, null, function (objwin) {
                    CategorySpecialWindowSize(2, objwin);
                });
                break;
            }
    }
}

//栏目修改的窗口大小
function CategorySpecialWindowSize(Type, objwin) {
    switch (Type) {
        case 0:
            {
                var Obj = $('#Cate1tabs>a');
                Obj.eq(0).bind('click', function () { objwin.setSize(700, 285); });
                Obj.eq(1).bind('click', function () { objwin.setSize(700, 570); });
                Obj.eq(2).bind('click', function () { objwin.setSize(700, 330); });
                Obj.eq(3).bind('click', function () { objwin.setSize(700, 400); });
                Obj.eq(4).bind('click', function () { objwin.setSize(700, 480); });
                Obj.eq(5).bind('click', function () { objwin.setSize(700, 330); });
                Obj.eq(6).bind('click', function () { objwin.setSize(700, 570); });
                Obj.eq(7).bind('click', function () { objwin.setSize(700, 330); });
                Obj.eq(8).bind('click', function () { objwin.setSize(700, 330); });
                break;
            }
        case 1:
            {
                var Obj = $('#Cate2tabs>a');
                Obj.eq(1).bind('click', function () { objwin.setSize(700, 570); });
                Obj.eq(0).bind('click', function () { objwin.setSize(700, 370); });
                Obj.eq(2).bind('click', function () { objwin.setSize(700, 320); });
                Obj.eq(3).bind('click', function () { objwin.setSize(700, 320); });
                Obj.eq(4).bind('click', function () { objwin.setSize(700, 570); });
                Obj.eq(5).bind('click', function () { objwin.setSize(700, 330); });
                Obj.eq(6).bind('click', function () { objwin.setSize(700, 330); });
                break;
            }
        case 2:
            {
                var Obj = $('#Cate3tabs>a');
                Obj.eq(1).bind('click', function () { objwin.setSize(700, 230); });
                Obj.eq(0).bind('click', function () { objwin.setSize(700, 230); });
                Obj.eq(2).bind('click', function () { objwin.setSize(700, 570); });
                Obj.eq(3).bind('click', function () { objwin.setSize(700, 330); });
                break;
            }
    }
}
///栏目修改
function CategoryModi(Classid, Type, IsAdd) {
    switch (Type) {
        case 0:
            {
                CreateWindow('Category/Modi.aspx?Classid=' + Classid, SycmsLanguage.Category.CategoryModi.l1, 'Category/Modi.aspx?action=save', 700, 285, 'ClassModi', (IsAdd ? { Name: SycmsLanguage.Category.CategoryModi.l2, Url: function (CreateWindowdiag, FormName, ParentName, PostReturnFunction) {
                    var childnum = $("#" + FormName + " #childnum").val();
                    childnum = parseInt(childnum.isNumber() ? childnum : 0);
                    if (childnum > 0) {
                        var obj = $("#ClassModi #ClassUrl");
                        var url1 = obj.val();
                        var url2 = obj.attr('_value');
                        if (url1 != url2) {
                            var i1 = url1.lastIndexOf("/");
                            if (i1 != -1) {
                                url1 = url1.substr(0, i1 + 1);
                            }
                            i1 = url2.lastIndexOf("/");
                            if (i1 != -1) {
                                url2 = url2.substr(0, i1 + 1);
                            }
                        } else {
                            url1 = "";
                            url2 = "";
                        }
                        //<br><fieldset><legend>生成地址规则</legend>1、<input type=\"radio\" value=\"1\" checked=\"checked\" name=\"Rulesvalue\" id=\"Rulesvalue_1\" /><label for=\"Rulesvalue_1\">地址后面随机数</label><br>2、<input type=\"radio\" value=\"1\" name=\"Rulesvalue\" id=\"Rulesvalue_2\" />把<input type=\"text\" id=\"Rulesvalue1\" style=\"width:60px;\" value=\"" + url2 + "\" \>替换为<input type=\"text\" id=\"Rulesvalue2\" style=\"width:60px;\" value=\"" + url1 + "\" \>
                        Dialog.confirm(SycmsLanguage.Category.CategoryModi.l3, function () {
                            CreateWindowFun("Category/Add_Two.aspx?action=save", FormName, CreateWindowdiag, ParentName, PostReturnFunction);
                        }, function () {
                            $("Rulesvalue_1").attr("checked");
                            CreateWindowFun("Category/Add_Two.aspx?action=save&child=1", FormName, CreateWindowdiag, ParentName, PostReturnFunction);
                        }, null, null, SycmsLanguage.Category.CategoryModi.l4, SycmsLanguage.Category.CategoryModi.l5);
                        //400, 150
                    } else {
                        CreateWindowFun("Category/Add_Two.aspx?action=save", FormName, CreateWindowdiag, ParentName, PostReturnFunction);
                    }
                }
                } : ""), null, null, null, function (objwin) {
                    CategorySpecialWindowSize(0, objwin);
                });
                break;
            }
        case 1:
            {
                CreateWindow('Category/Modi.aspx?Classid=' + Classid, SycmsLanguage.Category.CategoryModi.l1, 'Category/Modi.aspx?action=save', 700, 370, 'ClassModi', (IsAdd ? { Name: SycmsLanguage.Category.CategoryModi.l2, Url: 'Category/Add_Two.aspx?action=save'} : ""), null, null, null, function (objwin) {
                    CategorySpecialWindowSize(1, objwin);
                });
                break;
            }
        case 2:
            {
                CreateWindow('Category/Modi.aspx?Classid=' + Classid, SycmsLanguage.Category.CategoryModi.l1, 'Category/Modi.aspx?action=save', 700, 230, 'ClassModi', (IsAdd ? { Name: SycmsLanguage.Category.CategoryModi.l2, Url: 'Category/Add_Two.aspx?action=save'} : ""), null, null, null, function (objwin) {
                    CategorySpecialWindowSize(2, objwin);
                });
                break;
            }
    }
    return false;
}
///栏目移动
function CategoryMove(Classid) {
    CreateWindow('Category/Operate_Move.aspx?Classid=' + Classid, SycmsLanguage.Category.CategoryMove.l1, 'Category/Operate_Move.aspx?action=save', 400, 300, 'Modi_Move');
    return false;
}


///栏目删除
function CategoryDel(Classid) {
    Dialog.confirm(SycmsLanguage.Category.CategoryDel.l1, function () {
        AjaxFun('Category/Del.aspx', 'Classid=' + Classid, SycmsLanguage.Category.CategoryDel.l2);
    });
    return false;
}
///清空栏目内容
function CategoryClear(Classid) {
    Dialog.confirm(SycmsLanguage.Category.CategoryClear.l1, function () {
        AjaxFun('Category/Del_Clear.aspx', 'Classid=' + Classid, SycmsLanguage.Category.CategoryClear.l2);
    });
    return false;
}
///生成Html
///Type=Class为栏目  Content为内容
function CategoryCreate(Type) {
    var W = 400;
    var H = 300;
    if (Type.indexOf("Content")!=1) {
        H = 420;
    }
    CreateWindow('Category/Operate_Create.aspx?Type=' + Type, SycmsLanguage.Category.CategoryCreate.l1, function (objWin) {
        var Rvalue = ReadInputValue("CreateClass");
        objWin.close();
        CreateHtml(Rvalue);
        Rvalue = null;
    }, W, H, 'CreateClass');
    W = null;
    H = null;
}

///栏目移动
function CategoryMerge(ClassID) {
    CreateWindow('Category/Modi_Merge.aspx?ClassID=' + ClassID, SycmsLanguage.Category.CategoryMerge.l1, 'Category/Modi_Merge.aspx?action=save', 400, 300, 'Modi_Merge');
}

///修改设置属性
function CategoryOperate(ObjValue, Obj) {
    AjaxFun('Category/Operate.aspx', ObjValue, SycmsLanguage.Category.CategoryOperate.l1, function (html) {
        if (html) {
            $(Obj).html(html);
        }
    })
}

///专题添加
function SpecialAdd(Parentid) {
    CreateWindow('Special/Add.aspx?Parentid=' + Parentid, SycmsLanguage.Category.SpecialAdd.l1, 'Special/Add_Two.aspx', 600, 215, 'SpecialAdd', null, null, null, null, function (objwin) {
        objwin.okButton.value = SycmsLanguage.Category.SpecialAdd.l2;
        $('#SpecialAdd #Type_0').bind('click', function () {
            objwin.setSize(600, 215);
            $('#SpecialAdd #ModelView').show();
        });
        $('#SpecialAdd #Type_1').bind('click', function () {
            objwin.setSize(600, 170);
            $('#SpecialAdd #ModelView').hide();
        });
        $('#SpecialAdd #Type_2').bind('click', function () {
            objwin.setSize(600, 170);
            $('#SpecialAdd #ModelView').hide();
        });
    }, null, null, null, function (FormName) {
        if ($('#' + FormName + " input[name='Type']:checked").val() == "0") {
            var selectVal = $('#' + FormName + " select[name='modelid']").val();
            if (selectVal == "0" || selectVal == "") {
                Dialog.error("错误：模型必须选择。");
                return false;
            }
        }
        return true;
    });
}
///专题栏目添加
function SpecialAdd_Two(ParentId, Type, Modelid, SchemeClassID) {
    switch (Type) {
        case 0:
            {
                CreateWindow("Special/Add_Two.aspx?action=view&parentid=" + ParentId + "&type=" + Type + "&modelid=" + Modelid + "&SchemeClassID=" + SchemeClassID, "添加栏目 >> 第二步", "Special/Add_Two.aspx?action=save", 700, 285, 'ClassAddTwo', null, null, null, null, function (objwin) {
                    CategorySpecialWindowSize(0, objwin);
                });
                break;
            }
        case 1:
            {
                CreateWindow("Special/Add_Two.aspx?action=view&parentid=" + ParentId + "&type=" + Type + "&modelid=" + Modelid + "&SchemeClassID=" + SchemeClassID, "添加栏目 >> 第二步", "Special/Add_Two.aspx?action=save", 700, 370, 'ClassAddTwo', null, null, null, null, function (objwin) {
                    CategorySpecialWindowSize(1, objwin);
                });
                break;
            }
        case 2:
            {
                CreateWindow("Special/Add_Two.aspx?action=view&parentid=" + ParentId + "&type=" + Type + "&modelid=" + Modelid + "&SchemeClassID=" + SchemeClassID, "添加栏目 >> 第二步", "Special/Add_Two.aspx?action=save", 700, 230, 'ClassAddTwo', null, null, null, null, function (objwin) {
                    CategorySpecialWindowSize(2, objwin);
                });
                break;
            }
    }
}

///栏目修改
function SpecialModi(Specialid, Type,IsAdd) {
    switch (Type) {
        case 0:
            {
                CreateWindow('Special/Modi.aspx?Specialid=' + Specialid, SycmsLanguage.Category.SpecialModi.l1, 'Special/Modi.aspx?action=save', 700, 285, 'SpecialModi', (IsAdd ? { Name: SycmsLanguage.Category.SpecialModi.l2, Url: function (CreateWindowdiag, FormName, ParentName, PostReturnFunction) {
                    var childnum = $("#" + FormName + " #childnum").val();
                    childnum = parseInt(childnum.isNumber() ? childnum : 0);
                    if (childnum > 0) {
                        Dialog.confirm(SycmsLanguage.Category.SpecialModi.l3, function () {
                            CreateWindowFun("Special/Add_Two.aspx?action=save", FormName, CreateWindowdiag, ParentName, PostReturnFunction);
                        }, function () {
                            CreateWindowFun("Special/Add_Two.aspx?action=save&child=1", FormName, CreateWindowdiag, ParentName, PostReturnFunction);
                        }, null, null, SycmsLanguage.Category.SpecialModi.l4, SycmsLanguage.Category.SpecialModi.l5);
                    } else {
                        CreateWindowFun("Special/Add_Two.aspx?action=save", FormName, CreateWindowdiag, ParentName, PostReturnFunction);
                    }
                }
                } : ""), null, null, null, function (objwin) {
                    CategorySpecialWindowSize(0, objwin);
                });
                break;
            }
        case 1:
            {
                CreateWindow('Special/Modi.aspx?Specialid=' + Specialid, SycmsLanguage.Category.SpecialModi.l1, 'Special/Modi.aspx?action=save', 700, 370, 'SpecialModi', (IsAdd ? { Name: SycmsLanguage.Category.SpecialModi.l2, Url: 'Special/Add_Two.aspx?action=save'} : ""), null, null, null, function (objwin) {
                    CategorySpecialWindowSize(1, objwin);
                });
                break;
            }
        case 2:
            {
                CreateWindow('Special/Modi.aspx?Specialid=' + Specialid, SycmsLanguage.Category.SpecialModi.l1, 'Special/Modi.aspx?action=save', 700, 230, 'SpecialModi', (IsAdd ? { Name: SycmsLanguage.Category.SpecialModi.l2, Url: 'Special/Add_Two.aspx?action=save'} : ""), null, null, null, function (objwin) {
                    CategorySpecialWindowSize(2, objwin);
                });
                break;
            }
    }
}

//专题列表
function SpecialList(Specialid) {
    AjaxFun('Special/Lists.aspx', 'action=view&Parentid=' + Specialid, ' ', '.Rnr', '.Rnr');
}

///栏目删除
function SpecialDel(Specialid) {
    Dialog.confirm(SycmsLanguage.Category.SpecialDel.l1, function () {
        AjaxFun('Special/Del.aspx', 'Specialid=' + Specialid, SycmsLanguage.Category.SpecialDel.l2);
    });
}

///清空栏目内容
function SpecialClear(Specialid) {
    Dialog.confirm(SycmsLanguage.Category.SpecialClear.l1, function () {
        AjaxFun('Special/Del_Clear.aspx', 'Specialid=' + Specialid, SycmsLanguage.Category.SpecialClear.l2);
    });
}


///栏目移动
function SpecialMove(Specialid) {
    CreateWindow('Special/Modi_Move.aspx?SpecialId=' + Specialid, SycmsLanguage.Category.SpecialMove.l1, 'Special/Modi_Move.aspx?action=save', 400, 300, 'Modi_Move');
}


///栏目移动
function SpecialMerge() {
    CreateWindow('Special/Modi_Merge.aspx', SycmsLanguage.Category.SpecialMerge.l1, 'Special/Modi_Merge.aspx?action=save', 400, 300, 'Modi_Merge');
}


///修改设置属性
function SpecialOperate(ObjValue, Obj) {
    AjaxFun('Special/Operate.aspx', ObjValue, SycmsLanguage.Category.SpecialOperate.l1, function (html) {
        if (html) {
            $(Obj).html(html);
        }
    })
}

///专题
function AddClassOtherId(id, classID,ObjName,Type) {
    CreateWindow("Arti/Push_SpecialTree.aspx?Classid=" + classID + "&Type=" + Type + "&Specialid=" + $("#" + ObjName).val(), SycmsLanguage.Category.AddClassOtherId.l1, function (CreateWindowdiag) {
        var CheckList = $("#SpecialCheckList input").filter("[name='AddSpecialid']:checked");
        var CheckValue = new Array();
        CheckList.each(function() {
            CheckValue.push(encodeURIComponent($(this).val()));
        });
        $("#" + ObjName).val(CheckValue.join(','));
        CreateWindowdiag.close();
        CreateWindowdiag = null;
        CheckList = null;
        CheckValue = null;
    }, 500, 500, 'SpecialCheckList');
}
//栏目
function AddOtherId(id, classID, ObjName, Type) {
    CreateWindow("Arti/Push_CategoryTree.aspx?Classid=" + classID + "&Type=" + Type + "&AllClassid=" + $("#" + ObjName).val(), SycmsLanguage.Category.AddOtherId.l1, function (CreateWindowdiag) {
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



///属性窗口
function ArtiFunWin(Type, ClassID, FieldType, ClassName, ObjName, Action) {
    CreateWindow("ArtiInfo/Lists.aspx?action=view&Type=" + Type + "&ClassID=" + ClassID + "&FieldType=" + FieldType + "&ClassName=" + encodeURIComponent(ClassName) + "&ObjName=" + encodeURIComponent(ObjName) + Action, ClassName + SycmsLanguage.Category.ArtiFunWin.l1, null, 550, 500, null, null, null, null, null, null, null, null, null, null, null, null, function () {
        AjaxFun("ArtiInfo/Lists_View.aspx", "Type=" + Type + "&ClassID=" + ClassID + "&FieldType=" + FieldType + "&ClassName=" + encodeURIComponent(ClassName) + "&ObjName=" + encodeURIComponent(ObjName) + Action, " ", function (html) {
            if (html != "no") {
                var $obj = $("#" + ObjName);
                var type = $obj.attr("type");
                var oldvalue = ReadFromOneValue("#" + ObjName);
                $("#" + ObjName).html(html);
                WriteFromValue("#" + FromName, oldvalue, type);
            }
        });
    });
}
//属性窗口设置
function ArtiFunWinSetup(obj) {
    var option = obj.options[obj.selectedIndex];
    var value = option.value.split("|");
    var isalone = value[1];
    var isexpand = value[2];
    var obj1 = document.getElementById("IsAlone" + isalone);
    var obj2 = document.getElementById("IsExpand" + isexpand);
    if (obj1) {
        obj1.checked = true;
        document.getElementById("AdminAction1_View").style.display = "";
        document.getElementById("AdminAction1").checked = true;
        document.getElementById("AdminAction2_View").style.display = "";
        document.getElementById("AdminAction0_View").style.display = "none";
    } else {
        document.getElementById("AdminAction0_View").style.display = "";
        document.getElementById("AdminAction0").checked = true;
        document.getElementById("AdminAction1_View").style.display = "none";
        document.getElementById("AdminAction2_View").style.display = "none";
    }
    if (obj2) {
        obj2.checked = true;
    }
}

///文件上传（内容里）
function FileUpload(objName, ID, ModelID) {
    if (!ID) {
        ID = "";
    }
    var objT = $("#" + objName + "_" + ModelID + "_Select" + ID);
    var obj = $("#" + objName + "_" + ModelID + "_config" + ID);
    var objN = $("#" + objName + "_" + ModelID + "_name" + ID);
    if (obj.length > 0 && objN.length > 0) {
        var objV = obj.val();
        var objNV = objN.val();
        var objTT = objT.find("option:selected").text();
        var objTV = objT.val();
        if (objTV=="" || objTV=="0") {
            objTT = "";
        }
        if (objV.length > 0 && objNV.length > 0) {
            AjaxFun("AdminFun/ArtiFile.aspx", "ID=" + ID + "&Type=" + encodeURIComponent(objTV) + "&Name=" + encodeURIComponent(objNV) + "&Url=" + encodeURIComponent(objV), " ", function (html) {
                if (html.length > 0) {
                    obj.val("");
                    objN.val("");
                    FileUploadHtmlView(ID, html, objTV, objTT, objNV, objV, objName, ModelID);
                }
            });
        }
    }
}

function FileUploadHtmlView(Yid, ID, objTV, objTT, objNV, objV, objName, ModelID)
{
    if (Yid == "") {
        FileUpdateRecord(null, "0," + ID);
    } else {
        ID = Yid;
    }
    var str = "<fieldset><legend><div style=\"float:left;padding-left:3px;\"><input type=\"button\" value=\"" + SycmsLanguage.Arti.Content_Arti_FileUpdate.l1 + "\" onclick=\"FileUploadModi('" + ID + "','" + objTV + "', '" + objNV + "', '" + objV + "','" + objName + "','" + ModelID + "');\" icon=\"icon-table_edit\" /></div><div style=\"float:left;padding-left:3px;\"><input type=\"button\" value=\"" + SycmsLanguage.Arti.Content_Arti_FileUpdate.l2 + "\" onclick=\"$('#ArtiFile_" + ID + "_Con').remove();AjaxFun('AdminFun/ArtiFile.aspx','action=del&id=" + ID + "');\" icon=\"icon-delete\" /></div></legend><input type=\"hidden\" name=\"" + objName + "_" + ModelID + "\" value=\"" + ID + "\" /><div style=\"float:left;padding-top:3px;vertical-align:middle;\">" + SycmsLanguage.Arti.Content_Arti_FileUpdate.l3 + objTT + "&nbsp;&nbsp;" + SycmsLanguage.Arti.Content_Arti_FileUpdate.l4 + objNV + "&nbsp;&nbsp;" + SycmsLanguage.Arti.Content_Arti_FileUpdate.l5.replace("$$", FileUploadView(objV)) + objV + "&nbsp;&nbsp;" + SycmsLanguage.Arti.Content_Arti_FileUpdate.l6 + "0</div></fieldset>";
    if (Yid) {
        $("#ArtiFile_" + ID + "_Modiy").html("").hide();
        $("#ArtiFile_" + ID + "_View").show().html(str).btnForMat().find(".jTip").JT_init();
    } else {
        $("#" + objName + "_" + ModelID + "_configView").append("<div style=\"margin:3px;clear:both;\" id=\"ArtiFile_" + ID + "_Con\"><div id=\"ArtiFile_" + ID + "_Modiy\"></div><div id=\"ArtiFile_" + ID + "_View\">" + str + "</div></div>").btnForMat().find(".jTip").JT_init();
    }
}

function FileUploadView(FileName) {
    var str = "<img src=\"Images/File/Grid/file.png\" style=\"vertical-align:middle;\">";
    FileName = FileName.toLowerCase();
    if (FileName.Right(4) == ".jpg" || FileName.Right(5) == ".jpeg" || FileName.Right(4) == ".gif" || FileName.Right(4) == ".bmp" || FileName.Right(4) == ".png") {
        str = "<img src=\"Images/File/Grid/picture.png\" style=\"vertical-align:middle;\" alt=\"" + FileName + "?width=200&height=200\" class=\"jTip\" name=\"" + SycmsLanguage.Category.FileUploadView.l1 + "\">";
    }
    return str;
}
///内容中文件列表文件修改
function FileUploadModi(ID, FileType, FileName, FileUrl, objName, ModelID) {
    var objT = $("#" + objName + "_" + ModelID + "_Select");
    if (FileName.length > 0) { 
        $("#ArtiFile_"+ID+"_View").hide();
        $("#ArtiFile_" + ID + "_Modiy").show().html("<fieldset><legend><div style=\"float:left;padding-left:3px;\"><input type=\"button\" value=\"" + SycmsLanguage.Category.FileUploadModi.l1 + "\" onclick=\"FileUpload('" + objName + "','" + ID + "','" + ModelID + "');\" icon=\"icon-save\" /></div><div style=\"float:left;padding-left:3px;\"><input type=\"button\" value=\"" + SycmsLanguage.Category.FileUploadModi.l2 + "\" onclick=\"$('#ArtiFile_" + ID + "_Modiy').html('').hide();$('#ArtiFile_" + ID + "_View').show();\" icon=\"icon-retry\" /></div></legend><div style=\"float:left;\">" + SycmsLanguage.Category.FileUploadModi.l3 + "<select id=\"" + objName + "_" + ModelID + "_Select" + ID + "\" >" + objT.html() + "</select></div><div style=\"float:left;\">" + SycmsLanguage.Category.FileUploadModi.l4 + "<input type=\"text\" id=\"" + objName + "_" + ModelID + "_name" + ID + "\" size=\"30\" maxlength=\"500\" /></div><div style=\"float:left;\">&nbsp;" + SycmsLanguage.Category.FileUploadModi.l5 + "<input type=\"text\" id=\"" + objName + "_" + ModelID + "_config" + ID + "\"  size=\"30\" maxlength=\"500\" /></div><div style=\"float:left;padding-left:3px;\"><input type=\"button\" value=\"" + SycmsLanguage.Category.FileUploadModi.l6 + "\" onclick=\"UploadFile('" + objName + "_" + ModelID + "_config" + ID + "','File');\" icon=\"icon-picture_add\" /></div><div style=\"float:left;padding-left:3px;\"><input type=\"button\" value=\"" + SycmsLanguage.Category.FileUploadModi.l7 + "\" onclick=\"DirImgWin($id('" + objName + "_" + ModelID + "_config" + ID + "'),0);\" icon=\"icon-pictures\" /></div><div style=\"float:left;padding-left:3px;\"><input type=\"button\" icon=\"icon-picture_edit\" onclick=\"CutPicFun('" + objName + "_" + ModelID + "_config" + ID + "','');\" value=\"" + SycmsLanguage.Category.FileUploadModi.l8 + "\" /></div></fieldset>").btnForMat();
        $("#" + objName + "_" + ModelID + "_Select" + ID).val(FileType);
        $("#" + objName + "_" + ModelID + "_name" + ID).val(FileName);
        $("#" + objName + "_" + ModelID + "_config" + ID).val(FileUrl);
    }
}


//推送到其它栏目
function TSClass(Path,Type, ClassID, gridList, ModelID) {
    var ID = GridReadID(gridList);
    if (ID) {
        CreateWindow(Path + '/Push_CateTree.aspx?Type=' + Type + (ModelID ? "&ModelID=" + ModelID : "") + '&Classid=' + ClassID + '&id=' + ID, SycmsLanguage.Category.TSClass.l1, Path + '/Push_CateTree.aspx?Type=' + Type + (ModelID ? "&ModelID=" + ModelID : "") + '&Id=' + ID + '&Classid=' + ClassID + '&Action=save', 500, 400, 'ClassCheckList');
    }
    return false;
}

//移动到其它栏目
function MoveClass(Path,Type, ClassID, gridList, ModelID) {
    var ID = GridReadID(gridList);
    if (ID) {
        CreateWindow(Path + '/Modi_Move.aspx?Move=true&Type=' + Type + (ModelID ? "&ModelID=" + ModelID : "") + '&Classid=' + ClassID + '&id=' + ID, SycmsLanguage.Category.MoveClass.l1, Path + '/Modi_Move.aspx?Type=' + Type + (ModelID ? "&ModelID=" + ModelID : "") + '&Id=' + ID + '&Classid=' + ClassID + '&Move=true&action=save', 500, 400, 'ClassCheckList');
    }
    return false;
}

function TSSpecial(Path, Type, ClassID, gridList, ModelID) {
    var ID = GridReadID(gridList);
    if (ID) {
        CreateWindow(Path + '/Push_SpeTree.aspx?Type=' + Type + (ModelID ? "&ModelID=" + ModelID : "") + '&Classid=' + ClassID + '&id=' + ID, SycmsLanguage.Category.TSSpecial.l1, Path + '/Push_SpeTree.aspx?Type=' + Type + (ModelID ? "&ModelID=" + ModelID : "") + '&Classid=' + ClassID + '&id=' + ID + '&Action=save', 500, 400, 'ClassCheckList');
    }
    return false;
}

///栏目菜单
function ButtonMenu(objName, taskBar) {
    setTimeout(function () {
        var obj = $(objName);
        menuAdmin.del("Category_MoreMenu");
        if (taskBar.length > 0) {
            var m1 = new popUpMenu(taskBar, null, null, "Category_MoreMenu");
            menuAdmin.init("Category_MoreMenu").add(obj.get(0), m1, -3, 5);
        }
    }, 500);
}

///栏目菜单
function CategoryMenu(objName, objlist, classid,Type) {
    setTimeout(function() {
        var obj = $(objName);
        var taskBar = [];
        menuAdmin.del("Category_Menu" + classid);
        for (var i = 0; i < objlist.length; i++) {
            if (Type == 0) {
                taskBar.push({ text: "[" + (objlist[i].Depth + 1) + "]" + objlist[i].ClassName.MidStr(14), ico: 'images/icon/page_link.png', classID: objlist[i].ClassID, cmd: function() { CreateHtml('action=class&classid=' + this.classID, 1); } });
            } else {
                taskBar.push({ text: "[" + (objlist[i].Depth + 1) + "]" + objlist[i].ClassName.MidStr(14), ico: 'images/icon/page_link.png', classID: objlist[i].ClassID, cmd: function() { CreateHtml('action=special&specialid=' + this.classID + '&Classid=' + this.classID, 1); } });
            }
        }
        if (taskBar.length > 0) {
            var m1 = new popUpMenu(taskBar, null, null, "Category_Menu" + classid);
            menuAdmin.init("Category_Menu" + classid).add(obj.get(0), m1, -3, 5);
        }
    }, 500);
}
///同级栏目菜单
function CategorySameGrade(objName, objlist, classid, Type, NoTreeList) {
    setTimeout(function () {
        var obj = $(objName);
        var taskBar = [];
        menuAdmin.del("CategorySameGrade_Menu" + classid);
        for (var i = 0; i < objlist.length; i++) {
            if (Type == 0) {
                taskBar.push({ text: ((objlist[i].ClassID == classid) ? "<font color=red>" + objlist[i].ClassName.MidStr(14) + "</font>" : objlist[i].ClassName.MidStr(14)), ico: 'images/icon/folder.png', classID: objlist[i].ClassID, cmd: function () { ArtiViewList(this.classID, (NoTreeList ? "&NoTreeList=" + NoTreeList : "")); } });
            } else {
                taskBar.push({ text: ((objlist[i].ClassID == classid) ? "<font color=red>" + objlist[i].ClassName.MidStr(14) + "</font>" : objlist[i].ClassName.MidStr(14)), ico: 'images/icon/folder.png', classID: objlist[i].ClassID, cmd: function () { AjaxFun('Arti/Lists.aspx', 'action=view&Type=1&classid=' + this.classID, ' ', '.Rnr', '.Rnr'); } });
            }
        }
        if (taskBar.length > 0) {
            var m1 = new popUpMenu(taskBar, null, null, "CategorySameGrade_Menu" + classid);
            menuAdmin.init("CategorySameGrade_Menu" + classid).add(obj.get(0), m1, -3, 5);
        }
    }, 500);
}
//显示栏目位置
function ShowCategory(objValue, IsOpen) {
    if (objValue) {
        var ObjTable = $("#dnd-treeTable>tbody>tr");
        ObjTable.each(function (Index) {
            var ObjTr = $(this);
            var ObjSpan = ObjTr.find("td:eq(0)");
            var ObjSpanHtml = ObjSpan.html();
            if (ObjSpanHtml.indexOf("[" + objValue + "]") != -1 || ObjSpanHtml.indexOf(">" + objValue + "<") != -1 || ObjSpanHtml.indexOf("]" + objValue + "<") != -1) {
                if (!ObjTr.is(":visible")) {
                    var ObjTr1 = ObjTr;
                    var ObjArray = new Array();
                    while (ObjTr1 != null && ObjTr1.length > 0) {
                        var ParentID = ObjTr1.attr("class").split(" ")[0].split('-')[4]; //node-2-8
                        if (ParentID) {
                            var depth = parseInt(ObjTr1.attr("depth")) - 1;
                            ObjTr1 = ObjTable.filter("#node-" + depth + "-" + ParentID);
                            if (ObjTr1 != null && ObjTr1.length > 0 && !ObjTr1.hasClass("expanded")) {
                                ObjArray.push(ObjTr1);
                            } else {
                                break;
                            }
                        } else {
                            break;
                        }
                    }
                    for (var i = ObjArray.length - 1; i >= 0; i--) {
                        ObjArray[i].find("td:eq(0)>span.expander").trigger("click");
                    }
                }
                ObjTr.trigger("click");
                if (IsOpen)
                {
                    ObjSpan.find("span.expander").trigger("click");
                }
                var obj = $(".TreeViewTable");
                var ObjHeight = obj.height();
                var height = ObjTr.height() * Index;
                if (height > ObjHeight) {
                    obj.scrollTop(height - ObjHeight - 10);
                }
                return;
            }
        });
    }
}
//获取新的链接地址
function GetNewUrl(ObjName,ClassID,Type) {
    AjaxFun("Arti/Lists_GetUrl.aspx", "ClassID=" + ClassID + "&Type=" + Type, "", function (html) { $(ObjName).val(html); }, null, null, null, null, null, null, null, true);
}
//修改连接时
function ChangeUrl(ObjName, Url, Obj) {
    var obj_Button = null;
    var e = getEvent();
    if (document.all) {
        var m = MouseCoords(e);
        obj_Button = document.elementFromPoint(m.x, m.y);
    } else {
        obj_Button = e.explicitOriginalTarget;
    }
    if (!(obj_Button && obj_Button.tagName.toLowerCase() == "input" && obj_Button.type == "button")) {
        obj_Button = null;
    }    
    if (Url == "1") {
        if (Obj.value.length > 0) {
            var oldvalue = $(Obj).attr("oldid");
            if (!oldvalue) {
                $(Obj).attr("oldid", Obj.value);
            }
            if (Obj.value != oldvalue) {
                $("#" + Obj.id + "_aLink").show();
            }
            if (Obj.value.indexOf("://") == -1) {
                var obj = $(ObjName);
                if (obj) {
                    if (obj.length > 0) {
                        if (obj.val().length > 0 && obj.val() != "0") {
                            Dialog.confirm(SycmsLanguage.Category.ChangeUrl.l1, function () {
                                var oldid = obj.attr("oldid");
                                if (!oldid) {
                                    obj.attr("oldid", obj.val());
                                }
                                obj.val("");
                                $(ObjName.replace(".", "#") + "_a").show();
                                if (obj_Button) {
                                    $(obj_Button).trigger("click");
                                }
                            }, function () {
                                if (obj_Button) {
                                    $(obj_Button).trigger("click");
                                }
                            }, null, null, SycmsLanguage.Category.ChangeUrl.l2, SycmsLanguage.Category.ChangeUrl.l3);
                        }
                    }
                }
            }
        }
    } else if (Url == "2") {    //直接取消
        var obj = $(ObjName);
        if (obj) {
            if (obj.length > 0) {
                if (obj.val().length > 0 && obj.val() != "0") {
                    var oldid = obj.attr("oldid");
                    if (!oldid) {
                        obj.attr("oldid", obj.val());
                    }
                    obj.val("");
                    $(ObjName.replace(".", "#") + "_a").show();
                }
            }
        }
    }
}
//连接的还原
function ChangeUrlRestore(ObjName, obja) {
    var obj = $(ObjName);
    if (obj) {
        if (obj.length > 0) {
            obj.val(obj.attr("oldid"));
            $(obja).hide();
        }
    }
}
//栏目的显示与不显示
function CategoryView(obj, ClassName, ObjName) {
    var objv;
    if(typeof(obj)=="string")
    {
        objv = (obj == "1") ? true : false;
    }else{
        objv=obj.checked;
    }
    if (objv) {
        if (ClassName.length > 0) {
            FirefoxDisabled($(ClassName));
        }
        $(ObjName).hide();
    } else {
        if (ClassName.length > 0) {
            FirefoxDisabled($(ClassName),1);
            $(ClassName).each(function () {
                var o = $(this);
                var o1 = o.find(":checkbox");
                if (o1.length > 0) {
                    if (("1" + o1.attr("checked") + "1") == "1false1" || ("1" + o1.attr("checked") + "1") == "1undefined1") {
                        FirefoxDisabled(o1,1);
                    } else {
                        FirefoxDisabled(o1, 1);
                        FirefoxDisabled(o.find("th"),1);
                        
                    }
                }
            });
        }
        $(ObjName).show();
    }
}
//栏目字段显示
function CategoryViewField(obj, ViewObj, ClassName, ObjName, Num, ViewName, i, Sv) {
    if (obj) {
        if (Sv) {
            if (Sv == "1") {
                FirefoxDisabled($(obj).parent().parent().find("td"));
                $(ViewName + "_" + i).hide();
            }
        } else {
            var o1 = $(ClassName).find(":checkbox[checked='true']");
            if (o1.length == Num) {
                $(ViewObj).attr("checked", "checked");
                CategoryView(obj, ClassName, ObjName);
                FirefoxDisabled($(obj).parent().parent().find("td"));
                $(ViewName + "_" + i).hide();
            } else {
                if (obj.checked) {
                    FirefoxDisabled($(obj).parent().parent().find("td"));
                    $(ViewName + "_" + i).hide();
                } else {
                    FirefoxDisabled($(obj).parent().parent().find("td"), 1);
                    $(ViewName + "_" + i).show();
                }
            }
        }
    }
}
//
function CategoryViewFileName(obj, ObjName, i,defaultName) {
    var str = defaultName;
    if (typeof (obj) == "string") {
        if (obj.length > 0) {
            $(ObjName + "_" + i).find("th").html(obj + "：");
        }
    }else{
        if (obj.value.Trim().length > 0) {
            str = obj.value.Trim();
        }
        $(ObjName + "_" + i).find("th").html(str + "：");
    }
}


//审核等级机制--栏目  列表信息
function ArtiList_SystemAuditFun(IsAudit, value, id, row, idx, idName, Type, modelID) {
    var str = "";
    var val = value.split('+');
    var WorkFlowID = "";
    if (val.length == 2) {
        value = val[0];
        WorkFlowID = val[1];
    }
    if (IsAudit == 1) {
        if (WorkFlowID.length > 0 && WorkFlowID != "0") {
            str = ArtiList_SystemAuditFunView(IsAudit, Type, modelID, id, value, false);
        } else {
            str = "<a href=\"\" onclick=\"var Obj=this;AjaxFun('ArtiList/Lists_AuditWorkFlow.aspx', 'Type=" + Type + "&modelID=" + modelID + "&ID=" + id + "', SycmsLanguage.Category.ArtiOperate.l1, function (html) {if (html) {$(Obj).html(ShowTrueOrFalse(html, ''));}});return false;\" title=\"修改属性\">" + ShowTrueOrFalse(value, "") + "</a>";
        }
    } else {
        if (WorkFlowID.length > 0 && WorkFlowID != "0") {
            str = ArtiList_SystemAuditFunView(IsAudit, Type, modelID, id, value, true);
        } else {
            str = ShowTrueOrFalse(value);
        }
    }
    return str;
}
function ArtiList_SystemAuditFunView(IsAudit, Type, modelID, id, value, IsView) {
    var str = "";
    if (value == "1") {
        str = "<a href=\"\" onclick=\"SystemAuditCreateWin('ArtiList'," + IsAudit + ", " + Type + ",0," + modelID + "," + id + ");return false;\">" + ShowTrueOrFalse(value, "") + "</a>";
    } else {
        if (value == "0") {
            str = "<span class=\"audit_list\"><a href=\"\" onclick=\"SystemAuditCreateWin('ArtiList'," + IsAudit + ", " + Type + ",0," + modelID + "," + id + ");return false;\" class=\"" + (IsView ? "audit_view" : "audit_ok") + "\">&nbsp;</a></span>";
        } else {
            if (value.substr(0, 1) == "-") {
                str = "<span class=\"audit_list\"><a href=\"\" onclick=\"SystemAuditCreateWin('ArtiList'," + IsAudit + ", " + Type + ",0," + modelID + "," + id + ");return false;\" class=\"" + (IsView ? "audit_view view_no" : "audit_no") + "\">" + (value.Right(1) == "0" ? value.substr(value.length - 2, 1) : value.substr(0, 2).substr(1)) + "</a></span>";
            } else {
                str = "<span class=\"audit_list\"><a href=\"\" onclick=\"SystemAuditCreateWin('ArtiList'," + IsAudit + ", " + Type + ",0," + modelID + "," + id + ");return false;\" class=\"" + (IsView ? "audit_view view_ok" : "audit_ok") + "\">" + (value.Right(1) == "0" ? value.substr(value.length - 2, 1) : value.substr(0, 1)) + "</a></span>";
            }
        }
    }
    return str;
}


//审核等级机制--栏目列表
function SystemAuditFun(IsAudit, WorkFlowID, value, id, row, idx, idName, Type, ClassID)
{
    var str = "";
    if (IsAudit == 1) {
        if (WorkFlowID.length > 0 && WorkFlowID != "0") {
            str = SystemAuditFunView(IsAudit, Type, ClassID, id, WorkFlowID, value, false);
        } else {
            str = "<a href=\"\" onclick=\"ArtiOperate('wordtype=" + idName.name + "&Type=" + Type + "&id=" + id + "&classid=" + ClassID + "',this,1);return false;\" title=\"修改属性\">" + ShowTrueOrFalse(value, "") + "</a>";
        }
    } else {
        if (WorkFlowID.length > 0 && WorkFlowID != "0") {
            str = SystemAuditFunView(IsAudit, Type, ClassID, id, WorkFlowID, value, true);
        } else {
            str = ShowTrueOrFalse(value);
        }
    }
    return str;
}
function SystemAuditFunView(IsAudit, Type, ClassID, id, WorkFlowID, value, IsView)
{
    var str = "";
    if (value == "1") {
        str = "<a href=\"\" onclick=\"SystemAuditCreateWin('Arti'," + IsAudit + ", " + Type + "," + ClassID + ",0," + id + ");return false;\">" + ShowTrueOrFalse(value, "") + "</a>";
    } else {
        if (value == "0") {
            str = "<span class=\"audit_list\"><a href=\"\" onclick=\"SystemAuditCreateWin('Arti'," + IsAudit + ", " + Type + "," + ClassID + ",0," + id + ");return false;\" class=\"" + (IsView ? "audit_view" : "audit_ok") + "\">&nbsp;</a></span>";
        } else {
            if (value.substr(0, 1) == "-") {
                str = "<span class=\"audit_list\"><a href=\"\" onclick=\"SystemAuditCreateWin('Arti'," + IsAudit + ", " + Type + "," + ClassID + ",0," + id + ");return false;\" class=\"" + (IsView ? "audit_view view_no" : "audit_no") + "\">" + (value.Right(1) == "0" ? value.substr(value.length - 2, 1) : value.substr(0, 2).substr(1)) + "</a></span>";
            } else {
                str = "<span class=\"audit_list\"><a href=\"\" onclick=\"SystemAuditCreateWin('Arti'," + IsAudit + ", " + Type + "," + ClassID + ",0," + id + ");return false;\" class=\"" + (IsView ? "audit_view view_ok" : "audit_ok") + "\">" + (value.Right(1) == "0" ? value.substr(value.length - 2, 1) : value.substr(0, 1)) + "</a></span>";
            }
        }
    }
    return str;
}

function SystemAuditCreateWin(Path, IsAudit, Type, ClassID, modelID, ID)
{
    CreateWindow(Path + '/Lists_AuditWorkFlow.aspx?Type=' + Type + '&ClassID=' + ClassID + '&modelID=' + modelID + '&ID=' + ID, '审核工作流', Path + '/Lists_AuditWorkFlow.aspx?action=save&Type=' + Type + '&ClassID=' + ClassID + '&modelID=' + modelID + '&ID=' + ID, 400, 300, 'WorkFlowAudit', (IsAudit == 1 ? {
        Name: '驳回', Url: Path + '/Lists_AuditWorkFlow.aspx?action=save&ok=no&Type=' + Type + '&ClassID=' + ClassID + '&modelID=' + modelID + '&ID=' + ID
    } : null), null, null, null, function (dw) {
        var obj = $("#WorkFlowAudit");
        var Step = obj.find("#Step");
        var ObjAList = obj.find(".audit_list a");
        var obji = ObjAList.filter(".audit_no").length + ObjAList.filter(".view_no").length;
        ObjAList.bind("click", function () {
            var obja = $(this);
            if (obja.attr("user")=="1") {
                if (!obja.hasClass("select")) {
                    var ClassName = obja.attr("class");
                    if (obji > 0 && ClassName.indexOf("ok") != -1) {
                    } else {
                        ObjAList.removeClass("select");
                        obja.addClass("select");
                        Step.val(obja.html());
                        if (ClassName.indexOf("ok") != -1) {
                            dw.okButton.style.display = "none";
                        } else {
                            dw.okButton.style.display = "";
                        }
                        if (IsAudit == 1) {
                            if (ClassName.indexOf("no") != -1) {
                                dw.otherButton[0].style.display = "none";
                            } else {
                                dw.otherButton[0].style.display = "";
                            }
                        }
                    }
                }
            }
        });
        var objS = ObjAList.filter(".select").attr("class");
        if (objS) {
            if (objS.indexOf("no") != -1) {
                dw.okButton.style.display = "";
                if (IsAudit == 1) {
                    dw.otherButton[0].style.display = "none";
                }
            } else if (objS.indexOf("ok") != -1) {
                dw.okButton.style.display = "none";
                if (IsAudit == 1) {
                    dw.otherButton[0].style.display = "";
                }
            }
        }
        if (IsAudit == 1) {
            dw.okButton.value = "通过";
        } else {
            dw.okButton.style.display = "none";
            if (IsAudit == 1) {
                dw.otherButton[0].style.display = "none";
            }
        }
    });
}
//双击权限设置
function Cateondblclick(obj,inputName)
{
    var e = getEvent();
    if (e && e.which == 3) {
        var ObjInput = $("input[name='" + inputName + "']");
        if (ObjInput.length > 1) {
            var str = "设置所有的都为：";
            if (obj.checked) {
                str += "选中";
            } else {
                str += "非选中";
            }
            str += "。";
            Dialog.confirm(str, function () {
                if (obj.checked) {
                    ObjInput.attr("checked", "checked");
                } else {
                    ObjInput.removeAttr("checked");
                }
            }, null, 300, 60, "是", "否");
        }
    }
}