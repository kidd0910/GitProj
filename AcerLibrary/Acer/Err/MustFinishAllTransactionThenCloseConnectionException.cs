using System;
using System.Collections.Generic;
using System.Text;

namespace Acer.Err
{
	/// <summary>
	/// 必須完成所有交易才能關閉連線自訂錯誤物件
	/// </summary>
	class MustFinishAllTransactionThenCloseConnectionException: Exception
	{
		public MustFinishAllTransactionThenCloseConnectionException():base()
		{
		}

		public MustFinishAllTransactionThenCloseConnectionException(string message):base(message) 
		{
		}
	}
}
