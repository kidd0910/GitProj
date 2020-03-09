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
	/// �� Web �������@�Τ�k
	/// </summary>
	public class FormUtil
	{
	#region ���c
		/// <summary>
		/// �w�q�e������
		/// </summary>
		public enum UIType: int
		{
			/// <summary>�d�ߵe��</summary>
			Query	=	0,
			/// <summary>�s��e��</summary>
			Edit	=	1,
			/// <summary>�d�ߵ��G�e��</summary>
			Result	=	2,
		}

		/// <summary>
		/// �w�q�e������
		/// </summary>
		public enum FormatType: int
		{
			/// <summary>Grid �e�{</summary>
			Grid	=	0,
			/// <summary>�s��e�{</summary>
			Edit	=	1,
			/// <summary>�¤�r�e�{</summary>
			Label	=	2,
			/// <summary>����e�{</summary>
			Report	=	3,
		}
	#endregion

	#region �ݩ�
		/// <summary>
		/// ���o Response ����
		/// </summary>
		public static HttpResponse Response
		{
			get{return HttpContext.Current.Response;}
		}

		/// <summary>
		/// ���o Request ����
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
		/// ���o Session ����
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
		/// ���o Application ����
		/// </summary>
		public static HttpApplicationState Application
		{
			get{return HttpContext.Current.Application;}
		}

		/// <summary>
		/// ���o Server ����
		/// </summary>
		public static HttpServerUtility Server
		{
			get{return HttpContext.Current.Server;}
		}

		/// <summary>
		/// ���o Cache ����
		/// </summary>
		public static  Cache Cache
		{
		        get{return HttpContext.Current.Cache;}
		}
	#endregion

	#region ��k
		#region ToKeyObject �N Request �ର Javascript ����, var keyObj = {key1:value,key2:value};
		/// <summary>
		/// �N Request �ର Javascript ����, var keyObj = {key1:value,key2:value};
		/// </summary>
		/// <returns>Js ���</returns>
		public static string ToKeyObject()
		{
			HttpRequest	request		=	FormUtil.Request;
			StringBuilder	objBuff		=	new StringBuilder();
			objBuff.Append("<script>");
			
			//=== �N�e�����Ҧ����ܼƦW�٩�J Enumeration �� ===
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

		#region HasSession �ˮ� Session ��T, �O�_�D�k�n�J env.conf [SKIP_SESSION_VALID] [VALIDE_SESSION_NAME]
		/// <summary>
		/// �ˮ� Session ��T, �O�_�D�k�n�J env.conf [SKIP_SESSION_VALID] [VALIDE_SESSION_NAME]
		/// </summary>
		/// <returns>�O/�_</returns>
		public static Boolean HasSession()
		{
			HttpSessionState	session		=	FormUtil.Session;
			HttpRequest		request		=	FormUtil.Request;

			//=== �P�_ Session �O�s�٦s�b(���`�n�J), ���s�b��X�h ===
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

		#region SetControlValue �]�w�������
		/// <summary>
		/// �]�w�������
		/// </summary>
		/// <param name="control">���</param>
		/// <param name="value">��l��</param>
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

        #region SetControlText �]�w��������
        /// <summary>
        /// �]�w��������
        /// </summary>
        /// <param name="control">���</param>
        /// <param name="value">��l��</param>
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

		#region SetControlDisable �]�w����O�_��Ū
		/// <summary>
		/// �]�w����O�_��Ū
		/// </summary>
		/// <param name="control">���</param>
		/// <param name="isDisable">�O�_��Ū</param>
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

		#region GetControlValue ���o�������
		/// <summary>
		/// ���o�������
		/// </summary>
		/// <param name="control">���</param>
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

		#region GetAttributeData ���������ݩʭ�
		/// <summary>
		/// ���������ݩʭ�
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

		#region GetAttributeData ���������ݩʭ�
		/// <summary>
		/// �]�w������ݩʭ�
		/// </summary>
		/// <param name="control">���</param>
		/// <param name="arg">�ݩʦW��</param>
		/// <param name="value">�ݩʭ�</param>
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

		#region GetControlValidationGroupData ���o����w�q�� ValidationGroup �ݩʭ� 
		/// <summary>
		/// ���o����w�q�� ValidationGroup �ݩʭ� 
		/// </summary>
		/// <param name="control">���</param>
		/// <returns>ValidationGroup �ݩʭ�</returns>
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

		#region SetControlValidationGroup �]�w����� ValidationGroup �� 
		/// <summary>
		/// �]�w����� ValidationGroup �� 
		/// </summary>
		/// <param name="control">���</param>
		/// <param name="data">�ݩʭ�</param>
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

		#region BindCheckBoxList ���X BindCheckBoxList ���
		/// <summary>
		/// ���X BindCheckBoxList ���
		/// </summary>
		/// <param name="item">�U�Ԫ���</param>
		/// <param name="dataSource">��ƨӷ�����</param>
		/// <param name="valueField">value �����</param>
		/// <param name="textField">text �����</param>
		/// <param name="repeatColumns">��ܪ����</param>
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

		#region BindRadioButtonList ���X RadioButtonList ���
		/// <summary>
		/// ���X RadioButtonList ���
		/// </summary>
		/// <param name="item">�U�Ԫ���</param>
		/// <param name="dataSource">��ƨӷ�����</param>
		/// <param name="valueField">value �����</param>
		/// <param name="textField">text �����</param>
		/// <param name="repeatColumns">��ܪ����</param>
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

		#region BindDropDownList ���X DropDownList ���
		/// <summary>
		/// ���X DropDownList ���
		/// </summary>
		/// <param name="item">�U�Ԫ���</param>
		/// <param name="dataSource">��ƨӷ�����</param>
		/// <param name="valueField">value �����</param>
		/// <param name="textField">text �����</param>
		/// <param name="uIType">UI ����</param>
		/// <param name="hasEmpty">�O�_�n�]�t�ťո��</param>
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

				//=== �w��d�ߤU��, �j�w����v�������� ===
				if (uIType == UIType.Query)
				{
					if (dataSource.GetType().Name.Equals("DataTable"))
					{	
						DataTable	dt	=	(DataTable)dataSource;
						//=== ���j�w�v���� ===
						if (dt.Columns["HAS_FILTERX"] != null)
						{
							for (int i = 0; i < dt.Columns.Count; i++)
							{
								if (dt.Columns[i].ColumnName.IndexOf("��") != -1)
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

		#region BindListBox ���X ListBox ���
		/// <summary>
		/// ���X ListBox ���
		/// </summary>
		/// <param name="item">�h��U�Ԫ���</param>
		/// <param name="dataSource">��ƨӷ�����</param>
		/// <param name="valueField">value �����</param>
		/// <param name="textField">text �����</param>
		/// <param name="uIType">UI ����</param>
		/// <param name="hasEmpty">�O�_�n�]�t�ťո��</param>
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

		#region SetDropdownListEmptyList �]�w�ťդU�Կ�檺��
		/// <summary>
		/// �]�w�ťդU�Կ�檺��
		/// </summary>
		/// <param name="item">�U�Ԫ���</param>
		/// <param name="uIType">UI ����</param>
		public static void SetDropdownListEmptyList(DropDownList item, UIType uIType)
		{
            //=== �_�l���� ===
            LogUtil logUtil = new LogUtil("");
            DBUtil dbUtil = new DBUtil(logUtil);
            LangUtil langUtil = new LangUtil(logUtil.Logger, dbUtil.DBManager);
			

			if (item.Items.Count > 0 && (item.Items[0].Value.Equals("") || item.Items[0].Value.Trim().StartsWith("@#@")))
				return;

			switch(uIType)
			{
				case FormUtil.UIType.Query:
                    item.Items.Insert(0, new ListItem("����", ""));
					break;
				case FormUtil.UIType.Edit:
				case FormUtil.UIType.Result:
					item.Items.Insert(0, new ListItem("", ""));
					break;
			}
		}
		#endregion

		#region ��������\��
		/// <summary>
		/// �ˬd�O�_�]�t�Y�ر��
		/// </summary>
		/// <param name="currObject">�ˬd�������</param>
		/// <param name="controlType">�ˬd���󫬺A Exp: System.Web.UI.LiteralControl</param>
		/// <returns>�O�_�]�t�Y�ر��</returns>
		public static bool CheckControlByType (Control currObject, string controlType)
		{
			if (string.IsNullOrEmpty(controlType))
				throw new System.ArgumentException("���ର�Ÿ��", "controlType");
			
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

		#region FindControlByType �̾ڱ�����A�M�䱱�
		/// <summary>
		/// �̾ڱ�����A�M�䱱�
		/// </summary>
		/// <param name="currObject">�ˬd�������</param>
		/// <param name="controlType">�ˬd���󫬺A Exp: System.Web.UI.LiteralControl</param>
		/// <returns>���</returns>
		public static object FindControlByType(Control currObject, string controlType) 
		{
			if (string.IsNullOrEmpty(controlType))
				throw new System.ArgumentException("���ର�Ÿ��", "controlType");

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

		#region ProcessSQLInjection �B�z�m���|�o�� SQLInjection �����, �Ϊ��B���A��ƳB�z
		/// <summary>
		/// �B�z�m���|�o�� SQLInjection �����, �Ϊ��B���A��ƳB�z
		/// </summary>
		/// <param name="currObject">�ˬd�������</param>
		/// <param name="isPageLoad">�O�_���������J</param>
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
							//=== ���B�B�z�m���ʧ@ ===
							if ((GetAttributeData(obj, "DD") != null && GetAttributeData(obj, "DD").Equals("A")) && !((TextBox)obj).Text.Equals(""))
								((TextBox)obj).Text	=	((TextBox)obj).Text.Replace(",", "");
							//=== �ɶ��B�z�m���ʧ@ ===
							if ((GetAttributeData(obj, "DD") != null && GetAttributeData(obj, "DD").Equals("T")) && !((TextBox)obj).Text.Equals(""))
								((TextBox)obj).Text	=	((TextBox)obj).Text.Replace(":", "");
							//=== ����榡�B�z ===
							if ((GetAttributeData(obj, "DD") != null && GetAttributeData(obj, "DD").Equals("CD")) && !((TextBox)obj).Text.Equals(""))
								((TextBox)obj).Text	=	DateUtil.ConvertCDate(((TextBox)obj).Text, "yyyy/MM/dd");
						}
						else
						{
							((TextBox)obj).Text	=	((TextBox)obj).Text.Replace("''", "'");
							//=== ���B�B�z�m���ʧ@ ===
							if ((GetAttributeData(obj, "DD") != null && GetAttributeData(obj, "DD").Equals("A")) && !((TextBox)obj).Text.Equals(""))
								((TextBox)obj).Text	=	Convert.ToDouble(((TextBox)obj).Text).ToString("#,##0.########");
							//=== �ɶ��B�z�m���ʧ@ ===
							if ((GetAttributeData(obj, "DD") != null && GetAttributeData(obj, "DD").Equals("T")) && !((TextBox)obj).Text.Equals(""))
								((TextBox)obj).Text	=	DateUtil.FormatTime(((TextBox)obj).Text);
							//=== ����榡�B�z ===
							if ((GetAttributeData(obj, "DD") != null && GetAttributeData(obj, "DD").Equals("CD")) && !((TextBox)obj).Text.Equals(""))
							{
								try
								{
									((TextBox)obj).Text	=	DateUtil.FormatCDate(DateUtil.ConvertDate(((TextBox)obj).Text));
								}
								catch (Exception)
								{
									throw new Exception(((TextBox)obj).ID + " ����榡���~:" + ((TextBox)obj).Text);
								}
							}
						}
						break;
					case "HiddenField":
						if (isPageLoad)
						{
							((HiddenField)obj).Value	=	((HiddenField)obj).Value.Replace("'", "''");
							//=== ���B�B�z�m���ʧ@ ===
							if ((GetAttributeData(obj, "DD") != null && (GetAttributeData(obj, "DD").Equals("A") || GetAttributeData(obj, "DD").Equals("N3"))) 
								&& !((TextBox)obj).Text.Equals(""))
								((HiddenField)obj).Value	=	((HiddenField)obj).Value.Replace(",", "");
							//=== �ɶ��B�z�m���ʧ@ ===
							if ((GetAttributeData(obj, "DD") != null && GetAttributeData(obj, "DD").Equals("T")) && !((TextBox)obj).Text.Equals(""))
								((HiddenField)obj).Value	=	((HiddenField)obj).Value.Replace(":", "");
							//=== ����榡�B�z ===
							if ((GetAttributeData(obj, "DD") != null && GetAttributeData(obj, "DD").Equals("CD")) && !((TextBox)obj).Text.Equals(""))
								((HiddenField)obj).Value	=	DateUtil.ConvertCDate(((HiddenField)obj).Value, "yyyy/MM/dd");
						}
						else
						{
							((HiddenField)obj).Value	=	((HiddenField)obj).Value.Replace("''", "'");
							//=== ���B�B�z�m���ʧ@ ===
							if ((GetAttributeData(obj, "DD") != null && (GetAttributeData(obj, "DD").Equals("A") || GetAttributeData(obj, "DD").Equals("N3"))) 
								&& !((TextBox)obj).Text.Equals(""))
							{
								((HiddenField)obj).Value	=	Convert.ToDouble(((HiddenField)obj).Value).ToString("#,##0.########");
							}
							//=== �ɶ��B�z�m���ʧ@ ===
							if ((GetAttributeData(obj, "DD") != null && GetAttributeData(obj, "DD").Equals("T")) && !((TextBox)obj).Text.Equals(""))
							{
								((HiddenField)obj).Value	=	DateUtil.FormatTime(((HiddenField)obj).Value);
							}
							//=== ����榡�B�z ===
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

		#region FindUserControls �̾ڱ�����A�M�䱱����X
		/// <summary>
		/// �̾ڱ�����A�M�䱱����X
		/// </summary>
		/// <param name="currObject">�ˬd�������</param>
		/// <param name="controls">������X</param>
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

		#region FindHasValidationGroupControls �M��]�t ValidationGroup �ݩʪ����
		/// <summary>
		/// �M��]�t ValidationGroup �ݩʪ����
		/// </summary>
		/// <param name="currObject">�ˬd�������</param>
		/// <param name="controls">������X</param>
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

		#region FindNoEditControls �M�䤣�i�s�誺���
		/// <summary>
		/// �M�䤣�i�s�誺���
		/// </summary>
		/// <param name="currObject">�ˬd�������</param>
		/// <param name="controls">������X</param>
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

        #region FindUIDDControls �̾ڱ���e��X�M�䱱� (M_/Q_)
        /// <summary>
        /// �̾ڱ���e��X�M�䱱� (M_/Q_),2017.12.14 �W�[ UVWXYZ
        /// </summary>
        /// <param name="currObject">�ˬd�������</param>
        /// <param name="controls">������X</param>
        public static void FindUIDDControls(Control currObject, ArrayList controls)
        {
            string[] prefixes = { "M_", "Q_", "G_", "V_", "X_", "Y_", "Z_", "W_", "U_", "GOV_", "C_", "F_"};

            foreach (Control obj in currObject.Controls)
            {
                if (obj.ID != null && obj.ID.Length > 2)
                {

                    if (prefixes.Any(prefix => obj.ID.ToString().StartsWith(prefix)))
                        controls.Add(obj);

                    //=== �ĤG�X�� _ Exp: M_, Q_... ===
                    // if (obj.ID.ToString().StartsWith("M_") ||
                    // obj.ID.ToString().StartsWith("Q_") || obj.ID.ToString().StartsWith("G_") || obj.ID.ToString().StartsWith("W_") || obj.ID.ToString().StartsWith("X_") || obj.ID.ToString().StartsWith("Y_") || obj.ID.ToString().StartsWith("Z_"))
                    //controls.Add(obj);
                }

                if (obj.HasControls())
                    FindUIDDControls(obj, controls);
            }
        }
        #endregion

        #region FindUIMLControls �̾��ݩʴM�䱱�, �h��y�t�� (CL_/CB_/PL_/PB_)
        /// <summary>
        /// �̾��ݩʴM�䱱�, �h��y�t�� (CL_/CB_/PL_/PB_)
        /// </summary>
        /// <param name="currObject">�ˬd�������</param>
        /// <param name="controls">������X</param>
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

		#region GetGridCondition ���o Grid ����
		/// <summary>
		/// ���o Grid ����
		/// </summary>
		/// <param name="keyValue">��Ȧr��</param>
		/// <returns>���o���󵲪G</returns>
		public static string GetGridCondition(string keyValue)
		{
			StringBuilder	condBuff	=	new StringBuilder();
			string[]	keyAry		=	keyValue.Split('$');
			string[]	field;

			for (int i = 0; i < keyAry.Length; i++)
			{
				if (i > 0)
					condBuff.Append(" OR ");

				//=== �զX���� ===
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

		#region GetGridKeyMap ���o Grid ���󶰦X
		/// <summary>
		/// ���o Grid ���󶰦X
		/// </summary>
		/// <param name="keyValue">��Ȧr��</param>
		/// <returns>���o���󵲪G</returns>
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

		#region ControlEnabled ��� Enable ��k
		/// <summary>
		/// ��� Enable ��k
		/// </summary>
		/// <param name="control">���</param>
		/// <param name="enabled">�O�_ Enable</param>
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
