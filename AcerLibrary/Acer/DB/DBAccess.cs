// 2017-07-05 Steven  Execute(), ExecuteParam() �W�[ CommandTimeout ���]�w
// 2017-12-27 Tim Add Guardium �ʱ�
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
    /// ��Ʈw�򥻾ާ@, �]�A insert, delete, update...
    /// </summary>
    public class DBAccess
    {
        #region �ݩ�
        private Hashtable pPropertyMap = new Hashtable();

        private Hashtable PropertyMap
        {
            get { return this.pPropertyMap; }
        }

        /// <summary>�]�w MyLogger ����</summary>
        private MyLogger Logger
        {
            get { return this.LogUtil.Logger; }
        }

        /// <summary>�s�u�W��</summary>
        public string ConnectionName
        {
            get { return (string)this.PropertyMap["ConnectionName"]; }
            set { this.PropertyMap["ConnectionName"] = value; }
        }

        /// <summary>�]�w LogUtil ����</summary>
        private LogUtil LogUtil
        {
            get { return (LogUtil)this.PropertyMap["LogUtil"]; }
            set { this.PropertyMap["LogUtil"] = value; }
        }

        /// <summary>�]�w DbConnection ����</summary>
        private DbConnection DbConnection
        {
            get { return (DbConnection)this.PropertyMap["DbConnection"]; }
            set { this.PropertyMap["DbConnection"] = value; }
        }

        /// <summary>�]�w DbTransaction ����</summary>
        private DbTransaction DbTransaction
        {
            get { return (DbTransaction)this.PropertyMap["DbTransaction"]; }
            set { this.PropertyMap["DbTransaction"] = value; }
        }

        /// <summary>�]�w DbCommand ����</summary>
        private DbCommand DbCommand
        {
            get { return (DbCommand)this.PropertyMap["DbCommand"]; }
            set { this.PropertyMap["DbCommand"] = value; }
        }

        /// <summary>�O�_��ڰ���</summary>
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

        /// <summary>�]�w�O�_�n�O log, �j�q�B�z��ĳ���ϥ�</summary>
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

        /// <summary>�]�w�O�_�n�P�_�֨�</summary>
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

        /// <summary>�]�w ExecuteSql</summary>
        private string ExecuteSql
        {
            get { return (string)this.PropertyMap["ExecuteSql"]; }
            set { this.PropertyMap["ExecuteSql"] = value; }
        }

        /// <summary>�]�w TableName</summary>
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
        /// Constructs, �]�t Transaction
        /// </summary>
        /// <param name="conn">DbConnection</param>
        /// <param name="trans">DbTransaction</param>
        /// <param name="logUtil">MyLogger</param>
        /// <param name="provider">�s�u��T</param>
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
        /// Constructs, ���]�t Transaction
        /// </summary>
        /// <param name="conn">DbConnection</param>
        /// <param name="logUtil">MyLogger</param>
        /// <param name="provider">�s�u��T</param>
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
        /// �]�w���s�W, �ק�, �ΧR���� Table name
        /// ���e�H�I�s�L�i�K�A�I�s�~��ϥΦP�@ Table
        /// </summary>
        /// <param name="TableName">��ƪ�W��</param>
        public void SetTableName(string TableName)
        {
            if (this.Columns != null)
                this.Columns.Clear();

            this.TableName = TableName;
        }

        /// <summary>
        /// �]�w����s�����P��
        /// </summary>
        /// <param name="columnName">���W��</param>
        /// <param name="value">����</param>
        public void SetColumn(string columnName, Object value)
        {
            this.Columns[columnName] = "'" + value.ToString() + "'";
        }

        /// <summary>
        /// �]�w����s�����P��
        /// </summary>
        /// <param name="columnName">���W��</param>
        /// <param name="value">����</param>
        /// <param name="compute">true/false -- ��J�����ȬO�_�� db �p�⤧ function</param>
        public void SetColumn(string columnName, Object value, Boolean compute)
        {
            if (compute)
                this.Columns[columnName] = value;
            else
                this.Columns[columnName] = "'" + value.ToString() + "'";
        }

        /// <summary>
        /// �]�w����s�����(Clob)�P��
        /// </summary>
        /// <param name="columnName">���W��</param>
        /// <param name="value">����</param>
        public void SetClobColumn(string columnName, Object value)
        {
            SetColumn(columnName, value);
        }

        /// <summary>
        /// �s�W�@�����
        /// </summary>
        public void Insert()
        {
            InsertNormal();
        }

        /// <summary>
        /// �̶ǤJ�������s�@���Φh�����
        /// </summary>
        /// <param name="conditions">WHERE ����, �p COLUMN1 =  '001'</param>
        /// <returns>	�w��s����Ƶ���</returns>
        public int Update(string conditions)
        {
            return UpdateNormal(conditions);
        }

        /// <summary>
        /// �̶ǤJ������R���@���Φh�����
        /// </summary>
        /// <param name="conditions">WHERE����, �pCOLUMN1=  '001'</param>
        /// <returns>�w�R������Ƶ���</returns>
        public int Delete(string conditions)
        {

            try
            {
                string[] tableList = APConfig.GetProperty("LOG_TABLE").Split(',');

                for (int idx = 0; idx < tableList.Length; idx += 2)
                {
                    //���� Table �h�ۨ�t�~�� Table
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
        /// �ǤJ sql ���� db �B�z(insert, delete, update)
        /// TableName �O�d, ����T�M��
        /// </summary>
        /// <param name="sql">�����檺 SQL</param>
        /// <param name="nameAry">�ѼƦW�ٰ}�C</param>
        /// <param name="valAry">�ѼƭȰ}�C</param>
        /// <returns>�B�z���G����</returns>
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
                //Guardium Start �}�l
                sqlGuard = GetGuardiumStartString();
                if (sqlGuard.Length > 0) {
                    this.DbCommand.CommandText = sqlGuard;
                    this.DbCommand.ExecuteNonQuery();
                }
                //Guardium Start ����
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

                //2017-07-05 Steven �K�[ timeout �Ѽ�
                this.DbCommand.CommandTimeout = int.Parse(APConfig.GetProperty("SQL_TIMEOUT", "30"));

                int execCount = this.DbCommand.ExecuteNonQuery();

                long endTime = DateUtil.GetCurrTimeMillis();
                if (this.IsLog && this.Logger.IsLog)
                    this.Logger.Append("����ɶ��G" + System.Convert.ToString(endTime - startTime) + " ms, �v�T����:" + execCount);

                //=== ��ݭn�ˬd�֨��ɤ~�B�z ===
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
                    //Guardium End�}�l                
                    sqlGuard = GetGuardiumEndString();
                    this.DbCommand.CommandText = sqlGuard;
                    this.DbCommand.ExecuteNonQuery();
                    //Guardium End����
                }
            }

        }

        /// <summary>
        /// �ǤJ sql ���� db �B�z(insert, delete, update)
        /// TableName �O�d, ����T�M��
        /// </summary>
        /// <param name="sql">�����檺 SQL</param>
        /// <returns>�B�z���G����</returns>
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
                    //2017-07-05 Steven �K�[ timeout �Ѽ�
                    this.DbCommand.CommandTimeout = int.Parse(APConfig.GetProperty("SQL_TIMEOUT", "30"));

                    int execCount = this.DbCommand.ExecuteNonQuery();

                    long endTime = DateUtil.GetCurrTimeMillis();
                    if (this.IsLog && this.Logger.IsLog)
                        this.Logger.Append("����ɶ��G" + System.Convert.ToString(endTime - startTime) + " ms, �v�T����:" + execCount);

                    //=== ��ݭn�ˬd�֨��ɤ~�B�z ===
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
        /// SQL Server �j�q�s�W
        /// </summary>
        /// <param name="dt">�n�j�q�s�W�� DataTable</param>
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
                this.Logger.Append("TABLE:" + dt.TableName + " SqlBulryInsert ����ɶ��G" + timer.GetDiffTime() + " ms, ���ʵ���:" + dt.Rows.Count);

        }

        /// <summary>
        /// ���o���檺 sql ���O, ���o�ɾ� - ��ƳB�z����
        /// </summary>
        /// <returns></returns>
        public string GetSql()
        {
            return this.ExecuteSql;
        }

        /// <summary>
        /// �զ� Insert SQL �ð���
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

            //2011/08/05 nono add for �F�d�ϥ�
            try
            {
                string[] tableList = APConfig.GetProperty("LOG_TABLE").Split(',');

                for (int idx = 0; idx < tableList.Length; idx += 2)
                {
                    //���� Table �h�ۨ�t�~�� Table
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
                        //�W�[�����
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
        /// �զ� Update SQL �ð���
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

            //2011/08/05 nono add for �F�d�ϥ�
            try
            {
                string[] tableList = APConfig.GetProperty("LOG_TABLE").Split(',');

                for (int idx = 0; idx < tableList.Length; idx += 2)
                {
                    //���� Table �h�ۨ�t�~�� Table
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
        /// For NCC �ϥ� �إ�Guardium Start�r��
        /// </summary>
        /// <returns></returns>
        private string GetGuardiumStartString()
        {
            //�w�]����NCCEXT
            string sGuardAppEventType = APConfig.GetProperty("sGuardAppEventType");
            string sessionName = APConfig.GetProperty("VALIDE_SESSION_NAME");
            string sessionLocalIPName = APConfig.GetProperty("SESSION_LOCAL_IP_NAME");

            //HttpContext.Current
            //�W�[Guardium Start
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
            string sGuardAppEventStrValue = request.Url.AbsolutePath;  //�@�~ AMAT0031
            string sName = new System.Diagnostics.StackTrace(true).GetFrame(0).GetMethod().Name;
            sqlGuard = "select 'GuardAppEvent:Start'"
                + ",'GuardAppEventType:" + session[sessionLocalIPName] + "' "
                + ",'GuardAppEventUserName:" + Utility.DBStr(sGuardAppEventUserName) + "' "
                + ",'GuardAppEventStrValue:" + sGuardAppEventType + "-" + sGuardAppEventStrValue + " " + sName + "'; ";
            return sqlGuard;
        }

        /// <summary>
        /// For NCC �ϥ� 
        /// </summary>
        /// <returns></returns>
        private string GetGuardiumEndString()
        {
            string sqlGuard = "select 'GuardAppEvent:Released'";
            return sqlGuard;
        }
    }
}
