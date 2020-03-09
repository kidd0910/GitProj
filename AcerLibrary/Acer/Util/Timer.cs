using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.IO;
using System.Security.Cryptography;
using Acer.Apps;
using Acer.Util;
using System.Text.RegularExpressions;

namespace Acer.Util
{
	/// <summary>
	/// 處理一般的共用函式
	/// </summary>
	public class Timer
	{
		private	long	startTimer	=	0;
			
		/// <summary>
		/// 計時器
		/// </summary>
		public Timer()
		{
			startTimer	=	DateUtil.GetCurrTimeMillis();
		}

		/// <summary>
		/// 取得目前計時的經過時間 ms
		/// </summary>
		/// <returns>經過時間 ms</returns>
		public long GetDiffTime()
		{
			return DateUtil.GetCurrTimeMillis() - startTimer;
		}
	}
}
