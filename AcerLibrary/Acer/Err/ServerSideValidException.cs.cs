using System;
using System.Collections.Generic;
using System.Text;

namespace Acer.Err
{
	/// <summary>
	/// Server ºÝÀË®Ö¿ù»~ªº¦Û­q¿ù»~ª«¥ó
	/// </summary>
	class ServerSideValidException: Exception
	{
		public ServerSideValidException():base()
		{
		}

		public ServerSideValidException(string message):base(message) 
		{
		}
	}
}
