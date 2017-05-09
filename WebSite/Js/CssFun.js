var styleSheet = function (n, nn) {
    var yq_css_ss;
    var styleSheets = null;
    if (nn == null) {
        styleSheets = document.styleSheets;
    } else {
        styleSheets = nn.document.styleSheets;
    }
    if (typeof n == "number") {
        if (n >= styleSheets.length) {
            yq_css_ss = styleSheets[styleSheets.length - 1];
        } else {
            yq_css_ss = styleSheets[n];
        }
    } else {
        for (var i = 0; i < styleSheets.length; i++) {
            if (styleSheets[i].href == n || (styleSheets[i].href && styleSheets[i].href.indexOf(n) != -1)) {
                yq_css_ss = styleSheets[i];
                break;
            }
        }
    }
    this.sheet = yq_css_ss;
    this.rules = yq_css_ss.cssRules ? yq_css_ss.cssRules : yq_css_ss.rules;
};

styleSheet.prototype.addRuleArray = function(str) {
    var stylestr = new Array(new Array(), new Array());
    var str2n = 0;
    str1 = str.split("}");
    for (i = 0; i < str1.length - 1; i++) {
        if (str1[i].length > 0) {
            str2 = str1[i].split("{");
            str4 = str2[0].replace("\n", "");
            if (str4.length > 0 && str2.length > 0) {
                if (str2[1].length > 0) {
                    stylestr[0][str2n] = str4.replace("\r", "").replace("\n", "");
                    stylestr[1][str2n] = str2[1];
                    str2n = str2n + 1;
                }
            }
        }
    }
    for (var i = 0; i < stylestr[0].length; i++) {
        this.addRule(stylestr[0][i], stylestr[1][i], i);
    }
};
/**//*--------------------------------------------
    描述 : 查找样式rule，成功返回index,否则返回-1
    参数 : n为rule名称
    代码 : var ss = new styleSheet(0);
          ss.indexOf("className")
--------------------------------------------*/
styleSheet.prototype.indexOf = function(selector)
{
	for(var i=0;i<this.rules.length;i++)
	{
		if(this.rules[i].selectorText.toLowerCase()==selector.toLowerCase())
		{
			return i;
		}
	}
	return -1;
};



/**//*--------------------------------------------
    描述 : 删除样式rule
    参数 : n为rule索引或者名称
    代码 : var ss = new styleSheet(0);
          ss.removeRule(0) || ss.removeRule("className")
--------------------------------------------*/
styleSheet.prototype.removeRule = function(n)
{
	if(typeof n == "number")
	{
		if(n<this.rules.length)
		{
			this.sheet.removeRule?this.sheet.removeRule(n):this.sheet.deleteRule(n);
		}
	}else
	{
		var i = this.indexOf(n);
		this.sheet.removeRule?this.sheet.removeRule(i):this.sheet.deleteRule(i);
	}
};

/**//*--------------------------------------------
    描述 : 添加新的样式rule
    参数 : selector      样式rule名称
          styles        样式rule的style
          n             位置
    代码 : var ss = new styleSheet(0);
          ss.addRule("className","color:red",0);
--------------------------------------------*/
styleSheet.prototype.addRule = function (selector, styles, n) {
    var i = this.indexOf(selector);
    if (i != -1) {
        this.removeRule(i);
        n = i;
    } else {
        if (typeof n == "undefined") {
            n = this.rules.length;
        }
    }
    var s1 = selector.split(",");
    for (var i = 0; i < s1.length; i++) {
        this.sheet.insertRule ? this.sheet.insertRule(s1[i] + "{" + styles + "}", n) : this.sheet.addRule(s1[i], styles, n);
    }
};

/**//*--------------------------------------------
    描述 : 设置样式rule具体的属性
    参数 : selector      样式rule名称
          attribute     样式rule的属性
          _value        指定value值
    代码 : var ss = new styleSheet(0);
           ss.setRuleStyle("className","color","green");
--------------------------------------------*/
styleSheet.prototype.setRuleStyle = function(selector,attribute,_value)
{
	var i = this.indexOf(selector);
	if(i!=-1)
	{
		this.rules[i].style[attribute] = _value;
	}
};

/**//*--------------------------------------------
    描述 : 获得样式rule具体的属性
    参数 : selector      样式rule名称
          attribute      样式rule的属性
    代码 : var ss = new styleSheet(0);
          ss.getRuleStyle("className","color");
--------------------------------------------*/
styleSheet.prototype.getRuleStyle = function(selector,attribute)
{
	var i = this.indexOf(selector);
	return this.rules[i].style[attribute]
};