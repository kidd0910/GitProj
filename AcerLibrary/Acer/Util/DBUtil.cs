using Acer.Form;
using Acer.Log;
using Acer.Util;
using Acer.DB;
using Acer.Apps;
using Acer.Base;
using System.Collections;
using System.Text;

namespace Acer.Util
{
	/// <summary>
	/// 連線共用處理物件
	/// </summary>
	public class DBUtil : System.IDisposable
	{
	#region 屬性
		private Hashtable pPropertyMap	=	new Hashtable();

		#region PropertyMap 取得屬性
		/// <summary>取得屬性</summary>
		protected Hashtable PropertyMap 
		{
			get{return this.pPropertyMap;}
		}
		#endregion

		#region Logger 設定 Logger
		/// <summary>設定 Logger</summary>
		public MyLogger Logger 
		{
			get{return this.LogUtil.Logger;}
		}
		#endregion

		#region LogUtil 設定 LogUtil
		/// <summary>設定 Logger</summary>
		public LogUtil LogUtil 
		{
			get{return (LogUtil)this.PropertyMap["LogUtil"];}
			set{this.PropertyMap["LogUtil"]	=	value;}
		}
		#endregion

		#region DBManager 設定 DBManager
		/// <summary>設定 DBManager</summary>
		public DBManager DBManager 
		{
			get{return (DBManager)this.PropertyMap["DBManager"];}
			set{this.PropertyMap["DBManager"]	=	value;}
		}
		#endregion
	#endregion

	#region 建構子
		/// <summary>
		/// 建構子
		/// </summary>
		public DBUtil(LogUtil logUtil)
		{
			this.LogUtil	=	logUtil;
			this.DBManager	=	new DBManager(this.LogUtil);
		}
	#endregion

	#region 方法	
		#region CloseDBManager 關閉 DBManager 物件
		/// <summary>
		/// 關閉 DBManager 物件
		/// </summary>
		public void CloseDBManager()
		{
			if (this.DBManager != null)
			{
				this.DBManager.Close();
			}
		}
		#endregion

		#region 查詢使用方法
		/// <summary>
		/// 組合查詢字串
		/// </summary>
		/// <param name="outputBuff">回傳的字串</param>
		/// <param name="oper">條件資訊</param>
		/// <param name="column">欄位名稱</param>
		/// <param name="var">欄位值</param>
		/// <param name="needComma">是否需要引號資料</param>
		public static void ProcessQueryCondition(StringBuilder outputBuff, string oper, string column, string var, bool needComma)
		{
			//=== 當為空資料不組查詢條件 ===
			if (string.IsNullOrEmpty(var))
				return;

			if (!outputBuff.Equals(""))
				outputBuff.Append(" AND ");

			if (var.IndexOf("@#@") != -1)
				outputBuff.Append(ControlBase.aliasMark + column + var.Replace("@#@", ""));
			else
			{
				switch (oper.ToUpper().Trim())
				{
					case "=":
					case ">":
					case "<":
					case ">=":
					case "<=":
					case "<>":
					case "IN":
						if (needComma)
							outputBuff.Append(ControlBase.aliasMark + column + " " + oper + " '" + var + "'");
						else
							outputBuff.Append(ControlBase.aliasMark + column + " " + oper + " " + var);
						break;
					case "%LIKE%":
						outputBuff.Append(ControlBase.aliasMark + column + " LIKE '%" + var + "%'");
						break;
					case "LIKE%":
						outputBuff.Append(ControlBase.aliasMark + column + " LIKE '" + var + "%'");
						break;
					case "%LIKE":
						outputBuff.Append(ControlBase.aliasMark + column + " LIKE '%" + var + "'");
						break;
					case "ISNULL":
						outputBuff.Append(ControlBase.aliasMark + column + " IS NULL");
						break;
					case "ISNOTNULL":
						outputBuff.Append(ControlBase.aliasMark + column + " IS NOT NULL");
						break;
				}
			}
		}

		/// <summary>
		/// 組合查詢字串
		/// </summary>
		/// <param name="outputBuff">回傳的字串</param>
		/// <param name="oper">條件資訊</param>
		/// <param name="column">欄位名稱</param>
		/// <param name="var">欄位值</param>
		public static void ProcessQueryCondition(StringBuilder outputBuff, string oper, string column, string var)
		{
			DBUtil.ProcessQueryCondition(outputBuff, oper, column, var, true);
		}

		/// <summary>
		/// 組合查詢字串
		/// </summary>
		/// <param name="outputBuff">回傳的字串</param>
		/// <param name="oper">條件資訊 Ex: BT,...</param>
		/// <param name="column">欄位名稱</param>
		/// <param name="var1">欄位值1</param>
		/// <param name="var2">欄位值2</param>
		public static void ProcessQueryCondition(StringBuilder outputBuff, string oper, string column, string var1, string var2)
		{
			if (!outputBuff.Equals(""))
				outputBuff.Append(" AND ");

			switch (oper.ToUpper().Trim())
			{
				case "BT":
					outputBuff.Append(ControlBase.aliasMark + column + " BETWEEN '" + var1 + "' AND '" + var2 + "'");
					break;
			}
		}

		/// <summary>
		/// 處理 Or 的條件
		/// </summary>
		/// <param name="outputBuff">Me.TmpCondition</param>
		/// <param name="currCondition">tmpBuff</param>
		public static void ProcessQueryOrCondition(StringBuilder outputBuff, StringBuilder currCondition)
		{
			if (currCondition.Length == 0)
				return;
			else
			{
				if (outputBuff.Length == 0)
					outputBuff.Append("(" + ProcessCondition(currCondition.ToString()) + ")");
				else
					outputBuff.Append(" OR (" + ProcessCondition(currCondition.ToString()) + ")");
			}
		}

		/// <summary>
		/// 處理查詢條件
		/// </summary>
		/// <param name="cond">查詢條件</param>
		/// <returns>查詢條件</returns>
		public static string ProcessCondition(string cond)
		{
			if (string.IsNullOrEmpty(cond))
				return cond;

			if (cond.Substring(0, 5).Equals(" AND "))
				return cond.Substring(5);
			else
				return cond;
		}
		#endregion

		/// <summary>
		/// 覆寫 Dispose 方法
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			//System.GC.SuppressFinally(this);
		}

		/// <summary>
		/// 覆寫 Dispose 方法
		/// </summary>
		/// <param name="disposing">是否 dispose</param>
		protected virtual void Dispose(bool disposing)
		{
			if(disposing)
			{
				this.CloseDBManager();
			}
		}

	#endregion
	}
}