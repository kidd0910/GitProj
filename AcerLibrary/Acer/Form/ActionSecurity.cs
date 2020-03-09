using System;
using System.IO;
using System.Security.Cryptography;
using Acer.Form;
using Acer.DB;
using Acer.Util;
using Acer.Apps;
using System.Web.SessionState;

namespace Acer.Form
{
	/// <summary>
	/// 定義動作權限的物件
	/// </summary>
	sealed class ActionSecurity
	{
		#region 判斷是否有功能權限
		/// <summary>
		/// 判斷是否有功能權限
		/// </summary>
		/// <param name="funtionCode">功能代碼</param>
		/// <returns>是否有功能權限</returns>
		public static bool HasFunctionPermission(string funtionCode)
		{
			if (FormUtil.Session["FUNC_PERMISSION"] == null)
				return true;

			if (("," + FormUtil.Session["FUNC_PERMISSION"].ToString() + ",").IndexOf("," + funtionCode + ",") != -1)
				return true;
			else
				return false;
		}
		#endregion

		/// <summary>
		/// 按鈕權限檢核
		/// </summary>
		/// <param name="securityType">權限種類 ADD/MOD/DEL/QRY/PRT Or 12345678</param>
		/// <returns>是否有權限</returns>
		public static bool SecurityCheck(string securityType)
		{
			HttpSessionState	Session		=       FormUtil.Session;
			string			FUNC_PRVLG	=	(string)Session["FUNC_PRVLG"];
	                
			if (securityType.Equals("QRY") || securityType.Equals("MOD"))
				return true;

			//=== 當為空白表有全部權限 ===
			if (string.IsNullOrEmpty(FUNC_PRVLG))
				return true;
			
			//=== 使用對照表檢查 ===
			switch (securityType)
			{
				case "ADD":
					securityType	=	"1";
					break;
				case "MOD":
					securityType	=	"2";
					break;
				case "DEL":
					securityType	=	"3";
					break;
				case "QRY":
					securityType	=	"4";
					break;
				case "PRT":
					securityType	=	"5";
					break;
			}

			//=== 長度不為一使用對照表檢查 ===
			if (FUNC_PRVLG.Substring(Convert.ToInt16(securityType) - 1, 1).Equals("1"))
				return true;
			else
				return false;
		}
	}
}