$.fn.dragJQ = function (dragControl, documentBodyDiv, dragDivScroll, dragRecycleScroll) {
    var _drag = false, _x, _y, cw, ch, sw, sh;
    var DiagDivArray = $(this);
    DiagDivArray.unbind().bind("selectstart", function () { return false; });
    var DiagTable = DiagDivArray.find(".DiagTable");
    //把PX等里面数字转回去。
    var NumFun = function (NumStr) {
        javarun = NumStr.replace(/[^0-9]/ig, "");
        return parseInt(javarun);
    }
    var DiagBody = $(document.body);
    if (!documentBodyDiv) {
        documentBody = $(document);
    } else {
        documentBody = $(documentBodyDiv);
    }
    var ObjDiagTd = null;
    var ObjDiagTd_i = null;
    var AllTdCount = 5;
    var TdMinWidth = 120;
    DiagDivArray.find("#divDiagTable").remove();
    DiagDivArray.append("<div id=\"divDiagTable\" style=\"background-color:blue;\"></div>");
    var divDiagTable = $("#divDiagTable");
    ///回收站
    var DivDragRecycle_ID = "DivDragRecycle";
    var DivDragRecycle = DiagDivArray.find("#" + DivDragRecycle_ID);
    divDiagTable.css({ position: "fixed", "z-index": 100000000 });
    DiagDivArray.delegate(".DivDrag" + (dragControl ? " " + dragControl : " div>span.lock>img.open"), "click", function (e) {
        if (this.src.indexOf("false_") != -1) {
            this.src = this.src.replace("false_Lock", "true_Lock");
            $(this).parent().parent().parent().attr("lock", "1");
        } else {
            this.src = this.src.replace("true_Lock", "false_Lock");
            $(this).parent().parent().parent().attr("lock", "0");
        }
    });

    DiagDivArray.delegate(".DivDrag" + (dragControl ? " " + dragControl : " div>span.title"), "mousedown", function (e) {
        DiagTableFunction(e, $(this).parent().parent());
        DiagTableFun();
    });
    ///显示数值
    var DiagTableReSizeView = function (objTable) {
        var w = parseInt(objTable.width()) - (TdMinWidth - 1);
        var columns = objTable.find("tr:eq(0) td:not(:first,:last)");
        var icount = 100;
        var v = 0;
        for (var i = 1; i < columns.length; i++) {
            v = parseInt(((parseInt(columns.eq(i).width()) + 1) * 100) / w);
            icount -= v;
            columns.eq(i).html(v + "%");
        }
        columns.eq(0).html(icount + "%");
    }
    //开启表格改变大小
    var DiagTableReSize = function (objTable) {
        objTable.colResizable({
            liveDrag: true,
            minWidth: TdMinWidth,
            gripInnerHtml: "<div class='grip'></div>",
            draggingClass: "dragging",
            onResize: function (e) {
                DiagTableReSizeView($(e.currentTarget));
            }
        });
    }
    var DiagTableWZ = function (x, y, add) {
       //if (getBrowserOS() == "MSIE") {
            if (add) {
                if (documentBodyDiv) {
                    x += documentBody.get(0).scrollLeft;
                    y += documentBody.get(0).scrollTop;
                }
                if (dragDivScroll) {
                    x += $(dragDivScroll).get(0).scrollLeft;
                    y += $(dragDivScroll).get(0).scrollTop;
                }
                if (dragRecycleScroll) {
                    x += $(dragRecycleScroll).get(0).scrollLeft;
                    y += $(dragRecycleScroll).get(0).scrollTop;
                }
                if (document.documentElement && document.documentElement.scrollTop) {
                    x += document.documentElement.scrollLeft;
                    y += document.documentElement.scrollTop;
                } else if (document.body) {
                    x += document.body.scrollLeft;
                    y += document.body.scrollTop;
                }
            } else {
                if (documentBodyDiv) {
                    x -= documentBody.get(0).scrollLeft;
                    y -= documentBody.get(0).scrollTop;
                }
                if (dragDivScroll) {
                    x -= $(dragDivScroll).get(0).scrollLeft;
                    y -= $(dragDivScroll).get(0).scrollTop;
                }
                if (dragRecycleScroll) {
                    x -= $(dragRecycleScroll).get(0).scrollLeft;
                    y -= $(dragRecycleScroll).get(0).scrollTop;
                }
                if (document.documentElement && document.documentElement.scrollTop) {
                    x -= document.documentElement.scrollLeft;
                    y -= document.documentElement.scrollTop;
                } else if (document.body) {
                    x -= document.body.scrollLeft;
                    y -= document.body.scrollTop;
                }
            }
        //}
        return { x: parseInt(x), y: parseInt(y) };
    }

    var DiagTableFunction = function (e, dragDiv) {
        _drag = true;
        var wz = getElCoordinate(dragDiv.get(0));
        cw = $(window).width();
        ch = $(window).height();
        var Pleft = NumFun(dragDiv.css("padding-left"));
        var Pright = NumFun(dragDiv.css("padding-right"));
        var Ptop = NumFun(dragDiv.css("padding-top"));
        var Pbotom = NumFun(dragDiv.css("padding-bottom"));

        var Mleft = NumFun(dragDiv.css("margin-left"));
        var Mright = NumFun(dragDiv.css("margin-right"));
        var Mtop = NumFun(dragDiv.css("margin-top"));
        var Mbotom = NumFun(dragDiv.css("margin-bottom"));

        var boderwidth = 2;

        sw = parseInt(wz.width) - Pleft - Pright - boderwidth;
        sh = parseInt(wz.height) - Ptop - Pbotom - boderwidth;

        //_x = e.pageX - parseInt(wz.left) + Mleft;
        //_y = e.pageY - parseInt(wz.top) + Mtop;

        _x = parseInt(wz.width) / 2;
        _y = parseInt(wz.height) / 2;

        if (dragDiv.attr("copy") == "true" && dragDiv.parent().attr("id") == DivDragRecycle_ID) {
            var Copy = dragDiv.clone();
            dragDiv.after(Copy);
        }
        var wzxy = DiagTableWZ(wz.left - Mleft, wz.top - Mtop);

        dragDiv.css({ position: "fixed", "z-index": 100000001, width: sw, height: sh, left: wzxy.x, top: wzxy.y });

        window.getSelection ? window.getSelection().removeAllRanges() : document.selection.empty(); //禁止拖放对象文本被选择的方法
        document.body.setCapture && dragDiv[0].setCapture(); // IE下鼠标超出视口仍可被监听

        documentBody.unbind("mousemove").unbind("mouseup").mousemove(function (e) {
            if (_drag) {
                var x = e.pageX - _x;
                var y = e.pageY - _y;
                x = x < 0 ? x = 0 : x < (cw - sw) ? x : (cw - sw);
                y = y < 0 ? y = 0 : y < (ch - sh) ? y : (ch - sh);
                //var wz = DiagTableWZ(x, y);
                dragDiv.css({
                    top: y,
                    left: x
                });
                DiagTableMouseOver(e.pageX, e.pageY, dragDiv);
                window.getSelection ? window.getSelection().removeAllRanges() : document.selection.empty();
            }
        }).mouseup(function () {
            _drag = false;
            documentBody.unbind("mousemove").unbind("mouseup");
            if (dragDiv) {
                document.body.releaseCapture && dragDiv[0].releaseCapture();
                var dragDivTop = DiagTableWZ(0, parseInt(dragDiv.css("top").replace("px", "")), true).y;
                dragDiv.css({ position: "" });
                if (ObjDiagTd && ObjDiagTd.length > 0) {
                    var TrObj = ObjDiagTd.parent();
                    var ObjDiagTdClass = ObjDiagTd.attr("class");
                    var TrClass = TrObj.attr("class");
                    if ((TrClass || ObjDiagTdClass) && ObjDiagTd.attr("id") != DivDragRecycle_ID) {
                        var InTd = null;
                        if (TrClass == "top") {
                            InTd = DiagTableCreateTr(dragDiv, ObjDiagTd, TrObj, "top");
                        } else if (TrClass == "bottom") {
                            InTd = DiagTableCreateTr(dragDiv, ObjDiagTd, TrObj, "bottom");
                        } else if (ObjDiagTdClass == "left") {
                            InTd = DiagTableCreateTd(TrObj, ObjDiagTd, "left");
                        } else if (ObjDiagTdClass == "right") {
                            InTd = DiagTableCreateTd(TrObj, ObjDiagTd, "right");
                        }
                        if (InTd) {
                            InTd.append(dragDiv.removeAttr("style"));
                        }
                    } else {
                        if (ObjDiagTd_i) {
                            var ObjDiagTdPrev = ObjDiagTd.prev();
                            while (ObjDiagTdPrev.length > 0) {
                                var YColspan = ObjDiagTdPrev.attr("colspan");
                                if (!YColspan) {
                                    YColspan = "1";
                                }
                                ObjDiagTd_i -= parseInt(YColspan);
                                ObjDiagTdPrev = ObjDiagTdPrev.prev();
                            }
                            var YColspan = ObjDiagTd.attr("colspan");
                            if (!YColspan) {
                                YColspan = "1";
                            }
                            YColspan = parseInt(YColspan);
                            if (ObjDiagTd_i == 1) {
                                ObjDiagTd.removeAttr("colspan");
                            } else if (ObjDiagTd_i != 0) {
                                ObjDiagTd.attr("colspan", ObjDiagTd_i);
                            }
                            if (ObjDiagTd_i > 0) {
                                ObjDiagTd.after("<td" + ((YColspan - ObjDiagTd_i) > 1 ? " colspan=\"" + (YColspan - ObjDiagTd_i) + "\"" : "") + "></td>");
                                ObjDiagTd = ObjDiagTd.next();
                                ObjDiagTd.append(dragDiv.removeAttr("style"));
                            }
                        } else {
                            var DivObj = null;
                            var isbottom = 0;
                            if (ObjDiagTd.attr("id") != DivDragRecycle_ID) {
                                var field = dragDiv.attr("field");
                                var DivList = ObjDiagTd.find(">div[field!='" + field + "']");
                                var Height = 0;
                                var iCount = DivList.length;
                                for (var i1 = 0; i1 < iCount; i1++) {
                                    var wz = getElCoordinate(DivList.eq(i1).get(0));
                                    if (wz.top - Height >= dragDivTop) {
                                        DivObj = DivList.eq(i1);
                                        break;
                                    }
                                    if ((i1 + 1) == iCount && dragDivTop > wz.top + wz.height / 3) {
                                        isbottom = 1;
                                        break;
                                    }
                                }
                            }
                            if (isbottom == 1) {
                                InTd = DiagTableCreateTr(null, ObjDiagTd, TrObj, "top");
                                InTd.append(dragDiv.removeAttr("style"));
                            } else {
                                if (DivObj) {
                                    DivObj.before(dragDiv.removeAttr("style"));
                                } else {
                                    ObjDiagTd.append(dragDiv.removeAttr("style"));
                                }
                            }
                        }
                    }
                    var issys = "0";
                    var issysopen = dragDiv.attr("issysopen");
                    if (issysopen == "1") {
                        issys = dragDiv.attr("issys");
                    }
                    if (ObjDiagTd.attr("id") == DivDragRecycle_ID) {
                        dragDiv.find("span.lock").hide();
                        if (dragDiv.attr("copy")) {
                            dragDiv.remove();
                        } else {
                            if (issys == "1") {
                                dragDiv.find("span").css({ "color": "red" });
                            }
                        }
                    } else {
                        dragDiv.find("span.lock").show();
                        if (issys == "1") {
                            dragDiv.find("span").css({ "color": "" });
                        }
                    }
                } else {
                    if (dragDiv.attr("copy") == "true") {
                        dragDiv.remove();
                    } else {
                        //移出不需要删除
                        //DivDragRecycle.append(dragDiv);
                    }
                }
                DiagTableFun();
                dragDiv = null;
                ObjDiagTd = null;
            }
            divDiagTable.hide();
        });
    }

    ///建立列
    var DiagTableCreateTd = function (TrObj, ObjDiagTd, action) {
        var TrList = TrObj.parent().find("tr");
        var TrTd = TrList.eq(0).find("td")
        var TrTdLength = TrTd.length;
        var TdObj = null;
        if (TrTdLength < (AllTdCount + 2)) {
            for (var i = 0; i < TrList.length; i++) {
                if (action == "left") {
                    TrList.eq(i).find("td").eq(0).after("<td></td>");
                } else if (action == "right") {
                    TrList.eq(i).find("td:last").eq(0).before("<td></td>");
                }
            }
            if (action == "left") {
                TdObj = TrObj.find("td").eq(1);
            } else if (action == "right") {
                TdObj = TrObj.find("td:last").prev();
            }
            TrTd.removeAttr("style");
            setTimeout(function () {
                var TrTdObj = TrList.eq(0).find("td:not(:first,:last)");
                var total = 100;
                var bfb = parseInt(100 / TrTdObj.length);
                TrTdObj.html(bfb + "%");
                TrTdObj.eq(0).html((total - bfb * (TrTdObj.length - 1)) + "%");
            }, 100);
        }
        return TdObj;
    }
    ///算前面还有几格
    var PrevTdCount = function (ObjDiagTd) {
        var TdCount = 0;
        var ObjDiagTdPrev = ObjDiagTd.prev();
        while (ObjDiagTdPrev.length > 0) {
            if (!ObjDiagTdPrev.attr("class")) {
                var YColspan = ObjDiagTdPrev.attr("colspan");
                if (!YColspan) {
                    YColspan = "1";
                }
                TdCount += parseInt(YColspan);
            }
            ObjDiagTdPrev = ObjDiagTdPrev.prev();
        }
        return TdCount;
    }
    ///建立行
    var DiagTableCreateTr = function (dragDiv, ObjDiagTd, TrObj, action) {
        if (action == "top") {
            if (dragDiv) {
                var TrObjNextDiv = TrObj.next().find("div");
                if (TrObjNextDiv.length == 1) {
                    if (TrObjNextDiv.eq(0).attr("field") == dragDiv.attr("field")) {
                        return null;
                    }
                }
            }
        } else {
            if (dragDiv) {
                var TrObjPrev = TrObj.prev().find("div");
                if (TrObjPrev.length == 1) {
                    if (TrObjPrev.eq(0).attr("field") == dragDiv.attr("field")) {
                        return null;
                    }
                }
            }
        }
        var TdList = parseInt(TrObj.parent().parent().attr("TdList"));
        var TdCount = PrevTdCount(ObjDiagTd);
        var str = "<tr><td class=\"left\">&nbsp;</td>";
        if (TdCount == 0) {
            str += "<td" + ((TdList - 2) > 1 ? " colspan=\"" + (TdList - 2) + "\"" : "") + "></td>";
        } else {
            str += "<td" + ((TdCount) > 1 ? " colspan=\"" + (TdCount) + "\"" : "") + "></td><td" + ((TdList - TdCount - 2) > 1 ? " colspan=\"" + (TdList - TdCount - 2) + "\"" : "") + "></td>";
        }
        str += "<td class=\"right\">&nbsp;</td></tr>";
        if (action == "top") {
            TrObj.after(str);
            return TrObj.next().find("td").eq((TdCount == 0 ? 1 : 2));
        } else {
            TrObj.before(str);
            return TrObj.prev().find("td").eq((TdCount == 0 ? 1 : 2));
        }
    }

    var DiagTableFun = function (ViewNum) {
        DiagTable = DiagDivArray.find(".DiagTable");
        DiagTable.each(function () {
            var TrList = $(this).find("tr");
            if (TrList.length > 2) {
                for (var i = 1; i < TrList.length - 1; i++) {
                    if (TrList.eq(i).find("div").length == 0) {
                        TrList.eq(i).remove();
                    } else {
                        var TdList = TrList.eq(i).find("td");
                        if (TdList.length > 3) {
                            var HbTd = null;
                            for (var j = 1; j < TdList.length - 1; j++) {
                                if (TdList.eq(j).find("div").length > 0) {
                                    HbTd = TdList.eq(j);
                                } else {
                                    if (HbTd) {
                                        TdList.eq(j).remove();
                                        var YColspan = TdList.eq(j).attr("colspan");
                                        if (!YColspan) {
                                            YColspan = "1";
                                        }
                                        YColspan = parseInt(YColspan);
                                        var Colspan = HbTd.attr("colspan");
                                        if (!Colspan) {
                                            Colspan = "1";
                                        }
                                        Colspan = parseInt(Colspan) + YColspan;
                                        HbTd.attr("colspan", Colspan);
                                    }
                                }
                            }
                        }
                    }
                }
                var TopTdList = TrList.eq(0).find("td");
                var BottomTdList = TrList.eq(TrList.length - 1).find("td");
                if (TopTdList.length > 3) {
                    var ReSize = false;
                    for (var i = 1; i < TopTdList.length - 1; i++) {
                        var Colspan = 150;
                        var ColspanObjTd = new Array();
                        for (var i1 = 1; i1 < TrList.length - 1; i1++) {
                            var ObjTdList = TrList.eq(i1).find("td");
                            var ObjTd = null;
                            var ObjTdNum = 0;
                            var NYColspan_T = 1;
                            for (var i2 = 1; i2 < ObjTdList.length - 1 && i2 <= i; i2++) {
                                var NYColspan = ObjTdList.eq(i2).attr("colspan");
                                if (!NYColspan) {
                                    NYColspan = "1";
                                }
                                NYColspan_T += parseInt(NYColspan);
                                if (NYColspan_T >= (i + 1)) {
                                    ObjTd = ObjTdList.eq(i2);
                                }
                            }
                            if (ObjTd) {
                                ColspanObjTd.push(ObjTd);
                                var YColspan = ObjTd.attr("colspan");
                                if (!YColspan) {
                                    YColspan = "1";
                                }
                                if (parseInt(YColspan) < Colspan) {
                                    Colspan = parseInt(YColspan);
                                }
                                if (parseInt(YColspan) <= 1) {
                                    break;
                                }
                            }
                        }
                        if (Colspan > 1 && Colspan != 150) {
                            Colspan--;
                            ReSize = true;
                            for (var i1 = 0; i1 < ColspanObjTd.length; i1++) {
                                var YColspan = ColspanObjTd[i1].attr("colspan");
                                if (!YColspan) {
                                    YColspan = "1";
                                }
                                var NColspan = parseInt(YColspan) - Colspan;
                                if (NColspan > 1) {
                                    ColspanObjTd[i1].attr("colspan", NColspan);
                                } else {
                                    ColspanObjTd[i1].removeAttr("colspan");
                                }
                            }
                            var w1 = 0;
                            var w2 = TopTdList.eq(i).width();
                            for (var i1 = i + 1; i1 < i + Colspan + 1; i1++) {
                                w1 += TopTdList.eq(i1).width();
                                TopTdList.eq(i1).remove();
                                BottomTdList.eq(i1).remove();
                            }
                            TopTdList.eq(i).width(w1 + w2);
                            TopTdList = TrList.eq(0).find("td");
                            BottomTdList = TrList.eq(TrList.length - 1).find("td");
                        }
                    }
                    if (ReSize) {
                        DiagTableReSizeView($(this));
                    }
                }
            }
            var wz = getElCoordinate(this);
            $(this).attr("pageleft", wz.left);
            $(this).attr("pagetop", wz.top);
            $(this).attr("pagebottom", wz.bottom);
            $(this).attr("pageright", wz.right);
            $(this).attr("pagewidth", wz.width);
            $(this).attr("pageheight", wz.height);
            $(this).attr("TrList", TrList.length);
            if (TrList.length > 0) {
                var TdList = 0;
                var TdListArr = TrList.eq(0).find("td");
                for (var i = 0; i < TdListArr.length; i++) {
                    var YColspan = TdListArr.eq(i).attr("colspan");
                    if (!YColspan) {
                        YColspan = "1";
                    }
                    TdList += parseInt(YColspan);
                }
                $(this).attr("TdList", TdList);
            }
            $(this).find("td").each(function () {
                var wz = getElCoordinate(this);
                var obj = $(this);
                obj.attr("pageleft", wz.left);
                obj.attr("pagetop", wz.top);
                obj.attr("pagebottom", wz.bottom);
                obj.attr("pageright", wz.right);
                obj.attr("pagewidth", wz.width);
                obj.attr("pageheight", wz.height);
            });
            if (ViewNum) {
                //原有宽度的定义
                var TDListObj = $(this).find("tr:first>td:not(:first,:last)");
                var zw = parseInt($(this).width()) - (TdMinWidth - 1);
                if (TDListObj.length > 1) {
                    var w = zw;
                    var w1 = 0;
                    var jf = true;
                    for (i = 1; i < TDListObj.length; i++) {
                        var obj = TDListObj.eq(i).attr("widthbfb");
                        if (obj) {
                            w1 = parseInt(zw * parseInt(obj) / 100);
                            TDListObj.eq(i).width(w1 + "px");
                            w -= w1;
                        } else {
                            jf = false;
                        }
                    }
                    if (jf && w > 0) {
                        TDListObj.eq(0).width(w);
                    }
                } else {
                    TDListObj.eq(0).width(zw);
                }
                ///第一次加载显示
                DiagTableReSizeView($(this));
            }
            DiagTableReSize($(this));
        });
        if (DivDragRecycle.length > 0) {
            var wz = getElCoordinate(DivDragRecycle.get(0));
            DivDragRecycle.attr("pageleft", wz.left);
            DivDragRecycle.attr("pagetop", wz.top);
            DivDragRecycle.attr("pagebottom", wz.bottom);
            DivDragRecycle.attr("pageright", wz.right);
            DivDragRecycle.attr("pagewidth", wz.width);
            if (wz.height < 30) {
                wz.height = 30;
            }
            DivDragRecycle.attr("pageheight", wz.height);
        }
    };
    DiagTableFun(1);

    var DiagTableMouseOver = function (x, y, dragDiv) {
        var Dwz = DiagTableWZ(x, y, true);
        x = Dwz.x;
        y = Dwz.y;
        ObjDiagTd = null;
        ObjDiagTd_i = null;
        DiagTable = DiagDivArray.find(".DiagTable");
        DiagTable.each(function (Index) {
            var ObjTable1 = $(this);
            var left = parseInt(ObjTable1.attr("pageleft"));
            var top = parseInt(ObjTable1.attr("pagetop"));
            var bottom = parseInt(ObjTable1.attr("pagebottom"));
            var right = parseInt(ObjTable1.attr("pageright"));
            if (x >= left && y >= top && x <= right && y <= bottom) {
                //明天修改一下。这个地上。tr之后是TD
                var DiagTable_TR = ObjTable1.find("tr");
                var DiagTable_TRCount = DiagTable_TR.length;
                for (var i0 = 0; i0 < DiagTable_TRCount; i0++) {
                    var DiagTable_TD = DiagTable_TR.eq(i0).find("td");
                    var DiagTable_TDCount = DiagTable_TD.length;
                    top = parseInt(DiagTable_TD.eq(0).attr("pagetop"));
                    bottom = parseInt(DiagTable_TD.eq(0).attr("pagebottom"));
                    if (y >= top && y <= bottom) {
                        var obj = null;
                        for (var i = 0; i < DiagTable_TDCount; i++) {
                            obj = DiagTable_TD.eq(i);
                            var DiagTable_TDClass = obj.attr("class");
                            var DiagTable_TRClass = obj.parent().attr("class");
                            if (DiagTable_TDClass && DiagTable_TRClass) {

                            } else {
                                left = parseInt(obj.attr("pageleft"));
                                bottom = parseInt(obj.attr("pagebottom"));
                                right = parseInt(obj.attr("pageright"));
                                width = parseInt(obj.attr("pagewidth"));
                                height = parseInt(obj.attr("pageheight"));
                                var colspan = obj.attr("colspan");
                                if (!colspan) {
                                    colspan = "1";
                                }
                                colspan = parseInt(colspan);
                                if (x >= left && y >= top && x <= right && y <= bottom) {
                                    ObjDiagTd = obj;
                                    if (colspan > 1 && !DiagTable_TRClass) {
                                        var TrList = ObjTable1.find("tr:first");
                                        var TdList = TrList.find("td");
                                        var TdListCount = TdList.length;
                                        var Break = false;
                                        for (var j = 1; j < TdListCount - 1; j++) {
                                            var obj1 = TdList.eq(j);
                                            var left1 = parseInt(obj1.attr("pageleft"));
                                            var width1 = parseInt(obj1.attr("pagewidth"));
                                            if (x >= left1 && y >= top && x <= left1 + width1 && y <= top + height) {
                                                if (j > 1) {
                                                    ObjDiagTd_i = j;
                                                    left = left1;
                                                    width = width1;
                                                    var TdCount = PrevTdCount(ObjDiagTd) + 1;
                                                    for (var j1 = j + 1; j1 < colspan + TdCount; j1++) {
                                                        width += parseInt(TdList.eq(j1).attr("pagewidth"));
                                                    }
                                                }
                                                Break = true;
                                                break;
                                            }
                                        }
                                        if (Break) {
                                            break;
                                        }
                                    } else {
                                        Break = true;
                                        break;
                                    }
                                }
                            }
                        }
                        if (Break) {
                            break;
                        }
                    }
                }
                if (ObjDiagTd && ObjDiagTd.length > 0) {
                    var DiagTable_TDClass = ObjDiagTd.attr("class");
                    if (!DiagTable_TDClass) {
                        var ObjDiagTdNext = ObjDiagTd.next();
                        while (ObjDiagTdNext.length > 0) {
                            DiagTable_TDClass = ObjDiagTdNext.attr("class");
                            if (!DiagTable_TDClass) {
                                var ObjDiagTdNextDiv = ObjDiagTdNext.find("div");
                                if (ObjDiagTdNextDiv.length == 0 || dragDiv.attr("field") == ObjDiagTdNextDiv.eq(0).attr("field")) {
                                    width += parseInt(ObjDiagTdNext.attr("pagewidth"));
                                }
                            }
                            ObjDiagTdNext = ObjDiagTdNext.next();
                        }
                    }
                    divDiagTable.show().css({ "background-color": "blue", position: "fixed", width: width, height: height });
                    if (ObjDiagTd.hasClass("right")) {
                        if (ObjTable1.find("tr:first>td").length >= (AllTdCount + 2)) {
                            divDiagTable.css({ "background-color": "red" });
                        }
                    }
                    var wz = DiagTableWZ(left, top);
                    divDiagTable.css({
                        top: wz.y + "px",
                        left: wz.x + "px"
                    });
                }
            }
        });
        if ((!ObjDiagTd || ObjDiagTd.length == 0) && DivDragRecycle.length > 0) {
            var left = parseInt(DivDragRecycle.attr("pageleft"));
            var top = parseInt(DivDragRecycle.attr("pagetop"));
            var bottom = parseInt(DivDragRecycle.attr("pagebottom"));
            var right = parseInt(DivDragRecycle.attr("pageright"));
            var width = parseInt(DivDragRecycle.attr("pagewidth"));
            var height = parseInt(DivDragRecycle.attr("pageheight"));
            var wz = DiagTableWZ(0, 0, true);
            if (x >= left + wz.x && y >= top + wz.y && x <= right + wz.x && y <= bottom + wz.y) {
                divDiagTable.show().css({ position: "fixed", width: width, height: height });
                ObjDiagTd = DivDragRecycle;
                divDiagTable.css({
                    top: top + "px",
                    left: left + "px"
                });
            } else {
                divDiagTable.hide()
            }
        }
    }
}


function diagTabModi(obj) {
    var $objp = $(obj).parent();
    var InputValue = $objp.find("span").html();
    var ObjName = "TabListLayout";
    Dialog.alert("名称：<input type=\"text\" id=\"" + ObjName + "_Title\" value=\"" + InputValue + "\" size=\"20\" />", function () {
        var objInput = $("#" + ObjName + "_Title").val().Trim();
        if (objInput) {
            var obja = $("#" + ObjName).find("a");
            obja.each(function () {
                if (this != $objp.get(0) && $(this).text() == objInput) {
                    Dialog.error("已经存在。");
                    objInput = "";
                }
            });
            if (objInput && objInput != InputValue) {
                $objp.find("span").html(objInput);
            }
        }
    }, 300, 50, "", "修改");
    return false;
}
//删除标签
function diagTabDel(obj) {
    var $objp = $(obj).parent();
    var ObjName = "TabListLayout";
    var objList = $("#" + ObjName);
    var obja = objList.find("a");
    var TableId = $("#" + $objp.attr("id").replace("itemLink_", "item_"));
    TableId.find("div.DivDrag").each(function () {
        var dragDiv = $(this);
        var ObjDiagTd = $("#DivDragRecycle");
        ObjDiagTd.append(dragDiv.removeAttr("style"));
        var issys = "0";
        var issysopen = dragDiv.attr("issysopen");
        if (issysopen == "1") {
            issys = dragDiv.attr("issys");
        }
        if (dragDiv.attr("copy")) {
            dragDiv.remove();
        } else {
            if (issys == "1") {
                dragDiv.find("span").css({ "color": "red" });
            }
        }
    });
    var bjdq = -1;
    if ($objp.hasClass("dq")) {
        bjdq = 0;
    } else {
        for (var i = 0; i < obja.length; i++) {
            if (obja.eq(i).hasClass("dq")) {
                bjdq = i;
                break;
            }
        }
    }
    if (bjdq != -1) {
        obja.eq(0).addClass("dq").find("span").trigger("click");
    }
    TableId.remove();
    $objp.remove();
    diagTabClickFunction();
    return false;
}
function diagTabClickFunction() {
    var ObjName = "TabListLayout";
    var obj = $("#" + ObjName);
    var obja = obj.find("a");
    obja.each(function (Index) {
        $(this).find("span").removeAttr("click").unbind().bind("click", function () {
            ShowArtiBar(Index, obja.length, '_Layout_');
            return false;
        });
    })
}

function diagTabCreate() {
    var ObjName = "TabListLayout";
    var obj = $("#" + ObjName);
    Dialog.alert("名称：<input type=\"text\" id=\"" + ObjName + "_Title\" size=\"20\" />", function () {
        var objInput = $("#" + ObjName + "_Title").val().Trim();
        if (objInput) {
            var obja = obj.find("a");
            obja.each(function () {
                if ($(this).text() == objInput) {
                    Dialog.error("已经存在，不要重复添加。");
                    objInput = "";
                }
            });
            if (objInput) {
                obj.append("<a href=\"\" onclick=\"return false;\" id=\"itemLink_Layout_" + obja.length + "\"><img src=\"images/tab/modi.png\" onclick=\"return diagTabModi(this);\" alt=\"修改\" valign=\"middle\" /><span>" + objInput + "</span><img src=\"images/tab/Del.png\" alt=\"删除\" onclick=\"return diagTabDel(this);\" valign=\"middle\" /></a>");
                var DiagDivArray = $("#DiagDivArray");
                var Table = DiagDivArray.find("div>table>tbody>tr");
                Table.append("<td valign=\"top\" align=\"left\" id=\"item_Layout_" + obja.length + "\" style=\"display:none;\"><table cellspacing=\"0\" cellpadding=\"0\" class=\"DiagTable\"><tbody><tr class=\"top\"><td class=\"left\"></td><td>100%</td><td class=\"right\"></td></tr><tr class=\"bottom\"><td class=\"left\"></td><td></td><td class=\"right\"></td></tr></tbody></table></td>");
                diagTabClickFunction();
            }
        }
    }, 300, 50, "", "新增");
}

function dragTableFunction(modelID, ClassID, Type, IsOperate, IsTrue, modelType) {
    if (ClassID) {//栏目的
        CreateWindow((Type == "0" ? "Category" : "Special") + '/Layout.aspx?modelID=' + modelID + "&ClassID=" + ClassID + "&Type=" + Type + "&IsOperate=" + IsOperate + "&" + ReadInputValue('#ModelLayout_' + modelID + '_' + ClassID), '布局设置', function (zWindow) {
            var cstring = dragJQCreateTable("#DiagDivArray");
            if (cstring.length > 0) {
                AjaxFun((Type == "0" ? "Category" : "Special") + '/Layout.aspx?action=create', cstring, '正在返回布局设置...', function (html) {
                    $("#ModelLayoutID_" + modelID + "_" + ClassID).val(html);
                    $('#LayoutDel').btn().enable();
                    zWindow.close();
                });
            }
        }, 920, '50', 'Field_Layout', null, null, null, null, function () {
            var DiagDivArray = $("#DiagDivArray");
            DiagDivArray.dragJQ(null, "#DiagDivArray");
            DiagDivArray.height((Wh - 133) + "px");
            DiagDivArray.find("#DivDragRecycle").height((Wh - 167) + "px");
        }, null, null, null, function (FormName) {
            var JLValue = dragJQCreateTable("#DiagDivArray");
            if (JLValue) {
                var ObjCheckList = $("#ModelLayout_" + modelID + "_" + ClassID).find(".FieldViewCategory");
                ObjCheckList.removeAttr("checked");
                var JLValue1 = getParameter("Recycle", JLValue);
                if (JLValue1) {
                    ObjCheckList.each(function () {
                        if (("," + JLValue1 + ",").indexOf("," + this.value + ",") != -1) {
                            this.checked = true;
                        }
                    });
                }
                return true;
            } else {
                return false;
            }
        }, null, "ModelLayoutCategory=" + encodeURIComponent($("#ModelLayoutID_" + modelID + "_" + ClassID).val()));
    } else {
    CreateWindow((modelType ? "System/UniversalFrom/Layout.aspx?modelID=" + modelID + "&Type=" + modelType : "Content/Model_Field/Layout.aspx?modelID=" + modelID), '布局设置', function (zWindow) {
        var cstring = dragJQCreateTable("#DiagDivArray");
        if (cstring.length > 0) {
            AjaxFun((modelType ? "System/UniversalFrom/Layout.aspx?action=save&modelID=" + modelID + "&Type=" + modelType : "Content/Model_Field/Layout.aspx?action=save&modelID=" + modelID), cstring, '正在保存布局信息....', function () {
                zWindow.close();
            });
        }
    }, 920, '50', 'Field_Layout', null, null, null, null, function () {
        var DiagDivArray = $("#DiagDivArray");
        DiagDivArray.dragJQ(null, "#DiagDivArray");
        DiagDivArray.height((Wh - 133) + "px");
        DiagDivArray.find("#DivDragRecycle").height((Wh - 167) + "px");
    });
    }
}

function dragJQCreateTableWidth(WidthArray, i1,i2) {
    var w = 0;
    for (var j = i1; j < i1+i2 && j < WidthArray.length; j++) {
        w += WidthArray[j];
    }
    if (w != 100 && w != 0) {
        return "Width:\"" + w + "\",";
    } else {
        return "";
    }
}
//读取生成
function dragJQCreateTable(DiagDivArrayString) {
    var DiagDivArray = $(DiagDivArrayString);
    var DiagTableList = DiagDivArray.find(".DiagTable");
    var ObjName = "TabListLayout";
    var obja = $("#" + ObjName).find("a");
    var DiagString = "Num=" + obja.length;
    obja.each(function (Index) {
        DiagString += "&Title_" + Index + "=" + encodeURIComponent($(this).text());
    });
    for (var i = 0; i < DiagTableList.length; i++) {
        var DiagTableTr = DiagTableList.eq(i).find("tr");
        if (DiagTableTr.length > 2) {
            var w = parseInt(DiagTableList.eq(i).width()) - 119;
            var columns = DiagTableTr.eq(0).find("td:not(:first,:last)");
            var icount = 100;
            var v = 0;
            var WidthArray = new Array();
            WidthArray.push(0);
            for (var j = 1; j < columns.length; j++) {
                var widthn = columns.eq(j).html().Trim().replace("%", "");
                if (widthn && widthn.isDigit()) {
                    v = parseInt(widthn);
                    icount -= v;
                    WidthArray.push(v);
                } else {
                    WidthArray.push(0);
                }
            }
            WidthArray[0] = icount;
            DiagString += "&DiagTable_" + i + "_Width=" + WidthArray.join(",");
            DiagString += "&DiagTable_" + i + "=";
            if (DiagTableTr.length > 2) {
                DiagString += "[";

                //修改给所有的加上这个宽度。
                for (var j = 1; j < DiagTableTr.length - 1; j++) {
                    DiagString += "{\"Tr\":[";
                    var DiagTableTd = DiagTableTr.eq(j).find("td");
                    for (var j1 = 1; j1 < DiagTableTd.length - 1; j1++) {
                        var YColspan = DiagTableTd.eq(j1).attr("colspan");
                        if (!YColspan) {
                            YColspan = "1";
                        }
                        YColspan = parseInt(YColspan);
                        DiagString += "{\"Colspan\":\"" + YColspan + "\"," + dragJQCreateTableWidth(WidthArray, j1 - 1, parseInt(YColspan)) + "\"Content\":\"";
                        var DiagTableTdDiv = DiagTableTd.eq(j1).children("div");
                        for (var j2 = 0; j2 < DiagTableTdDiv.length; j2++) {
                            var DiagTableTdDivField = DiagTableTdDiv.eq(j2).attr("field");
                            var DiagTableTdDivFieldLock = DiagTableTdDiv.eq(j2).attr("lock");
                            if (!DiagTableTdDivFieldLock) {
                                DiagTableTdDivFieldLock = "0";
                            }
                            if (DiagTableTdDivField) {
                                DiagString += DiagTableTdDivField + "|" + DiagTableTdDivFieldLock;
                            } else {
                                DiagString += encodeURIComponent(DiagTableTdDiv.find("span").html()) + "|" + DiagTableTdDivFieldLock;
                            }
                            if ((j2 + 1) != DiagTableTdDiv.length) {
                                DiagString += ",";
                            }
                        }
                        DiagString += "\"}";
                        if ((j1 + 1) != (DiagTableTd.length - 1)) {
                            DiagString += ",";
                        }
                    }
                    DiagString += "]}";
                    if ((j + 1) != (DiagTableTr.length - 1)) {
                        DiagString += ",";
                    }
                }
                DiagString += "]";
            }
        }
    }
    var ListErrorDiv = "";
    var i1 = 1;
    var DivDragRecycle = DiagDivArray.find("#DivDragRecycle");
    if (DivDragRecycle.length > 0) {
        var DivDragRecycleDiv = DivDragRecycle.find(".DivDrag[field]");
        if (DivDragRecycleDiv.length > 0) {
            DiagString += "&Recycle=";
            for (var i = 0; i < DivDragRecycleDiv.length; i++) {
                DivDragRecycleDivField = DivDragRecycleDiv.eq(i).attr("field");
                DiagString += DivDragRecycleDivField;
                if ((i + 1) != DivDragRecycleDiv.length) {
                    DiagString += ",";
                }
                var issys = "0";
                var issysopen = DivDragRecycleDiv.eq(i).attr("issysopen");
                if (issysopen == "1") {
                    issys = DivDragRecycleDiv.eq(i).attr("issys");
                }
                if (issys == "1") {
                    ListErrorDiv += i1 + "：" + DivDragRecycleDiv.eq(i).find("span").html() + "；<br>";
                    i1++;
                }
            }
        }
    }
    if (ListErrorDiv.length > 0) {
        Dialog.error("下列字段必须被使用：<br>" + ListErrorDiv, null, 300, (ListErrorDiv.split("<br>").length + 1) * 18);
        DiagString = "";
    }
    return DiagString;
}
