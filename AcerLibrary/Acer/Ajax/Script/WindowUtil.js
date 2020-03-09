/**
@fileoverview
開窗的共用函式

@class WindowUtil
開窗的共用函式

@author &#29256;&#27402;&#25152;&#26377; &#23439;&#30849;&#32929;&#20221;&#26377;&#38480;&#20844;&#21496; &copy;2006 Acer Inc.
@version 0.0.1
*/

/**
@constructor WindowUtil
*/
var	WindowUtil	=	new Object();

/**
@method WindowUtil.openPrintWindow
開啟列印用視窗(window.open 全螢幕)
@param	String	url		連結
@param	String	windowName	視窗名稱
@return	window	window 物件
*/
WindowUtil.openPrintWindow	=	function (url_, windowName)
{
	var	height_	=	screen.availHeight - 20;
	var	width_	=	screen.availWidth - 10;
	var	style_	=	"width=" + width_ + ",height=" + height_ + ",left=0,top=0,scrollbars=1,status=no,resizable=yes,titlebar=no";

	return _w().open(url_, windowName, style_);
	win_.moveTo(0, 0);
	return win_;
}

/**
@method WindowUtil.openThirdDialog
開啟第三層的視窗(視窗大小跟螢幕一樣)
@param	String	url		要開啟的連結
@param	String	debugMode	可不傳, null 為開啟 showModalDialog 傳值為 window.open
@return	Object	window 或 showModalDialog 物件
*/
WindowUtil.openThirdDialog	=	function (url_, debugMode)
{
	var	height_	=	screen.availHeight;
	var	width_	=	screen.availWidth;

	if (debugMode == null)
	{
		return _wu().openDialog(url_, width_, height_);
	}
	else
	{
		var	win_	=	_wu().openDialog(url_, width_, height_, "");
		win_.moveTo(0, 0);
		return win_;
	}
}

/**
@method WindowUtil.openObjDialog
開啟自訂傳遞元件的視窗(視窗大小跟螢幕一樣)
@param	String	url		要開啟的連結
@param	int	width		開啟的視窗寬度
@param	int	height		開啟的視窗寬度
@param	Object	obj		要傳遞給開啟視窗的元件
@param	String	debugMode	可不傳, null 為開啟 showModalDialog 傳值為 window.open
@return	Object	window 或 showModalDialog 物件
*/

WindowUtil.openObjDialog	=	function (url_, width_, height_, obj_, debugMode)
{
	if (debugMode == null)
		return _wu().openDialog(url_, width_, height_, null, obj_);
	else
		return	win_	=	_wu().openDialog(url_, width_, height_, " ");
}

/**
@method WindowUtil.openDialog
開啟指定寬度、高度的視窗(showModalDialog)
@param	String	url		要開啟的連結
@param	int	width		開啟的視窗寬度
@param	int	height		開啟的視窗高度
@param	Object	obj		可不傳, 要傳遞給開啟視窗的元件, 不傳預設傳呼叫的 self 物件
@return	Object	showModalDialog 物件
*/
var	openWinArgmentsObj;
WindowUtil.openDialog	=	function (url_, width_, height_)
{
	if (arguments[4] == null)
		openWinArgmentsObj	=	self;
	else
		openWinArgmentsObj	=	arguments[4];
		
	if (arguments[3] == null)
	{
		var	style_	=	"px;dialogWidth:" + width_ + "px;dialogHeight:" + height_ + "px;center:1;scroll:1;help:0;status:0;resizable:1";
		var	style1_	=	"modal=yes,width=" + width_ + ",height=" + height_ + ",left=0,top=0,status=no,scrollbars=yes,resizable=yes,titlebar=no";
		var	result;
		if (arguments[4] == null)
		{
			try{result	=	_w().showModalDialog(url_, self, style_);}catch(ex){result	=	_w().open(url_, "xxx" + (new Date()).getTime(), style1_);};
		}
		else
		{
			try{result	=	_w().showModalDialog(url_, arguments[4], style_);}catch(ex){result	=	_w().open(url_, "xxx" + (new Date()).getTime(), style1_);};
		}
		return result;
	}
	else
	{
		var	style_	=	"width=" + width_ + ",height=" + height_ + ",left=0,top=0,status=no,scrollbars=yes,resizable=yes,titlebar=no";

		return _w().open(url_, "xxx" + (new Date()).getTime(), style_);
	}
}

/**
@method WindowUtil.openExceptionWindow
開啟顯示錯誤訊息的視窗
@param	String	errMessage	錯誤訊息
@param	int	width		開啟的視窗寬度, 可不傳, 預設為 500
@param	int	height		開啟的視窗高度 可不傳, 預設為 600
@return	window	window 物件
*/
WindowUtil.openExceptionWindow	=	function (errMessage, width_, height_)
{
	if (width_ == null)
		width_	=	700;
	if (height_ == null)
		height_	=	550;

	var	LeftPosition	=	(screen.width) ? (screen.width - width_) / 2 : 0;
	var	TopPosition	=	(screen.height) ? (screen.height - height_) / 2 : 0;
	var	errWin_		=	_w().open('', 'errWin', 'height=' + height_ + ',width=' + width_ + ',scrollbars=yes');

	errWin_.document.writeln(errMessage);
	errWin_.document.close();
	errWin_.focus();
	errWin_.moveTo(LeftPosition, TopPosition);
	errWin_.document.body.scrollTop	=	'10000000';
	errWin_.document.title		=	'Script Error Report';
	return errWin_;
}
