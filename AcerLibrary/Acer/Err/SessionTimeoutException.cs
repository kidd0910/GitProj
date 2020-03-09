using System;
using System.Collections.Generic;
using System.Text;

namespace Acer.Err
{
	/// <summary>
	/// Server ºÝÀË®Ö¿ù»~ªº¦Û­q¿ù»~ª«¥ó
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
