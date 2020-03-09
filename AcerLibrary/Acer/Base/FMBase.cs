using System;
using System.Text;
using System.Collections;
using System.Data.Common;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Acer.Util;
using Acer.DB;
using Acer.DB.Query; 
using Acer.Form;
using Acer.Log;

namespace Acer.Base
{
	/// <summary>
	/// Form Manager 繼承元件
	/// </summary>
	public class FMBase
	{
	#region 建構子
		/// <summary>
		/// 建構子, 初使化 Page 物件及對應 UI 元件
		/// </summary>
		/// <param name="page">Page 物件</param>
		public FMBase(PageBase page)
		{
			this.Page	=	page;
			this.DBManager	=	this.Page.DBManager;
			this.LogUtil	=	this.Page.LogUtil;
		}
	#endregion 

	#region 屬性
		private	Hashtable	pPropertyMap	=	new Hashtable();

		#region PropertyMap 設定取得屬性值
		/// <summary>設定取得屬性值</summary>
		protected Hashtable PropertyMap
		{
			get{return this.pPropertyMap;}
		}
		#endregion 

		#region DBManager 設定存取 DBManager 的物件
		/// <summary>設定存取 DBManager 的物件</summary>
		protected DBManager DBManager
		{
			get{return (DBManager)this.PropertyMap["DBManager"];}
			set{this.PropertyMap["DBManager"]	=	value;}
		}
		#endregion 

		#region ResultData 回傳資料集合
		/// <summary>回傳資料集合</summary>
		public DataTable ResultData
		{
			get{return (DataTable)this.PropertyMap["ResultData"];}
			set{this.PropertyMap["ResultData"]	=	value;}
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

		#region UpdateCount  修改更新筆數
		/// <summary>修改更新筆數</summary>
		public int UpdateCount
		{
			get{return (int)this.PropertyMap["UpdateCount"];}
			set{this.PropertyMap["UpdateCount"]	=	value;}
		}
		#endregion

		#region Application 取得 Application 物件
		/// <summary>取得 Application 物件</summary>
		protected HttpApplicationState Application
		{
			get{return FormUtil.Application;}
		}
		#endregion

		#region Session 取得 Session 物件
		/// <summary>取得 Session 物件</summary>
		protected HttpSessionState Session
		{
			get{return FormUtil.Session;}
		}
		#endregion

		#region Request 取得 Request 物件
		/// <summary>取得 Request 物件</summary>
		protected HttpRequest Request
		{
			get{return FormUtil.Request;}
		}
		#endregion

		#region Response 取得 Response 物件
		/// <summary>取得 Response 物件</summary>
		protected HttpResponse Response
		{
			get{return FormUtil.Response;}
		}
		#endregion

		#region Page 取得 Page 物件
		/// <summary>取得 Page 物件</summary>
		protected PageBase Page
		{
			get{return (PageBase)this.PropertyMap["Page"];}
			set{this.PropertyMap["Page"]	=	value;}
		}
		#endregion

		#region LogUtil 設定 LogUtil 物件
		/// <summary>LogUtil 設定 LogUtil 物件</summary>
		protected LogUtil LogUtil 
		{
			get{return (LogUtil)this.PropertyMap["LogUtil"];}
			set{this.PropertyMap["LogUtil"]	=	value;}
		}
		#endregion

		#region Logger 讀取 Log 物件
		/// <summary>讀取 Log 物件</summary>
		protected MyLogger Logger
		{
			get{return this.LogUtil.Logger;}
		}
		#endregion
	#endregion 

	#region 方法"
		#region 處理分頁
		#region 取得分頁資訊
		/// <summary>
		/// 取得 PageControl 的 PageNo 值
		/// <param name="defaultPageControlId">預設控制項名稱</param>
		/// </summary>
		protected string PageControlPageNo(string defaultPageControlId)
		{
			if (this.HiddenField("ActivePageControl") == null)
				this.Logger.Append("必須設定 HiddenField 控制項 ID [ActivePageControl]");
			
			if (!String.IsNullOrEmpty(this.HiddenField("ActivePageControl").Value))
				return ((TextBox)this.UserControl(this.HiddenField("ActivePageControl").Value).FindControl("PageNo")).Text;
			else
				return ((TextBox)this.UserControl(defaultPageControlId).FindControl("PageNo")).Text;
		}

		/// <summary>
		/// 取得 ScrollSize 值
		/// <param name="defaultPageControlId">預設控制項名稱</param>
		/// </summary>
		protected string PageControlPageSize(string defaultPageControlId)
		{
			if (this.HiddenField("ActivePageControl") == null)
				this.Logger.Append("控制項未設定 --> ActivePageControl");
			
			if (!String.IsNullOrEmpty(this.HiddenField("ActivePageControl").Value))
				return ((TextBox)this.UserControl(this.HiddenField("ActivePageControl").Value).FindControl("PageSize")).Text;
			else
				return ((TextBox)this.UserControl(defaultPageControlId).FindControl("PageSize")).Text;
		}
		#endregion
		#endregion

		#region 取得轉換控制項型態資料
		#region UserControl 取得 UserControl 控制項
		/// <summary>
		/// 取得 UserControl 控制項
		/// </summary>
		/// <param name="fieldName">控制項名稱</param>
		/// <returns>UserControl 控制項</returns>
		protected UserControl UserControl(string fieldName) 
		{
			return (UserControl)this.Page.FindControl(fieldName);
		}
		#endregion 

		#region TextBox 取得 TextBox 控制項
		/// <summary>
		/// 取得 TextBox 控制項
		/// </summary>
		/// <param name="fieldName">控制項名稱</param>
		/// <returns>TextBox 控制項</returns>
		protected TextBox TextBox(string fieldName)
		{
			return (TextBox)this.Page.FindControl(fieldName);
		}
		#endregion 

		#region ListBox 取得 ListBox 控制項
		/// <summary>
		/// 取得 ListBox 控制項
		/// </summary>
		/// <param name="fieldName">控制項名稱</param>
		/// <returns>ListBox 控制項</returns>
		protected ListBox ListBox(string fieldName)
		{
			return (ListBox)this.Page.FindControl(fieldName);
		}
		#endregion 

		#region Label 取得 Label 控制項
		/// <summary>
		/// 取得 Label 控制項
		/// </summary>
		/// <param name="fieldName">控制項名稱</param>
		/// <returns>Label 控制項</returns>
		protected Label Label(string fieldName)
		{
			return (Label)this.Page.FindControl(fieldName);
		}
		#endregion 

		#region DropDownList 取得 DropDownList 控制項
		/// <summary>
		/// 取得 DropDownList 控制項
		/// </summary>
		/// <param name="fieldName">控制項名稱</param>
		/// <returns>DropDownList 控制項</returns>
		protected DropDownList DropDownList(string fieldName)
		{
			return (DropDownList)this.Page.FindControl(fieldName);
		}
		#endregion 

		#region CheckBox 取得 CheckBox 控制項
		/// <summary>
		/// 取得 CheckBox 控制項
		/// </summary>
		/// <param name="fieldName">控制項名稱</param>
		/// <returns>CheckBox 控制項</returns>
		protected CheckBox CheckBox(string fieldName)
		{
			return (CheckBox)this.Page.FindControl(fieldName);
		}
		#endregion 

		#region CheckBoxList 取得 CheckBoxList 控制項
		/// <summary>
		/// 取得 CheckBoxList 控制項
		/// </summary>
		/// <param name="fieldName">控制項名稱</param>
		/// <returns>CheckBoxList 控制項</returns>
		protected CheckBoxList CheckBoxList(string fieldName) 
		{
			return (CheckBoxList)this.Page.FindControl(fieldName);
		}
		#endregion 

		#region RadioButton 取得 RadioButton 控制項
		/// <summary>
		/// 取得 RadioButton 控制項
		/// </summary>
		/// <param name="fieldName">控制項名稱</param>
		/// <returns>RadioButton 控制項</returns>
		protected RadioButton RadioButton(string fieldName)
		{
			return (RadioButton)this.Page.FindControl(fieldName);
		}
		#endregion 

		#region RadioButtonList 取得 RadioButtonList 控制項
		/// <summary>
		/// 取得 RadioButtonList 控制項
		/// </summary>
		/// <param name="fieldName">控制項名稱</param>
		/// <returns>RadioButtonList 控制項</returns>
		protected RadioButtonList RadioButtonList(string fieldName)
		{
			return (RadioButtonList)this.Page.FindControl(fieldName);
		}
		#endregion 

		#region HiddenField 取得 HiddenField 控制項
		/// <summary>
		/// 取得 HiddenField 控制項
		/// </summary>
		/// <param name="fieldName">控制項名稱</param>
		/// <returns>HiddenField 控制項</returns>
		protected HiddenField HiddenField(string fieldName)
		{
			return (HiddenField)this.Page.FindControl(fieldName);
		}
		#endregion 
		#endregion

		#region GetFromCondition 依據查詢畫面欄位(TextBox 型態)產生條件
		/// <summary>
		/// 依據查詢畫面欄位(TextBox 型態)產生條件
		/// </summary>
		/// <param name="fieldName">畫面欄位名稱</param>
		/// <returns>查詢條件</returns>
		protected string GetFromCondition(string fieldName)
		{
			if (string.IsNullOrEmpty(fieldName))
				throw new ArgumentException("欄位值不可空白", fieldName);

			string[]	fields		=	fieldName.Split(',');
			StringBuilder	condition	=	new StringBuilder();
			string		fieldStr;
			string		fieldValue;
			Control		tmpControl;
			string		validType	=	"";
			string		validData	=	"";

			condition.Append("1 = 1 ");

			for (int i = 0; i < fields.Length; i++)
			{
				fieldStr	=	fields[i].Trim();
				tmpControl	=	this.Page.FindControl(fieldStr);

				if (tmpControl == null)
					continue;

				fieldValue	=	FormUtil.GetControlValue(tmpControl);

				if (fieldValue != "")
				{
					if (fields[i] != "ROWSTAMP")
						fieldStr	=	fieldStr.Substring(2, fieldStr.Length - 2);

					//=== 取得檢核字串 ===
					validData	=	FormUtil.GetControlValidationGroupData(tmpControl);
					//=== 取得檢核種類 ===
					validType	=	GetValidType(validData);
				
					switch (validType)
					{
						case "":
						case "EQ":
							condition.Append("AND " + fieldStr + " = '" + fieldValue + "'");
							break;
						case "LIKE":
							condition.Append("AND " + fieldStr + " LIKE '%" + fieldValue + "%'");
							break;
						case "%LIKE":
							condition.Append("AND " + fieldStr + " LIKE '%" + fieldValue + "'");
							break;
						case "LIKE%":
							condition.Append("AND " + fieldStr + " LIKE '" + fieldValue + "%'");
							break;
						case "GT":
							condition.Append("AND " + fieldStr + " > '" + fieldValue + "'");
							break;
						case "GE":
							condition.Append("AND " + fieldStr + " >= '" + fieldValue + "'");
							break;
						case "LT":
							condition.Append("AND " + fieldStr + " < '" + fieldValue + "'");
							break;
						case "LE":
							condition.Append("AND " + fieldStr + " <= '" + fieldValue + "'");
							break;
						case "NE":
							condition.Append("AND " + fieldStr + " != '" + fieldValue + "'");
							break;
					}
				}
			}
			return condition.ToString();
		}

		private string GetValidType(string validData)
		{
			string[]	valids	=	new string[]{"EQ", "LIKE", "%LIKE", "LIKE%", "GT", "GE", "LT", "LE", "NE"};
			string[]	valAry	=	validData.Split(',');
			for (int i = 0; i < valAry.Length; i++)
			{
				for (int j = 0; j < valids.Length; j++)
				{
					if (valAry[i].Equals(valids[j]))
						return valids[j];
				}
			}
			return "";
		}
		#endregion 
	#endregion 
	}
}
