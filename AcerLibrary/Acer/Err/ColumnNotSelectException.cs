using System;
using System.Collections.Generic;
using System.Text;

namespace Acer.Err
{
	/// <summary>
	/// �������쪺�ۭq���~����
	/// </summary>
	class ColumnNotSelectException: Exception
	{
		public ColumnNotSelectException():base()
		{
		}

		public ColumnNotSelectException(string message):base(message) 
		{
		}
	}
}
