using Acer.Form;
using System.Web;
using System;
using Acer.Log;
using Acer.Util;
using Acer.Err;

namespace Acer.Ajax
{
	/// <summary>
	/// 處理記錄 Javascript 訊息的物件
	/// </summary>
	public class ErrorLog
	{
		/// <summary>
		/// 前端呼叫使用方法
		/// </summary>
		public static void DoCall()
		{
			HttpRequest	request		=	FormUtil.Request;
			HttpResponse	response	=	FormUtil.Response;

			//=== 無訊息不處理 === 
			if (request["MESSAGE"] == null)
				return;
			try
			{
				ClientLog.Log(request["MESSAGE"].ToString());
			}
			catch (Exception ex)
			{
				response.Write(ErrUtil.ErrToStr(ex).Replace("'", "\\'"));
			}
		}
	}
}
