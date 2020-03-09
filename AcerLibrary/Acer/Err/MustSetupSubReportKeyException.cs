using System;
using System.Collections.Generic;
using System.Text;

namespace Acer.Err
{
	/// <summary>
	/// 必須定義子報表鍵值的自訂錯誤物件
	/// </summary>
	class MustSetupSubReportKeyException: Exception
	{
		public MustSetupSubReportKeyException():base()
		{
		}

		public MustSetupSubReportKeyException(string message):base(message) 
		{
		}
	}
}
