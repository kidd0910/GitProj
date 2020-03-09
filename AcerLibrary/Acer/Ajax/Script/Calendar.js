doImport ("StrUtil.js, StringBuffer.js, Message.js, Check.js, DateUtil.js");

/**
@fileoverview
定義月曆的共用函式
使用方法為
new Calendar(self);
日期選擇: &lt;input id=txt>&lt;input type=button value=開窗 onclick="Calendar.showCalendar(this, txt)">


@class Calendar
定義月曆的共用函式
使用方法為
new Calendar(self);
日期選擇: &lt;input id=txt>&lt;input type=button value=開窗 onclick="Calendar.showCalendar(this, txt)">

@author &#29256;&#27402;&#25152;&#26377; &#23439;&#30849;&#32929;&#20221;&#26377;&#38480;&#20844;&#21496; &copy;2006 Acer Inc.
@version 0.0.1
*/

var	Calendar	=	new Object();

/**
@constructor Calendar
初始化日曆的 DIV 元件
*/
Calendar.init	=	function()
{
	/** 建立 Div */
	if ($(__d.body).length == 0)
		return;
	$(__d.body).append("<div id='__Calendar' style='position:absolute;top:0px;left:0px;display:none;z-index:99'></div>");
	
	var	htmlBuff	=	[];
	htmlBuff.push
	(
		"<span id='__SelectYearSpan' style='position:absolute;top:3px;left:42px;'></span>" +
		"<span id='__SelectMonthSpan' style='position:absolute;top:3px;left:98px;'></span>" +
		"<table whdth=100% border='1' cellspacing='0' cellpadding='0' width='200' height='160' bordercolor='#8080C0' bgcolor='#8080C0'>" +
		"	<tr>" +
		"		<td bgcolor='#FFFFFF'>" +
		"			<table border='0' cellspacing='1' cellpadding='0' width='100%' height='23'>" +
		"				<tr align='center'>" +
		"					<td width='100' align='center' bgcolor='#8080C0' style='cursor:pointer;color:#ffffff'" +
		"						onclick='_c().prevMonth()' title='向前翻 1 月'><b>&lt;</b>" +
		"					</td>" +
		"					<td width='100' align='center' style='cursor:default'" +
		"					onmouseover='style.backgroundColor=\"#FFD700\";' onmouseout='style.backgroundColor=\"white\"'" +
		"					onclick='_c().selectYear(_it(this)._s(0, 4))' title='點擊這裡選擇年份'>" +
		"						<span id='__YearHeader'>2005 年</span>" +
		"					</td>" +
		"					<td width='100' align='center' style='cursor:default' onmouseover=\"style.backgroundColor='#FFD700';\"" +
		"					onmouseout=\"style.backgroundColor='white'\" onclick=\"_c().selectMonth(_it(_(\'__MonthHeader\')).length==3?_it(this)._s(0, 1):_it(this)._s(0, 2))\"" +
		"					title='點擊這裡選擇月份'>" +
		"						<span id='__MonthHeader'>11 月</span>" +
		"					</td>" +
		"					<td width='100' bgcolor='#8080C0' align='center' style='cursor:pointer;color:#ffffff'" +
		"					onclick='_c().nextMonth()' title='向後翻 1 月'><b>&gt;</b></td>" +
		"				</tr>" +
		"			</table>" +
		"		</td>" +
		"	</tr>" +
		"	<tr>" +
		"		<td>" +
		"			<table border='1' cellspacing='0' cellpadding='0' bgcolor='#8080C0'" +
		"			BORDERCOLORLIGHT='#8080C0' BORDERCOLORDARK='#FFFFFF' width='100%' height='20'>" +
		"				<tr align='center'style='color:#FFFFFF;font-size:12px;'>" +
		"					<td><font color='white'>日</font></td>" +
		"					<td><font color='white'>一</font></td>" +
		"					<td><font color='white'>二</font></td>" +
		"					<td><font color='white'>三</font></td>" +
		"					<td><font color='white'>四</font></td>" +
		"					<td><font color='white'>五</font></td>" +
		"					<td><font color='white'>六</font></td>" +
		"				</tr>" +
		"			</table>" +
		"		</td>" +
		"	</tr>" +
		"	<tr>" +
		"		<td height='120'>" +
		"			<table border='1' cellspacing='1' cellpadding='0' width='100%'>"
	);

	var	n__	=	0;
	for (var j = 0; j < 5; j++)
	{
		htmlBuff.push ("<tr style='font-size:12px;color:#00008C;font-weight:bold;text-align:center;'>");
		for (var i = 0; i < 7; i++)
		{
			htmlBuff.push ("<td Height='20' id='__Day" + n__ + "'>11</td>");
			n__++;
		}
		htmlBuff.push ("</tr>");
	}

	htmlBuff.push ("<tr style='font-size:12px;color:#00008C;font-weight:bold;text-align:center;'>");
	for (var i = 35; i < 39; i++)
		htmlBuff.push ("<td height='20' id='__Day" + i +"'>11</td>");

	htmlBuff.push
	(
		"					<td colspan='3' align='right'>" +
		"						<span onclick='_c().closeCalendar();' style='font-size:12px;cursor:pointer;font-weight:normal;color:#ffffff;'><u>關閉</u></span>&nbsp;" +
		"					</td>" +
		"				</tr>" +
		"			</table>" +
		"		</td>" +
		"	</tr>" +
		"	<tr>" +
		"		<td>" +
		"			<table border='0' cellspacing='1' cellpadding='0' width='100%' bgcolor='#FFFFFF'>" +
		"				<tr>" +
		"					<td align='left' nowrap>" +
		"						<input type='button' value='<<' title='向前 1 年' onclick='_c().prevYear();' style='font-size:12px;height:20px;cursor:pointer'>" +
		"						<input type='button' value='< ' title='向前 1 月' onclick='_c().prevMonth();' style='font-size:12px;height:20px;cursor:pointer'>" +
		"					</td>" +
		"					<td align='center'>" +
		"						<input type='button' value='Today' title='當前日期' onclick='_c().today();' style='font-size:12px;height:20px;cursor:pointer'>" +
		"					</td>" +
		"					<td align='right' nowrap>" +
		"						<input type='button' value=' >' title='向後 1 月' onclick='_c().nextMonth();' style='font-size:12px;height:20px;cursor:pointer'>" +
		"						<input type='button' value='>>' title='向後 1 年' onclick='_c().nextYear()'  style='font-size:12px;height:20px;cursor:pointer'>" +
		"					</td>" +
		"				</tr>" +
		"			</table>" +
		"		</td>" +
		"	</tr>" +
		"</table>"
	);
	
	$("#__Calendar").html(htmlBuff.join(""));
	$(__d).bind("click",	_c().CalendarOnClick);
	$(__d).bind("keyup",	_c().CalendarOnKeyUp);
}

/** 輸入元件 inputObj */
_c()._io	=	null;
/** 按鈕元件 buttonObj */
_c()._bo	=	null;
/** 輸入日期 inputDate */
_c()._id	=	null;
/** 月曆元件 calendarDiv */
_c()._cd	=	null;
/** 預設年 defaultYear */
_c()._dy	=	new Date().getFullYear();
/** 預設月 defaultMonth */
_c()._dm	=	new Date().getMonth() + 1;
/** 月曆日陣列 dayArray */
_c()._dr	=	new Array(39);

/**
@method Calendar.showCalendar
顯示月曆
@param	button	buttonObj	按鈕元件
@param	input	inputObj	輸入元件
*/
Calendar.showCalendar	=	function (buttonObj_, inputObj_)
{
	if (inputObj_.disabled || inputObj_.readOnly)
		return false;

	_c()._io	=	inputObj_;
	_c()._bo	=	buttonObj_;
	_c()._cd	=	_("__Calendar");

	/** 判斷是否超出頁面範圍 */
	var	tmpInputObj_	=	inputObj_;
	var	offsetTop_	=	inputObj_.offsetTop;
	var	offsetLeft_	=	inputObj_.offsetLeft;

	while (tmpInputObj_ = tmpInputObj_.offsetParent)
	{
		offsetTop_	+=	tmpInputObj_.offsetTop;
		offsetLeft_	+=	tmpInputObj_.offsetLeft;
	}

	//nono add (offsetTop_ + inputObj_.clientHeight - 229) <-- 判斷 < 0 不往上開
	if ((offsetTop_ + inputObj_.clientHeight - 229) < 0 || _d().body.scrollTop + _d().body.offsetHeight - offsetTop_ >= 250)
	{
		_c()._cd.style.top	=	(offsetTop_ + inputObj_.clientHeight + 6) + 'px';
		_c()._cd.style.left	=	offsetLeft_ + 'px';
	}
	else
	{
		_c()._cd.style.top	=	(offsetTop_ + inputObj_.clientHeight - 229) + 'px';
		_c()._cd.style.left	=	offsetLeft_ + 'px';
	}

	/** 根據當前輸入框的日期顯示日曆的年月 */
	var	regExp_	=	/^(\d+)-(\d{1,2})-(\d{1,2})$/;
	var	dateStr	=	"";
	if (_df == 1)
		dateStr	=	_c()._io.value == ''?"":DateUtil.convert2Date(_c()._io.value, "-");
	else
		dateStr	=	DateUtil.formatDate(_c()._io.value, "-");
	var	reg_	=	dateStr.match(regExp_);
	if(reg_ != null)
	{
		reg_[2]	=	reg_[2] - 1;
		var	date_	=	new Date(reg_[1], reg_[2],reg_[3]);

		/** 保存外部傳入的日期 */
		if(date_.getFullYear()== reg_[1] && date_.getMonth()==reg_[2] && date_.getDate()==reg_[3])
			_c()._id	=	date_;
		else
			_c()._id	=	"";

		_c().setDate(reg_[1], reg_[2] + 1);
	}
	else
	{
		_c()._id	=	"";
		_c().setDate(new Date().getFullYear(), new Date().getMonth() + 1);
	}
	_c()._cd.style.display	=	"";
	Message.showDiv ("__Calendar", 1);
}

/** 任意點擊時關閉該控件 */
_c().CalendarOnClick	=	function (event_)
{
	if (_c()._cd == null)
		return;

	var	srcElement	=	_se(event_);
	if (srcElement != _c()._io && srcElement != _c()._bo && !Check.isContain(srcElement, _c()._cd))
		_c().closeCalendar();
}

/** 按Esc鍵關閉，切換焦點關閉 */
_c().CalendarOnKeyUp	=	function (event_)
{
	var	keyCode_	=	_e(event_);

	if (keyCode_ == 27)
	{
		if(_c()._io)
			_c()._io.blur();
		_c().closeCalendar();
	}
	else if(_d().activeElement)
	{
		if(_d().activeElement != _c()._io && _d().activeElement != _c()._bo)
			_c().closeCalendar();
	}
}

/** 主要的寫程序 */
_c().setDate	=	function (year_, month_)
{
	/** 往 head 中寫入當前的年與月 */
	if (_df == 1)
		_it(_("__YearHeader"),	(year_ - 1911) + " 年");
	else
		_it(_("__YearHeader"),	year_ + " 年");
	_it(_("__MonthHeader"),	month_ + " 月");

	/** 設置當前年月的公共變量為傳入值 */
	_c()._dy	=	year_;
	_c()._dm	=	month_;

	/** 將內容全部清空 */
	for (var i = 0; i < 39; i++)
		_c()._dr[i]	=	"";

	var	day1		=	1;
	var	day2		=	1;
	/** 某月第一天為星期幾 */
	var	firstDay	=	new Date(year_, month_ - 1, 1).getDay();

	/** 上個月的最後幾天 */
	for (var i = 0; i < firstDay; i++)
		_c()._dr[i]	=	_c().getMonthCount(month_ == 1 ? year_ - 1 : year_, month_ == 1 ? 12 : month_ - 1) - firstDay + i + 1;

	/** 本月 */
	for (var i = firstDay; day1 < _c().getMonthCount(year_, month_) + 1; i++, day1++)
		_c()._dr[i]	=	day1;

	/** 下個月前幾天 */
	for (var i = firstDay + _c().getMonthCount(year_, month_); i < 39; i++, day2++)
		_c()._dr[i]	=	day2;

	for (var i = 0; i < 39; i++)
	{
		/** 書寫新的一個月的日期星期排列 */
		var	dayObj	=	_("__Day" + i);

		/** 初始化邊框 */
		dayObj.borderColorLight	=	"#ECDEBD";
		dayObj.borderColorDark	=	"#ECDEBD";

		/** 上個月的部分 */
		if(i < firstDay)
		{
			dayObj.innerHTML		=	"<font color='gray'>" + _c()._dr[i] + "</font>";
			dayObj.title			=	(month_ == 1 ? 12 : month_ - 1) + " 月 " + _c()._dr[i] + " 日";
			$(dayObj).bind("click",	Function("_c().dayClick(_it(this), -1)"));
			dayObj.style.backgroundColor	=	"#e0e0e0";
		}
		/** 下個月的部分 */
		else if (i >= firstDay + _c().getMonthCount(year_, month_))
		{
			dayObj.innerHTML		=	"<font color='gray'>" + _c()._dr[i] + "</font>";
			dayObj.title			=	(month_ == 12 ? 1 : month_ + 1) + " 月 " + _c()._dr[i] + " 日";
			$(dayObj).bind("click",	Function("_c().dayClick(_it(this), 1)"));
			dayObj.style.backgroundColor	=	"#e0e0e0";
		}
		/** 本月的部分 */
		else
		{
			dayObj.innerHTML		=	_c()._dr[i];
			dayObj.title			=	month_ + " 月 " + _c()._dr[i] + " 日";
			$(dayObj).bind("click",	Function("_c().dayClick(_it(this), 0)"));
			/** 如果是當前選擇的日期，則顯示亮藍色的背景；如果是當前日期，則顯示暗黃色背景 */
			if(!_c()._id)
				dayObj.style.backgroundColor	=	((year_ == new Date().getFullYear() && month_ == (new Date().getMonth() + 1) && _c()._dr[i] == new Date().getDate()) ? "#FF5959" : "#e0e0e0");
			else
			{
				dayObj.style.backgroundColor	=	(year_ == _c()._id.getFullYear() && month_ == _c()._id.getMonth() + 1 && _c()._dr[i] == _c()._id.getDate()) ? "#A6C8FB" :
				((year_ == new Date().getFullYear() && month_ == new Date().getMonth() + 1 && _c()._dr[i] == new Date().getDate()) ? "#FF5959" : "#e0e0e0");
			}
		}
		dayObj.style.cursor	=	"pointer";
	}
}

/**
點擊顯示框選取日期
x@param	ex	表示偏移量，用於選擇上個月份和下個月份的日期
*/
_c().dayClick	=	function (clickDay_, ex_)
{
	var	year_	=	_c()._dy;
	var	month_	=	_p(_c()._dm) + ex_;

	/** 判斷月份，並進行對應的處理 */
	if(month_ < 1)
	{
		year_--;
		month_	=	12 + month_;
	}
	else if(month_>12)
	{
		year_++;
		month_	=	month_ - 12;
	}

	if (!clickDay_)
		return;

	/** 註：在這裡你可以輸出改成你想要的格式 */
	if (_df == 1)
		_c()._io.value	=	_fz(year_ - 1911 + '', 3) + _fz(month_ + '', 2) +  _fz(clickDay_ + '', 2);
	else
		_c()._io.value	=	_fz(year_ + '', 4) + _fz(month_ + '', 2) + _fz(clickDay_ + '', 2);
	_c()._io.focus();
	_c().closeCalendar();
}

/** 年份的下拉框 */
_c().selectYear	=	function (year_)
{
	if (_df == 1)
		year_	=	year_.substring(0, 3) * 1 + 1911;
	var	htmlBuff	=	[];
	htmlBuff.push
	(
		"<select size='10' id='__SelectYear'" +
		"onblur='_(\"__SelectYearSpan\").style.display=\"none\";'" +
		"onclick='" +
		"_(\"__SelectYearSpan\").style.display=\"none\";" +
		"_c()._dy=this.value;" +
		"_c().setDate(_c()._dy, _c()._dm);'>"
	);

	for (var i = (_p(year_, 10) - 70); i < (_p(year_, 10) + 70); i++)
	{
		if (i == year_)
		{
			if(_df == 1)
				htmlBuff.push ("<option value='" + i + "' selected>" + (i - 1911) + " 年" + "</option>\r\n");
			else
				htmlBuff.push ("<option value='" + i + "' selected>" + i + " 年" + "</option>\r\n");
		}
		else
		{
			if(_df == 1)
				htmlBuff.push ("<option value='" + i + "'>" + (i - 1911) + " 年" + "</option>\r\n");
			else
				htmlBuff.push ("<option value='" + i + "'>" + i + " 年" + "</option>\r\n");
		}
	}
	htmlBuff.push ("</select>");

	_("__SelectYearSpan").style.display	=	"";
	_("__SelectYearSpan").innerHTML		=	htmlBuff.join("");
	_("__SelectYear").focus();
}

/** 月份的下拉框 */
_c().selectMonth	=	function (month_)
{
	var	htmlBuff	=	[];
	htmlBuff.push
	(
		"<select size='10' id='__SelectMonth'" +
		"onblur='_(\"__SelectMonthSpan\").style.display=\"none\";'" +
		"onchange='" +
		"_(\"__SelectMonthSpan\").style.display=\"none\";" +
		"_c()._dm=this.value;" +
		"_c().setDate(_c()._dy, _c()._dm)'>\r\n"
	);

	for (var i = 1; i <= 12; i++)
	{
		if (i == (month_ || new Date().getMonth() + 1))
			htmlBuff.push ("<option value='" + i + "' selected>" + i + " 月</option>\r\n");
		else
			htmlBuff.push ("<option value='" + i + "'>" + i + " 月</option>\r\n");
	}
	htmlBuff.push ("</select>");
	_("__SelectMonthSpan").style.display	=	"";
	_("__SelectMonthSpan").innerHTML	=	htmlBuff.join("");
	_("__SelectMonth").focus();
}

/** 關閉日曆 */
_c().closeCalendar	=	function ()
{
	if (_c()._cd != null)
	{
		_c()._cd.style.display	=	"none";
		Message.showDiv ("__Calendar", 0);
	}
}

/** 閏年二月為29天 */
_c().getMonthCount	=	function (year_, month_)
{
	/** 定義陽曆中每個月的最大天數 */
	var	MonHead	=	new Array(31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31);
	var	result_	=	MonHead[month_ - 1];
	if((month_ == 2))
	{
		/** 判斷是否閏平年 */
		if (year_ % 4 == 0 && ((year_ % 100 != 0) || (year_ % 400 == 0)))
			result_++;
	}
	return result_;
};

/** 往前翻 Year */
_c().prevYear	=	function ()
{
	if(_c()._dy > 999 && _c()._dy < 10000)
		_c()._dy--;
	else
	{
		//年份超出範圍（1000-9999）！
		alert(Message.getMessage("222"));
	}

	_c().setDate(_c()._dy, _c()._dm);
}

/** 往後翻 Year */
_c().nextYear	=	function ()
{
	if(_c()._dy > 999 && _c()._dy <10000)
		_c()._dy++;
	else
	{
		//年份超出範圍（1000-9999）！
		alert(Message.getMessage("222"));
	}

	_c().setDate(_c()._dy, _c()._dm);
}

/** Today Button */
_c().today	=	function ()
{
	_c()._dy	=	new Date().getFullYear();
	_c()._dm	=	new Date().getMonth() + 1;

	if(_c()._io)
	{
		if (_df == 1)
			_c()._io.value	=	_fz(_c()._dy - 1911 + '', 3) + _fz(_c()._dm + '', 2) + _fz(new Date().getDate() + '', 2);
		else
			_c()._io.value	=	_fz(_c()._dy + '', 4) + _fz(_c()._dm + '', 2) + _fz(new Date().getDate() + '', 2);
	}

	_c()._io.focus();
	_c().closeCalendar();
}

/** 往前翻月份 */
_c().prevMonth	=	function ()
{
	if(_c()._dm > 1)
		_c()._dm--;
	else
	{
		_c()._dy--;
		_c()._dm	=	12;
	}
	_c().setDate(_c()._dy, _c()._dm);
}

/** 往後翻月份 */
_c().nextMonth	=	function ()
{
	if(_c()._dm == 12)
	{
		_c()._dy++;
		_c()._dm	=	1;
	}
	else
		_c()._dm++;
	_c().setDate(_c()._dy, _c()._dm);
}

Calendar.init();