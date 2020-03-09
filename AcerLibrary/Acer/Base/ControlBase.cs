using Acer.DB;
using Acer.Log;
using System.Collections;
using System.Data;
using System.Text;
using Acer.Util;
using Acer.Apps;

namespace Acer.Base
{
	/// <summary>
	/// 商業邏輯物件繼承元件, 初使化資料庫容器物件
	/// </summary>
	public class ControlBase
	{
		/// <summary>別名符號</summary>
		public	static	string	aliasMark	=	"$.";

	#region 建構子
		/// <summary>
		/// 建構子/處理異動處理
		/// </summary>
		/// <param name="dbManager">DBManager 物件</param>
		/// <param name="logUtil">logUtil 物件</param>
		/// <remarks>初使化資料庫容器物件</remarks>
		public ControlBase(DBManager dbManager, LogUtil logUtil)
		{
			this.PageNo		=	0;
			this.DBManager		=	dbManager;
			this.LogUtil		=	logUtil;
			this.TmpCondition	=	new StringBuilder();
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

		#region PageNo  設定目前頁次
		/// <summary>設定目前頁次</summary>
		public int PageNo
		{
			get{return (int)this.PropertyMap["PageNo"];}
			set{this.PropertyMap["PageNo"]	=	value;}
		}
		#endregion

		#region PageSize  每頁筆數
		/// <summary>每頁筆數</summary>
		public int PageSize
		{
			get{return (int)this.PropertyMap["PageSize"];}
			set{this.PropertyMap["PageSize"]	=	value;}
		}
		#endregion

		#region TotalRowCount  總筆數
		/// <summary>總筆數</summary>
		public int TotalRowCount
		{
			get{return (int)this.PropertyMap["TotalRowCount"];}
			set{this.PropertyMap["TotalRowCount"]	=	value;}
		}
		#endregion

		#region SqlRetrictions 設定的條件
		/// <summary>表格名稱</summary>
		public string SqlRetrictions
		{
			get{return (string)this.PropertyMap["SqlRetrictions"];}
			set{this.PropertyMap["SqlRetrictions"]	=	value;}
		}
		#endregion

		#region TmpCondition 暫存的查詢條件
		/// <summary>暫存的查詢條件</summary>
		protected StringBuilder TmpCondition
		{
			get{return (StringBuilder)this.PropertyMap["TmpCondition"];}
			set{this.PropertyMap["TmpCondition"]	=	value;}
		}
		#endregion

		#region OrderBys 設定的排序條件
		/// <summary>表格名稱</summary>
		public string OrderBys
		{
			get{return (string)this.PropertyMap["OrderBys"];}
			set{this.PropertyMap["OrderBys"]	=	value;}
		}
		#endregion

		#region ROWSTAMP 時間戳記
		/// <summary>時間戳記</summary>
		public string ROWSTAMP
		{
			get{return (string)this.PropertyMap["ROWSTAMP"];}
			set{this.PropertyMap["ROWSTAMP"]	=	value;}
		}
		#endregion

		#region PKNO
		/// <summary>PKNO</summary>
		public string PKNO
		{
			get{return (string)this.PropertyMap["PKNO"];}
			set{this.PropertyMap["PKNO"]	=	value;}
		}
        #endregion
        #endregion

        #region 方法

        /// <summary>
        /// 紀錄所塞的屬性資料
        /// </summary>
        public void LogProperty()
		{
			if (Utility.NullToSpace(APConfig.GetProperty("SHOW_TRACE_LOG")).Equals("N"))
				return;
			StringBuilder	logBuff	=	new StringBuilder();

			foreach (string key in this.pPropertyMap.Keys)
			{
				if (key.Equals("DBManager") || key.Equals("LogUtil") || key.Equals("TableCoumnInfo"))
					continue;

				if (this.pPropertyMap[key] != null)
				{
					if (logBuff.Length > 0)
						logBuff.Append(", ");
					logBuff.Append(key + ":" + this.pPropertyMap[key]);
				}
			}
			if (this.Logger.IsLog)
			{
				this.Logger.Append("=== 所設定屬性開始 ===");
				this.Logger.Append(logBuff.ToString());
				this.Logger.Append("=== 所設定屬性結束 ===");
			}
		}

		/// <summary>
		/// 重設所有欄位屬性, 僅針對數字(0)及字串("")
		/// </summary>
		public void ResetColumnProperty()
		{
			object[]	keyArray	=	new object[this.pPropertyMap.Keys.Count];
			this.pPropertyMap.Keys.CopyTo(keyArray, 0);
			foreach (object key in keyArray)
			{
				if (key.Equals("PageNo") || key.Equals("TotalRowCount") || key.Equals("PageSize"))
					continue;
				try
				{
					switch (this.pPropertyMap[key].GetType().Name.ToUpper())
					{
						case "STRING":
							this.pPropertyMap[key]	=	null;
							break;
						case "STRINGBUILDER":
							((StringBuilder)this.pPropertyMap[key]).Length	=	0;
							break;
						case "INT32":
						       this.pPropertyMap[key]	=	0;
							break;
					}
				}
				catch(System.Exception){}
			}
		}

		/// <summary>
		/// 組合查詢字串
		/// </summary>
		/// <param name="outputBuff">回傳的字串</param>
		/// <param name="oper">條件資訊</param>
		/// <param name="column">欄位名稱</param>
		/// <param name="var">欄位值</param>
		/// <param name="needComma">是否需要引號資料</param>
		protected void ProcessQueryCondition(StringBuilder outputBuff, string oper, string column, string var, bool needComma)
		{
			DBUtil.ProcessQueryCondition(outputBuff, oper, column, var, needComma);
		}

		/// <summary>
		/// 組合查詢字串
		/// </summary>
		/// <param name="outputBuff">回傳的字串</param>
		/// <param name="oper">條件資訊</param>
		/// <param name="column">欄位名稱</param>
		/// <param name="var">欄位值</param>
		protected void ProcessQueryCondition(StringBuilder outputBuff, string oper, string column, string var)
		{
			this.ProcessQueryCondition(outputBuff, oper, column, var, true);
		}

		/// <summary>
		/// 組合查詢字串
		/// </summary>
		/// <param name="outputBuff">回傳的字串</param>
		/// <param name="oper">條件資訊 Ex: BT,...</param>
		/// <param name="column">欄位名稱</param>
		/// <param name="var1">欄位值1</param>
		/// <param name="var2">欄位值2</param>
		protected void ProcessQueryCondition(StringBuilder outputBuff, string oper, string column, string var1, string var2)
		{
			DBUtil.ProcessQueryCondition(outputBuff, oper, column, var1, var2);
		}

		/// <summary>
		/// 處理 Or 的條件
		/// </summary>
		/// <param name="outputBuff">Me.TmpCondition</param>
		/// <param name="currCondition">tmpBuff</param>
		protected void ProcessQueryOrCondition(StringBuilder outputBuff, StringBuilder currCondition)
		{
			DBUtil.ProcessQueryOrCondition(outputBuff, currCondition);
		}

		/// <summary>
		/// 處理查詢條件
		/// </summary>
		/// <param name="cond">查詢條件</param>
		/// <returns>查詢條件</returns>
		public string ProcessCondition(string cond)
		{
			return DBUtil.ProcessCondition(cond);
		}
	#endregion
	}
}
