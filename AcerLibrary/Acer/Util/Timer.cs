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
	/// �B�z�@�몺�@�Ψ禡
	/// </summary>
	public class Timer
	{
		private	long	startTimer	=	0;
			
		/// <summary>
		/// �p�ɾ�
		/// </summary>
		public Timer()
		{
			startTimer	=	DateUtil.GetCurrTimeMillis();
		}

		/// <summary>
		/// ���o�ثe�p�ɪ��g�L�ɶ� ms
		/// </summary>
		/// <returns>�g�L�ɶ� ms</returns>
		public long GetDiffTime()
		{
			return DateUtil.GetCurrTimeMillis() - startTimer;
		}
	}
}
