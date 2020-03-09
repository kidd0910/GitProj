using System;
using System.Collections.Generic;
using System.Text;

namespace Acer.Err
{
	/// <summary>
	/// 資料型態錯誤的自訂錯誤物件
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
