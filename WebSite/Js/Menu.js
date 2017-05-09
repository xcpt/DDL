var Menu_cleartime = null;
var menuAdmin = {/* 菜单管理器 */
    list: Array(),
    add: function (owner, menu, top, left) {
        owner = typeof owner == 'string' ? document.getElementById(owner) : owner;
        if (this.obj) {         //真的时候
            var $Menu = this;
            var obj = document.getElementById($Menu.obj);
            top = top || 0;
            left = left || 0;
            owner.onmouseover = function (x) {
                if (Menu_cleartime) {
                    clearTimeout(Menu_cleartime);
                }
                for (var i = 0, e = window.event || x, src = e.srcElement || e.target; i < $Menu.list.length; i++) {
                    var J = $Menu.list[i];
                    J.menu.hide(); /* hide other menu */
                    if (src == J.owner) {
                        objwz = getElCoordinate(this); J.menu.popUp(objwz.left - left, objwz.bottom - top);
                        break;
                    };
                }
                stopBubble(x);
            };
            obj.onmouseover = function (x) {
                if (Menu_cleartime) {
                    clearTimeout(Menu_cleartime);
                }
            }
            obj.onmouseout = owner.onmouseout = function (x) {
                if (Menu_cleartime) {
                    clearTimeout(Menu_cleartime);
                }
                e = window.event | x | getEvent();
                Menu_cleartime = setTimeout(function () {
                    for (var i = 0, src = e.srcElement || e.target; i < $Menu.list.length; i++) {
                        var J = $Menu.list[i];
                        J.menu.hide(); /* hide other menu */
                    }
                }, 700);
            };
        }
        return this.list.push({ 'owner': owner, 'menu': menu }), this;
    },
    init: function (obj) {
        var $Menu = this, d = document;
        $Menu.obj = obj;
        if (window.ActiveXObject) { d.execCommand("BackgroundImageCache", false, true); };
        if (!obj) {
            d.oncontextmenu = function (x) {
                for (var i = 0, e = window.event || x, src = e.srcElement || e.target; i < $Menu.list.length; i++) {
                    var J = $Menu.list[i];
                    J.menu.hide(); /* hide other menu */
                    if (src == J.owner) { J.menu.popUp(e.clientX, e.clientY); };
                }
                return false;
            };
        }
        d.onclick = function () { for (var i = 0; i < $Menu.list.length; i++) { $Menu.list[i].menu.hide(); } }; /* hide other menu */
        return $Menu;
    },
    del: function (id) {
        var obj = document.getElementById(id);
        if (obj) obj.parentNode.removeChild(obj);
    }
};
var popUpMenu = function (data, parent, root, id) {/* 弹出菜单类 */
    if (!root) root = this; /* save top menu's hander */
    var ul = this.MUI('UL', null, 'popUpMenu', null, null, id), $Menu = this, oldEvent = function () { };
    $Menu.UI = ul;
    for (var i = 0; i < data.length; i++) {/* insert all items */
        var v = data[i], li = this.MUI('LI', ul, v.disabled ? 'disabled' : false);
        li.onmouseover = function () {/* hide all sibling's subMenu */
            var lis = this.parentNode.getElementsByTagName('LI');
            for (var i = 0; i < lis.length; i++) {
                var J = lis[i];
                if (J != this) {/* clear hasSub item bg */
                    J.className == 'open' && (J.className = '');
                    J.subMenu && (J.subMenu.hide());
                }
            };
        };
        if (v.radio != undefined) {/* if item like radio */
            li.setAttribute('radio', v.radio);
            if (v.selected == true && !this.hasOnlyRadio) {/* only first radio selected */
                v.ico = this.radioIco;
                this.hasOnlyRadio = true;
            }
        }
        if (v.selected != undefined && v.radio == undefined) {/* if item like checkbox */
            li.setAttribute('selected', v.selected);
            if (v.selected) v.ico = $Menu.selectIco;
        };
        if (v.line) { li.className = 'splitLine'; }
        else {
            if (v.disabled) {
                this.MUI('SPAN', li, (v.sub ? 'toSub' : false), v.text, v.ico);
            } else {
                this.MUI('SPAN', this.MUI('A', li, (v.sub ? 'toSub' : false)), false, v.text, v.ico);
            }
        };
        if (!v.sub) {
            if (typeof v.cmd != 'function') {
                v.cmd = this.cmd;
            };
            if (!v.disabled) {
                if (v.radio) {/* is radio group */
                    li.onclick = (function (v) {
                        return function () {
                            root.hide();
                            var allLi = this.parentNode.getElementsByTagName("LI"), rdo = this.getAttribute('radio');
                            for (var i = 0; i < allLi.length; i++) {/* each group */
                                var J = allLi[i];
                                if (rdo != J.getAttribute('radio')) continue;
                                var J2 = J.getElementsByTagName("SPAN");
                                if (J2 != null) {
                                    J2[0].style.backgroundImage = (J == this) ?
										'url(' + $Menu.radioIco + ')' : '';
                                };
                            }
                            v.cmd(rdo, this, $Menu.owner); /* input group name and li */
                            return false;
                        };
                    })(v);
                } else {/* is checkbox or normal */
                    li.onclick = (function (v) {
                        return function () {
                            root.hide();
                            var J = null; /* normal */
                            if (this.getAttribute('selected') != undefined) {/* if item can select */
                                J = (String(this.getAttribute('selected')) == "true");
                                this.setAttribute('selected', !J);
                                this.getElementsByTagName("SPAN")[0].style.backgroundImage = !J ?
									'url(' + $Menu.selectIco + ')' : '';
                            }
                            v.cmd(J, this, $Menu.owner); /* input selected and li */
                            return false;
                        };
                    })(v);
                }
            }
        } else {
            li.onclick = function (e) {/* cancel bubble */
                stopBubble(e);
            };
            new popUpMenu(v.sub, li, root); /* insert sub menu */
        };
    };
    if (parent) {/* set parent event */
        if (typeof parent.onmouseover == 'function') { oldEvent = parent.onmouseover; };
        parent.onmouseover = function (e) {
            oldEvent.call(this);
            this.className = 'open';
            var pos = $Menu.absPos(this), x = (pos.x + this.offsetWidth - 2), y = pos.y + 5;
            $Menu.show(x, y, this);
        };
        parent.onmouseout = function () { this.hideTimer = setTimeout(function () { $Menu.hide(); }, 20); };
        /* sub over event */
        parent.getElementsByTagName("SPAN")[0].onmouseover =
		this.UI.onmouseover = function () { clearTimeout(parent.hideTimer); };
        parent.subMenu = this; /* bind sub */
    }
};
popUpMenu.prototype = {/* 弹出菜单类扩展 */
    absPos: function (J) {
        var x = y = 0;
        do { x += J.offsetLeft; y += J.offsetTop; }
        while (J = J.offsetParent);
        return { 'x': x, 'y': y };
    }
	, popUp: function (x, y) { this.show(x, y); }
	, MUI: function (type, parent, css, text, ico, id) {
	    var d = document, ui = (parent || d.body).appendChild(d.createElement(type));
	    if (css) ui.className = css;
	    if (id) ui.id = id;
	    if (text) ui.innerHTML = text;
	    if (type.toUpperCase() == 'A') {
	        ui.setAttribute('href', 'javascript:void(0)');
	        ui.onclick = function () {
	            return false;
	        }
	    }
	    if (ico) ui.style.backgroundImage = 'url(' + ico + ')';
	    return ui;
	}
	, show: function (x, y, parent) {
	    var $UI = $(this.UI);
	    if (this.UI.id) {
	        $UI.show();
	    }
	    this.hide(); /* on reClick neet hide all sub */
	    var w = this.UI.offsetWidth, h = this.UI.offsetHeight, db = document.body
			, dw = db.clientWidth, dh = db.clientHeight;
	    if (h == 0)
	    {
	        var liList = $UI.find(">li");
	        var liCount = liList.length;
	        var splitCount = liList.filter(".splitLine").length;
	        h = (liCount - splitCount) * 26 + splitCount * 5;
	    }
	    if (h + y > dh) {/* y overflow */
	        if (parent) { y += parent.offsetHeight; };y -= (h + y - dh);
	    } else { if (parent) { y -= 10; x -= 10; } };
	    if (w + x > dw) {/* x overflow */
	        x -= w; if (parent) { x -= parent.offsetWidth - 10; };
	    } else { if (parent) { x += 5; }; }
	    var J = this.UI.style;
	    J.display == 'none' && (J.display = 'block'); J.top = y + 'px'; J.left = x + 'px';
	}
	, hide: function () {
	    var J = this.UI.style, items = this.UI.getElementsByTagName('LI');
	    J.display != 'none' && (J.display = 'none');
	    for (var i = 0; i < items.length; i++) {/* clear hasSub item bg */
	        var J = items[i];
	        J.className == 'open' && (J.className = '');
	        J.subMenu && J.subMenu.hide();
	    };
	}
	, cmd: function () {/* default eventHander */

	}
	, radioIco: 'images/icon/yes.png'
	, selectIco: 'images/icon/true.png'
};