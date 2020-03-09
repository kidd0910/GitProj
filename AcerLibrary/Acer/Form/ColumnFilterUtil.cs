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
using System.Web.Caching;

namespace Acer.Form
{
	/// <summary>
	/// 處理欄位篩選
	/// </summary>
	public class ColumnFilterUtil
	{
#region 結構
		#region ColumnDD 資料字典結構
		/// <summary>
		/// 資料字典結構
		/// </summary>
		/// <remarks></remarks>
		public struct ColiumnFilter
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

			/// <summary>英文名稱</summary>
			public string EName
			{
				get{return (string)this.PropertyMap["EName"];}
				set{this.PropertyMap["EName"]	=	value;}
			}

			/// <summary>中文名稱</summary>
			public string CName
			{
				get{return (string)this.PropertyMap["CName"];}
				set{this.PropertyMap["CName"]	=	value;}
			}

			/// <summary>對應索引</summary>
			public string Index
			{
				get{return (string)this.PropertyMap["Index"];}
				set{this.PropertyMap["Index"]	=	value;}
			}

			/// <summary>不顯示索引</summary>
			public string NoShowIndex
			{
				get{return (string)this.PropertyMap["NoShowIndex"];}
				set{this.PropertyMap["NoShowIndex"]	=	value;}
			}
		}
		#endregion
#endregion
		
		/// <summary>
		/// 初始化多國語系對應
		/// </summary>
		public static ColiumnFilter GetColumnFilter(DBManager dbManager, String pageNum)
		{
			Hashtable ColumnFilterMap	=	(Hashtable)FormUtil.Cache.Get("COLUMN_FILTER");

			if (ColumnFilterMap == null)
				ColumnFilterMap	=	new Hashtable();

			if (ColumnFilterMap[pageNum] != null)
			        return (ColiumnFilter)ColumnFilterMap[pageNum];

			DbConnection	conn;
            conn = dbManager.GetIConnection(APConfig.GetProperty("LANGUAGE_DATASOURCE"));
			
			IDBResult	rs	=	dbManager.GetResultSet(conn);

			string		sql	=	"SELECT * FROM COLUMN_FILTER " +
							"WHERE " +
							"PAGE_NUM	=	'" + pageNum + "' ";
			rs.ExecuteQuery(sql);

			ColiumnFilter	result	=	new ColiumnFilter();

			if (!rs.Next())
			{
				result.Index		=	"";
				result.EName		=	"";
				result.CName		=	"";
				result.NoShowIndex	=	"";

				ColumnFilterMap[pageNum]	=	result;
				dbManager.Logger.Append("欄位篩選未定義 : " + pageNum);
			}
			else
			{
				result.Index		=	rs.GetString("COLUMN_INDEX");
				result.EName		=	GetAryStr(rs.GetString("COLUMN_ENAME"));
				result.CName		=	GetAryStr(rs.GetString("COLUMN_CNAME"));
				result.NoShowIndex	=	rs.GetString("NO_SHOW_INDEX");
				
				ColumnFilterMap[pageNum]	=	result;
				if (FormUtil.Cache.Get("COLUMN_FILTER") == null)
				{
					if (APConfig.GetProperty("PRODECUTION").Equals("N"))
						FormUtil.Cache.Insert("COLUMN_FILTER", ColumnFilterMap, null, DateTime.Now.AddSeconds(1), TimeSpan.Zero);
					else
						FormUtil.Cache.Insert("COLUMN_FILTER", ColumnFilterMap, null, DateTime.Now.AddMinutes(30), TimeSpan.Zero);
				}
				
			}
			rs.Close();

			return	result;
		}

		private static string GetAryStr(string aryStr)
		{
			string[]	ary	=	aryStr.Split(',');
			StringBuilder	buff	=	new StringBuilder();

			for (int i = 0; i < ary.Length; i++)
			{
				if (buff.Length == 0)
					buff.Append("'" + ary[i].Trim() + "'");
				else
					buff.Append(",'" + ary[i].Trim() + "'");
			}

			return buff.ToString();
		}
	}
}
