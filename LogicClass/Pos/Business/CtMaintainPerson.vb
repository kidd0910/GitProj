'----------------------------------------------------------------------------------
'File Name		: CtMaintainPerson 
'Author			: 
'Description		: CtMaintainPerson 維護人員Ct
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2013/08/27	   	Source Create
'----------------------------------------------------------------------------------

Imports POS.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase

Namespace Pos.Business
    ''' <summary>
    ''' CtMaintainPerson 維護人員Ct
    ''' </summary>
    Partial Public Class CtMaintainPerson
        Inherits Acer.Base.ControlBase

#Region "屬性"
#Region "ACNT 帳號"
        ''' <summary>
        ''' ACNT 帳號
        ''' </summary>
        Public Property ACNT As String
            Get
                Return Me.PropertyMap("ACNT")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ACNT") = value
            End Set
        End Property
#End Region

#Region "CH_NAME 中文姓名"
        ''' <summary>
        ''' CH_NAME 中文姓名
        ''' </summary>
        Public Property CH_NAME As String
            Get
                Return Me.PropertyMap("CH_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CH_NAME") = value
            End Set
        End Property
#End Region

#Region "CONTACT_TEL 聯絡電話"
        ''' <summary>
        ''' CONTACT_TEL 聯絡電話
        ''' </summary>
        Public Property CONTACT_TEL As String
            Get
                Return Me.PropertyMap("CONTACT_TEL")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CONTACT_TEL") = value
            End Set
        End Property
#End Region

#Region "DEADLINE_EDATE 期限訖日"
        ''' <summary>
        ''' DEADLINE_EDATE 期限訖日
        ''' </summary>
        Public Property DEADLINE_EDATE As String
            Get
                Return Me.PropertyMap("DEADLINE_EDATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DEADLINE_EDATE") = value
            End Set
        End Property
#End Region

#Region "DEADLINE_SDATE 期限起日"
        ''' <summary>
        ''' DEADLINE_SDATE 期限起日
        ''' </summary>
        Public Property DEADLINE_SDATE As String
            Get
                Return Me.PropertyMap("DEADLINE_SDATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DEADLINE_SDATE") = value
            End Set
        End Property
#End Region

#Region "DEFAULT_NUM 預設筆數"
        ''' <summary>
        ''' DEFAULT_NUM 預設筆數
        ''' </summary>
        Public Property DEFAULT_NUM As String
            Get
                Return Me.PropertyMap("DEFAULT_NUM")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DEFAULT_NUM") = value
            End Set
        End Property
#End Region

#Region "DEP_CODE 單位代碼"
        ''' <summary>
        ''' DEP_CODE 單位代碼
        ''' </summary>
        Public Property DEP_CODE As String
            Get
                Return Me.PropertyMap("DEP_CODE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("DEP_CODE") = value
            End Set
        End Property
#End Region

#Region "EMAIL 電子信箱"
        ''' <summary>
        ''' EMAIL 電子信箱
        ''' </summary>
        Public Property EMAIL As String
            Get
                Return Me.PropertyMap("EMAIL")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("EMAIL") = value
            End Set
        End Property
#End Region

#Region "ERROR_TIMES 錯誤次數"
        ''' <summary>
        ''' ERROR_TIMES 錯誤次數
        ''' </summary>
        Public Property ERROR_TIMES As String
            Get
                Return Me.PropertyMap("ERROR_TIMES")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ERROR_TIMES") = value
            End Set
        End Property
#End Region

#Region "FONT_SIZE 字型大小"
        ''' <summary>
        ''' FONT_SIZE 字型大小
        ''' </summary>
        Public Property FONT_SIZE As String
            Get
                Return Me.PropertyMap("FONT_SIZE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("FONT_SIZE") = value
            End Set
        End Property
#End Region

#Region "IS_CHANG 是否變更"
        ''' <summary>
        ''' IS_CHANG 是否變更
        ''' </summary>
        Public Property IS_CHANG As String
            Get
                Return Me.PropertyMap("IS_CHANG")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IS_CHANG") = value
            End Set
        End Property
#End Region

#Region "MENU_STYLE 選單樣式"
        ''' <summary>
        ''' MENU_STYLE 選單樣式
        ''' </summary>
        Public Property MENU_STYLE As String
            Get
                Return Me.PropertyMap("MENU_STYLE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("MENU_STYLE") = value
            End Set
        End Property
#End Region

#Region "NO 號碼"
        ''' <summary>
        ''' NO 號碼
        ''' </summary>
        Public Property NO As String
            Get
                Return Me.PropertyMap("NO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("NO") = value
            End Set
        End Property
#End Region

#Region "PERSON_TYPE 人員類別"
        ''' <summary>
        ''' PERSON_TYPE 人員類別
        ''' </summary>
        Public Property PERSON_TYPE As String
            Get
                Return Me.PropertyMap("PERSON_TYPE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PERSON_TYPE") = value
            End Set
        End Property
#End Region

#Region "PW 密碼"
        ''' <summary>
        ''' PW 密碼
        ''' </summary>
        Public Property PW As String
            Get
                Return Me.PropertyMap("PW")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PW") = value
            End Set
        End Property
#End Region

#Region "PW_UPD_DATE 密碼修改日期"
        ''' <summary>
        ''' PW_UPD_DATE 密碼修改日期
        ''' </summary>
        Public Property PW_UPD_DATE As String
            Get
                Return Me.PropertyMap("PW_UPD_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PW_UPD_DATE") = value
            End Set
        End Property
#End Region

#Region "TYPE_CODE 類別代碼"
        ''' <summary>
        ''' TYPE_CODE 類別代碼
        ''' </summary>
        Public Property TYPE_CODE As String
            Get
                Return Me.PropertyMap("TYPE_CODE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TYPE_CODE") = value
            End Set
        End Property
#End Region

#Region "USE_STATE 使用狀態"
        ''' <summary>
        ''' USE_STATE 使用狀態
        ''' </summary>
        Public Property USE_STATE As String
            Get
                Return Me.PropertyMap("USE_STATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("USE_STATE") = value
            End Set
        End Property
#End Region

#Region "EntPerson 人員主檔ENT"
        ''' <summary>
        ''' EntPerson 人員主檔ENT
        ''' </summary>
        Private Property EntPerson() As EntPerson
            Get
                Return Me.PropertyMap("EntPerson")
            End Get
            Set(ByVal value As EntPerson)
                Me.PropertyMap("EntPerson") = value
            End Set
        End Property
#End Region

#Region "EntPOSCode 人員代碼檔"
        ''' <summary>
        ''' EntPOSCode 人員代碼檔
        ''' </summary>
        Private Property EntPOSCode() As EntPOSCode
            Get
                Return Me.PropertyMap("EntPOSCode")
            End Get
            Set(ByVal value As EntPOSCode)
                Me.PropertyMap("EntPOSCode") = value
            End Set
        End Property
#End Region

#Region "EntLoginData 登入資訊ENT"
        ''' <summary>
        ''' EntLoginData 登入資訊ENT
        ''' </summary>
        Private Property EntLoginData() As EntLoginData
            Get
                Return Me.PropertyMap("EntLoginData")
            End Get
            Set(ByVal value As EntLoginData)
                Me.PropertyMap("EntLoginData") = value
            End Set
        End Property
#End Region

#Region "EntPasswordHis 密碼歷史檔ENT"
        ''' <summary>
        ''' EntPasswordHis 密碼歷史檔ENT
        ''' </summary>
        Private Property EntPasswordHis() As EntPasswordHis
            Get
                Return Me.PropertyMap("EntPasswordHis")
            End Get
            Set(ByVal value As EntPasswordHis)
                Me.PropertyMap("EntPasswordHis") = value
            End Set
        End Property
#End Region

#Region "QUERY_COND 查詢條件"
        ''' <summary>
        ''' QUERY_COND 查詢條件
        ''' </summary>
        Public Property QUERY_COND() As String
            Get
                Return Me.PropertyMap("QUERY_COND")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("QUERY_COND") = value
            End Set
        End Property
#End Region

#Region "IS_ALL 全部執照"
        ''' <summary>
        ''' IS_ALL 全部執照
        ''' </summary>
        Public Property IS_ALL As String
            Get
                Return Me.PropertyMap("IS_ALL")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IS_ALL") = value
            End Set
        End Property
#End Region

#Region "LICENSE_NO_DATA 執照號碼"
        ''' <summary>
        ''' LICENSE_NO_DATA 執照號碼
        ''' </summary>
        Public Property LICENSE_NO_DATA As String
            Get
                Return Me.PropertyMap("LICENSE_NO_DATA")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("LICENSE_NO_DATA") = value
            End Set
        End Property
#End Region

#Region "APPR_ENABLE_TIME "
        '' <summary>
        '' 認證期限 
        '' </summary>
        Public Property APPR_ENABLE_TIME() As String
            Get
                Return Me.PropertyMap("APPR_ENABLE_TIME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("APPR_ENABLE_TIME") = value
            End Set
        End Property
#End Region
#End Region

#Region "建構子"
        ''' <summary>
        ''' 建構子
        ''' </summary>
        ''' <param name="dbManager">dbManager 物件</param>
        ''' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)

            '=== 關聯 Class ===
            Me.EntPerson = New EntPerson(Me.DBManager, Me.LogUtil)
            Me.EntPOSCode = New EntPOSCode(Me.DBManager, Me.LogUtil)
            Me.EntLoginData = New EntLoginData(Me.DBManager, Me.LogUtil)
            Me.EntPasswordHis = New EntPasswordHis(Me.DBManager, Me.LogUtil)
        End Sub
#End Region

#Region "方法"
#Region "UpdatePerson 更新人員主檔"
        ''' <summary>
        ''' 更新人員主檔 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function UpdatePerson() As Integer
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'EntPerson = new EntPerson()
                '組合查詢字串(EntPerson.QUERY_COND(查詢條件),"=",PKNO(Pkno),ACNT(帳號))
                'return EntPerson.Update()

                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)   'PKNO
                Me.ProcessQueryCondition(condition, "=", "ACNT", Me.ACNT)   'ACNT
                Me.EntPerson.SqlRetrictions = Me.ProcessCondition(condition.ToString)

                Me.EntPerson.PERSON_TYPE = Me.PERSON_TYPE
                Me.EntPerson.CH_NAME = Me.CH_NAME
                Me.EntPerson.DEP_CODE = Me.DEP_CODE
                Me.EntPerson.EMAIL = Me.EMAIL
                Me.EntPerson.CONTACT_TEL = Me.CONTACT_TEL
                Me.EntPerson.DEADLINE_SDATE = Me.DEADLINE_SDATE
                Me.EntPerson.DEADLINE_EDATE = Me.DEADLINE_EDATE
                Me.EntPerson.USE_STATE = Me.USE_STATE
                Me.EntPerson.FONT_SIZE = Me.FONT_SIZE
                Me.EntPerson.MENU_STYLE = Me.MENU_STYLE
                Me.EntPerson.DEFAULT_NUM = Me.DEFAULT_NUM

                Me.EntPerson.IS_ALL = Me.IS_ALL
                Me.EntPerson.LICENSE_NO_DATA = Me.LICENSE_NO_DATA
                Me.EntPerson.APPR_ENABLE_TIME = Me.APPR_ENABLE_TIME
                Dim result As Integer = Me.EntPerson.Update()

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "AddPerson 新增人員主檔"
        ''' <summary>
        ''' 新增人員主檔 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub AddPerson()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'EntPerson = new EntPerson()
                'return EntPerson.Insert()
                Me.EntPerson.ACNT = Me.ACNT
                Me.EntPerson.PERSON_TYPE = Me.PERSON_TYPE
                Me.EntPerson.CH_NAME = Me.CH_NAME
                Me.EntPerson.DEP_CODE = Me.DEP_CODE
                Me.EntPerson.EMAIL = Me.EMAIL
                Me.EntPerson.CONTACT_TEL = Me.CONTACT_TEL
                Me.EntPerson.DEADLINE_SDATE = Me.DEADLINE_SDATE
                Me.EntPerson.DEADLINE_EDATE = Me.DEADLINE_EDATE
                Me.EntPerson.USE_STATE = Me.USE_STATE
                Me.EntPerson.FONT_SIZE = Me.FONT_SIZE
                Me.EntPerson.MENU_STYLE = Me.MENU_STYLE
                Me.EntPerson.DEFAULT_NUM = Me.DEFAULT_NUM
                Me.EntPerson.IS_ALL = Me.IS_ALL
                Me.EntPerson.LICENSE_NO_DATA = Me.LICENSE_NO_DATA
                Me.EntPerson.APPR_ENABLE_TIME = Me.APPR_ENABLE_TIME
                Me.EntPerson.Insert()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "GetPerson 取得人員主檔"
        ''' <summary>
        ''' 取得人員主檔 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetPerson() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'EntPerson = new EntPerson()
                'return EntPerson.GetPerson_取得人員主檔

                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PERSON_TYPE", Me.PERSON_TYPE)   'PERSON_TYPE
                Me.ProcessQueryCondition(condition, "=", "DEP_CODE", Me.DEP_CODE)   'DEP_CODE

                If Not String.IsNullOrEmpty(Me.CH_NAME) Then
                    condition.Append(" AND $.CH_NAME LIKE N'%" & Me.CH_NAME & "%' ")
                End If

                'Me.ProcessQueryCondition(condition, "=", "ACNT", Me.ACNT)   'ACNT
                Me.ProcessQueryCondition(condition, "%LIKE%", "ACNT", Me.ACNT)   'ACNT 2014/03/17 Kevin Yu Revised
                Me.ProcessQueryCondition(condition, "=", "USE_STATE", Me.USE_STATE)   'USE_STATE

                If Not String.IsNullOrEmpty(Me.PKNO) Then
                    condition.Append(" AND $.PKNO IN ('" & Me.PKNO.Replace(",", "','") & "') ")
                End If

                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)

                Me.EntPerson.SqlRetrictions = condition.ToString()
                Me.EntPerson.OrderBys = Me.OrderBys
                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.EntPerson.GetPerson()
                Else
                    result = Me.EntPerson.GetPerson(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.EntPerson.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "ChkUserId 確認使用者帳號"
        ''' <summary>
        ''' 確認使用者帳號 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function ChkUserId() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If

                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "ACNT", Me.ACNT)   'ACNT

                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)

                Me.EntPerson.SqlRetrictions = condition.ToString()
                Me.EntPerson.OrderBys = Me.OrderBys
                '=== 處理取得回傳資料===
                Dim result As DataTable
                result = Me.EntPerson.GetPerson()
                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "DeletePerson 刪除人員主檔"
        ''' <summary>
        ''' 刪除人員主檔 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function DeletePerson() As Integer
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'EntPerson = new EntPerson()
                '組合查詢字串(EntPerson.QUERY_COND(查詢條件),"=",PKNO(Pkno),ACNT(帳號))
                'return EntPerson.Delete()

                '=== 處理查詢條件 ===
                DeleteValidation()

                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)   'PKNO
                Me.ProcessQueryCondition(condition, "=", "ACNT", Me.ACNT)   'ACNT
                Me.EntPerson.SqlRetrictions = Me.ProcessCondition(condition.ToString)

                Dim result As Integer = Me.EntPerson.Delete()

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "AddLoginData 新增登入資訊"
        ''' <summary>
        ''' 新增登入資訊 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub AddLoginData()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'EntLoginData = new EntLoginData()
                'return EntLoginData.Insert()

                Me.EntLoginData.ACNT = Me.ACNT
                Me.EntLoginData.PW = Me.PW
                Me.EntLoginData.PERSON_TYPE = Me.PERSON_TYPE
                Me.EntLoginData.IS_CHANG = Me.IS_CHANG
                Me.EntLoginData.ERROR_TIMES = Me.ERROR_TIMES
                Me.EntLoginData.PW_UPD_DATE = Me.PW_UPD_DATE
                Me.EntLoginData.Insert()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "UpdateLoginData 更新登入資訊"
        ''' <summary>
        ''' 更新登入資訊 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function UpdateLoginData() As Integer
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'EntLoginData = new EntLoginData()
                '組合查詢字串(EntLoginData.QUERY_COND(查詢條件),"=",PKNO(Pkno),ACNT(帳號))
                'return EntLoginData.Update()

                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)   'PKNO
                Me.ProcessQueryCondition(condition, "=", "ACNT", Me.ACNT)   'ACNT
                Me.EntLoginData.SqlRetrictions = Me.ProcessCondition(condition.ToString)

                Me.EntLoginData.PW = Me.PW
                Me.EntLoginData.PERSON_TYPE = Me.PERSON_TYPE
                Me.EntLoginData.IS_CHANG = Me.IS_CHANG
                Me.EntLoginData.ERROR_TIMES = Me.ERROR_TIMES
                Me.EntLoginData.PW_UPD_DATE = Me.PW_UPD_DATE

                Dim result As Integer = Me.EntLoginData.Update()

                Me.ResetColumnProperty()

                Return result

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetLoginData 取得登入資訊"
        ''' <summary>
        ''' 取得登入資訊 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub GetLoginData()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'EntLoginData = new EntLoginData()
                '組合查詢字串(EntLoginData.QUERY_COND(查詢條件),"=",PKNO(Pkno),ACNT(帳號))
                'return EntLoginData.Query()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "DeleteLoginData 刪除登入資訊"
        ''' <summary>
        ''' 刪除登入資訊 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function DeleteLoginData() As Integer
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'EntLoginData = new EntLoginData()
                '組合查詢字串(EntLoginData.QUERY_COND(查詢條件),"=",PKNO(Pkno),ACNT(帳號))
                'return EntLoginData.Delete()

                '=== 處理查詢條件 ===
                DeleteValidation()

                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)   'PKNO
                Me.ProcessQueryCondition(condition, "=", "ACNT", Me.ACNT)   'ACNT
                Me.EntLoginData.SqlRetrictions = Me.ProcessCondition(condition.ToString)

                Dim result As Integer = Me.EntLoginData.Delete()

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function

        Private Sub DeleteValidation()
            Dim pknoNull As Boolean = False
            Dim acntNull As Boolean = False

            If Me.PKNO Is Nothing And Me.ACNT Is Nothing Then
                Throw New Exception("Delete時，PKNO與ACNT不能同時為空值")
            End If

            If Me.PKNO IsNot Nothing Then
                If Me.PKNO.Length = 0 Then
                    pknoNull = True
                End If
            Else
                pknoNull = True
            End If

            If Me.ACNT IsNot Nothing Then
                If Me.ACNT.Length = 0 Then
                    acntNull = True
                End If
            Else
                acntNull = True
            End If

            If pknoNull = True And acntNull = True Then
                Throw New Exception("Delete時，PKNO與ACNT不能同時為空值")
            End If

        End Sub

#End Region

#Region "AddPasswordHis 新增密碼歷史檔"
        ''' <summary>
        ''' 新增密碼歷史檔 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub AddPasswordHis()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'EntPasswordHis = new EntPasswordHis()
                'return EntPasswordHis.Insert()

                Me.EntPasswordHis.ACNT = Me.ACNT
                Me.EntPasswordHis.PW = Me.PW
                Me.EntPasswordHis.PERSON_TYPE = Me.PERSON_TYPE
                Me.EntPasswordHis.PW_UPD_DATE = Me.PW_UPD_DATE
                Me.EntPasswordHis.Insert()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "GetPasswordHis 取得密碼歷史檔"
        ''' <summary>
        ''' 取得密碼歷史檔 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetPasswordHis() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'EntPasswordHis = new EntPasswordHis()
                '組合查詢字串(EntLoginData.QUERY_COND(查詢條件),"=",PKNO(Pkno),ACNT(帳號),PW(密碼))
                'return EntPasswordHis.Query() //order by PW_UPD_DATE(密碼修改日期)
                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)   'PKNO
                Me.ProcessQueryCondition(condition, "=", "ACNT", Me.ACNT)   'ACNT
                Me.ProcessQueryCondition(condition, "=", "PW", Me.PW)   'PW
                Me.EntPasswordHis.SqlRetrictions = condition.ToString()
                Me.EntPasswordHis.OrderBys = "PW_UPD_DATE"
                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.EntPasswordHis.Query()
                Else
                    result = Me.EntPasswordHis.Query(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.EntPasswordHis.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "DeletePasswordHis 刪除密碼歷史檔"
        ''' <summary>
        ''' 刪除密碼歷史檔 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function DeletePasswordHis() As Integer
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'EntPasswordHis = new EntPasswordHis()
                '組合查詢字串(EntLoginData.QUERY_COND(查詢條件),"=",PKNO(Pkno),ACNT(帳號),PW(密碼))
                'return EntPasswordHis.Delete() //刪除第一筆,時間最早的那一筆

                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)   'PKNO
                Me.ProcessQueryCondition(condition, "=", "ACNT", Me.ACNT)   'ACNT
                Me.ProcessQueryCondition(condition, "=", "PW", Me.PW)   'PW
                Me.EntPasswordHis.SqlRetrictions = Me.ProcessCondition(condition.ToString)
                Me.EntPasswordHis.OrderBys = "PW_UPD_DATE"
                Dim dt As DataTable = Me.EntPasswordHis.Query()

                Dim result As Integer = 0
                If dt.Rows.Count > 0 Then
                    Me.EntPasswordHis.PKNO = dt.Rows(0)("PKNO").ToString
                    result = Me.EntPasswordHis.DeleteByPkNo()
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "DeleteAllPasswordHis 刪除所有密碼歷史檔"
        ''' <summary>
        ''' 刪除所有密碼歷史檔 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function DeleteAllPasswordHis() As Integer
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'EntPasswordHis = new EntPasswordHis()
                '組合查詢字串(EntLoginData.QUERY_COND(查詢條件),"=",PKNO(Pkno),ACNT(帳號),PW(密碼))
                'return EntPasswordHis.Delete() //刪除第一筆,時間最早的那一筆

                '=== 處理查詢條件 ===
                DeleteValidation()

                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)   'PKNO
                Me.ProcessQueryCondition(condition, "=", "ACNT", Me.ACNT)   'ACNT
                Me.ProcessQueryCondition(condition, "=", "PW", Me.PW)   'PW
                Me.EntPasswordHis.SqlRetrictions = Me.ProcessCondition(condition.ToString)

                Dim result As Integer = Me.EntPasswordHis.Delete()

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetPOSCodeData 取得人員代碼資料"
        ''' <summary>
        ''' 取得人員代碼資料 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetPOSCodeData() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'EntPOSCode = new EntPOSCode()
                'return EntPOSCode.GetPOSCodeData_取得人員代碼資料()

                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "TYPE_CODE", Me.TYPE_CODE)   'TYPE_CODE
                Me.ProcessQueryCondition(condition, "=", "NO", Me.NO)   'NO
                Me.ProcessQueryCondition(condition, "=", "USE_STATE", Me.USE_STATE)   'USE_STATE
                Me.ProcessQueryCondition(condition, "=", "PKNO", Me.PKNO)   'PKNO

                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)

                Me.EntPOSCode.SqlRetrictions = condition.ToString()
                Me.EntPOSCode.OrderBys = Me.OrderBys
                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.EntPOSCode.GetPOSCodeData()
                Else
                    result = Me.EntPOSCode.GetPOSCodeData(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.EntPOSCode.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "GetDepCodeDDL 取得單位代碼下拉"
        ''' <summary>
        ''' 取得單位代碼下拉 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function GetDepCodeDDL() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'EntPOSCode = new EntPOSCode()
                'return EntPOSCode.GetDepCodeDDL_取得單位代碼下拉()

                '=== 處理查詢條件 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PERSON_TYPE", Me.PERSON_TYPE)   'PERSON_TYPE
                Me.ProcessQueryCondition(condition, "=", "DEP_CODE", Me.DEP_CODE)   'DEP_CODE
                Me.ProcessQueryCondition(condition, "=", "USE_STATE", Me.USE_STATE)   'USE_STATE

                '特殊條件 OR 自定條件
                condition.Append(Me.QUERY_COND)

                Me.EntPOSCode.SqlRetrictions = condition.ToString()
                Me.EntPOSCode.OrderBys = Me.OrderBys
                '=== 處理取得回傳資料===
                Dim result As DataTable
                If Me.PageNo = 0 Then
                    result = Me.EntPOSCode.GetDepCodeDDL()
                Else
                    result = Me.EntPOSCode.GetDepCodeDDL(Me.PageNo, Me.PageSize)
                    Me.TotalRowCount = Me.EntPOSCode.TotalRowCount
                End If

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region


#End Region
    End Class
End Namespace

