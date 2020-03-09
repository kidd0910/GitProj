using System;
using System.Collections.Generic;
using System.Text;
using Acer.Apps;
using Acer.DB;
using Acer.File;
using Acer.DB.Query;
using System.Data.Common;
using System.Data;
using System.Collections;
using System.Web;
using Acer.Log;
using Acer.Util;

namespace Acer.Form
{
	/// <summary>
	/// 處理表格快取的 Class
	/// </summary>
	public class CacheProcess
	{
		/// <summary>
		/// 建構子
		/// </summary>
		public CacheProcess()
		{
		}

		/// <summary>
		/// 建構子 For 舊程式用 just for call
		/// </summary>
		/// <param name="dbmanager"></param>
		public CacheProcess(DBManager dbmanager)
		{
		}

		/// <summary>
		/// 初始化快取處理 for init
		/// </summary>
		public static void InitCache()
		{
			InitCache("*");
		}

		/// <summary>
		/// 初始化快取處理 for init
		/// </summary>
		/// <param name="tableFilter">Table 篩選</param>
		public static void InitCache(string tableFilter)
		{
			InitCache(null, null, null, tableFilter);
		}

		/// <summary>
		/// 初始化快取處理 for init
		/// </summary>
		/// <param name="paramConn">連線</param>
		/// <param name="paramTrans">交易</param>
		/// <param name="paramProvider">連線提供者</param>
		/// <param name="tableFilter">Table 篩選</param>
		public static void InitCache(DbConnection paramConn, DbTransaction paramTrans, string paramProvider, string tableFilter)
		{
			MyLogger	logger		=	new MyLogger("");
			LogUtil		logUtil		=	new LogUtil("");
			DBManager	dbManager	=	new DBManager(logUtil);
			try
			{
				int		tableIndex	=	1;
				string[]	caches;
				Hashtable	cacheTableMap	=	new Hashtable();
				ArrayList	cacheTableList	=	new ArrayList();
				string		tableName	=	"";
				string		connName	=	"";
				string		columnList	=	"";
				string		condition	=	"";

				while(true)
				{
					try
					{
						caches	=	APConfig.GetProperty("CACHE_TABLE" + tableIndex).Split('|');
					}
					catch(System.Exception)
					{
						break;
					}
					connName	=	caches[0];
					tableName	=	caches[1].ToUpper();
					columnList	=	caches[2];
					condition	=	caches[3];

					//=== 紀錄 TableList ===
					cacheTableMap[tableName]	=	connName + "|" + tableName + "|" + columnList + "|" + condition;
					cacheTableList.Add(tableName);

					if (tableFilter.Equals(tableName) || tableFilter.Equals("") || tableFilter.Equals("*"))
					{
						DbConnection	conn	=	null;
						if (paramConn == null)
							conn	=	dbManager.GetIConnection(connName);
						else
							conn	=	paramConn;

						string		sql	=	"SELECT " + columnList + " FROM " + tableName;
						if (!string.IsNullOrEmpty(condition))
							sql	+=	" WHERE " + condition;
						DataTable	dt	=	null;
						if (paramConn == null)
							dt	=	dbManager.GetDataSet(conn, sql).Tables[0];
						else
							dt	=	dbManager.GetDataSet(conn, paramTrans, paramProvider, sql).Tables[0];

						//=== 塞 Cache ===
						MultiProcess.SetCrossSiteValue("CACHE_" + tableName, (Object)dt);
					}

					tableIndex++;
				}
				
				MultiProcess.SetCrossSiteValue("CACHE_TABLE", cacheTableMap);
				MultiProcess.SetCrossSiteValue("CACHE_TABLE_LIST", cacheTableList);
			}
			finally
			{
				dbManager.Close();
				logUtil.DoLog();
			}
		}

		/// <summary>
		/// 處理重載 Cache 內容動作（for 舊底層）
		/// </summary>
		/// <param name="sql">SQL</param>
		/// <param name="dbConnection">DbConnection</param>
		/// <param name="dbTransaction">DbTransaction</param>
		/// <param name="provider">provider</param>
		/// <returns></returns>
		public static void ProcessCacheForExecuteSQL(string sql, DbConnection dbConnection, DbTransaction dbTransaction, string provider)
		{
			ArrayList	cacheTableList	=	(ArrayList)Acer.Util.MultiProcess.GetCrossSiteValue("CACHE_TABLE_LIST");
			//=== 當 List 為空重新抓取 ===
			if (cacheTableList == null)
				CacheProcess.InitCache("NONO_SET_FOR_GET_EMPTY_TABLE");
			cacheTableList	=	(ArrayList)Acer.Util.MultiProcess.GetCrossSiteValue("CACHE_TABLE_LIST");

			for (int i = 0; i < cacheTableList.Count; i++)
			{
				if (sql.ToUpper().IndexOf("LOGMESSSAGE") == -1 && 
					sql.ToUpper().IndexOf(cacheTableList[i].ToString().ToUpper()) != -1)
				{
					CacheProcess.InitCache(dbConnection, dbTransaction, provider, cacheTableList[i].ToString().ToUpper());
				}
			}
		}

		/// <summary>
		/// 取得 Cache DataTable
		/// </summary>
		/// <param name="tableName">Table Name</param>
		/// <returns>DataTable</returns>
		public DataTable GetCacheData(string tableName)
		{
			DataTable	dt	=	(DataTable)MultiProcess.GetCrossSiteValue("CACHE_" + tableName);
			//=== 當未抓取到資料時重新初始化 ===
			if (dt == null)
				CacheProcess.InitCache(tableName);

			//=== 若仍未抓到資料回傳錯誤 ===
			dt	=	(DataTable)MultiProcess.GetCrossSiteValue("CACHE_" + tableName);
			if (dt == null)
				throw new Err.CacheNotSetException("Cache 未設定: Table -> " + tableName);

			return dt;
		}
	}
}
