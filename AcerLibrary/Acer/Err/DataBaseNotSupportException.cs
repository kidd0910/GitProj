using System;
using System.Collections.Generic;
using System.Text;

namespace Acer.Err
{
	/// <summary>
	/// ���䴩�Ӹ�Ʈw���ۭq���~����
	/// </summary>
	class DataBaseNotSupportException: Exception
	{
		public DataBaseNotSupportException():base()
		{
		}

		public DataBaseNotSupportException(string message):base(message) 
		{
		}
	}
}
