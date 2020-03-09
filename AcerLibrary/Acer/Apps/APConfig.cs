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
	/// 處理抓取設定檔 (env.conf) 相關處理動作
	/// </summary>
	public static class APConfig
	{
	#region 屬性
		
	#endregion
		private	static	object	lickObj	=	new object();
		
		/// <summary>
		/// 設定檔初始化
		/// </summary>
		public static void Init()
		{
			lock (lickObj)
			{
				//2011/02/11 nono for 東吳調整, 當無設定檔時不處理
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
		/// 取得 WEB Root 實際路徑 [REAL_PATH]
		/// </summary>
		public static string RealPath
		{
			get{return FileUtil.LastSeparator(GetProperty("REAL_PATH"));}
		}

		/// <summary>
		/// 取得環境變數
		/// </summary>
		/// <param name="keyStr">欲取得的環境變數內容</param>
		/// <returns>環境變數內容</returns>
		public static string GetProperty(string keyStr)
		{
			//2011/02/11 nono add 將設定檔抽離至 Web.config 中
			//if (APConfig.GetProperty("DATA_PROJECT").Equals("東吳大學二期") || APConfig.GetProperty("DATA_PROJECT").Equals("東吳大學一期") || APConfig.GetProperty("DATA_PROJECT").Equals("KNUE4"))
			//if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["DATA_PROJECT"]))
			//2011/05/23 nono 調整, 當有設定檔時處理
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

			//=== 再取不到時顯示訊息 ===
			if (dataMap == null || dataMap[keyStr] == null)
			{
				throw new MustSetupEnvException("必須設定環境變數 " + keyStr);
			}

			string	result	=	dataMap[keyStr].ToString();
			if (result.IndexOf("%") != -1)
			{
				//=== 置換參數設定 ===
				foreach (string key in propMap.Keys)
					result	=	result.Replace("%" + key + "%", propMap[key].ToString());
			}

			return result;
		}

        /// <summary>
        /// 取得環境變數值，若未設定則採用預設值
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
		/// 取得參數設定清單
		/// </summary>
		/// <returns>參數設定清單字串 &lt;br&gt; 換行</returns>
		public static string GetPropertyList()
		{
			Hashtable	dataMap	=	(Hashtable)MultiProcess.GetGlobalValue("APCONFIG_DATAMAP");
			Hashtable	propMap	=	(Hashtable)MultiProcess.GetGlobalValue("APCONFIG_PROPMAP");
			StringBuilder	tmpBuff	=	new StringBuilder();

			//=== 變數 ===
			tmpBuff.Append("<font color=blue>變數</font><br>");
			foreach (string key in propMap.Keys)
			{
				tmpBuff.Append("<font color=red>[" + key + "]:</font> " + propMap[key].ToString() + "<br>");
			}

			//=== 參數 ===
			tmpBuff.Append("<br><font color=blue>參數</font><br>");
			foreach (string key in dataMap.Keys)
			{
				tmpBuff.Append("<font color=red>[" + key + "]:</font> " + GetProperty(key) + "<br>");
			}

			return tmpBuff.ToString();
		}
	}
}
