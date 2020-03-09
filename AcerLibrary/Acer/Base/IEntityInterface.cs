using System.Data;

namespace Acer.Base
{
	/// <summary>
	/// Entity 介面 
	/// </summary>
	public interface IEntityInterface
	{
		/// <summary>
		/// 設定處理交易方式
		/// </summary>
		/// <param name="manualTransaction">是否自行設定處理交易</param>
		void SetTransactionMode(bool manualTransaction);

		/// <summary>
		/// 設定處理交易群組方式
		/// </summary>
		/// <param name="groupName">是否自行設定處理交易</param>
		void SetTransactionGroup(string groupName);

		/// <summary>
		/// 處理查詢動作
		/// </summary>
		/// <returns>DataTable 物件</returns>
		DataTable Query();

		/// <summary>
		/// 依據 PKNO 處理查詢動作
		/// </summary>
		/// <returns>DataTable 物件</returns>
		DataTable QueryByPkNo();

		/// <summary>
		/// 處理分頁查詢動作
		/// </summary>
		/// <param name="pageNo">目前頁次</param>
		/// <param name="pageSize">每頁筆數</param>
		/// <returns>DataTable 物件</returns>
		DataTable Query(int pageNo, int pageSize);

		/// <summary>
		/// 分頁總筆數
		/// </summary>
		/// <returns>分頁總筆數</returns>
		int TotalRowCount();

		/// <summary>
		/// 使用者 For 批次程式設定用
		/// </summary>
		/// <param name="userId">使用者</param>
		void SetUserId(string userId);

		/// <summary>
		/// 處理新增資料動作
		/// </summary>
		string Insert();

		/// <summary>
		/// 處理修改資料動作
		/// </summary>
		/// <returns>修改筆數</returns>
		int Update();

		/// <summary>
		/// 依據 PKNO 處理修改資料動作
		/// </summary>
		/// <returns>修改筆數</returns>
		int UpdateByPkNo();

		/// <summary>
		/// 處理刪除資料動作
		/// </summary>
		/// <returns>刪除筆數</returns>
		int Delete();

		/// <summary>
		/// 依據 PKNO 處理刪除資料動作
		/// </summary>
		/// <returns>刪除筆數</returns>
		int DeleteByPkNo();

		/// <summary>
		/// 將 Datatable 資料塞到屬性上
		/// </summary>
		/// <param name="index">該筆資料列索引</param>
		void PrepareProperty(int index);
	}
}
