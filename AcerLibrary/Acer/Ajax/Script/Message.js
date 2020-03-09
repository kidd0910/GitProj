doImport ("MessageContent.js, SuccessWindow.js");

/**
@fileoverview
定義訊息的共用函式
使用方法為
Message.getMessage("001");

@class Message
定義訊息的共用函式
使用方法為
Message.getMessage("001");

@author &#29256;&#27402;&#25152;&#26377; &#23439;&#30849;&#32929;&#20221;&#26377;&#38480;&#20844;&#21496; &copy;2006 Acer Inc.
@version 0.0.1
*/

/**
@constructor Message
*/
var	Message	=	new Object();

/**
@method Message.getMessage
取得訊息中文
@param	String	msgId	訊息代碼
@return	String	對應的訊息中文
*/
Message.getMessage	=	function (msgId)
{
	if (msgId.length != 3)
		return	msgId;

	var	strMsg	=	"";
	if (typeof(lang) == "undefined" || lang == 'ZH_TW')
		strMsg	=	MessageHashContent_[msgId];
	else
		strMsg	=	eval('MessageHashContent_' + lang)[msgId];
	
	if (strMsg == null)
		return "系統發生未知錯誤!";
	else
		return strMsg;
}

/**
@method Message.showMessage
顯示訊息, 將來可統一改變顯示模式成開窗或其他方法
@param	String	msgId	訊息代碼
*/
Message.showMessage	=	function (msgId)
{
	alert(Message.getMessage(msgId));
}

/**
@method Message.showConfirm
顯示訊息確認窗(是或否), 將來可統一改變顯示模式成開窗或其他方法
@param	String	msgId  訊息代碼
@return	boolean	是否確認
*/
Message.showConfirm	=	function (msgId)
{
	return confirm(this.getMessage(msgId));
}

function getDocHeight() 
{
	return Math.max(
		Math.max(__d.body.scrollHeight, __d.documentElement.scrollHeight),
		Math.max(__d.body.offsetHeight, __d.documentElement.offsetHeight),
		Math.max(__d.body.clientHeight, __d.documentElement.clientHeight)
	);
}

/**
@method Message.showProcess
顯示資料處理中
*/
Message.showProcess = function () {
    $("#AjaxPanel").mask("Waiting...");
}

Message.showProcessByID = function (id) {
    if (id != undefined) {
        $("#" + id).mask("Waiting...");
    }    
}

/**
@method Message.hideProcess
關閉資料處理中
*/
Message.hideProcess	=	function ()
{
    $("#AjaxPanel").unmask();
}

Message.hideProcessById = function (id) {
    if (id != undefined) {
        $("#" + id).unmask();
    }
}

/**
@method Message.openSuccess
顯示資料處理完成視窗
@param	String	messageId	可不傳, 為顯示訊息
*/
Message.openSuccess	=	function (messageId, processFunc)
{
	if (messageId == null)
		messageId	=	"A07";

	SuccessWindow.showMsg(this.getMessage(messageId), processFunc);
}

/**
@method Message.openFaile
顯示資料處理失敗視窗
@param	Object	ajaxData	顯示訊息
*/
Message.openFaile	=	function (ajaxData)
{
	Message.hideProcess();

	if (ajaxData.exception == null)
	{
		var	errStr	=	"<h2 style=\"color:red;text-align:center\">" + ajaxData.result + "</h2>" +
					"<hr size=1>" +
					"<center>" +
					"<input type=button value='C L O S E' id='closeBtn' onclick='top.close();'>" +
					"</center>";
		var	errWin	=	WindowUtil.openExceptionWindow(errStr, 400, 200);
		try{errWin.closeBtn.focus();}catch(ex){}
	}
	else
	{
		var	errStr	=	"<h2 style=\"color:red;text-align:center\">" + ajaxData.result + "</h2>" +
					"<font size=2><a href='javascript:show();'>顯示詳細訊息</a></font>" +
					"<hr size=1>" +
					"<pre id=exception style='display:none'>" + ajaxData.exception + "</pre>" +
					"<center>" +
					"<input type=button value='關　　閉'' id='closeBtn' onclick='top.close();'>" +
					"</center>"+
					"<script>" +
					"function show()" +
					"{" +
					"	var	LeftPosition	=	(screen.width) ? (screen.width - 700) / 2 : 0; " +
					"	var	TopPosition	=	(screen.height) ? (screen.height - 600) / 2 : 0; " +
					"	exception.style.display	=	'';" +
					"	window.resizeTo(700, 600); " +
					"	window.moveTo(LeftPosition, TopPosition); " +
					"}" +
					"<\/script>";
		var	errWin	=	WindowUtil.openExceptionWindow(errStr, 400, 200);
		try{errWin.closeBtn.focus();}catch(ex){}
	}
}

/**
@method Message.showDiv
墊在物件下層, 主要遮蔽下拉選單用
@param	Object	sDivID	物件 ID
@param	boolean	bState	true/false 隱藏/顯示
*/
Message.showDiv	=	function (sDivID, bState)
{
	var	objectDiv	=	_(sDivID);
	var	objectIframe	=	null;

	try
	{
		objectIframe	=	_d().getElementById(sDivID + '_HelpFrame');
		objectIframe.scrolling	=	'no';
	}
	catch (e)
	{
		objectIframe	=	_d().createElement('iframe');
		var	oParent		=	objectDiv.parentNode;
		objectIframe.id		=	sDivID + '_HelpFrame';
		oParent.appendChild(objectIframe);
	}
	
	objectIframe.frameborder	=	0;
	objectIframe.style.position	=	'absolute';
	objectIframe.style.top		=	'0px';
	objectIframe.style.left		=	'0px';
	objectIframe.style.display	=	'none';
	objectIframe.style.filter	=	"alpha(opacity=0)";

	if (bState)
	{
		objectDiv.style.display		=	'block';

		objectIframe.style.top		=	objectDiv.offsetTop + 'px';
		objectIframe.style.left		=	objectDiv.offsetLeft + 'px';
		objectIframe.style.zIndex	=	objectDiv.style.zIndex - 1;
		objectIframe.style.width	=	objectDiv.offsetWidth + 'px';
		objectIframe.style.height	=	objectDiv.offsetHeight + 'px';
		objectIframe.style.display	=	'block';
	}
	else
	{
		objectIframe.style.display	=	'none';
		objectDiv.style.display		=	'none';
	}
}