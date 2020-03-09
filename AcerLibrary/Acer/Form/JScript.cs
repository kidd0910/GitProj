using Acer.Log;
using System;
using System.Web.UI;
using System.Text;
using System.Collections;
using System.Web.UI.WebControls;

namespace Acer.Form
{
	/// <summary>
	/// 處理 Javascript 的物件
	/// </summary>
	public class JScript
	{
		StringBuilder	jScriptBuff;
		private	static	int	key	=	0;

		/// <summary>
		/// 建構子
		/// </summary>
		/// <param name="logger">MyLogger 物件</param>
		public JScript(MyLogger logger)
		{
			key		=	key + 1;
			jScriptBuff	=	new StringBuilder();
			this.Logger	=	logger;
		}

	#region 屬性
		private Hashtable	pPropertyMap	=	new Hashtable();

		#region PropertyMap 取得屬性
		/// <summary>取得屬性</summary>
		protected Hashtable PropertyMap 
		{
			get{return (Hashtable)this.pPropertyMap;}
		}
		#endregion

		#region Script 設定 Client 端的 Javascript code
		/// <summary>設定 Client 端的 Javascript code</summary>
		public string Script 
		{
			get{return jScriptBuff.ToString();}
			set{jScriptBuff.Append(value + ";");}
		}
		#endregion

		#region Logger 設定 Client 端的 Javascript code
		/// <summary>設定 Client 端的 Javascript code</summary>
		protected MyLogger Logger 
		{
			get{return (MyLogger)this.PropertyMap["Logger"];}
			set{this.PropertyMap["Logger"]	=	value;}
		}
		#endregion
	#endregion
	
	#region 結構
		/// <summary>
		/// Ctrl 結構
		/// </summary>
		public struct Ctrl
		{
			#region MaxLength M - 最長長度(2)
			/// <summary>M - 最長長度(2)</summary>
			public static string MaxLength
			{
				get{return "M";}
			}
			#endregion
			
			#region ReadOnly1 R - 唯讀(2)
			/// <summary>R - 唯讀(2)</summary>
			public static string ReadOnly
			{
				get{return "R";}
			}
			#endregion

			#region NumberFormat N - 整數不含小數(含負號)
			/// <summary>N - 整數不含小數(含負號)</summary>
			public static string NumberFormat
			{
				get{return "N";}
			}
			#endregion

			#region OnlyNumber N1 - 數字型態, 純數字
			/// <summary>N1 - 數字型態, 純數字</summary>
			public static string OnlyNumber
			{
				get{return "N1";}
			}
			#endregion

			#region OnlyNumber EN - 僅能輸入英文及數字(不含符號)
			/// <summary>EN - 僅能輸入英文及數字(不含符號)</summary>
			public static string OnlyNumberAndEnglish
			{
				get{return "EN";}
			}
			#endregion

			#region OnlyNumberEngAndSpecialWord SE - 允許英數及某些字元
			/// <summary>SE - 允許英數及某些字元</summary>
			public static string OnlyNumberEngAndSpecialWord
			{
				get{return "SE";}
			}
			#endregion

			#region DecimalFormat DC - 數字型態 ##.##(2)
			/// <summary>DC - 數字型態 ##.##(2)</summary>
			public static string DecimalFormat
			{
				get{return "DC";}
			}
			#endregion	

			#region DecimalFormatNoFormat1 DCN1 - 數字型態 ##.##(2)
			/// <summary>DCN1 - (僅正)數字型態 ##.##(2)</summary>
			public static string DecimalFormatNoFormat1
			{
				get{return "DCN1";}
			}
			#endregion

			#region DecimalFormatNoFormat DCN - 數字型態 ##.##(2)
			/// <summary>DCN - 數字型態 ##.##(2)</summary>
			public static string DecimalFormatNoFormat
			{
				get{return "DCN";}
			}
			#endregion
	
			#region NumberRange NR - 數字區間 ##-##(2)
			/// <summary>NR - 數字區間 ##-##(2)</summary>
			public static string NumberRange
			{
				get{return "NR";}
			}
			#endregion

			#region Disable D - 物件使無效(2)
			/// <summary>D - 物件使無效(2)</summary>
			public static string Disable
			{
				get{return "D";}
			}
			#endregion

			#region Size S - 物件尺寸(2)
			/// <summary>S - 物件尺寸(2)</summary>
			public static string Size
			{
				get{return "S";}
			}
			#endregion

			#region StyleSize S1 - 用 Style 定 Szie
			/// <summary>S1 - 用 Style 定 Szie</summary>
			public static string StyleSize
			{
				get{return "S1";}
			}
			#endregion

			#region AutoTab A - Key 滿自動跳離(2)
			/// <summary>A - Key 滿自動跳離(2)</summary>
			public static string AutoTab
			{
				get{return "A";}
			}
			#endregion
					
			#region Value V - 設定預設值(2)
			/// <summary>V - 設定預設值(2)</summary>
			public static string Value
			{
				get{return "V";}
			}
			#endregion

			#region DefaultValue DV - 設定預設值-保留(2)
			/// <summary>DV - 設定預設值-保留(2)</summary>
			public static string DefaultValue
			{
				get{return "DV";}
			}
			#endregion

			#region Uppercase U - 轉大寫
			/// <summary>U - 轉大寫</summary>
			public static string UpperCase
			{
				get{return "U";}
			}
			#endregion

			#region Lowercase L - 轉小寫
			/// <summary>L - 轉小寫</summary>
			public static string LowerCase
			{
				get{return "L";}
			}
			#endregion

			#region FullString FS - 輸入字皆轉全型(含符號)
			/// <summary>FS - 輸入字皆轉全型(含符號)</summary>
			public static string FullString
			{
				get{return "FS";}
			}
			#endregion

			#region DateFormat DT - 日期型態
			/// <summary>DT - 日期型態</summary>
			public static string DateFormat
			{
				get{return "DT";}
			}
			#endregion

			#region TimeFormat T - 時間型態
			/// <summary>T - 時間型態</summary>
			public static string TimeFormat
			{
				get{return "T";}
			}
			#endregion

			#region FillZero F - 填滿零(2)
			/// <summary>F - 填滿零(2)</summary>
			public static string FillZero
			{
				get{return "F";}
			}
			#endregion

			#region Focus FC - 游標停留
			/// <summary>FC - 游標停留</summary>
			public static string Focus
			{
				get{return "FC";}
			}
			#endregion

			#region NameOrAddress NA - 中文名地
			/// <summary>NA - 中文名地</summary>
			public static string NameOrAddress
			{
				get{return "NA";}
			}
			#endregion

			#region IDNo I - 身份證統一編號檢核
			/// <summary>I - 身份證統一編號檢核</summary>
			public static string IdnBan
			{
				get{return "I";}
			}
			#endregion

			#region IP - IP 格式
			/// <summary>IP - IP 格式</summary>
			public static string IP
			{
				get{return "IP";}
			}
			#endregion

			#region TEL - 電話型態
			/// <summary>TEL - 電話型態</summary>
			public static string TEL
			{
				get{return "TEL";}
			}
			#endregion

			#region HTTP - 網址
			/// <summary>HTTP - 網址</summary>
			public static string HTTP
			{
				get{return "HTTP";}
			}
			#endregion

			#region EMAIL - EMAIL
			/// <summary>EMAIL - EMAIL</summary>
			public static string EMAIL
			{
				get{return "EMAIL";}
			}
			#endregion
		}
	#endregion

	#region 方法
		#region Form 屬性設定
		#region IniFormSet 執行 Server 的 iniFormSet 動作, 可保持狀態
		/// <summary>
		/// 執行 Server 的 iniFormSet 動作, 可保持狀態
		/// </summary>
		/// <param name="control">控制項</param>
		/// <param name="argAry">輸入參數陣列, 不需包含引號資訊</param>
		public void IniFormSet(Control control, string[] argAry)
		{
			string	lastProp	=	"";
			try
			{
				for (int i = 0; i < argAry.Length; i++)
				{
					lastProp	=	argAry[i].ToUpper().Trim();

					switch (argAry[i].ToUpper().Trim())
					{
						//=== 最長長度(2) ===
						case "M":
							if (control.GetType().Name.Equals("TextBox"))
							{
								if (((TextBox)control).TextMode.Equals(TextBoxMode.MultiLine))
								{
									JScript.ControlEventAdd(control, "IniFormSet",	"'M'");
									JScript.ControlEventAdd(control, "onkeypress",	"_fe().chkTextAreaMaxNumber(event)");
									JScript.ControlEventAdd(control, "onblur",		"_fe().chkTextAreaMaxNumber(event)");
									((TextBox)control).Attributes.Add("maxLength",	argAry[i + 1].Trim());
								}
								((TextBox)control).MaxLength	=	Convert.ToInt32(argAry[i + 1].Trim());
							}
							break;
						//=== 唯讀(2) ===
						case "R":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'R'");
								((TextBox)control).ReadOnly	=	argAry[i + 1].Trim().Equals("1");
							}
							break;
						//=== 整數不含小數(含負號) ===
						case "N":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'N'");
								((TextBox)control).Attributes.Add("style",	"ime-mode:disabled;");
								JScript.ControlEventAdd(control,	"onkeypress",	"_fe().onlyAllowNumPress(event)");
								JScript.ControlEventAdd(control,	"onkeyup",	"_fe().onlyAllowNumUp(event)");
							}
							break;
						//=== 數字型態, 純數字 ===
						case "N1":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'N1'");
								((TextBox)control).Attributes.Add("style",	"ime-mode:disabled;");
								JScript.ControlEventAdd(control,	"onkeypress",	"_fe().onlyAllowNumPress1(event)");
							}
							break;
						//=== 僅能輸入英文及數字(不含符號) ===
						case "EN":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'EN'");
								((TextBox)control).Attributes.Add("style",	"ime-mode:disabled;");
								JScript.ControlEventAdd(control,	"onkeydown",	"_fe().lockAlphaNum(event)");
							}
							break;
						//=== 允許英數及某些字元 ===
						case "SE":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'SE'");
								((TextBox)control).Attributes.Add("style",	"ime-mode:disabled;");
								JScript.ControlEventAdd(control,	"onblur",	"_fe().lockAlphaNum1(event)");
							}
							break;
						//=== 數字型態 ##.##(2) ===
						case "DC":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'DC'");
								((TextBox)control).Attributes.Add("style",	"ime-mode:disabled;");
								((TextBox)control).Attributes.Add("decmalLength",	argAry[i + 1].Trim());
								JScript.ControlEventAdd(control,	"onkeyup",	"_fe().checkDecimal(event)");
								JScript.ControlEventAdd(control,	"onkeypress",	"_fe().onlyAllowNumPress2(event)");
								JScript.ControlEventAdd(control,	"onfocus",	"_fe().formatDecimal(event)");
								JScript.ControlEventAdd(control,	"onblur",	"_fe().formatDecimal1(event)");
							}
							break;
						//=== 數字型態(不格式化) ##.##(2) ===
						case "DCN":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'DCN'");
								((TextBox)control).Attributes.Add("style",	"ime-mode:disabled;");
								((TextBox)control).Attributes.Add("decmalLength",	argAry[i + 1].Trim());
								JScript.ControlEventAdd(control,	"onkeyup",	"_fe().checkDecimal(event)");
								JScript.ControlEventAdd(control,	"onkeypress",	"_fe().onlyAllowNumPress2(event)");
							}
							break;
						//=== 正整數型態(不格式化) ##.##(2) ===
						case "DCN1":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'DCN'");
								((TextBox)control).Attributes.Add("style",	"ime-mode:disabled;");
								((TextBox)control).Attributes.Add("decmalLength",	argAry[i + 1].Trim());
								JScript.ControlEventAdd(control,	"onkeyup",	"_fe().checkDecimal(event)");
								JScript.ControlEventAdd(control,	"onkeypress",	"_fe().onlyAllowNumPress3(event)");
							}
							break;
						//=== 數字區間 ##-##(2) ===
						case "NR":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'NR'");
								((TextBox)control).Attributes.Add("numberRange",	argAry[i + 1].Trim());
								JScript.ControlEventAdd(control,	"onblur",	"_fe().numberRngeCheck(event)");
							}
							break;
						//=== 物件使無效(2) ===
						case "D":
							JScript.ControlEventAdd(control,	"IniFormSet",	"'D'");
							FormUtil.ControlEnabled(control, !argAry[i + 1].Trim().Equals("1"));
							break;
						//=== 物件尺寸(2) ===
						case "S":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'S'");
								((TextBox)control).Attributes.Add("size",	argAry[i + 1].Trim());
							}
							break;
						//=== 用 Style 定 Szie ===
						case "S1":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'S'");
								((TextBox)control).Width	=	Convert.ToInt32(argAry[i + 1].Trim()) * 17;
							}
							break;
						//=== Key 滿自動跳離(2) ===
						case "A":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'A'");
								JScript.ControlEventAdd(control,	"onkeyup",	"_fe().autoTab(event)");
								JScript.ControlEventAdd(control,	"onkeypress",	"_fe().autoTab1(event)");
							}
							break;
						//=== 設定預設值(2) ===
						case "V":
							JScript.ControlEventAdd(control,	"IniFormSet",	"'V:" + argAry[i + 1].Trim() + "'");
							switch(control.GetType().Name)
							{
								case "Label":
								{
									((Label)control).Text	=	argAry[i + 1].Trim();
									break;
								}
								case "TextBox":
								{
									((TextBox)control).Text	=	argAry[i + 1].Trim();
									break;
								}
								case "DropDownList":
								{
									((DropDownList)control).SelectedValue	=	argAry[i + 1].Trim();
									break;
								}
								case "RadioButtonList":
								{
									((RadioButtonList)control).SelectedValue	=	argAry[i + 1].Trim();
									break;
								}
								case "HiddenField":
								{
									((HiddenField)control).Value	=	argAry[i + 1].Trim();
									break;
								}
							}
							break;
						//=== 設定預設值-保留(2) ===
						case "DV":
							JScript.ControlEventAdd(control,	"IniFormSet",	"'DV:" + argAry[i + 1].Trim() + "'");
							switch(control.GetType().Name)
							{
								case "TextBox":
								{
									((TextBox)control).Attributes.Add("DV", argAry[i + 1].Trim());
									((TextBox)control).Text	=	argAry[i + 1].Trim();
									break;
								}
								case "DropDownList":
								{
									((DropDownList)control).Attributes.Add("DV", argAry[i + 1].Trim());
									((DropDownList)control).SelectedValue	=	argAry[i + 1].Trim();
									break;
								}
								case "RadioButtonList":
								{
									((RadioButtonList)control).Attributes.Add("DV", argAry[i + 1].Trim());
									((RadioButtonList)control).SelectedValue	=	argAry[i + 1].Trim();
									break;
								}
							}
							break;
						//=== 轉大寫 ===
						case "U":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'U'");
								JScript.ControlEventAdd(control,	"onkeyup",	"_fe().upperCase(event)");
								JScript.ControlEventAdd(control,	"onblur",	"this.value=this.value.toUpperCase()");
							}
							break;
						//=== 轉小寫 ===
						case "L":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'L'");
								JScript.ControlEventAdd(control,	"onkeyup",	"_fe().lowerCase(event)");
								JScript.ControlEventAdd(control,	"onblur",	"this.value=this.value.toLowerCase()");
							}
							break;
						//=== 輸入字皆轉全型(含符號) ===
						case "FS":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'FS'");
								JScript.ControlEventAdd(control,	"onblur",	"_fe().toFullStr(event)");
							}
							break;
						//=== 日期型態 ===
						case "DT":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'DT'");
								JScript.ControlEventAdd(control,	"onfocus",	"_fe().formatDate(event)");
								JScript.ControlEventAdd(control,	"onblur",	"_fe().chkDate(event)");
							}
							break;
						//=== 時間型態 ===
						case "T":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'T'");
								JScript.ControlEventAdd(control,	"onblur",	"_fe().chkTime(event)");
							}
							break;
						//=== 填滿某字串 ===
						case "F":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'F'");
								JScript.ControlEventAdd(control,	"fillZero",	argAry[i + 1].Trim());
								JScript.ControlEventAdd(control,	"onblur",	"_fe().fillZero(event)");
							}
							break;
						//=== 游標停留 ===
						case "FC":
							JScript.ControlEventAdd(control,	"IniFormSet",	"'FC'");
							control.Focus();
							break;
						//=== 中文名地 ===
						case "NA":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'NA'");
								JScript.ControlEventAdd(control,	"onblur",	"_fe().toFullStrCheck(event)");
							}
							break;
						//=== 身份證統一編號檢核 ===
						case "I":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'I'");
								JScript.ControlEventAdd(control,	"onblur",	"_fe().checkID(event)");
							}
							break;
						//=== IP 檢核 ===
						case "IP":
							if (control.GetType().Name.Equals("TextBox"))
							{
								((TextBox)control).Attributes.Add("style",	"ime-mode:disabled;");
								JScript.ControlEventAdd(control,	"IniFormSet",	"'IP'");
								JScript.ControlEventAdd(control,	"onblur",	"_fe().checkIP(event)");
							}
							break;
						//=== 電話型態檢核 ===
						case "TEL":
							if (control.GetType().Name.Equals("TextBox"))
							{
								((TextBox)control).Attributes.Add("style",	"ime-mode:disabled;");
								JScript.ControlEventAdd(control,	"IniFormSet",	"'TEL'");
								JScript.ControlEventAdd(control,	"onblur",	"_fe().checkTEL(event)");
							}
							break;
						//=== 網址檢核 ===
						case "HTTP":
							if (control.GetType().Name.Equals("TextBox"))
							{
								((TextBox)control).Attributes.Add("style",	"ime-mode:disabled;");
								JScript.ControlEventAdd(control,	"IniFormSet",	"'HTTP'");
								JScript.ControlEventAdd(control,	"onblur",	"_fe().checkURL(event)");
							}
							break;
						//=== EMAIL 檢核 ===
						case "EMAIL":
							if (control.GetType().Name.Equals("TextBox"))
							{
								((TextBox)control).Attributes.Add("style",	"ime-mode:disabled;");
								JScript.ControlEventAdd(control,	"IniFormSet",	"'EMAIL'");
								JScript.ControlEventAdd(control,	"onblur",	"_fe().checkMail(event)");
							}
							break;
					}
				}
			}
			catch (IndexOutOfRangeException)
			{
				this.Logger.Append("Form_IniFormSet 參數錯誤, control " + control.ClientID + ", arguments " + argAry.ToString() + ", 可能錯誤點為 " + lastProp);
				throw new Exception("Form_IniFormSet 參數錯誤, control " + control.ClientID + ", arguments " + argAry.ToString() + ", 可能錯誤點為 " + lastProp);
			}
			catch (FormatException)
			{
				this.Logger.Append("Form_IniFormSet 參數錯誤, control " + control.ClientID + ", arguments " + argAry.ToString() + ", 可能錯誤點為 " + lastProp);
				throw new Exception("Form_IniFormSet 參數錯誤, control " + control.ClientID + ", arguments " + argAry.ToString() + ", 可能錯誤點為 " + lastProp);
			}
		}
		#endregion

		#region ControlEventAdd 新增加事件
		/// <summary>
		/// 新增加事件
		/// </summary>
		/// <param name="control">控制項</param>
		/// <param name="eventName">事件名稱</param>
		/// <param name="funName">方法名稱</param>
		public static void ControlEventAdd(Control control, string eventName, string funName)
		{
			FormUtil.SetAttributeData(control, eventName, JScript.ProcessData(FormUtil.GetAttributeData(control, eventName), funName));
		}
		#endregion

		#region ProcessData 處理屬性資料
		/// <summary>
		/// 處理屬性資料
		/// </summary>
		/// <param name="oldAttribute">舊屬性</param>
		/// <param name="newAttribute">新屬性</param>
		/// <returns></returns>
		public static string ProcessData(string oldAttribute, string newAttribute)
		{
			if (string.IsNullOrEmpty(oldAttribute))
				return newAttribute;
			else
				return oldAttribute + ";" + newAttribute;
		}
		#endregion

		#region ChkForm 設定檢查欄位
		/// <summary>
		/// 設定檢查欄位
		/// </summary>
		/// <param name="control">控制項</param>
		/// <param name="controlName">控制項中文</param>
		public void ChkForm(Control control, string controlName)
		{
			JScript.ControlEventAdd(control, "chkForm", controlName);
		}
		#endregion
		#endregion

		#region ShowHidwLabel 顯示/隱藏畫面上物件
		/// <summary>
		/// 顯示/隱藏畫面上物件
		/// </summary>
		/// <param name="control">物件</param>
		/// <param name="isShow">顯示/隱藏</param>
		/// <returns></returns>
		public void ShowHidwLabel(Control control, bool isShow)
		{
			string	tmpStyle	=	FormUtil.GetAttributeData(control, "style");
			tmpStyle.Replace("display:none", "display:blank").Replace("display:blank", "display:none");

			if (isShow)
				tmpStyle.Replace("display:none", "display:blank").Replace("display:blank", "display:blank");
			else
				tmpStyle.Replace("display:none", "display:none").Replace("display:blank", "display:none");

			FormUtil.SetAttributeData(control, "style", tmpStyle);
		}
		#endregion

		#region Javascript 方法封裝
		#region DisableAll 呼叫 Client Script Form.disableAll 是否無效化(Disable)所有物件
		/// <summary>
		/// 呼叫 Client Script Form.disableAll 是否無效化(Disable)所有物件
		/// </summary>
		/// <param name="isDisable">是/否</param>
		public void DisableAll(bool isDisable)
		{
			if (isDisable)
				this.Script	=	"Form.disableAll(0, 1);";
			else
				this.Script	=	"Form.disableAll(0, 0);";
		}
		#endregion

		#region IniFormColor 設定 Client 的 Form 顏色
		/// <summary>
		/// 設定 Client 的 Form 顏色
		/// </summary>
		public void IniFormColor()
		{
			this.Script	=	"try{Form.iniFormColor();}catch(ex){}";
		}
        #endregion

        #region 設定浮水印/Water Mark
        /// <summary>
        /// 設定浮水印/Water Mark
        /// </summary>
        public void SetWaterMark()
        {           
            string script = "";
            script = @" 
                    var path = window.location.pathname;
                    var page = path.split('/').pop().toLowerCase();
                    var skipPageList = ['MenuTree.aspx'];
                    if(skipPageList.length > 0){
                        for(i=0; i<skipPageList.length; i++)
                        {
                            if(skipPageList[i].toLowerCase() != page){
                                try {document.getElementsByTagName('body')[0].setAttribute('style', 'background-image: url(/CFCM/watermark.aspx); background-repeat: repeat; background-position-y: 50px;');}catch(ex){}
                            }
                        }
                    }
                    ";
            this.Script = script;
        }
        
        #endregion

        #region HideProcess 呼叫 Client 的 Message.hideProcess 隱藏訊息窗
        /// <summary>
        /// 呼叫 Client 的 Message.hideProcess 隱藏訊息窗
        /// </summary>
        public void HideProcess()
		{
            this.Script = "try{Message.hideProcess();}catch(ex){}";
		}
		#endregion

		#region OpenSuccess 呼叫 Client 的 Message.openSuccess 顯示處理成功訊息
		/// <summary>
		///  呼叫 Client 的 Message.openSuccess 顯示處理成功訊息
		/// </summary>
		/// <param name="message">要顯示的訊息</param>
		public void OpenSuccess(string message)
		{
			this.Script	=	"try{Message.showDiv('__SuccessWindow', 1);}catch(ex){};Message.openSuccess('" + message + "');";
		}
		#endregion

		#region OpenSuccess 呼叫 Client 的 Message.openSuccess 顯示處理成功訊息
		/// <summary>
		///  呼叫 Client 的 Message.openSuccess 顯示處理成功訊息
		/// </summary>
		/// <param name="message">要顯示的訊息</param>
		/// <param name="processFunction">處理完成要執行的 Function</param>
		public void OpenSuccess(string message, string processFunction)
		{
			this.Script	=	"try{Message.showDiv('__SuccessWindow', 1);}catch(ex){};Message.openSuccess('" + message + "', '" + processFunction + "');";
		}
		#endregion

		#region ShowMessage 呼叫 Client 的 Message.showMessage 顯示處理成功訊息
		/// <summary>
		/// 呼叫 Client 的 Message.showMessage 顯示處理成功訊息
		/// </summary>
		/// <param name="message">訊息</param>
		public void ShowMessage(string message)
		{
			if (String.IsNullOrEmpty(message))
				throw new System.ArgumentException("傳入參數不可為空值", "message");
			
			this.Script	=	"Message.showMessage('" + message + "');";
		}
		#endregion

		#region Alert 呼叫 Client 的 alert 顯示訊息
		/// <summary>
		/// 呼叫 Client 的 alert 顯示訊息
		/// </summary>
		/// <param name="message">顯示訊息</param>
		/// <remarks></remarks>
		public void Alert(string message)
		{
			if (String.IsNullOrEmpty(message))
				throw new System.ArgumentException("傳入參數不可為空值", "message");
			
			this.Script	=	"alert('" + message.Replace("\r\n", @"\r\n").Replace("'", "\'") + "');";
		}
		#endregion
		#endregion

		#region ExecAjaxClientScript 執行 Client Javascript
		/// <summary>
		/// 執行 Client Javascript
		/// </summary>
		/// <param name="page">Page 物件</param>
		public void ExecAjaxClientScript(Page page)
		{
			ScriptManager.RegisterStartupScript(page, this.GetType(), "ClientScript" + key, this.Script, true);
			this.Script	=	"";
		}
		#endregion

		#region ExecClientScript 執行 Client Javascript
		/// <summary>
		/// 執行 Client Javascript
		/// </summary>
		public void ExecClientScript(Page page)
		{
			page.ClientScript.RegisterStartupScript(this.GetType(), "ClientScript" + key, this.Script, true);
			this.Script	=	"";
		}
		#endregion

		#region ButtonPermission 處理按鈕權限功能
		/// <summary>
		/// 處理按鈕權限功能
		/// </summary>
		public void ButtonPermission()
		{
			this.Script	=	"";
		}
		#endregion
	#endregion
	}
}