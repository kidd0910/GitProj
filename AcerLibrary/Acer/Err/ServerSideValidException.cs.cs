using System;
using System.Collections.Generic;
using System.Text;

namespace Acer.Err
{
	/// <summary>
	/// Server ���ˮֿ��~���ۭq���~����
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
