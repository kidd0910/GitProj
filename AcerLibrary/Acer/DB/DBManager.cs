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
	/// DB ��������޲z�e��, 
	/// �i���o Connection, DBAccess, DBPageResultSet, DBResultSet, DBRowSet, SimpleResultSet 
	/// �γ]�w Transaction
	/// </summary>
	public class DBManager
	{
	#region �ܼƫŧi
		//public	static	int	connCount1	=	0;
		//public	static	int	connCount2	=	0;
		//public	static	string	cntName		=	"";
		private	ArrayList 	connectionContainer	=	new ArrayList();	
		private ArrayList	resultContainer		=	new ArrayList();
		private ArrayList	dbPageResultContainer	=	new ArrayList();
		private	int		rowCount		=	0;
	#endregion

	#region �ݩ�
		private	Hashtable	pPropertyMap	=	new Hashtable();

		private Hashtable PropertyMap
		{
			get{return this.pPropertyMap;}
		}

		/// <summary>�]�w MyLogger ����</summary>
		public MyLogger Logger
		{
			get{return this.LogUtil.Logger;}
		}

		/// <summary>�]�w LogUtil ����</summary>
		public LogUtil LogUtil
		{
			get{return (LogUtil)this.PropertyMap["LogUtil"];}
			set{this.PropertyMap["LogUtil"]	=	value;}
		}

		/// <summary>�����]�t����ݩ�</summary>
		public ArrayList MustHaveTransactions
		{
			get{return (ArrayList)this.PropertyMap["MustHaveTransactions"];}
			set{this.PropertyMap["MustHaveTransactions"]	=	value;}
		}
	#endregion

	#region �غc�l
		/// <summary>
		/// Constructs, ��l�� DBManager ����
		/// </summary>
		/// <param name="logUtil">MyLogger ����</param>
		public DBManager(LogUtil logUtil)
		{
			this.LogUtil	=	logUtil;
		}
	#endregion

	#region ��k
		private	static object	lockDBManager	=	new object();
		#region �s�u��T
		#region Init ��l��Ū�� db �s�u��T
		/// <summary>
		/// ��l��Ū�� db �s�u��T (db.conf)
		/// </summary>
		public void Init()
		{
			//2011/05/23 nono �վ�, ���]�w�ɮɳB�z 
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
					//=== ���o�[�K�s�u�r�� ===
					tmpStr = Utility.DecryptTagContent(content[i].ToString());

					if (tmpStr.StartsWith("#") || tmpStr.IndexOf("=") == -1)
						continue;

					dbconfig[tmpStr.Substring(0, tmpStr.IndexOf("="))] = tmpStr.Substring(tmpStr.IndexOf("=") + 1);
				}

				MultiProcess.SetGlobalValue("DBMANAGER", dbconfig);
			}
		}

		#region GetDBConfig/GetProperty ���o�]�w
		private string[] GetDBConfig(string name)
		{
			//=== �������^�ǿ��~ ===
			if (GetProperty(name) == null)
				throw new Err.MustSetupConnectionStringException("�����]�w�s�u��T " + name);
			
			return GetProperty(name);
		}

		private string[] GetProperty (string name)
		{
			//2011/05/23 nono �վ�, ���]�w�ɮɳB�z 
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

		#region �e������
		#region GetConnetionFromContainer �q�e�������o�s�u
		private DbConnection GetConnetionFromContainer(string connName, bool manualTransaction, string transactionGroup)
		{
			DbConnection	conn	=	null;

			//=== �ˬd�s�u�O�_�w�}��, ��w�}�ҳs�u ===
			Hashtable	connHash	=	null;
			for (int i = 0; i < this.connectionContainer.Count; i++)
			{
				connHash	=	(Hashtable)this.connectionContainer[i];

				//=== ��s�u�W�٬ۦP �B ����覡�ۦP �B ����s�լۦP�ɪ����^�ǭ���s�u
				if (connName.Equals(connHash["ConfigName"].ToString()) &&
					manualTransaction == (bool)connHash["ManualTransaction"] &&
					transactionGroup.Equals(connHash["TransactionGroup"].ToString()))
				{
					conn	=	(DbConnection)connHash["Connection"];

					//=== ��s�u���A���������ɦ^�ǥ��e�s�u ===
					if (conn != null && conn.State != System.Data.ConnectionState.Closed)
						return (DbConnection)conn;
					break;
				}
			}
			return null;
		}
		#endregion

		#region GetProvider �s�u����
		/// <summary>
		/// ���o�s�u����
		/// </summary>
		/// <param name="iConn">DbConnection ����</param>
		/// <returns>�s�u���� ODBC/OLEDB/SQLCLIENT/ORACLE</returns>
		public string GetProvider(DbConnection iConn)
		{
			Hashtable	connHash	=	GetContainerByIConnection(iConn);
			return connHash["Provider"].ToString();
		}
		#endregion

		#region GetDBType ��Ʈw����
		/// <summary>
		/// ��Ʈw����
		/// </summary>
		/// <param name="iConn">DbConnection ����</param>
		/// <returns>��Ʈw���� ORACLE/....</returns>
		public string GetDBType(DbConnection iConn)
		{
			Hashtable	connHash	=	GetContainerByIConnection(iConn);
			return connHash["DBType"].ToString();
		}
		#endregion

		#region GetDBTransaction ���o DBTransaction ����
		/// <summary>
		/// ���o DBTransaction ����
		/// </summary>
		/// <param name="conn">DBConnection ����</param>
		/// <returns>DBTransaction ����</returns>
		public DbTransaction GetDBTransaction(DbConnection conn)
		{
			Hashtable	ht	=	GetContainerByIConnection(conn);
			return (DbTransaction)ht["Transaction"];
		}
		#endregion

		#region GetContainerByIConnection �̾ڳs�u���o�e��
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
			throw new Exception("�e���䤣��ӳs�u!!");
		}
		#endregion
		#endregion

		#region Connection �s�u����
		#region MustHaveTransaction �]�w�����]�t���
		/// <summary>
		/// �]�w�����]�t���
		/// </summary>
		/// <param name="connName">�n�]�t������s�u�W��</param>
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

		#region GetIConnection ���o DbConnection
		private DbConnection GetIConnection(string connName, Boolean manualTransaction, string transactionGroup)
		{
			//=== ����{���H�}�ҳs�u ===
			DbConnection	conn	=	this.GetConnetionFromContainer(connName, manualTransaction, transactionGroup);

			if(conn != null)
				return conn;

			//=== ��|���s�u�ɶǦ^�s�s�u ===
			//=== ���o�s�u�r�� ===
			string[]	dbConfig	=	GetDBConfig(connName);
			string		dBType		=	dbConfig[0].Split('_')[dbConfig[0].Split('_').Length - 1];
			string		provider	=	dbConfig[2];
			//=== ���o�s�s�u ===
			conn	=	DBFactory.GetIConnection(provider);
			conn.ConnectionString	=	dbConfig[1];

			if (conn == null)
				throw new Err.GetConnectionFaileException("Connection ���o����!!");
			else
			{
//connCount1++;
//cntName	=	cntName + "," + Acer.Form.FormUtil.Request.FilePath;
				conn.Open();
			}

			//=== ����� ===
			DbTransaction	trans	=	null;
			
			//=== ���]�w���ݥ]�t����ɥ����o Transaction �B�z
			if (this.MustHaveTransactions != null && 
				((ArrayList)this.MustHaveTransactions).Contains(connName) && 
				!manualTransaction)
					trans	=	conn.BeginTransaction();
			
			//=== �N�s�u�Ȧs ===
			Hashtable	ht	=	new Hashtable();
			ht["Connection"]	=	conn;			//�s�u����
			ht["ManualTransaction"]	=	manualTransaction;	//���/�۰ʥ��
			ht["TransactionGroup"]	=	transactionGroup;	//����s��
			ht["ConfigName"]	=	connName;		//�s�u�W��
			ht["DBType"]		=	dBType;			//��Ʈw����
			ht["Provider"]		=	provider;		//�s�u���Ѫ� ODBC, OLEDB...
			if (trans != null)
			{
				ht["Transaction"]	=	trans;		//�������
				ht["TransactionStatus"]	=	"START";	//������A
			}
			else
				ht["TransactionStatus"]	=	"NONE";		//������A

			//=== �[�`�w�_�l������`�� ===
			DBManagerInfo.AddCount("Transaction Start");

			this.connectionContainer.Add(ht);

			//=== Oracle ���ܤ���e�{�榡 ===
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

		#region GetIConnection ���o DbConnection
		/// <summary>
		/// ���o DbConnection
		/// </summary>
		/// <param name="connName">DB �]�w�W��</param>
		/// <returns>DbConnection ����</returns>
		public DbConnection GetIConnection(string connName)
		{
			return GetIConnection(connName, false, "");
		}
		#endregion

		#region GetIConnection ���o DbConnection
		/// <summary>
		/// ���o DbConnection, �䤤����ѵ{���ۦ�B�z, ���]�t�b�� Container �B�z
		/// </summary>
		/// <param name="connName">DB �]�w�W��</param>
		/// <param name="manualTransaction">�O�_�ۦ�]�w�B�z���</param>
		/// <returns>DbConnection ����</returns>
		public DbConnection GetIConnection(string connName, Boolean manualTransaction)
		{
			return GetIConnection(connName, manualTransaction, "");
		}
		#endregion

		#region GetIConnection ���o DbConnection
		/// <summary>
		/// ���o DbConnection, �ó]�w�����s�զW��
		/// </summary>
		/// <param name="connName">DB �]�w�W��</param>
		/// <param name="transactionGroup">����s�զW��</param>
		/// <returns>Connection ����</returns>
		public DbConnection GetIConnection(string connName, string transactionGroup)
		{
			return GetIConnection(connName, false, transactionGroup);
		}
		#endregion

		
		#endregion

		#region ��ƪ���B�z
		#region GetDBAccess ���o DBAccess ����
		/// <summary>
		/// ���o db �s������, ���w�ҳs���� db (�pORACLE or MSSQL), �åѥѥ~���ǤJ Connection, ���w�ҳs���� db
		/// </summary>
		/// <param name="conn">Connection ����</param>
		/// <returns>DBAccess</returns>
		public DBAccess GetDBAccess(DbConnection conn)
		{
			//=== �P�_ Transaction �����B�z�_�l��� ===
			DbTransaction	trans	=	null;
			DBAccess	dba	=	null;	
			Hashtable	ht	=	GetContainerByIConnection(conn);

			//=== ��w�ϥιL DBAccess �����^�ǭ�� DBAccess ���� ===
			if ((DBAccess)ht["DBACCESS"] != null)
				return (DBAccess)ht["DBACCESS"];

			//=== �D��ʳ]�w�Ұʥ�� ===
			if (!ht["TransactionStatus"].ToString().Equals("START") && 
				!(bool)ht["ManualTransaction"])
			{
				trans	=	conn.BeginTransaction();

				//=== �]�w���A ===
				ht["Transaction"]	=	trans;
				ht["TransactionStatus"]	=	"START";

				//=== �[�`�w�_�l������`�� ===
				DBManagerInfo.AddCount("Transaction Start");

				//=== ���o DBAccess ���� ===
				dba	=	 new DBAccess(conn, trans, this.LogUtil, ht["Provider"].ToString());
				ht["DBACCESS"]	=	dba;
			}
			else
			{
				//=== ���o DBAccess ���� ===
				dba	=	 new DBAccess(conn, this.LogUtil, ht["Provider"].ToString());
				ht["DBACCESS"]	=	dba;
			}

			//=== �[�`�w���o���`�� ===
			DBManagerInfo.AddCount("DBAccess");

			return dba;
		}
        #endregion

        #region GetDataSet GetDataSet ����
        /// <summary>
        /// ���o DataSet �d�ߪ���, �ѥ~���ǤJ Connection
        /// </summary>
        /// <param name="conn">Connection ����</param>
        /// <param name="sql">SQL ���O</param>
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

        #region GetDataSet GetDataSet ����
        /// <summary>
        /// ���o DataSet �d�ߪ���, �ѥ~���ǤJ Connection
        /// </summary>
        /// <param name="conn">Connection ����</param>
        /// <param name="trans">DbTransaction ����</param>
        /// <param name="provider">���Ѫ�</param>
        /// <param name="sql">SQL ���O</param>
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

        #region GetDataReader ���o GetDataReader ����
        /// <summary>
        /// ���o GetDataReader ����, �ѥ~���ǤJ Connection
        /// </summary>
        /// <param name="conn">Connection ����</param>
        /// <param name="sql">SQL ���O</param>
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

        #region GetResultSet ���o IDBResult ����
        /// <summary>
        /// ���o IDBResult ����, �ѥ~���ǤJ Connection
        /// </summary>
        /// <param name="conn">Connection ����</param>
        /// <returns>IDBResult</returns>
        public IDBResult GetResultSet(DbConnection conn)
		{
			Hashtable	ht		=	GetContainerByIConnection(conn);
			DbTransaction	trans		=	(DbTransaction)ht["Transaction"];
			IDBResult	dbResult	=	new DBResultSet(conn, trans, this.LogUtil, ht["Provider"].ToString());
			this.resultContainer.Add(dbResult);
			
			//=== �[�`�w���o���`�� ===
			DBManagerInfo.AddCount("DBResult");

			return dbResult;
		}
		#endregion

		#region GetResultSet ���o IDBResult ����
		/// <summary>
		/// ���o IDBResult ����, �ѥ~���ǤJ Connection
		/// </summary>
		/// <param name="conn">Connection ����</param>
		/// <param name="trans">DbTransaction ����</param>
		/// <param name="provider">���Ѫ�</param>
		/// <returns>IDBResult</returns>
		public IDBResult GetResultSet(DbConnection conn, DbTransaction trans, string provider)
		{
			//Hashtable	ht		=	GetContainerByIConnection(conn);
			//DbTransaction	trans		=	(DbTransaction)ht["Transaction"];
			//IDBResult	dbResult	=	new DBResultSet(conn, trans, this.LogUtil, ht["Provider"].ToString());
			IDBResult	dbResult	=	new DBResultSet(conn, trans, this.LogUtil, provider);
			this.resultContainer.Add(dbResult);
			
			//=== �[�`�w���o���`�� ===
			//DBManagerInfo.AddCount("DBResult");

			return dbResult;
		}
        #endregion

        #region GetPageDataTable ���o���� DataTable
        /// <summary>
        /// ���o���� DataTable ����, �ѥ~���ǤJ Connection
        /// </summary>
        /// <param name="conn">DbConnection ����</param>
        /// <param name="sql">SQL ���O</param>
        /// <param name="startRow">�}�l����</param>
        /// <param name="pageSize">����</param>
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
        /// ���o�����`����, ���M GetPageDataTable �f�t�ϥ�
        /// </summary>
        /// <returns>�����`����</returns>
        public int GetRowCount()
		{
			return this.rowCount;
		}
		#endregion

		#region GetDBPageResultSet ���o�����d�ߪ��� DBPageResultSet
		/// <summary>
		/// ���o�����d�ߪ���, �ثe�䴩�s�u ORACLE/SQL2005/MSSQL/DB2/INFORMIX/ACCESS/SYBASE
		/// </summary>
		/// <param name="conn">DbConnection ����</param>
		/// <returns>DBPageResultSet</returns>
		public DBPageResultSet GetDBPageResultSet(DbConnection conn)
		{
			Hashtable	ht		=	GetContainerByIConnection(conn);
			DbTransaction	trans		=	(DbTransaction)ht["Transaction"];
			string		dBType		=	ht["DBType"].ToString();
			string		provider	=	ht["Provider"].ToString();

			//=== ���o�s�u ===
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
					throw new Err.DataBaseNotSupportException("�ثe���䴩����Ʈw " + dBType + "!!");
			}
			this.dbPageResultContainer.Add(dbPageResultSet);

			//=== �[�`�w���o���`�� ===
			DBManagerInfo.AddCount("DBPageResultSet");
			return dbPageResultSet;
		}
		#endregion

		#region Commit
		/// <summary>
		/// Commit �ӥ���s�ժ��B�z���
		/// </summary>
		/// <param name="transactionGroup">����s�զW�� </param>
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
					//=== �[�`�w�������`�� ===
					DBManagerInfo.AddCount("Transaction Commit");
				}
			}
		}
		
		/// <summary>
		/// Commit ���]�s�ժ��Ҧ�������
		/// </summary>
		public void Commit()
		{
			this.Commit("");
		}
		#endregion

		#region Rollback
		/// <summary>
		/// Rollback  �ӥ���s�ժ��B�z���
		/// </summary>
		/// <param name="transactionGroup">����s�զW�� </param>
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

					//=== �[�`�w�h�^���`�� ===
					DBManagerInfo.AddCount("Transaction Rollback");
				}
			}
		}
		
		/// <summary>
		/// Rollback ���]�s�ժ��Ҧ�������
		/// </summary>
		public void Rollback()
		{
			this.Rollback("");
		}
		#endregion

		#region Close ���� DBManager ���Ҧ��}�ҳs�u�� IDBResult �s�u
		/// <summary>
		/// Close ���� DBManager ���Ҧ��}�ҳs�u�� IDBResult �s�u
		/// </summary>
		public void Close()
		{
			this.Close("");
		}

		/// <summary>
		/// ���� DBManager ���ӥ���s�զW�ٳs�u�� IDBResult �s�u
		/// <param name="transactionGroup">����s�զW�� </param>
		/// </summary>
		public void Close(string transactionGroup)
		{
			try
			{
				Boolean		isTransactionFinish	=	true;
				Hashtable	ht			=	null;
				DbTransaction	trans			=	null;
				DbConnection	conn			=	null;
				
				//=== �ˬd������A ===
				for (int i = 0; i < this.connectionContainer.Count; i++)
				{
					ht	=	(Hashtable)this.connectionContainer[i];

					if (ht["TransactionStatus"] == null)
						continue;

					// 2011/12/07 nono add �[�W�̾ڥ�����������s�u�B�z
					if (!string.IsNullOrEmpty(transactionGroup) &&
						!ht["TransactionGroup"].ToString().Equals(transactionGroup))
						continue;

					//=== �|�����ʧ������� Rollback ===
					if (ht["TransactionStatus"].ToString().Equals("START"))
					{
						//=== 2006/11/29 �ץ����w�������s�u�������~�B�z ===
						if (conn != null && conn.State != ConnectionState.Closed)
						{
							if (ht["TransactionGroup"].Equals(""))
								this.Logger.Append("�@�P�s�u���������, ���s�u�Ҧ�����w�h�^!!");
							else
								this.Logger.Append("�s�u����s��[" + ht["TransactionGroup"] + "] ������, ���s�u�Ҧ�����w�h�^!!");
							trans	=	(DbTransaction)ht["Transaction"];
							
							//=== �[�`���Ѫ��`�� ===
							DBManagerInfo.AddCount("Transaction Faile");

							isTransactionFinish	=	false;
							
							//=== �ѨM�w�����s�u�y�� DB Lock ���D ===
							trans.Rollback();
						}
					}
				}

				// 2011/12/07 nono add �[�W�̾ڥ�����������s�u�B�z
				if (string.IsNullOrEmpty(transactionGroup))
				{
					//=== ���� ResultSet ===
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
					//=== ���� DBPageResultSet ===
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

				//=== ���� Connection, Transaction ===
				for (int i = 0; i < this.connectionContainer.Count; i++)
				{
					ht	=	(Hashtable)this.connectionContainer[i];

					// 2011/12/07 nono add �[�W�̾ڥ�����������s�u�B�z
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

				//=== �����ʧ���ܿ��~�T�� ===
				if (!isTransactionFinish)
					throw new Err.MustFinishAllTransactionThenCloseConnectionException("���������Ҧ�����A�����s�u, ����������w�h�^");
			}
			catch(Exception ex)
			{
				this.Logger.Append(ErrUtil.ErrToStr(ex));
			}
		}
        #endregion
        #endregion

        /// <summary>
        /// For NCC �ϥ� �إ�Guardium Start�r��
        /// </summary>
        /// <returns></returns>
        private string GetGuardiumStartString()
        {
            //�w�]����NCCEXT
            string sGuardAppEventType = APConfig.GetProperty("sGuardAppEventType");
            string sessionName = APConfig.GetProperty("VALIDE_SESSION_NAME");
            string sessionLocalIPName = APConfig.GetProperty("SESSION_LOCAL_IP_NAME");

            //HttpContext.Current
            //�W�[Guardium Start
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
            string sGuardAppEventStrValue = request.Url.AbsolutePath;  //�@�~ AMAT0031
            string sName = new System.Diagnostics.StackTrace(true).GetFrame(0).GetMethod().Name;
            sqlGuard = "select 'GuardAppEvent:Start'"
                + ",'GuardAppEventType:" + session[sessionLocalIPName] + "' "
                + ",'GuardAppEventUserName:" + Utility.DBStr(sGuardAppEventUserName) + "' "
                + ",'GuardAppEventStrValue:" + sGuardAppEventType + "-" + sGuardAppEventStrValue + " " + sName + "'; ";
            return sqlGuard;
        }

        /// <summary>
        /// For NCC �ϥ� 
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
