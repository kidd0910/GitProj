using System;
using System.Collections.Generic;
using System.Text;

namespace Acer.Err
{
	/// <summary>
	/// ���o�s�u���Ѫ��ۭq���~����
	/// </summary>
	class GetConnectionFaileException: Exception
	{
		public GetConnectionFaileException():base()
		{
		}

		public GetConnectionFaileException(string message):base(message) 
		{
		}
	}
}
