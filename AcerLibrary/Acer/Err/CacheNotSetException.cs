using System;
using System.Collections.Generic;
using System.Text;

namespace Acer.Err
{
	/// <summary>
	/// ���o�s�u���Ѫ��ۭq���~����
	/// </summary>
	class CacheNotSetException: Exception
	{
		public CacheNotSetException():base()
		{
		}

		public CacheNotSetException(string message):base(message) 
		{
		}
	}
}
