using System;
using System.Collections.Generic;
using System.Text;

namespace Acer.Err
{
	/// <summary>
	/// �l������ȸ�ѼƼƶq�����@�P���ۭq���~����
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
