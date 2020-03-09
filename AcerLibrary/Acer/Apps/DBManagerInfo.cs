using System;
using System.Collections;
using Acer.Log;
using Acer.Form;
using System.Web;

namespace Acer.Apps
{
	/// <summary>
	/// 處理取得資料庫處理訊息, 交易狀況, 資料庫元件使用統計
	/// </summary>
	public class DBManagerInfo
	{
		/// <summary>資料庫使用情況</summary>
		private	static	Hashtable	dbManagerInfo	=	new Hashtable();
		private	static	DateTime	lastLogTime	=	System.DateTime.Now;

		/// <summary>
		/// 紀錄交易總數
		/// </summary>
		public static void LogCount() 
		{	
			if (Microsoft.VisualBasic.DateAndTime.DateDiff(Microsoft.VisualBasic.DateInterval.Hour, System.DateTime.Now, DBManagerInfo.lastLogTime, Microsoft.VisualBasic.FirstDayOfWeek.Sunday, Microsoft.VisualBasic.FirstWeekOfYear.FirstFullWeek) > 1)
			{
				DBManagerInfo.lastLogTime	=	System.DateTime.Now;
				MyLogger.Log 
				(
					MyLogger.Debug, "DBManagerInfo.logCount",
					"交易狀態\r\nTransaction Count: " + DBManagerInfo.GetCount("Transaction Start") + "\r\n" +
					"Transaction Commit: " + DBManagerInfo.GetCount("Transaction Commit") + "\r\n" +
					"Transaction Rollback: " + DBManagerInfo.GetCount("Transaction Rollback") + "\r\n" +
					"Transaction Faile: " + DBManagerInfo.GetCount("Transaction Faile") + "\r\n" +
					"其他統計\r\n" +
					"DBAccess Count: " + DBManagerInfo.GetCount("DBAccess") + "\r\n" +
					"DBResult Count: " + DBManagerInfo.GetCount("DBResult") + "\r\n" +
					"SimpleResultSet Count: " + DBManagerInfo.GetCount("SimpleResultSet") + "\r\n" +
					"DBPageResultSet Count: " + DBManagerInfo.GetCount("DBPageResultSet"),
					"",
					0
				);
			}
		}

		private	static	Object addCountObject	=	new Object();

		/// <summary>
		/// 累加資料庫元件使用數
		/// </summary>
		/// <param name="countType">元件種類</param>
		public static void AddCount(string countType)
		{
			lock(addCountObject)
			{
				if (DBManagerInfo.dbManagerInfo[countType] == null)
					DBManagerInfo.dbManagerInfo[countType]	=	"0";
				DBManagerInfo.dbManagerInfo[countType]	=	Convert.ToString(Convert.ToInt64(DBManagerInfo.dbManagerInfo[countType].ToString()) + 1);
			}
		}
		
		private	static	Object getCountObject	=	new Object();

		/// <summary>
		/// 取得資料庫元件使用數
		/// </summary>
		/// <param name="countType">元件種類</param>
		/// <returns>使用數</returns>
		public static string GetCount(string countType)
		{
			lock(getCountObject)
			{
				if (DBManagerInfo.dbManagerInfo[countType] == null)
					DBManagerInfo.dbManagerInfo[countType]	=	"0";
				return Convert.ToString(Convert.ToInt64(DBManagerInfo.dbManagerInfo[countType].ToString()));
			}
		}
		
		/// <summary>
		/// 處理 HTTP Get request
		/// 處理展現統計資料的頁面
		/// </summary>
		public static void DoCall()
		{
			HttpResponse	response	=	FormUtil.Response;
			
			response.Write
			(
				"<html>"+
				"<head>" +
				"<title>DBMabagerInfo</title>" +
				"<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">" +
				"</head>" +
				"<body>" +
				"	<table align=center border=1>" +
				"		<tr bgcolor=pink><td colspan=8><b>交易狀態</b></td></tr>" +
				"		<tr>" +
				"			<td><b>Transaction Count: </b></td>" +
				"			<td width=100 align=right>" + DBManagerInfo.GetCount("Transaction Start") + "</td>" +
				"		</tr><tr>" +
				"			<td><b>Transaction Commit: </b></td>" +
				"			<td width=100 align=right>" + DBManagerInfo.GetCount("Transaction Commit") + "</td>" +
				"		</tr><tr>" +
				"			<td><b>Transaction Rollback: </b></td>" +
				"			<td width=100 align=right>" + DBManagerInfo.GetCount("Transaction Rollback") + "</td>" +
				"		</tr><tr>" +
				"			<td><b>Transaction Faile: </b></td>" +
				"			<td width=100 align=right>" + DBManagerInfo.GetCount("Transaction Faile") + "</td>" +
				"		</tr><tr bgcolor=pink>" +
				"			<td colspan=8><b>其他統計</b></td>" +
				"		</tr><tr>" +
				"			<td><b>DBAccess Count: </b></td>" +
				"			<td width=100 align=right>" + DBManagerInfo.GetCount("DBAccess") + "</td>" +
				"		</tr><tr>" +
				"			<td><b>DBResult Count: </b></td>" +
				"			<td width=100 align=right>" + DBManagerInfo.GetCount("DBResult") + "</td>" +
				"		</tr><tr>" +
				"			<td><b>SimpleResultSet Count: </b></td>" +
				"			<td width=100 align=right>" + DBManagerInfo.GetCount("SimpleResultSet") + "</td>" +
				"		</tr><tr>" +
				"			<td><b>DBPageResultSet Count: </b></td>" +
				"			<td width=100 align=right>" + DBManagerInfo.GetCount("DBPageResultSet") + "</td>" +
				"		</tr>" +
				"	</table>" +
				"</body>" +
				"</html>"
			);
		}
	}
}
