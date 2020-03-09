doImport ("StrUtil.js");

/**
@fileoverview
檢查各種資料是否符合規定相關之共用函式

@class Check
檢查各種資料是否符合規定相關之共用函式

@author &#29256;&#27402;&#25152;&#26377; &#23439;&#30849;&#32929;&#20221;&#26377;&#38480;&#20844;&#21496; &copy;2006 Acer Inc.
@version 0.0.1
*/

/**
@constructor Check
*/
var	Check	=	new Object();

/**
@method Check.chkID
檢查身份證及統一編號 空白或 * 不檢查
@param	String	usrId	身份證或統一編號字串
@return	boolean 	是否身分證/統編
*/
Check.chkID	=	function (usrId)
{
	if (usrId.length == 0)
		return true;
	/** 長度不對傳回失敗 */
	else if (usrId.length != 8 && usrId.length != 10)
		return false;
	/** 第一碼 * 號不檢查 */
	else if(usrId._s(0, 1) == "*")
		return true;
	/** 檢查統編 */
	else if (usrId.length == 8)
		return Check.checkTaxID(usrId);
	/** 檢查身分證字號 */
	else if (usrId.length == 10)
		return Check.chkIDNO(usrId);
}

/**
@method Check.checkMail
檢查 EMail 格式
@param	mail	EMail
@return	boolean 是否 EMail
*/
Check.checkMail	=	function (mail)
{
	if (mail == '') 
		return true; 
	
	if (mail.indexOf("@") == -1 || mail.indexOf(".") == -1 || mail.split('@').length > 2)
		return false;
	/**
	var	strr;
	re	=	/(\w+@\w+\.\w+)(\.{0,1}\w*)(\.{0,1}\w*)/i;
	re.exec(mail);
	
	if (RegExp.$3 != "" && RegExp.$3 != "." && RegExp.$2 != ".")  
		strr	=	RegExp.$1 + RegExp.$2 + RegExp.$3
	else
	{
		if  (RegExp.$2 != "" && RegExp.$2 != ".")  
			strr	=	RegExp.$1 + RegExp.$2
		else    
			strr	=	RegExp.$1
	}
	if  (strr!=mail)  
	{
		return  false
	}
	*/
	
	//nono add 2010/01/22
	if (mail.indexOf("'") != -1 )
		return false;
	
	return  true;
}

/**
@method Check.checkURL
檢查 URL 格式
@param	url	URL
@return	boolean 是否 URL
*/
Check.checkURL	=	function (url)
{
	if (url == '') 
		return true; 
	var	re	=	/https?:\/\/([-\w\.]+)+(:\d+)?(\/([\w/_\.]*(\?\S+)?)?)?/;
	return re.test(url.toLowerCase());
}

/**
@method Check.checkTEL
檢查電話格式
@param	tel	TEL
@return	boolean 是否電話格式
*/
Check.checkTEL	=	function (tel)   
{   
	if (tel == '') 
		return true; 
		
	//var	reg	=	/^([0-9]|[\-]|[()]|[#])+$/g ;
	if(tel.length < 7 || tel.length > 50)
	{
		return false;
	}
	/** nono mark , free format 無法檢查
	else
	{
		if (tel.match(reg) == null)
			return false;
		else
			return true;
	}
	*/
	return true;
}  

/**
@method Check.checkIP
檢查 IP 格式
@param	ip	IP
@return	boolean 是否 IP
*/
Check.checkIP	=	function (ip)   
{   
	if (ip == '') 
		return true; 
		
	var	re	=	/^(\d+)\.(\d+)\.(\d+)\.(\d+)$/g;
	
	if(re.test(ip)) 
	{
		var	ipAry	=	ip.split('.');
		for (var i = 0; i < ipAry.length; i++)
		{
			if (ipAry[i].length > 3)
				return false;
		}
	
		if(RegExp.$1 < 256 && RegExp.$2 < 256 && RegExp.$3 < 256 && RegExp.$4 < 256) 
			return true; 
	} 
	return false;
}  

/**
@method Check.checkTaxID
檢查統一編號
@param	String	str	統一編號字串
@return	boolean	是否統一編號
*/
Check.checkTaxID	=	function (usrId)
{
	/** @private 乘上權數 */
	this.fz_	=	function (str_, _s1, _e, _i)
	{
		return _fz((str_._s(_s1, _e) * _i) + '', 2);
	}

	/** @private 計算乘積和 */
	this.fc_	=	function (_ps)
	{
		return _p(_ps._s(0, 1)) + _p(_ps._s(1, 2));
	}

	/** 直接呼叫檢核 */
	if (usrId.length != 8)
		return false;

	var li_v1, li_v2, li_v3, li_v4, li_v5, li_v6, li_v7, li_v8;
	var ls_v1, ls_v2, ls_v3, ls_v4, ls_v5, ls_v6, ls_v7, ls_v8;
	var lb_ret1,lb_ret2, lb_retval;

	/** 乘上權數 */
	ls_v1	=	this.fz_(usrId, 0, 1, 1);
	ls_v2	=	this.fz_(usrId, 1, 2, 2);
	ls_v3	=	this.fz_(usrId, 2, 3, 1);
	ls_v4	=	this.fz_(usrId, 3, 4, 2);
	ls_v5	=	this.fz_(usrId, 4, 5, 1);
	ls_v6	=	this.fz_(usrId, 5, 6, 2);
	ls_v7	=	this.fz_(usrId, 6, 7, 4);
	ls_v8	=	this.fz_(usrId, 7, 8, 1);

	/** 計算乘積和 */
	li_v1	=	this.fc_(ls_v1);
	li_v2	=	this.fc_(ls_v2);
	li_v3	=	this.fc_(ls_v3);
	li_v4	=	this.fc_(ls_v4);
	li_v5	=	this.fc_(ls_v5);
	li_v6	=	this.fc_(ls_v6);
	li_v7	=	this.fc_(ls_v7);
	li_v8	=	this.fc_(ls_v8);

	if (((li_v1 + li_v2 + li_v3 + li_v4 + li_v5 + li_v6 + li_v7 + li_v8) % 10) == 0)
		lb_ret1	=	true;
	else
		lb_ret1	=	false;

	if (li_v7 == 10)
	{
		if (((li_v1 + li_v2 + li_v3 + li_v4 + li_v5 + li_v6 + 1 + li_v8) % 10) == 0)
			lb_ret2	=	true;
		else
			lb_ret2	=	false;
	}
	else
		lb_ret2	=	false;

	lb_retval	=	(lb_ret1 || lb_ret2);

	return lb_retval;
}

/**
@method Check.chkIDNO
檢查身份証字號
@param	String	str	身份証字串
@return	boolean	是否身份証字號
*/
Check.chkIDNO	=	function (usrId)
{
	if (usrId.length != 10)
		return false;

	var	Flag		=	false;
	var	id_num		=	"";

	/** 定義區域表的轉換值，沒有 I, O */
	var	location 	=
	[
		["A", "台北市", "10"],
		["B", "台中市", "11"],
		["C", "基隆市", "12"],
		["D", "台南市", "13"],
		["E", "高雄市", "14"],
		["F", "台北縣", "15"],
		["G", "宜蘭縣", "16"],
		["H", "桃園縣", "17"],
		["J", "新竹縣", "18"],
		["K", "苗栗縣", "19"],
		["L", "台中縣", "20"],
		["M", "南投縣", "21"],
		["N", "彰化縣", "22"],
		["P", "雲林縣", "23"],
		["Q", "嘉義縣", "24"],
		["R", "台南縣", "25"],
		["S", "高雄縣", "26"],
		["T", "屏東縣", "27"],
		["U", "花蓮縣", "28"],
		["V", "台東縣", "29"],
		["W", "金門縣", "32"],
		["X", "澎湖縣", "30"],
		["Y", "陽明山", "31"],
		["Z", "馬祖",   "33"],
		["I", "嘉義市", "34"],
		["O", "新竹市", "35"]
	];

	for(var i = 0; i < location.length; i++)
	{
		if(usrId._s(0,1).toUpperCase() == location[i][0])
		{
			/** 轉換成完整數字串列 */
			usrId	=	location[i][2] + usrId._s(1,usrId.length);
			id_num	=	usrId._s(0, 1) * 1 +
					usrId._s(1, 2) * 9 +
					usrId._s(2, 3) * 8 +
					usrId._s(3, 4) * 7 +
					usrId._s(4, 5) * 6 +
					usrId._s(5, 6) * 5 +
					usrId._s(6, 7) * 4 +
					usrId._s(7, 8) * 3 +
					usrId._s(8, 9) * 2 +
					usrId._s(9, 10) * 1 +
					usrId._s(10, 11) * 1;
			if ((id_num % 10) == 0)
				Flag	=	true;
		}
	}
	return Flag;
}

/**
@method Check.isCDate
判斷民國日期是否合法
@param	String	date	民國日期字串 yyymmdd(yymmdd, yyy/mm/dd, yy/mm/dd)
@return	boolean	是否民國日期
*/
Check.isCDate	=	function (date_)
{
	/** 將 / 拿掉 */
	date_ 	=	date_._r(/\/\s*/g, "");

	/** 六碼填滿檢查 */
	if (date_.length == 6)
		date_	=	_fz(date_ , 7);

	if (date_.length != 7)
		return false;

	/** 非數字型態回傳錯誤 */
	if (isNaN(date_))
		return false;
		
	/** 轉換民國 -> 西元 */
	var	year	=	date_._s(0, 3) * 1 + 1911;
	var	month	=	date_._s(3, 5);
	var	day	=	date_._s(5, 7);

	var	dateStr	=	"" + year + month + day;

	return Check.isDate(dateStr);
}

/**
@method Check.isDate
判斷西元日期是否合法
@param	String	date	西元日期字串 yyyymmdd(yyyy/mm/dd, yyyy-mm-dd)
@return	boolean	是否西元日期
*/
Check.isDate	=	function (date_)
{
	/** 將 / - 拿掉 */
	date_ 	=	date_._r(/\/\s*/g, "")._r(/-/g, "");

	if (date_.length != 8)
		return false;
		
	/** 非數字型態回傳錯誤 */
	if (isNaN(date_))
		return false;

	var	year	=	date_._s(0,4) * 1;
	var	month	=	date_._s(4,6) * 1;
	var	day	=	date_._s(6,8) * 1;

	if (month < 1 || month > 12)
		return false;
	if (day < 1 || day > 31)
		return false;
	if ((month == 4 || month == 6 || month == 9 || month == 11) && day == 31)
		return false;
	if (month == 2)
	{
		var isleap = (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0));
		if (day > 29 || (day==29 && !isleap))
			return false;
	}
	return true;
}

/**
@method Check.isTime
判斷時間是否合法
@param	String	time	時間字串 hhmmss (hh:mm:ss, hhmm, hh:mm)
@return	boolean	是否時間
*/
Check.isTime	=	function (time_)
{
	/** 將 : 拿掉 */
	time_ 	=	time_._r(/:/g, "")._r(/\./g, "");

	if (!(time_.length == 6 || time_.length == 4))
		return false;
		
	/** 非數字型態回傳錯誤 */
	if (isNaN(time_))
		return false;

	/** 檢查小時 */
	var	hh	=	time_._s(0, 2) * 1;
	if (hh < 0 || hh >= 24)
		return false;

	/** 檢查分 */
	var	mm	=	time_._s(2, 4) * 1;
	if (mm < 0 || mm >= 60)
		return false;

	/** 檢查秒 */
	if (time_.length == 6)
	{
		var	ss	=	time_._s(4, 6) * 1;
		if (ss < 0 || ss >= 60)
			return false;
	}

	return true;
}

/**
@method Check.checkBig5
檢查字串裡是否有中文
@param	String	str	字串
@return	boolean	是否有中文
*/
Check.checkBig5	=	function (str_)
{
	if (StrUtil.getBLen(str_) != str_.length)
		return true;
	else
		return false;
}

/**
@method Check.isContain
檢核是否包含在物件之中
@param	Object	checkObj	要檢核的物件
@param	Object	parentObj	主要物件
@return	boolean	是否包含在物件之中
*/
Check.isContain	=	function (checkObj, parentObj)
{
	var	tmpObj	=	checkObj;
	while (tmpObj.tagName != "HTML")
	{
		tmpObj	=	tmpObj.parentNode;
		if (tmpObj == parentObj)
			return true;
	}

	return false;
}