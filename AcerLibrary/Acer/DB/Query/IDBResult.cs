using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Text;

namespace Acer.DB.Query
{
	/// <summary>
	/// db 查詢物件介面
	/// </summary>
	public interface IDBResult
	{
		/// <summary>
		/// 不進行記錄 Log 動作
		/// </summary>
		void NoLog();

		/// <summary>
		/// 結束查詢並關閉連線
		/// </summary>
		/// <returns>True/False</returns>
		Boolean Close();

		/// <summary>
		/// 執行查詢
		/// </summary>
		/// <param name="sql">查詢語法</param>
		void ExecuteQuery(string sql);

		/// <summary>
		/// 取得 DataSet
		/// </summary>
		/// <param name="sql">查詢語法</param>
		/// <returns>DataSet</returns>
		DataSet GetDataSet(string sql);

		/// <summary>
		/// 取得 DataReader
		/// </summary>
		/// <param name="sql">查詢語法</param>
		/// <returns>DataReader</returns>
		DbDataReader GetDataReader(string sql);

		/// <summary>
		/// 執行查詢
		/// </summary>
		/// <param name="sql">查詢語法</param>
		/// <param name="hasBinary">是否包含二進制資料型態</param>
		void ExecuteQuery(string sql, Boolean hasBinary);

		/// <summary>
		/// 取得欄位數目
		/// </summary>
		/// <returns>欄位數目</returns>
		int GetColumnCount();

		/// <summary>
		/// 移至下一筆
		/// </summary>
		/// <returns>true/false</returns>
		Boolean Next();

		/// <summary>
		/// 依欄位名稱取得欄位值
		/// </summary>
		/// <param name="columnName">欄位名稱</param>
		/// <returns>欄位值(string), 若 DBNull 則傳回空白</returns>
		string GetString(string columnName);

		/// <summary>
		/// 依欄位索引取得欄位值
		/// </summary>
		/// <param name="columnIndex">欄位序號, 從 0 開始</param>
		/// <returns>欄位值(string), 若 DBNull 則傳回空白</returns>
		string GetString(int columnIndex);

		/// <summary>
		/// 依欄位名稱取得欄位值
		/// </summary>
		/// <param name="columnName">欄位名稱</param>
		/// <returns>欄位值(int), 若 DBNull 則傳回 0</returns>
		int GetInt(string columnName);

		/// <summary>
		/// 依欄位索引取得欄位值
		/// </summary>
		/// <param name="columnIndex">欄位序號, 從 0 開始</param>
		/// <returns>欄位值(int), 若 DBNull 則傳回 0</returns>
		int GetInt(int columnIndex);

		/// <summary>
		/// 依欄位名稱取得欄位值
		/// </summary>
		/// <param name="columnName">欄位序號,從1開始</param>
		/// <returns>欄位值(long), 若 DBNull 則傳回 0</returns>
		long GetLong(string columnName);

		/// <summary>
		/// 依欄位索引取得欄位值
		/// </summary>
		/// <param name="columnIndex">欄位序號, 從 0 開始</param>
		/// <returns>欄位值(int), 若 DBNull 則傳回 0</returns>
		long GetLong(int columnIndex);

		/// <summary>
		/// 依欄位名稱取得欄位值
		/// </summary>
		/// <param name="columnName">欄位名稱</param>
		/// <returns>欄位值(double), 若 DBNull 則傳回 0</returns>
		double GetDouble(string columnName);

		/// <summary>
		/// 依欄位索引取得欄位值
		/// </summary>
		/// <param name="columnIndex">欄位序號, 從 0 開始</param>
		/// <returns>欄位值(double), 若 DBNull 則傳回 0</returns>
		double GetDouble(int columnIndex);
		
		/// <summary>
		/// 依欄位索引取得欄位值
		/// </summary>
		/// <param name="columnIndex">欄位序號, 從 0 開始</param>
		/// <returns>欄位名稱</returns>
		string GetColumnName(int columnIndex);

		/// <summary>
		/// 將二位元資料轉成檔案
		/// </summary>
		/// <param name="columnIndex">欄位序號, 從 0 開始</param>
		/// <param name="filePath">轉存路徑</param>
		void BinaryToFile(int columnIndex, string filePath);

		/// <summary>
		/// 二進位資料輸出至 Web
		/// </summary>
		/// <param name="columnIndex">欄位序號, 從 0 開始</param>
		void BinaryToWeb(int columnIndex);
	}
}
