doImport ("FormEvent.js, StrUtil.js, Message.js, WindowUtil.js");

/**
@fileoverview
定義處理 Form 元件的共用函式

@class Form
定義處理 Form 元件的共用函式

@author &#29256;&#27402;&#25152;&#26377; &#23439;&#30849;&#32929;&#20221;&#26377;&#38480;&#20844;&#21496; &copy;2006 Acer Inc.
@version 0.0.1
*/

/**
@constructor Form
*/
Form	=	new Object();

/** 定義檢查的錯誤訊息, 累計錯誤訊息使用 */
Form.errMessage		=	null;

/**
@method Form.errAppend
累計錯誤訊息
@param	errMessage	錯誤訊息
*/
Form.errAppend	=	function (errMessage__)
{
	if (Form.errMessage == null)
		Form.errMessage	=	new StringBuffer();

	if (Form.errMessage.toString().indexOf(errMessage__) == -1)
		Form.errMessage.append(errMessage__ + "<br>");
}

/**
@method Form.showErrMessage
顯示累計的錯誤訊息視窗
*/
Form.showErrMessage	=	function ()
{
	var	errStr	=	"<body onunload='opener.Form.focusFirstErrObj()'>" +
				"<font color=blue><b>檢 核 錯 誤 清 單</b></font>" +
				"<hr size=1>" +
				"<font color=red>" +
				Form.errMessage.toString() +
				"</font>" +
				"<hr size=1>" +
				"<center>" +
				"<input type=button value='關　　閉' id='closeBtn' onclick='top.close();'>" +
				"</center>";

	var	errWin	=	_wu().openExceptionWindow(errStr, 300, 200);
	$(errWin.closeBtn).focus();

	Form.errMessage	=	new StringBuffer();
}

/**
@method Form.focusFirstErrObj
將遊標指到錯誤的第一個 Focus
*/
Form.focusFirstErrObj	=	function ()
{
	for (var i = 0; i < Form.errObjAry.length; i++)
	{
		if (Form.canFocus(Form.errObjAry[i]))
		{
			Form.errObjAry	=	[];
			return;
		}
	}
}

/**
@method Form.canFocus
判斷是否游標能停在此 Input, 若可以, 將游標停在此物件上
@param	input	inputObj	欄位元件
@return	boolean	是否游標能停在此 Input
*/
Form.canFocus	=	function (inputObj_)
{
	try
	{
		/** 唯讀或隱藏欄位不能被游標停留 */
		if (inputObj_.readOnly || inputObj_.disabled || inputObj_.type == 'hidden')
			return false;
		else
		{
			inputObj_.focus();
			if (inputObj_.select)
				inputObj_.select();
			return true;
		}
	}
	catch(ex)
	{
		return false;
	}
}

/**
@method Form.isButoon
判斷是否為按鈕物件
@param	input	obj	欄位物件
@return	boolean	是否為按鈕物件
*/
Form.isButoon	=	function (obj)
{
	if (obj.type == 'button' || obj.type == 'submit' || obj.type == 'cencel')
		return true;
	else
		return false;
}

/**
@method Form.chkForm
檢核處理空白動作, 會累計錯誤訊息至 Form.errMessage
Exp: chkForm('rcvdate', '接收日期');	--> 檢核日期不可空白
@param	String	objName		輸入欄位名稱
@param	String	reMark		輸入欄位中文名稱
*/
Form.chkForm = function (objName, reMark) {
    if (Form.isMultiObj(_i(0, objName))) {
        throw new Error("Form.chkForm [不支援多重物件]");
        return;
    }
    if (_t(_i(0, objName).value) == '') {
        Form.errAppend(Form.getFocusScript(objName, reMark, Message.getMessage('101')));
    }
}

/**
@method Form.getFocusScript
取得錯誤訊息(包含可點擊游標回該物件)
@param	String	objName		輸入欄位名稱
@param	String	reMark		輸入欄位中文名稱
@param	String	message		訊息
@return	String	訊息
*/
Form.errObjAry		=	[];
Form.getFocusScript	=	function (objName, reMark, message)
{
    Form.errObjAry[Form.errObjAry.length] = _i(0, objName);
    return "(<a href='javascript:opener.focus();opener._i(0, \"" + objName + "\").focus();'>" + reMark + "<a>) " + message;

}

/**
@method Form.isMultiObj
判斷是否多物件
@param	input	obj	要判斷的物件
@return	boolean	是否多物件
*/
Form.isMultiObj		=	function (obj)
{
	if (obj == null || obj[0] == null || obj[0].type == null)
		return false;
	else
		return true;
}

/**
@method Form.iniFormColor
設定 Form 的顏色 (Disable)
*/
Form.iniFormColor	=	function ()
{
	var	formObj	=	_d().forms;

	for (var i = 0; i < formObj.length; i++)
	{
		for (var j = 0; j < formObj[i].elements.length; j++)
		{
			var	inputObj	=	_i(i, j);

			if (inputObj.BGCOLOR != null)
				inputObj.style.backgroundColor	=	inputObj.BGCOLOR;
			else
				inputObj.style.backgroundColor	=	"";
			if (inputObj.COLOR != null)
				inputObj.style.color		=	inputObj.COLOR;
			else
				inputObj.style.color		=	"";
			
			if (inputObj.readOnly || inputObj.disabled)
			{
				if (top._disableBgColor	!= null)
				{
					inputObj.style.backgroundColor	=	top._disableBgColor;
				}
				else
				{
					inputObj.style.backgroundColor	=	"#E0F8F8";
				}
				
				inputObj.style.color		=	"#A8A8A8";
			}
		}
	}
}

/**
@method Form.disableField
隱藏包含名字的元件
Exp:
Form.disableField(0, "XX")
&lt;input name='xx1'>&lt;input name='1xx2'> 皆會 disable
@param	String	formIndex	Form name or index
@param	String	fieldName	欄位名稱, 可輸入數字或字串
*/
Form.disableField	=	function (formIndex, fieldName)
{
	var	formObj	=	_d().forms[formIndex];

	for (var i = 0; i < formObj.length; i++)
	{
		var	inputObj	=	formObj.elements[i];
		if (inputObj.name.toUpperCase()._i(fieldName.toUpperCase()) == -1)
			continue;

		if (inputObj.type == 'text' || inputObj.type == 'textarea')
			inputObj.readOnly	= true;
		else
			inputObj.disabled	= true;
	}
}

/**
@method Form.disableAll
是否隱藏所有物件
@param	String	formIndex	Form name or index
@param	boolean	stat		1(true) -- 是, 0(false) -- 否
*/
Form.disableAll	=	function (formIndex, stat)
{
	var	formObj	=	_d().forms[formIndex];

	for (var i = 0; i < formObj.length; i++)
	{
		var	inputObj	=	formObj.elements[i];

		if (inputObj.type == 'hidden')
			continue;

		if (inputObj.type == 'text' || inputObj.type == 'textarea')
			inputObj.readOnly	=	eval(stat);
		else
			inputObj.disabled	=	eval(stat);
	}
}

/**
@method Form.chkCheckBoxForName
檢核某名稱的 CheckBox 是否有勾選資料
@param	String	formIndex	Form name or index
@param	String	checkBoxName	CheckBox 名稱
@return	boolean	是否有勾選
*/
Form.chkCheckBoxForName	=	function (formIndex, checkBoxName)
{
	var	checkBoxObj	=	_i(formIndex, checkBoxName);
	var	checkCount	=	0;

	if (isNaN(checkBoxObj.length))
	{
		if (checkBoxObj.checked)
			checkCount++;
	}
	else
	{
		for(var i = 0; i < checkBoxObj.length; i++)
		{
			if (checkBoxObj[i].checked)
				checkCount++;
		}
	}

	if (checkCount == 0)
		return false;
	else
		return true;
}

/**
@method Form.doSubmit
處理 Submit 動作
@param	String	formIndex	Form name or index
@param	String	url		送出至哪一頁
@param	String	method		Get or Post
@param	String	target		Form Target(Frame name), 可不傳預設為空白
*/
Form.doSubmit	=	function (formIndex, url, method_, target_)
{
	if (target_ == null)
		target_	=	"";

	var	formObj	=	_d().forms[formIndex];

	formObj.action	=	url;
	formObj.method	=	method_;
	formObj.target	=	target_;

	formObj.submit();
}

/**
@method Form.setCheckBox
設定所有元件為勾選或不勾選
Exp:
setCheckBox(0)		--> 畫面上全部的都不勾選
setCheckBox(0, 1)	--> 畫面上的第一個 Form 內的都不勾選
setCheckBox(0, 1, "chk")--> 畫面上的第一個 Form 內 name=chk 的都不勾選
@param	boolean	checked		勾選  是 = 1(true) 否 = 0(false)
@param	String	formIndex	要核選的 Form 可不傳, 不傳為預設全選或全不選
@param	String	checkBoxName	要核選的 名稱 可不傳, 不傳為預設全選或全不選
*/
Form.setCheckBox	=	function (checked_, formIndex, checkBoxName)
{
	var	formObj	=	_d().forms;

	for(var i = 0; i < formObj.length; i++)
	{
		if (formIndex != null && formIndex != "")
		{
			if (formObj[formIndex] != formObj[i])
				continue;
		}

		var	inputObj	=	null;

		for(var j = 0; j < formObj[i].length; j++)
		{
			inputObj	=	_i(i, j);

			if (checkBoxName != null)
			{
				/** 2006/12/18 修正判斷物件會有誤 Bug(物件可能為多個), 應判斷物件名稱 */
				//if (inputObj != _i(i, checkBoxName))
				if (inputObj.name != checkBoxName)
					continue;
			}

			if (inputObj.disabled)
				continue;

			if (eval(checked_))
				inputObj.checked	= true;
			else
				inputObj.checked	= false;
		}
	}
}

/**
@method Form.clear
處理 Form 清除動作, 保留還原 iniFormSet 的 KV 項目值
@param	String	formIndex	要核選的 Form 可不傳, 不傳為處理畫面上所有的 Form
*/
Form.clear	=	function (formIndex)
{
	var	formObj	=	_d().forms;

	for (var i = 0; i < formObj.length; i++)
	{
		if (formIndex != null && formIndex != "")
		{
			if (formObj[formIndex] != formObj[i])
				continue;
		}

		/**Keep value*/
		for (var j = 0; j < formObj[i].length; j++)
		{
			if (_i(i, j).type == 'checkbox' || _i(i, j).type == 'radio')
				_i(i, j).checked	=	_i(i, j).keepValue;
			else if (_i(i, j).keepValue == null)
				continue;
			else
				_i(i, j).value	=	_i(i, j).keepValue;
		}
	}
}