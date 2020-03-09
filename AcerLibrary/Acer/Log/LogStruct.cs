
namespace Acer.Log
{
	/// <summary>
	/// Log �����c
	/// </summary>
	public class LogStruct
	{
		/// <summary>Log ����</summary>
		public string LogLevel{get;set;}

		/// <summary>�ϥΪ̸�T</summary>
		public string UserInfo{get;set;}

		/// <summary>Log �W��</summary>
		public string LogName{get;set;}

		/// <summary>Log �T��</summary>
		public string LogMessage{get;set;}

		/// <summary>Log ���</summary>
		public string LogDate{get;set;}

		/// <summary>Log �ɶ�</summary>
		public string LogTime{get;set;}

		/// <summary>�Ȥ�� IP</summary>
		public string ClientIP{get;set;}

		/// <summary>�D�� IP</summary>
		public string ServerIP{get;set;}

		/// <summary>Session Id</summary>
		public string SessionId{get;set;}

		/// <summary>��C�W�D</summary>
		public string LogChannel{get;set;}
	}
}


