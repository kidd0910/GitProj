using System;
using System.Text;
using System.Collections;
using Acer.Util;
using Acer.File;
using Acer.Err;
using System.Configuration;

namespace Acer.Apps
{
	/// <summary>
	/// �B�z����]�w�� (env.conf) �����B�z�ʧ@
	/// </summary>
	public static class APConfig
	{
	#region �ݩ�
		
	#endregion
		private	static	object	lickObj	=	new object();
		
		/// <summary>
		/// �]�w�ɪ�l��
		/// </summary>
		public static void Init()
		{
			lock (lickObj)
			{
				//2011/02/11 nono for �F�d�վ�, ��L�]�w�ɮɤ��B�z
				if (!System.IO.File.Exists(FileUtil.LastSeparator(FileUtil.RootPath) + @"conf\env.conf"))
					return;

				Hashtable	dataMap	=	new Hashtable();
				Hashtable	propMap	=	new Hashtable();
				ArrayList	content =	FileUtil.ReadFile(FileUtil.LastSeparator(FileUtil.RootPath) + @"conf\env.conf", System.Text.Encoding.GetEncoding("BIG5"));
				string		tmpStr	=	"";
				string		tmpKey	=	"";
					
				for (int i = 0; i < content.Count; i++)
				{
					tmpStr	=	content[i].ToString();
					
					if (tmpStr.StartsWith("#") || tmpStr.IndexOf("=") == -1)
						continue;

					if (tmpStr.StartsWith("%"))
					{
						tmpKey	=	tmpStr.Substring(1, tmpStr.IndexOf("=") - 1);
						if (tmpStr.Substring(tmpStr.IndexOf("=") + 1).Equals("ROOT_PATH"))
						{
							if (FileUtil.RootPath.EndsWith(@"\"))
								propMap[tmpKey]	=	FileUtil.RootPath.Remove(FileUtil.RootPath.Length - 1, 1);
							else
								propMap[tmpKey]	=	FileUtil.RootPath;
						}
						else
							propMap[tmpKey]	=	tmpStr.Substring(tmpStr.IndexOf("=") + 1);
					}
					else
						dataMap[tmpStr.Substring(0, tmpStr.IndexOf("="))]	=	tmpStr.Substring(tmpStr.IndexOf("=") + 1);
				}
				MultiProcess.SetGlobalValue("APCONFIG_DATAMAP", dataMap);
				MultiProcess.SetGlobalValue("APCONFIG_PROPMAP", propMap);
			}
		}

		/// <summary>
		/// ���o WEB Root ��ڸ��| [REAL_PATH]
		/// </summary>
		public static string RealPath
		{
			get{return FileUtil.LastSeparator(GetProperty("REAL_PATH"));}
		}

		/// <summary>
		/// ���o�����ܼ�
		/// </summary>
		/// <param name="keyStr">�����o�������ܼƤ��e</param>
		/// <returns>�����ܼƤ��e</returns>
		public static string GetProperty(string keyStr)
		{
			//2011/02/11 nono add �N�]�w�ɩ����� Web.config ��
			//if (APConfig.GetProperty("DATA_PROJECT").Equals("�F�d�j�ǤG��") || APConfig.GetProperty("DATA_PROJECT").Equals("�F�d�j�Ǥ@��") || APConfig.GetProperty("DATA_PROJECT").Equals("KNUE4"))
			//if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["DATA_PROJECT"]))
			//2011/05/23 nono �վ�, ���]�w�ɮɳB�z
			if (!System.IO.File.Exists(FileUtil.LastSeparator(FileUtil.RootPath) + @"conf\env.conf"))
			{
				if (keyStr.Equals("pwdkey"))
					return "??qfw?'";

				string		value	=	Utility.DecryptTagContent(ConfigurationManager.AppSettings[keyStr].ToString());
				ArrayList	tagAry	=	Utility.GetTagList(value, "[", "]");

				if (tagAry.Count > 0)
				{
					foreach(string tag in tagAry)
					{
						if (tag.Equals("ROOT_PATH"))
						{
							if (FileUtil.RootPath.EndsWith(@"\"))
								value	=	value.Replace("[" + tag + "]", FileUtil.RootPath.Remove(FileUtil.RootPath.Length - 1, 1));
							else
								value	=	value.Replace("[" + tag + "]", FileUtil.RootPath);
						}
						else if (ConfigurationManager.AppSettings["%" + tag] != null)
						{
							value	=	value.Replace("[" + tag + "]", ConfigurationManager.AppSettings["%" + tag].ToString());
						}
					}
				}

				return value;
			}

			Hashtable	dataMap	=	(Hashtable)MultiProcess.GetGlobalValue("APCONFIG_DATAMAP");
			Hashtable	propMap	=	(Hashtable)MultiProcess.GetGlobalValue("APCONFIG_PROPMAP");

			//=== �A���������ܰT�� ===
			if (dataMap == null || dataMap[keyStr] == null)
			{
				throw new MustSetupEnvException("�����]�w�����ܼ� " + keyStr);
			}

			string	result	=	dataMap[keyStr].ToString();
			if (result.IndexOf("%") != -1)
			{
				//=== �m���ѼƳ]�w ===
				foreach (string key in propMap.Keys)
					result	=	result.Replace("%" + key + "%", propMap[key].ToString());
			}

			return result;
		}

        /// <summary>
        /// ���o�����ܼƭȡA�Y���]�w�h�ĥιw�]��
        /// </summary>
        /// <param name="keyStr"></param>
        /// <param name="default_value"></param>
        /// <returns></returns>
        public static string GetProperty(string keyStr, string default_value)
        {
            try
            {
                return GetProperty(keyStr);
            }
            catch (MustSetupEnvException)
            {
                return default_value;
            }
        }

		/// <summary>
		/// ���o�ѼƳ]�w�M��
		/// </summary>
		/// <returns>�ѼƳ]�w�M��r�� &lt;br&gt; ����</returns>
		public static string GetPropertyList()
		{
			Hashtable	dataMap	=	(Hashtable)MultiProcess.GetGlobalValue("APCONFIG_DATAMAP");
			Hashtable	propMap	=	(Hashtable)MultiProcess.GetGlobalValue("APCONFIG_PROPMAP");
			StringBuilder	tmpBuff	=	new StringBuilder();

			//=== �ܼ� ===
			tmpBuff.Append("<font color=blue>�ܼ�</font><br>");
			foreach (string key in propMap.Keys)
			{
				tmpBuff.Append("<font color=red>[" + key + "]:</font> " + propMap[key].ToString() + "<br>");
			}

			//=== �Ѽ� ===
			tmpBuff.Append("<br><font color=blue>�Ѽ�</font><br>");
			foreach (string key in dataMap.Keys)
			{
				tmpBuff.Append("<font color=red>[" + key + "]:</font> " + GetProperty(key) + "<br>");
			}

			return tmpBuff.ToString();
		}
	}
}
