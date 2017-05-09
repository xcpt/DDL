var FirefoxDom = false;
function XML() {
    //说明：person/@last-name		<person last-name=""></person>
    //	person,2			<person></person><person>取它</person>
    //	person[name/@id='khlg']		<person><name id="khlg">里面所有</name></person>
    var isIE = true;
    var xmlDoc = null;
    //Firefox扩展函数
    this.FirefoxDom = function () {
        var ex;
        XMLDocument.prototype.__proto__.__defineGetter__("xml", function () {
            try {
                return new XMLSerializer().serializeToString(this);
            } catch (ex) {
                var d = document.createElement("div");
                d.appendChild(this.cloneNode(true));
                return d.innerHTML;
            }
        });
        Element.prototype.__proto__.__defineGetter__("xml", function () {
            try {
                return new XMLSerializer().serializeToString(this);
            } catch (ex) {
                var d = document.createElement("div");
                d.appendChild(this.cloneNode(true));
                return d.innerHTML;
            }
        });
        XMLDocument.prototype.__proto__.__defineGetter__("text", function () {
            return this.firstChild.textContent;
        });
        Element.prototype.__proto__.__defineGetter__("text", function () {
            return this.textContent;
        });

        XMLDocument.prototype.selectSingleNode = Element.prototype.selectSingleNode = function (xpath) {
            var x = this.selectNodes(xpath)
            if (!x || x.length < 1) return null;
            return x[0];
        }
        XMLDocument.prototype.selectNodes = Element.prototype.selectNodes = function (xpath) {
            var xpe = new XPathEvaluator();
            var nsResolver = xpe.createNSResolver(this.ownerDocument == null ? this.documentElement : this.ownerDocument.documentElement);
            var result = xpe.evaluate(xpath, this, nsResolver, 0, null);
            var found = [];
            var res;
            while (res = result.iterateNext())
                found.push(res);
            return found;
        }
        FirefoxDom = true;
    }
    this.GetString = function (Obj, i) {
        if (Obj) {
            if (i) {
                return this.getNode(Obj, i).xml;
            } else {
                var icount = this.getNodeslength(Obj);
                if (icount == 1) {
                    return this.getNode(Obj).xml;
                } else {
                    var string = "";
                    for (var i = 0; i < icount; i++) {
                        string += this.getNode(Obj, i + 1).xml;
                    }
                    return string;
                }
            }
        } else {
            return xmlDoc.xml;
        }
        return null;
    }
    this.GetXML = function(Obj) {
        if (Obj) {
            return this.getNode(Obj);
        } else {
            return xmlDoc;
        }
        return null;
    }
    this.Dispose = function () {
        xmlDoc = null;
    }
    //初始调入
    this.SetXML = function (Obj) {
        if (Obj.indexOf("<?xml") == -1) {
            Obj = "<?xml version='1.0' encoding='utf-8'?>" + Obj;
        }
        if (window.ActiveXObject) {
            isIE = true;
            var MSXMLS = ["MSXML2.DOMDocument.5.0", "MSXML2.DOMDocument.4.0", "MSXML2.DOMDocument.3.0", "MSXML2.DOMDocument", "Microsoft.XmlDom"];
            var MSXMLS_i = getCookie("XML_ActiveXObject");
            if (MSXMLS_i != "" && MSXMLS_i.IsDigit()) {
                xmlDoc = new ActiveXObject(MSXMLS[MSXMLS_i]);
            } else {
                for (var i = 0; i < MSXMLS.length; i++) {
                    try {
                        xmlDoc = new ActiveXObject(MSXMLS[i]);
                        SetCookie("XML_ActiveXObject", i);
                    } catch (e) {

                    }
                }
            }
            try {
                xmlDoc.loadXML(Obj);
            } catch (e) {
                alert(e);
            }
        } else if (document.implementation && document.implementation.createDocument) {
            isIE = false;
            var parser = new DOMParser();
            xmlDoc = parser.parseFromString(Obj, "text/xml");
            if (!FirefoxDom) {
                this.FirefoxDom();
            }
        }
        xmlDoc.async = false;
    }

    // 取得节点的值.
    this.getChild = function (xpath, i) {
        var retval = "";
        var value = this.getNode(xpath, i);
        if (value) {
            retval = (value.text);
            if (!retval) {
                retval = (value.nodeValue);
            }
        }
        return retval;
    }

    // 取得节点下的子节点个数
    this.getNodeslength = function (xpath, i) {
        var retval = 0;
        var value = xmlDoc.selectNodes(this.getNodeIndex(xpath, i));
        if (value) retval = value.length;
        return retval;
    }
    //给地址添加顺序号
    this.getNodeIndex = function (xpath, i) {
        if (i) {
            if (isIE) {
                xpath += "[" + (parseInt(i) - 1) + "]";
            } else {
                xpath += "[" + i + "]";
            }
        }
        return xpath;
    }
    // 取得XML中的一个节点.
    this.getNode = function (xpath, i) {
        return xmlDoc.selectSingleNode(this.getNodeIndex(xpath, i));
    }

    // 删除XML中的一个节点.不可删除根节点.
    this.delNode = function (xpath, i) {
        Node = this.getNode(xpath,i);
        if (Node) {
            Node.parentNode.removeChild(Node);
        }
    }

    // 添加子节点,在xpath添加Obj子节点,xpath必须为根路径后子节点
    this.InsertBeforeChild = function (xpath, Obj, value, AttribList, i) {
        Node = this.getNode(xpath, i);
        var edition = xmlDoc.createElement(Obj);
        var newtext = xmlDoc.createTextNode((value || ""));
        if (AttribList) {
            for (var i = 0; i < AttribList.length; i++) {
                var objNewAtt = xmlDoc.createAttribute(AttribList[i].name);
                if (isIE) {
                    objNewAtt.text = (AttribList[i].value || "");
                } else {
                    objNewAtt.value = (AttribList[i].value || "");
                }
                edition.attributes.setNamedItem(objNewAtt);
            }
        }
        edition.appendChild(newtext);
        Node.appendChild(edition);
    }


    // 在xpath同级添加节点Obj
    this.InsertChild = function (xpath, Obj, value, i) {
        Node = this.getNode(xpath,i);
        var edition = xmlDoc.createElement(Obj);
        var newtext = xmlDoc.createTextNode((value || ""));
        edition.appendChild(newtext);
        Node.parentNode.appendChild(edition);
    }

    // 在xpath下面创建一个<Str></Str>节点．
    this.CreateNodeS = function(xpath, Str) {
        NewNode = xmlDoc.createNode(1, Str, "");
        InsertChild(xpath, NewNode);
    }

    // 在xpath下添加属性名为 name 值为 value 的属性.
    this.addAttrib = function(xpath, name, value,index) {
        Node = this.getNode(xpath, index);
        var objNewAtt = xmlDoc.createAttribute(name);
        if (isIE) {
            objNewAtt.text = (value);
        } else {
            objNewAtt.value = (value);
        }
        Node.attributes.setNamedItem(objNewAtt);

        //Node.setAttributeNode(objNewAtt);
    }
    // 取得节点下的属性 attrib
    this.getAttrib = function (xpath, attrib, i) {
        if (i) {
            if (isIE) {
                xpath += "[" + (parseInt(i) - 1) + "]";
            } else {
                xpath += "[" + i + "]";
            }
        }
        return this.getChild(xpath + "/@" + attrib);
    }
    //删除属性
    this.delAttrib = function(xpath, attrib,Index) {
        var Node = this.getNode(xpath,Index);
        if (Node) {
            Node.removeAttribute(attrib);
        }
    }
    // 设置指定节点的属性值.如没有添加
    this.setAttrib = function(xpath, attrib, value,Index) {
        Node = this.getNode(xpath,Index).attributes;
        var i = 0;
        while (Node[i] != null) {
            if (Node[i].name == attrib) {
                if (isIE) {
                    Node[i].text =(value);
                } else {
                    Node[i].value = (value);
                }
                return true;
            }
            i++;
        }
        this.addAttrib(xpath, attrib, value);
        return true;
    }

    // 设置指定节点的值.
    this.setNodeValue = function(xpath, value) {
        Node = this.getNode(xpath);
        if (isIE) {
            Node.text = (value);
        } else {
            while (Node.childNodes.length > 0) {
                var NodeC = Node.childNodes[Node.childNodes.length-1];
                Node.removeChild(NodeC);
            }
            Node.appendChild(xmlDoc.createTextNode(value));
//            if (NodeC) {
//                NodeC.nodeValue = (value);
//            } else {
//                Node.appendChild(xmlDoc.createTextNode(value));
//            }
        }
    }

    // 查找XML中包含Str的所有路径.
    // 入口参数: Node   开始的节点
    //    xpath  当前节点的路径
    //    Str   所要查找的字符串
    // 出口参数: n   第n个查找到的节点
    //    Result  查找成功的节点数组
    // 特别注意:找到的结果是以反向存储在数组中.
    // 第一步:如果当前节点下有子节点,那么取出第一个子节点,进入循环.
    // 第二步:按XML顺序依次取出子节点
    // 第三步:过滤无效子节点.
    // 第四步:如果当前子节点属最底层节点,判断当前子节点是否包含了查找的字符串.
    // 第五步:否则查找当前子节点的兄弟点.
    // 第六步:如果当前子节点是带有孙子的节点,则进入递归.
    this.FindString = function(Node, Str, n, Result) {
        var i = 0;
        var a = "";
        while (Node.childNodes[i] != null) {
            a = Node.childNodes[i].nodeName;      // XML中的一个多的节点.名为#text,将它删除.
            if (a == "#text") { i++; continue; }
            n = FindString(Node.childNodes[i], Str, n, Result); // 因为Js不能传地址,那么我们可以将N返回到前面来,这样的结果才是正确的.
            if (Node.childNodes[i].childNodes[1] == null) {   // 如果当前节点下无子节点,那么,查找字符串.对查在成功者,加入 Result
                if ((Node.childNodes[i].text).indexOf(Str) != -1) {
                    Result[n] = Node.childNodes[i];
                    n++;
                }
            }
            i++;
        }
        return n;
    }
}