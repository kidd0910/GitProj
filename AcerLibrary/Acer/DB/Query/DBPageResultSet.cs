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
	/// �B�z�����d�ߥ\��
	/// </summary>
	public class DBPageResultSet : DBResultSet
	{
		private int		totalRowCount	=	0;
		private string		dBType		=	"";
		
		/// <summary>
		/// �غc�l - �@��� dbManager �I�s�ϥ�
		/// </summary>
		/// <param name="conn">DbConnection ����</param>
		/// <param name="trans">DbTransaction ����</param>
		/// <param name="logUtil">MyLogger ����</param>
		/// <param name="dBType">��Ʈw����</param>
		/// <param name="provider">�s�u����</param>
		public DBPageResultSet(DbConnection conn, DbTransaction trans, LogUtil logUtil, string dBType, string provider) : base(conn, trans, logUtil, provider)
		{
			this.dBType	=	dBType;
		}

		/// <summary>
		/// �ǤJ sql �y�k�ΰ_�l�C, �����j�p, ���o�����d�߻y�k
		/// </summary>
		/// <param name="sql">SQL �y�k</param>
		/// <param name="startRow">�_�l�C</param>
		/// <param name="pageSize">�����j�p</param>
		/// <returns>�����d�� SQL �y�k</returns>
		public string GetPageSqlStatement(string sql, int startRow, int pageSize)
		{
			if (startRow < 1)
				throw new ArgumentOutOfRangeException("startRow", "��J�Ѽƥ����j�� 1");

			//=== 2006/12/06 �ץ��_�l���Ʀ��~ Bug ===
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
		/// ���o�Ӭd�߸���`����
		/// </summary>
		/// <param name="sql">�@��d�߻y�k</param>
		/// <returns>�Ӭd�߸���`���ƪ� SQL</returns>
		public string GetTotalCountSql(string sql)
		{
			if (this.dBType.Equals("ORACLE") || this.dBType.Equals("ORACLE11") || this.dBType.Equals("INFORMIX"))
				sql	=	"SELECT COUNT(*) FROM (" + sql + ")";
			else if (this.dBType.Equals("SQL2005") || this.dBType.Equals("SYBASE") ||  this.dBType.Equals("MSSQL"))
			{
				if (sql.ToUpper().IndexOf("ORDER BY") == -1)
					throw new Exception("SQL �����]�t Order By ����");
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
		/// ���o������ DataTable
		/// </summary>
		/// <returns></returns>
		/// <param name="sql">SQL �y�k</param>
		/// <param name="startRow">�_�l�C</param>
		/// <param name="pageSize">�����j�p</param>
		/// <returns>�������G DataTable</returns>
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
		/// ��������d��
		/// </summary>
		/// <param name="sql">�d�ߤ��y�k</param>
		/// <param name="startRow">�Ӥ����_�l�� row number</param>
		/// <param name="pageSize">�����j�p</param>
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
			//=== SQL 2005 ���������� DataReader �A���s�d�� ===
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

			//=== �̫�@����쬰�t�Φ۰ʥ[�W��rownum, �]��column rowCnt - 1 ===
			this.columnCount	=	 this.columnCount - 1;
		}

		/// <summary>
		/// ���o�Ӭd�߸���`����
		/// </summary>
		/// <returns>�^���`����</returns>
		public int GetTotalRowCount()
		{
			return this.totalRowCount;
		}
	}
}
