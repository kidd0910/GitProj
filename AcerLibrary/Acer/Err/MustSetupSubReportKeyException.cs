using System;
using System.Collections.Generic;
using System.Text;

namespace Acer.Err
{
	/// <summary>
	/// �����w�q�l������Ȫ��ۭq���~����
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
