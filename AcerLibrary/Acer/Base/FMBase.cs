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
	/// Form Manager �~�Ӥ���
	/// </summary>
	public class FMBase
	{
	#region �غc�l
		/// <summary>
		/// �غc�l, ��Ϥ� Page ����ι��� UI ����
		/// </summary>
		/// <param name="page">Page ����</param>
		public FMBase(PageBase page)
		{
			this.Page	=	page;
			this.DBManager	=	this.Page.DBManager;
			this.LogUtil	=	this.Page.LogUtil;
		}
	#endregion 

	#region �ݩ�
		private	Hashtable	pPropertyMap	=	new Hashtable();

		#region PropertyMap �]�w���o�ݩʭ�
		/// <summary>�]�w���o�ݩʭ�</summary>
		protected Hashtable PropertyMap
		{
			get{return this.pPropertyMap;}
		}
		#endregion 

		#region DBManager �]�w�s�� DBManager ������
		/// <summary>�]�w�s�� DBManager ������</summary>
		protected DBManager DBManager
		{
			get{return (DBManager)this.PropertyMap["DBManager"];}
			set{this.PropertyMap["DBManager"]	=	value;}
		}
		#endregion 

		#region ResultData �^�Ǹ�ƶ��X
		/// <summary>�^�Ǹ�ƶ��X</summary>
		public DataTable ResultData
		{
			get{return (DataTable)this.PropertyMap["ResultData"];}
			set{this.PropertyMap["ResultData"]	=	value;}
		}
		#endregion 

		#region PageNo  �]�w�ثe����
		/// <summary>�]�w�ثe����</summary>
		public int PageNo
		{
			get{return (int)this.PropertyMap["PageNo"];}
			set{this.PropertyMap["PageNo"]	=	value;}
		}
		#endregion

		#region PageSize  �C������
		/// <summary>�C������</summary>
		public int PageSize
		{
			get{return (int)this.PropertyMap["PageSize"];}
			set{this.PropertyMap["PageSize"]	=	value;}
		}
		#endregion

		#region TotalRowCount  �`����
		/// <summary>�`����</summary>
		public int TotalRowCount
		{
			get{return (int)this.PropertyMap["TotalRowCount"];}
			set{this.PropertyMap["TotalRowCount"]	=	value;}
		}
		#endregion

		#region UpdateCount  �ק��s����
		/// <summary>�ק��s����</summary>
		public int UpdateCount
		{
			get{return (int)this.PropertyMap["UpdateCount"];}
			set{this.PropertyMap["UpdateCount"]	=	value;}
		}
		#endregion

		#region Application ���o Application ����
		/// <summary>���o Application ����</summary>
		protected HttpApplicationState Application
		{
			get{return FormUtil.Application;}
		}
		#endregion

		#region Session ���o Session ����
		/// <summary>���o Session ����</summary>
		protected HttpSessionState Session
		{
			get{return FormUtil.Session;}
		}
		#endregion

		#region Request ���o Request ����
		/// <summary>���o Request ����</summary>
		protected HttpRequest Request
		{
			get{return FormUtil.Request;}
		}
		#endregion

		#region Response ���o Response ����
		/// <summary>���o Response ����</summary>
		protected HttpResponse Response
		{
			get{return FormUtil.Response;}
		}
		#endregion

		#region Page ���o Page ����
		/// <summary>���o Page ����</summary>
		protected PageBase Page
		{
			get{return (PageBase)this.PropertyMap["Page"];}
			set{this.PropertyMap["Page"]	=	value;}
		}
		#endregion

		#region LogUtil �]�w LogUtil ����
		/// <summary>LogUtil �]�w LogUtil ����</summary>
		protected LogUtil LogUtil 
		{
			get{return (LogUtil)this.PropertyMap["LogUtil"];}
			set{this.PropertyMap["LogUtil"]	=	value;}
		}
		#endregion

		#region Logger Ū�� Log ����
		/// <summary>Ū�� Log ����</summary>
		protected MyLogger Logger
		{
			get{return this.LogUtil.Logger;}
		}
		#endregion
	#endregion 

	#region ��k"
		#region �B�z����
		#region ���o������T
		/// <summary>
		/// ���o PageControl �� PageNo ��
		/// <param name="defaultPageControlId">�w�]����W��</param>
		/// </summary>
		protected string PageControlPageNo(string defaultPageControlId)
		{
			if (this.HiddenField("ActivePageControl") == null)
				this.Logger.Append("�����]�w HiddenField ��� ID [ActivePageControl]");
			
			if (!String.IsNullOrEmpty(this.HiddenField("ActivePageControl").Value))
				return ((TextBox)this.UserControl(this.HiddenField("ActivePageControl").Value).FindControl("PageNo")).Text;
			else
				return ((TextBox)this.UserControl(defaultPageControlId).FindControl("PageNo")).Text;
		}

		/// <summary>
		/// ���o ScrollSize ��
		/// <param name="defaultPageControlId">�w�]����W��</param>
		/// </summary>
		protected string PageControlPageSize(string defaultPageControlId)
		{
			if (this.HiddenField("ActivePageControl") == null)
				this.Logger.Append("������]�w --> ActivePageControl");
			
			if (!String.IsNullOrEmpty(this.HiddenField("ActivePageControl").Value))
				return ((TextBox)this.UserControl(this.HiddenField("ActivePageControl").Value).FindControl("PageSize")).Text;
			else
				return ((TextBox)this.UserControl(defaultPageControlId).FindControl("PageSize")).Text;
		}
		#endregion
		#endregion

		#region ���o�ഫ������A���
		#region UserControl ���o UserControl ���
		/// <summary>
		/// ���o UserControl ���
		/// </summary>
		/// <param name="fieldName">����W��</param>
		/// <returns>UserControl ���</returns>
		protected UserControl UserControl(string fieldName) 
		{
			return (UserControl)this.Page.FindControl(fieldName);
		}
		#endregion 

		#region TextBox ���o TextBox ���
		/// <summary>
		/// ���o TextBox ���
		/// </summary>
		/// <param name="fieldName">����W��</param>
		/// <returns>TextBox ���</returns>
		protected TextBox TextBox(string fieldName)
		{
			return (TextBox)this.Page.FindControl(fieldName);
		}
		#endregion 

		#region ListBox ���o ListBox ���
		/// <summary>
		/// ���o ListBox ���
		/// </summary>
		/// <param name="fieldName">����W��</param>
		/// <returns>ListBox ���</returns>
		protected ListBox ListBox(string fieldName)
		{
			return (ListBox)this.Page.FindControl(fieldName);
		}
		#endregion 

		#region Label ���o Label ���
		/// <summary>
		/// ���o Label ���
		/// </summary>
		/// <param name="fieldName">����W��</param>
		/// <returns>Label ���</returns>
		protected Label Label(string fieldName)
		{
			return (Label)this.Page.FindControl(fieldName);
		}
		#endregion 

		#region DropDownList ���o DropDownList ���
		/// <summary>
		/// ���o DropDownList ���
		/// </summary>
		/// <param name="fieldName">����W��</param>
		/// <returns>DropDownList ���</returns>
		protected DropDownList DropDownList(string fieldName)
		{
			return (DropDownList)this.Page.FindControl(fieldName);
		}
		#endregion 

		#region CheckBox ���o CheckBox ���
		/// <summary>
		/// ���o CheckBox ���
		/// </summary>
		/// <param name="fieldName">����W��</param>
		/// <returns>CheckBox ���</returns>
		protected CheckBox CheckBox(string fieldName)
		{
			return (CheckBox)this.Page.FindControl(fieldName);
		}
		#endregion 

		#region CheckBoxList ���o CheckBoxList ���
		/// <summary>
		/// ���o CheckBoxList ���
		/// </summary>
		/// <param name="fieldName">����W��</param>
		/// <returns>CheckBoxList ���</returns>
		protected CheckBoxList CheckBoxList(string fieldName) 
		{
			return (CheckBoxList)this.Page.FindControl(fieldName);
		}
		#endregion 

		#region RadioButton ���o RadioButton ���
		/// <summary>
		/// ���o RadioButton ���
		/// </summary>
		/// <param name="fieldName">����W��</param>
		/// <returns>RadioButton ���</returns>
		protected RadioButton RadioButton(string fieldName)
		{
			return (RadioButton)this.Page.FindControl(fieldName);
		}
		#endregion 

		#region RadioButtonList ���o RadioButtonList ���
		/// <summary>
		/// ���o RadioButtonList ���
		/// </summary>
		/// <param name="fieldName">����W��</param>
		/// <returns>RadioButtonList ���</returns>
		protected RadioButtonList RadioButtonList(string fieldName)
		{
			return (RadioButtonList)this.Page.FindControl(fieldName);
		}
		#endregion 

		#region HiddenField ���o HiddenField ���
		/// <summary>
		/// ���o HiddenField ���
		/// </summary>
		/// <param name="fieldName">����W��</param>
		/// <returns>HiddenField ���</returns>
		protected HiddenField HiddenField(string fieldName)
		{
			return (HiddenField)this.Page.FindControl(fieldName);
		}
		#endregion 
		#endregion

		#region GetFromCondition �̾ڬd�ߵe�����(TextBox ���A)���ͱ���
		/// <summary>
		/// �̾ڬd�ߵe�����(TextBox ���A)���ͱ���
		/// </summary>
		/// <param name="fieldName">�e�����W��</param>
		/// <returns>�d�߱���</returns>
		protected string GetFromCondition(string fieldName)
		{
			if (string.IsNullOrEmpty(fieldName))
				throw new ArgumentException("���Ȥ��i�ť�", fieldName);

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

					//=== ���o�ˮ֦r�� ===
					validData	=	FormUtil.GetControlValidationGroupData(tmpControl);
					//=== ���o�ˮֺ��� ===
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
