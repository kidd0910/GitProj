/**
@fileoverview
定義 StringBuffer 型態物件

@class StringBuffer
定義 StringBuffer 型態物件

@author &#29256;&#27402;&#25152;&#26377; &#23439;&#30849;&#32929;&#20221;&#26377;&#38480;&#20844;&#21496; &copy;2006 Acer Inc.
@version 0.0.1
*/

/**
@constructor StringBuffer
*/
function StringBuffer()
{
	/** buffer_*/
	this.b_	=	[];
};

/**
@method StringBuffer.prototype.append
新增字串在後面
@param	String	str	預新增的字串
*/
StringBuffer.prototype.append	=	function (str_)
{
	this.b_[this.b_.length]	=	str_;
}

/**
@method StringBuffer.prototype.insert
新增字串在前面
@param	String	str	預新增的字串
*/
StringBuffer.prototype.insert	=	function (str_)
{
	for (var i = this.b_.length; i > 0; i--)
		this.b_[i]	=	this.b_[i - 1];

	this.b_[0]	=	str_;
}

/**
@method StringBuffer.prototype.clear
清空 StringBuffer 內容
*/
StringBuffer.prototype.clear	=	function ()
{
	this.b_.length	=	0;
};

/**
@method StringBuffer.prototype.length
取的 StringBuffer 內容長度
@return	int	長度
*/
StringBuffer.prototype.length	=	function ()
{
	return this.b_.join('').length;
};

/**
@method StringBuffer.prototype.toString
取的 StringBuffer 內容
@return	String	StringBuffer 內容
*/
StringBuffer.prototype.toString	=	function ()
{
	return this.b_.join('');
};