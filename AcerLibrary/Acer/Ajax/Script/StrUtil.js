/**
@fileoverview
定義字串的一般的共用函式
使用方法為
Exp:
StrUtil.trim(str);

@class StrUtil
定義字串的一般的共用函式
使用方法為
Exp:
StrUtil.trim(str);

@author &#29256;&#27402;&#25152;&#26377; &#23439;&#30849;&#32929;&#20221;&#26377;&#38480;&#20844;&#21496; &copy;2006 Acer Inc.
@version 0.0.1
*/

/**
@constructor StrUtil
*/
var	StrUtil	=	new Object();

/**
@method StrUtil.lTrim
去左邊空白
@param	String	str	要處理的字串
@return	String	去空白後的字串
*/
StrUtil.lTrim	=	function (str_)
{
	return (str_ + '')._r(/(^\s*)/g, "");
}

/**
@method StrUtil.rTrim
去右邊空白
@param	String	str	要處理的字串
@return	String	去空白後的字串
*/
StrUtil.rTrim	=	function (str_)
{
	return (str_ + '')._r(/(\s*$)/g, "");;
}

/**
@method StrUtil.trim
字串去前後空白
@param	String	str	要處理的字串
@return	String	去前後空白後的字串
*/
StrUtil.trim	=	function (str_)
{
	return (str_ + '')._r(/(^\s*)|(\s*$)/g,"");
}

/**
@method StrUtil.fillStr
將傳入的內容不足位時，於內容前方補足指定的字
@param	String	str		要處理的字串
@param	int	len		要檢核的長度
@param	String	fillStr	不足位時，於前方補足長度的指定字
@return	String	補足後的字串
*/
StrUtil.fillStr	=	function (str_, len_, fillStr_)
{
	str_	=	str_ + '';
	if (str_.length >= len_)
		return str_;

	var	tmpStr	=	str_;
	while(tmpStr.length != len_)
		tmpStr	=	'' + fillStr_ + tmpStr;

	return tmpStr;
}

/**
@method StrUtil.fillBStr
將傳入的內容不足位時，於內容前方補足指定的字
@param	String	str	要處理的字串(中文為兩碼)
@param	int	len	要檢核的長度
@param	String	fillStr	不足位時，於前方補足長度的指定字
@return	String	補足後的字串
*/
StrUtil.fillBStr	=	function (str_, len_, fillStr_)
{
	str_	=	str_ + '';
	if (StrUtil.getBLen(str_) >= len_)
		return str_;

	var	tmpStr	=	str_;
	while(StrUtil.getBLen(tmpStr) != len_)
		tmpStr	=	'' + fillStr_ + tmpStr;

	return tmpStr;
}

/**
@method StrUtil.fillZero
依輸入欄位設定的長度,不足長度時在資料前補零
@param	String	str	要處理的字串
@param	int	limit	長度
@return	String	補足後的字串
*/
StrUtil.fillZero	=	function (str_, limit_)
{
	str_	=	str_ + '';
	return StrUtil.fillStr(str_, limit_, '0');
}

/**
@method StrUtil.fillBZero
依輸入欄位設定的長度,不足長度時在資料前補零
@param	String	str	要處理的字串(中文為兩碼)
@param	int	limit	長度
@return	String	補足後的字串
*/
StrUtil.fillBZero	=	function (str_, limit_)
{
	str_	=	str_ + '';
	return StrUtil.fillBStr(str_, limit_, '0');
}

/**
@method StrUtil.fillBackStr
將傳入的內容不足位時，於內容後方補足指定的字
@param	String	str	要處理的字串
@param	int	len	要檢核的長度
@param	String	fillStr	不足位時，於後方補足長度的指定字
@return	String	補足後的字串
*/
StrUtil.fillBackStr	=	function (str_, len_, fillStr_)
{
	str_	=	str_ + '';
	if (str_.length >= len_)
		return str_;

	var	tmpStr	=	str_;
	while(tmpStr.length != len_)
		tmpStr	=	'' + tmpStr + fillStr_;

	return tmpStr;
}

/**
@method StrUtil.fillBackBStr
將傳入的內容不足位時，於內容後方補足指定的字
@param	String	str	要處理的字串(中文為兩碼)
@param	int	len	要檢核的長度
@param	String	fillStr	不足位時，於後方補足長度的指定字
@return	String	補足後的字串
*/
StrUtil.fillBackBStr	=	function (str_, len_, fillStr_)
{
	str_	=	str_ + '';
	if (StrUtil.getBLen(str_) >= len_)
		return str_;

	var	tmpStr	=	str_;
	while(StrUtil.getBLen(tmpStr) != len_)
		tmpStr	=	'' + tmpStr + fillStr_;

	return tmpStr;
}

/**
@method StrUtil.fillBackZero
依輸入欄位設定的長度,不足長度時在資料後補零
@param	String	str	要處理的字串
@param	int	limit	長度
@return	String	補足後的字串
*/
StrUtil.fillBackZero	=	function (str_, limit_)
{
	str_	=	str_ + '';
	return StrUtil.fillBackStr(str_, limit_, '0');
}

/**
@method StrUtil.fillBackBZero
依輸入欄位設定的長度,不足長度時在資料後補零
@param	String	str	要處理的字串(中文為兩碼)
@param	int	limit	長度
@return	String	補足後的字串
*/
StrUtil.fillBackBZero	=	function (str_, limit_)
{	
	str_	=	str_ + '';
	return StrUtil.fillBackBStr(str_, limit_, '0');
}

/**
@method StrUtil.getBLen
字串實際長度
@param	String	str	要處理的字串
@return	int	實際長度
*/
StrUtil.getBLen	=	function (str_)
{
    //alert(1);
	str_	=	str_ + '';
	var	matchAry	=	(str_ + '').match(/[^\x00-\xff]/ig);
	return str_.length + (matchAry == null?0 : matchAry.length);
}

/**
@method StrUtil.getCount
抓取字串包含某字串的總數
@param	String	str		要處理的字串
@param	String	containStr	包含某字串
@param	String	mode		不傳表區分大小寫, 傳入任意值表示不分大小寫
@type	int
@return	int	總數
*/
StrUtil.getCount	=	function (str_, containStr_, mode_)
{
	str_	=	str_ + '';
	return eval("(str_ + '').match(/(" + containStr_ + ")/g" + (mode_?"i":"")+").length");
}


/**
@method StrUtil.getBStr
傳回指定長度字串(中文為兩碼)
@param	String	str	要處理的字串
@param	int	len	截取長度
@return	String	指定長度字串
*/
StrUtil.getBStr	=	function (str_, len_)
{
	str_ 	=	str_  + '';
	var	bStr_	=	"";
	var	bLength	=	0;

	for (var i = 0; i < str_.length; i++)
	{
		if(str_.charCodeAt(i) == 13 || str_.charCodeAt(i) == 10)
		{
			bStr_	=	bStr_ + str_.substr(i, 1);
			continue;
		}

		if (str_.charCodeAt(i) >= 128 || str_.charCodeAt(i) <= -128)
			bLength	=	bLength + 2;
		else
			bLength++;

		if (bLength > len_)
			return bStr_;
		else
			bStr_	=	bStr_ + str_.substr(i, 1);
	}
	return bStr_;
}

/*
@method StrUtil.setPageArgument
設定連結的參數
Exp:
"http://localhost/xx/xx.jsp?xx=xx&vv=vv"
xx, a1 --> "http://localhost/xx/xx.jsp?xx=a1&vv=vv"
oo, a2 --> "http://localhost/xx/xx.jsp?xx=a1&vv=vv&oo=a2"
@param	String	str	要處理的字串
@param	String	name	要設定的參數
@param	String	value	要設定的值
@return	String	目前的頁面名稱
*/
StrUtil.setPageArgument	=	function (str_, name_, value_)
{
	var	baseUrl	=	(str_ + '')._r(/#/, '');

	if (baseUrl._i("?") == -1)
		baseUrl	=	baseUrl + "?" + name_ + "=" + value_;
	else if (baseUrl._i("?" + name_ + "=") == -1 && baseUrl._i("&" + name_ + "=") == -1)
		baseUrl	=	baseUrl + "&" + name_ + "=" + value_;
	else
	{
		var	startIndex	=	baseUrl._i("?" + name_ + "=") == -1?baseUrl._i("&" + name_ + "="):baseUrl._i("?" + name_ + "=");
		var	endStr		=	baseUrl._s(startIndex + 1, baseUrl.length);

		if (endStr._i("&") == -1)
			baseUrl	=	baseUrl._s(0, startIndex + 1) + name_ + "=" + value_;
		else
			baseUrl	=	baseUrl._s(0, startIndex + 1) + name_ + "=" + value_ + endStr._s(endStr._i("&"), endStr.length);
	}

	return baseUrl;
}

/*
@method StrUtil.getCurrentPage
取得目前的頁面名稱
Exp:
"http://localhost/xx/xx.jsp?xx=xx&vv=vv" --> xx.jsp
@param	String	str	要處理的字串
@return	String	目前的頁面名稱
*/
StrUtil.getCurrentPage	=	function (str_)
{
	str_	=	str_ + '';
	var	baseUrl	=	StrUtil.getBaseUrl(str_);

	return baseUrl.split('/')[baseUrl.split('/').length - 1];
}

/*
@method StrUtil.getBaseUrl
取得基本的連結
Exp: "http://localhost/xx/xx.jsp?xx=xx&vv=vv"	--> http://localhost/xx/xx.jsp
@param	String	str	要處理的字串
@return	String	基本的連結
*/
StrUtil.getBaseUrl	=	function (str_)
{
	if ((str_ + '')._i('?') == -1)
		return str_;
	else
		return str_.substr(0, (str_ + '')._i('?'));
}

/**
@method StrUtil.convertStr
將字串反向, 例如: '1234', 傳回 '4321'
@param	String	str	要處理的字串
@return	String	反向後的字串
*/
StrUtil.convertStr	=	function (str_)
{
	str_	=	str_ + '';
	var	result	=	"";
	
	for(i = str_.length - 1; i >= 0; i--)
		  result	=	result + (str_ + '')._c(i);

	return result;
}

/**
@method StrUtil.urlEncode
將字串編碼(呼叫 encodeURIComponent 處理)
@param	String	str	要處理的字串
@return	String	編碼後的字串
*/
StrUtil.urlEncode	=	function (str_)
{
	str_	=	str_ + '';
	return encodeURIComponent(str_);
}

/**
@method StrUtil.urlDecode
將字串解碼(呼叫 decodeURIComponent 處理)
@param	String	str	要處理的字串
@return	String	編碼後的字串
*/
StrUtil.urlDecode	=	function (str_)
{
	str_	=	str_ + '';
	return decodeURIComponent(str_);
}