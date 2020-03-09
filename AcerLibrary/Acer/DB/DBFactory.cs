using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;

namespace Acer.DB
{
	/// <summary>
	/// ���o��Ʈw���󤶭�, Connection, Command, DataAdapter, CommandBuilder
	/// </summary>
	public static class DBFactory
	{

#region GetIConnection ���o Connection ����
		/// <summary>
		/// ���o Connection ����, �w�]�� OleDbConnection 
		/// </summary>
		/// <param name="provider">�s�u���� ODBC/OLEDB/SQLCLIENT/ORACLE</param>
		/// <returns>DbConnection</returns>
		public static DbConnection GetIConnection(string provider)
		{
			DbConnection	iConn;
			if (string.Compare(provider, "ODBC", true) == 0)
				iConn	=	new OdbcConnection();
			else if (string.Compare(provider, "OLEDB", true) == 0)
				iConn	=	new OleDbConnection();
			else if (string.Compare(provider, "SQLCLIENT", true) == 0)
				iConn	=	new SqlConnection();
			else if (string.Compare(provider, "ORACLE", true) == 0)
				iConn	=	new OracleConnection();
			//else if (string.Compare(provider, "ORACLE11", true) == 0)
			//        iConn	=	new Oracle.DataAccess.Client.OracleConnection();
			else
				iConn	=	new OleDbConnection();
			
			return iConn;
		}
#endregion

#region GetIDBCommand ���o Command ����
		/// <summary>
		/// ���o Command ����, �w�]�� OleDbCommand 
		/// </summary>
		/// <param name="provider">�s�u���� ODBC/OLEDB/SQLCLIENT/ORACLE</param>
		/// <returns>DbCommand</returns>
		public static DbCommand GetIDBCommand(string provider)
		{
			DbCommand	iDBCommand;
			if (string.Compare(provider, "ODBC", true) == 0)
				iDBCommand	=	new OdbcCommand();
			else if (string.Compare(provider, "OLEDB", true) == 0)
				iDBCommand	=	new OleDbCommand();
			else if (string.Compare(provider, "SQLCLIENT", true) == 0)
				iDBCommand	=	new SqlCommand();
			else if (string.Compare(provider, "ORACLE", true) == 0)
				iDBCommand	=	new OracleCommand();
			//else if (string.Compare(provider, "ORACLE11", true) == 0)
			//        iDBCommand	=	new Oracle.DataAccess.Client.OracleCommand();
			else
				iDBCommand	=	new OleDbCommand();
			
			return iDBCommand;
		}
#endregion

#region GetIDbDataAdapter ���o DbDataAdapter ����
		/// <summary>
		/// ���o DbDataAdapter ����, �w�]�� OleDbDataAdapter
		/// </summary>
		/// <param name="provider">�s�u���� ODBC/OLEDB/SQLCLIENT/ORACLE</param>
		/// <returns>DbDataAdapter</returns>
		public static DbDataAdapter GetIDBDataAdapter(string provider)
		{
			DbDataAdapter	iDBDataAdapter;
			if (string.Compare(provider, "ODBC", true) == 0)
				iDBDataAdapter	=	new OdbcDataAdapter();
			else if (string.Compare(provider, "OLEDB", true) == 0)
				iDBDataAdapter	=	new OleDbDataAdapter();
			else if (string.Compare(provider, "SQLCLIENT", true) == 0)
				iDBDataAdapter	=	new SqlDataAdapter();
			else if (string.Compare(provider, "ORACLE", true) == 0)
				iDBDataAdapter	=	new OracleDataAdapter();
			//else if (string.Compare(provider, "ORACLE11", true) == 0)
			//        iDBDataAdapter	=	new Oracle.DataAccess.Client.OracleDataAdapter();
			else
				iDBDataAdapter	=	new OleDbDataAdapter();
			
			return iDBDataAdapter;
		}
#endregion

#region DbCommandBuilder ���o DbCommandBuilder ����
		/// <summary>
		/// ���o DbCommandBuilder ����, �w�]�� OracleCommandBuilder
		/// </summary>
		/// <param name="provider">�s�u���� ODBC/OLEDB/SQLCLIENT/ORACLE</param>
		/// <returns></returns>
		public static DbCommandBuilder GetIDBCommandBuilder(string provider)
		{
			DbCommandBuilder	iDBCommandBuilder;
			if (string.Compare(provider, "ODBC", true) == 0)
				iDBCommandBuilder	=	new OdbcCommandBuilder();
			else if (string.Compare(provider, "OLEDB", true) == 0)
				iDBCommandBuilder	=	new OleDbCommandBuilder();
			else if (string.Compare(provider, "SQLCLIENT", true) == 0)
				iDBCommandBuilder	=	new SqlCommandBuilder();
			else if (string.Compare(provider, "ORACLE", true) == 0)
				iDBCommandBuilder	=	new OracleCommandBuilder();
			//else if (string.Compare(provider, "ORACLE11", true) == 0)
			//        iDBCommandBuilder	=	new Oracle.DataAccess.Client.OracleCommandBuilder();
			else
				iDBCommandBuilder	=	new OracleCommandBuilder();
			
			return iDBCommandBuilder;
		}
#endregion
	}
}
