using Acer.DB;
using Acer.Log;
using System.Collections;

namespace Acer.Base
{
	/// <summary>
	/// 商業邏輯物件繼承元件, 初使化資料庫容器物件
	/// </summary>
	public class BusinessBase
	{
	#region 建構子
		/// <summary>
		/// 建構子/處理異動處理
		/// </summary>
		/// <param name="dbManager">DBManager 物件</param>
		/// <param name="logUtil">logUtil 物件</param>
		/// <remarks>初使化資料庫容器物件</remarks>
		public BusinessBase(DBManager dbManager, LogUtil logUtil)
		{
			this.DBManager	=	dbManager;
			this.LogUtil	=	logUtil;
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

		#region MyLogger 設定 Logger 物件
		/// <summary>設定 Logger 物件</summary>
		protected MyLogger Logger
		{
			get{return this.LogUtil.Logger;}
		}
		#endregion

		#region DBManager 設定 DBManager 物件
		/// <summary>設定 DBManager 物件</summary>
		protected DBManager DBManager
		{
			get{return (DBManager)this.PropertyMap["DBManager"];}
			set{this.PropertyMap["DBManager"]	=	value;}
		}
		#endregion
	#endregion
	}
}
