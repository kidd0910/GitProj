using System;
using System.Collections.Generic;
using System.Text;

namespace Acer.Err
{
	/// <summary>
	/// Server ���ˮֿ��~���ۭq���~����
	/// </summary>
	public class SessionTimeoutException: Exception
	{
		public SessionTimeoutException():base()
		{
		}

		public SessionTimeoutException(string message):base(message) 
		{
		}
	}
}
