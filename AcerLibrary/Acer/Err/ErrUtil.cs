using System;
using System.Text;
using System.Web;
using System.Data.Common;
using Acer.Util;
using Acer.Log;
using Acer.Form;
using Acer.Apps;

namespace Acer.Err
{
	/// <summary>
	/// 定義錯誤訊息的共用物件
	/// </summary>
	public class ErrUtil
	{
		/// <summary>
		/// 將 Exception 的 StractTrace 轉成 string 回傳 
		/// </summary>
		/// <param name="ex">Exception 物件</param>
		/// <returns>轉後字串</returns>
		public static string ErrToStr(Exception ex)
		{
			StringBuilder	buff	=	new StringBuilder();
			buff.Append
			(
				"系統發生錯誤: \r\n" +
				"GC.TotalMemory      : " + System.GC.GetTotalMemory(false) + "\r\n" +
				"Exception.Type      : " + ex.GetType().Name  + "\r\n" +
				"Exception.Message   : " + ex.Message + "\r\n" +
				"Exception.Source    : " + ex.Source + "\r\n" +
				"Exception.HelpLink  : " + ex.HelpLink + "\r\n" +
				"Exception.TargetSite: " + ex.TargetSite + "\r\n" +
				"Exception.StackTrace: \r\n" + ex.StackTrace + "\r\n" +
				"InnerException      : \r\n"
			);

			//=== 檢查更細節的例外處理- InnerException ===
			while(ex.InnerException != null )
			{
				buff.Append(ex.InnerException.ToString() + "\r\n");
				ex	=	ex.InnerException;
			}
			
			return buff.ToString();
		}

		/// <summary>
		/// 取的頁面處理的錯誤訊息
		/// </summary>
		/// <param name="ex">Exception 物件</param>
		/// <returns>錯誤訊息</returns>
		public static string GetPageError(System.Exception ex)
		{
            //if (APConfig.GetProperty("DATA_PROJECT").Equals("海洋大學") || APConfig.GetProperty("DATA_PROJECT").Contains("國防大學") || APConfig.GetProperty("DATA_PROJECT").Contains("東海大學") || APConfig.GetProperty("DATA_PROJECT").Contains("KNUE4"))
            //{
				string	errMessage	=	ErrUtil.ErrToStr(ex);
				if (errMessage.IndexOf("ORA-00001") != -1 || errMessage.IndexOf("違反 PRIMARY KEY 條件約束") != -1 
					|| errMessage.IndexOf("插入重複的索引鍵") != -1 || errMessage.ToLower().IndexOf("duplicate key row") != -1)
					//新增資料重複
					errMessage	=	"402";
				//else
					//系統發生錯誤, 請通知系統管理人員
					//errMessage	=	"403";
                if (errMessage.Equals("402"))
                    return "try{alert(Message.getMessage('" + errMessage + "'));}catch(ex){alert('新增資料重複')}";
                else
                {
                    //特殊錯誤，需顯示給User知道
                    if (errMessage.ToUpper().IndexOf("ALERTERR") != -1)
                        return "try{alert('" + ex.Message.Replace("alertErr:", "") + "');}catch(ex){alert('系統發生錯誤, 請通知系統管理人員!!')}";
                    else
                    {
                        errMessage = "403";
                        return "try{alert(Message.getMessage('" + errMessage + "'));}catch(ex){alert('系統發生錯誤, 請通知系統管理人員!!')}";
                    }
			    }
            //}
            //else
            //{
            //    string		errMessage	=	ErrUtil.ErrToStr(ex).Replace(@"\", @"\\").Replace("'", @"\'").Replace("\r\n", @"\r\n").Replace("\n", @"\r\n");
            //    DbException	dbEx		=	ex as DbException;
            //    if (dbEx != null) 
            //    {
            //        MyLogger.Log(MyLogger.Info, "MyLogger.handlePageError", "dbMsg --> " + dbEx.Message, "", 0);
            //    }
				
            //    string	confirmMsg	=	"";
            //    if (errMessage.IndexOf("ORA-00001") != -1 || errMessage.IndexOf("違反 PRIMARY KEY 條件約束") != -1
            //        || errMessage.IndexOf("插入重複的索引鍵") != -1 || errMessage.ToLower().IndexOf("duplicate key row") != -1)
            //        return "alert('新增資料重複!!')";
            //    else
            //        confirmMsg	=	"004";
				
            //    return	"try{var	confirmMessage	=	\"" + confirmMsg + "\";\r\n" +
            //        "if (Message.showConfirm (confirmMessage))\r\n" +
            //        "{\r\n" +
            //        "	var	errStr	=	'<pre>" + errMessage + "</pre>' +\r\n" +
            //        "				'<hr size=1>' +\r\n" +
            //        "				'<center>' +\r\n" +
            //        "				'<input type=button value=\"C L O S E\" id=\"closeBtn\" onclick=\"top.close();\">' +\r\n" +
            //        "				'</center>';\r\n" +
            //        "	var	errWin	=	WindowUtil.openExceptionWindow(errStr, 900, 600);\r\n" +
            //        "	errWin.closeBtn.focus();\r\n" +
            //        "};}catch(ex){alert(ex);}";
            //}
		}

		/// <summary>
		/// 處理一般頁面處理的錯誤機制
		/// </summary>
		/// <param name="ex">Exception 物件</param>
		public static void HandlePageError(System.Exception ex)
		{
            //if (APConfig.GetProperty("DATA_PROJECT").Equals("海洋大學") || APConfig.GetProperty("DATA_PROJECT").Contains("國防大學") || APConfig.GetProperty("DATA_PROJECT").Contains("東海大學") || APConfig.GetProperty("DATA_PROJECT").Contains("KNUE4"))
            //{
				HttpResponse	response	=	FormUtil.Response;
				response.Clear();
				
				string	errMessage	=	ErrUtil.ErrToStr(ex);
				if (errMessage.IndexOf("ORA-00001") != -1 || errMessage.IndexOf("違反 PRIMARY KEY 條件約束") != -1
					|| errMessage.IndexOf("插入重複的索引鍵") != -1 || errMessage.ToLower().IndexOf("duplicate key row") != -1)
					//新增資料重複
					errMessage	=	"402";
				//else
					//系統發生錯誤, 請通知系統管理人員
					//errMessage	=	"403";
				if (errMessage.Equals("402"))
					response.Write("<script>try{alert(Message.getMessage('" + errMessage + "'));}catch(ex){alert('新增資料重複')}</script>");
				else
                    if (errMessage.ToUpper().IndexOf("ALERTERR") != -1)
                        response.Write("<script>try{alert('" + ex.Message.Replace("alertErr:", "") + "');}catch(ex){alert('系統發生錯誤, 請通知系統管理人員!!')}</script>");
                    else
                    {
                        errMessage = "403";
                        response.Write("<script>try{alert(Message.getMessage('" + errMessage + "'));}catch(ex){alert('系統發生錯誤, 請通知系統管理人員!!')}</script>");
                    }
            //}
            //else
            //{
            //    HttpResponse	response	=	FormUtil.Response;
            //    string		vr		=	FormUtil.Application["vr"].ToString();
            //    response.Clear();
            //    response.Write
            //    (
            //            "<html>\r\n" +
            //            "<head>\r\n" +
            //            "<META HTTP-EQUIV=\"Pragma\" CONTENT=\"No-cache\">\r\n" +
            //            "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">\r\n" +
            //            "<script src='" + vr + "script/jquery-1.8.3.min.js'></script>\r\n" +
            //            "<script src='" + vr + "script/Base.js'></script>\r\n" +
            //            "<script>\r\n" +
            //            "	var	_vp	=	'" + vr + "';\r\n" +
            //            "	doImport (\"Message.js, MessageContent.js, WindowUtil.js\");\r\n"
            //    );
            //    string		errMessage	=	ErrUtil.ErrToStr(ex).Replace(@"\", @"\\").Replace("'", @"\'").Replace("\r\n", @"\r\n").Replace("\n", @"\r\n");
            //    DbException	dbEx		=	ex as DbException;
				
            //    if (dbEx != null) 
            //    {
            //            MyLogger.Log(MyLogger.Info, "MyLogger.handlePageError", "dbMsg --> " + dbEx.Message, "", 0);
            //    }

            //    string	confirmMsg	=	"";
            //    if (errMessage.IndexOf("ORA-00001") != -1 || errMessage.IndexOf("違反 PRIMARY KEY 條件約束") != -1
            //        || errMessage.IndexOf("插入重複的索引鍵") != -1 || errMessage.ToLower().IndexOf("duplicate key row") != -1)
            //    {
            //            response.Clear();
            //        response.Write("<script>alert('新增資料重複!!');</script>");
            //    }
            //    else
            //    {
            //            confirmMsg	=	"004";
				
            //        response.Write
            //        (
            //            "	var	confirmMessage	=	\"" + confirmMsg + "\";\r\n" +
            //            "	if (Message.showConfirm (confirmMessage))\r\n" +
            //            "	{\r\n" +
            //            "		var	errStr	=	'<pre>" + errMessage + "</pre>' +\r\n" +
            //            "					'<hr size=1>' +\r\n" +
            //            "					'<center>' +\r\n" +
            //            "					'<input type=button value=\"C L O S E\" id=\"closeBtn\" onclick=\"top.close();\">' +\r\n" +
            //            "					'</center>';\r\n" +
            //            "		var	errWin	=	WindowUtil.openExceptionWindow(errStr, 900, 600);\r\n" +
            //            "		errWin.closeBtn.focus();\r\n" +
            //            "	}\r\n" +
            //            "</script>\r\n" +
            //            "</head>\r\n" +
            //            "</html>"
            //        );
            //    }
            //}
		}
	}
}
