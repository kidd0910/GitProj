using System;
using System.Collections.Generic;
using System.Text;

namespace Acer.Err
{
	/// <summary>
	/// ���������Ҧ�����~�������s�u�ۭq���~����
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
