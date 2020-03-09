using Acer.Form;
using System.Web;
using System;
using Acer.Log;
using Acer.Util;
using Acer.Err;

namespace Acer.Ajax
{
	/// <summary>
	/// �B�z�O�� Javascript �T��������
	/// </summary>
	public class ErrorLog
	{
		/// <summary>
		/// �e�ݩI�s�ϥΤ�k
		/// </summary>
		public static void DoCall()
		{
			HttpRequest	request		=	FormUtil.Request;
			HttpResponse	response	=	FormUtil.Response;

			//=== �L�T�����B�z === 
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
