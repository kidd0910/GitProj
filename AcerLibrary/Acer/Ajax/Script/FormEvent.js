doImport ("Decimal.js");

/*
@noprocess 
*/

/**
@fileoverview
定義處理 Form 元件的 Event

@class FormEvent
定義處理 Form 元件的 Event

@author &#29256;&#27402;&#25152;&#26377; &#23439;&#30849;&#32929;&#20221;&#26377;&#38480;&#20844;&#21496; &copy;2006 Acer Inc.
@version 0.0.1
*/

/**
@constructor FormEvent
*/
var	FormEvent	=	new Object();
FormEvent.s_	=	" 1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ`~!@#$%^&*()_+|\=-.,/?';\":<>[]}{";
FormEvent.t_	=	"　１２３４５６７８９０ａｂｃｄｅｆｇｈｉｊｋｌｍｎｏｐｑｒｓｔｕｖｗｘｙｚＡＢＣＤＥＦＧＨＩＪＫＬＭＮＯＰＱＲＳＴＵＶＷＸＹＺ‵?！＠＃＄％︿＆＊（）＿＋｜＝－。，╱？’；”：＜＞〔〕｝｛";

/**
@method FormEvent.onlyAllowNumPress1
只允許數字型態 (onkeypress)
@param	event	event	事件
*/
FormEvent.onlyAllowNumPress1	=	function (event_)
{
	var	keyCode_	=	_e(event_);

	if (keyCode_ == 9 || keyCode_ == 8 || keyCode_ == 13)
		return;
	
	if ((keyCode_ < 48 || keyCode_ > 57) && keyCode_ != 13)
	{
		_rv(event_);
	}
}

/**
@method FormEvent.upperCase
將值轉換為大寫 (onkeyup)
@param	event	event	事件
*/
FormEvent.upperCase	=	function (event_)
{
	if (_e(event_) == 9 || _e(event_) == 13)
		return;
	
	var	keyCode_	=	_e(event_);
	var	inputObj_	=	_se(event_);

	if (keyCode_ == 13)
		return;
	if (keyCode_ != 8 && keyCode_ != 46 && keyCode_ != 35 && keyCode_ != 36 && keyCode_ != 37 && keyCode_ != 39)
	{
		/** 2006/12/19 修正轉換時中文登打會清除原先資料的 Bug */
		if (inputObj_.value.substring(inputObj_.value.length - 1).match(/[^\x00-\xff]/ig) != null)
			return;
		inputObj_.value	=	inputObj_.value.toUpperCase();
	}
}

/**
@method FormEvent.chkTextAreaMaxNumber
依輸入欄位設定的長度,超過時會限制輸入 (onkeypress、onblur)
@param	event	event	事件
*/
FormEvent.chkTextAreaMaxNumber	=	function (event_)
{
	var	inputObj_	=	_se(event_);
	/** 2006/12/14 新增加判斷當 onblur 物件為唯讀時不處理 */
	if (inputObj_.readOnly)
		return;
		
	if (inputObj_.value.length >= inputObj_.maxLength)
	{
		inputObj_.value	=	inputObj_.value.substr(0, inputObj_.maxLength);
		_rv(event_);
	}
}

/**
@method FormEvent.onlyAllowNumPress
只允許數字型態 (onkeypress)
@param	event	event	事件
*/
FormEvent.onlyAllowNumPress	=	function (event_)
{
	var	keyCode_	=	_e(event_);

	if (keyCode_ != 45 && (keyCode_ < 48 || keyCode_ > 57) && keyCode_ != 13 && keyCode_ != 9)
		_rv(event_);
}

/**
@method FormEvent.onlyAllowNumPress2
只允許數字型態(包含小數點) (onkeypress)
@param	event	event	事件
*/
FormEvent.onlyAllowNumPress2	=	function (event_)
{
	var	keyCode_	=	_e(event_);

	if (keyCode_ != 45 && (keyCode_ < 48 || keyCode_ > 57) && keyCode_ != 46 && keyCode_ != 13 && keyCode_ != 9)
		_rv(event_);
}

/**
@method FormEvent.onlyAllowNumPress2
只允許正整數型態(包含小數點) (onkeypress)
@param	event	event	事件
*/
FormEvent.onlyAllowNumPress3	=	function (event_)
{
	var	keyCode_	=	_e(event_);

	if ((keyCode_ < 48 || keyCode_ > 57) && keyCode_ != 46 && keyCode_ != 13 && keyCode_ != 9)
		_rv(event_);
}

/**
@method FormEvent.onlyAllowNumUp
只允許數字型態和 '-' (onkeyup)
@param	event	event	事件
*/
FormEvent.onlyAllowNumUp	=	function (event_)
{
	if (_e(event_) == 9 || _e(event_) == 13)
		return;
	
	var	inputObj_	=	_se(event_);

	if (isNaN(inputObj_.value) && inputObj_.value != '-')
		inputObj_.value	=	inputObj_.value.substr(0, inputObj_.value.length - 1);
}

FormEvent.autoTab1	=	function (event_)
{
	_se(event_).trigger	=	1;
}

/**
@method FormEvent.autoTab
自動將游標移往下一個 Input, button 除外 (onkeyup)
@param	event	event	事件
@type	void
*/
FormEvent.autoTab	=	function (event_)
{
	if (_e(event_) == 9 || _e(event_) == 13)
		return;
	
	//Fix 最後一碼為中文問題
	if (_se(event_).trigger == 0)
		return;
	else
		_se(event_).trigger	=	0;
		
	var	keyCode_	=	_e(event_);
	var	inputObj_	=	_se(event_);

	if (Form.isButoon(inputObj_))
		return;

	if (keyCode_ == 16)
		return;

	if (keyCode_ == 13)
		return;

	if (keyCode_ == 16 || keyCode_ == 9)
	{
		try{inputObj_.select();}catch(ex){}
		return;
	}

	if (keyCode_ == 37 || keyCode_ == 39)
		return;

	var	formObj	=	_d().forms;

	if (inputObj_.value.length == inputObj_.maxLength)
	{
		if (keyCode_ == 229)
			return;

		for (var i = 0; i < formObj.length; i++)
		{
			for (var j = 0; j < formObj[i].length; j++)
			{
				if (formObj[i].elements[j] == inputObj_)
				{
					while (!Form.canFocus(_i(i, j + 1)))
					{
						j++;

						if (i >= (formObj.length - 1) && (j >= (formObj[i].length - 1)))
						{
							i	=	0;
							j	=	-1;
						}
						else if (j >= (formObj[i].length - 1))
						{
							i++;
							j	=	0;
						}
					}
					//try
					//{
					//	if (_i(i, j + 1).type == 'button' || _i(i, j + 1).type == 'submit' || _i(i, j + 1).type == 'cencel')
					//		inputObj_.focus();
					//}
					//catch(ex){}

					return;
				}
			}
		}
	}
}

/**
@method FormEvent.lowerCase
將值轉換為小寫 ()
@param	event	event	事件
*/
FormEvent.lowerCase	=	function (event_)
{
	if (_e(event_) == 9 || _e(event_) == 13)
		return;
	
	var	keyCode_	=	_e(event_);
	var	inputObj_	=	_se(event_);

	if (keyCode_ != 8 && keyCode_ != 46 && keyCode_ != 35 && keyCode_ != 36 && keyCode_ != 37 && keyCode_ != 39)
		inputObj_.value	=	inputObj_.value.toLowerCase();
}

/**
@method FormEvent.formatDecimal
格式化金額格式 (onfocus)
@param	event	event	事件
*/
FormEvent.formatDecimal	=	function (event_)
{
	var	inputObj_	=	_se(event_);
	
	if (inputObj_.readOnly || inputObj_.disabled)
		return;
		
	inputObj_.value	=	inputObj_.value.replace(/,/g,'');
	inputObj_.select();
}

/**
@method FormEvent.formatDecimal1
格式化金額格式 (onblor)
@param	event	event	事件
*/
FormEvent.formatDecimal1	=	function (event_)
{
	var	inputObj_	=	_se(event_);
	if (inputObj_.value != "")
		inputObj_.value	=	Decimal.formatNumber(inputObj_.value.replace(/,/g,''), ",###.###");
}

/**
@method FormEvent.formatDate
格式化日期格式 (onfocus)
@param	event	event	事件
*/
FormEvent.formatDate	=	function (event_)
{
	var	inputObj_	=	_se(event_);
	
	if (inputObj_.readOnly || inputObj_.disabled)
		return;
	
	inputObj_.value	=	inputObj_.value._r(/\/\s*/g, "");
	inputObj_.select();
}

/**
@method FormEvent.chkDate
檢核日期格式 (onblur)
@param	event	event	事件
*/
FormEvent.chkDate	=	function (event_)
{
	var	inputObj_	=	_se(event_);
	/** 2006/12/14 新增加判斷當 onblur 物件為唯讀時不處理 */
	if (inputObj_.readOnly)
		return;

	if (inputObj_.value == '')
		return;

	/** 2007/01/22 依據設定檔判斷中或西元日期格式, 2007/03/03 西元日期檢核改為不補0後檢核, 避免補0輸民國年檢核成功資料錯誤問題 */
	if (_df == 1 && !Check.isCDate(_fz(inputObj_.value, 7)) ||
	_df == 2 && !Check.isDate(inputObj_.value))
	{
		Message.showMessage('105');
		inputObj_.focus();
	}
	else
		inputObj_.value	=	_df == 1 ? _du().formatCDate(inputObj_.value) : _du().formatDate(inputObj_.value);
}

/**
@method FormEvent.chkTime
檢核時間格式 (onblur)
@param	event	event	事件
*/
FormEvent.chkTime	=	function (event_)
{
	var	inputObj_	=	_se(event_);
	/** 2006/12/14 新增加判斷當 onblur 物件為唯讀時不處理 */
	if (inputObj_.readOnly)
		return;
		
	if (inputObj_.value == '')
		return;

	if (!Check.isTime(inputObj_.value))
	{
		inputObj_.value	=	'';
		Message.showMessage('106');
		inputObj_.focus();
	}
	else
	{
		inputObj_.value =	inputObj_.value._r(/:/g, "");
		if (inputObj_.value.length == 4)
			inputObj_.value	=	inputObj_.value._s(0, 2) + ':' + inputObj_.value._s(2, 4);
		else if (inputObj_.value.length == 6)
			inputObj_.value	=	inputObj_.value._s(0, 2) + ':' + inputObj_.value._s(2, 4) + ':' + inputObj_.value._s(4, 6);
	}
}

/**
@method FormEvent.fillZero
依輸入欄位設定的長度,不足長度時在資料前補零 (onblur)
@param	event	event	事件
*/
FormEvent.fillZero	=	function (event_)
{
	var	inputObj_	=	_se(event_);
	/** 2006/12/14 新增加判斷當 onblur 物件為唯讀時不處理 */
	if (inputObj_.readOnly)
		return;
		
	if (inputObj_.value == "")
		return;

	inputObj_.value	=	_fz(inputObj_.value, inputObj_.fillZero);
}

/**
@method FormEvent.lockAlphaNum
只能輸入英文字母 & 數字(onkeydown)
@param	event	event	事件
*/
FormEvent.lockAlphaNum	=	function (event_)
{
	var	keyCode_	=	_e(event_);

	if (keyCode_ != 9 && keyCode_ != 8 && keyCode_ != 46 && keyCode_ != 35 && keyCode_ != 36 && keyCode_ != 37 && keyCode_ != 39 && keyCode_ != 13)
	{
		if (event_.shiftKey)
		{
			if ((keyCode_ >= 48) && (keyCode_ <= 57))
				_rv(event_);
		}

		if ( (keyCode_ >= 48 && keyCode_ <= 57) || (keyCode_ >= 65 && keyCode_ <= 90)|| (keyCode_ >= 96 && keyCode_ <= 105))
			return;

		_rv(event_);
	}
}

/**
@method FormEvent.toFullStr
轉全形 (onblur)
@param	event	event	事件
*/
FormEvent.toFullStr	=	function (event_)
{
	var	inputObj_	=	_se(event_);
	/** 2006/12/14 新增加判斷當 onblur 物件為唯讀時不處理 */
	if (inputObj_.readOnly)
		return;
		
	var	result		=	"";

	for (var i = 0; i < inputObj_.value.length; i++)
	{
		var	currChar=	inputObj_.value.substr(i, 1);
		var	index_	=	FormEvent.s_._i(currChar);

		if (index_ != -1)
			result	+=	FormEvent.t_.substr(index_, 1);
		else
			result	+=	currChar;
	}
	inputObj_.value	=	result;
}

/**
@method FormEvent.checkDecimal
檢查浮點數型態 (onkeyup)
@param	event	event	事件
*/
FormEvent.checkDecimal	=	function (event_)
{
	if (_e(event_) == 9 || _e(event_) == 13)
		return;
		
	var	inputObj_	=	_se(event_);
	var	len1		=	$(inputObj_).attr("decmalLength").split(".")[0];
	var	len2		=	$(inputObj_).attr("decmalLength").split(".")[1];
	var	cLen1		=	inputObj_.value.replace(/-/g,'').split(".")[0].length;
	var	cLen2		=	(inputObj_.value._i(".") == -1)?0:inputObj_.value.split(".")[1].length;
	var	cLen3		=	(inputObj_.value.indexOf("-") == -1) ? 0 : 1;

	inputObj_.value	=	inputObj_.value._r(/,/g,'');
	if (inputObj_.value._i(".") != -1)
	{
		if (cLen1 > (len1 - len2))
			inputObj_.value	=	inputObj_.value.split(".")[0]._s(0, (len1 - len2 + cLen3)) + "." + inputObj_.value.split(".")[1];
		if (cLen2 > len2)
			inputObj_.value	=	inputObj_.value.split(".")[0] + "." + inputObj_.value.split(".")[1]._s(0, len2);
	}
	else
	{
		if (cLen1 > (len1 - len2))
			inputObj_.value	=	inputObj_.value.split(".")[0]._s(0, (len1 - len2 + cLen3));
	}
}

/**
@method FormEvent.numberRngeCheck
檢查數字區間 (onblur)
@param	event	event	事件
*/
FormEvent.numberRngeCheck	=	function (event_)
{
	var	inputObj_	=	_se(event_);

	if ($(inputObj_).attr("numberRange") == "")
		throw new Error("FormEvent.numberRngeCheck 必須設定區間!!");

	if ($(inputObj_).attr("numberRange")._i("-") == -1)
		throw new Error("FormEvent.numberRngeCheck 區間設定格式錯誤必須以 '-' 區隔起迄!!");

	if (inputObj_.value == "")
		return;

	var	rangeAry	=	$(inputObj_).attr("numberRange").split("-");
	var	rangeStart	=	(rangeAry[0] == "")?"0":rangeAry[0];
	var	rangeEnd	=	(rangeAry[1] == "")?"9999999999999":rangeAry[1];

	if (_p(inputObj_.value, 10) < rangeStart || _p(inputObj_.value, 10) > rangeEnd)
	{
		Message.showMessage(Message.getMessage('120') + " " + rangeStart + " - " + rangeAry[1]);
		Form.canFocus(inputObj_);
	}
}

/**
@method FormEvent.toFullStrCheck
中文名地型態, 有一中文就不轉全形, 無就全轉中文 (onblur)
@param	event	event	事件
*/
FormEvent.toFullStrCheck	=	function (event_)
{
	var	inputObj_	=	_se(event_);
	
	/** 2006/12/14 新增加判斷當 onblur 物件為唯讀時不處理 */
	if (inputObj_.readOnly)
		return;

	if (Check.checkBig5(inputObj_.value))
	{
		var	result	=	"";
		for (var i = 0; i < inputObj_.value.length; i++)
		{
			var	currChar=	inputObj_.value.substr(i, 1);
			var	index_	=	FormEvent.s_._i(currChar);

			if (index_ != -1)
				result	+=	FormEvent.t_.substr(index_, 1);
			else
				result	+=	currChar;
		}
		inputObj_.value	=	result;
	}
}

/**
@method FormEvent.checkIP
檢核 IP (onblur)
@param	event	event	事件
*/
FormEvent.checkIP	=	function (event_)
{
	var	inputObj_	=	_se(event_);
	
	/** 2006/12/14 新增加判斷當 onblur 物件為唯讀時不處理 */
	if (inputObj_.readOnly)
		return;
		
	if (!Check.checkIP(inputObj_.value))
	{
		Message.showMessage('124');
		Form.canFocus(inputObj_);
	}
}

/**
@method FormEvent.checkTEL
檢核電話型態 (onblur)
@param	event	event	事件
*/
FormEvent.checkTEL	=	function (event_)
{
	var	inputObj_	=	_se(event_);
	
	/** 2006/12/14 新增加判斷當 onblur 物件為唯讀時不處理 */
	if (inputObj_.readOnly)
		return;
		
	if (!Check.checkTEL(inputObj_.value))
	{
		Message.showMessage('125');
		Form.canFocus(inputObj_);
	}
}

/**
@method FormEvent.checkURL
檢核網址型態 (onblur)
@param	event	event	事件
*/
FormEvent.checkURL	=	function (event_)
{
	var	inputObj_	=	_se(event_);
	
	/** 2006/12/14 新增加判斷當 onblur 物件為唯讀時不處理 */
	if (inputObj_.readOnly)
		return;
		
	if (!Check.checkURL(inputObj_.value))
	{
		Message.showMessage('126');
		Form.canFocus(inputObj_);
	}
}

/**
@method FormEvent.checkMail
檢核 EMail 型態 (onblur)
@param	event	event	事件
*/
FormEvent.checkMail	=	function (event_)
{
	var	inputObj_	=	_se(event_);
	
	/** 2006/12/14 新增加判斷當 onblur 物件為唯讀時不處理 */
	if (inputObj_.readOnly)
		return;
		
	if (!Check.checkMail(inputObj_.value))
	{
		Message.showMessage('127');
		Form.canFocus(inputObj_);
	}
}

/**
@method FormEvent.checkID
檢核身分證字號 (onblur)
@param	event	event	事件
*/
FormEvent.checkID	=	function (event_)
{
	var	inputObj_	=	_se(event_);
	
	/** 2006/12/14 新增加判斷當 onblur 物件為唯讀時不處理 */
	if (inputObj_.readOnly)
		return;
		
	if (!Check.chkID(inputObj_.value))
	{
		Message.showMessage('108');
		//Form.canFocus(inputObj_);
	}
}

/**
@method FormEvent.lockAlphaNum1
不能輸入中文 (onkeydown)
@param	event	event	事件
*/
FormEvent.lockAlphaNum1 = function (event_) {
    var inputObj_ = _se(event_);

    if (inputObj_.readOnly)
        return;

    //alert(inputObj_.value);

    if (StrUtil.getBLen(inputObj_.value) != inputObj_.value.length) {
        Message.showMessage('128');
        Form.canFocus(inputObj_);
    }
}