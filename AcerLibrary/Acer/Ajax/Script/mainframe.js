/**
----------------------------------------------------------------------------------------
Vers 	Date		By			Notes
------	--------------	--------------		----------------------------------------
1.0.3	2006/12/21	nono			1. 新增加 showDetail 方法用來顯示 detailFrame 的網頁
						2. 調整 showView, hideView 方法多一個 detail 的比例
1.0.2	2006/12/08	nono			解決當開多個視窗時 Timeout 僅有當前畫面問題, 目前所有視窗皆會拉起 Timeout 視窗, 任一視窗登入即可
1.0.1	2006/04/19	nono			1. 增加 showView、hideView function
----------------------------------------------------------------------------------------
*/

/** 系統參數 */
var	baseIP___	=	'';
var	basePort___	=	'';
var	timer_		=	"";
var	processTime	=	1000 * 60;
var	masterTdIndex	=	"";
var	detailTdIndex	=	"";
var	externStr	=	"";
var	currWindow__	=	self;

/** 啟動計時器 */
function startTimer()
{
	stopTimer();
	timer_	=	setTimeout("showTimeout()", processTime);
}

/** 關閉計時器 */
function stopTimer()
{
	clearTimeout(timer_);
}

/** 顯示超出時間頁面 */
function showTimeout()
{
	var	obj_	=	"undefined";
	
	if (top.document.getElementById("topFrame").rows.split(",").length == 3)
		top.document.getElementById("topFrame").rows	= "0,0,*";
	else
		top.document.getElementById("topFrame").rows	= "0,*";

	/** 2006/12/08 新增加判斷開啟任意窗亦同樣拉起 Timeout 視窗 */	
	if (typeof(dialogArguments) != "undefined")
	{
		obj_	=	dialogArguments;

		while (true)
		{
			if (obj_.top.document.getElementById("topFrame").cols.split(",").length == 3)
				obj_.top.document.getElementById("topFrame").rows	= "0,0,*";
			else
				obj_.top.document.getElementById("topFrame").rows	= "0,*";
			
			if (typeof(obj_.dialogArguments) == "undefined")
				break;
				
			obj_	=	obj_.dialogArguments;
		}
	}
	
	if (typeof($.cookie) != "undefined")
		$.cookie('framepage_func', 'showTimeout()');
}

/** 隱藏超出時間頁面 */
function hideTimeOut()
{
	var	obj_	=	"undefined";
	
	if (top.document.getElementById("topFrame").rows.split(",").length == 3)
		top.document.getElementById("topFrame").rows	= "80,*,0";
	else
		top.document.getElementById("topFrame").rows	= "*,0";
		
	/** 2006/12/08 新增加判斷開啟任意窗亦同樣隱藏 Timeout 視窗 */	
	if (typeof(dialogArguments) != "undefined")
	{
		obj_	=	dialogArguments;

		while (true)
		{
			if (obj_.top.document.getElementById("topFrame").rows.split(",").length == 3)
				obj_.top.document.getElementById("topFrame").rows	= "80,*,0";
			else
				obj_.top.document.getElementById("topFrame").rows	= "*,0";
			
			if (typeof(obj_.dialogArguments) == "undefined")
				break;
				
			obj_	=	obj_.dialogArguments;
		}
	}
	
	if (typeof($.cookie) != "undefined")
		$.cookie('framepage_func', 'hideTimeOut()');
}

/** 顯示 viewFrame 頁面 */
function showView()
{
	top.document.getElementById("pageFrame").cols	=	"0,*,0";
}

/** 隱藏 viewFrame 頁面 */
function hideView()
{
	top.document.getElementById("pageFrame").cols	=	"*,0,0";
}

/** 顯示 detailFrame 頁面 */
function showDetail()
{
	top.document.getElementById("pageFrame").cols	=	"0,0,*";
}

function setProperty(_ip, _port, timeoutTime)
{
	baseIP___	=	_ip;
	basePort___	=	_port;
	processTime	=	timeoutTime * processTime;
	document.title	=	_ip;
}