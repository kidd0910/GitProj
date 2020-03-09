using Acer.Log;
using System;
using System.Web.UI;
using System.Text;
using System.Collections;
using System.Web.UI.WebControls;

namespace Acer.Form
{
	/// <summary>
	/// �B�z Javascript ������
	/// </summary>
	public class JScript
	{
		StringBuilder	jScriptBuff;
		private	static	int	key	=	0;

		/// <summary>
		/// �غc�l
		/// </summary>
		/// <param name="logger">MyLogger ����</param>
		public JScript(MyLogger logger)
		{
			key		=	key + 1;
			jScriptBuff	=	new StringBuilder();
			this.Logger	=	logger;
		}

	#region �ݩ�
		private Hashtable	pPropertyMap	=	new Hashtable();

		#region PropertyMap ���o�ݩ�
		/// <summary>���o�ݩ�</summary>
		protected Hashtable PropertyMap 
		{
			get{return (Hashtable)this.pPropertyMap;}
		}
		#endregion

		#region Script �]�w Client �ݪ� Javascript code
		/// <summary>�]�w Client �ݪ� Javascript code</summary>
		public string Script 
		{
			get{return jScriptBuff.ToString();}
			set{jScriptBuff.Append(value + ";");}
		}
		#endregion

		#region Logger �]�w Client �ݪ� Javascript code
		/// <summary>�]�w Client �ݪ� Javascript code</summary>
		protected MyLogger Logger 
		{
			get{return (MyLogger)this.PropertyMap["Logger"];}
			set{this.PropertyMap["Logger"]	=	value;}
		}
		#endregion
	#endregion
	
	#region ���c
		/// <summary>
		/// Ctrl ���c
		/// </summary>
		public struct Ctrl
		{
			#region MaxLength M - �̪�����(2)
			/// <summary>M - �̪�����(2)</summary>
			public static string MaxLength
			{
				get{return "M";}
			}
			#endregion
			
			#region ReadOnly1 R - ��Ū(2)
			/// <summary>R - ��Ū(2)</summary>
			public static string ReadOnly
			{
				get{return "R";}
			}
			#endregion

			#region NumberFormat N - ��Ƥ��t�p��(�t�t��)
			/// <summary>N - ��Ƥ��t�p��(�t�t��)</summary>
			public static string NumberFormat
			{
				get{return "N";}
			}
			#endregion

			#region OnlyNumber N1 - �Ʀr���A, �¼Ʀr
			/// <summary>N1 - �Ʀr���A, �¼Ʀr</summary>
			public static string OnlyNumber
			{
				get{return "N1";}
			}
			#endregion

			#region OnlyNumber EN - �ȯ��J�^��μƦr(���t�Ÿ�)
			/// <summary>EN - �ȯ��J�^��μƦr(���t�Ÿ�)</summary>
			public static string OnlyNumberAndEnglish
			{
				get{return "EN";}
			}
			#endregion

			#region OnlyNumberEngAndSpecialWord SE - ���\�^�ƤάY�Ǧr��
			/// <summary>SE - ���\�^�ƤάY�Ǧr��</summary>
			public static string OnlyNumberEngAndSpecialWord
			{
				get{return "SE";}
			}
			#endregion

			#region DecimalFormat DC - �Ʀr���A ##.##(2)
			/// <summary>DC - �Ʀr���A ##.##(2)</summary>
			public static string DecimalFormat
			{
				get{return "DC";}
			}
			#endregion	

			#region DecimalFormatNoFormat1 DCN1 - �Ʀr���A ##.##(2)
			/// <summary>DCN1 - (�ȥ�)�Ʀr���A ##.##(2)</summary>
			public static string DecimalFormatNoFormat1
			{
				get{return "DCN1";}
			}
			#endregion

			#region DecimalFormatNoFormat DCN - �Ʀr���A ##.##(2)
			/// <summary>DCN - �Ʀr���A ##.##(2)</summary>
			public static string DecimalFormatNoFormat
			{
				get{return "DCN";}
			}
			#endregion
	
			#region NumberRange NR - �Ʀr�϶� ##-##(2)
			/// <summary>NR - �Ʀr�϶� ##-##(2)</summary>
			public static string NumberRange
			{
				get{return "NR";}
			}
			#endregion

			#region Disable D - ����ϵL��(2)
			/// <summary>D - ����ϵL��(2)</summary>
			public static string Disable
			{
				get{return "D";}
			}
			#endregion

			#region Size S - ����ؤo(2)
			/// <summary>S - ����ؤo(2)</summary>
			public static string Size
			{
				get{return "S";}
			}
			#endregion

			#region StyleSize S1 - �� Style �w Szie
			/// <summary>S1 - �� Style �w Szie</summary>
			public static string StyleSize
			{
				get{return "S1";}
			}
			#endregion

			#region AutoTab A - Key ���۰ʸ���(2)
			/// <summary>A - Key ���۰ʸ���(2)</summary>
			public static string AutoTab
			{
				get{return "A";}
			}
			#endregion
					
			#region Value V - �]�w�w�]��(2)
			/// <summary>V - �]�w�w�]��(2)</summary>
			public static string Value
			{
				get{return "V";}
			}
			#endregion

			#region DefaultValue DV - �]�w�w�]��-�O�d(2)
			/// <summary>DV - �]�w�w�]��-�O�d(2)</summary>
			public static string DefaultValue
			{
				get{return "DV";}
			}
			#endregion

			#region Uppercase U - ��j�g
			/// <summary>U - ��j�g</summary>
			public static string UpperCase
			{
				get{return "U";}
			}
			#endregion

			#region Lowercase L - ��p�g
			/// <summary>L - ��p�g</summary>
			public static string LowerCase
			{
				get{return "L";}
			}
			#endregion

			#region FullString FS - ��J�r�������(�t�Ÿ�)
			/// <summary>FS - ��J�r�������(�t�Ÿ�)</summary>
			public static string FullString
			{
				get{return "FS";}
			}
			#endregion

			#region DateFormat DT - ������A
			/// <summary>DT - ������A</summary>
			public static string DateFormat
			{
				get{return "DT";}
			}
			#endregion

			#region TimeFormat T - �ɶ����A
			/// <summary>T - �ɶ����A</summary>
			public static string TimeFormat
			{
				get{return "T";}
			}
			#endregion

			#region FillZero F - �񺡹s(2)
			/// <summary>F - �񺡹s(2)</summary>
			public static string FillZero
			{
				get{return "F";}
			}
			#endregion

			#region Focus FC - ��а��d
			/// <summary>FC - ��а��d</summary>
			public static string Focus
			{
				get{return "FC";}
			}
			#endregion

			#region NameOrAddress NA - ����W�a
			/// <summary>NA - ����W�a</summary>
			public static string NameOrAddress
			{
				get{return "NA";}
			}
			#endregion

			#region IDNo I - �����ҲΤ@�s���ˮ�
			/// <summary>I - �����ҲΤ@�s���ˮ�</summary>
			public static string IdnBan
			{
				get{return "I";}
			}
			#endregion

			#region IP - IP �榡
			/// <summary>IP - IP �榡</summary>
			public static string IP
			{
				get{return "IP";}
			}
			#endregion

			#region TEL - �q�ܫ��A
			/// <summary>TEL - �q�ܫ��A</summary>
			public static string TEL
			{
				get{return "TEL";}
			}
			#endregion

			#region HTTP - ���}
			/// <summary>HTTP - ���}</summary>
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

	#region ��k
		#region Form �ݩʳ]�w
		#region IniFormSet ���� Server �� iniFormSet �ʧ@, �i�O�����A
		/// <summary>
		/// ���� Server �� iniFormSet �ʧ@, �i�O�����A
		/// </summary>
		/// <param name="control">���</param>
		/// <param name="argAry">��J�Ѽư}�C, ���ݥ]�t�޸���T</param>
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
						//=== �̪�����(2) ===
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
						//=== ��Ū(2) ===
						case "R":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'R'");
								((TextBox)control).ReadOnly	=	argAry[i + 1].Trim().Equals("1");
							}
							break;
						//=== ��Ƥ��t�p��(�t�t��) ===
						case "N":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'N'");
								((TextBox)control).Attributes.Add("style",	"ime-mode:disabled;");
								JScript.ControlEventAdd(control,	"onkeypress",	"_fe().onlyAllowNumPress(event)");
								JScript.ControlEventAdd(control,	"onkeyup",	"_fe().onlyAllowNumUp(event)");
							}
							break;
						//=== �Ʀr���A, �¼Ʀr ===
						case "N1":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'N1'");
								((TextBox)control).Attributes.Add("style",	"ime-mode:disabled;");
								JScript.ControlEventAdd(control,	"onkeypress",	"_fe().onlyAllowNumPress1(event)");
							}
							break;
						//=== �ȯ��J�^��μƦr(���t�Ÿ�) ===
						case "EN":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'EN'");
								((TextBox)control).Attributes.Add("style",	"ime-mode:disabled;");
								JScript.ControlEventAdd(control,	"onkeydown",	"_fe().lockAlphaNum(event)");
							}
							break;
						//=== ���\�^�ƤάY�Ǧr�� ===
						case "SE":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'SE'");
								((TextBox)control).Attributes.Add("style",	"ime-mode:disabled;");
								JScript.ControlEventAdd(control,	"onblur",	"_fe().lockAlphaNum1(event)");
							}
							break;
						//=== �Ʀr���A ##.##(2) ===
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
						//=== �Ʀr���A(���榡��) ##.##(2) ===
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
						//=== ����ƫ��A(���榡��) ##.##(2) ===
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
						//=== �Ʀr�϶� ##-##(2) ===
						case "NR":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'NR'");
								((TextBox)control).Attributes.Add("numberRange",	argAry[i + 1].Trim());
								JScript.ControlEventAdd(control,	"onblur",	"_fe().numberRngeCheck(event)");
							}
							break;
						//=== ����ϵL��(2) ===
						case "D":
							JScript.ControlEventAdd(control,	"IniFormSet",	"'D'");
							FormUtil.ControlEnabled(control, !argAry[i + 1].Trim().Equals("1"));
							break;
						//=== ����ؤo(2) ===
						case "S":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'S'");
								((TextBox)control).Attributes.Add("size",	argAry[i + 1].Trim());
							}
							break;
						//=== �� Style �w Szie ===
						case "S1":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'S'");
								((TextBox)control).Width	=	Convert.ToInt32(argAry[i + 1].Trim()) * 17;
							}
							break;
						//=== Key ���۰ʸ���(2) ===
						case "A":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'A'");
								JScript.ControlEventAdd(control,	"onkeyup",	"_fe().autoTab(event)");
								JScript.ControlEventAdd(control,	"onkeypress",	"_fe().autoTab1(event)");
							}
							break;
						//=== �]�w�w�]��(2) ===
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
						//=== �]�w�w�]��-�O�d(2) ===
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
						//=== ��j�g ===
						case "U":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'U'");
								JScript.ControlEventAdd(control,	"onkeyup",	"_fe().upperCase(event)");
								JScript.ControlEventAdd(control,	"onblur",	"this.value=this.value.toUpperCase()");
							}
							break;
						//=== ��p�g ===
						case "L":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'L'");
								JScript.ControlEventAdd(control,	"onkeyup",	"_fe().lowerCase(event)");
								JScript.ControlEventAdd(control,	"onblur",	"this.value=this.value.toLowerCase()");
							}
							break;
						//=== ��J�r�������(�t�Ÿ�) ===
						case "FS":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'FS'");
								JScript.ControlEventAdd(control,	"onblur",	"_fe().toFullStr(event)");
							}
							break;
						//=== ������A ===
						case "DT":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'DT'");
								JScript.ControlEventAdd(control,	"onfocus",	"_fe().formatDate(event)");
								JScript.ControlEventAdd(control,	"onblur",	"_fe().chkDate(event)");
							}
							break;
						//=== �ɶ����A ===
						case "T":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'T'");
								JScript.ControlEventAdd(control,	"onblur",	"_fe().chkTime(event)");
							}
							break;
						//=== �񺡬Y�r�� ===
						case "F":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'F'");
								JScript.ControlEventAdd(control,	"fillZero",	argAry[i + 1].Trim());
								JScript.ControlEventAdd(control,	"onblur",	"_fe().fillZero(event)");
							}
							break;
						//=== ��а��d ===
						case "FC":
							JScript.ControlEventAdd(control,	"IniFormSet",	"'FC'");
							control.Focus();
							break;
						//=== ����W�a ===
						case "NA":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'NA'");
								JScript.ControlEventAdd(control,	"onblur",	"_fe().toFullStrCheck(event)");
							}
							break;
						//=== �����ҲΤ@�s���ˮ� ===
						case "I":
							if (control.GetType().Name.Equals("TextBox"))
							{
								JScript.ControlEventAdd(control,	"IniFormSet",	"'I'");
								JScript.ControlEventAdd(control,	"onblur",	"_fe().checkID(event)");
							}
							break;
						//=== IP �ˮ� ===
						case "IP":
							if (control.GetType().Name.Equals("TextBox"))
							{
								((TextBox)control).Attributes.Add("style",	"ime-mode:disabled;");
								JScript.ControlEventAdd(control,	"IniFormSet",	"'IP'");
								JScript.ControlEventAdd(control,	"onblur",	"_fe().checkIP(event)");
							}
							break;
						//=== �q�ܫ��A�ˮ� ===
						case "TEL":
							if (control.GetType().Name.Equals("TextBox"))
							{
								((TextBox)control).Attributes.Add("style",	"ime-mode:disabled;");
								JScript.ControlEventAdd(control,	"IniFormSet",	"'TEL'");
								JScript.ControlEventAdd(control,	"onblur",	"_fe().checkTEL(event)");
							}
							break;
						//=== ���}�ˮ� ===
						case "HTTP":
							if (control.GetType().Name.Equals("TextBox"))
							{
								((TextBox)control).Attributes.Add("style",	"ime-mode:disabled;");
								JScript.ControlEventAdd(control,	"IniFormSet",	"'HTTP'");
								JScript.ControlEventAdd(control,	"onblur",	"_fe().checkURL(event)");
							}
							break;
						//=== EMAIL �ˮ� ===
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
				this.Logger.Append("Form_IniFormSet �Ѽƿ��~, control " + control.ClientID + ", arguments " + argAry.ToString() + ", �i����~�I�� " + lastProp);
				throw new Exception("Form_IniFormSet �Ѽƿ��~, control " + control.ClientID + ", arguments " + argAry.ToString() + ", �i����~�I�� " + lastProp);
			}
			catch (FormatException)
			{
				this.Logger.Append("Form_IniFormSet �Ѽƿ��~, control " + control.ClientID + ", arguments " + argAry.ToString() + ", �i����~�I�� " + lastProp);
				throw new Exception("Form_IniFormSet �Ѽƿ��~, control " + control.ClientID + ", arguments " + argAry.ToString() + ", �i����~�I�� " + lastProp);
			}
		}
		#endregion

		#region ControlEventAdd �s�W�[�ƥ�
		/// <summary>
		/// �s�W�[�ƥ�
		/// </summary>
		/// <param name="control">���</param>
		/// <param name="eventName">�ƥ�W��</param>
		/// <param name="funName">��k�W��</param>
		public static void ControlEventAdd(Control control, string eventName, string funName)
		{
			FormUtil.SetAttributeData(control, eventName, JScript.ProcessData(FormUtil.GetAttributeData(control, eventName), funName));
		}
		#endregion

		#region ProcessData �B�z�ݩʸ��
		/// <summary>
		/// �B�z�ݩʸ��
		/// </summary>
		/// <param name="oldAttribute">���ݩ�</param>
		/// <param name="newAttribute">�s�ݩ�</param>
		/// <returns></returns>
		public static string ProcessData(string oldAttribute, string newAttribute)
		{
			if (string.IsNullOrEmpty(oldAttribute))
				return newAttribute;
			else
				return oldAttribute + ";" + newAttribute;
		}
		#endregion

		#region ChkForm �]�w�ˬd���
		/// <summary>
		/// �]�w�ˬd���
		/// </summary>
		/// <param name="control">���</param>
		/// <param name="controlName">�������</param>
		public void ChkForm(Control control, string controlName)
		{
			JScript.ControlEventAdd(control, "chkForm", controlName);
		}
		#endregion
		#endregion

		#region ShowHidwLabel ���/���õe���W����
		/// <summary>
		/// ���/���õe���W����
		/// </summary>
		/// <param name="control">����</param>
		/// <param name="isShow">���/����</param>
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

		#region Javascript ��k�ʸ�
		#region DisableAll �I�s Client Script Form.disableAll �O�_�L�Ĥ�(Disable)�Ҧ�����
		/// <summary>
		/// �I�s Client Script Form.disableAll �O�_�L�Ĥ�(Disable)�Ҧ�����
		/// </summary>
		/// <param name="isDisable">�O/�_</param>
		public void DisableAll(bool isDisable)
		{
			if (isDisable)
				this.Script	=	"Form.disableAll(0, 1);";
			else
				this.Script	=	"Form.disableAll(0, 0);";
		}
		#endregion

		#region IniFormColor �]�w Client �� Form �C��
		/// <summary>
		/// �]�w Client �� Form �C��
		/// </summary>
		public void IniFormColor()
		{
			this.Script	=	"try{Form.iniFormColor();}catch(ex){}";
		}
        #endregion

        #region �]�w�B���L/Water Mark
        /// <summary>
        /// �]�w�B���L/Water Mark
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

        #region HideProcess �I�s Client �� Message.hideProcess ���ðT����
        /// <summary>
        /// �I�s Client �� Message.hideProcess ���ðT����
        /// </summary>
        public void HideProcess()
		{
            this.Script = "try{Message.hideProcess();}catch(ex){}";
		}
		#endregion

		#region OpenSuccess �I�s Client �� Message.openSuccess ��ܳB�z���\�T��
		/// <summary>
		///  �I�s Client �� Message.openSuccess ��ܳB�z���\�T��
		/// </summary>
		/// <param name="message">�n��ܪ��T��</param>
		public void OpenSuccess(string message)
		{
			this.Script	=	"try{Message.showDiv('__SuccessWindow', 1);}catch(ex){};Message.openSuccess('" + message + "');";
		}
		#endregion

		#region OpenSuccess �I�s Client �� Message.openSuccess ��ܳB�z���\�T��
		/// <summary>
		///  �I�s Client �� Message.openSuccess ��ܳB�z���\�T��
		/// </summary>
		/// <param name="message">�n��ܪ��T��</param>
		/// <param name="processFunction">�B�z�����n���檺 Function</param>
		public void OpenSuccess(string message, string processFunction)
		{
			this.Script	=	"try{Message.showDiv('__SuccessWindow', 1);}catch(ex){};Message.openSuccess('" + message + "', '" + processFunction + "');";
		}
		#endregion

		#region ShowMessage �I�s Client �� Message.showMessage ��ܳB�z���\�T��
		/// <summary>
		/// �I�s Client �� Message.showMessage ��ܳB�z���\�T��
		/// </summary>
		/// <param name="message">�T��</param>
		public void ShowMessage(string message)
		{
			if (String.IsNullOrEmpty(message))
				throw new System.ArgumentException("�ǤJ�ѼƤ��i���ŭ�", "message");
			
			this.Script	=	"Message.showMessage('" + message + "');";
		}
		#endregion

		#region Alert �I�s Client �� alert ��ܰT��
		/// <summary>
		/// �I�s Client �� alert ��ܰT��
		/// </summary>
		/// <param name="message">��ܰT��</param>
		/// <remarks></remarks>
		public void Alert(string message)
		{
			if (String.IsNullOrEmpty(message))
				throw new System.ArgumentException("�ǤJ�ѼƤ��i���ŭ�", "message");
			
			this.Script	=	"alert('" + message.Replace("\r\n", @"\r\n").Replace("'", "\'") + "');";
		}
		#endregion
		#endregion

		#region ExecAjaxClientScript ���� Client Javascript
		/// <summary>
		/// ���� Client Javascript
		/// </summary>
		/// <param name="page">Page ����</param>
		public void ExecAjaxClientScript(Page page)
		{
			ScriptManager.RegisterStartupScript(page, this.GetType(), "ClientScript" + key, this.Script, true);
			this.Script	=	"";
		}
		#endregion

		#region ExecClientScript ���� Client Javascript
		/// <summary>
		/// ���� Client Javascript
		/// </summary>
		public void ExecClientScript(Page page)
		{
			page.ClientScript.RegisterStartupScript(this.GetType(), "ClientScript" + key, this.Script, true);
			this.Script	=	"";
		}
		#endregion

		#region ButtonPermission �B�z���s�v���\��
		/// <summary>
		/// �B�z���s�v���\��
		/// </summary>
		public void ButtonPermission()
		{
			this.Script	=	"";
		}
		#endregion
	#endregion
	}
}