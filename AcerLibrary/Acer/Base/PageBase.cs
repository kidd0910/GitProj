using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Data.Common;
using Acer.Log;
using Acer.DB;
using Acer.Apps;
using Acer.Util;
using System.Data;
using Acer.Form;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Reflection;
using System.Threading;
using Acer.Err;
using System.Text.RegularExpressions;
using System.Web.SessionState;

namespace Acer.Base
{   
    /// <summary>
    /// Control �~�Ӥ���, ��Ϥ� UI ����
    /// </summary>
    /// <remarks></remarks>
    public class PageBase : Page
    {        
        private ArrayList ddUserControls = new ArrayList();

        #region �ݩ�
        private Hashtable pPropertyMap = new Hashtable();                

        #region CommonUIMap ���o CommonUI�ݩ�
        /// <summary>���o�ݩ�</summary>
        protected Hashtable CommonUIMap
        {
            get
            {
                if (this.ViewState["pCommonUIMap"] == null)
                    this.ViewState["pCommonUIMap"] = new Hashtable();

                return (Hashtable)this.ViewState["pCommonUIMap"];
            }
        }
        #endregion

        #region PropertyMap ���o�ݩ�
        /// <summary>���o�ݩ�</summary>
        protected Hashtable PropertyMap
        {
            get { return (Hashtable)this.pPropertyMap; }
        }
        #endregion

        private static object lockObj = new object();

        #region AjaxErrLog �]�w AjaxErrLog���~�T��
        private static Hashtable errMap = new Hashtable();
        /// <summary>�]�w AjaxErrLog���~�T��</summary>
        public static string AjaxErrLog
        {
            get
            {
                //=== ��X���~�T�� ===
                Hashtable errMap = MultiProcess.ChoiceHashtable(MultiProcess.GetRealGlobalValue("AJAX_ERROR"));
                string errLog = (string)errMap["AjaxErr" + FormUtil.Session.SessionID];
                //=== �����ӰT�� ===
                errMap.Remove("AjaxErr" + FormUtil.Session.SessionID);
                //=== �^��T�� ===
                MultiProcess.SetGlobalValue("AJAX_ERROR", errMap);
                return errLog;
            }
            set
            {
                Hashtable errMap = MultiProcess.ChoiceHashtable(MultiProcess.GetRealGlobalValue("AJAX_ERROR"));
                errMap["AjaxErr" + FormUtil.Session.SessionID] = value;
                MultiProcess.SetGlobalValue("AJAX_ERROR", errMap);
            }
            //                        get
            //                        {
            //                                string	errLog	=	"";
            //                                try
            //                                {
            //                                        if (FormUtil.Session["Ajax_Error"] != null)
            //                                        {
            //                                                errLog	=	FormUtil.Session["Ajax_Error"].ToString();
            //System.IO.File.AppendAllText(APConfig.RealPath + @"Temp\Log\MsgTimeList.txt", DateUtil.GetNowDateTime() + ": session get - " + FormUtil.Session.SessionID + ".msg\r\n" + errLog + "\r\n");
            //                                                return errLog;
            //                                        }

            //                                        lock(lockObj)
            //                                        {
            //                                                if (!System.IO.File.Exists(APConfig.RealPath + @"Temp\Log\" + FormUtil.Session.SessionID + ".msg"))
            //                                                        return "";
            //                                                else
            //                                                {
            //                                                        errLog	=	System.IO.File.ReadAllText(APConfig.RealPath + @"Temp\Log\" + FormUtil.Session.SessionID + ".msg");
            //                                                        System.IO.File.Delete(APConfig.RealPath + @"Temp\Log\" + FormUtil.Session.SessionID + ".msg");	
            //System.IO.File.AppendAllText(APConfig.RealPath + @"Temp\Log\MsgTimeList.txt", DateUtil.GetNowDateTime() + ": get - " + FormUtil.Session.SessionID + ".msg\r\n" + errLog + "\r\n");
            //                                                }
            //                                        }
            //                                }
            //                                catch(Exception)
            //                                {
            //                                        lock(lockObj)
            //                                        {
            //                                                System.IO.File.Delete(APConfig.RealPath + @"Temp\Log\" + FormUtil.Session.SessionID + ".msg");	
            //System.IO.File.AppendAllText(APConfig.RealPath + @"Temp\Log\MsgTimeList.txt", DateUtil.GetNowDateTime() + ": ex get - " + FormUtil.Session.SessionID + ".msg\r\n" + errLog + "\r\n");
            //                                        }
            //                                }
            //                                return errLog;
            //                        }
            //                        set
            //                        {
            //                                lock(lockObj)
            //                                {
            //System.IO.File.AppendAllText(APConfig.RealPath + @"Temp\Log\MsgTimeList.txt", DateUtil.GetNowDateTime() + ": set - " + FormUtil.Session.SessionID + ".msg\r\n" + value + "\r\n");
            //                                        FormUtil.Session["Ajax_Error"]	=	value;
            //                                        System.IO.File.AppendAllText(APConfig.RealPath + @"Temp\Log\" + FormUtil.Session.SessionID + ".msg", value);
            //                                }
            //                        }
        }
        #endregion

        #region DBUtil �]�w DBUtil ����
        /// <summary>DBUtil �]�w DBUtil ����</summary>
        protected DBUtil DBUtil
        {
            get { return (DBUtil)this.PropertyMap["DBUtil"]; }
            set { this.PropertyMap["DBUtil"] = value; }
        }
        #endregion

        #region LangUtil �]�w LangUtil ����
        /// <summary>LangUtil �]�w LangUtil ����</summary>
        protected LangUtil LangUtil
        {
            get { return (LangUtil)this.PropertyMap["LangUtil"]; }
            set { this.PropertyMap["LangUtil"] = value; }
        }
        #endregion

        #region LogUtil �]�w LogUtil ����
        /// <summary>LogUtil �]�w LogUtil ����</summary>
        public LogUtil LogUtil
        {
            get { return (LogUtil)this.PropertyMap["LogUtil"]; }
            set { this.PropertyMap["LogUtil"] = value; }
        }
        #endregion

        #region DBManager �]�w DBManager ����
        /// <summary>DBManager �]�w DBManager ����</summary>
        public DBManager DBManager
        {
            get { return this.DBUtil.DBManager; }
        }
        #endregion

        #region JScript �]�w JScript ����
        /// <summary>JScript �]�w JScript ����</summary>
        protected JScript JScript
        {
            get { return (JScript)this.PropertyMap["JScript"]; }
            set { this.PropertyMap["JScript"] = value; }
        }
        #endregion

        #region Exception �]�w Exception ����
        /// <summary>Exception �]�w Exception ����</summary>
        protected Exception Exception
        {
            get { return (Exception)this.PropertyMap["Exception"]; }
            set { this.PropertyMap["Exception"] = value; }
        }
        #endregion

        #region ScriptManager �]�w ScriptManager ����
        /// <summary>ScriptManager �]�w ScriptManager ����</summary>
        protected ScriptManager ScriptManager
        {
            get { return (ScriptManager)this.PropertyMap["ScriptManager"]; }
            set { this.PropertyMap["ScriptManager"] = value; }
        }
        #endregion

        #region Logger Ū�� Log ����
        /// <summary>Logger Ū�� Log ����</summary>
        protected MyLogger Logger
        {
            get { return this.LogUtil.Logger; }
        }
        #endregion

        #region PageRangeSize �����϶��j�p
        /// <summary>PageRangeSize �����϶��j�p</summary>
        protected int PageRangeSize
        {
            get { return (int)this.PropertyMap["PageRangeSize"]; }
            set { this.PropertyMap["PageRangeSize"] = value; }
        }
        #endregion

        #region PageNo  �]�w�ثe����
        /// <summary>�]�w�ثe����</summary>
        public int PageNo
        {
            get { return (int)this.PropertyMap["PageNo"]; }
            set { this.PropertyMap["PageNo"] = value; }
        }
        #endregion

        #region PageSize  �C������
        public const int defaultPageSize = 20;
        /// <summary>�C������</summary>
        public int PageSize
        {
            get { return (int)this.PropertyMap["PageSize"]; }
            set { this.PropertyMap["PageSize"] = value; }
        }
        #endregion


        #region TotalRowCount �`����
        /// <summary>TotalRowCount �`����</summary>
        protected int TotalRowCount
        {
            get { return (int)this.PropertyMap["TotalRowCount"]; }
            set { this.PropertyMap["TotalRowCount"] = value; }
        }
        #endregion

        #region IsListShow �O�_�����@���J�Y���
        /// <summary>IsListShow �O�_�����@���J�Y���</summary>
        public bool IsListShow
        {
            get { return (bool)this.PropertyMap["IsListShow"]; }
            set { this.PropertyMap["IsListShow"] = value; }
        }
        #endregion

        #region IsAjax �O�_�� Ajax �ǰe�覡
        /// <summary>IsAjax �O�_�� Ajax �ǰe�覡</summary>
        private bool IsAjax
        {
            get { return (bool)this.PropertyMap["IsAjax"]; }
            set { this.PropertyMap["IsAjax"] = value; }
        }
        #endregion

        #region IsLog �O�_���� Log
        /// <summary>IsLog �O�_���� Lo</summary>
        protected bool IsLog
        {
            get { return (bool)this.PropertyMap["IsLog"]; }
            set { this.PropertyMap["IsLog"] = value; }
        }
        #endregion

        #region IsDoIOLog �O�_���� Log
        /// <summary>IsDoIOLog �O�_���� Lo</summary>
        protected bool IsDoIOLog
        {
            get { return (bool)this.PropertyMap["IsDoIOLog"]; }
            set { this.PropertyMap["IsDoIOLog"] = value; }
        }
        #endregion

        #region HasForm �O�_�]�t Form ����
        /// <summary>HasForm �O�_�]�t Form ����</summary>
        private bool HasForm
        {
            get
            {
                if (this.PropertyMap["HasForm"] == null)
                    return false;
                else
                    return (bool)this.PropertyMap["HasForm"];
            }
            set { this.PropertyMap["HasForm"] = value; }
        }
        #endregion

        #region HasColumnFilter �O�_�]�t���z��\��
        /// <summary>HasColumnFilter �O�_�]�t���z��\��</summary>
        protected bool HasColumnFilter
        {
            get { return (bool)this.PropertyMap["HasColumnFilter"]; }
            set { this.PropertyMap["HasColumnFilter"] = value; }
        }
        #endregion

        #region NeedConnectDB �O�_�ݭn�s�u��Ʈw
        /// <summary>NeedConnectDB �O�_�ݭn�s�u��Ʈw</summary>
        protected bool NeedConnectDB
        {
            get { return (bool)this.PropertyMap["NeedConnectDB"]; }
            set { this.PropertyMap["NeedConnectDB"] = value; }
        }
        #endregion

        #region NeedCheckSession �O�_�ݭn�ˬd�n�J
        /// <summary>NeedCheckSession �O�_�ݭn�ˬd�n�J</summary>
        protected bool NeedCheckSession
        {
            get { return (bool)this.PropertyMap["NeedCheckSession"]; }
            set { this.PropertyMap["NeedCheckSession"] = value; }
        }
        #endregion

        #region NeedRollBack �O�_�ݭn�h�^���
        /// <summary>NeedRollBack �O�_�ݭn�h�^���</summary>
        private bool NeedRollBack
        {
            get { return (bool)this.PropertyMap["NeedRollBack"]; }
            set { this.PropertyMap["NeedRollBack"] = value; }
        }
        #endregion

        #region HasError �O�_�]�t���~
        /// <summary>HasError �O�_�]�t���~</summary>
        private bool HasError
        {
            get { return (bool)this.PropertyMap["HasError"]; }
            set { this.PropertyMap["HasError"] = value; }
        }
        #endregion

        #region RollBackPage RollBack page ������
        /// <summary>RollBackPage RollBack page ������</summary>
        private bool RollBackPage
        {
            get { return (bool)this.PropertyMap["RollBackPage"]; }
            set { this.PropertyMap["RollBackPage"] = value; }
        }
        #endregion

        #region PageID For �h��y�t�ϥΪ� PageID
        /// <summary>PageID For �h��y�t�ϥΪ� PageID</summary>
        protected string PageID
        {
            get { return (string)this.PropertyMap["PageID"]; }
            set { this.PropertyMap["PageID"] = value; }
        }
        #endregion

        #region HasLoad �O�_���J����
        /// <summary>HasLoad �O�_���J����Form ����</summary>
        private bool HasLoad
        {
            get { return (bool)this.PropertyMap["HasLoad"]; }
            set { this.PropertyMap["HasLoad"] = value; }
        }
        #endregion

        #region DDColumn ���o DDColumn
        /// <summary>���o DDColumn</summary>
        public Hashtable DDColumn
        {
            get
            {
                if (this.PropertyMap["DDColumn"] == null)
                    this.PropertyMap["DDColumn"] = (Hashtable)MultiProcess.GetCrossSiteValue("COLUMNDD"); ;

                //=== ������ɪ�l�� ===
                if (this.PropertyMap["DDColumn"] == null)
                    DataDictionaryUtil.InitDataDictionary(this.DBManager, this.LogUtil);

                //=== �A������^�ǿ��~ ===
                this.PropertyMap["DDColumn"] = (Hashtable)MultiProcess.GetCrossSiteValue("COLUMNDD");
                if (this.PropertyMap["DDColumn"] == null)
                    throw new Exception("��Ʀr���Ƹ��J���~, ���ˬd !!");

                return (Hashtable)this.PropertyMap["DDColumn"];
            }
        }
        #endregion

        #region PageColumn ���o PageColumn
        /// <summary>���o PageColumn</summary>
        public Hashtable PageColumn
        {
            get
            {
                if (this.PropertyMap["PageColumn"] == null)
                    this.PropertyMap["PageColumn"] = (Hashtable)MultiProcess.GetCrossSiteValue("PAGE_COLUMN");

                return (Hashtable)this.PropertyMap["PageColumn"];
            }
        }
        #endregion

        #region ColumnField ���o ColumnField
        /// <summary>���o ColumnField</summary>
        public Hashtable ColumnField
        {
            get
            {
                if (this.PropertyMap["ColumnField"] == null)
                    this.PropertyMap["ColumnField"] = (Hashtable)MultiProcess.GetCrossSiteValue("COLUMN_FIELD");
                return (Hashtable)this.PropertyMap["ColumnField"];
            }
        }
        #endregion

        #region SessionMap ���o SessionMap
        /// <summary>���o DDColumn</summary>
        public Hashtable SessionMap
        {
            get
            {
                if (FormUtil.Cache.Get("SessionMap") == null)
                {
                    //=== ��� Session ===
                    Hashtable sessionMap = new Hashtable();
                    if (!String.IsNullOrEmpty(APConfig.GetProperty("SESSION_MAP")))
                    {
                        string[] sessionAry = APConfig.GetProperty("SESSION_MAP").Split(',');
                        for (int i = 0; i < sessionAry.Length; i += 2)
                        {
                            sessionMap[sessionAry[i]] = sessionAry[i + 1];
                        }
                    }
                    FormUtil.Cache.Insert("SessionMap", sessionMap, null, DateTime.Now.AddMinutes(1), TimeSpan.Zero);
                }
                return (Hashtable)FormUtil.Cache.Get("SessionMap");
            }
        }
        #endregion
        #endregion

        #region �ƥ�
        #region �������J�ƥ�
        #region OnPreInit
        /// <summary>
        /// �������J�ƥ�
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreInit(EventArgs e)
        {
            //=== �M�� Cache ===
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            //Response.Expires = -1;            
            ////Response.ClearHeaders();            
            //Response.AppendHeader(@"Cache-Control",	@"no-cache");	// HTTP 1.1            
            //Response.AppendHeader(@"Cache-Control",	@"private");	// HTTP 1.1            
            //Response.AppendHeader(@"Cache-Control",	@"no-store");	// HTTP 1.1            
            //Response.AppendHeader(@"Cache-Control",	@"must-revalidate");	// HTTP 1.1            
            //Response.AppendHeader(@"Cache-Control",	@"max-stale=0");	// HTTP 1.1            
            //Response.AppendHeader(@"Cache-Control",	@"post-check=0");	// HTTP 1.1
            //Response.AppendHeader(@"Cache-Control",	@"pre-check=0");	// HTTP 1.1
            //Response.AppendHeader(@"Pragma",	@"no-cache");		// HTTP 1.1
            //Response.AppendHeader(@"Keep-Alive",	@"timeout=3, max=993");	// HTTP 1.1
            //Response.AppendHeader(@"Expires",	@"Mon, 26 Jul 1997 05:00:00 GMT");	// HTTP 1.1
            //Response.AppendHeader("Pragma", "no-cache");
            //Response.AppendHeader("Cache-Control", "no-cache");
            //Response.Expires = 0;

            //=== �]�w Session �̫�s���ɶ� ===
            Session["LAST_SESSION_TIME"] = System.DateTime.Now;

            //=== �w�]�B�z ===
            this.PageRangeSize = 10;
            this.IsListShow = false;
            this.IsAjax = false;
            this.IsLog = true;
            this.IsDoIOLog = true;
            this.HasLoad = false;
            this.HasError = false;
            this.RollBackPage = false;
            this.HasColumnFilter = true;
            this.NeedConnectDB = true;
            this.NeedCheckSession = true;
            this.NeedRollBack = false;

            //=== �_�l���� ===
            this.LogUtil = new LogUtil("");
            this.DBUtil = new DBUtil(this.LogUtil);
            this.LangUtil = new LangUtil(this.Logger, this.DBManager);

            this.LogUtil.TraceStart(MethodBase.GetCurrentMethod().Name);

            this.JScript = new JScript(this.Logger);

            if (!this.IsPostBack)
            {
                //=== ��l�Ƭd�� Flag ===
                this.ViewState["Has_Query"] = "N";
            }

            this.LogUtil.TraceEnd(MethodBase.GetCurrentMethod().Name);

            base.OnPreInit(e);
        }
        #endregion

        #region OnLoad
        /// <summary>
        /// �������J�ƥ�
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            // 2011/09/22 nono add for check security
            if (this.IsPostBack)
            {
                //this.Logger.Append("000======");
                //                                if (this.Form != null && this.Form.Attributes["d"] != null)
                //                                {
                //this.Logger.Append("111======" + this.Form.Attributes["d"]);
                //                                        string		content		=	Utility.DecryptStr(this.Form.Attributes["d"].ToString());
                //this.Logger.Append("111-======" + content);
                //                                        string[]	data		=	Utility.Split(content, "~!!@");
                //this.Logger.Append("222======" + content);
                //                                        string		key		=	"";
                //                                        string		value		=	"";
                //                                        for (int idx = 0; idx < data.Length; idx += 2)
                //                                        {
                //this.Logger.Append("333======");
                //                                                key	=	data[idx];
                //this.Logger.Append("444======" + key);
                //                                                if ((idx + 1) >= data.Length)
                //                                                        break;
                //                                                value	=	data[idx + 1];
                //this.Logger.Append("555======");
                //                                                if (!value.Equals(FormUtil.GetControlValue(this.FindControl(key))))
                //                                                {
                //                                                        throw new Exception(key + " ��l���: " + value + ", �{�b���: " + FormUtil.GetControlValue(this.FindControl(key)));
                //                                                }
                //                                        }
                //                                }
                //this.Logger.Append("666======");
            }

            //=== �]�w�O�_ Log ===
            this.LogUtil.IsLog = this.IsLog;
            this.Logger.IsLog = this.IsLog;
            try
            {
                this.LogUtil.TraceStart(MethodBase.GetCurrentMethod().Name);

                this.HasForm = FormUtil.CheckControlByType(this, "System.Web.UI.HtmlControls.HtmlForm");

                if (this.HasForm)
                {
                    //=== �P�_�O�_ Ajax ===
                    this.ScriptManager = (ScriptManager)FormUtil.FindControlByType(this, "ScriptManager");
                    this.IsAjax = (bool)(this.ScriptManager != null);
                }

                if (this.NeedCheckSession)
                {
                    //=== �P�_ Session �O�s�٦s�b(���`�n�J), ���s�b��X�h ===
                    if (!FormUtil.HasSession())
                    {
                        //=== �簣�έp��T ===
                        Hashtable onLineUser = MultiProcess.ChoiceHashtable(MultiProcess.GetProcessValue("ONLINE_USER"));
                        Hashtable onLineList = MultiProcess.ChoiceHashtable(MultiProcess.GetProcessValue("ONLINE_LIST"));
                        onLineUser.Remove("ONLINE_" + FormUtil.Session.SessionID);
                        onLineList.Remove("ONLIST_" + FormUtil.Session.SessionID);
                        MultiProcess.SetProcessValue("ONLINE_USER", onLineUser);
                        MultiProcess.SetProcessValue("ONLINE_LIST", onLineList);

                        //=== �� Ajax �B Timeout ��, �n�h�^��� ===
                        if (this.IsAjax)
                        {
                            throw new SessionTimeoutException("Timeout");
                        }
                        else
                        {
                            //System.Web.Security.FormsAuthentication.SignOut();
                            Response.Clear();
                            Response.Write("<script>alert('�ϥήɶ��O��,�t�Τw�N�z�۰ʵn�X,�ЦA���s�n�J�ϥΥ��t��!!');top.location.href='" + Application["vr"] + "logout.aspx';</script>");
                            Response.End();
                            return;
                        }
                    }
                }

                //=== ��l�ƨϥΪ̱�� ===
                ArrayList userControls = new ArrayList();
                FormUtil.FindUserControls(this, userControls);
                for (int i = 0; i < userControls.Count; i++)
                {
                    this.PrepareUserControl((UserControlBase)userControls[i]);
                }

                //=== ����ŦX�R�W����� Ex: Q_, M_, X_... ===
                FormUtil.FindUIDDControls(this, this.ddUserControls);

                //=== �]�w�y�t ===
                if (Session["Language"] == null)
                    Session["Language"] = "ZH-TW";

                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Session["Language"].ToString());
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Session["Language"].ToString());

                if (!this.IsPostBack)
                {

                    //=== �h��y�t Js �ϥ� ===
                    if (!Session["Language"].ToString().Equals("ZH-TW"))
                        this.JScript.Script = "try{doImport ('MessageContent_" + Session["Language"].ToString().Replace("-", "_") + ".js');}catch(ex){}";

                    this.JScript.Script = "var lang	=	'" + Session["Language"].ToString().Replace("-", "_") + "'";
                    this.JScript.Script = "try{if (getTop().columnFilterRecord == null)getTop().columnFilterRecord={};}catch(ex){}";

                    //=== ��l�Ƹ�Ʀr�����]�w ===
                    BindDDProperty();

                    //=== ��l�Ƹ�����]�w ===
                    BindColumnFieldProperty();

                    //=== ��l�Ʀh��y�t��� ===
                    BindMLProperty(this);

                    //=== �����s�W�� ===
                    string langType = Thread.CurrentThread.CurrentUICulture.ToString().ToUpper();

                    //if (APConfig.GetProperty("DATA_PROJECT").Equals("���v�j��") && langType.Equals("ZH-TW") || APConfig.GetProperty("DATA_PROJECT").Contains("�꨾�j��") || APConfig.GetProperty("DATA_PROJECT").Contains("�F���j��"))
                    //{
                    //    try{((HtmlInputButton)this.FindControl("QCLEAR_BTN1")).Value	=	"�٭�";}catch(Exception){}
                    //    try{((HtmlInputButton)this.FindControl("QCLEAR_BTN2")).Value	=	"�٭�";}catch(Exception){}
                    //    try{((HtmlInputButton)this.FindControl("MCLEAR_BTN1")).Value	=	"�٭�";}catch(Exception){}
                    //    try{((HtmlInputButton)this.FindControl("MCLEAR_BTN2")).Value	=	"�٭�";}catch(Exception){}

                    //    try{((Button)this.FindControl("QCLEAR_BTN1")).Text	=	"�٭�";}catch(Exception){}
                    //    try{((Button)this.FindControl("QCLEAR_BTN2")).Text	=	"�٭�";}catch(Exception){}
                    //    try{((Button)this.FindControl("MCLEAR_BTN1")).Text	=	"�٭�";}catch(Exception){}
                    //    try{((Button)this.FindControl("MCLEAR_BTN2")).Text	=	"�٭�";}catch(Exception){}
                    //}

                    //=== �P�_�\���v�� ===
                    ProcessPermission();
                }

                //=== nono 2009/03/25 add �קK keepSession �άO�ݱ`���㪺�{�����_��� ===
                if (this.HasColumnFilter)
                {
                    //=== ��l�����z��]�w ===
                    ColumnFilterInit();
                }

                //=== �B�z SQLInjection �m���ʧ@ ===
                FormUtil.ProcessSQLInjection(this, true);

                this.HasLoad = true;

                base.OnLoad(e);
            }
            finally
            {
                this.LogUtil.TraceEnd(MethodBase.GetCurrentMethod().Name);
            }
        }

        public void OnloadAction() 
        {            
            //=== �]�w�O�_ Log ===
            this.LogUtil.IsLog = this.IsLog;
            this.Logger.IsLog = this.IsLog;
            try
            {
                this.LogUtil.TraceStart(MethodBase.GetCurrentMethod().Name);

                this.HasForm = FormUtil.CheckControlByType(this, "System.Web.UI.HtmlControls.HtmlForm");

                if (this.HasForm)
                {
                    //=== �P�_�O�_ Ajax ===
                    this.ScriptManager = (ScriptManager)FormUtil.FindControlByType(this, "ScriptManager");
                    this.IsAjax = (bool)(this.ScriptManager != null);
                }

                if (this.NeedCheckSession)
                {
                    //=== �P�_ Session �O�s�٦s�b(���`�n�J), ���s�b��X�h ===
                    if (!FormUtil.HasSession())
                    {
                        //=== �簣�έp��T ===
                        Hashtable onLineUser = MultiProcess.ChoiceHashtable(MultiProcess.GetProcessValue("ONLINE_USER"));
                        Hashtable onLineList = MultiProcess.ChoiceHashtable(MultiProcess.GetProcessValue("ONLINE_LIST"));
                        onLineUser.Remove("ONLINE_" + FormUtil.Session.SessionID);
                        onLineList.Remove("ONLIST_" + FormUtil.Session.SessionID);
                        MultiProcess.SetProcessValue("ONLINE_USER", onLineUser);
                        MultiProcess.SetProcessValue("ONLINE_LIST", onLineList);

                        //=== �� Ajax �B Timeout ��, �n�h�^��� ===
                        if (this.IsAjax)
                        {
                            throw new SessionTimeoutException("Timeout");
                        }
                        else
                        {
                            //System.Web.Security.FormsAuthentication.SignOut();
                            Response.Clear();
                            Response.Write("<script>alert('�ϥήɶ��O��,�t�Τw�N�z�۰ʵn�X,�ЦA���s�n�J�ϥΥ��t��!!');top.location.href='" + Application["vr"] + "logout.aspx';</script>");
                            Response.End();
                            return;
                        }
                    }
                }

                //=== ��l�ƨϥΪ̱�� ===
                ArrayList userControls = new ArrayList();
                FormUtil.FindUserControls(this, userControls);
                for (int i = 0; i < userControls.Count; i++)
                {
                    this.PrepareUserControl((UserControlBase)userControls[i]);
                }

                //=== ����ŦX�R�W����� Ex: Q_, M_, X_... ===
                FormUtil.FindUIDDControls(this, this.ddUserControls);

                //=== �]�w�y�t ===
                if (Session["Language"] == null)
                    Session["Language"] = "ZH-TW";

                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Session["Language"].ToString());
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Session["Language"].ToString());

                //if (!this.IsPostBack)
                //{

                    //=== �h��y�t Js �ϥ� ===
                    //if (!Session["Language"].ToString().Equals("ZH-TW"))
                    //    this.JScript.Script = "try{doImport ('MessageContent_" + Session["Language"].ToString().Replace("-", "_") + ".js');}catch(ex){}";

                    //this.JScript.Script = "var lang	=	'" + Session["Language"].ToString().Replace("-", "_") + "'";
                    //this.JScript.Script = "try{if (getTop().columnFilterRecord == null)getTop().columnFilterRecord={};}catch(ex){}";

                    //=== ��l�Ƹ�Ʀr�����]�w ===
                    //BindDDProperty();

                    //=== ��l�Ƹ�����]�w ===
                    //BindColumnFieldProperty();

                    //=== ��l�Ʀh��y�t��� ===
                    //BindMLProperty(this);

                    //=== �����s�W�� ===
                    //string langType = Thread.CurrentThread.CurrentUICulture.ToString().ToUpper();

                  
                    //=== �P�_�\���v�� ===
                    ProcessPermission();
                //}

                //=== nono 2009/03/25 add �קK keepSession �άO�ݱ`���㪺�{�����_��� ===
                if (this.HasColumnFilter)
                {
                    //=== ��l�����z��]�w ===
                    ColumnFilterInit();
                }

                //=== �B�z SQLInjection �m���ʧ@ ===
                FormUtil.ProcessSQLInjection(this, true);

                this.HasLoad = true;

                //base.OnLoad(e);
            }
            finally
            {
                this.LogUtil.TraceEnd(MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region OnLoadComplete
        /// <summary>
        /// �������J�����ƥ�
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoadComplete(EventArgs e)
        {
            try
            {
                this.LogUtil.TraceStart(MethodBase.GetCurrentMethod().Name);

                //                                // 2011/09/22 nono add for check security
                //                                ArrayList	noeditControls	=	new ArrayList();
                //                                FormUtil.FindNoEditControls(this, noeditControls);
                //                                Control		tmpControl;
                //                                string		data		=	"";
                //                                string		delimStr	=	"~!!@";
                //                                for (int i = 0; i < noeditControls.Count; i++)
                //                                {
                //                                        tmpControl		=	(Control)noeditControls[i];
                //                                        if (string.IsNullOrEmpty(tmpControl.UniqueID))
                //                                                continue;
                //                                        if (string.IsNullOrEmpty(data))
                //                                                data			=	tmpControl.UniqueID + delimStr + FormUtil.GetControlValue(tmpControl);
                //                                        else
                //                                                data			=	data + delimStr + tmpControl.UniqueID + delimStr + FormUtil.GetControlValue(tmpControl);
                //                                }
                //                                if (this.HasForm)
                //                                {
                //this.Logger.Append("data ===" + data);
                //                                        this.Form.Attributes["d"]	=	Utility.EncryptStr(data);
                //                                }

                this.HasLoad = true;

                //=== ��l�� Grid ���U�C�� ===
                //Modify By Brian 2013/08/22 $(_d()).ready(Grid.setGridEvent); ���� /UserControl/PageInitControl.ascx BindInitScript()�B�z
                this.JScript.Script = "try{$(_d()).ready(iniGridClickColor);$(_d()).ready(SortTable.sortables_init);}catch(ex){}";

                //=== �B�z Grid Scroll �ʧ@, ���s�ܦ�ƥ� ===
                this.JScript.Script = "try{setButtonEvent();reSize();}catch(ex){}";

                //=== ���� Label ===
                this.JScript.Script = "try{switchLabel();}catch(ex){}";

                //=== �ŧi�M�קO ===
                this.JScript.Script = "var	proj	=	'" + APConfig.GetProperty("DATA_PROJECT") + "'";

                //=== �檫�z�� ===
                this.JScript.Script = "try{$(_d()).ready(function(){try{gridOuterHTML=_('DataGrid').outerHTML;setColumnHide()}catch(ex){}})}catch(ex){}";

                //=== �B�z SQLInjection �m���ʧ@, �Ϊ��B���A��ƳB�z ===
                FormUtil.ProcessSQLInjection(this, false);

                if (!this.IsPostBack)
                {
                    //=== ��l�Ƹ�����]�w ===
                    BindCompleteColumnFieldProperty();
                }

                if (!ActionSecurity.HasFunctionPermission("0001"))
                {
                    this.JScript.HideProcess();
                }

                base.OnLoadComplete(e);
            }
            finally
            {
                this.LogUtil.TraceEnd(MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion
        #endregion

        #region OnPreRender �������J��
        /// <summary>
        /// �������J���ƥ�
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            // 2011/09/22 nono add for check security
            ArrayList noeditControls = new ArrayList();
            FormUtil.FindNoEditControls(this, noeditControls);
            Control tmpControl;
            Hashtable dataMap = new Hashtable();
            for (int i = 0; i < noeditControls.Count; i++)
            {
                tmpControl = (Control)noeditControls[i];
                dataMap[tmpControl.ID] = FormUtil.GetControlValue(tmpControl);
                this.Logger.Append(tmpControl.ID + ":" + dataMap[tmpControl.ID]);
            }
            ViewState["NoEditData"] = dataMap;

            //=== ��� ===
            if (this.NeedConnectDB)
            {
                if (this.HasError || this.RollBackPage || this.NeedRollBack)
                    this.DBManager.Rollback();
                else
                    this.DBManager.Commit();
            }

            //=== �����s�u ===
            this.DBUtil.CloseDBManager();

            //=== ���� JavaScript ===
            this.JScript.IniFormColor();
            //=== �B���L ===
            this.JScript.SetWaterMark();

            //=== �]�w���s�v�� ===
            if (this.HasForm)
                this.JScript.ButtonPermission();

            if (this.IsAjax)
            {
                if (this.HasError)
                {
                    if (this.HasLoad)
                    {
                        PageBase.AjaxErrLog = this.JScript.Script;
                        //System.IO.File.AppendAllText(APConfig.RealPath + @"Temp\PageBase.txt", DateUtil.GetNowDateTime() + ":" + this.JScript.Script);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(this.JScript.Script))
                            ErrUtil.HandlePageError(this.Exception);
                        else
                        {
                            PageBase.AjaxErrLog = this.JScript.Script;
                        }
                    }

                    if (!this.IsPostBack)
                        Response.Write("<script src='" + Application["vr"] + "script/jquery-1.8.3.min.js'></script>" +
                                "<script src='" + Application["vr"] + "script/Base.js'></script>" +
                                "<script>var _vp = '" + Application["vr"] + "';" +
                                "doImport('WindowUtil.js,Message.js,Form.js');" +
                                this.JScript.Script + "</script>");
                }
                else
                    this.JScript.ExecAjaxClientScript(this);
            }
            else
            {
                if (this.HasError)
                    ErrUtil.HandlePageError(this.Exception);
                else
                    this.JScript.ExecClientScript(this);
            }

            if (this.IsDoIOLog)
                this.LogUtil.DoLog();
            //=== 2009/03/25 nono add for trace log happen ===
            else if (this.HasError)
                this.LogUtil.DoLog();
            //else
            //	this.LogUtil.ClearMonitor();

            //else
            //{
            //        try
            //        {
            //                System.IO.File.Delete(this.Logger.logIOName);
            //        }
            //        catch (System.Exception)
            //        {
            //        }
            //}

            base.OnPreRender(e);
        }
        #endregion

        #region OnError ���~�B�z
        /// <summary>
        /// ���~�B�z�ƥ�
        /// </summary>
        /// <param name="e"></param>
        protected override void OnError(EventArgs e)
        {
            Exception pageEx = Server.GetLastError();

            if (pageEx is System.Web.HttpRequestValidationException)
            {
                Response.Clear();
                Response.Write("<script>alert('�㦳��b�M�I���Ȥw�q�Τ�ݰ�����!!')</script>");
                Response.End();
            }
            Server.ClearError();

            if (this.LogUtil == null)
                return;

            this.LogUtil.TraceStart(MethodBase.GetCurrentMethod().Name);

            //=== �]�w���~ ===
            this.Logger.SetLogLevel(MyLogger.Error);
            this.Logger.Append(ErrUtil.ErrToStr(pageEx).Replace("<", "&lt;") + "};");

            //=== �z�L Ajax �I�s�B�z ===
            if (this.IsAjax)
            {
                if (pageEx is Acer.Err.SessionTimeoutException)
                {
                    this.JScript.Script = "alert('" + this.LangUtil.LangMap("�ϥήɶ��O��,�t�Τw�N�z�۰ʵn�X,�ЦA���s�n�J�ϥΥ��t��!!") + "');top.location.href='" + Application["vr"] + "logout.aspx';";
                    //System.IO.File.AppendAllText(APConfig.RealPath + @"Temp\PageBase.txt", DateUtil.GetNowDateTime() + ":" + this.JScript.Script);
                }
                else
                {
                    this.JScript.Script = ErrUtil.GetPageError(pageEx) + ";try{Message.hideProcess();}catch(xx){}";
                    this.Logger.Append("== nono trace ==" + ErrUtil.GetPageError(pageEx) + "== nono trace ==");
                }
            }
            this.Exception = pageEx;
            this.HasError = true;
            //System.IO.File.AppendAllText(APConfig.RealPath + @"\log\PageErr.txt", this.PageID + "\r\n" + ErrUtil.ErrToStr(pageEx) + "\r\n");
            //=== �B�z�����ʧ@ ===
            this.OnPreRender(null);

            base.OnError(e);
        }
        private static object lockObj1 = new object();
        #endregion
        #endregion

        #region ��k
        #region ���Ҭ���
        #region Tab_Click ��������
        /// <summary>
        /// �������� Tab_Click
        /// </summary>
        protected void Tab_Click(Object sender, System.EventArgs e)
        {
            int tabIndex = 1;
            int currIndex = 1;
            while (this.FindControl("TABLNK" + tabIndex) != null)
            {
                if (this.FindControl("TAB_CONTENT" + tabIndex) == null)
                    this.Logger.Append("==> TAB_CONTENT" + tabIndex + " ���󥼩w�q");

                if (sender.Equals(this.FindControl("TABLNK" + tabIndex)))
                    currIndex = tabIndex;

                ((LinkButton)this.FindControl("TABLNK" + tabIndex)).CssClass = "tab_non_select";
                ((HtmlGenericControl)this.FindControl("TAB_CONTENT" + tabIndex)).Attributes["style"] = "display:none";

                tabIndex++;
            }

            ((LinkButton)sender).CssClass = "tab_select";
            ((HtmlGenericControl)this.FindControl("TAB_CONTENT" + currIndex)).Attributes["style"] = "display:";
        }
        #endregion

        #region InitTab ��l�ƭ���
        /// <summary>
        /// InitTab ��l�ƭ���
        /// </summary>
        protected void InitTab(int showIndex)
        {
            int tabIndex = 1;
            while (this.FindControl("TABLNK" + tabIndex) != null)
            {
                if (this.FindControl("TAB_CONTENT" + tabIndex) == null)
                    this.Logger.Append("==> TAB_CONTENT" + tabIndex + " ���󥼩w�q");

                ((LinkButton)this.FindControl("TABLNK" + tabIndex)).CssClass = "tab_non_select";
                ((HtmlGenericControl)this.FindControl("TAB_CONTENT" + tabIndex)).Attributes["style"] = "display:none";

                tabIndex++;
            }

            ((LinkButton)this.FindControl("TABLNK" + showIndex)).CssClass = "tab_select";
            ((HtmlGenericControl)this.FindControl("TAB_CONTENT" + showIndex)).Attributes["style"] = "display:";
        }
        #endregion
        #endregion

        #region ��Ʈw�s��
        #region GetDBAccess ���o DBAccess ����
        /// <summary>
        /// ���o DBAccess ����
        /// </summary>
        /// <param name="connName">��Ʈw�s�u�]�w</param>
        /// <returns>DBAccess ����</returns>
        public DBAccess GetDBAccess(string connName)
        {
            DbConnection conn = this.DBManager.GetIConnection(connName);
            return this.DBManager.GetDBAccess(conn);
        }
        #endregion

        #region GetDtBySql �̾� SQL ���o DataTable
        /// <summary>
        /// �̾� SQL ���o DataTable
        /// </summary>
        /// <param name="connName">��Ʈw�s�u�]�w</param>
        /// <param name="sql">SQL �y�k</param>
        /// <returns>DataTable ����</returns>
        public DataTable GetDtBySql(string connName, string sql)
        {
            EntityBase ent = new EntityBase(this.DBManager, this.LogUtil);
            ent.ConnName = connName;
            return ent.QueryBySql(sql);
        }
        #endregion

        #region GetDtBySql �̾� SQL ���o DataTable
        /// <summary>
        /// �̾� SQL ���o DataTable
        /// </summary>
        /// <param name="connName">��Ʈw�s�u�]�w</param>
        /// <param name="sql">SQL �y�k</param>
        /// <param name="pageNo">����</param>
        /// <param name="pageSize">�C���ؤo</param>
        /// <returns>DataTable ����</returns>
        public DataTable GetDtBySql(string connName, string sql, int pageNo, int pageSize)
        {
            EntityBase ent = new EntityBase(this.DBManager, this.LogUtil);
            ent.ConnName = connName;
            DataTable dt = ent.QueryBySql(sql, pageNo, pageSize);
            this.TotalRowCount = ent.TotalRowCount();

            return dt;
        }
        #endregion

        #region RollBackPageTransaction �B�z���������ưh�^�ʧ@
        /// <summary>
        /// �B�z���������ưh�^�ʧ@
        /// </summary>
        protected void RollBackPageTransaction()
        {
            this.RollBackPage = true;
        }
        #endregion
        #endregion

        #region �B�z����
        #region ���o������T
        /// <summary>
        /// ���o PageControl �� PageNo ��
        /// <param name="defaultPageControlId">�w�]����W��</param>
        /// </summary>
        protected string PageControlPageNo(string defaultPageControlId)
        {
            if (this.HiddenFieldX("ActivePageControl") == null)
                this.Logger.Append("�����]�w HiddenField ��� ID [ActivePageControl]");

            if (!String.IsNullOrEmpty(this.HiddenFieldX("ActivePageControl").Value))
                return ((TextBox)this.UserControlX(this.HiddenFieldX("ActivePageControl").Value).FindControl("PageNo")).Text;
            else
                return ((TextBox)this.UserControlX(defaultPageControlId).FindControl("PageNo")).Text;
        }

        /// <summary>
        /// ���o ScrollSize ��
        /// <param name="defaultPageControlId">�w�]����W��</param>
        /// </summary>
        protected string PageControlPageSize(string defaultPageControlId)
        {
            if (this.HiddenFieldX("ActivePageControl") == null)
                this.Logger.Append("������]�w --> ActivePageControl");

            if (!String.IsNullOrEmpty(this.HiddenFieldX("ActivePageControl").Value))
            {
                //�YPageSize��J�ج��ŭȮɪ��B�z�覡
                if (((TextBox)this.UserControlX(this.HiddenFieldX("ActivePageControl").Value).FindControl("PageSize")).Text.Length == 0)
                    return defaultPageSize.ToString(); 
                else
                    return ((TextBox)this.UserControlX(this.HiddenFieldX("ActivePageControl").Value).FindControl("PageSize")).Text;
            }              
            else
                return ((TextBox)this.UserControlX(defaultPageControlId).FindControl("PageSize")).Text;
        }
        #endregion

        private HiddenField HiddenFieldX(string fieldName)
        {
            return (HiddenField)this.FindControl(fieldName);
        }

        private UserControl UserControlX(string fieldName)
        {
            return (UserControl)this.FindControl(fieldName);
        }
        #endregion

        #region �B�z Grid ������k
        #region �ˬd�O�_�d�߹L
        /// <summary>
        /// �ˬd�O�_�d�߹L, For �s�W��O�_�� Bind �P�_�ϥ�
        /// </summary>
        /// <param name="gridView">GridView ���</param>
        /// <returns>�O�_�d�߹L</returns>
        public bool ChkHasQuery(GridView gridView)
        {
            if (gridView.Rows.Count > 0)
                return true;
            else if (Utility.CheckNull(this.ViewState["Has_Query"], "N").Equals("Y"))
                return true;
            else
                return false;
        }
        #endregion

        #region AllCellResize �B�z DataGrid �Ҧ����Y�i�H���ܤj�p�ʧ@
        /// <summary>
        /// �B�z DataGrid �Ҧ����Y�i�H���ܤj�p�ʧ@
        /// </summary>
        /// <param name="gridView">gridView ���</param>
        private void AllCellResize(GridView gridView)
        {
            if (gridView == null)
                throw new ArgumentException("�ǤJ�ѼƤ��i���ť�", "gridView");

            if (gridView.HeaderRow == null)
                return;

            string tmpML;
            string tmpData;
            foreach (TableCell cell in gridView.HeaderRow.Cells)
            {
                if (cell.Text.StartsWith("PL_") || cell.Text.StartsWith("PC_"))
                {
                    //tmpML	=	cell.Text.Replace("CL_", "COMMON.LABEL.").Replace("CB_", "COMMON.BUTTON.").Replace("PL_", this.PageID + ".LABEL.").Replace("PB_", this.PageID + ".BUTTON.");
                    //tmpML	=	cell.Text.Replace("CL_", "COMMON.").Replace("CB_", "COMMON.").Replace("PL_", this.PageID + ".").Replace("PB_", this.PageID + ".");
                    //Modify By Brian 2014.04.14 PageID �令 PAGE
                    tmpML = cell.Text.Replace("CL_", "COMMON.").Replace("CB_", "COMMON.").Replace("PL_", "PAGE.").Replace("PB_", "PAGE.").Replace("PC_", this.PageID + ".");

                    tmpData = this.LangUtil.LangMap(tmpML);
                    if (!string.IsNullOrEmpty(tmpData))
                        cell.Text = tmpData;
                }
                cell.Attributes["resize"] = "on";
            }
        }
        #endregion

        #region SetupGridEvent �]�w Gird �ƥ�
        /// <summary>
        /// �]�w Gird �ƥ�
        /// </summary>
        /// <param name="grid">Gird ����</param>
        /// <param name="gridEvent">Gird �ƥ󵲺c</param>
        protected void SetupGridEvent(GridView grid, GridEvent gridEvent)
        {
            if (grid == null)
                throw new ArgumentException("�ǤJ�Ȥ��i����", "grid");

            this.ViewState["Has_Query"] = "Y";

            //=== �]�w���Y�i���ܤj�p ===
            if (gridEvent.IsColumnReSize)
                this.AllCellResize(grid);

            //=== ����������(���z��) ===
            //2009/03/25 nono �����L�ĳB�z
            //if (gridEvent.IsColumnFilter)
            //{
            //	this.JScript.Script	=	"$(_d()).ready(function(){gridOuterHTML=_('DataGrid').outerHTML;setColumnHide()})";
            //}

            //=== ����ŦX�R�W����� Ex: Q_, M_, X_... ===
            this.ddUserControls = new ArrayList();
            FormUtil.FindUIDDControls(grid, this.ddUserControls);

            //=== ��l�Ƹ�Ʀr�����]�w ===
            BindDDProperty();

            //=== ��l�Ƹ�����]�w ===
            BindColumnFieldProperty();

            //=== �O�d��l�Ȱʧ@ ===
            Control tmpControl;
            string controlValue;
            for (int i = 0; i < this.ddUserControls.Count; i++)
            {
                tmpControl = (Control)this.ddUserControls[i];
                controlValue = FormUtil.GetControlValue(tmpControl);

                controlValue = controlValue.Replace("'", "''");
                //=== ���B�B�z�m���ʧ@ ===
                if ((FormUtil.GetAttributeData(tmpControl, "DD") != null &&
                    FormUtil.GetAttributeData(tmpControl, "DD").Equals("A")) && !(controlValue.Equals("")))
                    controlValue = controlValue.Replace(",", "");
                //=== �ɶ��B�z�m���ʧ@ ===
                if ((FormUtil.GetAttributeData(tmpControl, "DD") != null &&
                    FormUtil.GetAttributeData(tmpControl, "DD").Equals("T")) && !(controlValue.Equals("")))
                    controlValue = controlValue.Replace(":", "");

                FormUtil.SetAttributeData(tmpControl, "RAW_DATA", controlValue);
            }
        }
        #endregion

        #region CheckHasChange �P�_�O�_�ݭn�B�z
        /// <summary>
        /// �P�_�O�_�ݭn�B�z
        /// </summary>
        /// <param name="row">�ӵ��C����</param>
        /// <returns>�O/�_</returns>
        protected bool CheckHasChange(GridViewRow row)
        {
            //=== ����ŦX�R�W����� Ex: Q_, M_, X_... ===
            this.ddUserControls = new ArrayList();
            FormUtil.FindUIDDControls(row, this.ddUserControls);

            Control tmpControl;
            for (int i = 0; i < this.ddUserControls.Count; i++)
            {
                tmpControl = (Control)this.ddUserControls[i];

                //=== ���l�ȸ�{�b���Ȥ��@�ˮɦ^�� true ===
                if (!FormUtil.GetAttributeData(tmpControl, "RAW_DATA").Equals(FormUtil.GetControlValue(tmpControl)))
                    return true;
            }
            return false;
        }
        #endregion

        #region GetKeyValueByGridCheckBox �̾� Grid CheckBox ���o���  KEY|VALUE$KEY|VALUE"
        /// <summary>
        /// �̾� Grid CheckBox ���o���"
        /// </summary>
        /// <param name="dataGrid">GridView ����</param>
        /// <param name="checkBoxName">�ֿ磌�� ID</param>
        /// <returns>���</returns>
        protected string GetKeyValueByGridCheckBox(GridView dataGrid, string checkBoxName)
        {
            StringBuilder keyValue = new StringBuilder();
            HtmlInputCheckBox chkBox;

            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                chkBox = (HtmlInputCheckBox)dataGrid.Rows[i].FindControl(checkBoxName);
                if (chkBox.Checked)
                {
                    if (keyValue.ToString().Equals(""))
                        keyValue.Append(chkBox.Value);
                    else
                        keyValue.Append("$" + chkBox.Value);
                }
            }

            return keyValue.ToString();
        }
        #endregion

        #region GetKeyValueByGridRow �̾� Grid �Y����o��� KEY|VALUE"
        /// <summary>
        /// �̾� Grid �Y����o���
        /// </summary>
        /// <param name="dataGrid">GridView ����</param>
        /// <param name="rowIndex">�����</param>
        /// <returns>���</returns>
        protected string GetKeyValueByGridRow(GridView dataGrid, int rowIndex)
        {
            StringBuilder keyValue = new StringBuilder();
            foreach (string key in dataGrid.DataKeys[rowIndex].Values.Keys)
            {
                if (keyValue.ToString().Equals(""))
                    keyValue.Append(key + "|" + dataGrid.DataKeys[rowIndex].Values[key].ToString());
                else
                    keyValue.Append("|" + key + "|" + dataGrid.DataKeys[rowIndex].Values[key].ToString());
            }

            return keyValue.ToString();
        }
        #endregion

        #region PrepareRowDataBoundEvent �B�z�C�� Grid �ƥ�"
        /// <summary>
        /// PrepareRowDataBoundEvent �B�z�C�� Grid �ƥ�, 
        /// �w�]�B�z�\�� �ֿ�/�s/��/�R �v������, 
        /// �Y���мg�\���U��A���мg�Y�i
        /// </summary>
        /// <param name="dataGrid">GridView ����</param>
        /// <param name="row">�檫��</param>
        protected void PrepareRowDataBoundEvent(GridView dataGrid, GridViewRow row)
        {
            string keyValue = this.GetKeyValueByGridRow(dataGrid, row.RowIndex);

            //=== �]�w DataGrid �� CheckBox�AValue �n�զX Primary Key ===
            HtmlInputCheckBox tmpChkBox = (HtmlInputCheckBox)row.FindControl("chkBox");
            if (tmpChkBox != null)
                tmpChkBox.Value = keyValue;

            //=== �]�w�s�� ===
            Label tmpLabel;

            //=== �]�w�R�� ===
            LinkButton tmpLink = (LinkButton)row.FindControl("del");
            if (tmpLink != null)
            {

                try
                {
                    if (!string.IsNullOrEmpty(APConfig.GetProperty("GRIDVIEW_DEL_IMG")))
                        tmpLink.Text = "<img src='" + APConfig.GetProperty("GRIDVIEW_DEL_IMG") + "' style='border:0; vertical-align:bottom' />";
                }
                catch { }

                //=== �v������(�R��) ===
                if (!ActionSecurity.HasFunctionPermission("0002"))
                    ((TableCell)tmpLink.Parent).Enabled = false;
                else
                {
                    //=== �I��R���ɡA�X�{ confirm �T�� ===
                    tmpLink.Attributes.Add("KEY", keyValue);
                    tmpLink.OnClientClick = "return doDelete();";
                }
            }

            //=== �]�w�h��y�t ===
            BindMLProperty(row);

            tmpLabel = (Label)row.FindControl("edit");
            if (tmpLabel != null)
            {
                tmpLabel.Text = "<a href='#this'>" + LangUtil.LangMap("COMMON.�s") + "</a>";

                try
                {
                    if (!string.IsNullOrEmpty(APConfig.GetProperty("GRIDVIEW_EDIT_IMG")))
                        tmpLabel.Text = "<a href='#this'><img src='" + APConfig.GetProperty("GRIDVIEW_EDIT_IMG") + "' style='border:0; vertical-align:bottom' /></a>";
                }
                catch { }

                //=== �v������(�s��) ===
                if (!ActionSecurity.HasFunctionPermission("0003"))
                    ((TableCell)tmpLabel.Parent).Enabled = false;
                else
                {
                    ((TableCell)tmpLabel.Parent).Attributes.Add("onclick", "doEdit1_2(this, '" + keyValue + "', 'Mod')");
                    row.Attributes.Add("KEY", keyValue);
                }
            }

            //=== �]�w�� ===
            tmpLabel = (Label)row.FindControl("detail");
            if (tmpLabel != null)
            {
                tmpLabel.Text = "<a href='#this'>" + LangUtil.LangMap("COMMON.��") + "</a>";

                try
                {
                    if (!string.IsNullOrEmpty(APConfig.GetProperty("GRIDVIEW_DETAIL_IMG")))
                        tmpLabel.Text = "<a href='#this'><img src='" + APConfig.GetProperty("GRIDVIEW_DETAIL_IMG") + "' style='border:0; vertical-align:bottom' /></a>";
                }
                catch { }

                //=== �v������(��) ===
                if (!ActionSecurity.SecurityCheck("DETAIL"))
                    ((TableCell)tmpLabel.Parent).Enabled = false;
                else
                {
                    ((TableCell)tmpLabel.Parent).Attributes.Add("onclick", "doEdit1_2(this, '" + keyValue + "', 'Detail')");
                    row.Attributes.Add("KEY", keyValue);
                }
            }
        }
        #endregion

        #region PrepareEditKey �N Key ��Ʀ^���e���W�h"
        /// <summary>
        /// �N Key ��Ʀ^���e���W�h, �ç��� TD �C��
        /// </summary>
        /// <param name="sender">Key ���(CD|VALUE|CD|VALUE)</param>
        /// <param name="blockName">blockName �r��,ex: M_</param>
        protected void PrepareEditKeyToUI(LinkButton sender,string blockName="M_")
        {
            string[] keyAry = sender.Attributes["KEY"].ToString().Split('|');
            for (int i = 0; i < keyAry.Length; i += 2)
            {
                if (this.FindControl(blockName + keyAry[i]) != null)
                    //== ��e����� ===
                    FormUtil.SetControlValue(this.FindControl(blockName + keyAry[i]), keyAry[i + 1]);
            }
        }
        #endregion

      
        #region PrepareRowDataBoundEventFor1_1 �B�z�C�� Grid �ƥ�"
        /// <summary>
        /// PrepareRowDataBoundEventFor1_1 �B�z�C�� Grid �ƥ�, For Pattern 1-1
        /// �w�]�B�z�\�� �ֿ�/�s/��/�R �v������, 
        /// �Y���мg�\���U��A���мg�Y�i
        /// </summary>
        /// <param name="dataGrid">GridView ����</param>
        /// <param name="row">�檫��</param>
        protected void PrepareRowDataBoundEventFor1_1(GridView dataGrid, GridViewRow row)
        {
            string keyValue = this.GetKeyValueByGridRow(dataGrid, row.RowIndex);

            //=== �]�w DataGrid �� CheckBox�AValue �n�զX Primary Key ===
            HtmlInputCheckBox tmpChkBox = (HtmlInputCheckBox)row.FindControl("chkBox");
            if (tmpChkBox != null)
                tmpChkBox.Value = keyValue;

            //=== �]�w�s�� ===
            LinkButton tmpLink;
            tmpLink = (LinkButton)row.FindControl("edit");

            if (tmpLink != null)
            {
                try
                {
                    if (!string.IsNullOrEmpty(APConfig.GetProperty("GRIDVIEW_EDIT_IMG")))
                        tmpLink.Text = "<img src='" + APConfig.GetProperty("GRIDVIEW_EDIT_IMG") + "' style='border:0; vertical-align:bottom' />";
                }
                catch { }

                //=== �v������(�s��) ===
                if (!ActionSecurity.HasFunctionPermission("0003"))
                    ((TableCell)tmpLink.Parent).Enabled = false;
                else
                {
                    tmpLink.Attributes.Add("onclick", "clickEditRow(this, '" + keyValue + "');");
                    tmpLink.Attributes.Add("KEY", keyValue);
                    row.Attributes.Add("KEY", keyValue);
                }
            }

            //=== �]�w�� ===
            tmpLink = (LinkButton)row.FindControl("detail");
            if (tmpLink != null)
            {
                try
                {
                    if (!string.IsNullOrEmpty(APConfig.GetProperty("GRIDVIEW_DETAIL_IMG")))
                        tmpLink.Text = "<img src='" + APConfig.GetProperty("GRIDVIEW_DETAIL_IMG") + "' style='border:0; vertical-align:bottom' />";
                }
                catch { }

                //=== �v������(��) ===
                if (!ActionSecurity.SecurityCheck("DETAIL"))
                    ((TableCell)tmpLink.Parent).Enabled = false;
                else
                {
                    tmpLink.Attributes.Add("onclick", "clickDetailRow(this, '" + keyValue + "');");
                    tmpLink.Attributes.Add("KEY", keyValue);
                    row.Attributes.Add("KEY", keyValue);
                }
            }

            //=== �]�w�R�� ===
            tmpLink = (LinkButton)row.FindControl("del");
            if (tmpLink != null)
            {
                try
                {
                    if (!string.IsNullOrEmpty(APConfig.GetProperty("GRIDVIEW_DEL_IMG")))
                        tmpLink.Text = "<img src='" + APConfig.GetProperty("GRIDVIEW_DEL_IMG") + "' style='border:0; vertical-align:bottom' />";
                }
                catch { }

                //=== �v������(�R��) ===
                if (!ActionSecurity.HasFunctionPermission("0002"))
                    ((TableCell)tmpLink.Parent).Enabled = false;
                else
                {
                    //=== �I��R���ɡA�X�{ confirm �T�� ===
                    tmpLink.Attributes.Add("KEY", keyValue);
                    tmpLink.OnClientClick = "return doDelete();";
                }
            }

            //=== �]�w�h��y�t ===
            BindMLProperty(row);
        }
        #endregion


        #region PrepareRowDataBoundEventFor1_1_V2 �B�z�C�� Grid �ƥ�"
        /// <summary>
        /// PrepareRowDataBoundEventFor1_1_V2 �B�z�C�� Grid �ƥ�, For Pattern 1-1
        /// �w�]�B�z�\�� �ֿ�/�s/��/�R �v������, 
        /// �Y���мg�\���U��A���мg�Y�i
        /// </summary>
        /// <param name="dataGrid">GridView ����</param>
        /// <param name="row">�檫��</param>
        /// <param name="num">����Ǹ�(ex:edit2,del2)</param>
        protected void PrepareRowDataBoundEventFor1_1_V2(GridView dataGrid, GridViewRow row,string num)
        {
            string keyValue = this.GetKeyValueByGridRow(dataGrid, row.RowIndex);

            //=== �]�w DataGrid �� CheckBox�AValue �n�զX Primary Key ===
            HtmlInputCheckBox tmpChkBox = (HtmlInputCheckBox)row.FindControl("chkBox");
            if (tmpChkBox != null)
                tmpChkBox.Value = keyValue;

            //=== �]�w�s�� ===
            LinkButton tmpLink;
            tmpLink = (LinkButton)row.FindControl("edit" + num) ;

            if (tmpLink != null)
            {
                try
                {
                    if (!string.IsNullOrEmpty(APConfig.GetProperty("GRIDVIEW_EDIT_IMG")))
                        tmpLink.Text = "<img src='" + APConfig.GetProperty("GRIDVIEW_EDIT_IMG") + "' style='border:0; vertical-align:bottom' />";
                }
                catch { }

                //=== �v������(�s��) ===
                if (!ActionSecurity.HasFunctionPermission("0003"))
                    ((TableCell)tmpLink.Parent).Enabled = false;
                else
                {
                    tmpLink.Attributes.Add("onclick", "clickEditRow(this, '" + keyValue + "');");
                    tmpLink.Attributes.Add("KEY", keyValue);
                    row.Attributes.Add("KEY", keyValue);
                }
            }

            //=== �]�w�� ===
            tmpLink = (LinkButton)row.FindControl("detail" + num);
            if (tmpLink != null)
            {
                try
                {
                    if (!string.IsNullOrEmpty(APConfig.GetProperty("GRIDVIEW_DETAIL_IMG")))
                        tmpLink.Text = "<img src='" + APConfig.GetProperty("GRIDVIEW_DETAIL_IMG") + "' style='border:0; vertical-align:bottom' />";
                }
                catch { }

                //=== �v������(��) ===
                if (!ActionSecurity.SecurityCheck("DETAIL"))
                    ((TableCell)tmpLink.Parent).Enabled = false;
                else
                {
                    tmpLink.Attributes.Add("onclick", "clickDetailRow(this, '" + keyValue + "');");
                    tmpLink.Attributes.Add("KEY", keyValue);
                    row.Attributes.Add("KEY", keyValue);
                }
            }

            //=== �]�w�R�� ===
            tmpLink = (LinkButton)row.FindControl("del" + num);
            if (tmpLink != null)
            {
                try
                {
                    if (!string.IsNullOrEmpty(APConfig.GetProperty("GRIDVIEW_DEL_IMG")))
                        tmpLink.Text = "<img src='" + APConfig.GetProperty("GRIDVIEW_DEL_IMG") + "' style='border:0; vertical-align:bottom' />";
                }
                catch { }

                //=== �v������(�R��) ===
                if (!ActionSecurity.HasFunctionPermission("0002"))
                    ((TableCell)tmpLink.Parent).Enabled = false;
                else
                {
                    //=== �I��R���ɡA�X�{ confirm �T�� ===
                    tmpLink.Attributes.Add("KEY", keyValue);
                    tmpLink.OnClientClick = "return doDelete();";
                }
            }

            //=== �]�w�h��y�t ===
            BindMLProperty(row);
        }
        #endregion

        #region MergeRows �X�� GridView �x�s��
        /// <summary>
        /// �X�� GridView �x�s��
        /// </summary>
        /// <param name="gridView">GridView ����</param>
        /// <param name="cellIndex">���X�֪��C��</param>
        public void MergeRows(ref GridView gridView, int cellIndex)
        {
            int tmpIdx = 0;
            int rowCnt = 1;
            string temp = gridView.Rows[0].Cells[cellIndex].Text;

            for (int i = 1; i < gridView.Rows.Count; i++)
            {
                if (gridView.Rows[i].Cells[cellIndex].Text == temp)
                {
                    rowCnt++;
                    gridView.Rows[tmpIdx].Cells[cellIndex].RowSpan = rowCnt;
                    gridView.Rows[i].Cells[cellIndex].Visible = false;
                }
                else
                {
                    tmpIdx = i;
                    rowCnt = 1;
                    temp = gridView.Rows[i].Cells[cellIndex].Text;
                }
            }
        }
        #endregion
        #endregion

        #region �ץX Excel ����
        #region GetCHeadingStr ����ץX���Y�r��
        /// <summary>
        /// ���Y�r��
        /// </summary>
        protected string headingStr = "";

        /// <summary>
        /// ����ץX������Y�r��
        /// </summary>
        /// <returns>������Y�r��</returns>
        protected string GetCHeadingStr()
        {
            //=== For �ȮɳB�z, �W�u�ɭn���� ===
            FormUtil.Cache.Remove("COLUMN_FILTER");

            ColumnFilterUtil.ColiumnFilter tmp = ColumnFilterUtil.GetColumnFilter(this.DBManager, this.PageID);

            this.headingStr = tmp.EName.Replace("'", "");
            return tmp.CName.Replace("'", "");
        }
        #endregion

        #region GetHeadingStr ����ץX���Y�r��
        /// <summary>
        /// ����ץX�^����Y�r��
        /// </summary>
        /// <returns>�^����Y�r��</returns>
        protected string GetHeadingStr()
        {
            if (!string.IsNullOrEmpty(headingStr))
                return headingStr;

            //=== For �ȮɳB�z, �W�u�ɭn���� ===
            FormUtil.Cache.Remove("COLUMN_FILTER");

            ColumnFilterUtil.ColiumnFilter tmp = ColumnFilterUtil.GetColumnFilter(this.DBManager, this.PageID);

            return tmp.EName.Replace("'", "");
        }
        #endregion

        #region DrawContent ���ͶץX��� | L�� M�� R�k
        /// <summary>
        /// DrawContent ���ͶץX��� | L�� M�� R�k
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="index">����</param>
        /// <param name="content">�n�ץX�����</param>
        protected void DrawContent(DataTable dt, Int32 index, string content)
        {
            string align = "L";
            if (content.IndexOf('|') != -1)
            {
                align = content.Split('|')[1];
                content = content.Split('|')[0];
            }
            switch (align)
            {
                case "L":
                    Response.Write("<td align='left'>" + dt.Rows[index][content].ToString() + "&nbsp;</td>");
                    break;
                case "M":
                    Response.Write("<td align='center'>" + dt.Rows[index][content].ToString() + "&nbsp;</td>");
                    break;
                case "R":
                    Response.Write("<td align='right'>" + dt.Rows[index][content].ToString() + "</td>");
                    break;
            }
        }
        #endregion

        #region DrawContent ���ͶץX��� | L�� M�� R�k
        /// <summary>
        /// ���ͶץX��� | L�� M�� R�k
        /// </summary>
        /// <param name="content">�n�ץX�����</param>
        protected void DrawContent(string content)
        {
            string align = "L";
            if (content.IndexOf('|') != -1)
            {
                align = content.Split('|')[1];
                content = content.Split('|')[0];
            }
            switch (align)
            {
                case "L":
                    Response.Write("<td align='left'>" + content + "&nbsp;</td>");
                    break;
                case "M":
                    Response.Write("<td align='center'>" + content + "&nbsp;</td>");
                    break;
                case "R":
                    Response.Write("<td align='right'>" + content + "</td>");
                    break;
            }
        }
        #endregion
        #endregion

        #region DD ����
        #region BindDDProperty �N��Ʀr��]�w�M�ήM�e���W
        /// <summary>
        /// �N��Ʀr��]�w�M�ήM�e���W
        /// </summary>
        private void BindDDProperty()
        {
            try
            {
                this.LogUtil.TraceStart(MethodBase.GetCurrentMethod().Name);

                string needDD = "Y";

                try
                {
                    if (!string.IsNullOrEmpty(APConfig.GetProperty("NEED_DD")))
                        needDD = APConfig.GetProperty("NEED_DD");
                }
                catch { }

                if (needDD != "Y")
                    return;

                DataDictionaryUtil.ColumnDD tmpStruct;
                Control tmpControl;
                string ddColumn;

                this.LogUtil.TraceStart(MethodBase.GetCurrentMethod().Name + "_1");
                Hashtable columnDDMap = this.DDColumn;
                this.LogUtil.TraceEnd(MethodBase.GetCurrentMethod().Name + "_1");

                this.LogUtil.TraceStart(MethodBase.GetCurrentMethod().Name + "_2");
                Hashtable pageColumnMap = this.PageColumn;
                this.LogUtil.TraceEnd(MethodBase.GetCurrentMethod().Name + "_2");

                StringBuilder ddErr = new StringBuilder();
                for (int i = 0; i < this.ddUserControls.Count; i++)
                {
                    tmpControl = (Control)this.ddUserControls[i];
                    ddColumn = GetDD(tmpControl.ID.Substring(2));

                    if (!columnDDMap.ContainsKey(ddColumn))
                    {
                        
                        this.Logger.Append("��Ʀr�奼�]�w����� --> " + ddColumn);
                        if (FormUtil.GetAttributeData(tmpControl, "SKIP") == null)
                        {
                            //=== 2009/08/27 ���j RadioButtonList ���e���|�ˬd, ��ӤS�ˬd�䤣�X��], �ҥH�w����j�}���ˬd ===

                            if (tmpControl.GetType().Name.Equals("RadioButtonList"))
                                continue;

                            //Brian Chou Modify 2017/3/7 �����@���e�{
                            //throw new Exception("��Ʀr�奼�]�w����� --> " + ddColumn);

                            //Brian Chou Modify 2017/3/7
                            ddErr.Append(ddColumn + ",");
                            
                        }
                        else
                            continue;
                    }
                    else
                    { 
                        tmpStruct = (DataDictionaryUtil.ColumnDD)columnDDMap[ddColumn];

                        //=== �O����Ʀr�嫬�A ===
                        FormUtil.SetAttributeData(tmpControl, "DD", tmpStruct.UIType);

                        //=== �O�d�����T ===
                        if (pageColumnMap[this.PageID + "_" + tmpStruct.Name] == null)
                            FormUtil.SetAttributeData(tmpControl, "CNAME", LangUtil.LangMap("PAGE." + tmpStruct.CName));
                        else
                            FormUtil.SetAttributeData(tmpControl, "CNAME", LangUtil.LangMap("PAGE." + pageColumnMap[this.PageID + "_" + tmpStruct.Name].ToString()));

                        //=== �����\�ť�, �Ȱw��s��e���B�z ===
                        SetBindUIChkFormByProp(tmpControl, tmpStruct);

                        //=== �w�q�e�����A ===
                        SetBindUIType(tmpControl, tmpStruct);

                        //=== ���� ===
                        if (!tmpStruct.UIType.Equals("CYM") && !tmpStruct.UIType.Equals("CD9") && !tmpStruct.UIType.Equals("CD7") && !tmpStruct.UIType.Equals("CD") && !tmpStruct.UIType.Equals("D") &&
                            !tmpStruct.UIType.Equals("T") && !tmpStruct.UIType.Equals("A") &&
                            !tmpStruct.UIType.Equals("N3") && !tmpStruct.UIType.Equals("N4"))
                            this.JScript.IniFormSet(tmpControl, new string[] { JScript.Ctrl.AutoTab, JScript.Ctrl.MaxLength, tmpStruct.Length });
                        else if (tmpStruct.UIType.Equals("A"))
                            this.JScript.IniFormSet(tmpControl, new string[] { JScript.Ctrl.AutoTab, JScript.Ctrl.MaxLength, tmpStruct.Length + 1 });

                        //2011/01/12 nono add for fix onchange event
                        if (tmpControl.GetType().Name.Equals("TextBox"))
                        {
                            //2017.12.27 Tim : EXCLUDE EMAIL
                            //if (!tmpStruct.UIType.Equals("EMAIL")) 
                            //{
                                JScript.ControlEventAdd(tmpControl, "onfocus", "focusTextBox(this);");                                
                            //}
                            JScript.ControlEventAdd(tmpControl, "onblur", "blurTextBox(this);");
                        }
                    }
                }
                
                if (!String.IsNullOrEmpty(ddErr.ToString()))
                {
                    throw new Exception("��Ʀr�奼�]�w����� --> " + ddErr.ToString());
                }
            }
            finally
            {
                this.LogUtil.TraceEnd(MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region GetDD ���o DD ���
        private string GetDD(string column)
        {
            if (column.IndexOf("_") == 1)
                return column.Substring(2);
            else
                return column;
        }
        #endregion

        #region ServerSideValid Server ���ˮ�
        /// <summary>
        /// Server ���ˮ�
        /// </summary>
        /// <param name="validForm">�ˮ֪� Form Q_ || M_</param>
        protected void ServerSideValid(string validForm)
        {
            try
            {
                this.LogUtil.TraceStart(MethodBase.GetCurrentMethod().Name);

                Hashtable columnDD = this.DDColumn;
                DataDictionaryUtil.ColumnDD tmpStruct;
                Control tmpControl;
                string ddColumn;
                string columnValue;
                for (int i = 0; i < this.ddUserControls.Count; i++)
                {
                    tmpControl = (Control)this.ddUserControls[i];
                    columnValue = FormUtil.GetControlValue(tmpControl);
                    ddColumn = GetDD(tmpControl.ID.Substring(2));

                    //=== �D�ˬd�� Form ���B�z ===
                    if (!tmpControl.ID.Substring(0, 2).Equals(validForm))
                        continue;

                    //=== SKIP �������ˬd ===
                    if (FormUtil.GetAttributeData(tmpControl, "SKIP") != null && FormUtil.GetAttributeData(tmpControl, "SKIP").Equals("Y"))
                        continue;

                    if (!columnDD.Contains(ddColumn))
                        continue;

                    tmpStruct = (DataDictionaryUtil.ColumnDD)columnDD[ddColumn];

                    //=== �ˬd�r����� ===
                    if (!string.IsNullOrEmpty(tmpStruct.Length))
                    {
                        if (tmpControl.GetType().Name.Equals("TextBox") && ((TextBox)tmpControl).MaxLength > 0)
                        {
                            int maxLength = Convert.ToInt32(((TextBox)tmpControl).MaxLength);
                            if (columnValue.Replace("''", "'").Length > maxLength && !tmpStruct.UIType.Equals("CYM") && !tmpStruct.UIType.Equals("CD9") && !tmpStruct.UIType.Equals("CD7") && !tmpStruct.UIType.Equals("CD") &&
                                !tmpStruct.UIType.Equals("D") && !tmpStruct.UIType.Equals("A") && !tmpStruct.UIType.Equals("T") &&
                                !tmpStruct.UIType.Equals("N3") && !tmpStruct.UIType.Equals("N4"))
                                throw new ServerSideValidException("���:" + tmpControl.ID + " ��J���׹L���G" + columnValue + "����:" + columnValue.Length + ", DD �]�w����(�ۭq)�G" + maxLength);
                        }
                        else
                        {
                            if (columnValue.Replace("''", "'").Length > Convert.ToInt32(tmpStruct.Length) && !tmpStruct.UIType.Equals("CYM") && !tmpStruct.UIType.Equals("CD9") && !tmpStruct.UIType.Equals("CD7") && !tmpStruct.UIType.Equals("CD") &&
                                !tmpStruct.UIType.Equals("D") && !tmpStruct.UIType.Equals("A") && !tmpStruct.UIType.Equals("T") &&
                                !tmpStruct.UIType.Equals("N3") && !tmpStruct.UIType.Equals("N4"))
                                throw new ServerSideValidException("���:" + tmpControl.ID + " ��J���׹L���G" + columnValue + "����:" + columnValue.Length + ", DD �]�w���סG" + tmpStruct.Length);
                        }
                    }

                    //20170906 ����
                    if (tmpControl.GetType().Name.Equals("DropDownList"))
                    {
                        DropDownList ddl = (DropDownList)tmpControl;
                        DBManager.Logger.Append("ddl->" + ddl.SelectedValue);
                    }

                    if (string.IsNullOrEmpty(columnValue))
                    {
                        //=== �ˬd�ťէ_ ===
                        if (!string.IsNullOrEmpty(FormUtil.GetAttributeData(tmpControl, "chkForm")))
                        {
                            throw new ServerSideValidException("���[" + tmpControl.ID + "]���i���ŭ�!!");
                        }
                        else
                            continue;
                    }
                    //=== �ˬd�r��榡 ===
                    Regex reg = null;
                    switch (tmpStruct.UIType)
                    {
                        //=== ��� ===
                        case "CD":
                            if (!DateUtil.IsDate(columnValue))
                                throw new ServerSideValidException("[���]���:" + tmpControl.ID + " ����榡���~�G" + columnValue);
                            break;
                        //=== ��� ===
                        case "D":
                            if (!DateUtil.IsDate(columnValue))
                                throw new ServerSideValidException("[���]���:" + tmpControl.ID + " ����榡���~�G" + columnValue);
                            break;
                        //=== ��� ===
                        case "DT":
                            if (!DateUtil.IsDate(columnValue))
                                throw new ServerSideValidException("[���]���:" + tmpControl.ID + " ����榡���~�G" + columnValue);
                            break;
                        //=== ��ƼƦr ===
                        case "N":
                            try { Convert.ToInt64(columnValue); }
                            catch (Exception) { throw new ServerSideValidException("[��ƼƦr]���:" + tmpControl.ID + " ��������ƼƦr�G" + columnValue); }
                            break;
                        //=== �¼Ʀr ===
                        case "N1":
                            reg = new Regex("[^0-9]");
                            if (reg.IsMatch(columnValue))
                                throw new ServerSideValidException("[�¼Ʀr]���:" + tmpControl.ID + " �������¼Ʀr�榡�G" + columnValue);
                            break;
                        //=== ����Ƥ��t�p�� ===
                        case "N2":
                            reg = new Regex("[^0-9]");
                            if (reg.IsMatch(columnValue))
                                throw new ServerSideValidException("[����Ƥ��t�p��]���:" + tmpControl.ID + " �������¼Ʀr�榡�G" + columnValue);
                            break;
                        //=== �Ʀr�t�p�Ƥ��n3��@�J ===
                        case "N3":
                            try { Convert.ToDouble(columnValue); }
                            catch (Exception) { throw new ServerSideValidException("[�Ʀr�t�p�Ƥ��n3��@�J]���:" + tmpControl.ID + " �������Ʀr�t�p�Ʈ榡�G" + columnValue); }
                            break;
                        //=== ����Ƨt�p�Ƥ��n3��@�J ===
                        case "N4":
                            try { Convert.ToDouble(columnValue); }
                            catch (Exception) { throw new ServerSideValidException("[����Ƨt�p�Ƥ��n3��@�J]���:" + tmpControl.ID + " ����������Ƨt�p�Ʈ榡�G" + columnValue); }
                            if (Convert.ToDouble(columnValue) < 0)
                                throw new ServerSideValidException("[����Ƨt�p�Ƥ��n3��@�J]���:" + tmpControl.ID + " ����������Ƨt�p�Ʈ榡�G" + columnValue);
                            break;
                        //=== ���^�V�X ===
                        case "X":
                            break;
                        //=== IDN_BAN ===
                        case "I":
                            break;
                        //=== �Ʀr�e�ɹs ===
                        case "Z":
                            reg = new Regex("[^0-9]");
                            if (reg.IsMatch(columnValue))
                                throw new ServerSideValidException("[�Ʀr�e�ɹs]���:" + tmpControl.ID + " ��������ƼƦr�榡�G" + columnValue);
                            break;
                        //=== �ɶ� ===
                        case "T":
                            if (!DateUtil.IsTime(columnValue))
                                throw new ServerSideValidException("[�ɶ�]���:" + tmpControl.ID + " �������ɶ��榡�G" + columnValue);
                            break;
                        //=== �Ʀr�t�p�� ===
                        case "A":
                            try { Convert.ToDouble(columnValue); }
                            catch (Exception) { throw new ServerSideValidException("[�Ʀr�t�p��]���:" + tmpControl.ID + " �������Ʀr�t�p�Ʈ榡�G" + columnValue); }
                            break;
                        //=== �^�� ===
                        case "E":
                            reg = new Regex("[^a-zA-Z0-9]");
                            if (reg.IsMatch(columnValue))
                                throw new ServerSideValidException("[�^��]���:" + tmpControl.ID + " �������^�Ʈ榡�G" + columnValue);
                            break;
                        //=== �^�Ƥp�g(�t�Ÿ�) ===
                        case "EL":
                            reg = new Regex("[A-Z]");
                            if (reg.IsMatch(columnValue))
                                throw new ServerSideValidException("[�^�Ƥp�g(�t�Ÿ�)]���:" + tmpControl.ID + " ���������i���^�Ƥj�g��T�G" + columnValue);
                            if (Utility.GetBLen(columnValue) != columnValue.Length)
                                throw new ServerSideValidException("[�^�Ƥp�g(�t�Ÿ�)]���:" + tmpControl.ID + " ���������i�]�t�����T�G" + columnValue);
                            break;
                        //=== �^�Ƥj�g(�t�Ÿ�) ===
                        case "EU":
                            reg = new Regex("[a-z]");
                            if (reg.IsMatch(columnValue))
                                throw new ServerSideValidException("[�^�Ƥj�g(�t�Ÿ�)]���:" + tmpControl.ID + " ���������i���^�Ƥp�g��T�G" + columnValue);
                            if (Utility.GetBLen(columnValue) != columnValue.Length)
                                throw new ServerSideValidException("[�^�Ƥj�g(�t�Ÿ�)]���:" + tmpControl.ID + " ���������i�]�t�����T�G" + columnValue);
                            break;
                        //=== �^�Ƥj�g(���t�Ÿ�) ===
                        case "EU1":
                            reg = new Regex("[a-z]");
                            if (reg.IsMatch(columnValue))
                                throw new ServerSideValidException("[�^�Ƥj�g(�t�Ÿ�)]���:" + tmpControl.ID + " ���������i���^�Ƥp�g��T�G" + columnValue);
                            if (Utility.GetBLen(columnValue) != columnValue.Length)
                                throw new ServerSideValidException("[�^�Ƥj�g(�t�Ÿ�)]���:" + tmpControl.ID + " ���������i�]�t�����T�G" + columnValue);
                            break;
                        //=== �^��(�t�Ÿ�) ===
                        case "EW":
                            if (Utility.GetBLen(columnValue) != columnValue.Length)
                                throw new ServerSideValidException("[�^��(�t�Ÿ�)]���:" + tmpControl.ID + " ���������i�]�t�����T�G" + columnValue);
                            break;
                        //=== PKNO ===
                        case "PK":
                            break;
                    }
                }
            }
            finally
            {
                this.LogUtil.TraceEnd(MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region BindDDFormat �M�θ�Ʀr��榡��
        /// <summary>
        /// �M�θ�Ʀr��榡��
        /// </summary>
        /// <param name="dt">DataTable ���</param>
        /// <param name="formatType">�榡�ƺ���</param>
        /// <returns>�榡�ƫ�r�� DataTable ���</returns>
        public DataTable BindDDFormat(DataTable dt, FormUtil.FormatType formatType)
        {
            DataTable newCloneDt = new DataTable();

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (formatType.Equals(FormUtil.FormatType.Report))
                {
                    if (dt.Columns[i].DataType.ToString().Equals("System.DateTime") || dt.Columns[i].DataType.ToString().Equals("System.String"))
                        newCloneDt.Columns.Add(new DataColumn(dt.Columns[i].ColumnName, System.Type.GetType("System.String")));
                    else
                        newCloneDt.Columns.Add(new DataColumn(dt.Columns[i].ColumnName, System.Type.GetType(dt.Columns[i].DataType.ToString())));
                }
                else
                    newCloneDt.Columns.Add(new DataColumn(dt.Columns[i].ColumnName, System.Type.GetType("System.String")));
            }

            Hashtable columnDD = this.DDColumn;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dw = newCloneDt.NewRow();

                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (dt.Columns[j].DataType.ToString().Equals("System.String"))
                    {
                        dw[dt.Columns[j].ColumnName] = Utility.CheckNull(dt.Rows[i][j], "");
                        dw[dt.Columns[j].ColumnName] = Utility.CheckNull(this.BindDDFormat(dw, dt.Columns[j].ColumnName, formatType, columnDD), "");
                    }
                    else
                    {
                        dw[dt.Columns[j].ColumnName] = dt.Rows[i][j];
                        dw[dt.Columns[j].ColumnName] = this.BindDDFormat(dw, dt.Columns[j].ColumnName, formatType, columnDD);
                    }
                }
                newCloneDt.Rows.Add(dw);
            }
            newCloneDt.AcceptChanges();

            return newCloneDt;
        }
        #endregion

        #region BindDDFormat �M�θ�Ʀr��榡��
        /// <summary>
        /// �M�θ�Ʀr��榡��
        /// </summary>
        /// <param name="dr">��ƦC����</param>
        /// <param name="columnName">���W��</param>
        /// <param name="formatType">�榡�ƺ���</param>
        /// <param name="columnDD">��Ʀr��Ȧs���e</param>
        /// <returns>�榡�ƫ�r��</returns>
        private object BindDDFormat(DataRow dr, String columnName, FormUtil.FormatType formatType, Hashtable columnDD)
        {
            if (Convert.IsDBNull(dr[columnName]))
                return dr[columnName];

            if (columnDD[columnName] == null)
                return dr[columnName].ToString();

            DataDictionaryUtil.ColumnDD tmpStruct = (DataDictionaryUtil.ColumnDD)columnDD[columnName];
            string result = "";

            try
            {
                switch (tmpStruct.UIType)
                {
                    //=== ������ɶ�(�����) ===
                    case "DT":
                        if (string.IsNullOrEmpty((string)dr[columnName]))
                            result = "";
                        else
                            result = Convert.ToDateTime(dr[columnName]).ToString("yyyy/MM/dd HH:mm:ss");
                        break;
                    //=== ���j�g����ɶ�(�����) ===
                    case "FCDT":
                        if (string.IsNullOrEmpty((string)dr[columnName]))
                            result = "";
                        else
                        {
                            string cDate = DateUtil.ConvertDate(Convert.ToDateTime(dr[columnName]).ToString("yyyyMMdd"));
                            result = "����" + Convert.ToInt32(cDate.Substring(0, 3)) + "�~" +
                                    Convert.ToInt32(cDate.Substring(3, 2)) + "��" +
                                    Convert.ToInt32(cDate.Substring(5)) + "�� " +
                                    Convert.ToDateTime(dr[columnName]).ToString("HH:mm:ss");
                        }
                        break;
                    //=== ���j�g����ɶ�(�����) ===
                    case "FCD":
                        if (string.IsNullOrEmpty((string)dr[columnName]))
                            result = "";
                        else
                        {
                            string cDate = DateUtil.ConvertDate(Convert.ToDateTime(dr[columnName]).ToString("yyyyMMdd"));
                            result = "����" + Convert.ToInt32(cDate.Substring(0, 3)) + "�~" +
                                    Convert.ToInt32(cDate.Substring(3, 2)) + "��" +
                                    Convert.ToInt32(cDate.Substring(5)) + "��";
                        }
                        break;
                    //=== ������ɶ�(�����) ===
                    case "CDT":
                        if (string.IsNullOrEmpty((string)dr[columnName]))
                            result = "";
                        else
                            result = DateUtil.FormatCDate(DateUtil.ConvertDate(Convert.ToDateTime(dr[columnName]).ToString("yyyyMMdd"))) + " " + Convert.ToDateTime(dr[columnName]).ToString("HH:mm:ss");
                        break;
                    //=== ��� ===
                    case "CD":
                        if (string.IsNullOrEmpty((string)dr[columnName]))
                            result = "";
                        else
                            result = DateUtil.FormatCDate(DateUtil.ConvertDate(Convert.ToDateTime(dr[columnName]).ToString("yyyyMMdd")));
                        break;
                    case "CD7":
                        if (string.IsNullOrEmpty((string)dr[columnName]))
                            result = "";
                        else
                            result = DateUtil.FormatCDate(dr[columnName].ToString());
                        break;
                    case "CD9":
                        if (string.IsNullOrEmpty((string)dr[columnName]))
                            result = "";
                        else
                            result = DateUtil.FormatCDate(dr[columnName].ToString());
                        break;
                    //=== �褸�~ ===
                    case "D":
                        if (string.IsNullOrEmpty((string)dr[columnName]))
                            result = "";
                        else
                            result = Convert.ToDateTime(dr[columnName]).ToString("yyyy/MM/dd");
                        break;
                    //=== �ɶ��榡 ===
                    case "T":
                        if (string.IsNullOrEmpty((string)dr[columnName]))
                            result = "";
                        else
                            result = DateUtil.FormatTime(dr[columnName].ToString());
                        break;
                    //=== ���B ===
                    case "A":
                        if (formatType.Equals(FormUtil.FormatType.Report))
                            result = dr[columnName].ToString();
                        else
                        {
                            if (!dr[columnName].ToString().Equals(""))
                            {
                                result = Convert.ToDouble(dr[columnName]).ToString("#,##0.########");
                            }
                        }
                        break;
                    default:
                        result = dr[columnName].ToString();
                        break;
                }
            }
            catch (Exception)
            {
                this.Logger.Append("Error Column:" + columnName + ", Value:" + dr[columnName]);
                throw;
            }

            return result;
        }

        private void SetBindUIChkFormByProp(Control control, DataDictionaryUtil.ColumnDD tmpStruct)
        {
            //=== ���o�ˮ֦r�� ===
            string validData = FormUtil.GetControlValidationGroupData(control);
            //=== ���o�ˮֺ��� ===
            string validType = GetValidType(validData.Trim().ToUpper());

            switch (validType)
            {
                case "NOTNULL":
                    this.JScript.ChkForm(control, FormUtil.GetAttributeData(control, "CNAME"));
                    break;
            }
        }

        private string GetValidType(string validData)
        {
            string[] valids = new string[] { "NOTNULL" };
            string[] valAry = validData.Split(',');
            for (int i = 0; i < valAry.Length; i++)
            {
                for (int j = 0; j < valids.Length; j++)
                {
                    if (valAry[i].Trim().ToUpper().Equals(valids[j]))
                        return valids[j].ToUpper();
                }
            }
            return "";
        }

        private void SetBindUIType(Control control, DataDictionaryUtil.ColumnDD tmpStruct)
        {
            switch (tmpStruct.UIType)
            {
                //=== ��� yyy/MM/dd ===
                case "CD":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.MaxLength, "9" });
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.DateFormat });
                    break;
                //=== ��� yyyy/MM/dd ===
                case "D":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.MaxLength, "10" });
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.DateFormat });
                    break;
                //=== ��� ===
                case "DT":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.DateFormat });
                    break;
                //=== ��ƼƦr ===
                case "N":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.NumberFormat });
                    break;
                //=== �¼Ʀr ===
                case "N1":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.OnlyNumber });
                    break;
                //=== ����Ƥ��t�p�� ===
                case "N2":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.OnlyNumber });
                    break;
                //=== �¤��� ===
                case "H":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.FullString });
                    break;
                //=== �^�ƫ��A ===
                case "E":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.OnlyNumberAndEnglish });
                    break;
                //=== ���^�V�X ===
                case "X":
                    break;
                //=== IDN_BAN ===
                case "I":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.IdnBan });
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.UpperCase });
                    break;
                //=== �Ʀr�e�ɹs ===
                case "Z":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.OnlyNumber });
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.FillZero, tmpStruct.Length });
                    break;
                //=== �ɶ� ===
                case "T":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.MaxLength, "8" });
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.TimeFormat });
                    break;
                //=== �Ʀr�t�p�� ===
                case "A":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.DecimalFormat, tmpStruct.Length + "." + tmpStruct.Dot });
                    break;
                //=== �Ʀr�t�p�Ƥ��n3��@�J ===
                case "N3":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.DecimalFormatNoFormat, tmpStruct.Length + "." + tmpStruct.Dot });
                    break;
                //=== ����Ƨt�p�Ƥ��n3��@�J ===
                case "N4":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.DecimalFormatNoFormat1, tmpStruct.Length + "." + tmpStruct.Dot });
                    break;
                //=== �^�Ƥp�g(�t�Ÿ�) ===
                case "EL":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.OnlyNumberEngAndSpecialWord });
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.LowerCase });
                    break;
                //=== �^�Ƥj�g(�t�Ÿ�) ===
                case "EU":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.OnlyNumberEngAndSpecialWord });
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.UpperCase });
                    break;
                //=== �^�Ƥj�g(���t�Ÿ�) ===
                case "EU1":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.OnlyNumberAndEnglish });
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.UpperCase });
                    break;
                //=== �^��(�t�Ÿ�) ===
                case "EW":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.OnlyNumberEngAndSpecialWord });
                    break;
                //=== IP ===
                case "IP":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.IP });
                    break;
                //=== �q�ܫ��A ===
                case "TEL":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.TEL });
                    break;
                //=== ���} ===
                case "HTTP":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.HTTP });
                    break;
                //=== EMAIL ===
                case "EMAIL":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.EMAIL });
                    break;
                //=== PKNO ===
                case "PK":
                    break;
            }
        }
        #endregion

        #region BindCompleteColumnFieldProperty ��l�Ƹ�����]�w Load Complete
        /// <summary>
        /// BindCompleteColumnFieldProperty
        /// </summary>
        private void BindCompleteColumnFieldProperty()
        {
            try
            {
                this.LogUtil.TraceStart(MethodBase.GetCurrentMethod().Name);

                DataDictionaryUtil.ColumnField tmpStruct;
                Control tmpControl;
                string ddColumn;
                string columnHeader;
                string fieldCD;
                Hashtable columnFieldMap = this.ColumnField;

                for (int i = 0; i < this.ddUserControls.Count; i++)
                {
                    tmpControl = (Control)this.ddUserControls[i];
                    ddColumn = GetDD(tmpControl.ID.Substring(2));
                    columnHeader = tmpControl.ID.Substring(0, 2);
                    fieldCD = columnHeader + ddColumn;

                    //=== ����� Exp: M_DD ===
                    if (!columnFieldMap.ContainsKey(this.PageID + "_" + fieldCD))
                        continue;

                    tmpStruct = (DataDictionaryUtil.ColumnField)columnFieldMap[this.PageID + "_" + fieldCD];

                    //=== �ﶵ�[�ť� ===
                    if (!string.IsNullOrEmpty(tmpStruct.AddBlank) && tmpStruct.AddBlank.Equals("Y") && tmpStruct.FieldType.Equals("DDL"))
                    {
                        switch (tmpStruct.Head)
                        {
                            case "Q":
                                FormUtil.SetDropdownListEmptyList(((DropDownList)tmpControl), FormUtil.UIType.Query);
                                break;
                            case "M":
                                FormUtil.SetDropdownListEmptyList(((DropDownList)tmpControl), FormUtil.UIType.Edit);
                                break;
                            case "G":
                                FormUtil.SetDropdownListEmptyList(((DropDownList)tmpControl), FormUtil.UIType.Result);
                                break;
                            default:
                                FormUtil.SetDropdownListEmptyList(((DropDownList)tmpControl), FormUtil.UIType.Edit);
                                break;
                        }
                    }
                }
            }
            finally
            {
                this.LogUtil.TraceEnd(MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region BindColumnFieldProperty ��l�Ƹ�����]�w
        /// <summary>
        /// ��l�Ƹ�����]�w
        /// </summary>
        private void BindColumnFieldProperty()
        {
            try
            {
                this.LogUtil.TraceStart(MethodBase.GetCurrentMethod().Name);

                DataDictionaryUtil.ColumnField tmpStruct;
                Control tmpControl;
                string ddColumn;
                string columnHeader;
                string fieldCD;
                Hashtable columnFieldMap = this.ColumnField;
                Hashtable sessionMap = this.SessionMap;	//(Hashtable)MultiProcess.GetGlobalValue("SESSION_MAP");

                for (int i = 0; i < this.ddUserControls.Count; i++)
                {
                    tmpControl = (Control)this.ddUserControls[i];
                    try
                    {
                        //=== nono mark 2009/04/28 �e����줣�ݧP�_ _1 _2 Spec �w�t ===
                        //ddColumn	=	GetDD(tmpControl.ID.Substring(2));
                        ddColumn = tmpControl.ID.Substring(2);
                        columnHeader = tmpControl.ID.Substring(0, 2);
                        fieldCD = columnHeader + ddColumn;

                        //=== ����� Exp: M_DD ===
                        if (!columnFieldMap.ContainsKey(this.PageID + "_" + fieldCD))
                            continue;

                        tmpStruct = (DataDictionaryUtil.ColumnField)columnFieldMap[this.PageID + "_" + fieldCD];

                        //=== ��Ū ===
                        if (tmpStruct.ReadOnly)
                            this.JScript.IniFormSet(tmpControl, new string[] { JScript.Ctrl.Disable, "1" });
                        //=== ���� ===
                        if (tmpStruct.NotNull)
                        {
                            FormUtil.SetControlValidationGroup(tmpControl, "NOTNULL");
                            FormUtil.SetAttributeData(tmpControl, "chkForm", LangUtil.LangMap("PAGE." + tmpStruct.CName));
                        }

                        //=== �ﶵ�[�ť� ===
                        if (!string.IsNullOrEmpty(tmpStruct.AddBlank) && tmpStruct.AddBlank.Equals("Y") && tmpStruct.FieldType.Equals("DDL"))
                        {
                            FormUtil.SetAttributeData(tmpControl, "ADD_BLANK", "Y");
                        }

                        //=== �ﶵ���e ===
                        string[] content;
                        if (!string.IsNullOrEmpty(tmpStruct.Content))
                        {
                            content = tmpStruct.Content.Split(',');
                            if (content.Length % 2 != 0)
                                throw new Exception(tmpStruct.CName + "�U�Թw�]���e���~: " + tmpStruct.Content);

                            switch (tmpStruct.FieldType.ToUpper())
                            {
                                case "CHK":
                                    ((CheckBoxList)tmpControl).Items.Clear();
                                    break;
                                case "DDL":
                                case "DDLM":
                                    ((DropDownList)tmpControl).Items.Clear();
                                    break;
                                case "RDO":
                                    ((RadioButtonList)tmpControl).Items.Clear();
                                    break;
                            }

                            for (int j = 0; j < content.Length; j += 2)
                            {
                                ListItem item = new ListItem(content[j + 1].Trim(), content[j].Trim());

                                switch (tmpStruct.FieldType.ToUpper())
                                {
                                    case "CHK":
                                        ((CheckBoxList)tmpControl).Items.Add(item);
                                        break;
                                    case "DDL":
                                    case "DDLM":
                                        ((DropDownList)tmpControl).Items.Add(item);
                                        break;
                                    case "RDO":
                                        ((RadioButtonList)tmpControl).Items.Add(item);
                                        break;
                                }
                            }
                        }

                        //=== �w�]�� ===
                        if (!string.IsNullOrEmpty(tmpStruct.DefaultValue))
                        {
                            switch (tmpStruct.DefaultValue)
                            {
                                case "�t�Τ��":
                                    tmpStruct.DefaultValue = DateUtil.FormatCDate(DateUtil.GetNowCDate());
                                    break;
                                case "�t�Φ~":
                                    tmpStruct.DefaultValue = DateUtil.GetNowCDate().Substring(0, 3);
                                    break;
                                case "�t�Τ�":
                                    tmpStruct.DefaultValue = System.DateTime.Now.ToString("MM");
                                    break;
                                case "�t�Τ�":
                                    tmpStruct.DefaultValue = System.DateTime.Now.ToString("dd");
                                    break;
                                case "�t�ή�":
                                    tmpStruct.DefaultValue = System.DateTime.Now.ToString("HH");
                                    break;
                            }
                            this.JScript.IniFormSet(tmpControl, new string[] { JScript.Ctrl.DefaultValue, tmpStruct.DefaultValue, JScript.Ctrl.Value, tmpStruct.DefaultValue });
                        }

                        //�w�]��, �w�] Session, ��Ū, ����, �ﶵ�[�ť�, �ﶵ���e
                        if (!string.IsNullOrEmpty(tmpStruct.DefaultSessionValue))
                        {
                            if (sessionMap[tmpStruct.DefaultSessionValue] == null)
                                throw new Exception("�w�]�� Session �w�q���~: " + tmpStruct.DefaultSessionValue);
                            if (Session[sessionMap[tmpStruct.DefaultSessionValue].ToString()] == null)
                                throw new Exception("�w�]�� Session: Session ���w�q -> " + tmpStruct.DefaultSessionValue + ":" + sessionMap[tmpStruct.DefaultSessionValue].ToString());
                            this.JScript.IniFormSet(tmpControl, new string[]{JScript.Ctrl.DefaultValue, Session[sessionMap[tmpStruct.DefaultSessionValue].ToString()].ToString(), 
													JScript.Ctrl.Value, Session[sessionMap[tmpStruct.DefaultSessionValue].ToString()].ToString()});
                        }

                        //=== �O�d�����T ===
                        FormUtil.SetAttributeData(tmpControl, "CNAME", LangUtil.LangMap("PAGE." + tmpStruct.CName));
                    }
                    catch (Exception ex)
                    {
                        this.Logger.Append("�e�����B�z���~ :" + tmpControl.ID);
                        throw ex;
                    }
                }
            }
            finally
            {
                this.LogUtil.TraceEnd(MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        /// <summary>
        /// �P�_�O�_�ﶵ�[�ť�
        /// </summary>
        /// <param name="controlName">����W��</param>
        /// <param name="currAttr">������Ѽ�</param>
        /// <returns>�O�_�ﶵ�[�ť�</returns>
        protected bool IsAddBlank(string controlName, bool currAttr)
        {
            if (currAttr ||
                (((DropDownList)this.FindControl(controlName)).Attributes["ADD_BLANK"] != null &&
                ((DropDownList)this.FindControl(controlName)).Attributes["ADD_BLANK"].Equals("Y")))
                return true;
            else
                return false;
        }
        #endregion

        #region �h��y�t����
        #region BindMLProperty �N�h��y�t��ƮM�b�e���W
        /// <summary>
        /// �N�h��y�t��ƮM�b�e���W
        /// </summary>
        /// <remarks></remarks>
        public void BindMLProperty(Control processObject)
        {
            try
            {
                this.LogUtil.TraceStart(MethodBase.GetCurrentMethod().Name);

                ArrayList userControls = new ArrayList();
                FormUtil.FindUIMLControls(processObject, userControls);

                string tmpML;
                string tmpData;

                for (int i = 0; i < userControls.Count; i++)
                {
                    //tmpML	=	FormUtil.GetAttributeData(userControls[i], "ML").Replace("CL_", "COMMON.LABEL.").Replace("CB_", "COMMON.BUTTON.").Replace("PL_", this.PageID + ".LABEL.").Replace("PB_", this.PageID + ".BUTTON.");

                    //tmpML	=	FormUtil.GetAttributeData(userControls[i], "ML").Replace("CL_", "COMMON.").Replace("CB_", "COMMON.").Replace("PL_", this.PageID + ".").Replace("PB_", this.PageID + ".");
                    //2014.04.14 Brian Modify this.PageID �אּ PAGE
                    //tmpML = FormUtil.GetAttributeData(userControls[i], "ML").Replace("CL_", "COMMON.").Replace("CB_", "COMMON.").Replace("PL_", "PAGE.").Replace("PB_", "PAGE.").Replace("PC_", this.PageID + ".");

                    string ml = "";
                    switch (userControls[i].GetType().Name)
                    {
                        case "Label":
                            ml = ((Label)userControls[i]).Attributes["ML"];
                            break;
                        case "LinkButton":
                            ml = ((LinkButton)userControls[i]).Attributes["ML"];
                            break;
                        case "Button":
                            ml = ((Button)userControls[i]).Attributes["ML"];
                            break;
                        case "CheckBox":
                            ml = ((CheckBox)userControls[i]).Attributes["ML"];
                            break;
                        case "RadioButton":
                            ml = ((RadioButton)userControls[i]).Attributes["ML"];
                            break;
                        case "HtmlInputButton":
                            ml = ((HtmlInputButton)userControls[i]).Attributes["ML"];
                            break;
                        case "HtmlGenericControl":
                            ml = ((HtmlGenericControl)userControls[i]).Attributes["ML"];
                            break;
                        case "DataControlFieldHeaderCell":
                            ml = ((DataControlFieldHeaderCell)userControls[i]).Text;
                            break;
                    }

                    tmpML = ml.Replace("CL_", "COMMON.").Replace("CB_", "COMMON.").Replace("PL_", "PAGE.").Replace("PB_", "PAGE.").Replace("PC_", this.PageID + ".");

                    tmpData = this.LangUtil.LangMap(tmpML);
                    if (String.IsNullOrEmpty(tmpData))
                        continue;
                    //== ��e����� ===
                    FormUtil.SetControlText((Control)userControls[i], tmpData);
                }
            }
            finally
            {
                this.LogUtil.TraceEnd(MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion
        #endregion

        #region �e���B�z
        #region BindUIByDataTable �B�z�N DataTable ���G Bind ��e���W"
        /// <summary>
        /// �B�z�N DataTable ���G Bind ��e���W
        /// </summary>
        /// <param name="data">DataTable ��ƪ���</param>
        protected void BindUIByDataTable(DataTable data)
        {
            string fieldName;

            for (int i = 0; i < data.Columns.Count; i++)
            {
                fieldName = data.Columns[i].ColumnName.ToUpper();
                if (!fieldName.Equals("ROWSTAMP"))
                    fieldName = "M_" + fieldName;

                if (this.FindControl(fieldName) != null)
                {
                    //== ��e����� ===
                    FormUtil.SetControlValue(this.FindControl(fieldName), data.Rows[0][i]);
                }
            }
        }
        #endregion

        #region BindUIByDataTable �B�z�N DataTable ���G Bind ��e���W(���w�϶�)"
        /// <summary>
        /// �B�z�N DataTable ���G Bind ��e���W
        /// </summary>
        /// <param name="data">DataTable ��ƪ���</param>
        /// <param name="blockName">�϶��W��</param>
        protected void BindUIByDataTable(DataTable data, string blockName)
        {
            string fieldName;

            for (int i = 0; i < data.Columns.Count; i++)
            {
                fieldName = data.Columns[i].ColumnName.ToUpper();
                if (!fieldName.Equals("ROWSTAMP"))
                    fieldName = blockName + fieldName;

                if (this.FindControl(fieldName) != null)
                {
                    //== ��e����� ===
                    FormUtil.SetControlValue(this.FindControl(fieldName), data.Rows[0][i]);
                }
            }
        }
        #endregion

        #region ColumnFilterInit ��l�����z��]�w
        /// <summary>
        /// ��l�����z��]�w
        /// </summary>
        private void ColumnFilterInit()
        {
            if (this.PageID == null)
                return;

            ColumnFilterUtil.ColiumnFilter filter = ColumnFilterUtil.GetColumnFilter(this.DBManager, this.PageID);
            this.JScript.Script = "var columnNameAry1 = [" + filter.CName + "]";
            this.JScript.Script = "var columnCodeAry1 = [" + filter.EName + "]";
            this.JScript.Script = "var columnIndexAry1 = [" + filter.Index + "]";
            this.JScript.Script = "var nonCheckQry1 = [" + filter.NoShowIndex + "]";
            this.JScript.Script = "var recordName1 = '" + this.PageID + "'";
            this.JScript.Script = "var readOnlyColumn = '," + Utility.CheckNull(Session["1_READONLY_COLUMN"], "") + ",'";
        }
        #endregion

        #region MapRequestToUIControl �N Request ��ƹ����챱��W, For �ץX�ϥ�(�ȳB�z HiddenField�BTextBox �� DropDownList)
        /// <summary>
        /// �N Request ��ƹ����챱��W, For �ץX�ϥ�(�ȳB�z HiddenField�BTextBox �� DropDownList)
        /// </summary>
        protected void MapRequestToUIControl(Page page)
        {
            foreach (string key in Request.Form.Keys)
            {
                if (key.StartsWith("Q_") || key.StartsWith("M_"))
                {
                    if (this.FindControl(key) != null)
                        //== ��e����� ===
                        FormUtil.SetControlValue(this.FindControl(key), Request[key]);
                }
            }
        }
        #endregion

        #region MapDropDownListText �����U�Կﶵ����
        /// <summary>
        /// �����U�Կﶵ����
        /// </summary>
        /// <param name="ddl">�U�Ա��</param>
        /// <param name="value">�n��������</param>
        /// <returns>�^�ǹ�������, ��������^�ǭ�l��</returns>
        public string MapDropDownListText(DropDownList ddl, string value)
        {
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                if (ddl.Items[i].Value.Equals(value))
                {
                    string tmpStr = ddl.Items[i].Text;
                    if (tmpStr.IndexOf("-") != -1)
                        return tmpStr.Substring(tmpStr.IndexOf("-") + 1).Trim();
                    else
                        return tmpStr;
                }
            }

            return value;
        }
        #endregion

        #region MapRadioButtonListText �����ֿ����M�椤��
        /// <summary>
        /// �����ֿ����M�椤��
        /// </summary>
        /// <param name="ddl">�ֿ����M�檫��</param>
        /// <param name="value">�n��������</param>
        /// <returns>�^�ǹ�������, ��������^�ǭ�l��</returns>
        public string MapRadioButtonListText(RadioButtonList ddl, string value)
        {
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                if (ddl.Items[i].Value.Equals(value))
                {
                    string tmpStr = ddl.Items[i].Text;
                    if (tmpStr.IndexOf("-") != -1)
                        return tmpStr.Substring(tmpStr.IndexOf("-") + 1).Trim();
                    else
                        return tmpStr;
                }
            }

            return value;
        }
        #endregion

        #region PrepareUserControl �N���󪬺A�L�絹�ϥΪ̱���W
        /// <summary>
        /// �N���󪬺A�L�絹�ϥΪ̱���W
        /// </summary>
        /// <param name="userControl">�ϥΪ̱��</param>
        private void PrepareUserControl(UserControlBase userControl)
        {
            userControl.DBManager = this.DBManager;
            userControl.JScript = this.JScript;
            userControl.LogUtil = this.LogUtil;
        }
        #endregion

        #region GetControlHtml ���o�����X�� HTML
        /// <summary>
        /// ���o�����X�� HTML
        /// </summary>
        /// <param name="webControl">���</param>
        /// <returns></returns>
        protected string GetControlHtml(WebControl webControl)
        {
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter);

            webControl.RenderControl(htmlWriter);

            return stringWriter.ToString();
        }
        #endregion
        #endregion

        #region ���~�B�z
        #region AjaxError Ajax ���~�B�z����ϥ�
        /// <summary>
        /// Ajax ���~�B�z����ϥ�
        /// </summary>
        /// <returns>Ajax ���~�T��</returns>
        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public static string AjaxError()
        {
            return PageBase.AjaxErrLog;
        }
        #endregion
        #endregion

        #region �L����k
        #region GetFromCondition �̾ڬd�ߵe�����(TextBox ���A)���ͱ���
        /// <summary>
        /// �̾ڬd�ߵe�����(TextBox ���A)���ͱ���
        /// </summary>
        /// <param name="fieldName">�e�����W��</param>
        /// <returns>�d�߱���</returns>
        [Obsolete("This method is deprecated, use GetHashCode instead.")]
        protected string GetFromCondition(string fieldName)
        {
            if (string.IsNullOrEmpty(fieldName))
                throw new ArgumentException("���Ȥ��i�ť�", fieldName);

            string[] fields = fieldName.Split(',');
            StringBuilder condition = new StringBuilder();
            string fieldStr;
            string fieldValue;
            Control tmpControl;
            string validType = "";
            string validData = "";

            condition.Append("1 = 1 ");

            for (int i = 0; i < fields.Length; i++)
            {
                fieldStr = fields[i].Trim();
                tmpControl = this.Page.FindControl(fieldStr);

                if (tmpControl == null)
                    continue;

                fieldValue = FormUtil.GetControlValue(tmpControl).Trim();

                if (fieldValue != "")
                {
                    if (fields[i] != "ROWSTAMP")
                        fieldStr = fieldStr.Substring(2, fieldStr.Length - 2);

                    //=== ���o�ˮ֦r�� ===
                    validData = FormUtil.GetControlValidationGroupData(tmpControl);
                    //=== ���o�ˮֺ��� ===
                    validType = GetValidTypeForCondition(validData);

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

        [Obsolete]
        private string GetValidTypeForCondition(string validData)
        {
            string[] valids = new string[] { "EQ", "LIKE", "%LIKE", "LIKE%", "GT", "GE", "LT", "LE", "NE" };
            string[] valAry = validData.Split(',');
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

        #region �v������
        #region ProcessPermission �B�z�v���ʧ@
        /// <summary>
        /// �B�z�v���ʧ@
        /// </summary>
        private void ProcessPermission()
        {
            //�s�W�v��
            if (!ActionSecurity.HasFunctionPermission("0001"))
            {
                try { ((Button)this.FindControl("ADD_BTN1")).Enabled = false; }
                catch (System.Exception) { }
                try { ((HtmlInputButton)this.FindControl("ADD_BTN1")).Disabled = true; }
                catch (System.Exception) { }
                try { ((HiddenField)this.FindControl("Mode")).Value = "OTH"; }
                catch (System.Exception) { }
                try { ((HtmlGenericControl)this.FindControl("EditStatus")).InnerText = ""; }
                catch (System.Exception) { }
            }
            //�R���v��
            if (!ActionSecurity.HasFunctionPermission("0002"))
            {
                try { ((Button)this.FindControl("DEL_BTN1")).Enabled = false; }
                catch (System.Exception) { }
                try { ((Button)this.FindControl("DEL_BTN2")).Enabled = false; }
                catch (System.Exception) { }
            }
            //�ק��v��
            if (!ActionSecurity.HasFunctionPermission("0003"))
            {
                if (!ActionSecurity.HasFunctionPermission("0001"))
                {
                    try { ((Button)this.FindControl("SAVE_BTN1")).Enabled = false; }
                    catch (System.Exception) { }
                    try { ((HtmlInputButton)this.FindControl("SAVE_BTN1")).Disabled = false; }
                    catch (System.Exception) { }
                    try { ((Button)this.FindControl("SAVE_BTN2")).Enabled = false; }
                    catch (System.Exception) { }
                    try { ((HtmlInputButton)this.FindControl("SAVE_BTN2")).Disabled = false; }
                    catch (System.Exception) { }
                }
            }
            //�d���v��
            if (!ActionSecurity.HasFunctionPermission("0004"))
            {
                try { ((Button)this.FindControl("QUERY_BTN1")).Enabled = false; }
                catch (System.Exception) { }
            }

            //=== �B�z��Ū�涵(�d��) ===
            if (Session["0_READONLY_COLUMN"] != null)
            {
                string[] columnAry = Session["0_READONLY_COLUMN"].ToString().Split(',');
                for (int i = 0; i < columnAry.Length; i++)
                {
                    if (this.FindControl("Q_" + columnAry[i]) == null)
                        this.Logger.Append("==>" + columnAry[i] + "�e���W�õL�����(�v�����]�w Q)");
                    else
                        FormUtil.SetControlDisable(this.FindControl("Q_" + columnAry[i]), true);
                }
            }

            //=== �B�z������涵(�d��) ===
            if (Session["1_READONLY_COLUMN"] != null)
            {
                string[] columnAry = Session["1_READONLY_COLUMN"].ToString().Split(',');
                for (int i = 0; i < columnAry.Length; i++)
                {
                    if (this.FindControl("Q_" + columnAry[i]) == null)
                        this.Logger.Append("==>" + columnAry[i] + "�e���W�õL�����(�v�����]�w Q)");
                    else
                    {
                        FormUtil.SetAttributeData(this.FindControl("Q_" + columnAry[i]), "style", "display:none");
                        this.JScript.Script = "_i(0, 'Q_" + columnAry[i] + "').outerHTML = _i(0, 'Q_" + columnAry[i] + "').outerHTML + '&nbsp'";
                    }
                }
            }

            //=== �B�z��Ū�涵(�s��) ===
            if (Session["2_READONLY_COLUMN"] != null)
            {
                string[] columnAry = Session["2_READONLY_COLUMN"].ToString().Split(',');
                for (int i = 0; i < columnAry.Length; i++)
                {
                    if (this.FindControl("M_" + columnAry[i]) == null)
                        this.Logger.Append("==>" + columnAry[i] + "�e���W�õL�����(�v�����]�w M)");
                    else
                        FormUtil.SetControlDisable(this.FindControl("M_" + columnAry[i]), true);
                }
            }

            //=== �B�z������涵(�s��) ===
            if (Session["3_READONLY_COLUMN"] != null)
            {
                string[] columnAry = Session["3_READONLY_COLUMN"].ToString().Split(',');
                for (int i = 0; i < columnAry.Length; i++)
                {
                    if (this.FindControl("M_" + columnAry[i]) == null)
                        this.Logger.Append("==>" + columnAry[i] + "�e���W�õL�����(�v�����]�w M)");
                    else
                    {
                        FormUtil.SetAttributeData(this.FindControl("M_" + columnAry[i]), "style", "display:none");
                        this.JScript.Script = "_i(0, 'M_" + columnAry[i] + "').outerHTML = _i(0, 'M_" + columnAry[i] + "').outerHTML + '&nbsp'";
                    }
                }
            }
        }
        #endregion
        #endregion

        /// <summary>
        /// �զX�d�ߦr��
        /// </summary>
        /// <param name="outputBuff">�^�Ǫ��r��</param>
        /// <param name="oper">�����T</param>
        /// <param name="column">���W��</param>
        /// <param name="var">����</param>
        /// <param name="needComma">�O�_�ݭn�޸����</param>
        protected void ProcessQueryCondition(StringBuilder outputBuff, string oper, string column, string var, bool needComma)
        {
            DBUtil.ProcessQueryCondition(outputBuff, oper, column, var, needComma);
        }

        /// <summary>
        /// �զX�d�ߦr��
        /// </summary>
        /// <param name="outputBuff">�^�Ǫ��r��</param>
        /// <param name="oper">�����T</param>
        /// <param name="column">���W��</param>
        /// <param name="var">����</param>
        protected void ProcessQueryCondition(StringBuilder outputBuff, string oper, string column, string var)
        {
            this.ProcessQueryCondition(outputBuff, oper, column, var, true);
        }

        /// <summary>
        /// �զX�d�ߦr��
        /// </summary>
        /// <param name="outputBuff">�^�Ǫ��r��</param>
        /// <param name="oper">�����T Ex: BT,...</param>
        /// <param name="column">���W��</param>
        /// <param name="var1">����1</param>
        /// <param name="var2">����2</param>
        protected void ProcessQueryCondition(StringBuilder outputBuff, string oper, string column, string var1, string var2)
        {
            DBUtil.ProcessQueryCondition(outputBuff, oper, column, var1, var2);
        }

        /// <summary>
        /// �B�z Or ������
        /// </summary>
        /// <param name="outputBuff">Me.TmpCondition</param>
        /// <param name="currCondition">tmpBuff</param>
        protected void ProcessQueryOrCondition(StringBuilder outputBuff, StringBuilder currCondition)
        {
            DBUtil.ProcessQueryOrCondition(outputBuff, currCondition);
        }

        /// <summary>
        /// �B�z�d�߱���
        /// </summary>
        /// <param name="cond">�d�߱���</param>
        /// <returns>�d�߱���</returns>
        public string ProcessCondition(string cond)
        {
            return DBUtil.ProcessCondition(cond);
        }
        #endregion

        #region ���c
        #region GridEvent Grid �ƥ󵲺c
        /// <summary>
        /// Grid �ƥ󵲺c
        /// </summary>
        protected struct GridEvent
        {
            private Hashtable pPropertyMap;

            private Hashtable PropertyMap
            {
                get
                {
                    if (pPropertyMap == null)
                        pPropertyMap = new Hashtable();
                    return pPropertyMap;
                }
            }

            /// <summary>�O�_�i�������j�p</summary>
            public bool IsColumnReSize
            {
                get { return (bool)this.PropertyMap["IsColumnReSize"]; }
                set { this.PropertyMap["IsColumnReSize"] = value; }
            }

            /// <summary>�O�_�]�t���z��\��</summary>
            public bool IsColumnFilter
            {
                get { return (bool)this.PropertyMap["IsColumnFilter"]; }
                set { this.PropertyMap["IsColumnFilter"] = value; }
            }
        }
        #endregion
        #endregion
    }
}