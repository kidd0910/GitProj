doImport ("Message.js");

/**
@fileoverview
定義 Success 視窗的共用函式
使用方法為
var	success_	=	new SuccessWindow();
<!-- 可不設
success_.headerStr	=	"[系 統 訊 息]";	//標題字串 	(預設 [系 統 訊 息])
success_.bgColor	=	"#cfdef4";		//背景顏色	(預設 #cfdef4)
success_.headerFontColor=	"#1f336b";		//標題字顏色	(預設 #1f336b)
success_.borderTop	=	"#728eb8 1px solid";	//上框格式	(預設 #728eb8 1px solid)
success_.borderBottom	=	"#b9c9ef 1px solid";	//下框格式	(預設 #b9c9ef 1px solid)
success_.fontColor	=	"#ca0000";		//內容字型顏色	(預設 #ca0000)
可不設  -->
success_.showMsg("訊息", 1000);

@class SuccessWindow
定義 Success 視窗的共用函式
使用方法為
var	success_	=	new SuccessWindow();
<!-- 可不設
success_.headerStr	=	"[系 統 訊 息]";	//標題字串 	(預設 [系 統 訊 息])
success_.bgColor	=	"#cfdef4";		//背景顏色	(預設 #cfdef4)
success_.headerFontColor=	"#1f336b";		//標題字顏色	(預設 #1f336b)
success_.borderTop	=	"#728eb8 1px solid";	//上框格式	(預設 #728eb8 1px solid)
success_.borderBottom	=	"#b9c9ef 1px solid";	//下框格式	(預設 #b9c9ef 1px solid)
success_.fontColor	=	"#ca0000";		//內容字型顏色	(預設 #ca0000)
可不設  -->
success_.showMsg("訊息", 1000);

@author &#29256;&#27402;&#25152;&#26377; &#23439;&#30849;&#32929;&#20221;&#26377;&#38480;&#20844;&#21496; &copy;2006 Acer Inc.
@version 0.0.1
*/

var	SuccessWindow	=	new Object();

/**
@constructor SuccessWindow
*/
SuccessWindow.init	=	function ()
{
	/** 建立 Div */
	var	divObject	=	_d().createElement("div");
	divObject.setAttribute("id", "__SuccessWindow");
	var	style_		=	divObject.style;
	style_.borderRight	=	"#455690 1px solid";
	style_.borderLeft	=	"#a6b4cf 1px solid";
	style_.borderTop	=	"#a6b4cf 1px solid";
	style_.bordeBottom	=	"#455690 1px solid";
	style_.zIndex		=	"9999999";
	style_.left		=	"64px";
	style_.visibility	=	"hidden";
	style_.width		=	"168px";
	style_.position		=	"absolute";
	style_.top		=	"0px";
	style_.height		=	"115px";
	style_.backgroundColor	=	"#c9d3f3";

	_d().body.appendChild(divObject);
}

/** Div 高度 divHeight */
_s()._dh	=	0;
/** Div 寬度 divWidth */
_s()._dw	=	0;
/** document 寬度 docWidth */
_s()._cw	=	0;
/** document 高度 docHeight */
_s()._ch	=	0;
/** Timer timer */
_s()._t		=	null;

/** 標題字串 */
_s().headerStr	=	"[系 統 訊 息]";
/** 背景顏色 */
_s().bgColor		=	"#cfdef4";
/** 標題字顏色 */
_s().headerFontColor	=	"#1f336b";
/** 上框格式 */
_s().borderTop	=	"#728eb8 1px solid";
/** 下框格式 */
_s().borderBottom	=	"#b9c9ef 1px solid";
/** 內容字型顏色 */
_s().fontColor	=	"#ca0000";

/** 設定視窗內容 */
_s().setContent_	=	function (_message)
{
	_("__SuccessWindow").innerHTML	=	"<table style='border-top:#ffffff 1px solid;border-left:#ffffff 1px solid' cellSpacing='0' cellPadding='0' width='100%' bgColor='" + this.bgColor + "' border='0'>" +
						"	<tr>" +
						"		<td style='padding-left:2px;font-size:12px;color:" + this.headerFontColor + ";margin-left:118px' width='100%'>" +
						"			<strong>" + this.headerStr + "</strong>" +
						"		</td>" +
						"		<td align='right' width='192'>" +
						"			<span title='關閉' style='font-weight:bold;font-size:12px;cursor:pointer;color:white;margin-right:3px;background-color:#FF8080' onclick='_s().hideBox()'>&nbsp;× </span>" +
						"		</td>" +
						"	</tr>" +
						"	<tr>" +
	 					"		<td style='padding-right:1px;padding-bottom:0px;' align=center valign='middle' colSpan='3' height='90'>" +
	 					"			<div style='border-right:#b9c9ef 1px solid;border-top:" + this.borderTop + ";padding-left:3px;font-size:14px;padding-bottom:13px;border-left:" + this.borderTop + ";width:97%;color:" + this.fontColor + ";padding-top:18px;border-bottom:" + this.borderBottom + ";height:100%'>" +
	 					"				<br><strong id='SuccessMessage_'>" + _message + "</strong>" +
	 					"			</div>" +
	 					"		</td>" +
	 					"	</tr>" +
	 					"</table>";
 	Message.showDiv ("__SuccessWindow", 1);
}

/**
@method SuccessWindow.prototype.showMsg
顯示完成視窗 (直接顯示)
@param	String	message		顯示訊息
*/
_s().showMsg	=	function (_message, processFunc)
{
	if (_d().getElementById("__SuccessWindow") == null)
	{
		_w().setTimeout(Function("_s().showMsg('" + _message + "', '" + processFunc + "')"), 100);
		return;
	}

	this.setContent_(_message);

	var	successObj	=	_("__SuccessWindow");
	var	bodyObj		=	_d().body;
	var	style_		=	successObj.style;

	var	divTop		=	_p(style_.top);
	var	divLeft		=	_p(style_.left);
	_s()._dh		=	_p(successObj.offsetHeight);
	_s()._dw		=	_p(successObj.offsetWidth);
	_s()._cw		=	bodyObj.clientWidth;
	_s()._ch		=	bodyObj.clientHeight;
	
	//=== 置中 ===
	//	style_.top		=	(bodyObj.clientHeight / 2) - 60;
	//	style_.left		=	(bodyObj.clientWidth / 2) - 84;
	
	//=== 右下 ===
		style_.top		=	_p(bodyObj.scrollTop) + _s()._ch - _s()._dh - 20;
		style_.left		=	_p(bodyObj.scrollLeft) + _s()._cw - _s()._dw - 20;
	
	style_.visibility	=	"visible";
	Message.showDiv ("__SuccessWindow", 1);
	
	/** 顯示時間 */
	var	messageTime_	=	top._publicMessageTime;
	messageTime_	=	(typeof(_privateMessageTime) == "undefined" || _privateMessageTime == -1) ? top._publicMessageTime : _privateMessageTime;

	var	doFunc	=	function ()
	{
		SuccessWindow.hideBox();
		if (processFunc != null)
			_ev(processFunc);
	}
	_w().setTimeout(doFunc, messageTime_);
}

/**
@method SuccessWindow.prototype.hideBox
關閉視窗 Div
*/
_s().hideBox	=	function ()
{
	_("__SuccessWindow").style.visibility	=	'hidden';
	Message.showDiv ("__SuccessWindow", 0);
}

$(_d()).ready(SuccessWindow.init);