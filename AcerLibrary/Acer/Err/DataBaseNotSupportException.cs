using System;
using System.Collections.Generic;
using System.Text;

namespace Acer.Err
{
	/// <summary>
	/// 不支援該資料庫的自訂錯誤物件
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
