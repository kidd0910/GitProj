using System;
using System.Collections.Generic;
using System.Text;

namespace Acer.Err
{
	/// <summary>
	/// 子報表鍵值跟參數數量必須一致的自訂錯誤物件
	/// </summary>
	class MustBeSameNumberOfSubReportKeyAndArgumentsException: Exception
	{
		public MustBeSameNumberOfSubReportKeyAndArgumentsException():base()
		{
		}

		public MustBeSameNumberOfSubReportKeyAndArgumentsException(string message):base(message) 
		{
		}
	}
}
