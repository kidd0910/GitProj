using System;
using System.Data.Common;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Acer.DB.Query;
using Acer.Log;
using Acer.Err;
using Acer.Apps;
using Acer.Util;
using Acer.File;
using System.Collections.Specialized;
using System.Configuration;

namespace Acer.DB
{
	/// <summary>
	/// DB 相關物件管理容器, 
	/// 可取得 Connection, DBAccess, DBPageResultSet, DBResultSet, DBRowSet, SimpleResultSet 
	/// 及設定 Transaction
	/// </summary>
	public class DBManager
	{
	#region 變數宣告
		//public	static	int	connCount1	=	0;
		//public	static	int	connCount2	=	0;
		//public	static	string	cntName		=	"";
		private	ArrayList 	connectionContainer	=	new ArrayList();	
		private ArrayList	resultContainer		=	new ArrayList();
		private ArrayList	dbPageResultContainer	=	new ArrayList();
		private	int		rowCount		=	0;
	#endregion

	#region 屬性
		private	Hashtable	pPropertyMap	=	new Hashtable();

		private Hashtable PropertyMap
		{
			get{return this.pPropertyMap;}
		}

		/// <summary>設定 MyLogger 物件</summary>
		public MyLogger Logger
		{
			get{return this.LogUtil.Logger;}
		}

		/// <summary>設定 LogUtil 物件</summary>
		public LogUtil LogUtil
		{
			get{return (LogUtil)this.PropertyMap["LogUtil"];}
			set{this.PropertyMap["LogUtil"]	=	value;}
		}

		/// <summary>必須包含交易屬性</summary>
		public ArrayList MustHaveTransactions
		{
			get{return (ArrayList)this.PropertyMap["MustHaveTransactions"];}
			set{this.PropertyMap["MustHaveTransactions"]	=	value;}
		}
	#endregion

	#region 建構子
		/// <summary>
		/// Constructs, 初始化 DBManager 物件
		/// </summary>
		/// <param name="logUtil">MyLogger 物件</param>
		public DBManager(LogUtil logUtil)
		{
			this.LogUtil	=	logUtil;
		}
	#endregion

	#region 方法
		private	static object	lockDBManager	=	new object();
		#region 連線資訊
		#region Init 初始化讀取 db 連線資訊
		/// <summary>
		/// 初始化讀取 db 連線資訊 (db.conf)
		/// </summary>
		public void Init()
		{
			//2011/05/23 nono 調整, 當有設定檔時處理 
			if (!System.IO.File.Exists(FileUtil.LastSeparator(FileUtil.RootPath) + @"conf\db.conf"))
				return;

			lock(lockDBManager)
			{
				Hashtable	dbconfig	=	new Hashtable();
				this.Logger.Append(FileUtil.RootPath + @"conf\db.conf");
				ArrayList	content		=	FileUtil.ReadFile(FileUtil.RootPath + @"conf\db.conf", System.Text.Encoding.GetEncoding("BIG5"));
				string		tmpStr		=	"";

				for (int i = 0; i < content.Count; i++)
				{
					//=== 取得加密連線字串 ===
					tmpStr = Utility.DecryptTagContent(content[i].ToString());

					if (tmpStr.StartsWith("#") || tmpStr.IndexOf("=") == -1)
						continue;

					dbconfig[tmpStr.Substring(0, tmpStr.IndexOf("="))] = tmpStr.Substring(tmpStr.IndexOf("=") + 1);
				}

				MultiProcess.SetGlobalValue("DBMANAGER", dbconfig);
			}
		}

		#region GetDBConfig/GetProperty 取得設定
		private string[] GetDBConfig(string name)
		{
			//=== 當取不到回傳錯誤 ===
			if (GetProperty(name) == null)
				throw new Err.MustSetupConnectionStringException("必須設定連線資訊 " + name);
			
			return GetProperty(name);
		}

		private string[] GetProperty (string name)
		{
			//2011/05/23 nono 調整, 當有設定檔時處理 
			if (!System.IO.File.Exists(FileUtil.LastSeparator(FileUtil.RootPath) + @"conf\db.conf"))
			{
				string[]	configScu	=	null;
				string		configNameScu	=	name + "_";
			
				NameValueCollection	databaseList	=	(NameValueCollection) ConfigurationManager.GetSection("DataBaseConfig");
				for (int i = 0; i < databaseList.Count; i++)
				{
					string	key	=	databaseList.Keys[i];
					string	value	=	Utility.DecryptTagContent(databaseList[i]);

					if (key.Substring(0, key.LastIndexOf('_')).Equals(name))
					{
						if (configNameScu.Length != -1)
						{
							
							configScu	=	new string[3];
							configScu[0]	=	key.Substring(configNameScu.Length);
							configScu[1]	=	Utility.Split(value, "#")[0];
							if (value.IndexOf("#") == -1)
								configScu[2]	=	"OLEDB";
							else
								configScu[2]	=	Utility.Split(value, "#")[1];
						}
					}
				}
				return configScu;
			}

			Hashtable	dbconfig	=	(Hashtable)MultiProcess.GetGlobalValue("DBMANAGER");
			string[]	config		=	null;
			string		configName	=	name + "_";

			foreach (string key in dbconfig.Keys)
			{
				if (key.StartsWith(configName))
				{
					if (configName.Length != -1)
					{
						config		=	new string[3];
						config[0]	=	key.Substring(configName.Length);
						config[1]	=	Utility.Split(dbconfig[key].ToString(), "#")[0];
						if (dbconfig[key].ToString().IndexOf("#") == -1)
							config[2]	=	"OLEDB";
						else
							config[2]	=	Utility.Split(dbconfig[key].ToString(), "#")[1];
					}
				}
			}
			return config;
		}
		#endregion
		#endregion
		#endregion

		#region 容器相關
		#region GetConnetionFromContainer 從容器中取得連線
		private DbConnection GetConnetionFromContainer(string connName, bool manualTransaction, string transactionGroup)
		{
			DbConnection	conn	=	null;

			//=== 檢查連線是否已開啟, 抓已開啟連線 ===
			Hashtable	connHash	=	null;
			for (int i = 0; i < this.connectionContainer.Count; i++)
			{
				connHash	=	(Hashtable)this.connectionContainer[i];

				//=== 當連線名稱相同 且 交易方式相同 且 交易群組相同時直接回傳原先連線
				if (connName.Equals(connHash["ConfigName"].ToString()) &&
					manualTransaction == (bool)connHash["ManualTransaction"] &&
					transactionGroup.Equals(connHash["TransactionGroup"].ToString()))
				{
					conn	=	(DbConnection)connHash["Connection"];

					//=== 當連線狀態不為關閉時回傳先前連線 ===
					if (conn != null && conn.State != System.Data.ConnectionState.Closed)
						return (DbConnection)conn;
					break;
				}
			}
			return null;
		}
		#endregion

		#region GetProvider 連線種類
		/// <summary>
		/// 取得連線種類
		/// </summary>
		/// <param name="iConn">DbConnection 物件</param>
		/// <returns>連線種類 ODBC/OLEDB/SQLCLIENT/ORACLE</returns>
		public string GetProvider(DbConnection iConn)
		{
			Hashtable	connHash	=	GetContainerByIConnection(iConn);
			return connHash["Provider"].ToString();
		}
		#endregion

		#region GetDBType 資料庫種類
		/// <summary>
		/// 資料庫種類
		/// </summary>
		/// <param name="iConn">DbConnection 物件</param>
		/// <returns>資料庫種類 ORACLE/....</returns>
		public string GetDBType(DbConnection iConn)
		{
			Hashtable	connHash	=	GetContainerByIConnection(iConn);
			return connHash["DBType"].ToString();
		}
		#endregion

		#region GetDBTransaction 取得 DBTransaction 物件
		/// <summary>
		/// 取得 DBTransaction 物件
		/// </summary>
		/// <param name="conn">DBConnection 物件</param>
		/// <returns>DBTransaction 物件</returns>
		public DbTransaction GetDBTransaction(DbConnection conn)
		{
			Hashtable	ht	=	GetContainerByIConnection(conn);
			return (DbTransaction)ht["Transaction"];
		}
		#endregion

		#region GetContainerByIConnection 依據連線取得容器
		private Hashtable GetContainerByIConnection(DbConnection iConn)
		{
			DbConnection	conn		=	null;
			Hashtable	connHash	=	null;
			for (int i = 0; i < this.connectionContainer.Count; i++)
			{
				connHash	=	(Hashtable)this.connectionContainer[i];
				conn		=	(DbConnection)connHash["Connection"];
				if (iConn.Equals(conn))
					return connHash;
			}
			throw new Exception("容器找不到該連線!!");
		}
		#endregion
		#endregion

		#region Connection 連線相關
		#region MustHaveTransaction 設定必須包含交易
		/// <summary>
		/// 設定必須包含交易
		/// </summary>
		/// <param name="connName">要包含交易的連線名稱</param>
		public void MustHaveTransaction(string connName)
		{
			ArrayList	tmpData;
			if (this.MustHaveTransactions == null)
				tmpData	=	new ArrayList();
			else
				tmpData	=	this.MustHaveTransactions;
			tmpData.Add(connName);
			
			this.MustHaveTransactions	=	tmpData;
		}
		#endregion

		#region GetIConnection 取得 DbConnection
		private DbConnection GetIConnection(string connName, Boolean manualTransaction, string transactionGroup)
		{
			//=== 抓取現有以開啟連線 ===
			DbConnection	conn	=	this.GetConnetionFromContainer(connName, manualTransaction, transactionGroup);

			if(conn != null)
				return conn;

			//=== 當尚未連線時傳回新連線 ===
			//=== 取得連線字串 ===
			string[]	dbConfig	=	GetDBConfig(connName);
			string		dBType		=	dbConfig[0].Split('_')[dbConfig[0].Split('_').Length - 1];
			string		provider	=	dbConfig[2];
			//=== 取得新連線 ===
			conn	=	DBFactory.GetIConnection(provider);
			conn.ConnectionString	=	dbConfig[1];

			if (conn == null)
				throw new Err.GetConnectionFaileException("Connection 取得失敗!!");
			else
			{
//connCount1++;
//cntName	=	cntName + "," + Acer.Form.FormUtil.Request.FilePath;
				conn.Open();
			}

			//=== 取交易 ===
			DbTransaction	trans	=	null;
			
			//=== 當有設定必需包含交易時先取得 Transaction 處理
			if (this.MustHaveTransactions != null && 
				((ArrayList)this.MustHaveTransactions).Contains(connName) && 
				!manualTransaction)
					trans	=	conn.BeginTransaction();
			
			//=== 將連線暫存 ===
			Hashtable	ht	=	new Hashtable();
			ht["Connection"]	=	conn;			//連線物件
			ht["ManualTransaction"]	=	manualTransaction;	//手動/自動交易
			ht["TransactionGroup"]	=	transactionGroup;	//交易群組
			ht["ConfigName"]	=	connName;		//連線名稱
			ht["DBType"]		=	dBType;			//資料庫種類
			ht["Provider"]		=	provider;		//連線提供者 ODBC, OLEDB...
			if (trans != null)
			{
				ht["Transaction"]	=	trans;		//交易物件
				ht["TransactionStatus"]	=	"START";	//交易狀態
			}
			else
				ht["TransactionStatus"]	=	"NONE";		//交易狀態

			//=== 加總已起始的交易總數 ===
			DBManagerInfo.AddCount("Transaction Start");

			this.connectionContainer.Add(ht);

			//=== Oracle 改變日期呈現格式 ===
			if (GetDBType(conn).Equals("ORACLE") || GetDBType(conn).Equals("ORACLE11"))
			{
				DbCommand	dbCommand	=	DBFactory.GetIDBCommand(provider);
				dbCommand.Connection	=	conn;
				if (trans != null)
					dbCommand.Transaction	=	trans;
				dbCommand.CommandText	=	"ALTER SESSION SET NLS_DATE_FORMAT = 'yyyy/MM/dd HH24:MI:SS'";
				dbCommand.ExecuteNonQuery();
			}
			
			return conn;
		}
		#endregion

		#region GetIConnection 取得 DbConnection
		/// <summary>
		/// 取得 DbConnection
		/// </summary>
		/// <param name="connName">DB 設定名稱</param>
		/// <returns>DbConnection 物件</returns>
		public DbConnection GetIConnection(string connName)
		{
			return GetIConnection(connName, false, "");
		}
		#endregion

		#region GetIConnection 取得 DbConnection
		/// <summary>
		/// 取得 DbConnection, 其中交易由程式自行處理, 不包含在此 Container 處理
		/// </summary>
		/// <param name="connName">DB 設定名稱</param>
		/// <param name="manualTransaction">是否自行設定處理交易</param>
		/// <returns>DbConnection 物件</returns>
		public DbConnection GetIConnection(string connName, Boolean manualTransaction)
		{
			return GetIConnection(connName, manualTransaction, "");
		}
		#endregion

		#region GetIConnection 取得 DbConnection
		/// <summary>
		/// 取得 DbConnection, 並設定其交易群組名稱
		/// </summary>
		/// <param name="connName">DB 設定名稱</param>
		/// <param name="transactionGroup">交易群組名稱</param>
		/// <returns>Connection 物件</returns>
		public DbConnection GetIConnection(string connName, string transactionGroup)
		{
			return GetIConnection(connName, false, transactionGroup);
		}
		#endregion

		
		#endregion

		#region 資料物件處理
		#region GetDBAccess 取得 DBAccess 物件
		/// <summary>
		/// 取得 db 存取物件, 指定所連接之 db (如ORACLE or MSSQL), 並由由外部傳入 Connection, 指定所連接之 db
		/// </summary>
		/// <param name="conn">Connection 物件</param>
		/// <returns>DBAccess</returns>
		public DBAccess GetDBAccess(DbConnection conn)
		{
			//=== 判斷 Transaction 種類處理起始交易 ===
			DbTransaction	trans	=	null;
			DBAccess	dba	=	null;	
			Hashtable	ht	=	GetContainerByIConnection(conn);

			//=== 當已使用過 DBAccess 直接回傳原來 DBAccess 物件 ===
			if ((DBAccess)ht["DBACCESS"] != null)
				return (DBAccess)ht["DBACCESS"];

			//=== 非手動設定啟動交易 ===
			if (!ht["TransactionStatus"].ToString().Equals("START") && 
				!(bool)ht["ManualTransaction"])
			{
				trans	=	conn.BeginTransaction();

				//=== 設定狀態 ===
				ht["Transaction"]	=	trans;
				ht["TransactionStatus"]	=	"START";

				//=== 加總已起始的交易總數 ===
				DBManagerInfo.AddCount("Transaction Start");

				//=== 取得 DBAccess 物件 ===
				dba	=	 new DBAccess(conn, trans, this.LogUtil, ht["Provider"].ToString());
				ht["DBACCESS"]	=	dba;
			}
			else
			{
				//=== 取得 DBAccess 物件 ===
				dba	=	 new DBAccess(conn, this.LogUtil, ht["Provider"].ToString());
				ht["DBACCESS"]	=	dba;
			}

			//=== 加總已取得的總數 ===
			DBManagerInfo.AddCount("DBAccess");

			return dba;
		}
        #endregion

        #region GetDataSet GetDataSet 物件
        /// <summary>
        /// 取得 DataSet 查詢物件, 由外部傳入 Connection
        /// </summary>
        /// <param name="conn">Connection 物件</param>
        /// <param name="sql">SQL 指令</param>
        /// <returns>DataSet</returns>
        public DataSet GetDataSet(DbConnection conn, string sql)
        {
            IDBResult rs = this.GetResultSet(conn);

            bool isUseGuard = false;
            string sqlGuard = "";
            try
            {
                if (!string.IsNullOrEmpty(APConfig.GetProperty("IsUseGuard")))
                {
                    if (APConfig.GetProperty("IsUseGuard") == "Y")
                        isUseGuard = true;
                }
            }
            catch { }

            if (isUseGuard)
            {
                sqlGuard = GetGuardiumStartString();
                if (sqlGuard.Length > 0)
                {
                    rs.GetDataSet(sqlGuard);
                }

            }

            try
            {
                return rs.GetDataSet(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (isUseGuard)
                {
                    sqlGuard = GetGuardiumEndString();
                    rs.GetDataSet(sqlGuard);
                }
            }


        }
        #endregion

        #region GetDataSet GetDataSet 物件
        /// <summary>
        /// 取得 DataSet 查詢物件, 由外部傳入 Connection
        /// </summary>
        /// <param name="conn">Connection 物件</param>
        /// <param name="trans">DbTransaction 物件</param>
        /// <param name="provider">提供者</param>
        /// <param name="sql">SQL 指令</param>
        /// <returns>DataSet</returns>
        public DataSet GetDataSet(DbConnection conn, DbTransaction trans, string provider, string sql)
        {
            IDBResult rs = this.GetResultSet(conn, trans, provider);

            bool isUseGuard = false;
            string sqlGuard = "";
            try
            {
                if (!string.IsNullOrEmpty(APConfig.GetProperty("IsUseGuard")))
                {
                    if (APConfig.GetProperty("IsUseGuard") == "Y")
                        isUseGuard = true;
                }
            }
            catch { }

            if (isUseGuard)
            {
                sqlGuard = GetGuardiumStartString();
                if (sqlGuard.Length > 0)
                {
                    rs.GetDataSet(sqlGuard);
                }

            }

            try
            {
                return rs.GetDataSet(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (isUseGuard)
                {
                    sqlGuard = GetGuardiumEndString();
                    rs.GetDataSet(sqlGuard);
                }

            }
        }
        #endregion

        #region GetDataReader 取得 GetDataReader 物件
        /// <summary>
        /// 取得 GetDataReader 物件, 由外部傳入 Connection
        /// </summary>
        /// <param name="conn">Connection 物件</param>
        /// <param name="sql">SQL 指令</param>
        /// <returns>GetDataReader</returns>
        public DbDataReader GetDataReader(DbConnection conn, string sql)
        {
            IDBResult rs = this.GetResultSet(conn);

            bool isUseGuard = false;
            string sqlGuard = "";
            try
            {
                if (!string.IsNullOrEmpty(APConfig.GetProperty("IsUseGuard")))
                {
                    if (APConfig.GetProperty("IsUseGuard") == "Y")
                        isUseGuard = true;
                }
            }
            catch { }

            if (isUseGuard)
            {
                
                sqlGuard = GetGuardiumStartString();
                if (sqlGuard.Length > 0)
                {
                    rs.GetDataSet(sqlGuard);
                }
               
            }

            try
            {
                return rs.GetDataReader(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (isUseGuard)
                {
                   
                    sqlGuard = GetGuardiumEndString();                   
                    rs.GetDataSet(sqlGuard);
                 
                }

            }
        }
        #endregion

        #region GetResultSet 取得 IDBResult 物件
        /// <summary>
        /// 取得 IDBResult 物件, 由外部傳入 Connection
        /// </summary>
        /// <param name="conn">Connection 物件</param>
        /// <returns>IDBResult</returns>
        public IDBResult GetResultSet(DbConnection conn)
		{
			Hashtable	ht		=	GetContainerByIConnection(conn);
			DbTransaction	trans		=	(DbTransaction)ht["Transaction"];
			IDBResult	dbResult	=	new DBResultSet(conn, trans, this.LogUtil, ht["Provider"].ToString());
			this.resultContainer.Add(dbResult);
			
			//=== 加總已取得的總數 ===
			DBManagerInfo.AddCount("DBResult");

			return dbResult;
		}
		#endregion

		#region GetResultSet 取得 IDBResult 物件
		/// <summary>
		/// 取得 IDBResult 物件, 由外部傳入 Connection
		/// </summary>
		/// <param name="conn">Connection 物件</param>
		/// <param name="trans">DbTransaction 物件</param>
		/// <param name="provider">提供者</param>
		/// <returns>IDBResult</returns>
		public IDBResult GetResultSet(DbConnection conn, DbTransaction trans, string provider)
		{
			//Hashtable	ht		=	GetContainerByIConnection(conn);
			//DbTransaction	trans		=	(DbTransaction)ht["Transaction"];
			//IDBResult	dbResult	=	new DBResultSet(conn, trans, this.LogUtil, ht["Provider"].ToString());
			IDBResult	dbResult	=	new DBResultSet(conn, trans, this.LogUtil, provider);
			this.resultContainer.Add(dbResult);
			
			//=== 加總已取得的總數 ===
			//DBManagerInfo.AddCount("DBResult");

			return dbResult;
		}
        #endregion

        #region GetPageDataTable 取得分頁 DataTable
        /// <summary>
        /// 取得分頁 DataTable 物件, 由外部傳入 Connection
        /// </summary>
        /// <param name="conn">DbConnection 物件</param>
        /// <param name="sql">SQL 指令</param>
        /// <param name="startRow">開始筆數</param>
        /// <param name="pageSize">頁次</param>
        /// <returns>DataTable</returns>
        public DataTable GetPageDataTable(DbConnection conn, string sql, int startRow, int pageSize)
        {
            DBPageResultSet rs = this.GetDBPageResultSet(conn);

            bool isUseGuard = false;
            string sqlGuard = "";
            try
            {
                if (!string.IsNullOrEmpty(APConfig.GetProperty("IsUseGuard")))
                {
                    if (APConfig.GetProperty("IsUseGuard") == "Y")
                        isUseGuard = true;
                }
            }
            catch { }

            if (isUseGuard)
            {               
                sqlGuard = GetGuardiumStartString();
                if (sqlGuard.Length > 0)
                {
                    rs.GetDataSet(sqlGuard);
                }
              
            }

            try
            {
                DataTable dt = rs.GetDataTable(sql, startRow, pageSize);
                this.rowCount = rs.GetTotalRowCount();
                rs.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (isUseGuard)
                {                   
                    sqlGuard = GetGuardiumEndString();                   
                    rs.GetDataSet(sqlGuard);
                  
                }

            }
        }

        /// <summary>
        /// 取得分頁總筆數, 須和 GetPageDataTable 搭配使用
        /// </summary>
        /// <returns>分頁總筆數</returns>
        public int GetRowCount()
		{
			return this.rowCount;
		}
		#endregion

		#region GetDBPageResultSet 取得分頁查詢物件 DBPageResultSet
		/// <summary>
		/// 取得分頁查詢物件, 目前支援連線 ORACLE/SQL2005/MSSQL/DB2/INFORMIX/ACCESS/SYBASE
		/// </summary>
		/// <param name="conn">DbConnection 物件</param>
		/// <returns>DBPageResultSet</returns>
		public DBPageResultSet GetDBPageResultSet(DbConnection conn)
		{
			Hashtable	ht		=	GetContainerByIConnection(conn);
			DbTransaction	trans		=	(DbTransaction)ht["Transaction"];
			string		dBType		=	ht["DBType"].ToString();
			string		provider	=	ht["Provider"].ToString();

			//=== 取得連線 ===
			DBPageResultSet	dbPageResultSet	=	null;

			switch (dBType)
			{
				case "ORACLE":
					dbPageResultSet	=	new DBPageResultSet(conn, trans, this.LogUtil, "ORACLE", provider);
					break;
				case "ORACLE11":
					dbPageResultSet	=	new DBPageResultSet(conn, trans, this.LogUtil, "ORACLE11", provider);
					break;
				case "SQL2005":
					dbPageResultSet	=	new DBPageResultSet(conn, trans, this.LogUtil, "SQL2005", provider);
					break;
				case "MSSQL":
					dbPageResultSet	=	new DBPageResultSet(conn, trans, this.LogUtil, "MSSQL", provider);
					break;
				case "DB2":
					dbPageResultSet	=	new DBPageResultSet(conn, trans, this.LogUtil, "DB2", provider);
					break;
				case "INFORMIX":
					dbPageResultSet	=	new DBPageResultSet(conn, trans, this.LogUtil, "INFORMIX", provider);
					break;
				case "ACCESS":
					dbPageResultSet	=	new DBPageResultSet(conn, trans, this.LogUtil, "ACCESS", provider);
					break;
				case "SYBASE":
					dbPageResultSet	=	new DBPageResultSet(conn, trans, this.LogUtil, "SYBASE", provider);
					break;
				default:
					throw new Err.DataBaseNotSupportException("目前不支援此資料庫 " + dBType + "!!");
			}
			this.dbPageResultContainer.Add(dbPageResultSet);

			//=== 加總已取得的總數 ===
			DBManagerInfo.AddCount("DBPageResultSet");
			return dbPageResultSet;
		}
		#endregion

		#region Commit
		/// <summary>
		/// Commit 該交易群組的處理資料
		/// </summary>
		/// <param name="transactionGroup">交易群組名稱 </param>
		public void Commit(string transactionGroup)
		{
			Hashtable	ht	=	null;
			DbTransaction	trans	=	null;
			for (int i = 0; i < this.connectionContainer.Count; i++)
			{
				ht	=	(Hashtable)this.connectionContainer[i];
				if (ht["TransactionGroup"].ToString().Equals(transactionGroup))
				{
					if (ht["Transaction"] == null)
						continue;
					trans	=	(DbTransaction)ht["Transaction"];
					trans.Commit();
					ht["TransactionStatus"]	=	"COMMIT";
					//=== 加總已完成的總數 ===
					DBManagerInfo.AddCount("Transaction Commit");
				}
			}
		}
		
		/// <summary>
		/// Commit 未設群組的所有交易資料
		/// </summary>
		public void Commit()
		{
			this.Commit("");
		}
		#endregion

		#region Rollback
		/// <summary>
		/// Rollback  該交易群組的處理資料
		/// </summary>
		/// <param name="transactionGroup">交易群組名稱 </param>
		public void Rollback(string transactionGroup)
		{
			Hashtable	ht	=	null;
			DbTransaction	trans	=	null;
			
			for (int i = 0; i < this.connectionContainer.Count; i++)
			{
				ht	=	(Hashtable)this.connectionContainer[i];
				if (ht["TransactionGroup"].ToString().Equals(transactionGroup))
				{
					if (ht["Transaction"] == null)
						continue;
					trans	=	(DbTransaction)ht["Transaction"];
					trans.Rollback();
					ht["TransactionStatus"]	=	"ROLLBACK";

					//=== 加總已退回的總數 ===
					DBManagerInfo.AddCount("Transaction Rollback");
				}
			}
		}
		
		/// <summary>
		/// Rollback 未設群組的所有交易資料
		/// </summary>
		public void Rollback()
		{
			this.Rollback("");
		}
		#endregion

		#region Close 關閉 DBManager 中所有開啟連線及 IDBResult 連線
		/// <summary>
		/// Close 關閉 DBManager 中所有開啟連線及 IDBResult 連線
		/// </summary>
		public void Close()
		{
			this.Close("");
		}

		/// <summary>
		/// 關閉 DBManager 中該交易群組名稱連線及 IDBResult 連線
		/// <param name="transactionGroup">交易群組名稱 </param>
		/// </summary>
		public void Close(string transactionGroup)
		{
			try
			{
				Boolean		isTransactionFinish	=	true;
				Hashtable	ht			=	null;
				DbTransaction	trans			=	null;
				DbConnection	conn			=	null;
				
				//=== 檢查交易狀態 ===
				for (int i = 0; i < this.connectionContainer.Count; i++)
				{
					ht	=	(Hashtable)this.connectionContainer[i];

					if (ht["TransactionStatus"] == null)
						continue;

					// 2011/12/07 nono add 加上依據交易種類關閉連線處理
					if (!string.IsNullOrEmpty(transactionGroup) &&
						!ht["TransactionGroup"].ToString().Equals(transactionGroup))
						continue;

					//=== 尚未異動完成直接 Rollback ===
					if (ht["TransactionStatus"].ToString().Equals("START"))
					{
						//=== 2006/11/29 修正為已關閉的連線不當成錯誤處理 ===
						if (conn != null && conn.State != ConnectionState.Closed)
						{
							if (ht["TransactionGroup"].Equals(""))
								this.Logger.Append("共同連線交易未完成, 此連線所有交易已退回!!");
							else
								this.Logger.Append("連線交易群組[" + ht["TransactionGroup"] + "] 未完成, 此連線所有交易已退回!!");
							trans	=	(DbTransaction)ht["Transaction"];
							
							//=== 加總失敗的總數 ===
							DBManagerInfo.AddCount("Transaction Faile");

							isTransactionFinish	=	false;
							
							//=== 解決已關閉連線造成 DB Lock 問題 ===
							trans.Rollback();
						}
					}
				}

				// 2011/12/07 nono add 加上依據交易種類關閉連線處理
				if (string.IsNullOrEmpty(transactionGroup))
				{
					//=== 關閉 ResultSet ===
					IDBResult	dbResult	=	null;
					for (int i = 0; i < this.resultContainer.Count; i++)
					{
						dbResult	=	(IDBResult)this.resultContainer[i];
						if (dbResult != null)
						{
							dbResult.Close();
							dbResult	=	null;
						}
					}
					//=== 關閉 DBPageResultSet ===
					for (int i = 0; i < this.dbPageResultContainer.Count; i++)
					{
						dbResult	=	(IDBResult)this.dbPageResultContainer[i];
						if (dbResult != null)
						{
							dbResult.Close();
							dbResult	=	null;
						}
					}
				}

				//=== 關閉 Connection, Transaction ===
				for (int i = 0; i < this.connectionContainer.Count; i++)
				{
					ht	=	(Hashtable)this.connectionContainer[i];

					// 2011/12/07 nono add 加上依據交易種類關閉連線處理
					if (!string.IsNullOrEmpty(transactionGroup) &&
						!ht["TransactionGroup"].ToString().Equals(transactionGroup))
						continue;

					trans	=	(DbTransaction)((Hashtable)this.connectionContainer[i])["Transaction"];
					if (trans != null)
					{
						trans.Dispose();
						trans	=	null;
					}
					conn	=	(DbConnection)((Hashtable)this.connectionContainer[i])["Connection"];
					if (conn != null)
					{
						conn.Close();
						conn.Dispose();
						conn	=	null;
					}
				}

				//=== 未異動完顯示錯誤訊息 ===
				if (!isTransactionFinish)
					throw new Err.MustFinishAllTransactionThenCloseConnectionException("必須完成所有交易再關閉連線, 未完成交易已退回");
			}
			catch(Exception ex)
			{
				this.Logger.Append(ErrUtil.ErrToStr(ex));
			}
		}
        #endregion
        #endregion

        /// <summary>
        /// For NCC 使用 建立Guardium Start字串
        /// </summary>
        /// <returns></returns>
        private string GetGuardiumStartString()
        {
            //預設先用NCCEXT
            string sGuardAppEventType = APConfig.GetProperty("sGuardAppEventType");
            string sessionName = APConfig.GetProperty("VALIDE_SESSION_NAME");
            string sessionLocalIPName = APConfig.GetProperty("SESSION_LOCAL_IP_NAME");

            //HttpContext.Current
            //增加Guardium Start
            System.Web.HttpRequest request = Acer.Form.FormUtil.Request;
            System.Web.SessionState.HttpSessionState session = Form.FormUtil.Session;
            string sqlGuard = "";
            string sGuardAppEventUserName = "";  //ex:SESSION_LOGIN_NAME

            if (session == null)
            {
                return "";
            }

            if (session[sessionName] != null)
            {
                sGuardAppEventUserName = session[sessionName].ToString();
            }
            string sGuardAppEventStrValue = request.Url.AbsolutePath;  //作業 AMAT0031
            string sName = new System.Diagnostics.StackTrace(true).GetFrame(0).GetMethod().Name;
            sqlGuard = "select 'GuardAppEvent:Start'"
                + ",'GuardAppEventType:" + session[sessionLocalIPName] + "' "
                + ",'GuardAppEventUserName:" + Utility.DBStr(sGuardAppEventUserName) + "' "
                + ",'GuardAppEventStrValue:" + sGuardAppEventType + "-" + sGuardAppEventStrValue + " " + sName + "'; ";
            return sqlGuard;
        }

        /// <summary>
        /// For NCC 使用 
        /// </summary>
        /// <returns></returns>
        private string GetGuardiumEndString()
        {
            string sqlGuard = "select 'GuardAppEvent:Released'";
            return sqlGuard;
        }

        #endregion
    }
}
