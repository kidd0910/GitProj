using System;
using System.Text;
using Acer.Util;
using Acer.File;

namespace Acer.Log
{
	/// <summary>
	/// �B�z���� Client �� Log ������
	/// </summary>
	public class ClientLog
	{
		private	static	string	backGroundColor	=	"C6D8F8";
		private	static	string	lastLogDate	=	DateUtil.GetNowCDate();
		private	static	Object	logLockObject	=	new Object();

		/// <summary>
		/// ���� Client ��T
		/// </summary>
		/// <param name="content">�n�O��������</param>
		public static void Log(string content) 
		{
			StringBuilder	logMessage	=	new StringBuilder();
			string		fileName	=	FileUtil.RootPath + @"log\WebClientLog.htm";
			
			ClientLog.backGroundColor	=	(ClientLog.backGroundColor.Equals("C6D8F8"))?"B6C893":"C6D8F8";

			logMessage.Append
			(
				"<div style='background-color:#" + ClientLog.backGroundColor + "'>" +
				DateUtil.ConvertCDate(DateUtil.GetNowCDate(), "yyyy-MM-dd") + " " + DateUtil.FormatTime(DateUtil.GetNowTime()) + " - " + Utility.GetIP() + " - " +
				content +
				"</div>" +
				"<hr color=red size=1>"
			);

			//=== ����ܧ�άO�j�� 100K ���� ===/
			if (!ClientLog.lastLogDate.Equals(DateUtil.GetNowCDate()) || ClientLog.GetFileSize(fileName) >= 102400)
			{
				string	fileName_	=	fileName.Replace(".htm", "") + "." + DateUtil.ConvertCDate(ClientLog.lastLogDate, "yyyy-MM-dd");

				ClientLog.lastLogDate	=	DateUtil.GetNowCDate();

				if (!FileUtil.FileExists(fileName_))
				{
					int	nameIndex	=	1;
					string	fileName_1	=	fileName_ + "." + Convert.ToString(nameIndex).PadLeft(3, '0') + ".htm";

					while(FileUtil.FileExists(fileName_1))
					{
						nameIndex++;
						fileName_1	=	fileName_.Replace(".htm", "") + "." + Convert.ToString(nameIndex).PadLeft(3, '0') + ".htm";
					}
					fileName_	=	fileName_1;
				}
				FileUtil.MoveFile(fileName, fileName_);
			}
	
			lock(logLockObject)
				FileUtil.AppendFile(fileName, logMessage.ToString(), System.Text.Encoding.UTF8);
		}

		private static long GetFileSize(string filePath) 
		{
			try
			{
				return FileUtil.GetFileSize(filePath);
			}
			catch(Exception)
			{
				return 0;
			}
		}
	}

	
}
