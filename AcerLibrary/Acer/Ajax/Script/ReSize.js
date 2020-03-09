/**
@fileoverview
主要是用來使物件可用拖拉改變尺寸的物件
使用方法：
在想被拖拉物件加上 resize='on' 即可
Exp:
&lt;textarea resize="on">&lt;/textarea>

@class ReSize
主要是用來使物件可用拖拉改變尺寸的物件
使用方法：
在想被拖拉物件加上 resize='on' 即可
Exp:
&lt;textarea resize="on">&lt;/textarea>

@author &#29256;&#27402;&#25152;&#26377; &#23439;&#30849;&#32929;&#20221;&#26377;&#38480;&#20844;&#21496; &copy;2006 Acer Inc.
@version 0.0.1
*/

/**
@constructor ReSize
*/
var	ReSize	=	new Object();

ReSize.init	=	function ()
{
	/** @private resizeObj */
	this._r	=	null;
	/** @private dir */
	this._di	=	"";
	/** @private grabx */
	this._gx	=	null;
	/** @private graby */
	this._gy	=	null;
	/** @private width */
	this._w	=	null;
	/** @private height */
	this._h	=	null;
	/** @private left */
	this._l	=	null;
	/** @private top */
	this._t	=	null;
}

/** currResizeObject */
ReSize._c	=	null;

/** 取得方向 */
ReSize.getDirection	=	function (resizeObj)
{
	var xPos, yPos, offset_, dir_;
	dir_	=	"";
	xPos	=	event.offsetX;
	yPos	=	event.offsetY;
	offset_	=	8;
	if (yPos < offset_)
		dir_	+=	"n";
	else if (yPos > resizeObj.offsetHeight - offset_)
		dir_	+=	"s";

	if (xPos < offset_)
		dir_	+=	"w";
	else if (xPos > resizeObj.offsetWidth - offset_)
		dir_	+=	"e";
	return dir_;
}

/** 滑鼠按下 */
ReSize.doDown	=	function ()
{
	if (!window.event)
		return;
	
	var	resizeObj	=	ReSize.getReal(event.srcElement);
	if (resizeObj == null)
	{
		ReSize._c	=	null;
		return;
	}
	
	var	dir_	=	ReSize.getDirection(resizeObj);
	if (dir_ == "")
		return;

	/** 初始化 ReSize 物件 */
	ReSize._c	=	ReSize;
	ReSize._c._r	=	resizeObj;
	ReSize._c._di	=	dir_;
	ReSize._c._gx	=	event.clientX;
	ReSize._c._gy	=	event.clientY;
	ReSize._c._w	=	resizeObj.offsetWidth;
	ReSize._c._h	=	resizeObj.offsetHeight;
	ReSize._c._l	=	resizeObj.offsetLeft;
	ReSize._c._t	=	resizeObj.offsetTop;
	
	event.returnValue	=	false;
	event.cancelBubble	=	true;
}

/** 滑鼠按鈕起移除物件 */
ReSize.doUp	=	function ()
{
	if (!window.event)
		return;
	
	if (ReSize._c != null)
		ReSize._c._r.className	=	'';
	ReSize._c	=	null;
	delete	ReSize._c;
}

/** 滑鼠移動設定游標及設定寬及高度 */
ReSize.doMove	=	function ()
{
	if (!window.event)
		return;
	
	var resizeObj, xPos, yPos, str, xMin, yMin;
	xMin		=	1;
	yMin		=	1;
	resizeObj	=	ReSize.getReal(event.srcElement);

	if (resizeObj != null)
	{
		str	=	ReSize.getDirection(resizeObj);
		if (str == "")
			str	=	"default";
		else
			str	+=	"-resize";
		resizeObj.style.cursor	=	str;
	}

	if(ReSize._c != null)
	{
		if (ReSize._c._di.indexOf("e") != -1)
			ReSize._c._r.style.width	=	Math.max(xMin, ReSize._c._w + event.clientX - ReSize._c._gx) + "px";

		if (ReSize._c._di.indexOf("s") != -1)
			ReSize._c._r.style.height	=	Math.max(yMin, ReSize._c._h + event.clientY - ReSize._c._gy) + "px";
		
		if (ReSize._c._di.indexOf("w") != -1)
		{
			ReSize._c._r.style.left		=	Math.min(ReSize._c._l + event.clientX - ReSize._c._gx, ReSize._c._l + ReSize._c._w - xMin) + "px";
			ReSize._c._r.style.width	=	Math.max(xMin, ReSize._c._w - event.clientX + ReSize._c._gx) + "px";
		}
		if (ReSize._c._di.indexOf("n") != -1)
		{
			ReSize._c._r.style.top		=	Math.min(ReSize._c._t + event.clientY - ReSize._c._gy, ReSize._c._t + ReSize._c._h - yMin) + "px";
			ReSize._c._r.style.height	=	Math.max(yMin, ReSize._c._h - event.clientY + ReSize._c._gy) + "px";
		}
		
		ReSize._c._r.className	=	"wrapper";
		event.returnValue	=	false;
		event.cancelBubble	=	true;
	}
}

/** 取得要設定的物件 */
ReSize.getReal	=	function (resizeObj)
{
	var	tempObj	=	resizeObj;
	while ((tempObj != null) && (tempObj.tagName != "BODY"))
	{
		if (tempObj.resize != null && tempObj.resize.toUpperCase() == "ON")
		{
			resizeObj	=	tempObj;
			return resizeObj;
		}
		tempObj	=	tempObj.parentElement;
	}
	return null;
}

$(_d()).bind("mousedown",	ReSize.doDown);
$(_d()).bind("mouseup",		ReSize.doUp);
$(_d()).bind("mousemove",	ReSize.doMove);
_d().write ("<style>.wrapper {border: 1px dashed #808080;}<\/style>");

ReSize.init();