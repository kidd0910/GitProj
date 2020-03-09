using System;
using System.Data.Common;
using System.Collections.Generic;
using System.Text;
using Acer.DB.Query;
using Acer.Log;
using System.Data;
using Acer.Util;
using Acer.Apps;

namespace Acer.DB.Query
{
	/// <summary>
	/// 處理分頁查詢功能
	/// </summary>
	public class DBPageResultSet : DBResultSet
	{
		private int		totalRowCount	=	0;
		private string		dBType		=	"";
		
		/// <summary>
		/// 建構子 - 一般由 dbManager 呼叫使用
		/// </summary>
		/// <param name="conn">DbConnection 物件</param>
		/// <param name="trans">DbTransaction 物件</param>
		/// <param name="logUtil">MyLogger 物件</param>
		/// <param name="dBType">資料庫種類</param>
		/// <param name="provider">連線種類</param>
		public DBPageResultSet(DbConnection conn, DbTransaction trans, LogUtil logUtil, string dBType, string provider) : base(conn, trans, logUtil, provider)
		{
			this.dBType	=	dBType;
		}

		/// <summary>
		/// 傳入 sql 語法及起始列, 分頁大小, 取得分頁查詢語法
		/// </summary>
		/// <param name="sql">SQL 語法</param>
		/// <param name="startRow">起始列</param>
		/// <param name="pageSize">分頁大小</param>
		/// <returns>分頁查詢 SQL 語法</returns>
		public string GetPageSqlStatement(string sql, int startRow, int pageSize)
		{
			if (startRow < 1)
				throw new ArgumentOutOfRangeException("startRow", "輸入參數必須大於 1");

			//=== 2006/12/06 修正起始筆數有誤 Bug ===
			startRow	=	(startRow - 1) * pageSize + 1;
			if (this.dBType.Equals("ORACLE") || this.dBType.Equals("ORACLE11"))
			{
				int	endRow	=	startRow + pageSize - 1;

				sql	=	"SELECT * FROM (SELECT ORATABLE.*, ROWNUM AS ORAROWNUM FROM (" + sql + ") ORATABLE) WHERE ORAROWNUM BETWEEN " + startRow + " AND " + endRow;
			}
			else if (this.dBType.Equals("MYSQL"))
				sql	=	sql + " LIMIT " + (startRow - 1) + ", " + pageSize;
			else if (this.dBType.Equals("SQL2005"))
			{
				int	endRow	=	startRow + pageSize - 1;
				string	orderBy	=	sql.Substring(sql.ToUpper().LastIndexOf("ORDER BY"));
				sql	=	sql.Replace(orderBy, "");
				sql	=	"SELECT * FROM (SELECT *, ROW_NUMBER() OVER (" + orderBy + ") AS RCOUNT FROM (" +
						sql +
						") SQL ) RSQL WHERE RCOUNT BETWEEN " + startRow + " AND " + endRow + " " + orderBy;
			}
			
			return sql;
		}

		/// <summary>
		/// 取得該查詢資料總筆數
		/// </summary>
		/// <param name="sql">一般查詢語法</param>
		/// <returns>該查詢資料總筆數的 SQL</returns>
		public string GetTotalCountSql(string sql)
		{
			if (this.dBType.Equals("ORACLE") || this.dBType.Equals("ORACLE11") || this.dBType.Equals("INFORMIX"))
				sql	=	"SELECT COUNT(*) FROM (" + sql + ")";
			else if (this.dBType.Equals("SQL2005") || this.dBType.Equals("SYBASE") ||  this.dBType.Equals("MSSQL"))
			{
				if (sql.ToUpper().IndexOf("ORDER BY") == -1)
					throw new Exception("SQL 必須包含 Order By 條件");
				string	orderBy	=	sql.Substring(sql.ToUpper().LastIndexOf("ORDER BY"));

				sql	=	sql.Replace(orderBy, "");
				
				sql	=	"SELECT COUNT(*) FROM (" + sql + ") CNT_TABLE";

				if (this.dBType.Equals("SYBASE"))
				{
					try
					{
						sql	=	sql.Replace("TOP " + APConfig.GetProperty("ROW_LIMIT"), "");
					}
					catch(System.Exception)
					{}
				}
			}
			else
				sql	=	"SELECT COUNT(*) FROM (" + sql + ") CNT_TABLE";

			return sql;
		}

		/// <summary>
		/// 取得分頁的 DataTable
		/// </summary>
		/// <returns></returns>
		/// <param name="sql">SQL 語法</param>
		/// <param name="startRow">起始列</param>
		/// <param name="pageSize">分頁大小</param>
		/// <returns>分頁結果 DataTable</returns>
		public DataTable GetDataTable(string sql, int startRow, int pageSize) 
		{
			this.ExecuteQuery(sql, startRow, pageSize);
			DataTable	dt	=	new DataTable("PAGE");
			for (int i = 0; i <= this.GetColumnCount(); i++)
			{
				try{dt.Columns.Add(this.GetColumnName(i));}catch(System.Exception){}
			}

			while(this.Next())
			{
				DataRow	dr	=	dt.NewRow();
				for (int i = 0; i <= this.GetColumnCount(); i++)
				{
					try
					{
						dr[this.GetColumnName(i)]	=	this.GetString(this.GetColumnName(i));
					}
					catch(System.Exception)
					{
					}
				}
				dt.Rows.Add(dr);
			}
			base.Close();
			return dt;
		}

		/// <summary>
		/// 執行分頁查詢
		/// </summary>
		/// <param name="sql">查詢之語法</param>
		/// <param name="startRow">該分頁起始的 row number</param>
		/// <param name="pageSize">分頁大小</param>
		public void ExecuteQuery(string sql, int startRow, int pageSize) 
		{
			if (this.dBType.Equals("MSSQL") || this.dBType.Equals("INFORMIX") || this.dBType.Equals("SYBASE") || this.dBType.Equals("ACCESS"))
			{
				string	sql_cnt	=	GetTotalCountSql(sql);
				base.ExecuteQuery(sql_cnt);

				if (Next())
					this.totalRowCount	=	 GetInt(0);
				else
					this.totalRowCount	=	 0;
				base.Close();
				base.ExecuteQuery(sql);
				base.Absolute(startRow, pageSize);
			}
			//=== SQL 2005 必須先關閉 DataReader 再重新查詢 ===
			else if (this.dBType.Equals("SQL2005"))
			{
				string	sql_cnt	=	GetTotalCountSql(sql);
				base.ExecuteQuery(sql_cnt);

				if (Next())
					this.totalRowCount	=	 GetInt(0);
				else
					this.totalRowCount	=	 0;
				base.Close();

				string	newSQL	=	 GetPageSqlStatement(sql, startRow, pageSize);
				base.ExecuteQuery(newSQL);
			}
			else
			{
				string	sql_cnt	=	GetTotalCountSql(sql);
				base.ExecuteQuery(sql_cnt);

				if (Next())
					this.totalRowCount	=	 GetInt(0);
				else
					this.totalRowCount	=	 0;

				string	newSQL	=	 GetPageSqlStatement(sql, startRow, pageSize);
				base.ExecuteQuery(newSQL);
			}

			//=== 最後一個欄位為系統自動加上之rownum, 因此column rowCnt - 1 ===
			this.columnCount	=	 this.columnCount - 1;
		}

		/// <summary>
		/// 取得該查詢資料總筆數
		/// </summary>
		/// <returns>回傳總筆數</returns>
		public int GetTotalRowCount()
		{
			return this.totalRowCount;
		}
	}
}
