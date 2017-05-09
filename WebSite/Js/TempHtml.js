var InterVeersionDiv = "pre"//(getBrowserOS() == "Firefox" ? "pre" : "div");
var LabelItemHtml = new Array("样式模块管理", 900, 560, 1, "<div class=\"WinRtop\" id=\"$$Tabletabs\"><span style=\"float:right;display:none;padding:2px 0 0\" id=\"$$VierLabelItem\"><input type=\"button\" value=\"说明\" icon=\"icon-help\" id=\"$$VierLabelItemHelp\"><input type=\"button\" value=\"效果\" icon=\"icon-eye\" id=\"$$VierLabelItemView\"><input type=\"button\" value=\"图片\" icon=\"icon-pictures\" id=\"$$VierLabelItemImages\"><input type=\"button\" value=\"文件\" icon=\"icon-page_copy\" id=\"$$VierLabelItemJs\"></span><span style=\"float:right;padding:2px 5px 0;\" id=\"$$T0LabelLog\"><input type=\"button\" icon=\"icon-table_multiple\" id=\"$$LabelItemLog\" value=\"使用记录\" /></span><a href=\"#$$Tabletab1\">HTML</a><a href=\"#$$Tabletab2\">Css</a></div><div style=\"padding:20px;\">" +
"    <div class=\"tab_container\">" +
"        <div id=\"$$Tabletab1\" class=\"$$Tabletab_content\">" +
"<table border=\"0\" width=\"100%\" cellspacing=\"0\" class=\"StyleView\" style=\"width:100%;\" scellpadding=\"0\">" +
"	<tr>" +
"		<th align=\"right\" width=\"80px;\">名称：</th>" +
"       <td align=\"left\"><input type=\"text\" name=\"$$Title\" id=\"$$Title\" size=\"45\" maxlength=\"50\">&nbsp;<select id=\"$$T11_0\"></select>&nbsp;<input type=\"checkbox\" value=\"1\" name=\"$$T11_1\" id=\"$$T11_1\">模块样式</td>" +
"	</tr>" +
"	<tr>" +
"		<th align=\"right\">HTML：</th>" +
"		<td align=\"left\"><div style=\"display:;padding-top:5px;\" id=\"$$T11_View\" name=\"$$T11_View\">" +
"<div class=\"WinRtop\" id=\"$$tabs\"><a href=\"#$$tab1\">循环显示</a><a href=\"#$$tab2\">交替显示</a><a href=\"#$$tab3\">无时显示</a><a href=\"#$$tab4\">最后不显示</a><a href=\"#$$tab5\">开始显示</a><a href=\"#$$tab6\">结束显示</a></div>" +
"    <div class=\"tab_container\">" +
"        <div id=\"$$tab1\" class=\"$$tab_content\"><div id=\"$$T1Viewtab1_1\" style=\"width:140px;height:$:160:$px;float:right;text-align:left;padding-left:3px;margin-left:3px;overflow-y:auto;overflow-x:hidden\"></div><div style=\"float:left;\"><div class=\"TextAreaSyCms\" style=\"width:600px;height:$:200:$px;\"><div id=\"$$T11_2_Line\" class=\"TextAreaSyCmsLine TextAreaSyCmsFont\"></div><" + InterVeersionDiv + " id=\"$$T11_2_Bg\" style=\"width:565px;\" class=\"TextAreaSyCmsPackage TextAreaSyCmsFont\"></" + InterVeersionDiv + "><textarea rows=\"7\" wrap=\"off\" class=\"TextArea TextAreaSyCmsFont\" name=\"$$T11_2\" id=\"$$T11_2\" style=\"width:565px;height:$:200:$px;\" cols=\"70\"></textarea></div><select id=\"$$T12_1\" style=\"margin:5px 0 0 5px;\" name=\"$$T12_1\"></select><select id=\"$$T13_1\" style=\"margin:5px 0 0 5px;\" name=\"$$T13_1\"></select></div></div>" +
"        <div id=\"$$tab2\" class=\"$$tab_content\" style=\"display:none\"><div id=\"$$T1Viewtab2_1\" style=\"width:140px;height:$:160:$px;float:right;text-align:left;padding-left:3px;margin-left:3px;overflow-y:auto;overflow-x:hidden\"></div><div style=\"float:left;\"><div class=\"TextAreaSyCms\" style=\"width:600px;height:$:200:$px;\"><div id=\"$$T11_3_Line\" class=\"TextAreaSyCmsLine TextAreaSyCmsFont\"></div><" + InterVeersionDiv + " id=\"$$T11_3_Bg\" style=\"width:565px;\" class=\"TextAreaSyCmsPackage TextAreaSyCmsFont\"></" + InterVeersionDiv + "><textarea rows=\"7\" name=\"$$T11_3\" wrap=\"off\" class=\"TextArea TextAreaSyCmsFont\" id=\"$$T11_3\" style=\"width:565px;height:$:200:$px;\" cols=\"70\"></textarea></div><select id=\"$$T12_2\" style=\"margin:5px 0 0 5px;\" name=\"$$T12_2\"></select><select style=\"margin:5px 0 0 5px;\" id=\"$$T13_2\" name=\"$$T13_2\"></select></div></div>" +
"        <div id=\"$$tab3\" class=\"$$tab_content\" style=\"display:none\"><div id=\"$$T1Viewtab3_1\" style=\"width:140px;height:$:160:$px;float:right;text-align:left;padding-left:3px;margin-left:3px;overflow-y:auto;overflow-x:hidden\"></div><div style=\"float:left;\"><div class=\"TextAreaSyCms\" style=\"width:600px;height:$:200:$px;\"><div id=\"$$T11_4_Line\" class=\"TextAreaSyCmsLine TextAreaSyCmsFont\"></div><" + InterVeersionDiv + " id=\"$$T11_4_Bg\" style=\"width:565px;\" class=\"TextAreaSyCmsPackage TextAreaSyCmsFont\"></" + InterVeersionDiv + "><textarea rows=\"7\" name=\"$$T11_4\" wrap=\"off\" class=\"TextArea TextAreaSyCmsFont\" id=\"$$T11_4\" style=\"width:565px;height:$:200:$px;\" cols=\"70\"></textarea></div><select id=\"$$T12_3\" style=\"margin:5px 0 0 5px;\" name=\"$$T12_3\"></select><select id=\"$$T13_3\" style=\"margin:5px 0 0 5px;\" name=\"$$T13_3\"></select></div></div>" +
"        <div id=\"$$tab4\" class=\"$$tab_content\" style=\"display:none\"><div id=\"$$T1Viewtab4_1\" style=\"width:140px;height:$:160:$px;float:right;text-align:left;padding-left:3px;margin-left:3px;overflow-y:auto;overflow-x:hidden\"></div><div style=\"float:left;\"><div class=\"TextAreaSyCms\" style=\"width:600px;height:$:200:$px;\"><div id=\"$$T11_5_Line\" class=\"TextAreaSyCmsLine TextAreaSyCmsFont\"></div><" + InterVeersionDiv + " id=\"$$T11_5_Bg\" style=\"width:565px;\" class=\"TextAreaSyCmsPackage TextAreaSyCmsFont\"></" + InterVeersionDiv + "><textarea rows=\"7\" name=\"$$T11_5\" wrap=\"off\" class=\"TextArea TextAreaSyCmsFont\" id=\"$$T11_5\" style=\"width:565px;height:$:200:$px;\" cols=\"70\"></textarea></div><select id=\"$$T12_4\" style=\"margin:5px 0 0 5px;\" name=\"$$T12_4\"></select><select id=\"$$T13_4\" style=\"margin:5px 0 0 5px;\" name=\"$$T13_4\"></select></div></div>" +
"        <div id=\"$$tab5\" class=\"$$tab_content\" style=\"display:none\"><div id=\"$$T1Viewtab5_1\" style=\"width:140px;height:$:160:$px;float:right;text-align:left;padding-left:3px;margin-left:3px;overflow-y:auto;overflow-x:hidden\"></div><div style=\"float:left;\"><div class=\"TextAreaSyCms\" style=\"width:600px;height:$:200:$px;\"><div id=\"$$T11_6_Line\" class=\"TextAreaSyCmsLine TextAreaSyCmsFont\"></div><" + InterVeersionDiv + " id=\"$$T11_6_Bg\" style=\"width:565px;\" class=\"TextAreaSyCmsPackage TextAreaSyCmsFont\"></" + InterVeersionDiv + "><textarea rows=\"7\" name=\"$$T11_6\" wrap=\"off\" class=\"TextArea TextAreaSyCmsFont\" id=\"$$T11_6\" style=\"width:565px;height:$:200:$px;\" cols=\"70\"></textarea></div><select id=\"$$T12_5\" style=\"margin:5px 0 0 5px;\" name=\"$$T12_5\"></select><select id=\"$$T13_5\" style=\"margin:5px 0 0 5px;\" name=\"$$T13_5\"></select></div></div>" +
"        <div id=\"$$tab6\" class=\"$$tab_content\" style=\"display:none\"><div id=\"$$T1Viewtab6_1\" style=\"width:140px;height:$:160:$px;float:right;text-align:left;padding-left:3px;margin-left:3px;overflow-y:auto;overflow-x:hidden\"></div><div style=\"float:left;\"><div class=\"TextAreaSyCms\" style=\"width:600px;height:$:200:$px;\"><div id=\"$$T11_7_Line\" class=\"TextAreaSyCmsLine TextAreaSyCmsFont\"></div><" + InterVeersionDiv + " id=\"$$T11_7_Bg\" style=\"width:565px;\" class=\"TextAreaSyCmsPackage TextAreaSyCmsFont\"></" + InterVeersionDiv + "><textarea rows=\"7\" name=\"$$T11_7\" wrap=\"off\" class=\"TextArea TextAreaSyCmsFont\" id=\"$$T11_7\" style=\"width:565px;height:$:200:$px;\" cols=\"70\"></textarea></div><select id=\"$$T12_6\" style=\"margin:5px 0 0 5px;\" name=\"$$T12_6\"></select><select id=\"$$T13_6\" style=\"margin:5px 0 0 5px;\" name=\"$$T13_6\"></select></div></div>" +
"	</div></div></td>" +
"	</tr>" +
" </table>"+
"       </div>" +
"        <div id=\"$$Tabletab2\" class=\"$$Tabletab_content\" style=\"display:none;\">" +
"       <table border=\"0\" width=\"100%\" cellspacing=\"0\" class=\"StyleView\" style=\"width:100%;\" cellpadding=\"0\">" +
"	        <tr>" +
"		        <th align=\"right\" width=\"80px;\">基本样式：</th>" +
"               <td align=\"left\">如果有图片的时候前面要加[$Path$],如[$Path$]/Images/.JPG<br><textarea rows=\"7\" name=\"$$T14\" id=\"$$T14\" wrap=\"off\" style=\"width:740px;height:$:350:$px;\" cols=\"70\"></textarea></td>" +
"	        </tr>" +
"       </table>"+
"       </div>" +
"   </div>" +
"</div>");



var LabelTemplateHtml = new Array("区块", 900, 590, 0, "<div style=\"height:$:0:$px;overflow:hidden;\">" +
"   <div><table border=\"0\" width=\"100%\" cellspacing=\"0\" class=\"StyleView\" style=\"width:100%;\" cellpadding=\"0\">"+
"	<tr>"+
"		<th align=\"right\" width=\"75px;\">区块名称：</th>" +
"		<td align=\"left\"><span style=\"float:right;padding-right:5px;\"><span id=\"$$T0UserView\"><input type=\"button\" icon=\"icon-table_multiple\" onclick=\"OpenTemLog($('#TemId').val());\" value=\"使用记录\" /></span></span><input type=\"text\" name=\"$$T0\" id=\"$$T0\" size=\"50\" maxlength=\"50\" ><input type=\"hidden\" name=\"TemId\" id=\"TemId\" size=\"50\" maxlength=\"50\" >&nbsp;&nbsp;<select id=\"$$T0_1\" name=\"$$T0_1\" jTipTitle=\"调用说明\" class=\"jTip\" alt=\"Help/Lists.aspx?action=tem-loadtype\"><option value=\"0\">标准</option><option value=\"1\">静态调用</option><option value=\"2\">动态调用</option></select></td>" +
"	</tr></table></div>"+
"   <div class=\"WinRtop\" id=\"$$tabs\"><a href=\"#$$tab1\">HTML</a><a href=\"#$$tab2\">变量</a><a href=\"#$$tab3\">CSS</a></div>" +
"    <div class=\"tab_container\">" +
"        <div id=\"$$tab1\" class=\"$$tab_content\"><div id=\"$$T1View1\" style=\"width:150px;height:$:90:$px;float:right;text-align:left;padding-left:3px;overflow-y:auto;overflow-x:hidden\"></div><div style=\"float:left;padding-left:5px;\">"+
"<div class=\"TextAreaSyCms\" style=\"width:735px;height:$:90:$px;\"><div id=\"$$T1_Line\" class=\"TextAreaSyCmsLine TextAreaSyCmsFont\"></div><" + InterVeersionDiv + " id=\"$$T1_Bg\" style=\"width:700px;\" class=\"TextAreaSyCmsPackage TextAreaSyCmsFont\"></" + InterVeersionDiv + "><textarea rows=\"7\" wrap=\"off\" IsList=\"0\" IsLabel=\"1\" class=\"TextArea TextAreaSyCmsFont\" name=\"$$T1\" id=\"$$T1\" style=\"width:700px;height:$:90:$px;\" cols=\"70\"></textarea></div></div></div>" +
"        <div id=\"$$tab2\" class=\"$$tab_content\" style=\"display:none;width:864px;height:$:110:$px;overflow:auto;overflow-x:hidden\"><div style=\"text-align:left;padding:15px 10px;\"><div style=\"padding:3px;float:left;\">&nbsp;&nbsp;<b>变量列表</b>&nbsp;</div><div style=\"float:left;\"><input type=\"button\" name=\"$$Submit10_1\" onclick=\"AddMember('$$T1MemberList');\" icon=\"icon-add\" value=\"添加变量\"></div></div><div id=\"$$T1MemberList\" style=\"padding:15px 10px;\"></div></div>" +
"        <div id=\"$$tab3\" class=\"$$tab_content\" align=\"left\" style=\"padding:15px;\">如果有图片的时候前面要加[$Path$],如[$Path$]/Images/.JPG<div><input type=\"text\" name=\"$$T16_0\" id=\"$$T16_0\" size=\"20\"><input type=\"button\" onclick=\"LoadSpreadView('$$T16_0',$('#YQ_listID').val(),'$$T3');\"  icon=\"icon-css_go\" value=\"调入扩展样式\"></div><textarea rows=\"7\" wrap=\"off\" name=\"$$T3\" id=\"$$T3\" style=\"width:860px;height:$:150:$px;\" cols=\"70\"></textarea></div>" +
"   </div>"+
"</div>");


var LabelBasicTemHtml = new Array("引用基础样式", 600, 60, 0, "<div style=\"height:60px;overflow:hidden;width:600px\">" +
"   <table border=\"0\" width=\"100%\" cellspacing=\"0\" class=\"StyleView\" style=\"width:100%;\" cellpadding=\"0\">" +
"	<tr>" +
"		<td align=\"left\" colspan=\"2\">（只能在模块样式中或者是其它基础样式中引用，其它地方引用无效。）</td>" +
"	</tr>"+
"	<tr>" +
"		<th align=\"right\" width=\"85px;\">基础样式名称：</th>" +
"		<td align=\"left\" id=\"$$ObjView\"></td>" +
"	</tr></table>" +
"</div>");

var LabelSeoHtml = new Array("Seo优化", 650, 300, 0, "<div style=\"height:300px;overflow:hidden;overflow-y:auto;width:650px\">" +
"   <table border=\"0\" width=\"100%\" cellspacing=\"0\" class=\"StyleView\" style=\"width:100%;\" cellpadding=\"0\">" +
"	<tr>" +
"		<th align=\"right\" width=\"75px;\">数据模型：</th>" +
"		<td align=\"left\"><input type=\"hidden\" name=\"$$T0\" id=\"$$T0\" /><span style=\"float:right;\"><input type=\"checkbox\" name=\"$$T11\" id=\"$$T11\"><label for=\"$$T11\">为空使用系统设置。</label>&nbsp;&nbsp;</span><select name=\"$$T1\" id=\"$$T1\" onchange=\"Label_Sell_Mdb_Seo(this,'$$')\" size=1></select></td>" +
"	</tr>" +
"	<tr>" +
"		<th align=\"right\">递归关系：</th>" +
"		<td align=\"left\" id=\"$$ObjView\"></td>" +
"	</tr><tr>" +
"		<th align=\"right\">Seo字段：</th>" +
"		<td align=\"left\" id=\"$$ObjFieldView\"></td>" +
"	</tr><tr>" +
"		<th align=\"right\">输出选项：</th>" +
"		<td align=\"left\"><span style=\"float:right;\"><input type=\"checkbox\" checked=\"checked\" name=\"$$T33\" id=\"$$T33\"><label for=\"$$T33\">带html标签</label>&nbsp;&nbsp;</span><input type=\"checkbox\" checked=\"checked\" name=\"$$T22\" id=\"$$T22_0\" /><label for=\"$$T22_0\">显示Title</label><input type=\"checkbox\" checked=\"checked\" name=\"$$T22\" id=\"$$T22_1\" /><label for=\"$$T22_1\">显示KeyWords</label><input type=\"checkbox\" checked=\"checked\" name=\"$$T22\" id=\"$$T22_2\" /><label for=\"$$T22_2\">显示Description</label></td>" +
"	</tr><tr>" +
"		<th align=\"right\">附加功能：</th>" +
"		<td align=\"left\"><select name=\"$$T44\" id=\"$$T44\"></select></td>" +
"	</tr></table>" +
"</div>");

var LabelListHtml = new Array("常规标签", 900, 580, 1, "<div style=\"word-break:break-all;table-layout:fixed;z-index:0;height:$:0:$px;overflow:auto;overflow-x:hidden;\">" +
"<div class=\"WinRtop\" id=\"$$Tabletabs\"><a href=\"#$$Tabletab1\">常规设置</a><a href=\"#$$Tabletab2\">显示设置</a></div>" +
"    <div class=\"tab_container\">" +
"<table border=\"0\" width=\"100%\" cellspacing=\"0\" id=\"$$Tabletab1\" class=\"StyleView $$Tabletab_content\" style=\"width:100%;\" cellpadding=\"0\">" +
"	<tr>"+
"		<th align=\"right\" width=\"75px;\">数据模型：</th>" +
"		<td align=\"left\"><select name=\"$$T1\" id=\"$$T1\" onchange=\"Label_Sell_Mdb(this,'$$')\" size=1></select>&nbsp;&nbsp;&nbsp;标签说明：<input type=\"text\" name=\"$$T1Help\" id=\"$$T1Help\" size=50></td>" +
"	</tr>"+
"	<tr>"+
"		<th align=\"right\">条件设置：</th>"+
"		<td align=\"left\">"+
"<div class=\"WinRtop\" id=\"$$ATtabs\"><a href=\"#$$ATtab1\">标准</a><a href=\"#$$ATtab2\">高级</a></div><div id=\"$$ATtab1\" class=\"$$ATtab_content\">" +
"<table border=\"0\" class=\"nb\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">"+
"	<tr>"+
"		<td width=\"480\">&nbsp;<select size=\"12\" style=\"width:468px;height:130px\" onchange=\"ATfun('$$');\" name=\"$$T4\" id=\"$$T4\"></td>" +
"		<td style=\"line-height:25px;\"><fieldset><legend>位置</legend><input type=\"button\" name=\"$$T4Sub2\" icon=\"icon-prev\" id=\"$$T4Sub2\" value=\"向上\"><input type=\"button\" name=\"$$T4Sub3\" id=\"$$T4Sub3\" icon=\"icon-next\" value=\"向下\"><input type=\"button\" name=\"$$T4Sub5\" id=\"$$T4Sub5\" icon=\"icon-delete\" onclick=\"AtDel('$$','4');\" value=\"删除选定项\"></fieldset><fieldset><legend>关系</legend><input type=\"radio\" name=\"$$T4_Sub1\" onclick=\"AtAndOrfun('$$', '4','AND')\" id=\"$$T4_Sub1_0\"><label for=\"$$T4_Sub1_0\">并且</label>&nbsp;&nbsp;<input type=\"radio\" name=\"$$T4_Sub1\" onclick=\"AtAndOrfun('$$', '4','OR')\" id=\"$$T4_Sub1_1\"><label for=\"$$T4_Sub1_1\">或者</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type=\"checkbox\" name=\"$$T4_Sub2\" id=\"$$T4_Sub2\" onclick=\"AtLikeFun('$$', '4', this, '(')\"><label for=\"$$T4_Sub2\">左括号</label>&nbsp;<input type=\"checkbox\" name=\"$$T4_Sub3\" onclick=\"AtLikeFun('$$', '4', this, ')')\" id=\"$$T4_Sub3\"><label for=\"$$T4_Sub3\">右括号</label></fieldset></td>" +
"	</tr>"+
"	<tr>"+
"		<td colspan=2><div style=\"float:left;padding:3px\">&nbsp;<select size=\"1\" style=\"width:150px;\" name=\"$$T4_2\" onchange=\"LabelJudgeChange(this,'$$')\" id=\"$$T4_2\">" +
"	</select><select name=\"$$T4_3\" id=\"$$T4_3\" size=\"1\" style=\"display:none;width:150px;\" onchange=\"LabelJudgeChange1(this,'$$')\">" +
"        </select><input type=\"Text\" size=50 id=\"$$T4_4\" style=\"display:none;\" jTipTitle=\"规则\" class=\"jTip\" alt=\"Help/Lists.aspx?action=temhtml-atspace\" name=\"$$T4_4\"><select onchange=\"LabelJudgeChange2(this,'$$')\" name=\"$$T4_5\" id=\"$$T4_5\" style=\"display:none;\" size=\"1\"></select></div>" +
"        <div style=\"float:left\"><input type=\"button\" name=\"Submit\" onclick=\"AddValue1('$$','4',null)\" icon=\"icon-add\" value=\"添加\"></div><div style=\"float:left;display:none;padding-left:3px;\" id=\"$$T4_View\"><input type=\"button\" name=\"Submit\" onclick=\"AddValue1('$$','4',$id('$$T4_View'))\" icon=\"icon-edit\" value=\"修改\"></div></td>" +
"	</tr>"+
"</table></div>"+
"<div id=\"$$ATtab2\" class=\"$$ATtab_content\" style=\"display:none;\"><div id=\"$$T21Viewtab\" style=\"width:140px;height:150px;float:right;text-align:left;padding-left:3px;margin-left:3px;overflow-y:auto;overflow-x:hidden\"></div><div style=\"float:left;\"><div class=\"TextAreaSyCms\" style=\"width:630px;height:130px;\"><div id=\"$$T21_Line\" class=\"TextAreaSyCmsLine TextAreaSyCmsFont\"></div><" + InterVeersionDiv + " id=\"$$T21_Bg\" style=\"width:595px;\" class=\"TextAreaSyCmsPackage TextAreaSyCmsFont\"></" + InterVeersionDiv + "><textarea rows=\"8\" name=\"$$T21\" wrap=\"off\" class=\"TextArea TextAreaSyCmsFont\" id=\"$$T21\" style=\"width:595px;height:130px;\" cols=\"40\"></textarea></div>" +
"<select name=\"$$T4_7\" id=\"$$T4_7\" style=\"margin:5px 0 0 5px\" onchange=\"InsertAtCaret($id('$$T21'),this.options[this.selectedIndex].value)\" size=\"1\"></select></div></div>" +
"</td>"+
"	</tr>" +
"	<tr>" +
"		<th align=\"right\">排序设置：</tdh>" +
"		<td align=\"left\"><div class=\"WinRtop\" id=\"$$ordertabs\"><a href=\"#$$ordertab1\">标准</a><a href=\"#$$ordertab2\">高级</a></div><div id=\"$$ordertab1\" class=\"$$ordertab_content\">" +
"<table border=\"0\" class=\"nb\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">" +
"	<tr>" +
"		<td style=\"width:480px;\">&nbsp;<select size=\"12\" style=\"width:468px;height:80px\" name=\"$$T9\" id=\"$$T9\"></td>" +
"		<td style=\"line-height:25px;\"><fieldset><legend>位置</legend><input type=\"button\" name=\"$$Sub9_1\" id=\"$$Sub9_1\" icon=\"icon-prev\" value=\"向上\"><input type=\"button\" name=\"$$Sub9_2\" id=\"$$Sub9_2\" icon=\"icon-next\" value=\"向下\"><input type=\"button\" name=\"$$Submit4\" onclick=\"DelSelectValue($id('$$T9'));\" icon=\"icon-delete\" value=\"删除选择项\"></fieldset></td>" +
"	</tr>" +
"	<tr>" +
"		<td colspan=2><div style=\"float:left;padding:3px\">&nbsp;<select name=\"$$T9_2\" id=\"$$T9_2\" size=\"1\">" +
"        	</select><select name=\"$$T9_3\" id=\"$$T9_3\" size=\"1\"></select></div>" +
"        	<div style=\"float:left;\"><input type=\"button\" name=\"$$Submit0_1\" onclick=\"AddValue2($id('$$T9'),$id('$$T9_2'),$id('$$T9_3'));\" icon=\"icon-add\" value=\"添加\"></div></td>" +
"	</tr>" +
"	</table></div>"+
"<div id=\"$$ordertab2\" class=\"$$ordertab_content\" style=\"display:none;\"><div id=\"$$T21Viewtab\" style=\"width:140px;height:85px;float:right;text-align:left;padding-left:3px;margin-left:3px;overflow-y:auto;overflow-x:hidden\"></div><div style=\"float:left;\"><div class=\"TextAreaSyCms\" style=\"width:630px;height:85px;\"><div id=\"$$T22_Line\" class=\"TextAreaSyCmsLine TextAreaSyCmsFont\"></div><" + InterVeersionDiv + " id=\"$$T22_Bg\" style=\"width:595px;\" class=\"TextAreaSyCmsPackage TextAreaSyCmsFont\"></" + InterVeersionDiv + "><textarea rows=\"8\" wrap=\"off\" class=\"TextArea TextAreaSyCmsFont\" name=\"$$T22\" id=\"$$T22\" style=\"width:595px;height:85px;\" cols=\"40\"></textarea></div><select name=\"$$T9_7\" style=\"margin:5px 0 0 5px\" id=\"$$T9_7\" onchange=\"InsertAtCaret($id('$$T22'),this.options[this.selectedIndex].value)\" size=\"1\"></select></div></div>" +
"</td>" +
"	</tr>" +
"	<tr>" +
"		<th align=\"right\">调用数量：</th>" +
"		<td align=\"left\"><div id=\"$$LoadNum\">&nbsp;<input type=\"radio\" checked=\"checked\" onchange=\"LoadNum_PageFun(this,0,'$$');\" name=\"$$T7_0\" id=\"$$T7_0_0\"><label for=\"$$T7_0_0\">部分调用</label><span id=\"$$LoadNumView\">：调用<input type=\"Text\" size=10 name=\"$$T7_1\" jTipTitle=\"调用数量\" class=\"jTip\" alt=\"Help/Lists.aspx?action=temhtml-loadnum\" id=\"$$T7_1\" value=\"10\">条&nbsp;从<input type=\"Text\" size=10 name=\"$$T7_2\" id=\"$$T7_2\">条开始显示</span></div>" +
"<div id=\"$$LoadNumPage\">&nbsp;<input type=\"radio\" onchange=\"LoadNum_PageFun(this,1,'$$');\" name=\"$$T7_0\" id=\"$$T7_0_1\"><label for=\"$$T7_0_1\">全部调用</label>：<span id=\"$$LoadPage\"><span>&nbsp;<input type=\"checkbox\" class=\"radio\" name=\"$$T13_1\" id=\"$$T13_1\" onclick=\"if(this.checked){FirefoxDisabled('$$T13_PageView',1);FirefoxDisabled('$$LoadNum');FirefoxDisabled('$$LoadPageType');}else{FirefoxDisabled('$$T13_PageView');FirefoxDisabled('$$LoadNum',1);FirefoxDisabled('$$LoadNumView');FirefoxDisabled('$$LoadPageType',1);}\" value=\"1\"><label for=\"$$T13_1\">分页显示：</label></span>" +
"		<span id=\"$$T13_PageView\">&nbsp;分页样式：<select name=\"$$T13_2\" jTipTitle=\"分页样式\" class=\"jTip\" alt=\"Help/Lists.aspx?action=temhtml-pagestyle\" id=\"$$T13_2\" size=\"1\"></select>&nbsp;每页数量：<input type=\"Text\" size=10 name=\"$$T13_3\" id=\"$$T13_3\" value=\"50\">条&nbsp;最大页码：<input type=\"Text\" size=10 name=\"$$T13_14\" id=\"$$T13_14\" value=\"0\">页&nbsp;分页名称：<input type=\"Text\" size=10 name=\"$$T13_7\" id=\"$$T13_7\" value=\"记录\"></span></span></div></td>" +
"	</tr>" +
"	<tr>" +
"		<th align=\"right\">输出结果：<input type=\"hidden\" name=\"$$T11\" id=\"$$T11\" value=\"1\"></th>" +
"		<td align=\"left\"><div class=\"WinRtop\" id=\"$$Writetabs\"><a href=\"#$$Writetab1\">选择样式输出</a><a href=\"#$$Writetab2\">直接输出</a></div>" +
"       <div class=\"tab_container\">" +
"        <div id=\"$$Writetab1\" class=\"$$Writetab_content\">" +
"<div style=\"height:25px\"><span style=\"float:right;\"><input type=\"button\" id=\"$$SelectStyleModi\" icon=\"icon-text_align_justify\" disabled=\"disabled\" onclick=\"ModiyItemSelectFun('$$',this)\" value=\"修改样式模块\"><input type=\"button\" id=\"$$SelectSpStyleModi\" icon=\"icon-text_horizontalrule\" onclick=\"ModiyItemSelectSpFun('$$')\" disabled=\"disabled\" value=\"修改扩展样式模块\"></span><div id=\"$$T11View\" style=\"padding:5px;\">请选择样式输出</div></div><hr/>" +
"<input type=\"button\" id=\"$$SubmitStyleWrite\" icon=\"icon-text_dropcaps\" onclick=\"SelectStyleModule(this,'$$');\" value=\"选择样式输出\"/>" +
"</div>" +
"        <div id=\"$$Writetab2\" class=\"$$Writetab_content\"><div id=\"$$T1View1\" style=\"width:140px;height:110px;float:right;text-align:left;padding-left:3px;margin-left:3px;overflow-y:auto;overflow-x:hidden\"></div>" +
"       <div style=\"float:left;\"><div class=\"TextAreaSyCms\" style=\"width:630px;height:85px;\"><div id=\"$$T11_1_Line\" class=\"TextAreaSyCmsLine TextAreaSyCmsFont\"></div><" + InterVeersionDiv + " id=\"$$T11_1_Bg\" style=\"width:595px;\" class=\"TextAreaSyCmsPackage TextAreaSyCmsFont\"></" + InterVeersionDiv + "><textarea wrap=\"off\" class=\"TextArea TextAreaSyCmsFont\" rows=\"8\" name=\"$$T11_1\" id=\"$$T11_1\" style=\"width:595px;height:85px;\" cols=\"40\"></textarea></div><select id=\"$$T11_2\" style=\"margin-top:5px;\" name=\"$$T11_2\"></select></div>" +
"</div></div></td>" +
"	</tr>" +
"</table>" +
"<table border=\"0\" width=\"100%\" cellspacing=\"0\" id=\"$$Tabletab2\" class=\"StyleView $$Tabletab_content\" style=\"width:100%;display:none;\" cellpadding=\"0\">" +
"	<tr>" +
"		<th align=\"right\" width=\"75px\">图片格式：</th>" +
"		<td align=\"left\">&nbsp;宽：<input type=\"Text\" size=10 name=\"$$T3_1\" jTipTitle=\"切图大小\" class=\"jTip\" alt=\"Help/Lists.aspx?action=temhtml-picwidth\" id=\"$$T3_1\">px&nbsp;高：<input type=\"Text\" size=10 name=\"$$T3_2\" jTipTitle=\"切图大小\" class=\"jTip\" alt=\"Help/Lists.aspx?action=temhtml-picheight\" id=\"$$T3_2\">px&nbsp<select name=\"$$T3_3\" jTipTitle=\"切图方式\" class=\"jTip\" alt=\"Help/Lists.aspx?action=temhtml-piccuttype\" id=\"$$T3_3\"><option value=\"\">选择切图方式</option><option value=\"cut\">普通切法</option><option value=\"cen\">切取中间</option><option value=\"hwc\">高宽比例</option><option value=\"h\">限制高度</option><option value=\"w\">限制宽度</option></select>&nbsp;<input type=\"checkbox\" jTipTitle=\"切图水印\" class=\"jTip\" alt=\"Help/Lists.aspx?action=temhtml-piclogo\" name=\"$$T3_4\" id=\"$$T3_4\" value=\"1\"><label for=\"$$T3_4\">添加水印</label></td>" +
"	</tr>" +
"	<tr>" +
"		<th align=\"right\">标题字数：</th>" +
"		<td align=\"left\"><div style=\"float:left;\">&nbsp;<input type=\"Text\" size=10 name=\"$$T6\" id=\"$$T6\"/>&nbsp;1个汉字2个字符&nbsp;<input type=\"Text\" name=\"$$T6_2\" id=\"$$T6_2\" maxlength=\"10\" size=\"6\"/>&nbsp;截取补字符。&nbsp;&nbsp;<input type=\"hidden\" name=\"$$T6_2_1\" id=\"$$T6_2_1\"></div><div style=\"float:left;\"><input type=\"button\" icon=\"icon-text_fit\" value=\"设置规则\" id=\"$$T6_2_1Button\" onclick=\"InterceptionHtmlFun('$$T6_2_1');\"/></div></td>" +
"	</tr>" +
"	<tr>" +
"		<th align=\"right\">日期格式：</th>" +
"		<td align=\"left\">&nbsp;<input type=\"Text\" size=\"38\" class=\"jTip\" alt=\"Help/Lists.aspx?action=temhtml-timemess\" name=\"$$T10\" id=\"$$T10\">&nbsp;<select name=\"$$T10_1\" id=\"$$T10_1\" onchange=\"$id('$$T10').value=this.options[this.selectedIndex].value;\" size=\"1\"></select></td>" +
"	</tr>" +
"	<tr>" +
"		<th align=\"right\">内容显示：</th>" +
"		<td align=\"left\"><div style=\"float:left;\">&nbsp;<input type=\"checkbox\" class=\"radio\" onclick=\"if(this.checked){FirefoxDisabled('$$T12_1ViewContent',1);}else{FirefoxDisabled('$$T12_1ViewContent');};\" name=\"$$T12_1\" id=\"$$T12_1\" value=\"1\"/></div><div style=\"float:left;\" id=\"$$T12_1ViewContent\"><div style=\"float:left;\">&nbsp;&nbsp;内容：<input type=\"Text\" size=10 name=\"$$T12_2\" id=\"$$T12_2\"/>个&nbsp;<input type=\"hidden\" name=\"$$T12_2_1\" id=\"$$T12_2_1\"/></div><div style=\"float:left;\"><input type=\"button\" id=\"$$T12_2_1Button\" icon=\"icon-text_fit\" value=\"设置规则\" onclick=\"InterceptionHtmlFun('$$T12_2_1');\"></div><div style=\"float:left;\">； 摘要：<input type=\"Text\" size=10 name=\"$$T12_3\" id=\"$$T12_3\"/>个&nbsp;<input type=\"hidden\" name=\"$$T12_3_1\" id=\"$$T12_3_1\" value=\"1\"/></div><div style=\"float:left;\"><input type=\"button\" icon=\"icon-text_fit\" id=\"$$T12_3_1Button\" value=\"设置规则\" onclick=\"InterceptionHtmlFun('$$T12_3_1');\"/></div><div style=\"float:left;\">；&nbsp;截取补字符<input type=\"Text\" name=\"$$T12_4\" id=\"$$T12_4\" value=\"...\" maxlength=\"10\" size=\"6\"/></div></div></td>" +
"	</tr>" +
"	<tr id=\"$$LoadPageType\">" +
"		<th align=\"right\">内容分页：</th>" +
"		<td align=\"left\">&nbsp;<select name=\"$$T23_1\" jTipTitle=\"分页样式\" class=\"jTip\" alt=\"Help/Lists.aspx?action=temhtml-pagestyle\" id=\"$$T23_1\" size=\"1\"></select></td>" +
"	</tr>" +
"	<tr>" +
"		<th align=\"right\">行隔显示：</th>" +
"		<td align=\"left\">&nbsp;代码：<input type=\"Text\" size=40 name=\"$$T13_4\" id=\"$$T13_4\"/>&nbsp;HTML代码&nbsp;行隔：<input type=\"Text\" size=10 name=\"$$T13_5\" id=\"$$T13_5\" value=\"5\"/>行</td>" +
"	</tr>" +
"</table>" +

"</div>");


var LabelWordHtml = new Array("字段属性显示", 790, 550, 0, "<div style=\"height:$:0:$px;overflow:auto;overflow-x:hidden;\"><table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"StyleView\" id=\"$$StyleView\" style=\"width:100%;\">" +
"	<tr>" +
"		<th align=\"right\" width=\"70px;\">字段说明：</th>" +
"		<td align=\"left\"><div style=\"float:right;\"><input type=\"button\" icon=\"icon-text_horizontalrule\" id=\"$$T200_1Button\" onclick=\"SpecialValueHtmlFun('$$T200_1');\" value=\"特殊取值\"/><input type=\"hidden\" name=\"$$T200_1\" id=\"$$T200_1\"/></div><div id=\"$$View1\" style=\"padding-top:5px;\">&nbsp;</div></td>" +
"	</tr>" +
"	<tr>" +
"		<th align=\"right\"><input type=\"radio\" class=\"radio\" checked name=\"$$T1\" id=\"$$T11\"/><label for=\"$$T11\">标准型</label></th>" +
"		<td align=\"left\"><fieldset>" +
"  <legend>分隔取值</legend>" +
"<div>用<input type=\"text\" name=\"$$T0_1\" id=\"$$T0_1\" size=\"2\"/>分隔取<input type=\"text\" name=\"$$T0_2\" id=\"$$T0_2\" size=\"2\"/>个其余用<input type=\"text\" name=\"$$T0_3\" id=\"$$T0_3\" size=\"2\"/>填充</div><div>(“第三个”为空时，显示“第二个”位置的值；不为空时，“第二个”前面为原数据，后面用“第三个”补全。“第二个”为空时“第三个”不为空时用“第三个”重新组合数据。)</div></fieldset>" +
"<fieldset id=\"$$PicView\">" +
"  <legend>图片（宽高为0时不切图）</legend>" +
"<div>宽<input type=\"text\" name=\"$$T0_4\" id=\"$$T0_4\" jTipTitle=\"切图大小\" class=\"jTip\" alt=\"Help/Lists.aspx?action=temhtml-picwidth\" size=\"2\"/>高<input type=\"text\" jTipTitle=\"切图大小\" class=\"jTip\" alt=\"Help/Lists.aspx?action=temhtml-picheight\" name=\"$$T0_5\" id=\"$$T0_5\" size=\"2\"/>&nbsp;<select name=\"$$T0_6\" jTipTitle=\"切图方式\" class=\"jTip\" alt=\"Help/Lists.aspx?action=temhtml-piccuttype\" id=\"$$T0_6\"><option value=\"\">选择切图方式</option><option value=\"cut\">普通切法</option><option value=\"cen\">切取中间</option><option value=\"hwc\">高宽比例</option><option value=\"h\">限制高度</option><option value=\"w\">限制宽度</option></select>&nbsp;&nbsp;<input type=\"checkbox\" jTipTitle=\"切图水印\" class=\"jTip\" alt=\"Help/Lists.aspx?action=temhtml-piclogo\" name=\"$$T0_7\" id=\"$$T0_7\" value=\"1\"/><label for=\"$$T0_7\">添加水印</label></div></fieldset>" +
"</td>" +
"	</tr>" +
"	<tr id=\"$$View1_1\">" +
"		<th align=\"right\"><input type=\"radio\" class=\"radio\" value=\"1\" name=\"$$T1\" id=\"$$T12\" /><label for=\"$$T12\">字符串</label></th>" +
"		<td align=\"left\"><div style=\"float:left;\">长度：<input type=\"Text\" name=\"$$T2_1\" value=\"0\" id=\"$$T2_1\" maxlength=\"10\" size=\"6\" />1个汉字2个字符（0不限制）<input type=\"hidden\" name=\"$$T2_1_1\" id=\"$$T2_1_1\"/></div><div style=\"float:left;\"><input type=\"button\" icon=\"icon-text_fit\" value=\"设置规则\" id=\"$$T2_1_1Button\" onclick=\"InterceptionHtmlFun('$$T2_1_1');\"/>&nbsp;<input type=\"Text\" name=\"$$T2_2\" id=\"$$T2_2\" value=\"...\" maxlength=\"10\" size=\"6\"/>截取补字符。&nbsp;<select name=\"$$T2_3\" id=\"$$T2_3\"></select>&nbsp;<input type=\"checkbox\" name=\"$$T2_4\" id=\"$$T2_4\" value=\"1\"/><label for=\"$$T2_4\">删除\\r\\n</label></div></td>" +
"	</tr>" +
"	<tr id=\"$$View1_2\" disabled=\"true\">" +
"		<th align=\"right\"><input type=\"radio\" class=\"radio\" value=\"2\" name=\"$$T1\" id=\"$$T13\"><label for=\"$$T13\">日期型</label></th>" +
"		<td align=\"left\"><input type=\"Text\" name=\"$$T3_1\" class=\"jTip\" alt=\"Help/Lists.aspx?action=temhtml-timemess\" value=\"YY04-MM-DD\" id=\"$$T3_1\" size=\"25\" />&nbsp;<select name=\"$$T10_1\" id=\"$$T10_1\" onchange=\"$id('$$T3_1').value=this.options[this.selectedIndex].value;\" size=\"1\"></select>&nbsp;时间差输出：<select name=\"$$T3_2\" id=\"$$T3_2\" size=\"1\"></select>" +
"    </td>" +
"	</tr>" +
"	<tr id=\"$$View1_3\" disabled=\"true\">" +
"		<th align=\"right\"><input type=\"radio\" class=\"radio\" value=\"3\" name=\"$$T1\" id=\"$$T14\" /><label for=\"$$T14\">数字型</label></th>" +
"		<td align=\"left\"><input type=\"radio\" class=\"radio\" value=\"0\" checked name=\"$$T4_1\" id=\"$$T4_10\" /><label for=\"$$T4_10\">汉字大写</label>&nbsp;<input type=\"radio\" class=\"radio\" value=\"1\" name=\"$$T4_1\" id=\"$$T4_11\"/><label for=\"$$T4_11\">货币</label>&nbsp;<input type=\"radio\" class=\"radio\" value=\"2\" name=\"$$T4_1\" id=\"$$T4_12\"/><label for=\"$$T4_12\">科学型</label>&nbsp;<input type=\"radio\" class=\"radio\" value=\"3\" name=\"$$T4_1\" id=\"$$T4_13\"/><label for=\"$$T4_13\">逗号分隔</label></td>" +
"	</tr>" +
"	<tr id=\"$$View1_4\" disabled=\"true\">" +
"		<th align=\"right\">附加属性</th>" +
"		<td align=\"left\"><select name=\"$$T15\" id=\"$$T15\" size=\"1\"></select>&nbsp;<input type=\"checkbox\" value=\"1\" name=\"$$T16_2\" id=\"$$T16_2\" /><label for=\"$$T16_2\">输出HTML编码</label>&nbsp;<input type=\"checkbox\" value=\"1\" name=\"$$T16_3\" id=\"$$T16_3\" /><label for=\"$$T16_3\">输出SQL编码（转义'）</label>&nbsp;<input type=\"checkbox\" value=\"1\" name=\"$$T16_1\" id=\"$$T16_1\" /><label for=\"$$T16_1\">输出URL编码</label>&nbsp;<input type=\"checkbox\" value=\"1\" name=\"$$T16\" id=\"$$T16\" /><label for=\"$$T16\">输出JS字符串格式</label></td>" +
"	</tr>" +
"	<tr>" +
"		<th align=\"right\"><input type=\"checkbox\" value=\"1\" name=\"$$T36\" id=\"$$T36\" /><label for=\"$$T36\">生成图片</label><br>将清除所有HTML代码</th>" +
"		<td align=\"left\"><div>" +
"<fieldset style=\"float:left;height:95px;\">" +
"  <legend>类型</legend>"+
"<div>JPG：<input type=\"radio\" id=\"$$T17\" name=\"$$T17\" value=\"jpg\" checked=\"checked\" /></div>" +
"<div>GIF：<input type=\"radio\" id=\"$$T17\" name=\"$$T17\" value=\"gif\" /></div>" +
"<div>PNG：<input type=\"radio\" id=\"$$T17\" name=\"$$T17\" value=\"png\" /></div>" +
"</fieldset>" +
"<fieldset style=\"float:left;margin-left:3px;height:95px;\">" +
"  <legend>字体</legend>" +
"<div>字体：<input type=\"text\" id=\"$$T18\" name=\"$$T18\" size=\"10\" style=\"margin-bottom:2px;\" value=\"宋体\" /></div>" +
"<div>大小：<input type=\"text\" size=\"2\" value=\"12\" id=\"$$T19\" style=\"margin-bottom:2px;\" name=\"$$T19\" /></div>" +
"<div><div style=\"float:left;\">颜色：<input type=\"text\" size=\"7\" value=\"#000000\" onPropertyChange=\"changecolor('$$T20')\" onclick=\"changecolor('$$T20')\" id=\"$$T20\" name=\"$$T20\" /></div><div id=\"$$T20-view\" style=\"background:#000000;float:left;margin-top:3px;\"><img style=\"cursor:pointer;\" onClick=\"DisplayClrDlg('$$T20-view');\" src=\"images/bg.gif\" width=18 height=17></div></div>" +
"</fieldset>" +
"<fieldset style=\"float:left;margin-left:3px;height:95px;\">" +
"  <legend>大小</legend>" +
"<div>宽：<input type=\"text\" value=\"0\" size=\"3\" id=\"$$T21\" style=\"margin-bottom:2px;\" name=\"$$T21\" />px</div>" +
"<div>高：<input type=\"text\" value=\"0\" size=\"3\" id=\"$$T22\" name=\"$$T22\" />px</div>" +
"<div>填写0时会自动计算</div>" +
"</fieldset>" +
"<fieldset style=\"float:left;margin-left:3px;height:95px;\">" +
"  <legend>边距</legend>" +
"<div>上：<input type=\"text\" value=\"0\" size=\"1\" id=\"$$T23\" style=\"margin-bottom:2px;\" name=\"$$T23\" />px</div>" +
"<div>左：<input type=\"text\" value=\"0\" size=\"1\" id=\"$$T24\" name=\"$$T24\" />px</div>" +
"</fieldset>" +
"<fieldset style=\"float:left;margin-left:3px;height:95px;\">" +
"  <legend>效果</legend>" +
"<div>透明：<span style=\"display: inline-block; width: 140px; padding: 0 5px;\"><input type=\"hidden\" value=\"255\" size=\"2\" id=\"$$T27\" style=\"margin-bottom:2px;\" name=\"$$T27\" /></span></div>" +
"<div>阴影：<input type=\"checkbox\" checked value=\"1\" id=\"$$T28\" name=\"$$T28\" /></div>"+
"<div><input type=\"checkbox\" value=\"b\" id=\"$$T29\" name=\"$$T29\" />粗体&nbsp;<input type=\"checkbox\" value=\"i\" id=\"$$T29\" name=\"$$T29\" />斜体&nbsp;<input type=\"checkbox\" value=\"s\" id=\"$$T29\" name=\"$$T29\" />删除&nbsp;<input type=\"checkbox\" value=\"u\" id=\"$$T29\" name=\"$$T29\" />下划</div>" +
"</fieldset>" +
"</div>" +
"<div style=\"clear:both;\">" +
"<fieldset>" +
"  <legend>底纹</legend>" +
"<div><div style=\"float:left;\">颜色：<input type=\"text\" size=\"7\" id=\"$$T25\" onPropertyChange=\"changecolor('$$T25')\" onclick=\"changecolor('$$T25')\" name=\"$$T25\" style=\"margin-bottom:2px;\" value=\"#FFFFFF\" /></div><div id=\"$$T25-view\" style=\"background:#ffffff;float:left;margin-top:3px;\"><img style=\"cursor:pointer;\" onClick=\"DisplayClrDlg('$$T25-view');\" src=\"images/bg.gif\" width=18 height=17></div><div style=\"float:left;\">[空时PNG为透明，其它为白。]&nbsp;如上传了图片颜色将失效。</div></div>" +
"<div style=\"clear:both;\"><div style=\"float:left;\">图片：<input type=\"text\" size=\"40\" id=\"$$T26\" name=\"$$T26\" /></div><div style=\"float:left;\"><input type=\"button\" value=\"上传图片\" onclick=\"UploadFile('$$T26','PIC', 'IsStyle=1&Listid='+$('#YQ_listID').val());\" icon=\"icon-picture_add\" /></div><div style=\"float:left;\"><input type=\"button\" value=\"选择图片\" onclick=\"DirImgWin($id('$$T26'),$('#YQ_listID').val(),'IsStyle=1');\" icon=\"icon-pictures\" /></div></div>" +
"</fieldset>" +
"</div></td>" +
"	</tr>" +
"</table></div>");


var LabelNavigateHtml = new Array("面包屑导航", 920, 370, 0, "<div style=\"width:920px;height:370px;overflow:auto;overflow-x:hidden;\">" +
"<table border=\"0\" width=\"100%\" cellspacing=\"0\" class=\"StyleView\" id=\"$$StyleView\" style=\"width:100%;\" cellpadding=\"0\">" +
"	<tr>" +
"		<th align=\"right\" style=\"width:75px;\">数据模型：</th>" +
"		<td align=\"left\"><select name=\"$$T1\" id=\"$$T1\" onchange=\"Label_Sell_Mdb(this,'$$',1)\" size=1></select></td>" +
"	</tr>" +
"	<tr>" +
"		<th align=\"right\">显示方式：</th>" +
"		<td align=\"left\">&nbsp;<input type=\"radio\" value=\"0\" class=\"radio\" checked name=\"$$T3\" id=\"$$T3_1\"/><label for=\"$$T3_1\">顺序（由大到小）</label>&nbsp;&nbsp;&nbsp;<input type=\"radio\" value=\"1\" class=\"radio\" name=\"$$T3\" id=\"$$T3_2\"/><label for=\"$$T3_2\">倒序（由小到大）</label></td>" +
"	</tr>" +
"	<tr>" +
"		<th align=\"right\">字段设置：</th>" +
"		<td align=\"left\">&nbsp;标题：<select name=\"$$T66_1\" id=\"$$T66_1\" size=\"1\"></select>&nbsp;&nbsp;地址：<select name=\"$$T66_2\" id=\"$$T66_2\" size=\"1\"></select>&nbsp;标题附加功能：<select name=\"$$T666_3\" id=\"$$T666_3\" size=\"1\"></select></td>" +
"	</tr>" +
"	<tr>" +
"		<th align=\"right\">查询条件：<br/><input type=\"checkbox\" id=\"$$T4_100Check\" onclick=\"if(this.checked){$('#$$OldAT').show();$('#$$NewAT').hide();}else{$('#$$NewAT').show();$('#$$OldAT').hide();}\" /><label for=\"$$T4_100Check\">高级模式</label></th>" +
"		<td align=\"left\"><div id=\"$$OldAT\" style=\"display:none;\"><table border=\"0\" class=\"nb\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\"><tr>" +
"		<td width=\"480px;\"><select size=\"12\" style=\"width:468px;height:130px\" name=\"$$T4\" onchange=\"ATfun('$$');\" id=\"$$T4\"></td>" +
"		<td style=\"line-height:25px;\"><fieldset><legend>位置</legend><input type=\"button\" name=\"$$T4Sub2\" icon=\"icon-prev\" id=\"$$T4Sub2\" value=\"向上\"/><input type=\"button\" name=\"$$T4Sub3\" id=\"$$T4Sub3\" icon=\"icon-next\" value=\"向下\"/><input type=\"button\" name=\"$$T4Sub5\" id=\"$$T4Sub5\" icon=\"icon-delete\" onclick=\"AtDel('$$','4');\" value=\"删除选定项\"/></fieldset><fieldset><legend>关系</legend><input type=\"radio\" name=\"$$T4_Sub1\" onclick=\"AtAndOrfun('$$', '4','AND')\" id=\"$$T4_Sub1_0\"/><label for=\"$$T4_Sub1_0\">并且</label>&nbsp;&nbsp;<input type=\"radio\" name=\"$$T4_Sub1\" onclick=\"AtAndOrfun('$$', '4','OR')\" id=\"$$T4_Sub1_1\"/><label for=\"$$T4_Sub1_1\">或者</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type=\"checkbox\" name=\"$$T4_Sub2\" id=\"$$T4_Sub2\" onclick=\"AtLikeFun('$$', '4', this, '(')\"/><label for=\"$$T4_Sub2\">左括号（</label>&nbsp;<input type=\"checkbox\" name=\"$$T4_Sub3\" onclick=\"AtLikeFun('$$', '4', this, ')')\" id=\"$$T4_Sub3\"/><label for=\"$$T4_Sub3\">右括号）</label></fieldset></td>" +
"	        </tr>" +
"	        <tr>" +
"		<td colspan=2><div style=\"float:left;padding:3px;\">&nbsp;<select size=\"1\" name=\"$$T4_2\" style=\"width:150px;\" onchange=\"LabelJudgeChange(this,'$$')\" id=\"$$T4_2\">" +
"       </select><select name=\"$$T4_3\" id=\"$$T4_3\" size=\"1\" style=\"display:none;width:150px;\" onchange=\"LabelJudgeChange1(this,'$$')\">" +
"        </select><input type=\"Text\" size=50 id=\"$$T4_4\" jTipTitle=\"规则\" class=\"jTip\" alt=\"Help/Lists.aspx?action=temhtml-atspace\" style=\"display:none;\" name=\"$$T4_4\"/><select onchange=\"LabelJudgeChange2(this,'$$')\" name=\"$$T4_5\" id=\"$$T4_5\" style=\"display:none;\" size=\"1\"></select></div>" +
"        <div style=\"float:left;\"><input type=\"button\" name=\"Submit\" icon=\"icon-add\" onclick=\"AddValue1('$$','4')\" value=\"添加\"/></div><div style=\"float:left;display:none;padding-left:3px;\" id=\"$$T4_View\"><input type=\"button\" name=\"Submit\" onclick=\"AddValue1('$$','4',$id('$$T4_View'))\" icon=\"icon-edit\" value=\"修改\"/></div></td>" +
"           </tr></table></div><div id=\"$$NewAT\"><span id=\"$$T4_100Span\"></span><input type=\"hidden\" name=\"$$T4_100\" id=\"$$T4_100\" style=\"width:460px;\" /></div></td>" +
"	</tr>" +
"	<tr>" +
"		<th align=\"right\">跳过条件：</th>" +
"		<td align=\"left\"><table border=\"0\" class=\"nb\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">" +
"	<tr>" +
"		<td width=\"480px;\"><select size=\"12\" style=\"width:468px;height:130px\" name=\"$$T6\" onchange=\"ATfun('$$','6');\" id=\"$$T6\"></td>" +
"		<td style=\"line-height:25px;\"><fieldset><legend>位置</legend><input type=\"button\" name=\"$$T6Sub2\" icon=\"icon-prev\" id=\"$$T6Sub2\" value=\"向上\"/><input type=\"button\" name=\"$$T6Sub3\" id=\"$$T6Sub3\" icon=\"icon-next\" value=\"向下\"/><input type=\"button\" name=\"$$T6Sub5\" id=\"$$T6Sub5\" icon=\"icon-delete\" onclick=\"AtDel('$$','6');\" value=\"删除选定项\"/></fieldset><fieldset><legend>关系</legend><input type=\"radio\" name=\"$$T6_Sub1\" onclick=\"AtAndOrfun('$$', '6','AND')\" id=\"$$T6_Sub1_0\"/><label for=\"$$T6_Sub1_0\">并且</label>&nbsp;&nbsp;<input type=\"radio\" name=\"$$T6_Sub1\" onclick=\"AtAndOrfun('$$', '6','OR')\" id=\"$$T6_Sub1_1\"/><label for=\"$$T6_Sub1_1\">或者</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type=\"checkbox\" name=\"$$T6_Sub2\" id=\"$$T6_Sub2\" onclick=\"AtLikeFun('$$', '6', this, '(')\"/><label for=\"$$T6_Sub2\">左括号（</label>&nbsp;<input type=\"checkbox\" name=\"$$T6_Sub3\" onclick=\"AtLikeFun('$$', '6', this, ')')\" id=\"$$T6_Sub3\"/><label for=\"$$T6_Sub3\">右括号）</label></fieldset></td>" +
"	</tr>" +
"	<tr>" +
"		<td colspan=2><div style=\"float:left;padding:3px;\">&nbsp;<select size=\"1\" name=\"$$T6_2\" style=\"width:150px;\" onchange=\"LabelJudgeChange(this,'$$','6')\" id=\"$$T6_2\">" +
"	</select><select name=\"$$T6_3\" id=\"$$T6_3\" size=\"1\" style=\"display:none;width:150px;\" onchange=\"LabelJudgeChange1(this,'$$','6')\">" +
"        </select><input type=\"Text\" size=50 id=\"$$T6_4\" jTipTitle=\"规则\" class=\"jTip\" alt=\"Help/Lists.aspx?action=temhtml-atspace\" style=\"display:none;\" name=\"$$T6_4\"/><select onchange=\"LabelJudgeChange2(this,'$$','6')\" name=\"$$T6_5\" id=\"$$T6_5\" style=\"display:none;\" size=\"1\"></select></div>" +
"        <div style=\"float:left;\"><input type=\"button\" name=\"Submit\" icon=\"icon-add\" onclick=\"AddValue1('$$','6')\" value=\"添加\"/></div><div style=\"float:left;display:none;padding-left:3px;\" id=\"$$T6_View\"><input type=\"button\" name=\"Submit\" onclick=\"AddValue1('$$','6',$id('$$T6_View'))\" icon=\"icon-edit\" value=\"修改\"/></div></td>" +
"	</tr>" +
"	</table></td>" +
"	</tr>" +
"	<tr>" +
"		<th align=\"right\">分隔符号：</th>" +
"		<td align=\"left\">&nbsp;<input type=\"Text\" size=50 name=\"$$T5\" id=\"$$T5\" value=\" &gt;&gt \"/></td>" +
"	</tr>" +
"	<tr>" +
"		<th align=\"right\">当前样式：</th>" +
"		<td align=\"left\">&nbsp;<input type=\"Text\" size=50 name=\"$$T55\" id=\"$$T55\"/></td>" +
"	</tr>" +
"</table>" +
"</div>");


var LabelFactor_ORHtml = new Array("或者为真设置", 500, 265, 0, "<div style=\"width:500px;height:265px;\"><table border=\"0\" cellspacing=\"0\" class=\"StyleView\" width=\"100%\" height=\"100%\" cellpadding=\"0\">" +
"	<tr>" +
"		<th align=right>说明：</th>" +
"		<td><input type=\"text\" name=\"$$T1Help\" id=\"$$T1Help\" size=100></td>" +
"	</tr>" +
"	<tr>" +
"		<th align=right>值：</th>" +
"		<td><textarea rows=\"10\" name=\"$$T1\" id=\"$$T1\" style=\"width:400px;height:190px;\" cols=\"44\"></textarea><br>依“||”分隔各值。前值为空使用后值，依次类推。</td>" +
"	</tr>" +
"</table></div>");

var LabelFactor_ForHtml = new Array("根据循环条件显示", 700, 435, 0, "<div style=\"width:700px;height:435px;\"><table border=\"0\" cellspacing=\"0\" class=\"StyleView\" width=\"100%\" cellpadding=\"0\">" +
"	<tr>" +
"		<th align=right>说明：</th>" +
"		<td><input type=\"text\" name=\"$$T1Help\" id=\"$$T1Help\" size=100></td>" +
"	</tr>" +
"	</table>" +
"<div class=\"WinRtop\" id=\"$$tabs\"><a href=\"#$$tab1\">数字循环</a><a href=\"#$$tab2\">拆分循环</a><a href=\"#$$tab3\">其它循环</a></div>" +
"    <div class=\"tab_container\">" +
"        <div id=\"$$tab1\" class=\"$$tab_content\"><table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"StyleView\" width=\"100%\" height=\"100%\">" +
"	<tr>" +
"		<th align=right width=\"60px\">条件：</th>" +
"		<td align=left>从<input type=\"Text\" name=\"$$T01_0\" id=\"$$T01_0\" size=\"2\" style=\"width:160px;\" value=\"1\"/>到<input type=\"Text\" name=\"$$T01_1\" id=\"$$T01_1\" size=\"2\" style=\"width:160px;\" value=\"1\"/>；递增<input type=\"Text\" name=\"$$T01_2\" id=\"$$T01_2\" size=\"2\" style=\"width:160px;\" value=\"1\"/></td>" +
"	</tr>" +
"	<tr>" +
"		<th align=right>循环：</th>" +
"		<td><div id=\"$$T02Viewtab\" style=\"width:140px;height:315px;float:right;text-align:left;padding-left:3px;margin-left:3px;overflow-y:auto;overflow-x:hidden\"></div><div style=\"float:left;\"><div class=\"TextAreaSyCms\" style=\"width:460px;height:315px;\"><div id=\"$$T02_Line\" class=\"TextAreaSyCmsLine TextAreaSyCmsFont\"></div><" + InterVeersionDiv + " id=\"$$T02_Bg\" style=\"width:425px;\" class=\"TextAreaSyCmsPackage TextAreaSyCmsFont\"></" + InterVeersionDiv + "><textarea rows=\"8\" wrap=\"off\" class=\"TextArea TextAreaSyCmsFont\" name=\"$$T02\" id=\"$$T02\" style=\"width:425px;height:315px;\" cols=\"40\"></textarea></div></div></td>" +
"	</tr>" +
"</table>" +
"</div>" +
"        <div id=\"$$tab2\" class=\"$$tab_content\" style=\"display:none;\"><table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"StyleView\" width=\"100%\" height=\"100%\">" +
"	<tr>" +
"		<th align=right width=\"60px\">条件：</th>" +
"		<td align=left>把<input type=\"Text\" name=\"$$T11_0\" id=\"$$T11_0\" size=\"2\" style=\"width:300px;\" value=\"\"/>依<input type=\"Text\" name=\"$$T11_1\" id=\"$$T11_1\" size=\"2\" style=\"width:200px;\" value=\",\"/>分隔；<br\>" +
"    <input type=\"checkbox\" name=\"$$T11_2\" id=\"$$T11_2\"/>倒序输出（<input type=\"checkbox\" name=\"$$T11_5\" id=\"$$T11_5\"/>顺序号不变）；取<input type=\"Text\" name=\"$$T11_3\" id=\"$$T11_3\" style=\"width:120px;\" size=\"5\" value=\"0\" style=\"width:30px;\"/>个；从<input type=\"Text\" style=\"width:120px;\" name=\"$$T11_4\" id=\"$$T11_4\" size=\"5\" value=\"0\" style=\"width:30px;\"/>开始；去除重复：<input type=\"checkbox\" name=\"$$T11_6\" id=\"$$T11_6\"/></td>" +
"	</tr>" +
"	<tr>" +
"		<th align=right>循环：</th>" +
"		<td><div id=\"$$T12Viewtab\" style=\"width:140px;height:290px;float:right;text-align:left;padding-left:3px;margin-left:3px;overflow-y:auto;overflow-x:hidden\"></div><div style=\"float:left;\"><div class=\"TextAreaSyCms\" style=\"width:460px;height:290px;\"><div id=\"$$T12_Line\" class=\"TextAreaSyCmsLine TextAreaSyCmsFont\"></div><" + InterVeersionDiv + " id=\"$$T12_Bg\" style=\"width:425px;\" class=\"TextAreaSyCmsPackage TextAreaSyCmsFont\"></" + InterVeersionDiv + "><textarea rows=\"8\" wrap=\"off\" class=\"TextArea TextAreaSyCmsFont\" name=\"$$T12\" id=\"$$T12\" style=\"width:425px;height:290px;\" cols=\"40\"></textarea></div></div></td>" +
"	</tr>" +
"</table>" +
"</div>" +
"        <div id=\"$$tab3\" class=\"$$tab_content\" style=\"display:none;\"><table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"StyleView\" width=\"100%\" height=\"100%\">" +
"	<tr>" +
"		<th align=right width=\"60px\">循环：</th>" +
"		<td align=left><input type=\"Text\" name=\"$$T1\" id=\"$$T1\" size=\"2\" style=\"width:20px;\" value=\"0\"/>注：0：循环一次；1：重复循环；>=2为从>=2位置开始循环。</td>" +
"	</tr>" +
"	<tr>" +
"		<th align=right>值：</th>" +
"		<td><div id=\"$$T2Viewtab\" style=\"width:140px;height:300px;float:right;text-align:left;padding-left:3px;margin-left:3px;overflow-y:auto;overflow-x:hidden\"></div><div style=\"float:left;\"><div class=\"TextAreaSyCms\" style=\"width:460px;height:300px;\"><div id=\"$$T2_Line\" class=\"TextAreaSyCmsLine TextAreaSyCmsFont\"></div><" + InterVeersionDiv + " id=\"$$T2_Bg\" style=\"width:425px;\" class=\"TextAreaSyCmsPackage TextAreaSyCmsFont\"></" + InterVeersionDiv + "><textarea rows=\"8\" wrap=\"off\" class=\"TextArea TextAreaSyCmsFont\" name=\"$$T2\" id=\"$$T2\" style=\"width:425px;height:300px;\" cols=\"40\"></textarea></div></div><div style=\"clear:both;\">依“||”分隔各值。</div></td>" +
"	</tr>" +
"</table>" +
"</div>" +
"</div>" +
"</div>");

var LabelFactor_IfHtml = new Array("IF语句", 900, 580, 1, "<div id=\"$$LabelList\" style=\"word-break:break-all;table-layout:fixed;z-index:0;height:$:0:$px;\"><table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"StyleView\" width=\"100%\">" +
"	<tr>" +
"		<th align=right>说明：</th>" +
"		<td><input type=\"text\" name=\"$$T1Help\" id=\"$$T1Help\" size=100></td>" +
"	</tr>" +
"	<tr>" +
"		<td colspan=\"2\" align=left><div id=\"$$ValueView\" style=\"height:$:195:$px;overflow:scroll;overflow-x:hidden;text-align:left;\"></div></td>" +
"	</tr>" +
"	<tr>" +
"		<th align=right width=\"40\">否则：</th>" +
"		<td align=left><div id=\"$$T40View1\" style=\"width:170px;height:110px;float:right;text-align:left;padding-left:3px;margin-left:3px;overflow-y:auto;overflow-x:hidden\"></div>" +
"       <div style=\"float:left;\"><div class=\"TextAreaSyCms\" style=\"width:650px;height:100px;\"><div id=\"$$T40_Line\" class=\"TextAreaSyCmsLine TextAreaSyCmsFont\"></div><" + InterVeersionDiv + " id=\"$$T40_Bg\" style=\"width:615px;\" class=\"TextAreaSyCmsPackage TextAreaSyCmsFont\"></" + InterVeersionDiv + "><textarea rows=\"4\" name=\"$$T40\" id=\"$$T40\" wrap=\"off\" class=\"TextArea TextAreaSyCmsFont\" style=\"width:615px;height:100px;\" cols=\"44\"></textarea></div><br/>（可以不填写。）</div></td>" +
"	</tr>" +
"</table></div>");

var LabelGetHtml = new Array("网页传值（GET、POST）", 500, 270, 1, "<div style=\"width:500px;height:270px;\"><table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"StyleView\" style=\"width:100%;height:100%;\">" +
"	<tr>" +
"		<th align=right width=\"70px;\">传值名称：</th>" +
"		<td align=left><input type=\"text\" name=\"$$T3\" id=\"$$T3\" style=\"width:200px;\" size=\"8\" />&nbsp;<select name=\"$$T3_1\" id=\"$$T3_1\" style=\"width:130px;\"><option value=\"\">可选的验证方式</option><option value=\"1\">数字</option><option value=\"3\">日期</option></select></td>" +
"	</tr>" +
"   <tr><td colspan=\"2\"><fieldset style=\"padding:0px;margin:0px;\">" +
"  <legend>高级属性</legend><table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"StyleView\" style=\"width:100%;height:100%;border-left:0px;padding:0px;margin:0px;\">" +
"	<tr>" +
"		<th align=right width=\"70px\">特殊取值：</th>" +
"		<td align=left style=\"border-right:0px\"><input type=\"text\" name=\"$$T4\" id=\"$$T4\" style=\"width:50px;\" size=\"8\" />取结果值（只支持数字），如a0b1，取b即输出1。</td>" +
"	</tr>" +
"	<tr>" +
"		<th align=right>分隔取值：</th>" +
"		<td align=left style=\"border-right:0px\">用<input type=\"text\" name=\"$$T17_1\" id=\"$$T17_1\" size=\"2\"/>分隔取<input type=\"text\" name=\"$$T17_2\" id=\"$$T17_2\" size=\"2\"/>个其余用<input type=\"text\" name=\"$$T17_3\" id=\"$$T17_3\" size=\"2\"/>填充</div><br>(“第三个”为空时，显示“第二个”位置的值；不为空时，“第二个”前面为原数据，后面用“第三个”补全。“第二个”为空时“第三个”不为空时用“第三个”重新组合数据。)</td>" +
"	</tr>" +
"	<tr>" +
"		<th align=right style=\"border:0px\">附加属性：</th>" +
"		<td align=left style=\"border:0px\"><input type=\"checkbox\" value=\"1\" name=\"$$T16_2\" id=\"$$T16_2\" /><label for=\"$$T16_2\">HTML编码</label>&nbsp;<input type=\"checkbox\" value=\"1\" name=\"$$T16_3\" id=\"$$T16_3\" /><label for=\"$$T16_3\">SQL编码(转义')</label>&nbsp;<input type=\"checkbox\" value=\"1\" name=\"$$T16_1\" id=\"$$T16_1\" /><label for=\"$$T16_1\">URL编码</label>&nbsp;<input type=\"checkbox\" value=\"1\" name=\"$$T16\" id=\"$$T16\" /><label for=\"$$T16\">JS字符串格式</label></td>" +
"	</tr>" +
"	<tr>" +
"		<th align=right style=\"border:0px\">转换：</th>" +
"		<td align=left style=\"border:0px\"><select name=\"$$T20_1\" id=\"$$T20_1\"></select></td>" +
"	</tr>" +
"</table></fieldset></td></tr>"+
"</table></div>");

var LabelSysHtml = new Array("系统变量", 400, 200, 1, "<div style=\"height:$:0:$px;overflow:scroll;overflow-x:hidden;\"><table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"StyleView\" id=\"$$StyleView\" style=\"width:100%;\">" +
"	<tr>" +
"		<th align=right width=\"70px;\">变量选择：</th>" +
"		<td align=left><select name=\"$$T1\" id=\"$$T1\" onchange=\"SysHtmlFun(this,'$$');\" style=\"width:260px;\" size=8></select></td>" +
"	</tr>" +
"	<tr id=\"$$T2_0View\">" +
"		<th align=right>获取方式：</th>" +
"		<td align=left><input type=\"radio\" id=\"$$T2_0\" checked=\"true\" name=\"$$T2\" value=\"0\"/><label for=\"$$T2_0\">普通</label>&nbsp;<input type=\"radio\" id=\"$$T2_1\" name=\"$$T2\" value=\"1\"/><label for=\"$$T2_1\">JS取值</label></td>" +
"	</tr>" +
"	<tr id=\"$$T0_0View\" class=\"$$View\" style=\"display:none;\">" +
"		<th align=right>几级栏目：</th>" +
"		<td align=left><input type=\"text\" id=\"$$T0_0\" value=\"1\" name=\"$$T0_0\"/></td>" +
"	</tr>" +
"	<tr id=\"$$T0_1View\" class=\"$$View\" style=\"display:none;\">" +
"		<th align=right>类型：</th>" +
"		<td align=left><input type=\"radio\" id=\"$$T0_1_0\" checked=\"true\" name=\"$$T0_1\" value=\"Category\"/><label for=\"$$T0_1_0\">栏目</label>&nbsp;<input type=\"radio\" id=\"$$T0_1_1\" name=\"$$T0_1\" value=\"Special\"/><label for=\"$$T0_1_1\">专题栏目</label></td>" +
"	</tr>" +
"	<tr id=\"$$T0_2View\" class=\"$$View\" style=\"display:none;\">" +
"		<th align=right>判断值：</th>" +
"		<td align=left><input type=\"radio\" id=\"$$T0_2_0\" checked=\"true\" name=\"$$T0_2\" value=\"%3Csycms%20type%3D%22Word%22%20name%3D%22C.ClassId%22%20%2F%3E\"/><label for=\"$$T0_2_0\">栏目ID</label>&nbsp;<input type=\"radio\" id=\"$$T0_2_1\" name=\"$$T0_2\" value=\"%3Csycms%20type%3D%22Word%22%20name%3D%22S.ClassId%22%20%2F%3E\"/><label for=\"$$T0_2_1\">专题栏目ID</label></td>" +
"	</tr>" +
"	<tr id=\"$$T0_3View\" class=\"$$View\" style=\"display:none;\">" +
"		<th align=right>日期格式：</th>" +
"		<td align=left><input type=\"Text\" size=\"20\" class=\"jTip\" alt=\"Help/Lists.aspx?action=temhtml-timemess\" name=\"$$T0_3\" id=\"$$T0_3\">&nbsp;<select name=\"$$T0_3_1\" id=\"$$T0_3_1\" onchange=\"$id('$$T0_3').value=this.options[this.selectedIndex].value;\" style=\"width:150px;\" size=\"1\"></select>"+
"<br/>追加<input type=\"Text\" size=\"5\" name=\"$$T0_4\" value=\"0\" id=\"$$T0_4\"><select name=\"$$T0_5\" id=\"$$T0_5\" size=\"1\"><option value=\"Year\">年</option><option value=\"Month\">月</option><option value=\"Day\">天</option><option value=\"Hour\">时</option><option value=\"Minute\">分</option></select>" +
"    </td>" +
"	</tr>" +
"</table></div>");

var LabelCookieHtml = new Array("读取缓存", 360, 135, 1, "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"StyleView\" id=\"$$StyleView\" style=\"width:100%;height:100%;\">" +
"	<tr>" +
"		<th align=right width=\"70px;\">变量名字：</th>" +
"		<td align=left><input type=\"text\" name=\"$$T0\" size=\"15\" id=\"$$T0\"/>&nbsp;<select name=\"$$T1\" style=\"width:150px;\" onchange=\"$('#$$T0').val($(this).val());\" id=\"$$T1\"><option value=\"\">请选择系统自带</option><option value=\"UserId\">用户ID</option><option value=\"UserName\">用户名称</option><option value=\"UserFaceUrl\">用户头像</option><optgroup label=\"后台登录信息\"><option value=\"UserInfo\">后台用户信息数组[0:用户ID，1:用户名，2:用户角色]</option></optgroup></select></td>" +
"	</tr>" +
"	<tr>" +
"		<th align=right>获取类型：</th>" +
"		<td align=left><input type=\"radio\" id=\"$$T3_0\" checked=\"true\" onclick=\"FirefoxDisabled('$$StyleViewTr');FirefoxDisabled('$$ArrayViewTr',1);\" name=\"$$T3\" value=\"0\"/><label for=\"$$T3_0\">Session</label>&nbsp;<input type=\"radio\" id=\"$$T3_1\" onclick=\"FirefoxDisabled('$$StyleViewTr',1);FirefoxDisabled('$$ArrayViewTr');\" name=\"$$T3\" value=\"1\"/><label for=\"$$T3_1\">Cookies</label></td>" +
"	</tr>" +
"	<tr id=\"$$ArrayViewTr\">" +
"		<th align=right>数组：</th>" +
"		<td align=left><input type=\"text\" id=\"$$T4\" name=\"$$T4\"/>：位置</td>" +
"	</tr>" +
"	<tr id=\"$$StyleViewTr\">" +
"		<th align=right>获取方式：</th>" +
"		<td align=left><input type=\"radio\" id=\"$$T2_0\" checked=\"true\" name=\"$$T2\" value=\"0\"/><label for=\"$$T2_0\">普通</label>&nbsp;<input type=\"radio\" id=\"$$T2_1\" name=\"$$T2\" value=\"1\"/><label for=\"$$T2_1\">JS取值</label></td>" +
"	</tr>" +
"</table>");

var LabelVarValueHtml = new Array("设置变量", 900, 400, 1,"<table border=\"0\" cellspacing=\"0\" class=\"StyleView\" style=\"width:100%;height:100%;\" cellpadding=\"0\">" +
"	<tr>" +
"		<th height=\"35\" align=right width=\"70px;\">变量名字：</th>" +
"		<td align=left><span style=\"float:right;padding-right:15px;\"><select name=\"$$T0_0\" id=\"$$T0_0\"/><option value=\"\">定义变量</option><option value=\"Add\">追加值(,分隔)[常规调用有效]</option><option value=\"True\">替换上级同名变量</option></select></span><input type=\"text\" name=\"$$T0\" size=\"25\" id=\"$$T0\"/></td>" +
"	</tr><tr><td colspan=\"2\" valign=\"top\"><div class=\"WinRtop\" id=\"$$Tabletabs\"><a href=\"#$$Tabletab1\">常规调用</a><a href=\"#$$Tabletab2\">条件调用</a></div>" +
"    <div class=\"Tabletab_container\">" +
"<table border=\"0\" cellspacing=\"0\" id=\"$$Tabletab1\" class=\"StyleView $$Tabletab_content\" style=\"width:100%;\" cellpadding=\"0\">" +
"	<tr>" +
"		<th align=right>变量值：</th>" +
"		<td align=left><div id=\"$$T001View_1\" style=\"width:150px;height:200px;float:right;text-align:left;padding-left:3px;overflow-y:auto;overflow-x:hidden\"></div><div style=\"float:left;\"><div class=\"TextAreaSyCms\" style=\"width:645px;height:300px;\"><div id=\"$$T001_Line\" class=\"TextAreaSyCmsLine TextAreaSyCmsFont\"></div><" + InterVeersionDiv + " id=\"$$T001_Bg\" style=\"width:610px;\" class=\"TextAreaSyCmsPackage TextAreaSyCmsFont\"></" + InterVeersionDiv + "><textarea rows=\"4\" name=\"$$T001\" id=\"$$T001\" IsList=\"0\" wrap=\"off\" class=\"TextArea TextAreaSyCmsFont\" style=\"width:610px;height:300px;\" cols=\"44\"></textarea></div></div></td>" +
"	</tr>" +
"</table><table border=\"0\" width=\"100%\" cellspacing=\"0\" id=\"$$Tabletab2\" class=\"StyleView $$Tabletab_content\" style=\"width:100%;\" cellpadding=\"0\">" +
"	<tr>" +
"		<th align=\"right\" style=\"width:75px;\">数据模型：</th>" +
"		<td align=\"left\"><select name=\"$$T1\" id=\"$$T1\" onchange=\"Label_Sell_Mdb(this,'$$',1)\" size=1></select></td>" +
"	</tr>" +
"	<tr>" +
"		<th align=\"right\">查询条件：<br/><input type=\"checkbox\" id=\"$$T4_100Check\" onclick=\"if(this.checked){$('#$$OldAT').show();$('#$$NewAT').hide();}else{$('#$$NewAT').show();$('#$$OldAT').hide();}\" /><label for=\"$$T4_100Check\">高级模式</label></th>" +
"		<td align=\"left\"><div id=\"$$OldAT\" style=\"display:none;\"><table border=\"0\" class=\"nb\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\"><tr>" +
"		<td width=\"480px;\"><select size=\"12\" style=\"width:468px;height:130px\" name=\"$$T4\" onchange=\"ATfun('$$');\" id=\"$$T4\"></td>" +
"		<td style=\"line-height:25px;\"><fieldset><legend>位置</legend><input type=\"button\" name=\"$$T4Sub2\" icon=\"icon-prev\" id=\"$$T4Sub2\" value=\"向上\"/><input type=\"button\" name=\"$$T4Sub3\" id=\"$$T4Sub3\" icon=\"icon-next\" value=\"向下\"/><input type=\"button\" name=\"$$T4Sub5\" id=\"$$T4Sub5\" icon=\"icon-delete\" onclick=\"AtDel('$$','4');\" value=\"删除选定项\"/></fieldset><fieldset><legend>关系</legend><input type=\"radio\" name=\"$$T4_Sub1\" onclick=\"AtAndOrfun('$$', '4','AND')\" id=\"$$T4_Sub1_0\"/><label for=\"$$T4_Sub1_0\">并且</label>&nbsp;&nbsp;<input type=\"radio\" name=\"$$T4_Sub1\" onclick=\"AtAndOrfun('$$', '4','OR')\" id=\"$$T4_Sub1_1\"/><label for=\"$$T4_Sub1_1\">或者</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type=\"checkbox\" name=\"$$T4_Sub2\" id=\"$$T4_Sub2\" onclick=\"AtLikeFun('$$', '4', this, '(')\"/><label for=\"$$T4_Sub2\">左括号（</label>&nbsp;<input type=\"checkbox\" name=\"$$T4_Sub3\" onclick=\"AtLikeFun('$$', '4', this, ')')\" id=\"$$T4_Sub3\"/><label for=\"$$T4_Sub3\">右括号）</label></fieldset></td>" +
"	        </tr>" +
"	        <tr>" +
"		<td colspan=2><div style=\"float:left;padding:3px;\">&nbsp;<select size=\"1\" name=\"$$T4_2\" onchange=\"LabelJudgeChange(this,'$$')\" id=\"$$T4_2\">" +
"       </select><select name=\"$$T4_3\" id=\"$$T4_3\" size=\"1\" style=\"display:none;\" onchange=\"LabelJudgeChange1(this,'$$')\">" +
"        </select><input type=\"Text\" size=50 id=\"$$T4_4\" jTipTitle=\"规则\" class=\"jTip\" alt=\"Help/Lists.aspx?action=temhtml-atspace\" style=\"display:none;\" name=\"$$T4_4\"/><select onchange=\"LabelJudgeChange2(this,'$$')\" name=\"$$T4_5\" id=\"$$T4_5\" style=\"display:none;\" size=\"1\"></select></div>" +
"        <div style=\"float:left;\"><input type=\"button\" name=\"Submit\" icon=\"icon-add\" onclick=\"AddValue1('$$','4')\" value=\"添加\"/></div><div style=\"float:left;display:none;padding-left:3px;\" id=\"$$T4_View\"><input type=\"button\" name=\"Submit\" onclick=\"AddValue1('$$','4',$id('$$T4_View'))\" icon=\"icon-edit\" value=\"修改\"/></div></td>" +
"           </tr></table></div><div id=\"$$NewAT\"><span id=\"$$T4_100Span\"></span><input type=\"hidden\" name=\"$$T4_100\" id=\"$$T4_100\" style=\"width:460px;\" /></div></td>" +
"	</tr>" +
"	<tr>" +
"		<td align=\"left\" colspan=\"2\">注：此只取一条记录信息。</td>" +
"	</tr>" +
"</table></td></tr>" +
"</table>");


var LabelVarHtml = new Array("选择变量", 350, 210, 1, "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"StyleView\" id=\"$$StyleView\" style=\"width:100%;height:100%;\">" +
"	<tr>" +
"		<th align=right width=\"70px;\">变量列表：</th>" +
"		<td align=left><select name=\"$$T0\" id=\"$$T0\" style=\"width:260px;height:100px;\" size=12></select><div style=\"padding-top:10px;\"><input type=\"hidden\"  name=\"$$T1\" id=\"$$T1\" /><input type=\"button\" icon=\"icon-text_fit\" value=\"设置规则\" id=\"$$T0Button\" onclick=\"VarFormatFun('$$','T0','T1')\"/></div></td>" +
"	</tr>" +
"	<tr>" +
"		<th align=right>附加属性：</th>" +
"		<td align=left><input type=\"checkbox\" value=\"1\" name=\"$$T16_2\" id=\"$$T16_2\" /><label for=\"$$T16_2\">HTML编码</label>&nbsp;<input type=\"checkbox\" value=\"1\" name=\"$$T16_3\" id=\"$$T16_3\" /><label for=\"$$T16_3\">SQL编码(转义')</label>&nbsp;<input type=\"checkbox\" value=\"1\" name=\"$$T16_1\" id=\"$$T16_1\" /><label for=\"$$T16_1\">URL编码</label>&nbsp;<input type=\"checkbox\" value=\"1\" name=\"$$T16\" id=\"$$T16\" /><label for=\"$$T16\">JS字符串格式</label></td>" +
"	</tr>" +
"</table>");


var InterceptionHtml = new Array("截取字段串", 650, 250, 1, "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"StyleView\" id=\"$$StyleView\" style=\"width:100%;height:100%;\">" +
"	<tr>" +
"		<th align=\"left\" colspan=5><input type=\"checkbox\" name=\"$$T100_1\" id=\"$$T100_1\" onclick=\"if(this.checked){FirefoxDisabled('$$T1000_1');FirefoxDisabled('$$T1000_2');FirefoxDisabled('$$T1000_3');FirefoxDisabled('$$T1000_4');}else{FirefoxDisabled('$$T1000_1',1);FirefoxDisabled('$$T1000_2',1);FirefoxDisabled('$$T1000_3',1);FirefoxDisabled('$$T1000_4',1);}\" value=\"1\" size=\"25\"/><label for=\"$$T100_1\">截取英文字母（将自动按单词截取）</label></th>" +
"	</tr>" +
"	<tr>" +
"		<th align=\"left\" colspan=5>&nbsp;勾选保留以下HTML标签</th>" +
"	</tr>" +
"	<tr id=\"$$T1000_1\">" +
"		<td align=left><input type=\"checkbox\" name=\"$$T100_3\" id=\"$$T100_3_0\" value=\"table\"/><label for=\"$$T100_3_0\">表格&lt;table</label></td>" +
"		<td align=left><input type=\"checkbox\" name=\"$$T100_3\" id=\"$$T100_3_1\" value=\"tbody\"/><label for=\"$$T100_3_1\">表格体&lt;tbody</label></td>" +
"		<td align=left><input type=\"checkbox\" name=\"$$T100_3\" id=\"$$T100_3_2\" value=\"thead\"/><label for=\"$$T100_3_2\">表格头&lt;thead</label></td>" +
"		<td align=left><input type=\"checkbox\" name=\"$$T100_3\" id=\"$$T100_3_3\" value=\"tr\"/><label for=\"$$T100_3_3\">表格行&lt;tr</label></td>" +
"		<td align=left><input type=\"checkbox\" name=\"$$T100_3\" id=\"$$T100_3_4\" value=\"th,td\"/><label for=\"$$T100_3_4\">单元&lt;th,td</label></td>" +
"	</tr>" +
"	<tr id=\"$$T1000_2\">" +
"		<td align=left><input type=\"checkbox\" name=\"$$T100_3\" id=\"$$T100_3_5\" value=\"form\"/><label for=\"$$T100_3_5\">表单&lt;form</label></td>" +
"		<td align=left><input type=\"checkbox\" name=\"$$T100_3\" id=\"$$T100_3_6\" value=\"frame\"/><label for=\"$$T100_3_6\">框架&lt;frame</label></td>" +
"		<td align=left><input type=\"checkbox\" name=\"$$T100_3\" id=\"$$T100_3_7\" value=\"script\"/><label for=\"$$T100_3_7\">脚本&lt;script</label></td>" +
"		<td align=left><input type=\"checkbox\" name=\"$$T100_3\" id=\"$$T100_3_8\" value=\"iframe\"/><label for=\"$$T100_3_8\">框架&lt;iframe</label></td>" +
"		<td align=left><input type=\"checkbox\" name=\"$$T100_3\" id=\"$$T100_3_9\" value=\"sub,sup\"/><label for=\"$$T100_3_9\">上下标&lt;sub,sup</label></td>" +
"	</tr>" +
"	<tr id=\"$$T1000_3\">" +
"		<td align=left><input type=\"checkbox\" name=\"$$T100_3\" id=\"$$T100_3_10\" value=\"p\"/><label for=\"$$T100_3_10\">段落&lt;p</label></td>" +
"		<td align=left><input type=\"checkbox\" name=\"$$T100_3\" id=\"$$T100_3_11\" value=\"div\"/><label for=\"$$T100_3_11\">层&lt;div</label></td>" +
"		<td align=left><input type=\"checkbox\" name=\"$$T100_3\" id=\"$$T100_3_12\" value=\"span\"/><label for=\"$$T100_3_12\">Span&lt;span</label></td>" +
"		<td align=left><input type=\"checkbox\" name=\"$$T100_3\" id=\"$$T100_3_13\" value=\"br\"/><label for=\"$$T100_3_13\">换行&lt;br</label></td>" +
"		<td align=left><input type=\"checkbox\" name=\"$$T100_3\" id=\"$$T100_3_14\" value=\"hr\"/><label for=\"$$T100_3_14\">HR标签&lt;hr</label></td>" +
"	</tr>" +
"	<tr id=\"$$T1000_4\">" +
"		<td align=left><input type=\"checkbox\" name=\"$$T100_3\" id=\"$$T100_3_15\" value=\"a\"/><label for=\"$$T100_3_15\">链接&lt;a</label></td>" +
"		<td align=left><input type=\"checkbox\" name=\"$$T100_3\" id=\"$$T100_3_16\" value=\"img\"/><label for=\"$$T100_3_16\">图像&lt;img</label></td>" +
"		<td align=left><input type=\"checkbox\" name=\"$$T100_3\" id=\"$$T100_3_17\" value=\"li,ol,ul,dd,dt\"/><label for=\"$$T100_3_17\">列表&lt;li,ol,ul,dd,dt</label></td>" +
"		<td align=left><input type=\"checkbox\" name=\"$$T100_3\" id=\"$$T100_3_18\" value=\"h1,h2,h3,h4,h5,h6,h7\"/><label for=\"$$T100_3_18\">H标签&lt;h1-7</label></td>" +
"		<td align=left><input type=\"checkbox\" name=\"$$T100_3\" id=\"$$T100_3_19\" value=\"font,b,strong\"/><label for=\"$$T100_3_19\">字体&lt;font,b,strong</label></td>" +
"	</tr>" +
"</table>");


var SpecialValueHtml = new Array("特殊取值", 550, 180, 1, "<div style=\"width:550px;height:180px;\"><div class=\"WinRtop\" id=\"$$tabs\"><a href=\"#$$tab1\">正则取值</a><a href=\"#$$tab2\">XML取值</a></div>"+
"<div class=\"tab_container\">" +
"<div id=\"$$tab1\" class=\"$$tab_content\">" +
"<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"StyleView\" width=\"100%\">" +
"	<tr>" +
"		<th align=\"right\" width=\"70px;\">正则：</th>" +
"       <td align=\"left\"><input type=\"text\" name=\"$$T1\" id=\"$$T1\" size=\"50\"/>&nbsp;<select style=\"width:170px;\" id=\"$$T1Select\"><option value=\"\">常用正则</option></select></td>" +
"	</tr>" +
"	<tr>" +
"		<th align=\"right\">显示：</th>" +
"       <td align=\"left\"><input type=\"text\" name=\"$$T2\" value=\"$1\" id=\"$$T2\" size=\"50\"/>$后面跟着位置</td>" +
"	</tr>" +
"	<tr>" +
"		<th align=\"right\">记录：</th>" +
"       <td align=\"left\"><input type=\"checkbox\" name=\"$$T3\" checked=\"checked\" id=\"$$T3\"/><label for=\"$$T3\">只显示第一条</label><span id=\"$$T3View\">&nbsp;&nbsp;&nbsp;多条分隔符：<input type=\"text\" name=\"$$T4\" value=\",\" id=\"$$T4\" size=\"10\"/></span></td>" +
"	</tr>" +
"   </table></div>" +
"        <div id=\"$$tab2\" class=\"$$tab_content\">"+
"<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"StyleView\" width=\"100%\">" +
"	<tr>" +
"		<th align=\"right\" width=\"70px;\">节点：</th>" +
"       <td align=\"left\"><input type=\"text\" name=\"$$T01\" id=\"$$T01\" size=\"50\"/></td>" +
"	</tr>" +
"	<tr>" +
"		<th align=\"right\">属性：</th>" +
"       <td align=\"left\"><input type=\"text\" name=\"$$T05\" id=\"$$T05\" size=\"50\"/>（无属性读取节点值）</td>" +
"	</tr>" +
"	<tr>" +
"		<th align=\"right\">显示：</th>" +
"       <td align=\"left\"><input type=\"text\" name=\"$$T02\" value=\"$value$\" id=\"$$T02\" size=\"50\"/>（取出来的值用$value$代替）</td>" +
"	</tr>" +
"	<tr>" +
"		<th align=\"right\">记录：</th>" +
"       <td align=\"left\"><input type=\"checkbox\" name=\"$$T03\" checked=\"checked\" id=\"$$T03\"/><label for=\"$$T3\">只显示第一条</label><span id=\"$$T03View\">&nbsp;&nbsp;&nbsp;多条分隔符：<input type=\"text\" name=\"$$T04\" value=\",\" id=\"$$T04\" size=\"10\"/></span></td>" +
"	</tr>" +
"   </table></div>" +
"</div>");


var PlusFunHtml = new Array("插入插件", 600, 450, 1, "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"StyleView\" id=\"$$StyleView\" style=\"width:100%\">" +
"	<tr>" +
"		<th align=right height=\"20\" width=\"100\">插件选择</th>" +
"		<td align=left><select id=\"$$TT001\" name=\"$$TT001\"></select></td>" +
"	</tr>" +
"	<tr>" +
"		<td colspan=\"2\"><div style=\"width:590px;height:400px;overflow:auto;overflow-x:hidden;\" id=\"$$TT002\"></div></td>" +
"	</tr>" +
"</table>");


var LabelFieldFunHtml = new Array("选择字段", 500, 35, 1, "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"StyleView\" id=\"$$StyleView\" style=\"width:100%;height:100%\">" +
"	<tr>" +
"		<th align=right height=\"20\" width=\"100\">字段选择</th>" +
"		<td align=left><select style=\"width:380px;\" id=\"$$TT001\" name=\"$$TT001\"></select></td>" +
"	</tr>" +
"</table>");

var AutoTaskFunHtml = new Array("时间周期", 600, 350, 1, "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"StyleView\" id=\"$$StyleView\" style=\"width:100%;\">" +
"	<tr>" +
"		<th align=right width=\"60\">周期</th>" +
"		<td align=left><fieldset style=\"padding:5px;margin:5px;\">" +
"  <legend><input type=\"radio\" name=\"$$T01\" id=\"$$T01_0\" checked=\"checked\" onclick=\"FirefoxDisabled('$$T02_1d',1);FirefoxDisabled('$$T02_0d',1);FirefoxDisabled('$$T02_1View');FirefoxDisabled('$$T01_1View');FirefoxDisabled('$$T01_0View',1);\" value=\"0\"/><label for=\"$$T01_0\">星期</label></legend><div id=\"$$T01_0View\"><input type=\"checkbox\" checked=\"checked\" name=\"$$T011\" value=\"1\" id=\"$$T011_1\"/><label for=\"$$T011_1\">星期一</label>&nbsp;<input type=\"checkbox\" checked=\"checked\" name=\"$$T011\" value=\"2\" id=\"$$T011_2\"/><label for=\"$$T011_2\">星期二</label>&nbsp;<input type=\"checkbox\" checked=\"checked\" value=\"3\" name=\"$$T011\" id=\"$$T011_3\"/><label for=\"$$T011_3\">星期三</label>&nbsp;<input type=\"checkbox\" checked=\"checked\" value=\"4\" name=\"$$T011\" id=\"$$T011_4\"/><label for=\"$$T011_4\">星期四</label>&nbsp;<input type=\"checkbox\" checked=\"checked\" value=\"5\" name=\"$$T011\" id=\"$$T011_5\"/><label for=\"$$T011_5\">星期五</label>&nbsp;<input type=\"checkbox\" checked=\"checked\" value=\"6\" name=\"$$T011\" id=\"$$T011_6\"/><label for=\"$$T011_6\">星期六</label>&nbsp;<input type=\"checkbox\" checked=\"checked\" value=\"7\" name=\"$$T011\" id=\"$$T011_7\"/><label for=\"$$T011_7\">星期日</label>&nbsp;</div></fieldset>" +
"<fieldset style=\"padding:5px;margin:5px;\">" +
"  <legend><input type=\"radio\" name=\"$$T01\" id=\"$$T01_1\" onclick=\"$id('$$T02_1').checked=true;FirefoxDisabled('$$T02_1d',1);FirefoxDisabled('$$T02_0d');FirefoxDisabled('$$T01_0View');FirefoxDisabled('$$T01_1View',1);\" value=\"1\"/><label for=\"$$T01_1\">间隔</label></legend><div id=\"$$T01_1View\">每隔<span style=\"display:inline-block;width:390px;padding:0 5px;\"><input type=\"hidden\" value=\"7\" size=\"2\" id=\"$$T012\" style=\"margin-bottom:2px;\" name=\"$$T012\" /></span>天执行</div></fieldset>" +
"       </td>" +
"	</tr>" +
"	<tr>" +
"		<th align=right>时间</th>" +
"		<td align=left><fieldset style=\"padding:5px;margin:5px;\" id=\"$$T02_0d\">" +
"  <legend><span style=\"float:right;padding-right:10px;\"><input type=\"button\" icon=\"icon-time_add\" onclick=\"AutoTaskChildFun(this,'$$T021Div',$Min$,$Max$);\" value=\"增加特殊时段\" /></span><input type=\"radio\" name=\"$$T02\" id=\"$$T02_0\" checked=\"checked\" onclick=\"FirefoxDisabled('$$T02_1View');FirefoxDisabled('$$T02_0View',1);\" value=\"0\"/><label for=\"$$T02_0\">循环</label></legend><div id=\"$$T02_0View\">每隔<span style=\"display:inline-block;width:390px;padding:10px 5px 0px\"><input type=\"hidden\" value=\"1\" size=\"2\" id=\"$$T021\" style=\"margin-bottom:2px;\" name=\"$$T021\" /></span>分钟执行</div><div id=\"$$T021Div\" style=\"overflow-x:none;overflow-y:auto;height:50px;padding:10px;\"></div></fieldset>" +
"<fieldset style=\"padding:5px;margin:5px;\" id=\"$$T02_1d\">" +
"  <legend><input type=\"radio\" name=\"$$T02\" id=\"$$T02_1\" onclick=\"FirefoxDisabled('$$T02_0View');FirefoxDisabled('$$T02_1View',1);\" value=\"1\"/><label for=\"$$T02_1\">时间</label></legend><div id=\"$$T02_1View\"><select id=\"$$T022_0\" name=\"$$T022_0\"></select>点<select id=\"$$T022_1\" name=\"$$T022_1\"></select>分执行</div></fieldset>" +
"</td>" +
"	</tr>" +
"</table>");

var AutoTaskChildFunHtml = new Array("特殊时段", 500, 85, 1, "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"StyleView\" id=\"$$StyleView\" style=\"width:100%;\">" +
"	<tr><td><fieldset style=\"padding:5px;margin:5px;\">" +
"  <legend><select id=\"$$T1\" name=\"$$T1\"></select>点至<select id=\"$$T2\" name=\"$$T2\"></select>点</legend><div>隔<span style=\"display:inline-block;width:390px;padding:10px 5px 0px\"><input type=\"hidden\" value=\"1\" size=\"2\" id=\"$$T3\" style=\"margin-bottom:2px;\" name=\"$$T3\" /></span>分钟执行</div></fieldset></td></tr>" +
"</table>");


var CommonlyUsedLabelFunHtml = new Array("常用标签选择", 500, 400, 1, "<div style=\"width:500px;height:400px;overflow-x:hidden;overflow-y:auto;\"><table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"StyleView\" style=\"width:100%;height:100%\">" +
"	<tr><td id=\"$$StyleViewDiv\" style=\"text-align:left;\" valign=\"top\"></td></tr>" +
"</table></div>");

var FormFunHtml = new Array("表单选择", 500, 105, 1, "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"StyleView\" id=\"$$StyleView\" style=\"width:100%;height:100%\">" +
"	<tr>" +
"		<th align=right height=\"20\" width=\"100\">选择表单</th>" +
"		<td align=left><select style=\"width:380px;\" id=\"$$TT001\" name=\"$$TT001\"></select></td>" +
"	</tr>" +
"	<tr>" +
"		<th align=right height=\"20\" width=\"100\">功能选择</th>" +
"		<td align=left><select style=\"width:200px;\" id=\"$$TT002\" name=\"$$TT002\"></select></td>" +
"	</tr>" +
"	<tr>" +
"		<th align=right height=\"20\" width=\"100\">JS验证语言</th>" +
"		<td align=left><select style=\"width:200px;\" id=\"$$TT003\" name=\"$$TT003\"></select></td>" +
"	</tr>" +
"</table>");

var LabelPageListHtml = new Array("功能选择", 500, 35, 1, "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"StyleView\" id=\"$$StyleView\" style=\"width:100%;height:100%\">" +
"	<tr>" +
"		<th align=right height=\"20\" width=\"100\">分页信息</th>" +
"		<td align=left><select style=\"width:380px;\" id=\"$$TT001\" name=\"$$TT001\"></select></td>" +
"	</tr>" +
"</table>");

var htmlnojoinhtmlFunHtml = new Array("定义组件", 600, 485, 1, "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"StyleView table\" style=\"width:100%;\">" +
"	<tr>" +
"		<th align=right height=\"20\" width=\"80\">组件选择</th>" +
"		<td align=left><input type=\"radio\" name=\"T01\" id=\"T01_1\" checked=\"checked\" /><label for=\"T01_1\">下拉框</label><input type=\"radio\" name=\"T01\" id=\"T01_2\"/><label for=\"T01_2\">文本框</label></td>" +
"	</tr>" +
"	<tr id=\"T80Tr\">" +
"		<th align=right height=\"20\">组件名称</th>" +
"		<td align=left><input type=\"text\" size=\"5\" value=\"\" name=\"T80\" id=\"T80\" />&nbsp;有名称可以关联显示。</td>" +
"	</tr>" +
"	<tr id=\"T70Tr\">" +
"		<th align=right height=\"20\">关联组件</th>" +
"		<td align=left><select style=\"width:180px;\" id=\"T70\" name=\"T70\"></select>" + SycmsLanguage.Expand.GetFiledOtherStr.l63 + "</td>" +
"	</tr>" +
"	<tr>" +
"		<th align=right height=\"20\">提示信息</th>" +
"		<td align=left><input type=\"text\" size=\"50\" name=\"T02\" id=\"T02\" /></td>" +
"	</tr>" +
"	<tr id=\"T10Tr\">" +
"		<th align=right height=\"20\">选项值</th>" +
"		<td align=left><textarea name=\"T10\" id=\"T10\" htmlformat=\"选项名称$选项值\r\n\" style=\"width: 350px; height: 100px;\">选项名称$选项值\r\n</textarea><br/>一行一个换行输出</td>" +
"	</tr>" +
"	<tr>" +
"		<th align=right height=\"20\">必填</th>" +
"		<td align=left><input type=\"radio\" name=\"T51\" id=\"T51_1\" onclick=\"if($id('T30').value=='0'){$id('T30').value='1'};FirefoxDisabled('T30',1);\" checked=\"checked\" /><label for=\"T51_1\">必填</label><input type=\"radio\" onclick=\"$id('T30').value='0';FirefoxDisabled('T30');\" name=\"T51\" id=\"T51_2\" /><label for=\"T51_2\">选填</label></td>" +
"	</tr>" +
"	<tr>" +
"		<th align=right height=\"20\">宽度</th>" +
"		<td align=left><input type=\"text\" size=\"5\" name=\"T50\" id=\"T50\" />px</td>" +
"	</tr>" +
"	<tr id=\"T20Tr\">" +
"		<th align=right height=\"20\">验证</th>" +
"		<td align=left><select style=\"width:180px;\" id=\"T20\" name=\"T20\"></select></td>" +
"	</tr>" +
"	<tr id=\"T30Tr\">" +
"		<th align=right height=\"20\">长度</th>" +
"		<td align=left><input type=\"text\" size=\"5\" value=\"1\" name=\"T30\" id=\"T30\" />-<input type=\"text\" size=\"5\" value=\"50\" name=\"T31\" id=\"T31\" /></td>" +
"	</tr>" +
"</table>");



var htmlLayoutFunHtml = new Array("选择布局", 400, 280, 1, "<table border=\"0\" id=\"LayoutSelectView\" cellspacing=\"0\" cellpadding=\"0\" class=\"StyleView table\" style=\"width:100%;\">" +
"	<tr>" +
"		<td align=\"center\"><a href=\"\" layout=\"100\"><img src=\"images/layouts/layout_1.png\"><br>1</a></td>" +
"		<td align=\"center\"><a href=\"\" layout=\"20,80\"><img src=\"images/layouts/layout_14.png\"><br>1:4</a></td>" +
"		<td align=\"center\"><a href=\"\" layout=\"25,75\"><img src=\"images/layouts/layout_13.png\"><br>1:3</a></td>" +
"		<td align=\"center\"><a href=\"\" layout=\"33,67\"><img src=\"images/layouts/layout_12.png\"><br>1:2</a></td>" +
"	</tr>" +
"	<tr>" +
"		<td align=\"center\"><a href=\"\" layout=\"40,60\"><img src=\"images/layouts/layout_23.png\"><br>2,3</a></td>" +
"		<td align=\"center\"><a href=\"\" layout=\"50,50\"><img src=\"images/layouts/layout_11.png\"><br>1:1</a></td>" +
"		<td align=\"center\"><a href=\"\" layout=\"20,20,60\"><img src=\"images/layouts/layout_113.png\"><br>1:1:3</a></td>" +
"		<td align=\"center\"><a href=\"\" layout=\"25,25,50\"><img src=\"images/layouts/layout_112.png\"><br>1:1:2</a></td>" +
"	</tr>" +
"	<tr>" +
"		<td align=\"center\"><a href=\"\" layout=\"33,33,33\"><img src=\"images/layouts/layout_111.png\"><br>1:1:1</a></td>" +
"		<td align=\"center\"><a href=\"\" layout=\"40,40,20\"><img src=\"images/layouts/layout_221.png\"><br>2:2:1</a></td>" +
"		<td align=\"center\"><a href=\"\" layout=\"20,60,20\"><img src=\"images/layouts/layout_131.png\"><br>1:3:1</a></td>" +
"		<td align=\"center\"><a href=\"\" layout=\"25,50,25\"><img src=\"images/layouts/layout_121.png\"><br>1:2:1</a></td>" +
"	</tr>" +
"	<tr>" +
"		<td align=\"center\"><a href=\"\" layout=\"30,40,30\"><img src=\"images/layouts/layout_343.png\"><br>3:4:3</a></td>" +
"		<td align=\"center\"><a href=\"\" layout=\"\"><img src=\"images/layouts/layout_manual.png\"><br>自定义</a></td>" +
"		<td align=\"center\">&nbsp;</td>" +
"		<td align=\"center\">&nbsp;</td>" +
"	</tr>" +
"</table>");
var htmlLayoutModiyFunHtml = new Array("布局设置", 380, 190, 1, "<table border=\"0\" id=\"LayoutEditView\" cellspacing=\"0\" cellpadding=\"0\" class=\"StyleView table\" style=\"width:100%;\">" +
"	<tr>" +
"		<th align=\"right\" width=\"80\">栏数：</th>" +
"		<td align=\"left\"><input type=\"radio\" name=\"LayoutNum\" value=\"1\" checked=\"checked\" id=\"LayoutNum_1\"><label for=\"LayoutNum_1\">一栏</label>&nbsp;<input type=\"radio\" name=\"LayoutNum\" value=\"2\" id=\"LayoutNum_2\"><label for=\"LayoutNum_2\">二栏</label>&nbsp;<input type=\"radio\" name=\"LayoutNum\" value=\"3\" id=\"LayoutNum_3\"><label for=\"LayoutNum_3\">三栏</label>&nbsp;<input type=\"radio\" name=\"LayoutNum\" value=\"4\" id=\"LayoutNum_4\"><label for=\"LayoutNum_4\">四栏</label></td>" +
"	</tr>" +
"	<tr>" +
"		<th align=\"right\">各栏宽度：</th>" +
"		<td align=\"left\" class=\"LayoutWidthView\"><input type=\"text\" size=\"4\" value=\"100\" name=\"LayoutWidth\">%</td>" +
"	</tr>" +
"	<tr>" +
"		<th align=\"right\">上边距：</th>" +
"		<td align=\"left\"><input type=\"text\" size=\"5\" value=\"0\" name=\"margintop\" id=\"margintop\">px</td>" +
"	</tr>" +
"	<tr>" +
"		<th align=\"right\">下边距：</th>" +
"		<td align=\"left\"><input type=\"text\" size=\"5\" value=\"0\" name=\"marginbottom\" id=\"marginbottom\">px</td>" +
"	</tr>" +
"</table>");
var htmlLayoutModiyFunHtml = new Array("布局设置", 380, 190, 1, "<table border=\"0\" id=\"LayoutEditView\" cellspacing=\"0\" cellpadding=\"0\" class=\"StyleView table\" style=\"width:100%;\">" +
"	<tr>" +
"		<th align=\"right\" width=\"80\">栏数：</th>" +
"		<td align=\"left\"><input type=\"radio\" name=\"LayoutNum\" value=\"1\" checked=\"checked\" id=\"LayoutNum_1\"><label for=\"LayoutNum_1\">一栏</label>&nbsp;<input type=\"radio\" name=\"LayoutNum\" value=\"2\" id=\"LayoutNum_2\"><label for=\"LayoutNum_2\">二栏</label>&nbsp;<input type=\"radio\" name=\"LayoutNum\" value=\"3\" id=\"LayoutNum_3\"><label for=\"LayoutNum_3\">三栏</label>&nbsp;<input type=\"radio\" name=\"LayoutNum\" value=\"4\" id=\"LayoutNum_4\"><label for=\"LayoutNum_4\">四栏</label></td>" +
"	</tr>" +
"	<tr>" +
"		<th align=\"right\">各栏宽度：</th>" +
"		<td align=\"left\" class=\"LayoutWidthView\"><input type=\"text\" size=\"4\" value=\"100\" name=\"LayoutWidth\">%</td>" +
"	</tr>" +
"	<tr>" +
"		<th align=\"right\">上边距：</th>" +
"		<td align=\"left\"><input type=\"text\" size=\"5\" value=\"0\" name=\"margintop\" id=\"margintop\">px</td>" +
"	</tr>" +
"	<tr>" +
"		<th align=\"right\">下边距：</th>" +
"		<td align=\"left\"><input type=\"text\" size=\"5\" value=\"0\" name=\"marginbottom\" id=\"marginbottom\">px</td>" +
"	</tr>" +
"</table>");

var LabelCountHtml = new Array("计算表达式", 500, 290, 0, "<div style=\"width:500px;height:290px;\"><table border=\"0\" cellspacing=\"0\" class=\"StyleView\" width=\"100%\" height=\"100%\" cellpadding=\"0\">" +
"	<tr>" +
"		<th align=right>表达式：</th>" +
"		<td><textarea rows=\"10\" name=\"$$T1\" id=\"$$T1\" style=\"width:400px;height:220px;\" cols=\"44\"></textarea><br/>在dhtml页面或者是动态区块中尽量少使用。支持()+_*?计算。</td>" +
"	</tr>" +
"	<tr>" +
"		<th align=right>保留小数：</th>" +
"		<td align=left><select name=\"$$T2\" id=\"$$T2\"><option value=\"0\">0位</option><option value=\"1\">1位</option><option value=\"2\">2位</option><option value=\"3\">3位</option><option value=\"4\">4位</option><option value=\"5\">5位</option></select>&nbsp;&nbsp;<input type=\"checkbox\" name=\"$$T3\" value=\"1\" id=\"$$T3\"><label for=\"$$T3\">最大取整</label></td>" +
"	</tr>" +
"</table></div>");

var LabelUser_LoginHtml = new Array("登录判断", 500, 170, 0, "<table border=\"0\" cellspacing=\"0\" class=\"StyleView\" width=\"100%\" height=\"100%\" cellpadding=\"0\">" +
"	<tr>" +
"		<th colspan=\"2\" align=left>判断前台用户是否登录状态（只能在动态区块下使用）</th>" +
"	</tr>" +
"	<tr>" +
"		<th align=right width=\"80\">返回值类型：</th>" +
"		<td align=left><input type=\"radio\" name=\"$$T1\" value=\"js\" onclick=\"FirefoxDisabled($('.$$UserWeb'));\" id=\"$$T1_0\"/><label for=\"$$T1_0\">JS返回值，类型[1/0,UserID]</label><input type=\"radio\" onclick=\"FirefoxDisabled($('.$$UserWeb'),1);\" name=\"$$T1\" value=\"web\" checked=\"checked\" id=\"$$T1_1\"/><label for=\"$$T1_1\">后台判断</label></td>" +
"	</tr>" +
"	<tr class=\"$$UserWeb\">" +
"		<th align=right>弹出提示：</th>" +
"		<td align=left><input type=\"text\" name=\"$$T2\" size=\"50\" id=\"$$T2\"/>&nbsp;为空不提示</td>" +
"	</tr>" +
"	<tr class=\"$$UserWeb\">" +
"		<th align=right>跳转地址：</th>" +
"		<td align=left><input type=\"text\" name=\"$$T3\" id=\"$$T3\" size=\"50\"/>&nbsp;为空不跳转</td>" +
"	</tr>" +
"</table>");

var LabelSys_GoToUrlHtml = new Array("页面跳转", 500, 40, 0, "<table border=\"0\" cellspacing=\"0\" class=\"StyleView\" width=\"100%\" height=\"100%\" cellpadding=\"0\">" +
"	<tr>" +
"		<th align=right width=\"80\">跳转地址：</th>" +
"		<td align=left><input type=\"text\" name=\"$$T1\" size=\"70\" id=\"$$T1\"/></td>" +
"	</tr>" +
"</table>");

var LabelTemplateNavHtml = new Array("区块【导航菜单】", 900, 590, 0, "<div style=\"height:$:0:$px;overflow:hidden;\">" +
"   <div><table border=\"0\" width=\"100%\" cellspacing=\"0\" class=\"StyleView\" style=\"width:100%;\" cellpadding=\"0\">" +
"	<tr>" +
"		<th align=\"right\" width=\"75px;\">区块名称：</th>" +
"		<td align=\"left\"><span style=\"float:right;padding-right:5px;\"><span id=\"$$T0UserView\"><input type=\"button\" icon=\"icon-table_multiple\" onclick=\"OpenTemLog($('#TemId').val());\" value=\"使用记录\" /></span></span><textarea name=\"$$T1\" id=\"$$T1\" style=\"display:none;\"></textarea><input type=\"text\" name=\"$$T0\" id=\"$$T0\" size=\"50\" maxlength=\"50\" ><input type=\"hidden\" name=\"TemId\" id=\"TemId\" size=\"50\" maxlength=\"50\" >&nbsp;&nbsp;<select id=\"$$T0_1\" name=\"$$T0_1\" jTipTitle=\"调用说明\" class=\"jTip\" alt=\"Help/Lists.aspx?action=tem-loadtype\"><option value=\"0\">标准</option><option value=\"1\">静态调用</option><option value=\"2\">动态调用</option></select></td>" +
"	</tr></table></div>" +
"   <div class=\"WinRtop\" id=\"$$tabs\"><a href=\"#$$tab1\">HTML</a><a href=\"#$$tab3\">CSS</a></div>" +
"    <div class=\"tab_container\">" +
"        <div id=\"$$tab1\" class=\"$$tab_content\"><table border=\"0\" cellspacing=\"0\" class=\"StyleView\" width=\"100%\" height=\"100%\" cellpadding=\"0\">" +
"	<tr>" +
"		<th align=right width=\"80\">菜单类型：</th>" +
"		<td align=left><select name=\"$$T11\" id=\"$$T11\" onchange=\"Label_Sell_Mdb(this, '$$',2);\"></select></td>" +
"	</tr>" +
"	<tr>" +
"		<th align=right>上级ID：</th>" +
"		<td align=left><input type=\"text\" name=\"$$T12\" size=\"70\" id=\"$$T12\"/></td>" +
"	</tr>" +
"	<tr>" +
"		<th align=right>显示方式：</th>" +
"		<td align=left>层级：<input type=\"text\" name=\"$$T13\" size=\"10\" value=\"1\" id=\"$$T13\"/>&nbsp;&nbsp;当前样式：<input type=\"radio\" name=\"$$T15\" value=\"True\" id=\"$$T15_0\" checked/><label for=\"$$T15_0\">有</label><input type=\"radio\" name=\"$$T15\" value=\"True\" id=\"$$T15_1\"/><label for=\"$$T15_1\">没有</label>&nbsp;&nbsp;目标窗口：<select name=\"$$T14\" id=\"$$T14\"><option value=\"\">当前页面</option><option value=\"_blank\">新窗口(_blank)</option></select></td>" +
"	</tr>" +
"	<tr>" +
"		<th align=\"right\">附加条件：</th>" +
"		<td align=\"left\">" +
"<table border=\"0\" class=\"nb\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">" +
"	<tr>" +
"		<td width=\"480\">&nbsp;<select size=\"12\" style=\"width:468px;height:130px\" onchange=\"ATfun('$$');\" name=\"$$T4\" id=\"$$T4\"></td>" +
"		<td style=\"line-height:25px;\"><fieldset><legend>位置</legend><input type=\"button\" name=\"$$T4Sub2\" icon=\"icon-prev\" id=\"$$T4Sub2\" value=\"向上\"><input type=\"button\" name=\"$$T4Sub3\" id=\"$$T4Sub3\" icon=\"icon-next\" value=\"向下\"><input type=\"button\" name=\"$$T4Sub5\" id=\"$$T4Sub5\" icon=\"icon-delete\" onclick=\"AtDel('$$','4');\" value=\"删除选定项\"></fieldset><fieldset><legend>关系</legend><input type=\"radio\" name=\"$$T4_Sub1\" onclick=\"AtAndOrfun('$$', '4','AND')\" id=\"$$T4_Sub1_0\"><label for=\"$$T4_Sub1_0\">并且</label>&nbsp;&nbsp;<input type=\"radio\" name=\"$$T4_Sub1\" onclick=\"AtAndOrfun('$$', '4','OR')\" id=\"$$T4_Sub1_1\"><label for=\"$$T4_Sub1_1\">或者</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type=\"checkbox\" name=\"$$T4_Sub2\" id=\"$$T4_Sub2\" onclick=\"AtLikeFun('$$', '4', this, '(')\"><label for=\"$$T4_Sub2\">左括号</label>&nbsp;<input type=\"checkbox\" name=\"$$T4_Sub3\" onclick=\"AtLikeFun('$$', '4', this, ')')\" id=\"$$T4_Sub3\"><label for=\"$$T4_Sub3\">右括号</label></fieldset></td>" +
"	</tr>" +
"	<tr>" +
"		<td colspan=2><div style=\"float:left;padding:3px\">&nbsp;<select size=\"1\" name=\"$$T4_2\" onchange=\"LabelJudgeChange(this,'$$')\" id=\"$$T4_2\">" +
"	</select><select name=\"$$T4_3\" id=\"$$T4_3\" size=\"1\" style=\"display:none;\" onchange=\"LabelJudgeChange1(this,'$$')\">" +
"        </select><input type=\"Text\" size=50 id=\"$$T4_4\" style=\"display:none;\" jTipTitle=\"规则\" class=\"jTip\" alt=\"Help/Lists.aspx?action=temhtml-atspace\" name=\"$$T4_4\"><select onchange=\"LabelJudgeChange2(this,'$$')\" name=\"$$T4_5\" id=\"$$T4_5\" style=\"display:none;\" size=\"1\"></select></div>" +
"        <div style=\"float:left\"><input type=\"button\" name=\"Submit\" onclick=\"AddValue1('$$','4',null)\" icon=\"icon-add\" value=\"添加\"></div><div style=\"float:left;display:none;padding-left:3px;\" id=\"$$T4_View\"><input type=\"button\" name=\"Submit\" onclick=\"AddValue1('$$','4',$id('$$T4_View'))\" icon=\"icon-edit\" value=\"修改\"></div></td>" +
"	</tr>" +
"</table>" +
"</td>" +
"	</tr>" +
"	<tr>" +
"		<th align=right>显示内容：</th>" +
"		<td align=left>链接地址：<select name=\"$$T66_2\" id=\"$$T66_2\"></select>&nbsp;&nbsp;显示名称：<select name=\"$$T66_1\" id=\"$$T66_1\"></select></td>" +
"	</tr>" +
"	<tr>" +
"		<th align=right>菜单样式：</th>" +
"		<td align=left><select name=\"$$T17\" id=\"$$T17\"></select>&nbsp;&nbsp;样式内容会写入CSS中</td>" +
"	</tr>" +
"	<tr>" +
"		<td align=left colspan=\"2\" style=\"height:165px\"><iframe width=\"100%\" id=\"$$T8Iframe\" height=\"100%\" frameborder=\"0\" src=\"js/blank.html\" style=\"border:none;\"></iframe></td>" +
"	</tr>" +
"</table></div>" +
"        <div id=\"$$tab3\" class=\"$$tab_content\" align=\"left\" style=\"padding:15px;\">如果有图片的时候前面要加[$Path$],如[$Path$]/Images/.JPG<div><input type=\"text\" name=\"$$T16_0\" id=\"$$T16_0\" size=\"20\"><input type=\"button\" onclick=\"LoadSpreadView('$$T16_0',$('#YQ_listID').val(),'$$T3');\"  icon=\"icon-css_go\" value=\"调入扩展样式\"></div><textarea rows=\"7\" wrap=\"off\" name=\"$$T3\" id=\"$$T3\" style=\"width:860px;height:$:150:$px;\" cols=\"70\"></textarea></div>" +
"   </div>" +
"</div>");



var LabelTemplateSysHtml = new Array("区块【系统样式】", 900, 590, 0, "<div style=\"height:$:0:$px;overflow:hidden;\">" +
"   <div><table border=\"0\" width=\"100%\" cellspacing=\"0\" class=\"StyleView\" style=\"width:100%;\" cellpadding=\"0\">" +
"	<tr>" +
"		<th align=\"right\" width=\"75px;\">区块名称：</th>" +
"		<td align=\"left\"><span style=\"float:right;padding-right:5px;\"><span id=\"$$T0UserView\"><input type=\"button\" icon=\"icon-table_multiple\" onclick=\"OpenTemLog($('#TemId').val());\" value=\"使用记录\" /></span></span><textarea name=\"$$T1\" id=\"$$T1\" style=\"display:none;\"></textarea><input type=\"text\" name=\"$$T0\" id=\"$$T0\" size=\"50\" maxlength=\"50\" ><input type=\"hidden\" name=\"TemId\" id=\"TemId\" size=\"50\" maxlength=\"50\" >&nbsp;&nbsp;<select id=\"$$T0_1\" name=\"$$T0_1\" jTipTitle=\"调用说明\" class=\"jTip\" alt=\"Help/Lists.aspx?action=tem-loadtype\"><option value=\"0\">标准</option><option value=\"1\">静态调用</option><option value=\"2\">动态调用</option></select></td>" +
"	</tr></table></div>" +
"   <div class=\"WinRtop\" id=\"$$tabs\"><a href=\"#$$tab1\">样式</a><a href=\"#$$tab2\">数据</a><a href=\"#$$tab3\">输出</a><a href=\"#$$tab4\">CSS</a></div>" +
"    <div class=\"tab_container\">"+
"       <div id=\"$$tab1\" class=\"$$tab_content\"></div>" +
"        <div id=\"$$tab2\" class=\"$$tab_content\"><table border=\"0\" cellspacing=\"0\" class=\"StyleView\" width=\"100%\" height=\"100%\" cellpadding=\"0\">" +
"	<tr>" +
"		<th align=right width=\"80\">数据模型：</th>" +
"		<td align=left><select name=\"$$T11\" id=\"$$T11\" onchange=\"Label_Sell_Mdb(this, '$$',2);\"></select></td>" +
"	</tr>" +
"	<tr id=\"$$T12_Title\">" +
"		<th align=right>标题：</th>" +
"		<td align=left><div id=\"$$T12View1\" style=\"width:150px;50px;float:right;text-align:left;padding-left:3px;overflow-y:auto;overflow-x:hidden\"></div><div style=\"float:left;padding-left:5px;\">" +
"<div class=\"TextAreaSyCms\" style=\"width:655px;height:50px;\"><div id=\"$$T12_Line\" class=\"TextAreaSyCmsLine TextAreaSyCmsFont\"></div><" + InterVeersionDiv + " id=\"$$T12_Bg\" style=\"width:620px;\" class=\"TextAreaSyCmsPackage TextAreaSyCmsFont\"></" + InterVeersionDiv + "><textarea rows=\"7\" wrap=\"off\" IsList=\"0\" IsLabel=\"1\" htmlformat=\"标题,链接地址\" class=\"TextArea TextAreaSyCmsFont\" name=\"$$T12\" id=\"$$T12\" style=\"width:620px;height:50px;\" cols=\"70\">标题,链接地址</textarea></div></div></td>" +
"	</tr>" +
"	<tr>" +
"		<th align=\"right\">条件设置：</th>" +
"		<td align=\"left\">" +
"<div class=\"WinRtop\" id=\"$$ATtabs\"><a href=\"#$$ATtab1\">标准</a><a href=\"#$$ATtab2\">高级</a></div><div id=\"$$ATtab1\" class=\"$$ATtab_content\">" +
"<table border=\"0\" class=\"nb\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">" +
"	<tr>" +
"		<td width=\"480\">&nbsp;<select size=\"12\" style=\"width:468px;height:130px\" onchange=\"ATfun('$$');\" name=\"$$T4\" id=\"$$T4\"></td>" +
"		<td style=\"line-height:25px;\"><fieldset><legend>位置</legend><input type=\"button\" name=\"$$T4Sub2\" icon=\"icon-prev\" id=\"$$T4Sub2\" value=\"向上\"><input type=\"button\" name=\"$$T4Sub3\" id=\"$$T4Sub3\" icon=\"icon-next\" value=\"向下\"><input type=\"button\" name=\"$$T4Sub5\" id=\"$$T4Sub5\" icon=\"icon-delete\" onclick=\"AtDel('$$','4');\" value=\"删除选定项\"></fieldset><fieldset><legend>关系</legend><input type=\"radio\" name=\"$$T4_Sub1\" onclick=\"AtAndOrfun('$$', '4','AND')\" id=\"$$T4_Sub1_0\"><label for=\"$$T4_Sub1_0\">并且</label>&nbsp;&nbsp;<input type=\"radio\" name=\"$$T4_Sub1\" onclick=\"AtAndOrfun('$$', '4','OR')\" id=\"$$T4_Sub1_1\"><label for=\"$$T4_Sub1_1\">或者</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type=\"checkbox\" name=\"$$T4_Sub2\" id=\"$$T4_Sub2\" onclick=\"AtLikeFun('$$', '4', this, '(')\"><label for=\"$$T4_Sub2\">左括号</label>&nbsp;<input type=\"checkbox\" name=\"$$T4_Sub3\" onclick=\"AtLikeFun('$$', '4', this, ')')\" id=\"$$T4_Sub3\"><label for=\"$$T4_Sub3\">右括号</label></fieldset></td>" +
"	</tr>" +
"	<tr>" +
"		<td colspan=2><div style=\"float:left;padding:3px\">&nbsp;<select size=\"1\" name=\"$$T4_2\" onchange=\"LabelJudgeChange(this,'$$')\" id=\"$$T4_2\">" +
"	</select><select name=\"$$T4_3\" id=\"$$T4_3\" size=\"1\" style=\"display:none;\" onchange=\"LabelJudgeChange1(this,'$$')\">" +
"        </select><input type=\"Text\" size=50 id=\"$$T4_4\" style=\"display:none;\" jTipTitle=\"规则\" class=\"jTip\" alt=\"Help/Lists.aspx?action=temhtml-atspace\" name=\"$$T4_4\"><select onchange=\"LabelJudgeChange2(this,'$$')\" name=\"$$T4_5\" id=\"$$T4_5\" style=\"display:none;\" size=\"1\"></select></div>" +
"        <div style=\"float:left\"><input type=\"button\" name=\"Submit\" onclick=\"AddValue1('$$','4',null)\" icon=\"icon-add\" value=\"添加\"></div><div style=\"float:left;display:none;padding-left:3px;\" id=\"$$T4_View\"><input type=\"button\" name=\"Submit\" onclick=\"AddValue1('$$','4',$id('$$T4_View'))\" icon=\"icon-edit\" value=\"修改\"></div></td>" +
"	</tr>" +
"</table></div>" +
"<div id=\"$$ATtab2\" class=\"$$ATtab_content\" style=\"display:none;\"><div id=\"$$T21Viewtab\" style=\"width:140px;height:150px;float:right;text-align:left;padding-left:3px;margin-left:3px;overflow-y:auto;overflow-x:hidden\"></div><div style=\"float:left;\"><div class=\"TextAreaSyCms\" style=\"width:630px;height:130px;\"><div id=\"$$T21_Line\" class=\"TextAreaSyCmsLine TextAreaSyCmsFont\"></div><" + InterVeersionDiv + " id=\"$$T21_Bg\" style=\"width:595px;\" class=\"TextAreaSyCmsPackage TextAreaSyCmsFont\"></" + InterVeersionDiv + "><textarea rows=\"8\" name=\"$$T21\" wrap=\"off\" class=\"TextArea TextAreaSyCmsFont\" id=\"$$T21\" style=\"width:595px;height:130px;\" cols=\"40\"></textarea></div>" +
"<select name=\"$$T4_7\" id=\"$$T4_7\" style=\"margin:5px 0 0 5px\" onchange=\"InsertAtCaret($id('$$T21'),this.options[this.selectedIndex].value)\" size=\"1\"></select></div></div>" +
"</td>" +
"	</tr>" +
"	<tr>" +
"		<th align=\"right\">排序设置：</tdh>" +
"		<td align=\"left\"><div class=\"WinRtop\" id=\"$$ordertabs\"><a href=\"#$$ordertab1\">标准</a><a href=\"#$$ordertab2\">高级</a></div><div id=\"$$ordertab1\" class=\"$$ordertab_content\">" +
"<table border=\"0\" class=\"nb\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">" +
"	<tr>" +
"		<td style=\"width:480px;\">&nbsp;<select size=\"12\" style=\"width:468px;height:80px\" name=\"$$T9\" id=\"$$T9\"></td>" +
"		<td style=\"line-height:25px;\"><fieldset><legend>位置</legend><input type=\"button\" name=\"$$Sub9_1\" id=\"$$Sub9_1\" icon=\"icon-prev\" value=\"向上\"><input type=\"button\" name=\"$$Sub9_2\" id=\"$$Sub9_2\" icon=\"icon-next\" value=\"向下\"><input type=\"button\" name=\"$$Submit4\" onclick=\"DelSelectValue($id('$$T9'));\" icon=\"icon-delete\" value=\"删除选择项\"></fieldset></td>" +
"	</tr>" +
"	<tr>" +
"		<td colspan=2><div style=\"float:left;padding:3px\">&nbsp;<select name=\"$$T9_2\" id=\"$$T9_2\" size=\"1\">" +
"        	</select><select name=\"$$T9_3\" id=\"$$T9_3\" size=\"1\"></select></div>" +
"        	<div style=\"float:left;\"><input type=\"button\" name=\"$$Submit0_1\" onclick=\"AddValue2($id('$$T9'),$id('$$T9_2'),$id('$$T9_3'));\" icon=\"icon-add\" value=\"添加\"></div></td>" +
"	</tr>" +
"	</table></div>" +
"<div id=\"$$ordertab2\" class=\"$$ordertab_content\" style=\"display:none;\"><div id=\"$$T21Viewtab\" style=\"width:140px;height:85px;float:right;text-align:left;padding-left:3px;margin-left:3px;overflow-y:auto;overflow-x:hidden\"></div><div style=\"float:left;\"><div class=\"TextAreaSyCms\" style=\"width:630px;height:85px;\"><div id=\"$$T22_Line\" class=\"TextAreaSyCmsLine TextAreaSyCmsFont\"></div><" + InterVeersionDiv + " id=\"$$T22_Bg\" style=\"width:595px;\" class=\"TextAreaSyCmsPackage TextAreaSyCmsFont\"></" + InterVeersionDiv + "><textarea rows=\"8\" wrap=\"off\" class=\"TextArea TextAreaSyCmsFont\" name=\"$$T22\" id=\"$$T22\" style=\"width:595px;height:85px;\" cols=\"40\"></textarea></div><select name=\"$$T9_7\" style=\"margin:5px 0 0 5px\" id=\"$$T9_7\" onchange=\"InsertAtCaret($id('$$T22'),this.options[this.selectedIndex].value)\" size=\"1\"></select></div></div>" +
"</td>" +
"	</tr>" +
"	<tr>" +
"		<th align=\"right\">调用数量：</th>" +
"		<td align=\"left\"><div id=\"$$LoadNum\">&nbsp;<input type=\"radio\" checked=\"checked\" onchange=\"LoadNum_PageFun(this,0,'$$');\" name=\"$$T7_0\" id=\"$$T7_0_0\"><label for=\"$$T7_0_0\">部分调用</label><span id=\"$$LoadNumView\">：调用<input type=\"Text\" size=10 name=\"$$T7_1\" jTipTitle=\"调用数量\" class=\"jTip\" alt=\"Help/Lists.aspx?action=temhtml-loadnum\" id=\"$$T7_1\" value=\"10\">条&nbsp;从<input type=\"Text\" size=10 name=\"$$T7_2\" id=\"$$T7_2\">条开始显示</span></div>" +
"<div id=\"$$LoadNumPage\">&nbsp;<input type=\"radio\" onchange=\"LoadNum_PageFun(this,1,'$$');\" name=\"$$T7_0\" id=\"$$T7_0_1\"><label for=\"$$T7_0_1\">全部调用</label>：<span id=\"$$LoadPage\"><span>&nbsp;<input type=\"checkbox\" class=\"radio\" name=\"$$T13_1\" id=\"$$T13_1\" onclick=\"if(this.checked){FirefoxDisabled('$$T13_PageView',1);FirefoxDisabled('$$LoadNum');FirefoxDisabled('$$LoadPageType');}else{FirefoxDisabled('$$T13_PageView');FirefoxDisabled('$$LoadNum',1);FirefoxDisabled('$$LoadNumView');FirefoxDisabled('$$LoadPageType',1);}\" value=\"1\"><label for=\"$$T13_1\">分页显示：</label></span>" +
"		<span id=\"$$T13_PageView\">&nbsp;分页样式：<select name=\"$$T13_2\" jTipTitle=\"分页样式\" class=\"jTip\" alt=\"Help/Lists.aspx?action=temhtml-pagestyle\" id=\"$$T13_2\" size=\"1\"></select>&nbsp;每页数量：<input type=\"Text\" size=10 name=\"$$T13_3\" id=\"$$T13_3\" value=\"50\">条&nbsp;最大页码：<input type=\"Text\" size=10 name=\"$$T13_14\" id=\"$$T13_14\" value=\"0\">页&nbsp;分页名称：<input type=\"Text\" size=10 name=\"$$T13_7\" id=\"$$T13_7\" value=\"记录\"></span></span></div></td>" +
"	</tr>" +
"</table></div><div id=\"$$tab3\" class=\"$$tab_content\" align=\"left\" style=\"padding:15px;\"><div id=\"$$tab3List\"></div><div>"+
"<table border=\"0\" class=\"StyleView nb\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">" +
"	<tr id=\"$$Title\">" +
"		<th style=\"width:100px;\" align=\"right\">标题字段：</th>" +
"		<td><select id=\"$$T66_1\" style=\"width:200px;float:left;\"></select><input type=\"hidden\" id=\"$$T66_11\"/><div style=\"float:left;padding-left:15px;\"><input type=\"button\" icon=\"icon-text_fit\" value=\"设置规则\" id=\"$$T0Button\" onclick=\"VarFormatFun('$$','T66_1','T66_11')\"/></div></td>" +
"	</tr>" +
"	<tr id=\"$$Link\">" +
"		<th style=\"width:100px;\" align=\"right\">链接字段：</th>" +
"		<td><select id=\"$$T66_2\" style=\"width:200px;float:left;\"></select><input type=\"hidden\" id=\"$$T66_22\"/><div style=\"float:left;padding-left:15px;\"><input type=\"button\" icon=\"icon-text_fit\" value=\"设置规则\" id=\"$$T0Button\" onclick=\"VarFormatFun('$$','T66_2','T66_22')\"/></div></td>" +
"	</tr>" +
"	<tr id=\"$$Pic\">" +
"		<th style=\"width:100px;\" align=\"right\">图片字段：</th>" +
"		<td><select id=\"$$T66_3\" style=\"width:200px;float:left;\"></select><input type=\"hidden\" id=\"$$T66_33\"/><div style=\"float:left;padding-left:15px;\"><input type=\"button\" icon=\"icon-text_fit\" value=\"设置规则\" id=\"$$T0Button\" onclick=\"VarFormatFun('$$','T66_3','T66_33')\"/></div></td>" +
"	</tr>" +
"	<tr id=\"$$Summary\">" +
"		<th style=\"width:100px;\" align=\"right\">摘要字段：</th>" +
"		<td><select id=\"$$T66_4\" style=\"width:200px;float:left;\"></select><input type=\"hidden\" id=\"$$T66_44\"/><div style=\"float:left;padding-left:15px;\"><input type=\"button\" icon=\"icon-text_fit\" value=\"设置规则\" id=\"$$T0Button\" onclick=\"VarFormatFun('$$','T66_4','T66_44')\"/></div></td>" +
"	</tr></table>" +
"</div></div>" +
"        <div id=\"$$tab4\" class=\"$$tab_content\" align=\"left\" style=\"padding:15px;\">如果有图片的时候前面要加[$Path$],如[$Path$]/Images/.JPG<div><input type=\"text\" name=\"$$T16_0\" id=\"$$T16_0\" size=\"20\"><input type=\"button\" onclick=\"LoadSpreadView('$$T16_0',$('#YQ_listID').val(),'$$T3');\"  icon=\"icon-css_go\" value=\"调入扩展样式\"></div><textarea rows=\"7\" wrap=\"off\" name=\"$$T3\" id=\"$$T3\" style=\"width:860px;height:$:150:$px;\" cols=\"70\"></textarea></div>" +
"   </div>" +
"</div>");


var FormATHtml = new Array("高级条件", 800, 210, 0, "<table border=\"0\" cellspacing=\"0\" class=\"StyleView\" width=\"100%\" cellpadding=\"0\">" +
"	<tr>" +
"		<td align=\"left\">" +
"<div class=\"WinRtop\" id=\"$$ATtabs\"><a href=\"#$$ATtab1\">标准</a><a href=\"#$$ATtab2\">高级</a></div><div id=\"$$ATtab1\" class=\"$$ATtab_content\">" +
"<table border=\"0\" class=\"nb\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">" +
"	<tr>" +
"		<td width=\"480\">&nbsp;<select size=\"12\" style=\"width:468px;height:130px\" onchange=\"ATfun('$$');\" name=\"$$T4\" id=\"$$T4\"></td>" +
"		<td style=\"line-height:25px;\"><fieldset><legend>位置</legend><input type=\"button\" name=\"$$T4Sub2\" icon=\"icon-prev\" id=\"$$T4Sub2\" value=\"向上\"><input type=\"button\" name=\"$$T4Sub3\" id=\"$$T4Sub3\" icon=\"icon-next\" value=\"向下\"><input type=\"button\" name=\"$$T4Sub5\" id=\"$$T4Sub5\" icon=\"icon-delete\" onclick=\"AtDel('$$','4');\" value=\"删除选定项\"></fieldset><fieldset><legend>关系</legend><input type=\"radio\" name=\"$$T4_Sub1\" onclick=\"AtAndOrfun('$$', '4','AND')\" id=\"$$T4_Sub1_0\"><label for=\"$$T4_Sub1_0\">并且</label>&nbsp;&nbsp;<input type=\"radio\" name=\"$$T4_Sub1\" onclick=\"AtAndOrfun('$$', '4','OR')\" id=\"$$T4_Sub1_1\"><label for=\"$$T4_Sub1_1\">或者</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type=\"checkbox\" name=\"$$T4_Sub2\" id=\"$$T4_Sub2\" onclick=\"AtLikeFun('$$', '4', this, '(')\"><label for=\"$$T4_Sub2\">左括号</label>&nbsp;<input type=\"checkbox\" name=\"$$T4_Sub3\" onclick=\"AtLikeFun('$$', '4', this, ')')\" id=\"$$T4_Sub3\"><label for=\"$$T4_Sub3\">右括号</label></fieldset></td>" +
"	</tr>" +
"	<tr>" +
"		<td colspan=2><div style=\"float:left;padding:3px\">&nbsp;<select size=\"1\" name=\"$$T4_2\" onchange=\"LabelJudgeChange(this,'$$')\" id=\"$$T4_2\">" +
"	</select><select name=\"$$T4_3\" id=\"$$T4_3\" size=\"1\" style=\"display:none;\" onchange=\"LabelJudgeChange1(this,'$$')\">" +
"        </select><input type=\"Text\" size=50 id=\"$$T4_4\" style=\"display:none;\" jTipTitle=\"规则\" class=\"jTip\" alt=\"Help/Lists.aspx?action=temhtml-atspace\" name=\"$$T4_4\"><select onchange=\"LabelJudgeChange2(this,'$$')\" name=\"$$T4_5\" id=\"$$T4_5\" style=\"display:none;\" size=\"1\"></select></div>" +
"        <div style=\"float:left\"><input type=\"button\" name=\"Submit\" onclick=\"AddValue1('$$','4',null)\" icon=\"icon-add\" value=\"添加\"></div><div style=\"float:left;display:none;padding-left:3px;\" id=\"$$T4_View\"><input type=\"button\" name=\"Submit\" onclick=\"AddValue1('$$','4',$id('$$T4_View'))\" icon=\"icon-edit\" value=\"修改\"></div></td>" +
"	</tr>" +
"</table></div>" +
"<div id=\"$$ATtab2\" class=\"$$ATtab_content\" style=\"display:none;\"><div id=\"$$T21Viewtab\" style=\"width:140px;height:150px;float:right;text-align:left;padding-left:3px;margin-left:3px;overflow-y:auto;overflow-x:hidden\"></div><div style=\"float:left;\"><div class=\"TextAreaSyCms\" style=\"width:630px;height:130px;\"><div id=\"$$T21_Line\" class=\"TextAreaSyCmsLine TextAreaSyCmsFont\"></div><" + InterVeersionDiv + " id=\"$$T21_Bg\" style=\"width:595px;\" class=\"TextAreaSyCmsPackage TextAreaSyCmsFont\"></" + InterVeersionDiv + "><textarea rows=\"8\" name=\"$$T21\" wrap=\"off\" class=\"TextArea TextAreaSyCmsFont\" id=\"$$T21\" style=\"width:595px;height:130px;\" cols=\"40\"></textarea></div>" +
"<select name=\"$$T4_7\" id=\"$$T4_7\" style=\"margin:5px 0 0 5px\" onchange=\"InsertAtCaret($id('$$T21'),this.options[this.selectedIndex].value)\" size=\"1\"></select></div></div>" +
"</td>" +
"	</tr>" +
"</table>");