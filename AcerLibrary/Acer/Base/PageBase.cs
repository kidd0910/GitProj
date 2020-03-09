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
    /// Control 繼承元件, 初使化 UI 元件
    /// </summary>
    /// <remarks></remarks>
    public class PageBase : Page
    {        
        private ArrayList ddUserControls = new ArrayList();

        #region 屬性
        private Hashtable pPropertyMap = new Hashtable();                

        #region CommonUIMap 取得 CommonUI屬性
        /// <summary>取得屬性</summary>
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

        #region PropertyMap 取得屬性
        /// <summary>取得屬性</summary>
        protected Hashtable PropertyMap
        {
            get { return (Hashtable)this.pPropertyMap; }
        }
        #endregion

        private static object lockObj = new object();

        #region AjaxErrLog 設定 AjaxErrLog錯誤訊息
        private static Hashtable errMap = new Hashtable();
        /// <summary>設定 AjaxErrLog錯誤訊息</summary>
        public static string AjaxErrLog
        {
            get
            {
                //=== 抓出錯誤訊息 ===
                Hashtable errMap = MultiProcess.ChoiceHashtable(MultiProcess.GetRealGlobalValue("AJAX_ERROR"));
                string errLog = (string)errMap["AjaxErr" + FormUtil.Session.SessionID];
                //=== 移除該訊息 ===
                errMap.Remove("AjaxErr" + FormUtil.Session.SessionID);
                //=== 回塞訊息 ===
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

        #region DBUtil 設定 DBUtil 物件
        /// <summary>DBUtil 設定 DBUtil 物件</summary>
        protected DBUtil DBUtil
        {
            get { return (DBUtil)this.PropertyMap["DBUtil"]; }
            set { this.PropertyMap["DBUtil"] = value; }
        }
        #endregion

        #region LangUtil 設定 LangUtil 物件
        /// <summary>LangUtil 設定 LangUtil 物件</summary>
        protected LangUtil LangUtil
        {
            get { return (LangUtil)this.PropertyMap["LangUtil"]; }
            set { this.PropertyMap["LangUtil"] = value; }
        }
        #endregion

        #region LogUtil 設定 LogUtil 物件
        /// <summary>LogUtil 設定 LogUtil 物件</summary>
        public LogUtil LogUtil
        {
            get { return (LogUtil)this.PropertyMap["LogUtil"]; }
            set { this.PropertyMap["LogUtil"] = value; }
        }
        #endregion

        #region DBManager 設定 DBManager 物件
        /// <summary>DBManager 設定 DBManager 物件</summary>
        public DBManager DBManager
        {
            get { return this.DBUtil.DBManager; }
        }
        #endregion

        #region JScript 設定 JScript 物件
        /// <summary>JScript 設定 JScript 物件</summary>
        protected JScript JScript
        {
            get { return (JScript)this.PropertyMap["JScript"]; }
            set { this.PropertyMap["JScript"] = value; }
        }
        #endregion

        #region Exception 設定 Exception 物件
        /// <summary>Exception 設定 Exception 物件</summary>
        protected Exception Exception
        {
            get { return (Exception)this.PropertyMap["Exception"]; }
            set { this.PropertyMap["Exception"] = value; }
        }
        #endregion

        #region ScriptManager 設定 ScriptManager 物件
        /// <summary>ScriptManager 設定 ScriptManager 物件</summary>
        protected ScriptManager ScriptManager
        {
            get { return (ScriptManager)this.PropertyMap["ScriptManager"]; }
            set { this.PropertyMap["ScriptManager"] = value; }
        }
        #endregion

        #region Logger 讀取 Log 物件
        /// <summary>Logger 讀取 Log 物件</summary>
        protected MyLogger Logger
        {
            get { return this.LogUtil.Logger; }
        }
        #endregion

        #region PageRangeSize 頁面區間大小
        /// <summary>PageRangeSize 頁面區間大小</summary>
        protected int PageRangeSize
        {
            get { return (int)this.PropertyMap["PageRangeSize"]; }
            set { this.PropertyMap["PageRangeSize"] = value; }
        }
        #endregion

        #region PageNo  設定目前頁次
        /// <summary>設定目前頁次</summary>
        public int PageNo
        {
            get { return (int)this.PropertyMap["PageNo"]; }
            set { this.PropertyMap["PageNo"] = value; }
        }
        #endregion

        #region PageSize  每頁筆數
        public const int defaultPageSize = 20;
        /// <summary>每頁筆數</summary>
        public int PageSize
        {
            get { return (int)this.PropertyMap["PageSize"]; }
            set { this.PropertyMap["PageSize"] = value; }
        }
        #endregion


        #region TotalRowCount 總筆數
        /// <summary>TotalRowCount 總筆數</summary>
        protected int TotalRowCount
        {
            get { return (int)this.PropertyMap["TotalRowCount"]; }
            set { this.PropertyMap["TotalRowCount"] = value; }
        }
        #endregion

        #region IsListShow 是否頁面一載入即顯示
        /// <summary>IsListShow 是否頁面一載入即顯示</summary>
        public bool IsListShow
        {
            get { return (bool)this.PropertyMap["IsListShow"]; }
            set { this.PropertyMap["IsListShow"] = value; }
        }
        #endregion

        #region IsAjax 是否為 Ajax 傳送方式
        /// <summary>IsAjax 是否為 Ajax 傳送方式</summary>
        private bool IsAjax
        {
            get { return (bool)this.PropertyMap["IsAjax"]; }
            set { this.PropertyMap["IsAjax"] = value; }
        }
        #endregion

        #region IsLog 是否紀錄 Log
        /// <summary>IsLog 是否紀錄 Lo</summary>
        protected bool IsLog
        {
            get { return (bool)this.PropertyMap["IsLog"]; }
            set { this.PropertyMap["IsLog"] = value; }
        }
        #endregion

        #region IsDoIOLog 是否紀錄 Log
        /// <summary>IsDoIOLog 是否紀錄 Lo</summary>
        protected bool IsDoIOLog
        {
            get { return (bool)this.PropertyMap["IsDoIOLog"]; }
            set { this.PropertyMap["IsDoIOLog"] = value; }
        }
        #endregion

        #region HasForm 是否包含 Form 物件
        /// <summary>HasForm 是否包含 Form 物件</summary>
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

        #region HasColumnFilter 是否包含欄位篩選功能
        /// <summary>HasColumnFilter 是否包含欄位篩選功能</summary>
        protected bool HasColumnFilter
        {
            get { return (bool)this.PropertyMap["HasColumnFilter"]; }
            set { this.PropertyMap["HasColumnFilter"] = value; }
        }
        #endregion

        #region NeedConnectDB 是否需要連線資料庫
        /// <summary>NeedConnectDB 是否需要連線資料庫</summary>
        protected bool NeedConnectDB
        {
            get { return (bool)this.PropertyMap["NeedConnectDB"]; }
            set { this.PropertyMap["NeedConnectDB"] = value; }
        }
        #endregion

        #region NeedCheckSession 是否需要檢查登入
        /// <summary>NeedCheckSession 是否需要檢查登入</summary>
        protected bool NeedCheckSession
        {
            get { return (bool)this.PropertyMap["NeedCheckSession"]; }
            set { this.PropertyMap["NeedCheckSession"] = value; }
        }
        #endregion

        #region NeedRollBack 是否需要退回交易
        /// <summary>NeedRollBack 是否需要退回交易</summary>
        private bool NeedRollBack
        {
            get { return (bool)this.PropertyMap["NeedRollBack"]; }
            set { this.PropertyMap["NeedRollBack"] = value; }
        }
        #endregion

        #region HasError 是否包含錯誤
        /// <summary>HasError 是否包含錯誤</summary>
        private bool HasError
        {
            get { return (bool)this.PropertyMap["HasError"]; }
            set { this.PropertyMap["HasError"] = value; }
        }
        #endregion

        #region RollBackPage RollBack page 交易資料
        /// <summary>RollBackPage RollBack page 交易資料</summary>
        private bool RollBackPage
        {
            get { return (bool)this.PropertyMap["RollBackPage"]; }
            set { this.PropertyMap["RollBackPage"] = value; }
        }
        #endregion

        #region PageID For 多國語系使用的 PageID
        /// <summary>PageID For 多國語系使用的 PageID</summary>
        protected string PageID
        {
            get { return (string)this.PropertyMap["PageID"]; }
            set { this.PropertyMap["PageID"] = value; }
        }
        #endregion

        #region HasLoad 是否載入完成
        /// <summary>HasLoad 是否載入完成Form 物件</summary>
        private bool HasLoad
        {
            get { return (bool)this.PropertyMap["HasLoad"]; }
            set { this.PropertyMap["HasLoad"] = value; }
        }
        #endregion

        #region DDColumn 取得 DDColumn
        /// <summary>取得 DDColumn</summary>
        public Hashtable DDColumn
        {
            get
            {
                if (this.PropertyMap["DDColumn"] == null)
                    this.PropertyMap["DDColumn"] = (Hashtable)MultiProcess.GetCrossSiteValue("COLUMNDD"); ;

                //=== 取不到時初始化 ===
                if (this.PropertyMap["DDColumn"] == null)
                    DataDictionaryUtil.InitDataDictionary(this.DBManager, this.LogUtil);

                //=== 再取不到回傳錯誤 ===
                this.PropertyMap["DDColumn"] = (Hashtable)MultiProcess.GetCrossSiteValue("COLUMNDD");
                if (this.PropertyMap["DDColumn"] == null)
                    throw new Exception("資料字典資料載入有誤, 請檢查 !!");

                return (Hashtable)this.PropertyMap["DDColumn"];
            }
        }
        #endregion

        #region PageColumn 取得 PageColumn
        /// <summary>取得 PageColumn</summary>
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

        #region ColumnField 取得 ColumnField
        /// <summary>取得 ColumnField</summary>
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

        #region SessionMap 取得 SessionMap
        /// <summary>取得 DDColumn</summary>
        public Hashtable SessionMap
        {
            get
            {
                if (FormUtil.Cache.Get("SessionMap") == null)
                {
                    //=== 對照 Session ===
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

        #region 事件
        #region 頁面載入事件
        #region OnPreInit
        /// <summary>
        /// 頁面載入事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreInit(EventArgs e)
        {
            //=== 清除 Cache ===
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

            //=== 設定 Session 最後存取時間 ===
            Session["LAST_SESSION_TIME"] = System.DateTime.Now;

            //=== 預設處理 ===
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

            //=== 起始物件 ===
            this.LogUtil = new LogUtil("");
            this.DBUtil = new DBUtil(this.LogUtil);
            this.LangUtil = new LangUtil(this.Logger, this.DBManager);

            this.LogUtil.TraceStart(MethodBase.GetCurrentMethod().Name);

            this.JScript = new JScript(this.Logger);

            if (!this.IsPostBack)
            {
                //=== 初始化查詢 Flag ===
                this.ViewState["Has_Query"] = "N";
            }

            this.LogUtil.TraceEnd(MethodBase.GetCurrentMethod().Name);

            base.OnPreInit(e);
        }
        #endregion

        #region OnLoad
        /// <summary>
        /// 頁面載入事件
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
                //                                                        throw new Exception(key + " 原始資料: " + value + ", 現在資料: " + FormUtil.GetControlValue(this.FindControl(key)));
                //                                                }
                //                                        }
                //                                }
                //this.Logger.Append("666======");
            }

            //=== 設定是否 Log ===
            this.LogUtil.IsLog = this.IsLog;
            this.Logger.IsLog = this.IsLog;
            try
            {
                this.LogUtil.TraceStart(MethodBase.GetCurrentMethod().Name);

                this.HasForm = FormUtil.CheckControlByType(this, "System.Web.UI.HtmlControls.HtmlForm");

                if (this.HasForm)
                {
                    //=== 判斷是否 Ajax ===
                    this.ScriptManager = (ScriptManager)FormUtil.FindControlByType(this, "ScriptManager");
                    this.IsAjax = (bool)(this.ScriptManager != null);
                }

                if (this.NeedCheckSession)
                {
                    //=== 判斷 Session 是存還存在(正常登入), 不存在踢出去 ===
                    if (!FormUtil.HasSession())
                    {
                        //=== 剔除統計資訊 ===
                        Hashtable onLineUser = MultiProcess.ChoiceHashtable(MultiProcess.GetProcessValue("ONLINE_USER"));
                        Hashtable onLineList = MultiProcess.ChoiceHashtable(MultiProcess.GetProcessValue("ONLINE_LIST"));
                        onLineUser.Remove("ONLINE_" + FormUtil.Session.SessionID);
                        onLineList.Remove("ONLIST_" + FormUtil.Session.SessionID);
                        MultiProcess.SetProcessValue("ONLINE_USER", onLineUser);
                        MultiProcess.SetProcessValue("ONLINE_LIST", onLineList);

                        //=== 當為 Ajax 且 Timeout 時, 要退回交易 ===
                        if (this.IsAjax)
                        {
                            throw new SessionTimeoutException("Timeout");
                        }
                        else
                        {
                            //System.Web.Security.FormsAuthentication.SignOut();
                            Response.Clear();
                            Response.Write("<script>alert('使用時間逾時,系統已將您自動登出,請再重新登入使用本系統!!');top.location.href='" + Application["vr"] + "logout.aspx';</script>");
                            Response.End();
                            return;
                        }
                    }
                }

                //=== 初始化使用者控制項 ===
                ArrayList userControls = new ArrayList();
                FormUtil.FindUserControls(this, userControls);
                for (int i = 0; i < userControls.Count; i++)
                {
                    this.PrepareUserControl((UserControlBase)userControls[i]);
                }

                //=== 抓取符合命名的控制項 Ex: Q_, M_, X_... ===
                FormUtil.FindUIDDControls(this, this.ddUserControls);

                //=== 設定語系 ===
                if (Session["Language"] == null)
                    Session["Language"] = "ZH-TW";

                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Session["Language"].ToString());
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Session["Language"].ToString());

                if (!this.IsPostBack)
                {

                    //=== 多國語系 Js 使用 ===
                    if (!Session["Language"].ToString().Equals("ZH-TW"))
                        this.JScript.Script = "try{doImport ('MessageContent_" + Session["Language"].ToString().Replace("-", "_") + ".js');}catch(ex){}";

                    this.JScript.Script = "var lang	=	'" + Session["Language"].ToString().Replace("-", "_") + "'";
                    this.JScript.Script = "try{if (getTop().columnFilterRecord == null)getTop().columnFilterRecord={};}catch(ex){}";

                    //=== 初始化資料字典欄位設定 ===
                    BindDDProperty();

                    //=== 初始化資料欄位設定 ===
                    BindColumnFieldProperty();

                    //=== 初始化多國語系資料 ===
                    BindMLProperty(this);

                    //=== 更改按鈕名稱 ===
                    string langType = Thread.CurrentThread.CurrentUICulture.ToString().ToUpper();

                    //if (APConfig.GetProperty("DATA_PROJECT").Equals("海洋大學") && langType.Equals("ZH-TW") || APConfig.GetProperty("DATA_PROJECT").Contains("國防大學") || APConfig.GetProperty("DATA_PROJECT").Contains("東海大學"))
                    //{
                    //    try{((HtmlInputButton)this.FindControl("QCLEAR_BTN1")).Value	=	"還原";}catch(Exception){}
                    //    try{((HtmlInputButton)this.FindControl("QCLEAR_BTN2")).Value	=	"還原";}catch(Exception){}
                    //    try{((HtmlInputButton)this.FindControl("MCLEAR_BTN1")).Value	=	"還原";}catch(Exception){}
                    //    try{((HtmlInputButton)this.FindControl("MCLEAR_BTN2")).Value	=	"還原";}catch(Exception){}

                    //    try{((Button)this.FindControl("QCLEAR_BTN1")).Text	=	"還原";}catch(Exception){}
                    //    try{((Button)this.FindControl("QCLEAR_BTN2")).Text	=	"還原";}catch(Exception){}
                    //    try{((Button)this.FindControl("MCLEAR_BTN1")).Text	=	"還原";}catch(Exception){}
                    //    try{((Button)this.FindControl("MCLEAR_BTN2")).Text	=	"還原";}catch(Exception){}
                    //}

                    //=== 判斷功能權限 ===
                    ProcessPermission();
                }

                //=== nono 2009/03/25 add 避免 keepSession 或是需常重整的程式不斷抓取 ===
                if (this.HasColumnFilter)
                {
                    //=== 初始化欄位篩選設定 ===
                    ColumnFilterInit();
                }

                //=== 處理 SQLInjection 置換動作 ===
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
            //=== 設定是否 Log ===
            this.LogUtil.IsLog = this.IsLog;
            this.Logger.IsLog = this.IsLog;
            try
            {
                this.LogUtil.TraceStart(MethodBase.GetCurrentMethod().Name);

                this.HasForm = FormUtil.CheckControlByType(this, "System.Web.UI.HtmlControls.HtmlForm");

                if (this.HasForm)
                {
                    //=== 判斷是否 Ajax ===
                    this.ScriptManager = (ScriptManager)FormUtil.FindControlByType(this, "ScriptManager");
                    this.IsAjax = (bool)(this.ScriptManager != null);
                }

                if (this.NeedCheckSession)
                {
                    //=== 判斷 Session 是存還存在(正常登入), 不存在踢出去 ===
                    if (!FormUtil.HasSession())
                    {
                        //=== 剔除統計資訊 ===
                        Hashtable onLineUser = MultiProcess.ChoiceHashtable(MultiProcess.GetProcessValue("ONLINE_USER"));
                        Hashtable onLineList = MultiProcess.ChoiceHashtable(MultiProcess.GetProcessValue("ONLINE_LIST"));
                        onLineUser.Remove("ONLINE_" + FormUtil.Session.SessionID);
                        onLineList.Remove("ONLIST_" + FormUtil.Session.SessionID);
                        MultiProcess.SetProcessValue("ONLINE_USER", onLineUser);
                        MultiProcess.SetProcessValue("ONLINE_LIST", onLineList);

                        //=== 當為 Ajax 且 Timeout 時, 要退回交易 ===
                        if (this.IsAjax)
                        {
                            throw new SessionTimeoutException("Timeout");
                        }
                        else
                        {
                            //System.Web.Security.FormsAuthentication.SignOut();
                            Response.Clear();
                            Response.Write("<script>alert('使用時間逾時,系統已將您自動登出,請再重新登入使用本系統!!');top.location.href='" + Application["vr"] + "logout.aspx';</script>");
                            Response.End();
                            return;
                        }
                    }
                }

                //=== 初始化使用者控制項 ===
                ArrayList userControls = new ArrayList();
                FormUtil.FindUserControls(this, userControls);
                for (int i = 0; i < userControls.Count; i++)
                {
                    this.PrepareUserControl((UserControlBase)userControls[i]);
                }

                //=== 抓取符合命名的控制項 Ex: Q_, M_, X_... ===
                FormUtil.FindUIDDControls(this, this.ddUserControls);

                //=== 設定語系 ===
                if (Session["Language"] == null)
                    Session["Language"] = "ZH-TW";

                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Session["Language"].ToString());
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Session["Language"].ToString());

                //if (!this.IsPostBack)
                //{

                    //=== 多國語系 Js 使用 ===
                    //if (!Session["Language"].ToString().Equals("ZH-TW"))
                    //    this.JScript.Script = "try{doImport ('MessageContent_" + Session["Language"].ToString().Replace("-", "_") + ".js');}catch(ex){}";

                    //this.JScript.Script = "var lang	=	'" + Session["Language"].ToString().Replace("-", "_") + "'";
                    //this.JScript.Script = "try{if (getTop().columnFilterRecord == null)getTop().columnFilterRecord={};}catch(ex){}";

                    //=== 初始化資料字典欄位設定 ===
                    //BindDDProperty();

                    //=== 初始化資料欄位設定 ===
                    //BindColumnFieldProperty();

                    //=== 初始化多國語系資料 ===
                    //BindMLProperty(this);

                    //=== 更改按鈕名稱 ===
                    //string langType = Thread.CurrentThread.CurrentUICulture.ToString().ToUpper();

                  
                    //=== 判斷功能權限 ===
                    ProcessPermission();
                //}

                //=== nono 2009/03/25 add 避免 keepSession 或是需常重整的程式不斷抓取 ===
                if (this.HasColumnFilter)
                {
                    //=== 初始化欄位篩選設定 ===
                    ColumnFilterInit();
                }

                //=== 處理 SQLInjection 置換動作 ===
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
        /// 頁面載入完成事件
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

                //=== 初始化 Grid 按下顏色 ===
                //Modify By Brian 2013/08/22 $(_d()).ready(Grid.setGridEvent); 移到 /UserControl/PageInitControl.ascx BindInitScript()處理
                this.JScript.Script = "try{$(_d()).ready(iniGridClickColor);$(_d()).ready(SortTable.sortables_init);}catch(ex){}";

                //=== 處理 Grid Scroll 動作, 按鈕變色事件 ===
                this.JScript.Script = "try{setButtonEvent();reSize();}catch(ex){}";

                //=== 切換 Label ===
                this.JScript.Script = "try{switchLabel();}catch(ex){}";

                //=== 宣告專案別 ===
                this.JScript.Script = "var	proj	=	'" + APConfig.GetProperty("DATA_PROJECT") + "'";

                //=== 欄物篩選 ===
                this.JScript.Script = "try{$(_d()).ready(function(){try{gridOuterHTML=_('DataGrid').outerHTML;setColumnHide()}catch(ex){}})}catch(ex){}";

                //=== 處理 SQLInjection 置換動作, 及金額型態資料處理 ===
                FormUtil.ProcessSQLInjection(this, false);

                if (!this.IsPostBack)
                {
                    //=== 初始化資料欄位設定 ===
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

        #region OnPreRender 頁面載入完
        /// <summary>
        /// 頁面載入完事件
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

            //=== 交易 ===
            if (this.NeedConnectDB)
            {
                if (this.HasError || this.RollBackPage || this.NeedRollBack)
                    this.DBManager.Rollback();
                else
                    this.DBManager.Commit();
            }

            //=== 關閉連線 ===
            this.DBUtil.CloseDBManager();

            //=== 執行 JavaScript ===
            this.JScript.IniFormColor();
            //=== 浮水印 ===
            this.JScript.SetWaterMark();

            //=== 設定按鈕權限 ===
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

        #region OnError 錯誤處理
        /// <summary>
        /// 錯誤處理事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnError(EventArgs e)
        {
            Exception pageEx = Server.GetLastError();

            if (pageEx is System.Web.HttpRequestValidationException)
            {
                Response.Clear();
                Response.Write("<script>alert('具有潛在危險的值已從用戶端偵測到!!')</script>");
                Response.End();
            }
            Server.ClearError();

            if (this.LogUtil == null)
                return;

            this.LogUtil.TraceStart(MethodBase.GetCurrentMethod().Name);

            //=== 設定錯誤 ===
            this.Logger.SetLogLevel(MyLogger.Error);
            this.Logger.Append(ErrUtil.ErrToStr(pageEx).Replace("<", "&lt;") + "};");

            //=== 透過 Ajax 呼叫處理 ===
            if (this.IsAjax)
            {
                if (pageEx is Acer.Err.SessionTimeoutException)
                {
                    this.JScript.Script = "alert('" + this.LangUtil.LangMap("使用時間逾時,系統已將您自動登出,請再重新登入使用本系統!!") + "');top.location.href='" + Application["vr"] + "logout.aspx';";
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
            //=== 處理結束動作 ===
            this.OnPreRender(null);

            base.OnError(e);
        }
        private static object lockObj1 = new object();
        #endregion
        #endregion

        #region 方法
        #region 頁籤相關
        #region Tab_Click 切換頁籤
        /// <summary>
        /// 切換頁籤 Tab_Click
        /// </summary>
        protected void Tab_Click(Object sender, System.EventArgs e)
        {
            int tabIndex = 1;
            int currIndex = 1;
            while (this.FindControl("TABLNK" + tabIndex) != null)
            {
                if (this.FindControl("TAB_CONTENT" + tabIndex) == null)
                    this.Logger.Append("==> TAB_CONTENT" + tabIndex + " 物件未定義");

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

        #region InitTab 初始化頁籤
        /// <summary>
        /// InitTab 初始化頁籤
        /// </summary>
        protected void InitTab(int showIndex)
        {
            int tabIndex = 1;
            while (this.FindControl("TABLNK" + tabIndex) != null)
            {
                if (this.FindControl("TAB_CONTENT" + tabIndex) == null)
                    this.Logger.Append("==> TAB_CONTENT" + tabIndex + " 物件未定義");

                ((LinkButton)this.FindControl("TABLNK" + tabIndex)).CssClass = "tab_non_select";
                ((HtmlGenericControl)this.FindControl("TAB_CONTENT" + tabIndex)).Attributes["style"] = "display:none";

                tabIndex++;
            }

            ((LinkButton)this.FindControl("TABLNK" + showIndex)).CssClass = "tab_select";
            ((HtmlGenericControl)this.FindControl("TAB_CONTENT" + showIndex)).Attributes["style"] = "display:";
        }
        #endregion
        #endregion

        #region 資料庫存取
        #region GetDBAccess 取得 DBAccess 物件
        /// <summary>
        /// 取得 DBAccess 物件
        /// </summary>
        /// <param name="connName">資料庫連線設定</param>
        /// <returns>DBAccess 物件</returns>
        public DBAccess GetDBAccess(string connName)
        {
            DbConnection conn = this.DBManager.GetIConnection(connName);
            return this.DBManager.GetDBAccess(conn);
        }
        #endregion

        #region GetDtBySql 依據 SQL 取得 DataTable
        /// <summary>
        /// 依據 SQL 取得 DataTable
        /// </summary>
        /// <param name="connName">資料庫連線設定</param>
        /// <param name="sql">SQL 語法</param>
        /// <returns>DataTable 物件</returns>
        public DataTable GetDtBySql(string connName, string sql)
        {
            EntityBase ent = new EntityBase(this.DBManager, this.LogUtil);
            ent.ConnName = connName;
            return ent.QueryBySql(sql);
        }
        #endregion

        #region GetDtBySql 依據 SQL 取得 DataTable
        /// <summary>
        /// 依據 SQL 取得 DataTable
        /// </summary>
        /// <param name="connName">資料庫連線設定</param>
        /// <param name="sql">SQL 語法</param>
        /// <param name="pageNo">頁次</param>
        /// <param name="pageSize">每頁尺寸</param>
        /// <returns>DataTable 物件</returns>
        public DataTable GetDtBySql(string connName, string sql, int pageNo, int pageSize)
        {
            EntityBase ent = new EntityBase(this.DBManager, this.LogUtil);
            ent.ConnName = connName;
            DataTable dt = ent.QueryBySql(sql, pageNo, pageSize);
            this.TotalRowCount = ent.TotalRowCount();

            return dt;
        }
        #endregion

        #region RollBackPageTransaction 處理頁面交易資料退回動作
        /// <summary>
        /// 處理頁面交易資料退回動作
        /// </summary>
        protected void RollBackPageTransaction()
        {
            this.RollBackPage = true;
        }
        #endregion
        #endregion

        #region 處理分頁
        #region 取得分頁資訊
        /// <summary>
        /// 取得 PageControl 的 PageNo 值
        /// <param name="defaultPageControlId">預設控制項名稱</param>
        /// </summary>
        protected string PageControlPageNo(string defaultPageControlId)
        {
            if (this.HiddenFieldX("ActivePageControl") == null)
                this.Logger.Append("必須設定 HiddenField 控制項 ID [ActivePageControl]");

            if (!String.IsNullOrEmpty(this.HiddenFieldX("ActivePageControl").Value))
                return ((TextBox)this.UserControlX(this.HiddenFieldX("ActivePageControl").Value).FindControl("PageNo")).Text;
            else
                return ((TextBox)this.UserControlX(defaultPageControlId).FindControl("PageNo")).Text;
        }

        /// <summary>
        /// 取得 ScrollSize 值
        /// <param name="defaultPageControlId">預設控制項名稱</param>
        /// </summary>
        protected string PageControlPageSize(string defaultPageControlId)
        {
            if (this.HiddenFieldX("ActivePageControl") == null)
                this.Logger.Append("控制項未設定 --> ActivePageControl");

            if (!String.IsNullOrEmpty(this.HiddenFieldX("ActivePageControl").Value))
            {
                //若PageSize輸入框為空值時的處理方式
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

        #region 處理 Grid 相關方法
        #region 檢查是否查詢過
        /// <summary>
        /// 檢查是否查詢過, For 新增後是否重 Bind 判斷使用
        /// </summary>
        /// <param name="gridView">GridView 控制項</param>
        /// <returns>是否查詢過</returns>
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

        #region AllCellResize 處理 DataGrid 所有表頭可以改變大小動作
        /// <summary>
        /// 處理 DataGrid 所有表頭可以改變大小動作
        /// </summary>
        /// <param name="gridView">gridView 控制項</param>
        private void AllCellResize(GridView gridView)
        {
            if (gridView == null)
                throw new ArgumentException("傳入參數不可為空白", "gridView");

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
                    //Modify By Brian 2014.04.14 PageID 改成 PAGE
                    tmpML = cell.Text.Replace("CL_", "COMMON.").Replace("CB_", "COMMON.").Replace("PL_", "PAGE.").Replace("PB_", "PAGE.").Replace("PC_", this.PageID + ".");

                    tmpData = this.LangUtil.LangMap(tmpML);
                    if (!string.IsNullOrEmpty(tmpData))
                        cell.Text = tmpData;
                }
                cell.Attributes["resize"] = "on";
            }
        }
        #endregion

        #region SetupGridEvent 設定 Gird 事件
        /// <summary>
        /// 設定 Gird 事件
        /// </summary>
        /// <param name="grid">Gird 物件</param>
        /// <param name="gridEvent">Gird 事件結構</param>
        protected void SetupGridEvent(GridView grid, GridEvent gridEvent)
        {
            if (grid == null)
                throw new ArgumentException("傳入值不可為空", "grid");

            this.ViewState["Has_Query"] = "Y";

            //=== 設定表頭可改變大小 ===
            if (gridEvent.IsColumnReSize)
                this.AllCellResize(grid);

            //=== 顯示隱藏欄位(欄位篩選) ===
            //2009/03/25 nono 拿掉無效處理
            //if (gridEvent.IsColumnFilter)
            //{
            //	this.JScript.Script	=	"$(_d()).ready(function(){gridOuterHTML=_('DataGrid').outerHTML;setColumnHide()})";
            //}

            //=== 抓取符合命名的控制項 Ex: Q_, M_, X_... ===
            this.ddUserControls = new ArrayList();
            FormUtil.FindUIDDControls(grid, this.ddUserControls);

            //=== 初始化資料字典欄位設定 ===
            BindDDProperty();

            //=== 初始化資料欄位設定 ===
            BindColumnFieldProperty();

            //=== 保留初始值動作 ===
            Control tmpControl;
            string controlValue;
            for (int i = 0; i < this.ddUserControls.Count; i++)
            {
                tmpControl = (Control)this.ddUserControls[i];
                controlValue = FormUtil.GetControlValue(tmpControl);

                controlValue = controlValue.Replace("'", "''");
                //=== 金額處理置換動作 ===
                if ((FormUtil.GetAttributeData(tmpControl, "DD") != null &&
                    FormUtil.GetAttributeData(tmpControl, "DD").Equals("A")) && !(controlValue.Equals("")))
                    controlValue = controlValue.Replace(",", "");
                //=== 時間處理置換動作 ===
                if ((FormUtil.GetAttributeData(tmpControl, "DD") != null &&
                    FormUtil.GetAttributeData(tmpControl, "DD").Equals("T")) && !(controlValue.Equals("")))
                    controlValue = controlValue.Replace(":", "");

                FormUtil.SetAttributeData(tmpControl, "RAW_DATA", controlValue);
            }
        }
        #endregion

        #region CheckHasChange 判斷是否需要處理
        /// <summary>
        /// 判斷是否需要處理
        /// </summary>
        /// <param name="row">該筆列物件</param>
        /// <returns>是/否</returns>
        protected bool CheckHasChange(GridViewRow row)
        {
            //=== 抓取符合命名的控制項 Ex: Q_, M_, X_... ===
            this.ddUserControls = new ArrayList();
            FormUtil.FindUIDDControls(row, this.ddUserControls);

            Control tmpControl;
            for (int i = 0; i < this.ddUserControls.Count; i++)
            {
                tmpControl = (Control)this.ddUserControls[i];

                //=== 當原始值跟現在的值不一樣時回傳 true ===
                if (!FormUtil.GetAttributeData(tmpControl, "RAW_DATA").Equals(FormUtil.GetControlValue(tmpControl)))
                    return true;
            }
            return false;
        }
        #endregion

        #region GetKeyValueByGridCheckBox 依據 Grid CheckBox 取得鍵值  KEY|VALUE$KEY|VALUE"
        /// <summary>
        /// 依據 Grid CheckBox 取得鍵值"
        /// </summary>
        /// <param name="dataGrid">GridView 物件</param>
        /// <param name="checkBoxName">核選物件 ID</param>
        /// <returns>鍵值</returns>
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

        #region GetKeyValueByGridRow 依據 Grid 某行取得鍵值 KEY|VALUE"
        /// <summary>
        /// 依據 Grid 某行取得鍵值
        /// </summary>
        /// <param name="dataGrid">GridView 物件</param>
        /// <param name="rowIndex">行索引</param>
        /// <returns>鍵值</returns>
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

        #region PrepareRowDataBoundEvent 處理每行 Grid 事件"
        /// <summary>
        /// PrepareRowDataBoundEvent 處理每行 Grid 事件, 
        /// 預設處理功能 核選/編/詳/刪 權限機制, 
        /// 若欲覆寫功能於下方再行覆寫即可
        /// </summary>
        /// <param name="dataGrid">GridView 物件</param>
        /// <param name="row">行物件</param>
        protected void PrepareRowDataBoundEvent(GridView dataGrid, GridViewRow row)
        {
            string keyValue = this.GetKeyValueByGridRow(dataGrid, row.RowIndex);

            //=== 設定 DataGrid 的 CheckBox，Value 要組合 Primary Key ===
            HtmlInputCheckBox tmpChkBox = (HtmlInputCheckBox)row.FindControl("chkBox");
            if (tmpChkBox != null)
                tmpChkBox.Value = keyValue;

            //=== 設定編輯 ===
            Label tmpLabel;

            //=== 設定刪除 ===
            LinkButton tmpLink = (LinkButton)row.FindControl("del");
            if (tmpLink != null)
            {

                try
                {
                    if (!string.IsNullOrEmpty(APConfig.GetProperty("GRIDVIEW_DEL_IMG")))
                        tmpLink.Text = "<img src='" + APConfig.GetProperty("GRIDVIEW_DEL_IMG") + "' style='border:0; vertical-align:bottom' />";
                }
                catch { }

                //=== 權限控制(刪除) ===
                if (!ActionSecurity.HasFunctionPermission("0002"))
                    ((TableCell)tmpLink.Parent).Enabled = false;
                else
                {
                    //=== 點選刪除時，出現 confirm 訊息 ===
                    tmpLink.Attributes.Add("KEY", keyValue);
                    tmpLink.OnClientClick = "return doDelete();";
                }
            }

            //=== 設定多國語系 ===
            BindMLProperty(row);

            tmpLabel = (Label)row.FindControl("edit");
            if (tmpLabel != null)
            {
                tmpLabel.Text = "<a href='#this'>" + LangUtil.LangMap("COMMON.編") + "</a>";

                try
                {
                    if (!string.IsNullOrEmpty(APConfig.GetProperty("GRIDVIEW_EDIT_IMG")))
                        tmpLabel.Text = "<a href='#this'><img src='" + APConfig.GetProperty("GRIDVIEW_EDIT_IMG") + "' style='border:0; vertical-align:bottom' /></a>";
                }
                catch { }

                //=== 權限控制(編輯) ===
                if (!ActionSecurity.HasFunctionPermission("0003"))
                    ((TableCell)tmpLabel.Parent).Enabled = false;
                else
                {
                    ((TableCell)tmpLabel.Parent).Attributes.Add("onclick", "doEdit1_2(this, '" + keyValue + "', 'Mod')");
                    row.Attributes.Add("KEY", keyValue);
                }
            }

            //=== 設定詳 ===
            tmpLabel = (Label)row.FindControl("detail");
            if (tmpLabel != null)
            {
                tmpLabel.Text = "<a href='#this'>" + LangUtil.LangMap("COMMON.詳") + "</a>";

                try
                {
                    if (!string.IsNullOrEmpty(APConfig.GetProperty("GRIDVIEW_DETAIL_IMG")))
                        tmpLabel.Text = "<a href='#this'><img src='" + APConfig.GetProperty("GRIDVIEW_DETAIL_IMG") + "' style='border:0; vertical-align:bottom' /></a>";
                }
                catch { }

                //=== 權限控制(詳) ===
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

        #region PrepareEditKey 將 Key 資料回塞到畫面上去"
        /// <summary>
        /// 將 Key 資料回塞到畫面上去, 並改變 TD 顏色
        /// </summary>
        /// <param name="sender">Key 資料(CD|VALUE|CD|VALUE)</param>
        /// <param name="blockName">blockName 字首,ex: M_</param>
        protected void PrepareEditKeyToUI(LinkButton sender,string blockName="M_")
        {
            string[] keyAry = sender.Attributes["KEY"].ToString().Split('|');
            for (int i = 0; i < keyAry.Length; i += 2)
            {
                if (this.FindControl(blockName + keyAry[i]) != null)
                    //== 塞畫面資料 ===
                    FormUtil.SetControlValue(this.FindControl(blockName + keyAry[i]), keyAry[i + 1]);
            }
        }
        #endregion

      
        #region PrepareRowDataBoundEventFor1_1 處理每行 Grid 事件"
        /// <summary>
        /// PrepareRowDataBoundEventFor1_1 處理每行 Grid 事件, For Pattern 1-1
        /// 預設處理功能 核選/編/詳/刪 權限機制, 
        /// 若欲覆寫功能於下方再行覆寫即可
        /// </summary>
        /// <param name="dataGrid">GridView 物件</param>
        /// <param name="row">行物件</param>
        protected void PrepareRowDataBoundEventFor1_1(GridView dataGrid, GridViewRow row)
        {
            string keyValue = this.GetKeyValueByGridRow(dataGrid, row.RowIndex);

            //=== 設定 DataGrid 的 CheckBox，Value 要組合 Primary Key ===
            HtmlInputCheckBox tmpChkBox = (HtmlInputCheckBox)row.FindControl("chkBox");
            if (tmpChkBox != null)
                tmpChkBox.Value = keyValue;

            //=== 設定編輯 ===
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

                //=== 權限控制(編輯) ===
                if (!ActionSecurity.HasFunctionPermission("0003"))
                    ((TableCell)tmpLink.Parent).Enabled = false;
                else
                {
                    tmpLink.Attributes.Add("onclick", "clickEditRow(this, '" + keyValue + "');");
                    tmpLink.Attributes.Add("KEY", keyValue);
                    row.Attributes.Add("KEY", keyValue);
                }
            }

            //=== 設定詳 ===
            tmpLink = (LinkButton)row.FindControl("detail");
            if (tmpLink != null)
            {
                try
                {
                    if (!string.IsNullOrEmpty(APConfig.GetProperty("GRIDVIEW_DETAIL_IMG")))
                        tmpLink.Text = "<img src='" + APConfig.GetProperty("GRIDVIEW_DETAIL_IMG") + "' style='border:0; vertical-align:bottom' />";
                }
                catch { }

                //=== 權限控制(詳) ===
                if (!ActionSecurity.SecurityCheck("DETAIL"))
                    ((TableCell)tmpLink.Parent).Enabled = false;
                else
                {
                    tmpLink.Attributes.Add("onclick", "clickDetailRow(this, '" + keyValue + "');");
                    tmpLink.Attributes.Add("KEY", keyValue);
                    row.Attributes.Add("KEY", keyValue);
                }
            }

            //=== 設定刪除 ===
            tmpLink = (LinkButton)row.FindControl("del");
            if (tmpLink != null)
            {
                try
                {
                    if (!string.IsNullOrEmpty(APConfig.GetProperty("GRIDVIEW_DEL_IMG")))
                        tmpLink.Text = "<img src='" + APConfig.GetProperty("GRIDVIEW_DEL_IMG") + "' style='border:0; vertical-align:bottom' />";
                }
                catch { }

                //=== 權限控制(刪除) ===
                if (!ActionSecurity.HasFunctionPermission("0002"))
                    ((TableCell)tmpLink.Parent).Enabled = false;
                else
                {
                    //=== 點選刪除時，出現 confirm 訊息 ===
                    tmpLink.Attributes.Add("KEY", keyValue);
                    tmpLink.OnClientClick = "return doDelete();";
                }
            }

            //=== 設定多國語系 ===
            BindMLProperty(row);
        }
        #endregion


        #region PrepareRowDataBoundEventFor1_1_V2 處理每行 Grid 事件"
        /// <summary>
        /// PrepareRowDataBoundEventFor1_1_V2 處理每行 Grid 事件, For Pattern 1-1
        /// 預設處理功能 核選/編/詳/刪 權限機制, 
        /// 若欲覆寫功能於下方再行覆寫即可
        /// </summary>
        /// <param name="dataGrid">GridView 物件</param>
        /// <param name="row">行物件</param>
        /// <param name="num">物件序號(ex:edit2,del2)</param>
        protected void PrepareRowDataBoundEventFor1_1_V2(GridView dataGrid, GridViewRow row,string num)
        {
            string keyValue = this.GetKeyValueByGridRow(dataGrid, row.RowIndex);

            //=== 設定 DataGrid 的 CheckBox，Value 要組合 Primary Key ===
            HtmlInputCheckBox tmpChkBox = (HtmlInputCheckBox)row.FindControl("chkBox");
            if (tmpChkBox != null)
                tmpChkBox.Value = keyValue;

            //=== 設定編輯 ===
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

                //=== 權限控制(編輯) ===
                if (!ActionSecurity.HasFunctionPermission("0003"))
                    ((TableCell)tmpLink.Parent).Enabled = false;
                else
                {
                    tmpLink.Attributes.Add("onclick", "clickEditRow(this, '" + keyValue + "');");
                    tmpLink.Attributes.Add("KEY", keyValue);
                    row.Attributes.Add("KEY", keyValue);
                }
            }

            //=== 設定詳 ===
            tmpLink = (LinkButton)row.FindControl("detail" + num);
            if (tmpLink != null)
            {
                try
                {
                    if (!string.IsNullOrEmpty(APConfig.GetProperty("GRIDVIEW_DETAIL_IMG")))
                        tmpLink.Text = "<img src='" + APConfig.GetProperty("GRIDVIEW_DETAIL_IMG") + "' style='border:0; vertical-align:bottom' />";
                }
                catch { }

                //=== 權限控制(詳) ===
                if (!ActionSecurity.SecurityCheck("DETAIL"))
                    ((TableCell)tmpLink.Parent).Enabled = false;
                else
                {
                    tmpLink.Attributes.Add("onclick", "clickDetailRow(this, '" + keyValue + "');");
                    tmpLink.Attributes.Add("KEY", keyValue);
                    row.Attributes.Add("KEY", keyValue);
                }
            }

            //=== 設定刪除 ===
            tmpLink = (LinkButton)row.FindControl("del" + num);
            if (tmpLink != null)
            {
                try
                {
                    if (!string.IsNullOrEmpty(APConfig.GetProperty("GRIDVIEW_DEL_IMG")))
                        tmpLink.Text = "<img src='" + APConfig.GetProperty("GRIDVIEW_DEL_IMG") + "' style='border:0; vertical-align:bottom' />";
                }
                catch { }

                //=== 權限控制(刪除) ===
                if (!ActionSecurity.HasFunctionPermission("0002"))
                    ((TableCell)tmpLink.Parent).Enabled = false;
                else
                {
                    //=== 點選刪除時，出現 confirm 訊息 ===
                    tmpLink.Attributes.Add("KEY", keyValue);
                    tmpLink.OnClientClick = "return doDelete();";
                }
            }

            //=== 設定多國語系 ===
            BindMLProperty(row);
        }
        #endregion

        #region MergeRows 合併 GridView 儲存格
        /// <summary>
        /// 合併 GridView 儲存格
        /// </summary>
        /// <param name="gridView">GridView 物件</param>
        /// <param name="cellIndex">欲合併的列數</param>
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

        #region 匯出 Excel 相關
        #region GetCHeadingStr 抓取匯出表頭字串
        /// <summary>
        /// 表頭字串
        /// </summary>
        protected string headingStr = "";

        /// <summary>
        /// 抓取匯出中文表頭字串
        /// </summary>
        /// <returns>中文表頭字串</returns>
        protected string GetCHeadingStr()
        {
            //=== For 暫時處理, 上線時要移除 ===
            FormUtil.Cache.Remove("COLUMN_FILTER");

            ColumnFilterUtil.ColiumnFilter tmp = ColumnFilterUtil.GetColumnFilter(this.DBManager, this.PageID);

            this.headingStr = tmp.EName.Replace("'", "");
            return tmp.CName.Replace("'", "");
        }
        #endregion

        #region GetHeadingStr 抓取匯出表頭字串
        /// <summary>
        /// 抓取匯出英文表頭字串
        /// </summary>
        /// <returns>英文表頭字串</returns>
        protected string GetHeadingStr()
        {
            if (!string.IsNullOrEmpty(headingStr))
                return headingStr;

            //=== For 暫時處理, 上線時要移除 ===
            FormUtil.Cache.Remove("COLUMN_FILTER");

            ColumnFilterUtil.ColiumnFilter tmp = ColumnFilterUtil.GetColumnFilter(this.DBManager, this.PageID);

            return tmp.EName.Replace("'", "");
        }
        #endregion

        #region DrawContent 產生匯出資料 | L左 M中 R右
        /// <summary>
        /// DrawContent 產生匯出資料 | L左 M中 R右
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="index">索引</param>
        /// <param name="content">要匯出的資料</param>
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

        #region DrawContent 產生匯出資料 | L左 M中 R右
        /// <summary>
        /// 產生匯出資料 | L左 M中 R右
        /// </summary>
        /// <param name="content">要匯出的資料</param>
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

        #region DD 相關
        #region BindDDProperty 將資料字典設定套用套畫面上
        /// <summary>
        /// 將資料字典設定套用套畫面上
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
                        
                        this.Logger.Append("資料字典未設定該欄位 --> " + ddColumn);
                        if (FormUtil.GetAttributeData(tmpControl, "SKIP") == null)
                        {
                            //=== 2009/08/27 海大 RadioButtonList 之前不會檢查, 後來又檢查找不出原因, 所以針對海大開放不檢查 ===

                            if (tmpControl.GetType().Name.Equals("RadioButtonList"))
                                continue;

                            //Brian Chou Modify 2017/3/7 全部一齊呈現
                            //throw new Exception("資料字典未設定該欄位 --> " + ddColumn);

                            //Brian Chou Modify 2017/3/7
                            ddErr.Append(ddColumn + ",");
                            
                        }
                        else
                            continue;
                    }
                    else
                    { 
                        tmpStruct = (DataDictionaryUtil.ColumnDD)columnDDMap[ddColumn];

                        //=== 記錄資料字典型態 ===
                        FormUtil.SetAttributeData(tmpControl, "DD", tmpStruct.UIType);

                        //=== 保留中文資訊 ===
                        if (pageColumnMap[this.PageID + "_" + tmpStruct.Name] == null)
                            FormUtil.SetAttributeData(tmpControl, "CNAME", LangUtil.LangMap("PAGE." + tmpStruct.CName));
                        else
                            FormUtil.SetAttributeData(tmpControl, "CNAME", LangUtil.LangMap("PAGE." + pageColumnMap[this.PageID + "_" + tmpStruct.Name].ToString()));

                        //=== 不允許空白, 僅針對編輯畫面處理 ===
                        SetBindUIChkFormByProp(tmpControl, tmpStruct);

                        //=== 定義畫面型態 ===
                        SetBindUIType(tmpControl, tmpStruct);

                        //=== 長度 ===
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
                    throw new Exception("資料字典未設定該欄位 --> " + ddErr.ToString());
                }
            }
            finally
            {
                this.LogUtil.TraceEnd(MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region GetDD 取得 DD 資料
        private string GetDD(string column)
        {
            if (column.IndexOf("_") == 1)
                return column.Substring(2);
            else
                return column;
        }
        #endregion

        #region ServerSideValid Server 端檢核
        /// <summary>
        /// Server 端檢核
        /// </summary>
        /// <param name="validForm">檢核的 Form Q_ || M_</param>
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

                    //=== 非檢查的 Form 不處理 ===
                    if (!tmpControl.ID.Substring(0, 2).Equals(validForm))
                        continue;

                    //=== SKIP 掉的不檢查 ===
                    if (FormUtil.GetAttributeData(tmpControl, "SKIP") != null && FormUtil.GetAttributeData(tmpControl, "SKIP").Equals("Y"))
                        continue;

                    if (!columnDD.Contains(ddColumn))
                        continue;

                    tmpStruct = (DataDictionaryUtil.ColumnDD)columnDD[ddColumn];

                    //=== 檢查字串長度 ===
                    if (!string.IsNullOrEmpty(tmpStruct.Length))
                    {
                        if (tmpControl.GetType().Name.Equals("TextBox") && ((TextBox)tmpControl).MaxLength > 0)
                        {
                            int maxLength = Convert.ToInt32(((TextBox)tmpControl).MaxLength);
                            if (columnValue.Replace("''", "'").Length > maxLength && !tmpStruct.UIType.Equals("CYM") && !tmpStruct.UIType.Equals("CD9") && !tmpStruct.UIType.Equals("CD7") && !tmpStruct.UIType.Equals("CD") &&
                                !tmpStruct.UIType.Equals("D") && !tmpStruct.UIType.Equals("A") && !tmpStruct.UIType.Equals("T") &&
                                !tmpStruct.UIType.Equals("N3") && !tmpStruct.UIType.Equals("N4"))
                                throw new ServerSideValidException("欄位:" + tmpControl.ID + " 輸入長度過長：" + columnValue + "長度:" + columnValue.Length + ", DD 設定長度(自訂)：" + maxLength);
                        }
                        else
                        {
                            if (columnValue.Replace("''", "'").Length > Convert.ToInt32(tmpStruct.Length) && !tmpStruct.UIType.Equals("CYM") && !tmpStruct.UIType.Equals("CD9") && !tmpStruct.UIType.Equals("CD7") && !tmpStruct.UIType.Equals("CD") &&
                                !tmpStruct.UIType.Equals("D") && !tmpStruct.UIType.Equals("A") && !tmpStruct.UIType.Equals("T") &&
                                !tmpStruct.UIType.Equals("N3") && !tmpStruct.UIType.Equals("N4"))
                                throw new ServerSideValidException("欄位:" + tmpControl.ID + " 輸入長度過長：" + columnValue + "長度:" + columnValue.Length + ", DD 設定長度：" + tmpStruct.Length);
                        }
                    }

                    //20170906 測試
                    if (tmpControl.GetType().Name.Equals("DropDownList"))
                    {
                        DropDownList ddl = (DropDownList)tmpControl;
                        DBManager.Logger.Append("ddl->" + ddl.SelectedValue);
                    }

                    if (string.IsNullOrEmpty(columnValue))
                    {
                        //=== 檢查空白否 ===
                        if (!string.IsNullOrEmpty(FormUtil.GetAttributeData(tmpControl, "chkForm")))
                        {
                            throw new ServerSideValidException("欄位[" + tmpControl.ID + "]不可為空值!!");
                        }
                        else
                            continue;
                    }
                    //=== 檢查字串格式 ===
                    Regex reg = null;
                    switch (tmpStruct.UIType)
                    {
                        //=== 國曆 ===
                        case "CD":
                            if (!DateUtil.IsDate(columnValue))
                                throw new ServerSideValidException("[國曆]欄位:" + tmpControl.ID + " 日期格式錯誤：" + columnValue);
                            break;
                        //=== 西曆 ===
                        case "D":
                            if (!DateUtil.IsDate(columnValue))
                                throw new ServerSideValidException("[西曆]欄位:" + tmpControl.ID + " 日期格式錯誤：" + columnValue);
                            break;
                        //=== 日期 ===
                        case "DT":
                            if (!DateUtil.IsDate(columnValue))
                                throw new ServerSideValidException("[日期]欄位:" + tmpControl.ID + " 日期格式錯誤：" + columnValue);
                            break;
                        //=== 整數數字 ===
                        case "N":
                            try { Convert.ToInt64(columnValue); }
                            catch (Exception) { throw new ServerSideValidException("[整數數字]欄位:" + tmpControl.ID + " 必須為整數數字：" + columnValue); }
                            break;
                        //=== 純數字 ===
                        case "N1":
                            reg = new Regex("[^0-9]");
                            if (reg.IsMatch(columnValue))
                                throw new ServerSideValidException("[純數字]欄位:" + tmpControl.ID + " 必須為純數字格式：" + columnValue);
                            break;
                        //=== 正整數不含小數 ===
                        case "N2":
                            reg = new Regex("[^0-9]");
                            if (reg.IsMatch(columnValue))
                                throw new ServerSideValidException("[正整數不含小數]欄位:" + tmpControl.ID + " 必須為純數字格式：" + columnValue);
                            break;
                        //=== 數字含小數不要3位一撇 ===
                        case "N3":
                            try { Convert.ToDouble(columnValue); }
                            catch (Exception) { throw new ServerSideValidException("[數字含小數不要3位一撇]欄位:" + tmpControl.ID + " 必須為數字含小數格式：" + columnValue); }
                            break;
                        //=== 正整數含小數不要3位一撇 ===
                        case "N4":
                            try { Convert.ToDouble(columnValue); }
                            catch (Exception) { throw new ServerSideValidException("[正整數含小數不要3位一撇]欄位:" + tmpControl.ID + " 必須為正整數含小數格式：" + columnValue); }
                            if (Convert.ToDouble(columnValue) < 0)
                                throw new ServerSideValidException("[正整數含小數不要3位一撇]欄位:" + tmpControl.ID + " 必須為正整數含小數格式：" + columnValue);
                            break;
                        //=== 中英混合 ===
                        case "X":
                            break;
                        //=== IDN_BAN ===
                        case "I":
                            break;
                        //=== 數字前補零 ===
                        case "Z":
                            reg = new Regex("[^0-9]");
                            if (reg.IsMatch(columnValue))
                                throw new ServerSideValidException("[數字前補零]欄位:" + tmpControl.ID + " 必須為整數數字格式：" + columnValue);
                            break;
                        //=== 時間 ===
                        case "T":
                            if (!DateUtil.IsTime(columnValue))
                                throw new ServerSideValidException("[時間]欄位:" + tmpControl.ID + " 必須為時間格式：" + columnValue);
                            break;
                        //=== 數字含小數 ===
                        case "A":
                            try { Convert.ToDouble(columnValue); }
                            catch (Exception) { throw new ServerSideValidException("[數字含小數]欄位:" + tmpControl.ID + " 必須為數字含小數格式：" + columnValue); }
                            break;
                        //=== 英數 ===
                        case "E":
                            reg = new Regex("[^a-zA-Z0-9]");
                            if (reg.IsMatch(columnValue))
                                throw new ServerSideValidException("[英數]欄位:" + tmpControl.ID + " 必須為英數格式：" + columnValue);
                            break;
                        //=== 英數小寫(含符號) ===
                        case "EL":
                            reg = new Regex("[A-Z]");
                            if (reg.IsMatch(columnValue))
                                throw new ServerSideValidException("[英數小寫(含符號)]欄位:" + tmpControl.ID + " 必須為不可為英數大寫資訊：" + columnValue);
                            if (Utility.GetBLen(columnValue) != columnValue.Length)
                                throw new ServerSideValidException("[英數小寫(含符號)]欄位:" + tmpControl.ID + " 必須為不可包含中文資訊：" + columnValue);
                            break;
                        //=== 英數大寫(含符號) ===
                        case "EU":
                            reg = new Regex("[a-z]");
                            if (reg.IsMatch(columnValue))
                                throw new ServerSideValidException("[英數大寫(含符號)]欄位:" + tmpControl.ID + " 必須為不可為英數小寫資訊：" + columnValue);
                            if (Utility.GetBLen(columnValue) != columnValue.Length)
                                throw new ServerSideValidException("[英數大寫(含符號)]欄位:" + tmpControl.ID + " 必須為不可包含中文資訊：" + columnValue);
                            break;
                        //=== 英數大寫(不含符號) ===
                        case "EU1":
                            reg = new Regex("[a-z]");
                            if (reg.IsMatch(columnValue))
                                throw new ServerSideValidException("[英數大寫(含符號)]欄位:" + tmpControl.ID + " 必須為不可為英數小寫資訊：" + columnValue);
                            if (Utility.GetBLen(columnValue) != columnValue.Length)
                                throw new ServerSideValidException("[英數大寫(含符號)]欄位:" + tmpControl.ID + " 必須為不可包含中文資訊：" + columnValue);
                            break;
                        //=== 英數(含符號) ===
                        case "EW":
                            if (Utility.GetBLen(columnValue) != columnValue.Length)
                                throw new ServerSideValidException("[英數(含符號)]欄位:" + tmpControl.ID + " 必須為不可包含中文資訊：" + columnValue);
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

        #region BindDDFormat 套用資料字典格式化
        /// <summary>
        /// 套用資料字典格式化
        /// </summary>
        /// <param name="dt">DataTable 資料</param>
        /// <param name="formatType">格式化種類</param>
        /// <returns>格式化後字串 DataTable 資料</returns>
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

        #region BindDDFormat 套用資料字典格式化
        /// <summary>
        /// 套用資料字典格式化
        /// </summary>
        /// <param name="dr">資料列物件</param>
        /// <param name="columnName">欄位名稱</param>
        /// <param name="formatType">格式化種類</param>
        /// <param name="columnDD">資料字典暫存內容</param>
        /// <returns>格式化後字串</returns>
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
                    //=== 西曆日期時間(純顯示) ===
                    case "DT":
                        if (string.IsNullOrEmpty((string)dr[columnName]))
                            result = "";
                        else
                            result = Convert.ToDateTime(dr[columnName]).ToString("yyyy/MM/dd HH:mm:ss");
                        break;
                    //=== 國曆大寫日期時間(純顯示) ===
                    case "FCDT":
                        if (string.IsNullOrEmpty((string)dr[columnName]))
                            result = "";
                        else
                        {
                            string cDate = DateUtil.ConvertDate(Convert.ToDateTime(dr[columnName]).ToString("yyyyMMdd"));
                            result = "民國" + Convert.ToInt32(cDate.Substring(0, 3)) + "年" +
                                    Convert.ToInt32(cDate.Substring(3, 2)) + "月" +
                                    Convert.ToInt32(cDate.Substring(5)) + "日 " +
                                    Convert.ToDateTime(dr[columnName]).ToString("HH:mm:ss");
                        }
                        break;
                    //=== 國曆大寫日期時間(純顯示) ===
                    case "FCD":
                        if (string.IsNullOrEmpty((string)dr[columnName]))
                            result = "";
                        else
                        {
                            string cDate = DateUtil.ConvertDate(Convert.ToDateTime(dr[columnName]).ToString("yyyyMMdd"));
                            result = "民國" + Convert.ToInt32(cDate.Substring(0, 3)) + "年" +
                                    Convert.ToInt32(cDate.Substring(3, 2)) + "月" +
                                    Convert.ToInt32(cDate.Substring(5)) + "日";
                        }
                        break;
                    //=== 國曆日期時間(純顯示) ===
                    case "CDT":
                        if (string.IsNullOrEmpty((string)dr[columnName]))
                            result = "";
                        else
                            result = DateUtil.FormatCDate(DateUtil.ConvertDate(Convert.ToDateTime(dr[columnName]).ToString("yyyyMMdd"))) + " " + Convert.ToDateTime(dr[columnName]).ToString("HH:mm:ss");
                        break;
                    //=== 國曆 ===
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
                    //=== 西元年 ===
                    case "D":
                        if (string.IsNullOrEmpty((string)dr[columnName]))
                            result = "";
                        else
                            result = Convert.ToDateTime(dr[columnName]).ToString("yyyy/MM/dd");
                        break;
                    //=== 時間格式 ===
                    case "T":
                        if (string.IsNullOrEmpty((string)dr[columnName]))
                            result = "";
                        else
                            result = DateUtil.FormatTime(dr[columnName].ToString());
                        break;
                    //=== 金額 ===
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
            //=== 取得檢核字串 ===
            string validData = FormUtil.GetControlValidationGroupData(control);
            //=== 取得檢核種類 ===
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
                //=== 國曆 yyy/MM/dd ===
                case "CD":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.MaxLength, "9" });
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.DateFormat });
                    break;
                //=== 西曆 yyyy/MM/dd ===
                case "D":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.MaxLength, "10" });
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.DateFormat });
                    break;
                //=== 日期 ===
                case "DT":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.DateFormat });
                    break;
                //=== 整數數字 ===
                case "N":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.NumberFormat });
                    break;
                //=== 純數字 ===
                case "N1":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.OnlyNumber });
                    break;
                //=== 正整數不含小數 ===
                case "N2":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.OnlyNumber });
                    break;
                //=== 純中文 ===
                case "H":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.FullString });
                    break;
                //=== 英數型態 ===
                case "E":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.OnlyNumberAndEnglish });
                    break;
                //=== 中英混合 ===
                case "X":
                    break;
                //=== IDN_BAN ===
                case "I":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.IdnBan });
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.UpperCase });
                    break;
                //=== 數字前補零 ===
                case "Z":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.OnlyNumber });
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.FillZero, tmpStruct.Length });
                    break;
                //=== 時間 ===
                case "T":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.MaxLength, "8" });
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.TimeFormat });
                    break;
                //=== 數字含小數 ===
                case "A":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.DecimalFormat, tmpStruct.Length + "." + tmpStruct.Dot });
                    break;
                //=== 數字含小數不要3位一撇 ===
                case "N3":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.DecimalFormatNoFormat, tmpStruct.Length + "." + tmpStruct.Dot });
                    break;
                //=== 正整數含小數不要3位一撇 ===
                case "N4":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.DecimalFormatNoFormat1, tmpStruct.Length + "." + tmpStruct.Dot });
                    break;
                //=== 英數小寫(含符號) ===
                case "EL":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.OnlyNumberEngAndSpecialWord });
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.LowerCase });
                    break;
                //=== 英數大寫(含符號) ===
                case "EU":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.OnlyNumberEngAndSpecialWord });
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.UpperCase });
                    break;
                //=== 英數大寫(不含符號) ===
                case "EU1":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.OnlyNumberAndEnglish });
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.UpperCase });
                    break;
                //=== 英數(含符號) ===
                case "EW":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.OnlyNumberEngAndSpecialWord });
                    break;
                //=== IP ===
                case "IP":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.IP });
                    break;
                //=== 電話型態 ===
                case "TEL":
                    this.JScript.IniFormSet(control, new string[] { JScript.Ctrl.TEL });
                    break;
                //=== 網址 ===
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

        #region BindCompleteColumnFieldProperty 初始化資料欄位設定 Load Complete
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

                    //=== 先比對 Exp: M_DD ===
                    if (!columnFieldMap.ContainsKey(this.PageID + "_" + fieldCD))
                        continue;

                    tmpStruct = (DataDictionaryUtil.ColumnField)columnFieldMap[this.PageID + "_" + fieldCD];

                    //=== 選項加空白 ===
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

        #region BindColumnFieldProperty 初始化資料欄位設定
        /// <summary>
        /// 初始化資料欄位設定
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
                        //=== nono mark 2009/04/28 畫面欄位不需判斷 _1 _2 Spec 已含 ===
                        //ddColumn	=	GetDD(tmpControl.ID.Substring(2));
                        ddColumn = tmpControl.ID.Substring(2);
                        columnHeader = tmpControl.ID.Substring(0, 2);
                        fieldCD = columnHeader + ddColumn;

                        //=== 先比對 Exp: M_DD ===
                        if (!columnFieldMap.ContainsKey(this.PageID + "_" + fieldCD))
                            continue;

                        tmpStruct = (DataDictionaryUtil.ColumnField)columnFieldMap[this.PageID + "_" + fieldCD];

                        //=== 唯讀 ===
                        if (tmpStruct.ReadOnly)
                            this.JScript.IniFormSet(tmpControl, new string[] { JScript.Ctrl.Disable, "1" });
                        //=== 必填 ===
                        if (tmpStruct.NotNull)
                        {
                            FormUtil.SetControlValidationGroup(tmpControl, "NOTNULL");
                            FormUtil.SetAttributeData(tmpControl, "chkForm", LangUtil.LangMap("PAGE." + tmpStruct.CName));
                        }

                        //=== 選項加空白 ===
                        if (!string.IsNullOrEmpty(tmpStruct.AddBlank) && tmpStruct.AddBlank.Equals("Y") && tmpStruct.FieldType.Equals("DDL"))
                        {
                            FormUtil.SetAttributeData(tmpControl, "ADD_BLANK", "Y");
                        }

                        //=== 選項內容 ===
                        string[] content;
                        if (!string.IsNullOrEmpty(tmpStruct.Content))
                        {
                            content = tmpStruct.Content.Split(',');
                            if (content.Length % 2 != 0)
                                throw new Exception(tmpStruct.CName + "下拉預設內容有誤: " + tmpStruct.Content);

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

                        //=== 預設值 ===
                        if (!string.IsNullOrEmpty(tmpStruct.DefaultValue))
                        {
                            switch (tmpStruct.DefaultValue)
                            {
                                case "系統日期":
                                    tmpStruct.DefaultValue = DateUtil.FormatCDate(DateUtil.GetNowCDate());
                                    break;
                                case "系統年":
                                    tmpStruct.DefaultValue = DateUtil.GetNowCDate().Substring(0, 3);
                                    break;
                                case "系統月":
                                    tmpStruct.DefaultValue = System.DateTime.Now.ToString("MM");
                                    break;
                                case "系統日":
                                    tmpStruct.DefaultValue = System.DateTime.Now.ToString("dd");
                                    break;
                                case "系統時":
                                    tmpStruct.DefaultValue = System.DateTime.Now.ToString("HH");
                                    break;
                            }
                            this.JScript.IniFormSet(tmpControl, new string[] { JScript.Ctrl.DefaultValue, tmpStruct.DefaultValue, JScript.Ctrl.Value, tmpStruct.DefaultValue });
                        }

                        //預設值, 預設 Session, 唯讀, 必填, 選項加空白, 選項內容
                        if (!string.IsNullOrEmpty(tmpStruct.DefaultSessionValue))
                        {
                            if (sessionMap[tmpStruct.DefaultSessionValue] == null)
                                throw new Exception("預設值 Session 定義錯誤: " + tmpStruct.DefaultSessionValue);
                            if (Session[sessionMap[tmpStruct.DefaultSessionValue].ToString()] == null)
                                throw new Exception("預設值 Session: Session 未定義 -> " + tmpStruct.DefaultSessionValue + ":" + sessionMap[tmpStruct.DefaultSessionValue].ToString());
                            this.JScript.IniFormSet(tmpControl, new string[]{JScript.Ctrl.DefaultValue, Session[sessionMap[tmpStruct.DefaultSessionValue].ToString()].ToString(), 
													JScript.Ctrl.Value, Session[sessionMap[tmpStruct.DefaultSessionValue].ToString()].ToString()});
                        }

                        //=== 保留中文資訊 ===
                        FormUtil.SetAttributeData(tmpControl, "CNAME", LangUtil.LangMap("PAGE." + tmpStruct.CName));
                    }
                    catch (Exception ex)
                    {
                        this.Logger.Append("畫面欄位處理錯誤 :" + tmpControl.ID);
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
        /// 判斷是否選項加空白
        /// </summary>
        /// <param name="controlName">控制項名稱</param>
        /// <param name="currAttr">原先的參數</param>
        /// <returns>是否選項加空白</returns>
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

        #region 多國語系相關
        #region BindMLProperty 將多國語系資料套在畫面上
        /// <summary>
        /// 將多國語系資料套在畫面上
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
                    //2014.04.14 Brian Modify this.PageID 改為 PAGE
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
                    //== 塞畫面資料 ===
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

        #region 畫面處理
        #region BindUIByDataTable 處理將 DataTable 結果 Bind 到畫面上"
        /// <summary>
        /// 處理將 DataTable 結果 Bind 到畫面上
        /// </summary>
        /// <param name="data">DataTable 資料物件</param>
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
                    //== 塞畫面資料 ===
                    FormUtil.SetControlValue(this.FindControl(fieldName), data.Rows[0][i]);
                }
            }
        }
        #endregion

        #region BindUIByDataTable 處理將 DataTable 結果 Bind 到畫面上(指定區塊)"
        /// <summary>
        /// 處理將 DataTable 結果 Bind 到畫面上
        /// </summary>
        /// <param name="data">DataTable 資料物件</param>
        /// <param name="blockName">區塊名稱</param>
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
                    //== 塞畫面資料 ===
                    FormUtil.SetControlValue(this.FindControl(fieldName), data.Rows[0][i]);
                }
            }
        }
        #endregion

        #region ColumnFilterInit 初始化欄位篩選設定
        /// <summary>
        /// 初始化欄位篩選設定
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

        #region MapRequestToUIControl 將 Request 資料對應到控制項上, For 匯出使用(僅處理 HiddenField、TextBox 及 DropDownList)
        /// <summary>
        /// 將 Request 資料對應到控制項上, For 匯出使用(僅處理 HiddenField、TextBox 及 DropDownList)
        /// </summary>
        protected void MapRequestToUIControl(Page page)
        {
            foreach (string key in Request.Form.Keys)
            {
                if (key.StartsWith("Q_") || key.StartsWith("M_"))
                {
                    if (this.FindControl(key) != null)
                        //== 塞畫面資料 ===
                        FormUtil.SetControlValue(this.FindControl(key), Request[key]);
                }
            }
        }
        #endregion

        #region MapDropDownListText 對應下拉選項中文
        /// <summary>
        /// 對應下拉選項中文
        /// </summary>
        /// <param name="ddl">下拉控制項</param>
        /// <param name="value">要對應的值</param>
        /// <returns>回傳對應中文, 對應不到回傳原始值</returns>
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

        #region MapRadioButtonListText 對應核選方塊清單中文
        /// <summary>
        /// 對應核選方塊清單中文
        /// </summary>
        /// <param name="ddl">核選方塊清單物件</param>
        /// <param name="value">要對應的值</param>
        /// <returns>回傳對應中文, 對應不到回傳原始值</returns>
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

        #region PrepareUserControl 將物件狀態過渡給使用者控制項上
        /// <summary>
        /// 將物件狀態過渡給使用者控制項上
        /// </summary>
        /// <param name="userControl">使用者控制項</param>
        private void PrepareUserControl(UserControlBase userControl)
        {
            userControl.DBManager = this.DBManager;
            userControl.JScript = this.JScript;
            userControl.LogUtil = this.LogUtil;
        }
        #endregion

        #region GetControlHtml 取得控制項輸出的 HTML
        /// <summary>
        /// 取得控制項輸出的 HTML
        /// </summary>
        /// <param name="webControl">控制項</param>
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

        #region 錯誤處理
        #region AjaxError Ajax 錯誤處理機制使用
        /// <summary>
        /// Ajax 錯誤處理機制使用
        /// </summary>
        /// <returns>Ajax 錯誤訊息</returns>
        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public static string AjaxError()
        {
            return PageBase.AjaxErrLog;
        }
        #endregion
        #endregion

        #region 過期方法
        #region GetFromCondition 依據查詢畫面欄位(TextBox 型態)產生條件
        /// <summary>
        /// 依據查詢畫面欄位(TextBox 型態)產生條件
        /// </summary>
        /// <param name="fieldName">畫面欄位名稱</param>
        /// <returns>查詢條件</returns>
        [Obsolete("This method is deprecated, use GetHashCode instead.")]
        protected string GetFromCondition(string fieldName)
        {
            if (string.IsNullOrEmpty(fieldName))
                throw new ArgumentException("欄位值不可空白", fieldName);

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

                    //=== 取得檢核字串 ===
                    validData = FormUtil.GetControlValidationGroupData(tmpControl);
                    //=== 取得檢核種類 ===
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

        #region 權限相關
        #region ProcessPermission 處理權限動作
        /// <summary>
        /// 處理權限動作
        /// </summary>
        private void ProcessPermission()
        {
            //新增權限
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
            //刪除權限
            if (!ActionSecurity.HasFunctionPermission("0002"))
            {
                try { ((Button)this.FindControl("DEL_BTN1")).Enabled = false; }
                catch (System.Exception) { }
                try { ((Button)this.FindControl("DEL_BTN2")).Enabled = false; }
                catch (System.Exception) { }
            }
            //修改權限
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
            //查詢權限
            if (!ActionSecurity.HasFunctionPermission("0004"))
            {
                try { ((Button)this.FindControl("QUERY_BTN1")).Enabled = false; }
                catch (System.Exception) { }
            }

            //=== 處理唯讀欄項(查詢) ===
            if (Session["0_READONLY_COLUMN"] != null)
            {
                string[] columnAry = Session["0_READONLY_COLUMN"].ToString().Split(',');
                for (int i = 0; i < columnAry.Length; i++)
                {
                    if (this.FindControl("Q_" + columnAry[i]) == null)
                        this.Logger.Append("==>" + columnAry[i] + "畫面上並無此控制項(權限欄位設定 Q)");
                    else
                        FormUtil.SetControlDisable(this.FindControl("Q_" + columnAry[i]), true);
                }
            }

            //=== 處理不顯示欄項(查詢) ===
            if (Session["1_READONLY_COLUMN"] != null)
            {
                string[] columnAry = Session["1_READONLY_COLUMN"].ToString().Split(',');
                for (int i = 0; i < columnAry.Length; i++)
                {
                    if (this.FindControl("Q_" + columnAry[i]) == null)
                        this.Logger.Append("==>" + columnAry[i] + "畫面上並無此控制項(權限欄位設定 Q)");
                    else
                    {
                        FormUtil.SetAttributeData(this.FindControl("Q_" + columnAry[i]), "style", "display:none");
                        this.JScript.Script = "_i(0, 'Q_" + columnAry[i] + "').outerHTML = _i(0, 'Q_" + columnAry[i] + "').outerHTML + '&nbsp'";
                    }
                }
            }

            //=== 處理唯讀欄項(編輯) ===
            if (Session["2_READONLY_COLUMN"] != null)
            {
                string[] columnAry = Session["2_READONLY_COLUMN"].ToString().Split(',');
                for (int i = 0; i < columnAry.Length; i++)
                {
                    if (this.FindControl("M_" + columnAry[i]) == null)
                        this.Logger.Append("==>" + columnAry[i] + "畫面上並無此控制項(權限欄位設定 M)");
                    else
                        FormUtil.SetControlDisable(this.FindControl("M_" + columnAry[i]), true);
                }
            }

            //=== 處理不顯示欄項(編輯) ===
            if (Session["3_READONLY_COLUMN"] != null)
            {
                string[] columnAry = Session["3_READONLY_COLUMN"].ToString().Split(',');
                for (int i = 0; i < columnAry.Length; i++)
                {
                    if (this.FindControl("M_" + columnAry[i]) == null)
                        this.Logger.Append("==>" + columnAry[i] + "畫面上並無此控制項(權限欄位設定 M)");
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
        /// 組合查詢字串
        /// </summary>
        /// <param name="outputBuff">回傳的字串</param>
        /// <param name="oper">條件資訊</param>
        /// <param name="column">欄位名稱</param>
        /// <param name="var">欄位值</param>
        /// <param name="needComma">是否需要引號資料</param>
        protected void ProcessQueryCondition(StringBuilder outputBuff, string oper, string column, string var, bool needComma)
        {
            DBUtil.ProcessQueryCondition(outputBuff, oper, column, var, needComma);
        }

        /// <summary>
        /// 組合查詢字串
        /// </summary>
        /// <param name="outputBuff">回傳的字串</param>
        /// <param name="oper">條件資訊</param>
        /// <param name="column">欄位名稱</param>
        /// <param name="var">欄位值</param>
        protected void ProcessQueryCondition(StringBuilder outputBuff, string oper, string column, string var)
        {
            this.ProcessQueryCondition(outputBuff, oper, column, var, true);
        }

        /// <summary>
        /// 組合查詢字串
        /// </summary>
        /// <param name="outputBuff">回傳的字串</param>
        /// <param name="oper">條件資訊 Ex: BT,...</param>
        /// <param name="column">欄位名稱</param>
        /// <param name="var1">欄位值1</param>
        /// <param name="var2">欄位值2</param>
        protected void ProcessQueryCondition(StringBuilder outputBuff, string oper, string column, string var1, string var2)
        {
            DBUtil.ProcessQueryCondition(outputBuff, oper, column, var1, var2);
        }

        /// <summary>
        /// 處理 Or 的條件
        /// </summary>
        /// <param name="outputBuff">Me.TmpCondition</param>
        /// <param name="currCondition">tmpBuff</param>
        protected void ProcessQueryOrCondition(StringBuilder outputBuff, StringBuilder currCondition)
        {
            DBUtil.ProcessQueryOrCondition(outputBuff, currCondition);
        }

        /// <summary>
        /// 處理查詢條件
        /// </summary>
        /// <param name="cond">查詢條件</param>
        /// <returns>查詢條件</returns>
        public string ProcessCondition(string cond)
        {
            return DBUtil.ProcessCondition(cond);
        }
        #endregion

        #region 結構
        #region GridEvent Grid 事件結構
        /// <summary>
        /// Grid 事件結構
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

            /// <summary>是否可改變欄位大小</summary>
            public bool IsColumnReSize
            {
                get { return (bool)this.PropertyMap["IsColumnReSize"]; }
                set { this.PropertyMap["IsColumnReSize"] = value; }
            }

            /// <summary>是否包含欄位篩選功能</summary>
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