var yqrj_COLOR_TABLE = Array(
	"#FFFFFF","#DCEDFA","#D9FFFF","#E4F9D0","#EDFAC5","#FFFFD7","#FFFAD0","#FFEECE","#FFDFDF","#FFE6F9","#E9E1FF",
	"#DFDFDF","#B7D8F9","#A0EBF5","#BEFF7D","#E4FF79","#FBFBA8","#FFEE75","#FFDC9B","#FFB0B0","#F3B6E4","#DCB7F2",
	"#BFBFBF","#86BAEE","#2DDFFF","#58FF20","#CCFF00","#FFFF00","#FFDF00","#FFBD44","#FF6F6F","#EE82D3","#BF93EC",
	"#9F9F9F","#3C8FE3","#13BBD9","#79D959","#B3DF00","#FFEC00","#FFCC00","#FF9900","#FF0000","#E021B0","#AD58E7",
	"#6A6A6A","#166CC2","#0C97BA","#2FB900","#97B911","#E0D614","#D9A300","#FF5C00","#CE0F04","#C109A6","#9514EB",
	"#454545","#0449a6","#007795","#249100","#749100","#D5BF00","#AA8000","#CE4E00","#9C150E","#A20983","#6F17A8",
	"#252525","#033578","#075C8F","#1A6600","#556A00","#B0A513","#7B5300","#933F00","#6A0000","#800053","#510086",
	"#000000","#000055","#002F4A","#0F3500","#354000","#7D7100","#483100","#5B2200","#431412","#4A002F","#2F004A"
);
	var colorcmd="userblogcolor";
function blogCreateColorTable(cmd, eventStr,nonecolor)
{
	var str = '';
	str += '<div style="position:absolute;width:120px;z-index:999;background-color:#ffffff;border:1px solid #c0c0c0;"><table cellpadding="0" cellspacing="1" border="0" style="width:120px;"><tr><td colspan=7 id="'+cmd+'select" name="'+cmd+'select" height=14> </td>';
	if(nonecolor==null)
	{
	    str += '<td style="cursor:pointer;" colspan=2 onclick="blogExecute(\'' + eventStr + '\', \'\',1);" align=center><img alt="' + SycmsLanguage.color.l1 + '" src="images/select_nocolor.gif" style="width:10px;height:10px;"></td>';
	}
	str += '<td style="cursor:pointer;" colspan=2 align=center onclick="blogExecute(\'' + eventStr + '\', \'\',2);"><img alt="' + SycmsLanguage.color.l2 + '" src="images/select_no.gif" style="width:10px;height:10px;"></td></tr>';
	for (i = 0; i < yqrj_COLOR_TABLE.length; i++) {
		if (i == 0 || (i >= 11 && i%11 == 0)) {
			str += '<tr>';
		}
		str += '<td style="line-height:0px;width:10px;height:10px;border:0px solid #AAAAAA;font-size:1px;cursor:pointer;background-color:' +
		yqrj_COLOR_TABLE[i] + ';" onmouseover="document.getElementById(\''+cmd+'select\').style.backgroundColor=\''+ yqrj_COLOR_TABLE[i] +'\';" ' +
		'onclick="blogExecute(\''+eventStr+'\', \'' + yqrj_COLOR_TABLE[i] + '\',1);">&nbsp;</td>';
		if (i >= 10 && i%(i-1) == 0) {
			str += '</tr>';
		}
	}
	str += '</table></div><iframe style="LEFT: 0px; WIDTH: 120px; POSITION: absolute; TOP: 0px; HEIGHT: 104px;z-index:900;" frameBorder="0" src="about:blank;" scrolling="no"></iframe>';
	return str;
}

function blogExecute(cmd,color1,color2)
{	if(color2==1){
		document.getElementById(cmd).style.backgroundColor=color1;
		document.getElementById(cmd.replace("-view","")).value=color1;
	}
	HideHeadPhotcolor(cmd);
}
function DisplayClrDlg(cmdd, nonecolor) {
    var obj = document.getElementById(cmdd);
    if (obj != undefined) {
        var objDialog = document.getElementById(colorcmd);
        if (objDialog) {
            objDialog.parentNode.removeChild(objDialog);
        }
        ss = document.createElement("DIV");
        ss.id = colorcmd;
        ss.name = colorcmd;
        ss.style.zIndex = "999";
        ss.style.position = "absolute";
        ss.style.border = "1px #828282 solid";
        ss.innerHTML = blogCreateColorTable(colorcmd, cmdd, nonecolor);
        var objjj = getElCoordinate(obj);
        var left1 = objjj.left;
        var top1 = objjj.top + obj.offsetHeight;
        ss.style.backgroundColor = "#fff";

        if (left1 + 120 > document.body.offsetWidth) {
            ss.style.left = left1 - (120 - (document.body.offsetWidth - left1)) + "px";
        } else {
            ss.style.left = left1 + "px";
        }
        ss.style.top = top1 + "px";
        var objj = document.getElementById(colorcmd + "select");
        document.body.appendChild(ss);
        if (objj != undefined) {
            objj.style.backgroundColor = obj.style.backgroundColor;
        }
    }
}

function HideHeadPhotcolor(cmd) {
    var objDialog = document.getElementById(colorcmd);
    if (objDialog) {
        if (objDialog.parentNode != null && objDialog.parentNode != undefined) {
            document.body.removeChild(objDialog);
        }
    }
    var obj = document.getElementById(cmd.replace("-view", ""));
    if (obj) {
        try {
            obj.oninput();
        } catch (e) { }
        try {
            obj.onPropertyChange();
        } catch (e) { }
    }
}