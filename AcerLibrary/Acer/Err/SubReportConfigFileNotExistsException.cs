using System;
using System.Collections.Generic;
using System.Text;

namespace Acer.Err
{
	/// <summary>
	/// �l����]�w�ɤ��s�b���ۭq���~����
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
