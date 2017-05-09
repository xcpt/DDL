﻿/// <reference path="../intellisense/jquery-1.2.6-vsdoc-cn.js" />
/* --------------------------------------------------	
参数说明
option: {width:Number, items:Array, onShow:Function, rule:JSON}
成员语法(三种形式)	-- para.items
-> {text:String, icon:String, type:String, alias:String, width:Number, items:Array}		--	菜单组
-> {text:String, icon:String, type:String, alias:String, action:Function }				--	菜单项
-> {type:String}																		--	菜单分隔线
--------------------------------------------------*/
(function ($) {
    function returnfalse() { return false; };
    $.fn.contextmenu = function (option) {
        var objDiv = this.get(0);
        option = $.extend({ alias: "cmroot", width: 150, type: "contextmenu", left: 0, top: 0 }, option);
        var ruleName = null, target = null,
	    groups = {}, mitems = {}, actions = {}, showGroups = [],
        itemTpl = "<div class='b-m-$[type]' unselectable=on><nobr unselectable=on><img src='$[icon]' align='absmiddle'/><span unselectable=on>$[text]</span></nobr></div>";

        var gTemplet = $("<div/>").addClass("b-m-mpanel").attr("unselectable", "on").css("display", "none");
        var iTemplet = $("<div/>").addClass("b-m-item").attr("unselectable", "on");
        var sTemplet = $("<div/>").addClass("b-m-split");
        //创建菜单组
        var buildGroup = function (obj) {
            $("#" + obj.alias).remove();
            groups[obj.alias] = this;
            this.gidx = obj.alias;
            this.id = obj.alias;
            if (obj.disable) {
                this.disable = obj.disable;
                this.className = "b-m-idisable";
            }
            $(this).width(obj.width).click(returnfalse).mousedown(returnfalse).appendTo($("body"));
            obj = null;
            return this;
        };
        var buildItem = function (obj) {
            var T = this;
            T.title = obj.text.ClearHtml();
            T.idx = obj.alias;
            T.gidx = obj.gidx;
            T.data = obj;
            T.innerHTML = itemTpl.replace(/\$\[([^\]]+)\]/g, function () {
                return obj[arguments[1]];
            });

            if (obj.disable) {
                T.disable = obj.disable;
                T.className = "b-m-idisable";
            }
            obj.items && (T.group = true);
            obj.action && (actions[obj.alias] = obj.action);
            mitems[obj.alias] = T;
            T = obj = null;
            return this;
        };
        //添加菜单项
        var addItems = function (gidx, items) {
            var tmp = null;
            for (var i = 0; i < items.length; i++) {
                if (items[i]) {
                    if (items[i].type && items[i].type == "splitLine") {
                        //菜单分隔线
                        tmp = sTemplet.clone()[0];
                    } else {
                        items[i].gidx = gidx;
                        if (items[i].type == "group") {
                            //菜单组
                            buildGroup.apply(gTemplet.clone()[0], [items[i]]);
                            arguments.callee(items[i].alias, items[i].items);
                            items[i].type = "arrow";
                            tmp = buildItem.apply(iTemplet.clone()[0], [items[i]]);
                        } else {
                            //菜单项
                            items[i].type = "ibody";
                            tmp = buildItem.apply(iTemplet.clone()[0], [items[i]]);
                            $(tmp).click(function (e) {
                                if (!this.disable) {
                                    if ($.isFunction(actions[this.idx])) {
                                        actions[this.idx].call(this, target);
                                    }
                                    hideMenuPane();
                                }
                                return false;
                            });

                        } //Endif
                        $(tmp).bind("contextmenu", returnfalse).hover(overItem, outItem);
                    } //Endif
                    groups[gidx].appendChild(tmp);
                    tmp = items[i] = items[i].items = null;
                }
            } //Endfor
            gidx = items = null;
        };
        var overItem = function (e) {
            //如果菜单项不可用          
            if (this.disable)
                return false;
            hideMenuPane.call(groups[this.gidx]);
            //如果是菜单组
            if (this.group) {
                var pos = $(this).offset();
                var width = $(this).outerWidth();
                showMenuGroup.apply(groups[this.idx], [pos, width]);
            }
            this.className = "b-m-ifocus";
            return false;
        };
        //菜单项失去焦点
        var outItem = function (e) {
            //如果菜单项不可用
            if (this.disable)
                return false;
            if (!this.group) {
                //菜单项
                this.className = "b-m-item";
            } //Endif
            return false;
        };
        //在指定位置显示指定的菜单组
        var showMenuGroup = function (pos, width) {
            var bwidth = $("body").width();
            var bheight = document.documentElement.clientHeight;
            var mwidth = $(this).outerWidth();
            var mheight = $(this).outerHeight();
            pos.left = (pos.left + width + mwidth > bwidth) ? (pos.left - mwidth < 0 ? 0 : pos.left - mwidth) : pos.left + width;
            pos.top = (pos.top + mheight > bheight) ? (pos.top - mheight + (width > 0 ? 25 : 0) < 0 ? 0 : pos.top - mheight + (width > 0 ? 25 : 0)) : pos.top;
            $(this).css(pos).show();
            showGroups.push(this.gidx);
        };
        //隐藏菜单组
        var hideMenuPane = function () {
            var alias = null;
            for (var i = showGroups.length - 1; i >= 0; i--) {
                if (showGroups[i] == this.gidx)
                    break;
                alias = showGroups.pop();
                groups[alias].style.display = "none";
                mitems[alias] && (mitems[alias].className = "b-m-item");
            } //Endfor
            //CollectGarbage();
        };
        function applyRule(rule) {
            if (ruleName && ruleName == rule.name)
                return false;
            for (var i in mitems)
                disable(i, !rule.disable);
            for (var i = 0; i < rule.items.length; i++)
                disable(rule.items[i], rule.disable);
            ruleName = rule.name;
        };
        function disable(alias, disabled) {
            var item = mitems[alias];
            item.className = (item.disable = item.lastChild.disabled = disabled) ? "b-m-idisable" : "b-m-item";
        };

        /** 右键菜单显示 */
        function showMenu(e, menutarget) {
            target = menutarget;
            if (option.type == "contextmenu") {
                showMenuGroup.call(groups[option.alias], ((e.pageX || e.pageY) ? { left: e.pageX, top: e.pageY} : { left: parseInt(event.clientX) + parseInt(document.body.scrollLeft) - parseInt(document.body.clientLeft), top: parseInt(event.clientY) + parseInt(document.body.scrollTop) - parseInt(document.body.clientTop) }), 0);
            } else {
                objwz = getElCoordinate(objDiv);
                showMenuGroup.call(groups[option.alias], { left: objwz.left - option.left, top: objwz.bottom - option.top }, 0);
            }
            $(document).one('mousedown', hideMenuPane);
        }
        var $root = $("#" + option.alias);
        var root = null;
        if ($root.length == 0) {
            root = buildGroup.apply(gTemplet.clone()[0], [option]);
            root.applyrule = applyRule;
            root.showMenu = showMenu;
            addItems(option.alias, option.items);
        }
        else {
            root = $root[0];
        }
        var me = $(this).each(function () {
            return $(this).bind(option.type, function (e) {
                var bShowContext = (option.onContextMenu && $.isFunction(option.onContextMenu)) ? option.onContextMenu.call(this, e) : true;
                if (bShowContext) {
                    if (option.onShow && $.isFunction(option.onShow)) {
                        option.onShow.call(this, root);
                    }
                    root.showMenu(e, this);
                }
                return false;
            });
        });
        //设置显示规则
        if (option.rule) {
            applyRule(option.rule);
        }
        gTemplet = iTemplet = sTemplet = itemTpl = buildGroup = buildItem = null;
        addItems = overItem = outItem = null;
        //CollectGarbage();
        return me;
    }
})(jQuery);