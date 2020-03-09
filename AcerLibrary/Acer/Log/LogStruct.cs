
namespace Acer.Log
{
	/// <summary>
	/// Log 的結構
	/// </summary>
	public class LogStruct
	{
		/// <summary>Log 等級</summary>
		public string LogLevel{get;set;}

		/// <summary>使用者資訊</summary>
		public string UserInfo{get;set;}

		/// <summary>Log 名稱</summary>
		public string LogName{get;set;}

		/// <summary>Log 訊息</summary>
		public string LogMessage{get;set;}

		/// <summary>Log 日期</summary>
		public string LogDate{get;set;}

		/// <summary>Log 時間</summary>
		public string LogTime{get;set;}

		/// <summary>客戶端 IP</summary>
		public string ClientIP{get;set;}

		/// <summary>主機 IP</summary>
		public string ServerIP{get;set;}

		/// <summary>Session Id</summary>
		public string SessionId{get;set;}

		/// <summary>佇列頻道</summary>
		public string LogChannel{get;set;}
	}
}


