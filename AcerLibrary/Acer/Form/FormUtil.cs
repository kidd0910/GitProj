using System;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Collections;
using Acer.Util;
using Acer.Apps;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.Caching;
using System.Linq;
using Acer.Log;

namespace Acer.Form
{
	/// <summary>
	/// 跟 Web 相關的共用方法
	/// </summary>
	public class FormUtil
	{
	#region 結構
		/// <summary>
		/// 定義畫面種類
		/// </summary>
		public enum UIType: int
		{
			/// <summary>查詢畫面</summary>
			Query	=	0,
			/// <summary>編輯畫面</summary>
			Edit	=	1,
			/// <summary>查詢結果畫面</summary>
			Result	=	2,
		}

		/// <summary>
		/// 定義畫面種類
		/// </summary>
		public enum FormatType: int
		{
			/// <summary>Grid 呈現</summary>
			Grid	=	0,
			/// <summary>編輯呈現</summary>
			Edit	=	1,
			/// <summary>純文字呈現</summary>
			Label	=	2,
			/// <summary>報表呈現</summary>
			Report	=	3,
		}
	#endregion

	#region 屬性
		/// <summary>
		/// 取得 Response 物件
		/// </summary>
		public static HttpResponse Response
		{
			get{return HttpContext.Current.Response;}
		}

		/// <summary>
		/// 取得 Request 物件
		/// </summary>
		public static HttpRequest Request
        {
            get {
                try
                {
                    if (HttpContext.Current.Request != null)
                    {
                        return HttpContext.Current.Request;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch
                { return null; }                    
            }
        }

		/// <summary>
		/// 取得 Session 物件
		/// </summary>
		public static HttpSessionState Session
		{
			get{
                if (HttpContext.Current.Session != null)
                {
                    return HttpContext.Current.Session; 
                }
                else {
                    return null;
                }                
            }
		}

		/// <summary>
		/// 取得 Application 物件
		/// </summary>
		public static HttpApplicationState Application
		{
			get{return HttpContext.Current.Application;}
		}

		/// <summary>
		/// 取得 Server 物件
		/// </summary>
		public static HttpServerUtility Server
		{
			get{return HttpContext.Current.Server;}
		}

		/// <summary>
		/// 取得 Cache 物件
		/// </summary>
		public static  Cache Cache
		{
		        get{return HttpContext.Current.Cache;}
		}
	#endregion

	#region 方法
		#region ToKeyObject 將 Request 轉為 Javascript 物件, var keyObj = {key1:value,key2:value};
		/// <summary>
		/// 將 Request 轉為 Javascript 物件, var keyObj = {key1:value,key2:value};
		/// </summary>
		/// <returns>Js 資料</returns>
		public static string ToKeyObject()
		{
			HttpRequest	request		=	FormUtil.Request;
			StringBuilder	objBuff		=	new StringBuilder();
			objBuff.Append("<script>");
			
			//=== 將前頁表單所有的變數名稱放入 Enumeration 內 ===
			int		index		=	0;
			foreach (string key in request.Form)
			{
				if (request.Form[key] == null)
					continue;
				if (key == null || key.IndexOf("$") != -1 || key.IndexOf(".") != -1 || key.IndexOf("_") != -1 || request.Form[key].ToString().Length > 100)
					continue;
				
				if (index == 0)
					objBuff.Append("var	keyObj	=	{");
				if (index == 0)
					objBuff.Append(key + ":'" + Utility.FormStr(request.Form[key].ToString()) + "'");
				else
					objBuff.Append("," + key + ":'" + Utility.FormStr(request.Form[key].ToString()) + "'");
				index ++;
			}
			
			objBuff.Append("};</script>");
			
			if (index > 0)
				return objBuff.ToString();
			else
				return "";
		}
		#endregion

		#region HasSession 檢核 Session 資訊, 是否非法登入 env.conf [SKIP_SESSION_VALID] [VALIDE_SESSION_NAME]
		/// <summary>
		/// 檢核 Session 資訊, 是否非法登入 env.conf [SKIP_SESSION_VALID] [VALIDE_SESSION_NAME]
		/// </summary>
		/// <returns>是/否</returns>
		public static Boolean HasSession()
		{
			HttpSessionState	session		=	FormUtil.Session;
			HttpRequest		request		=	FormUtil.Request;

			//=== 判斷 Session 是存還存在(正常登入), 不存在踢出去 ===
			string[]		nonCheckList	=	Utility.Split(APConfig.GetProperty("SKIP_SESSION_VALID").ToString(), ",");
			Boolean			checkFlag	=	true;
			
			for (int i = 0; i < nonCheckList.Length; i++)
			{
				if (request.FilePath.ToString().ToUpper().IndexOf(nonCheckList[i].Trim().ToUpper()) != -1)
				{
					checkFlag	=	false;
					break;
				}
			}
			if (checkFlag && 
				(session[APConfig.GetProperty("VALIDE_SESSION_NAME").ToString()] == null || session[APConfig.GetProperty("VALIDE_SESSION_NAME").ToString()].Equals("")))
				return false;
			else
				return true;
		}
		#endregion

		#region SetControlValue 設定控制項的值
		/// <summary>
		/// 設定控制項的值
		/// </summary>
		/// <param name="control">控制項</param>
		/// <param name="value">初始值</param>
		public static void SetControlValue(Control control, object value)
		{
			switch (control.GetType().Name)
			{
				case "TextBox":
					((TextBox)control).Text			=	Utility.NullToSpace(value);
					break;
				case "HiddenField":
					((HiddenField)control).Value		=	Utility.NullToSpace(value);
					break;
				case "DropDownList":
					((DropDownList)control).SelectedValue	=	Utility.NullToSpace(value);
					break;
				case "Label":
					((Label)control).Text			=	Utility.NullToSpace(value);
					break;
				case "LinkButton":
					((LinkButton)control).Text		=	Utility.NullToSpace(value);
					break;
				case "Button": 
					((Button)control).Text			=	Utility.NullToSpace(value);
					break;
				case "HtmlInputButton":
					((HtmlInputButton)control).Value	=	Utility.NullToSpace(value);
					break;
				case "HtmlGenericControl":
					((HtmlGenericControl)control).InnerText	=	Utility.NullToSpace(value);
					break;
				case "RadioButtonList":
					if (String.IsNullOrEmpty(value.ToString()))
						return;
					((RadioButtonList)control).SelectedValue	=	Utility.NullToSpace(value);
					break;
			}
		}
		#endregion

        #region SetControlText 設定控制項的顯示
        /// <summary>
        /// 設定控制項的顯示
        /// </summary>
        /// <param name="control">控制項</param>
        /// <param name="value">初始值</param>
        public static void SetControlText(Control control, object value)
        {
            switch (control.GetType().Name)
            {
                case "TextBox":
                    ((TextBox)control).Text = Utility.NullToSpace(value);
                    break;
                case "HiddenField":
                    ((HiddenField)control).Value = Utility.NullToSpace(value);
                    break;
                case "DropDownList":
                    ((DropDownList)control).SelectedValue = Utility.NullToSpace(value);
                    break;
                case "Label":
                    ((Label)control).Text = Utility.NullToSpace(value);
                    break;
                case "LinkButton":
                    ((LinkButton)control).Text = Utility.NullToSpace(value);
                    break;
                case "Button":
                    ((Button)control).Text = Utility.NullToSpace(value);
                    break;
                case "CheckBox":
                    ((CheckBox)control).Text = Utility.NullToSpace(value);
                    break;
                case "RadioButton":
                    ((RadioButton)control).Text = Utility.NullToSpace(value);
                    break;
                case "HtmlInputButton":
                    ((HtmlInputButton)control).Value = Utility.NullToSpace(value);
                    break;
                case "HtmlGenericControl":
                    ((HtmlGenericControl)control).InnerText = Utility.NullToSpace(value);
                    break;
                case "RadioButtonList":
                    if (String.IsNullOrEmpty(value.ToString()))
                        return;
                    ((RadioButtonList)control).SelectedValue = Utility.NullToSpace(value);
                    break;
            }
        }
        #endregion

		#region SetControlDisable 設定控制項是否唯讀
		/// <summary>
		/// 設定控制項是否唯讀
		/// </summary>
		/// <param name="control">控制項</param>
		/// <param name="isDisable">是否唯讀</param>
		public static void SetControlDisable(Control control, bool isDisable)
		{
			switch (control.GetType().Name)
			{
				case "TextBox":
					((TextBox)control).Enabled		=	!isDisable;
					break;
				case "HiddenField":
					break;
				case "DropDownList":
					((DropDownList)control).Enabled		=	!isDisable;
					break;
				case "Label":
					break;
				case "LinkButton":
					((LinkButton)control).Enabled		=	!isDisable;
					break;
				case "Button": 
					((Button)control).Enabled		=	!isDisable;
					break;
				case "HtmlInputButton":
					((HtmlInputButton)control).Disabled	=	isDisable;
					break;
				case "HtmlGenericControl":
					break;
			}
		}
		#endregion

		#region GetControlValue 取得控制項的值
		/// <summary>
		/// 取得控制項的值
		/// </summary>
		/// <param name="control">控制項</param>
		public static string GetControlValue(Control control)
		{
			switch (control.GetType().Name)
			{
				case "TextBox":
					return ((TextBox)control).Text;
				case "HiddenField":
					return ((HiddenField)control).Value;
				case "DropDownList":
					return ((DropDownList)control).SelectedValue;
				case "Label":
					return ((Label)control).Text;
				case "LinkButton":
					return ((LinkButton)control).Text;
				case "Button": 
					return ((Button)control).Text;
				case "HtmlInputButton":
					return ((HtmlInputButton)control).Value;
				case "HtmlGenericControl":
					return ((HtmlGenericControl)control).InnerText;
				case "CheckBoxList":
					return ((CheckBoxList)control).SelectedValue;
				case "RadioButtonList":
					return ((RadioButtonList)control).SelectedValue;
				case "FileUpload":
					return ((FileUpload)control).FileName;
				default:
					return "0";
			}
		}
		#endregion

		#region GetAttributeData 抓取控制項的屬性值
		/// <summary>
		/// 抓取控制項的屬性值
		/// </summary>
		/// <param name="control"></param>
		/// <param name="arg"></param>
		/// <returns></returns>
		public static string GetAttributeData(object control, string arg)
		{
			switch (control.GetType().Name)
			{
				case "TextBox":
					return (string)((TextBox)control).Attributes[arg];
				case "RadioButtonList":
					return (string)((RadioButtonList)control).Attributes[arg];
				case "DropDownList":
					return (string)((DropDownList)control).Attributes[arg];
				case "Label":
					return (string)((Label)control).Attributes[arg];
				case "Button":
					return (string)((Button)control).Attributes[arg];
				case "HtmlInputButton":
					return (string)((HtmlInputButton)control).Attributes[arg];
				case "HtmlGenericControl":
					return (string)((HtmlGenericControl)control).Attributes[arg];
				case "LinkButton":
					return (string)((LinkButton)control).Attributes[arg];
				default:
					return "";
			}
		}
		#endregion

		#region GetAttributeData 抓取控制項的屬性值
		/// <summary>
		/// 設定控制項的屬性值
		/// </summary>
		/// <param name="control">控制項</param>
		/// <param name="arg">屬性名稱</param>
		/// <param name="value">屬性值</param>
		public static void SetAttributeData(object control, string arg, string value)
		{
			switch (control.GetType().Name)
			{
				case "TextBox":
					((TextBox)control).Attributes[arg]		=	value;
					break;
				case "DropDownList":
					((DropDownList)control).Attributes[arg]		=	value;
					break;
				case "RadioButtonList":
					((RadioButtonList)control).Attributes[arg]	=	value;
					break;
				case "CheckBoxList":
					((CheckBoxList)control).Attributes[arg]		=	value;
					break;
				case "Label":
					((Label)control).Attributes[arg]		=	value;
					break;
				case "Button":
					((Button)control).Attributes[arg]		=	value;
					break;
				case "HtmlInputButton":
					((HtmlInputButton)control).Attributes[arg]	=	value;
					break;
				case "HtmlGenericControl":
					((HtmlGenericControl)control).Attributes[arg]	=	value;
					break;
				case "LinkButton":
					((LinkButton)control).Attributes[arg]		=	value;
					break;
			}
		}
		#endregion

		#region GetControlValidationGroupData 取得控制項定義的 ValidationGroup 屬性值 
		/// <summary>
		/// 取得控制項定義的 ValidationGroup 屬性值 
		/// </summary>
		/// <param name="control">控制項</param>
		/// <returns>ValidationGroup 屬性值</returns>
		public static string GetControlValidationGroupData(Control control)
		{
			switch (control.GetType().Name)
			{
				case "TextBox":
					return Utility.NullToSpace((string)((TextBox)control).ValidationGroup);
				case "DropDownList":
					return Utility.NullToSpace((string)((DropDownList)control).ValidationGroup);
				case "Button":
					return Utility.NullToSpace((string)((Button)control).ValidationGroup);
				case "HtmlInputButton":
					return Utility.NullToSpace((string)((HtmlInputButton)control).ValidationGroup);
				case "LinkButton":
					return Utility.NullToSpace((string)((LinkButton)control).ValidationGroup);
				case "HiddenField":
					return "";
				default:
					return "";
			}
		}
		#endregion

		#region SetControlValidationGroup 設定控制項的 ValidationGroup 值 
		/// <summary>
		/// 設定控制項的 ValidationGroup 值 
		/// </summary>
		/// <param name="control">控制項</param>
		/// <param name="data">屬性值</param>
		public static void SetControlValidationGroup(Control control, string data)
		{
			switch (control.GetType().Name)
			{
				case "TextBox":
					((TextBox)control).ValidationGroup	=	data;
					break;
				case "DropDownList":
					((DropDownList)control).ValidationGroup	=	data;
					break;
				case "RadioButtonList":
					((RadioButtonList)control).ValidationGroup	=	data;
					break;
				case "CheckBoxList":
					((CheckBoxList)control).ValidationGroup	=	data;
					break;
				case "RadioButton":
					((RadioButton)control).ValidationGroup	=	data;
					break;
				case "CheckBox":
					((CheckBox)control).ValidationGroup	=	data;
					break;
				case "Button":
					((Button)control).ValidationGroup	=	data;
					break;
				case "HtmlInputButton":
					((HtmlInputButton)control).ValidationGroup	=	data;
					break;
				case "LinkButton":
					((LinkButton)control).ValidationGroup	=	data;
					break;
				case "HiddenField":
					break;
				default:
					break;
			}
		}
		#endregion

		#region BindCheckBoxList 產出 BindCheckBoxList 資料
		/// <summary>
		/// 產出 BindCheckBoxList 資料
		/// </summary>
		/// <param name="item">下拉物件</param>
		/// <param name="dataSource">資料來源物件</param>
		/// <param name="valueField">value 的欄位</param>
		/// <param name="textField">text 的欄位</param>
		/// <param name="repeatColumns">顯示的欄位</param>
		public static void BindCheckBoxList(CheckBoxList item, object dataSource,
			string valueField, string textField, int repeatColumns)
		{
			item.Items.Clear();
			
			item.DataSource		=	dataSource;
			item.DataTextField	=	textField;
			item.DataValueField	=	valueField;
			item.DataBind();
			item.RepeatColumns	=	repeatColumns;
		}
		#endregion

		#region BindRadioButtonList 產出 RadioButtonList 資料
		/// <summary>
		/// 產出 RadioButtonList 資料
		/// </summary>
		/// <param name="item">下拉物件</param>
		/// <param name="dataSource">資料來源物件</param>
		/// <param name="valueField">value 的欄位</param>
		/// <param name="textField">text 的欄位</param>
		/// <param name="repeatColumns">顯示的欄位</param>
		public static void BindRadioButtonList(RadioButtonList item, object dataSource,
			string valueField, string textField, int repeatColumns)
		{
			item.Items.Clear();
			
			item.DataSource		=	dataSource;
			item.DataTextField	=	textField;
			item.DataValueField	=	valueField;
			item.DataBind();
			item.RepeatColumns	=	repeatColumns;
		}
		#endregion

		#region BindDropDownList 產出 DropDownList 資料
		/// <summary>
		/// 產出 DropDownList 資料
		/// </summary>
		/// <param name="item">下拉物件</param>
		/// <param name="dataSource">資料來源物件</param>
		/// <param name="valueField">value 的欄位</param>
		/// <param name="textField">text 的欄位</param>
		/// <param name="uIType">UI 種類</param>
		/// <param name="hasEmpty">是否要包含空白資料</param>
		public static void BindDropDownList(DropDownList item, object dataSource,
			string valueField, string textField, UIType uIType, bool hasEmpty)
		{
			item.Items.Clear();
			
			item.DataSource		=	dataSource;
			item.DataTextField	=	textField;
			item.DataValueField	=	valueField;
			item.DataBind();

			if (hasEmpty || 
				(FormUtil.GetAttributeData(item, "ADD_BLANK") != null && 
				FormUtil.GetAttributeData(item, "ADD_BLANK").Equals("Y")))
			{
				FormUtil.SetDropdownListEmptyList(item, uIType);

				//=== 針對查詢下拉, 綁定資料權限的全部 ===
				if (uIType == UIType.Query)
				{
					if (dataSource.GetType().Name.Equals("DataTable"))
					{	
						DataTable	dt	=	(DataTable)dataSource;
						//=== 當有綁定權限時 ===
						if (dt.Columns["HAS_FILTERX"] != null)
						{
							for (int i = 0; i < dt.Columns.Count; i++)
							{
								if (dt.Columns[i].ColumnName.IndexOf("€") != -1)
								{
									FormUtil.SetAttributeData(item, "SKIP", "Y");
									item.Items[0].Value	=	" @#@" + FormUtil.Session[dt.Columns[i].ColumnName];
								}
							}
						}
					}
				}
			}
		}
		#endregion

		#region BindListBox 產出 ListBox 資料
		/// <summary>
		/// 產出 ListBox 資料
		/// </summary>
		/// <param name="item">多選下拉物件</param>
		/// <param name="dataSource">資料來源物件</param>
		/// <param name="valueField">value 的欄位</param>
		/// <param name="textField">text 的欄位</param>
		/// <param name="uIType">UI 種類</param>
		/// <param name="hasEmpty">是否要包含空白資料</param>
		public static void BindListBox(ListBox item, object dataSource,
			string valueField, string textField, UIType uIType, bool hasEmpty)
		{
			item.Items.Clear();
			
			item.DataSource		=	dataSource;
			item.DataTextField	=	textField;
			item.DataValueField	=	valueField;
			item.DataBind();
		}
		#endregion

		#region SetDropdownListEmptyList 設定空白下拉選單的值
		/// <summary>
		/// 設定空白下拉選單的值
		/// </summary>
		/// <param name="item">下拉物件</param>
		/// <param name="uIType">UI 種類</param>
		public static void SetDropdownListEmptyList(DropDownList item, UIType uIType)
		{
            //=== 起始物件 ===
            LogUtil logUtil = new LogUtil("");
            DBUtil dbUtil = new DBUtil(logUtil);
            LangUtil langUtil = new LangUtil(logUtil.Logger, dbUtil.DBManager);
			

			if (item.Items.Count > 0 && (item.Items[0].Value.Equals("") || item.Items[0].Value.Trim().StartsWith("@#@")))
				return;

			switch(uIType)
			{
				case FormUtil.UIType.Query:
                    item.Items.Insert(0, new ListItem("全部", ""));
					break;
				case FormUtil.UIType.Edit:
				case FormUtil.UIType.Result:
					item.Items.Insert(0, new ListItem("", ""));
					break;
			}
		}
		#endregion

		#region 控制項相關功能
		/// <summary>
		/// 檢查是否包含某種控制項
		/// </summary>
		/// <param name="currObject">檢查控制項物件</param>
		/// <param name="controlType">檢查物件型態 Exp: System.Web.UI.LiteralControl</param>
		/// <returns>是否包含某種控制項</returns>
		public static bool CheckControlByType (Control currObject, string controlType)
		{
			if (string.IsNullOrEmpty(controlType))
				throw new System.ArgumentException("不能為空資料", "controlType");
			
			foreach (Control obj in currObject.Controls)
			{
				if (obj.ToString().Equals(controlType))
					return true;

				if (obj.HasControls())
				{
					if (CheckControlByType(obj, controlType))
						return true;
				}
			}
			return false;
		}
		#endregion

		#region FindControlByType 依據控制項型態尋找控制項
		/// <summary>
		/// 依據控制項型態尋找控制項
		/// </summary>
		/// <param name="currObject">檢查控制項物件</param>
		/// <param name="controlType">檢查物件型態 Exp: System.Web.UI.LiteralControl</param>
		/// <returns>控制項</returns>
		public static object FindControlByType(Control currObject, string controlType) 
		{
			if (string.IsNullOrEmpty(controlType))
				throw new System.ArgumentException("不能為空資料", "controlType");

			object	resultObj	=	null;

			foreach (Control obj in currObject.Controls)
			{
				if (obj.GetType().Name.Equals(controlType))
				{
					resultObj	=	obj;
					break;
				}

				if (obj.HasControls())
				{
					resultObj	=	FindControlByType(obj, controlType);
					if (resultObj != null)
						break;
				}
			}
			return resultObj;
		}
		#endregion

		#region ProcessSQLInjection 處理置換會發生 SQLInjection 的資料, 及金額型態資料處理
		/// <summary>
		/// 處理置換會發生 SQLInjection 的資料, 及金額型態資料處理
		/// </summary>
		/// <param name="currObject">檢查控制項物件</param>
		/// <param name="isPageLoad">是否為頁面載入</param>
		public static void ProcessSQLInjection(Control currObject, bool isPageLoad)
		{
			foreach (Control obj in currObject.Controls)
			{
				switch (obj.GetType().Name)
				{
					case "TextBox":
						if (isPageLoad)
						{
							((TextBox)obj).Text	=	((TextBox)obj).Text.Replace("'", "''");
							//=== 金額處理置換動作 ===
							if ((GetAttributeData(obj, "DD") != null && GetAttributeData(obj, "DD").Equals("A")) && !((TextBox)obj).Text.Equals(""))
								((TextBox)obj).Text	=	((TextBox)obj).Text.Replace(",", "");
							//=== 時間處理置換動作 ===
							if ((GetAttributeData(obj, "DD") != null && GetAttributeData(obj, "DD").Equals("T")) && !((TextBox)obj).Text.Equals(""))
								((TextBox)obj).Text	=	((TextBox)obj).Text.Replace(":", "");
							//=== 日期格式處理 ===
							if ((GetAttributeData(obj, "DD") != null && GetAttributeData(obj, "DD").Equals("CD")) && !((TextBox)obj).Text.Equals(""))
								((TextBox)obj).Text	=	DateUtil.ConvertCDate(((TextBox)obj).Text, "yyyy/MM/dd");
						}
						else
						{
							((TextBox)obj).Text	=	((TextBox)obj).Text.Replace("''", "'");
							//=== 金額處理置換動作 ===
							if ((GetAttributeData(obj, "DD") != null && GetAttributeData(obj, "DD").Equals("A")) && !((TextBox)obj).Text.Equals(""))
								((TextBox)obj).Text	=	Convert.ToDouble(((TextBox)obj).Text).ToString("#,##0.########");
							//=== 時間處理置換動作 ===
							if ((GetAttributeData(obj, "DD") != null && GetAttributeData(obj, "DD").Equals("T")) && !((TextBox)obj).Text.Equals(""))
								((TextBox)obj).Text	=	DateUtil.FormatTime(((TextBox)obj).Text);
							//=== 日期格式處理 ===
							if ((GetAttributeData(obj, "DD") != null && GetAttributeData(obj, "DD").Equals("CD")) && !((TextBox)obj).Text.Equals(""))
							{
								try
								{
									((TextBox)obj).Text	=	DateUtil.FormatCDate(DateUtil.ConvertDate(((TextBox)obj).Text));
								}
								catch (Exception)
								{
									throw new Exception(((TextBox)obj).ID + " 日期格式有誤:" + ((TextBox)obj).Text);
								}
							}
						}
						break;
					case "HiddenField":
						if (isPageLoad)
						{
							((HiddenField)obj).Value	=	((HiddenField)obj).Value.Replace("'", "''");
							//=== 金額處理置換動作 ===
							if ((GetAttributeData(obj, "DD") != null && (GetAttributeData(obj, "DD").Equals("A") || GetAttributeData(obj, "DD").Equals("N3"))) 
								&& !((TextBox)obj).Text.Equals(""))
								((HiddenField)obj).Value	=	((HiddenField)obj).Value.Replace(",", "");
							//=== 時間處理置換動作 ===
							if ((GetAttributeData(obj, "DD") != null && GetAttributeData(obj, "DD").Equals("T")) && !((TextBox)obj).Text.Equals(""))
								((HiddenField)obj).Value	=	((HiddenField)obj).Value.Replace(":", "");
							//=== 日期格式處理 ===
							if ((GetAttributeData(obj, "DD") != null && GetAttributeData(obj, "DD").Equals("CD")) && !((TextBox)obj).Text.Equals(""))
								((HiddenField)obj).Value	=	DateUtil.ConvertCDate(((HiddenField)obj).Value, "yyyy/MM/dd");
						}
						else
						{
							((HiddenField)obj).Value	=	((HiddenField)obj).Value.Replace("''", "'");
							//=== 金額處理置換動作 ===
							if ((GetAttributeData(obj, "DD") != null && (GetAttributeData(obj, "DD").Equals("A") || GetAttributeData(obj, "DD").Equals("N3"))) 
								&& !((TextBox)obj).Text.Equals(""))
							{
								((HiddenField)obj).Value	=	Convert.ToDouble(((HiddenField)obj).Value).ToString("#,##0.########");
							}
							//=== 時間處理置換動作 ===
							if ((GetAttributeData(obj, "DD") != null && GetAttributeData(obj, "DD").Equals("T")) && !((TextBox)obj).Text.Equals(""))
							{
								((HiddenField)obj).Value	=	DateUtil.FormatTime(((HiddenField)obj).Value);
							}
							//=== 日期格式處理 ===
							if ((GetAttributeData(obj, "DD") != null && GetAttributeData(obj, "DD").Equals("CD")) && !((TextBox)obj).Text.Equals(""))
								((HiddenField)obj).Value	=	DateUtil.ConvertDate(((HiddenField)obj).Value);
						}
						break;
				}
				
				if (obj.HasControls())
					ProcessSQLInjection(obj, isPageLoad);
			}
		}
		#endregion

		#region FindUserControls 依據控制項型態尋找控制項集合
		/// <summary>
		/// 依據控制項型態尋找控制項集合
		/// </summary>
		/// <param name="currObject">檢查控制項物件</param>
		/// <param name="controls">控制項集合</param>
		public static void FindUserControls(Control currObject, ArrayList controls)
		{
			foreach (Control obj in currObject.Controls)
			{
				if (obj.ToString().ToUpper().IndexOf("USERCONTROL") != -1)
					controls.Add(obj);

				if (obj.HasControls())
					FindUserControls(obj, controls);
			}
		}
		#endregion

		#region FindHasValidationGroupControls 尋找包含 ValidationGroup 屬性的控制項
		/// <summary>
		/// 尋找包含 ValidationGroup 屬性的控制項
		/// </summary>
		/// <param name="currObject">檢查控制項物件</param>
		/// <param name="controls">控制項集合</param>
		public static void FindHasValidationGroupControls(Control currObject, ArrayList controls)
		{
			foreach (Control obj in currObject.Controls)
			{
				try
				{
					GetControlValidationGroupData(currObject);
					controls.Add(obj);
				}
				catch(Exception)
				{
				}

				if (obj.HasControls())
					FindHasValidationGroupControls(obj, controls);
			}
		}
		#endregion

		#region FindNoEditControls 尋找不可編輯的控制項
		/// <summary>
		/// 尋找不可編輯的控制項
		/// </summary>
		/// <param name="currObject">檢查控制項物件</param>
		/// <param name="controls">控制項集合</param>
		public static void FindNoEditControls(Control currObject, ArrayList controls)
		{
			foreach (Control obj in currObject.Controls)
			{
				bool	needAdd	=	false;

				switch (obj.GetType().Name)
				{
					case "DropDownList":
						needAdd	=	!((DropDownList)obj).Enabled;
						break;
					case "TextBox":
						if (((TextBox)obj).TextMode.ToString().ToLower().Equals("password"))
							continue;
						needAdd	=	!((TextBox)obj).Enabled;
						if (!needAdd)
							needAdd	=	((TextBox)obj).ReadOnly;
						break;
					case "HtmlInputText":
						needAdd	=	((HtmlInputText)obj).Disabled;
						break;
					case "HtmlTextArea":
						needAdd	=	((HtmlTextArea)obj).Disabled;
						break;
					case "HtmlSelect":
						needAdd	=	((HtmlTextArea)obj).Disabled;
						break;
				}
				if (needAdd)
				{
					controls.Add(obj);
				}

				if (obj.HasControls())
					FindNoEditControls(obj, controls);
			}
		}
        #endregion

        #region FindUIDDControls 依據控制項前兩碼尋找控制項 (M_/Q_)
        /// <summary>
        /// 依據控制項前兩碼尋找控制項 (M_/Q_),2017.12.14 增加 UVWXYZ
        /// </summary>
        /// <param name="currObject">檢查控制項物件</param>
        /// <param name="controls">控制項集合</param>
        public static void FindUIDDControls(Control currObject, ArrayList controls)
        {
            string[] prefixes = { "M_", "Q_", "G_", "V_", "X_", "Y_", "Z_", "W_", "U_", "GOV_", "C_", "F_"};

            foreach (Control obj in currObject.Controls)
            {
                if (obj.ID != null && obj.ID.Length > 2)
                {

                    if (prefixes.Any(prefix => obj.ID.ToString().StartsWith(prefix)))
                        controls.Add(obj);

                    //=== 第二碼為 _ Exp: M_, Q_... ===
                    // if (obj.ID.ToString().StartsWith("M_") ||
                    // obj.ID.ToString().StartsWith("Q_") || obj.ID.ToString().StartsWith("G_") || obj.ID.ToString().StartsWith("W_") || obj.ID.ToString().StartsWith("X_") || obj.ID.ToString().StartsWith("Y_") || obj.ID.ToString().StartsWith("Z_"))
                    //controls.Add(obj);
                }

                if (obj.HasControls())
                    FindUIDDControls(obj, controls);
            }
        }
        #endregion

        #region FindUIMLControls 依據屬性尋找控制項, 多國語系用 (CL_/CB_/PL_/PB_)
        /// <summary>
        /// 依據屬性尋找控制項, 多國語系用 (CL_/CB_/PL_/PB_)
        /// </summary>
        /// <param name="currObject">檢查控制項物件</param>
        /// <param name="controls">控制項集合</param>
        public static void FindUIMLControls(Control currObject, ArrayList controls)
		{
			string	ml	=	"";

			foreach (Control obj in currObject.Controls)
			{
				switch (obj.GetType().Name)
				{
					case "Label":
						ml	=	((Label)obj).Attributes["ML"];
						break;
					case "LinkButton":
						ml	=	((LinkButton)obj).Attributes["ML"];
						break;
					case "Button":
						ml	=	((Button)obj).Attributes["ML"];
						break;
                    case "CheckBox":
                        ml = ((CheckBox)obj).Attributes["ML"];
                        break;
                    case "RadioButton":
                        ml = ((RadioButton)obj).Attributes["ML"];
                        break;
					case "HtmlInputButton":
						ml	=	((HtmlInputButton)obj).Attributes["ML"];
						break;
					case "HtmlGenericControl":
						ml	=	((HtmlGenericControl)obj).Attributes["ML"];
						break;
                    case "DataControlFieldHeaderCell":
                        ml = ((DataControlFieldHeaderCell)obj).Text;
                        break;
					default:
						ml	=	"";
						break;
				}

				if (!string.IsNullOrEmpty(ml) &&
                    (ml.StartsWith("CL_") || ml.StartsWith("CB_") || ml.StartsWith("PL_") || ml.StartsWith("PB_") || ml.StartsWith("PC_")))
					controls.Add(obj);
				
				if (obj.HasControls())
					FindUIMLControls(obj, controls);
			}
		}
		#endregion

		#region GetGridCondition 取得 Grid 條件
		/// <summary>
		/// 取得 Grid 條件
		/// </summary>
		/// <param name="keyValue">鍵值字串</param>
		/// <returns>取得條件結果</returns>
		public static string GetGridCondition(string keyValue)
		{
			StringBuilder	condBuff	=	new StringBuilder();
			string[]	keyAry		=	keyValue.Split('$');
			string[]	field;

			for (int i = 0; i < keyAry.Length; i++)
			{
				if (i > 0)
					condBuff.Append(" OR ");

				//=== 組合條件 ===
				field	=	keyAry[i].Split('|');
				condBuff.Append("(");
				for (int j = 0; j < field.Length; j += 2)
				{
					if (j > 0)
						condBuff.Append(" AND ");

					condBuff.Append(field[j] + " =	'" + field[j + 1] + "'");
				}
				condBuff.Append(")");
			}

			return condBuff.ToString();
		}
		#endregion

		#region GetGridKeyMap 取得 Grid 條件集合
		/// <summary>
		/// 取得 Grid 條件集合
		/// </summary>
		/// <param name="keyValue">鍵值字串</param>
		/// <returns>取得條件結果</returns>
		public static ArrayList GetGridKeyMap(string keyValue)
		{
			ArrayList	result		=	new ArrayList();
			string[]	keyAry		=	keyValue.Split('$');
			string[]	field;

			for (int i = 0; i < keyAry.Length; i++)
			{
				Hashtable	ht	=	new Hashtable();
				field	=	keyAry[i].Split('|');

				for (int j = 0; j < field.Length; j += 2)
					ht[field[j]]	=	field[j + 1];

				result.Add(ht);
			}

			return result;
		}
		#endregion

		#region ControlEnabled 控制項 Enable 方法
		/// <summary>
		/// 控制項 Enable 方法
		/// </summary>
		/// <param name="control">控制項</param>
		/// <param name="enabled">是否 Enable</param>
		public static void ControlEnabled(Control control, bool enabled)
		{
			switch (control.GetType().Name)
			{
				case "TextBox":
					((TextBox)control).Enabled	=	enabled;
					break;
				case "DropDownList":
					((DropDownList)control).Enabled	=	enabled;
					break;
				case "Label":
					((Label)control).Enabled	=	enabled;
					break;
				case "LinkButton":
					((LinkButton)control).Enabled	=	enabled;
					break;
				case "Button":
					((Button)control).Enabled	=	enabled;
					break;
				case "HtmlGenericControl":
					((HtmlInputButton)control).Disabled	=	!enabled;
					break;
				case "HtmlInputButton":
					((HtmlInputButton)control).Disabled	=	!enabled;
					break;
			}
		}
		#endregion
	#endregion

	}
}
