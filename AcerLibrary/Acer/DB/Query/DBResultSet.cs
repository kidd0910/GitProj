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
	/// DBResultSet 資料查詢元件
	/// </summary>
	public class DBResultSet : IDBResult
	{
	#region 屬性
		/// <summary>設定 PropertyMap 物件</summary>
		protected	Hashtable	pPropertyMap	=	new Hashtable();

		/// <summary>設定 PropertyMap 物件</summary>
		protected Hashtable PropertyMap
		{
			get{return this.pPropertyMap;}
		}

		/// <summary>設定 MyLogger 物件</summary>
		protected MyLogger Logger
		{
			get{return this.LogUtil.Logger;}
		}

		/// <summary>設定 LogUtil 物件</summary>
		protected LogUtil LogUtil
		{
			get{return (LogUtil)this.PropertyMap["LogUtil"];}
			set{this.PropertyMap["LogUtil"]	=	value;}
		}

		/// <summary>是否執行 Log 機制</summary>
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
		/// <summary>欄位總數</summary>
		protected	int		columnCount	=	0;
		/// <summary>全域的 MyLogger 物件</summary>
		private		int		pageSize	=	-1;
		private		int		pageRowPos	=	0;
		private		string		provider	=	"";

		/// <summary>
		/// 建構子 - DBManager 使用
		/// </summary>
		/// <param name="conn">DbConnection 物件</param>
		/// <param name="trans">DbTransaction 物件</param>
		/// <param name="logUtil">LogUtil 物件</param>
		/// <param name="provider">連線類型</param>
		public DBResultSet(DbConnection conn, DbTransaction trans, LogUtil logUtil, string provider)
		{
			this.trans	=	trans;
			this.LogUtil	=	logUtil;
			this.conn	=	conn;
			this.provider	=	provider;
		}

		/// <summary>
		/// 不進行記錄 Log 動作
		/// </summary>
		public void NoLog()
		{
			this.IsLog	=	false;
		}

		/// <summary>
		/// 結束查詢並關閉連線
		/// </summary>
		/// <returns>是否有出錯</returns>
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
		/// 執行查詢
		/// </summary>
		/// <param name="sql">查詢語法</param>
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
		/// 取得 DataSet
		/// </summary>
		/// <param name="sql">查詢語法</param>
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
				this.Logger.Append(System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " - 執行時間：" + (endTime - startTime).ToString() + " ms");
			
			if ((endTime - startTime) > System.Convert.ToInt32(APConfig.GetProperty("MAX_SQL_TIME")))
			{
				try
				{
					FormUtil.Application.Lock();
					System.IO.File.AppendAllText(APConfig.RealPath + @"Temp\sqltime" + System.DateTime.Now.ToString("yyyyMMdd") + ".txt", 
						System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + 
						"執行時間：" + (endTime - startTime).ToString() + " ms\r\n" + 
						sql + "\r\n=================================\r\n");
					FormUtil.Application.UnLock();
				}
				catch(Exception){}
			}
		
			return ds;
		}

		/// <summary>
		/// 取得 DataReader
		/// </summary>
		/// <param name="sql">查詢語法</param>
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
				this.Logger.Append(System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " - 執行時間：" + (endTime - startTime).ToString() + " ms");
			
			if ((endTime - startTime) > System.Convert.ToInt32(APConfig.GetProperty("MAX_SQL_TIME")))
			{
				try
				{
					FormUtil.Application.Lock();
					System.IO.File.AppendAllText(APConfig.RealPath + @"Temp\sqltime" + System.DateTime.Now.ToString("yyyyMMdd") + ".txt", 
						System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + 
						"執行時間：" + (endTime - startTime).ToString() + " ms\r\n" + 
						sql + "\r\n=================================\r\n");
					FormUtil.Application.UnLock();
				}
				catch(Exception){}
			}

			return rs;
		}

		/// <summary>
		/// 執行查詢
		/// </summary>
		/// <param name="sql">查詢語法</param>
		/// <param name="hasBinary">是否包含二進制資料型態</param>
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
					this.Logger.Append(System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " - 執行時間：" + (endTime - startTime).ToString() + " ms");
				
				if ((endTime - startTime) > System.Convert.ToInt32(APConfig.GetProperty("MAX_SQL_TIME")))
				{
					try
					{
						FormUtil.Application.Lock();
						System.IO.File.AppendAllText(APConfig.RealPath + @"Temp\sqltime" + System.DateTime.Now.ToString("yyyyMMdd") + ".txt", 
							System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + 
							"執行時間：" + (endTime - startTime).ToString() + " ms\r\n" + 
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
		/// MSSQL, Access 分頁專用, 2007/03/o4 補上
		/// </summary>
		/// <param name="cousor">起始點</param>
		/// <param name="pageSize">每頁尺寸</param>
		public void Absolute(int cousor, int pageSize) 
		{
			if (cousor < 1)
				throw new ArgumentOutOfRangeException("cousor", "參數必須大於 1");

			for (int i = 0; i < (cousor - 1) * pageSize; i++)
				Next();
			this.pageSize		=	pageSize;
			this.pageRowPos		=	0;
		}

		/// <summary>
		/// 移至下一筆
		/// </summary>
		/// <returns>true/false</returns>
		public Boolean Next()
		{
			try
			{
				//=== MSSQL, Access 分頁專用, 2007/03/o4 補上 ===
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
		/// 將結果的右邊空白去掉, 若為 Null 回傳空白字串
		/// </summary>
		/// <param name="val">處理的值</param>
		/// <returns>處理後結果</returns>
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
		/// 依欄位名稱取得欄位值
		/// </summary>
		/// <param name="columnName">欄位名稱</param>
		/// <returns>欄位值(string), 若 DBNull 則傳回空白</returns>
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
		/// 依欄位索引取得欄位值
		/// </summary>
		/// <param name="columnIndex">欄位序號, 從 0 開始</param>
		/// <returns>欄位值(string), 若 DBNull 則傳回空白</returns>
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
		/// 依欄位名稱取得欄位值
		/// </summary>
		/// <param name="columnName">欄位名稱</param>
		/// <returns>欄位值(int), 若 DBNull 則傳回 0</returns>
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
		/// 依欄位索引取得欄位值
		/// </summary>
		/// <param name="columnIndex">欄位序號, 從 0 開始</param>
		/// <returns>欄位值(int), 若 DBNull 則傳回 0</returns>
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
		/// 依欄位名稱取得欄位值
		/// </summary>
		/// <param name="columnName">欄位序號,從1開始</param>
		/// <returns>欄位值(long), 若 DBNull 則傳回 0</returns>
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
		/// 依欄位索引取得欄位值
		/// </summary>
		/// <param name="columnIndex">欄位序號, 從 0 開始</param>
		/// <returns>欄位值(int), 若 DBNull 則傳回 0</returns>
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
		/// 依欄位名稱取得欄位值
		/// </summary>
		/// <param name="columnName">欄位名稱</param>
		/// <returns>欄位值(double), 若 DBNull 則傳回 0</returns>
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
		/// 依欄位索引取得欄位值
		/// </summary>
		/// <param name="columnIndex">欄位序號, 從 0 開始</param>
		/// <returns>欄位值(double), 若 DBNull 則傳回 0</returns>
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
		/// 二進位資料輸出至 Web
		/// </summary>
		/// <param name="columnIndex">欄位序號, 從 0 開始</param>
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
		/// 將二位元資料轉成檔案
		/// </summary>
		/// <param name="columnIndex">欄位序號, 從 0 開始</param>
		/// <param name="filePath">轉存路徑</param>
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
		/// 取得欄位 Meta 資訊
		/// </summary>
		/// <returns>包含欄位資訊的 DataTable</returns>
		public DataTable GetMetaData() 
		{
			return this.rs.GetSchemaTable();
		}

		/// <summary>
		/// 依欄位索引取得欄位值
		/// </summary>
		/// <param name="columnIndex">欄位序號, 從 0 開始</param>
		/// <returns>欄位名稱</returns>
		public string GetColumnName(int columnIndex) 
		{
			return this.rs.GetName(columnIndex);
		}

		/// <summary>
		/// 取得欄位總數
		/// </summary>
		/// <returns></returns>
		public int GetColumnCount()
		{
			return this.columnCount;
		}
	}
}
