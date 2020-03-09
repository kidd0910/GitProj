using System;
using System.Collections;
using System.Text;
using Acer.DB.Query;
using System.Data.Common;
using Acer.Log;
using System.Data;
using Acer.Apps;
using Acer.DB;
using Acer.Util;
using System.Web;
using Acer.Form;
using System.IO;

namespace Acer.DB.Query
{
	/// <summary>
	/// DBResultSet ��Ƭd�ߤ���
	/// </summary>
	public class DBResultSet : IDBResult
	{
	#region �ݩ�
		/// <summary>�]�w PropertyMap ����</summary>
		protected	Hashtable	pPropertyMap	=	new Hashtable();

		/// <summary>�]�w PropertyMap ����</summary>
		protected Hashtable PropertyMap
		{
			get{return this.pPropertyMap;}
		}

		/// <summary>�]�w MyLogger ����</summary>
		protected MyLogger Logger
		{
			get{return this.LogUtil.Logger;}
		}

		/// <summary>�]�w LogUtil ����</summary>
		protected LogUtil LogUtil
		{
			get{return (LogUtil)this.PropertyMap["LogUtil"];}
			set{this.PropertyMap["LogUtil"]	=	value;}
		}

		/// <summary>�O�_���� Log ����</summary>
		private bool IsLog
		{
			get
			{
				if (this.PropertyMap["IsLog"] == null)
					return true;
				else
					return (bool)this.PropertyMap["IsLog"];
			}
			set{this.PropertyMap["IsLog"]	=	value;}
		}
	#endregion

		private		DbConnection	conn		=	null;
		private		DbTransaction	trans		=	null;
		private		DbDataReader	rs		=	null;
		private		DbCommand	cmd		=	null;
		/// <summary>����`��</summary>
		protected	int		columnCount	=	0;
		/// <summary>���쪺 MyLogger ����</summary>
		private		int		pageSize	=	-1;
		private		int		pageRowPos	=	0;
		private		string		provider	=	"";

		/// <summary>
		/// �غc�l - DBManager �ϥ�
		/// </summary>
		/// <param name="conn">DbConnection ����</param>
		/// <param name="trans">DbTransaction ����</param>
		/// <param name="logUtil">LogUtil ����</param>
		/// <param name="provider">�s�u����</param>
		public DBResultSet(DbConnection conn, DbTransaction trans, LogUtil logUtil, string provider)
		{
			this.trans	=	trans;
			this.LogUtil	=	logUtil;
			this.conn	=	conn;
			this.provider	=	provider;
		}

		/// <summary>
		/// ���i��O�� Log �ʧ@
		/// </summary>
		public void NoLog()
		{
			this.IsLog	=	false;
		}

		/// <summary>
		/// �����d�ߨ������s�u
		/// </summary>
		/// <returns>�O�_���X��</returns>
		public Boolean Close()
		{
			try
			{
				if (this.rs != null)
					this.rs.Close();
				if (this.cmd != null)
					this.cmd.Dispose();
				return true;
			}
			catch(Exception)
			{
				return false;
			}
		}

		/// <summary>
		/// ����d��
		/// </summary>
		/// <param name="sql">�d�߻y�k</param>
		public void ExecuteQuery(string sql) 
		{
			ExecuteQuery(sql, false);
		}

		private String GetPageName()
		{
			try
			{
				return "--" + System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + " " +
						FormUtil.Session["LOGIN_ACNT"].ToString() + " " + FormUtil.Session["NAME"].ToString() + " " +
						FormUtil.Request.ServerVariables["LOCAL_ADDR"].ToString() + " " + 
						FormUtil.Request.FilePath;
			}
			catch(Exception)
			{
				return "";
			}
		}

		/// <summary>
		/// ���o DataSet
		/// </summary>
		/// <param name="sql">�d�߻y�k</param>
		/// <returns>DataSet</returns>
		public DataSet GetDataSet(string sql) 
		{
			sql	=	sql + GetPageName();

			int	maxSqlLen	=	500;
			try
			{
				maxSqlLen	=	System.Convert.ToInt32(APConfig.GetProperty("MAX_SQL_LEN"));
			}
			catch(Exception)
			{
				maxSqlLen	=	500;
			}
			try
			{
				if (sql.Length > maxSqlLen)
				{
					FormUtil.Application.Lock();
					System.IO.File.AppendAllText(APConfig.RealPath + @"Temp\sqllength" +
						System.DateTime.Now.ToString("yyyyMMdd") + ".txt", 
						System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " - \r\n" + sql + 
						"\r\n=================================\r\n");
					FormUtil.Application.UnLock();
				}
			}
			catch(Exception){}

			//=== Log SQL ===
			long	startTime	=	DateUtil.GetCurrTimeMillis();
			if (this.IsLog && this.Logger.IsLog)
				this.Logger.Append(APConfig.GetProperty("SQLMARK") + sql);

			this.cmd	=	 DBFactory.GetIDBCommand(this.provider);
			this.cmd.CommandText	=	sql;
			this.cmd.Connection	=	this.conn;
			if (this.trans != null)
				this.cmd.Transaction	=	this.trans;
			
			DbDataAdapter	adpt	=	DBFactory.GetIDBDataAdapter(this.provider);
			adpt.SelectCommand	=	this.cmd;
			DataSet		ds	=	new DataSet();
			adpt.Fill(ds);

			long	endTime	=	DateUtil.GetCurrTimeMillis();
			if (this.IsLog && this.Logger.IsLog)
				this.Logger.Append(System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " - ����ɶ��G" + (endTime - startTime).ToString() + " ms");
			
			if ((endTime - startTime) > System.Convert.ToInt32(APConfig.GetProperty("MAX_SQL_TIME")))
			{
				try
				{
					FormUtil.Application.Lock();
					System.IO.File.AppendAllText(APConfig.RealPath + @"Temp\sqltime" + System.DateTime.Now.ToString("yyyyMMdd") + ".txt", 
						System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + 
						"����ɶ��G" + (endTime - startTime).ToString() + " ms\r\n" + 
						sql + "\r\n=================================\r\n");
					FormUtil.Application.UnLock();
				}
				catch(Exception){}
			}
		
			return ds;
		}

		/// <summary>
		/// ���o DataReader
		/// </summary>
		/// <param name="sql">�d�߻y�k</param>
		/// <returns>DataReader</returns>
		public DbDataReader GetDataReader(string sql) 
		{
			sql	=	sql + GetPageName();

			int	maxSqlLen	=	500;
			try
			{
				maxSqlLen	=	System.Convert.ToInt32(APConfig.GetProperty("MAX_SQL_LEN"));
			}
			catch(Exception)
			{
				maxSqlLen	=	500;
			}
			try
			{
				if (sql.Length > maxSqlLen)
				{
					FormUtil.Application.Lock();
					System.IO.File.AppendAllText(APConfig.RealPath + @"Temp\sqllength" + 
						System.DateTime.Now.ToString("yyyyMMdd") + ".txt", 
						System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " - \r\n" + sql + 
						"\r\n=================================\r\n");
					FormUtil.Application.UnLock();
				}
			}
			catch(Exception){}

			//=== Log SQL ===
			long	startTime	=	DateUtil.GetCurrTimeMillis();
			if (this.IsLog && this.Logger.IsLog)
				this.Logger.Append(APConfig.GetProperty("SQLMARK") + sql);
			this.cmd	=	DBFactory.GetIDBCommand(this.provider);
			this.cmd.CommandText	=	sql;
			this.cmd.Connection	=	this.conn;
			if (this.trans != null)
				this.cmd.Transaction	=	this.trans;
			this.rs	=	this.cmd.ExecuteReader();
			
			long	endTime	=	DateUtil.GetCurrTimeMillis();
			if (this.IsLog && this.Logger.IsLog)
				this.Logger.Append(System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " - ����ɶ��G" + (endTime - startTime).ToString() + " ms");
			
			if ((endTime - startTime) > System.Convert.ToInt32(APConfig.GetProperty("MAX_SQL_TIME")))
			{
				try
				{
					FormUtil.Application.Lock();
					System.IO.File.AppendAllText(APConfig.RealPath + @"Temp\sqltime" + System.DateTime.Now.ToString("yyyyMMdd") + ".txt", 
						System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + 
						"����ɶ��G" + (endTime - startTime).ToString() + " ms\r\n" + 
						sql + "\r\n=================================\r\n");
					FormUtil.Application.UnLock();
				}
				catch(Exception){}
			}

			return rs;
		}

		/// <summary>
		/// ����d��
		/// </summary>
		/// <param name="sql">�d�߻y�k</param>
		/// <param name="hasBinary">�O�_�]�t�G�i���ƫ��A</param>
		public void ExecuteQuery(string sql, Boolean hasBinary) 
		{
			try
			{
				sql	=	sql + GetPageName();

				int	maxSqlLen	=	500;
				try
				{
					maxSqlLen	=	System.Convert.ToInt32(APConfig.GetProperty("MAX_SQL_LEN"));
				}
				catch(Exception)
				{
					maxSqlLen	=	500;
				}
				try
				{
					if (sql.Length > maxSqlLen)
					{
						FormUtil.Application.Lock();
						System.IO.File.AppendAllText(APConfig.RealPath + @"Temp\sqllength" + 
							System.DateTime.Now.ToString("yyyyMMdd") + ".txt", 
							System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " - \r\n" + sql + 
							"\r\n=================================\r\n");
						FormUtil.Application.UnLock();
					}
				}
				catch(Exception){}

				//=== Log SQL ===
				long	startTime	=	DateUtil.GetCurrTimeMillis();
				if (this.IsLog && this.Logger.IsLog)
					this.Logger.Append(APConfig.GetProperty("SQLMARK") + sql);
				this.cmd	=	DBFactory.GetIDBCommand(this.provider);
				this.cmd.CommandText	=	sql;
				this.cmd.Connection	=	this.conn;
				if (this.trans != null)
					this.cmd.Transaction	=	this.trans;
				if (hasBinary)
					this.rs	=	this.cmd.ExecuteReader(CommandBehavior.SequentialAccess);
				else
					this.rs	=	this.cmd.ExecuteReader();
				
				long	endTime	=	DateUtil.GetCurrTimeMillis();
				if (this.IsLog && this.Logger.IsLog)
					this.Logger.Append(System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " - ����ɶ��G" + (endTime - startTime).ToString() + " ms");
				
				if ((endTime - startTime) > System.Convert.ToInt32(APConfig.GetProperty("MAX_SQL_TIME")))
				{
					try
					{
						FormUtil.Application.Lock();
						System.IO.File.AppendAllText(APConfig.RealPath + @"Temp\sqltime" + System.DateTime.Now.ToString("yyyyMMdd") + ".txt", 
							System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + 
							"����ɶ��G" + (endTime - startTime).ToString() + " ms\r\n" + 
							sql + "\r\n=================================\r\n");
						FormUtil.Application.UnLock();
					}
					catch(Exception){}
				}

				this.columnCount	=	this.rs.FieldCount;
			}
			catch (Exception)
			{
				this.Close();
				throw;
			}
		}

		/// <summary>
		/// MSSQL, Access �����M��, 2007/03/o4 �ɤW
		/// </summary>
		/// <param name="cousor">�_�l�I</param>
		/// <param name="pageSize">�C���ؤo</param>
		public void Absolute(int cousor, int pageSize) 
		{
			if (cousor < 1)
				throw new ArgumentOutOfRangeException("cousor", "�Ѽƥ����j�� 1");

			for (int i = 0; i < (cousor - 1) * pageSize; i++)
				Next();
			this.pageSize		=	pageSize;
			this.pageRowPos		=	0;
		}

		/// <summary>
		/// ���ܤU�@��
		/// </summary>
		/// <returns>true/false</returns>
		public Boolean Next()
		{
			try
			{
				//=== MSSQL, Access �����M��, 2007/03/o4 �ɤW ===
				if (this.pageSize != -1)
				{
					if (this.pageRowPos >= this.pageSize)
						return false;
						
					this.pageRowPos++;
				}

				if (this.rs.Read())
					return true;
				else
					return false;
			}
			catch (Exception)
			{
				this.Close();
				return false;
			}
		}

		/// <summary>
		/// �N���G���k��ťեh��, �Y�� Null �^�Ǫťզr��
		/// </summary>
		/// <param name="val">�B�z����</param>
		/// <returns>�B�z�ᵲ�G</returns>
		private static string Convert(Object val)
		{
			try
			{
				if (val == null)
					return "";
				else
					return Utility.RTrim(val.ToString());
			}
			catch(Exception)
			{
				return val.ToString();
			}
		}

		/// <summary>
		/// �����W�٨��o����
		/// </summary>
		/// <param name="columnName">���W��</param>
		/// <returns>����(string), �Y DBNull �h�Ǧ^�ť�</returns>
		public string GetString(string columnName) 
		{
			try
			{
				return Convert(rs[columnName]);
			}
			catch (Exception e)
			{
				this.Close();
				this.Logger.Append("Column Name : [" + columnName + "] -- " + e.ToString());
				throw;
			}
		}

		/// <summary>
		/// �������ި��o����
		/// </summary>
		/// <param name="columnIndex">���Ǹ�, �q 0 �}�l</param>
		/// <returns>����(string), �Y DBNull �h�Ǧ^�ť�</returns>
		public string GetString(int columnIndex) 
		{
			try
			{
				return Convert(rs[columnIndex]);
			}
			catch (Exception e)
			{
				this.Close();
				this.Logger.Append("Column Index : [" + columnIndex + "] -- " + e.ToString());
				throw;
			}
		}

		/// <summary>
		/// �����W�٨��o����
		/// </summary>
		/// <param name="columnName">���W��</param>
		/// <returns>����(int), �Y DBNull �h�Ǧ^ 0</returns>
		public int GetInt(string columnName) 
		{
			try
			{
				if (System.Convert.IsDBNull(rs[columnName]))
					return 0;
				else
					return System.Convert.ToInt32(rs[columnName]);
			}
			catch (Exception e)
			{
				this.Close();
				this.Logger.Append ("Column Name : [" + columnName + "] -- " + e.ToString());
				throw;
			}
		}

		/// <summary>
		/// �������ި��o����
		/// </summary>
		/// <param name="columnIndex">���Ǹ�, �q 0 �}�l</param>
		/// <returns>����(int), �Y DBNull �h�Ǧ^ 0</returns>
		public int GetInt(int columnIndex) 
		{
			try
			{
				if (System.Convert.IsDBNull(rs[columnIndex]))
					return 0;
				else
					return System.Convert.ToInt32(rs[columnIndex]);
			}
			catch (Exception e)
			{
				this.Close();
				this.Logger.Append ("Column Index : [" + columnIndex + "] -- " + e.ToString());
				throw;
			}
		}

		/// <summary>
		/// �����W�٨��o����
		/// </summary>
		/// <param name="columnName">���Ǹ�,�q1�}�l</param>
		/// <returns>����(long), �Y DBNull �h�Ǧ^ 0</returns>
		public long GetLong(string columnName) 
		{
			try
			{
				if (System.Convert.IsDBNull(rs[columnName]))
					return 0;
				else
					return System.Convert.ToInt64(rs[columnName]);
			}
			catch (Exception e)
			{
				this.Close();
				this.Logger.Append ("Column Name : [" + columnName + "] -- " + e.ToString());
				throw;
			}
		}

		/// <summary>
		/// �������ި��o����
		/// </summary>
		/// <param name="columnIndex">���Ǹ�, �q 0 �}�l</param>
		/// <returns>����(int), �Y DBNull �h�Ǧ^ 0</returns>
		public long GetLong(int columnIndex) 
		{
			try
			{
				if (System.Convert.IsDBNull(rs[columnIndex]))
					return 0;
				else
					return System.Convert.ToInt64(rs[columnIndex]);
			}
			catch (Exception e)
			{
				this.Close();
				this.Logger.Append ("Column Index : [" + columnIndex + "] -- " + e.ToString());
				throw;
			}
		}

		/// <summary>
		/// �����W�٨��o����
		/// </summary>
		/// <param name="columnName">���W��</param>
		/// <returns>����(double), �Y DBNull �h�Ǧ^ 0</returns>
		public double GetDouble(string columnName) 
		{
			try
			{
				if (System.Convert.IsDBNull(rs[columnName]))
					return 0;
				else
					return System.Convert.ToDouble(rs[columnName]);
			}
			catch (Exception e)
			{
				this.Close();
				this.Logger.Append ("Column Name : [" + columnName + "] -- " + e.ToString());
				throw;
			}
		}

		/// <summary>
		/// �������ި��o����
		/// </summary>
		/// <param name="columnIndex">���Ǹ�, �q 0 �}�l</param>
		/// <returns>����(double), �Y DBNull �h�Ǧ^ 0</returns>
		public double GetDouble(int columnIndex) 
		{
			try
			{
				if (System.Convert.IsDBNull(rs[columnIndex]))
					return 0;
				else
					return System.Convert.ToDouble(rs[columnIndex]);
			}
			catch (Exception e)
			{
				this.Close();
				this.Logger.Append ("Column Index : [" + columnIndex + "] -- " + e.ToString());
				throw;
			}
		}

		/// <summary>
		/// �G�i���ƿ�X�� Web
		/// </summary>
		/// <param name="columnIndex">���Ǹ�, �q 0 �}�l</param>
		public void BinaryToWeb(int columnIndex) 
		{
			HttpResponse	response	=	FormUtil.Response;
			long		startIndex	=	0;
			long		retval		=	0;
			int		bufferSize	=	100;
			byte[]		outByte		=	new byte[bufferSize];  

			try
			{
				startIndex	=	0;
				retval		=	rs.GetBytes(columnIndex, startIndex, outByte, 0, bufferSize);
				response.Clear();
				while (retval == bufferSize)
				{
					response.BinaryWrite(outByte);
					response.Flush();

					startIndex	+=	bufferSize;
					retval		=	rs.GetBytes(columnIndex, startIndex, outByte, 0, bufferSize);
				}
				
				response.BinaryWrite(outByte);
			}
			catch (Exception e)
			{
				this.Close();
				this.Logger.Append ("Column Index : [" + columnIndex + "] -- " + e.ToString());
				throw;
			}
		}

		/// <summary>
		/// �N�G�줸����ন�ɮ�
		/// </summary>
		/// <param name="columnIndex">���Ǹ�, �q 0 �}�l</param>
		/// <param name="filePath">��s���|</param>
		public void BinaryToFile(int columnIndex, string filePath) 
		{
			FileStream	stream		=	null;
			BinaryWriter	writer		=	null;
			long		startIndex	=	0;
			long		retval		=	0;
			int		bufferSize	=	100;
			byte[]		outByte		=	new byte[bufferSize];  

			try
			{
				stream		=	new FileStream (filePath, FileMode.OpenOrCreate, FileAccess.Write);
				writer		=	new BinaryWriter(stream);
				startIndex	=	0;
				retval		=	rs.GetBytes(columnIndex, startIndex, outByte, 0, bufferSize);

				while (retval == bufferSize)
				{
					writer.Write(outByte);
					writer.Flush();

					startIndex	+=	bufferSize;
					retval		=	rs.GetBytes(columnIndex, startIndex, outByte, 0, bufferSize);
				}
				
				writer.Write(outByte, 0, (int)retval);
				writer.Flush();
			}
			catch (Exception e)
			{
				this.Close();
				this.Logger.Append ("Column Index : [" + columnIndex + "] -- " + e.ToString());
				throw;
			}
			finally
			{
				if (writer != null)
					writer.Close();
				if (stream != null)
				{
					stream.Dispose();
				}
			}
		}

		/// <summary>
		/// ���o��� Meta ��T
		/// </summary>
		/// <returns>�]�t����T�� DataTable</returns>
		public DataTable GetMetaData() 
		{
			return this.rs.GetSchemaTable();
		}

		/// <summary>
		/// �������ި��o����
		/// </summary>
		/// <param name="columnIndex">���Ǹ�, �q 0 �}�l</param>
		/// <returns>���W��</returns>
		public string GetColumnName(int columnIndex) 
		{
			return this.rs.GetName(columnIndex);
		}

		/// <summary>
		/// ���o����`��
		/// </summary>
		/// <returns></returns>
		public int GetColumnCount()
		{
			return this.columnCount;
		}
	}
}
