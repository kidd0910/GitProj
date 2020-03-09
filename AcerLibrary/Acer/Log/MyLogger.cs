using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Acer.Util;
using Acer.Err;
using System.Web;
using Acer.Form;
using System.Xml;
using Acer.File;
using System.Data.Common;
using Acer.DB;
using Acer.Apps;
using System.Net;
using System.Messaging;

namespace Acer.Log
{
	/// <summary>
	/// 處理 Log 的共用函式
	/// </summary>
	public class MyLogger
	{
#region 變數宣告
		private	static	string		lastLogDate	=	MyLogger.GetSysDate();
		/// <summary>
		/// 記錄目前排隊處理的 Logger 物件, 非同步處理時使用
		/// </summary>
		private	static	ArrayList	currLogger	=	new ArrayList();

		/// <summary>
		/// 紀錄 Log 的序號, DB 切割資料串接使用
		/// </summary>
		private	static	int	threadId;
		private	static	bool	isBatch		=	false;
		
		private	string		name		=	"";
		private	string		userInfo	=	"";
		private StringBuilder	message		=	new StringBuilder();
		private	string		tmpStr		=	"";
		/// <summary>Session ID</summary>
		public	string		sessionId	=	"";
		/// <summary>總共執行時間</summary>
		public	long		execTime	=	0;
		/// <summary>Log 等級</summary>
		public	int		logLevel=	0;
		/// <summary>記錄 IO Log 的檔案名稱</summary>
		public	String		logIOName	=	"";	
#endregion

#region 屬性
		private	Hashtable	pPropertyMap	=	new Hashtable();

		#region MULTI_LANGUAGE 取得 MULTI_LANGUAGE
		/// <summary>取得 MULTI_LANGUAGE</summary>
		public Hashtable MULTI_LANGUAGE
		{
			get
			{
				if (this.pPropertyMap["MULTI_LANGUAGE"] == null)
                    this.pPropertyMap["MULTI_LANGUAGE"] = (Hashtable)MultiProcess.GetCrossSiteValue("MULTI_LANGUAGE");
				return (Hashtable)this.pPropertyMap["MULTI_LANGUAGE"];
			}
		}
		#endregion

		/// <summary>Log 等級 Info</summary>
		public static int Info
		{
			get {return 0;}
		}

		/// <summary>Log 等級 Debug</summary>
		public static int Debug
		{
			get {return 1;}
		}

		/// <summary>Log 等級 Warn</summary>
		public static int Warn
		{
			get {return 2;}
		}

		/// <summary>Log 等級 Fatal</summary>
		public static int Fatal
		{
			get {return 3;}
		}

		/// <summary>Log 等級 Error</summary>
		public static int Error
		{
			get {return 4;}
		}

		#region IsLog 判斷是否紀錄 Log
		private	bool	isLog	=	true;
		/// <summary>判斷是否紀錄 Log</summary>
		public bool IsLog
		{
			get{return isLog;}
			set{isLog	=	value;}
		}
		#endregion

		/// <summary>判斷是否批次程式</summary>
		public bool IsBatch
		{
			get{return isBatch;}
			set{isBatch	=	value;}
		}
#endregion
		/// <summary>
		/// 建構子, 初始化 log, 以程式名稱
		/// </summary>
		/// <param name="name">程式名稱</param>
		/// 
		public MyLogger(string name)
		{
			this.name	=	name;
		}
		
		/// <summary>
		/// 初使化紀錄使用者資訊
		/// </summary>
		/// <param name="userInfo">使用者資訊</param>
		public void IniUserInfo(string userInfo)
		{
			this.userInfo	=	userInfo;

			//=== 2008/11/24 nono 增加將 Memory 也記一份到 IO, 執行完畢後砍掉該檔, 以判斷哪些程式未執行完畢 ===//
			//try
			//{
			//        this.logIOName	=	APConfig.RealPath + "\\Temp\\LogIO_" + FormUtil.Request.FilePath.Replace("/", "_") + "_" + FormUtil.Session.SessionID + "_" + DateTime.Now.ToString("HHmmss") + "_" + DateTime.Now.Millisecond;
			//        FileUtil.AppendFile(this.logIOName, this.name + " " + userInfo, Encoding.UTF8);
			//}
			//catch(System.Exception)
			//{
			//}
		}

		/// <summary>
		/// 紀錄  Log 訊息累加	
		/// </summary>
		/// <param name="inputMessage">紀錄的資訊</param>
		public void Append(string inputMessage)
		{
			message.Append("\r\n" + inputMessage);
	                
			if (message.Length > 32000)
			{
				long	logLength	=	Convert.ToInt64(Utility.CheckNull(APConfig.GetProperty("MEMORY_LOG_LENGTH"), "100000"));
				if (tmpStr.Length > logLength)
					tmpStr	=	message.ToString();
				else
					tmpStr	+=	message.ToString();
				message	=	null;
				message	=	new StringBuilder();
			}

			//=== 2008/11/24 nono 增加將 Memory 也記一份到 IO, 執行完畢後砍掉該檔, 以判斷哪些程式未執行完畢 ===//
			//try
			//{
			//        FileUtil.AppendFile(this.logIOName, inputMessage, Encoding.UTF8);
			//}
			//catch(Exception)
			//{
			//}
		}

		/// <summary>
		/// 紀錄  Log 訊息累加	
		/// </summary>
		/// <param name="message">紀錄的資訊</param>
		public void Append(int message)
		{
			Append(Convert.ToString(message));
		}

		/// <summary>
		/// 紀錄  Log 訊息累加	
		/// </summary>
		/// <param name="message">紀錄的資訊</param>
		public void Append(double message)
		{
			Append(Convert.ToString(message));
		}

		/// <summary>
		/// 紀錄  Log 訊息累加	
		/// </summary>
		/// <param name="message">紀錄的資訊</param>
		public void Append(char message)
		{
			Append(message.ToString());
		}
		
		/// <summary>
		/// 設定要 Log 的等級
		/// </summary>
		/// <param name="logLevel">Log 的等級</param>
		public void SetLogLevel(int logLevel)
		{
			this.logLevel	=	logLevel;
		}
		 
		/// <summary>
		/// 取得 Log 訊息, Log 記錄使用
		/// </summary>
		/// <returns></returns>
		public string GetMessage()
		{
			string	result	=	"";
			result	=	tmpStr + message.ToString();
			
			tmpStr	=	"";
			message = null;
			message	=	new StringBuilder();
			
			return result;
		}

		/// <summary>
		/// 將目前 Memory 的紀錄內容 Log 起來, 並清掉 Cache Memory
		/// </summary>
		/// <param name="logger"></param>
		public static void Flush(MyLogger logger)
		{
			MyLogger.Log(logger.logLevel, logger.name, logger.GetMessage(), logger.sessionId, logger.execTime);
		}
		
		/// <summary>
		/// 開始進行 Log 動作
		/// </summary>
		/// <param name="logger">MyLogger 物件</param>
		public static void Log(MyLogger logger) 
		{
			MyLogger.Log(logger.logLevel, logger.name, logger.userInfo, logger.GetMessage(), logger.sessionId, logger.execTime, logger.IsBatch);

			//=== 2008/11/24 nono 增加將 Memory 也記一份到 IO, 執行完畢後砍掉該檔, 以判斷哪些程式未執行完畢 ===//
			//try
			//{
			//        System.IO.File.Delete(logger.logIOName);
			//}
			//catch(System.Exception)
			//{
			//}
		}

		/// <summary>
		/// 直接呼叫 log 訊息(Debug)
		/// </summary>
		/// <param name="logLevel">Log 等級</param>
		/// <param name="logName">Log 標題</param>
		/// <param name="userInfo">使用者資訊</param>
		/// <param name="logMessage">要 Log 的內容</param>
		/// <param name="sessionId">SessionId</param>
		/// <param name="execTime">執行時間</param>
		/// <param name="isBatch">是否批次處理</param>
		public static void Log(int logLevel, string logName, string userInfo, string logMessage, string sessionId, long execTime, bool isBatch) 
		{	
			MyLogger	logger	=	new MyLogger("tmp");
			logger.logLevel		=	logLevel;
			logger.name		=	logName;
			logger.userInfo		=	userInfo;
			logger.sessionId	=	sessionId;
			logger.execTime		=	execTime;
			logger.message		=	new StringBuilder().Append(logMessage);
			
			MyLogger.currLogger.Add(logger);

			//2011/06/10 nono add 增加 MSMQ 記錄模式
			string	logProcotol	=	"CLIENT";
			try {logProcotol	=	APConfig.GetProperty("LOG_PROTOCAL");}catch(Exception){}
			if (logProcotol.Equals("MSMQ"))
			{
				//=== 同步呼叫處理 ===
				MyLogger.StartThreadLog ();
			}
			else
			{
				try
				{
					//=== nono add 2010/02/24 非批次才判斷是否有設定 ===
					if (!isBatch)
					{
						APConfig.GetProperty("LOG_TRACE");
					}
					//=== 同步呼叫處理 ===
					MyLogger.StartThreadLog ();
				}
				catch(System.Exception)
				{
					//=== 非同步呼叫處理 ===
					new System.Threading.ThreadStart(MyLogger.StartThreadLog).BeginInvoke(new System.AsyncCallback(MyLogger.EndThreadLog), null);
				}
			}
		}

		/// <summary>
		/// 直接呼叫 log 訊息(Debug)
		/// </summary>
		/// <param name="logLevel">Log 等級</param>
		/// <param name="logName">Log 標題</param>
		/// <param name="logMessage">要 Log 的內容</param>
		public static void Log(int logLevel, string logName, string logMessage)
		{	
			Log(logLevel, logName, "", logMessage, "", 0, false);
		}

		/// <summary>
		/// 直接呼叫 log 訊息(Debug)
		/// </summary>
		/// <param name="logLevel">Log 等級</param>
		/// <param name="logName">Log 標題</param>
		/// <param name="logMessage">要 Log 的內容</param>
		/// <param name="sessionId">SessionId</param>
		/// <param name="execTime">執行時間</param>
		public static void Log(int logLevel, string logName, string logMessage, string sessionId, long execTime)
		{	
			Log(logLevel, logName, "", logMessage, sessionId, execTime, false);
		}

		/// <summary>
		/// Log 非同步處理結束時呼叫
		/// </summary>
		/// <param name="ar"></param>
		public static void EndThreadLog(System.IAsyncResult ar)
		{
			
		} 

		private	static	Object threadLogObject	=	new Object();

		private static string GetLogStr(int logLevel)
		{
			string strLevel = "";

			switch (logLevel)
			{
				case 0:
					strLevel	=	"info";
					break;
				case 1:
					strLevel	=	"debug";
					break;
				case 2:
					strLevel	=	"warn";
					break;
				case 3:
					strLevel	=	"fatal";
					break;
				case 4:
					strLevel	=	"error";
					break;
				default:
					strLevel	=	"info";
					break;
			}

			return strLevel;
		}

		/// <summary>
		/// Log 非同步處理起始時呼叫
		/// </summary>
		public static void StartThreadLog() 
		{
			//2011/06/10 nono add 增加 MSMQ 記錄模式
			string	logProcotol	=	"CLIENT";
			try {logProcotol	=	APConfig.GetProperty("LOG_PROTOCAL");}catch(Exception){}
			if (logProcotol.Equals("MSMQ"))
			{
				if (MyLogger.currLogger.Count == 0)
					return;
				MyLogger	logger	=	(MyLogger)MyLogger.currLogger[0];
				MyLogger.currLogger.RemoveAt(0);
				
				LogStruct	log	=	new LogStruct();
				log.LogLevel	=	GetLogStr(logger.logLevel);
				log.UserInfo	=	logger.userInfo;
				log.LogName	=	logger.name;
				log.LogMessage	=	logger.message.ToString();
				log.LogDate	=	DateTime.Now.ToString("yyyy/MM/dd");
				log.LogTime	=	DateTime.Now.ToString("HH:mm:ss");
				log.ClientIP	=	Utility.GetIP();
				log.ServerIP	=	GetIPAddress().ToString().Replace(" ", "+");
                if (System.Web.HttpContext.Current != null)
                    log.SessionId = System.Web.HttpContext.Current.Session.SessionID;

				string		msmqURL	=	APConfig.GetProperty("MSMQ_URI");
				MessageQueue	mq	=	new MessageQueue(msmqURL);
				mq.Send(log);
			}
			else
			{
				lock(threadLogObject)
				{
					try
					{
						if (MyLogger.currLogger.Count == 0)
							return;
						MyLogger	logger	=	(MyLogger)MyLogger.currLogger[0];
						MyLogger.currLogger.RemoveAt(0);
						int	logLevel	=	logger.logLevel;
						string	userInfo	=	logger.userInfo;
						string	logName		=	logger.name;
						string	logMessage	=	logger.message.ToString();
						
						//=== 判斷要紀錄的等級 ===
						if (Convert.ToInt32(APConfig.GetProperty("LOG_LEVEL")) > logLevel)
							return;

						string	strLevel	=	GetLogStr(logLevel);

						//=== 2009/12/18 nono add 將 Log 成功及失敗訊息切割開 ===
						if (logLevel == 0)
						{
							if (APConfig.GetProperty("INFO_LOG_FORMAT").IndexOf("HTML") != -1)
								MyLogger.LogHTML(strLevel, logName, userInfo, logMessage);
							if (APConfig.GetProperty("INFO_LOG_FORMAT").IndexOf("XML") != -1)
								MyLogger.LogXML(strLevel, logName, userInfo, logMessage);
							if (APConfig.GetProperty("INFO_LOG_FORMAT").IndexOf("DB") != -1)
								MyLogger.LogDB(strLevel, logName, userInfo, logMessage);
						}
						else
						{
							if (APConfig.GetProperty("LOG_FORMAT").IndexOf("HTML") != -1)
								MyLogger.LogHTML(strLevel, logName, userInfo, logMessage);
							if (APConfig.GetProperty("LOG_FORMAT").IndexOf("XML") != -1)
								MyLogger.LogXML(strLevel, logName, userInfo, logMessage);
							if (APConfig.GetProperty("LOG_FORMAT").IndexOf("DB") != -1)
								MyLogger.LogDB(strLevel, logName, userInfo, logMessage);
						}
						//=== nono 2009/12/21 nono add 寫入一個 FileList 方便用 LogParser 查索引 ===
						string	fileName	=	FileUtil.RootPath + @"log\WebServerLog_" + System.DateTime.Now.ToString("yyyyMMdd") + ".csv";
						string	content		=	"";
						if (!System.IO.File.Exists(fileName))
						{
							content	=	"date,time,logtype,page,ip,user,sessionid,executetime";
							FileUtil.AppendFile(fileName, content, System.Text.Encoding.UTF8);
						}
						content	=	System.DateTime.Now.ToString("yyyy/MM/dd") + "," + 
								System.DateTime.Now.ToString("HH:mm:ss") + "," +
								strLevel + "," +
								logName.ToString().Replace(" ", "+") + "," +
								GetIPAddress().ToString().Replace(" ", "+") + "," +
								userInfo.ToString().Replace(" ", "+") + "," +
								logger.sessionId.ToString().Replace(" ", "+") + "," +
								Convert.ToString(logger.execTime, 10);
	 
						FileUtil.AppendFile(fileName, content, System.Text.Encoding.UTF8);
					}
					catch(Exception ex)
					{
						try{ClientLog.Log(ErrUtil.ErrToStr(ex));}catch(System.Exception){}
					}
				}
			}
		}

		/// <summary>
		/// 紀錄 Log 到資料庫
		/// </summary>
		/// <param name="strLevel">Log 等級</param>
		/// <param name="logName">Log 標題</param>
		/// <param name="userInfo">使用者資訊</param>
		/// <param name="logMessage">要 Log 的內容</param>
		private static void LogDB(string strLevel, string logName, string userInfo, string logMessage)
		{
			MyLogger	logger		=	new MyLogger("");
			LogUtil		logUtil		=	new LogUtil("");
			DBManager	dbManager	=	new DBManager(logUtil);
			string		sql	=	"";
	
			try
			{
				DbConnection	conn	=	dbManager.GetIConnection(APConfig.GetProperty("LOG_DATASOURCE").ToString(), "LOG_TRANSACTION");
				DBAccess	dba	=	dbManager.GetDBAccess(conn);

				int		logLen	=	Utility.DBStr(logMessage).Length;
				string		message	=	Utility.DBStr(logMessage);
				string		new_msg	=	"";
				int		runCount=	logLen % 2000 == 0 ? logLen / 2000 : (logLen - (logLen % 2000)) / 2000 + 1;
				string		threadId=	MyLogger.GetThreadId();
				
				for (int i = 0; i < runCount; i++)
				{
					if (logLen > (i + 1) * 2000)
						new_msg	=	message.Substring(i * 2000, 2000);
					else
						new_msg	=	message.Substring(i * 2000);

					dba.SetTableName("LOGMESSSAGE");
					dba.SetColumn("LOGLEVEL",	strLevel);
					dba.SetColumn("LOGNAME",	System.DateTime.Now.ToString(":ss") + " " + logName + GetIPAddress());
					dba.SetColumn("USERINFO",	userInfo);
					dba.SetColumn("LOGMESSAGE",	"N'" + Utility.DBStr(new_msg.ToString().Replace("''", "'")) + "'", true);
					dba.SetColumn("SERIALNO",	i);
					dba.SetColumn("THREADNO",	threadId);
					dba.SetColumn("LOGDATE",	DateUtil.GetNowDate());
                    dba.SetColumn("LOGTIME",    System.DateTime.Now.ToString("HH:mm:ss"));
					sql	=	dba.GetSql();
					dba.IsNeedCheckCache	=	false;
					dba.Insert();
				}
				dbManager.Commit("LOG_TRANSACTION");
			}
			catch (Exception ex)
			{
System.IO.File.AppendAllText(FileUtil.LastSeparator(APConfig.RealPath) + @"log\DBLogErr_" + System.DateTime.Now.ToString("yyyyMMdd") + ".txt", MyLogger.GetPageName() + 
				"\r\nsql:\r\n" + sql + 
				"\r\n" + ex.Message + 
				"\r\n" + ex.StackTrace + 
				"\r\n", Encoding.UTF8);
				dbManager.Rollback("LOG_TRANSACTION");
				throw;
			}
			finally
			{
				dbManager.Close();
			}
		}

		private static string GetIPAddress()
		{
			 //取得本機名稱
			String		strHostName	=	Dns.GetHostName(); 

			//取得本機的 IpHostEntry 類別實體
            IPHostEntry iphostentry = Dns.GetHostEntry(strHostName);

        	StringBuilder	buff		=	new StringBuilder();
			int		num		=	1;

			foreach (IPAddress ipaddress in iphostentry.AddressList)
			{
				buff.Append(" IP #" + num + ": " + ipaddress.ToString());
				num = num + 1;
			}
			return buff.ToString();
		}

		private static String GetPageName()
		{
			try
			{
				return "--" + System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + " " +
						FormUtil.Session["empno"].ToString() + " " + FormUtil.Session["empname"].ToString() + " " +
						FormUtil.Request.ServerVariables["LOCAL_ADDR"].ToString() + " " + 
						FormUtil.Request.FilePath;
			}
			catch(Exception)
			{
				return System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
			}
		}

		/// <summary>
		/// 紀錄 Log 到 HTML 檔案
		/// </summary>
		/// <param name="strLevel">Log 等級</param>
		/// <param name="logName">Log 標題</param>
		/// <param name="userInfo">使用者資訊</param>
		/// <param name="logMessage">要 Log 的內容</param>
		private static void LogHTML(string strLevel, string logName, string userInfo, string logMessage)
		{
			int	rem	=	System.Convert.ToInt32(System.Environment.WorkingSet) / 1024;
			string	memUse	=	Convert.ToString(rem / 1024) + "." + Convert.ToString(rem % 1024) + " M";
			if (string.IsNullOrEmpty(userInfo))
				userInfo	=	Utility.GetIP();

			logMessage = "<font color=AE0000>[" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] [" + strLevel + "]<font color=blue>[" + logName + "][" + userInfo + "]</font></font>" + memUse + "\r\n<div class='hiders' style='display: block'><pre style='background-color:#DAE3E7;font-family:Courier New'>" + logMessage + "</pre><hr style='color:blue;height:1px;'></div><br/>\r\n";

			string	fileName	=	FileUtil.RootPath + @"log\WebServerLog.htm";
			
			//=== 日期變更大於 10M 分檔 ===
			if (!MyLogger.lastLogDate.Equals(DateUtil.GetNowCDate()) || FileUtil.GetFileSize(fileName) >= 2097152)
			{
				//string	fileName_	=	Utility.Replace(fileName, ".htm", "") + "." + DateUtil.ConvertCDate(MyLogger.lastLogDate, "yyyy-MM-dd") + ".htm";
				string	fileName_	=	fileName.Replace(".htm", "") + "." + DateUtil.ConvertCDate(MyLogger.lastLogDate, "yyyy-MM-dd") + ".htm";
				int	index		=	0;
				while (FileUtil.FileExists(fileName_))
				{
					index++;
					//fileName_	=	Utility.Replace(fileName, ".htm", "") + "." + DateUtil.ConvertCDate(MyLogger.lastLogDate, "yyyy-MM-dd") + "-" + index.ToString().PadLeft(2, '0') + ".htm";
					fileName_	=	fileName.Replace(".htm", "") + "." + DateUtil.ConvertCDate(MyLogger.lastLogDate, "yyyy-MM-dd") + "-" + index.ToString().PadLeft(2, '0') + ".htm";
				}
				FileUtil.MoveFile(fileName, fileName_);

				MyLogger.lastLogDate	=	DateUtil.GetNowCDate();
				
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

            FileUtil.AppendFile(fileName, logMessage, System.Text.Encoding.UTF8);
		}

		/// <summary>
		/// 紀錄 Log 到 XML 檔案
		/// </summary>
		/// <param name="strLevel">Log 等級</param>
		/// <param name="logName">Log 標題</param>
		/// <param name="userInfo">使用者資訊</param>
		/// <param name="logMessage">要 Log 的內容</param>
		private static void LogXML(string strLevel, string logName, string userInfo, string logMessage)
		{
			Hashtable	xmlMap	=	new Hashtable();
			
			if (string.IsNullOrEmpty(userInfo))
				userInfo	=	Utility.GetIP();

			xmlMap.Add("logtime",	System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss tt"));
			xmlMap.Add("loglevel",	strLevel);
			xmlMap.Add("caller",	logName);
			xmlMap.Add("userinfo",	userInfo);
			xmlMap.Add("content",	logMessage);

			string	fileName	=	FileUtil.RootPath + @"log\WebServerLog.xml";
			
			//=== 日期變更 ===
			if (!MyLogger.lastLogDate.Equals(DateUtil.GetNowCDate()))
			{
				MyLogger.lastLogDate	=	DateUtil.GetNowCDate();
				string	fileName_	=	fileName.Replace(".htm", "") + "." + DateUtil.ConvertCDate(MyLogger.lastLogDate, "yyyy-MM-dd");
				FileUtil.MoveFile(fileName, fileName_);
			}

			AppendXMLMessage(fileName, xmlMap);
		}

		private	static	Object AppendXMLMessageObject	=	new Object();

		/// <summary>
		/// 累計 XML 檔案資料
		/// </summary>
		/// <param name="filePath">檔案路徑</param>
		/// <param name="map">對應資料</param>
		private static void AppendXMLMessage(string filePath, Hashtable map)
		{
			lock(AppendXMLMessageObject)
			{
				if (!FileUtil.FileExists(filePath))
				{
					ArrayList	al	=	new ArrayList();
					al.Add("<?xml version=\"1.0\" encoding=\"Utf8\"?>");
					al.Add("<?xml-stylesheet type=\"text/xsl\" href=\"WebServerLog.xsl\"?>");
					al.Add("<message>");
					al.Add("</message>");
					FileUtil.WriteFile(filePath, al, System.Text.Encoding.UTF8);
				}

				XmlDocument	xmlDoc		=	new XmlDocument();
				xmlDoc.Load(filePath);
				XmlElement	root		=	xmlDoc.DocumentElement;
				XmlElement	listElem	=	xmlDoc.CreateElement("list");

				IDictionaryEnumerator	mapValues	=	map.GetEnumerator();
				string			tmpKey		=	"";
				string			tmpValue	=	"";

				while (mapValues.MoveNext())
				{
					tmpKey		=	mapValues.Key.ToString();
					tmpValue	=	mapValues.Value.ToString();
					XmlElement	childElem	=	xmlDoc.CreateElement(tmpKey);
					childElem.InnerText	=	tmpValue;
					listElem.AppendChild(childElem);
				}

				root.AppendChild(listElem);

				xmlDoc.Save(filePath);
			}
		}

		/// <summary>
		/// 取得系統日期
		/// </summary>
		/// <returns>系統日期</returns>
		private	static string GetSysDate()
		{
			return DateUtil.GetNowCDate();
		}

		private	static	Object getThreadIDObject	=	new Object();

		/// <summary>
		/// 取的唯一執行 ID
		/// </summary>
		/// <returns>唯一執行 ID</returns>
		public static string GetThreadId()
		{
			lock(getThreadIDObject)
			{
				MyLogger.threadId++;
				return DateUtil.GetCurrTimeMillis() + "_" + MyLogger.threadId;
			}
		}
	}
}
