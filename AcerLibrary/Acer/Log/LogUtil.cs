using System;
using Acer.Form;
using Acer.Log;
using Acer.Util;
using Acer.DB;
using Acer.Apps;
using Acer.File;
using System.Collections;
using System.Web.SessionState;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text;

namespace Acer.Log
{
	/// <summary>
	/// Log �@�Τ�k����
	/// </summary>
	public class LogUtil
	{

	#region �ݩ�
		private Hashtable	pPropertyMap	=	new Hashtable();
		private int		colorIndex;
		private	string[]	colorAry	=	new string[]
		{
			"#0000FF", "#8A2BE2", "#A52A2A", "#5F9EA0", "#D2691E", "#6495ED", 
			"#DC143C", "#00008B", "#008B8B", "#B8860B", "#006400", "#8B008B", 
			"#8B0000", "#483D8B", "#2F4F4F", "#696969", "#228B22", "#008000"
		};

		#region PropertyMap ���o�ݩ�
		/// <summary>���o�ݩ�</summary>
		protected Hashtable PropertyMap
		{
			get{return this.pPropertyMap;}
		}
		#endregion

		#region CACHE_TABLE_LIST ���o CACHE_TABLE_LIST
		/// <summary>���o CACHE_TABLE_LIST</summary>
		public ArrayList CACHE_TABLE_LIST
		{
			get
			{
				if (this.PropertyMap["CACHE_TABLE_LIST"] == null)
					this.PropertyMap["CACHE_TABLE_LIST"]	=	(ArrayList)MultiProcess.GetCrossSiteValue("CACHE_TABLE_LIST");
				if (this.PropertyMap["CACHE_TABLE_LIST"] == null)
					this.PropertyMap["CACHE_TABLE_LIST"]	=	new ArrayList();
				return (ArrayList)this.PropertyMap["CACHE_TABLE_LIST"];
			}
		}
		#endregion

		#region StartTime �]�w�}�l�ɶ�
		/// <summary>�]�w�}�l�ɶ�</summary>
		private long StartTime
		{
			get{return (long)this.PropertyMap["StartTime"];}
			set{this.PropertyMap["StartTime"]	=	value;}
		}
		#endregion

		#region Logger �]�w Logger
		/// <summary>�]�w Logger</summary>
		public MyLogger Logger
		{
			get{return (MyLogger)this.PropertyMap["Logger"];}
			set{this.PropertyMap["Logger"]	=	value;}
		}
		#endregion

		#region IsLog �P�_�O�_���� Log
		/// <summary>�P�_�O�_���� Log</summary>
		public bool IsLog
		{
			get{return (bool)this.PropertyMap["IsLog"];}
			set{this.PropertyMap["IsLog"]	=	value;}
		}
		#endregion
	#endregion

	#region �غc�l
		/// <summary>
		/// �غc�l
		/// </summary>
		public LogUtil()
		{
			construct("");
		}

		/// <summary>
		/// �غc�l
		/// </summary>
		/// <param name="jobID">�u�@�s��</param>
		public LogUtil(string jobID)
		{
			construct(jobID);
		}

		private void construct(string jobID)
		{
			this.StartTime	=	DateUtil.GetCurrTimeMillis();

			//=== nono 2009/09/29 add for monitor ===
			try
			{
				//=== nono add �P�_�W���s���ɶ��W�L 1 �����~��s���A ===
				if (FormUtil.Session["LastAccessTime"] == null ||
					Microsoft.VisualBasic.DateAndTime.DateDiff (
					Microsoft.VisualBasic.DateInterval.Minute, 
					(DateTime)FormUtil.Session["LastAccessTime"], 
					System.DateTime.Now, 
					Microsoft.VisualBasic.FirstDayOfWeek.Friday, 
					Microsoft.VisualBasic.FirstWeekOfYear.Jan1) >= 1)
				{
					//### �u�W�H�� ###
					int		minChkTime	=	5;
					string[]	info;
					Hashtable	onLineUser	=	MultiProcess.ChoiceHashtable(MultiProcess.GetProcessValue("ONLINE_USER"));
					Hashtable	onLineList	=	MultiProcess.ChoiceHashtable(MultiProcess.GetProcessValue("ONLINE_LIST"));
					//=== �M���L������� ===
					foreach(object key in onLineUser.Keys)
					{
						info	=	onLineUser[key].ToString().Split('|');

						//=== �ˬd�W�L�ɶ��� ===
						if (Microsoft.VisualBasic.DateAndTime.DateDiff (
								Microsoft.VisualBasic.DateInterval.Minute, 
								Convert.ToDateTime(info[0]), 
								System.DateTime.Now, 
								Microsoft.VisualBasic.FirstDayOfWeek.Friday, 
								Microsoft.VisualBasic.FirstWeekOfYear.Jan1) >= minChkTime)
							onLineUser.Remove(key);
					}
					//��J��T
					onLineUser["ONLINE_" + FormUtil.Session.SessionID]	=	
							System.DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "|" + 
							Utility.CheckNull(FormUtil.Session[APConfig.GetProperty("VALIDE_SESSION_NAME").ToString()], "No Session") + "|" +
							Utility.GetIP() + "|" +
							System.DateTime.Now.ToString();
					
					//### ����\���O�� ###
					if (!FormUtil.Request.FilePath.ToLower().Contains("keepsession1.aspx"))
					{
						//=== �M���L������� ===
						foreach(object key in onLineList.Keys)
						{
							//=== �ˬd���b�u�W�̽� ===
							if (onLineUser[key.ToString().Replace("ONLIST_", "ONLINE_")] == null)
								onLineList.Remove(key);
						}

						//��J��T
						onLineList["ONLIST_" + FormUtil.Session.SessionID]	=	FormUtil.Request.FilePath;
					}

					MultiProcess.SetProcessValue("ONLINE_USER", onLineUser);
					MultiProcess.SetProcessValue("ONLINE_LIST", onLineList);
				}
				else
				{
					Hashtable	onLineUser	=	MultiProcess.ChoiceHashtable(MultiProcess.GetProcessValue("ONLINE_USER"));
					Hashtable	onLineList	=	MultiProcess.ChoiceHashtable(MultiProcess.GetProcessValue("ONLINE_LIST"));

					//��J��T
					onLineUser["ONLINE_" + FormUtil.Session.SessionID]	=	
							System.DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "|" + 
							Utility.CheckNull(FormUtil.Session[APConfig.GetProperty("VALIDE_SESSION_NAME").ToString()], "No Session") + "|" +
							Utility.GetIP() + "|" +
							System.DateTime.Now.ToString();

					//��J��T
					onLineList["ONLIST_" + FormUtil.Session.SessionID]	=	FormUtil.Request.FilePath;

					MultiProcess.SetProcessValue("ONLINE_USER", onLineUser);
					MultiProcess.SetProcessValue("ONLINE_LIST", onLineList);
				}
				FormUtil.Session["LastAccessTime"]	=	System.DateTime.Now;
			}
			catch(System.Exception ex){
				//throw new Exception(ex.ToString());
			}
		
			//try
			//{
			//        //���b�ϥΪ�����
			//        if (FormUtil.Request.FilePath.ToLower().Contains("keepsession1.aspx") || FormUtil.Request.FilePath.ToLower().Contains("menutree.aspx"))
			//        {
			//        }
			//        else
			//        {
			//                string	loginName	=	Utility.CheckNull(FormUtil.Session[APConfig.GetProperty("VALIDE_SESSION_NAME").ToString()], "");
			//                Hashtable	pageInfo	=	MultiProcess.ChoiceHashtable(MultiProcess.GetProcessValue("PAGE_INFO"));
			//                pageInfo[FormUtil.Session + "__" + this.StartTime]	=	System.DateTime.Now + " - " + loginName + " - " + FormUtil.Request.FilePath;
			//                MultiProcess.SetProcessValue("PAGE_INFO", pageInfo);
			//        }
			//}
			//catch(System.Exception){}

			try
			{
				this.IsLog	=	true;
				this.Logger	=	new MyLogger(FormUtil.Request.FilePath);
			}
			catch(System.Exception)
			{
				if (string.IsNullOrEmpty(jobID))
					this.Logger	=	new MyLogger("AP");
				else
					this.Logger	=	new MyLogger(jobID);
			}

			//=== �_�l Log ===
			try
			{
				if (FormUtil.Session == null)
					this.Logger.IniUserInfo("IIS Start");
				else
				{
					string	empno	=	(string)FormUtil.Session[APConfig.GetProperty("VALIDE_SESSION_NAME").ToString()];
					this.Logger.sessionId	=	FormUtil.Session.SessionID;
					if (string.IsNullOrEmpty(empno))
						this.Logger.IniUserInfo("No Session User IP:" + Utility.GetIP());
					else
					{
						string	loginInfo	=	"";
						if (FormUtil.Session["LOGIN_TIME"] != null)
							loginInfo	=	" Login time:" + FormUtil.Session["LOGIN_TIME"].ToString();
						
						this.Logger.IniUserInfo("User:" + empno + " IP:" + Utility.GetIP() + loginInfo);
					}
				}
			}
			catch(System.Exception)
			{
				this.Logger.IniUserInfo("AP Start");
			}
		}
	#endregion

	#region ��k	
		/// <summary>
		/// ��������
		/// </summary>
		public enum PointType:int
		{
			/// <summary>�_�I</summary>
			PointStart	=	0,
			/// <summary>�I</summary>
			Point		=	1,
			/// <summary>�����I</summary>
			PointEnd	=	2,
		}

		/// <summary>
		/// ���������I�}�l (For Trace PRODECUTION=Y �h���B�z)
		/// </summary>
		/// <param name="functionName">�����I�W��</param>
		public void TraceStart(string functionName)
		{
			//=== ���B�z Log �ʧ@ ===
			if (!IsLog)
				return;
			if (Utility.NullToSpace(APConfig.GetProperty("SHOW_TRACE_LOG")).Equals("N"))
				return;
			this.PropertyMap[functionName + "LAST_START_TIME"]	=	DateUtil.GetCurrTimeMillis();
			this.PropertyMap[functionName + "COLOR"]		=	this.colorAry[this.colorIndex];
			//=== ��� Session ������T ===
			string[]	sessionInfo	=	LogUtil.SessionSize();
			this.PropertyMap[functionName + "SESSION_SIZE"]		=	sessionInfo[0];
			this.PropertyMap[functionName + "SESSION_NAME"]		=	sessionInfo[1];
			if (this.colorIndex == this.colorAry.Length - 1)
				this.colorIndex	=	0;
			else
				this.colorIndex	+=	1;
			this.Logger.Append(LogUtil.PointStr(this.PropertyMap, functionName, "", (int)LogUtil.PointType.PointStart));
		}

		/// <summary>
		/// ���������I�}�l
		/// </summary>
		/// <param name="functionName">�����I�W��</param>
		public void MethodStart(string functionName)
		{
			//=== ���B�z Log �ʧ@ ===
			if (!IsLog)
				return;
			this.PropertyMap[functionName + "LAST_START_TIME"]	=	DateUtil.GetCurrTimeMillis();
			this.PropertyMap[functionName + "COLOR"]		=	this.colorAry[this.colorIndex];
			//=== ��� Session ������T ===
			string[]	sessionInfo	=	LogUtil.SessionSize();
			this.PropertyMap[functionName + "SESSION_SIZE"]		=	sessionInfo[0];
			this.PropertyMap[functionName + "SESSION_NAME"]		=	sessionInfo[1];
			if (this.colorIndex == this.colorAry.Length - 1)
				this.colorIndex	=	0;
			else
				this.colorIndex	+=	1;
			this.Logger.Append(LogUtil.PointStr(this.PropertyMap, functionName, "", (int)LogUtil.PointType.PointStart));
		}

		/// <summary>
		/// ���������I���� (For Trace PRODECUTION=Y �h���B�z)
		/// </summary>
		/// <param name="functionName">�����I�W��</param>
		public void TraceEnd(string functionName)
		{
			//=== ���B�z Log �ʧ@ ===
			if (!IsLog)
				return;
			if (Utility.NullToSpace(APConfig.GetProperty("SHOW_TRACE_LOG")).Equals("N"))
				return;
			long	endTime	=	DateUtil.GetCurrTimeMillis();
			this.Logger.Append(LogUtil.PointStr(this.PropertyMap, functionName, System.Convert.ToString(endTime - (long)this.PropertyMap[functionName + "LAST_START_TIME"], 10) + " ms", (int)LogUtil.PointType.Point));
			this.Logger.Append(LogUtil.PointStr(this.PropertyMap, functionName, "", (int)LogUtil.PointType.PointEnd));
			this.PropertyMap.Remove(functionName + "LAST_START_TIME");
			this.PropertyMap.Remove(functionName + "COLOR");
			this.PropertyMap.Remove(functionName + "SESSION_SIZE");
			this.PropertyMap.Remove(functionName + "SESSION_NAME");
		}

		/// <summary>
		/// ���������I����
		/// </summary>
		/// <param name="functionName">�����I�W��</param>
		public void MethodEnd(string functionName)
		{
			//=== nono 2009/09/29 add for monitor ===
			try
			{
				Hashtable	pageInfo	=	MultiProcess.ChoiceHashtable(MultiProcess.GetProcessValue("PAGE_INFO"));
				if (pageInfo[FormUtil.Session + "__" + this.StartTime] != null )
				{
					if (pageInfo[FormUtil.Session + "__" + this.StartTime].ToString().Length > 500)
					{
						if (!pageInfo[FormUtil.Session + "__" + this.StartTime].ToString().EndsWith("..."))
							pageInfo[FormUtil.Session + "__" + this.StartTime]	+=	"...";
					}
					else
					{
						pageInfo[FormUtil.Session + "__" + this.StartTime]	=	
							pageInfo[FormUtil.Session + "__" + this.StartTime].ToString() + 
							", " + functionName + 
							"(" + System.Convert.ToString(DateUtil.GetCurrTimeMillis() - (long)this.PropertyMap[functionName + "LAST_START_TIME"], 10) + " ms)";
					}
				}
				MultiProcess.SetProcessValue ("PAGE_INFO", pageInfo);
			}
			catch(System.Exception){}

			//=== ���B�z Log �ʧ@ ===
			if (!IsLog)
				return;
			
			try
			{
				long	endTime	=	DateUtil.GetCurrTimeMillis();

				this.Logger.Append(LogUtil.PointStr(this.PropertyMap, functionName, System.Convert.ToString(endTime - (long)this.PropertyMap[functionName + "LAST_START_TIME"], 10) + " ms", (int)LogUtil.PointType.Point));
				this.Logger.Append(LogUtil.PointStr(this.PropertyMap, functionName, "", (int)LogUtil.PointType.PointEnd));
				this.PropertyMap.Remove(functionName + "LAST_START_TIME");
				this.PropertyMap.Remove(functionName + "COLOR");
				this.PropertyMap.Remove(functionName + "SESSION_SIZE");
				this.PropertyMap.Remove(functionName + "SESSION_NAME");
			}
			catch(System.Exception)
			{
			}
		}

		/// <summary>
		/// ���o�����I����r
		/// </summary>
		/// <param name="propertyMap">�ݩʪ���</param>
		/// <param name="functionName">�����I</param>
		/// <param name="timerStr">�ɶ�����</param>
		/// <param name="pointType">��������</param>
		/// <returns>�����I����r</returns>
		private static string PointStr(Hashtable propertyMap, string functionName, string timerStr, int pointType)
		{
			string	result;
			switch (pointType)
			{
				case (int)LogUtil.PointType.PointStart:
					result	=	"<blockquote><font color='" + propertyMap[functionName + "COLOR"] + "'>�z---- [" + GetFunctionName(functionName) + " START] ----�{</font>";
					break;
				case (int)LogUtil.PointType.Point:
					result	=	"<font color=blue>" + functionName + " ����ɶ��G" + timerStr + "</font>";
					break;
				case (int)LogUtil.PointType.PointEnd:
					string[]	sessionInfo	=	LogUtil.SessionSize();
					String		tmpContent	=	(String)propertyMap[functionName + "SESSION_NAME"];
					long		size		=	System.Convert.ToInt64(sessionInfo[0]);
					long		diff		=	size - (System.Convert.ToInt64(propertyMap[functionName + "SESSION_SIZE"]));
					if (diff > 0)
					{
						string[]	tmp1		=	tmpContent.Split(',');
						string[]	tmp2		=	sessionInfo[1].Split(',');
						Hashtable	map1		=	new Hashtable();
						Hashtable	map2		=	new Hashtable();
						StringBuilder	diffBuff	=	new StringBuilder();
						string[]	tmp;

						//=== �N Start ��ƶ�� Map ===
						for (int i = 0; i < tmp1.Length; i++)
						{
							if (tmp1[i].Trim().Equals(""))
								continue;
						        tmp		=	tmp1[i].Split('.');
						        map1[tmp[0]]	=	tmp[1];
						}

						//=== �N End ��ƶ�� Map ===
						for (int i = 0; i < tmp2.Length; i++)
						{
							if (tmp2[i].Trim().Equals(""))
								continue;
							tmp		=	tmp2[i].Split('.');
							map2[tmp[0]]	=	tmp[1];
						}

						//=== �P�_��� Key ���t��, �ηs�����ª� ===
						foreach(object key in map2.Keys)
						{
							if (map1[key] == null)
						                diffBuff.Append(",add " + key + ":" + map2[key]);
						        else
						        {
						                if (!map1[key].Equals(map2[key]))
						                {
						                        diffBuff.Append(",mod " + key + ":" + map1[key] + " -> " + map2[key]);
						                }
						        }
						}

						//=== �P�_��� ===
						foreach(object key in map1.Keys)
						{
							if (map2[key] == null)
						                diffBuff.Append(",del " + key + ":" + map2[key]);
						}

						result	=	"<font color='" + propertyMap[functionName + "COLOR"] + "'>�|---- [" + functionName + " END]   ----�} (Session Size:" + size + 
								" Session Diff:" + diff  + " Detail:" + diffBuff.ToString() + ")</font></blockquote>";
					
						//=== �O�� log ===
						LogUtil.WriteWaringLog (functionName, size, diff, diffBuff);
					}
					else
					{
						result	=	"<font color='" + propertyMap[functionName + "COLOR"] + "'>�|---- [" + functionName + " END]   ----�} (Session Size:" + size + 
								")</font></blockquote>";
					}
					break;
				default:
					result	=	"";
					break;
			}

			return result;
		}

		private static void WriteWaringLog (string functionName, long sessionSize, long diff, StringBuilder diffBuff)
		{
			string	pageName	=	"";
			try
			{
				pageName	=	"--" + System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + " " +
							FormUtil.Session["LOGIN_ACNT"].ToString() + " " + FormUtil.Session["NAME"].ToString() + " " +
							FormUtil.Request.ServerVariables["LOCAL_ADDR"].ToString() + " " + 
							FormUtil.Request.FilePath;
			}
			catch(Exception)
			{
				pageName	=	"";
			}

			if (diff > 1024 * LogUtil.GetMemoryLimit())
			{
				FormUtil.Application.Lock();
				System.IO.File.AppendAllText(APConfig.RealPath + @"Temp\memory_length" +
					System.DateTime.Now.ToString("yyyyMMdd") + ".txt", 
					pageName + functionName + 
					" \r\nSession Size:" + sessionSize + " Session Diff:" + diff  + " \r\nDetail:" + diffBuff.ToString() +
					"\r\n=================================\r\n");
				FormUtil.Application.UnLock();
			}
		}

		private static string GetFunctionName(string functionName)
		{
			try
			{
				if (functionName.IndexOf(".Business.") != -1 || functionName.IndexOf(".Data.") != -1)
				{
					string	sysName		=	functionName.Split('.')[0];
					string	className	=	functionName.Split('.')[2];
					string	methodName	=	functionName.Split('.')[3];
					functionName	=	"<a href='http://210.80.86.203" + FormUtil.Application["vr"] + "Application/Tool/SPEC001_03.aspx?sys=" + sysName + "&class=" + className + "&method=" + methodName + "' target='CLASS_" + DateUtil.GetCurrTimeMillis() + "'>" + functionName + "</a>";
				}
			}
			catch(System.Exception)
			{
			}
			return functionName;
		}

		/// <summary>
		/// �}�l���� Log
		/// </summary>
		public void DoLog()
		{
			long	endTime		=	DateUtil.GetCurrTimeMillis();
			long	execTime	=	endTime - this.StartTime;
			this.Logger.execTime	=	execTime;
			this.Logger.Append("��������ɶ��G" + execTime + " ms");
			//=== nono 2009/09/28 nono �������L�[�O�� ===
			try
			{
				if ((endTime - this.StartTime) > (60000 * 3))
				{
					System.IO.File.AppendAllText(FileUtil.RootPath + @"temp\ProcessLongTime.txt", 
									System.DateTime.Now + " -- " + FormUtil.Request.FilePath + " Process: " + (endTime - this.StartTime) + " ms\r\n");
				}
			}catch(System.Exception){}

			//this.ClearMonitor();

			MyLogger.Log(this.Logger);
		}

		///// <summary>
		///// �M���ʱ��O�� For Page
		///// </summary>
		//public void ClearMonitor()
		//{
		//        //=== nono 2009/09/29 add for monitor ===
		//        try
		//        {
		//                Hashtable	pageInfo	=	MultiProcess.ChoiceHashtable(MultiProcess.GetProcessValue("PAGE_INFO"));
		//                pageInfo.Remove(FormUtil.Session + "__" + this.StartTime);
		//                MultiProcess.SetProcessValue("PAGE_INFO", pageInfo);
		//        }
		//        catch(System.Exception){}
		//}
	#endregion

	#region Session ����
		/// <summary>
		/// ���o Session �j�p�Τ��e
		/// </summary>
		/// <returns></returns>
		private static string[] SessionSize()
		{
			string[]		result	=	{"", ""};
			BinaryFormatter		b	=	new BinaryFormatter();
			MemoryStream		m;

			//���w�q�άO�]�w���O���ɪ����^�� 0
			try
			{
				if (!APConfig.GetProperty("IS_LOG_MEMORY_SIZE").Equals("Y"))
					return new String[]{"0", ""};
			}
			catch (Exception)
			{
				return new String[]{"0", ""};
			}

			//=== �妸�Ϊ� Session �����^�� 0 ===
			try
			{
				if (FormUtil.Session == null)
					return new String[]{"0", ""};
			}
			catch (Exception)
			{
				return new String[]{"0", ""};
			}

			StringBuilder	sessionNames	=	new StringBuilder();
			long		sessionSize	=	0;

			if (FormUtil.Session == null || FormUtil.Session.Keys == null)
				return new String[]{"0", ""};

			foreach (String key in FormUtil.Session.Keys)
			{
			        m	=	new MemoryStream();  
				try
				{
					b.Serialize(m, FormUtil.Session[key]);  
					//=== ���� Memory �� Size ===
					sessionSize	+=	m.Length;

					//=== �줺�e ===
					if (sessionNames.Length == 0)
						sessionNames.Append(key + "." + m.Length);
					else
						sessionNames.Append("," + key + "." + m.Length);
				}
				catch (Exception)
				{}
				finally
				{
					m.Dispose();
					m.Close();
				}
			}
			
			result[0]	=	sessionSize.ToString();
			result[1]	=	sessionNames.ToString();
			return result;
		}

		private static long GetMemoryLimit()
		{
			try
			{
				return System.Convert.ToInt64(APConfig.GetProperty("LOG_MEMORY_LIMIT"));
			}
			catch (Exception)
			{
				return 100;
			}
		}
	#endregion
	}
}