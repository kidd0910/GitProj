using System;
using System.Collections;
using System.Text;
using System.Data.Common;
using Acer.Form;
using Acer.Log;
using Acer.DB;
using Acer.Apps;
using Acer.Util;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Acer.Base
{
    /// <summary>
    /// Control 繼承元件, 初使化 UI 元件
    /// </summary>
    public class UserControlBase : UserControl
    {
        #region 屬性
        private Hashtable pPropertyMap = new Hashtable();

        #region PropertyMap 取得屬性
        /// <summary>取得屬性</summary>
        public Hashtable PropertyMap
        {
            get { return (Hashtable)this.pPropertyMap; }
        }
        #endregion

        #region DBManager 設定 DBManager 物件
        /// <summary>設定 DBManager 物件</summary>
        public DBManager DBManager
        {
            get { return (DBManager)this.PropertyMap["DBManager"]; }
            set { this.PropertyMap["DBManager"] = value; }
        }
        #endregion

        #region JScript 設定 JScript 物件
        /// <summary>設定 JScript 物件</summary>
        public JScript JScript
        {
            get { return (JScript)this.PropertyMap["JScript"]; }
            set { this.PropertyMap["JScript"] = value; }
        }
        #endregion

        #region Logger 讀取 Log 物件
        /// <summary>Logger 讀取 Log 物件</summary>
        protected MyLogger Logger
        {
            get { return this.LogUtil.Logger; }
        }
        #endregion

        #region DBUtil 設定 DBUtil 物件
        /// <summary>DBUtil 設定 DBUtil 物件</summary>
        private DBUtil DBUtil
        {
            get { return (DBUtil)this.PropertyMap["DBUtil"]; }
            set { this.PropertyMap["DBUtil"] = value; }
        }
        #endregion

        #region LogUtil 設定 LogUtil 物件
        /// <summary>設定 LogUtil 物件</summary>
        public LogUtil LogUtil
        {
            get { return (LogUtil)this.PropertyMap["LogUtil"]; }
            set { this.PropertyMap["LogUtil"] = value; }
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
        #endregion

        #region 事件
        //#region 頁面載入事件
        //#region OnInit
        ///// <summary>
        ///// 頁面載入事件
        ///// </summary>
        ///// <param name="e"></param>
        //protected override void OnInit(EventArgs e)
        //{
        //    //=== 起始物件 ===
        //    this.LogUtil = new LogUtil("");
        //    this.DBUtil = new DBUtil(this.LogUtil);
        //    this.LangUtil = new LangUtil(this.Logger, this.DBManager);
        //}
        //#endregion
        //#endregion
        #endregion

        #region 方法
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

        #region DataGrid Binding
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
            //BindMLProperty(row);

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
        #endregion

        #region 資料庫存取
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
        #endregion
        #endregion
    }
}