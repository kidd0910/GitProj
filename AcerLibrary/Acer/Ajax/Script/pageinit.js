/**
----------------------------------------------------------------------------------------
Vers 	Date		By			Notes
------	--------------	--------------		----------------------------------------
1.0.8	2006/11/29	nono			將檢查必須包含在框架中的檢核拿掉, 避免造成不必要的混淆
						*Note: 不能混淆, 否則宣告的變數會亂掉
1.0.7	2006/04/20	nono			1. 將資料處理中窗拿掉(太耗資源)
1.0.6	2006/04/18	nono			1. 修正 ProcessBar 框度變更時不會跟著變大的問題
1.0.5	2006/04/16	nono			1. 增加判斷 Js 統一由 Top 載入還是個別載入
1.0.5	2006/04/15	nono			1. 將 PopUp 元件移除
						2. 新稱加 Ajax 元件
						3. 新增加 Hashtable 元件
						4. 將 onerror 處理機制放在 onload 外, 避免無法追蹤 page onload 發生的錯誤訊息
1.0.4	2006/04/11	nono			1. 新增加 Calendar 元件
1.0.3	2006/04/03	nono			1. 將 SuccessWindow 改為呼叫共用元件方式處理
1.0.2	2006/03/28	nono			1. 新增加控制 Sucess Window 功能
						2. 將訊息顯示時間改為可由外部設定每頁或共通顯示時間
1.0.1	2006/03/27	nono			1. 將功能改由外部控制, 彈性化
						2. 新增加控制 Process Bar 功能
----------------------------------------------------------------------------------------
*/

doImport ("PageScript.js, SuccessWindow.js, Calendar.js");

/** 重新啟動 Timer */
function startTimerEvent()
{
	try{top.startTimer();}catch(e){}
}

function onloadEvent()
{
	/** 螢幕保護機制 */
	if (top._isScreenSaver)
		startTimerEvent();
		
	Calendar.init();
	SuccessWindow.init();
}
 
$(document).ready(onloadEvent);

/** 螢幕保護機制 */
if (top._isScreenSaver)
{
	$(document).bind('mousemove', startTimerEvent);
	$(document).bind('keypress', startTimerEvent);
}