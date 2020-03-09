/**
@fileoverview
定義處理數字型態元件的共用函式

@class Decimal
定義處理數字型態元件的共用函式

@version 0.0.1
*/

/**
@constructor Decimal
初始化 Decimal 物件
*/
function Decimal()
{
	// CONSTANTS;
	/** use comma as 000's separator */
	this.separator	=	",";
	/** use period as decimal point	*/
	this.decpoint	=	".";
	this.percent	=	"%";
	/** use dollar sign for currency */
	this.currency	=	"$";

	this.strip	=	function(input_, chars_)
	{
		try
		{
			/** strip all characters in 'chars' from input*/
			var	output	=	"";	// initialise output string;
			for (var i=0; i < input_.length; i++)
			{
				if (chars_._i(input_._c(i)) == -1)
					output	+=	input_._c(i);
			}
			return output;
		}
		catch(ex)
		{
			throw new Error(getExceptionStr("Decimal.strip", arguments, ex));
		}
	};

	this.separate	=	function(input_, separator_)
	{
		try
		{
			/** format input using 'separator' to mark 000's*/
			input_	=	"" + input_;

			var	output	=	"";	// initialise output string;

			for (var i = 0; i < input_.length; i++)
			{
				if (i != 0 && (input_.length - i) % 3 == 0)
					output	+=	separator_;

				output	+=	input_._c(i);
			}
			return output;
		}
		catch(ex)
		{
			throw new Error(getExceptionStr("Decimal.separate", arguments, ex));
		}
	}
}

/**
@method Decimal.formatNumber
格式化數字
Exp:
Decimal.formatNumber(3, "$0.00")		--> $3.00
Decimal.formatNumber(3.14159265, "##0.####")	--> 3.1416
Decimal.formatNumber(3.14, "0.0###%")		--> 314.0%
Decimal.formatNumber(314159, ",##0.####")	--> 314,159
Decimal.formatNumber(31415962, "$,##0.00")	--> $31,415,962.00
Decimal.formatNumber(cat43, "0.####%")		--> null
Decimal.formatNumber(0.5, "#.00##")		--> 0.50
Decimal.formatNumber(0.5, "0.00##")		--> 0.50
Decimal.formatNumber(0.5, "00.00##")		--> 00.50
Decimal.formatNumber(4.44444, "0.00")		--> 4.44
Decimal.formatNumber(5.55555, "0.00")		--> 5.56
Decimal.formatNumber(9.99999, "0.00")		--> 10.00
@param	Decimal	number	輸入數字
@param	String	format	格式化樣式
@return	String	格式化後的數字
*/
Decimal.formatNumber	=	function (number_, format_)
{
	var	 _separator_	=	(new Decimal()).separator;
	var	 _decpoint_	=	(new Decimal()).decpoint;
	var	 _percent_	=	(new Decimal()).percent;
	var	 _currency_	=	(new Decimal()).currency;
	var	 _strip_	=	(new Decimal()).strip;
	var	 _separate_	=	(new Decimal()).separate;

	if (number_ - 0 != number_)
		throw new Error(getExceptionStr_("Decimal.formatNumber", arguments, "必須輸入數字型態資料!!"));

	var	useSeparator	=	format_._i(_separator_)	!= -1;	// use separators in number;
	var	usePercent	=	format_._i(_percent_)	!= -1;	// convert output to percentage;
	var	useCurrency	=	format_._i(_currency_)	!= -1;	// use currency format;
	var	isNegative	=	(number_ < 0);

	number_	=	Math.abs (number_);

	if (usePercent)
		number_	*=	100;
	format_	=	_strip_(format_, _separator_ + _percent_ + _currency_);	// remove key characters;
	number_	=	"" + number_;						// convert number input to string;

	/**split input value into LHS and RHS using decpoint as divider*/
	var	dec_		=	number_._i(_decpoint_) != -1;
	var	nleftEnd	=	(dec_) ? number_._s(0, number_._i(".")) : number_;
	var	nrightEnd	=	(dec_) ? number_._s(number_._i(".") + 1) : "";

	/**split format string into LHS and RHS using decpoint as divider*/
	dec_	=	format_._i(_decpoint_) != -1;
	var	sleftEnd	=	(dec_) ? format_._s(0, format_._i(".")) : format_;
	var	srightEnd	=	(dec_) ? format_._s(format_._i(".") + 1) : "";

	/**adjust decimal places by cropping or adding zeros to LHS of number*/
	if (srightEnd.length < nrightEnd.length)
	{
		var	nextChar	=	nrightEnd._c(srightEnd.length) - 0;
		nrightEnd	=	nrightEnd._s(0, srightEnd.length);
		if (nextChar >= 5)
			nrightEnd	=	"" + ((nrightEnd - 0) + 1);	// round up;

		/**patch provided by Patti Marcoux 1999/08/06*/
		while (srightEnd.length > nrightEnd.length)
		{
			nrightEnd	=	"0" + nrightEnd;
		}

		if (srightEnd.length < nrightEnd.length)
		{
			nrightEnd	=	nrightEnd._s(1);
			nleftEnd	=	(nleftEnd - 0) + 1;
		}
	}
	else
	{
		for (var i=nrightEnd.length; srightEnd.length > nrightEnd.length; i++)
		{
			/**append zero to RHS of number*/
			if (srightEnd._c(i) == "0")
				nrightEnd += "0";
			else
				break;
		}
	};

	/** adjust leading zeros*/
	sleftEnd	=	_strip_(sleftEnd, "#");	// remove hashes from LHS of format;
	while (sleftEnd.length > nleftEnd.length)
	{
		nleftEnd	=	"0" + nleftEnd;	// prepend zero to LHS of number;
	}

	if (useSeparator)
		nleftEnd	=	_separate_(nleftEnd, _separator_);			// add separator;

	var	output	=	nleftEnd + ((nrightEnd != "") ? "." + nrightEnd : "");	// combine parts;
	output	=	((useCurrency) ? _currency_ : "") + output + ((usePercent) ? _percent_ : "");

	if (isNegative)
	{
		/** patch suggested by Tom Denn 25/4/2001*/
		output	=	(useCurrency) ? "(" + output + ")" : "-" + output;
	}
	return output;
}