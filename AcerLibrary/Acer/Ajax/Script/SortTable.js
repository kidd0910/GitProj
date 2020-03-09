/**
@fileoverview
主要是用來排序 Table 內的資料
使用方法：
在想加上排序的 Table 中加上 class='sortable' 即可
Exp:
&lt;table class='sortable'>...&lt;/table>

@class SortTable
主要是用來排序 Table 內的資料
使用方法：
在想加上排序的 Table 中加上 class='sortable' 即可
Exp:
&lt;table class='sortable'>...&lt;/table>

@author &#29256;&#27402;&#25152;&#26377; &#23439;&#30849;&#32929;&#20221;&#26377;&#38480;&#20844;&#21496; &copy;2006 Acer Inc.
@version 0.0.1
*/

/**
@constructor SortTable
*/
var	SortTable	=	new Object();

//SortTable.addEvent(window, "load", SortTable.sortables_init);

SortTable.SORT_COLUMN_INDEX	=	null;

SortTable.sortables_init	=	function () 
{
	/** Find all tables with class sortable and make them sortable */
	if (!_d().getElementsByTagName) 
		return;
		
	var	tables	=	_d().getElementsByTagName("table");
	
	for (var i = 0; i < tables.length; i++) 
	{
		thisTable	=	tables[i];
		if (thisTable.className.toUpperCase() == "SORTABLE" && thisTable.id)
			SortTable.ts_makeSortable(thisTable);
	}
}

SortTable.ts_makeSortable	=	function (_table) 
{
	/** 有資料時處理 */
	var	firstRow;
	if (_table.rows && _table.rows.length > 0) 
		firstRow	=	_table.rows[0];
	else
		return;
    
	var	cell_	=	null;
	var	txt_	=	null; 
	for (var i = 0; i < firstRow.cells.length; i++) 
	{
		cell_		=	firstRow.cells[i];
		txt_		=	SortTable.ts_getInnerText(cell_);
		if (txt_.indexOf('查無符合資料!!') == -1)
		{
			cell_.innerHTML =	'<a href="#" class="sortheader" onclick="SortTable.ts_resort_table(this, ' + i + ');return false;">' + 
						txt_ + '<span class="sortarrow">&nbsp;&nbsp;&nbsp;</span></a>';
		}
	}
}

SortTable.ts_getInnerText	=	function (_cell) 
{
	if (typeof _cell == "string") 
		return _cell;
	if (typeof _cell == "undefined") 
		return _cell;
	if (_it(_cell)) 
		return _it(_cell);	//Not needed but it is faster

	var	result	=	"";
	var	cellStr	=	_cell.childNodes;
	var	cellLen	=	cellStr.length;
	for (var i = 0; i < cellLen; i++) 
	{
		switch (cellStr[i].nodeType) 
		{
			case 1:	//ELEMENT_NODE
				result	+=	SortTable.ts_getInnerText(cellStr[i]);
				break;
			case 3:	//TEXT_NODE
				result	+=	cellStr[i].nodeValue;
				break;
		}
	}
	return result;
}

SortTable.ts_resort_table	=	function (lnk, clid) 
{
	// get the span
	var	spanObj;
	for (var ci = 0; ci < lnk.childNodes.length; ci++) 
	{
		if (lnk.childNodes[ci].tagName && lnk.childNodes[ci].tagName.toLowerCase() == 'span') 
			spanObj	=	lnk.childNodes[ci];
	}
    
	var	tdObj		=	lnk.parentNode;
	var	columnIndex	=	clid || tdObj.cellIndex;
	var	tableObj	=	SortTable.getParent(tdObj, 'TABLE');
    
	// Work out a type for the column
	if (tableObj.rows.length <= 1) 
		return;
	
	/** 取得欄位種類 */
	var	itm	=	null;
	var	sortfn	=	null;
	for (var ci = 1; ci < tableObj.rows.length; ci++)
	{
		itm	=	SortTable.ts_getInnerText(tableObj.rows[ci].cells[columnIndex]);
		if (isNaN(itm))
			sortfn	=	SortTable.ts_sort_caseinsensitive;
	}
	
	if (sortfn == null)
		sortfn	=	SortTable.ts_sort_numeric;
    	
	SortTable.SORT_COLUMN_INDEX	=	columnIndex;
	var	firstRow	=	new Array();
	var	newRows		=	new Array();
	for (var i = 0; i < tableObj.rows[0].length; i++)
	{ 
		firstRow[i]	=	tableObj.rows[0][i]; 
	}
	for (var j = 1; j < tableObj.rows.length; j++) 
	{
		newRows[j - 1]	=	tableObj.rows[j]; 
	}
	newRows.sort(sortfn);
	
	var	ARROW	=	null;
	if (spanObj.getAttribute("sortdir") == 'down') 
	{
		ARROW	=	'&nbsp;&nbsp;&uarr;';
		newRows.reverse();
		spanObj.setAttribute('sortdir','up');
	} 
	else 
	{
		ARROW	=	'&nbsp;&nbsp;&darr;';
		spanObj.setAttribute('sortdir','down');
	}
	
	// We appendChild rows that already exist to the tbody, so it moves them rather than creating new ones
	// don't do sortbottom rows
	for (var i = 0; i < newRows.length; i++) 
	{ 
		if (!newRows[i].className || (newRows[i].className && (newRows[i].className.indexOf('sortbottom') == -1))) 
			tableObj.tBodies[0].appendChild(newRows[i]);
	}
	// do sortbottom rows only
	for (var i = 0; i < newRows.length; i++) 
	{ 
		if (newRows[i].className && (newRows[i].className.indexOf('sortbottom') != -1)) 
			tableObj.tBodies[0].appendChild(newRows[i]);
	}
	
	// Delete any other arrows there may be showing
	var	allspans	=	_d().getElementsByTagName("span");
	for (var ci = 0; ci < allspans.length; ci++) 
	{
		if (allspans[ci].className == 'sortarrow') 
		{
			if (SortTable.getParent(allspans[ci],"table") == SortTable.getParent(lnk,"table")) 
			{ // in the same table as us?
				allspans[ci].innerHTML	=	'&nbsp;&nbsp;&nbsp;';
			}
		}
	}
	
	spanObj.innerHTML	=	ARROW;
}

SortTable.getParent	=	function (_element, pTagName) 
{
	if (_element == null) 
		return null;
	else if (_element.nodeType == 1 && _element.tagName.toLowerCase() == pTagName.toLowerCase())	// Gecko bug, supposed to be uppercase
		return _element;
	else
		return SortTable.getParent(_element.parentNode, pTagName);
}

SortTable.ts_sort_currency	=	function (_a, _b) 
{ 
	aa_	=	SortTable.ts_getInnerText(_a.cells[SortTable.SORT_COLUMN_INDEX]).replace(/[^0-9.]/g, '');
	bb_	=	SortTable.ts_getInnerText(_b.cells[SortTable.SORT_COLUMN_INDEX]).replace(/[^0-9.]/g, '');
	return parseFloat(aa_) - parseFloat(bb_);
}

SortTable.ts_sort_numeric	=	function (_a, _b) 
{ 
	aa_ = parseFloat(SortTable.ts_getInnerText(_a.cells[SortTable.SORT_COLUMN_INDEX]));
	if (isNaN(aa_)) 
		aa_	=	0;
	bb_ = parseFloat(SortTable.ts_getInnerText(_b.cells[SortTable.SORT_COLUMN_INDEX])); 
	if (isNaN(bb_)) 
		bb_	=	0;
	return aa_ - bb_;
}

SortTable.ts_sort_caseinsensitive	=	function (_a, _b) 
{
	aa_	=	SortTable.ts_getInnerText(_a.cells[SortTable.SORT_COLUMN_INDEX]).toLowerCase();
	bb_	=	SortTable.ts_getInnerText(_b.cells[SortTable.SORT_COLUMN_INDEX]).toLowerCase();
	if (aa_ == bb_) 
		return 0;
	if (aa_ < bb_)
		return -1;
	return 1;
}

SortTable.addEvent	=	function (elm, evType, fn, useCapture)
// addEvent and removeEvent
// cross-browser event handling for IE5+,  NS6 and Mozilla
// By Scott Andrew
{
	if (elm.addEventListener)
	{
		elm.addEventListener(evType, fn, useCapture);
		return true;
	} 
	else if (elm.attachEvent)
	{
		return	elm.attachEvent("on" + evType, fn);
	} 
	else 
	{
		alert("Handler could not be removed");
	}
} 
