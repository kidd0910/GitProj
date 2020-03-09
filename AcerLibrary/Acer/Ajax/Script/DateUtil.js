doImport ("StrUtil.js");

/**
@fileoverview
日期相關的共用函式

@class DateUtil
日期相關的共用函式

@author &#29256;&#27402;&#25152;&#26377; &#23439;&#30849;&#32929;&#20221;&#26377;&#38480;&#20844;&#21496; &copy;2006 Acer Inc.
@version 0.0.1
*/

/**
@constructor DateUtil
*/
var	DateUtil	=	new Object();

/**
@method DateUtil.formatDate
將日期格式化 yyyymmdd --> yyyy/mm/dd(yyyy-mm-dd)
@param	String	date	欲格式化的日期字串
@param	String	delim	格式化字串 '/' 或 '-', 不傳預設為 '/'
return	String	格式化後字串
*/
DateUtil.formatDate	=	function (date_, d_)
{
	if (d_ == null)
		d_	=	"/";

	date_	=	date_._r(/\/\s*/g, "");
	
	return date_._s(0, 4) + d_ + date_._s(4, 6) + d_ + date_._s(6, 8);
}

/** 將日期格式轉為字串 */
_du().toString	=	function (date_, d_)
{
	return _du().formatDate(_fz(date_.getYear(), 4) + _fz(date_.getMonth() + 1, 2) + _fz(date_.getDate(), 2), d_);
}

/**
@method DateUtil.getNowDate
取得系統日期，格式為西元日期 yyyymmdd(yyyy/mm/dd, yyyy-mm-dd)
@param	String	delim	格式化字串, '/' 或 '-', 不傳預設空白
@return	String	西元日期 yyyymmdd
*/
DateUtil.getNowDate	=	function (d_)
{
	if (d_ == null)
		d_	=	"";
	return _du().toString(new Date(), d_);
}

/**
@method DateUtil.getNowCDate
取得系統日期，格式為七碼中文日期. yyymmdd(yyy/mm/dd)
@param	String	delim	格式化字串, '/' 不傳預設空白
@return	String	七碼中文日期 yyymmdd
*/
DateUtil.getNowCDate	=	function (d_)
{
	if (d_ == null)
		d_	=	"";
	var	year_	=	_fz((new Date().getYear() - 1911) + '',	3);
	var	month_	=	_fz((new Date().getMonth() + 1) + '',	2);
	var	day_	=	_fz(new Date().getDate() + '',		2);

	return year_ + d_ + month_ + d_ + day_;
}

/**
@method DateUtil.formatCDate
將民國日期格式化  yyymmdd --> (yyy/mm/dd)
@param	String	date	日期字串
@return	String	中文日期 yyy/MM/dd
*/
DateUtil.formatCDate	=	function (date_)
{
	date_	=	date_._r(/\/\s*/g, "")._r(/-/g, "");
	var	tmpDate	=	_fz(date_, 7);
	return	tmpDate._s(0, 3) + "/" + tmpDate._s(3, 5) + "/" + tmpDate._s(5, 7);
}

/**
@method DateUtil.convert2CDate
將西元日期格式化為民國日期 yyyy/mm/dd(yyyy-mm-dd, yyyymmdd) --> yyymmdd(yyy/mm/dd)
@param	String	date	日期字串
@param	String	delim	格式化字串 '/' 或 '', 不傳預設為空白
@return	String	民國日期
*/
DateUtil.convert2CDate	=	function (date_, d_)
{
	date_	=	date_._r(/\/\s*/g, "")._r(/-/g, "");
	if (d_ == null)
		d_	=	"";

	return _fz((date_._s(0, 4) * 1 - 1911), 3) + d_ + date_._s(4, 6) + d_ + date_._s(6, 8);
}

/**
@method DateUtil.convert2Date
將民國日期格式化為西元日期 yyymmdd(yyy/mm/dd, yymmdd, yy/mm/dd) --> yyyymmdd(yyyy/mm/dd. yyyy-mm-dd)
@param	String	date	日期字串
@param	String	delim	格式化字串 '/' 或 '-' 或 '', 不傳預設為空白
@return	String	西元日期
*/
DateUtil.convert2Date	=	function (date_, d_)
{
	date_	=	_fz(date_, 7)._r(/\/\s*/g, "");
	if (d_ == null)
		d_	=	"";

	return (date_._s(0, 3) * 1 + 1911) + d_ + date_._s(3, 5) + d_ + date_._s(5, 7);
}

/**
@method DateUtil.getCDayDiff
計算相差幾日，日前後都算，格式為民國日期 yyymmdd(yyy/mm/dd, yymmdd, yy/mm/dd)
@param	String	sday	起始日期
@param	String	eday	結束日期
@return	int	相差天數
*/
DateUtil.getCDayDiff	=	function (sday_, eday_)
{
	sday_	=	_fz(sday_, 7)._r(/\/\s*/g, "");
	eday_	=	_fz(eday_, 7)._r(/\/\s*/g, "");

	var	sDate_		=	new Date(_du().convert2Date(sday_, "/"));
	var	eDate_		=	new Date(_du().convert2Date(eday_, "/"));
	var	mills		=	24 * 60 * 60 * 1000;

	/** 格林威治時間(台灣加8:00) */
	var	millsDate	=	sDate_.getTime() + 8 * 60 * 60 * 1000;
	var	milleDate	=	eDate_.getTime() + 8 * 60 * 60 * 1000;

	return parseInt((millsDate - milleDate) / mills);
}

/**
@method DateUtil.getDayDiff
計算相差幾日，日前後都算，格式為西元日期 yyyymmdd(yyyy/mm/dd, yyyy-mm-dd)
@param	String	sday	起始日期
@param	String	eday	結束日期
@return	int	相差天數
*/
DateUtil.getDayDiff	=	function (sday_, eday_)
{
	return _du().getCDayDiff(_du().convert2CDate(sday_), _du().convert2CDate(eday_));
}

/**
@method DateUtil.getEndOfDay
傳入民國(西元)年月回傳中文年月日(正確的月底日期)
Exp:      09202 --> 0920228, 200302 --> 20030228
　　　　　09302 --> 0930229, 200402 --> 20040229
　　　　　09301 --> 0930131, 200401 --> 20040131
　　　　　09311 --> 0931130, 200411 --> 20041130
@param	String	ym	日期字串
@return	String	日
*/
DateUtil.getEndOfDay	=	function (ym_)
{
	var	year, month, day;

	if (ym_.length == 5)
	{
		year	=	ym_._s(0, 3) * 1 + 1911;
		month	=	ym_._s(3, 5);
	}
	else if (ym_.length == 6)
	{
		year	=	ym_._s(0, 4);
		month	=	ym_._s(4, 6);
	}

	switch (month)
	{
		case "01":  case "03":  case  "05":  case "07":  case "08":  case "10": case "12":
			day = 31;
			break;
		case "04": case "06": case "09":  case "11":
			day = 30;
			break;
		case "02":
			if(year % 4 != 0)
				day = 28;
			else
				day = 29;
			break;
		default :
	}

	return day;
}

/**
@method DateUtil.CDateAdd
日期加減，格式為民國日期 yyymmdd(yyy/mm/dd, yymmdd, yy/mm/dd) 
Exp: DateUtil.DateAdd("M", 1, "0930101") --> 0930201
@param	String	type	加減的單位，年或月或日  'Y' or 'M' or 'D'
@param	int	num	加減數量
@param	String	date	要計算的日期
@param	String	delim	格式化字串 '/' 或 '-', 不傳預設為 ''
@return	String	計算後日期
*/
DateUtil.CDateAdd	=	function (type_, num_, date_, d_)
{
	if (d_ == null)
		d_	=	"";
	var	cDate		=	new Date(this.convert2Date(date_, "/"));
	var	year_		=	cDate.getYear();
	var	month_		=	cDate.getMonth();
	var	day_		=	cDate.getDate();
	var	resultDate	=	null;

	switch (type_.toUpperCase())
	{
		case "Y":
			resultDate	=	new Date(year_ + (num_ * 1), month_, day_);
			break;
		case "M":
			resultDate	=	new Date(year_, month_ + (num_ * 1), day_);
			break;
		case "D":
			resultDate	=	new Date(year_, month_, day_ + (num_ * 1));
			break;
	}
	return _du().convert2CDate(_du().toString(resultDate), d_);
}


/**
@method DateUtil.DateAdd
日期加減，格式為西元日期 yyyymmdd(yyyy/mm/dd, yyyy-mm-dd) 
Exp: DateUtil.DateAdd("M", 1, "20040101") --> 20040201
@param	String	type	加減的單位，年或月或日  'Y' or 'M' or 'D'
@param	int	num	加減數量
@param	String	date	要計算的日期
@param	String	delim	格式化字串 '/' 或 '-', 不傳預設為 ''
@return	String	計算後日期
*/
DateUtil.DateAdd	=	function (type_, num_, date_, d_)
{
	return _du().convert2Date(_du().CDateAdd(type_, num_, _du().convert2CDate(date_)), d_);
}

/**
@method DateUtil.getTime
返回自從公元1970年1月1日的毫秒數
@return	String	毫秒數
*/
DateUtil.getTime	=	function ()
{
	return (new Date()).getTime();
}

/** 
@method DateUtil.getWeek
@param	String	date	日期字串 yyyymmdd
取得星期幾
@return String	星期 0-星期日......6-星期六 
*/
DateUtil.getWeek	=	function (date_)
{
	return new Date(this.formatDate(date_, "/")).getDay();
}