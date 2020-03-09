using System;
using System.Collections.Generic;
using System.Text;

namespace Acer.Err
{
	/// <summary>
	/// 取得連線失敗的自訂錯誤物件
	/// </summary>
	class GetConnectionFaileException: Exception
	{
		public GetConnectionFaileException():base()
		{
		}

		public GetConnectionFaileException(string message):base(message) 
		{
		}
	}
}
