﻿//### AjaxScript ###
/**
頁面載入事件, 處理記憶體回收
*/
function page_init_start()
{
	try
	{
		var	top_	=	getTop();
		var	nonCheckIndexAry	=	[];
		for (var i = 0; i < columnCodeAry1.length; i++)
		{
			if (readOnlyColumn.indexOf(',' + columnCodeAry1[i] + ',') != -1)
				nonCheckIndexAry[nonCheckIndexAry.length]	=	i;
		}

		//=== 記錄到全域範圍 ===
		if (top_.columnFilterRecord == null)
			top_.columnFilterRecord	=	{};
		top_.columnFilterRecord[recordName1]	=	nonCheckIndexAry.toString();

		//=== 處理欄位隱藏動作 ===
		setColumnHide();
	}
	catch(ex)
	{
	}
	
	try
	{
		//=== 欄位篩選多國語系處理 ===
		try{_i(0, 'FILTER_BTN1').value=Message.getMessage('601')}catch(ex){}
		
		//=== 預設 Focus 在第一個位置上 ===
		for (var i = 0; i < _d().forms[0].length; i++)
		{
			if (_i(0, i).type == 'text' && Form.canFocus(_i(0, i)))
				return;
		}
	}
	catch(ex)
	{
	}
	try{CollectGarbage();}catch(ex){};
}

/**
按鈕變色事件
*/
function setButtonEvent()
{
	var	fObj;
	for (var i = 0; i < document.forms[0].length; i++)
	{
		fObj	=	_i(0, i);
		if (Form.isButoon(fObj))
		{
			$(_i(0, i)).bind('mouseover', buttonMouseOver);
			$(_i(0, i)).bind('mouseleave', buttonMouseLeave);
		}
	}
	
	try{_i(0, 'QUERY_BTN2').parentNode.innerHTML = "&nbsp;";}catch(ex){}
}

function buttonMouseOver(event_)
{
	if (!_se(event_).disabled)
		_se(event_).className	=	'btnhov';
}

function buttonMouseLeave(event_)
{
	if (!_se(event_).disabled)
		_se(event_).className	=	'btn';
}

/** 
資料檢核處理, 
檢核是否空白 'ChkForm' 或是 iniFormSet 屬性 Double Check 
@blockName	區塊名稱
*/
function valideMessage(blockName)
{
	//=== Double Check iniFormSet 型態資料 ===
	if (!reCheckIniFormSet(blockName))
	{
		Form.errMessage		=	null;
		return false;
	}
	
	//=== 檢核設定欄位 ===
	startChkForm(blockName)

	//=== 有錯誤顯示錯誤訊息窗 ===
	if (Form.errMessage != null && Form.errMessage.toString() != "")
	{
		//=== 顯示錯誤訊息 ===
		Form.showErrMessage();

		return false;
	}
	return true;
}

/** 
Double Check iniFormSet 型態資料
@blockName	區塊名稱
*/
function reCheckIniFormSet(blockName)
{
	var	formObj		=	_d().forms[0];
	var	inputObjreCheckIniFormSet	=	null;

	for (var i = 0; i < formObj.length; i++)
	{
		inputObj	=	formObj.elements[i];
		
		try
		{
			if (inputObj.name.substring(0, 2) != blockName)
				continue;
				
			if (inputObj.value == '')
				continue;
		}
		catch(ex)
		{
			continue;
		}
		
		var	type	=	$(inputObj).attr("IniFormSet") == null ? "" : $(inputObj).attr("IniFormSet");
		var	dd	=	$(inputObj).attr("DD") == null ? "" : $(inputObj).attr("DD");
		var	skip	=	$(inputObj).attr("SKIP") == null ? "" : $(inputObj).attr("SKIP");
		var	showName=	($(inputObj).attr("CNAME") != null) ? $(inputObj).attr("CNAME") : inputObj.name;
		
		if (skip == 'Y')
			continue;
		
		//=== M - 最長長度 ===
		if (type.indexOf("'M'") != -1 && (inputObj.value.length > inputObj.maxLength))
		{
			//該欄位長度超過限制
			alert('[' + showName + ']' + Message.getMessage("201"));
			Form.canFocus(inputObj);
			return false;
		}
		//=== A - 金額型態 ===
		if ((dd == "A" || dd == "N3") && isNaN(inputObj.value.replace(/,/g, '')))
		{
			//該欄位資料型態有誤, 請檢查
			alert('[' + showName + ']' + Message.getMessage("202"));
			Form.canFocus(inputObj);
			return false;
		}
		//=== N - 數字型態 ===
		if (dd == "N" && (isNaN(inputObj.value) || inputObj.value.indexOf('.') != -1 || inputObj.value == '-'))
		{
			//該欄位必須為數字型態資料
			alert('[' + showName + ']' + Message.getMessage("203"));
			Form.canFocus(inputObj);
			return false;
		}
		//=== N1 - 純數字, Z - 數字前補 0 ===
		if (dd == "N1" || dd == "N2" || dd == "Z")
		{
			var	reg	=	/^([0-9])+$/g ;
			if (inputObj.value.match(reg) == null)
			{
				//該欄位必須為純數字型態資料
				alert('[' + showName + ']' + Message.getMessage("204"));
				Form.canFocus(inputObj);
				return false;
			}
		}
		//=== E 英數型態 ===
		if (dd == "E")
		{
			var	reg	=	/^([0-9]|[a-z]|[A-Z])+$/g ;
			if (inputObj.value.match(reg) == null)
			{
				//該欄位僅能包含英數型態資料
				alert('[' + showName + ']' + Message.getMessage("205"));
				Form.canFocus(inputObj);
				return false;
			}
		}
		//=== EL 英數小寫(含符號)型態 ===
		if (dd == "EL")
		{
			var	reg	=	/([A-Z])+$/g ;
			if (inputObj.value.match(reg) != null || StrUtil.getBLen(inputObj.value) != inputObj.value.length)
			{
				//該欄位僅能包含英數小寫型態資料
				alert('[' + showName + ']' + Message.getMessage("206"));
				Form.canFocus(inputObj);
				return false;
			}
		}
		//=== EL 英數大寫(含符號)型態 ===
		if (dd == "EU" || dd == "EU1")
		{
			var	reg	=	/([a-z])+$/g ;
			if (inputObj.value.match(reg) != null || StrUtil.getBLen(inputObj.value) != inputObj.value.length)
			{
				//該欄位僅能包含英數大寫型態資料
				alert('[' + showName + ']' + Message.getMessage("207"));
				Form.canFocus(inputObj);
				return false;
			}
		}
		//=== EL 英數(含符號)型態 ===
		if (dd == "EW")
		{
			if (StrUtil.getBLen(inputObj.value) != inputObj.value.length)
			{
				//該欄位僅能包含英數(含符號)型態資料
				alert('[' + showName + ']' + Message.getMessage("208"));
				Form.canFocus(inputObj);
				return false;
			}
		}
		//=== EN, SE 英數型態 ===
		if ((type.indexOf("'EN'") != -1 || type.indexOf("'SE'") != -1) && inputObj.value.length != StrUtil.getBLen(inputObj.value))
		{
			//該欄位不能包含中文資料
			alert('[' + showName + ']' + Message.getMessage("209"));
			Form.canFocus(inputObj);
			return false;
		}
		//=== CD 國曆型態 ===
		if (dd == "CD")
		{
			//2011/05/23 nono 加上, 有可能未輸滿七位後端檢查會死掉
			var	date 	=	inputObj.value._r(/\/\s*/g, "");
			if (date.length == 6)
				inputObj.value	=	'0' + inputObj.value;
		}

		//=== CD 國曆型態 ===
		if (dd == "CD" && !Check.isCDate(inputObj.value))
		{
			//該欄位必須為國曆型態
			alert('[' + showName + ']' + Message.getMessage("210"));
			Form.canFocus(inputObj);
			return false;
		}
		//=== D 西曆型態 ===
		if (dd == "D" && !Check.isDate(inputObj.value))
		{
			//該欄位必須為西曆型態
			alert('[' + showName + ']' + Message.getMessage("211"));
			Form.canFocus(inputObj);
			return false;
		}
		//=== T 時間型態 ===
		if (dd == "T" && !Check.isTime(inputObj.value))
		{
			//該欄位必須為時間型態
			alert('[' + showName + ']' + Message.getMessage("212"));
			Form.canFocus(inputObj);
			return false;
		}
		//=== EMAIL E-MAIL型態 ===
		if (dd == "EMAIL" && !Check.checkMail(inputObj.value))
		{
			//該欄位必須為 E-MAIL 型態
			alert('[' + showName + ']' + Message.getMessage("213"));
			Form.canFocus(inputObj);
			return false;
		}
		//=== IP IP型態 ===
		if (dd == "IP" && !Check.checkIP(inputObj.value))
		{
			//該欄位必須為 IP 型態
			alert('[' + showName + ']' + Message.getMessage("214"));
			Form.canFocus(inputObj);
			return false;
		}
		//=== TEL 電話型態 ===
		if (dd == "TEL" && !Check.checkTEL(inputObj.value))
		{
			//該欄位必須為電話型態
			alert('[' + showName + ']' + Message.getMessage("215"));
			Form.canFocus(inputObj);
			return false;
		}
		//=== HTTP 網址型態 ===
		if (dd == "HTTP" && !Check.checkURL(inputObj.value))
		{
			//該欄位必須為網址型態
			alert('[' + showName + ']' + Message.getMessage("216"));
			Form.canFocus(inputObj);
			return false;
		}
		//=== 一般字串資料 ===
		if (dd != "HTML" && filterHtmlTag(inputObj.value) != inputObj.value)
		{
			//該欄位包含非法的 Html Tag, 請檢查
			alert('[' + showName + ']' + Message.getMessage("217"));
			Form.canFocus(inputObj);
			return false;
		}
	}
	return true;
}

function filterHtmlTag(htmlString)
{
	var	reg		=	/<[^>]*>|<\/[^>]*>/gm;
	var	myString	=	htmlString.replace(reg,"");
	return myString;
}

/** 
檢核設定欄位, 
檢核是否空白 'ChkForm'
@param	blockName	區塊名稱
*/
function startChkForm (blockName)
{
	var	formObj		=	_d().forms[0];
	var	inputObj	=	null;
	var	cName		=	"";
	var	checkedTmp	=	"";

	for (var i = 0; i < formObj.length; i++)
	{
		inputObj	=	formObj.elements[i];
		
		try
		{
			if (inputObj.name.substring(0, 2) != blockName)
				continue;
		}
		catch(ex)
		{
			continue;
		}

		//=== 檢核不可為停用 - for 國防 ===
		if (blockName != 'Q_' && inputObj.type == 'select-one')
		{
			//2010/09/08 nono add 多判斷 null 避免下拉裡什麼選項都沒有造成的問題
			if ($(inputObj).val() != null && $(inputObj).val().indexOf('(停用)') != -1)
			{
				Form.errAppend('(' + $(inputObj).attr("CNAME") + ') 所選取的項目已停用');
			}
		}



		//起訖檢查
		if (inputObj.name.indexOf("_S_") != -1)
		{
			cName	=	$(inputObj).attr("CNAME");
				
			var	endObj	=	_i(0, inputObj.name.replace(/_S_/, '_E_'));
			if (typeof(endObj) != "undefined" && inputObj.value != '' && endObj.value != '')
			{
				if (inputObj.value * 1 > endObj.value * 1)
					Form.errAppend(cName + '起不可大於' + cName + '訖');
			}
		}
		
		if ($(inputObj).attr("chkForm") != null || $(inputObj.parentNode).attr("chkForm") != null)
		{
			if ($(inputObj).attr("CNAME") != null)
				cName	=	$(inputObj).attr("CNAME");
			if ($(inputObj.parentNode).attr("CNAME") != null)
				cName	=	$(inputObj.parentNode).attr("CNAME");
			
			if (inputObj.name.indexOf("_S_") != -1)
				cName	=	cName + '起';
			if (inputObj.name.indexOf("_E_") != -1)
				cName	=	cName + '訖';
			
			//=== 處理過則不處理, For CheckBox, RadioBox ===
			if (checkedTmp.indexOf(',' + cName + ',') != -1)
				continue;
				
			if (inputObj.type == 'radio' || inputObj.type == 'checkbox')
			{
				var	parentObj	=	inputObj.parentNode;
				var	hasCheck	=	false;
				for (var i = 0; i < parentObj.childNodes.length; i++)
				{
					if (parentObj.childNodes[i].type == 'radio' || parentObj.childNodes[i].type == 'checkbox')
					{
						if (parentObj.childNodes[i].checked)
							hasCheck	=	true;
					}
				}
				if (!hasCheck)
					Form.errAppend('(' + cName + ') ' + Message.getMessage('101'));
			}
			else
			{
				Form.chkForm(inputObj.name, cName);
			}
			
			checkedTmp	+=	',' + cName + ',';
		}
	}
}

/** 開啟 Detail 頁面 */
function doOpen(keyStr, width, height, pageName)
{
	var	height_	=	screen.availHeight - 20;
	var	width_	=	screen.availWidth - 10;
	
	width	=	(width == null) ? width_ : width;
	height	=	(height == null) ? height_ : height;

	//=== 將 Key 組在 URL 後面帶入 ===
	var	keyAry		=	keyStr.split("|");
	var	keyUrlBuff	=	new StringBuffer();

	for (var i = 0; i < keyAry.length; i += 2)
	{
		if (i == 0)
			keyUrlBuff.append ("?" + keyAry[i] + "=" + StrUtil.urlEncode(keyAry[i + 1]));
		else
			keyUrlBuff.append ("&" + keyAry[i] + "=" + StrUtil.urlEncode(keyAry[i + 1]));
	}

	//=== 2006/12/4 解決傳空字串有 Bug 的問題 ===
	var	openUrl	=	"";
	if (keyStr == '')
		openUrl	=	_vp + "mainframe_open.aspx?mainPage=" + StrUtil.urlEncode(pageName);
	else
		openUrl	=	_vp + "mainframe_open.aspx?mainPage=" + StrUtil.urlEncode(pageName) + "&keyParam=" + StrUtil.urlEncode(keyUrlBuff.toString());

	WindowUtil.openObjDialog (openUrl, width, height, self);
}

/** 開啟 Detail 頁面 */
function doFlowOpen(keyStr, width, height, pageName)
{
	width	=	(width == null) ? 800 : width;
	height	=	(height == null) ? 600 : height;
	
	//=== 2007/11/28 for 東吳, 若為 flowlist 頁面則固定開窗大小 ===
	var	rootPath	=	_vp;
	if (pageName.indexOf("flowlist") != -1)
	{
		width	=	810;
		height	=	450;
		rootPath=	_vp1;
	}

	//=== 將 Key 組在 URL 後面帶入 ===
	var	keyAry		=	keyStr.split("|");
	var	keyUrlBuff	=	new StringBuffer();

	for (var i = 0; i < keyAry.length; i += 2)
	{
		if (i == 0)
			keyUrlBuff.append ("?" + keyAry[i] + "=" + StrUtil.urlEncode(keyAry[i + 1]));
		else
			keyUrlBuff.append ("&" + keyAry[i] + "=" + StrUtil.urlEncode(keyAry[i + 1]));
	}

	//=== 2006/12/07 新增可自訂傳入頁面, 不傳預設為 c1 設定頁面 ===
	if (pageName == null)
		pageName	=	detailPage;
		
	//=== 2006/12/4 解決傳空字串有 Bug 的問題 ===
	var	openUrl	=	"";
	
	if (pageName.indexOf("flowlist") != -1)
	{
		if (keyStr == '')
			openUrl	=	rootPath + "mainframe_open_flow.aspx?mainPage=" + StrUtil.urlEncode(pageName);
		else
			openUrl	=	rootPath + "mainframe_open_flow.aspx?mainPage=" + StrUtil.urlEncode(pageName) + "&keyParam=" + StrUtil.urlEncode(keyUrlBuff.toString());
	}
	else
	{
		if (keyStr == '')
			openUrl	=	rootPath + "mainframe_open_flow.aspx?mainPage=" + StrUtil.urlEncode(pageName);
		else
			openUrl	=	rootPath + "mainframe_open_flow.aspx?mainPage=" + StrUtil.urlEncode(pageName) + StrUtil.urlEncode(keyUrlBuff.toString());
	}
	
	WindowUtil.openObjDialog (openUrl, width, height, self);
}

//=== 開啟 Dialog 的方法 Start ===
var	dialogArgumentNames	=	null;
var	dialogArgumentValues	=	null;
var	defaultPage		=	null;
var	dialogShowTitle		=	null;

function openDialog(openUrl, showTitle, argusNameAry, argusValueAry, width, height)
{
	width	=	(width == null) ? 800 : width;
	height	=	(height == null) ? 600 : height;

	if (dialogArgumentNames == null)
	{
		dialogArgumentNames	=	[];
		dialogArgumentValues	=	[];
	}

	defaultPage	=	openUrl;
	dialogShowTitle	=	showTitle;

	WindowUtil.openObjDialog (_vp + 'utility/DIALOG_PAGE.aspx', width, height, self);
	
}
//=== 開啟 Dialog 的方法 End ===

/** 傳送資料, 透過 Form Post */
function sendData(url, target, argusNameAry, argusValueAry)
{
	var	formObj	=	_d().createElement("form");
	formObj.name	=	"TMP_FORM";
	_d().body.appendChild(formObj)
	formObj.style.display	=	'none';
	var	tObj;
	for (var i = 0; i < argusNameAry.length; i++)
	{
		tObj		=	_d().createElement("INPUT");
		tObj.name	=	argusNameAry[i];
		tObj.value	=	argusValueAry[i];
		formObj.appendChild(tObj);
	}
	
	formObj.action	=	url;
	if (target != null)
		formObj.target	=	target;
	formObj.method	=	"POST";
	formObj.submit();
	
	_d().body.removeChild(formObj);
}

/**
控制 Input 物件所要觸發的按鈕
*/
function backClick(e)
{    
	var	key		=	_e(e);
	var	srcElement	=	_se(e);

	if (key == 13 && srcElement.tagName == 'INPUT') 
	{
		key	=	9;
		
		_rv(e);

		for (var i = 1 ; i < arguments.length; i++)
		{
			if (srcElement.id.substring(0, 2) == (arguments[i][0]))
				try{_(arguments[i][1]).click();}catch(ex){}
		}
	} 
}

//### AjaxErrorHandle ###
function EndRequestHandler(sender, args)
{
	if (args.get_error() != undefined)
	{
		var errorMessage;
		if (args.get_response().get_statusCode() == '200')
		{
			if (args.get_error().message.indexOf('alert') != -1)
				alert("具有潛在危險的值已從用戶端偵測到!!");
			else
				errorMessage = args.get_error().message;
		}
		
		args.set_errorHandled(true);
		
		Message.hideProcess();

		PageMethods.AjaxError(onSucceeded, onFailed);
	}  
}

function onSucceeded(result, userContext, methodName)
{    
	eval(result);
}

function onFailed(error, userContext, methodName)
{
	if(error !== null)
	{
		alert('An error occurred: ' + error.get_message());
	};
}

//### ColumnFilter ###
/**
進行欄位篩選動作
*/
function doFilter()
{
	openColumnFilterWindow(3);
}

/**
開啟欄位過濾視窗
@param showColumns	每列顯示欄位數
*/
function openColumnFilterWindow(lineColumns, width, height)
{
	width	=	(width == null) ? 500 : width;
	height	=	(height == null) ? 200 : height;
	
	var	htmlBuf	=	new StringBuffer();
	htmlBuf.append("<script>window.onload=function(){dialogArguments.preLoad(self);}<\/script>");
	htmlBuf.append("<form><table width=100%>");
	htmlBuf.append("<tr><td>篩選欄位 ");
	htmlBuf.append("<a href='#'><span onclick='for(var i=0;i<document.forms[0].filter.length;i++){if (!document.forms[0].filter[i].disabled)document.forms[0].filter[i].checked=true;}'><font size='2'>選取全部</font></span></a> ");
	htmlBuf.append("<a href='#'><span onclick='for(var i=0;i<document.forms[0].filter.length;i++){document.forms[0].filter[i].checked=false;}'><font size='2'>取消全部</font></span></a> ");
	htmlBuf.append("<td align=right><input type=button value='設定' onclick='opener ? opener.openWinArgmentsObj.checkList(self) : dialogArguments.checkList(self)'> ");
	htmlBuf.append("<input type=button value='關閉' onclick='top.close()'></td></tr></table>");
	htmlBuf.append("<hr color=blue><table border=0>");
	
	if (typeof(columnIndexAry1) == "undefined")
		columnIndexAry1	=	[];
		
	for (var i = 0; i < columnIndexAry1.length; i++)
	{
		if (i != 0 && i % lineColumns == 0)
			htmlBuf.append("</tr>");
		if (i % lineColumns == 0)
			htmlBuf.append("<tr>");
		if (readOnlyColumn.indexOf(',' + columnCodeAry1[i] + ',') == -1)
			htmlBuf.append("<td><input type=checkbox checked name='filter' vlaue='" + columnIndexAry1[i] + "'><span onclick='try{document.forms[0].filter[" +i + "].click();}catch(ex){document.forms[0].filter.click();}'>" + columnNameAry1[i] + "</span></td>");
		else
			htmlBuf.append("<td><input type=checkbox disabled name='filter' vlaue='" + columnIndexAry1[i] + "'><span>" + columnNameAry1[i] + "</span></td>");
	}
	htmlBuf.append("</tr></table>");
	htmlBuf.append("<hr color=blue><table width=100%><tr><td align=right><input type=button value='設定' onclick='opener ? opener.openWinArgmentsObj.checkList(self) : dialogArguments.checkList(self)'> ");
	htmlBuf.append("<input type=button value='關閉' onclick='top.close()'></td></tr></table>");
	htmlBuf.append("</form>")
	
	Form.bodyStr	=	htmlBuf.toString();
	var	phraseWin	=	_wu().openObjDialog(_vp + "utility/phrase.htm", width, height, self);
}

/**
檢查清單並記錄起來
*/
function checkList(windowObj)
{
	var	top_	=	getTop();

	//=== 紀錄勾選索引 ===
	var	nonCheckIndexAry	=	[];
	for (var i = 0; i < windowObj.document.forms[0].filter.length; i++)
	{
		if (!windowObj.document.forms[0].filter[i].checked)
			nonCheckIndexAry[nonCheckIndexAry.length]	=	i;
	}

	//=== 記錄到全域範圍 ===
	if (top_.columnFilterRecord == null)
		top_.columnFilterRecord	=	{};
	top_.columnFilterRecord[recordName1]	=	nonCheckIndexAry.toString();

	//=== 將勾選結果回傳到畫面隱藏欄位處理 ===
	var	tmpBuf	=	new StringBuffer();
	for (var i = 0; i < nonCheckIndexAry.length; i++)
	{
		if (tmpBuf.toString() == '')
			tmpBuf.append(columnIndexAry1[nonCheckIndexAry[i]]);
		else
			tmpBuf.append("," + columnIndexAry1[nonCheckIndexAry[i]]);
	}

	//=== 處理欄位隱藏動作 ===
	setColumnHide();
	
	//=== 關閉視窗 ===
	windowObj.close();
}

/**
處理欄位隱藏動作
*/
function setColumnHide()
{
	if (gridOuterHTML != '' && typeof(gridOuterHTML) != "undefined" && typeof(_("DataGrid").rows) != "undefined")
	{
		_("DataGrid").outerHTML	=	gridOuterHTML;
		
		var	nonCheckIndexAry	=	getNonCheckAry();
		
		//=== 將畫面控制項欄位隱藏起來 ===
		for (var i = 0; i < _("DataGrid").rows.length; i++)
		{
			for (var j = 0; j < nonCheckIndexAry.length; j++)
			{
				try{_("DataGrid").rows[i].cells[columnIndexAry1[nonCheckIndexAry[j]]].style.display	=	'none';}catch(ex){}
			}	
		}
	}
}

/**
剛開窗設定欄位過濾視窗的載入預設勾選動作
*/
function preLoad(windowObj)
{
	var	nonCheckIndexAry	=	getNonCheckAry();

	//=== 取消設定的欄位 ===
	for (var i = 0; i < nonCheckIndexAry.length; i++)
	{
		if (nonCheckIndexAry[i] != '')
			windowObj.document.forms[0].filter[nonCheckIndexAry[i]].checked	=	false;
	}
}

var	gridOuterHTML;

/**
取得未核選的索引陣列, 未設定過傳回空陣列值
*/
function getNonCheckAry()
{
	var	top_	=	getTop();
	if (top_.columnFilterRecord != null && top_.columnFilterRecord[recordName1] != null)
		return top_.columnFilterRecord[recordName1].split(',');
	if (typeof(nonCheckQry1) == "undefined")
		return [];
	else
		return nonCheckQry1;
}

/** 
取得最外層 top 物件, 確保為最外層的 top 使用 
*/
function getTop()
{
	if (top.dialogArguments != null)
		return top.dialogArguments.top;
	else if (top.opener != null && typeof(top.opener.top) != 'unknown')
		return top.opener.top;
	else
		return top;
}

//### EditPageUse ###
/**
頁面載入結束事件, For 編輯頁面使用
處理對應 Request 塞畫面及唯讀處理
*/
function page_init_end()
{
	//=== 非編輯進來頁面不處理 ===
	if (typeof(keyObj) == "undefined")
		return;
		
	//=== 塞初始鍵值, 若有符合 M_[Request] 即塞值處理 ===
	for (keyName in keyObj)
		try {Form.iniFormSet(0, "M_" + keyName,  "R", 1);}catch(ex){};
}

/**
設定為詳細頁面, 將所有控制項改為唯讀, 除了回查詢頁按鈕及自訂 ID 外
@param	allowEditId	允許編輯的ID, 以 $ 連結, 前後都需有 Exp: $A_BTN$B_BTN$
*/
function setDetailPage(allowEditId)
{
	for (var i = 0; i < document.forms[0].elements.length; i++)
	{
		if (_i(0, i).type == 'hidden')
			continue;
			
		_i(0, i).disabled	=	true;
		
		//=== 回查詢頁可使用 ===
		if (_i(0, i).id.indexOf('BACK_BTN') != -1)
			_i(0, i).disabled	=	false;
			
		//=== 自訂 ID 可使用 ===
		if (allowEditId != null && allowEditId.indexOf('$' + _i(0, i).name + '$') != -1)
			_i(0, i).disabled	=	false;
	}
}

/**
設定為詳細頁面, 將所有 M_ 控制項改為唯讀, 另可自訂 ID
@param	disableId	要唯讀的ID, 以 $ 連結
*/
function setDetailPage1_1(disableId)
{
	for (var i = 0; i < document.forms[0].elements.length; i++)
	{
		if (_i(0, i).type == 'hidden' || _i(0, i).name.substring(0, 2) != 'M_')
			continue;
			
		_i(0, i).disabled	=	true;
	}

	if (disableId == null)
		return;
		
	var	disableAry	=	disableId.split('$');
	
	for (var i = 0; i < disableAry.length; i++)
	{
		_i(0, disableAry[i]).disabled	=	true;
	}	
}

/** 
回查詢頁 
*/
function doBack()
{
	//=== 若查詢過才呼叫查詢 Frame 重新 bindgrid ===
	if (chkHasQuery())
		parent.mainFrame.reQuery();
		
	self.location.href	=	'about:blank';
	
	//=== 關閉新增 Frame ===
	parent.hideView();
}

/* 
判斷是否查詢過 
**/
function chkHasQuery()
{
	if (parent.mainFrame._("DataGrid").rows != null || parent.mainFrame.$(".txtRed").length > 0)
		return true;
}

/** 
處理清除動作 
*/
function doClear()
{
	if (_i(0, "Mode").value == "ADD")
		parent.mainFrame.doAdd1_2();
	else if (_i(0, "Mode").value == "MOD")
		parent.mainFrame.doEdit1_2();
}

/** 
處理清除動作, For Pattern 1-1
*/
function doClear1_1()
{
	if (_i(0, "Mode").value == "ADD")
		clearEditForm();
	else if (_i(0, "Mode").value == "MOD")
		_ev(_d().getElementById(top.lastEditId).toString().replace(/javascript:/g, ""));
}

/** 
清空查詢的資料
*/
function clearQueryForm()
{
	clearBlockForm("Q_");
}

/** 
清空編輯的資料
*/
function clearEditForm()
{
	clearBlockForm("M_");
}

/** 
清空定義區塊的資料
@param blockName 區塊名稱
*/
function clearBlockForm(blockName)
{
	for (var i = 0; i < document.forms[0].length; i++)
	{
		//=== 僅處理該區塊的物件 ===
		if (_i(0, i).name.substring(0, 2) != blockName)
			continue;
			
		//=== 下拉預設選取第一筆 ===
		if (_i(0, i).type == 'select-one')
			_i(0, i).selectedIndex	=	0;
		//=== 其餘數入項目預設空白 ===
		else if (_i(0, i).type != 'radio' && _i(0, i).type != 'checkbox')
			_i(0, i).value		=	'';
		//=== Radio 或 CheckBox 預設不核選 ===
		else
		   _i(0, i).checked		=	false;
		   
		//=== 處理 default value ===
		if ($(_i(0, i).parentNode).attr("DV") != null || ($(_i(0, i)).attr("DV") != null && $(_i(0, i)).attr("DV") != ""))
		{
			//=== radio 當值為預設值時選取 ===
			if (_i(0, i).type == 'radio')
			{
				if (_i(0, i).value == $(_i(0, i)).attr("DV") || _i(0, i).value == $(_i(0, i).parentNode).attr("DV"))
					_i(0, i).checked	=	true;
			}
			else
				_i(0, i).value	=	$(_i(0, i)).attr("DV");
			continue;
		}
	}
}

//### GridEvent ###
/** 
定義 Grid 物件 
*/
var	Grid	=	new Object();

/** 
取得 Tr 的物件 
*/
Grid.getTRObj	=	function (obj_)
{
	try
	{
		while (obj_.tagName != 'TR')
		{
			obj_	=	obj_.parentNode;
			try{obj_.tagName}catch(ex){return null;}
		}
		return obj_;
	}
	catch(ex)
	{
		return null;
	}
}

/** 
滑鼠移過去要處理的動作 
*/
Grid.ScrollTrMouseOver	=	function (e)
{
	var	trObj_	=	Grid.getTRObj(_se(e));
	if (trObj_ == null)
		return;
	if (trObj_.className == top._scrollClickClassName)
		return;
	trObj_.className	=	top._scrollHighLightClassName;
}

/** 
滑鼠移開要處理的動作 
*/
Grid.ScrollTrMouseOut	=	function (e)
{
	var	trObj_		=	Grid.getTRObj(_se(e));
	if (trObj_ == null)
		return;
	if (trObj_.className == top._scrollClickClassName)
		return;
	if (trObj_.rowIndex % 2 != 0)
		trObj_.className	=	top._scrollTr01ClassName;
	else
		trObj_.className	=	top._scrollTr02ClassName;
}

/**
初始化 Grid 中 TR 的動作
滑鼠移過去即移開顏色控制
滑鼠點下去顏色控制
@param gridId	要處理的 Table 物件
*/
Grid.initTrScroll	=	function (table)
{
	for (var j = 1; j < table.rows.length; j++)
	{
		$(table.rows[j]).bind("mouseover",	Grid.ScrollTrMouseOver);
		$(table.rows[j]).bind("mouseout",	Grid.ScrollTrMouseOut);
	}
}

/** 
初始化 Grid 的 Event 
@param gridId	要處理的 Grid ID
*/
Grid.setGridEvent	=	function ()
{
	var	tables	=	_d().getElementsByTagName("TABLE");
	
	for (var i = 0; i < tables.length; i++)
	{
		if (tables[i].id == null)
			continue;
		if (tables[i].id.toUpperCase().indexOf("GRID") == -1)
			continue;
			
		if (tables[i].rows.length <= 200)
		{
			Grid.initTrScroll(tables[i]);

			for (var j = 1; j < tables[i].rows.length; j++)
			{
				try
				{
					tables[i].rows[j].fireEvent("onmouseover");
					tables[i].rows[j].fireEvent("onmouseout");
				}
				catch(ex){}	
				$(tables[i].rows[j]).triggerHandler("mouseover");
				$(tables[i].rows[j]).triggerHandler("mouseout");
			}
		}
	}
}

/** 
Grid 按下改變顏色事件 
*/
function clickEditRow(linkObj, key)
{
	Message.showProcess();

	top.lastEditId	=	linkObj.id;
	var	tr	=	linkObj.parentNode.parentNode;
	top.rowKey	=	tr.parentNode.parentNode.id + "," + $(tr).attr('KEY');
	tr.className	=	top._scrollClickClassName;
}

/** 
Grid 按下改變顏色事件 
*/
function clickDetailRow(linkObj, key)
{
	Message.showProcess();
	var	tr	=	linkObj.parentNode.parentNode;
	top.rowKey	=	tr.parentNode.parentNode.id + "," + $(tr).attr('KEY');
	tr.className	=	top._scrollClickClassName;
}

/** 
Grid 按下改變顏色事件, PageLoad 初始化呼叫
*/
function iniGridClickColor()
{
	if (top.rowKey == null || top.rowKey == '')
		return;
	var	tables	=	_d().getElementsByTagName("TABLE");
	var	rowKey	=	top.rowKey.split(',')[1];
	
	for (var j = 0; j < tables.length; j++)
	{
		if (tables[j].id == null)
			continue;
		if (tables[j].id.toUpperCase().indexOf("GRID") == -1)
			continue;
			
		for (var i = 0; i < tables[j].rows.length; i++)
		{
			if ($(tables[j].rows[i]).attr('KEY') == rowKey)
			{
				tables[j].rows[i].className	=	top._scrollClickClassName;
				//tables[j].rows[i].scrollIntoView();
			}
		}
	}
}

//### PageScript ###
/** 
分頁使用 
@param pageNoId		分頁編號 Client ID
@param pageNum		目前處理頁次
@param validFunctionName檢核 Function 名稱
@param postBackName	PostBast 控制項名稱
*/
function gotoPage(pageNoId, pageNum, validFunctionName, postBackName)
{
	var	validResult	=	eval(validFunctionName + "()");
	if (validResult != null && !validResult)
		return;
		
	if (pageNum != null)
		_i(0, pageNoId).value	=	pageNum;

	_i(0, 'ActivePageControl').value	=	pageNoId.substring(0, pageNoId.lastIndexOf('_'));
	
	__doPostBack(postBackName, '');
}

//### QueryPageUse ###
/** 
處理查詢動作 
*/
function reQuery()
{
	__doPostBack('ReQuery','');
}

/** 
新增功能時呼叫 
*/
function doAdd1_2()
{
	var	argusNameAry	=	["Mode"];
	var	argusValueAry	=	["ADD"];

	top.rowKey	=	null;
	
	//=== 呼叫新增 ===
	sendData(viewpage, "viewFrame", argusNameAry, argusValueAry);
	
	//=== 開啟新增 Frame ===
	top.showView();
}

/**
按下編輯時呼叫
@param	keyStr	參數 KEY|VALUE
@param	typw	處理種類 Mod - 編, Detail - 詳
*/
var	last_KetStr;
function doEdit1_2(td, keyStr, type)
{
	try
	{
		var	tr	=	td.parentNode;
		top.rowKey	=	tr.parentNode.parentNode.id + "," + tr.KEY;
		tr.className	=	top._scrollClickClassName;
	}
	catch(ex)
	{
	}
	if (keyStr == null)
	{
		keyStr	=	last_KetStr;
		type	=	"Mod"
	}
	else
		last_KetStr	=	keyStr
	
	var	argusNameAry	=	["Mode"];
	var	argusValueAry	=	[type.toUpperCase()];
	
	var	keyAry		=	keyStr.split("|");
	for (var i = 0; i < keyAry.length; i += 2)
	{
		argusNameAry[argusNameAry.length]	=	keyAry[i];
		argusValueAry[argusValueAry.length]	=	keyAry[i + 1];
	}
	
	sendData(viewpage, "viewFrame", argusNameAry, argusValueAry);
	
	//=== 開啟新增 Frame ===
	parent.showView();
}

/** 
處理刪除動作 
@param	gridID		GridID
@param	checkBoxName	要核選的 名稱
@param	delType		刪除種類, CHECK 表示多筆刪除
*/
function doDelete(gridID, checkBoxName, delType)
{
	var	nameAry		=	null;
	var	formObj		=	_d().forms[0];
	var	inputObj	=	null;
	var	checkCount	=	0;
	
	if (delType == "CHECK")
	{
		checkCount	=	getGridCheckCount(gridID, checkBoxName);
		
		if (checkCount == 0)
		{
			//必須選擇資料再進行處理
			Message.showMessage("218");
			return false;
		}
	}
	
	if (checkCount == 0)
		checkCount	=	1;
	
	//確定刪除 {CNT} 筆資料??
	if (confirm(Message.getMessage("219").replace(/{CNT}/g, checkCount)))
	{
		Message.showProcess();
		return true;
	}
	else
		return false;
}

/**
@method Form.setCheckBox
設定 Grid 元件為勾選或不勾選
@param	gridID		GridID
@param	checkBoxName	要核選的 名稱
@param	checked		勾選  是 = 1(true) 否 = 0(false)
*/
function setGridCheckBox(gridID, checkBoxName, checked)
{
	var	formObj		=	_d().forms[0];
	var	inputObj	=	null;
	var	nameAry		=	null;

	for(var i = 0; i < formObj.elements.length; i++)
	{
		inputObj	=	_i(0, i);
		nameAry		=	(typeof(inputObj.name) == "undefined")?[]:inputObj.name.split("$");
		if (nameAry.length != 3)
			continue;
			
		if (nameAry[0] != gridID || nameAry[2] != checkBoxName)
				continue;

		if (inputObj.disabled)
			continue;

		inputObj.checked	=	checked;
	}
}

/** 
處理列印動作 
@param	gridID		GridID
@param	checkBoxName	要核選的 名稱
@param	exportType	匯出種類, CHECK 表示多筆刪除
*/
function doPrint(gridID, checkBoxName, printType)
{
	//=== 減核錯誤處理 ===
	if (!valideMessage("Q_"))
		return;

	var	checkCount	=	0;

	if (printType == "CHECK")
	{
		checkCount	=	getGridCheckCount(gridID, checkBoxName)

		if (checkCount == 0)
		{
			Message.showMessage("必須選擇資料再進行處理!!");
			return false;
		}
	}
	else
	{
		if (!doQuery())
			return;
		Message.hideProcess();
	}
	
	var	printTarget	=	"Print" + (new Date()).getTime();
	var	printWin	=	WindowUtil.openPrintWindow("", printTarget);

	printWin.document.write("報表列印須花費幾分鐘計算，請您稍等！");

	if (printType == 'CHECK')
		_i(0, 'TYPE').value	=	"PRINT";
	else
		_i(0, 'TYPE').value	=	"PRINT_ALL";
	
	document.forms[0].target	=	printTarget;
	
	__doPostBack('DoPrint','');
	
	printWin.focus();
	
	document.forms[0].target	=	"_self";
}

/** 
處理匯出動作 
@param	gridID		GridID
@param	checkBoxName	要核選的 名稱
@param	exportType	匯出種類, CHECK 表示多筆刪除
*/
function doExport(gridID, checkBoxName, exportType)
{
	//=== 減核錯誤處理 ===
	if (!valideMessage("Q_"))
		return;

	var	checkCount	=	0;

	if (exportType == "CHECK")
	{
		checkCount	=	getGridCheckCount(gridID, checkBoxName)

		if (checkCount == 0)
		{
			//必須選擇資料再進行處理
			Message.showMessage("220");
			return false;
		}
	}
	else
	{
		if (!doQuery())
			return;
		Message.hideProcess();
	}

	//=== 設定過濾欄位 ===
	var	nonCheckIndexStr	=	',' + getNonCheckAry().toString() + ',';
	var	codeBuff		=	new StringBuffer();
	var	nameBuff		=	new StringBuffer();
	
	if (typeof(columnNameAry1) == "undefined")
		columnNameAry1	=	[];
		
	for (var i = 0; i < columnNameAry1.length; i++)
	{
		if (nonCheckIndexStr.indexOf(',' + i + ',') == -1)
		{
			if (nameBuff.toString() == '')
			{
				codeBuff.append(columnCodeAry1[i]);
				nameBuff.append(columnNameAry1[i]);
			}
			else
			{
				codeBuff.append(',' + columnCodeAry1[i]);
				nameBuff.append(',' + columnNameAry1[i]);
			}
		}
	}
	_i(0, 'ColumnFilter').value	=	codeBuff.toString() + '$' + nameBuff.toString();

	//必須設定欄位才能進行匯出動作
	if (_i(0, 'ColumnFilter').value == '$')
		alert(Message.getMessage("221"));

	var	formObj;
	var	postPage;
	if (exportType == 'CHECK')
	{
		postPage	=	StrUtil.setPageArgument(self.location.href.replace(/#this/g, ''), "TYPE", "EXPORT");
		formObj		=	createTmpForm(gridID, checkBoxName);
	}
	else
	{
		postPage	=	StrUtil.setPageArgument(self.location.href.replace(/#this/g, ''), "TYPE", "EXPORT_ALL");
		formObj		=	createTmpForm('', '');
	}
	
	Form.doSubmit(1, postPage, "post", "actionFrame");
	_d().body.removeChild(formObj);
}

/** 
處理匯出動作 
@param	gridID		GridID
@param	checkBoxName	要核選的 名稱
@param	exportType	匯出種類, CHECK 表示多筆刪除
*/
function doExportNoFilter(gridID, checkBoxName, exportType)
{
	//=== 減核錯誤處理 ===
	if (!valideMessage("Q_"))
		return;

	var	checkCount	=	0;

	if (exportType == "CHECK")
	{
		checkCount	=	getGridCheckCount(gridID, checkBoxName)

		if (checkCount == 0)
		{
			//必須選擇資料再進行處理
			Message.showMessage("220");
			return false;
		}
	}
	else
	{
		if (!doQuery())
			return;
		Message.hideProcess();
	}

	var	formObj;
	var	postPage;
	if (exportType == 'CHECK')
		_i(0, 'TYPE').value	=	"EXPORT";
	else
		_i(0, 'TYPE').value	=	"EXPORT_ALL";
	
	document.forms[0].target	=	"actionFrame";
	__doPostBack('DoExport','');
	document.forms[0].target	=	"_self";
}

/**
取得 Grid 內 ChekBox 控制項核選的數量
@param	gridID		GridID
@param	checkBoxName	要核選的 名稱
*/
function getGridCheckCount(gridID, checkBoxName)
{
	var	checkCount	=	0;
	
	for(var i = 0; i < document.forms[0].elements.length; i++)
	{
		inputObj	=	_i(0, i);
		nameAry		=	(typeof(inputObj.name) == "undefined")?[]:inputObj.name.split("$");
		if (nameAry.length != 3)
			continue;
			
		if (nameAry[0] != gridID || nameAry[2] != checkBoxName)
				continue;

		if (inputObj.disabled)
			continue;

		if (inputObj.checked)
			checkCount++;
	}
	
	return checkCount;
}

/**
產生暫存複製一份的 Form, For Print Excel Use,
For Grid chkBox 特別處理組成同一名稱 Form 處理
@param	gridID		GridID
@param	checkBoxName	要核選的 名稱
*/
function createTmpForm(gridID, checkBoxName)
{
	var	formObj	=	_d().createElement("form");
	_d().body.appendChild(formObj)
	formObj.style.display	=	'none';
	var	tObj;
	var	tmpAry;
	for (var i = 0; i < _d().forms[0].elements.length; i++)
	{
		if (_i(0, i).type == 'select-one')
		{
			tObj		=	_d().createElement("INPUT");
			tObj.name	=	_i(0, i).name + '_NM';
			if (_i(0, i).selectedIndex == -1)
				tObj.value	=	"";
			else
				tObj.value	=	_i(0, i).options[_i(0, i).selectedIndex].text;
			formObj.appendChild(tObj);
		}
		
		if (_i(0, i).type == 'text' || _i(0, i).type == 'select-one' || _i(0, i).type == 'textarea')
		{
			tObj		=	_d().createElement("INPUT");
			tObj.name	=	_i(0, i).name;
			tObj.value	=	_i(0, i).value;
			formObj.appendChild(tObj);
		}
		else if (_i(0, i).type == 'hidden' && _i(0, i).name != '__VIEWSTATE' && _i(0, i).name != '__EVENTARGUMENT' &&
		 _i(0, i).name != '__EVENTTARGET' && _i(0, i).name != '__EVENTVALIDATION')
		{
			tObj		=	_d().createElement("INPUT");
			tObj.name	=	_i(0, i).name;
			tObj.value	=	_i(0, i).value;
			formObj.appendChild(tObj);
		}
		else if (_i(0, i).type == 'checkbox')
		{
			tmpAry		=	_i(0, i).name.split('$');
			tObj		=	_d().createElement("INPUT");
			tObj.type	=	'checkbox';
			
			if (tmpAry.length == 3 && tmpAry[0] == gridID && tmpAry[2] == checkBoxName)
				tObj.name	=	checkBoxName;
			else
				tObj.name	=	_i(0, i).name;
			tObj.value	=	_i(0, i).value;
			formObj.appendChild(tObj);
			tObj.checked	=	_i(0, i).checked;
		}
		else if (_i(0, i).type == 'radio')
		{
			tObj		=	_d().createElement("INPUT");
			tObj.type	=	'radio';
			tObj.name	=	_i(0, i).name;
			tObj.value	=	_i(0, i).value;
			formObj.appendChild(tObj);
			tObj.checked	=	_i(0, i).checked;
		}
	}
	
	return formObj;
}

function showHideQtable()
{
	try { _("QTable1").style.display = (_("QTable1").style.display == 'none') ? "" : "none"; } catch (ex) { };
	try { _("QTable2").style.display = (_("QTable2").style.display == 'none') ? "" : "none"; } catch (ex) { };
}

/** 
處理匯入動作 
@param	progName	傳入的程式代號
@param	func		處理完要執行的 function
@param	otherArgument	其他欲塞入的欄項, Exp: COL1|VAL1|COL2|VAL2
@param	validArgument	欲檢核的欄項, Exp: COL1|VAL11$VAL12$VAL13|COL2|VAL2
*/
function doImportFile(progName, func, otherArgument, validArgument)
{
	if (otherArgument == null)
		otherArgument	=	"";
		
	doOpen('', 500, 250, _vp + 'Application/IMP/IMP1010_01.aspx?IMP_OPERATE_PROG=' + progName + '&STATIC_COLUMN_DATA=' + otherArgument + '&VALID_COLUMN_DATE=' + validArgument + '#');
	
	if (func != null)
		func();
}

/**
處理 Grid 的自動 Scroll 處理
*/
function reSize()
{
	//try{_("grid-scroll").style.width	=	document.body.clientWidth * 0.94;}catch(ex){}; 
	//try{_("grid-scroll").style.height	=	document.getElementById('grid-scroll').clientHeight + 40;}catch(ex){}; 
}

/**
切換 Label, 當唯讀時不處理
*/
function switchLabel()
{
	for (var i = 0; i < _d().forms[0].length; i++)
	{
		var	inputObj	=	_i(0, i);

		//=== 當為唯讀狀態時 ===
		if (inputObj.readOnly || inputObj.disabled)
		{
			if (_d().getElementById('L_' + inputObj.name) != null)
			{
				_d().getElementById('L_' + inputObj.name).innerHTML	=	inputObj.value;
				inputObj.style.display	=	'none';
				_d().getElementById('L_' + inputObj.name).style.display	=	'';
				_d().getElementById('L_' + inputObj.name).className	=	'WrapLabel';
			}
		}
	}
}

/**
Pattern1-3 的清除編輯欄項
*/
function clearEditForm1_3()
{
	//=== 先清除 M_ 的欄位 ===
	clearEditForm();
	
	//=== 處理 Q_ 對應到 M_ 的動作 ===
	var	inputObj	=	null;
	for (var i = 0; i < document.forms[0].length; i++)
	{
		//=== 僅處理 Q_ 的物件 ===
		if (_i(0, i).name.substring(0, 2) != "Q_")
			continue;
			
		inputObj	=	_i(0, 'M_' + _i(0, i).name.substring(2));
		
		//=== 判斷是否有 M_ 物件 ===
		if (inputObj != null)
		{
			//=== 下拉預設選取第一筆 ===
			if (_i(0, i).type == 'select-one')
				inputObj.selectedIndex	=	_i(0, i).selectedIndex;
			//=== 其餘數入項目預設空白 ===
			else if (_i(0, i).type != 'radio' && _i(0, i).type != 'checkbox')
				inputObj.value	=	_i(0, i).value;
			//=== Radio 或 CheckBox 預設不核選 ===
			else
				inputObj.checked	=	 _i(0, i).checked;
		}
	}
}

/**
Pattern1-3 的清除動作
*/
function doClear1_3()
{
	if (_i(0, "Mode").value == "ADD")
		__doPostBack('ADD_BTN', '');
	else if (_i(0, "Mode").value == "MOD")
		__doPostBack('QUERY_BTN', '');
}

function focusTextBox(obj)
{
	if (obj.onchange != null)
	{
		obj.onerror	=	obj.onchange;
		obj.onchange	=	null;
	};
	$(obj).attr('ov',obj.value);
}

function blurTextBox(obj)
{
	if($(obj).attr('ov') != obj.value)
		$(obj).trigger('onerror');
}
