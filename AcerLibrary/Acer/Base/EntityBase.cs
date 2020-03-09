using Acer.DB;
using Acer.DB.Query;
using Acer.Log;
using Acer.Util;
using System.Data.Common;
using Acer.Form;
using Acer.Apps;
using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Reflection;
using Acer;
using System.Net.Sockets;

namespace Acer.Base
{
	/// <summary>
	/// 商業邏輯物件繼承元件, 初使化資料庫容器物件
	/// </summary>
	public class EntityBase : IEntityInterface 
	{
		private	Hashtable	pColumnMap	=	new Hashtable (new Util.EntityColumnCompare());
		private	DataTable	queryData;
		private	ArrayList	batchCommand	=	new ArrayList();	//紀錄異動的 SQL
		private	bool		realAction	=	true;			//是否實際寫入 DB(for 大量異動用)

	#region 建構子
		/// <summary>
		/// 建構子/處理異動處理
		/// </summary>
		/// <param name="dbManager">DBManager 物件</param>
		/// <param name="logUtil">logUtil 物件</param>
		/// <remarks>初使化資料庫容器物件</remarks>
		public EntityBase(DBManager dbManager, LogUtil logUtil)
		{
			this.TransactionGroup	=	"";
			this.ManualTransaction	=	false;
			this.DBManager		=	dbManager;
			this.LogUtil		=	logUtil;
			this.TableCoumnInfo	=	new ArrayList();
			this.SkipProperty	=	false;
			this.IsManualPKNO	=	false;
		}

		/// <summary>
		/// 建構子/處理屬性對應處理
		/// </summary>
		/// <param name="dt">DataTable 物件</param>
		/// <remarks>初使化資料庫容器物件</remarks>
		public EntityBase(DataTable dt)
		{
			this.queryData	=	dt;
		}
	#endregion

	#region 屬性
		private	Hashtable	pPropertyMap	=	new Hashtable();
		/// <summary>參數對應屬性</summary>
		protected Hashtable PropertyMap
		{
			get{return this.pPropertyMap;}
		}

		/// <summary>設定欄位集合</summary>
		protected Hashtable ColumnyMap
		{
			get{return this.pColumnMap;}
		}

		#region SkipProperty 保留屬性資料
		/// <summary>保留屬性資料</summary>
		protected bool SkipProperty
		{
			get{return (bool)this.PropertyMap["SkipProperty"];}
			set{this.PropertyMap["SkipProperty"]	=	value;}
		}
		#endregion

		#region SysName 設定 SysName
		/// <summary>設定 SysName</summary>
		public string SysName
		{
			get{return (string)this.PropertyMap["SysName"];}
			set{this.PropertyMap["SysName"]	=	value;}
		}
		#endregion

		#region LONG_FIELD_NAME 設定欄位長度過長欄名(逗後區隔)
		/// <summary>設定欄位長度過長欄名(逗後區隔)</summary>
		public string LONG_FIELD_NAME
		{
			get{return (string)this.PropertyMap["LONG_FIELD_NAME"];}
			set{this.PropertyMap["LONG_FIELD_NAME"]	=	value;}
		}
		#endregion

		#region SET_NULL_FIELD 設定欄位空白時塞 NULL(逗後區隔)
		/// <summary>設定欄位空白時塞 NULL(逗後區隔)</summary>
		public string SET_NULL_FIELD
		{
			get{return (string)this.PropertyMap["SET_NULL_FIELD"];}
			set{this.PropertyMap["SET_NULL_FIELD"]	=	value;}
		}
		#endregion

		#region FUNCTION_FIELD 設定欄位套用 Function 或是自定 Exp: COLUMN = COLUMN + 1, Me.FUNCTION_FIELD = "COLUMN"(逗後區隔)
		/// <summary>設定欄位套用 Function 或是自定 Exp: COLUMN = NULL, Me.FUNCTION_FIELD = "COLUMN"(逗後區隔)</summary>
		public string FUNCTION_FIELD
		{
			get{return (string)this.PropertyMap["FUNCTION_FIELD"];}
			set{this.PropertyMap["FUNCTION_FIELD"]	=	value;}
		}
		#endregion

		#region LogUtil 設定 LogUtil 物件
		/// <summary>設定 LogUtil 物件</summary>
		protected LogUtil LogUtil
		{
			get{return (LogUtil)this.PropertyMap["LogUtil"];}
			set{this.PropertyMap["LogUtil"]	=	value;}
		}
		#endregion

		#region ColumnFilter 設定欄位資料
		/// <summary>設定 LogUtil 物件</summary>
		protected String ColumnFilter
		{
			get{return (String)this.PropertyMap["ColumnFilter"];}
			set{this.PropertyMap["ColumnFilter"]	=	value;}
		}
		#endregion

		#region ExecuteSQL 執行的 SQL 指令
		/// <summary>執行的 SQL 指令</summary>
		public String ExecuteSQL
		{
			get{return (String)this.PropertyMap["ExecuteSQL"];}
			set{this.PropertyMap["ExecuteSQL"]	=	value;}
		}
		#endregion

		#region NotContainPKNO 欄位未包含 PKNO
		/// <summary>欄位未包含 PKNO</summary>
		public bool NotContainPKNO
		{
			get
			{
				if (this.PropertyMap["NotContainPKNO"] == null)
					return false;
				else
					return (bool)this.PropertyMap["NotContainPKNO"];
			}
			set{this.PropertyMap["NotContainPKNO"]	=	value;}
		}
		#endregion

		#region MyLogger 設定 Logger 物件
		/// <summary>設定 Logger 物件</summary>
		protected MyLogger Logger
		{
			get{return this.LogUtil.Logger;}
		}
		#endregion

		#region ConnName 連線字串屬性
		/// <summary>連線字串屬性</summary>
		public string ConnName
		{
			get{return (string)this.PropertyMap["ConnName"];}
			set{this.PropertyMap["ConnName"]	=	value;}
		}
		#endregion

		#region DBManager 設定 DBManager 物件
		/// <summary>設定 DBManager 物件</summary>
		protected DBManager DBManager
		{
			get{return (DBManager)this.PropertyMap["DBManager"];}
			set{this.PropertyMap["DBManager"]	=	value;}
		}
		#endregion

		#region TableName 表格名稱
		/// <summary>表格名稱</summary>
		public string TableName
		{
			get{return (string)this.PropertyMap["TableName"];}
			set{this.PropertyMap["TableName"]	=	value;}
		}
		#endregion

		#region Hint SQL Hint
		/// <summary>SQL Hint</summary>
		public string Hint
		{
			get{return (string)this.PropertyMap["Hint"];}
			set{this.PropertyMap["Hint"]	=	value;}
		}
		#endregion

		#region BatchExecuteSize 一次執行 SQL 的數量(預設 500)
		/// <summary>BatchExecuteSize 一次執行 SQL 的數量(預設 500)</summary>
		public int BatchExecuteSize
		{
			get{
				if (this.PropertyMap["BatchExecuteSize"] == null)
					return 500;
				else
					return (int)this.PropertyMap["BatchExecuteSize"];
			}
			set{this.PropertyMap["BatchExecuteSize"]	=	value;}
		}
		#endregion

		#region TOTAL_ROW_COUNT 總筆數
		/// <summary>總筆數</summary>
		public int TOTAL_ROW_COUNT
		{
			get{return (int)this.PropertyMap["TOTAL_ROW_COUNT"];}
			set{this.PropertyMap["TOTAL_ROW_COUNT"]	=	value;}
		}
		#endregion

		#region SelectColumns 查詢的欄位
		/// <summary>查詢的欄位</summary>
		public string SelectColumns
		{
			get{return (string)this.PropertyMap["SelectColumns"];}
			set{this.PropertyMap["SelectColumns"]	=	value;}
		}
		#endregion

		#region GroupBys 設定的群組條件
		/// <summary>設定的群組條件</summary>
		public string GroupBys
		{
			get{return (string)this.PropertyMap["GroupBys"];}
			set{this.PropertyMap["GroupBys"]	=	value;}
		}
		#endregion

		#region OrderBys 設定的排序條件
		/// <summary>設定的排序條件</summary>
		public string OrderBys
		{
			get{return (string)this.PropertyMap["OrderBys"];}
			set{this.PropertyMap["OrderBys"]	=	value;}
		}
		#endregion

		#region CurrentUserId 取得目前使用者資料
		/// <summary>
		/// 取得目前使用者資料
		/// </summary>
		/// <returns></returns>
		/// <remarks></remarks>
		protected string CurrentUserId
		{
			get
			{
				if (string.IsNullOrEmpty((string)this.PropertyMap["USERID"]))
				{
					if (System.Web.HttpContext.Current != null)
						return (string)FormUtil.Session[APConfig.GetProperty("VALIDE_SESSION_NAME")];
					else
						return "system";
				}
				else
					return this.PropertyMap["USERID"].ToString();
			}
		}
		#endregion

		#region 共用欄位
		/// <summary>更新者帳號</summary>
		public virtual string UPD_USER_ID
		{
			get{return (string)this.PropertyMap["UPD_USER_ID"];}
			set{this.PropertyMap["UPD_USER_ID"]	=	value;}
		}

		/// <summary>更新日期</summary>
		public virtual string UPD_DATE
		{
			get{return (string)this.PropertyMap["UPD_DATE"];}
			set{this.PropertyMap["UPD_DATE"]	=	value;}
		}

		/// <summary>更新時間</summary>
		public virtual string UPD_TIME
		{
			get{return (string)this.PropertyMap["UPD_TIME"];}
			set{this.PropertyMap["UPD_TIME"]	=	value;}
		}

		/// <summary>時間戳記</summary>
		public string ROWSTAMP
		{
			get{return (string)this.PropertyMap["ROWSTAMP"];}
			set{this.PropertyMap["ROWSTAMP"]	=	value;}
		}

		/// <summary>PKNO</summary>
		public string PKNO
		{
			get{return (string)this.PropertyMap["PKNO"];}
			set{this.PropertyMap["PKNO"]	=	value;}
		}

		private bool ManualTransaction
		{
			get{return (bool)this.PropertyMap["ManualTransaction"];}
			set{this.PropertyMap["ManualTransaction"]	=	value;}
		}

		/// <summary>
		/// 是否手動輸入 PKNO
		/// </summary>
		public bool IsManualPKNO
		{
			get{return (bool)this.PropertyMap["ManualPKNO"];}
			set{this.PropertyMap["ManualPKNO"]	=	value;}
		}

		private string TransactionGroup
		{
			get{return (string)this.PropertyMap["TransactionGroup"];}
			set{this.PropertyMap["TransactionGroup"]	=	value;}
		}
		#endregion

		#region SqlRetrictions 設定的條件
		/// <summary>表格名稱</summary>
		public string SqlRetrictions
		{
			get{return (string)this.PropertyMap["SqlRetrictions"];}
			set{this.PropertyMap["SqlRetrictions"]	=	value;}
		}
		#endregion

		#region TableCoumnInfo 設定欄位資訊
		/// <summary>設定欄位資訊, string(){(0)為 Table Name, (1)為別名, 接下來為欄位名稱}</summary>
		protected ArrayList TableCoumnInfo
		{
			get{return (ArrayList)this.PropertyMap["TableCoumnInfo"];}
			set{this.PropertyMap["TableCoumnInfo"]	=	value;}
		}
		#endregion
	#endregion

	#region 介面方法實作
		/// <summary>
		/// 處理轉換別名資訊
		/// </summary>
		protected void ParserAlias()
		{
            //Add By Brian 2013/10/28
            if (! string.IsNullOrEmpty(this.SqlRetrictions))
            {
                string[] tmpAry;

                this.SqlRetrictions = ProcessCondition(this.SqlRetrictions);

                for (int i = 0; i < this.TableCoumnInfo.Count; i++)
                {
                    tmpAry = (string[])this.TableCoumnInfo[i];
                    for (int j = 2; j < tmpAry.Length; j++)
                        this.SqlRetrictions = this.SqlRetrictions.Replace(ControlBase.aliasMark + tmpAry[j], tmpAry[1] + "." + tmpAry[j]);
                }
            }
		}

		/// <summary>
		/// 處理查詢條件
		/// </summary>
		/// <param name="cond">查詢條件</param>
		/// <returns>查詢條件</returns>
		public string ProcessCondition(string cond)
		{
			return DBUtil.ProcessCondition(cond);
		}

		/// <summary>
		/// 重設所有欄位屬性
		/// </summary>
		public void ResetColumnProperty()
		{
			if (!this.SkipProperty)
			{
				this.pColumnMap		=	new Hashtable (new Util.EntityColumnCompare());
				this.SqlRetrictions	=	"";
				this.OrderBys		=	"";
				this.GroupBys		=	"";
				this.SelectColumns	=	"";
			}
		}

		/// <summary>
		/// 設定處理交易方式
		/// </summary>
		/// <param name="manualTransaction">是否自行設定處理交易</param>
		public void SetTransactionMode(bool manualTransaction)
		{
			this.ManualTransaction	=	manualTransaction;
		}

		/// <summary>
		/// 設定處理交易群組方式
		/// </summary>
		/// <param name="groupName">設定處理交易群組方式</param>
		public void SetTransactionGroup(string groupName)
		{
			this.TransactionGroup	=	groupName;
		}

		private DbConnection GetIConnection()
		{
			try
			{
				this.LogUtil.TraceStart("GetConnection");
				
				DbConnection	conn;
				if (!string.IsNullOrEmpty(this.TransactionGroup))
					conn	=	this.DBManager.GetIConnection(this.ConnName, this.TransactionGroup);
				else
					conn	=	this.DBManager.GetIConnection(this.ConnName, this.ManualTransaction);
				
				return conn;
			}
			finally
			{
				this.LogUtil.TraceEnd("GetConnection");
			}
		}

		/// <summary>
		/// 紀錄所塞的屬性資料
		/// </summary>
		public void LogProperty()
		{
			if (Utility.NullToSpace(APConfig.GetProperty("SHOW_TRACE_LOG")).Equals("N"))
				return;
			StringBuilder	logBuff	=	new StringBuilder();

			logBuff.Append("ColumnMap -> ");
			foreach (string key in this.pColumnMap.Keys)
			{
				if (this.pColumnMap[key] != null)
				{
					logBuff.Append("," + key + ":" + this.pColumnMap[key]);
				}
			}

			logBuff.Append("\r\nPropertyMap -> ");
			foreach (string key in this.pPropertyMap.Keys)
			{
				if (key.Equals("DBManager") || key.Equals("LogUtil") || key.Equals("TableCoumnInfo") || key.Equals("ExecuteSQL"))
					continue;

				if (this.pPropertyMap[key] != null)
				{
					logBuff.Append("," + key + ":" + this.pPropertyMap[key]);
				}
			}
			
			if (this.Logger.IsLog)
			{
				this.Logger.Append("=== 所設定屬性開始 ===");
				this.Logger.Append(logBuff.ToString());
				this.Logger.Append("=== 所設定屬性結束 ===");
			}
		}

		private	static	string[]	ip	=	null;
		private	static	int		ipIdx	=	0;

		private void ConnectSocket(TcpClient clientSocket)
		{
			try
			{
				if (ip == null)
					ip	=	APConfig.GetProperty("PKNO_SERVER_LIST").Split(',');
				clientSocket.Connect(ip[ipIdx], Convert.ToInt32(APConfig.GetProperty("PKNO_SERVER_PORT")));
                clientSocket.ReceiveBufferSize = 8192;
			}
			catch(SocketException ex)
			{
				switch(ex.ErrorCode)
				{
					//使用埠已經有人連接
					case 10048 :
						ConnectSocket(clientSocket);
						break;
					//無法連線，因為目標電腦拒絕連線
					case 10061 :
						if (ipIdx == ip.Length - 1)
							ipIdx	=	0;
						else
							ipIdx++;
						ConnectSocket(clientSocket);
						break;
					default:
						this.Logger.Append("errcode:" + ex.ErrorCode);
						throw;
				}
			}
		}

		private	static	Object sequenceLockObject	=	new Object();
		private	ArrayList	sequenceContent		=	new ArrayList();

		/// <summary>
		/// 取得 Table 流水號 PKNO
		/// </summary>
		/// <returns>流水號</returns>
		public string GetSequence()
		{
			
			string	result	=	"";
			
			lock(sequenceLockObject)
			{
				if (sequenceContent.Count == 0)
				{	
					TcpClient	clientSocket	=	new TcpClient();
					clientSocket.ExclusiveAddressUse	=	false;
			
					ConnectSocket(clientSocket);

					//send
					NetworkStream	serverStream	=	clientSocket.GetStream();
					byte[]		outStream	=	System.Text.Encoding.ASCII.GetBytes("0009Lpkno,100");
					serverStream.Write(outStream, 0, outStream.Length);
					serverStream.Flush();
			
					//reveive
					byte[]		inStream	=	new byte[10025];
					serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
			
					//send X
					outStream	=	System.Text.Encoding.ASCII.GetBytes("0001X");
					serverStream.Write(outStream, 0, outStream.Length);
					serverStream.Flush();

					serverStream.Close();
					clientSocket.Close();
					result	=	System.Text.Encoding.ASCII.GetString(inStream);

					if (result.Substring(4, 1).Equals("7"))
						throw new Exception(result.Substring(5));

					result	=	result.Substring(5).Substring(0, Convert.ToInt32(result.Substring(0, 4)) - 1);

					string[]	noAry	=	result.Split(',');
					foreach (string data in noAry)
					{
						if (String.IsNullOrEmpty(data))
							continue;
						sequenceContent.Add(data.Trim());
					}
				}

				result	=	sequenceContent[0].ToString();
				sequenceContent.RemoveAt(0);
			}
			return result;
			

			//DbConnection	conn	=	this.GetIConnection();
			//string		dBType	=	this.DBManager.GetDBType(conn);
			//string		sql;
                        //
			//switch(dBType)
			//{
			//	case "ORACLE":
			//		sql	=	"SELECT SEQ_" + this.SysName + ".NEXTVAL AS SNO FROM DUAL";
			//		return this.DBManager.GetDataSet(conn, sql.ToString()).Tables[0].Rows[0]["SNO"].ToString();
			//	case "ORACLE11":
			//		sql	=	"SELECT SEQ_" + this.SysName + ".NEXTVAL AS SNO FROM DUAL";
			//		return this.DBManager.GetDataSet(conn, sql.ToString()).Tables[0].Rows[0]["SNO"].ToString();
			//	case "SQL2005":
			//		lock(sequenceLockObject)
			//		{
			//			sql	=	"SELECT ISNULL(MAX(PKNO), 0) + 1 AS SNO FROM " + this.TableName;
			//			return this.DBManager.GetDataSet(conn, sql.ToString()).Tables[0].Rows[0]["SNO"].ToString();
			//		}
			//	default:
			//		throw new NotSupportedException("此方法目前不支援此資料庫 : " + dBType);
			//}
		}

		/// <summary>
		/// 執行大量新增動作
		/// </summary>
		public virtual void DoBatchInsert()
		{
			this.realAction	=	true;

			StringBuilder	sql	=	new StringBuilder();

			for (int i = 0; i < this.batchCommand.Count; i++)
			{
				if (i != 0 && i % this.BatchExecuteSize == 0)
				{
					sql.Append("; END;");
					this.Execute(sql.ToString());
					sql.Length	=	0;
				}

				if (sql.Length > 0)
					sql.Append(";");
				else
					sql.Append("BEGIN ");

				sql.Append(this.batchCommand[i].ToString());
			}

			if (sql.Length > 0)
			{
				sql.Append("; END;");
				this.Execute(sql.ToString());
			}
		}
 
		/// <summary>
		/// 處理大量新增動作
		/// </summary>
		public virtual void AddInsert()
		{
			this.realAction	=	false;
			this.Insert();
			this.batchCommand.Add(this.ExecuteSQL);
			this.realAction	=	true;
		}

		/// <summary>
		/// SQL Server 大量新增
		/// </summary>
		public virtual void BatchInsert(DataTable dt)
		{
            //Brian Modify
            if(string.IsNullOrEmpty(dt.TableName))
    			dt.TableName	=	this.TableName;

			Timer	timer	=	new Timer();
            dt.Columns.Add("PKNO");
			dt.Columns.Add("ROWSTAMP");
			dt.Columns.Add("CREATE_TIME", Type.GetType("System.DateTime"));
			dt.Columns.Add("CREATE_USER");
			dt.Columns.Add("UPDATE_TIME", Type.GetType("System.DateTime"));
			dt.Columns.Add("UPDATE_USER");
			
			foreach (DataRow dr in dt.Rows)
			{
				string[]	encodeColumns	=	APConfig.GetProperty("ENCODE_COLUMN").Split(',');
				string[]	encodeTypes	=	APConfig.GetProperty("ENCODE_TYPE").Split(',');

				for (int i = 0; i < encodeColumns.Length; i++)
				{	
					if (encodeTypes[i].Equals("1") && dt.Columns.Contains(encodeColumns[i].Replace(" ", "")))
					{
						if (!string.IsNullOrEmpty(dr[encodeColumns[i].Replace(" ", "")].ToString()))
							dr[encodeColumns[i].Replace(" ", "")]	=	Utility.TripleDesEncrypt(dr[encodeColumns[i].Replace(" ", "")].ToString());
						else
							dr[encodeColumns[i].Replace(" ", "")]	=	"";
					}
				}

                dr["PKNO"] = this.GetSequence();
				dr["CREATE_USER"]	=	Utility.DBStr(this.CurrentUserId);
				dr["CREATE_TIME"]	=	System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
				dr["UPDATE_USER"]	=	Utility.DBStr(this.CurrentUserId);
				dr["UPDATE_TIME"]	=	System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
				dr["ROWSTAMP"]		=	DateUtil.GetNowTimeMS();
			}

			StringBuilder	columnBuff	=	new StringBuilder();
			for (int i = 0; i < dt.Columns.Count; i++)
			{
				columnBuff.Append("," + dt.Columns[i].ColumnName);
			}
			columnBuff.Remove(0, 1);

			if (this.Logger.IsLog)
			{
				this.Logger.Append("TableName:" + dt.TableName + ", ColumnName:" + columnBuff.ToString());
				if (Utility.NullToSpace(APConfig.GetProperty("SHOW_TRACE_LOG")).Equals("Y"))
				{
					StringBuilder	data	=	new StringBuilder();
					if (dt != null && dt.Rows.Count > 0)
					{
						foreach (DataRow dr in dt.Rows)
						{
							for (int i = 0; i < dt.Columns.Count; i++)
								data.Append("," + dr[dt.Columns[i].ColumnName].ToString());
							data.Append("\r\n");
						}
						this.Logger.Append("Data:" + data.Remove(0, 1).ToString());
					}
					else
						this.Logger.Append("No Data");
				}
				this.Logger.Append("EntityBase-BatchInsert dt 準備時間：" + timer.GetDiffTime() + "ms, 筆數:" + dt.Rows.Count);
			}
			
			DbConnection	conn	=	this.GetIConnection();
			DBAccess	dba	=	this.DBManager.GetDBAccess(conn);
			dba.SqlBulryInsert(dt);
		}

		/// <summary>
		/// 處理新增資料動作
		/// </summary>
		public virtual string Insert()
		{
			DbConnection	conn	=	this.GetIConnection();
			DBAccess	dba	=	this.DBManager.GetDBAccess(conn);
			dba.Hint	=	this.Hint;
			string		result	=	"";
			
			//=== 處理新增動作 ===
			dba.SetTableName(this.TableName);

			//=== 共通欄位 ===
			if (!this.NotContainPKNO)
			{
				if (this.IsManualPKNO)
					result	=	this.PKNO;
				else
					result	=	this.GetSequence();
				
				if (!string.IsNullOrEmpty(this.FUNCTION_FIELD) && ("," + this.FUNCTION_FIELD + ",").IndexOf(",PKNO,") != -1)
					dba.SetColumn("PKNO", result, true);
				else
					dba.SetColumn("PKNO", result);
			}
			dba.SetColumn("CREATE_USER",	Utility.DBStr(this.CurrentUserId));
			dba.SetColumn("CREATE_TIME",	System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
			dba.SetColumn("UPDATE_USER",	Utility.DBStr(this.CurrentUserId));
			dba.SetColumn("UPDATE_TIME",	System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
			dba.SetColumn("ROWSTAMP",	DateUtil.GetNowTimeMS());

			//=== 設定欄位 ===
			string	columnData	=	null;
			foreach (string key in this.pColumnMap.Keys)
			{
				if (this.pColumnMap[key] == null)
					this.Logger.Append("KEY NULL --> " + key);
				else
				{
					columnData	=	(string)this.pColumnMap[key];

					//資料加密
					string[]	encodeColumns	=	APConfig.GetProperty("ENCODE_COLUMN").Split(',');
					string[]	encodeTypes	=	APConfig.GetProperty("ENCODE_TYPE").Split(',');
					bool		needEncrypt	=	false;

					for (int i = 0; i < encodeColumns.Length; i++)
					{	
						if (encodeTypes[i].Equals("1") && key.ToUpper().Equals(encodeColumns[i].Replace(" ", "").ToUpper()))
						{
							needEncrypt	=	true;
							break;
						}
					}

					if (needEncrypt)
					{
						if (!string.IsNullOrEmpty(columnData))
							columnData	=	Utility.TripleDesEncrypt(columnData);
						else
							columnData	=	"";
					}

					//=== 當為長字串時處理 ===
					if (!string.IsNullOrEmpty(this.LONG_FIELD_NAME) && ("," + this.LONG_FIELD_NAME + ",").IndexOf("," + key + ",") != -1)
					{
						this.Logger.Append("Long field -->" + key);
						dba.SetColumn(key,	"N'" + Utility.CheckNull(columnData, "") + "'", true);
					}
					else if (!string.IsNullOrEmpty(this.FUNCTION_FIELD) && ("," + this.FUNCTION_FIELD + ",").IndexOf("," + key + ",") != -1)
						dba.SetColumn(key, Utility.CheckNull(columnData, ""), true);
					else if (!string.IsNullOrEmpty(this.SET_NULL_FIELD) && ("," + this.SET_NULL_FIELD + ",").IndexOf("," + key + ",") != -1)
					{
						if (string.IsNullOrEmpty(Utility.CheckNull(columnData, "")))
							dba.SetColumn(key, "NULL", true);
						else
							dba.SetColumn(key, Utility.CheckNull(columnData, ""));
					}	
					else
						dba.SetColumn(key, Utility.CheckNull(columnData, ""));
				}
			}
			
			dba.IsRealAction	=	this.realAction;
			dba.Insert();
			dba.IsRealAction	=	true;

			if (!this.SkipProperty)
				this.pColumnMap	=	new Hashtable (new Util.EntityColumnCompare());
			this.ExecuteSQL	=	dba.GetSql();

			return result;
		}

		/// <summary>
		/// 執行 SQL 指令
		/// </summary>
		public virtual int Execute(String sql) 
		{
			DbConnection	conn		=	this.GetIConnection();
			DBAccess	dba		=	this.DBManager.GetDBAccess(conn);
			
			//=== 條件 ===
			int	resultCount	=	dba.Execute(sql);
			this.SqlRetrictions	=	"";

			this.ExecuteSQL		=	dba.GetSql();
			return resultCount;
		}

		/// <summary>
		/// 修改資料
		/// </summary>
		public virtual int Update() 
		{
			DbConnection	conn		=	this.GetIConnection();
			DBAccess	dba		=	this.DBManager.GetDBAccess(conn);
			dba.Hint	=	this.Hint;
			int		resultCount;	

			//=== 處理修改動作 ===
			dba.SetTableName(this.TableName);

			//=== 共通欄位 ===
			//dba.SetColumn("CREATE_USER",	Utility.DBStr(this.CurrentUserId));
			//dba.SetColumn("CREATE_TIME",	System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
			dba.SetColumn("UPDATE_USER",	Utility.DBStr(this.CurrentUserId));
			dba.SetColumn("UPDATE_TIME",	System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
			dba.SetColumn("ROWSTAMP",	DateUtil.GetNowTimeMS());

			//=== 設定欄位 ===
			string	columnData	=	null;
			foreach (string key in this.pColumnMap.Keys)
			{
				if (this.pColumnMap[key] == null)
					this.Logger.Append("KEY NULL --> " + key);
				else
				{
					columnData	=	(string)this.pColumnMap[key];

					
					string[]	encodeColumns	=	APConfig.GetProperty("ENCODE_COLUMN").Split(',');
					string[]	encodeTypes	=	APConfig.GetProperty("ENCODE_TYPE").Split(',');
					bool		needEncrypt	=	false;

					for (int i = 0; i < encodeColumns.Length; i++)
					{	
						if (encodeTypes[i].Equals("1") && key.ToUpper().Equals(encodeColumns[i].Replace(" ", "").ToUpper()))
						{
							needEncrypt	=	true;
							break;
						}
					}

					if (needEncrypt)
					{
						if (!string.IsNullOrEmpty(columnData))
							columnData	=	Utility.TripleDesEncrypt(columnData);
						else
							columnData	=	"";
					}
					
					//=== 當為長字串時處理 ===
					if (!string.IsNullOrEmpty(this.LONG_FIELD_NAME) && ("," + this.LONG_FIELD_NAME + ",").IndexOf("," + key + ",") != -1)
					{
						this.Logger.Append("Long field -->" + key);
						dba.SetColumn(key,	"N'" + Utility.CheckNull(columnData, "") + "'", true);
					}
					else if (!string.IsNullOrEmpty(this.FUNCTION_FIELD) && ("," + this.FUNCTION_FIELD + ",").IndexOf("," + key + ",") != -1)
						dba.SetColumn(key, Utility.CheckNull(columnData, ""), true);
					else if (!string.IsNullOrEmpty(this.SET_NULL_FIELD) && ("," + this.SET_NULL_FIELD + ",").IndexOf("," + key + ",") != -1)
					{
						if (string.IsNullOrEmpty(Utility.CheckNull(columnData, "")))
							dba.SetColumn(key, "NULL", true);
						else
							dba.SetColumn(key, Utility.CheckNull(columnData, ""));
					}	
					else
						dba.SetColumn(key, Utility.CheckNull(columnData, ""));
				}
			}

			//=== 條件 ===
			resultCount		=	dba.Update(this.SqlRetrictions.Replace(ControlBase.aliasMark, ""));
			this.SqlRetrictions	=	"";

			if (!this.SkipProperty)
				this.pColumnMap		=	new Hashtable (new Util.EntityColumnCompare());
			this.ExecuteSQL		=	dba.GetSql();
			return resultCount;
		}

		/// <summary>
		/// 依據 PKNO 修改資料
		/// </summary>
		public virtual int UpdateByPkNo() 
		{
			this.SqlRetrictions	=	"PKNO = '" + this.PKNO + "'";
			if (!string.IsNullOrEmpty(this.ROWSTAMP))
			{
				this.SqlRetrictions	+=	" AND ROWSTAMP = '" + this.ROWSTAMP + "'";
				this.ROWSTAMP		=	"";
			}

			return this.Update();
		}

		/// <summary>g
		/// 刪除資料
		/// </summary>
 		public virtual int Delete()
		{
			DbConnection	conn		=	this.GetIConnection();
			DBAccess	dba		=	this.DBManager.GetDBAccess(conn);
			dba.Hint	=	this.Hint;
			int		resultCount;

			//=== 處理刪除動作 ===
			dba.SetTableName(this.TableName);

			resultCount		=	dba.Delete(this.SqlRetrictions.Replace(ControlBase.aliasMark, ""));

			this.SqlRetrictions	=	"";
			this.ExecuteSQL		=	dba.GetSql();

			if (!this.SkipProperty)
				this.pColumnMap		=	new Hashtable (new Util.EntityColumnCompare());

			return resultCount;
		}

		/// <summary>
		/// 依據 PKNO 刪除資料
		/// </summary>
 		public virtual int DeleteByPkNo()
		{
			this.SqlRetrictions	=	"PKNO = '" + this.PKNO + "'";
			return this.Delete();
		}

		/// <summary>
		/// 查詢資料
		/// </summary>
		/// <returns>DataTable 資料集合</returns>
		public virtual DataTable Query()
		{
			return Query(0, 0);
		}

		/// <summary>
		/// 依據 PKNO 查詢資料
		/// </summary>
		/// <returns>DataTable 資料集合</returns>
		public virtual DataTable QueryByPkNo()
		{
			StringBuilder	sql	=	new StringBuilder();
			sql.Append("PKNO = '" + this.PKNO + "'");

			if (this.ROWSTAMP != null)
				sql.Append("AND ROWSTAMP = '" + this.ROWSTAMP + "'");

			this.SqlRetrictions	=	sql.ToString();
			return Query(0, 0);
		}

		/// <summary>
		/// 查詢資料/包含分頁處理
		/// </summary>
		/// <param name="pageNo">頁次</param>
		/// <param name="pageSize">每頁尺寸</param>
		/// <returns>DataTable 資料集合</returns>
		public virtual DataTable Query(int pageNo, int pageSize)
		{
			StringBuilder	sql	=	new StringBuilder();

			if (!string.IsNullOrEmpty(this.ColumnFilter))
				sql.Append("SELECT " + this.Hint + " " + this.ColumnFilter + ", " + this.TableName + ".* FROM " + this.TableName + " M ");
			else
			{
				if (String.IsNullOrEmpty(this.SelectColumns))
					this.SelectColumns	=	"*";
				sql.Append("SELECT " + this.SelectColumns + " FROM " + this.TableName + " M ");
			}

			if (!string.IsNullOrEmpty(this.SqlRetrictions))
				sql.Append(" WHERE " + ProcessCondition(this.SqlRetrictions).Replace(ControlBase.aliasMark, ""));

			if (!string.IsNullOrEmpty(this.GroupBys))
				sql.Append(" GROUP BY " + this.GroupBys);

			if (!string.IsNullOrEmpty(this.OrderBys))
				sql.Append(" ORDER BY " + this.OrderBys);

			return this.QueryBySql(sql.ToString(), pageNo, pageSize);
		}

		/// <summary>
		/// 依據 SQL 查詢資料
		/// </summary>
		/// <param name="sql">SQL 語法</param>
		/// <returns>DataTable 資料集合</returns>
		public DataTable QueryBySql(String sql)
		{
			return this.QueryBySql(sql, 0, 0);
		}

		/// <summary>
		/// 依據 SQL 查詢資料
		/// </summary>
		/// <param name="sql">SQL 語法</param>
		/// <param name="pageNo">頁次</param>
		/// <param name="pageSize">每頁尺寸</param>
		/// <returns>DataTable 資料集合</returns>
		public DataTable QueryBySql(String sql, int pageNo, int pageSize)
		{
			DbConnection	conn		=	this.GetIConnection();
			DataTable	resultData;

			//=== 查詢 ===
			if (pageNo > 0)
			{
				resultData			=	this.DBManager.GetPageDataTable(conn, sql, pageNo, pageSize);
				this.PropertyMap["TOTALPAGE"]	=	this.DBManager.GetRowCount();
			}
			else
			{
				//=== 海大處理資料篩選動作 ===
				try
				{
					if (FormUtil.Session != null && 
						FormUtil.Session["DATA_FILTER"] != null &&
						sql.IndexOf("SELECT_VALUE") != -1)
					{
						//=== 判斷 Mode ===
						if (!
							(
								(
									sql.IndexOf("'Q'") != -1 && sql.IndexOf("FILTER_MODE") != -1 && 
									((DataTable)FormUtil.Session["DATA_FILTER"]).Select("MODE = 'Q'").Length == 0
								) ||
								(
									sql.IndexOf("'M'") != -1 && sql.IndexOf("FILTER_MODE") != -1 && 
									((DataTable)FormUtil.Session["DATA_FILTER"]).Select("MODE = 'M'").Length == 0
								)
							)
						)
						{
							//=== 取得欄位 ===
							string	column	=	this.GetSQLColumn(sql);

							//=== 取得篩選條件 ===
							string	filter	=	"";
							if (column.IndexOf(".") == -1)
								filter	=	this.GetFilterCondition(column.Split('.')[0], "");
							else
								filter	=	this.GetFilterCondition(column.Split('.')[1], column.Split('.')[0]);

							//=== 依據篩選條件設定 SQL ===
							if (!string.IsNullOrEmpty(filter))
							{
								FormUtil.Session["€" + column]	=	filter.Substring(filter.IndexOf(" IN"));

								sql	=	this.BindSQL(sql, filter, column);
							}
						}
					}
				}
				catch(System.Exception)
				{}

				resultData			=	this.DBManager.GetDataSet(conn, sql).Tables[0];
			}

			if (!this.SkipProperty)
				this.pColumnMap		=	new Hashtable (new Util.EntityColumnCompare());
			
			this.queryData		=	resultData;

			this.SqlRetrictions	=	"";
			this.ExecuteSQL		=	sql;

			//針對國防的處理(資料解密)
				string[]	encodeColumns	=	APConfig.GetProperty("ENCODE_COLUMN").Split(',');
				string[]	encodeTypes	=	APConfig.GetProperty("ENCODE_TYPE").Split(',');
				string		encodeScreen	=	APConfig.GetProperty("ENCODE_SCREEN");
				string		extendSession	=	APConfig.GetProperty("EXTEND_SESSION");
				string		decryptData	=	"";

				foreach (DataRow dr in resultData.Rows)
				{
					for (int i = 0; i < encodeColumns.Length; i++)
					{
						if (resultData.Columns.Contains(encodeColumns[i].ToUpper()))
						{
							//當例外判斷成立則不亂畫面
							if (System.Web.HttpContext.Current != null)
							{
								if (FormUtil.Session[extendSession] != null && FormUtil.Session[extendSession].Equals("Y"))
									encodeScreen	=	"N";
							}
							//當設定不亂畫面不亂畫面
							if (encodeScreen.Equals("N"))
							{
								if (encodeTypes[i].Equals("1"))
								{
									if (!string.IsNullOrEmpty(dr[encodeColumns[i]].ToString()))
										dr[encodeColumns[i]]	=	Utility.TripleDesDecrypt(dr[encodeColumns[i]].ToString());
									else
										dr[encodeColumns[i]]	=	"";
								}
							}
							else
							{
								//亂畫面規則
								switch(encodeTypes[i])
								{
									//1-A123456789 -> A120000789
									case "1":
										if (!string.IsNullOrEmpty(dr[encodeColumns[i]].ToString()))
											decryptData	=	Utility.TripleDesDecrypt(dr[encodeColumns[i]].ToString());
										else
											decryptData	=	"";
										if (!string.IsNullOrEmpty(decryptData))
										{
											if (decryptData.Length < 7)
												dr[encodeColumns[i]]	=	decryptData.Substring(0, 3).PadRight(decryptData.Length, '*');
											else
												dr[encodeColumns[i]]	=	decryptData.Substring(0, 3) + "****" + decryptData.Substring(7);
										}
										break;
									//2-66/12/31 -> 01/12/31
									case "2":
										if (!string.IsNullOrEmpty(dr[encodeColumns[i]].ToString()))
										{
											decryptData		=	Convert.ToDateTime(dr[encodeColumns[i]]).ToString("1912/MM/dd");
											dr[encodeColumns[i]]	=	Convert.ToDateTime(decryptData);
										}
										break;
								}
							}
						}
					}
				}
			return resultData;
		}

		
		private string BindSQL(string sql, string filterCondition, string column)
		{
			sql	=	sql.ToUpper();
			sql	=	sql.Substring(0, sql.IndexOf(" FROM")) + ", 1 AS \"€" + column + "\", 'Y' AS HAS_FILTERX " + sql.Substring(sql.IndexOf("FROM"));

			//=== 針對子查詢填欄位部份 ===
			if (sql.IndexOf("SUBQRY_AUT") != -1)
			{
					//因國防是 sql server order by 不能含在子查詢裡面處理
					if (sql.IndexOf("ORDER") != -1)
						sql	=	sql.Substring(0, sql.IndexOf("ORDER")) + " WHERE " + filterCondition + sql.Substring(sql.IndexOf("ORDER"));
					else
						sql	=	sql + " WHERE " + filterCondition;
				
			}
			else
			{
				if (sql.IndexOf("ORDER") != -1)
				{
					if (sql.IndexOf("WHERE") != -1)
						sql	=	sql.Substring(0, sql.IndexOf("ORDER")) + " AND " + filterCondition + sql.Substring(sql.IndexOf("ORDER"));
					else
						sql	=	sql.Substring(0, sql.IndexOf("ORDER")) + "WHERE" + filterCondition + sql.Substring(sql.IndexOf("ORDER"));
				}
				else
				{
					if (sql.IndexOf("WHERE") != -1)
						sql	=	sql + " AND " + filterCondition;
					else
						sql	=	sql + " WHERE " + filterCondition;
				}
			}
			return sql;
		}

		private String GetSQLColumn(string sql)
		{
			sql	=	sql.ToUpper();
			string	column	=	sql.Substring(0, sql.IndexOf(" AS SELECT_VALUE")).Trim();
			column	=	column.Substring(column.LastIndexOf(" ")).Trim();
			if (column.IndexOf(",") != -1)
				column	=	column.Substring(column.LastIndexOf(",") + 1).Trim();

			return column;
		}

		private string GetFilterCondition(string filterColumnName, String columnAliasName)
		{
			String	condition	=	"";

			if (FormUtil.Session["DATA_FILTER"] != null)
			{
				DataTable	dtX	=	(DataTable)FormUtil.Session["DATA_FILTER"];
				DataRow[]	dw	=	dtX.Select("DATA_FIELD_ENG = '" + filterColumnName + "'");
				string		alias	=	(columnAliasName.Equals("")) ? "": columnAliasName + ".";

				if (dw.Length > 0)
				{
					if (!dw[0]["SQL_VALUE"].ToString().Equals(""))
						condition	=	" " + alias + filterColumnName + " IN (" + dw[0]["SQL_VALUE"].ToString() + ") ";
					else
					{
						switch (dw[0]["DATA_RANGE_LABEL"].ToString().ToUpper())
						{
							case "IN":
								StringBuilder	tmp	=	new StringBuilder();
								String[]	ary	=	dw[0]["DATA_RANGE_VALUE"].ToString().Split(',');
								for (int i = 0; i < ary.Length; i++)
									tmp.Append(",'" + ary[i] + "'");

								tmp.Remove(0, 1);
								condition	=	" " + alias + filterColumnName + " IN (" + tmp.ToString() + ") ";

								break;
							default:
								condition	=	" " + alias + filterColumnName + " " + dw[0]["DATA_RANGE_LABEL"].ToString() + " '" + dw[0]["DATA_RANGE_VALUE"].ToString() + "' ";
								break;
						}
					}
				}
			}

			return condition;	
		}

		/// <summary>
		/// 取得分頁查詢總筆數
		/// </summary>
		/// <returns>總筆數</returns>
		public int TotalRowCount()
		{
			return (int)this.PropertyMap["TOTALPAGE"];
		}

		/// <summary>
		/// 設定使用者/批次執行檔使用(Insert/Updaet)
		/// </summary>
		/// <param name="userId">使用者帳號</param>
		public void SetUserId(string userId)
		{
			this.PropertyMap["USERID"]	=	userId;
		}

		/// <summary>
		/// 將回傳資料(DataTable)某索引資料設定對應至屬性上
		/// </summary>
		/// <param name="index">資料索引</param>
		public void PrepareProperty(int index)
		{
			if (this.queryData == null)
				throw new NullReferenceException("必須查詢資料再呼叫或適於建構子傳入 DataTable 結果再行處理");
			
			for (int i = 0; i < this.queryData.Columns.Count; i++)
			{
				if (Convert.IsDBNull(this.queryData.Rows[index][i]))
					this.ColumnyMap[this.queryData.Columns[i].ColumnName]	=	"";
				else
					this.ColumnyMap[this.queryData.Columns[i].ColumnName]	=	this.queryData.Rows[index][i];
			}
		}

		#region 查詢使用
		/// <summary>
		/// 組合查詢字串
		/// </summary>
		/// <param name="outputBuff">回傳的字串</param>
		/// <param name="oper">條件資訊</param>
		/// <param name="column">欄位名稱</param>
		/// <param name="var">欄位值</param>
		/// <param name="needComma">是否需要引號資料</param>
		protected void ProcessQueryCondition(StringBuilder outputBuff, string oper, string column, string var, bool needComma)
		{
			DBUtil.ProcessQueryCondition(outputBuff, oper, column, var, needComma);
		}

		/// <summary>
		/// 組合查詢字串
		/// </summary>
		/// <param name="outputBuff">回傳的字串</param>
		/// <param name="oper">條件資訊</param>
		/// <param name="column">欄位名稱</param>
		/// <param name="var">欄位值</param>
		protected void ProcessQueryCondition(StringBuilder outputBuff, string oper, string column, string var)
		{
			this.ProcessQueryCondition(outputBuff, oper, column, var, true);
		}

		/// <summary>
		/// 組合查詢字串
		/// </summary>
		/// <param name="outputBuff">回傳的字串</param>
		/// <param name="oper">條件資訊 Ex: BT,...</param>
		/// <param name="column">欄位名稱</param>
		/// <param name="var1">欄位值1</param>
		/// <param name="var2">欄位值2</param>
		protected void ProcessQueryCondition(StringBuilder outputBuff, string oper, string column, string var1, string var2)
		{
			DBUtil.ProcessQueryCondition(outputBuff, oper, column, var1, var2);
		}

		/// <summary>
		/// 處理 Or 的條件
		/// </summary>
		/// <param name="outputBuff">Me.TmpCondition</param>
		/// <param name="currCondition">tmpBuff</param>
		protected void ProcessQueryOrCondition(StringBuilder outputBuff, StringBuilder currCondition)
		{
			DBUtil.ProcessQueryOrCondition(outputBuff, currCondition);
		}
		#endregion
	#endregion
	}
}