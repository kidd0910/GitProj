using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.IO;
using System.Security.Cryptography;
using Acer.Apps;
using Acer.Util;
using Acer.File;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;
using Acer.Form;
using System.Data.Common;
using Acer.DB;
using Acer.Log;

namespace Acer.Util
{
	/// <summary>
	/// 處理多處理序的共用函式
	/// </summary>
	public class MultiProcess
	{
		//private static string	traceVar	=	"";
		private	static Hashtable globalMap	=	new Hashtable();

		#region SetProcessInit 設定處理初始化
		/// <summary>
		/// 設定處理初始化
		/// </summary>
		/// <param name="basePath">檔案路徑</param>
		/// <param name="processName">處理名稱</param>
		private static void SetProcessInit(string basePath, string processName)
		{
			basePath	=	basePath + processName + ".init";
			if (System.IO.File.Exists(basePath) && new FileInfo(basePath).Length > 888)
				System.IO.File.Delete(basePath);
			System.IO.File.AppendAllText(basePath, DateUtil.GetNowDateTime() + " " + DateUtil.GetNowTimeMS() + "\r\n");
			MultiProcess.globalMap["lastInitTime_" + processName]	=	new FileInfo(basePath).LastWriteTime;
			MultiProcess.globalMap["lastLength_" + processName]	=	new FileInfo(basePath).Length;
		}
		#endregion

		#region CheckNeedInitProcess 檢查是否須變更處理
		/// <summary>
		/// 檢查是否須變更處理
		/// </summary>
		/// <param name="basePath">檔案路徑</param>
		/// <param name="processName">處理名稱</param>
		private static bool CheckNeedInitProcess(string basePath, string processName)
		{
			basePath	=	basePath + processName + ".init";
				
			if (MultiProcess.globalMap[processName] == null || 
				MultiProcess.globalMap["lastInitTime_" + processName] == null ||
				MultiProcess.globalMap["lastLength_" + processName] == null)
			{
				if (System.IO.File.Exists(basePath))
				{
					MultiProcess.globalMap["lastInitTime_" + processName]	=	new FileInfo(basePath).LastWriteTime;
					MultiProcess.globalMap["lastLength_" + processName]	=	new FileInfo(basePath).Length;
				}
				else
				{
					System.IO.File.AppendAllText(basePath, DateUtil.GetNowDateTime() + " " + DateUtil.GetNowTimeMS() + "\r\n");
					MultiProcess.globalMap["lastInitTime_" + processName]	=	new FileInfo(basePath).LastWriteTime;
					MultiProcess.globalMap["lastLength_" + processName]	=	new FileInfo(basePath).Length;
				}
				return true;
			}

			if (MultiProcess.globalMap["lastInitTime_" + processName].Equals(new FileInfo(basePath).LastWriteTime) && 
				MultiProcess.globalMap["lastLength_" + processName].Equals(new FileInfo(basePath).Length))
				return false;
			else
			{
				if (System.IO.File.Exists(basePath))
				{
					MultiProcess.globalMap["lastInitTime_" + processName]	=	new FileInfo(basePath).LastWriteTime;
					MultiProcess.globalMap["lastLength_" + processName]	=	new FileInfo(basePath).Length;
				}
				else
				{
					System.IO.File.AppendAllText(basePath, DateUtil.GetNowDateTime() + " " + DateUtil.GetNowTimeMS() + "\r\n");
					MultiProcess.globalMap["lastInitTime_" + processName]	=	new FileInfo(basePath).LastWriteTime;
					MultiProcess.globalMap["lastLength_" + processName]	=	new FileInfo(basePath).Length;
				}
				return true;
			}
		}
		#endregion

		#region SerializeToFile 將物件序化到檔案
		/// <summary>
		/// 將物件序化到檔案
		/// </summary>
		/// <param name="basePath">檔案路徑</param>
		/// <param name="fileName">檔案名稱</param>
		/// <param name="obj">物件</param>
		public static void SerializeToFile(string basePath, string fileName, Object obj)
		{
DoTrace("SerializeToFile", basePath + fileName);
			if (System.IO.File.Exists(basePath + fileName))
			{
				System.IO.File.Delete(basePath + fileName);
			}
			Stream		fs	=	new FileStream(basePath + fileName, System.IO.FileMode.Create);
			BinaryFormatter	bf	=	new BinaryFormatter();
			bf.Serialize(fs, obj) ;
			fs.Close();
			fs.Dispose();
		}
		#endregion

		#region SerializeFromFile 將檔案反序列化到物件
		private	static object	lockObject1	=	new object();
		/// <summary>
		/// 將檔案反序列化到物件
		/// </summary>
		/// <param name="basePath">檔案路徑</param>
		/// <param name="fileName">檔案名稱</param>
		public static Object SerializeFromFile(string basePath, string fileName)
		{
			string	serializeFile	=	basePath + fileName;
			Object	result		=	null;

			if(System.IO.File.Exists(serializeFile))
			{
				while (true)
				{
					lock(lockObject1)
					{
						try
						{
							System.IO.Stream	fs	=	new System.IO.FileStream(serializeFile, System.IO.FileMode.Open);
						
							if (fs.Length == 0)
							{
								System.IO.File.Delete(serializeFile);
								return result;
							}

							BinaryFormatter	bs	=	new BinaryFormatter();
							result	=	bs.Deserialize(fs); 

							fs.Close();
							fs.Dispose();

							break;
						}
						catch(Exception ex)
						{
							DoTrace("SerializeFromFile", ex.StackTrace.ToString());
						}
						System.Threading.Thread.Sleep(100);
					}
				}
			}
			return result;
		}
		#endregion

		#region SetCrossSiteValue 設定跨網站變數
		private	static	object	lockObject2	=	new object();
		/// <summary>
		/// 設定跨網站變數
		/// </summary>
		/// <param name="varName">變數名稱</param>
		/// <param name="obj">變數值</param>
		public static void SetCrossSiteValue(string varName, object obj)
		{
			//抓設定檔
			if (APConfig.GetProperty("CROSS_SITE_VARIABLE_IN").ToString().Equals("FILE"))
			{
				string	basePath	=	APConfig.GetProperty("SHARE_TMP") + @"\Cache\";
				if (!Directory.Exists(basePath))
					Directory.CreateDirectory(basePath);

				if (!Directory.Exists(basePath))
					throw new Exception("SHARE_TMP 路徑設定有誤, 請檢查 !! -> " + APConfig.GetProperty("SHARE_TMP"));

				while (true)
				{
					lock(lockObject2)
					{
						try
						{
							MultiProcess.SerializeToFile(basePath, varName, obj);
							MultiProcess.globalMap[varName]	=	obj;
							MultiProcess.SetProcessInit(basePath, varName);

							break;
						}
						catch(Exception ex)
						{
							DoTrace("SetCrossSiteValue", ex.StackTrace.ToString());
						}
					}

					System.Threading.Thread.Sleep(100);
				}
			}
			else
			{
				MultiProcess.globalMap[varName]				=	obj;
				MultiProcess.globalMap["lastInitTime_" + varName]	=	System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");	

				lock(lockObject2)
				{
					MyLogger	logger		=	new MyLogger("");
					LogUtil		logUtil		=	new LogUtil("");
					DBManager	dbManager	=	new DBManager(logUtil);
					
					try
					{
						DbConnection	conn;
						//if (APConfig.GetProperty("DATA_PROJECT").Contains("國防大學"))
							conn	=	dbManager.GetIConnection(APConfig.GetProperty("COMMON_DATASOURCE").ToString(), "LOG_TRANSACTION");
						//else
						//	conn	=	dbManager.GetIConnection(APConfig.GetProperty("DATA_DICTIONARY_DATASOURCE").ToString(), "LOG_TRANSACTION");
						string		sql	=	"DELETE CROSS_SITE_VARIABLE WHERE VAR_NAME = '" + varName + "'";
						DbCommand	cmd	=	DBFactory.GetIDBCommand(dbManager.GetProvider(conn));
						cmd.Connection	=	conn;
						cmd.CommandText	=	sql;
						cmd.ExecuteNonQuery();

						//if (APConfig.GetProperty("DATA_PROJECT").Contains("國防大學"))
							sql	=	"INSERT INTO CROSS_SITE_VARIABLE(VAR_NAME, VAR_DATA, MODIFY_DATE) VALUES (@VAR_NAME, @VAR_DATA, @MODIFY_DATE)";
						//else
						//	sql	=	"INSERT INTO CROSS_SITE_VARIABLE(VAR_NAME, VAR_DATA, MODIFY_DATE) VALUES (:VAR_NAME, :VAR_DATA, :MODIFY_DATE)";
						
						MemoryStream	ms	=	new MemoryStream();
						BinaryFormatter	bf	=	new BinaryFormatter();
						bf.Serialize(ms, obj) ;

						cmd.CommandText	=	sql;

						//if (APConfig.GetProperty("DATA_PROJECT").Contains("國防大學"))
						//{
							cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VAR_NAME",		varName));
							cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VAR_DATA",		ms.ToArray()));
							cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MODIFY_DATE",	MultiProcess.globalMap["lastInitTime_" + varName].ToString()));
						//}
                        //else
                        //{
                        //    cmd.Parameters.Add(new System.Data.OracleClient.OracleParameter(":VAR_NAME",	varName));
                        //    cmd.Parameters.Add(new System.Data.OracleClient.OracleParameter(":VAR_DATA",	ms.ToArray()));
                        //    cmd.Parameters.Add(new System.Data.OracleClient.OracleParameter(":MODIFY_DATE",	MultiProcess.globalMap["lastInitTime_" + varName].ToString()));
                        //}
						cmd.ExecuteNonQuery();

						dbManager.Commit();
					}
					finally
					{
						dbManager.Close();
					}
				}
			}
		}
		#endregion

		#region GetDelayCrossSiteValue 取得延遲跨網站變數 (半小時)
		/// <summary>
		/// 取得延遲跨網站變數 (半小時)
		/// </summary>
		/// <param name="varName">變數名稱</param>
		/// <returns>變數值</returns>
		public static object GetDelayCrossSiteValue(string varName)
		{
			try
			{
				//=== 當有快取且快取時間不超過半小時直接回傳不檢查 ===
				if (MultiProcess.globalMap[varName] != null &&
					Microsoft.VisualBasic.DateAndTime.DateDiff (
					Microsoft.VisualBasic.DateInterval.Minute, 
					Convert.ToDateTime(MultiProcess.globalMap["checkInitTime_" + varName]), 
					System.DateTime.Now, 
					Microsoft.VisualBasic.FirstDayOfWeek.Friday, 
					Microsoft.VisualBasic.FirstWeekOfYear.Jan1) <= 30)
				{
					return (object)globalMap[varName];
				}

				return GetRealCrossSiteValue(varName);
			}
			catch(Exception)
			{
				return GetRealCrossSiteValue(varName);
			}
		}
		#endregion

		#region GetDelayCrossSiteValue 取得延遲跨網站變數 (半小時), For check Hashtable key use
		/// <summary>
		/// 取得延遲跨網站變數 (半小時), For check Hashtable key use
		/// </summary>
		/// <param name="varName">變數名稱</param>
		/// <param name="keyName">Key</param>
		/// <returns>變數值</returns>
		public static object GetDelayCrossSiteValue(string varName, string keyName)
		{
			try
			{
				//=== 當有快取且快取時間不超過半小時直接回傳不檢查 ===
				if (MultiProcess.globalMap[varName] != null)
				{
					if (((Hashtable)MultiProcess.globalMap[varName])[keyName] != null)
					{
						if (Microsoft.VisualBasic.DateAndTime.DateDiff (
							Microsoft.VisualBasic.DateInterval.Minute, 
							Convert.ToDateTime(MultiProcess.globalMap["checkInitTime_" + varName]), 
							System.DateTime.Now, 
							Microsoft.VisualBasic.FirstDayOfWeek.Friday, 
							Microsoft.VisualBasic.FirstWeekOfYear.Jan1) <= 30)
						{
							return (object)globalMap[varName];
						}
					}
				}

				return GetRealCrossSiteValue(varName);
			}
			catch(Exception)
			{
				return GetRealCrossSiteValue(varName);
			}
		}
		#endregion

		#region GetCrossSiteValue 取得跨網站變數
		/// <summary>
		/// 取得跨網站變數
		/// </summary>
		/// <param name="varName">變數名稱</param>
		/// <returns>變數值</returns>
		public static object GetCrossSiteValue(string varName)
		{
			try
			{
				//=== 當有快取且快取時間不超過 30s 直接回傳不檢查 ===
				if (MultiProcess.globalMap[varName] != null &&
					Microsoft.VisualBasic.DateAndTime.DateDiff (
					Microsoft.VisualBasic.DateInterval.Second, 
					Convert.ToDateTime(MultiProcess.globalMap["checkInitTime_" + varName]), 
					System.DateTime.Now, 
					Microsoft.VisualBasic.FirstDayOfWeek.Friday, 
					Microsoft.VisualBasic.FirstWeekOfYear.Jan1) <= 30)
				{
					return (object)globalMap[varName];
				}

				return GetRealCrossSiteValue(varName);
			}
			catch(Exception)
			{
				return GetRealCrossSiteValue(varName);
			}
		}
		#endregion

		#region GetCrossSiteValue 取得跨網站變數
		/// <summary>
		/// 取得跨網站變數
		/// </summary>
		/// <param name="varName">變數名稱</param>
		/// <param name="keyName">Key</param>
		/// <returns>變數值</returns>
		public static object GetCrossSiteValue(string varName, string keyName)
		{
			try
			{
				//=== 當有快取且快取時間不超過 30s 直接回傳不檢查 ===
				if (MultiProcess.globalMap[varName] != null)
				{
					if (((Hashtable)MultiProcess.globalMap[varName])[keyName] != null)
					{
						if (Microsoft.VisualBasic.DateAndTime.DateDiff (
							Microsoft.VisualBasic.DateInterval.Second, 
							Convert.ToDateTime(MultiProcess.globalMap["checkInitTime_" + varName]), 
							System.DateTime.Now, 
							Microsoft.VisualBasic.FirstDayOfWeek.Friday, 
							Microsoft.VisualBasic.FirstWeekOfYear.Jan1) <= 30)
						{
							return (object)globalMap[varName];
						}
					}
				}

				return GetRealCrossSiteValue(varName);
			}
			catch(Exception)
			{
				return GetRealCrossSiteValue(varName);
			}
		}
		#endregion

		#region GetRealCrossSiteValue 取得跨網站變數
		/// <summary>
		/// 取得跨網站變數
		/// </summary>
		/// <param name="varName">變數名稱</param>
		/// <returns>變數值</returns>
		public static object GetRealCrossSiteValue(string varName)
		{
			//抓設定檔
			if (APConfig.GetProperty("CROSS_SITE_VARIABLE_IN").ToString().Equals("FILE"))
			{
				//=== 如果空的表示未初始過或變更過, 直接抓序列化物件 ===
				string	basePath	=	APConfig.GetProperty("SHARE_TMP") + @"\Cache\";
				if (!Directory.Exists(basePath))
					Directory.CreateDirectory(basePath);

				if (!Directory.Exists(basePath))
					throw new Exception("SHARE_TMP 路徑設定有誤, 請檢查 !! -> " + APConfig.GetProperty("SHARE_TMP"));

				//抓設定檔
				if (MultiProcess.CheckNeedInitProcess(basePath, varName))
				{
					MultiProcess.globalMap[varName]	=	MultiProcess.SerializeFromFile(basePath, varName);
				}
			}
			//抓 DB
			else
			{
				MyLogger	logger		=	new MyLogger("");
				LogUtil		logUtil		=	new LogUtil("");
				DBManager	dbManager	=	new DBManager(logUtil);
				
				try
				{
					if (MultiProcess.globalMap[varName] == null || 
						MultiProcess.globalMap["lastInitTime_" + varName] == null)
					{
						MultiProcess.globalMap["lastInitTime_" + varName]	=	"2001/01/01 01:01:01";
					}

					DbConnection	conn;
					string		sql;
					//if (APConfig.GetProperty("DATA_PROJECT").Contains("國防大學"))
						conn	=	dbManager.GetIConnection(APConfig.GetProperty("COMMON_DATASOURCE").ToString(), "LOG_TRANSACTION");
                    //else
                    //    conn	=	dbManager.GetIConnection(APConfig.GetProperty("DATA_DICTIONARY_DATASOURCE").ToString(), "LOG_TRANSACTION");
					
					//if (APConfig.GetProperty("DATA_PROJECT").Contains("國防大學"))
						sql	=	"SELECT VAR_DATA, MODIFY_DATE FROM CROSS_SITE_VARIABLE WITH (NOLOCK) " +
								"WHERE " +
								"VAR_NAME = '" + varName + "' AND " + 
								"CONVERT(VARCHAR, MODIFY_DATE, 20) > '" + MultiProcess.globalMap["lastInitTime_" + varName] + "'";
                    //else
                    //    sql	=	"SELECT VAR_DATA, MODIFY_DATE FROM CROSS_SITE_VARIABLE " +
                    //            "WHERE " +
                    //            "VAR_NAME = '" + varName + "' AND " + 
                    //            "TO_CHAR(MODIFY_DATE, 'yyyy/MM/dd HH24:mi:ss') > '" + MultiProcess.globalMap["lastInitTime_" + varName] + "'";
					DbTransaction	trans	=	dbManager.GetDBTransaction(conn);
					DbCommand	cmd	=	DBFactory.GetIDBCommand(dbManager.GetProvider(conn));
					cmd.Connection	=	conn;
					if (trans != null)
						cmd.Transaction	=	trans;
					cmd.CommandText	=	sql;

					DbDataReader	rs	=	cmd.ExecuteReader();
					//=== 當有符合時回傳 ===
					if (rs.Read())
					{
						MemoryStream	ms	=	new MemoryStream((byte[])rs["VAR_DATA"]);
						BinaryFormatter	bs	=	new BinaryFormatter();
						ms.Position	=	0;
						MultiProcess.globalMap[varName]				=	bs.Deserialize(ms); 

						MultiProcess.globalMap["lastInitTime_" + varName]	=	Convert.ToDateTime(rs["MODIFY_DATE"]).ToString("yyyy/MM/dd HH:mm:ss");
						MultiProcess.globalMap["checkInitTime_" + varName]	=	System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
					}
					//未設定該物件時補上檢查時間
					else
					{
						MultiProcess.globalMap["checkInitTime_" + varName]	=	System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
					}

					rs.Close();
				}
				finally
				{
					dbManager.Close();
				}
			}
			return (object)globalMap[varName];
		}
		#endregion

		#region SetGlobalValue 設定全域變數
		private	static	object	lockObject3	=	new object();
		/// <summary>
		/// 設定全域變數
		/// </summary>
		/// <param name="varName">變數名稱</param>
		/// <param name="obj">變數值</param>
		public static void SetGlobalValue(string varName, object obj)
		{
			string	basePath	=	FileUtil.RootPath + @"Temp\Cache\";
			if (!Directory.Exists(basePath))
				Directory.CreateDirectory(basePath);

			if (!Directory.Exists(basePath))
				throw new Exception("SHARE_TMP 路徑設定有誤, 請檢查 !! -> " + APConfig.GetProperty("SHARE_TMP"));

			while(true)
			{
				lock(lockObject3)
				{
					try
					{
						MultiProcess.SerializeToFile(basePath, varName, obj);
						MultiProcess.globalMap[varName]	=	obj;
						MultiProcess.SetProcessInit(basePath, varName);

						break;
					}
					catch(Exception ex)
					{
						DoTrace("SetGlobalValue", ex.StackTrace.ToString());
					}

					System.Threading.Thread.Sleep(100);
				}
			}
		}
		#endregion

		#region GetDelayGlobalValue 取得延遲全域變數 (半小時)
		/// <summary>
		/// 取得延遲全域變數 (半小時)
		/// </summary>
		/// <param name="varName">變數名稱</param>
		/// <returns>變數值</returns>
		public static object GetDelayGlobalValue(string varName)
		{
			//=== 當有快取且快取時間不超過半小時直接回傳不檢查 ===
			if (MultiProcess.globalMap[varName] != null &&
				Microsoft.VisualBasic.DateAndTime.DateDiff (
				Microsoft.VisualBasic.DateInterval.Minute, 
				(DateTime)MultiProcess.globalMap["lastInitTime_" + varName], 
				System.DateTime.Now, 
				Microsoft.VisualBasic.FirstDayOfWeek.Friday, 
				Microsoft.VisualBasic.FirstWeekOfYear.Jan1) <= 30)
			{
				return (object)globalMap[varName];
			}

			return GetRealGlobalValue(varName);
		}
		#endregion

		#region GetDelayGlobalValue 取得延遲全域變數 (半小時), For check Hashtable key use
		/// <summary>
		/// 取得延遲全域變數 (半小時), For check Hashtable key use
		/// </summary>
		/// <param name="varName">變數名稱</param>
		/// <param name="keyName">Key</param>
		/// <returns>變數值</returns>
		public static object GetDelayGlobalValue(string varName, string keyName)
		{
			//=== 當有快取且快取時間不超過半小時直接回傳不檢查 ===
			if (MultiProcess.globalMap[varName] != null)
			{
				if (((Hashtable)MultiProcess.globalMap[varName])[keyName] != null)
				{
					if (Microsoft.VisualBasic.DateAndTime.DateDiff (
						Microsoft.VisualBasic.DateInterval.Minute, 
						(DateTime)MultiProcess.globalMap["lastInitTime_" + varName], 
						System.DateTime.Now, 
						Microsoft.VisualBasic.FirstDayOfWeek.Friday, 
						Microsoft.VisualBasic.FirstWeekOfYear.Jan1) <= 30)
					{
						return (object)globalMap[varName];
					}
				}
			}

			return GetRealGlobalValue(varName);
		}
		#endregion

		#region GetGlobalValue 取得全域變數
		/// <summary>
		/// 取得全域變數
		/// </summary>
		/// <param name="varName">變數名稱</param>
		/// <returns>變數值</returns>
		public static object GetGlobalValue(string varName)
		{
			//=== 當有快取且快取時間不超過 30s 直接回傳不檢查 ===
			if (MultiProcess.globalMap[varName] != null &&
				Microsoft.VisualBasic.DateAndTime.DateDiff (
				Microsoft.VisualBasic.DateInterval.Second, 
				(DateTime)MultiProcess.globalMap["lastInitTime_" + varName], 
				System.DateTime.Now, 
				Microsoft.VisualBasic.FirstDayOfWeek.Friday, 
				Microsoft.VisualBasic.FirstWeekOfYear.Jan1) <= 30)
			{
				return (object)globalMap[varName];
			}

			return GetRealGlobalValue(varName);
		}
		#endregion

		#region GetGlobalValue 取得全域變數
		/// <summary>
		/// 取得全域變數
		/// </summary>
		/// <param name="varName">變數名稱</param>
		/// <param name="keyName">Key</param>
		/// <returns>變數值</returns>
		public static object GetGlobalValue(string varName, string keyName)
		{
			//=== 當有快取且快取時間不超過 30s 直接回傳不檢查 ===
			if (MultiProcess.globalMap[varName] != null)
			{
				if (((Hashtable)MultiProcess.globalMap[varName])[keyName] != null)
				{
					if (Microsoft.VisualBasic.DateAndTime.DateDiff (
						Microsoft.VisualBasic.DateInterval.Second, 
						(DateTime)MultiProcess.globalMap["lastInitTime_" + varName], 
						System.DateTime.Now, 
						Microsoft.VisualBasic.FirstDayOfWeek.Friday, 
						Microsoft.VisualBasic.FirstWeekOfYear.Jan1) <= 30)
					{
						return (object)globalMap[varName];
					}
				}
			}

			return GetRealGlobalValue(varName);
		}
		#endregion

		#region GetRealGlobalValue 取得即時全域變數
		/// <summary>
		/// 取得即時全域變數
		/// </summary>
		/// <param name="varName">變數名稱</param>
		/// <returns>變數值</returns>
		public static object GetRealGlobalValue(string varName)
		{
			//=== 如果空的表示未初始過或變更過, 直接抓序列化物件 ===
			string	basePath	=	FileUtil.RootPath + @"Temp\Cache\";
			if (!Directory.Exists(basePath))
				Directory.CreateDirectory(basePath);

			if (!Directory.Exists(basePath))
				throw new Exception("SHARE_TMP 路徑設定有誤, 請檢查 !! -> " + APConfig.GetProperty("SHARE_TMP"));

			if (MultiProcess.CheckNeedInitProcess(basePath, varName))
			{
				MultiProcess.globalMap[varName]	=	MultiProcess.SerializeFromFile(basePath, varName);
			}

			return (object)globalMap[varName];
		}
		#endregion

		#region ChoiceHashtable 判斷要回傳物件
		/// <summary>
		/// 判斷要回傳物件
		/// </summary>
		/// <param name="obj">要判斷的物件</param>
		/// <returns>Hashtable</returns>
		public static Hashtable ChoiceHashtable(object obj)
		{
			if (obj == null)
				return new Hashtable();
			else
				return (Hashtable)obj;
		}
		#endregion

		#region GetProcessValue 取得處理序變數值
		/// <summary>
		/// 取得處理序變數值
		/// </summary>
		/// <param name="varName">變數名稱</param>
		/// <returns>變數值</returns>
		public static object GetProcessValue(string varName)
		{
			//2011/08/03 nono mark 因壓測會造成 Session 序列化錯誤
			//if (FormUtil.Session[varName] == null)
			//        return (object)MultiProcess.globalMap[varName];

			//if (MultiProcess.globalMap[varName] == null)
			//        return (object)FormUtil.Session[varName];

			////=== 當本地的值較新時, 將值同步到 Session 中並回傳本地值 ===
			//if (((long)MultiProcess.globalMap["lastInitTime_" + varName]) > ((long)FormUtil.Session["lastInitTime_" + varName]))
			//{
			//        FormUtil.Session["lastInitTime_" + varName]	=	MultiProcess.globalMap["lastInitTime_" + varName];
			//        FormUtil.Session[varName]			=	MultiProcess.globalMap[varName];
			//        return (object)MultiProcess.globalMap[varName];
			//}
			//else
			//{
			//        MultiProcess.globalMap["lastInitTime_" + varName]	=	FormUtil.Session["lastInitTime_" + varName];
			//        MultiProcess.globalMap[varName]				=	FormUtil.Session[varName];
			//        return (object)FormUtil.Session[varName];
			//}

			return (object)MultiProcess.globalMap[varName];
		}
		#endregion

		#region SetProcessValue 設定處理序變數值
		/// <summary>
		/// 設定處理序變數值
		/// </summary>
		/// <param name="varName">變數名稱</param>
		/// <param name="obj">變數值</param>
		public static void SetProcessValue(string varName, object obj)
		{
			//2011/08/03 nono mark 因壓測會造成 Session 序列化錯誤
			//long	ms	=	DateUtil.GetCurrTimeMillis();

			////=== 設定 Session ===
			//FormUtil.Session["lastInitTime_" + varName]		=	ms;
			//FormUtil.Session[varName]				=	obj;
			////=== 設定 static 變數 ===
			//MultiProcess.globalMap["lastInitTime_" + varName]	=	ms;
			//MultiProcess.globalMap[varName]				=	obj;

			MultiProcess.globalMap[varName]				=	obj;
		}
		#endregion

		#region DoTrace
		private static void DoTrace(string varName, string content)
		{
			//if (varName.Equals(MultiProcess.traceVar))
				System.IO.File.AppendAllText(FileUtil.RootPath + @"Temp\TRACE_PROCESS.txt", DateUtil.GetNowDateTime() + " " + varName + " -- " + DateUtil.GetNowTimeMS() + " - " + content + "\r\n");
		}
		#endregion
	}
}
