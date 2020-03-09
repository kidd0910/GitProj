using System;
using System.Collections.Generic;
using System.Text;

namespace Acer.Err
{
	/// <summary>
	/// 未選擇欄位的自訂錯誤物件
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
