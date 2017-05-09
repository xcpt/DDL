function LogView(Id) {
    AjaxFun('Manager/Log/Lists_View.aspx', "id=" + Id, SycmsLanguage.OtherJs.LogView.l1, function (html) {
        TemEyediag = new Dialog();
        TemEyediag.Title = SycmsLanguage.OtherJs.LogView.l2;
        TemEyediag.URL = "about:blank";
        TemEyediag.Width = 800;
        TemEyediag.Drag = false;
        TemEyediag.Height = 500;
        TemEyediag.ShowButtonRow = true;
        TemEyediag.OKEvent = function ()
        {
            TemEyediag.innerFrame.contentWindow.print();
        }
        TemEyediag.show();
        TemEyediag.okButton.value = "打印";
        TemEyediag.cancelButton.value = "关闭";
        var doc = TemEyediag.innerFrame.contentWindow.document;
        doc.open();
        doc.write(html);
        doc.close();
    });
}
function Check_Menu3(classname) {
    if ($("." + classname + ":checked").length > 0) {
        if (!$("#" + classname).is(":checked")) {
            $("#" + classname).attr("checked", true);
        }
    }
}

//先定复选框 第一参数为当前选定  第二个复选框的样式
function Check_Menu(chk, classname, type) {
    var objval = false;
    if (type) {
        if (chk.innerHTML == "全选") {
            objval = true;
            chk.innerHTML = "不选";
        } else {
            chk.innerHTML = "全选";
        }
    } else {
        if (chk.checked) {
            objval = true;
        }
    }
    if (objval) {
        $("." + classname).attr("checked", true);
    }
    else {
        $("." + classname).attr("checked", false);
    }
}

//下面使用的是库关联相关

function MdbChange(obj) {
    var objv = $(obj).val();
    if (objv.length > 0) {
        AjaxFun("Tem/Mdb/Modi_LoadWord.aspx", "id=" + objv, " ", function(html) {
            $("#RelationWinDiv #Mdb_Word_id").empty().append(html);
        }, "#RelationWinDiv");
    } else {
        $("#RelationWinDiv #Mdb_Word_id").empty();
    }
}

//模型中的关联
function MdbAdd() {
    var WB = $("#RelationWinDiv");
    var W1 = $("#Word_Id");
    var W1v = W1.val();
    var W1vv = W1v.split("|||");
    var W1t = W1.find('option:selected').text();
    var W2 = WB.find("#Mdb_Word_id");
    var W2v = W2.val();
    var W2vv = W2v.split("|||");
    var W2t = W2.find('option:selected').text();
    var M1 = WB.find("#id");
    var M1v = M1.val();
    var M1t = M1.find('option:selected').text();
    var M2 = WB.find("#Mdb_Id");
    var M2v = M2.val();
    var M2t = M2.find('option:selected').text();

    var J2 = WB.find("#Mdb_Word_IsJoin");
    var J2v = J2.val();
    var J2t = J2.find('option:selected').text();
    if (M1v == M2v) {
        if (W1vv[0] == W2vv[0]) {
            Dialog.error(SycmsLanguage.OtherJs.MdbAdd.l1);
            return;
        }
    }
    if (W1vv[1] != W2vv[1]) {
        Dialog.error(SycmsLanguage.OtherJs.MdbAdd.l2);
        return;
    }
    var adddiv = $("#RelationWordList");
    if (adddiv.find("input[name=MdbID][value=" + M2v + "]").length > 0) {
        Dialog.error(SycmsLanguage.OtherJs.MdbAdd.l3);
        return;
    }
    if (adddiv.find("input[name=WordId][value=" + W1vv[0] + "]").length > 0 && adddiv.find("input[name=MdbID][value=" + M2v + "]").length > 0 && adddiv.find("input[name=RelationWordId][value=" + W2vv[0] + "]").length > 0) {
        Dialog.error(SycmsLanguage.OtherJs.MdbAdd.l4);
        return;
    }
    adddiv.append("<div style=\"border-bottom:1px solid #c0c0c0;text-align:left;height:25px;margin-bottom:5px;\"><div style=\"float:left\"><input type=\"button\" value=\"" + SycmsLanguage.OtherJs.MdbAdd.l5 + "\" onclick=\"$(this).parent().parent().remove();\" icon=\"icon-delete\"></div><div style=\"float:left;padding:3px;\">&nbsp;" + SycmsLanguage.OtherJs.MdbAdd.l6 + W1t + "<input type=\"hidden\" value=\"" + W1vv[0] + "\" Name=\"WordId\">&nbsp;&nbsp;" + SycmsLanguage.OtherJs.MdbAdd.l7 + M2t + "<input type=\"hidden\" value=\"" + M2v + "\" Name=\"MdbID\">&nbsp;&nbsp;" + SycmsLanguage.OtherJs.MdbAdd.l8 + W2t + "<input type=\"hidden\" value=\"" + W2vv[0] + "\" Name=\"RelationWordId\">&nbsp;&nbsp;" + SycmsLanguage.OtherJs.MdbAdd.l9 + J2t + "<input type=\"hidden\" value=\"" + J2v + "\" Name=\"RelationIsJoin\"></div></div>").btnForMat();
}
//菜单排序
function SaveCategoryOrder() {
    AjaxFun("Manager/MenuClass/Operate_Order.aspx", ReadInputValue("dnd-treeTable"), SycmsLanguage.OtherJs.SaveCategoryOrder.l1);
}
//保存个人密码
function SavePass() {
    AjaxForm("#UsersPassModi", "Manager/MyInfo/Modi_Pass.aspx?action=save", SycmsLanguage.OtherJs.SavePass.l1);
}
//保存网站信息
function SaveWebInfo() {
    AjaxForm("#WebInfo", "System/SiteInfo/Modi.aspx?action=save");
}

function ShowApp(obj, num) {
    if (obj == true) {
        if (num != "0") {
            document.getElementById("isCol").style.display = "block";
        }
        else {
            document.getElementById("isCol").style.display = "none";
        }
    }
}

function isShow(v, iCount) {
    for (var i = 0; i <= (iCount ? iCount : 8); i++) {
        document.getElementById("item" + i).style.display = "none";
        document.getElementById("itemLink" + i).className = "";
    }
    document.getElementById("item" + v).style.display = "";
    document.getElementById("itemLink" + v).className = "dq";
}



//栏目使用
//第一个为表格的ID或者是CLASS，第二个为标识的上面Id 值 自己的ID
function TreeGridModi(TableObjName, ParentIdName, ObjListValue, IdName) {
    var GridObj = $(TableObjName);
    var TrObj = GridObj.find(ParentIdName);
    if (GridObj.length > 0 && TrObj.length > 0) {
        if (ObjListValue) {
            var yId = GridObj.find(IdName);
            yclass = yId.attr("class");
            yId.remove();
            if (ParentIdName.indexOf("node-") != -1) {
                TrObj.after(ObjListValue); //在某某的后面   .expand()
            } else {
                TrObj.prepend(ObjListValue);            //在里面
            }
            TreeGridModiMove(GridObj,IdName.substr(1));
            GridObj.find(IdName).bind("mouseover", function () {
                if (!$(this).hasClass("selected")) {
                    $(this).addClass("selected");
                }
            }).bind("mouseout", function () {
                if ($(this).attr("select") != "1") {
                    $(this).removeClass("selected");
                }
            }).bind("click", function () {
                if ($(this).attr("select") != "1") {
                    $(this).parent().children().removeAttr("select").removeClass("selected");
                    $(this).attr("select", "1").addClass("selected");
                }
            });
            var objjg = GridObj.treeTable.defaults.childPrefix;
            if (yclass && yclass.indexOf(objjg) != -1) {
                $("#" + yclass.split(' ')[0].replace(objjg, "")).removeClass("initialized").removeClass("parent").expand();
            };
            var obj = GridObj.find(IdName).expand();
            if (yclass && yclass.indexOf("expanded") != -1) {
                obj.removeClass("collapsed").addClass("expanded");
            } else {
                obj.removeClass("expanded").toggleBranch();
            }
            GridObj.find(IdName).trigger("click");
        }
    }
}
//关联上面——修改移除
function TreeGridModiMove(GridObj, IdName) {
    var IdNameParent = GridObj.find("#" + IdName);
    var GridTr = GridObj.find("tbody tr.child-of-" + IdName);
    for (var i = GridTr.length - 1; i >= 0; i--) {
        IdNameParent.after(GridTr.eq(i));
        TreeGridModiMove(GridObj,GridTr.eq(i).attr("id"));
    }
}

//添加
//表格.#结构  第二个为添加的上面ID 添加的值，父级
function TreeGridAdd(TableObjName, ParentIdName, ObjListValue, Myid, Parentnode) {
    var GridObj = $(TableObjName);
    var TrObj = GridObj.find(ParentIdName);
    if (TrObj.length == 0) {
        Dialog.alert(SycmsLanguage.OtherJs.TreeGridAdd.l1);
    } else {
        TrObj = TreeGridAddTree(GridObj.find("tbody tr"), ParentIdName.substr(1), TrObj);
        if (ParentIdName.indexOf("node-") != -1) {
            TrObj.after(ObjListValue); //在某某的后面
        } else {
            TrObj.append(ObjListValue); //在某某的里面
        }
        $(Myid).bind("mouseover", function() {
            if (!$(this).hasClass("selected")) {
                $(this).addClass("selected");
            }
        }).bind("mouseout", function() {
            if ($(this).attr("select") != "1") {
                $(this).removeClass("selected");
            }
        }).bind("click", function () {
            if ($(this).attr("select") != "1") {
                $(this).parent().children().removeAttr("select").removeClass("selected");
                $(this).attr("select", "1").addClass("selected");
            }
        });
        if (Parentnode) {
            $(Parentnode).removeClass("initialized").removeClass("parent").addClass("parent").expand().removeClass("collapsed").addClass("expanded");
        }
        $(Myid).trigger("click");
    }
}
//关联上面——添加
function TreeGridAddTree(GridTr, IdName, TrObj) {
    for (var i = GridTr.length - 1; i >= 0; i--) {
        if (GridTr.eq(i).get(0).className.indexOf(IdName) != -1) {
            return TreeGridAddTree(GridTr, GridTr.eq(i).attr("id"), GridTr.eq(i));
            break;
        }
    }
    return TrObj;
}

//删除
function TreeGridDel(TableObjName, IdName) {
    var GridObj = $(TableObjName);
    var TrObj = GridObj.find(IdName);
    var ClassName = TrObj.attr("class");
    TrObj.remove();
    TreeGridDelAll(GridObj, IdName.substr(1));
    var objjg = GridObj.treeTable.defaults.childPrefix;
    if (ClassName.indexOf(objjg) != -1) {
        var obj = $("#" + ClassName.split(' ')[0].replace(objjg, ""));
        obj.find("td").eq(GridObj.treeTable.defaults.treeColumn).find("span").removeClass("expander");
        obj.removeClass("initialized").removeClass("parent").expand();
    }
}
//循环删除，上面函数用
function TreeGridDelAll(GridObj, IdName) {
    var ObjList = GridObj.find("tr.child-of-" + IdName);
    for (var j = 0; j < ObjList.length; j++) {
        TreeGridDelAll(GridObj, ObjList.eq(j).attr("id"));
    }
    ObjList.remove();
}

//索引用
function SelectFieldSort(objId, obj, I) {
    if (obj.checked) {
        FirefoxDisabled("View" + I + "_" + objId);
    } else {
        FirefoxDisabled("View" + I + "_" + objId, 1);
    }
}

function SelectEDSort1(objid, Value) {
    if (("," + Value).indexOf("," + objid + " ") != -1) {
        $("#Field1_" + objid).attr("checked", true);
        SelectFieldSort(objid, $("#Field1_" + objid).get(0), 2);
    }
}
function SelectEDSort2(objid, Value) {
    if (("," + Value + ",").indexOf("," + objid + ",") != -1) {
        $("#Field2_" + objid).attr("checked", true);
        SelectFieldSort(objid, $("#Field2_" + objid).get(0), 1);
    }
}


//导入导出模板

function TemExportFile(id) {
    Dialog.confirm(SycmsLanguage.OtherJs.TemExportFile.l1, function () { $("#DownFileWin").attr("src","Tem/Class/Operate_Down.aspx?id=" + id); }, null, null, null, SycmsLanguage.OtherJs.TemExportFile.l2, null, SycmsLanguage.OtherJs.TemExportFile.l3, function (diag) {
        AjaxFun("Tem/Class/Operate_Export.aspx?action=create&id=" + id, "", SycmsLanguage.OtherJs.TemExportFile.l4);
        diag.close();
    });
}
//WebIIS
function IISSiteIf(id) {
    Dialog.confirm(SycmsLanguage.OtherJs.IISSiteIf.l1, function (diag) { AjaxFun("WebIIS/Operate_Detection.aspx?action=create&id=" + id, "", SycmsLanguage.OtherJs.IISSiteIf.l2); diag.close(); }, null, null, null, SycmsLanguage.OtherJs.IISSiteIf.l3);
}



//地图API接口函数
function MapsFunctionSrc(Type, diag, str) {
    var url = "";
    if (Type == "0") {
        url = "js/Map/GIndex.Html#" + encodeURIComponent(str);
    } else {
        url = "js/Map/BIndex.Html#" + encodeURIComponent(str);
    }
    if (diag) {
        var obj = diag.innerFrame;
        if (obj) {
            obj.src = url;
        } else {
            Dialog.error("加载完成之后再选择......");
        }
    } else {
        return url;
    }
}

function MapsFunction(str, objname,ShowPic,ShowIframe) {
    var diag = new Dialog();
    diag.Width = 720;
    diag.Height = 520;
    diag.Title = SycmsLanguage.OtherJs.MapsFunction.l1;
    diag.Message = "<div id=\"MapGoogleBaidy\">地址：<input type=\"text\" id=\"address\" value=\"\" /><button id=\"mapsearch\">搜索</button>&nbsp;&nbsp;宽：<input type=\"text\" id=\"addressWidth\" style=\"width:25px;\" value=\"700\" />&nbsp;高：<input type=\"text\" style=\"width:25px;\" id=\"addressHeight\" value=\"500\" />&nbsp;&nbsp;<input type=\"radio\" value=\"0\" name=\"maptype\" id=\"maptype_0\"" + (str.indexOf("maptype=sycms") == -1 ? " checked=\"checked\"" : "") + " style=\"border:0px;\" /><label for=\"maptype_0\">google地图</label>&nbsp;<input type=\"radio\" value=\"1\" name=\"maptype\" style=\"border:0px;\"" + (str.indexOf("maptype=sycms") != -1 ? " checked=\"checked\"" : "") + " id=\"maptype_1\" /><label for=\"maptype_1\">百度地图</label></div>";
    diag.URL = MapsFunctionSrc(str.indexOf("maptype=sycms") != -1 ? "1" : "0", null, str);
    diag.OKEvent = function () {
        var obj = diag.innerFrame;
        if (obj) {
            var objvalue = obj.contentWindow.doOk();
            $(objname).val(objvalue.markers);
            $(objname + "_ViewSpan").html("地图坐标");
        }
        diag.close();
    }
    diag.show();
    var diagMap = $("#MapGoogleBaidy");
    diagMap.find("input[name='maptype']").bind("click", function () {
        MapsFunctionSrc(this.value, diag, str);
    });
    diagMap.find("#mapsearch").bind("click", function () {
        var obj = diag.innerFrame;
        if (obj) {
            obj.contentWindow.doSearch(diagMap.find("#address").val());
        } else {
            Dialog.error("加载完成之后再选择......");
        }
    })
    if (!ShowPic || ShowPic == "1") {
        diag.addButton("mapnext", SycmsLanguage.OtherJs.MapsFunction.l2, function () {
            var obj = diag.innerFrame;
            if (obj) {
                var objvalue = obj.contentWindow.doOk();
                var mapHeight = diagMap.find("#addressHeight").val();
                var mapWidth = diagMap.find("#addressWidth").val();
                if (diagMap.find("#maptype_0").attr("checked") == "checked") {
                    $(objname).val("http://maps.google.com/maps/api/staticmap?center=" + objvalue.center + "&markers=" + objvalue.markers + "&zoom=" + objvalue.zoom + "&size=" + mapWidth + 'x' + mapHeight + "&maptype=" + objvalue.maptype + "&sensor=false");
                } else {
                    $(objname).val("http://api.map.baidu.com/staticimage?center=" + objvalue.center + "&markers=" + objvalue.markers + "&width=" + mapWidth + "&height=" + mapHeight + "&zoom=" + objvalue.zoom + "&maptype=sycms");
                }
                $(objname + "_ViewSpan").html("地图图片");
            }
            diag.close();
        });
    }
    diag.okButton.style.display = "";
    diag.cancelButton.style.display = "";
    diag.okButton.value = SycmsLanguage.OtherJs.MapsFunction.l3;
    if (!ShowIframe || ShowIframe == "1") {
        diag.addButton("next", SycmsLanguage.OtherJs.MapsFunction.l4, function () {
            var obj = diag.innerFrame;
            if (obj) {
                var objvalue = obj.contentWindow.doOk();
                var mapHeight = diagMap.find("#addressHeight").val();
                var mapWidth = diagMap.find("#addressWidth").val();
                if (diagMap.find("#maptype_0").attr("checked") == "checked") {
                    $(objname).val("<iframe src='http://maps.google.com/maps?zoom=" + objvalue.zoom + "&saddr=" + objvalue.markers + "&amp;ie=UTF8&amp;source=embed&amp;ll=" + objvalue.center + "&amp;z=" + objvalue.zoom + "&amp;output=embed' frameborder='0' height='" + mapHeight + "' scrolling='no' width='" + mapWidth + "'></iframe><br /><small><a href='http://maps.google.com/maps?saddr=" + objvalue.markers + "&amp;ie=UTF8&amp;source=embed&amp;ll=" + objvalue.center + "&amp;z=" + objvalue.zoom + "'>查看大图</a></small>");
                } else {
                    $(objname).val("<iframe src='/Plus/BaiduMap/?zoom=" + objvalue.zoom + "&width=" + mapWidth + "&height=" + mapHeight + "&saddr=" + objvalue.markers + "&amp;ll=" + objvalue.center + "&amp;z=" + objvalue.zoom + "&amp;maptype=sycms' frameborder='0' height='" + mapHeight + "' scrolling='no' width='" + mapWidth + "'></iframe>");
                }
                $(objname + "_ViewSpan").html("框架地图");
            }
            diag.close();
        });
    }
}


function SearchEnter(SearchID, SearchView)
{
    $("#" + SearchView).find("input").unbind("keydown").keydown(function (event) {
        if (event.keyCode == 13) {
            $("#" + SearchID).trigger("click");
            return false;
        }
    });
}