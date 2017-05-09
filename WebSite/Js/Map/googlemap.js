function initMap(zoom,Type) {
    var setZoom = 4;
    zoom = zoom ? zoom : setZoom;
    var mapWidth = 700;
    var mapHeight = 500;
    var center = "";
    var markers = "";
    var maptype = "";
    var s = location.href.split("#");
    var str = "", url = "";
    if (s.length > 1) {
        url = unescape(s[1].split("?")[0]);
    }
    var bo = false;
    if (url.indexOf("?") != -1) {
        if (url.indexOf("?center=") != -1) {
            zoom = RegExpValue(url, "zoom");
            center = RegExpValue(url, "center");
            var size = RegExpValue(url, "size");
            if (size.length > 0) {
                mapWidth = size.split('x')[0];
                mapHeight = size.split('x')[1];
            } else {
                mapWidth = RegExpValue(url, "width");
                mapHeight = RegExpValue(url, "height");
            }
        } else {
            center = RegExpValue(url, "saddr");
            mapWidth = RegExpNum(url, "width");
            mapHeight = RegExpNum(url, "height");
            zoom = RegExpValue(url, "zoom");
        }
        if (center.length > 0) {
            mapType = RegExpValue(url, "maptype");
            ///Plus/BaiduMap/?zoom=10&saddr=116.403874,39.914889&amp;ll=116.403874,39.914889&amp;z=10&amp;maptype=sycms
            markers = RegExpValue(url, "markers");
            if (markers.length <= 0) {
                var markers = RegExpValue(url, "ll");
                if (markers.length <= 0) {
                    markers = center;
                }
            }
            bo = true;
        }
    } else {
        if (url.length > 0) {
            str = url;
            var str1 = url.replace(",", "").replace(".", "").replace(".", "");
            if (str1.isDigit()) {
                bo = true;
                center = url;
                markers = center;
            }
        }
    }
    var obj = $(window.parent.document).find("#MapGoogleBaidy");
    obj.find("#addressWidth").val(mapWidth);
    obj.find("#addressHeight").val(mapHeight);
    if (center) {
        if (url.indexOf("maptype=sycms") != -1) { //百度的
            if (Type == "0") {
                var centerarr = center.split(",");
                center = centerarr[1] + "," + centerarr[0];
                var markersarr = markers.split(",");
                markers = markersarr[1] + "," + markersarr[0];
            }
        } else {
            if (Type == "1") {
                var centerarr = center.split(",");
                center = centerarr[1] + "," + centerarr[0];
                var markersarr = markers.split(",");
                markers = markersarr[1] + "," + markersarr[0];
            }
        }
    }
    return { zoom: zoom, mapwidth: mapWidth, mapheight: mapHeight, center: center, markers: markers, maptype: maptype };
}
///提取像width=80&height=80&  width的值
function RegExpValue(Str, Rstring) {
    var s = "";
    if (Str && Str.length > 0) {
        var re = new RegExp(Rstring + "=(.*?)&", "gi");
        var mArr = Str.match(re);
        if (!(mArr instanceof Array)) return "";
        s = mArr[0];
        s = s.Right(s.length - (Rstring.length + 1));
        s = s.Left(s.length - 1);
        re = null;
        mArr = null;
    }
    return s;
}
///提取像width=\"80\"
function RegExpNum(Str, Rstring) {
    var s = "";
    if (Str && Str.length > 0) {
        var re = new RegExp(Rstring + "=[\"|'](.*?)[\"|']", "gi");
        var mArr = Str.match(re);
        if (!(mArr instanceof Array)) return "";
        s = mArr[0];
        s = s.Right(s.length - (Rstring.length + 2));
        s = s.Left(s.length - 1);
        re = null;
        mArr = null;
    }
    return s;
}