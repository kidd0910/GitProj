using System;
using System.Collections.Generic;
using System.Text;

namespace Acer.Err
{
	/// <summary>
	/// 子報表設定檔不存在的自訂錯誤物件
	/// </summary>
	class SubReportConfigFileNotExistsException: Exception
	{
		public SubReportConfigFileNotExistsException():base()
		{
		}

		public SubReportConfigFileNotExistsException(string message):base(message) 
		{
		}
	}
}
