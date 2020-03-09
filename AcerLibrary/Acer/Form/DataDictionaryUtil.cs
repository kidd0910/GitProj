using System;
using System.Text;
using Acer.DB;
using System.Collections;
using Acer.DB.Query;
using System.Data.Common;
using Acer.Base;
using Acer.Log;
using Acer.Apps;
using System.Threading;
using Acer.Util;
using System.Text.RegularExpressions;

namespace Acer.Form
{
	/// <summary>
	/// 處理資料字典
	/// </summary>
	public class DataDictionaryUtil
	{
#region 結構
		#region ColumnDD 資料字典結構
		/// <summary>
		/// 資料字典結構
		/// </summary>
		/// <remarks></remarks>
		[Serializable]
		public struct ColumnDD
		{
			private	Hashtable	pPropertyMap;

			private	Hashtable PropertyMap
			{
				get
				{
					if (pPropertyMap == null)
						pPropertyMap	=	new Hashtable();
					return pPropertyMap;
				}
			}

			/// <summary>欄位名稱</summary>
			public string Name
			{
				get{return (string)this.PropertyMap["Code"];}
				set{this.PropertyMap["Code"]	=	value;}
			}

			/// <summary>欄位中文名稱</summary>
			public string CName
			{
				get{return (string)this.PropertyMap["CName"];}
				set{this.PropertyMap["CName"]	=	value;}
			}

			/// <summary>欄位長度</summary>
			public string Length
			{
				get{return (string)this.PropertyMap["Length"];}
				set{this.PropertyMap["Length"]	=	value;}
			}

			/// <summary>小數點位數</summary>
			public string Dot
			{
				get{return (string)this.PropertyMap["Dot"];}
				set{this.PropertyMap["Dot"]	=	value;}
			}

			/// <summary>畫面種類</summary>
			public string UIType
			{
				get{return (string)this.PropertyMap["UIType"];}
				set{this.PropertyMap["UIType"]	=	value;}
			}

			/// <summary>檢查格式</summary>
			public string ChkType
			{
				get{return (string)this.PropertyMap["ChkType"];}
				set{this.PropertyMap["ChkType"]	=	value;}
			}

			/// <summary>檢查資料一</summary>
			public string Valid1
			{
				get{return (string)this.PropertyMap["Valid1"];}
				set{this.PropertyMap["Valid1"]	=	value;}
			}

			/// <summary>檢查資料二</summary>
			public string Valid2
			{
				get{return (string)this.PropertyMap["Valid2"];}
				set{this.PropertyMap["Valid2"]	=	value;}
			}

			/// <summary>資料庫型態</summary>
			public string DBType
			{
				get{return (string)this.PropertyMap["DBType"];}
				set{this.PropertyMap["DBType"]	=	value;}
			}
		}
		#endregion

		#region ColumnField 程式資料欄位結構
		/// <summary>
		/// 程式資料欄位結構
		/// </summary>
		/// <remarks></remarks>
		[Serializable]
		public struct ColumnField
		{
			private	Hashtable	pPropertyMap;

			private	Hashtable PropertyMap
			{
				get
				{
					if (pPropertyMap == null)
						pPropertyMap	=	new Hashtable();
					return pPropertyMap;
				}
			}

			/// <summary>欄位開頭 M_ Q_</summary>
			public string Head
			{
				get{return (string)this.PropertyMap["Head"];}
				set{this.PropertyMap["Head"]	=	value;}
			}

			/// <summary>欄位代號</summary>
			public string FieldCd
			{
				get{return (string)this.PropertyMap["FieldCd"];}
				set{this.PropertyMap["FieldCd"]	=	value;}
			}

			/// <summary>欄位型態</summary>
			public string FieldType
			{
				get{return (string)this.PropertyMap["FieldType"];}
				set{this.PropertyMap["FieldType"]	=	value;}
			}

			/// <summary>欄位中文名稱</summary>
			public string CName
			{
				get{return (string)this.PropertyMap["CName"];}
				set{this.PropertyMap["CName"]	=	value;}
			}

			/// <summary>預設值</summary>
			public string DefaultValue
			{
				get{return (string)this.PropertyMap["DefaultValue"];}
				set{this.PropertyMap["DefaultValue"]	=	value;}
			}

			/// <summary>預設 Session 值</summary>
			public string DefaultSessionValue
			{
				get{return (string)this.PropertyMap["DefaultSessionValue"];}
				set{this.PropertyMap["DefaultSessionValue"]	=	value;}
			}

			/// <summary>唯讀</summary>
			public bool ReadOnly
			{
				get{return (bool)this.PropertyMap["ReadOnly"];}
				set{this.PropertyMap["ReadOnly"]	=	value;}
			}

			/// <summary>必填否</summary>
			public bool NotNull
			{
				get{return (bool)this.PropertyMap["NotNull"];}
				set{this.PropertyMap["NotNull"]	=	value;}
			}

			/// <summary>下拉加空白</summary>
			public string AddBlank
			{
				get{return (string)this.PropertyMap["AddBlank"];}
				set{this.PropertyMap["AddBlank"]	=	value;}
			}

			/// <summary>控制項資料</summary>
			public string Content
			{
				get{return (string)this.PropertyMap["Content"];}
				set{this.PropertyMap["Content"]	=	value;}
			}
		}
		#endregion
#endregion

#region 方法

#region 初始化資料字典
		/// <summary>
		/// 初始化資料字典
		/// </summary>
		public static void InitDataDictionary(DBManager dbManager, LogUtil logUtil)
		{
			InitDataDictionary(dbManager, logUtil, false);
		}
#endregion

#region 初始化資料字典對應 for init
		/// <summary>
		/// 初始化資料字典對應 for init
		/// </summary>
		public static void InitDataDictionary(DBManager dbManager, LogUtil logUtil, bool isReload)
		{
logUtil.MethodStart("GetConnection");
			DbConnection	conn	=	dbManager.GetIConnection(APConfig.GetProperty("DATA_DICTIONARY_DATASOURCE"));
logUtil.MethodEnd("GetConnection");
			IDBResult	rs	=	dbManager.GetResultSet(conn);

			string		sql	=	"SELECT * FROM COLUMNDD A " +
							"INNER JOIN UITYPE B " +
							"ON " +
							"A.PROJ_NM	=	B.PROJ_NM AND " +
							"A.CODEGEN_TYPE	=	B.TYPE_ID " +
							"WHERE " +
							"A.PROJ_NM	=	'" + APConfig.GetProperty("DATA_PROJECT") + "'";
			rs.ExecuteQuery(sql);
			Hashtable	columnDDMap	=	new Hashtable();
System.IO.File.AppendAllText(APConfig.RealPath + @"Temp\DDLog.txt", DateUtil.GetNowDateTime() + ":" + sql + "\r\n");
logUtil.MethodStart("Dump to ColumnDDMap");
			while (rs.Next())
			{
				DataDictionaryUtil.ColumnDD	columnDD	=	new DataDictionaryUtil.ColumnDD();
				switch (rs.GetString("CODEGEN_TYPE"))
				{
					case "D":
						columnDD.Length	=	"8";
						break;
					case "CD":
						columnDD.Length	=	"7";
						break;
					case "T":
						columnDD.Length	=	"6";
						break;
					default:
						columnDD.Length	=	rs.GetString("COLUMN_LEN");
						break;
				}

				columnDD.Name	=	rs.GetString("COLUMN_CD");
				columnDD.CName	=	rs.GetString("COLUMN_NM");
				columnDD.Dot	=	rs.GetString("COLUMN_DOT");
				columnDD.UIType	=	rs.GetString("CODEGEN_TYPE");
				columnDD.ChkType=	rs.GetString("CHKTYPE");
				columnDD.Valid1	=	rs.GetString("VAILD1");
				columnDD.Valid2	=	rs.GetString("VAILD2");
				columnDD.DBType	=	rs.GetString("DB_TYPE");

				columnDDMap[rs.GetString("COLUMN_CD")]	=	columnDD;
			}
			rs.Close();
			MultiProcess.SetCrossSiteValue("COLUMNDD", (Object)columnDDMap);
logUtil.MethodEnd("Dump to ColumnDDMap");

			//=== For 海大 ===
			sql	=	"SELECT DISTINCT SCREEN_CD, FIELD_DD, FIELD_NM " +
					"FROM SCREEN_COLUMN " +
					"WHERE " +
					"PROJ_NM	=	'" + APConfig.GetProperty("DATA_PROJECT") + "'";
			rs.ExecuteQuery(sql);
System.IO.File.AppendAllText(APConfig.RealPath + @"Temp\DDLog.txt", DateUtil.GetNowDateTime() + ":" + sql + "\r\n");
logUtil.MethodStart("Dump to PageColumnMap");
			Hashtable	pageColumnMap	=	new Hashtable();
			while (rs.Next())
			{
				pageColumnMap[rs.GetString("SCREEN_CD") + "_" + rs.GetString("FIELD_DD")]	=	rs.GetString("FIELD_NM").Replace("{","").Replace("}","");
			}
			rs.Close();
			MultiProcess.SetCrossSiteValue("PAGE_COLUMN", pageColumnMap);
logUtil.MethodEnd("Dump to PageColumnMap");

			//=== 海洋大學不執行以下動作 ===
				MultiProcess.SetCrossSiteValue("COLUMN_FIELD", new Hashtable());
				return;

			//=== For 海大以後系統 ===
			sql	=	"SELECT M.FIELD_ID_HEAD, M.FIELD_CD, M.FIELD_TYPE, M.FIELD_HEADING, M.DEFAULT_VAL, M.DEFAULT_SESSION, " +
					"M.READONLY, M.REQUIRE, M.DLL_ADD_BLANK, M.OPTION_CONTENT, R2.SCREEN_CD " +
					"FROM SCREEN_FIELD M " +
					"INNER JOIN SCREEN_BLOCK R1 " +
					"ON " +
					"M.SCREEN_PKNO		=	R1.SCREEN_PKNO AND " +
					"M.FIELD_ID_HEAD	=	R1.FIELD_ID_HEAD AND " +
					"R1.BLOCK_TYPE		<>	'G' " +
					"INNER JOIN UI_SCREEN R2 " +
					"ON " +
					"M.SCREEN_PKNO	=	R2.PKNO AND " +
					"R2.PROJ_NM	=	'" + APConfig.GetProperty("DATA_PROJECT") + "'";
			rs.ExecuteQuery(sql);
logUtil.MethodStart("Dump to ColumnFieldMap");

			Hashtable	columnFieldMap	=	new Hashtable();
			int	idx	=	0;
			while (rs.Next())
			{
				idx ++;
				
				DataDictionaryUtil.ColumnField	columnField	=	new DataDictionaryUtil.ColumnField();
				
				columnField.Head		=	rs.GetString("FIELD_ID_HEAD");
				columnField.FieldCd		=	rs.GetString("FIELD_CD");
				columnField.FieldType		=	rs.GetString("FIELD_TYPE").ToUpper();
				columnField.CName		=	rs.GetString("FIELD_HEADING");
				columnField.DefaultValue	=	rs.GetString("DEFAULT_VAL");
				columnField.DefaultSessionValue	=	rs.GetString("DEFAULT_SESSION");
				columnField.ReadOnly		=	rs.GetString("READONLY").Equals("Y");
				columnField.NotNull		=	rs.GetString("REQUIRE").Equals("Y");
				columnField.AddBlank		=	rs.GetString("DLL_ADD_BLANK");
				columnField.Content		=	rs.GetString("OPTION_CONTENT");

				columnFieldMap[rs.GetString("SCREEN_CD") + "_" + rs.GetString("FIELD_ID_HEAD") + "_" + rs.GetString("FIELD_CD")]	=	columnField;
			}
			rs.Close();
			MultiProcess.SetCrossSiteValue("COLUMN_FIELD", columnFieldMap);
logUtil.MethodEnd("Dump to ColumnFieldMap");
		}
#endregion

		#region 檢查資料 DD 格式符合
		/// <summary>
		/// 檢查資料 DD 格式符合
		/// </summary>
		/// <param name="pageObj">PageBase 物件</param>
		/// <param name="columnName">欄位名稱</param>
		/// <param name="columnValue">欄位值</param>
		/// <returns>錯誤訊息, 無錯誤回傳空白</returns>
		public static String CheckDDFormat(PageBase pageObj, String columnName, String columnValue)
		{
			Hashtable			columnDDMap	=	pageObj.DDColumn;
			DataDictionaryUtil.ColumnDD	tmpStruct	=	(DataDictionaryUtil.ColumnDD)columnDDMap[columnName];

			//=== 檢查字串長度 ===
			if (!string.IsNullOrEmpty(tmpStruct.Length))
			{
				int	maxLength	=	Convert.ToInt32(tmpStruct.Length);
				if (columnValue.Length > maxLength && !tmpStruct.UIType.Equals("CD") && 
					!tmpStruct.UIType.Equals("D") && !tmpStruct.UIType.Equals("A") && !tmpStruct.UIType.Equals("T") && 
					!tmpStruct.UIType.Equals("N3") && !tmpStruct.UIType.Equals("N4"))
					return "欄位:" + columnName + " 輸入長度過長：" + columnValue + "長度:" + columnValue.Length + ", DD 設定長度(自訂)：" + maxLength;
			}

			//=== 檢查字串格式 ===
			Regex	reg	=	null;
			switch (tmpStruct.UIType)
			{
				//=== 國曆 ===
				case "CD":
					if (!DateUtil.IsDate(columnValue))
						return "[國曆]欄位:" + columnName + " 日期格式錯誤：" + columnValue;
					break;
				//=== 西曆 ===
				case "D":
					if (!DateUtil.IsDate(columnValue))
						return "[西曆]欄位:" + columnName + " 日期格式錯誤：" + columnValue;
					break;
				//=== 日期 ===
				case "DT":
					if (!DateUtil.IsDate(columnValue))
						return "[日期]欄位:" + columnName + " 日期格式錯誤：" + columnValue;
					break;
				//=== 整數數字 ===
				case "N":
					try{Convert.ToInt64(columnValue);}
					catch(Exception){return "[整數數字]欄位:" + columnName + " 必須為整數數字：" + columnValue;}
					break;
				//=== 純數字 ===
				case "N1":
					reg	=	new Regex("[^0-9]");
					if (reg.IsMatch(columnValue))
						return "[純數字]欄位:" + columnName + " 必須為純數字格式：" + columnValue;
					break;
				//=== 正整數不含小數 ===
				case "N2":
					reg	=	new Regex("[^0-9]");
					if (reg.IsMatch(columnValue))
						return "[正整數不含小數]欄位:" + columnName + " 必須為純數字格式：" + columnValue;
					break;
				//=== 數字含小數不要3位一撇 ===
				case "N3":
					try{Convert.ToDouble(columnValue);}
					catch(Exception){return "[數字含小數不要3位一撇]欄位:" + columnName + " 必須為數字含小數格式：" + columnValue;}
					break;
				//=== 正整數含小數不要3位一撇 ===
				case "N4":
					try{Convert.ToDouble(columnValue);}
					catch(Exception){return "[正整數含小數不要3位一撇]欄位:" + columnName + " 必須為正整數含小數格式：" + columnValue;}
					if (Convert.ToDouble(columnValue) < 0)
						return "[正整數含小數不要3位一撇]欄位:" + columnName + " 必須為正整數含小數格式：" + columnValue;
					break;
				//=== 中英混合 ===
				case "X":
					break;
				//=== IDN_BAN ===
				case "I":
					break;
				//=== 數字前補零 ===
				case "Z":
					reg	=	new Regex("[^0-9]");
					if (reg.IsMatch(columnValue))
						return "[數字前補零]欄位:" + columnName + " 必須為整數數字格式：" + columnValue;
					break;
				//=== 時間 ===
				case "T":
					if (!DateUtil.IsTime(columnValue))
						return "[時間]欄位:" + columnName + " 必須為時間格式：" + columnValue;
					break;
				//=== 數字含小數 ===
				case "A":
					try{Convert.ToDouble(columnValue);}
					catch(Exception){return "[數字含小數]欄位:" + columnName + " 必須為數字含小數格式：" + columnValue;}
					break;
				//=== 英數 ===
				case "E":
					reg	=	new Regex("[^a-zA-Z0-9]");
					if (reg.IsMatch(columnValue))
						return "[英數]欄位:" + columnName + " 必須為英數格式：" + columnValue;
					break;
				//=== 英數小寫(含符號) ===
				case "EL":
					reg	=	new Regex("[A-Z]");
					if (reg.IsMatch(columnValue))
						return "[英數小寫(含符號)]欄位:" + columnName + " 必須為不可為英數大寫資訊：" + columnValue;
					if (Utility.GetBLen(columnValue) != columnValue.Length)
						return "[英數小寫(含符號)]欄位:" + columnName + " 必須為不可包含中文資訊：" + columnValue;
					break;
				//=== 英數大寫(含符號) ===
				case "EU":
					reg	=	new Regex("[a-z]");
					if (reg.IsMatch(columnValue))
						return "[英數大寫(含符號)]欄位:" + columnName + " 必須為不可為英數小寫資訊：" + columnValue;
					if (Utility.GetBLen(columnValue) != columnValue.Length)
						return "[英數大寫(含符號)]欄位:" + columnName + " 必須為不可包含中文資訊：" + columnValue;
					break;
				//=== 英數大寫(不含符號) ===
				case "EU1":
					reg	=	new Regex("[a-z]");
					if (reg.IsMatch(columnValue))
						return "[英數大寫(含符號)]欄位:" + columnName + " 必須為不可為英數小寫資訊：" + columnValue;
					if (Utility.GetBLen(columnValue) != columnValue.Length)
						return "[英數大寫(含符號)]欄位:" + columnName + " 必須為不可包含中文資訊：" + columnValue;
					break;
				//=== 英數(含符號) ===
				case "EW":
					if (Utility.GetBLen(columnValue) != columnValue.Length)
						return "[英數(含符號)]欄位:" + columnName + " 必須為不可包含中文資訊：" + columnValue;
					break;
				//=== PKNO ===
				case "PK":
					break;
			}
			return "";
		}
	}
#endregion
#endregion
}
