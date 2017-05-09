function SetoncontextmenuOff() {
    document.oncontextmenu = function (e) {
        return false;
    }
    //document.onselectstart = function() {
    //    return false;
    //}
};
function SetoncontextmenuOn() {
    document.oncontextmenu = function (e) {
        return true;
    }
    //document.onselectstart = function() {
    //    return true;
    //}
};
SetoncontextmenuOff();
var isIE = navigator.userAgent.indexOf('MSIE') != -1;

var JsFile = new Array();
JsFile.push("js/js.ashx");
JsFile.push("ckeditor/ckeditor.js");
JsFile.push("js/DatePicker/WdatePicker.js");
for (var i = 0; i < JsFile.length; i++) {
    if (JsFile[i].indexOf("?") == -1) {
        JsFile[i] += "?version=1.0";
    }
    document.writeln("<scr" + "ipt src=\"" + JsFile[i] + "\" type=\"text/javascript\"></scr" + "ipt>");
}