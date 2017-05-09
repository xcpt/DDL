Array.prototype.MSremove = function (item) {
    var a = -1;
    if (this && this.length > 0) {
        try {
            a = this.indexOf(item);
        } catch (e) {
            for (var i = 0; i < this.length; i++) {
                if (this[i] == item) {
                    a = i;
                    break;
                }
            }
        }
        if (a >= 0) {
            this.splice(a, 1);
            return true;
        }
    }
    return false;
}

function clearEventBubble(evt) {
    evt = evt || window.event;
    if (evt.stopPropagation) evt.stopPropagation(); else evt.cancelBubble = true;
    if (evt.preventDefault) evt.preventDefault(); else evt.returnValue = false;
}

function posXY(event, _self) {
    event = event || window.event;
    var posX = event.pageX || (event.clientX);
    var posY = event.pageY || (event.clientY);
    return { x: posX, y: posY };
}

function RegionSelect(selRegionProp) {
    this._selectedRegions = [];
    this.regions = $(selRegionProp["region"]);
    var _self = this;
    this.regions.bind("mousedown", function (evt) {
        if ((!evt.shiftKey && !evt.ctrlKey) || _self.selRegionProp.isNum == 1) {
            // 清空所有select样式
            _self.regions.removeClass(_self.selectedClass);
            $(this).addClass(_self.selectedClass);
            // 清空selected数组，并加入当前select中的元素
            _self._selectedRegions = [];
            _self._selectedRegions.push(this);
        } else {
            if (!$(this).hasClass(_self.selectedClass)) {
                $(this).addClass(_self.selectedClass);
                _self._selectedRegions.push(this);
            } else {
                $(this).removeClass(_self.selectedClass);
                _self._selectedRegions.MSremove(this);
            }
        }
        if (_self.selRegionProp.returnFunction) {
            _self.selRegionProp.returnFunction(_self._selectedRegions);
        }
        clearEventBubble(evt);
    })

    this.selectedClass = selRegionProp["selectedClass"];
    this.selRegionProp = selRegionProp;
    this.selectedRegion = [];
    this.selectDiv = null;
    this.startX = null;
    this.startY = null;
    this.parentObj = selRegionProp["parentObj"];
    this.scrollObj = selRegionProp["scrollObj"];
}

RegionSelect.prototype.select = function () {
    var _self = this;
    if (_self.selRegionProp.isNum != 1) {
        var objID = _self.parentObj ? $(_self.parentObj) : $(document);
        objID.unbind().bind("mousedown", function (evt) {
            _self.onEnd();
            var evt = window.event || arguments[0];
            _self.onBeforeSelect(evt);
            _self.regions.removeClass(_self.selectedClass);
        }).bind("mousemove", function () {
            var evt = window.event || arguments[0];
            _self.onSelect(evt);
        });
        $(document).unbind().bind("selectstart", function () {
            return false;
        }).bind("mouseup", function () {
            try {
                _self.onEnd();
            } catch (e) { }
        });
    }
}

RegionSelect.prototype.onBeforeSelect = function (evt) {
    if (!document.getElementById("selContainer")) {
        this.selectDiv = document.createElement("div");
        this.selectDiv.style.cssText = "position:absolute;width:0px;height:0px;font-size:0px;margin:0px;padding:0px;border:1px dashed #0099FF;background-color:#C3D5ED;z-index:1000;filter:alpha(opacity:60);opacity:0.6;display:none;";
        this.selectDiv.id = "selContainer";
        document.body.appendChild(this.selectDiv);
    } else {
        this.selectDiv = document.getElementById("selContainer");
    }
    $(this.selectDiv).css({ "width": "0px", "height": "0px" }).show();
    this.startX = posXY(evt, this).x;
    this.startY = posXY(evt, this).y;
    if (this.parentObj) {
        var selDiv = getElCoordinate($(this.parentObj).get(0));
        this.s_top = parseInt(selDiv.top);
        this.s_left = parseInt(selDiv.left);
        this.s_right = parseInt(selDiv.right);
        this.s_bottom = parseInt(selDiv.bottom);
    }
    this.isSelect = true;
}

RegionSelect.prototype.onSelect = function (evt) {
    var _self = this;
    if (_self.isSelect) {
        var posX = posXY(evt, _self).x;
        var poxY = posXY(evt, _self).y;
        var x = Math.min(posX, this.startX);
        var y = Math.min(poxY, this.startY);
        if (!this.parentObj || (posX >= _self.s_left && posX <= _self.s_right)) {
            _self.selectDiv.style.left = x + "px";
            _self.selectDiv.style.width = Math.abs(posX - this.startX) + "px";
        }
        if (!this.parentObj || (poxY >= _self.s_top && poxY <= _self.s_bottom)) {
            _self.selectDiv.style.top = y + "px";
            _self.selectDiv.style.height = Math.abs(poxY - this.startY) + "px";
        }
        var regionList = _self.regions;
        _self._selectedRegions = [];
        _self.regions.removeClass(_self.selectedClass);
        for (var i = 0; i < regionList.length; i++) {
            var r = regionList[i], sr = _self.innerRegion(_self.selectDiv, r);
            if (sr) {
                $(r).removeClass(_self.selectedClass).addClass(_self.selectedClass);
                _self._selectedRegions.push(r);
            }
        }
        if (_self.selRegionProp.returnFunction) {
            _self.selRegionProp.returnFunction(_self._selectedRegions);
        }
    }
}

RegionSelect.prototype.onEnd = function () {
    if (this.selectDiv) {
        $(this.selectDiv).hide();
    }
    this.isSelect = false;
}

// 判断一个区域是否在选择区内
RegionSelect.prototype.innerRegion = function (selDiv, region) {
    var s = getElCoordinate(selDiv);
    var s_top = parseInt(s.top);
    var s_left = parseInt(s.left);
    var s_right = parseInt(s.right);
    var s_bottom = parseInt(s.bottom);
    var r = getElCoordinate(region);
    var r_top = parseInt(r.top);
    var r_left = parseInt(r.left);
    var r_right = parseInt(r.right);
    var r_bottom = parseInt(r.bottom);
    var l = (this.scrollObj ? $(this.scrollObj).get(0).scrollLeft : document.body.scrollLeft);
    var t = (this.scrollObj ? $(this.scrollObj).get(0).scrollTop : document.body.scrollTop);
    if (!isNaN(l)) {
        r_left -= l;
        r_right -= l;
    }
    if (!isNaN(t)) {
        r_top -= t;
        r_bottom -= t;
    }
    var t = Math.max(s_top, r_top);
    var r = Math.min(s_right, r_right);
    var b = Math.min(s_bottom, r_bottom);
    var l = Math.max(s_left, r_left);

    if (b > t + 5 && r > l + 5) {
        return region;
    } else {
        return null;
    }
}