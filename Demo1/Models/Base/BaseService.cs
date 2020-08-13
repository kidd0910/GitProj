using Acer.DB;
using Acer.Log;
using Acer.Util;
using Demo1.Models.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo1.Models.Services
{
    public class BaseService
    {
        protected IBaseInit _baseInit { get; set; }

        protected BaseService(IBaseInit _baseInit)
        {
            this.LogUtil = new LogUtil("");
            this.DBUtil = new DBUtil(this.LogUtil);
        }

        protected void WriteLogMehtodStart(string mehtodName)
        {
            this.LogUtil.MethodStart(mehtodName);
        }
        protected void WriteLogMehtodEnd(string mehtodName)
        {
            this.LogUtil.MethodEnd(mehtodName);
            this.LogUtil.DoLog();
        }

        protected void WriteLog(string msg)
        {
            this.LogUtil.Logger.Append(msg);
            //this.LogUtil.DoLog();
        }

        #region PropertyMap 取得屬性
        private Hashtable pPropertyMap = new Hashtable();

        /// <summary>取得屬性</summary>
        protected Hashtable PropertyMap
        {
            get { return (Hashtable)this.pPropertyMap; }
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

        #region Logger 讀取 Log 物件
        /// <summary>Logger 讀取 Log 物件</summary>
        protected MyLogger Logger
        {
            get { return this.LogUtil.Logger; }
        }
        #endregion
    }
}