var	_df=2;//1-yyymmdd 2-yyyymmdd
var	__package	=	new Array();
var	__lo	=	new Object();
var	__d	=	document;

function _gl(ajaxType)
{
	return _vp + "utility/Ajax/" + ajaxType + ".aspx";
}

function doImport(fileName)
{
	var	importAry	=	fileName.split(",");
	for (var i = 0; i < importAry.length; i++)
	{
		_ip(importAry[i]._r(/(^\s*)|(\s*$)/g,""));
	}
}

function _ip(fileName)
{
	for (var i = 0; i < __package.length; i++)
	{
		if (__package[i] == fileName)
			return;
	}
	__package[__package.length]	=	fileName;
	var	js	=	fileName.replace(/.js/g,'');
	try
	{
		try
		{
			top.dialogArguments.top.libObj[js];
			top.libObj[js]	=	top.dialogArguments.top.libObj[js];
		}
		catch(e1)
		{
			try
			{
				top.opener.top.libObj[js];
				top.libObj[js]	=	top.opener.top.libObj[js];
			}
			catch(e2)
			{}
		}
		if (top.libObj[js]!=null && __lo[js]==null)
		{
			_ev(top.libObj[js]);
			__lo[js]='Y';
			return;
		}
	}
	catch(ex)
	{}
	//if (fileName.indexOf('MessageContent') != -1)
	//{
		var code = $.ajax({
		url: _vp + "script/" + fileName,
		async: false
		}).responseText;
		_ev(code);
		try{top.libObj[js]=code;}catch(ex){}
	//}
	//else
	//{
	//	var path=_gl("LoadScript") + "?scriptName=" + fileName;
	//	var code = $.ajax({
	//	url: path,
	//	async: false
	//	}).responseText;
	//	_ev(code);
	//	__lo[js]='Y';
	//	try{top.libObj[js]=code;}catch(ex){}
	//}
}

function _()
{
var	result	=	new Array();
for (var i = 0; i < arguments.length; i++)
result[i]	=	($('#' + arguments[i]).length == 1)?$('#' + arguments[i])[0]:$('#' + arguments[i]);
if (arguments.length == 1)
return result[0];
else
return result;
}
__Base__WinObj	=	self;
function _w(_winObj)
{
if (_winObj != null)
__Base__WinObj	=	_winObj;
else
return __Base__WinObj;
}
function _i(formName, inputName)
{
return _w().document.forms[formName].elements[inputName];
}
function _e(e)
{
return window.event ? e.keyCode : e.which;
}
function _se(e)
{
return window.event ? e.srcElement : e.target;
}
function _rv(e)
{
window.event ? e.returnValue = false : e.preventDefault();
}
function _d()
{
return document;
}
function _p(str)
{
return parseInt(str, 10);
}
function _ce(id)
{
return _d().createElement(id);
}
function _du()
{
return DateUtil;
}
function _wu()
{
return WindowUtil;
}
function _fe()
{
return FormEvent;
}
function _d()
{
return document;
}
function _fz(str, num)
{
return StrUtil.fillZero(StrUtil.trim(new String(str)), num);
}
function _t(str)
{
    //return StrUtil.trim(new String(str));
    return $.trim(str);
}
function _s()
{
return SuccessWindow;
}
String.prototype._s	=	function (s_, e_)
{
return this.substring(s_, e_);
}
String.prototype._r	=	function (regexp, s_)
{
return this.replace(regexp, s_);
}
String.prototype._i	=	function (s_)
{
return this.indexOf(s_);
}
String.prototype._c	=	function (s_)
{
return this.charAt(s_);
}
function _c()
{
return Calendar;
}
function _it(obj, v_)
{
if (v_ == null)
return obj.innerText ? obj.innerText : obj.textContent;
else
obj.innerText ? obj.innerText = v_ : obj.textContent = v_;
}
function _ev(code)
{
jQuery.globalEval(code);
}
/** 
回查詢頁 
*/
function doBackViewFrame() {
    //=== 若查詢過才呼叫查詢 Frame 重新 bindgrid ===
    if (chkHasQuery2())
        parent.viewFrame.reQuery();

    self.location.href = 'about:blank';

    //=== 關閉新增 Frame ===
    fs = top.document.getElementById("pageFrame");
    fs.cols = "0,*,0"
}

/* 
判斷是否查詢過 
**/
function chkHasQuery2() {
    if (parent.viewFrame._("DataGrid").rows != null || parent.viewFrame.$(".txtRed").length > 0)
        return true;
}
/** 
處理清除動作 
*/
function doClear2() {
    if (_i(0, "Mode").value == "ADD")
        parent.viewFrame.doAdd1_3();
    else if (_i(0, "Mode").value == "MOD")
        parent.viewFrame.doEdit1_2();
}
/** 
新增功能時呼叫 
*/
function doAdd1_3() {
    var argusNameAry = ["Mode"];
    var argusValueAry = ["ADD"];

    top.rowKey = null;

    //=== 呼叫新增 ===
    sendData(viewpage2, "viewFrame2", argusNameAry, argusValueAry);

    //=== 開啟新增 Frame ===
    fs = top.document.getElementById("pageFrame");
    fs.cols = "0,0,*"
}

/**
按下編輯時呼叫
@param	keyStr	參數 KEY|VALUE
@param	typw	處理種類 Mod - 編, Detail - 詳
*/
var last_KetStr;
function doEdit1_3(td, keyStr, type) {
    try {
        var tr = td.parentNode;
        top.rowKey = tr.parentNode.parentNode.id + "," + tr.KEY;
        tr.className = top._scrollClickClassName;
    }
    catch (ex) {
    }
    if (keyStr == null) {
        keyStr = last_KetStr;
        type = "Mod"
    }
    else
        last_KetStr = keyStr

    var argusNameAry = ["Mode"];
    var argusValueAry = [type.toUpperCase()];

    var keyAry = keyStr.split("|");
    for (var i = 0; i < keyAry.length; i += 2) {
        argusNameAry[argusNameAry.length] = keyAry[i];
        argusValueAry[argusValueAry.length] = keyAry[i + 1];
    }

    sendData(viewpage2, "viewFrame2", argusNameAry, argusValueAry);

    //=== 開啟新增 Frame ===
    fs = top.document.getElementById("pageFrame");
    fs.cols = "0,0,*"
}