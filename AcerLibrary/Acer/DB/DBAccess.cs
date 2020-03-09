// 2017-07-05 Steven  Execute(), ExecuteParam() 增加 CommandTimeout 的設定
// 2017-12-27 Tim Add Guardium 監控
//
using System;
using System.Data.OleDb;
using System.Data.Common;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Acer.Log;
using Acer.Apps;
using Acer.Util;
using Acer.Form;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace Acer.DB
{
    /// <summary>
    /// 資料庫基本操作, 包括 insert, delete, update...
    /// </summary>
    public class DBAccess
    {
        #region 屬性
        private Hashtable pPropertyMap = new Hashtable();

        private Hashtable PropertyMap
        {
            get { return this.pPropertyMap; }
        }

        /// <summary>設定 MyLogger 物件</summary>
        private MyLogger Logger
        {
            get { return this.LogUtil.Logger; }
        }

        /// <summary>連線名稱</summary>
        public string ConnectionName
        {
            get { return (string)this.PropertyMap["ConnectionName"]; }
            set { this.PropertyMap["ConnectionName"] = value; }
        }

        /// <summary>設定 LogUtil 物件</summary>
        private LogUtil LogUtil
        {
            get { return (LogUtil)this.PropertyMap["LogUtil"]; }
            set { this.PropertyMap["LogUtil"] = value; }
        }

        /// <summary>設定 DbConnection 物件</summary>
        private DbConnection DbConnection
        {
            get { return (DbConnection)this.PropertyMap["DbConnection"]; }
            set { this.PropertyMap["DbConnection"] = value; }
        }

        /// <summary>設定 DbTransaction 物件</summary>
        private DbTransaction DbTransaction
        {
            get { return (DbTransaction)this.PropertyMap["DbTransaction"]; }
            set { this.PropertyMap["DbTransaction"] = value; }
        }

        /// <summary>設定 DbCommand 物件</summary>
        private DbCommand DbCommand
        {
            get { return (DbCommand)this.PropertyMap["DbCommand"]; }
            set { this.PropertyMap["DbCommand"] = value; }
        }

        /// <summary>是否實際執行</summary>
        public bool IsRealAction
        {
            get
            {
                if (this.PropertyMap["IsRealAction"] == null)
                    return true;
                else
                    return (bool)this.PropertyMap["IsRealAction"];
            }
            set { this.PropertyMap["IsRealAction"] = value; }
        }

        /// <summary>設定是否要記 log, 大量處理建議不使用</summary>
        public bool IsLog
        {
            get
            {
                if (this.PropertyMap["IsLog"] == null)
                    return true;
                else
                    return (bool)this.PropertyMap["IsLog"];
            }
            set { this.PropertyMap["IsLog"] = value; }
        }

        /// <summary>設定是否要判斷快取</summary>
        public bool IsNeedCheckCache
        {
            get
            {
                if (this.PropertyMap["IsNeedCheckCache"] == null)
                    return true;
                else
                    return (bool)this.PropertyMap["IsNeedCheckCache"];
            }
            set { this.PropertyMap["IsNeedCheckCache"] = value; }
        }

        /// <summary>Provider</summary>
        private string Provider
        {
            get { return (string)this.PropertyMap["Provider"]; }
            set { this.PropertyMap["Provider"] = value; }
        }

        /// <summary>Provider</summary>
        public string Hint
        {
            get { return (string)this.PropertyMap["Hint"]; }
            set { this.PropertyMap["Hint"] = value + " "; }
        }

        /// <summary>設定 ExecuteSql</summary>
        private string ExecuteSql
        {
            get { return (string)this.PropertyMap["ExecuteSql"]; }
            set { this.PropertyMap["ExecuteSql"] = value; }
        }

        /// <summary>設定 TableName</summary>
        private string TableName
        {
            get { return (string)this.PropertyMap["TableName"]; }
            set { this.PropertyMap["TableName"] = value; }
        }

        private Hashtable Columns
        {
            get { return (Hashtable)this.PropertyMap["Columns"]; }
            set { this.PropertyMap["Columns"] = value; }
        }
        #endregion

        #region Constructs DBAccess
        /// <summary>
        /// Constructs, 包含 Transaction
        /// </summary>
        /// <param name="conn">DbConnection</param>
        /// <param name="trans">DbTransaction</param>
        /// <param name="logUtil">MyLogger</param>
        /// <param name="provider">連線資訊</param>
        public DBAccess(DbConnection conn, DbTransaction trans, LogUtil logUtil, string provider)
        {
            this.DbConnection = conn;
            this.DbTransaction = trans;
            this.LogUtil = logUtil;
            this.Columns = new Hashtable();
            this.DbCommand = DBFactory.GetIDBCommand(provider);
            this.DbCommand.Connection = conn;
            this.DbCommand.Transaction = this.DbTransaction;
            this.Provider = provider;
        }

        /// <summary>
        /// Constructs, 不包含 Transaction
        /// </summary>
        /// <param name="conn">DbConnection</param>
        /// <param name="logUtil">MyLogger</param>
        /// <param name="provider">連線資訊</param>
        public DBAccess(DbConnection conn, LogUtil logUtil, string provider)
        {
            this.DbConnection = conn;
            this.LogUtil = logUtil;
            this.Columns = new Hashtable();
            this.DbCommand = DBFactory.GetIDBCommand(provider);
            this.DbCommand.Connection = this.DbConnection;
            this.Provider = provider;
        }
        #endregion

        /// <summary>
        /// 設定欲新增, 修改, 或刪除之 Table name
        /// 先前以呼叫過可免再呼叫繼續使用同一 Table
        /// </summary>
        /// <param name="TableName">資料表名稱</param>
        public void SetTableName(string TableName)
        {
            if (this.Columns != null)
                this.Columns.Clear();

            this.TableName = TableName;
        }

        /// <summary>
        /// 設定欲更新之欄位與值
        /// </summary>
        /// <param name="columnName">欄位名稱</param>
        /// <param name="value">欄位值</param>
        public void SetColumn(string columnName, Object value)
        {
            this.Columns[columnName] = "'" + value.ToString() + "'";
        }

        /// <summary>
        /// 設定欲更新之欄位與值
        /// </summary>
        /// <param name="columnName">欄位名稱</param>
        /// <param name="value">欄位值</param>
        /// <param name="compute">true/false -- 輸入之欄位值是否為 db 計算之 function</param>
        public void SetColumn(string columnName, Object value, Boolean compute)
        {
            if (compute)
                this.Columns[columnName] = value;
            else
                this.Columns[columnName] = "'" + value.ToString() + "'";
        }

        /// <summary>
        /// 設定欲更新之欄位(Clob)與值
        /// </summary>
        /// <param name="columnName">欄位名稱</param>
        /// <param name="value">欄位值</param>
        public void SetClobColumn(string columnName, Object value)
        {
            SetColumn(columnName, value);
        }

        /// <summary>
        /// 新增一筆資料
        /// </summary>
        public void Insert()
        {
            InsertNormal();
        }

        /// <summary>
        /// 依傳入之條件更新一筆或多筆資料
        /// </summary>
        /// <param name="conditions">WHERE 條件, 如 COLUMN1 =  '001'</param>
        /// <returns>	已更新之資料筆數</returns>
        public int Update(string conditions)
        {
            return UpdateNormal(conditions);
        }

        /// <summary>
        /// 依傳入之條件刪除一筆或多筆資料
        /// </summary>
        /// <param name="conditions">WHERE條件, 如COLUMN1=  '001'</param>
        /// <returns>已刪除之資料筆數</returns>
        public int Delete(string conditions)
        {

            try
            {
                string[] tableList = APConfig.GetProperty("LOG_TABLE").Split(',');

                for (int idx = 0; idx < tableList.Length; idx += 2)
                {
                    //當為該 Table 則抄到另外的 Table
                    if (this.TableName.ToUpper().Contains(tableList[idx].Trim().ToUpper()))
                    {
                        this.Execute("INSERT INTO " + tableList[idx + 1] + " SELECT A.*, 'D' FROM " + this.TableName + " A WHERE " + conditions);
                        this.Execute("UPDATE " + tableList[idx + 1] + " SET UPDATE_USER = '" + FormUtil.Session["LOGIN_ACNT"] + "',UPDATE_TIME = '" + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "' WHERE LOG_ACTIVE = 'D' AND " + conditions);
                    }
                }
            }
            catch (Exception) { }

            string sql = "DELETE " + this.Hint + "FROM " + this.TableName;

            if (!string.IsNullOrEmpty(conditions.Trim()))
                sql = sql + " WHERE " + conditions;

            return this.Execute(sql);
        }

        private String GetPageName()
        {
            if (HttpContext.Current != null)
                return "--" + FormUtil.Request.ServerVariables["LOCAL_ADDR"] + " " + FormUtil.Request.FilePath;
            else
                return "";
        }

        /// <summary>
        /// 傳入 sql 執行 db 處理(insert, delete, update)
        /// TableName 保留, 欄位資訊清除
        /// </summary>
        /// <param name="sql">欲執行的 SQL</param>
        /// <param name="nameAry">參數名稱陣列</param>
        /// <param name="valAry">參數值陣列</param>
        /// <returns>處理結果筆數</returns>
        public int ExecuteParam(string sql, string[] nameAry, string[] valAry)
        {

            bool isUseGuard = false;
            string sqlGuard = "";
            try
            {
                if (!string.IsNullOrEmpty(APConfig.GetProperty("IsUseGuard")))
                {
                    if (APConfig.GetProperty("IsUseGuard") == "Y")
                        isUseGuard = true;
                }
            }
            catch { }

            if (isUseGuard)
            {                
                //Guardium Start 開始
                sqlGuard = GetGuardiumStartString();
                if (sqlGuard.Length > 0) {
                    this.DbCommand.CommandText = sqlGuard;
                    this.DbCommand.ExecuteNonQuery();
                }
                //Guardium Start 結束
            }

            try
            {
                sql = sql + GetPageName();

                this.ExecuteSql = sql;

                //=== Log SQL ===
                if (this.IsLog && this.Logger.IsLog)
                    this.Logger.Append(APConfig.GetProperty("SQLMARK") + sql);

                long startTime = DateUtil.GetCurrTimeMillis();

                this.DbCommand.CommandText = sql;

                for (int i = 0; i < nameAry.Length; i++)
                {
                    this.Logger.Append("Params [" + nameAry[i] + "] ==> " + valAry[i]);
                    this.DbCommand.Parameters.Add(new System.Data.OracleClient.OracleParameter(nameAry[i], valAry[i]));
                }

                //2017-07-05 Steven 添加 timeout 參數
                this.DbCommand.CommandTimeout = int.Parse(APConfig.GetProperty("SQL_TIMEOUT", "30"));

                int execCount = this.DbCommand.ExecuteNonQuery();

                long endTime = DateUtil.GetCurrTimeMillis();
                if (this.IsLog && this.Logger.IsLog)
                    this.Logger.Append("執行時間：" + System.Convert.ToString(endTime - startTime) + " ms, 影響筆數:" + execCount);

                //=== 當需要檢查快取時才處理 ===
                if (this.IsNeedCheckCache)
                {
                    CacheProcess.ProcessCacheForExecuteSQL(sql, this.DbConnection, this.DbTransaction, this.Provider);

                }

                this.DbCommand.Parameters.Clear();

                return execCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (isUseGuard)
                {
                    //Guardium End開始                
                    sqlGuard = GetGuardiumEndString();
                    this.DbCommand.CommandText = sqlGuard;
                    this.DbCommand.ExecuteNonQuery();
                    //Guardium End結束
                }
            }

        }

        /// <summary>
        /// 傳入 sql 執行 db 處理(insert, delete, update)
        /// TableName 保留, 欄位資訊清除
        /// </summary>
        /// <param name="sql">欲執行的 SQL</param>
        /// <returns>處理結果筆數</returns>
        public int Execute(string sql)
        {
            bool isUseGuard = false;
            string sqlGuard = "";
            try
            {
                if (!string.IsNullOrEmpty(APConfig.GetProperty("IsUseGuard")))
                {
                    if (APConfig.GetProperty("IsUseGuard") == "Y")
                        isUseGuard = true;
                }
            }
            catch { }

            if (isUseGuard)
            {

                sqlGuard = GetGuardiumStartString();
                if (sqlGuard.Length > 0) {
                    this.DbCommand.CommandText = sqlGuard;
                    this.DbCommand.ExecuteNonQuery();
                }
            }

            try
            {

                if (this.IsRealAction)
                    sql = sql + GetPageName();

                this.ExecuteSql = sql;

                if (this.IsRealAction)
                {
                    //=== Log SQL ===
                    if (this.IsLog && this.Logger.IsLog)
                        this.Logger.Append(APConfig.GetProperty("SQLMARK") + sql);

                    long startTime = DateUtil.GetCurrTimeMillis();

                    this.DbCommand.CommandText = sql;
                    //2017-07-05 Steven 添加 timeout 參數
                    this.DbCommand.CommandTimeout = int.Parse(APConfig.GetProperty("SQL_TIMEOUT", "30"));

                    int execCount = this.DbCommand.ExecuteNonQuery();

                    long endTime = DateUtil.GetCurrTimeMillis();
                    if (this.IsLog && this.Logger.IsLog)
                        this.Logger.Append("執行時間：" + System.Convert.ToString(endTime - startTime) + " ms, 影響筆數:" + execCount);

                    //=== 當需要檢查快取時才處理 ===
                    if (this.IsNeedCheckCache)
                    {
                        CacheProcess.ProcessCacheForExecuteSQL(sql, this.DbConnection, this.DbTransaction, this.Provider);
                    }

                    return execCount;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (isUseGuard)
                {

                    sqlGuard = GetGuardiumEndString();
                    this.DbCommand.CommandText = sqlGuard;
                    this.DbCommand.ExecuteNonQuery();
                }

            }

        }

        /// <summary>
        /// SQL Server 大量新增
        /// </summary>
        /// <param name="dt">要大量新增的 DataTable</param>
        public void SqlBulryInsert(DataTable dt)
        {
            Timer timer = new Timer();
            SqlBulkCopy sqlBulkCopy = new SqlBulkCopy((SqlConnection)this.DbConnection, SqlBulkCopyOptions.Default, (SqlTransaction)this.DbTransaction);
            sqlBulkCopy.DestinationTableName = dt.TableName;
            if (dt != null && dt.Rows.Count != 0)
            {
                //Brian Modify
                for (int idx = 0; idx < dt.Columns.Count; idx++)
                {
                    sqlBulkCopy.ColumnMappings.Add(dt.Columns[idx].ColumnName, dt.Columns[idx].ColumnName);
                }

                sqlBulkCopy.BulkCopyTimeout = 3000;
                sqlBulkCopy.WriteToServer(dt);
            }
            sqlBulkCopy.Close();

            if (this.IsLog && this.Logger.IsLog)
                this.Logger.Append("TABLE:" + dt.TableName + " SqlBulryInsert 執行時間：" + timer.GetDiffTime() + " ms, 異動筆數:" + dt.Rows.Count);

        }

        /// <summary>
        /// 取得執行的 sql 指令, 取得時機 - 資料處理完後
        /// </summary>
        /// <returns></returns>
        public string GetSql()
        {
            return this.ExecuteSql;
        }

        /// <summary>
        /// 組成 Insert SQL 並執行
        /// </summary>
        private void InsertNormal()
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder args = new StringBuilder();

            sql.Append("INSERT " + this.Hint + "INTO " + this.TableName.ToUpper() + "(");
            args.Append(" VALUES (");

            foreach (DictionaryEntry de in this.Columns)
            {
                sql.Append(de.Key.ToString().ToUpper() + ",");
                args.Append(de.Value.ToString() + ",");
            }
            sql.Remove(sql.Length - 1, 1).Append(")");
            args.Remove(args.Length - 1, 1).Append(")");
            sql.Append(args);
            this.Execute(sql.ToString());

            //2011/08/05 nono add for 東吳使用
            try
            {
                string[] tableList = APConfig.GetProperty("LOG_TABLE").Split(',');

                for (int idx = 0; idx < tableList.Length; idx += 2)
                {
                    //當為該 Table 則抄到另外的 Table
                    if (this.TableName.ToUpper().Contains(tableList[idx].Trim().ToUpper()))
                    {
                        sql.Length = 0;
                        args.Length = 0;

                        sql.Append("INSERT " + this.Hint + "INTO " + tableList[idx + 1] + "(");
                        args.Append(" VALUES (");

                        foreach (DictionaryEntry de in this.Columns)
                        {
                            sql.Append(de.Key.ToString().ToUpper() + ",");
                            args.Append(de.Value.ToString() + ",");
                        }
                        //增加的欄位
                        sql.Append("LOG_ACTIVE)");
                        args.Append("'I')");

                        sql.Append(args);
                        this.Execute(sql.ToString());
                    }
                }
            }
            catch (Exception) { }
        }
        /// <summary>
        /// 組成 Update SQL 並執行
        /// </summary>
        private int UpdateNormal(string conditions)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE " + this.Hint + this.TableName.ToUpper() + " SET ");

            foreach (DictionaryEntry de in this.Columns)
            {
                sql.Append(de.Key.ToString().ToUpper() + " = " + de.Value.ToString() + ",");
            }
            sql.Remove(sql.Length - 1, 1);

            if (!string.IsNullOrEmpty(conditions.Trim()))
                sql.Append(" WHERE ").Append(conditions);

            int result = this.Execute(sql.ToString().Replace(", WHERE", " WHERE "));

            //2011/08/05 nono add for 東吳使用
            try
            {
                string[] tableList = APConfig.GetProperty("LOG_TABLE").Split(',');

                for (int idx = 0; idx < tableList.Length; idx += 2)
                {
                    //當為該 Table 則抄到另外的 Table
                    if (this.TableName.ToUpper().Contains(tableList[idx].Trim().ToUpper()))
                    {
                        this.Execute("INSERT INTO " + tableList[idx + 1] + " SELECT A.*, 'U' FROM " + this.TableName + " A WHERE " + Utility.Split(conditions, "AND ROWSTAMP")[0]);
                    }
                }
            }
            catch (Exception) { }


            return result;
        }

        /// <summary>
        /// For NCC 使用 建立Guardium Start字串
        /// </summary>
        /// <returns></returns>
        private string GetGuardiumStartString()
        {
            //預設先用NCCEXT
            string sGuardAppEventType = APConfig.GetProperty("sGuardAppEventType");
            string sessionName = APConfig.GetProperty("VALIDE_SESSION_NAME");
            string sessionLocalIPName = APConfig.GetProperty("SESSION_LOCAL_IP_NAME");

            //HttpContext.Current
            //增加Guardium Start
            System.Web.HttpRequest request = Acer.Form.FormUtil.Request;
            System.Web.SessionState.HttpSessionState session = FormUtil.Session;

            if (request == null) {
                return null;
            }

            if (session == null) {
                return "";
            }

            string sqlGuard = "";
            string sGuardAppEventUserName = "";  //ex:SESSION_LOGIN_NAME
            if (session[sessionName] != null)
            {
                sGuardAppEventUserName = session[sessionName].ToString();
            }
            string sGuardAppEventStrValue = request.Url.AbsolutePath;  //作業 AMAT0031
            string sName = new System.Diagnostics.StackTrace(true).GetFrame(0).GetMethod().Name;
            sqlGuard = "select 'GuardAppEvent:Start'"
                + ",'GuardAppEventType:" + session[sessionLocalIPName] + "' "
                + ",'GuardAppEventUserName:" + Utility.DBStr(sGuardAppEventUserName) + "' "
                + ",'GuardAppEventStrValue:" + sGuardAppEventType + "-" + sGuardAppEventStrValue + " " + sName + "'; ";
            return sqlGuard;
        }

        /// <summary>
        /// For NCC 使用 
        /// </summary>
        /// <returns></returns>
        private string GetGuardiumEndString()
        {
            string sqlGuard = "select 'GuardAppEvent:Released'";
            return sqlGuard;
        }
    }
}
