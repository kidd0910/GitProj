using Acer.DB;
using Acer.Log;
using System.Collections;
using System.Data;
using System.Text;
using Acer.Util;
using Acer.Apps;
using Acer.Err;

namespace Acer.Base
{
	/// <summary>
	/// 批次物件繼承元件, 初使化資料庫容器物件
	/// </summary>
	public class BatchBase
	{
	#region 建構子
		/// <summary>
		/// 建構子/處理異動處理
		/// </summary>
		public BatchBase(string jobID)
		{
			this.HasError	=	false;

			APConfig.Init();
			//=== 起始物件 ===
			this.LogUtil	=	new LogUtil(jobID);
			this.DBUtil	=	new DBUtil(this.LogUtil);
			this.DBManager.Init();
		}
	#endregion

	#region 屬性
		private	Hashtable	pPropertyMap	=	new Hashtable();
		/// <summary>參數對應屬性</summary>
		protected Hashtable PropertyMap
		{
			get{return this.pPropertyMap;}
		}

		#region LogUtil 設定 LogUtil 物件
		/// <summary>設定 LogUtil 物件</summary>
		protected LogUtil LogUtil
		{
			get{return (LogUtil)this.PropertyMap["LogUtil"];}
			set{this.PropertyMap["LogUtil"]	=	value;}
		}
		#endregion

		#region Logger 讀取 Log 物件
		/// <summary>Logger 讀取 Log 物件</summary>
		protected MyLogger Logger 
		{
			get{return this.LogUtil.Logger;}
		}
		#endregion

		#region DBManager 設定 DBManager 物件
		/// <summary>DBManager 設定 DBManager 物件</summary>
		public DBManager DBManager 
		{
			get{return this.DBUtil.DBManager;}
		}
		#endregion

		#region DBUtil 設定 DBUtil 物件
		/// <summary>DBUtil 設定 DBUtil 物件</summary>
		private DBUtil DBUtil 
		{
			get{return (DBUtil)this.PropertyMap["DBUtil"];}
			set{this.PropertyMap["DBUtil"]	=	value;}
		}
		#endregion

		#region HasError 是否包含錯誤
		/// <summary>HasError 是否包含錯誤</summary>
		private bool HasError 
		{
			get{return (bool)this.PropertyMap["HasError"];}
			set{this.PropertyMap["HasError"]	=	value;}
		}
		#endregion

		#region JobID 設定工作編號
		/// <summary>設定工作編號</summary>
		public string JobID
		{
			get{return (string)this.PropertyMap["JobID"];}
			set{this.PropertyMap["JobID"]	=	value;}
		}
		#endregion
	#endregion

	#region 方法
		/// <summary>
		/// 關閉批次程式
		/// </summary>
		public void CloseBatch()
		{
			if (this.DBManager != null)
			{
				if (this.HasError)
					this.DBManager.Rollback();
				else
					this.DBManager.Commit();
			}

			//=== 關閉連線 ===
			this.DBUtil.CloseDBManager();
			this.LogUtil.Logger.IsBatch	=	true;
			this.LogUtil.DoLog();
		}

		/// <summary>
		/// 處理 Excetion 機制
		/// </summary>
		/// <param name="ex">Exception</param>
		public void HandleError(System.Exception ex)
		{
			//=== 設定錯誤 ===
			this.Logger.SetLogLevel(MyLogger.Error);
			this.Logger.Append(ErrUtil.ErrToStr(ex).Replace("<", "&lt;") + "};");

			this.HasError	=	true;
		}
	#endregion
	}
}
