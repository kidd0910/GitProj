using System;
using System.Collections.Generic;
using System.Text;

namespace Acer.Err
{
	/// <summary>
	/// ��ƫ��A���~���ۭq���~����
	/// </summary>
	class DataTypeFaileException: Exception
	{
		public DataTypeFaileException():base()
		{
		}

		public DataTypeFaileException(string message):base(message) 
		{
		}
	}
}
