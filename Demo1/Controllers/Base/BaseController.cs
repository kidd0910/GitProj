using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo1.Models.Base;
using System.Web.UI;
using Acer.Util;
using Acer.Form;
using Acer.Log;
using Acer.DB;
using Acer.Apps;
using System.Reflection;
using Acer.Err;

namespace Demo1.Controllers
{
    public class BaseController : Controller
    {
        protected IBaseInit _baseInit;

        public BaseController()
        {
            _baseInit = DependencyResolver.Current.GetService<IBaseInit>();

            this.LogUtil = new LogUtil("");                    
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            DoPreInit();
            DoOnload();
            DoOnPreRender();

            this.LogUtil.MethodEnd(MethodBase.GetCurrentMethod().Name);
            
            this.LogUtil.Logger.Append(filterContext.Controller.ToString());

            this.LogUtil.MethodEnd(MethodBase.GetCurrentMethod().Name);
        }

        private void WriteLog(string msg)
        {            
            this.LogUtil.Logger.Append(msg);         

            this.LogUtil.DoLog();
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //var message = new StringBuilder();
            //message.Append("----------");
            //message.Append("[end]");
            //message.Append("[" + DateTimeUtil.GetNowCDate() + " " + DateTimeUtil.GetNowTime() + "]");
            //message.Append("----------");
            //WriteLog(message.ToString());


            this.LogUtil.MethodStart(MethodBase.GetCurrentMethod().Name);

            this.LogUtil.MethodEnd(MethodBase.GetCurrentMethod().Name);

            this.LogUtil.DoLog();
        }        

        protected override void OnException(ExceptionContext filterContext)
        {
            //var message = filterContext.Exception.ToString();
            //WriteErrorLog(message);
            //ViewData["Message"] = message;
            //Response.StatusCode = 500;
            //filterContext.ExceptionHandled = true;
            //filterContext.Result = View("~/Views/Shared/Error.cshtml");
            ////WriteLog("OnException");
            ///            

            this.LogUtil.Logger.Append("*** OnException ***");
            this.LogUtil.Logger.Append(filterContext.Exception.ToString());

            this.LogUtil.DoLog();
        }

      

        #region Private Function        
        private void DoPreInit()
        {
            //=== 清除 Cache ===
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

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

            //=== 起始物件 === Begin
            //this.LogUtil = new LogUtil("");

            this.DBUtil = new DBUtil(this.LogUtil);

            this.LangUtil = new LangUtil(this.Logger, this.DBManager);

            this.LogUtil.TraceStart(MethodBase.GetCurrentMethod().Name);

            this.JScript = new JScript(this.Logger);
            //=== 起始物件 === End

            this.LogUtil.TraceEnd(MethodBase.GetCurrentMethod().Name);

        }

        private void DoOnload()
        {
            //=== 設定是否 Log ===
            this.LogUtil.IsLog = this.IsLog;
            this.Logger.IsLog = this.IsLog;
            try
            {
                this.LogUtil.TraceStart(MethodBase.GetCurrentMethod().Name);

                //this.HasForm = FormUtil.CheckControlByType(this, "System.Web.UI.HtmlControls.HtmlForm");

                //if (this.HasForm)
                //{
                //    //=== 判斷是否 Ajax ===
                //    this.ScriptManager = (ScriptManager)FormUtil.FindControlByType(this, "ScriptManager");
                //    this.IsAjax = (bool)(this.ScriptManager != null);
                //}

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
                        //if (this.IsAjax)
                        //{
                        //    throw new Acer.Err.SessionTimeoutException("Timeout");
                        //}
                        //else
                        //{
                        //    //System.Web.Security.FormsAuthentication.SignOut();
                        //    Response.Clear();
                        //    //Response.Write("<script>alert('使用時間逾時,系統已將您自動登出,請再重新登入使用本系統');top.location.href='" + Application["vr"] + "logout.aspx';</script>");
                        //    Response.Write("<script>alert('使用時間逾時,系統已將您自動登出,請再重新登入使用本系統');</script>");
                        //    Response.End();
                        //    return;
                        //}
                    }
                }

                ////=== 初始化使用者控制項 ===
                //ArrayList userControls = new ArrayList();
                //FormUtil.FindUserControls(this, userControls);
                //for (int i = 0; i < userControls.Count; i++)
                //{
                //    this.PrepareUserControl((UserControlBase)userControls[i]);
                //}

                ////=== 抓取符合命名的控制項 Ex: Q_, M_, X_... ===
                //FormUtil.FindUIDDControls(this, this.ddUserControls);

                ////=== 設定語系 ===
                //if (Session["Language"] == null)
                //    Session["Language"] = "ZH-TW";

                //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Session["Language"].ToString());
                //Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Session["Language"].ToString());

                //if (!this.IsPostBack)
                //{

                //    //=== 多國語系 Js 使用 ===
                //    if (!Session["Language"].ToString().Equals("ZH-TW"))
                //        this.JScript.Script = "try{doImport ('MessageContent_" + Session["Language"].ToString().Replace("-", "_") + ".js');}catch(ex){}";

                //    this.JScript.Script = "var lang	=	'" + Session["Language"].ToString().Replace("-", "_") + "'";
                //    this.JScript.Script = "try{if (getTop().columnFilterRecord == null)getTop().columnFilterRecord={};}catch(ex){}";

                //    //=== 初始化資料字典欄位設定 ===
                //    BindDDProperty();

                //    //=== 初始化資料欄位設定 ===
                //    BindColumnFieldProperty();

                //    //=== 初始化多國語系資料 ===
                //    BindMLProperty(this);

                //    //=== 更改按鈕名稱 ===
                //    string langType = Thread.CurrentThread.CurrentUICulture.ToString().ToUpper();

                //    //=== 判斷功能權限 ===
                //    ProcessPermission();
                //}

                ////=== nono 2009/03/25 add 避免 keepSession 或是需常重整的程式不斷抓取 ===
                //if (this.HasColumnFilter)
                //{
                //    //=== 初始化欄位篩選設定 ===
                //    ColumnFilterInit();
                //}

                ////=== 處理 SQLInjection 置換動作 ===
                //FormUtil.ProcessSQLInjection(this, true);

                //this.HasLoad = true;

                //base.OnLoad(e);
            }
            finally
            {
                this.LogUtil.TraceEnd(MethodBase.GetCurrentMethod().Name);
            }
        }

        private void DoOnPreRender()
        {
            try
            {
                this.LogUtil.TraceStart(MethodBase.GetCurrentMethod().Name);

                // 2011/09/22 nono add for check security
                ArrayList noeditControls = new ArrayList();
                //FormUtil.FindNoEditControls(this, noeditControls);
                Control tmpControl;
                Hashtable dataMap = new Hashtable();
                for (int i = 0; i < noeditControls.Count; i++)
                {
                    tmpControl = (Control)noeditControls[i];
                    dataMap[tmpControl.ID] = FormUtil.GetControlValue(tmpControl);
                    this.Logger.Append(tmpControl.ID + ":" + dataMap[tmpControl.ID]);
                }
                //ViewState["NoEditData"] = dataMap;

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
                            //PageBase.AjaxErrLog = this.JScript.Script;
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(this.JScript.Script))
                                ErrUtil.HandlePageError(this.Exception);
                            else
                            {
                                //PageBase.AjaxErrLog = this.JScript.Script;
                            }
                        }

                        //if (!this.IsPostBack)
                        //    Response.Write("<script src='" + Application["vr"] + "script/jquery-1.8.3.min.js'></script>" +
                        //            "<script src='" + Application["vr"] + "script/Base.js'></script>" +
                        //            "<script>var _vp = '" + Application["vr"] + "';" +
                        //            "doImport('WindowUtil.js,Message.js,Form.js');" +
                        //            this.JScript.Script + "</script>");
                    }
                    else
                    {
                        //this.JScript.ExecAjaxClientScript(this);
                    }
                }
                else
                {
                    if (this.HasError)
                    {
                        ErrUtil.HandlePageError(this.Exception);
                    }
                    else
                    {
                        //this.JScript.ExecClientScript(this);
                    }
                }

                if (this.IsDoIOLog)
                    this.LogUtil.DoLog();
                else if (this.HasError)
                    this.LogUtil.DoLog();

            }
            finally
            {
                this.LogUtil.TraceEnd(MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region 屬性
        private Hashtable pPropertyMap = new Hashtable();

        #region CommonUIMap 取得 CommonUI屬性
        /// <summary>取得屬性</summary>
        //protected Hashtable CommonUIMap
        //{
        //    //get
        //    //{
        //    //    //if (this.ViewState["pCommonUIMap"] == null)
        //    //    //    this.ViewState["pCommonUIMap"] = new Hashtable();

        //    //    //return (Hashtable)this.ViewState["pCommonUIMap"];
        //    //}
        //}
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
                Hashtable errMap = Acer.Util.MultiProcess.ChoiceHashtable(MultiProcess.GetRealGlobalValue("AJAX_ERROR"));
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

    }
}